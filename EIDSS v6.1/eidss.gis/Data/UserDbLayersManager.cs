using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using bv.common.db.Core;
using eidss.gis.Layers;
using eidss.gis.Properties;
using eidss.model.Core;
using GIS_V4.Serializers.StyleSerializers;
using GIS_V4.Serializers.ThemeSerializers;
using SharpMap.Rendering.Thematics;
using SharpMap.Styles;

namespace eidss.gis.Data
{
    /// <summary>
    /// Type of user layer in db
    /// </summary>
    public enum UserDbLayerType
    {
        None = 0,
        Imported = 1,
        Avr = 2,
        BuffZones =3
    }

    /// <summary>
    /// Buffer zones pivot layer type
    /// </summary>
    public enum PivotLayerType
    {
        None = 0,
        AvrPoints = 1,
        Settlements = 2,
        Districts = 3,
        Regions = 4
    }

    /// <summary>
    /// Information about user layer in db
    /// </summary>
    public struct UserDbLayerInfo
    {
        public Guid m_Id;
        public string m_Name;
        public long m_UserId; 
        public DateTime m_CreationDate;
        public DateTime m_LastModifiedDate;
        public UserDbLayerType m_LayerType;
        public VectorStyle m_Style;
        public ITheme m_Theme;
        public string m_Description;
        public PivotLayerType m_PivotalLayer;

        public override string ToString()
        {
            return m_Name;
        }
    }

    public static class UserDbLayersManager
    {
        internal const string UserTablePrefix = "Usr";
        internal const string GisDbShema = "gis";

        public static event EventHandler UserLayersListChanged;

        public static string ConnectionString
        {
            get { return ConnectionManager.DefaultInstance.ConnectionString; }
        }

        #region UserLayers Names, metadata, layers
        
        public static IDictionary<Guid, String> GetLayersNames(UserDbLayerType userDbLayerType = UserDbLayerType.None)
        {
            var names = new Dictionary<Guid, string>();
            var query = "SELECT guidLayer, strName FROM gisUserLayer WHERE intDeleted=0";
            if (userDbLayerType != UserDbLayerType.None)
                query += string.Format(" AND intType={0}", (int) userDbLayerType);
            var dt = SqlExecHelper.SqlExecTable(new SqlConnection(ConnectionString), query);
            foreach (DataRow row in dt.Rows)
                names.Add((Guid)row[0], (String)row[1]);
            return names;
        }

        public static UserDbLayerInfo GetLayerMetadata(Guid layerId)
        {
            var query = string.Format("SELECT * FROM gisUserLayer WHERE guidLayer='{0}'",layerId);
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var dataReader = SqlExecHelper.SqlExecReader(conn, query);
                if (!dataReader.HasRows)
                    throw new ApplicationException(Resources.gis_UserDbLayersManager_GetLayerMetadataException + layerId);
                dataReader.Read();


                var style = new VectorStyle();
                if (dataReader["xmlStyle"] != DBNull.Value && !string.IsNullOrEmpty(dataReader["xmlStyle"] as string))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml((string) dataReader["xmlStyle"]);
                    style = StyleSerializer.DeserializeFromDocument(doc) as VectorStyle;
                }

                ITheme theme = null;
                if (dataReader["xmlTheme"] != DBNull.Value && !string.IsNullOrEmpty(dataReader["xmlTheme"] as string))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml((string) dataReader["xmlTheme"]);
                    theme = ThemeSerializer.DeserializeFromDocument(doc);
                }

                return new UserDbLayerInfo
                           {
                               m_Id = (Guid) dataReader["guidLayer"],
                               m_Name = (String) dataReader["strName"],
                               m_UserId = (long) dataReader["idfUser"],
                               m_CreationDate = (DateTime) dataReader["CreationDate"],
                               m_LastModifiedDate = (DateTime) dataReader["LastModifiedDate"],
                               m_Description = dataReader["strDescription"] as string,
                               m_LayerType = (UserDbLayerType) dataReader["intType"],
                               m_PivotalLayer = (PivotLayerType) dataReader["intPivotalLayer"],
                               m_Style = style,
                               m_Theme = theme
                           };
            }

        }

        public static List<UserDbLayerInfo> GetLayersMetadates(UserDbLayerType userDbLayerType = UserDbLayerType.None)
        {
            var infos = new List<UserDbLayerInfo>();
            var query = string.Format("SELECT * FROM gisUserLayer WHERE intDeleted=0");
            if (userDbLayerType != UserDbLayerType.None)
                query += string.Format(" AND intType={0}", (int)userDbLayerType);
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var dt = SqlExecHelper.SqlExecTable(new SqlConnection(ConnectionString), query);
                foreach (DataRow row in dt.Rows)
                {

                    var style = new VectorStyle();
                    if (row["xmlStyle"] != DBNull.Value &&
                        !string.IsNullOrEmpty(row["xmlStyle"] as string))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml((string)row["xmlStyle"]);
                        style = StyleSerializer.DeserializeFromDocument(doc) as VectorStyle;
                    }

                    ITheme theme = null;
                    if (row["xmlTheme"] != DBNull.Value &&
                        !string.IsNullOrEmpty(row["xmlTheme"] as string))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml((string)row["xmlTheme"]);
                        theme = ThemeSerializer.DeserializeFromDocument(doc);
                    }

                    infos.Add(new UserDbLayerInfo
                                  {
                                   m_Id = (Guid)row["guidLayer"],
                                   m_Name = (String)row["strName"],
                                   m_UserId = (long)row["idfUser"],
                                   m_CreationDate = (DateTime)row["CreationDate"],
                                   m_LastModifiedDate = (DateTime)row["LastModifiedDate"],
                                   m_Description = row["strDescription"] as string,
                                   m_LayerType = (UserDbLayerType)row["intType"],
                                   m_PivotalLayer = (PivotLayerType)row["intPivotalLayer"],
                                   m_Style = style,
                                   m_Theme = theme
                               });
                }
                return infos;
            }

        }

        public static EidssUserDbLayer GetUserLayer(Guid layerId)
        {
            UserDbLayerInfo info = GetLayerMetadata(layerId);
            switch (info.m_LayerType)
            {
                case UserDbLayerType.BuffZones:
                    return new EidssUserBufZoneLayer(info.m_Id, info.m_Name);
                default:
                    throw new NotImplementedException();
            }
        }

        public static void DropUserLayer(Guid layerId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction("Create buff zones layer");

                //Drop metadata
                RemoveUserLayerMetadata(layerId); //TODO: maybe need add 'delete' field?

                //remove user layer table in db
                var tableName = UserTablePrefix + layerId.ToString("N");
                //TableCreator.DropTable(conn, tableName);

                //trans.Commit();
                conn.Close();
            }

            if (UserLayersListChanged != null)
                UserLayersListChanged(null, EventArgs.Empty);
        }

        #endregion

        #region BufZone
        //BufferZoneColumns
        
        public static EidssUserBufZoneLayer CreateBufZoneLayer(string name, string desc, PivotLayerType pivotLayerType)
        {
            
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction("Create buff zones layer");
                
                //create new metadata
                var layerInfo = new UserDbLayerInfo();
                layerInfo.m_Id = Guid.NewGuid();
                layerInfo.m_LayerType = UserDbLayerType.BuffZones;
                layerInfo.m_Name = name;
                layerInfo.m_Description = desc;
                layerInfo.m_UserId = (long)EidssUserContext.User.ID;
                layerInfo.m_PivotalLayer = pivotLayerType;

                InsertUserLayerMetadata(layerInfo); //, conn, trans);

                //create new user layer table in db
                var addtionalColumns = new List<DataColumn>();
                addtionalColumns.Add(new DataColumn("strName", typeof(string)));
                addtionalColumns.Add(new DataColumn("strDescription", typeof(string)));
                addtionalColumns.Add(new DataColumn("dblRadius", typeof(double)));
                addtionalColumns.Add(new DataColumn("dblCenterX", typeof(double)));
                addtionalColumns.Add(new DataColumn("dblCenterY", typeof(double)));
                
                var deleted = new DataColumn("intDeleted", typeof(int));
                deleted.DefaultValue = 0;
                deleted.AllowDBNull = false;
                addtionalColumns.Add(deleted);


                var tableName = UserTablePrefix + layerInfo.m_Id.ToString("N");

                TableCreator.CreateGeomTable(conn, tableName, addtionalColumns, GisDbShema);

                if (UserLayersListChanged != null)
                    UserLayersListChanged(null, EventArgs.Empty);

                return GetUserLayer(layerInfo.m_Id) as EidssUserBufZoneLayer;
            }
        }

        public static void DropBufZoneLayer(Guid layerId)
        {
            DropUserLayer(layerId);
        }

        #endregion

        #region Metadata CRUD

        /// <summary>
        /// Insert new user layer metadata
        /// </summary>
        /// <param name="newLayerInfo">LayerInfo. REQUERED: Id, name, UserID, LayerType</param>
        /// <param name="conn"> </param>
        /// <param name="trans">Transaction</param>
        public static void InsertUserLayerMetadata(UserDbLayerInfo newLayerInfo, SqlConnection conn, SqlTransaction trans = null)
        {
            if (string.IsNullOrEmpty(newLayerInfo.m_Name))
                throw new ArgumentException(Resources.gis_UserDbLayersManager_InsertUserLayerMetadataException);

           

                var style = (newLayerInfo.m_Style==null)?string.Empty:StyleSerializer.SerializeAsDocument(newLayerInfo.m_Style).InnerXml;
                var theme = (newLayerInfo.m_Theme == null) ? string.Empty : ThemeSerializer.SerializeAsDocument(newLayerInfo.m_Theme).InnerXml;

                //TODO[enikulin]: make with SqlHelper
                using (var addCommand = new SqlCommand("spGisInsertUserLayerMetadata", conn, trans))
                {
                    addCommand.CommandType = CommandType.StoredProcedure;

                    addCommand.Parameters.AddWithValue("@ID", newLayerInfo.m_Id);
                    addCommand.Parameters.AddWithValue("@Name", newLayerInfo.m_Name);
                    addCommand.Parameters.AddWithValue("@UserID", newLayerInfo.m_UserId);
                    addCommand.Parameters.AddWithValue("@LayerType", (int)newLayerInfo.m_LayerType);
                    addCommand.Parameters.AddWithValue("@STYLE", style);
                    addCommand.Parameters.AddWithValue("@THEME", theme);
                    addCommand.Parameters.AddWithValue("@DESC", string.IsNullOrEmpty(newLayerInfo.m_Description) ? DBNull.Value : (object)newLayerInfo.m_Description);
                    addCommand.Parameters.AddWithValue("@PIVOTALLAYER", newLayerInfo.m_PivotalLayer);

                    addCommand.ExecuteNonQuery();
                }
        }

        /// <summary>
        /// Insert new user layer metadata
        /// </summary>
        /// <param name="newLayerInfo">LayerInfo. REQUERED: Id, name, UserID, LayerType</param>
        public static void InsertUserLayerMetadata(UserDbLayerInfo newLayerInfo)
        {
        
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                InsertUserLayerMetadata(newLayerInfo, conn);
                conn.Close();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="layerInfo"></param>
        public static void UpdateUserLayerMetadata(UserDbLayerInfo layerInfo)
        {
            if (string.IsNullOrEmpty(layerInfo.m_Name) || layerInfo.m_Id == Guid.Empty )
                throw new ArgumentException(Resources.gis_UserDbLayersManager_UpdateUserLayerMetadataException);

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var style = (layerInfo.m_Style == null) ? (Object)DBNull.Value : StyleSerializer.SerializeAsDocument(layerInfo.m_Style).InnerXml;
                var theme = (layerInfo.m_Theme == null) ? (Object)DBNull.Value : ThemeSerializer.SerializeAsDocument(layerInfo.m_Theme).InnerXml;

                using (var updCommand = new SqlCommand("spGisUpdateUserLayerMetadata", conn))
                {
                    updCommand.CommandType = CommandType.StoredProcedure;

                    updCommand.Parameters.AddWithValue("@LAYERID", layerInfo.m_Id);
                    updCommand.Parameters.AddWithValue("@Name", layerInfo.m_Name);
                    updCommand.Parameters.AddWithValue("@STYLE", style);
                    updCommand.Parameters.AddWithValue("@THEME", theme);
                    updCommand.Parameters.AddWithValue("@DESC", string.IsNullOrEmpty(layerInfo.m_Description) ? DBNull.Value : (object)layerInfo.m_Description);

                    updCommand.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        /// <summary>
        /// Delete user layer metadata
        /// </summary>
        /// <param name="layerInfo">User Layer metadata. REQUERED: valid LayerId </param>
        public static void RemoveUserLayerMetadata(UserDbLayerInfo layerInfo)
        {
            RemoveUserLayerMetadata(layerInfo.m_Id);
        }

        /// <summary>
        /// Delete user layer metadata
        /// </summary>
        /// <param name="layerId">REQUERED: valid LayerId </param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        public static void RemoveUserLayerMetadata(Guid layerId, SqlConnection conn, SqlTransaction trans = null)
        {
            
                using (var delCommand = new SqlCommand("spGisDeleteUserLayerMetadata", conn))
                {
                    delCommand.CommandType = CommandType.StoredProcedure;
                    delCommand.Parameters.AddWithValue("@LAYERID", layerId);

                    delCommand.ExecuteNonQuery();
                }
        }

        public static void RemoveUserLayerMetadata(Guid layerId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                RemoveUserLayerMetadata(layerId, conn);
                conn.Close();
            }
        }

        #endregion
    }
}
