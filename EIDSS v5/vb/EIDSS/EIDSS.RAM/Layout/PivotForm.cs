using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM.Properties;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM.Tools;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.common.db.Core;
using bv.common.win;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using ErrorForm = bv.common.win.ErrorForm;
using Localizer = bv.common.Core.Localizer;

namespace EIDSS.RAM.Layout
{
    public partial class PivotForm : BaseLayoutForm, IPivotView
    {
        private bool m_Changed;
        private bool m_ApplyingFilter;

        private bool m_CopyDefaultLayoutName;
        private bool m_AggregateDisableChanging;
        private readonly FieldAreaChangedDublicateFinder m_AreaChangedDublicateFinder = new FieldAreaChangedDublicateFinder();

        private FilterControlHelper m_FilterControlHelper;

        private Dictionary<string, UnitField> m_UnitDictionary;
        private readonly PivotPresenter m_PivotPresenter;
        private bool m_PivotAccessible;
        private bool m_DenyPivotRefresh;
        private Point m_SelectedCell = new Point(-1, -1);

        private LayoutDetailDataSet.AggregateRow m_SelectedRow;

        private WinPivotGridField m_SelectedField;

        public event EventHandler<PivotSelectionEventArgs> PivotSelected;
        public event EventHandler<PivotDataEventArgs> PivotDataLoaded;
        public event EventHandler<ComboBoxEventArgs> InitAdmUnit;
        public event EventHandler<ComboBoxEventArgs> InitStatDate;
        public event EventHandler<ComboBoxEventArgs> InitDenominator;

        public PivotForm()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "PivotForm creating...");

                InitializeComponent();

                if (IsDesignMode())
                {
                    return;
                }

                cbDenominator.Left = cbAggregate.Left;
                cbDenominator.Width = cbAggregate.Width;

                m_PivotPresenter = (PivotPresenter) BaseRamPresenter;

                ResetUnitDictionary();

                tbDefaultLayoutName.Properties.Mask.MaskType = MaskType.RegEx;
                tbDefaultLayoutName.Properties.Mask.EditMask = Resources.PivotForm_PivotForm_LayoutNameEditMask;
                tbDefaultLayoutName.Properties.Mask.UseMaskAsDisplayFormat = true;

                if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                {
                    int delta = Math.Abs(tbLayoutName.Top - memDescription.Top);
                    memDescription.Top -= delta;
                    lblDescription.Top -= delta;
                    memDescription.Height += delta;

                    tbLayoutName.Visible = false;
                    lblLayoutName.Visible = false;
                    tbLayoutName.Tag = null;
                }

                lblLayoutName.Text = PivotPresenter.AppendLanguageNameTo(lblLayoutName.Text);

                InitFilterControlHelper(PivotGrid.Criteria);

                OnBeforePost += PivotForm_OnBeforePost;
                OnAfterPost += PivotForm_OnAfterPost;
                PivotGrid.GridLayout += PivotGridGridLayout;
                PivotGrid.FieldAreaChanged += PivotGridFieldAreaChanged;
                PivotGrid.FieldValueExpanded += PivotGrid_FieldValueExpanded;

                ceUseArchiveData.Visible = ArchiveDataHelper.ShowUseArchiveDataCheckbox;
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
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
//            if (Utils.IsCalledFromUnitTest())
//                return;
            //  eventManager.RemoveDataHandler("Layout.blnApplyFilter");

            pivotGrid.CellClick -= pivotGrid_CellClick;
            pivotGrid.FocusedCellChanged -= pivotGrid_FocusedCellChanged;
            pivotGrid.CellSelectionChanged -= pivotGrid_CellSelectionChanged;
            PivotGrid.GridLayout -= PivotGridGridLayout;
            PivotGrid.FieldAreaChanged -= PivotGridFieldAreaChanged;
            cbGroupInterval.EditValueChanged -= cbGroupInterval_EditValueChanged;
            cbGroupInterval.Properties.DataSource = null;
            cbGroupInterval.DataBindings.Clear();
            OnBeforePost -= PivotForm_OnBeforePost;
            OnAfterPost -= PivotForm_OnAfterPost;

            ClearFilterControlHelper();

            eventManager.ClearAllReferences();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            nbContainerCustomization = null;
        }

        #region Raise Events 

        public void RaiseDataLoadedEvent()
        {
            PivotDataLoaded.SafeRaise(this, new PivotDataEventArgs(PivotGrid));
        }

        
        public void RefreshData()
        {
            if (!m_DenyPivotRefresh)
            {
                pivotGrid.RefreshData();
            }
        }

        private void RaiseInitAdmUnitComboBox()
        {
            InitAdmUnit.SafeRaise(this, new ComboBoxEventArgs(cbAdministrativeUnit, m_SelectedRow));
        }

        private void RaiseInitStatDateComboBox()
        {
            InitStatDate.SafeRaise(this, new ComboBoxEventArgs(cbForDate, m_SelectedRow));
        }

        private void RaiseInitDenominatorComboBox()
        {
            InitDenominator.SafeRaise(this, new ComboBoxEventArgs(cbDenominator, m_SelectedRow));
        }

        #endregion

        #region Properties

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ApplyFilter
        {
            get { return m_PivotPresenter.ApplyFilter; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CriteriaOperator FilterCriteria { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long LayoutId
        {
            get
            {
                return ((baseDataSet is LayoutDetailDataSet) && ((LayoutDetailDataSet) baseDataSet).Layout.Count > 0)
                           ? m_PivotPresenter.LayoutId
                           : m_PivotPresenter.SharedPresenter.SharedModel.SelectedLayoutId;
            }
        }

        public RamPivotGrid PivotGrid
        {
            get { return pivotGrid; }
        }

        public DataTable FilteredDataSource
        {
            get { return pivotGrid.GetFilteredDataSource(CorrectedLayoutName); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DataSource
        {
            get { return pivotGrid.DataSource; }
        }

        public string CorrectedLayoutName
        {
            get { return m_PivotPresenter.CorrectedLayoutName; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotGridFieldCollectionBase BaseFields
        {
            get { return PivotGrid.Fields; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<WinPivotGridField> WinFields
        {
            get { return PivotGrid.RamFields; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LayoutDetailDataSet.AggregateRow SelectedRow
        {
            get { return m_SelectedRow; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WinPivotGridField SelectedField
        {
            get { return m_SelectedField; }
        }

        internal string SelectedTabPageName
        {
            get { return (tcLayoutDetails.SelectedTabPage != null) ? tcLayoutDetails.SelectedTabPage.Name : string.Empty; }
        }

        public void SetChanged(bool changed)
        {
            m_Changed = changed;
        }

        public override bool HasChanges()
        {
            return (m_Changed || base.HasChanges());
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
                    ceShareLayout.Enabled = !value;
                    FilterControlHelper.ProcessEnablingFor(filterControl);

                    //hide customization panel only if layout selected
                    bool showCustomization = (!value);
                    nbCustomization.Visible = showCustomization;
//                    if (showCustomization)
//                        PivotGrid.SortFieldCustomizationPanel();
                    splitter.Visible = showCustomization;

                    BindingHelper.HideDeleteButton(cbGroupInterval);
                    SetPivotReadOnly(value);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PivotAccessible
        {
            get { return m_PivotAccessible; }
            set
            {
                if (IsDesignMode())
                {
                    return;
                }

                m_PivotAccessible = value;
                if (grcGrid != null)
                {
                    grcGrid.Visible = value;
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

        public void AddField(WinPivotGridField field)
        {
            PivotGrid.Fields.Add(field);
        }

        public void RemoveField(WinPivotGridField field)
        {
            PivotGrid.Fields.Remove(field);
        }

        public WinPivotGridField GetField(string fieldName)
        {
            return (WinPivotGridField) PivotGrid.Fields[fieldName];
        }

        public CriteriaOperator InitFilterControlHelper(CriteriaOperator filterCriteria)
        {
            ClearFilterControlHelper();

            m_FilterControlHelper = new FilterControlHelper(filterControl, PivotGrid, true,
                                                            filterCriteria);
            m_FilterControlHelper.OnFilterChanged += FilterChanged;

            //return corrected filter criteria after check inside FilterControlHelper .ctor
            return m_FilterControlHelper.FilterCriteria;
        }

        public IList<CustomMapDataItem> GetSelectedCells(PivotGridField idField, PivotGridField typeField)
        {
            return PivotGrid.GetSelectedCells(idField, typeField);
        }

        public void InitFilterControlHelperAndRefreshFilter()
        {
            FilterCriteria = InitFilterControlHelper(FilterCriteria);
            chkApplyFilter.ToolTip = FilterControlHelper.GetFilterTextForPivotGrid(PivotGrid, FilterCriteria);
            chkApplyFilter.Text = chkApplyFilter.ToolTip.Replace(Environment.NewLine, " ");
            chkApplyFilter.Visible = !Utils.IsEmpty(chkApplyFilter.Text.Trim());
        }

        private void ClearFilterControlHelper()
        {
            if (m_FilterControlHelper != null)
            {
                m_FilterControlHelper.OnFilterChanged -= FilterChanged;
                m_FilterControlHelper.Dispose();
                m_FilterControlHelper = null;
            }
        }

        public void SetInnerFilterCriteria()
        {
            FilterCriteria = PivotGrid.Criteria;
        }

        protected override void DefineBinding()
        {
            Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.DefineBinding() call");

            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.DefineBinding))
            {
                eventManager.RemoveDataHandler("Layout.blnApplyFilter");

                //It's Nice to at least suspend layout while all the controls getting initialized
                //Thus firing lots of events with underlying customization structure partially initialized
                //Maybe it would be even better to just clear it altogether
                PivotGrid.Fields.Clear();
                PivotGrid.OptionsLayout.StoreAllOptions = true;
                PivotGrid.OptionsLayout.StoreAppearance = true;

                BindAggregateFunctions();

                m_PivotPresenter.BindGroupInterval(cbGroupInterval);

                m_CopyDefaultLayoutName = true;

                m_PivotPresenter.BindDefaultLayoutName(tbDefaultLayoutName);

                if (ModelUserContext.CurrentLanguage != Localizer.lngEn)
                {
                    m_PivotPresenter.BindLayoutName(tbLayoutName);
                }

                m_PivotPresenter.BindDescription(memDescription);

                m_PivotPresenter.BindShowTotalCols(ccbShowTotals);
                m_PivotPresenter.BindBackShowTotalCols(ccbShowTotals, PivotGrid.OptionsView, false);

                m_PivotPresenter.BindShareLayout(ceShareLayout);

                m_PivotPresenter.BindApplyFilter(chkApplyFilter);

                chkApplyFilter.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

                PivotGrid.DataSourceWithFields = m_PivotPresenter.GetPreparedDataSource();

                PivotGrid.FieldsCustomization(grcCustomization);
                PivotGrid.CustomizationForm.Dock = DockStyle.Fill;

                // clear cashe of Data, Column and Row AreaFields
                PivotGrid.DataAreaFields = null;
                PivotGrid.ColumnAreaFields = null;
                PivotGrid.RowAreaFields = null;
                //

               

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
                            PivotGrid.DataSource = PivotGrid.DataSource.Clone();
                        }

                      

                    }
                    FillDataSourceWithAbsentValues();
                    RefreshData();
                }

                ClickOnFocusedCell(true);

                if (m_PivotAccessible)
                {
                    ceCompactLayout.Checked = PivotGrid.OptionsView.RowTotalsLocation == PivotRowTotalsLocation.Tree;
                    eventManager.AttachDataHandler("Layout.blnApplyFilter", ApplyFilter_Changed);

                    m_PivotPresenter.PivotFormService.AcceptChanges(baseDataSet);

                    foreach (WinPivotGridField field in PivotGrid.RamFields)
                    {
                        field.UseNativeFormat = DefaultBoolean.False;
                    }

                    AjustCreateDeleteFieldsEnable();
                }
                UpdateCustomizationFormEnabling();
                m_Changed = false;
            }
        }



        #region Binding of  Controls

        private void PivotForm_OnBeforePost(object sender, EventArgs e)
        {
            try
            {
                m_Changed = false;

                PivotGrid.Criteria = FilterCriteria;
                string xml;
                using (var stream = new MemoryStream())
                {
                    PivotGrid.SaveLayoutToStream(stream);
                    stream.Position = 0;
                    using (var streamReader = new StreamReader(stream))
                    {
                        xml = streamReader.ReadToEnd();
                    }
                }
                m_PivotPresenter.LayoutXml = xml;
            }
            catch (XmlException ex)
            {
                Trace.WriteLine(ex);
                ErrorForm.ShowError(new EIDSSErrorMessage("errCantSaveLayout", "Cannot save Layout to Database", ex));
            }
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
                        // if Pivot will not have big size
                        RefreshChkApplyFilter(filterControl.FilterCriteria);
                        PivotGrid.Criteria = null;
                    }
                    else
                    {
                        chkApplyFilter.Checked = true;
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
            bool readOnly = m_PivotPresenter.ReadOnly || (!RamPermissions.UpdatePermission);

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
                ResetUnitDictionary();

                cbAggregate.DataBindings.Clear();

                cbAggregate.Properties.Columns.Clear();
                var info = new LookUpColumnInfo("AggregateFunctionName",
                                                EidssMessages.Get("colCaption", "Caption"),
                                                200, FormatType.None, "", true, HorzAlignment.Near);
                cbAggregate.Properties.Columns.AddRange(new[] {info});
                cbAggregate.Properties.PopupWidth = cbAggregate.Width;
                cbAggregate.Properties.NullText = string.Empty;

                DataView dataView = LookupCache.Get(LookupTables.AggregateFunction.ToString());
                cbAggregate.Properties.DataSource = dataView;
                cbAggregate.Properties.ValueMember = "idfAggregateFunction";
                cbAggregate.Properties.DisplayMember = "AggregateFunctionName";

                tbAggregateColumnName.Text = string.Empty;
                cbAggregate.EditValue = DBNull.Value;
                cbAggregate.Enabled = false;

                AdministrativeUnitVisible(false, false);
                DenominatorVisible(false);
            }
        }

        private void RestorePivotSettings()
        {
            // no need to restore if pivot is no visible
            if (!m_PivotPresenter.SharedPresenter.SharedModel.PivotAccessible)
            {
                return;
            }

            try
            {
                string layoutXml = m_PivotPresenter.LayoutXml;
                if (!string.IsNullOrEmpty(layoutXml))
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var streamWriter = new StreamWriter(stream))
                        {
                            streamWriter.Write(layoutXml);
                            streamWriter.Flush();
                            stream.Position = 0;
                            PivotGrid.RestoreLayoutFromStream(stream);
                        }
                    }
                }
                else
                {
                    PivotGrid.CriteriaString = string.Empty;
                }

                SwapOriginalAndCopiedFieldsIfReversed();

                SetPivotOptionsAfterRestoring();

                FilterControlHelper.CheckPivotGridPrefilter(PivotGrid);

                FilterCriteria = PivotGrid.Criteria;

                CheckAndFixFilterCriteria();

                PivotGrid.PivotGridPresenter.UpdatePivotCaptions();

                InitFilterControlHelperAndRefreshFilter();
                SetPrefilter(FilterCriteria, true);
                
                UpdateDenominatorIndexes();

                UpdateNameSummaryTypeDictionary();

                PivotGrid.Cells.Selection = new Rectangle();

                PivotSelected.SafeRaise(this, new PivotSelectionEventArgs(false, false));
            }
            catch (XmlException ex)
            {
                Trace.WriteLine(ex);
                ErrorForm.ShowError(new EIDSSErrorMessage("errCantParseLayout", "Cannot parse Layout retrived from Database", ex));
            }
        }

        private void SetPivotOptionsAfterRestoring()
        {
            PivotGrid.Appearance.Cell.TextOptions.HAlignment = HorzAlignment.Near;
            PivotGrid.OptionsLayout.StoreAllOptions = true;
            PivotGrid.OptionsLayout.StoreAppearance = true;
            PivotGrid.OptionsView.ShowFilterHeaders = false;
        }

        private void SwapOriginalAndCopiedFieldsIfReversed()
        {
            var fieldsAndCopies = GetFieldsAndCopiesConsideringArea();

            // in case original and copied fields have been swapped in the migration process from v4
            foreach (KeyValuePair<WinPivotGridField, WinPivotGridField> pair in fieldsAndCopies)
            {
                WinPivotGridField origin = pair.Key;
                WinPivotGridField copy = pair.Value;

                PivotArea newArea = origin.Area;
                bool newVisible = origin.Visible;
                int newIndex = origin.AreaIndex;
                bool isSwap = false;

                if (origin.Area == PivotArea.FilterArea)
                {
                    if (copy.Area == PivotArea.FilterArea)
                    {
                        isSwap = (copy.AllowedAreas != (copy.AllowedAreas & PivotGridAllowedAreas.FilterArea));
                        newVisible = false;
                    }
                    else
                    {
                        isSwap = true;
                        newArea = copy.Area;
                        newVisible = copy.Visible;
                        newIndex = copy.AreaIndex;
                    }
                }

                WinPivotGridField originToProcess = isSwap ? copy : origin;
                WinPivotGridField copyToProcess = isSwap ? origin : copy;

                originToProcess.IsFilter = false;
                originToProcess.Area = (newArea == PivotArea.FilterArea) ? PivotArea.RowArea : newArea;
                originToProcess.AreaIndex = newIndex;
                originToProcess.Visible = newVisible;


                copyToProcess.Visible = true;
                copyToProcess.IsFilter = true;
                copyToProcess.GroupInterval = PivotGroupInterval.Default;
            }
        }

        private void CheckAndFixFilterCriteria()
        {
            if (FilterCriteria != null)
            {
                var finalFilter = FilterCriteria.LegacyToString();

                foreach (var pair in GetFieldsAndCopies())
                {
                    finalFilter = finalFilter.Replace(pair.Key.FieldName, pair.Value.FieldName);
                }
                if (finalFilter != FilterCriteria.LegacyToString())
                {
                    FilterCriteria = CriteriaOperator.Parse(finalFilter);
                }
            }
        }

        private Dictionary<WinPivotGridField, WinPivotGridField> GetFieldsAndCopiesConsideringArea()
        {
            var fieldsAndCopies = new Dictionary<WinPivotGridField, WinPivotGridField>();
            IEnumerable<IGrouping<string, WinPivotGridField>> grouppedField = WinFields.GroupBy(f => f.OriginalName);
            foreach (IGrouping<string, WinPivotGridField> fields in grouppedField)
            {
                WinPivotGridField fieldCopy;
                fieldCopy = fields.FirstOrDefault(f => f.Area == PivotArea.FilterArea &&
                                                       f.AllowedAreas == (f.AllowedAreas & PivotGridAllowedAreas.FilterArea))
                            ?? (fields.FirstOrDefault(f => f.Area == PivotArea.FilterArea)
                                ?? (fields.FirstOrDefault(f => !f.Visible)
                                    ?? fields.FirstOrDefault(f => f.IsFilter)));

                if (fieldCopy != null)
                {
                    foreach (WinPivotGridField field in fields)
                    {
                        if (field != fieldCopy)
                        fieldsAndCopies.Add(field, fieldCopy);
                    }
                }
            }

            return fieldsAndCopies;
        }

        private Dictionary<WinPivotGridField, WinPivotGridField> GetFieldsAndCopies()
        {
            var fieldsAndCopies = new Dictionary<WinPivotGridField, WinPivotGridField>();
            foreach (WinPivotGridField field in WinFields.Where(f => !f.IsFilter))
            {
                WinPivotGridField fieldCopy = WinFields.FirstOrDefault(f => f.IsFilter && f.OriginalName == field.OriginalName);
                if (fieldCopy != null)
                {
                    fieldsAndCopies.Add(field, fieldCopy);
                }
            }
            return fieldsAndCopies;
        }


        public override bool ValidateData()
        {
            if (!base.ValidateData())
            {
                return false;
            }

            return m_PivotPresenter.ValidateLayoutName();
        }

        public void UpdateNameSummaryTypeDictionary()
        {
            PivotGrid.NameSummaryTypeDictionary = m_PivotPresenter.GetNameSummaryTypeDictionary();
        }

        public void UpdateDenominatorIndexes()
        {
            PivotGrid.DenominatorIndexes = m_PivotPresenter.GetIndexesDictionary();
        }

        private void ceShareLayout_CheckedChanged(object sender, EventArgs e)
        {
            if (Utils.IsCalledFromUnitTest() ||
                ceShareLayout.Checked ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) ||
                SharedPresenter.ContextKeeper.ContainsContext(ContextValue.Post))
            {
                return;
            }

            if (!ceShareLayout.Checked)
            {
                string msg = EidssMessages.Get("msgPrivateLayout",
                                               "Are you sure you want to make layout private? Other users will not see it.");
                bool answer = PivotPresenter.AskQuestion(msg, BvMessages.Get("Confirmation"));
                if (!answer)
                {
                    ceShareLayout.Checked = true;
                }
            }
        }

        private void tbDefaultLayoutName_EditValueChanged(object sender, EventArgs e)
        {
            ////Workaround to fix resetting of textbox
            m_PivotPresenter.SetDefaultLayoutName(tbDefaultLayoutName.Text);
            //
            if (m_CopyDefaultLayoutName && m_PivotPresenter.IsNewObject)
            {
                tbLayoutName.Text = tbDefaultLayoutName.Text;

                tbLayoutName.Focus();
                tbDefaultLayoutName.Focus();
            }
            m_PivotPresenter.CopyLayoutNameIfNeeded();
        }

        private void tbLayoutName_EditValueChanged(object sender, EventArgs e)
        {
            //Workaround to fix resetting of textbox
            m_PivotPresenter.SetLayoutName(tbLayoutName.Text);
            //
            if (tbLayoutName.Text != tbDefaultLayoutName.Text)
            {
                m_CopyDefaultLayoutName = false;
            }
            m_PivotPresenter.CopyLayoutNameIfNeeded();
        }

        private void tbDefaultLayoutName_EditValueChanging(object sender, ChangingEventArgs e)
        {
            m_CopyDefaultLayoutName = tbLayoutName.Text == tbDefaultLayoutName.Text;
            m_PivotPresenter.CopyPivotName = m_PivotPresenter.LayoutName == m_PivotPresenter.PivotName;
            m_PivotPresenter.CopyMapName = m_PivotPresenter.LayoutName == m_PivotPresenter.MapName;
            m_PivotPresenter.CopyChartName = m_PivotPresenter.LayoutName == m_PivotPresenter.ChartName;
        }

        #endregion

        #region Update Chart and Map handlers

        private void pivotGrid_CellSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ClickOnFocusedCell(false);
                PivotSelectionEventArgs args = m_PivotPresenter.DefineMapChartPageEnabled(PivotGrid.Cells.Selection);
                PivotSelected.SafeRaise(this, new PivotSelectionEventArgs(args.ChartEnabled, args.MapEnabled));
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

        #endregion

        #region Pivot grid layout event handlers

        private void ceUseArchiveData_CheckedChanged(object sender, EventArgs e)
        {
            // todo: [ivan] uncomment and implement
            //RaiseSendCommand(new LayoutCommand(this, LayoutOperation.UseArchiveChanged));
            m_PivotPresenter.SharedPresenter.SharedModel.UseArchiveData = ceUseArchiveData.Checked;
            PivotGrid.DataSource = m_PivotPresenter.GetPreparedDataSource();
        }

        // it called from layout detail. can't call directly here because it should be used after post
        public void RefreshDataSourceOnUseArchiveDataChanged(object sender, EventArgs e)
        {
            m_PivotPresenter.SharedPresenter.SharedModel.UseArchiveData = ceUseArchiveData.Checked;
            PivotGrid.DataSource = m_PivotPresenter.GetPreparedDataSource();
        }

        private void btnValidateFilter_Click(object sender, EventArgs e)
        {
            if (m_FilterControlHelper.Validate() == false)
            {
                tcLayoutDetails.SelectedTabPage = pageFilter;
            }
        }

        private void FilterChanged(object sender, FilterChangedEventArgs e)
        {
            if (e.Action == FilterChangedAction.AddGroupNode)
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
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.RefreshDataWithoutChanges) &&
                    !SharedPresenter.ContextKeeper.ContainsContext(ContextValue.Post))
                {
                    m_Changed = true;
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

        public void OnChangeOrientation(ChartChangeOrientationEventArgs e)
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.OnChangeOrientation()");
                PivotGrid.OptionsChartDataSource.ProvideDataByColumns = e.Vertical;
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
                Trace.WriteLine(Trace.Kind.Info, "PivotForm.cbGroupInterval_EditValueChanged()");
               
                PivotGroupInterval interval = PivotPresenter.GetGroupInterval(cbGroupInterval.EditValue);
                PivotGrid.DateGroupIntervalChanging = PivotGrid.DateGroupInterval != interval;
                PivotGrid.DateGroupInterval = interval;

                UpdateNameSummaryTypeDictionary();
                //// commented because no need to refresh filter when group interval changed
               // InitFilterControlHelperAndRefreshFilter();
               // ApplyFilter_Changed();

                ////
                FillDataSourceWithAbsentValues();
                RefreshData();
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
                PivotGrid.DateGroupIntervalChanging = false;
            }
        }

        private bool m_UpdateShowTotals;

        private void ccbShowTotals_EditValueChanged(object sender, EventArgs e)
        {
            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding) || m_UpdateShowTotals)
            {
                return;
            }
            try
            {
                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.ccbShowTotals_EditValueChanged()");

                m_UpdateShowTotals = true;
                m_PivotPresenter.BindBackShowTotalCols(ccbShowTotals, PivotGrid.OptionsView, ceCompactLayout.Checked);
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

        private void ceCompactLayout_CheckedChanged(object sender, EventArgs e)
        {
            ccbShowTotals_EditValueChanged(sender, e);
            ccbShowTotals.Enabled = !ceCompactLayout.Checked;
        }

        private void pivotGrid_FocusedCellChanged(object sender, EventArgs e)
        {
               ClickOnFocusedCell(false);
        }

        private void ClickOnFocusedCell(bool forceClick)
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
                m_DenyPivotRefresh = true;

                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.pivotGrid_CellClick()");
                if (e.ColumnIndex == m_SelectedCell.X && e.RowIndex == m_SelectedCell.Y)
                {
                    return;
                }

                m_SelectedCell = new Point(e.ColumnIndex, e.RowIndex);

                // selection change part
                PivotSelectionEventArgs args = m_PivotPresenter.DefineMapChartPageEnabled(PivotGrid.Cells.Selection);
                PivotSelected.SafeRaise(this, new PivotSelectionEventArgs(args.ChartEnabled, args.MapEnabled));

                if ((e.DataField == null) ||
                    (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions)))
                {
                    return;
                }

                m_SelectedField = (WinPivotGridField)e.DataField;

                tbAggregateColumnName.Text = e.DataField.Caption;

                SelectAggregateRow(e.DataField.FieldName);

                if ((cbAggregate.EditValue is long) &&
                    ((long)cbAggregate.EditValue == m_SelectedRow.idfsAggregateFunction))
                {
                    cbAggregate_EditValueChanged(sender, e);
                }
                cbAggregate.EditValue = m_SelectedRow.idfsAggregateFunction;
                cbAggregate.Enabled = true;

                bool isPopulation = (SelectedRowSummaryType == CustomSummaryType.Pop10000) ||
                                    (SelectedRowSummaryType == CustomSummaryType.Pop100000) ||
                                    (SelectedRowSummaryType == CustomSummaryType.PopGender100000);

                if (isPopulation)
                {
                    var dataView = cbAdministrativeUnit.Properties.DataSource as DataView;
                    cbAdministrativeUnit.EditValue = SharedPresenter.GetSelectedAdmFieldAlias(dataView, m_SelectedRow) ??
                                                     (object)DBNull.Value;

                    cbForDate.EditValue = SharedPresenter.GetSelectedDateFieldAlias(m_SelectedRow) ?? (object)DBNull.Value;
                }
                else
                {
                    cbAdministrativeUnit.EditValue = DBNull.Value;
                    cbForDate.EditValue = DBNull.Value;
                }

                AjustCreateDeleteFieldsEnable();
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

                DataSource.RejectChanges();
                RefreshData();

                using (PivotGrid.BeginTransaction())
                {
                    FillDataSourceWithAbsentValues();

                    if (e.Field.Area == PivotArea.DataArea)
                    {
                        if (e.Field.Visible)
                        {
                            m_SelectedField = (WinPivotGridField) e.Field;

                            SelectAggregateRow(e.Field.FieldName);
                            WinPivotGridField field = GetField(e.Field.FieldName);
                            PivotGrid.UpdatePivotFieldSummary(field, SelectedRowSummaryType);
                        }
                        else
                        {
                            m_SelectedField = null;
                            e.Field.Area = PivotArea.FilterArea;
                        }
                    }

                    if (!Utils.IsEmpty(cbAggregate.EditValue))
                    {
                        UpdateDenominatorIndexes();
                        RaiseInitDenominatorComboBox();
                        RaiseInitAdmUnitComboBox();
                        RaiseInitStatDateComboBox();
                    }

                    ClickOnFocusedCell(true);

                    AjustCreateDeleteFieldsEnable();
                    if (PivotGrid.IsDataAreaEmpty)
                    {
                        try
                        {
                            m_AggregateDisableChanging = true;

                            tbAggregateColumnName.Text = string.Empty;
                            cbAggregate.EditValue = DBNull.Value;
                            cbAggregate.Enabled = false;
                        }
                        finally
                        {
                            m_AggregateDisableChanging = false;
                        }
                    }

                    InitFilterControlHelperAndRefreshFilter();
                    RefreshChkApplyFilter(FilterCriteria);

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
            FillDataSourceWithAbsentValues();
            RefreshData();
        }

        private void cbAggregate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.cbAggregate_EditValueChanged()");

                if (m_AggregateDisableChanging)
                {
                    return;
                }

                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.BindAggregateFunctions))
                {
                    return;
                }

                CheckSelectedRow();

                PivotGridField field;
                if (!TryGetSelectedField(out field))
                {
                    return;
                }

                m_SelectedRow.idfsAggregateFunction = PivotPresenter.ConvertValueToLong(cbAggregate.EditValue);
                ResetUnitDictionary();

                CustomSummaryType summaryTypeType = SelectedRowSummaryType;

                bool isPopulation = (summaryTypeType == CustomSummaryType.Pop10000) ||
                                    (summaryTypeType == CustomSummaryType.Pop100000) ||
                                    (summaryTypeType == CustomSummaryType.PopGender100000);
                AdministrativeUnitVisible(isPopulation, (summaryTypeType == CustomSummaryType.PopGender100000));
                if (isPopulation)
                {
                    RaiseInitAdmUnitComboBox();
                    RaiseInitStatDateComboBox();
                }
                else
                {
                    cbAdministrativeUnit.EditValue = DBNull.Value;
                }

                bool isProportion = (summaryTypeType == CustomSummaryType.Proportion);
                DenominatorVisible(isProportion);
                if (isProportion)
                {
                    UpdateDenominatorIndexes();
                    RaiseInitDenominatorComboBox();
                }
                else
                {
                    cbDenominator.EditValue = DBNull.Value;
                }

                switch (summaryTypeType)
                {
                    case CustomSummaryType.PercentOfColumn:
                        field.SummaryDisplayType = PivotSummaryDisplayType.PercentOfColumn;
                        break;
                    case CustomSummaryType.PercentOfRow:
                        field.SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow;
                        break;
                    default:
                        field.SummaryDisplayType = PivotSummaryDisplayType.Default;
                        break;
                }
                //row["idfsUnitQuerySearchField"] = cbAdministrativeUnit.EditValue;

                PivotGrid.UpdatePivotFieldSummary(field, summaryTypeType);
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

        private void cbDenominator_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.cbDenominator_EditValueChanged()");

                CheckSelectedRow();

                PivotGridField field;
                if (!TryGetSelectedField(out field))
                {
                    return;
                }

                string denominatorFieldName = Utils.Str(cbDenominator.EditValue);
                if (string.IsNullOrEmpty(denominatorFieldName))
                {
                    m_SelectedRow.SetDenominatorSearchFieldAliasNull();
                    m_SelectedRow.SetidfDenominatorQuerySearchFieldNull();
                }
                else
                {
                    m_SelectedRow.DenominatorSearchFieldAlias =
                        RamPivotGridHelper.GetOriginalNameFromFieldName(denominatorFieldName);
                    m_SelectedRow.idfDenominatorQuerySearchField =
                        RamPivotGridHelper.GetIdFromFieldName(denominatorFieldName);
                }

                //Recount aggregation 
                WinPivotGridField denominatorField = GetField(denominatorFieldName);
                int denominatorIndex = (denominatorField != null) ? denominatorField.AreaIndex : -1;

                PivotGrid.UpdateDenominatorIndex(field.FieldName, denominatorIndex);

                PivotGrid.UpdatePivotFieldSummary(field, SelectedRowSummaryType);

                // refresh but should not set m_Changes to true
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                {
                    RefreshData();
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

        private void cbAdministrativeUnit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.cbAdministrativeUnit_EditValueChanged()");

                CheckSelectedRow();

                PivotGridField field;
                if (!TryGetSelectedField(out field))
                {
                    return;
                }

                string fieldName = Utils.Str(cbAdministrativeUnit.EditValue);
                if (string.IsNullOrEmpty(fieldName))
                {
                    m_SelectedRow.SetUnitSearchFieldAliasNull();
                    m_SelectedRow.SetidfUnitQuerySearchFieldNull();
                }
                else
                {
                    m_SelectedRow.UnitSearchFieldAlias = RamPivotGridHelper.GetOriginalNameFromFieldName(fieldName);
                    m_SelectedRow.idfUnitQuerySearchField = RamPivotGridHelper.GetIdFromFieldName(fieldName);
                }
                ResetUnitDictionary();

                //Recount aggregation 
                PivotGrid.UpdatePivotFieldSummary(field, SelectedRowSummaryType);

                // refresh but should not set m_Changes to true
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                {
                    RefreshData();
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
                Trace.WriteLine(Trace.Kind.Undefine, "PivotForm.cbForDate_EditValueChanged()");

                CheckSelectedRow();

                PivotGridField field;
                if (!TryGetSelectedField(out field))
                {
                    return;
                }

                string fieldName = Utils.Str(cbForDate.EditValue);
                if (string.IsNullOrEmpty(fieldName))
                {
                    m_SelectedRow.SetDateSearchFieldAliasNull();
                    m_SelectedRow.SetidfDateQuerySearchFieldNull();
                }
                else
                {
                    m_SelectedRow.DateSearchFieldAlias = RamPivotGridHelper.GetOriginalNameFromFieldName(fieldName);
                    m_SelectedRow.idfDateQuerySearchField = RamPivotGridHelper.GetIdFromFieldName(fieldName);
                }

                ResetUnitDictionary();

                //Recount aggregation 
                PivotGrid.UpdatePivotFieldSummary(field, SelectedRowSummaryType);

                // refresh but should not set m_Changes to true
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                {
                    RefreshData();
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
            using (
                var filterForm = new FilterForm(PivotGrid, filterControl.FilterCriteria,
                                                m_PivotPresenter.SharedPresenter.SharedModel.SelectedQueryId))
            {
                filterForm.ApplyFilter = ApplyFilter;
                if (filterForm.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    m_ApplyingFilter = true;
                    //m_PivotPresenter.ApplyFilter = filterForm.m_PivotPresenter.ApplyFilter;

                    bool oldState = chkApplyFilter.Checked;
                    chkApplyFilter.Checked = filterForm.ApplyFilter;
                    bool isFilterApplied = SetPrefilter(filterForm.FilterCriteria, true);
                    if (!isFilterApplied)
                    {
                        chkApplyFilter.Checked = oldState;
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
                CheckSelectedRow();
                return PivotPresenter.ParseSummaryType(m_SelectedRow.idfsAggregateFunction);
            }
        }

        private bool SetPrefilter(CriteriaOperator criteria, bool resetFilterControl)
        {
            if ((!PivotGrid.LayoutRestoring) &&
                (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding)) &&
                ((!ReferenceEquals(FilterCriteria, null) && !FilterCriteria.Equals(criteria)) ||
                 (!ReferenceEquals(criteria, null) && criteria.Equals(FilterCriteria)) == false))
            {
                m_Changed = true;
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

            RefreshChkApplyFilter(criteria);

            
            return result;
        }

        private void RefreshChkApplyFilter(CriteriaOperator criteria)
        {
            
            if (ReferenceEquals(criteria, null) || Utils.IsEmpty(criteria.LegacyToString()))
            {
                chkApplyFilter.Text = "";
                chkApplyFilter.ToolTip = "";
                chkApplyFilter.ForeColor = Color.Black;
            }
            else
            {
                chkApplyFilter.ToolTip = FilterControlHelper.GetFilterTextForPivotGrid(PivotGrid, criteria);
                chkApplyFilter.Text = chkApplyFilter.ToolTip.Replace(Environment.NewLine, " ");
                chkApplyFilter.ForeColor = m_FilterControlHelper.Validate(false) ? Color.Black : Color.Red;
            }
            m_PivotPresenter.SetFilterText(chkApplyFilter.ToolTip);
            chkApplyFilter.Visible = !Utils.IsEmpty(chkApplyFilter.Text.Trim());
            chkApplyFilter.Refresh();
        }

        private void ResetUnitDictionary()
        {
            m_UnitDictionary = new Dictionary<string, UnitField>();
        }

        public void UpdateCustomizationFormEnabling()
        {
            CustomizationFormEnabled = RamPermissions.UpdatePermission && PivotGrid.FieldsInvisible;
        }

        private void CreateFieldsCopyButton_Click(object sender, EventArgs e)
        {
            if (SelectedField != null)
            {
                using (PivotGrid.BeginTransaction())
                {
                    m_PivotPresenter.CreateFieldCopy(SelectedField);
                    UpdateNameSummaryTypeDictionary();
                    UpdateDenominatorIndexes();
                }
                ClickOnFocusedCell(true);
            }
        }

        private void DeleteFieldsCopyButton_Click(object sender, EventArgs e)
        {
            if (SelectedField != null)
            {
                using (PivotGrid.BeginTransaction())
                {
                    m_PivotPresenter.DeleteFieldCopy(SelectedField);
                    UpdateNameSummaryTypeDictionary();
                    UpdateDenominatorIndexes();
                }
                ClickOnFocusedCell(true);
                AjustCreateDeleteFieldsEnable();
            }
        }

        #endregion

        #region helper methods

        private void FillDataSourceWithAbsentValues()
        {
            try
            {
                if (PivotGrid.CellsCount <= RamPivotGrid.MaxLayoutCellCount )
                {
                    PivotGrid.FillDataSourceWithAbsentValues();
                }
                else
                {
                    ErrorForm.ShowError("msgTooManyLayoutCells", "msgTooManyLayoutCells", PivotGrid.CellsCount.ToString(),
                                        RamPivotGrid.MaxLayoutCellCount.ToString());
                }
            }
            catch (OutOfMemoryException)
            {
                ErrorForm.ShowError("ErrAVROutOfMemory");
                PivotGrid.DataSource = m_PivotPresenter.GetPreparedDataSource();
            }
        }

    

        private void CheckSelectedRow()
        {
            if (m_SelectedRow == null)
            {
                throw new RamException("Row in AggregateTable should be filtered");
            }
        }

        private void AdministrativeUnitVisible(bool visible, bool isGender)
        {
            lblAdministrativeUnit.Visible = visible && (!isGender);
            cbAdministrativeUnit.Visible = visible && (!isGender);
            cbForDate.Visible = visible;
            lblForDate.Visible = visible;
            // lblForDate.Left = ccbShowTotals.Left;
        }

        private void DenominatorVisible(bool visible)
        {
            lblDenominator.Visible = visible;
            cbDenominator.Visible = visible;
        }

        public UnitField GetIdUnitFieldName(string unitFieldName)
        {
            Utils.CheckNotNullOrEmpty(unitFieldName, "unitFieldName");

            if (m_UnitDictionary.ContainsKey(unitFieldName))
            {
                return m_UnitDictionary[unitFieldName];
            }

            SelectAggregateRow(unitFieldName);

            var dataView = cbAdministrativeUnit.Properties.DataSource as DataView;
            string unitFullFieldName = SharedPresenter.GetSelectedAdmFieldAlias(dataView, m_SelectedRow);

            string dateFullFieldName = SharedPresenter.GetSelectedDateFieldAlias(m_SelectedRow);

            var unitField = new UnitField(unitFullFieldName, dateFullFieldName);

            m_UnitDictionary.Add(unitFieldName, unitField);
            return unitField;
        }

        internal void AddCopyPrefixForLayoutNames()
        {
            tbLayoutName.Text = m_PivotPresenter.GetValueWithPrefix(tbLayoutName.Text, "strLayoutName",
                                                                    ModelUserContext.CurrentLanguage);
            tbDefaultLayoutName.Text = m_PivotPresenter.GetValueWithPrefix(tbDefaultLayoutName.Text,
                                                                           "strDefaultLayoutName",
                                                                           Localizer.lngEn);
        }

        private void SelectAggregateRow(string fieldName)
        {
            Utils.CheckNotNullOrEmpty(fieldName, "fieldName");

            WinPivotGridField field = GetField(fieldName);

            string filter = string.Format("idfLayoutSearchField ='{0}'", field.Id);
            DataRow[] selectedRows = m_PivotPresenter.AggregateTable.Select(filter);
            m_SelectedRow = GetAggregateDetail(selectedRows, field);
        }

        private LayoutDetailDataSet.AggregateRow GetAggregateDetail(DataRow[] rows, WinPivotGridField field)
        {
            Utils.CheckNotNull(rows, "rows");
            Utils.CheckNotNull(field, "field");

            if (rows.Length == 0)
            {
                LayoutDetailDataSet.AggregateRow newRow =
                    m_PivotPresenter.AddNewAggregateRow(field.OriginalName, (long) field.GetSummaryType);

                return newRow;
            }
            return (LayoutDetailDataSet.AggregateRow) rows[0];
        }

        private bool TryGetSelectedField(out PivotGridField field)
        {
            string fieldName = RamPivotGridHelper.CreateFieldName(m_SelectedRow.SearchFieldAlias,
                                                                  m_SelectedRow.idfLayoutSearchField);

            field = GetField(fieldName);
            return (field != null);
        }

        private void AjustCreateDeleteFieldsEnable()
        {
            bool createEnabled = !ReadOnly && !PivotGrid.IsDataAreaEmpty;
            CreateFieldsCopyButton.Enabled = createEnabled;

            bool deleteEnabled = createEnabled;
            if (createEnabled && m_SelectedRow != null)
            {
                var count = WinFields.Count(field => field.OriginalName == m_SelectedRow.SearchFieldAlias);
                deleteEnabled = count > 2;
            }
            DeleteFieldsCopyButton.Enabled = deleteEnabled;
        }

        #endregion
    }
}
