using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DotSpatial.Projections;
using SharpMap.Data;
using bv.common.db.Core;
using SharpMap.Data.Providers;
using SharpMap.Geometries;
using GIS_V4.Data;
using bv.model.BLToolkit;
using eidss.gis.Utils;

namespace eidss.gis.Data.Providers
{

    public class EidssSqlServer2008 : SqlServer2008, IExtendedExport
    {
        private static readonly string m_ConnectionString = ConnectionManager.DefaultInstance.ConnectionString;
        private const string m_GeomFieldName = "geomShape";
        private const string m_OidFieldName = "idfsGeoObject";


        public EidssSqlServer2008(string tableName)
            : base(m_ConnectionString, tableName, m_GeomFieldName, m_OidFieldName)
        {
            SRID = 3857;
        }

        public EidssSqlServer2008(string tableName, SqlServerSpatialObjectType spatType)
            : base(m_ConnectionString, tableName, m_GeomFieldName, m_OidFieldName, spatType)
        {
            SRID = 3857;
        }

        public Geometry GetGeometryByID(long oid)
        {
            Geometry geom = null;
            using (var conn = new SqlConnection(m_ConnectionString))
            {
                var strSQL = string.Format("SELECT TOP 1 {0}.STAsBinary() FROM {1} WHERE {2} = '{3}' AND {0} IS NOT NULL",
                                           GeometryColumn, Table, ObjectIdColumn, oid);
                conn.Open();
                using (var command = new SqlCommand(strSQL, conn))
                {
                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr[0] != DBNull.Value)
                                geom = SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[])dr[0]);
                        }
                    }
                }
                conn.Close();
            }
            return geom;
        }

        public override BoundingBox GetExtents()
        {
            return new BoundingBox(-20037508, -20037508, 20037508, 20037508);
        }


        //It is butifule :)
        public FeatureDataSet GetAllFeatures()
        {
            if (!SystemLayerNames.IsSystemLayerName(Table))
            {
                var fds = new FeatureDataSet();
                var bbox = GetExtents();
                bbox = bbox.Grow(bbox.Width / 1000);
                ExecuteIntersectionQuery(bbox, fds);
                return fds;
            }
            else
            {
                var fds = new FeatureDataSet();

                //get langs codes
                long langCode = TranslationCache.GetLanguageCode(bv.model.Model.Core.ModelUserContext.CurrentLanguage,
                                                                 ConnectionString);
                long enLangCode = TranslationCache.GetLanguageCode("en", ConnectionString);

                string strSQL = string.Empty;
                string makeValid = ValidateGeometries ? ".MakeValid()" : String.Empty;

                //construct query
                switch (Table)
                {
                    case SystemLayerNames.Countries:
                    case SystemLayerNames.Regions:
                        strSQL = String.Format(
                            @"SELECT g.*,
	                          g.{0}{1}.STAsBinary() AS sharpmap_tempgeometry,
    	                      TR_en.strTextString as 'name_en',
	                          TR.strTextString as 'name'
                              FROM {2} g
                              LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {3}) TR_en on g.{5}=TR_en.idfsGISBaseReference
                              LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {4}) TR on g.{5}=TR.idfsGISBaseReference",
                            GeometryColumn, makeValid, Table, enLangCode, langCode, ObjectIdColumn);
                            break;
                    
                    case SystemLayerNames.Rayons:
                        strSQL = String.Format(
                                @"SELECT g.*,
	                            g.{0}{1}.STAsBinary() AS sharpmap_tempgeometry,
	                            TR_en.strTextString as 'name_en',
	                            TR.strTextString as 'name',
	                            g_spr.idfsRegion as 'region_id',
	                            TR_par_en.strTextString as 'region_en', 
	                            TR_par.strTextString as 'region_name'
                                FROM {2} g
                                LEFT JOIN gisRayon	g_spr on g.{5}=g_spr.idfsRayon
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {3}) TR_en on g.{5}=TR_en.idfsGISBaseReference
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {4}) TR on g.{5}=TR.idfsGISBaseReference
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {3}) TR_par_en on g_spr.idfsRegion=TR_par_en.idfsGISBaseReference
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {4}) TR_par on g_spr.idfsRegion=TR_par.idfsGISBaseReference",
                            GeometryColumn, makeValid, Table, enLangCode, langCode, ObjectIdColumn);
                        break;
                    case SystemLayerNames.Settlements:
                        strSQL = String.Format(
                                @"SELECT g.*,
	                            g.{0}{1}.STAsBinary() AS sharpmap_tempgeometry,
	                            TR_en.strTextString as 'name_en',
	                            TR.strTextString as 'name',
	                            g_spr.idfsRayon as 'rayon_id',
	                            TR_par_en.strTextString as 'rayon_en', 
	                            TR_par.strTextString as 'rayon_name'
                                FROM {2} g
                                LEFT JOIN gisSettlement	g_spr on g.{5}=g_spr.idfsSettlement
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {3}) TR_en on g.{5}=TR_en.idfsGISBaseReference
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {4}) TR on g.{5}=TR.idfsGISBaseReference
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {3}) TR_par_en on g_spr.idfsRayon=TR_par_en.idfsGISBaseReference
                                LEFT JOIN (SELECT * FROM gisStringNameTranslation WHERE idfsLanguage = {4}) TR_par on g_spr.idfsRayon=TR_par.idfsGISBaseReference",
                            GeometryColumn, makeValid, Table, enLangCode, langCode, ObjectIdColumn);
                        break;
                    default:
                        strSQL = String.Format(@"SELECT g.*, g.{0}{1}.STAsBinary() AS sharpmap_tempgeometry FROM {2} g",
                                GeometryColumn, makeValid, Table);
                        break;
                }



                using (var conn = new SqlConnection(ConnectionString))
                {
                    

                    if (!String.IsNullOrEmpty(DefinitionQuery))
                        strSQL += (" AND " + DefinitionQuery);

                    using (var adapter = new SqlDataAdapter(strSQL, conn))
                    {
                        conn.Open();
                        var ds2 = new DataSet();
                        adapter.Fill(ds2);
                        conn.Close();
                        if (ds2.Tables.Count > 0)
                        {
                            var fdt = new FeatureDataTable(ds2.Tables[0]);
                            foreach (DataColumn col in ds2.Tables[0].Columns)
                                if (col.ColumnName != GeometryColumn && col.ColumnName != "sharpmap_tempgeometry")
                                    fdt.Columns.Add(col.ColumnName, col.DataType, col.Expression);

                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                var fdr = fdt.NewRow();
                                foreach (DataColumn col in ds2.Tables[0].Columns)
                                    if (col.ColumnName != GeometryColumn && col.ColumnName != "sharpmap_tempgeometry")
                                        fdr[col.ColumnName] = dr[col];
                                fdr.Geometry =
                                    SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse(
                                        (byte[]) dr["sharpmap_tempgeometry"]);
                                fdt.AddRow(fdr);
                            }
                            fds.Tables.Add(fdt);
                        }
                    }
                }
                return fds;
            }
        }

        //public FeatureDataSet GetAllFeatures()
        //{
        //    //get all
        //    var fds = new FeatureDataSet();
        //    var bbox = GetExtents();
        //    bbox = bbox.Grow(bbox.Width / 1000);
        //    ExecuteIntersectionQuery(bbox, fds);

        //    //if system layer - add labels, parent id and parent label
        //    if (SystemLayerNames.IsSystemLayerName(Table))
        //    {
        //        //add extended fields
        //        fds.Tables[0].Columns.Add("name_en", typeof (string));
        //        fds.Tables[0].Columns.Add("name", typeof(string));


        //        //get langs codes
        //        long langCode = TranslationCache.GetLanguageCode(bv.model.Model.Core.ModelUserContext.CurrentLanguage,
        //                                                 ConnectionString);
        //        long enLangCode = TranslationCache.GetLanguageCode("en", ConnectionString);


        //        using(var conn=new SqlConnection(ConnectionString))
        //        {
        //            //setup command obj
        //            conn.Open();
        //            var tempCommand = conn.CreateCommand();
        //            tempCommand .CommandType= CommandType.Text;

        //            switch (Table)
        //            {
        //                case SystemLayerNames.Countries:
        //                case SystemLayerNames.Regions:
        //                    var query_name = "SELECT strTextString FROM gisStringNameTranslation WHERE idfsGISBaseReference={0} AND idfsLanguage={1}";
        //                    for (int i = 0; i < fds.Tables[0].Rows.Count; i++)
        //                    {
        //                        var fdr = fds.Tables[0][i];
        //                        var id = (long)fdr["idfsGeoObject"];

        //                        var name_en = (string)SqlExecHelper.SqlExecScalar(conn, string.Format(query_name,id, enLangCode));
        //                        fdr["name_en"] = name_en;
        //                        var name = (string)SqlExecHelper.SqlExecScalar(conn, string.Format(query_name, id, langCode));
        //                        fdr["name"] = name;
        //                    }
        //                    break;
        //                case SystemLayerNames.Rayons:
        //                    fds.Tables[0].Columns.Add("region_id", typeof (long));
        //                    fds.Tables[0].Columns.Add("region_name", typeof (string));
        //                    fds.Tables[0].Columns.Add("region_en", typeof (string));
        //                    var query_rayon = "SELECT strTextString as  FROM gisStringNameTranslation WHERE idfsGISBaseReference={0} AND idfsLanguage={1}";
        //                    for (int i = 0; i < fds.Tables[0].Rows.Count; i++)
        //                    {
        //                        var fdr = fds.Tables[0][i];
        //                        var id = (long)fdr["idfsGeoObject"];

        //                        var name_en = (string)SqlExecHelper.SqlExecScalar(conn, string.Format(query_name,id, enLangCode));
        //                        fdr["name_en"] = name_en;
        //                        var name = (string)SqlExecHelper.SqlExecScalar(conn, string.Format(query_name, id, langCode));
        //                        fdr["name"] = name;
        //                    }
        //                    break;
        //                case SystemLayerNames.Settlements:
        //                    fds.Tables[0].Columns.Add("rayon_id", typeof (long));
        //                    fds.Tables[0].Columns.Add("rayon_name", typeof (string));
        //                    fds.Tables[0].Columns.Add("rayon_en", typeof (string));

        //                    break;

        //                default:
        //                    break;
        //            }
        //            conn.Close();
        //        }

        //    }
        //    return fds;
        //}

    }
}
