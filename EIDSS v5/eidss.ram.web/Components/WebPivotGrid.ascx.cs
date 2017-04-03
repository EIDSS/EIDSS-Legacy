using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Data.PivotGrid;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Components.DataTransactions;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary;
using EIDSS.RAM.Tools;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.Views;
using bv.common.Core;
using PivotCellDisplayTextEventArgs = DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs;
using PivotFieldDisplayTextEventArgs = DevExpress.Web.ASPxPivotGrid.PivotFieldDisplayTextEventArgs;
using PivotGridCustomSummaryEventArgs = DevExpress.Web.ASPxPivotGrid.PivotGridCustomSummaryEventArgs;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;
using ReflectionHelper = EIDSS.RAM_DB.Common.ReflectionHelper;

namespace eidss.ram.web.Components
{
    public partial class WebPivotGrid : ASPxPivotGrid, IRamPivotGridView
    {
        public new event PivotFieldVisibleChangedEventHandler FieldVisibleChanged;

        public event EventHandler<CommandEventArgs> SendCommand;

        private readonly IDataTransactionStrategy m_DataTransactionStrategy;
        private RamPivotGridPresenter m_PivotGridPresenter;
        private readonly CustomSummaryHandler m_CustomSummaryHandler;
        private readonly DisplayTextHandler m_DisplayTextHandler;
        private List<PivotGridFieldBase> m_DataAreaFields;
        private List<PivotGridFieldBase> m_ColumnAreaFields;
        private List<PivotGridFieldBase> m_RowAreaFields;
        private bool m_IsGenderFieldPresnts;
        private PivotGridFieldBase m_GenderField;
        private PivotGridFieldBase m_AgeGroupField;
        private bool m_IsAgeGroupFieldPresents;


        private readonly Dictionary<string, UnitField> m_UnitDictionary;

        public WebPivotGrid()
        {
            DenominatorIndexes = new Dictionary<string, int>();
            m_UnitDictionary = new Dictionary<string, UnitField>();

            m_CustomSummaryHandler = new CustomSummaryHandler(this);
            m_DisplayTextHandler = new DisplayTextHandler(this);

            CustomCellDisplayText += OnCustomCellDisplayText;
            FieldValueDisplayText += OnFieldValueDisplayText;
            CustomSummary += OnCustomSummary;

            m_DataTransactionStrategy = new DataTransactionStrategy();
        }

        #region Properties

        public IEnumerable<WebPivotGridField> WebFields
        {
            get { return Fields.Cast<WebPivotGridField>(); }
        }

        public bool LayoutRestoring
        {
            get { return false; }
        }

        public string FriendlyCriteriaString
        {
            get { return MakeFilterFriendly(CriteriaString); }
        }

        public PivotGridFieldBase GenderField
        {
            get
            {
                if (!m_IsGenderFieldPresnts)
                {
                    m_IsGenderFieldPresnts = true;
                    m_GenderField = RamPivotGridHelper.GetGenderField(WebFields);
                }
                return m_GenderField;
            }
        }

        public PivotGridFieldBase AgeGroupField
        {
            get
            {
                if (!m_IsAgeGroupFieldPresents)
                {
                    m_IsAgeGroupFieldPresents = true;
                    m_AgeGroupField = RamPivotGridHelper.GetGenderField(WebFields);
                }
                return m_AgeGroupField;
            }
        }

        public PivotGridFieldCollectionBase BaseFields
        {
            get { return Fields; }
        }

        public IDataTransactionStrategy DataTransactionStrategy
        {
            get { return m_DataTransactionStrategy; }
        }

        public RamPivotGridPresenter PivotGridPresenter
        {
            get
            {
                return m_PivotGridPresenter ??
                       (m_PivotGridPresenter = (RamPivotGridPresenter) PresenterFactory.SharedPresenter[this]);
            }
        }

        public CriteriaOperator Criteria
        {
            get { return Prefilter != null ? Prefilter.Criteria : null; }
            set { Prefilter.Criteria = value; }
        }

        public string CriteriaString
        {
            get { return Prefilter != null ? Prefilter.CriteriaString : null; }
            set { Prefilter.CriteriaString = value; }
        }

        //todo: [ivan] modify like in RamPivotGrid.DataSource
        public new DataTable DataSource
        {
            get { return base.DataSource as DataTable; }
            set { base.DataSource = value; }
        }

        //todo: [ivan] modify like in RamPivotGrid.DataSourceWithFields
        public DataTable DataSourceWithFields
        {
            get { return DataSource; }
            set
            {
                DataSource = value;

                using (BeginTransaction())
                {
                    Fields.Clear();

                    DataTable oldTable = DataSource;
                    if (oldTable != null && oldTable != value)
                    {
                        oldTable.Clear();
                        oldTable.Columns.Clear();
                        oldTable.AcceptChanges();
                    }
                    MemoryManager.Flush();

                    base.DataSource = null;
                    if (value == null)
                    {
                        return;
                    }

                    PivotGridPresenter.InitPivotCaptions(value);

                    List<RamPivotGridFieldData> dataFields = RamPivotGridPresenter.CreateDataFields(value);

                    foreach (RamPivotGridFieldData dataField in dataFields)
                    {
                        var field = new PivotGridField
                                        {
                                            ID = dataField.Name,
                                            FieldName = dataField.FieldName,
                                            Caption = dataField.Caption,
                                            Visible = dataField.Visible,
                                            Area = (dataField.IsFilter)
                                                       ? PivotArea.FilterArea
                                                       : PivotArea.RowArea,
                                            AllowedAreas = (dataField.IsFilter)
                                                               ? PivotGridAllowedAreas.FilterArea
                                                               : PivotGridAllowedAreas.All ^ PivotGridAllowedAreas.FilterArea,
                                        };
                        Fields.Add(field);
                    }

                    base.DataSource = value;
                }
                PivotGridPresenter.DistinctCounter = new DistinctCounter(value);
            }
        }

        public LayoutDetailDataSet.AggregateDataTable AggregateTable { get; set; }

        public List<PivotGridFieldBase> DataAreaFields
        {
            get
            {
                return m_DataAreaFields ??
                       (m_DataAreaFields =
                        RamPivotGridHelper.GetFieldCollectionFromArea(BaseFields.Cast<PivotGridFieldBase>(),
                                                                      PivotArea.DataArea));
            }
            set { m_DataAreaFields = value; }
        }

        public List<PivotGridFieldBase> ColumnAreaFields
        {
            get
            {
                return m_ColumnAreaFields ??
                       (m_ColumnAreaFields =
                        RamPivotGridHelper.GetFieldCollectionFromArea(BaseFields.Cast<PivotGridFieldBase>(),
                                                                      PivotArea.ColumnArea));
            }
            set { m_ColumnAreaFields = value; }
        }

        public List<PivotGridFieldBase> RowAreaFields
        {
            get
            {
                return m_RowAreaFields ??
                       (m_RowAreaFields =
                        RamPivotGridHelper.GetFieldCollectionFromArea(BaseFields.Cast<PivotGridFieldBase>(),
                                                                      PivotArea.RowArea));
            }
            set { m_RowAreaFields = value; }
        }

        public Dictionary<string, int> DenominatorIndexes { get; set; }

        public int DataSelectedIndex { get; set; }

        /// <summary>
        ///   get or set dictionary with key corresponding to field name and value - summary type Updates pivot grid fields summary type when set
        /// </summary>
        public Dictionary<string, CustomSummaryType> NameSummaryTypeDictionary
        {
            get { return m_CustomSummaryHandler.NameSummaryTypeDictionary; }
            set
            {
                Utils.CheckNotNull(value, "value");
                m_CustomSummaryHandler.NameSummaryTypeDictionary = value;

                using (BeginTransaction())
                {
                    foreach (PivotGridFieldBase field in BaseFields)
                    {
                        CustomSummaryType summaryTypeType =
                            m_CustomSummaryHandler.NameSummaryTypeDictionary.ContainsKey(field.FieldName)
                                ? m_CustomSummaryHandler.NameSummaryTypeDictionary[field.FieldName]
                                : RamPivotGridHelper.GetFieldSummaryType(field);

                        UpdatePivotFieldSummary(field, summaryTypeType);
                    }
                }
            }
        }

        #endregion

        #region Data Processing

        public IList<CustomMapDataItem> GetSelectedCells(PivotGridFieldBase idFieldBase, PivotGridFieldBase typeFieldBase)
        {
            Utils.CheckNotNull(idFieldBase, "idFieldBase");

            PivotCellBaseEventArgsWrapper.GetCellInfoDelegate getCellInfo =
                (column, row) => new PivotCellBaseEventArgsWrapper(GetCellInfo(column, row));
            int bottom = Math.Min(OptionsPager.RowsPerPage, RowCount - OptionsPager.PageIndex * OptionsPager.RowsPerPage);
            var selection = new Rectangle(DataSelectedIndex, 0, 1, bottom);
            

            return PivotCellBaseEventArgsWrapper.GetSelectedCells(idFieldBase, typeFieldBase, getCellInfo, selection);
        }

        public UnitField GetIdUnitFieldName(string unitFieldName)
        {
            Utils.CheckNotNullOrEmpty(unitFieldName, "unitFieldName");

            if (m_UnitDictionary.ContainsKey(unitFieldName))
            {
                return m_UnitDictionary[unitFieldName];
            }

            string unitFullFieldName = null;
            string dateFullFieldName = null;

            PivotGridFieldBase field = BaseFields[unitFieldName];
            if (field != null)
            {
                string filter = string.Format("idfLayoutSearchField ='{0}'", ((WebPivotGridField) field).Id);
                if (AggregateTable == null)
                {
                    throw new RamException("AggregateTable is not initialized");
                }

                DataRow[] selectedRows = AggregateTable.Select(filter);
                if (selectedRows.Length > 0)
                {
                    var selectedRow = (LayoutDetailDataSet.AggregateRow) selectedRows[0];

                    unitFullFieldName = (!selectedRow.IsidfUnitQuerySearchFieldNull())
                                            ? RamPivotGridHelper.CreateFieldName(selectedRow.UnitSearchFieldAlias,
                                                                                 selectedRow.idfUnitQuerySearchField)
                                            : null;
                    dateFullFieldName = (!selectedRow.IsidfDateQuerySearchFieldNull())
                                            ? RamPivotGridHelper.CreateFieldName(selectedRow.DateSearchFieldAlias,
                                                                                 selectedRow.idfDateQuerySearchField)
                                            : null;
                }
            }
            var unitField = new UnitField(unitFullFieldName, dateFullFieldName);

            m_UnitDictionary.Add(unitFieldName, unitField);
            return unitField;
        }

        internal void UpdatePivotFieldSummary(PivotGridFieldBase field, CustomSummaryType customType)
        {
            Utils.CheckNotNull(field, "field");
            if (!NameSummaryTypeDictionary.ContainsKey(field.FieldName))
            {
                NameSummaryTypeDictionary.Add(field.FieldName, customType);
            }
            else
            {
                NameSummaryTypeDictionary[field.FieldName] = customType;
            }

            PivotSummaryType summaryType = customType == CustomSummaryType.Count
                                               ? PivotSummaryType.Count
                                               : PivotSummaryType.Custom;

            RefreshData();
            field.SummaryType = summaryType;
        }

        public IDisposable BeginTransaction()
        {
            return DataTransactionStrategy.BeginTransaction(Data);
        }

        public void CreateWebPivotGridFrom(RamPivotGrid sourceGrid)
        {
            Utils.CheckNotNull(sourceGrid, "sourceGrid");

            using (BeginTransaction())
            {
                DataSource = null;
                Fields.ClearAndDispose();

                var winFieldList = new List<WinPivotGridField>();
                try
                {
                    // datasource of report is set equal to datasource of pivot while copy properties
                    var ignoreProperties = new List<string>
                                               {
                                                   "DataSource",
                                                   "Fields",
                                                   "DataSourceWithFields",
                                                   "NameSummaryTypeDictionary"
                                               };
                    ReflectionHelper.CopyCommonProperties(sourceGrid, this, ignoreProperties);

                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsView, OptionsView);
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsData, OptionsData);
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsDataField, OptionsDataField);
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsLayout, OptionsLayout);

                    foreach (WinPivotGridField field in sourceGrid.Fields)
                    {
                        winFieldList.Add(field);
                        var webField = new WebPivotGridField();
                        ReflectionHelper.CopyCommonProperties(field, webField);
                        Fields.Add(webField);
                    }
                }
                catch (Exception ex)
                {
                    throw new RamException("Cannot import source from sourceGrid to report", ex);
                }

                winFieldList.Sort((x, y) => Comparer<int>.Default.Compare(x.AreaIndex, y.AreaIndex));
                foreach (WinPivotGridField field in winFieldList)
                {
                    PivotGridFieldBase webField = Fields[field.FieldName];
                    webField.AreaIndex = field.AreaIndex;
                }
                OptionsView.ShowFilterHeaders = false;
            }
        }

        private string MakeFilterFriendly(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return string.Empty;
            }

            foreach (PivotGridFieldBase field in Fields)
            {
                filter = filter.Replace(field.Name, field.Caption);
            }
            return filter;
        }

        #endregion

        #region Handlers

        public void OnSendCommand(CommandEventArgs e)
        {
            EventHandler<CommandEventArgs> handler = SendCommand;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void RaiseFieldVisibleChangedEvent(bool visible)
        {
            PivotFieldVisibleChangedEventHandler eventHandler = FieldVisibleChanged;
            if (eventHandler != null)
            {
                eventHandler(new LayoutFieldVisibleChanged(visible));
            }
        }

        private void OnCustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            m_CustomSummaryHandler.OnCustomSummary(sender, new PivotGridCustomSummaryEventArgsWrapper(e));
        }

        public static Dictionary<string, int> GetIndexesDictionary
            (LayoutDetailDataSet.AggregateDataTable aggregateTable, PivotGridFieldCollectionBase fields)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (LayoutDetailDataSet.AggregateRow row in aggregateTable.Rows)
            {
                if (row.IsidfDenominatorQuerySearchFieldNull())
                {
                    continue;
                }

                string fieldName = RamPivotGridHelper.CreateFieldName(row.SearchFieldAlias, row.idfLayoutSearchField);
                string denominatorFieldName = RamPivotGridHelper.CreateFieldName(row.DenominatorSearchFieldAlias,
                                                                                 row.idfDenominatorQuerySearchField);
                PivotGridFieldBase denominatorField = fields[denominatorFieldName];

                if ((denominatorField != null) && denominatorField.Visible &&
                    (denominatorField.Area == PivotArea.DataArea))
                {
                    dictionary.Add(fieldName, denominatorField.AreaIndex);
                }
            }
            return dictionary;
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
            m_DisplayTextHandler.DisplayProportionText(new PivotCellDisplayTextEventArgsWrapper(e), denominatorIndex,
                                                       summaryType);
        }

        internal void OnFieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            m_DisplayTextHandler.DisplayAsterisk(new PivotFieldDisplayTextEventArgsWrapper(e));
            if (e.DataField == null)
            {
                return;
            }

            var summaryTypes = new List<CustomSummaryType>();
            foreach (PivotGridFieldBase field in DataAreaFields)
            {
                CustomSummaryType summaryType;
                m_CustomSummaryHandler.NameSummaryTypeDictionary.TryGetValue(field.FieldName, out summaryType);
                summaryTypes.Add(summaryType);
            }

            m_DisplayTextHandler.DisplayStatisticsTotalCaption(new PivotFieldDisplayTextEventArgsWrapper(e),
                                                               summaryTypes);
        }

        #endregion
    }
}