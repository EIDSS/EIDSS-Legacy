using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using EIDSS.RAM.Components.DataTransactions;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary;
using EIDSS.RAM.Tools;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.Access;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Core;
using eidss.model.Resources;
using ErrorForm = bv.common.win.ErrorForm;

namespace EIDSS.RAM.Components
{
    public partial class RamPivotGrid : PivotGridControl, IRamPivotGridView
    {
        private const int DefaultMaxCellCountValue = 1000000;
        private const int DefaultMaxLayoutComplexity = 500000;
        private const int DefaultMaxChartItemCount = 200;
        private readonly IDataTransactionStrategy m_DataTransactionStrategy;
        private bool m_LayoutFieldVisible;
        private PivotForm m_ParentPivotForm;
        private bool m_LayoutRestoring;

        private PivotGridFieldBase m_GenderField;
        private PivotGridFieldBase m_AgeGroupField;

        private bool m_IsGenderFieldPresents;
        private bool m_IsAgeGroupFieldPresents;

        private readonly RamPivotGridPresenter m_PivotGridPresenter;
        private readonly SharedPresenter m_SharedPresenter;
        private readonly CustomSummaryHandler m_CustomSummaryHandler;
        private readonly DisplayTextHandler m_DisplayTextHandler;
        private List<PivotGridFieldBase> m_DataAreaFields;
        private List<PivotGridFieldBase> m_ColumnAreaFields;
        private List<PivotGridFieldBase> m_RowAreaFields;

        public event EventHandler<CommandEventArgs> SendCommand;

        public new event PivotFieldVisibleChangedEventHandler FieldVisibleChanged;
        public event EventHandler<PivotFieldPopupMenuEventArgs> PivotFieldMouseRightClick;

        public RamPivotGrid()
        {
            InitializeComponent();
            DenominatorIndexes = new Dictionary<string, int>();
            m_SharedPresenter = PresenterFactory.SharedPresenter;
            m_PivotGridPresenter = (RamPivotGridPresenter) m_SharedPresenter[this];
            m_CustomSummaryHandler = new CustomSummaryHandler(this);
            m_DisplayTextHandler = new DisplayTextHandler(this);

            CustomCellDisplayText += OnCustomCellDisplayText;
            FieldValueDisplayText += OnFieldValueDisplayText;
            CustomSummary += OnCustomSummary;

            FieldAreaChanging += RamPivotGrid_FieldAreaChanging;
            FieldAreaChanged += RamPivotGrid_FieldAreaChanged;
            FieldFilterChanged += RamPivotGrid_FieldFilterChanged;

            MouseClick += RamPivotGrid_MouseClick;
            HideCustomizationForm += RamPivotGrid_HideCustomizationForm;
            ShowCustomizationForm += RamPivotGrid_ShowCustomizationForm;

            if ((CustomizationForm != null) && (CustomizationForm.ActiveListBox != null))
            {
                CustomizationForm.ActiveListBox.MouseClick += ActiveListBox_MouseClick;
            }

            GridLayout += RamPivotGrid_GridLayout;

            m_DataTransactionStrategy = new DataTransactionStrategy();

            HeaderImages = RamFieldIcons.ImageList;

            OptionsBehavior.HorizontalScrolling = PivotGridScrolling.Control;
            
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            if (m_SharedPresenter != null)
            {
                m_SharedPresenter.UnregisterView(this);
            }
            if (!IsDisposed)
            {
                using (BeginTransaction())
                {
                    Fields.Clear();
                    DataSource = null;
                }
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Properties

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotGridFieldCollectionBase BaseFields
        {
            get { return Fields; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<WinPivotGridField> RamFields
        {
            get { return Fields.Cast<WinPivotGridField>(); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int MaxLayoutCellCount
        {
            get { return Config.GetIntSetting("MaxLayoutCellCount", DefaultMaxCellCountValue); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int MaxLayoutComplexity
        {
            get { return Config.GetIntSetting("MaxLayoutComplexity", DefaultMaxLayoutComplexity); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int MaxChartItemCount
        {
            get { return Config.GetIntSetting("MaxChartItemCount", DefaultMaxChartItemCount); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalWidth
        {
            get
            {
                return (ViewInfo != null && ViewInfo.CellsArea != null)
                           ? ViewInfo.CellsArea.FirstCellOffSet.X + ViewInfo.CellsArea.TotalWidth
                           : Width;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataSet BaseDataSet
        {
            get { return new DataSet("EmptyData"); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long TotalCells
        {
            get
            {
                int columnCount = ViewInfo.CellsArea.ColumnCount + RowAreaFields.Count;
                int rowCount = ViewInfo.CellsArea.RowCount + ColumnAreaFields.Count;
                return columnCount * rowCount;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long Complexity
        {
            get
            {
                const double magicNumber = 0.4; // it received by experimental way while measuring report rendering time
                double columnCount = ViewInfo.CellsArea.ColumnCount + Math.Exp(magicNumber * RowAreaFields.Count);
                double rowCount = ViewInfo.CellsArea.RowCount + Math.Exp(magicNumber * ColumnAreaFields.Count);
                return (long) (columnCount * rowCount);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDataTransactionStrategy DataTransactionStrategy
        {
            get { return m_DataTransactionStrategy; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DateGroupIntervalChanging
        {
            get
            {
                return RamFields.Select(field => field.DateGroupIntervalChanging).FirstOrDefault();
            }
            internal set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }

                foreach (WinPivotGridField field in RamFields)
                {
                    field.DateGroupIntervalChanging = value;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotGroupInterval DateGroupInterval
        {
            get
            {
                foreach (WinPivotGridField field in RamFields)
                {
                    if (!field.IsFilter && field.GroupInterval.IsDate())
                    {
                        return field.GroupInterval;
                    }
                }
                return PivotGroupInterval.Date;
            }
            internal set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }

                PivotGroupInterval groupInterval = value.IsDate()
                                                       ? value
                                                       : PivotGroupInterval.Date;

                foreach (WinPivotGridField field in RamFields)
                {
                    field.UpdateFieldGroupInterval(groupInterval);
                }
            }
        }

        [DefaultValue(null)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTable DataSource
        {
            get { return base.DataSource as DataTable; }
            set
            {
                DataTable oldTable = DataSource;
                if (oldTable != null && oldTable != value)
                {
                    m_SharedPresenter.SharedModel.ResetReportData();
                    m_PivotGridPresenter.DistinctCounter = new DistinctCounter();
                    base.DataSource = null;

                    //DbDisposeHelper.DisposeTable(ref oldTable, true);
                }

                if (value != null)
                {
                    m_PivotGridPresenter.DistinctCounter = new DistinctCounter(value);
                }

                base.DataSource = value;
            }
        }

        [DefaultValue(null)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DataSourceWithFields
        {
            get { return DataSource; }
            set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }

                using (BeginTransaction())
                {
                    Fields.Clear();

                    DataSource = null;

                    if (value == null)
                    {
                        return;
                    }

                    m_PivotGridPresenter.InitPivotCaptions(value);

                    List<WinPivotGridField> fieldList = RamPivotGridPresenter.CreateWinFields(value);

                    if ((CustomizationForm != null) && (CustomizationForm.ActiveListBox != null))
                    {
                        CustomizationForm.ActiveListBox.BeginUpdate();
                        Fields.AddRange(fieldList.Select(field => field as PivotGridField).ToArray());
                        CustomizationForm.ActiveListBox.EndUpdate();
                    }
                    else
                    {
                        Fields.AddRange(fieldList.Select(field => field as PivotGridField).ToArray());
                    }

                    DataSource = value;
                }
            }
        }

        public UnitField GetIdUnitFieldName(string unitFieldName)
        {
            return ParentPivotForm.GetIdUnitFieldName(unitFieldName);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LayoutRestoring
        {
            get { return m_LayoutRestoring; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FieldsVisible
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return true;
                }

                bool anyVisible = RamFields.Any(field => field.Visible);
                return anyVisible;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FieldsInvisible
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return true;
                }

                bool anyInvisible = RamFields.Any(field => !field.Visible);
                return anyInvisible;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDataAreaEmpty
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return true;
                }

                bool allEmpty = RamFields.All(field => (!field.Visible) || (field.Area != PivotArea.DataArea));
                return allEmpty;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PivotGridFieldBase> DataAreaFields
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new List<PivotGridFieldBase>();
                }

                return m_DataAreaFields ??
                       (m_DataAreaFields =
                        RamPivotGridHelper.GetFieldCollectionFromArea(BaseFields.Cast<PivotGridFieldBase>(),
                                                                      PivotArea.DataArea));
            }
            set { m_DataAreaFields = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PivotGridFieldBase> ColumnAreaFields
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new List<PivotGridFieldBase>();
                }

                return m_ColumnAreaFields ??
                       (m_ColumnAreaFields =
                        RamPivotGridHelper.GetFieldCollectionFromArea(BaseFields.Cast<PivotGridFieldBase>(),
                                                                      PivotArea.ColumnArea));
            }
            set { m_ColumnAreaFields = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PivotGridFieldBase> RowAreaFields
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new List<PivotGridFieldBase>();
                }

                return m_RowAreaFields ??
                       (m_RowAreaFields =
                        RamPivotGridHelper.GetFieldCollectionFromArea(BaseFields.Cast<PivotGridFieldBase>(),
                                                                      PivotArea.RowArea));
            }
            set { m_RowAreaFields = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CriteriaOperator Criteria
        {
            get { return Prefilter != null ? Prefilter.Criteria : null; }
            set { Prefilter.Criteria = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CriteriaString
        {
            get { return Prefilter != null ? Prefilter.CriteriaString : null; }
            set { Prefilter.CriteriaString = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal PivotForm ParentPivotForm
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new PivotForm();
                }

                if (m_ParentPivotForm == null)
                {
                    Control parent = Parent;
                    while (parent != null)
                    {
                        if (parent is PivotForm)
                        {
                            m_ParentPivotForm = parent as PivotForm;
                            break;
                        }
                        parent = parent.Parent;
                    }
                }
                if (m_ParentPivotForm == null)
                {
                    throw new RamException("RamPivotGrid should be placed on PivotForm.");
                }
                return m_ParentPivotForm;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, int> DenominatorIndexes { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RamPivotGridPresenter PivotGridPresenter
        {
            get { return m_PivotGridPresenter; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotGridFieldBase GenderField
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return null;
                }

                if (!m_IsGenderFieldPresents)
                {
                    m_IsGenderFieldPresents = true;
                    m_GenderField = RamPivotGridHelper.GetGenderField(RamFields);
                }
                return m_GenderField;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotGridFieldBase AgeGroupField
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return null;
                }

                if (!m_IsAgeGroupFieldPresents)
                {
                    m_IsAgeGroupFieldPresents = true;
                    m_AgeGroupField = RamPivotGridHelper.GetAgeGroupField(RamFields);
                }
                return m_AgeGroupField;
            }
        }
        

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PivotChartTitle ChartTitle
        {
            get
            {
                Rectangle selection = Cells.Selection;
                var dataFields = new List<PivotGridField>();
                var rowFields = new List<PivotGridField>();
                var columnFields = new List<PivotGridField>();
                for (int x = selection.Left; x < selection.Right; x++)
                {
                    for (int y = selection.Top; y < selection.Bottom; y++)
                    {
                        PivotCellEventArgs info = Cells.GetCellInfo(x, y);
                        if (info.Selected)
                        {
                            if ((info.DataField != null) && (!dataFields.Contains(info.DataField)))
                            {
                                dataFields.Add(info.DataField);
                            }
                            if ((info.RowField != null) && (!rowFields.Contains(info.RowField)))
                            {
                                rowFields.Add(info.RowField);
                            }
                            if ((info.ColumnField != null) && (!columnFields.Contains(info.ColumnField)))
                            {
                                columnFields.Add(info.ColumnField);
                            }
                        }
                    }
                }
                Func<string, PivotGridField, string> aggrFunc = (result, field) => result + field.Caption + Environment.NewLine;
                var title = new PivotChartTitle(dataFields.Aggregate(string.Empty, aggrFunc),
                                                rowFields.Aggregate(string.Empty, aggrFunc),
                                                columnFields.Aggregate(string.Empty, aggrFunc));
                return title;
            }
        }

        #endregion

        #region Base methods

        protected override void RestoreLayoutCore(XtraSerializer serializer, object path, OptionsLayoutBase options)
        {
            try
            {
                m_LayoutRestoring = true;
                base.RestoreLayoutCore(serializer, path, options);
            }
            finally
            {
                m_LayoutRestoring = false;
            }
        }

        #endregion

        #region Update methods

        public IDisposable BeginTransaction()
        {
            return DataTransactionStrategy.BeginTransaction(Data);
        }

        internal bool CheckDataSize(CriteriaOperator criteria)
        {
            if (DataSource == null)
            {
                return true;
            }

            if (!BaseSettings.ShowBigLayoutWarning)
            {
                return true;
            }

            string filter = string.Empty;

            if (criteria is GroupOperator)
            {
                GroupOperator copiedCriteria = ((GroupOperator) criteria).Clone();

                //It need because CriteriaToWhereClauseHelper.GetDataSetWhere doesn't work correctry with function operators
                // todo: change removing of function operators to correct processing
                RemoveFunctionOperators(copiedCriteria);
                filter = RamPivotGridHelper.GetCorrectFilter(copiedCriteria);
            }

            List<string> columnList = PrepareColumnNameList(ColumnAreaFields);
            int columnCount = m_PivotGridPresenter.DistinctCounter.DistinctCount(columnList, filter);
            List<string> rowListList = PrepareColumnNameList(RowAreaFields);
            int rowCount = m_PivotGridPresenter.DistinctCounter.DistinctCount(rowListList, filter);
            long count = (columnCount + RowAreaFields.Count + DataAreaFields.Count) *
                         (rowCount + ColumnAreaFields.Count + DataAreaFields.Count);

            if (count < MaxLayoutCellCount)
            {
                return true;
            }

            return ShowConfirmationLoadBigLayoutDialog(count) == DialogResult.OK;
        }

        private static DialogResult ShowConfirmationLoadBigLayoutDialog(long count)
        {
            const long roundTo = 100000;
            long roundedCount = count > roundTo ? roundTo * (count / roundTo + 1) : roundTo;

            string resourceMessage = EidssMessages.Get("msgApproximatelyTooBigLayout");
            string message = string.Format(resourceMessage, roundedCount);
            string caption = BvMessages.Get("Confirmation");

            return MessageForm.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        /// <summary>
        ///   Remove Function Operators from Clause.
        /// </summary>
        /// <param name="criteria"> </param>
        private static void RemoveFunctionOperators(GroupOperator criteria)
        {
            var toRemove = new List<CriteriaOperator>();
            foreach (CriteriaOperator operand in criteria.Operands)
            {
                if (operand is FunctionOperator)
                {
                    toRemove.Add(operand);
                }
                else if (operand is GroupOperator)
                {
                    RemoveFunctionOperators((GroupOperator) operand);
                }
            }
            foreach (CriteriaOperator operand in toRemove)
            {
                criteria.Operands.Remove(operand);
            }
        }

        private static List<string> PrepareColumnNameList(IEnumerable<PivotGridFieldBase> fieldList)
        {
            List<string> columnNames = fieldList.Select(field => field.FieldName).ToList();
            return columnNames;
        }

        internal DataTable GetFilteredDataSource(string layoutName)
        {
            Utils.CheckNotNullOrEmpty(layoutName, "layoutName");

            DataTable table = DataSource.Copy();
            table.TableName = AccessTypeConverter.CovertName(layoutName);

            if (!Utils.IsEmpty(Prefilter))
            {
                string filter = RamPivotGridHelper.GetCorrectFilter(Prefilter.Criteria);
                if (!Utils.IsEmpty(filter))
                {
                    filter = Regex.Replace(filter, "(\\[field)", "[");
                    filter = string.Format("Not ({0}) ", filter);
                    using (var view = new DataView(table, filter, "", DataViewRowState.CurrentRows))
                    {
                        for (int i = view.Count - 1; i >= 0; i--)
                        {
                            view[i].Delete();
                        }
                        table.AcceptChanges();
                    }
                }
            }

            foreach (WinPivotGridField field in RamFields)
            {
                if (!field.Visible)
                {
                    table.Columns.Remove(field.FieldName);
                }
            }
            return table;
        }

        internal void SortFieldCustomizationPanel()
        {
            //workaround for sorting fields in fieldcustomization panel
            foreach (WinPivotGridField field in RamFields)
            {
                if (!field.Visible)
                {
                    field.Visible = true;
                    field.Visible = false;
                    break;
                }
            }
        }

        /// <summary>
        ///   get or set dictionary with key corresponding to field name and value - summary type Updates pivot grid fields summary type when set
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, CustomSummaryType> NameSummaryTypeDictionary
        {
            get { return m_CustomSummaryHandler.NameSummaryTypeDictionary; }
            set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }
                Utils.CheckNotNull(value, "value");
                m_CustomSummaryHandler.NameSummaryTypeDictionary = value;

                using (BeginTransaction())
                {
                    foreach (WinPivotGridField field in RamFields)
                    {
                        try
                        {
                            CustomSummaryType summaryTypeType = m_CustomSummaryHandler.NameSummaryTypeDictionary.ContainsKey(field.FieldName)
                                                                    ? m_CustomSummaryHandler.NameSummaryTypeDictionary[field.FieldName]
                                                                    : field.GetSummaryType;

                            UpdatePivotFieldSummary(field, summaryTypeType);
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
            }
        }

        internal void UpdatePivotFieldSummary(PivotGridField field, CustomSummaryType customType)
        {
            Utils.CheckNotNull(field, "field");
            bool isChanged = true;
            if (!m_CustomSummaryHandler.NameSummaryTypeDictionary.ContainsKey(field.FieldName))
            {
                m_CustomSummaryHandler.NameSummaryTypeDictionary.Add(field.FieldName, customType);
            }
            else
            {
                isChanged = (m_CustomSummaryHandler.NameSummaryTypeDictionary[field.FieldName] != customType) ||
                            (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding));
                m_CustomSummaryHandler.NameSummaryTypeDictionary[field.FieldName] = customType;
            }

            PivotSummaryType summaryType = customType == CustomSummaryType.Count
                                               ? PivotSummaryType.Count
                                               : PivotSummaryType.Custom;
            if (field.SummaryType == PivotSummaryType.Custom && summaryType == PivotSummaryType.Custom && isChanged)
            {
                RefreshData();
            }
            field.SummaryType = summaryType;
        }

        internal void UpdateDenominatorIndex(string fieldName, int denominatorIndex)
        {
            if (!DenominatorIndexes.ContainsKey(fieldName))
            {
                DenominatorIndexes.Add(fieldName, denominatorIndex);
            }
            else
            {
                DenominatorIndexes[fieldName] = denominatorIndex;
            }
        }

        public IList<CustomMapDataItem> GetSelectedCells(PivotGridFieldBase idFieldBase, PivotGridFieldBase typeFieldBase)
        {
            Utils.CheckNotNull(idFieldBase, "idFieldBase");

            PivotCellBaseEventArgsWrapper.GetCellInfoDelegate getCellInfo =
                (column, row) => new PivotCellBaseEventArgsWrapper(Cells.GetCellInfo(column, row));
            Rectangle selection = Cells.Selection.Height != 0
                                      ? Cells.Selection
                                      : new Rectangle(Cells.FocusedCell, new Size(1, 1));

            return PivotCellBaseEventArgsWrapper.GetSelectedCells(idFieldBase, typeFieldBase, getCellInfo, selection);
        }

        public long CellsCount
        {
            get { return Cells.ColumnCount * Cells.RowCount; }
        }

        public void FillDataSourceWithAbsentValues()
        {
            if (DataSource == null)
            {
                return;
            }
         
            var fieldProcessor = new RamEmptyFieldProcessor();
            for (int columnIndex = 0; columnIndex < Cells.ColumnCount; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < Cells.RowCount; rowIndex++)
                {
                    PivotCellEventArgs cellInfo = Cells.GetCellInfo(columnIndex, rowIndex);
                    if (cellInfo != null &&
                        cellInfo.Item != null &&
                        cellInfo.Item.ColumnValueType == PivotGridValueType.Value &&
                        cellInfo.Item.RowValueType == PivotGridValueType.Value
                        )
                    {
                        PivotDrillDownDataSource downDataSource = cellInfo.CreateDrillDownDataSource();
                        if (downDataSource.RowCount == 0)
                        {
                            Dictionary<string, object> fieldValues = fieldProcessor.GetFieldValuesDictionary(cellInfo, columnIndex, rowIndex);

                            DataRow row = DataSource.NewRow();
                            foreach (KeyValuePair<string, object> field in fieldValues)
                            {
                                row[field.Key] = field.Value;
                            }

                            DataSource.Rows.Add(row);
                        }
                    }
                }
            }
            // for debug
            // MessageBox.Show(string.Format("Total empty cells that filled with zero: {0}. Duration: {1}", counter, DateTime.Now - oldTime));
        }

        #endregion

        #region Handlers

        public void RaiseSendCommand(CommandEventArgs e)
        {
            EventHandler<CommandEventArgs> handler = SendCommand;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal void OnCustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            m_CustomSummaryHandler.OnCustomSummary(sender, new PivotGridCustomSummaryEventArgsWrapper(e));
        }

        internal void OnCustomCellDisplayText(object sender, PivotCellDisplayTextEventArgs e)
        {
            m_DisplayTextHandler.DisplayAsterisk(new PivotCellDisplayTextEventArgsWrapper(e));
            if (e.DataField == null)
            {
                return;
            }
            CustomSummaryType summaryType;
            m_CustomSummaryHandler.NameSummaryTypeDictionary.TryGetValue(e.DataField.FieldName, out summaryType);

            int denominatorIndex;
            if (!DenominatorIndexes.TryGetValue(e.DataField.FieldName, out denominatorIndex))
            {
                denominatorIndex = -1;
            }
            m_DisplayTextHandler.DisplayProportionText(new PivotCellDisplayTextEventArgsWrapper(e), denominatorIndex, summaryType);
            m_DisplayTextHandler.DisplayDateMonthText(new PivotCellDisplayTextEventArgsWrapper(e), summaryType);

            //e.DataField.GroupInterval == 
        }

        internal void OnFieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            m_DisplayTextHandler.DisplayAsterisk(new PivotFieldDisplayTextEventArgsWrapper(e));

            if (e.DataField == null)
            {
                return;
            }

            var summaryTypes = new List<CustomSummaryType>();
            foreach (WinPivotGridField field in DataAreaFields)
            {
                CustomSummaryType summaryType;
                m_CustomSummaryHandler.NameSummaryTypeDictionary.TryGetValue(field.FieldName, out summaryType);
                summaryTypes.Add(summaryType);
            }

            m_DisplayTextHandler.DisplayStatisticsTotalCaption(new PivotFieldDisplayTextEventArgsWrapper(e), summaryTypes);
        }

        private void RamPivotGrid_FieldAreaChanging(object sender, PivotAreaChangingEventArgs e)
        {
            Cells.Selection = new Rectangle();
            m_IsGenderFieldPresents = false;
            m_IsAgeGroupFieldPresents = false;
        }

        private void RamPivotGrid_FieldFilterChanged(object sender, PivotFieldEventArgs e)
        {
            Cells.Selection = new Rectangle();
        }

        private void RamPivotGrid_ShowCustomizationForm(object sender, EventArgs e)
        {
            if (CustomizationForm != null)
            {
                CustomizationForm.ActiveListBox.MouseClick += ActiveListBox_MouseClick;
            }
        }

        private void RamPivotGrid_HideCustomizationForm(object sender, EventArgs e)
        {
            if (CustomizationForm != null)
            {
                CustomizationForm.ActiveListBox.MouseClick -= ActiveListBox_MouseClick;
            }
        }

        private void ActiveListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && CustomizationForm != null && CustomizationForm.ActiveListBox != null)
            {
                PivotCustomizationTreeNode item = CustomizationForm.ActiveListBox.GetItem(e.Location);
                if (item != null && item.Field != null)
                {
                    RaisePivotFieldMouseRightClick(item.Field.FieldName, GetAbsoluteLocation(CustomizationForm.ActiveListBox, e.Location));
                }
            }
        }

        private void RamPivotGrid_MouseClick(object sender, MouseEventArgs e)
        {
            PivotGridHitInfo hInfo = CalcHitInfo(e.Location);
            if ((e.Button == MouseButtons.Right) && (hInfo.HeaderField != null))
            {
                RaisePivotFieldMouseRightClick(hInfo.HeaderField.FieldName, GetAbsoluteLocation(this, e.Location));
            }
        }

        private Point GetAbsoluteLocation(Control parent, Point location)
        {
            return parent == null
                       ? location
                       : GetAbsoluteLocation(parent.Parent, new Point(parent.Left + location.X, parent.Top + location.Y));
        }

        private void RamPivotGrid_FieldAreaChanged(object sender, PivotFieldEventArgs e)
        {
            var field = (WinPivotGridField) e.Field;
            if (!field.Visible)
            {
                field.FilterValues.Clear();
            }

            // clear cashe of Data, Column and Row AreaFields
            DataAreaFields = null;
            ColumnAreaFields = null;
            RowAreaFields = null;
            //
            field.UpdateFieldGroupInterval(DateGroupInterval);
        }

        private void RamPivotGrid_GridLayout(object sender, EventArgs e)
        {
            if (m_LayoutFieldVisible != FieldsVisible)
            {
                m_LayoutFieldVisible = FieldsVisible;
                RaiseFieldVisibleChangedEvent(m_LayoutFieldVisible);
            }
        }

        private void RaiseFieldVisibleChangedEvent(bool visible)
        {
            PivotFieldVisibleChangedEventHandler eventHandler = FieldVisibleChanged;
            if (eventHandler != null)
            {
                eventHandler(new LayoutFieldVisibleChanged(visible));
            }
        }

        private void RaisePivotFieldMouseRightClick(string fieldName, Point location)
        {
            PivotFieldMouseRightClick.SafeRaise(this, new PivotFieldPopupMenuEventArgs(fieldName, location));
        }

        #endregion
    }
}
