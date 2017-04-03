using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.Common;
using eidss.avr.ViewForm;
using eidss.gis.Forms;
using eidss.model.Avr.Commands.Models;
using eidss.model.Resources;

namespace eidss.avr.MapForm
{
    public partial class MapDetailPanel : BaseAvrDetailPresenterPanel, IMapView
    {
        private bool m_FirstTimeRefresh = true;
        private AvrMapControl m_MapControl;
        private MapPresenter m_MapPresenter;

        public MapDetailPanel()
        {
            try
            {
                m_MapPresenter = (MapPresenter) BaseAvrPresenter;

                InitializeComponent();
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                TryToPrepareMapDataHandler = null;
                MapSettings = null;
                if (m_MapPresenter != null)
                {
                    if (m_MapPresenter.SharedPresenter != null)
                    {
                        m_MapPresenter.SharedPresenter.UnregisterView(this);
                    }
                    m_MapPresenter.Dispose();
                    m_MapPresenter = null;
                }
                if (m_MapControl != null)
                {
                    m_MapControl.Dispose();
                    m_MapControl = null;
                }
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
            
        }

        public TryToPrepareMapDataHandler TryToPrepareMapDataHandler { get; internal set; }

        public EventLayerSettings MapSettings { get; internal set; }

        public LookUpEdit AdministrativeUnit
        {
            get { return cbAdministrativeUnit; }
        }

        public AvrMapControl MapControl
        {
            get
            {
                if (m_MapControl == null)
                {
                    m_MapControl = new AvrMapControl {Parent = grcMapMain, Dock = DockStyle.Fill, Visible = true};
                    m_MapControl.InitMap();
                }
                return m_MapControl;
            }
        }

        public override bool HasChanges()
        {
            return MapControl.HasChanges() || base.HasChanges();
        }

        public void RefreshMap()
        {
            string columnName;
            if (AvrViewHelper.TryGetCheckedComboSelValue(cbAdministrativeUnit.EditValue, out columnName))
            {
                DataSet mapData;
                if (TryToPrepareMapDataHandler(columnName, out mapData))
                {
                    Trace.WriteLine(Trace.Kind.Undefine, "MapForm.RefreshMap(): Refresh Map page");
                    string title = EidssMessages.Get("msgPleaseWait");
                    string caption = EidssMessages.Get("msgMapInitializing");

                    using (new WaitDialog(caption, title))
                    {
                        MapControl.RemoveAllEventLayers();

                        //КЛЮЧ ISSINGLE (FALSE/TRUE) В ЗАВИСИМОСТИ ОТ ТИПА ТАБЛИЦЫ (ЕСТЬ РАЗБИВКА ПО ТИПАМ КЕЙСОВ, ИЛИ НЕТ)
                        //MapControl.AddEventLayer(tempData.TableName, avrData, tempData, true, settings);
                        MapControl.AddEventLayer(mapData, MapSettings);
                    }
                }
            }
        }

        public bool PostMap()
        {
            if (CancelMapChanges())
            {
                return false;
            }
            MapSettings = MapControl.GetMapSettings() ?? new EventLayerSettings();
            return true;
        }

        public void PrintMap()
        {
            m_MapPresenter.PrintMap(printingSystem);
        }

        public void ExportMap()
        {
            m_MapPresenter.ExportMap();
        }

        internal void InitMap()
        {
            MapControl.InitMap();
        }

        private void cbMapField_EditValueChanged(object sender, EventArgs e)
        {
            if (!Utils.IsEmpty(cbAdministrativeUnit.EditValue))
            {
                // no need to post if map refreshes first time
                if (m_FirstTimeRefresh || Post())
                {
                    RefreshMap();
                    m_FirstTimeRefresh = false;
                }
            }
        }

        private void cbAdministrativeUnit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            // Save changes in buffer zones if we are in edit mode
            e.Cancel = CancelMapChanges();
        }

        public bool CancelMapChanges()
        {
            if (MapControl == null)
            {
                return false;
            }

            var cea = new CancelEventArgs();
            MapControl.OnLeavingMap(cea);
            return cea.Cancel;
        }
    }
}