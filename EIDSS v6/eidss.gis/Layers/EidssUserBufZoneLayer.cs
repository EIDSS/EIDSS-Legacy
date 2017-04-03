using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using eidss.gis.Data;
using eidss.gis.Data.Providers;
using SharpMap.Data;
using SharpMap.Geometries;
using Point = SharpMap.Geometries.Point;

namespace eidss.gis.Layers
{
    public class EidssUserBufZoneLayer : EidssUserDbLayer
    {
        public Color generateRandomColor(Color mix)
        {
            Random random = new Random();
            var red = random.Next(128, 256);
            var green = random.Next(128, 256);
            var blue = random.Next(128, 256);

            // mix the color
            if (mix != null)
            {
                red = (red + mix.R) / 2;
                green = (green + mix.G) / 2;
                blue = (blue + mix.B) / 2;
            }

            var color = Color.FromArgb(red, green, blue);
            return color;
        }

        private void InitDefaultStyle()
        {
            //---create style
            var bufZoneColour = generateRandomColor(Color.White); //Color.Magenta;
            Style.Outline = new Pen(Color.DarkRed, 2);
            Style.EnableOutline = true;
            
            Brush brush = new SolidBrush(bufZoneColour);
            Style.Fill = brush;
            SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //---set Transparency
            Transparency = 150;

            //LABELS!!!
            if (!(m_LabelLayer == null && LabelLayerGuid != Guid.Empty))
                LabelLayer.LabelColumn = "strName";
        }

        public EidssUserBufZoneLayer(Guid layerDbGuid, string layerName)
            : base(layerDbGuid, layerName)
        {
            InitDefaultStyle();
        }

        public EidssUserBufZoneLayer(Guid layerDbGuid, string layerName, Guid initGuid)
            : base(layerDbGuid, layerName, initGuid)
        {
            InitDefaultStyle();
        }

        public EidssUserBufZoneLayer(Guid layerDbGuid, string layerName, Guid initGuid, Guid labelLayerGuid)
            : base(layerDbGuid, layerName, initGuid, labelLayerGuid)
        {
            InitDefaultStyle();
        }


        #region Features edition

         /// <summary>
        /// Feature, stored in DB
        /// </summary>
        public struct UserBufZone
        {
            public long ID;
            public Geometry Geometry;
            public string Name;
            public string Description;
            public double Radius;
            public Point Center;
        }

        public UserBufZone FeatureRowToStruct(FeatureDataRow dataRow)
        {
            return new UserBufZone
                       {
                           ID = (long) dataRow["idfsGeoObject"],
                           Geometry = dataRow.Geometry,
                           Name = dataRow["strName"] as String,
                           Description =  dataRow["strDescription"] as String,
                           Radius = (double) dataRow["dblRadius"],
                           Center = new Point((double) dataRow["dblCenterX"], (double) dataRow["dblCenterY"])
                        };
        }


        public long AddNewZone(UserBufZone bufZone)
        {
            using (var conn = new SqlConnection((DataSource as EidssSqlServer2008).ConnectionString))
            {
                conn.Open();

                using (var addCommand = conn.CreateCommand())
                {
                    addCommand.CommandType = CommandType.Text;

                    addCommand.CommandText = string.Format(
                        @"INSERT INTO {0} 
                                (geomShape, 
                                 strName, 
                                 strDescription, 
                                 dblRadius, 
                                 dblCenterX, 
                                 dblCenterY) 
                        VALUES (geometry::STGeomFromWKB(@GeomShape, 3857), 
                                @Name, 
                                @Desc, 
                                @Radius,
                                @CenterX, 
                                @CenterY); 
                        select scope_identity()",
                        (DataSource as EidssSqlServer2008).Table);

                    var param = addCommand.Parameters.Add("@GeomShape", SqlDbType.VarBinary, Int32.MaxValue);
                    param.Value = bufZone.Geometry == null ? DBNull.Value : (object)bufZone.Geometry.AsBinary();
                    addCommand.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(bufZone.Name) ? DBNull.Value : (object)bufZone.Name);
                    addCommand.Parameters.AddWithValue("@Desc", string.IsNullOrEmpty(bufZone.Description) ? DBNull.Value : (object)bufZone.Description);
                    addCommand.Parameters.AddWithValue("@Radius", bufZone.Radius);
                    if (bufZone.Center != null)
                    {

                        var projectedCenter = bufZone.Center;//GeometryTransform.TransformPoint(bufZone.Center,
                                              //                                 CoordinateSystems.SphericalMercatorCS,
                                              //                                 CoordinateSystems.WGS84);
                        addCommand.Parameters.AddWithValue("@CenterX", projectedCenter.X);
                        addCommand.Parameters.AddWithValue("@CenterY", projectedCenter.Y);
                    }
                    else
                    {   
                        addCommand.Parameters.AddWithValue("@CenterX", 0);
                        addCommand.Parameters.AddWithValue("@CenterY", 0);
                    }

                    var result = (decimal)addCommand.ExecuteScalar();
                    return decimal.ToInt64(result);
                }
            }
        }

        public void DeleteZone(long bufId)
        {
            using (var conn = new SqlConnection((DataSource as EidssSqlServer2008).ConnectionString))
            {
                conn.Open();

                var sql=string.Format( @"DELETE {0} WHERE idfsGeoObject = {1}", (DataSource as EidssSqlServer2008).Table, bufId);
                SqlExecHelper.SqlExecNonQuery(conn, sql);

                conn.Close();
            }
        }

        public long UpdateZone(UserBufZone bufZone)
        {
            using (var conn = new SqlConnection((DataSource as EidssSqlServer2008).ConnectionString))
            {
                conn.Open();

                using (var addCommand = conn.CreateCommand())
                {
                    addCommand.CommandType = CommandType.Text;

                    addCommand.CommandText = string.Format(
                        @"UPDATE {0} SET 
                            geomShape = geometry::STGeomFromWKB(@GeomShape, 3857),
                            strName = @Name, 
                            strDescription = @Desc, 
                            dblRadius = @Radius, 
                            dblCenterX =  @CenterX,
                            dblCenterY = @CenterY
                          WHERE idfsGeoObject = @id;",
                        (DataSource as EidssSqlServer2008).Table);

                    var param = addCommand.Parameters.Add("@GeomShape", SqlDbType.VarBinary, Int32.MaxValue);
                    param.Value = bufZone.Geometry == null ? DBNull.Value : (object)bufZone.Geometry.AsBinary();
                    addCommand.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(bufZone.Name) ? DBNull.Value : (object)bufZone.Name);
                    addCommand.Parameters.AddWithValue("@Desc", string.IsNullOrEmpty(bufZone.Description) ? DBNull.Value : (object)bufZone.Description);
                    addCommand.Parameters.AddWithValue("@Radius", bufZone.Radius);
                    if (bufZone.Center != null)
                    {
                        var projectedCenter = bufZone.Center; 
                                                //GeometryTransform.TransformPoint(bufZone.Center,
                                                //         CoordinateSystems.SphericalMercatorCS,
                                                //         CoordinateSystems.WGS84);
                        addCommand.Parameters.AddWithValue("@CenterX", projectedCenter.X);
                        addCommand.Parameters.AddWithValue("@CenterY", projectedCenter.Y);

                    }
                    else
                    {
                        addCommand.Parameters.AddWithValue("@CenterX", 0);
                        addCommand.Parameters.AddWithValue("@CenterY", 0);
                    }
                    
                    
                    addCommand.Parameters.AddWithValue("@id", bufZone.ID);

                    return addCommand.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
