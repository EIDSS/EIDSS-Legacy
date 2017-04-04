using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Diagnostics;
using bv.common.win;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.db.Interfaces;
using eidss.avr.FilterForm;
using eidss.avr.PivotComponents;
using eidss.avr.Tools;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.model.Core;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using EIDSS;
using Localizer = bv.common.Core.Localizer;

namespace eidss.avr.PivotForm
{
    public partial class PivotDetailPanel : BaseAvrDetailPresenterPanel, IPivotDetailView
    {
        private bool m_ApplyingFilter;
        private bool m_AggregateDisableChanging;
        private bool m_UpdateShowTotals;
        private bool m_ShowMissedValuesdisabledWhenHideData;

        private bool m_DenyPivotRefresh;
        private Point m_SelectedCell = new Point(-1, -1);
        private readonly FieldAreaChangedDublicateFinder m_AreaChangedDublicateFinder = new FieldAreaChangedDublicateFinder();
        private PivotDetailPresenter m_PivotDetailPresenter;

        public PivotDetailPanel()
        {
            try
            {
                InitializeComponent();

                if (IsDesignMode() || BaseSettings.ScanFormsMode)
                {
                    return;
                }

                InitShowTotals();

                m_PivotDetailPresenter = (PivotDetailPresenter) BaseAvrPresenter;

                nbControlSettings_GroupExpanded(this, new NavBarGroupEventArgs(nbGroupSettings));

                OnBeforePost += PivotForm_OnBeforePost;

                PivotGrid.GridLayout += PivotGridGridLayout;
                PivotGrid.FieldAreaChanged += PivotGridFieldAreaChanged;
                PivotGrid.FieldValueExpanded += PivotGrid_FieldValueExpanded;
                if (Localizer.IsRtl)
                {
                    nbCustomization.Dock = DockStyle.Right;
                    splitter.Dock = DockStyle.Right;
                }
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
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (m_PivotDetailPresenter != null)
                {
                    if (m_PivotDetailPresenter.SharedPresenter != null)
                    {
                        m_PivotDetailPresenter.SharedPresenter.UnregisterView(this);
                    }
                    m_PivotDetailPresenter.Dispose();
                    m_PivotDetailPresenter = null;
                }

                if (pivotGrid != null)
                {
                    pivotGrid.CellClick -= pivotGrid_CellClick;
                    pivotGrid.FocusedCellChanged -= pivotGrid_FocusedCellChanged;
                    pivotGrid.CellSelectionChanged -= pivotGrid_CellSelectionChanged;
                    PivotGrid.GridLayout -= PivotGridGridLayout;
                    PivotGrid.FieldAreaChanged -= PivotGridFieldAreaChanged;
                }
                if (GroupIntervalLookupEdit != null)
                {
                    GroupIntervalLookupEdit.EditValueChanged -= cbGroupInterval_EditValueChanged;
                    GroupIntervalLookupEdit.Properties.DataSource = null;
                    GroupIntervalLookupEdit.DataBindings.Clear();
                }
                OnBeforePost -= PivotForm_OnBeforePost;

                if (eventManager != null)
                {
                    eventManager.ClearAllReferences();
                }

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                nbContainerCustomization = null;
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Raise Events 

        public void RaisePivotGridDataLoadedCommand()
        {
            PivotGridDataLoadedCommand command = CreatePivotDataLoadedCommand();

            RaiseSendCommand(command);
        }

        public PivotGridDataLoadedCommand CreatePivotDataLoadedCommand()
        {
            PivotGridDataLoadedCommand command;
            try
            {
                bool isLayoutTooBig = PivotGrid.CellsCount > BaseSettings.AvrErrorCellCountLimit;
                if (isLayoutTooBig)
                {
                    ErrorForm.ShowError("msgTooManyViewCells", "msgTooManyViewCells",
                        PivotGrid.CellsCount.ToString(), BaseSettings.AvrErrorCellCountLimit.ToString());
                }
                using (BaseAvrPresenter.CreateLoadingDialog())
                {
                    command = PivotGrid.CreatePivotDataLoadedCommand(CorrectedLayoutName, isLayoutTooBig);
                }
            }
            catch (OutOfMemoryException)
            {
                ErrorForm.ShowError("ErrAVROutOfMemory");
                command = PivotGrid.CreatePivotDataLoadedCommand(CorrectedLayoutName, true);
            }
            return command;
        }

        public void RefreshPivotData()
        {
            if (!m_DenyPivotRefresh)
            {
                using (CreateWaitDialog())
                {
                    pivotGrid.RefreshData();
                }
            }
        }

        public IDisposable BeginTransaction()
        {
            return PivotGrid.BeginTransaction();
        }

        #endregion

        #region Properties

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ApplyFilter
        {
            get { return m_PivotDetailPresenter.ApplyFilter; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CriteriaOperator FilterCriteria { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public long LayoutId
        {
            get
            {
                return ((baseDataSet is LayoutDetailDataSet) && ((LayoutDetailDataSet) baseDataSet).Layout.Count > 0)
                    ? m_PivotDetailPresenter.LayoutId
                    : m_PivotDetailPresenter.SharedPresenter.SharedModel.SelectedLayoutId;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvrPivotGrid PivotGrid
        {
            get { return pivotGrid; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IAvrPivotGridView PivotGridView
        {
            get { return pivotGrid; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AvrPivotGridData DataSource
        {
            get { return pivotGrid.DataSource; }
            set { pivotGrid.DataSource = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CorrectedLayoutName
        {
            get { return m_PivotDetailPresenter.CorrectedLayoutName; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotGridFieldCollectionBase BaseFields
        {
            get { return PivotGrid.Fields; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<IAvrPivotGridField> AvrFields
        {
            get { return PivotGrid.AvrFields; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IAvrPivotGridField SelectedField { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowData
        {
            get { return ShowDataCheckEdit.Checked; }
            set { ShowDataCheckEdit.Checked = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowMissedValues
        {
            get { return ShowMissedValuesCheckEdit.Checked; }
            set { ShowMissedValuesCheckEdit.Checked = value; }
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
                if (IsDesignMode())
                {
                    return;
                }

                using (PivotGrid.BeginTransaction())
                {
                    base.ReadOnly = value;

                    //hide customization panel only if layout selected
                    bool showCustomization = (!value);
                    nbCustomization.Visible = showCustomization;
                    splitter.Visible = showCustomization;
                    CompactLayoutCheckEdit.Enabled = !value;

                    BindingHelper.HideDeleteButton(GroupIntervalLookupEdit);
                    SetPivotReadOnly(value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CustomizationFormEnabled
        {
            get { return PivotGrid.CustomizationForm.Enabled; }
            set
            {
                if (IsDesignMode())
                {
                    return;
                }

                PivotGrid.CustomizationForm.Enabled = value;
            }
        }

        #endregion

        public void SetDataSourceAsync(AvrPivotGridData value)
        {
            pivotGrid.SetDataSourceAsync(value);
        }

        public void SetChanged()
        {
            m_PivotDetailPresenter.Changed = true;
        }

        public override bool HasChanges()
        {
            return (m_PivotDetailPresenter.Changed || base.HasChanges());
        }

        public void FillAbsentAndMissingValues()
        {
            //should be used only inside PivotGrid.BeginTransaction()
            using (CreateWaitDialog())
            {
                DataSource.RejectChanges();

                FillAbsentValuesAndCheckComplexity(DataSource);
            }
        }

        public void AddField(IAvrPivotGridField field)
        {
            PivotGrid.Fields.Add((PivotGridField) field);
        }

        public void RemoveField(IAvrPivotGridField field)
        {
            PivotGrid.Fields.Remove((PivotGridField) field);
        }

        public IAvrPivotGridField GetField(string fieldName)
        {
            return (IAvrPivotGridField) PivotGrid.Fields[fieldName];
        }

        protected override void DefineBinding()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.DefineBinding))
            {
                eventManager.RemoveDataHandler("Layout.blnApplyPivotGridFilter");

                //It's Nice to at least suspend layout while all the controls getting initialized
                //Thus firing lots of events with underlying customization structure partially initialized
                //Maybe it would be even better to just clear it altogether
                PivotGrid.Fields.Clear();
                PivotGrid.OptionsLayout.StoreAllOptions = true;
                PivotGrid.OptionsLayout.StoreAppearance = true;
                PivotGrid.RowsFreezed = m_PivotDetailPresenter.FreezeRowHeaders;

                BindAggregateFunctions();
                BindBasicCountFunctions();

                m_PivotDetailPresenter.BindGroupInterval(GroupIntervalLookupEdit);

                m_PivotDetailPresenter.BindShowTotalCols(ShowTotalsComboBoxEdit);
                m_PivotDetailPresenter.BindBackShowTotalCols(ShowTotalsComboBoxEdit, PivotGrid.OptionsView, false);
                m_PivotDetailPresenter.BindFreezeRowHeaders(FreezeRowHeadersCheckEdit);
                m_PivotDetailPresenter.BindApplyFilter(ApplyFilterCheckEdit);
                m_PivotDetailPresenter.BindShowDataInPivotGrid(ShowDataCheckEdit);

                if (m_PivotDetailPresenter.CompactPivotGrid)
                {
                    CompactLayoutCheckEdit.Checked = true;
                    ShowTotalsComboBoxEdit.Enabled = false;
                    m_PivotDetailPresenter.BindBackShowTotalCols(ShowTotalsComboBoxEdit, PivotGrid.OptionsView, true);
                }

                m_PivotDetailPresenter.BindShowMissedValues(ShowMissedValuesCheckEdit);

                FreezeRowHeadersCheckEdit_CheckedChanged(this, EventArgs.Empty);

                ApplyFilterCheckEdit.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

                AvrDataTable preparedDataTable = m_PivotDetailPresenter.GetPreparedDataSource();

                using (PivotGrid.BeginTransaction())
                {

                    if (!m_PivotDetailPresenter.ShowDataInPivotGrid)
                    {
                        PivotGrid.HideData = true;
                        ShowDataCheckEdit.Checked = false;
                        bool isMissedValuesChecked = m_PivotDetailPresenter.ShowMissedValues;
                        m_PivotDetailPresenter.ShowMissedValues = false;
                        m_ShowMissedValuesdisabledWhenHideData = isMissedValuesChecked;
                    }


                    PivotGrid.SetDataSourceAndCreateFields(preparedDataTable);

                    PivotGrid.FieldsCustomization(grcCustomization);
                    PivotGrid.CustomizationForm.Dock = DockStyle.Fill;

                    PivotGrid.ClearCacheDataRowColumnAreaFields();

                    //Init filter contol Accessory code
                    var queryId = m_PivotDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId;
                    string haCode = LookupCache.GetLookupValue(queryId, LookupTables.Query, "intHACode");
                    if (!String.IsNullOrEmpty(haCode) && (Int32.Parse(haCode)) > 0)
                    {
                        filterControl.ObjectHACode = (HACode) Int32.Parse(haCode);
                    }

                    string singleSearchObject = LookupCache.GetLookupValue(queryId, LookupTables.Query, "blnSingleSearchObject");
                    PivotGrid.SingleSearchObject = (singleSearchObject != "0");

                    RestorePivotSettings();
                    RestoreReadOnly();

                    FillAbsentValuesAndCheckComplexity(PivotGrid.DataSource);

                    //Just firing up FocusedCellChanged - in order to initialize Aggregate Function controls, etc.
                    PivotGrid.Cells.FocusedCell = new Point(0, 0);

                    // refresh but should not set m_Changes to true
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                    {
                        ClickOnFocusedCell(true);
                    }
                    eventManager.AttachDataHandler("Layout.blnApplyPivotGridFilter", ApplyFilter_Changed);

                    m_PivotDetailPresenter.PivotFormService.AcceptChanges(baseDataSet);

                    UpdateCustomizationFormEnabling();

                    m_PivotDetailPresenter.Changed = false;
                }
            }
        }

        #region Binding of  Controls

        private void PivotForm_OnBeforePost(object sender, EventArgs e)
        {
            m_PivotDetailPresenter.SavePivotFilterToDB(FilterCriteria);
        }

        private void ApplyFilter_Changed(Object sender, DataFieldChangeEventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }

            ApplyFilter_Changed();
        }

        private void ApplyFilter_Changed()
        {
            if (m_ApplyingFilter)
            {
                return;
            }
            m_ApplyingFilter = true;
            try
            {
                using (CreateWaitDialog())
                {
                    CriteriaOperator criteria = ApplyFilter
                        ? filterControl.FilterCriteria
                        : null;

                    using (BeginTransaction())
                    {
                        // dispose old pivot datasource before getting new datasource
                        AvrPivotGridData oldDataSource = DataSource;
                        if (oldDataSource != null)
                        {
                            DataSource = new AvrPivotGridData(oldDataSource.ClonedPivotData);
                            oldDataSource.Dispose();
                        }

                        var expression = ReferenceEquals(criteria, null) ? null : criteria.LegacyToString();
                        AvrDataTable table = m_PivotDetailPresenter.GetPreparedDataSourceFiltered(expression);
                        DataSource = new AvrPivotGridData(table);
                        FillAbsentValuesAndCheckComplexity(DataSource);
                    }

//                    if (ApplyFilter)
//                    {
//                        SetPrefilter(criteria, false);
//                    }
//                    else
//                    {
//                        RefreshPivotData();
//                    }
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during filter applying:{0}", ex);
            }
            finally
            {
                m_ApplyingFilter = false;
            }
        }

        private void RestoreReadOnly()
        {
            // apply readonly and update permission to pivot
            bool readOnly = m_PivotDetailPresenter.ReadOnly || (!AvrPermissions.UpdatePermission);

            SetPivotReadOnly(readOnly);

            ParentObject.ReadOnly = readOnly;
        }

        private void SetPivotReadOnly(bool readOnly)
        {
            PivotGrid.OptionsCustomization.BeginUpdate();
            PivotGrid.OptionsCustomization.AllowDrag = !readOnly;
            PivotGrid.OptionsCustomization.AllowEdit = !readOnly;
            PivotGrid.OptionsCustomization.AllowExpand = !readOnly;
            PivotGrid.OptionsCustomization.EndUpdate();
        }

        private void BindAggregateFunctions()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindAggregateFunctions))
            {
                m_PivotDetailPresenter.SharedPresenter.BindAggregateFunctionsInternal(AggregateLookupEdit, AggregateFunctionTarget.Pivot);

                AggregateColumnNameTextEdit.Text = String.Empty;

                AdmUnitAndDateSetVisibility(false, false);
            }
        }

        private void BindBasicCountFunctions()
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.BindBasicCountFunctions))
            {
                m_PivotDetailPresenter.SharedPresenter.BindAggregateFunctionsInternal(BasicCountLookupEdit, AggregateFunctionTarget.Basic);
                BasicCountLookupEdit.Enabled = true;
                BasicCountLookupEdit.Visible = false;
                BasicCountLabel.Visible = false;
            }
        }

        private void RestorePivotSettings()
        {
            try
            {
                m_PivotDetailPresenter.LoadPivotFromDB();

                AvrPivotGridHelper.SwapOriginalAndCopiedFieldsIfReversed(AvrFields);

                SetPivotOptionsAfterRestoring();

                CheckAndFixFilterCriteria();

                PivotGrid.PivotGridPresenter.UpdatePivotCaptions();

                filterControl.InitPivotFilter(PivotGrid, true, FilterCriteria);

                ClearCacheDataRowColumnAreaFields();

                PivotGrid.RefreshAllPivotFieldsSummary();

                PivotGrid.Cells.Selection = new Rectangle();
            }
            catch (XmlException ex)
            {
                Trace.WriteLine(ex);
                ErrorForm.ShowError("errCantParseLayout", "Cannot parse Layout retrived from Database", ex);
            }
        }

        private void SetPivotOptionsAfterRestoring()
        {
            //         PivotGrid.Appearance.Cell.TextOptions.HAlignment = HorzAlignment.Near;
            PivotGrid.OptionsLayout.StoreAllOptions = true;
            PivotGrid.OptionsLayout.StoreAppearance = true;
            PivotGrid.OptionsView.ShowFilterHeaders = false;
        }

        private void CheckAndFixFilterCriteria()
        {
            if (!ReferenceEquals(FilterCriteria, null))
            {
                string finalFilter = FilterCriteria.LegacyToString();

                foreach (KeyValuePair<IAvrPivotGridField, IAvrPivotGridField> pair in m_PivotDetailPresenter.GetFieldsAndCopies())
                {
                    finalFilter = finalFilter.Replace(pair.Key.FieldName, pair.Value.FieldName);
                }
                if (finalFilter != FilterCriteria.LegacyToString())
                {
                    FilterCriteria = CriteriaOperator.Parse(finalFilter);
                }
            }
        }

        public void ClearCacheDataRowColumnAreaFields()
        {
            PivotGrid.ClearCacheDataRowColumnAreaFields();
        }

        #endregion

        #region Pivot grid layout event handlers

        private void pivotGrid_CellSelectionChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }

            try
            {
                ClickOnFocusedCell(false);
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

        private void PivotGridGridLayout(object sender, EventArgs e)
        {
            try
            {
                if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) &&
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.AfterLoad) &&
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.OpenEditor) &&
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.RefreshDataWithoutChanges) &&
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.Post) &&
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
                {
                    m_PivotDetailPresenter.Changed = true;
                }
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

        private void cbGroupInterval_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                    SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
                {
                    return;
                }

                using (CreateWaitDialog())
                {
                    using (PivotGrid.BeginTransaction())
                    {
                        PivotGroupInterval interval = GroupIntervalHelper.GetGroupInterval(GroupIntervalLookupEdit.EditValue);
                        PivotGroupInterval dateInterval = interval.IsDate()
                            ? interval
                            : PivotGroupInterval.DateYear;

                        foreach (IAvrPivotGridField field in AvrFields)
                        {
                            field.DefaultGroupInterval = dateInterval;
                        }
                        FillAbsentAndMissingValues();
                    }
                }
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

        private void ShowTotalsComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle) ||
                m_UpdateShowTotals)
            {
                return;
            }
            try
            {
                m_UpdateShowTotals = true;
                m_PivotDetailPresenter.BindBackShowTotalCols(ShowTotalsComboBoxEdit, PivotGrid.OptionsView, CompactLayoutCheckEdit.Checked);
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
            finally
            {
                m_UpdateShowTotals = false;
            }
        }

        private void RefreshDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.RefreshDataWithoutChanges))
                {
                    Enabled = false;
                    m_PivotDetailPresenter.SharedPresenter.SharedModel.QueryRefreshDateTime = DateTime.Now;
                    RaiseSendCommand(new QueryLayoutCommand(sender, QueryLayoutOperation.RefreshQuery));

                    ShowData = true;
                }
            }
            finally
            {
                Enabled = true;
            }
        }

        private void EditFiltersButton_Click(object sender, EventArgs e)
        {
            using (var filterForm = new FilterDialog(PivotGrid, filterControl.FilterCriteria, filterControl.ObjectHACode))
            {
                if (filterForm.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    m_PivotDetailPresenter.Changed = true;

                    FilterCriteria = filterForm.FilterCriteria;
                    filterControl.InitPivotFilter(PivotGrid, true, FilterCriteria);

                    if (ApplyFilterCheckEdit.Checked)
                    {
                        ApplyFilter_Changed();
                    }
                    else
                    {
                        // ApplyFilter_Changed fires automatically
                        ApplyFilterCheckEdit.Checked = true;
                    }
                }
            }
        }

        private void CompactLayoutCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }
            m_PivotDetailPresenter.CompactPivotGrid = CompactLayoutCheckEdit.Checked;
            ShowTotalsComboBoxEdit_EditValueChanged(sender, e);
            ShowTotalsComboBoxEdit.Enabled = !CompactLayoutCheckEdit.Checked;
        }

        private void FreezeRowHeadersCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }
            PivotGrid.RowsFreezed = FreezeRowHeadersCheckEdit.Checked;
        }

        private void ShowDataCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.RefreshDataWithoutChanges) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }

            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.RefreshDataWithoutChanges))
            {
                using (BaseAvrPresenter.CreateLoadingDialog())
                {
                    using (PivotGrid.BeginTransaction())
                    {
                        PivotGrid.HideData = !ShowData;

                        if (!ShowData)
                        {
                            bool isMissedValuesChecked = ShowMissedValues;
                            ShowMissedValues = false;
                            m_ShowMissedValuesdisabledWhenHideData = isMissedValuesChecked;
                            RefreshPivotData();
                        }
                        else
                        {
                            if (m_ShowMissedValuesdisabledWhenHideData)
                            {
                                ShowMissedValues = true;
                            }
                            else
                            {
                                FillAbsentAndMissingValues();
                            }
                        }
                    }
                }
            }
        }

        private void pivotGrid_FocusedCellChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }
            ClickOnFocusedCell(false);
            PivotGrid.Refresh();
        }

        public void ClickOnFocusedCell(bool forceClick)
        {
            if (forceClick)
            {
                m_SelectedCell = new Point(-1, -1);
            }
            PivotCellEventArgs cellInfo = PivotGrid.Cells.GetFocusedCellInfo();
            if (cellInfo != null)
            {
                pivotGrid_CellClick(this, cellInfo);
            }
        }

        private void pivotGrid_CellClick(object sender, PivotCellEventArgs e)
        {
            //Also called from pivotGrid_FocusedCellChanged, in order to handle non-mouse initiated focus change

            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                    SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
                {
                    return;
                }

                m_DenyPivotRefresh = true;

                if (e.ColumnIndex == m_SelectedCell.X && e.RowIndex == m_SelectedCell.Y)
                {
                    return;
                }

                m_SelectedCell = new Point(e.ColumnIndex, e.RowIndex);

                // selection change part

                if ((e.DataField == null) ||
                    (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions)))
                {
                    return;
                }

                AggregateColumnNameTextEdit.Text = e.DataField.Caption;

                SelectedField = (IAvrPivotGridField) e.DataField;

                if ((AggregateLookupEdit.EditValue is long) &&
                    ((long) AggregateLookupEdit.EditValue == SelectedField.AggregateFunctionId))
                {
                    Aggregate_EditValueChanged(sender, e);
                }
                AggregateLookupEdit.EditValue = SelectedField.AggregateFunctionId;
                AggregateLookupEdit.Enabled = true;
                PrecisionSpinEdit.Enabled = true;

                if (SelectedRowSummaryType.IsAdmUnitOrGender())
                {
                    var dataView = AdministrativeUnitLookupEdit.Properties.DataSource as DataView;
                    AdministrativeUnitLookupEdit.EditValue = SharedPresenter.GetSelectedAdministrativeFieldAlias(dataView, SelectedField) ??
                                                             (object) DBNull.Value;

                    ForDateLookupEdit.EditValue = SelectedField.GetSelectedDateFieldAlias() ?? (object) DBNull.Value;
                }
                else
                {
                    AdministrativeUnitLookupEdit.EditValue = DBNull.Value;
                    ForDateLookupEdit.EditValue = DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
            finally
            {
                m_DenyPivotRefresh = false;
            }
        }

        private void PivotGridFieldAreaChanged(object sender, PivotFieldEventArgs e)
        {
            try
            {
                if (m_AreaChangedDublicateFinder.IsFieldAreaChangedProcessed(e))
                {
                    return;
                }
                using (CreateWaitDialog())
                {
                    PivotGroupInterval interval = GroupIntervalHelper.GetGroupInterval(GroupIntervalLookupEdit.EditValue);
                    var field = (IAvrPivotGridField) e.Field;
                    field.DefaultGroupInterval = interval;

                    if (field.Visible && (field.Area == PivotArea.ColumnArea || field.Area == PivotArea.RowArea))
                    {
                        bool anyHasMissedValues = m_PivotDetailPresenter.GetFieldCopiesExceptHidden(field).Any(copy => copy.AddMissedValues);
                        if (anyHasMissedValues)
                        {
                            field.AddMissedValues = true;
                            field.UpdateImageIndex();
                        }
                    }
                    else
                    {
                        field.AddMissedValues = false;
                        field.UpdateImageIndex();
                    }

                    using (PivotGrid.BeginTransaction())
                    {
                        FillAbsentAndMissingValues();

                        if (field.Area == PivotArea.DataArea)
                        {
                            if (field.Visible)
                            {
                                SelectedField = field;

                                PivotGrid.UpdatePivotFieldSummary(field, SelectedRowSummaryType);
                            }
                            else
                            {
                                SelectedField = null;
                                field.Area = PivotArea.FilterArea;
                            }
                        }

                        if (!Utils.IsEmpty(AggregateLookupEdit.EditValue))
                        {
                            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.InitAdmUnit))
                            {
                                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.InitStatDate))
                                {
                                    m_PivotDetailPresenter.InitAdmUnit(AdministrativeUnitLookupEdit, SelectedField);
                                    m_PivotDetailPresenter.InitStatDate(ForDateLookupEdit, SelectedField);
                                }
                            }
                        }

                        ClickOnFocusedCell(true);

                        if (PivotGrid.IsDataAreaEmpty)
                        {
                            try
                            {
                                m_AggregateDisableChanging = true;

                                AggregateColumnNameTextEdit.Text = String.Empty;
                                AggregateLookupEdit.EditValue = DBNull.Value;
                                AggregateLookupEdit.Enabled = false;
                                PrecisionSpinEdit.Enabled = false;

                                BasicCountLookupEdit.Visible = false;
                                BasicCountLabel.Visible = false;
                            }
                            finally
                            {
                                m_AggregateDisableChanging = false;
                            }
                        }

                        UpdateCustomizationFormEnabling();
                    }
                }
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

        private void PivotGrid_FieldValueExpanded(object sender, PivotFieldValueEventArgs e)
        {
//            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
//                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
//            {
//                return;
//            }
//            RejectChangesAddMissingValues();
        }

        private void BasicCount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                    SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindBasicCountFunctions))
                {
                    return;
                }

                CheckSelectedField();

                if (SelectedField == null)
                {
                    return;
                }

                SelectedField.BasicCountFunctionId = ValueConverter.ConvertValueToLong(BasicCountLookupEdit.EditValue);

                RefreshPivotData();
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

        private void Aggregate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                    SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions) ||
                    m_AggregateDisableChanging)
                {
                    return;
                }

                CheckSelectedField();

                if (SelectedField == null)
                {
                    return;
                }

                var id = ValueConverter.ConvertValueToLong(AggregateLookupEdit.EditValue);
                if (SelectedField.AggregateFunctionId == id)
                {
                    AggregateChangedCalculations(sender, e);
                }
                else
                {
                    using (CreateWaitDialog())
                    {
                        SelectedField.AggregateFunctionId = id;
                        AggregateChangedCalculations(sender, e);
                    }
                }
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

        private void AggregateChangedCalculations(object sender, EventArgs e)
        {
            BasicCountLookupEdit.Visible = ((CustomSummaryType) SelectedField.AggregateFunctionId).IsBasicCounterNeeded();
            BasicCountLabel.Visible = BasicCountLookupEdit.Visible;
            if (BasicCountLookupEdit.Visible)
            {
                if ((BasicCountLookupEdit.EditValue is long) &&
                    ((long) BasicCountLookupEdit.EditValue == SelectedField.BasicCountFunctionId))
                {
                    BasicCount_EditValueChanged(sender, e);
                }
                BasicCountLookupEdit.EditValue = SelectedField.BasicCountFunctionId;
            }

            CustomSummaryType summaryType = SelectedRowSummaryType;
            AdmUnitAndDateSetVisibility(summaryType.IsAdmUnitOrGender(), summaryType.IsAdmUnit());
            if (summaryType.IsAdmUnitOrGender())
            {
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.InitAdmUnit))
                {
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.InitStatDate))
                    {
                        m_PivotDetailPresenter.InitAdmUnit(AdministrativeUnitLookupEdit, SelectedField);
                        m_PivotDetailPresenter.InitStatDate(ForDateLookupEdit, SelectedField);
                    }
                }
            }
            else
            {
                AdministrativeUnitLookupEdit.EditValue = DBNull.Value;
            }

            SelectedField.SummaryDisplayType = PivotSummaryDisplayType.Default;

            PivotGrid.UpdatePivotFieldSummary(SelectedField, summaryType);

            if (SelectedField.PrecisionDictionary.ContainsKey(summaryType))
            {
                SelectedField.Precision = SelectedField.PrecisionDictionary[summaryType];
            }
            else
            {
                string strPrecision = LookupCache.GetLookupValue((long) summaryType, LookupTables.AggregateFunction,
                    "intDefaultPrecision");
                int precision;
                SelectedField.Precision = Int32.TryParse(strPrecision, out precision)
                    ? precision
                    : -1;
            }

            using (m_PivotDetailPresenter.SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.PrecisionRefreshing))
            {
                PrecisionSpinEdit.Value = SelectedFieldPrecision;
            }
        }

        private void PrecisionSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.PrecisionRefreshing) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }

            if (SelectedField != null)
            {
                var precision = (int) PrecisionSpinEdit.Value;
                SelectedField.Precision = precision;

                CustomSummaryType summaryType = SelectedField.CustomSummaryType;

                if (SelectedField.PrecisionDictionary.ContainsKey(summaryType))
                {
                    SelectedField.PrecisionDictionary[summaryType] = precision;
                }
                else
                {
                    SelectedField.PrecisionDictionary.Add(summaryType, precision);
                }

                RefreshPivotData();
            }
        }

        private void ShowMissedValuesCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }
            m_ShowMissedValuesdisabledWhenHideData = false;
            using (PivotGrid.BeginTransaction())
            {
                if (ShowMissedValues)
                {
                    ShowData = true;
                }
                FillAbsentAndMissingValues();
                RefreshPivotData();
            }
        }

        private void nbControlSettings_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlSettings.Height = BaseAvrPresenter.NavBarGroupHeaderHeight;
            }
        }

        private void cbAdministrativeUnit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                    SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
                {
                    return;
                }

                if (SelectedField == null)
                {
                    return;
                }

                string fieldName = Utils.Str(AdministrativeUnitLookupEdit.EditValue);
                if (String.IsNullOrEmpty(fieldName))
                {
                    SelectedField.UnitSearchFieldAlias = String.Empty;
                    SelectedField.UnitLayoutSearchFieldId = -1;
                }
                else
                {
                    SelectedField.UnitSearchFieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(fieldName);
                    SelectedField.UnitLayoutSearchFieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(fieldName);
                }

                //Recount aggregation 
                bool refreshed = PivotGrid.UpdatePivotFieldSummary(SelectedField, SelectedRowSummaryType);
                if (!refreshed)
                {
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                    {
                        RefreshPivotData();
                    }
                }
                if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.InitAdmUnit))
                {
                    m_PivotDetailPresenter.Changed = true;
                }
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

        private void cbForDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                    SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
                {
                    return;
                }
                //    CheckSelectedField();

                if (SelectedField == null)
                {
                    return;
                }

                string fieldName = Utils.Str(ForDateLookupEdit.EditValue);
                if (String.IsNullOrEmpty(fieldName))
                {
                    SelectedField.DateSearchFieldAlias = String.Empty;
                    SelectedField.DateLayoutSearchFieldId = -1;
                }
                else
                {
                    SelectedField.DateSearchFieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(fieldName);
                    SelectedField.DateLayoutSearchFieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(fieldName);
                }

                //Recount aggregation 
                bool refreshed = PivotGrid.UpdatePivotFieldSummary(SelectedField, SelectedRowSummaryType);

                if (!refreshed)
                {
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                    {
                        RefreshPivotData();
                    }
                }
                if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.InitStatDate))
                {
                    m_PivotDetailPresenter.Changed = true;
                }
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

        private CustomSummaryType SelectedRowSummaryType
        {
            get
            {
                CheckSelectedField();
                return AvrPivotGridHelper.ParseSummaryType(SelectedField.AggregateFunctionId);
            }
        }

        private int SelectedFieldPrecision
        {
            get
            {
                CheckSelectedField();

                return SelectedField.Precision.HasValue
                    ? SelectedField.Precision.Value
                    : -1;
            }
        }

        public void UpdateCustomizationFormEnabling()
        {
            CustomizationFormEnabled = AvrPermissions.UpdatePermission && PivotGrid.FieldsInvisible;
        }

        #endregion

        #region helper methods

        public void FillAbsentValuesAndCheckComplexity(AvrPivotGridData avrDataSource)
        {
            if (avrDataSource != null && ShowData)
            {
                try
                {
                    List<IAvrPivotGridField> fields = AvrFields.ToList();
                    var validator = new LayoutDesktopValidator(this)
                    {
                        IgnoreValidationWarnings = m_PivotDetailPresenter.SharedPresenter.SharedModel.IgnoreValidationWarnings
                    };

                    var result = new LayoutValidateResult();
                    if ((!ShowMissedValuesCheckEdit.Visible && m_PivotDetailPresenter.ShowMissedValues) ||
                        (ShowMissedValuesCheckEdit.Visible && ShowMissedValues))
                    {
                        result = AvrPivotGridHelper.AddMissedValuesAndValidateComplexity(avrDataSource, fields, validator);
                    }

                    if (!result.IsCancelOrUserDialogCancel())
                    {
                        result = AvrPivotGridHelper.FillEmptyValuesAndValidateComplexity(avrDataSource, fields, validator);
                    }
                    if (result.IsCancelOrUserDialogCancel())
                    {
                        ShowData = false;
                        PivotGrid.HideData = true;
                    }
                }
                catch (OutOfMemoryException)
                {
                    ErrorForm.ShowError("ErrAVROutOfMemory");
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
        }

        private void CheckSelectedField()
        {
            if (SelectedField == null)
            {
                throw new AvrException("Pivot Grid Field should be selected");
            }
        }

        private void AdmUnitAndDateSetVisibility(bool visible, bool isAdmin)
        {
            AdmUnitLabel.Visible = visible && isAdmin;
            AdministrativeUnitLookupEdit.Visible = visible && isAdmin;
            ForDateLookupEdit.Visible = visible;
            DateFieldLabel.Visible = visible;
        }

        private static WaitDialog CreateWaitDialog()
        {
            string title = EidssMessages.Get("msgPleaseWait");
            string caption = EidssMessages.Get("msgAvrPivotCalculating");
            return new WaitDialog(caption, title);
        }

        private void InitShowTotals()
        {
            CheckedListBoxItemCollection items = ShowTotalsComboBoxEdit.Properties.Items;
            items[0].Description = EidssMessages.Get("itemCols", "Cols");
            items[1].Description = EidssMessages.Get("itemRows", "Rows");
            items[2].Description = EidssMessages.Get("itemColGrand", "Col Grand");
            items[3].Description = EidssMessages.Get("itemRowGrand", "Row Grand");
            items[4].Description = EidssMessages.Get("itemForSingle", "For Single");
        }

        #endregion

        #region Nav Bar Layout

        private void nbControlSettings_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlSettings.Height = nbGroupSettings.ControlContainer.Height +
                                           BaseAvrPresenter.NavBarGroupHeaderHeight;
            }
        }

        private void nbCustomization_NavPaneStateChanged(object sender, EventArgs e)
        {
            if (nbCustomization.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
            {
                grcCustomization.Dock = DockStyle.None;
                grcCustomization.Size = new Size(0, 0);
            }
            else
            {
                grcCustomization.Dock = DockStyle.Fill;
            }
        }

        #endregion
    }
}