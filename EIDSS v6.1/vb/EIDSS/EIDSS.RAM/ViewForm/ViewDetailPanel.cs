using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.Data;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using eidss.avr.BaseComponents;
using eidss.avr.ChartForm;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.avr.Handlers.DevExpressEventArgsWrappers;
using eidss.avr.MapForm;
using eidss.avr.PivotComponents;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.View;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using Convert = BLToolkit.Common.Convert;

namespace eidss.avr.ViewForm
{
    public sealed partial class ViewDetailPanel : BaseAvrDetailPresenterPanel, IViewDetailView
    {
        private ViewDetailPresenter m_ViewDetailPresenter;
        private readonly AggregateCashe m_AggrCache;
        private string m_OldAggrFunction = "";
        

        private bool m_AreHandlersAttached;
        public DisplayTextHandler DisplayTextHandler { get; private set; }

        public ViewDetailPanel()
        {
            try
            {
                InitializeComponent();

                if (IsDesignMode() || BaseSettings.ScanFormsMode)
                {
                    return;
                }

                m_ViewDetailPresenter = (ViewDetailPresenter) SharedPresenter[this];
                m_AggrCache = new AggregateCashe(m_ViewDetailPresenter);
                DisplayTextHandler = new DisplayTextHandler();
                RtlHelper.SetRTL(this);
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
                if (m_ViewDetailPresenter != null)
                {
                    if (m_ViewDetailPresenter.SharedPresenter != null)
                    {
                        m_ViewDetailPresenter.SharedPresenter.UnregisterView(this);
                    }
                    m_ViewDetailPresenter.Dispose();
                    m_ViewDetailPresenter = null;
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

        private bool OpenedFromNewLayout
        {
            get { return DbService != null && DbService.ParentService != null && DbService.ParentService.IsNewObject; }
        }

        public override bool HasChanges()
        {
            return m_ViewDetailPresenter.HasChanges();
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                //nothing
            }
        }

        #region Binding

        protected override void DefineBinding()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext("DefineBinding"))
            {
                BindAggregateFunctions();

                WinUtils.AddClearButton(cbAggregate);
                ViewDetailPresenter.AddClearButton(cbChartDefSeries);
                ViewDetailPresenter.AddClearButton(cbMapDefDataChart);
                WinUtils.AddClearButton(cbMapDefDataGradient);
                WinUtils.AddClearButton(cbChartDefXaxis);
                WinUtils.AddClearButton(cbMapDefAdminUnit);
                WinUtils.AddClearButton(cbColumn);
                WinUtils.AddClearButton(cbDenominator);

                if (!m_AreHandlersAttached)
                {
                    m_AreHandlersAttached = true;

                    cbMapDefAdminUnit.EditValueChanged += (cbMapDefAdminUnit_EditValueChanged);
                    cbMapDefDataGradient.EditValueChanged += (cbMapDefDataGradient_EditValueChanged);
                    cbMapDefDataChart.EditValueChanged += (cbMapDefDataChart_EditValueChanged);
                    cbChartDefSeries.EditValueChanged += (cbChartDefSeries_EditValueChanged);
                    cbColumn.EditValueChanged += (cbColumn_EditValueChanged);

                    cbDenominator.EditValueChanged += (cbDenominator_EditValueChanged);
                    spinPrecision.EditValueChanged += (spinPrecision_EditValueChanged);
                    cbChartDefXaxis.EditValueChanged += (cbChartDefXaxis_EditValueChanged);
                    cbAggregate.EditValueChanged += (cbAggregate_EditValueChanged);
                    cbAggregate.EditValueChanging += (cbAggregate_EditValueChanging);
                }
            }
        }

        private void FillChartMapCombos()
        {
            FillChartMapSeries();
            m_ViewDetailPresenter.FillChartXAxis(cbChartDefXaxis);
            m_ViewDetailPresenter.FillMapAdminUnit(cbMapDefAdminUnit);

            SetChartButtonEnable();
            SetMapButtonEnable();
        }

        private void FillChartMapSeries()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.FillChartSeries(cbChartDefSeries);
                m_ViewDetailPresenter.FillMapDiagramSeries(cbMapDefDataChart);
                m_ViewDetailPresenter.FillMapDataGradient(cbMapDefDataGradient);
            }
        }

        #region AggregateFunctions

        private void BindAggregateFunctions()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.SharedPresenter.BindAggregateFunctionsInternal(cbAggregate, AggregateFunctionTarget.View);

                tbAggregateColumnName.Text = string.Empty;

                //cbAggrPropertiesVisible(0 /*invisible*/, null /*band*/);
            }
        }

        private void cbAggrPropertiesVisible(long? daggrF)
        {
            switch (daggrF)
            {
                case (long) ViewAggregateFunction.CumulativePercent:
                case (long) ViewAggregateFunction.PercentOfColumn:
                case (long) ViewAggregateFunction.PercentOfRow:
                    cbAggrPropertiesVisible(1, ((AvrViewColumn) ((GridView) grid.MainView).FocusedColumn.Tag).Owner);
                    break;
                case (long) ViewAggregateFunction.Proportion:
                case (long) ViewAggregateFunction.Ratio:
                    cbAggrPropertiesVisible(2, ((AvrViewColumn) ((GridView) grid.MainView).FocusedColumn.Tag).Owner);
                    break;
                default: //'Max of row'//'Min of row'
                    cbAggrPropertiesVisible(0, null);
                    break;
            }
        }

        private void cbAggrPropertiesVisible(int visible, BaseBand band)
        {
            //visible = 0 - hide everything, 1 - column, 2 - numerator/denominator
            lblColumn.Visible = visible == 1;
            cbColumn.Visible = visible > 0;
            lblNumerator.Visible = visible == 2;
            lblDenominator.Visible = visible == 2;
            cbDenominator.Visible = visible == 2;
            if (visible > 0)
            {
                m_ViewDetailPresenter.FillBandColumns(cbColumn, band);
                if (visible == 2)
                {
                    m_ViewDetailPresenter.FillBandColumns(cbDenominator, band);
                }
            }
        }

        #endregion

        #endregion

        #region Refresh Grid

        private void RefreshGrid(AvrPivotViewModel model)
        {
            m_ViewDetailPresenter.AdjustToPivotView(model.ViewHeader);

            FillHeadAndData(model.ViewData);
            ResetViewButtonEnable(m_ViewDetailPresenter.View.IsDiffFromPivot());
        }

        private void FillHeadAndData(DataTable data)
        {
            bandedGridView1.BeginUpdate();

            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
            {
                ShowCurrentView();

                AvrViewHelper.AddIDColumn(ref data);

                AvrViewHelper.RemoveHASCadditions(m_ViewDetailPresenter.View, ref data);

                grid.DataSource = data;

                m_ViewDetailPresenter.View.setColumnsTypes((GridView) grid.MainView, m_AggrCache);

                FillChartMapCombos();

                // - forget all aggregate functions cashe of view
                RefreshUnboundData();
            }

            bandedGridView1.EndUpdate();
        }

        // creating the header of grid from Current object AvrView
        private void ShowCurrentView()
        {
            //hide band panel if there is only one band
            if (m_ViewDetailPresenter.View.Bands.Find(b => !b.IsToDelete) != null)
            {
                grid.MainView = bandedGridView1;
            }
            else
            {
                grid.MainView = gridView1;
            }

            m_ViewDetailPresenter.View.AddToGrid((GridView) grid.MainView);
        }

        #endregion

        #region Event handlers

        private void ViewDetailPanel_Load(object sender, EventArgs e)
        {
            grid.MainView.BeginUpdate();

            ((GridView) grid.MainView).OptionsMenu.EnableColumnMenu = true;
            ((GridView) grid.MainView).OptionsCustomization.AllowColumnMoving = true;
            ((GridView) grid.MainView).OptionsCustomization.AllowQuickHideColumns = true;

            grid.MainView.EndUpdate();
        }

        // after pivot grid reloaded : load data to the view from the pivot grid
        public void OnPivotDataLoaded(PivotGridDataLoadedCommand command)
        {
            RefreshGrid(command.Model);
        }

        #region Print/Export

        public void OnPrint()
        {
            // Check whether the GridControl can be previewed.
            if (!grid.IsPrintingAvailable)
            {
                MessageForm.Show(EidssMessages.Get("msgDevExpressXtraPrintingNotFound"), EidssMessages.Get("ErrErrorFormCaption"),
                    MessageBoxButtons.OK);
                return;
            }

            // Open the Preview window.
            var ps = new PrintingSystem();

            var compositeLink = new CompositeLink {PrintingSystem = ps};
            var link = new PrintableComponentLink {Component = grid};
            compositeLink.Links.Add(link);

            compositeLink.CreateDocument();
            compositeLink.ShowPreview();
            if (ps.PreviewFormEx != null && ps.PreviewFormEx.PrintBarManager != null)
            {
                AvrPrintingLink.Init(ps.PreviewFormEx.PrintBarManager);
            }

            //grid.ShowPrintPreview();
        }

        public void OnExport(ExportType exportType)
        {
            // Check whether the GridControl can be previewed.
            if (!grid.IsPrintingAvailable)
            {
                MessageForm.Show(EidssMessages.Get("msgDevExpressXtraPrintingNotFound"), EidssMessages.Get("ErrErrorFormCaption"),
                    MessageBoxButtons.OK);
                return;
            }

            switch (exportType)
            {
                case ExportType.Pdf:
                    m_ViewDetailPresenter.ExportTo("pdf",
                        EidssMessages.Get("msgFilterPdf", "PDF documents|*.pdf"),
                        ExportPdf);
                    break;

                case ExportType.Xlsx:
                    m_ViewDetailPresenter.ExportTo("xlsx",
                        EidssMessages.Get("msgFilterExcelXLSX", "Excel documents|*.xlsx"),
                        ExportXlsx);
                    break;

                case ExportType.Xls:
                    m_ViewDetailPresenter.ExportTo("xls",
                        EidssMessages.Get("msgFilterExcel", "Excel documents|*.xls"),
                        ExportXls);
                    break;

                case ExportType.Rtf:
                    m_ViewDetailPresenter.ExportTo("rtf",
                        EidssMessages.Get("msgFilterRtf", "Rich text documents|*.rtf"),
                        grid.ExportToRtf);
                    break;

                default:
                    throw new AvrException("Not supported export type: " + exportType);
            }
        }

        private void ExportPdf(string fileName)
        {
            var view = grid.MainView
                as GridView;
            if (view != null)
            {
                bool bRah = view.OptionsView.RowAutoHeight;
                view.OptionsView.RowAutoHeight = true;
                //view.BestFitColumns();
                view.ExportToPdf(fileName);

                view.OptionsView.ColumnAutoWidth = false;
                view.OptionsView.RowAutoHeight = bRah;
            }
        }

        private void ExportXls(string fileName)
        {
            var ps = new PrintingSystem();

            var options = new XlsExportOptions {TextExportMode = TextExportMode.Value};

            var compositeLink = new CompositeLink {PrintingSystem = ps};
            var link = new PrintableComponentLink {Component = grid};
            compositeLink.Links.Add(link);
            try
            {
                compositeLink.ExportToXls(fileName, options);
            }
            catch (Exception e)
            {
                MessageForm.Show(e.Message, "", MessageBoxButtons.OK);
            }
        }

        private void ExportXlsx(string fileName)
        {
            var ps = new PrintingSystem();

            var options = new XlsxExportOptions {TextExportMode = TextExportMode.Value};

            var compositeLink = new CompositeLink {PrintingSystem = ps};
            var link = new PrintableComponentLink {Component = grid};
            compositeLink.Links.Add(link);
            compositeLink.ExportToXlsx(fileName, options);
        }

        #endregion

        // forget view settings
        private void ResetViewButton_Click(object sender, EventArgs e)
        {
            if (
                MessageForm.Show(
                    EidssMessages.Get("msgConfirmResetViewPanel", "Do you want to reset the view? All view settings will be cleared."), "",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m_ViewDetailPresenter.Reset();

                DataTable data = null;
                if (grid.DataSource is DataView)
                {
                    data = ((DataView) grid.DataSource).Table;
                }
                else if (grid.DataSource is DataTable)
                {
                    data = (DataTable) grid.DataSource;
                }
                grid.DataSource = null;
                FillHeadAndData(data);

                ResetViewButtonEnable(false);
            }
        }

        // button "Refresh Data" was clicked
        private void RefreshDataButton_Click(object sender, EventArgs e)
        {
            RaiseResendDataFromPivot();
        }

        private void RaiseResendDataFromPivot()
        {
            RaiseSendCommand(new QueryLayoutCommand(this, QueryLayoutOperation.RefreshQuery));
        }

        #region Combos for AggregateFunctions

        private void cbAggregate_EditValueChanging(object sender, ChangingEventArgs e)
        {
            m_OldAggrFunction = cbAggregate.Text;
        }

        private void cbAggregate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions) ||
                    ((GridView) grid.MainView).FocusedColumn == null ||
                    !((AvrViewColumn) ((GridView) grid.MainView).FocusedColumn.Tag).IsAggregate)
                {
                    return;
                }

                var col = ((GridView) grid.MainView).FocusedColumn.Tag as AvrViewColumn;
                if (col != null)
                {
                    if (cbAggregate.EditValue is long)
                    {
                        var id = (long) cbAggregate.EditValue;

                        col.AggregateFunction = id;
                        DataRow r = ((DataView) cbAggregate.Properties.DataSource).Table.Rows.Find(id.ToString());

                        spinPrecision.Text = r["intDefaultPrecision"].ToString();
                        col.Precision = (int) r["intDefaultPrecision"];

                        cbAggrPropertiesVisible(id);

                        if (col.DisplayText == EidssMessages.Get("AggregateColumn", "Aggregate Column") ||
                            col.DisplayText == m_OldAggrFunction)
                        {
                            col.DisplayText = cbAggregate.Text;
                            ((GridView) grid.MainView).FocusedColumn.Caption = col.DisplayText;
                        }
                    }
                    else
                    {
                        col.AggregateFunction = null;
                    }

                    m_OldAggrFunction = "";
                    col.setAggrColumnType(((GridView) grid.MainView).FocusedColumn, getRatio(col.AggregateFunction), m_AggrCache);
                }
                RefreshVisibleAreaOfColumn((GridView) grid.MainView, ((GridView) grid.MainView).FocusedColumn);
                FillChartMapSeries();
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

        private void spinPrecision_EditValueChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions) ||
                ((GridView) grid.MainView).FocusedColumn == null)
            {
                return;
            }

            var col = ((GridView) grid.MainView).FocusedColumn.Tag as AvrViewColumn;
            if (col != null)
            {
                if (!col.IsAggregate || col.AggregateFunction == null || spinPrecision.EditValue == null)
                {
                    col.SetPrecision = null;
                }
                else
                {
                    col.SetPrecision = int.Parse(spinPrecision.Text);
                }

                if (col.IsAggregate)
                {
                    col.setAggrColumnType(((GridView) grid.MainView).FocusedColumn, getRatio(col.AggregateFunction), m_AggrCache);
                    FillChartMapSeries();
                }
            }

            RefreshVisibleAreaOfColumn((GridView) grid.MainView, ((GridView) grid.MainView).FocusedColumn);
        }

        private void cbColumn_EditValueChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions) ||
                ((GridView) grid.MainView).FocusedColumn == null)
            {
                return;
            }

            var columnID = (string) cbColumn.EditValue;

            var col = ((GridView) grid.MainView).FocusedColumn.Tag as AvrViewColumn;
            if (col != null)
            {
                col.SourceViewColumn = columnID;

                col.setAggrColumnType(((GridView) grid.MainView).FocusedColumn, getRatio(col.AggregateFunction), m_AggrCache);
            }
            RefreshVisibleAreaOfColumn((GridView) grid.MainView, ((GridView) grid.MainView).FocusedColumn);
            FillChartMapSeries();
        }

        private void cbDenominator_EditValueChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions) ||
                ((GridView) grid.MainView).FocusedColumn == null ||
                !((AvrViewColumn) ((GridView) grid.MainView).FocusedColumn.Tag).IsAggregate)
            {
                return;
            }
            Trace.WriteLine(Trace.Kind.Undefine, "ViewDetailForm.cbDenominator_EditValueChanged()");

            var denomrID = (string) cbDenominator.EditValue;

            var col = ((GridView) grid.MainView).FocusedColumn.Tag as AvrViewColumn;
            if (col != null)
            {
                col.DenominatorViewColumn = denomrID;

                col.setAggrColumnType(((GridView) grid.MainView).FocusedColumn, getRatio(col.AggregateFunction), m_AggrCache);
            }

            RefreshVisibleAreaOfColumn((GridView) grid.MainView, ((GridView) grid.MainView).FocusedColumn);
            FillChartMapSeries();
        }

        private void RefreshVisibleAreaOfColumn(GridView view, GridColumn col)
        {
            var vi = (GridViewInfo) view.GetViewInfo();
            int visibleCount = vi.RowsInfo.GetScrollableRowsCount(view);

            int currentRowHandle = view.GetVisibleRowHandle(view.TopRowIndex);

            for (int i = 0; i < visibleCount && currentRowHandle != GridControl.InvalidRowHandle; i++)
            {
                view.RefreshRowCell(currentRowHandle, col);

                currentRowHandle = view.GetNextVisibleRow(currentRowHandle);
            }
        }

        private bool getRatio(long? aggrFunction)
        {
            bool ratio = false;
            var columnID = (string) cbColumn.EditValue;
            var denomrID = (string) cbDenominator.EditValue;
            switch (aggrFunction)
            {
                case (long) ViewAggregateFunction.CumulativePercent:
                case (long) ViewAggregateFunction.PercentOfColumn:
                case (long) ViewAggregateFunction.PercentOfRow:
                    if (columnID == null)
                    {
                        ratio = true;
                    }
                    break;
                case (long) ViewAggregateFunction.Proportion:
                    if (columnID == null || denomrID == null)
                    {
                        ratio = true;
                    }
                    break;
                case (long) ViewAggregateFunction.Ratio:
                    if (columnID == null || denomrID == null)
                    {
                        ratio = true;
                    }
                    //else if (((GridView) grid.MainView).Columns.ColumnByFieldName(columnID).ColumnType == typeof (int) &&
                    //         ((GridView) grid.MainView).Columns.ColumnByFieldName(denomrID).ColumnType == typeof (int))
                    //{
                    ratio = true;
                    //}
                    break;
            }
            return ratio;
        }

        #endregion

        #region Chart/Map

        #region Chart/Map Comboboxes

        private void cbChartDefSeries_EditValueChanged(object sender, EventArgs e)
        {
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.FillColumnsBooleans(((CheckedComboBoxEdit) sender).EditValue, "IsChartSeries");
            }
            ResetViewButtonEnable(true);
        }

        private void cbMapDefDataChart_EditValueChanged(object sender, EventArgs e)
        {
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.FillColumnsBooleans(((CheckedComboBoxEdit) sender).EditValue, "IsMapDiagramSeries");
            }
            ResetViewButtonEnable(true);
        }

        private void cbMapDefDataGradient_EditValueChanged(object sender, EventArgs e)
        {
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.FillColumnsBooleans(((BaseEdit) sender).EditValue, "IsMapGradientSeries");
            }
            ResetViewButtonEnable(true);
        }

        private void cbChartDefXaxis_EditValueChanged(object sender, EventArgs e)
        {
            object selCol = ((BaseEdit) sender).EditValue;
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.SaveColumnsDefs(Utils.IsEmpty(selCol)
                    ? null
                    : selCol.ToString(), "ChartXAxisViewColumn");
            }

            SetChartButtonEnable();
            ResetViewButtonEnable(true);
        }

        private void cbMapDefAdminUnit_EditValueChanged(object sender, EventArgs e)
        {
            object selCol = ((BaseEdit) sender).EditValue;
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                m_ViewDetailPresenter.SaveColumnsDefs(Utils.IsEmpty(selCol)
                    ? null
                    : selCol.ToString(), "MapAdminUnitViewColumn");
            }

            SetMapButtonEnable();
        }

        #endregion

        private void OpenChartButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // have we anything selected in combo Xaxis? 
            string[] selCols = AvrViewHelper.GetCheckedComboSelValues(cbChartDefXaxis.EditValue);
            if (selCols.Length != 1) //(this situation is impossible)
            {
                return;
            }

            // remember columns for future DataTable
            List<AvrViewColumn> chartColumns = m_ViewDetailPresenter.FillSeriesColumns((GridView) grid.MainView, cbChartDefSeries, null);

            // remember rows for future DataTable
            Dictionary<int, DataRow> xAxisRows = m_ViewDetailPresenter.FillXAxisData((GridView) grid.MainView, selCols[0]);

            // have we duplicates? - remove everything
            /*List<DataRow> l = new List<DataRow>(XAxisRows.Values);
            if (ViewDetailPresenter.hasDuplicates(l.ConvertAll(x => x[selCols[0]])))
            {
                MessageForm.Show(EidssMessages.Get("msgDuplicatesInXAxis"), "", MessageBoxButtons.OK);
                return;
            }*/

            // fill DataTable !!!
            DataTable dt = m_ViewDetailPresenter.CreateDataForChart(selCols[0], chartColumns, xAxisRows, m_AggrCache,
                (GridView) grid.MainView);

            object id = m_ViewDetailPresenter.LayoutID();

            ChartDetailForm chartForm;
            using (PresenterFactory.BeginSharedPresenterTransaction(SharedPresenter))
            {
                chartForm = new ChartDetailForm();
            }
            try
            {
                chartForm.DataSource = dt;
                chartForm.SetXml(m_ViewDetailPresenter.View.ChartLocalSettingsXml);
                bool isOkResult = BaseFormManager.ShowModal(chartForm, this, ref id, null, null);

                SetChartSettingsToModel(chartForm.GetXml(), isOkResult && chartForm.NeedSave());
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                chartForm.Dispose();
            }

            Cursor.Current = Cursors.Default;
        }

        private void OpenMapButton_Click(object sender, EventArgs e)
        {
            string columnName;
            if (AvrViewHelper.TryGetCheckedComboSelValue(cbMapDefAdminUnit.EditValue, out columnName))
            {
                DataSet dataSet;
                if (TryToPrepareMapData(columnName, out dataSet))
                {
                    EventLayerSettings mapSettings = GetMapSettingsFromModel();
                    MapDetailForm mapForm;
                    using (PresenterFactory.BeginSharedPresenterTransaction(SharedPresenter))
                    {
                        mapForm = new MapDetailForm(m_ViewDetailPresenter.FillMapAdminUnit, TryToPrepareMapData,
                            mapSettings, m_ViewDetailPresenter.View.LayoutName, OpenedFromNewLayout);
                    }
                    try
                    {
                        object id = m_ViewDetailPresenter.LayoutID();
                        BaseFormManager.ShowModal(mapForm, this, ref id, null, null);

                        SetMapSettingsToModel(mapForm.ChangedMapSettings, mapForm.NeedSaveMapSettings, mapForm.MapAdminUnitViewColumn);
                    }
                    finally
                    {
                        mapForm.Dispose();
                    }
                }
            }
        }

        private EventLayerSettings GetMapSettingsFromModel()
        {
            var mapSettings = new EventLayerSettings();
            if (!string.IsNullOrEmpty(m_ViewDetailPresenter.View.GisMapLocalSettingsXml))
            {
                mapSettings.MapSettings = Convert.ToXmlDocument(m_ViewDetailPresenter.View.GisMapLocalSettingsXml);
            }
            if (!string.IsNullOrEmpty(m_ViewDetailPresenter.View.GisLayerLocalSettingsXml))
            {
                mapSettings.LayerSettings = Convert.ToXmlDocument(m_ViewDetailPresenter.View.GisLayerLocalSettingsXml);
            }
            mapSettings.Position = m_ViewDetailPresenter.View.GisLayerPosition.HasValue
                ? m_ViewDetailPresenter.View.GisLayerPosition.Value
                : 0;
            return mapSettings;
        }

        private void SetMapSettingsToModel(EventLayerSettings settings, bool isChanged, string sMapAdminUnit)
        {
            Utils.CheckNotNull(settings, "settings");
            if (isChanged)
            {
                m_ViewDetailPresenter.View.GisLayerPosition = settings.Position;
                m_ViewDetailPresenter.View.GisMapLocalSettingsXml = Convert.ToString(settings.MapSettings);
                m_ViewDetailPresenter.View.GisLayerLocalSettingsXml = Convert.ToString(settings.LayerSettings);
            }

            m_ViewDetailPresenter.View.MapAdminUnitViewColumn = sMapAdminUnit;
            cbMapDefAdminUnit.EditValue = sMapAdminUnit;
        }

        private void SetChartSettingsToModel(string settings, bool isChanged)
        {
            Utils.CheckNotNull(settings, "settings");
            if (isChanged)
            {
                m_ViewDetailPresenter.View.ChartLocalSettingsXml = settings;
            }
        }

        private bool TryToPrepareMapData(string columnName, out DataSet data)
        {
            // remember columns for future DataTable
            List<AvrViewColumn> mapColumns = m_ViewDetailPresenter.FillSeriesColumns((GridView) grid.MainView, cbMapDefDataChart,
                cbMapDefDataGradient);

            // remember rows for future DataTable
            Dictionary<int, DataRow> xAxisRows = m_ViewDetailPresenter.FillXAxisData((GridView) grid.MainView, columnName);

            //remove * strings
            xAxisRows.ToList().FindAll(d => ((string) d.Value[columnName]).Equals("*")).ForEach(d => xAxisRows.Remove(d.Key));

            if (xAxisRows != null && xAxisRows.Count > 0 &&
                xAxisRows[xAxisRows.Keys.FirstOrDefault()].Table.Columns.Contains(columnName + "hasc"))
            {
                columnName = columnName + "hasc";
            }

            // have we duplicates? - remove everything
            if (xAxisRows != null)
            {
                var l = new List<DataRow>(xAxisRows.Values);
                if (AvrViewHelper.hasDuplicates(l.ConvertAll(v => v[columnName])))
                {
                    data = new DataSet();
                    MessageForm.Show(EidssMessages.Get("msgDuplicatesInAdmUnit"), "", MessageBoxButtons.OK);
                    return false;
                }
            }

            // fill DataSet with 2 DataTable !!!
            bool useDefaults = false;
            // nothing selected in table and something selected in defaults - use defaults
            if (((GridView) grid.MainView).GetSelectedCells().Length <= 1 &&
                ((cbMapDefDataChart.EditValue.ToString().Length > 0) ||
                 (cbMapDefDataGradient != null && cbMapDefDataGradient.EditValue != null &&
                  cbMapDefDataGradient.EditValue.ToString().Length > 0)))
            {
                useDefaults = true;
            }
            data = m_ViewDetailPresenter.CreateDataForMap(columnName, mapColumns, xAxisRows, m_AggrCache, (GridView) grid.MainView,
                useDefaults);
            return true;
        }

        #endregion

        #endregion

        #region Grid Event handlers

        #region AggregateFunctions

        // show/hide aggregate function controls
        private void bandedGridView1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == null || e.FocusedColumn.Tag == null || !((AvrViewColumn) e.FocusedColumn.Tag).IsAggregate)
            {
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
                {
                    cbAggregate.Enabled = false;
                    spinPrecision.Enabled = false;
                    spinPrecision.Text = "";
                }
                tbAggregateColumnName.Text = "";
                cbAggrPropertiesVisible(0, null);
                return;
            }

            var aColumn = (AvrViewColumn) e.FocusedColumn.Tag;

            cbAggregate.Enabled = true;
            spinPrecision.Enabled = true;
            tbAggregateColumnName.Text = aColumn.DisplayText;

            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
            {
                cbAggregate.EditValue = aColumn.AggregateFunction;

                if (aColumn.Precision != null)
                {
                    spinPrecision.EditValue = aColumn.Precision;
                }
            }

            cbColumn.EditValue = aColumn.SourceViewColumn;

            cbDenominator.EditValue = aColumn.DenominatorViewColumn;

            cbAggrPropertiesVisible(aColumn.AggregateFunction);
        }

        #endregion

        #region ContextMenu

        // configure context menu as required
        private void bandedGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                //Erasing the default menu items
                if (e.Menu is GridViewColumnMenu)
                {
                    var menu = e.Menu as GridViewColumnMenu;
                    foreach (DXMenuItem item in menu.Items)
                    {
                        switch ((GridStringId) item.Tag)
                        {
                            case GridStringId.MenuColumnGroup:
                            case GridStringId.MenuColumnGroupBox:
                            case GridStringId.MenuColumnBestFit:
                            case GridStringId.MenuColumnBestFitAllColumns:
                            case GridStringId.MenuColumnFilterEditor:
                            case GridStringId.MenuColumnFindFilterShow:
                            case GridStringId.MenuColumnRemoveColumn:
                                item.Visible = false;
                                break;
                            case GridStringId.MenuColumnBandCustomization:
                                item.BeginGroup = false;
                                break;
                        }
                    }
                }

                //Adding new items
                if (e.Menu is GridViewBandMenu)
                {
                    var menu = e.Menu as GridViewBandMenu;
                    var hi = e.HitInfo as BandedGridHitInfo;

                    if (hi != null && hi.Band.Visible)
                    {
                        //Adding new items
                        bool bFr = hi.Band.Fixed == FixedStyle.Left;
                        int pol = 0;
                        if (hi.Band.ParentBand == null)
                        {
                            menu.Items.Insert(0, CreateMenuItem(EidssMessages.Get("FreezeBand"), hi.Band, false, !bFr, OnFixedClick));
                            menu.Items.Insert(1, CreateMenuItem(EidssMessages.Get("UnfreezeBand"), hi.Band, false, bFr, OnUnFixedClick));
                            pol = 2;
                        }
                        menu.Items.Insert(pol,
                            CreateMenuItem(EidssMessages.Get("UnfreezeAllBands"), hi.Band, false, m_ViewDetailPresenter.HasFreezedBands(),
                                OnUnFixedAllClick));
                        menu.Items.Insert(pol + 1, CreateMenuItem(EidssMessages.Get("HideBand"), hi.Band, true, true, OnRemoveBandClick));
                        menu.Items.Add(CreateMenuItem(EidssMessages.Get("RenameBand"), hi.Band, true, true, OnRenameBandItemClick));
                        if (hi.Band.Columns.Count > 0)
                        {
                            menu.Items.Add(CreateMenuItem(EidssMessages.Get("btAddAggregateColumn"), hi.Band, true, true,
                                OnAddAggregateColumn));
                        }
                    }
                }
                else if (e.Menu is GridViewColumnMenu)
                {
                    var menu = e.Menu as GridViewColumnMenu;
                    //Adding new items
                    if (menu.Column != null && menu.Column.Visible)
                    {
                        if (!(menu.Column is BandedGridColumn))
                        {
                            bool bFr = menu.Column.Fixed == FixedStyle.Left;
                            menu.Items.Add(CreateMenuItem(EidssMessages.Get("FreezeColumn"), menu.Column, true, !bFr, OnFixedColClick));
                            menu.Items.Add(CreateMenuItem(EidssMessages.Get("UnfreezeColumn"), menu.Column, false, bFr, OnUnFixedColClick));
                            menu.Items.Add(CreateMenuItem(EidssMessages.Get("UnfreezeAllColumns"), menu.Column, false,
                                m_ViewDetailPresenter.HasFreezedColumns(), OnUnFixedAllColClick));
                        }
                        menu.Items.Add(CreateMenuItem(EidssMessages.Get("HideColumn"), menu.Column, true, true, OnHideColumn));
                        menu.Items.Add(CreateMenuItem(EidssMessages.Get("RenameColumn"), menu.Column, false, true, OnRenameColumnItemClick));
                        menu.Items.Add(CreateMenuItem(EidssMessages.Get("btAddAggregateColumn"), menu.Column, true, true,
                            OnAddAggregateColumn));
                        if (((AvrViewColumn) menu.Column.Tag).IsAggregate)
                        {
                            menu.Items.Add(CreateMenuItem(EidssMessages.Get("DeleteAggregateColumn"), menu.Column, false, true,
                                OnDeleteAggregateColumn));
                        }
                    }
                }
            }
        }

        //Create a Band menu item 
        private DXMenuItem CreateMenuItem(string caption, GridBand band, bool bBeginGroup, bool bEnabled, EventHandler eventHandler)
        {
            var item = new DXMenuItem(caption, eventHandler)
            {
                Tag = band,
                BeginGroup = bBeginGroup,
                Enabled = bEnabled,
            };
            return item;
        }

        //Create a Column menu item 
        private DXMenuItem CreateMenuItem(string caption, GridColumn column, bool bBeginGroup, bool bEnabled, EventHandler eventHandler)
        {
            var item = new DXMenuItem(caption, eventHandler)
            {
                Tag = column,
                BeginGroup = bBeginGroup,
                Enabled = bEnabled,
            };
            return item;
        }

        //  Remove Column
        private void OnHideColumn(object sender, EventArgs e)
        {
            // MenuColumnRemoveColumn
            var gColumn = (GridColumn) ((DXMenuItem) sender).Tag;
            var aColumn = (AvrViewColumn) gColumn.Tag;
            aColumn.IsVisible = false;
            gColumn.Visible = false;

            ResetViewButtonEnable(true);
            FillChartMapCombos();
        }

        //  Remove Band
        private void OnRemoveBandClick(object sender, EventArgs e)
        {
            var gBand = (GridBand) ((DXMenuItem) sender).Tag;
            var aBand = (AvrViewBand) gBand.Tag;
            gBand.Visible = false;
            aBand.IsVisible = false;

            ResetViewButtonEnable(true);
            FillChartMapCombos();
        }

        //  Rename Column
        private void OnRenameColumnItemClick(object sender, EventArgs e)
        {
            var gColumn = (GridColumn) ((DXMenuItem) sender).Tag;
            var aColumn = (AvrViewColumn) gColumn.Tag;
            var gView = (GridView) gColumn.View;
            Rectangle columnBounds = ((GridViewInfo) gView.GetViewInfo()).ColumnsInfo[gColumn].Bounds;
            var formLocation = new Point(columnBounds.Left, columnBounds.Bottom);
            formLocation = gView.GridControl.PointToScreen(formLocation);
            aColumn.DisplayText = RenameColumnForm.Input(EidssMessages.Get("NewColumnName"), EidssMessages.Get("RenameColumn"),
                aColumn.OriginalName, EidssMessages.Get("OriginalColumnName"), aColumn.DisplayText, formLocation);
            gColumn.Caption = aColumn.DisplayText;

            ResetViewButtonEnable(true);
            FillChartMapCombos();
        }

        //  Rename Band
        private void OnRenameBandItemClick(object sender, EventArgs e)
        {
            var gBand = (GridBand) ((DXMenuItem) sender).Tag;
            var aBand = (AvrViewBand) gBand.Tag;
            var gView = (GridView) gBand.View;
            //Rectangle clBounds = ((GridViewInfo)gView.GetViewInfo()).ColumnsInfo[gBand.Columns[0]].Bounds;
            var formLocation = new Point(0, 0); //(clBounds.Left, clBounds.Top);
            formLocation = gView.GridControl.PointToScreen(formLocation);
            aBand.DisplayText = RenameColumnForm.Input(EidssMessages.Get("NewBandName"), EidssMessages.Get("RenameBand"), aBand.OriginalName,
                EidssMessages.Get("OriginalBandName"), aBand.DisplayText, formLocation);
            gBand.Caption = aBand.DisplayText;

            ResetViewButtonEnable(true);
            FillChartMapCombos();
        }

        #region Freezing/Unfreezing

        //  Freeze Band
        private void OnFixedClick(object sender, EventArgs e)
        {
            OnFreezeClick((GridBand) ((DXMenuItem) sender).Tag, true);
        }

        //  Unfreeze Band
        private void OnUnFixedClick(object sender, EventArgs e)
        {
            OnFreezeClick((GridBand) ((DXMenuItem) sender).Tag, false);
        }

        private void OnFreezeClick(GridBand gBand, bool bFreeze)
        {
            var aBand = (AvrViewBand) gBand.Tag;
            aBand.IsFreezed = bFreeze;
            gBand.Fixed = bFreeze ? FixedStyle.Left : FixedStyle.None;
            ChangeBandsOrderOfBand(gBand);
        }

        //  Unfreeze All Bands
        private void OnUnFixedAllClick(object sender, EventArgs e)
        {
            GridBandCollection topBands = ((GridBand) ((DXMenuItem) sender).Tag).View.Bands;
            for (int i = topBands.Count - 1; i >= 0; i--)
            {
                if (topBands[i].Fixed == FixedStyle.Left)
                {
                    var aBand = (AvrViewBand) topBands[i].Tag;
                    aBand.IsFreezed = false;
                    topBands[i].Fixed = FixedStyle.None;
                }
            }
            ChangeBandsOrderOfBand(topBands[0]);
        }

        //  Freeze Column
        private void OnFixedColClick(object sender, EventArgs e)
        {
            OnFreezeColClick((GridColumn) ((DXMenuItem) sender).Tag, true);
        }

        //  Unfreeze Column
        private void OnUnFixedColClick(object sender, EventArgs e)
        {
            OnFreezeColClick((GridColumn) ((DXMenuItem) sender).Tag, false);
        }

        private void OnFreezeColClick(GridColumn gColumn, bool bFreeze)
        {
            var aColumn = (AvrViewColumn) gColumn.Tag;
            aColumn.IsFreezed = bFreeze;
            gColumn.Fixed = bFreeze ? FixedStyle.Left : FixedStyle.None;
            ChangeColumnsOrderOfBand(gColumn, false);
        }

        //  Unfreeze All Columns
        private void OnUnFixedAllColClick(object sender, EventArgs e)
        {
            GridColumnCollection topBands = ((GridColumn) ((DXMenuItem) sender).Tag).View.Columns;
            for (int i = topBands.Count - 1; i >= 0; i--)
            {
                if (topBands[i].Fixed == FixedStyle.Left)
                {
                    var aBand = (AvrViewColumn) topBands[i].Tag;
                    aBand.IsFreezed = false;
                    topBands[i].Fixed = FixedStyle.None;
                }
            }
            ChangeColumnsOrderOfBand(topBands[0], false);
        }

        #endregion

        // Add Aggregate Column
        private void OnAddAggregateColumn(object sender, EventArgs e)
        {
            if (((DXMenuItem) sender).Tag is GridBand)
            {
                var gBandParent = (GridBand) ((DXMenuItem) sender).Tag;
                AddAggregateColumn((BaseBand) gBandParent.Tag, gBandParent.Columns);
            }
            else if (((DXMenuItem) sender).Tag is BandedGridColumn)
            {
                var gColumn = (BandedGridColumn) ((DXMenuItem) sender).Tag;
                AddAggregateColumn((BaseBand) gColumn.OwnerBand.Tag, gColumn.OwnerBand.Columns);
            }
            else if (((DXMenuItem) sender).Tag is GridColumn)
            {
                var gColumn = (GridColumn) ((DXMenuItem) sender).Tag;
                AddAggregateColumn((BaseBand) gColumn.View.Tag, gColumn.View.Columns);
            }
        }

        private void AddAggregateColumn(BaseBand aBand, CollectionBase columns)
        {
            // adding: to model, to grid, to aggregate cashe
            AvrViewColumn newCol = aBand.AddAggregateColumn();

            if (newCol != null)
            {
                var gv = (GridView) grid.MainView;
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
                {
                    newCol.AddToGrid(columns, gv);
                }
                m_AggrCache.AddColumn(newCol.LayoutSearchFieldName);
                RefreshVisibleAreaOfColumn(gv, gv.Columns[gv.Columns.Count - 1]);
                FillChartMapSeries();

                ResetViewButtonEnable(true);
            }
        }

        // Delete Aggregate Column
        private void OnDeleteAggregateColumn(object sender, EventArgs e)
        {
            if (((DXMenuItem) sender).Tag is GridColumn)
            {
                var gColumn = (GridColumn) ((DXMenuItem) sender).Tag;
                if (
                    MessageForm.Show(
                        EidssMessages.Get("msgDeleteAggregateColumn", "Do you want to delete aggregate column?"), "",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteAggregateColumn((AvrViewColumn) gColumn.Tag, gColumn.AbsoluteIndex);
                }
            }
        }

        private void DeleteAggregateColumn(AvrViewColumn aCol, int index)
        {
            // deleting: from model, from grid, from aggregate cashe
            m_AggrCache.DeleteColumn(aCol.UniquePath);

            if (!aCol.Delete())
            {
                aCol.Owner.Columns.Remove(aCol);
            }

            var gv = (GridView) grid.MainView;
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
            {
                gv.Columns.RemoveAt(index);
            }

            RefreshVisibleAreaOfColumn(gv, gv.Columns[gv.Columns.Count - 1]);
            FillChartMapSeries();

            ResetViewButtonEnable(true);
        }

        #endregion

        // Band Width
        private void bandedGridView1_BandWidthChanged(object sender, BandEventArgs e)
        {
            if (sender is BandedGridView)
            {
                var grView = sender as BandedGridView;
                foreach (BandedGridColumn grC in grView.Columns)
                {
                    if (grC.Tag != null)
                    {
                        ((AvrViewColumn) grC.Tag).ColumnWidth = grC.Width;
                    }
                }
            }
        }

        // Column Width  -   change columns widths of the all neibours by band in model
        private void bandedGridView1_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            if (sender is GridColumn)
            {
                if (((GridColumn) sender).Tag == null)
                {
                    return;
                }

                if (sender is BandedGridColumn)
                {
                    var grCol = sender as BandedGridColumn;
                    var col = grCol.Tag as AvrViewColumn;
                    if (col != null && grCol.Width != col.ColumnWidth)
                    {
                        foreach (BandedGridColumn grC in grCol.OwnerBand.Columns)
                        {
                            ((AvrViewColumn) grC.Tag).ColumnWidth = grC.Width;
                        }
                    }
                }
                else
                {
                    var grCol = sender as GridColumn;
                    var col = grCol.Tag as AvrViewColumn;
                    if (col != null && grCol.Width != col.ColumnWidth)
                    {
                        foreach (GridColumn grC in grCol.View.Columns)
                        {
                            ((AvrViewColumn) grC.Tag).ColumnWidth = grC.Width;
                        }
                    }
                }
            }
            else if (sender is GridView)
            {
                foreach (GridColumn grC in ((GridView) sender).Columns)
                {
                    ((AvrViewColumn) grC.Tag).ColumnWidth = grC.Width;
                }
            }
        }

        // change columns order of the all columns in parent band in model
        private void bandedGridView1_ColumnPositionChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                return;
            }

            if (sender is GridColumn && ((GridColumn) sender).Tag != null)
            {
                var grCol = sender as GridColumn;
                var col = grCol.Tag as AvrViewColumn;

                bool bChangedVisibility = false;
                if (col != null && grCol.VisibleIndex > 0)
                {
                    if (!col.IsVisible)
                    {
                        bChangedVisibility = true;
                        col.IsVisible = true;
                    }
                }
                else
                {
                    if (col != null && col.IsVisible)
                    {
                        bChangedVisibility = true;
                        col.IsVisible = false;
                    }
                }

                ChangeColumnsOrderOfBand(grCol, bChangedVisibility);
            }
        }

        // change bands order of the all bands in parent band in model
        private void bandedGridView1_DragObjectDrop(object sender, DragObjectDropEventArgs e)
        {
            if (e.DragObject is GridBand && ((GridBand) e.DragObject).Tag != null)
            {
                ChangeBandsOrderOfBand(e.DragObject as GridBand);
            }
        }

        private void bandedGridView1_Layout(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                return;
            }

            for (int i = 0; i < bandedGridView1.Bands.Count; i++)
            {
                SetBandsVisibility(bandedGridView1.Bands[i]);
            }
        }

        // remember column sorting in model
        private void bandedGridView1_EndSorting(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
            {
                return;
            }

            if (sender is GridView)
            {
                var grView = sender as GridView;
                ((AvrView) grView.Tag).ClearSorting();
                foreach (GridColumn grC in grView.SortedColumns)
                {
                    if (grC.Tag != null)
                    {
                        ((AvrViewColumn) grC.Tag).SortOrder = grC.SortIndex;
                        ((AvrViewColumn) grC.Tag).IsSortAscending = grC.SortOrder == ColumnSortOrder.Ascending;
                    }
                }
                // - forget all aggregate functions cashe of view
                RefreshUnboundData();

                ResetViewButtonEnable(true);
            }
        }

        // remember column filter string in model
        private void bandedGridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridColumnCollection cols = ((GridView) grid.MainView).Columns;
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].Tag != null)
                {
                    ((AvrViewColumn) cols[i].Tag).ColumnFilter = cols[i].FilterInfo.FilterString;
                }
            }

            // - forget all aggregate functions cashe of view
            RefreshUnboundData();
        }

        // selection кликом по заголовкам bands
        private void bandedGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is BandedGridView && e.Button == MouseButtons.Left)
            {
                BandedGridHitInfo hit = bandedGridView1.CalcHitInfo(e.Location);

                if (hit != null)
                {
                    if (hit.HitTest == BandedGridHitTest.Band)
                    {
                        if (ModifierKeys == Keys.None)
                        {
                            GridColumn firstCol = GetFirstColumnOfBand(hit.Band);
                            GridColumn lastCol = GetLastColumnOfBand(hit.Band);
                            if (firstCol == null || lastCol == null)
                            {
                                return;
                            }

                            bandedGridView1.BeginSelection();
                            bandedGridView1.ClearSelection();
                            bandedGridView1.SelectCells(bandedGridView1.GetVisibleRowHandle(0), firstCol,
                                bandedGridView1.GetVisibleRowHandle(bandedGridView1.RowCount - 1), lastCol);
                            bandedGridView1.EndSelection();
                        }
                        else if (ModifierKeys == Keys.Control)
                        {
                            GridColumn firstCol = GetFirstColumnOfBand(hit.Band);
                            GridColumn lastCol = GetLastColumnOfBand(hit.Band);
                            if (firstCol == null || lastCol == null)
                            {
                                return;
                            }

                            bandedGridView1.SelectCells(bandedGridView1.GetVisibleRowHandle(0), firstCol,
                                bandedGridView1.GetVisibleRowHandle(bandedGridView1.RowCount - 1), lastCol);
                        }
                        else if (ModifierKeys == Keys.Shift)
                        {
                            GridColumn[] cells = bandedGridView1.GetSelectedCells(bandedGridView1.GetVisibleRowHandle(0));
                            GridColumn firstCol = GetFirstColumnOfBand(hit.Band);
                            GridColumn lastCol = GetLastColumnOfBand(hit.Band);
                            if (cells.Length <= 0 || firstCol == null || lastCol == null)
                            {
                                return;
                            }

                            bandedGridView1.BeginSelection();
                            if (cells[cells.Length - 1].VisibleIndex > lastCol.VisibleIndex)
                            {
                                bandedGridView1.SelectCells(bandedGridView1.GetVisibleRowHandle(0), firstCol,
                                    bandedGridView1.GetVisibleRowHandle(bandedGridView1.RowCount - 1), lastCol);
                            }
                            bandedGridView1.SelectCells(bandedGridView1.GetVisibleRowHandle(0), cells[cells.Length - 1],
                                bandedGridView1.GetVisibleRowHandle(bandedGridView1.RowCount - 1), lastCol);
                            bandedGridView1.EndSelection();
                        }
                    }
                }
            }
        }

        // заполнение столбцов вычисляемых с помощью аггрегированных функций
        private void bandedGridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && ((AvrViewColumn) e.Column.Tag).IsAggregate)
            {
                e.Value = m_AggrCache.GetValue(e.Column.FieldName, e.ListSourceRowIndex, ((DataRowView) e.Row).Row, (GridView) sender,
                    e.Column, (AvrViewColumn) e.Column.Tag);
            }
            if (e.IsSetData && ((AvrViewColumn) e.Column.Tag).IsAggregate)
            {
                m_AggrCache.SetValue(e.Column.FieldName, e.ListSourceRowIndex, e.Value);
            }
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            var viewColumn = ((AvrViewColumn) e.Column.Tag);
            DisplayTextHandler.DisplayAsterisk(viewColumn, new WinGridCellDisplayTextEventArgs(e));
            /*if (viewColumn.IsAggregate || viewColumn.CustomSummaryType.IsAdmUnitOrGender())
            {
                if (e.Value == DBNull.Value ||
                    (e.Value is double && (double.IsNaN((double) e.Value) || double.IsInfinity((double) e.Value))))
                {
                    e.DisplayText = m_NotAvaliable;
                }
            }
            else if (e.Value == DBNull.Value && BaseSettings.ShowAvrAsterisk)
            {
                e.DisplayText = "*";
            }*/
        }

        private void bandedGridView1_PrintInitialize(object sender, PrintInitializeEventArgs e)
        {
            var pb = e.PrintingSystem as PrintingSystemBase;
            if (pb != null)
            {
                pb.PageSettings.Landscape = true;
            }
        }

        #endregion

        #region Private Functions

        // remember order of bands - neibours of input by band/view (children of one band/view in model)
        private void ChangeBandsOrderOfBand(GridBand grBand)
        {
            var band = grBand.Tag as AvrViewBand;
            if (band != null)
            {
                band.IsVisible = grBand.Visible;

                //not top band
                if (grBand.ParentBand != null)
                {
                    if (grBand.ParentBand.Children.IndexOf(grBand) != band.Order - 1)
                    {
                        for (int i = 0; i < grBand.ParentBand.Children.Count; i++)
                        {
                            ((AvrViewBand) grBand.ParentBand.Children[i].Tag).Order = i + 1;
                        }
                    }
                }
                // top band
                else
                {
                    if (grBand.View.Bands.IndexOf(grBand) != band.Order - 1)
                    {
                        for (int i = 0; i < grBand.View.Bands.Count; i++)
                        {
                            ((AvrViewBand) grBand.View.Bands[i].Tag).Order = i + 1;
                        }
                    }
                }
            }

            ResetViewButtonEnable(true);
            FillChartMapCombos();
        }

        private void SetBandsVisibility(GridBand grBand)
        {
            var band = grBand.Tag as AvrViewBand;
            if (band != null)
            {
                band.IsVisible = grBand.Visible;

                for (int i = 0; i < grBand.Children.Count; i++)
                {
                    SetBandsVisibility(grBand.Children[i]);
                }
            }
        }

        // remember order of columns - neibours of input by band/view (children of one band/view in model)
        private void ChangeColumnsOrderOfBand(GridColumn grCol, bool bChangedVisibility)
        {
            var col = grCol as BandedGridColumn;
            // Parent is Band
            if (col != null)
            {
                GridBand grBand = col.OwnerBand;
                for (int i = 0; i < grBand.Columns.Count; i++)
                {
                    ((AvrViewColumn) grBand.Columns[i].Tag).Order = grCol.View.Columns[i].VisibleIndex + 1;
                }
            }
            // Parent is View
            else
            {
                for (int i = 0; i < grCol.View.Columns.Count; i++)
                {
                    ((AvrViewColumn) grCol.View.Columns[i].Tag).Order = grCol.View.Columns[i].VisibleIndex + 1;
                }
            }

            // - forget all aggregate functions cashe of band
            if (bChangedVisibility)
            {
                RefreshUnboundData();

                ResetViewButtonEnable(true);
            }
            FillChartMapCombos();
        }

        private GridColumn GetFirstColumnOfBand(GridBand grBand)
        {
            if (grBand.Columns.VisibleColumnCount > 0)
            {
                for (int i = 0; i < grBand.Columns.Count; i++)
                {
                    if (grBand.Columns[i].Visible)
                    {
                        return grBand.Columns[i];
                    }
                }
            }
            if (grBand.HasChildren && grBand.Children.VisibleBandCount > 0)
            {
                return GetFirstColumnOfBand(grBand.Children.FirstVisibleBand);
            }
            return null;
        }

        private GridColumn GetLastColumnOfBand(GridBand grBand)
        {
            if (grBand.Columns.VisibleColumnCount > 0)
            {
                for (int i = grBand.Columns.Count - 1; i >= 0; i--)
                {
                    if (grBand.Columns[i].Visible)
                    {
                        return grBand.Columns[i];
                    }
                }
            }
            if (grBand.HasChildren && grBand.Children.VisibleBandCount > 0)
            {
                return GetLastColumnOfBand(grBand.Children.LastVisibleBand);
            }
            return null;
        }

        private void SetChartButtonEnable()
        {
            if (Utils.IsEmpty(cbChartDefXaxis.EditValue) || m_ViewDetailPresenter.View.GetVisibleNotRowColumns(false).Count == 0)
            {
                btOpenChartButton.Enabled = false;
            }
            else
            {
                btOpenChartButton.Enabled = true;
            }
        }

        private void SetMapButtonEnable()
        {
            if (EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.GIS)))
            {
                if (Utils.IsEmpty(cbMapDefAdminUnit.EditValue) || m_ViewDetailPresenter.View.GetVisibleNotRowColumns(false).Count == 0)
                {
                    btOpenMapButton.Enabled = false;
                }
                else
                {
                    btOpenMapButton.Enabled = true;
                }
            }
            else
            {
                btOpenMapButton.Enabled = false;
            }
        }

        private void ResetViewButtonEnable(bool visible)
        {
            btResetViewButton.Enabled = visible;
        }

        private void RefreshUnboundData()
        {
            if (((AvrView) grid.MainView.Tag).GetAllColumns().ToList()
                .FindAll(x => x.IsAggregate).Count > 0)
            {
                // - forget all aggregate functions cashe of view
                ((AvrView) grid.MainView.Tag).GetAllColumns().ToList()
                    .FindAll(x => x.IsAggregate)
                    .ForEach(c => m_AggrCache.ClearColumn(c.UniquePath));

                // force refresh
                int visibleIndex = 0;
                int currentRowHandle = ((ColumnView) grid.MainView).GetVisibleRowHandle(visibleIndex);
                while (currentRowHandle != GridControl.InvalidRowHandle)
                {
                    ((ColumnView) grid.MainView).RefreshRow(currentRowHandle);
                    visibleIndex = ((ColumnView) grid.MainView).GetNextVisibleRow(visibleIndex);
                    currentRowHandle = ((ColumnView) grid.MainView).GetVisibleRowHandle(visibleIndex);
                }
            }
        }

        #endregion
    }
}