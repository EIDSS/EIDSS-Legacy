using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using DotSpatial.Projections;
using GIS_V4.Common;
using GIS_V4.Data.Providers;
using GIS_V4.Layers;
using GIS_V4.Properties;
using GIS_V4.Utils;
using SharpMap.Data;
using SharpMap.Geometries;

namespace eidss.gis.common
{
    public static class MapUtils
    {
        public enum MapProjectState
        {
            New,
            Unsaved,
            Saved
        }

        private static string GetWKBTableName(DataTable dataTable, string connection)
        {
            try
            {
                var objId = dataTable.Rows[0]["id"];

                if (objId.ToString() == string.Empty) return string.Empty;

                long id;
                if (!long.TryParse(objId.ToString(), out id)) return string.Empty;

                var sqlConnection = new SqlConnection(connection);

                var sql = "SELECT idfsGISReferenceType FROM gisBaseReference WHERE (idfsGISBaseReference = " + id + ")";

                sqlConnection.Open();
                var sqlCommand = new SqlCommand(sql, sqlConnection);
                var tId = sqlCommand.ExecuteScalar();
                sqlConnection.Close();

                long idType;
                if (!long.TryParse(tId.ToString(), out idType)) return string.Empty;

                switch (idType)
                {
                    case 19000004:
                        return "gisWKBSettlement";
                    case 19000003:
                        return "gisWKBRegion";
                    case 19000002:
                        return "gisWKBRayon";
                    default:
                        return string.Empty;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExportToFGDB(DataSet dataSource, string connection, string path)
        {
            try
            {
                var layer = AvrData2EventLayer(dataSource, connection);
                ExportUtils.ExportToFileGDB(layer, path);
            }
            catch (Exception e)
            {
                throw new Exception("Can't export to File GDB: " + e.Message);
            }
        }

        public static void ExtractEmbeddedDll(string dllName)
        {
            WindowsIdentity callerWindowsIdentity = WindowsIdentity.GetCurrent();
            if (callerWindowsIdentity == null)
            {
                throw new InvalidOperationException("The caller cannot be mapped to a WindowsIdentity");
            }

            using (callerWindowsIdentity.Impersonate())
            {
                // Get the byte[] of the DLL
                byte[] ba;
                var resource = "eidss.gis.common." + dllName;
                var curAsm = Assembly.GetExecutingAssembly();
                using (var stm = curAsm.GetManifestResourceStream(resource))
                {
                    if (stm != null)
                    {
                        ba = new byte[(int) stm.Length];
                        stm.Read(ba, 0, (int) stm.Length);
                    }
                    else
                    {
                        return;
                    }
                }

                var fileOk = false;
                string location;

                using (var sha1 = new SHA1CryptoServiceProvider())
                {
                    // Get the hash value of the Embedded DLL
                    var fileHash = BitConverter.ToString(sha1.ComputeHash(ba)).Replace("-", string.Empty);

                    // The full path of the DLL that will be saved
                    var assembly = Assembly.GetExecutingAssembly();
                    location = Path.GetDirectoryName(assembly.Location);

                    // Check if the DLL is already existed or not?
                    if (File.Exists(location))
                    {
                        // Get the file hash value of the existed DLL
                        var bb = File.ReadAllBytes(location);
                        var fileHash2 = BitConverter.ToString(sha1.ComputeHash(bb)).Replace("-", string.Empty);

                        // Compare the existed DLL with the Embedded DLL
                        fileOk = fileHash == fileHash2;
                    }
                }

                // Create the file on disk
                if (fileOk)
                {
                    return;
                }
                if (location != null)
                {
                    File.WriteAllBytes(location, ba);
                }
            }
        }

        public static EventLayer AvrData2EventLayer(DataSet dataSource, string connection)
        {
            var coordinateTransformation = new CoordinateTransformation
            {
                Source = CoordinateSystems.WGS84,
                Target = CoordinateSystems.SphericalMercatorCS
            };

            var data = dataSource.Tables[0];
            var dictionary = dataSource.Tables[1];

            if (data.Rows.Count == 0) return null;
            
            var avrLayer = new EventLayer(Resources.MapControl_AVR_Gradient) { Tag = "event_gradient" };
            
            //MapSpatRef = CoordinateSystems.SphericalMercatorCS;
            var dataType = GetWKBTableName(data, connection);

            if (dataType != string.Empty)
            {
                // Use administrative geometries

                #region Create gradient layer

                // add prefix to dictionary
                foreach (DataRow rowDict in dictionary.Rows)
                {
                    rowDict["ColumnName"] = string.Format("gisBegin_{1}_gisEnd{0}", rowDict["ColumnName"],
                        rowDict["ColumnDescription"]);
                }

                for (var i = 0; i <= data.Columns.Count - 1; i++)
                {
                    if (!(data.Columns[i].ColumnName == "id" | data.Columns[i].ColumnName == "x" |
                          data.Columns[i].ColumnName == "y"))
                    {
                        data.Columns[i].ColumnName = (string)dictionary.DefaultView.ToTable().Rows[i - 3]["ColumnName"];

                    }
                }

                avrLayer.DataSource = new EventDataProvider(connection, GetWKBTableName(data, connection), "geomShape",
                                                             "idfsGeoObject", data) { SRID = 3857 };

                ((EventDataProvider)avrLayer.DataSource).EventTable = data;
                ((EventDataProvider)avrLayer.DataSource).EventIdColumn = "id";

                var gradColName = string.Empty;
                var gradColDescription = string.Empty;
                string colName, colDescription;
                string colFullName = string.Empty;
                var colIsGradient = false;

                // Find gradient column



                foreach (DataColumn column in from DataColumn column in data.Columns
                                              where column != null
                                              where
                                                  !(column.ColumnName == "id" | column.ColumnName == "x" |
                                                    column.ColumnName == "y")
                                              select column)
                {
                    dictionary.DefaultView.RowFilter = string.Format("ColumnName = '{0}'", column.ColumnName);
                    if (dictionary.DefaultView.Count == 0) continue;

                    colName = (string)dictionary.DefaultView.ToTable().Rows[0]["ColumnName"];
                    colDescription = (string)dictionary.DefaultView.ToTable().Rows[0]["ColumnDescription"];
                    colIsGradient = (bool)dictionary.DefaultView.ToTable().Rows[0]["blnIsGradient"];

                    colFullName = column.ColumnName = colName;// colDescription;


                    if (colIsGradient)
                    {
                        gradColName = colName;
                        gradColDescription = colDescription;
                        break;
                    }
                }

                if (colIsGradient)
                {
                    avrLayer.LabelLayer.LabelColumn = gradColName;
                    avrLayer.LayerName = avrLayer.LayerName + " - " + gradColDescription; //gradColName;
                    // Create gradient layer
                    switch (dataType)
                    {
                        case "gisWKBSettlement":
                            avrLayer.Theme = ThematicUtils.CreateEventTheme(data, GeometryType2.Point, true,
                                                                             colFullName, true);
                            break;
                        case "gisWKBRayon":
                            avrLayer.Theme = ThematicUtils.CreateEventTheme(data, GeometryType2.Polygon, true,
                                                                             colFullName,
                                                                             true);
                            break;
                        case "gisWKBRegion":
                            avrLayer.Theme = ThematicUtils.CreateEventTheme(data, GeometryType2.Polygon, true,
                                                                             colFullName,
                                                                             true);
                            break;
                        case "gisWKBDistrict":
                            avrLayer.Theme = ThematicUtils.CreateEventTheme(data, GeometryType2.Polygon, true,
                                                                             colFullName,
                                                                             true);
                            break;
                        default:
                            break;
                    }
                }
                else
                    avrLayer = null;

                #endregion
           
            }
            else
            {
                #region Create coordinate point layer

                //use coordinates
                avrLayer.CoordinateTransformation = coordinateTransformation;

                var gradColName = string.Empty;
                //string colName, colDescription;
                var colIsGradient = false;
                //var chartFieldNum = 0;

                //// Rename columns
                foreach (DataColumn column in from DataColumn column in data.Columns
                                              where column != null
                                              where !(column.ColumnName == "id" | column.ColumnName == "x" | column.ColumnName == "y")
                                              select column)
                {
                    dictionary.DefaultView.RowFilter = string.Format("ColumnName = '{0}'", column.ColumnName);
                    if (dictionary.DefaultView.Count == 0) continue;

                    //colName = (string)dictionary.DefaultView.ToTable().Rows[0]["ColumnName"];
                    var colDescription = (string)dictionary.DefaultView.ToTable().Rows[0]["ColumnDescription"];
                    colIsGradient = (bool)dictionary.DefaultView.ToTable().Rows[0]["blnIsGradient"];

                    column.ColumnName = colDescription;


                    if (colIsGradient)
                    {
                        gradColName = colDescription;
                        //    break;
                    }
                }

                var fdt = new FeatureDataTable();

                foreach (DataColumn column in data.Columns)
                {
                    fdt.Columns.Add(column.ColumnName, column.DataType);
                }
                fdt.Columns.Add("sharpmap_tempgeometry", typeof(byte[]));

                foreach (DataRow dr in data.Rows)
                {
                    var newFeatureDataRow = fdt.NewRow();

                    foreach (DataColumn column in data.Columns)
                    {
                        var columnName = column.ColumnName;
                        newFeatureDataRow[columnName] = dr[columnName];
                    }

                    double x, y;

                    if (double.TryParse(dr["x"].ToString(), out x) && double.TryParse(dr["y"].ToString(), out y))
                    //if (dr["x"] is double && dr["y"] is double)
                    {
                        var casePoint = new SharpMap.Geometries.Point(y, x);
                        newFeatureDataRow.Geometry = casePoint;
                        newFeatureDataRow["sharpmap_tempgeometry"] =
                            SharpMap.Converters.WellKnownBinary.GeometryToWKB.Write(newFeatureDataRow.Geometry);
                        fdt.AddRow(newFeatureDataRow);
                    }
                }

                avrLayer.DataSource = new GeometryProvider(fdt);
                avrLayer.SRID = 4326;
                avrLayer.Theme = ThematicUtils.CreateEventTheme(data, GeometryType2.Point, true, gradColName, true);

                avrLayer.LayerName = "AVR Coordinate Layer"; 

                #endregion
            }

            return avrLayer;
        }

    


    }
}
