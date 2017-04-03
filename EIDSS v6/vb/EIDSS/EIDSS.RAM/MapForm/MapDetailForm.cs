using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.win;
using DevExpress.XtraEditors;
using eidss.avr.db.DBService;
using eidss.model.Avr.Commands.Models;

namespace eidss.avr.MapForm
{
    public partial class MapDetailForm : BaseDetailForm
    {
        private bool m_IsMapPosted;
        private readonly string m_LayoutName;
        

        public MapDetailForm()
        {
            InitializeComponent();

            if (IsDesignMode())
            {
                return;
            }

            DbService = new BaseAvrDbService();

            IgnoreAudit = true;
            RegisterChildObject(MapDetail, RelatedPostOrder.SkipPost);
            OnBeforePost += MapDetailForm_OnBeforePost;

            MapDetail.InitMap();

            ShowNewButton = false;
            ShowDeleteButton = false;
            ExportMapButton.Enabled = true;
            PrintMapButton.Enabled = true;
        }

        public MapDetailForm(Action<LookUpEdit> fillMapAdminUnitHandler, TryToPrepareMapDataHandler tryToPrepareMapData, 
            EventLayerSettings settings,string layoutName, bool isNewParentLayout)
            : this()
        {
            Utils.CheckNotNull(fillMapAdminUnitHandler, "fillMapAdminUnitHandler");
            Utils.CheckNotNull(tryToPrepareMapData, "tryToPrepareMapData");
            Utils.CheckNotNull(settings, "settings");

            m_LayoutName = layoutName;
            MapDetail.TryToPrepareMapDataHandler = tryToPrepareMapData;
            MapDetail.MapSettings = settings;

            //ShowSaveButton = !isNewParentLayout;
            //ShowOkButton = !isNewParentLayout;

            fillMapAdminUnitHandler(MapDetail.AdministrativeUnit);
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            OnBeforePost -= MapDetailForm_OnBeforePost;
            if (MapDetail != null)
            {
                UnRegisterChildObject(MapDetail);
                MapDetail.Dispose();
                MapDetail = null;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public DataSet DataSource { get; set; }

      
        public bool NeedSaveMapSettings
        {
            get { return m_IsMapPosted; }
        }

        public EventLayerSettings ChangedMapSettings
        {
            get { return MapDetail.MapSettings; }
        }

        public string MapAdminUnitViewColumn
        {
            get { return MapDetail.AdministrativeUnit.EditValue.ToString(); }
        }

        private void ExportMapButton_Click(object sender, EventArgs e)
        {
            MapDetail.ExportMap();
        }

        private void PrintMapButton_Click(object sender, EventArgs e)
        {
            MapDetail.PrintMap();
        }

        private void MapDetailForm_OnBeforePost(object sender, EventArgs e)
        {
            m_IsMapPosted = MapDetail.PostMap();
        }

        private void ChangeCaptionTimer_Tick(object sender, EventArgs e)
        {
            Form parentForm = FindForm();
            if (parentForm != null)
            {
                ChangeCaptionTimer.Stop();
                var resources = new ComponentResourceManager(typeof (MapDetailForm));
                string baseCaption = resources.GetString("$this.Caption");
                parentForm.Text = string.Format("{0} - {1}", baseCaption, m_LayoutName);
            }
        }
    }
}