using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;
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
using eidss.avr.Tools.DataTransactions;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.model.Reports.OperationContext;

namespace eidss.avr.PivotComponents
{
    public partial class AvrPivotGrid : PivotGridControl, IAvrPivotGridView
    {
        private const int DefaultMaxChartItemCount = 200;
        private readonly IDataTransactionStrategy m_DataTransactionStrategy;
        private AvrPivotGridData m_DataSource;
        private bool m_HideData;

        private IAvrPivotGridField m_GenderField;
        private IAvrPivotGridField m_AgeGroupField;

        private bool m_IsGenderFieldPresents;
        private bool m_IsAgeGroupFieldPresents;

        private readonly SharedPresenter m_SharedPresenter;
        private readonly CustomSummaryHandler m_CustomSummaryHandler;
        //  private readonly CustomSortHandler m_CustomSortHandler;

        private List<IAvrPivotGridField> m_DataAreaFields;
        private List<IAvrPivotGridField> m_ColumnAreaFields;
        private List<IAvrPivotGridField> m_RowAreaFields;

        public event EventHandler<CommandEventArgs> SendCommand;

        //fake event handler to supress warning about not used SendCommand
        protected virtual void OnSendCommand(CommandEventArgs e)
        {
            if (SendCommand != null)
            {
                SendCommand(this, e);
            }
        }

        public event EventHandler<PivotFieldPopupMenuEventArgs> PivotFieldMouseRightClick;

        public AvrPivotGrid()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this) || BaseSettings.ScanFormsMode)
            {
                return;
            }
            //  OptionsBehavior.UseAsyncMode = true;

            m_SharedPresenter = PresenterFactory.SharedPresenter;
            PivotGridPresenter = (AvrPivotGridPresenter) m_SharedPresenter[this];
            m_CustomSummaryHandler = new CustomSummaryHandler(this);
            //m_CustomSortHandler = new CustomSortHandler();

            DisplayTextHandler = new DisplayTextHandler();

            CustomCellDisplayText += OnCustomCellDisplayText;
            FieldValueDisplayText += OnFieldValueDisplayText;
            CustomSummary += OnCustomSummary;
            //CustomFieldSort += OnCustomFieldSort;

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

            if (WinUtils.IsComponentInDesignMode(this) || BaseSettings.ScanFormsMode)
            {
                return;
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
                base.DataSource = null;

                m_DataSource = value;
                if (m_DataSource != null && m_DataSource.RealPivotData != null)
                {
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
                if (DataSource != null)
                {
                    base.DataSource = value
                        ? DataSource.ClonedPivotData
                        : DataSource.RealPivotData;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LayoutRestoring { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                return m_RowAreaFields ??
                       (m_RowAreaFields = AvrPivotGridHelper.GetFieldCollectionFromArea(AvrFields, PivotArea.RowArea));
            }
            private set { m_RowAreaFields = value; }
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
                var title = new PivotChartTitle(dataFields.Aggregate(String.Empty, aggrFunc),
                    rowFields.Aggregate(String.Empty, aggrFunc),
                    columnFields.Aggregate(String.Empty, aggrFunc));
                return title;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DisplayTextHandler DisplayTextHandler { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SingleSearchObject { get; set; }

        #endregion

        #region Restore Layout methods

        protected override void RestoreLayoutCore(XtraSerializer serializer, object path, OptionsLayoutBase options)
        {
            try
            {
                LayoutRestoring = true;
                base.RestoreLayoutCore(serializer, path, options);
            }
            finally
            {
                LayoutRestoring = false;
            }
        }

        #endregion

        #region Update methods

        public void SetDataSourceAndCreateFields(AvrDataTable table)
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

        internal void RefreshAllPivotFieldsSummary()
        {
            foreach (IAvrPivotGridField field in AvrFields)
            {
                PivotSummaryType summaryType = field.CustomSummaryType == CustomSummaryType.Count
                    ? PivotSummaryType.Count
                    : PivotSummaryType.Custom;
                field.SummaryType = summaryType;
            }
            //  RefreshData();
        }

        internal bool UpdatePivotFieldSummary(IAvrPivotGridField field, CustomSummaryType customType)
        {
            Utils.CheckNotNull(field, "field");

            bool isChanged = (field.CustomSummaryType != customType) ||
                             (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding));

            PivotSummaryType summaryType = customType == CustomSummaryType.Count
                ? PivotSummaryType.Count
                : PivotSummaryType.Custom;

            bool doRefresh = (field.SummaryType == PivotSummaryType.Custom && summaryType == PivotSummaryType.Custom && isChanged);

            field.CustomSummaryType = customType;
            field.SummaryType = summaryType;

            if (doRefresh)
            {
                RefreshData();
            }
            return doRefresh;
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

        internal void OnCustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            m_CustomSummaryHandler.OnCustomSummary(sender, new WinPivotGridCustomSummaryEventArgs(e));
        }

        // todo[ivan] uncomment and implement if custom sorting need to be implemented, delete otherwise
//        internal void OnCustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
//        {
//            
//            m_CustomSortHandler.OnCustomFieldSort(sender, e);
//        }

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
            var eventArgs = new WinPivotFieldDisplayTextEventArgs(e);
            DisplayTextHandler.DisplayAsterisk(eventArgs);
            DisplayTextHandler.DisplayBool(eventArgs);

            var dataField = e.DataField as IAvrPivotGridField;
            if (dataField != null)
            {
                if (e.ValueType != PivotGridValueType.Value)
                {
                    List<CustomSummaryType> summaryTypes = DataAreaFields.Select(field => field.CustomSummaryType).ToList();

                    DisplayTextHandler.DisplayStatisticsTotalCaption(eventArgs, summaryTypes);
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

            PivotFieldMouseRightClick.SafeRaise(this, new PivotFieldPopupMenuEventArgs(field, location));
        }

        #endregion
    }
}