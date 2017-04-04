using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using eidss.model.Resources;
using GIS_V4.Common;
using GIS_V4.Forms;
using GIS_V4.Tools;
using SharpMap.Geometries;
using bv.common.db.Core;
using eidss.gis.Forms;

namespace eidss.gis.Tools
{
    public class GeoSearch : StateViewer 
    {
        public GeoSearch()
        {
            m_DockManager = new DockManager();
            m_DockManager.StartDocking += m_DockManager_StartDocking;
        }

        void m_SearchResultPanel_ClosingPanel(object sender, DockPanelCancelEventArgs e)
        {
            m_SearchResultPanel.Visible = false;
            e.Cancel = true;
        }

        void m_DockManager_StartDocking(object sender, DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }

        #region Events

        //public delegate void NewSearchEventHandler(string searchString);

        //public event NewSearchEventHandler NewSearchCall;

        #endregion

        #region << ControlForVisualize >>

        private BarEditItem m_GeoSearchButtonEdit;
        private DockManager m_DockManager;
        private DockPanel m_SearchResultPanel;
        private SearchResult m_SearchResult;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(null)]
        public BarEditItem ControlForVisualize
        {
            get { return m_GeoSearchButtonEdit; }
            set
            {
                m_GeoSearchButtonEdit = value;
                if (m_GeoSearchButtonEdit != null)
                {
                    
                }
            }
        }

        private MapImage m_MapImage;
        public new MapImage MapControl
        {
            get { return m_MapImage; }
            set
            {
                m_MapImage = value;
                if (m_MapImage != null)
                    if (m_MapImage.Parent != null)
                    {
                        var form = m_MapImage.Parent as MapControl;
                        if (form != null)
                            m_DockManager.Form = (ContainerControl) m_MapImage.Parent;
                    }
            }
        }

        public class SearchItem
        {
            public SearchItem(string region, string rayon, string settlement, long id, Geometry shape)
            {
                Region = region;
                Rayon = rayon;
                Settlement = settlement;
                Id = id;
                Shape = shape;
            }

            public string Region { get; set; }
            public string Rayon { get; set; }
            public string Settlement { get; set; }
            public long Id { get; set; }
            public Geometry Shape { get; set; }

            public string Result
            {
                get
                {
                    var strReg = EidssMessages.GetForCurrentLang("gis_GeoSearch_Region", "region");
                    var strRay = EidssMessages.GetForCurrentLang("gis_GeoSearch_Rayon", "rayon");
                    var strStt = EidssMessages.GetForCurrentLang("gis_GeoSearch_Settlement", "settlement");

                    if (Settlement.Trim() != "")
                    {
                        return string.Format("{0} {5}, {1} {4}, {2} {3}", Settlement, Rayon, Region, strReg, strRay,strStt);
                    }
                   
                    if (Rayon.Trim() != "" & Settlement.Trim() == "")
                        return string.Format("{0} {3}, {1} {2}", Rayon, Region, strReg, strRay);

                    return string.Format("{0} {1}", Region, strReg);
                }
            }
            
        }

        //public List<string> SearchResultItems;
        
        public List<SearchItem> SearchResultList;

        //private int m_SearchPage = 0;
        private int m_SearchRegNum = 0;
        private int m_SearchRnNum = 0;
        private int m_SearchStNum = 0;
        private const int GeoObjPerPage = 10;
        
        private string m_SearchString = string.Empty;

        public void NewSearch(string value)
        {
            m_SearchRegNum = 0;
            m_SearchRnNum = 0;
            m_SearchStNum = 0;
            m_SearchString = value;
            if (!Search())
                MessageBox.Show("Nothing is found", "Search");
        }

        public bool Search()
        {
            var value = m_SearchString;
            if (value == string.Empty) return false;

            SearchResultList = new List<SearchItem>();
            
            try
            {
                var strConnect = ConnectionManager.DefaultInstance.ConnectionString;
                var sqlConnection = new SqlConnection(strConnect);
                
                sqlConnection.Open();

                int objNum = 0;

                #region Search in Regions

                var sql =
                    string.Format(
                        @"WITH [RegSearchOrder] AS (SELECT ROW_NUMBER() OVER (ORDER BY [strTextString]) AS [rownum],
                                [idfsGISBaseReference],
                                [strTextString], 
                                [gisWKBRegion].[geomShape].STAsBinary() AS [Shape]
                          FROM [gisStringNameTranslation] 
                          INNER JOIN [gisRegion] ON [gisStringNameTranslation].[idfsGISBaseReference]=[gisRegion].[idfsRegion]
                            INNER JOIN [gisWKBRegion] ON [gisStringNameTranslation].[idfsGISBaseReference]=[gisWKBRegion].[idfsGeoObject]   
                          WHERE [strTextString] LIKE N'%{0}%') SELECT [idfsGISBaseReference], [strTextString], [Shape] FROM [RegSearchOrder] WHERE [rownum] BETWEEN {1} AND {2}",
                        value, m_SearchRegNum + 1, m_SearchRegNum + GeoObjPerPage);
                    
                var sqlCommand1 = new SqlCommand(sql, sqlConnection);
                var sqlDataReader1 = sqlCommand1.ExecuteReader();
                while (sqlDataReader1.Read())
                {
                    var geom =
                        SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[])sqlDataReader1[2]);
                    SearchResultList.Add(new SearchItem(sqlDataReader1[1].ToString(), string.Empty, string.Empty,
                                                        long.Parse(sqlDataReader1[0].ToString()), geom));
                    objNum++;
                    m_SearchRegNum++;
                }

                #endregion

                if (objNum < GeoObjPerPage)
                {
                    #region Search in Rayons

                    sql = string.Format(@"WITH [RnSearchOrder] AS
                                        (
	                                        SELECT ROW_NUMBER() OVER (ORDER BY [gisStringNameTranslation].[strTextString]) AS [rownum],
                                                   [gisStringNameTranslation].[idfsGISBaseReference], 
                                                   [gisStringNameTranslation].[idfsLanguage],
                                                   [gisStringNameTranslation].[strTextString], 
                                                   [gisRayon].idfsRegion, 
                                                   [trans].[strTextString] AS [regName],
                                                   [gisWKBRayon].[geomShape].STAsBinary() AS [Shape]
	                                        FROM [gisStringNameTranslation]
		                                    INNER JOIN [gisRayon] ON [gisStringNameTranslation].[idfsGISBaseReference]=[gisRayon].[idfsRayon]	
			                                    INNER JOIN [gisStringNameTranslation] AS [trans] ON [trans].[idfsGISBaseReference]=[gisRayon].[idfsRegion]
                                                    INNER JOIN [gisWKBRayon] ON [gisStringNameTranslation].[idfsGISBaseReference]=[gisWKBRayon].[idfsGeoObject]		
	                                        WHERE [gisStringNameTranslation].[strTextString] LIKE N'%{0}%' 
                                                  AND [gisStringNameTranslation].[idfsLanguage]=[trans].[idfsLanguage]
                                        )
                                        SELECT [RnSearchOrder].[idfsGISBaseReference],
                                               [RnSearchOrder].[idfsLanguage], 
                                               [RnSearchOrder].[strTextString], 
                                               [idfsRegion], 
                                               [regName], 
                                               [Shape]
                                        FROM [RnSearchOrder] 	
                                        WHERE [rownum] BETWEEN {1} AND {2}", value, m_SearchRnNum + 1,
                                        m_SearchRnNum + GeoObjPerPage - objNum);

                    objNum = 0;
                    var sqlCommand2 = new SqlCommand(sql, sqlConnection);
                    var sqlDataReader2 = sqlCommand2.ExecuteReader();
                    while (sqlDataReader2.Read())
                    {
                        var geom = SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[]) sqlDataReader2[5]);
                        SearchResultList.Add(new SearchItem(sqlDataReader2[4].ToString(), sqlDataReader2[2].ToString(),
                                                            string.Empty, long.Parse(sqlDataReader2[0].ToString()), geom));
                        objNum++;
                        m_SearchRnNum++;
                    }
                    #endregion

                    #region Search in settlements

                    sql = string.Format(@"WITH [StSearchOrder] AS
                                        (
	                                        SELECT ROW_NUMBER() OVER (ORDER BY [gisStringNameTranslation].[strTextString]) AS [rownum],
		                                           [gisStringNameTranslation].[idfsGISBaseReference],
                                                   [gisStringNameTranslation].[idfsLanguage],
		                                           [gisStringNameTranslation].[strTextString],
		                                           [gisSettlement].[idfsSettlement], 		   
		                                           [trans].[strTextString] AS [rnName],
		                                           [trans1].[strTextString] AS [regName],
                                                   [gisWKBSettlement].[geomShape].STAsBinary() AS [Shape]
	                                        FROM [gisStringNameTranslation]
		                                    INNER JOIN [gisSettlement] ON [gisStringNameTranslation].idfsGISBaseReference=[gisSettlement].[idfsSettlement]
			                                    INNER JOIN [gisStringNameTranslation] AS [trans] ON [trans].[idfsGISBaseReference]=[gisSettlement].[idfsRayon]		
				                                    INNER JOIN [gisStringNameTranslation] AS [trans1] ON [trans1].[idfsGISBaseReference]=[gisSettlement].[idfsRegion]
                                                        INNER JOIN [gisWKBSettlement] ON [gisStringNameTranslation].[idfsGISBaseReference]=[gisWKBSettlement].[idfsGeoObject]										
	                                        WHERE [gisStringNameTranslation].[strTextString] LIKE N'%{0}%' 
	                                                AND [gisStringNameTranslation].[idfsLanguage]=[trans].[idfsLanguage]
	                                                AND [gisStringNameTranslation].[idfsLanguage]=[trans1].[idfsLanguage]
                                        )
                                        SELECT [StSearchOrder].[idfsGISBaseReference],
                                               [StSearchOrder].[idfsLanguage], 
                                               [StSearchOrder].[strTextString], 
                                               [rnName], 
                                               [regName], 
                                               [Shape]
                                        FROM [StSearchOrder] 	
                                        WHERE [rownum] BETWEEN {1} AND {2}", value, m_SearchStNum + 1,
                                        m_SearchStNum + GeoObjPerPage - objNum);
                    objNum = 0;
                    var sqlCommand3 = new SqlCommand(sql, sqlConnection);
                    var sqlDataReader3 = sqlCommand3.ExecuteReader();
                    while (sqlDataReader3.Read())
                    {
                        var geom = SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[]) sqlDataReader3[5]);
                        SearchResultList.Add(new SearchItem(sqlDataReader3[4].ToString(), sqlDataReader3[3].ToString(),
                                                            sqlDataReader3[2].ToString(),
                                                            long.Parse(sqlDataReader3[0].ToString()), geom));
                        objNum++;
                        m_SearchStNum++;
                    }
                    #endregion
                }

                sqlConnection.Close();

                if (SearchResultList.Count == 0) return false;

                if (m_SearchResultPanel == null)
                {
                    if (!RtlHelper.IsRtl)
                        m_SearchResultPanel = m_DockManager.AddPanel(DockingStyle.Left);
                    else
                        m_SearchResultPanel = m_DockManager.AddPanel(DockingStyle.Right);
                    //m_SearchResultPanel.Visible = false;
                    m_SearchResultPanel.Text = EidssMessages.GetForCurrentLang("gis_Tools_Geosearch_Btn", "Search"); 
                    m_DockManager.DockingOptions.ShowAutoHideButton = false;
                    m_SearchResult = new SearchResult(this);
                    m_SearchResultPanel.Controls.Add(m_SearchResult);
                    m_SearchResult.Dock = DockStyle.Fill;

                    m_SearchResultPanel.ClosingPanel += m_SearchResultPanel_ClosingPanel;
                }

                    m_SearchResult.RefreshList();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Search error: " + ex.Message);
            }
            
            return true;
        }
        
        #endregion
    }
}
