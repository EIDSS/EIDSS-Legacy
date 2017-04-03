using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Projections;
using GIS_V4.Common;
using GIS_V4.Data.Providers;
using GIS_V4.Forms;
using GIS_V4.Properties;
using GIS_V4.Tools;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Geometries;
using SharpMap.Layers;
using bv.common;
using bv.common.db.Core;
using bv.common.win;
using eidss.gis.Data;
using eidss.gis.Layers;
using eidss.gis.Tools.ToolForms;
using eidss.gis.Utils;
using eidss.gis.common;
using eidss.model.Core;
using GeometryProvider = GIS_V4.Data.Providers.GeometryProvider;

namespace eidss.gis.Tools
{
    public class MtInfo : ControllerMapTool
    {
        #region layers

        private ILayer m_CurrentLayer;
        private MapContent m_MapContent;
        private DataTable m_Translation;

        public MapContent Content
        {
            get { return m_MapContent; }
            set { m_MapContent = value; }
        }

        #endregion


        public MtInfo()
        {
            var temp = Resources.mActionIdentify;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Properties.Resources.gis_MtInfo_Caption;
            m_ToolTipText = Properties.Resources.gis_MtInfo_ToolTipText;
        }

        public string ConnectionString { get; set; }

        public string CurrentFeatureName { get; set; }

        public void LoadTranslations()
        {
            try
            {
                var tr1 = TranslationCache.GetTranslation(ConnectionString, (long)GisDbType.RftSettlement, EidssUserContext.CurrentLanguage);
                var tr2 = TranslationCache.GetTranslation(ConnectionString, (long)GisDbType.RftRayon, EidssUserContext.CurrentLanguage);
                var tr3 = TranslationCache.GetTranslation(ConnectionString, (long)GisDbType.RftRegion, EidssUserContext.CurrentLanguage);
                var tr4 = TranslationCache.GetTranslation(ConnectionString, (long)GisDbType.RftCountry, EidssUserContext.CurrentLanguage);

                m_Translation = tr1;
                m_Translation.Merge(tr2);
                m_Translation.Merge(tr3);
                m_Translation.Merge(tr4);
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(new ErrorMessage(ex.Message, ex));
            }

        }

        protected override void OnToolActivated()
        {
            m_MapImage.Cursor = Cursors.Cross;
            m_MapImage.MouseDown += m_MapImage_MouseDown;
            m_MapImage.MouseMove += m_MapImage_MouseMove;
        }

        void m_MapImage_MouseMove(Point worldPos, MouseEventArgs imagePos)
        {
            //if (m_InfoForm==null) return;
            //if (!m_InfoForm.Visible) return;
            //InfoRoutine(worldPos);
        }

        public string GetWebPointInfo(double lon, double lat, string[] mInfoRegion, string[] mInfoRayon, ref string mInfoSettlement)
        {
            //var fds = new FeatureDataSet();
            DataTable tbl;
            var lPoint = new Point(lon, lat);
            var projectedPoint = GeometryTransform.TransformPoint(lPoint, CoordinateSystems.WGS84,
                                                                  CoordinateSystems.SphericalMercatorCS);
            var connectionString = ConnectionManager.DefaultInstance.ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            string lRegion = null;
            long id = 0;
            lRegion = GetGeoName(connectionString, "gisWKBRegion", projectedPoint.X, projectedPoint.Y) + "  ";
            if (lRegion == null)
            {
                return "";
            }
            else
            {
                mInfoRegion[0] = lRegion;
                //// Region
                id = GetGeoId(connectionString, "gisWKBRegion", projectedPoint.X, projectedPoint.Y);
                tbl = SqlExecHelper.SqlExecTable(sqlConnection,
                                                     string.Format(
                                                         "SELECT * FROM dbo.fn_GetRegionStatInfo(dbo.fnGetLanguageCode('{0}'), {1})",
                                                         EidssUserContext.CurrentLanguage, id));
                tbl.Columns.Add("varPopDens", Type.GetType("System.Double"));
                foreach (DataRow row in tbl.Rows)
                {
                    if (row["varPopulation"] is DBNull || row["varArea"] is DBNull) continue;

                    double population = (double) row["varPopulation"];
                    double area = (double) row["varArea"];

                    if (area != 0) row["varPopDens"] = population / area;
                    else row["varPopDens"] = null;

                    mInfoRegion[1] = GetStatValue(row["varArea"]);
                    mInfoRegion[2] = GetStatValue(row["varPopulation"]);
                    mInfoRegion[3] = GetStatValue(row["varPopDens"]);
                }
            }

            mInfoRayon[0] = GetGeoName(connectionString, "gisWKBRayon", projectedPoint.X, projectedPoint.Y) + "  ";
            id = GetGeoId(connectionString, "gisWKBRayon", projectedPoint.X, projectedPoint.Y);
            tbl = SqlExecHelper.SqlExecTable(sqlConnection, string.Format("SELECT * FROM dbo.fn_GetRayonStatInfo(dbo.fnGetLanguageCode('{0}'), {1})", EidssUserContext.CurrentLanguage, id));
            tbl.Columns.Add("varPopDens", Type.GetType("System.Double"));
            foreach (DataRow row in tbl.Rows)
            {
                if (row["varPopulation"] is DBNull || row["varArea"] is DBNull) continue;
                double population = (double) row["varPopulation"];
                double area = (double) row["varArea"];
                //double density;
                if (area != 0) row["varPopDens"] = population / area;
                else row["varPopDens"] = null;

                mInfoRayon[1] = GetStatValue(row["varArea"]);
                mInfoRayon[2] = GetStatValue(row["varPopulation"]);
                mInfoRayon[3] = GetStatValue(row["varPopDens"]);
            }


            mInfoSettlement = GetGeoName(connectionString, "gisWKBSettlement", projectedPoint.X, projectedPoint.Y);


            /*
            varArea
            varPopulation
            varPopDens                                     
             */

            return "";
        }

        public string GetStatValue(object pdata)
        {
            if (pdata != null)
            {
                double varArea = 0;
                try { varArea = double.Parse(pdata.ToString()); }
                catch (Exception) { }
                return varArea.ToString("#.##");
            }
            return "No data";
        }

        public long GetGeoId(string connectionString, string lTable, double lon, double lat)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText =
                string.Format(
                    "SELECT idfsGeoObject FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1",
                    lTable, lon, lat);
            if (lTable == "gisWKBSettlement")
            {
                cmd.CommandText =
                    string.Format(
                        "SELECT TOP 1 idfsGeoObject FROM {0} WHERE geomShape.STDistance(geometry::STGeomFromText('POINT({1} {2})', 3857)) < 1000",
                        lTable, lon, lat);
            }
            long idfGeo = 0;
            try
            {
                idfGeo = long.Parse(cmd.ExecuteScalar().ToString());
            }
            catch(Exception){}

            return idfGeo;
        }

        public string GetGeoName(string connectionString, string lTable, double lon, double lat)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = string.Format("SELECT idfsGeoObject FROM {0} WHERE  geomShape.STContains(geometry::STGeomFromText('POINT({1} {2})', 3857))=1", lTable, lon, lat);
            if (lTable == "gisWKBSettlement") { cmd.CommandText = string.Format("SELECT TOP 1 idfsGeoObject FROM {0} WHERE geomShape.STDistance(geometry::STGeomFromText('POINT({1} {2})', 3857)) < 1000", lTable, lon, lat); }
            var idfGeo = (long?)cmd.ExecuteScalar();
            if (idfGeo == null) {return "";}
            var rowSearch = m_Translation.Rows.Find(idfGeo);
            return rowSearch["Name"].ToString();
        }

        private bool m_IsAVR;
        //private bool m_IsSystem;
        private FeatureDataRow GetNearestFeature(Point worldPos)
        {
            var fds = new FeatureDataSet();
            var area = GIS_V4.Utils.GeometryUtils.PointToArea(worldPos, 3, MapImage.Map.PixelWidth);

            if (!(m_CurrentLayer is VectorLayer)) return null;

            var provider = ((VectorLayer)m_CurrentLayer).DataSource;
            provider.Open();

            m_IsAVR = false;

            if (provider is EventDataProvider)
            {
                //AVR settlements
                ((EventDataProvider)provider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                provider.Close();

                if (fds.Tables == null) return null;
                if (fds.Tables.Count == 0) return null;
                if (fds.Tables[0].Rows == null) return null;
                if (fds.Tables[0].Rows.Count == 0) return null;

                var rowSearch = m_Translation.Rows.Find(fds.Tables[0][0]["idfsGeoObject"]);
                CurrentFeatureName = rowSearch != null
                                         ? m_CurrentLayer.LayerName + ": " + rowSearch["Name"]
                                         : m_CurrentLayer.LayerName;

                m_IsAVR = true;
            }
            else if (provider is GeometryProvider)
            {
                area = GeometryTransform.TransformGeometry(area, CoordinateSystems.SphericalMercatorCS,
                                                           CoordinateSystems.WGS84);
                ((GeometryProvider)provider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                provider.Close();
            }
            else if (provider is ShapeFile)
            {
                //external shapes
                area = GeometryTransform.TransformGeometry(area, CoordinateSystems.SphericalMercatorCS,
                                                           CoordinateSystems.WGS84);
                ((ShapeFile)provider).Encoding = Encoding.UTF8;
                provider.SRID = 4326;
                ((ShapeFile)provider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                provider.Close();
            }
            else
            {
                if (!(provider is SqlServer2008)) return null;
                //sql 2008 geometries
                ((SqlServer2008)provider).ExecuteIntersectionQuery(area.GetBoundingBox(), fds);
                provider.Close();
                if (fds.Tables == null) return null;
                if (fds.Tables.Count == 0) return null;
                if (fds.Tables[0].Rows == null) return null;
                if (fds.Tables[0].Rows.Count == 0) return null;

                var rowSearch = m_Translation.Rows.Find(fds.Tables[0][0]["idfsGeoObject"]);
                CurrentFeatureName = rowSearch != null
                                         ? m_CurrentLayer.LayerName + ": " + rowSearch["Name"]
                                         : m_CurrentLayer.LayerName;
            }



            if (fds.Tables.Count <= 0) return null;
            if (fds.Tables[0].Rows.Count <= 0) return null;

            var featureDataRow = fds.Tables[0][0];

            return featureDataRow;
        }

        private InfoForm m_InfoForm;

        void m_MapImage_MouseDown(Point worldPos, MouseEventArgs imagePos)
        {
            InfoRoutine(worldPos);

            //var connectionString = ConnectionManager.DefaultInstance.ConnectionString;

            //var geoPoint = GeometryTransform.TransformPoint(worldPos, CoordinateSystems.SphericalMercatorCS,
            //                                                CoordinateSystems.WGS84);

            //long? country, region, district;
            //var result = CoordinatesUtils.CoordToAdm(out country, out region, out district, connectionString, geoPoint.Y,
            //                                         geoPoint.X);
        }

        private void InfoRoutine(Point worldPos)
        {
            m_CurrentLayer = m_MapContent.CurrentLayer;

            if (m_CurrentLayer == null) return;
            if (!m_CurrentLayer.Enabled) return;

            var featureDataRow = GetNearestFeature(worldPos);

            if (featureDataRow == null) return;

            var id = (long) featureDataRow.ItemArray[0];

            // Check type of selected layer

            if (m_CurrentLayer is EidssSystemDbLayer)
            {
                var strTableName = ((SqlServer2008)(((EidssSystemDbLayer)m_CurrentLayer).DataSource)).Table;
                if (strTableName=="gisWKBRegion")
                {
                    #region Regional statistic
                    var sqlConnection = new SqlConnection(ConnectionManager.DefaultInstance.ConnectionString);
                    var tbl = SqlExecHelper.SqlExecTable(sqlConnection,
                                                         string.Format(
                                                             "SELECT * FROM dbo.fn_GetRegionStatInfo(dbo.fnGetLanguageCode('{0}'), {1})",
                                                             EidssUserContext.CurrentLanguage, id));
                    tbl.Columns.Add("varPopDens", Type.GetType("System.Double"));
                    foreach (DataRow row in tbl.Rows)
                    {
                        if (row["varPopulation"] is DBNull || row["varArea"] is DBNull) continue;

                        double population = (double) row["varPopulation"];
                        double area = (double) row["varArea"];
                        
                        //double density;
                        if (area != 0)
                            row["varPopDens"] = population / area;
                        else
                            row["varPopDens"] = null;
                    }

                    if (m_InfoForm == null)
                        m_InfoForm = new InfoForm { IsAVR = false, Text = CurrentFeatureName, Feature = null, StatTable = tbl};
                    else
                    {
                        m_InfoForm.IsAVR = m_IsAVR;
                        m_InfoForm.Text = CurrentFeatureName;
                        m_InfoForm.Feature = null;
                        m_InfoForm.StatTable = tbl;
                    }
                    #endregion
                }
                else if (strTableName=="gisWKBRayon")
                {
                    #region Rayon statistic
                    var sqlConnection = new SqlConnection(ConnectionManager.DefaultInstance.ConnectionString);
                    var tbl = SqlExecHelper.SqlExecTable(sqlConnection,
                                                         string.Format(
                                                             "SELECT * FROM dbo.fn_GetRayonStatInfo(dbo.fnGetLanguageCode('{0}'), {1})",
                                                             EidssUserContext.CurrentLanguage, id));

                    tbl.Columns.Add("strRayon", Type.GetType("System.String"));
                    tbl.Columns.Add("strRegion", Type.GetType("System.String"));



                    tbl.Columns.Add("varPopDens", Type.GetType("System.Double"));
                    foreach (DataRow row in tbl.Rows)
                    {
                        var name = row["strName"].ToString();
                        var reg = name.Substring(0, name.IndexOf(",", System.StringComparison.Ordinal));
                        var distr = name.Substring(name.IndexOf(",", System.StringComparison.Ordinal) + 2);

                        row["strRegion"] = reg;
                        row["strRayon"] = distr;

                        if (row["varPopulation"] is DBNull || row["varArea"] is DBNull) continue;

                        double population = (double)row["varPopulation"];
                        double area = (double)row["varArea"];

                        //double density;
                        if (area != 0)
                            row["varPopDens"] = population / area;
                        else
                            row["varPopDens"] = null;
                    }

                    if (m_InfoForm == null)
                        m_InfoForm = new InfoForm { IsAVR = false, Text = CurrentFeatureName, Feature = null, StatTable = tbl };
                    else
                    {
                        m_InfoForm.IsAVR = m_IsAVR;
                        m_InfoForm.Text = CurrentFeatureName;
                        m_InfoForm.Feature = null;
                        m_InfoForm.StatTable = tbl;
                    }
                    #endregion
                }
                else if (strTableName=="gisWKBSettlement")
                {
                    #region Settlement statistic

                    var sqlConnection = new SqlConnection(ConnectionManager.DefaultInstance.ConnectionString);
                    var tbl = SqlExecHelper.SqlExecTable(sqlConnection,
                                                         string.Format(
                                                             "SELECT * FROM dbo.fn_GetSettlementStatInfo(dbo.fnGetLanguageCode('{0}'), {1})",
                                                             EidssUserContext.CurrentLanguage, id));
                    
                    if (m_InfoForm == null)
                        m_InfoForm = new InfoForm { IsAVR = false, Text = CurrentFeatureName, Feature = null, StatTable = tbl };
                    else
                    {
                        m_InfoForm.IsAVR = m_IsAVR;
                        m_InfoForm.Text = CurrentFeatureName;
                        m_InfoForm.Feature = null;
                        m_InfoForm.StatTable = tbl;
                    }

                    #endregion
                }
                else if (strTableName == "gisWKBCountry")
                {
                    if (m_InfoForm == null)
                        m_InfoForm = new InfoForm { IsAVR = m_IsAVR, Text = CurrentFeatureName, StatTable = null, Feature = featureDataRow };
                    else
                    {
                        m_InfoForm.IsAVR = m_IsAVR;
                        m_InfoForm.Text = CurrentFeatureName;
                        m_InfoForm.StatTable = null;
                        m_InfoForm.Feature = featureDataRow;
                    }
                }
                //m_InfoForm.Show();
            }
            else
            {
                // for other type of layers
                
                //m_InfoForm = new InfoForm {IsAVR = m_IsAVR, Text = CurrentFeatureName, Feature = featureDataRow};
                if (m_InfoForm == null)
                    m_InfoForm = new InfoForm { IsAVR = m_IsAVR, Text = CurrentFeatureName, StatTable = null, Feature = featureDataRow };
                else
                {
                    m_InfoForm.IsAVR = m_IsAVR;
                    m_InfoForm.Text = CurrentFeatureName;
                    m_InfoForm.StatTable = null;
                    m_InfoForm.Feature = featureDataRow;
                }

                // Dialog();
                //infoForm.ShowDialog();
            }
            m_InfoForm.Show(); 
        }

        protected override void OnToolDeactivated()
        {
            if (m_InfoForm != null)
                m_InfoForm.Hide();
            m_MapImage.Cursor = Cursors.Default;
            m_MapImage.MouseDown -= m_MapImage_MouseDown;

        }

    }
}
