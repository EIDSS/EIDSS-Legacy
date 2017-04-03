using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.BaseComponents;
using eidss.avr.ChartForm;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.avr.Handlers.AvrEventArgs;
using eidss.avr.Handlers.DevExpressEventArgsWrappers;
using eidss.avr.Tools;
using eidss.avr.Tools.DataTransactions;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;

namespace eidss.avr.PivotComponents
{
    public partial class AvrPivotGrid : PivotGridControl, IAvrPivotGridView
    {
        private const int DefaultMaxCellCountValue = 1000000;
        private const int DefaultMaxLayoutComplexity = 500000;
        private const int DefaultMaxChartItemCount = 200;
        private readonly IDataTransactionStrategy m_DataTransactionStrategy;
        private AvrPivotGridData m_DataSource;
        private bool m_HideData;

        private bool m_LayoutRestoring;

        private IAvrPivotGridField m_GenderField;
        private IAvrPivotGridField m_AgeGroupField;

        private bool m_IsGenderFieldPresents;
        private bool m_IsAgeGroupFieldPresents;

        private readonly SharedPresenter m_SharedPresenter;
        private readonly CustomSummaryHandler m_CustomSummaryHandler;

        private List<IAvrPivotGridField> m_DataAreaFields;
        private List<IAvrPivotGridField> m_ColumnAreaFields;
        private List<IAvrPivotGridField> m_RowAreaFields;

        public event EventHandler<CommandEventArgs> SendCommand;

        public event EventHandler<PivotFieldPopupMenuEventArgs> PivotFieldMouseRightClick;

        public AvrPivotGrid()
        {
            InitializeComponent();
            m_SharedPresenter = PresenterFactory.SharedPresenter;
            PivotGridPresenter = (AvrPivotGridPresenter) m_SharedPresenter[this];
            m_CustomSummaryHandler = new CustomSummaryHandler(this);
            DisplayTextHandler = new DisplayTextHandler();

            CustomCellDisplayText += OnCustomCellDisplayText;
            FieldValueDisplayText += OnFieldValueDisplayText;
            CustomSummary += OnCustomSummary;

            FieldAreaChanging += OnFieldAreaChanging;
            FieldAreaChanged += OnFieldAreaChanged;
            FieldFilterChanged += OnFieldFilterChanged;
            CustomDrawFieldHeaderArea += OnCustomDrawFieldHeaderArea;

            CustomDrawFieldHeader += OnCustomDrawFieldHeader;

            MouseClick += OnMouseClick;
            HideCustomizationForm += OnHideCustomizationForm;
            ShowCustomizationForm += OnShowCustomizationForm;

            if ((CustomizationForm != null) && (CustomizationForm.ActiveListBox != null))
            {
                CustomizationForm.ActiveListBox.MouseClick += ActiveListBox_MouseClick;
            }

            m_DataTransactionStrategy = new DataTransactionStrategy();

            HeaderImages = AvrFieldIcons.ImageList;
        }

        /// <summary>
        ///     Clean up any resources being used.
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
                    var fieldsToDispose = new List<PivotGridFieldBase>();
                    fieldsToDispose.AddRange(Fields.Cast<PivotGridFieldBase>());

                    foreach (PivotGridFieldBase field in fieldsToDispose)
                    {
                        field.Dispose();
                    }
                    Fields.Clear();
                    DataSource = null;
                }
            }
            if (PivotGridPresenter != null)
            {
                PivotGridPresenter.Dispose();
                PivotGridPresenter = null;
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
        public IEnumerable<IAvrPivotGridField> AvrFields
        {
            get { return Fields.Cast<IAvrPivotGridField>(); }
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
        public bool RowsFreezed
        {
            get { return OptionsBehavior.HorizontalScrolling == PivotGridScrolling.CellsArea; }
            set { OptionsBehavior.HorizontalScrolling = (value) ? PivotGridScrolling.CellsArea : PivotGridScrolling.Control; }
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
        public PivotGridViewInfoData PivotData
        {
            get { return Data; }
        }

        [DefaultValue(null)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AvrPivotGridData DataSource
        {
            get { return m_DataSource; }
            set
            {
                AvrPivotGridData oldData = m_DataSource;

                // DistinctCounter should not reference to old data table
                if (oldData != null && oldData.RealPivotData != null && oldData != value)
                {
                    PivotGridPresenter.DistinctCounter = new DistinctCounter();
                }
                base.DataSource = null;

                m_DataSource = value;
                if (m_DataSource != null && m_DataSource.RealPivotData != null)
                {
                    PivotGridPresenter.DistinctCounter = new DistinctCounter(m_DataSource.RealPivotData);
                    base.DataSource = HideData
                        ? m_DataSource.ClonedPivotData
                        : m_DataSource.RealPivotData;
                }
            }
        }

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HideData
        {
            get { return m_HideData; }
            set
            {
                m_HideData = value;
                base.DataSource = value
                    ? DataSource.ClonedPivotData
                    : DataSource.RealPivotData;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LayoutRestoring
        {
            get { return m_LayoutRestoring; }
        }

        public long CellsCount
        {
            get { return Cells.ColumnCount * Cells.RowCount; }
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

                bool anyVisible = AvrFields.Any(field => field.Visible);
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

                bool anyInvisible = AvrFields.Any(field => !field.Visible);
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

                bool allEmpty = AvrFields.All(field => (!field.Visible) || (field.Area != PivotArea.DataArea));
                return allEmpty;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<IAvrPivotGridField> DataAreaFields
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new List<IAvrPivotGridField>();
                }

                return m_DataAreaFields ??
                       (m_DataAreaFields = AvrPivotGridHelper.GetFieldCollectionFromArea(AvrFields, PivotArea.DataArea));
            }
            private set { m_DataAreaFields = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<IAvrPivotGridField> ColumnAreaFields
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new List<IAvrPivotGridField>();
                }

                return m_ColumnAreaFields ??
                       (m_ColumnAreaFields = AvrPivotGridHelper.GetFieldCollectionFromArea(AvrFields, PivotArea.ColumnArea));
            }
            private set { m_ColumnAreaFields = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<IAvrPivotGridField> RowAreaFields
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new List<IAvrPivotGridField>();
                }

                return m_RowAreaFields ??
                       (m_RowAreaFields = AvrPivotGridHelper.GetFieldCollectionFromArea(AvrFields, PivotArea.RowArea));
            }
            private set { m_RowAreaFields = value; }
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
        public AvrPivotGridPresenter PivotGridPresenter { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IAvrPivotGridField GenderField
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
                    m_GenderField = AvrPivotGridHelper.GetGenderField(AvrFields);
                }
                return m_GenderField;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IAvrPivotGridField AgeGroupField
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
                    m_AgeGroupField = AvrPivotGridHelper.GetAgeGroupField(AvrFields);
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DisplayTextHandler DisplayTextHandler { get; private set; }

        #endregion

        #region Restore Layout methods

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

        public void SetDataSourceAndCreateFields(DataTable table)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            using (BeginTransaction())
            {
                Fields.Clear();

                DataSource = null;

                if (table == null)
                {
                    return;
                }

                PivotGridPresenter.InitPivotCaptions(table);

                List<WinPivotGridField> fieldList = AvrPivotGridHelper.CreateFields<WinPivotGridField>(table);

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

                DataSource = new AvrPivotGridData(table);
            }
        }

        public IDisposable BeginTransaction()
        {
            return DataTransactionStrategy.BeginTransaction(Data);
        }

        public PivotGridDataLoadedCommand CreatePivotDataLoadedCommand(string layoutName, bool skipData = false)
        {
            PivotGridDataLoadedCommand command = PivotGridPresenter.CreatePivotDataLoadedCommand(layoutName, skipData);
            return command;
        }

        public void ClearCacheDataRowColumnAreaFields()
        {
            DataAreaFields = null;
            ColumnAreaFields = null;
            RowAreaFields = null;
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

            var groupOperator = criteria as GroupOperator;
            if (!ReferenceEquals(groupOperator, null))
            {
                GroupOperator copiedCriteria = groupOperator.Clone();

                //It need because CriteriaToWhereClauseHelper.GetDataSetWhere doesn't work correctry with function operators
                // todo: change removing of function operators to correct processing
                RemoveFunctionOperators(copiedCriteria);
                filter = AvrPivotGridHelper.GetCorrectFilter(copiedCriteria);
            }

            List<string> columnList = PrepareColumnNameList(ColumnAreaFields);
            int columnCount = PivotGridPresenter.DistinctCounter.DistinctCount(columnList, filter);
            List<string> rowListList = PrepareColumnNameList(RowAreaFields);
            int rowCount = PivotGridPresenter.DistinctCounter.DistinctCount(rowListList, filter);
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

        internal void SortFieldCustomizationPanel()
        {
            //workaround for sorting fields in fieldcustomization panel
            foreach (IAvrPivotGridField field in AvrFields)
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
        ///     Remove Function Operators from Clause.
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
                else
                {
                    var groupOperator = operand as GroupOperator;
                    if (!ReferenceEquals(groupOperator, null))
                    {
                        RemoveFunctionOperators(groupOperator);
                    }
                }
            }
            foreach (CriteriaOperator operand in toRemove)
            {
                criteria.Operands.Remove(operand);
            }
        }

        private static List<string> PrepareColumnNameList(IEnumerable<IAvrPivotGridField> fieldList)
        {
            List<string> columnNames = fieldList.Select(field => field.FieldName).ToList();
            return columnNames;
        }

        internal void RefreshAllPivotFieldsSummary()
        {
            foreach (IAvrPivotGridField field in AvrFields)
            {
                PivotSummaryType summaryType = field.CustomSummaryType == CustomSummaryType.Count
                    ? PivotSummaryType.Count
                    : PivotSummaryType.Custom;
                field.SummaryType = summaryType;
            }
            RefreshData();
        }

        internal void UpdatePivotFieldSummary(IAvrPivotGridField field, CustomSummaryType customType)
        {
            Utils.CheckNotNull(field, "field");

            bool isChanged = (field.CustomSummaryType != customType) ||
                             (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding));

            PivotSummaryType summaryType = customType == CustomSummaryType.Count
                ? PivotSummaryType.Count
                : PivotSummaryType.Custom;
            if (field.SummaryType == PivotSummaryType.Custom && summaryType == PivotSummaryType.Custom && isChanged)
            {
                RefreshData();
            }
            field.CustomSummaryType = customType;
            field.SummaryType = summaryType;
        }

        public void AddMissedValuesInRowColumnArea()
        {
            try
            {
                AvrPivotGridHelper.AddMissedValuesInRowColumnArea(DataSource, AvrFields.ToList());
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

        public new void RefreshData()
        {
            if (HideData)
            {
                base.DataSource = m_DataSource.ClonedPivotData;
            }
            base.RefreshData();
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
            m_CustomSummaryHandler.OnCustomSummary(sender, new WinPivotGridCustomSummaryEventArgs(e));
        }

        internal void OnCustomCellDisplayText(object sender, PivotCellDisplayTextEventArgs e)
        {
            var dataField = e.DataField as IAvrPivotGridField;
            if (dataField != null)
            {
                DisplayTextHandler.DisplayCellText(new WinPivotCellDisplayTextEventArgs(e), dataField.CustomSummaryType, dataField.Precision);
            }
            else
            {
                DisplayTextHandler.DisplayAsterisk(new WinPivotCellDisplayTextEventArgs(e));
            }
        }

        internal void OnFieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            DisplayTextHandler.DisplayAsterisk(new WinPivotFieldDisplayTextEventArgs(e));

            var dataField = e.DataField as IAvrPivotGridField;
            if (dataField != null)
            {
                if (e.ValueType != PivotGridValueType.Value)
                {
                    List<CustomSummaryType> summaryTypes = DataAreaFields.Select(field => field.CustomSummaryType).ToList();

                    DisplayTextHandler.DisplayStatisticsTotalCaption(new WinPivotFieldDisplayTextEventArgs(e), summaryTypes);
                }
            }
        }

        private void OnFieldAreaChanging(object sender, PivotAreaChangingEventArgs e)
        {
            Cells.Selection = new Rectangle();
            m_IsGenderFieldPresents = false;
            m_IsAgeGroupFieldPresents = false;
        }

        private void OnFieldFilterChanged(object sender, PivotFieldEventArgs e)
        {
            Cells.Selection = new Rectangle();
        }

        private void OnCustomDrawFieldHeaderArea(object sender, PivotCustomDrawHeaderAreaEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, e.Bounds);

            //  e.Handled = true;
        }

        private void OnCustomDrawFieldHeader(object sender, PivotCustomDrawFieldHeaderEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, e.Bounds);
        }

        private void OnShowCustomizationForm(object sender, EventArgs e)
        {
            if (CustomizationForm != null)
            {
                CustomizationForm.ActiveListBox.MouseClick += ActiveListBox_MouseClick;
            }
        }

        private void OnHideCustomizationForm(object sender, EventArgs e)
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
                IVisualCustomizationTreeItem item = CustomizationForm.ActiveListBox.GetItem(e.Location);
                if (item != null && item.Field != null)
                {
                    RaisePivotFieldMouseRightClick(item.Field.FieldName,
                        WinUtils.GetAbsoluteLocation(CustomizationForm.ActiveListBox, e.Location));
                }
            }
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            PivotGridHitInfo hInfo = CalcHitInfo(e.Location);
            if ((e.Button == MouseButtons.Right) && (hInfo.HeaderField != null))
            {
                RaisePivotFieldMouseRightClick(hInfo.HeaderField.FieldName, WinUtils.GetAbsoluteLocation(this, e.Location));
            }
        }

        private void OnFieldAreaChanged(object sender, PivotFieldEventArgs e)
        {
            if (e.Field != null && (!e.Field.Visible || e.Field.Area == PivotArea.DataArea))
            {
                e.Field.FilterValues.Clear();
            }

            ClearCacheDataRowColumnAreaFields();
        }

        private void RaisePivotFieldMouseRightClick(string fieldName, Point location)
        {
            Utils.CheckNotNullOrEmpty(fieldName, "fieldName");
            IAvrPivotGridField field = AvrFields.FirstOrDefault(f => f.FieldName == fieldName);

            bool enableDelete = EnableDeleteField(field);

            bool enableGroupDate = field != null && field.IsDateTimeField;

            PivotFieldMouseRightClick.SafeRaise(this, new PivotFieldPopupMenuEventArgs(field, location, enableDelete, enableGroupDate));
        }

        private bool EnableDeleteField(IAvrPivotGridField field)
        {
            return AvrPivotGridHelper.EnableDeleteField(field, AvrFields);
            //if (field == null)
            //{
            //    return false;
            //}
            //int count = AvrFields.Count(f => f.GetOriginalName() == field.GetOriginalName());
            //return count > 2;
        }

        #endregion
    }
}