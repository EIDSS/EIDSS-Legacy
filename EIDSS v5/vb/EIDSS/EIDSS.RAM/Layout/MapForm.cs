using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using EIDSS.Reports.OperationContext;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using bv.model.Model.Core;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using eidss.gis.Forms;
using eidss.model.Resources;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Views;

namespace EIDSS.RAM.Layout
{
    public partial class MapForm : BaseLayoutForm, IMapView
    {
        private AvrMapControl m_AvrMapControl;

        private readonly MapPresenter m_MapPresenter;
        public event EventHandler<ComboBoxEventArgs> InitAdmUnit;
        public event EventHandler<EventArgs> RefreshMap;

        public MapForm()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "MapForm creating...");

                m_MapPresenter = (MapPresenter) BaseRamPresenter;

                InitializeComponent();

                timerLoadMap.Start();
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                    throw;
                ErrorForm.ShowError(ex);
            }
        }

//
//        public override bool ReadOnly
//        {
//            get { return base.ReadOnly; }
//            set
//            {
//                base.ReadOnly = value;
//                tbMapName.Enabled = true;
//                memFilter.Enabled = true;
//                cbAdministrativeUnit.Enabled = true;
//            }
//        }

        public string FilterText
        {
            get { return memFilter.Text; }
            set { memFilter.Text = value; }
        }

        public string MapName
        {
            get { return tbMapName.Text; }
            set { tbMapName.Text = value; }
        }

        public object AdmUnitValue
        {
            get { return cbAdministrativeUnit.EditValue; }
        }

        public PrintingSystem PrintingSystem
        {
            get { return printingSystem; }
        }

        public Bitmap GetMapImage(double mmWidth, double mmHeight, int dpi)
        {
            //TODO[tkobilov] Make AvrMapControl.GetMapImage(mmWidth, mmHeight, dpi) 
            return AvrMapControl.GetMapImage(mmWidth, mmHeight, dpi); //current condition - 300dpi
        }

        public EventLayerSettings MapSettings
        {
            get
            {
                return
                    (m_AvrMapControl == null)
                        ? new EventLayerSettings()
                        : AvrMapControl.GetMapSettings();
            }
        }

        private AvrMapControl AvrMapControl
        {
            get
            {
                if (m_AvrMapControl == null)
                {
                    Trace.WriteLine(Trace.Kind.Info, "MapForm.InitGIS(): Initializing GIS component...");

                    m_AvrMapControl = new AvrMapControl {Parent = grcMapMain, Dock = DockStyle.Fill, Visible = true};
                    m_AvrMapControl.InitMap();
                    Trace.WriteLine(Trace.Kind.Info, "MapForm.InitGIS(): GIS Initialized");
                }

                return m_AvrMapControl;
            }
        }

        private void MapControlOnMapSettingsChanged()
        {
            m_MapPresenter.MapHasChanges = true;
        }

        public override bool HasChanges()
        {
            return m_MapPresenter.MapHasChanges || base.HasChanges();
        }

        protected override void DefineBinding()
        {
            Trace.WriteLine(Trace.Kind.Undefine, "MapForm.DefineBinding() call");
            using (SharedPresenter.ContextKeeper.CreateNewContext("DefineBinding"))
            {
                m_MapPresenter.BindMapName(tbMapName);
            }
        }

        public void UpdateMap(DataTable dataSource, EventLayerSettings settings, bool isSingle)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DenyMapRefresh))
                return;

            Utils.CheckNotNull(dataSource, "dataSource");
            Trace.WriteLine(Trace.Kind.Undefine, "MapForm.UpdateMap(): Refresh Map page");
            string title = EidssMessages.Get("msgPleaseWait");
            string caption = EidssMessages.Get("msgMapInitializing");

            string avrData = EidssMessages.Get("gis_avrData", "AVR Data", ModelUserContext.CurrentLanguage);

            using (new WaitDialog(caption, title))
            {
                AvrMapControl.RemoveAllEventLayers();
                //КЛЮЧ ISSINGLE (FALSE/TRUE) В ЗАВИСИМОСТИ ОТ ТИПА ТАБЛИЦЫ (ЕСТЬ РАЗБИВКА ПО ТИПАМ КЕЙСОВ, ИЛИ НЕТ)
                AvrMapControl.AddEventLayer(dataSource.TableName, avrData, dataSource, isSingle, settings);
            }
        }

        public void RaiseInitAdmUnitComboBox()
        {
            using (m_MapPresenter.SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.DenyMapRefresh))
            {
                InitAdmUnit.SafeRaise(this, new ComboBoxEventArgs(cbAdministrativeUnit, true));
            }
        }

        internal void ReInitMapIfExists()
        {
            // init only in case map already exists
            if (m_AvrMapControl != null)
            {
                m_AvrMapControl.InitMap();
            }
        }

        internal void RaiseImportSettingsIntoMapAndRefreshMap()
        {
            RefreshMap.SafeRaise(this, EventArgs.Empty);
        }

        private void cbMapField_EditValueChanged(object sender, EventArgs e)
        {
            if (!Utils.IsEmpty(cbAdministrativeUnit.EditValue))
            {
                RaiseImportSettingsIntoMapAndRefreshMap();
            }
        }

        private void timerLoadMap_Tick(object sender, EventArgs e)
        {
            try
            {
                timerLoadMap.Stop();
                bool initMap = Config.GetBoolSetting("InitMapOnStart");
                if (initMap)
                {
                    var events = new DataTable();
                    events.Columns.AddRange(new[]
                                                {
                                                    new DataColumn("id", typeof (long)),
                                                    new DataColumn("caption", typeof (string)),
                                                    new DataColumn("value", typeof (double))
                                                });

                    UpdateMap(events, new /*eidss.gis.*/ EventLayerSettings(), true);
                }
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                    throw;
                ErrorForm.ShowError(ex);
            }
        }

        #region Save changes in buffer zones if we are in edit mode
        public bool CancelMapChanges()
        {
            if (m_AvrMapControl == null) return false;

            var cea = new CancelEventArgs();
            m_AvrMapControl.OnLeavingMap(cea);
            return cea.Cancel;
        }
        #endregion

        #region Nav Bar Layout

        private void nbControlMaps_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
                nbControlMaps.Height = BaseRamPresenter.NavBarGroupHeaderHeight;
        }

        private void nbControlMaps_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlMaps.Height = nbGroupSettings.ControlContainer.Height +
                                       BaseRamPresenter.NavBarGroupHeaderHeight;
            }
        }

        #endregion

        private void cbAdministrativeUnit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            #region Save changes in buffer zones if we are in edit mode
            e.Cancel = CancelMapChanges();
            #endregion
        }
    }
}
