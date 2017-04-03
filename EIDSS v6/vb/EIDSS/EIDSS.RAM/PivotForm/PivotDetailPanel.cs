using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using EIDSS;
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
using eidss.model.Core;
using eidss.model.Reports.OperationContext;

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

                m_PivotDetailPresenter = (PivotDetailPresenter) BaseAvrPresenter;

                filterControl.OnFilterChanged += FilterChanged;
                InitFilterControl(PivotGrid.Criteria);
                nbControlSettings_GroupExpanded(this, new NavBarGroupEventArgs(nbGroupSettings));

                OnBeforePost += PivotForm_OnBeforePost;
                OnAfterPost += PivotForm_OnAfterPost;
                PivotGrid.GridLayout += PivotGridGridLayout;
                PivotGrid.FieldAreaChanged += PivotGridFieldAreaChanged;
                PivotGrid.FieldValueExpanded += PivotGrid_FieldValueExpanded;
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
                OnAfterPost -= PivotForm_OnAfterPost;

                ClearFilterControl();

                eventManager.ClearAllReferences();

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
                bool isLayoutTooBig = PivotGrid.CellsCount > AvrPivotGrid.MaxLayoutCellCount;
                if (isLayoutTooBig)
                {
                    ErrorForm.ShowError("msgTooManyViewCells", "msgTooManyViewCells",
                        PivotGrid.CellsCount.ToString(), AvrPivotGrid.MaxLayoutCellCount.ToString());
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
                pivotGrid.RefreshData();
            }
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
        public CriteriaOperator FilterCriteria { get; private set; }

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
            private set { ShowDataCheckEdit.Checked = value; }
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

        public void SetChanged()
        {
            m_PivotDetailPresenter.Changed = true;
        }

        public override bool HasChanges()
        {
            return (m_PivotDetailPresenter.Changed || base.HasChanges());
        }

        //todo: [ivan] remove usagese without new data  because of possible bugs !!!
        public void RejectChangesAddMissingValues(bool getNewData = false)
        {
            using (PivotGrid.BeginTransaction())
            {
                if (DataSource != null)
                {
                    if (getNewData)
                    {
                        DataSource = new AvrPivotGridData(m_PivotDetailPresenter.GetPreparedDataSource());
                    }
                    else
                    {
                        DataSource.RejectChanges();
                    }
                }

                FillDataSourceWithAbsentValues();
                RefreshPivotData();
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

        public CriteriaOperator InitFilterControl(CriteriaOperator filterCriteria)
        {
            ClearFilterControl();

            filterControl.InitPivotFilter(PivotGrid, true,
                filterCriteria);
            filterControl.OnFilterChanged += FilterChanged;

            //return corrected filter criteria after check inside FilterControlHelper .ctor
            return filterControl.FilterCriteria;
        }

        public void InitFilterControlHelperAndRefreshFilter()
        {
            FilterCriteria = InitFilterControl(FilterCriteria);
        }

        private void ClearFilterControl()
        {
            if (filterControl != null)
            {
                filterControl.OnFilterChanged -= FilterChanged;
            }
        }

        public void SetInnerFilterCriteria()
        {
            FilterCriteria = PivotGrid.Criteria;
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

                m_PivotDetailPresenter.BindGroupInterval(GroupIntervalLookupEdit);

                m_PivotDetailPresenter.BindShowTotalCols(ShowTotalsComboBoxEdit);
                m_PivotDetailPresenter.BindBackShowTotalCols(ShowTotalsComboBoxEdit, PivotGrid.OptionsView, false);
                m_PivotDetailPresenter.BindFreezeRowHeaders(FreezeRowHeadersCheckEdit);
                m_PivotDetailPresenter.BindApplyFilter(ApplyFilterCheckEdit);
                m_PivotDetailPresenter.BindShowMissedValues(ShowMissedValuesCheckEdit);

                FreezeRowHeadersCheckEdit_CheckedChanged(this, EventArgs.Empty);

                ApplyFilterCheckEdit.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

                PivotGrid.SetDataSourceAndCreateFields(m_PivotDetailPresenter.GetPreparedDataSource());

                PivotGrid.FieldsCustomization(grcCustomization);
                PivotGrid.CustomizationForm.Dock = DockStyle.Fill;

                PivotGrid.ClearCacheDataRowColumnAreaFields();

                //Init filter contol Accessory code
                string haCode = LookupCache.GetLookupValue(m_PivotDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId,
                    LookupTables.Query, "intHACode");
                if (!string.IsNullOrEmpty(haCode) && (int.Parse(haCode)) > 0)
                {
                    filterControl.ObjectHACode = (HACode) int.Parse(haCode);
                }
                bool needReloadData = true;
                while (needReloadData)
                {
                    using (PivotGrid.BeginTransaction())
                    {
                        RestorePivotSettings();
                        RestoreReadOnly();

                        //Just firing up FocusedCellChanged - in order to initialize Aggregate Function controls, etc.
                        PivotGrid.Cells.FocusedCell = new Point(0, 0);

                        CriteriaOperator criteria = PivotGrid.Criteria;
                        needReloadData = !PivotGrid.CheckDataSize(criteria);
                        if (needReloadData)
                        {
                            PivotGrid.DataSource = new AvrPivotGridData(PivotGrid.DataSource.ClonedPivotData);
                        }
                    }
                }

                using (PivotGrid.BeginTransaction())
                {
                    FillDataSourceWithAbsentValues();
                    // refresh but should not set m_Changes to true
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                    {
                        ClickOnFocusedCell(true);
                    }

                    CompactLayoutCheckEdit.Checked = PivotGrid.OptionsView.RowTotalsLocation == PivotRowTotalsLocation.Tree;
                    eventManager.AttachDataHandler("Layout.blnApplyPivotGridFilter", ApplyFilter_Changed);

                    m_PivotDetailPresenter.PivotFormService.AcceptChanges(baseDataSet);

                    UpdateCustomizationFormEnabling();
                    RefreshPivotData();

                    m_PivotDetailPresenter.Changed = false;
                }
            }
        }

        #region Binding of  Controls

        private void PivotForm_OnBeforePost(object sender, EventArgs e)
        {
            PivotGrid.Criteria = FilterCriteria;

            m_PivotDetailPresenter.SavePivotFilterToDB(FilterCriteria);
        }

        private void PivotForm_OnAfterPost(object sender, EventArgs e)
        {
            if (!ApplyFilter)
            {
                PivotGrid.Criteria = null;
            }
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
                if (ApplyFilter)
                {
                    SetPrefilter(filterControl.FilterCriteria, false);
                }
                else
                {
                    if (PivotGrid.CheckDataSize(null))
                    {
                        PivotGrid.Criteria = null;
                    }
                    else
                    {
                        ApplyFilterCheckEdit.Checked = true;
                    }
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
                m_PivotDetailPresenter.SharedPresenter.BindAggregateFunctionsInternal(AggregateLookupEdit, true, false);

                AggregateColumnNameTextEdit.Text = string.Empty;

                AdministrativeUnitVisible(false, false);
            }
        }

        private void RestorePivotSettings()
        {
            try
            {
                m_PivotDetailPresenter.LoadPivotFromDB();

                AvrPivotGridHelper.SwapOriginalAndCopiedFieldsIfReversed(AvrFields);

                SetPivotOptionsAfterRestoring();

                FilterCriteria = PivotGrid.Criteria;

                CheckAndFixFilterCriteria();

                PivotGrid.PivotGridPresenter.UpdatePivotCaptions();

                InitFilterControlHelperAndRefreshFilter();
                SetPrefilter(FilterCriteria, true);

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

        private void FilterChanged(object sender, FilterChangedEventArgs e)
        {
            if (e.Action == FilterChangedAction.AddNode && (e.CurrentNode is GroupNode)) //AddGroupNode
            {
                return;
            }
            SetPrefilter(((FilterControl) sender).FilterCriteria, false);
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

                PivotGroupInterval interval = GroupIntervalHelper.GetGroupInterval(GroupIntervalLookupEdit.EditValue);
                PivotGroupInterval dateInterval = interval.IsDate()
                    ? interval
                    : PivotGroupInterval.DateYear;

                foreach (IAvrPivotGridField field in AvrFields)
                {
                    field.DefaultGroupInterval = dateInterval;
                }

                //// commented because no need to refresh filter when group interval changed
                // InitFilterControlHelperAndRefreshFilter();
                // ApplyFilter_Changed();

                ////

                RejectChangesAddMissingValues();
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
            ShowFilterForm();

            RaisePivotGridDataLoadedCommand();
        }

        private void CompactLayoutCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle))
            {
                return;
            }

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
                    PivotGrid.HideData = !ShowData;
                }

                if (!ShowData)
                {
                    bool isMissedValuesChecked = ShowMissedValuesCheckEdit.Checked;
                    ShowMissedValuesCheckEdit.Checked = false;
                    m_ShowMissedValuesdisabledWhenHideData = isMissedValuesChecked;
                    PivotGrid.RefreshData();
                }
                else
                {
                    if (m_ShowMissedValuesdisabledWhenHideData)
                    {
                        ShowMissedValuesCheckEdit.Checked = true;
                    }
                    else
                    {
                        RejectChangesAddMissingValues();
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
                    cbAggregate_EditValueChanged(sender, e);
                }
                AggregateLookupEdit.EditValue = SelectedField.AggregateFunctionId;
                AggregateLookupEdit.Enabled = true;
                PrecisionSpinEdit.Enabled = true;

                bool isPopulation = (SelectedRowSummaryType == CustomSummaryType.Pop10000) ||
                                    (SelectedRowSummaryType == CustomSummaryType.Pop100000) ||
                                    (SelectedRowSummaryType == CustomSummaryType.PopGender100000);

                if (isPopulation)
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
                PivotGroupInterval interval = GroupIntervalHelper.GetGroupInterval(GroupIntervalLookupEdit.EditValue);
                var field = (IAvrPivotGridField) e.Field;
                field.DefaultGroupInterval = interval;

                if (!(field.Visible &&
                      (field.Area == PivotArea.ColumnArea || field.Area == PivotArea.RowArea)))
                {
                    field.AddMissedValues = false;
                    field.UpdateImageIndex();
                }

                using (PivotGrid.BeginTransaction())
                {
                    RejectChangesAddMissingValues(ShowMissedValuesCheckEdit.Checked && ShowData);

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

                            AggregateColumnNameTextEdit.Text = string.Empty;
                            AggregateLookupEdit.EditValue = DBNull.Value;
                            AggregateLookupEdit.Enabled = false;
                            PrecisionSpinEdit.Enabled = false;
                        }
                        finally
                        {
                            m_AggregateDisableChanging = false;
                        }
                    }

                    InitFilterControlHelperAndRefreshFilter();

                    UpdateCustomizationFormEnabling();
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

        private void cbAggregate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding))
                {
                    return;
                }

                if (m_AggregateDisableChanging)
                {
                    return;
                }

                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
                {
                    return;
                }

                CheckSelectedField();

                if (SelectedField == null)
                {
                    return;
                }

                SelectedField.AggregateFunctionId = ValueConverter.ConvertValueToLong(AggregateLookupEdit.EditValue);

                CustomSummaryType summaryTypeType = SelectedRowSummaryType;

                bool isPopulation = (summaryTypeType == CustomSummaryType.Pop10000) ||
                                    (summaryTypeType == CustomSummaryType.Pop100000) ||
                                    (summaryTypeType == CustomSummaryType.PopGender100000);
                AdministrativeUnitVisible(isPopulation, (summaryTypeType == CustomSummaryType.PopGender100000));
                if (isPopulation)
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

                PivotGrid.UpdatePivotFieldSummary(SelectedField, summaryTypeType);

                if (SelectedField.PrecisionDictionary.ContainsKey(summaryTypeType))
                {
                    SelectedField.Precision = SelectedField.PrecisionDictionary[summaryTypeType];
                }
                else
                {
                    string strPrecision = LookupCache.GetLookupValue((long) summaryTypeType, LookupTables.AggregateFunction,
                        "intDefaultPrecision");
                    int precision;
                    SelectedField.Precision = int.TryParse(strPrecision, out precision)
                        ? precision
                        : -1;
                }

                using (m_PivotDetailPresenter.SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.PrecisionRefreshing))
                {
                    PrecisionSpinEdit.Value = SelectedFieldPrecision;
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

                PivotGrid.RefreshData();
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
            if (ShowMissedValuesCheckEdit.Checked)
            {
                ShowData = true;
            }

            RejectChangesAddMissingValues(!ShowMissedValuesCheckEdit.Checked && ShowData);
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
                if (string.IsNullOrEmpty(fieldName))
                {
                    SelectedField.UnitSearchFieldAlias = string.Empty;
                    SelectedField.UnitLayoutSearchFieldId = -1;
                }
                else
                {
                    SelectedField.UnitSearchFieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(fieldName);
                    SelectedField.UnitLayoutSearchFieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(fieldName);
                }

                //Recount aggregation 
                PivotGrid.UpdatePivotFieldSummary(SelectedField, SelectedRowSummaryType);

                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                {
                    RefreshPivotData();
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
                if (string.IsNullOrEmpty(fieldName))
                {
                    SelectedField.DateSearchFieldAlias = string.Empty;
                    SelectedField.DateLayoutSearchFieldId = -1;
                }
                else
                {
                    SelectedField.DateSearchFieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(fieldName);
                    SelectedField.DateLayoutSearchFieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(fieldName);
                }

                //Recount aggregation 
                PivotGrid.UpdatePivotFieldSummary(SelectedField, SelectedRowSummaryType);

                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                {
                    RefreshPivotData();
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

        public void ShowFilterForm()
        {
            if (!ApplyFilter)
            {
                PivotGrid.Criteria = filterControl.FilterCriteria;
            }
            using (var filterForm = new FilterDialog(PivotGrid, filterControl.FilterCriteria, filterControl.ObjectHACode))
            {
                if (filterForm.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    m_ApplyingFilter = true;
                    //m_PivotPresenter.ApplyFilter = filterForm.m_PivotPresenter.ApplyFilter;

                    bool oldState = ApplyFilterCheckEdit.Checked;
                    bool isFilterApplied = SetPrefilter(filterForm.FilterCriteria, true);
                    if (!isFilterApplied)
                    {
                        ApplyFilterCheckEdit.Checked = oldState;
                    }
                    m_ApplyingFilter = false;
                }
                else
                {
                    if (!ApplyFilter)
                    {
                        PivotGrid.Criteria = null;
                    }
                }
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

        private bool SetPrefilter(CriteriaOperator criteria, bool resetFilterControl)
        {
            if ((!PivotGrid.LayoutRestoring) &&
                (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding)) &&
                !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ApplyStyle) &&
                ((!ReferenceEquals(FilterCriteria, null) && !FilterCriteria.Equals(criteria)) ||
                 (!ReferenceEquals(criteria, null) && criteria.Equals(FilterCriteria)) == false))
            {
                m_PivotDetailPresenter.Changed = true;
            }

            bool isCriteriaEmpty = ReferenceEquals(criteria, null) || Utils.IsEmpty(criteria.LegacyToString());

            CriteriaOperator newCriteria = ApplyFilter ? criteria : null;
            bool result = PivotGrid.CheckDataSize(newCriteria);
            if (result)
            {
                // if Pivot will not have big size
                PivotGrid.Criteria = newCriteria;
            }
            else
            {
                // if Pivot is too big - return filter to previous stage
                criteria = PivotGrid.Criteria;
                filterControl.FilterCriteria = criteria;
            }

            FilterCriteria = criteria;
            if (!isCriteriaEmpty)
            {
                if (resetFilterControl)
                {
                    filterControl.FilterCriteria = criteria;
                }
            }
            else
            {
                if (!Utils.IsEmpty(filterControl.FilterString))
                {
                    filterControl.FilterCriteria = null;
                }
            }

            return result;
        }

        public void UpdateCustomizationFormEnabling()
        {
            CustomizationFormEnabled = AvrPermissions.UpdatePermission && PivotGrid.FieldsInvisible;
        }

        #endregion

        #region helper methods

        public void FillDataSourceWithAbsentValues()
        {
            try
            {
                if ((!ShowMissedValuesCheckEdit.Visible && m_PivotDetailPresenter.ShowMissedValues) ||
                    (ShowMissedValuesCheckEdit.Visible && ShowMissedValuesCheckEdit.Checked))
                {
                    PivotGrid.AddMissedValuesInRowColumnArea();
                }
            }
            catch (OutOfMemoryException)
            {
                ErrorForm.ShowError("ErrAVROutOfMemory");
                PivotGrid.DataSource = new AvrPivotGridData(m_PivotDetailPresenter.GetPreparedDataSource());
            }
        }

        private void CheckSelectedField()
        {
            if (SelectedField == null)
            {
                throw new AvrException("Pivot Grid Field should be selected");
            }
        }

        private void AdministrativeUnitVisible(bool visible, bool isGender)
        {
            AdmUnitLabel.Visible = visible && (!isGender);
            AdministrativeUnitLookupEdit.Visible = visible && (!isGender);
            ForDateLookupEdit.Visible = visible;
            DateFieldLabel.Visible = visible;
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

        #endregion
    }
}