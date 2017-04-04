using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using bv.common.Enums;
using bv.common.db.Core;
using eidss.gis.Data;
using eidss.gis.Data.Providers;
using eidss.gis.Layers;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using eidss.gis.Utils;
using eidss.model.Resources;
using GIS_V4.Layers;
using SharpMap.Styles;
using bv.winclient.Core;

namespace eidss.gis.Forms
{
    public partial class DbLayersForm : BvForm
    {
        private static readonly DbLayersForm m_Instance = new DbLayersForm();
        private readonly Random m_Random = new Random((int)DateTime.Now.Ticks);


        /// <summary>
        /// Method, for select DB layer
        /// </summary>
        /// <returns></returns>
        public static VectorLayer SelectDbLayer()
        {
            
            //dynamic
            var instance = new DbLayersForm();
            using(new TemporaryWaitCursor())
            {
                instance.RefreshUserLayers();
            }
            instance.SelectedLayer = null;

            instance.ShowDialog();
            return instance.SelectedLayer; 
        }


        protected VectorLayer SelectedLayer { get; private set; }


        public DbLayersForm()
        {
            InitializeComponent();
            //InitializeTableView();

            if (bv.common.Configuration.BaseSettings.ScanFormsMode)
                return;
            
            FillSystemDbLayers();
            FillExtSystemDbLayers();
        }

        private void InitializeTableView()
        {
            var gridColumn = new GridColumn();
            //CreationDate
            gridColumn.FieldName = "CreationDate";
            gridColumn.Caption = Resources.gis_DbLayersForm_BufTable_CreationDate;
            gridColumn.DisplayFormat.FormatType = FormatType.DateTime;
            gridColumn.DisplayFormat.FormatString = "d";
            bufLayersGridView.Columns.Add(gridColumn);

            //LayerName
            gridColumn = new GridColumn();
            gridColumn.FieldName = "LayerName";
            gridColumn.Caption = Resources.gis_DbLayersForm_BufTable_LayerName;
            bufLayersGridView.Columns.Add(gridColumn);
            //Description
            gridColumn = new GridColumn();
            gridColumn.FieldName = "Description";
            gridColumn.Caption = Resources.gis_DbLayersForm_BufTable_Description;
            bufLayersGridView.Columns.Add(gridColumn);
            //User
            gridColumn = new GridColumn();  
            gridColumn.FieldName = "User";
            gridColumn.Caption = Resources.gis_DbLayersForm_BufTable_User;
            bufLayersGridView.Columns.Add(gridColumn);
            //PivotalLayer
            gridColumn = new GridColumn();
            gridColumn.FieldName = "PivotalLayer";
            gridColumn.Caption = Resources.gis_DbLayersForm_BufTable_PivotalLayer;
            bufLayersGridView.Columns.Add(gridColumn);
        }

        private void GenerateRandomStyle(VectorLayer layer)
        {
            //---create style
            Color randomColour = Color.FromArgb(255, m_Random.Next(128, 255), m_Random.Next(128, 255),
                                                m_Random.Next(128, 255));
            layer.SmoothingMode = SmoothingMode.AntiAlias;

            //point style
            //layer.Style.Symbol = Markers.SimpleSymbol(randomColour, "Circle", 7, true, Color.Black, 1);
            layer.Style.PointSize = 8;
            layer.Style.PointColor = new SolidBrush(randomColour);
            layer.Style.MarkerType = MarkerTypes.Circle;

            layer.MarkerColor = randomColour;

            //line style
            layer.Style.Line = new Pen(randomColour);
            layer.Style.Line.Width = 1;

            //outline style
            layer.Style.Outline = Pens.Black;
            layer.Style.EnableOutline = true;

            //polygon style
            Brush brush = new SolidBrush(randomColour);
            layer.Style.Fill = brush;

            //antialias
            layer.SmoothingMode = SmoothingMode.AntiAlias;
        }

        //static data
        private void FillSystemDbLayers()
        {
            //bad version. need metadata + default styles in db
            systemLayersList.Items.Add(new NamedTable(SystemLayerNames.Countries));
            systemLayersList.Items.Add(new NamedTable(SystemLayerNames.Regions));
            systemLayersList.Items.Add(new NamedTable(SystemLayerNames.Rayons));
            systemLayersList.Items.Add(new NamedTable(SystemLayerNames.Settlements));
        }
        
        //TMP
        private bool IsRuralExists() 
        {
            var result = false;

            var connectionString = ConnectionManager.DefaultInstance.ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                var strSQL = "SELECT strLayer FROM gisMetadata WHERE strLayer='gisWKBRuralDistrict'";
                conn.Open();
                using (var command = new SqlCommand(strSQL, conn))
                {
                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr[0] != DBNull.Value)
                                result = true;
                        }
                    }
                }
                conn.Close();
            }

            return result;
        }

        private bool IsDistrictExists()
        {
            var result = false;

            var connectionString = ConnectionManager.DefaultInstance.ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                var strSQL = "SELECT strLayer FROM gisMetadata WHERE strLayer='gisWKBDistrict'";
                conn.Open();
                using (var command = new SqlCommand(strSQL, conn))
                {
                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr[0] != DBNull.Value)
                                result = true;
                        }
                    }
                }
                conn.Close();
            }

            return result;
        }

        private void FillExtSystemDbLayers()
        {
            //bad version. need metadata + default styles in db
            extSysLayersList.Items.Add(new NamedTable("gisWKBEarthRoad"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBHighway"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBInlandWater"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBLake"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBMainRiver"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBMajorRoad"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBRailroad"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBRiver"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBSea"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBSmallRiver"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBForest"));
            extSysLayersList.Items.Add(new NamedTable("gisWKBLanduse"));
            if (IsRuralExists()) extSysLayersList.Items.Add(new NamedTable("gisWKBRuralDistrict"));
            if (IsDistrictExists()) extSysLayersList.Items.Add(new NamedTable("gisWKBDistrict"));
        }

        //dynamic data
        private void RefreshUserLayers()
        {
            //update buf zones
            var layers = UserDbLayersManager.GetLayersMetadates(UserDbLayerType.BuffZones);
            var bufLayersTable = new DataTable("BufLayers");
            bufLayersTable.Columns.Add("ID",typeof(Guid));
            bufLayersTable.Columns.Add("LayerName");
            bufLayersTable.Columns.Add("Description");
            bufLayersTable.Columns.Add("User");
            bufLayersTable.Columns.Add("CreationDate");
            bufLayersTable.Columns.Add("PivotalLayer");
            

            foreach (var info in layers)
            {
                var row = bufLayersTable.NewRow();
                bufLayersTable.Rows.Add(new object[]
                {
                    info.m_Id,
                    info.m_Name,
                    info.m_Description,
                    Users.GetUserName(info.m_UserId), //info.m_UserId,//
                    info.m_CreationDate,
                    info.m_PivotalLayer
                }
                );
            }

            bufZoneLayersGrid.DataSource = bufLayersTable;
            if (bufLayersGridView.Columns["ID"] != null)
            {
                bufLayersGridView.Columns["ID"].Dispose();
                bufLayersGridView.Columns["CreationDate"].DisplayFormat.FormatType = FormatType.DateTime;
                bufLayersGridView.Columns["CreationDate"].DisplayFormat.FormatString = "d";
                bufLayersGridView.Columns["CreationDate"].Caption = Resources.gis_DbLayersForm_BufTable_CreationDate;
                bufLayersGridView.Columns["LayerName"].Caption = Resources.gis_DbLayersForm_BufTable_LayerName;
                bufLayersGridView.Columns["Description"].Caption = Resources.gis_DbLayersForm_BufTable_Description;
                bufLayersGridView.Columns["User"].Caption = Resources.gis_DbLayersForm_BufTable_User;
                bufLayersGridView.Columns["PivotalLayer"].Caption = Resources.gis_DbLayersForm_BufTable_PivotalLayer;
            }
        }

 
        
        //handlers
        private void LayersTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //activate/deactivate remove button
            if (LayersTabControl.SelectedTabPage == systemTab || LayersTabControl.SelectedTabPage == additionalTab)
            {
                RemoveButton.Visible = false;
                PropertiesButton.Visible = false;
            }
            else
            {
                RemoveButton.Visible = true;
                PropertiesButton.Visible = true;
            }
            //activate/deactivate add button
            CheckAddButtonEnable(this, null);
        }

        /// <summary>
        /// Add layer to the map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            using (new TemporaryWaitCursor())
            {
                if (LayersTabControl.SelectedTabPage == systemTab)
                {
                    SelectedLayer = new EidssSystemDbLayer(((NamedTable)systemLayersList.SelectedItem).m_Name);
                    SelectedLayer.DataSource = new EidssSqlServer2008(((NamedTable)systemLayersList.SelectedItem).m_Table);
                    GenerateRandomStyle(SelectedLayer);
                    Close();
                    return;
                }
                if (LayersTabControl.SelectedTabPage == additionalTab)
                {
                    SelectedLayer = new EidssExtSystemDbLayer(((NamedTable)extSysLayersList.SelectedItem).m_Name);
                    SelectedLayer.DataSource = new EidssSqlServer2008(((NamedTable)extSysLayersList.SelectedItem).m_Table);
                    GenerateRandomStyle(SelectedLayer);
                    Close();
                    return;
                }
                if (LayersTabControl.SelectedTabPage == bufZoneTab)
                {
                    if (bufLayersGridView.SelectedRowsCount!=1)
                        return;
                    var selectedRow = bufLayersGridView.GetDataRow(bufLayersGridView.FocusedRowHandle);
                    SelectedLayer = UserDbLayersManager.GetUserLayer((Guid)selectedRow[0]);
                    Close();
                    return;
                }

            }
        }

        /// <summary>
        /// Remove user layer from DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            using (new TemporaryWaitCursor())
            {
                Guid id = Guid.Empty;
                String name = string.Empty;

                if (LayersTabControl.SelectedTabPage == bufZoneTab && bufLayersGridView.SelectedRowsCount == 1)
                {
                    var selectedRow = bufLayersGridView.GetDataRow(bufLayersGridView.FocusedRowHandle);
                    id = (Guid)selectedRow[0];
                    name = (String)selectedRow[1];
                }

                if (id == Guid.Empty)
                    return;

                string title = Resources.gis_DbLayersForm_RemoveTitle;
                string question = string.Format(Resources.gis_DbLayersForm_RemoveQuestion,name);
                if (MessageForm.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                try
                {
                    UserDbLayersManager.DropUserLayer(id);
                    
                    var success_message = string.Format(Resources.gis_DbLayersForm_Remove, name);
                    MessageForm.Show(success_message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    var error_message = string.Format(Resources.gis_DbLayersForm_RemoveError, name);
                    ErrorForm.ShowError(error_message, ex);
                }

                RefreshUserLayers();
                CheckAddButtonEnable(this, null);
            }
        }


        private void DbLayersForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LayersTabControl_SelectedPageChanged(this, null);
                CheckAddButtonEnable(this, null);
            }

        }

        private void CheckAddButtonEnable(object sender, EventArgs e)
        {
            object selectedItem = null;
            if (LayersTabControl.SelectedTabPage == systemTab)
                selectedItem = systemLayersList.SelectedItem;
            if (LayersTabControl.SelectedTabPage == additionalTab)
                selectedItem = extSysLayersList.SelectedItem;
            if (LayersTabControl.SelectedTabPage == bufZoneTab) 
                selectedItem = bufLayersGridView.GetDataRow(bufLayersGridView.FocusedRowHandle); 
            AddButton.Enabled = selectedItem != null;
            PropertiesButton.Enabled = selectedItem != null;
            RemoveButton.Enabled = selectedItem != null;
        }

        private void PropertiesButton_Click(object sender, EventArgs e)
        {
            //get selected layer props
            var row=bufLayersGridView.GetDataRow(bufLayersGridView.FocusedRowHandle);
            var layerId = (Guid)row["ID"];
            UserDbLayerInfo layerInfo;
            try
            {
                layerInfo = UserDbLayersManager.GetLayerMetadata(layerId);
            }
            catch(Exception )
            {
                ErrorForm.ShowError(Resources.DbLayersFormFailedToObtainMetadata);
                return;
            }

            var propForm=new BufZonesLayer();
            propForm.ZoneLayerName = layerInfo.m_Name;
            propForm.Description = layerInfo.m_Description;
            propForm.PivotalLayer = layerInfo.m_PivotalLayer;
            propForm.PivotComboEnabled = false;
            if(propForm.ShowDialog(this)==DialogResult.OK)
            {
                var msgCaption = Resources.DbLayersForm_MsgBoxCaption;
                var msgText = Resources.DbLayersForm_SaveMetadataMsg;
                if (MessageForm.Show( msgText, msgCaption, MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                layerInfo.m_Name = propForm.ZoneLayerName;
                layerInfo.m_Description = propForm.Description;
                try
                {
                    UserDbLayersManager.UpdateUserLayerMetadata(layerInfo);
                }
                catch (Exception )
                {
                    ErrorForm.ShowErrorDirect(Resources.DbLayersForm_FailedToSaveMetadata);
                    return;
                }
                RefreshUserLayers();
            }
        }

    }

    struct NamedTable
    {
        public NamedTable(string tableName) //helper constructor
        {
            m_Table = tableName;
            m_Name = MapProjectsStorage.TranslateLayerName(tableName);
        }

        public string m_Table;
        public string m_Name;

        public override string ToString()
        {
            return m_Name;
        }
    }
}
