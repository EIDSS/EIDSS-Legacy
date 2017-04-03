using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Access;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Enums;
using bv.common.Objects;
using bv.common.Resources;
using bv.common.db;
using bv.common.db.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Resources;
using ErrorForm = bv.common.win.ErrorForm;
using Localizer = bv.common.Core.Localizer;
using ReflectionHelper = EIDSS.RAM_DB.Common.ReflectionHelper;

namespace EIDSS.RAM.Presenters
{
    public sealed class PivotPresenter : RelatedObjectPresenter
    {
        public const string ColumnIdName = "id";
        public const string ColumnLongitudeName = "x";
        public const string ColumnLatitudeName = "y";
        public const string ColumnTypeName = "type";
        public const string ColumnValueName = "value";
        public const string ColumnInfoName = "info";

        private readonly IPivotView m_PivotView;

        private readonly BaseRamDbService m_PivotFormService;
        private readonly LayoutMediator m_LayoutMediator;

        static PivotPresenter()
        {
            InitGisTypes();
        }

        public PivotPresenter(SharedPresenter sharedPresenter, IPivotView view)
            : base(sharedPresenter, view)
        {
            m_PivotFormService = new BaseRamDbService();

            m_PivotView = view;
            m_PivotView.DBService = PivotFormService;
            m_LayoutMediator = new LayoutMediator(this);

            m_PivotView.PivotSelected += PivotView_PivotSelected;
            m_PivotView.PivotDataLoaded += PivotView_PivotDataLoaded;
            m_PivotView.InitAdmUnit += PivotView_InitAdmUnit;
            m_PivotView.InitDenominator += PivotView_InitDenominator;
            m_PivotView.InitStatDate += PivotView_InitStatDate;

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
            m_SharedPresenter.SharedModel.GetMapDataTableCallback = GetWinMapDataTable;
            m_SharedPresenter.SharedModel.GetAvailableMapFieldViewCallback = GetAvailableMapFieldView;
            m_SharedPresenter.SharedModel.GetDenominatorDataViewCallback = GetDenominatorDataView;
            m_SharedPresenter.SharedModel.GetStatDateDataViewCallback = GetStatDateDataView;
        }

        public static Dictionary<string, GisCaseType> GisTypeDictionary 
        { get; private set; }

        public BaseRamDbService PivotFormService
        {
            get { return m_PivotFormService; }
        }

        public string CorrectedLayoutName
        {
            get
            {
                return (Utils.IsEmpty(LayoutName))
                           ? EidssMessages.Get("msgNoReportHeader", "[Untitled]")
                           : LayoutName;
            }
        }

        public string LayoutName
        {
            get
            {
                return (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                           ? m_LayoutMediator.LayoutRow.strDefaultLayoutName
                           : m_LayoutMediator.LayoutRow.strLayoutName;
            }
        }

        public string PivotName
        {
            get { return m_LayoutMediator.LayoutRow.strPivotName; }
            set
            {
                SharedPresenter.SharedModel.PivotName = value;
                m_LayoutMediator.LayoutRow.strPivotName = value;
            }
        }

        public string ChartName
        {
            get { return m_LayoutMediator.LayoutRow.strChartName; }
            set
            {
                SharedPresenter.SharedModel.ChartName = value;
                m_LayoutMediator.LayoutRow.strChartName = value;
            }
        }

        public string MapName
        {
            get { return m_LayoutMediator.LayoutRow.strMapName; }
            set
            {
                SharedPresenter.SharedModel.MapName = value;
                m_LayoutMediator.LayoutRow.strMapName = value;
            }
        }

        public long LayoutId
        {
            get { return m_LayoutMediator.LayoutRow.idflLayout; }
        }

        public long QueryId
        {
            get { return m_LayoutMediator.LayoutRow.idflQuery; }
        }

        public bool ApplyFilter
        {
            get
            {
                if (m_LayoutMediator.LayoutRow.IsblnApplyFilterNull())
                {
                    return false;
                }
                return m_LayoutMediator.LayoutRow.blnApplyFilter;
            }
        }

        public LayoutDetailDataSet.AggregateDataTable AggregateTable
        {
            get { return m_LayoutMediator.LayoutDataSet.Aggregate; }
        }

        public string LayoutXml
        {
            get
            {
                string basicXml = m_LayoutMediator.LayoutRow.IsstrBasicXmlNull()
                                      ? String.Empty
                                      : m_LayoutMediator.LayoutRow.strBasicXml;

                return basicXml;
            }
            set { m_LayoutMediator.LayoutRow.strBasicXml = value; }
        }

        public bool ReadOnly
        {
            get { return m_LayoutMediator.LayoutRow.blnReadOnly; }
        }

        public bool CopyPivotName { get; set; }

        public bool CopyMapName { get; set; }

        public bool CopyChartName { get; set; }

        #region Binding

        public void BindShareLayout(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                                        m_LayoutMediator.LayoutDataSet,
                                        m_LayoutMediator.LayoutTable.TableName,
                                        m_LayoutMediator.LayoutTable.blnShareLayoutColumn.ColumnName);
        }

        public void BindApplyFilter(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                                        m_LayoutMediator.LayoutDataSet,
                                        m_LayoutMediator.LayoutTable.TableName,
                                        m_LayoutMediator.LayoutTable.blnApplyFilterColumn.ColumnName);
        }

        public void BindDefaultLayoutName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                                     m_LayoutMediator.LayoutDataSet,
                                     m_LayoutMediator.LayoutTable.TableName,
                                     m_LayoutMediator.LayoutTable.strDefaultLayoutNameColumn.ColumnName);
        }

        public void BindLayoutName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                                     m_LayoutMediator.LayoutDataSet,
                                     m_LayoutMediator.LayoutTable.TableName,
                                     m_LayoutMediator.LayoutTable.strLayoutNameColumn.ColumnName);
        }

        public void BindDescription(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                                     m_LayoutMediator.LayoutDataSet,
                                     m_LayoutMediator.LayoutTable.TableName,
                                     m_LayoutMediator.LayoutTable.strDescriptionColumn.ColumnName);
        }

        internal void BindGroupInterval(LookUpEdit comboBox)
        {
            BindingHelper.BindCombobox(comboBox,
                                       m_LayoutMediator.LayoutDataSet,
                                       m_LayoutMediator.LayoutTable.TableName,
                                       m_LayoutMediator.LayoutTable.idfsGroupIntervalColumn.ColumnName,
                                       BaseReferenceType.rftGroupInterval,
                                       (long) DBGroupInterval.gitDate);
        }

        public void BindShowTotalCols(CheckedComboBoxEdit edit)
        {
            edit.Properties.Items[0].CheckState = GetCheckState(m_LayoutMediator.LayoutRow.blnShowColsTotals);
            edit.Properties.Items[1].CheckState = GetCheckState(m_LayoutMediator.LayoutRow.blnShowRowsTotals);
            edit.Properties.Items[2].CheckState = GetCheckState(m_LayoutMediator.LayoutRow.blnShowColGrandTotals);
            edit.Properties.Items[3].CheckState = GetCheckState(m_LayoutMediator.LayoutRow.blnShowRowGrandTotals);
            edit.Properties.Items[4].CheckState = GetCheckState(m_LayoutMediator.LayoutRow.blnShowForSingleTotals);

            edit.RefreshEditValue();
            edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (Utils.IsEmpty(edit.EditValue))
            {
                edit.EditValue = DBNull.Value;
            }
        }

        public void BindBackShowTotalCols(CheckedComboBoxEdit edit, PivotGridOptionsView optionsView, bool isCompact)
        {
            if (isCompact)
            {
                optionsView.ShowRowTotals = true;
                optionsView.ShowTotalsForSingleValues = true;
//                optionsView.ShowColumnTotals = true;
//                optionsView.ShowColumnGrandTotals = true;
//                optionsView.ShowRowGrandTotals = true;
//                optionsView.ShowGrandTotalsForSingleValues = true;
                optionsView.RowTotalsLocation = PivotRowTotalsLocation.Tree;
            }
            else
            {
                optionsView.RowTotalsLocation = PivotRowTotalsLocation.Far;

                m_LayoutMediator.LayoutRow.blnShowColsTotals = IsChecked(edit, 0);
                m_LayoutMediator.LayoutRow.blnShowRowsTotals = IsChecked(edit, 1);
                m_LayoutMediator.LayoutRow.blnShowColGrandTotals = IsChecked(edit, 2);
                m_LayoutMediator.LayoutRow.blnShowRowGrandTotals = IsChecked(edit, 3);
                m_LayoutMediator.LayoutRow.blnShowForSingleTotals = IsChecked(edit, 4);

                optionsView.ShowColumnTotals = m_LayoutMediator.LayoutRow.blnShowColsTotals;
                optionsView.ShowRowTotals = m_LayoutMediator.LayoutRow.blnShowRowsTotals;
                optionsView.ShowColumnGrandTotals = m_LayoutMediator.LayoutRow.blnShowColGrandTotals;
                optionsView.ShowRowGrandTotals = m_LayoutMediator.LayoutRow.blnShowRowGrandTotals;
                optionsView.ShowTotalsForSingleValues = m_LayoutMediator.LayoutRow.blnShowForSingleTotals;
                optionsView.ShowGrandTotalsForSingleValues = m_LayoutMediator.LayoutRow.blnShowForSingleTotals;
            }
        }

        private static CheckState GetCheckState(bool flag)
        {
            return flag
                       ? CheckState.Checked
                       : CheckState.Unchecked;
        }

        private static bool IsChecked(CheckedComboBoxEdit edit, int index)
        {
            if (index >= edit.Properties.Items.Count || index < 0)
            {
                throw new ArgumentException("Index out of range");
            }

            return edit.Properties.Items[index].CheckState == CheckState.Checked;
        }

        #endregion

        /// <summary>
        ///   It's workaround method. don't use it
        /// </summary>
        /// <param name="layoutName"> </param>
        public void SetLayoutName(string layoutName)
        {
            m_LayoutMediator.LayoutRow.strLayoutName = layoutName;
        }

        /// <summary>
        ///   It's workaround method. don't use it
        /// </summary>
        /// <param name="layoutName"> </param>
        public void SetDefaultLayoutName(string layoutName)
        {
            m_LayoutMediator.LayoutRow.strDefaultLayoutName = layoutName;
        }

        public void SetFilterText(string text)
        {
            SharedPresenter.SharedModel.FilterText = ApplyFilter ? text : String.Empty;
        }

        public void CopyLayoutNameIfNeeded()
        {
            if (!IsNewObject)
            {
                return;
            }

            if (CopyPivotName)
            {
                PivotName = LayoutName;
            }
            if (CopyChartName)
            {
                ChartName = LayoutName;
            }
            if (CopyMapName)
            {
                MapName = LayoutName;
            }
        }

        private void PivotView_InitAdmUnit(object sender, ComboBoxEventArgs e)
        {
            m_SharedPresenter.BindAdmUnitComboBox(e);
        }

        private void PivotView_InitDenominator(object sender, ComboBoxEventArgs e)
        {
            m_SharedPresenter.BindDenominatorComboBox(e);
        }

        private void PivotView_InitStatDate(object sender, ComboBoxEventArgs e)
        {
            m_SharedPresenter.BindStatDateComboBox(e);
        }

        /// <summary>
        ///   Returns layout name with prefix "Copy of" on corresponding language
        /// </summary>
        /// <param name="layoutName"> </param>
        /// <param name="columnName"> </param>
        /// <param name="lngName"> </param>
        /// <returns> </returns>
        public string GetValueWithPrefix(string layoutName, string columnName, string lngName)
        {
            Utils.CheckNotNullOrEmpty(columnName, "columnName");
            Utils.CheckNotNullOrEmpty(lngName, "lngName");

            string result = layoutName;
            for (int index = 0; index < Int32.MaxValue; index++)
            {
                string strIndex = index > 0 ? String.Format(" ({0})", index) : String.Empty;
                string prefix = EidssMessages.Get("msgCopyPrefix", "Copy{0} of", lngName);
                prefix = String.Format(Utils.Str(prefix).Trim(), strIndex);
                string format = EidssMessages.Get("msgCopyFormat", "{0} {1}", lngName);
                result = String.Format(format, prefix, Utils.Str(layoutName));

                if (!IsLayoutExists(result, columnName))
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        ///   Defines is layout with name stored in column "columnName" equals value "layoutName" exists
        /// </summary>
        /// <param name="layoutName"> </param>
        /// <param name="columnName"> </param>
        /// <returns> </returns>
        private bool IsLayoutExists(string layoutName, string columnName)
        {
            Utils.CheckNotNull(layoutName, "layoutName");
            Utils.CheckNotNullOrEmpty(columnName, "columnName");

            LookupTableInfo info = LookupCache.LookupTables[LookupTables.Layout.ToString()];
            DataTable dtLayout = LookupCache.Fill(info);
            string filter = String.Format("idflQuery={0} and {1} = '{2}'", PivotFormService.QueryID, columnName,
                                          layoutName.Replace("'", "''"));
            DataRow[] dr = dtLayout.Select(filter);

            bool isExists = (dr.Length > 1) ||
                            (IsNewObject && dr.Length > 0) ||
                            ((dr.Length == 1) && (Utils.Str(dr[0]["idflLayout"]) != Utils.Str(m_LayoutMediator.LayoutRow.idflLayout)));
            return isExists;
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.SelectedQueryId:
                    long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
                    PivotFormService.QueryID = queryId;
                    break;
                case SharedProperty.ChartDataVertical:
                    bool vertical = m_SharedPresenter.SharedModel.ChartDataVertical;
                    m_PivotView.OnChangeOrientation(new ChartChangeOrientationEventArgs(vertical));
                    break;
            }
        }

        public Dictionary<string, CustomSummaryType> GetNameSummaryTypeDictionary()
        {
            return GetNameSummaryTypeDictionary(AggregateTable);
        }

        public static Dictionary<string, CustomSummaryType> GetNameSummaryTypeDictionary
            (LayoutDetailDataSet.AggregateDataTable aggregateTable)
        {
            var dictionary = new Dictionary<string, CustomSummaryType>();
            foreach (LayoutDetailDataSet.AggregateRow row in aggregateTable.Rows)
            {
                string key = RamPivotGridHelper.CreateFieldName(row.SearchFieldAlias, row.idfLayoutSearchField);
                if (!dictionary.ContainsKey(key))
                {
                    CustomSummaryType value = ParseSummaryType(row.idfsAggregateFunction);
                    dictionary.Add(key, value);
                }
            }
            return dictionary;
        }

        public Dictionary<string, int> GetIndexesDictionary()
        {
            return GetIndexesDictionary(AggregateTable, m_PivotView.BaseFields);
        }

        public static Dictionary<string, int> GetIndexesDictionary
            (LayoutDetailDataSet.AggregateDataTable aggregateTable, PivotGridFieldCollectionBase fields)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (LayoutDetailDataSet.AggregateRow row in aggregateTable.Rows)
            {
                if (row.IsidfDenominatorQuerySearchFieldNull() || row.IsDenominatorSearchFieldAliasNull())
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

        public override void Process(Command cmd)
        {
            try
            {
                if (cmd is LayoutCommand)
                {
                    ProcessLayout((LayoutCommand) cmd);
                }
                else if (cmd is ExportCommand)
                {
                    ProcessExport(cmd as ExportCommand);
                }
                else if (cmd is ChangeFieldCaptionCommand)
                {
                    ProcessChangeFieldCaption(cmd as ChangeFieldCaptionCommand);
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

        private void ProcessExport(ExportCommand exportCommand)
        {
            if (exportCommand.ExportObject != ExportObject.Access)
            {
                return;
            }
            exportCommand.State = CommandState.Pending;
            var dialog = new OpenFileDialog
                             {
                                 DefaultExt = "mdb",
                                 Filter = EidssMessages.Get("msgFilterAccess", "MS Access database|*.mdb"),
                                 CheckFileExists = false
                             };

            if (dialog.ShowDialog(m_PivotView.ParentForm) == DialogResult.OK)
            {
                DataTable dataTable = m_PivotView.FilteredDataSource;
                var adapter = new AccessDataAdapter(dialog.FileName);
                bool needExport = true;
                if (adapter.IsTableExistInAccess(dataTable.TableName))
                {
                    string caption = EidssMessages.Get("msgMessage");
                    string formatMsg = EidssMessages.Get("msgOverwriteAccessTable");
                    string msg = String.Format(formatMsg, adapter.DbFileName, dataTable.TableName);

                    needExport = AskQuestion(msg, caption);
                }
                if (needExport)
                {
                    adapter.ExportTableToAccess(dataTable);
                }
            }
            exportCommand.State = CommandState.Processed;
        }

        private void ProcessLayout(LayoutCommand layoutCommand)
        {
            if (layoutCommand.Operation == LayoutOperation.Filter)
            {
                layoutCommand.State = CommandState.Pending;
                m_PivotView.ShowFilterForm();
                layoutCommand.State = CommandState.Processed;
                m_PivotView.RaiseDataLoadedEvent();
            }
        }

        private void ProcessChangeFieldCaption(ChangeFieldCaptionCommand command)
        {
            if (command == null || String.IsNullOrEmpty(command.FieldName))
            {
                return;
            }
            command.State = CommandState.Pending;

            WinPivotGridField field = m_PivotView.GetField(command.FieldName);
            if (field == null)
            {
                throw new RamException(String.Format("Could not find field {0} in the PivotGrid", command.FieldName));
            }

            LayoutDetailDataSet.AggregateRow row = GetAggregateRowByField(field);
            using (var form = new FieldCaptionForm(row.strOriginalFieldENCaption, row.strOriginalFieldCaption,
                                                   row.strNewFieldENCaption, row.strNewFieldCaption))
            {
                if (form.ShowDialog(m_PivotView.ParentForm) == DialogResult.OK)
                {
                    row.strNewFieldENCaption = form.NewEnglishCaption;
                    row.strNewFieldCaption = ModelUserContext.CurrentLanguage == Localizer.lngEn
                                                 ? form.NewEnglishCaption
                                                 : form.NewNationalCaption;

                    field.Caption = row.strNewFieldCaption;
                    m_PivotView.InitFilterControlHelperAndRefreshFilter();
                }
            }

            command.State = CommandState.Processed;
        }

        private void PivotView_PivotSelected(object sender, PivotSelectionEventArgs e)
        {
            m_SharedPresenter.SharedModel.ControlsView = e;
        }

        private void PivotView_PivotDataLoaded(object sender, PivotDataEventArgs e)
        {
            m_SharedPresenter.SharedModel.PivotData = e;
        }

        internal bool ValidateLayoutName()
        {
            if (IsLayoutExists(m_LayoutMediator.LayoutRow.strDefaultLayoutName, "strDefaultLayoutName"))
            {
                MessageForm.Show(EidssMessages.Get("msgNoUniqueLayoutName",
                                                   "Layout with that name already exists. Please modify it."));
                return false;
            }

            if ((ModelUserContext.CurrentLanguage != Localizer.lngEn) &&
                (IsLayoutExists(m_LayoutMediator.LayoutRow.strLayoutName, "strLayoutName")))
            {
                MessageForm.Show(EidssMessages.Get("msgNoUniqueNatLayoutName",
                                                   "Layout with that national name already exists. Please modify it."));
                return false;
            }
            return true;
        }

        internal PivotSelectionEventArgs DefineMapChartPageEnabled(Rectangle selection)
        {
            bool mapPageEnabled = false;
            bool chartPageEnabled = (selection.Width > 0) || (selection.Height > 0);

            bool isColumnSelected = (selection.Width == 1) && (selection.Height > 0);
            bool isCellSelected = (selection.Width == 0) && (selection.Height == 0);
            if (isColumnSelected || isCellSelected)
            {
                DataView dvMapFieldList = GetMapFiledView(PivotFormService.QueryID, true);
                foreach (DataRowView r in dvMapFieldList)
                {
                    if (GetFieldsInRow(Utils.Str(r["FieldAlias"])).Count > 0)
                    {
                        mapPageEnabled = true;
                        break;
                    }
                }
            }

            return new PivotSelectionEventArgs(chartPageEnabled, mapPageEnabled);
        }

        public static DataTable GetMapDataTable()
        {
            //string tableName = m_PivotView.CorrectedLayoutName;
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new[]
                                           {
                                               new DataColumn(ColumnIdName, typeof (long)),
                                               new DataColumn(ColumnLongitudeName, typeof (double)),
                                               new DataColumn(ColumnLatitudeName, typeof (double)),
                                               new DataColumn(ColumnTypeName, typeof (int)),
                                               new DataColumn(ColumnValueName, typeof (double)),
                                               new DataColumn(ColumnInfoName, typeof (string))
                                           });

            return dataTable;
        }

        public DataTable GetWinMapDataTable(string fieldName, out bool isSingle)
        {
            var idField = (PivotGridField) GetMapIdField(m_PivotView.BaseFields, fieldName);
            var typeField = (PivotGridField) RamPivotGridHelper.GetEventTypeField(m_PivotView.BaseFields.Cast<PivotGridFieldBase>());

            isSingle = (typeField == null);

            IList<CustomMapDataItem> mapData = m_PivotView.GetSelectedCells(idField, typeField);

            DataTable mapDataTable = ConvertMapDataForGis(mapData);
            mapDataTable.TableName = m_PivotView.CorrectedLayoutName;
            return mapDataTable;
        }

        public static DataTable GetWebMapDataTable(IRamPivotGridView pivotGrid, string fieldName, out bool isSingle)
        {
            PivotGridFieldBase idField = GetMapIdField(pivotGrid.BaseFields, fieldName);
            PivotGridFieldBase typeField = RamPivotGridHelper.GetEventTypeField(pivotGrid.BaseFields.Cast<PivotGridFieldBase>());

            isSingle = (typeField == null);

            IList<CustomMapDataItem> mapData = pivotGrid.GetSelectedCells(idField, typeField);

            DataTable mapDataTable = ConvertMapDataForGis(mapData);
            return mapDataTable;
        }

        private static PivotGridFieldBase GetMapIdField(PivotGridFieldCollectionBase fields, string fieldName)
        {
            Utils.CheckNotNullOrEmpty(fieldName, "fieldName");
            Utils.CheckNotNull(fields, "fields");

            List<PivotGridFieldBase> list = fields.Cast<PivotGridFieldBase>().ToList();
            PivotGridFieldBase idField = list.Find(field => (field.Visible) &&
                                                            (field.AreaIndex >= 0) &&
                                                            (field.Area == PivotArea.RowArea) &&
                                                            (field.FieldName == fieldName));

            if (idField == null)
            {
                throw new RamException(
                    String.Format("Invalid map field name {0}", fieldName));
            }
            return idField;
        }

        public static DataTable ConvertMapDataForGis(IList<CustomMapDataItem> mapData)
        {
            DataView gisView = LookupCache.Get(LookupTables.AVRGIS);
            gisView.Sort = "ExtendedName";

            // creating table for map
            DataTable dataTable = GetMapDataTable();

            // filling table for map
            dataTable.BeginLoadData();

            foreach (CustomMapDataItem item in mapData)
            {
                DataRowView[] foundRows = gisView.FindRows(item.GisReferenceName);

                if (foundRows.Length > 0)
                {
                    DataRow row = dataTable.NewRow();
                    row[ColumnIdName] = foundRows[0]["idfsReference"];
                    row[ColumnLongitudeName] = foundRows[0]["dblLongitude"];
                    row[ColumnLatitudeName] = foundRows[0]["dblLatitude"];
                    row[ColumnTypeName] = item.GisCaseType;
                    row[ColumnValueName] = item.Value;
                    row[ColumnInfoName] = item.TotalCaption;
                    dataTable.Rows.Add(row);
                }
                else
                {
                    Match match = Regex.Match(item.GisReferenceName, @"\((?<Latitude>-?\d+.\d+)\D+(?<Longitude>-?\d+.\d+)\)");
                    Group latitudeGroup = match.Groups["Latitude"];
                    Group longitudeGroup = match.Groups["Longitude"];
                    if ((latitudeGroup.Captures.Count > 0) && (longitudeGroup.Captures.Count > 0))
                    {
                        float latitude;
                        float longitude;
                        if (
                            Single.TryParse(latitudeGroup.Captures[0].Value, NumberStyles.Float,
                                            CultureInfo.InvariantCulture, out latitude) &&
                            Single.TryParse(longitudeGroup.Captures[0].Value, NumberStyles.Float,
                                            CultureInfo.InvariantCulture, out longitude))
                        {
                            DataRow row = dataTable.NewRow();

                            row[ColumnLongitudeName] = longitude;
                            row[ColumnLatitudeName] = latitude;
                            row[ColumnValueName] = item.Value;
                            row[ColumnTypeName] = item.GisCaseType;
                            row[ColumnInfoName] = item.TotalCaption;
                            dataTable.Rows.Add(row);
                        }
                    }
                }
            }

            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return dataTable;
        }

        internal DataView GetStatDateDataView()
        {
            DataTable dataTable = GetListDataTable("DateFieldList");
            dataTable.BeginLoadData();

            foreach (WinPivotGridField field in m_PivotView.WinFields)
            {
                if (field.Visible &&
                    field.Area == PivotArea.ColumnArea &&
                    field.FieldDataType == typeof (DateTime))
                {
                    DataRow dr = dataTable.NewRow();
                    dr["Alias"] = field.FieldName;
                    dr["Caption"] = field.Caption;
                    dataTable.Rows.Add(dr);
                }
            }
            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", "Caption, Alias", DataViewRowState.CurrentRows);
        }

        internal DataView GetDenominatorDataView()
        {
            DataTable dataTable = GetListDataTable("DenominatorList");
            dataTable.BeginLoadData();

            foreach (WinPivotGridField field in m_PivotView.WinFields)
            {
                if (field.Visible &&
                    field.Area == PivotArea.DataArea &&
                    field.OriginalName != m_PivotView.SelectedRow.SearchFieldAlias)
                {
                    DataRow dr = dataTable.NewRow();

                    dr["Alias"] = field.FieldName;
                    dr["Caption"] = field.Caption;
                    dataTable.Rows.Add(dr);
                }
            }
            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", "Caption, Alias", DataViewRowState.CurrentRows);
        }

        private static DataTable GetListDataTable(string tableName)
        {
            var dataTable = new DataTable(tableName);
            var colAlias = new DataColumn("Alias", typeof (string));
            dataTable.Columns.Add(colAlias);
            var colCaption = new DataColumn("Caption", typeof (string));
            dataTable.Columns.Add(colCaption);
            dataTable.PrimaryKey = new[] {colAlias};
            return dataTable;
        }

        internal DataView GetAvailableMapFieldView(bool isMap)
        {
            DataView dvMapFieldList = GetMapFiledView(PivotFormService.QueryID, isMap);

            DataTable dataTable = GetListDataTable("AdmUnitList");
            var colOrder = new DataColumn("Order", typeof (int));
            dataTable.Columns.Add(colOrder);

            dataTable.BeginLoadData();
            foreach (DataRowView r in dvMapFieldList)
            {
                List<WinPivotGridField> fields = GetFieldsInRow(Utils.Str(r["FieldAlias"]));
                foreach (WinPivotGridField field in fields)
                {
                    DataRow dr = dataTable.NewRow();
                    dr["Alias"] = field.FieldName;
                    dr["Caption"] = field.Caption;
                    dr["Order"] = isMap ? r["intMapDisplayOrder"] : r["intIncidenceDisplayOrder"];
                    dataTable.Rows.Add(dr);
                }
            }
            if (!isMap)
            {
                DataRow countryRow = dataTable.NewRow();
                countryRow["Alias"] = SharedPresenter.VirtualCountryFieldName;
                countryRow["Caption"] = EidssMessages.Get("strCountry", "Country");
                countryRow["Order"] = -1;
                dataTable.Rows.Add(countryRow);
            }

            dataTable.EndLoadData();
            dataTable.AcceptChanges();
            return new DataView(dataTable, "", "Order, Caption, Alias", DataViewRowState.CurrentRows);
        }

        public static DataView GetMapFiledView(long queryId, bool isMap)
        {
            string key = LookupTables.QuerySearchField.ToString();
            DataTable dtMapFieldList = LookupCache.Fill(LookupCache.LookupTables[key]);

            string field = isMap ? "intMapDisplayOrder" : "intIncidenceDisplayOrder";
            string filter = String.Format("idflQuery = {0} and {1} is not null", queryId, field);
            string sort = String.Format("{0}, FieldCaption", field);
            var dvMapFieldList = new DataView(dtMapFieldList, filter, sort, DataViewRowState.CurrentRows);
            return dvMapFieldList;
        }

        #region Prepare Data Source For Pivot Grid 

        public DataTable GetPreparedDataSource()
        {
            if (m_SharedPresenter.IsQueryResultNull)
            {
                return null;
            }

            if (!m_SharedPresenter.SharedModel.PivotAccessible)
            {
                return m_SharedPresenter.GetQueryResultClone();
            }

            DataTable newDataSource = m_SharedPresenter.GetQueryResultCopy();


            FillAggregateForNewFields(newDataSource, IsNewObject);

            DeleteColumnsMissingInAggregateTable(AggregateTable, newDataSource, IsNewObject);

            CreateCopiedColumnsAndAjustColumnNames(AggregateTable, newDataSource);

            return newDataSource;
        }

        public static DataTable GetWebPreparedDataSource
            (LayoutDetailDataSet.AggregateDataTable aggregateTable, DataTable queryResult)
        {
            if (queryResult == null)
            {
                return null;
            }

            DataTable newDataSource = queryResult.Copy();

            DeleteColumnsMissingInAggregateTable(aggregateTable, newDataSource, false);

            CreateCopiedColumnsAndAjustColumnNames(aggregateTable, newDataSource);

            return newDataSource;
        }

        /// <summary>
        ///   method generates AggregateRow for each column in the Data Source that hasn't aggregate information
        /// </summary>
        /// <param name="newDataSource"> </param>
        /// <param name="isNewObject"> </param>
        private void FillAggregateForNewFields(DataTable newDataSource, bool isNewObject)
        {
            List<LayoutDetailDataSet.AggregateRow> aggregateRows =
                AggregateTable.Rows.Cast<LayoutDetailDataSet.AggregateRow>().OrderBy(row=>row.idfLayoutSearchField).ToList();

            // If AggregateTable doesn't contain row with Search Field that corresponds to one of QueryResult column, 
            // we should create corresponding aggregate row

            List<long> idList = null;
            if (isNewObject)
            {
                idList = BaseDbService.NewListIntID(newDataSource.Columns.Count);
            }

            int count = 0;
            foreach (DataColumn column in newDataSource.Columns)
            {

                string columnName = column.ColumnName;
                // process original fields, not copied fields in filter
                // we think than each column has a copy 
                if (RamPivotGridHelper.GetIsCopyForFilter(columnName))
                    continue;

                var foundRows = aggregateRows.FindAll(row => (row.SearchFieldAlias == columnName));
                if (foundRows.Count < 2)
                {
                    CustomSummaryType summaryType = (foundRows.Count == 0)
                                                        ? Configuration.GetSummaryTypeFor(columnName, column.DataType)
                                                        : (CustomSummaryType) foundRows[0].idfsAggregateFunction;

                    var copyColumnName = columnName + RamPivotGridHelper.CopySuffix;
                    if (isNewObject && idList != null)
                    {
                        if (foundRows.Count == 0)
                        {
                            AddNewAggregateRow(columnName, (long)summaryType, idList[count]);
                            count++;
                        }
                        AddNewAggregateRow(copyColumnName, (long)summaryType, idList[count]);
                        count++;
                    }
                    else
                    {
                        if (foundRows.Count == 0)
                        {
                            AddNewAggregateRow(columnName, (long)summaryType);
                        }
                        AddNewAggregateRow(copyColumnName, (long)summaryType);
                    }
                }
                else
                {
                    // second row corresponding to the copied column, so we should change SearchFieldAlias according to copied column name
                    foundRows[1].SearchFieldAlias = columnName + RamPivotGridHelper.CopySuffix;
                }
            }
        }

        /// <summary>
        ///   If Current object is NOT new, Method deletes all columns in the Data Source that hasn't corresponding rows in AggregateTable
        /// </summary>
        /// <param name="aggregateTable"> </param>
        /// <param name="newDataSource"> </param>
        /// <param name="isNewObject"> </param>
        private static void DeleteColumnsMissingInAggregateTable
            (LayoutDetailDataSet.AggregateDataTable aggregateTable,
             DataTable newDataSource, bool isNewObject)
        {
            if (!isNewObject)
            {
                List<LayoutDetailDataSet.AggregateRow> aggregateRows =
                    aggregateTable.Rows.Cast<LayoutDetailDataSet.AggregateRow>().ToList();
                List<DataColumn> dataColumns = newDataSource.Columns.Cast<DataColumn>().ToList();

                foreach (DataColumn column in dataColumns)
                {
                    string columnName = column.ExtendedProperties.ContainsKey(RamPivotGridHelper.CopySuffix)
                                            ? RamPivotGridHelper.GetOriginalNameFromCopyForFilterName(column.ColumnName)
                                            : column.ColumnName;
                    LayoutDetailDataSet.AggregateRow foundRow =
                        aggregateRows.Find(row => (row.SearchFieldAlias == columnName));
                    if (foundRow == null)
                    {
                        newDataSource.Columns.Remove(column);
                    }
                }
            }
        }

        /// <summary>
        ///   If AggregateTable contains multiple rows with the same SearchFieldAlias, method creates corresponding columns. Also method appends Column Name with corresponding idfLayoutSearchField for each column
        /// </summary>
        /// <param name="aggregateTable"> </param>
        /// <param name="newDataSource"> </param>
        private static void CreateCopiedColumnsAndAjustColumnNames
            (LayoutDetailDataSet.AggregateDataTable aggregateTable,
             DataTable newDataSource)
        {
            List<DataColumn> dataColumns = newDataSource.Columns.Cast<DataColumn>().ToList();
            List<LayoutDetailDataSet.AggregateRow> aggregateRows =
                aggregateTable.Rows.Cast<LayoutDetailDataSet.AggregateRow>().ToList();
            foreach (DataColumn column in dataColumns)
            {
                string originalName = column.ColumnName;
                List<LayoutDetailDataSet.AggregateRow> foundRows =
                    aggregateRows.FindAll(row => (row.SearchFieldAlias == originalName));

                int rowCounter = 0;
                foreach (LayoutDetailDataSet.AggregateRow row in foundRows)
                {
                    CheckAggregateRowTranslations(row);
                    if (column.ExtendedProperties.ContainsKey(RamPivotGridHelper.CopySuffix))
                    {
                        row.SearchFieldAlias = RamPivotGridHelper.GetOriginalNameFromCopyForFilterName(originalName);
                    }
                    string caption = row.IsstrNewFieldCaptionNull() || Utils.IsEmpty(row.strNewFieldCaption)
                                         ? row.strOriginalFieldCaption
                                         : row.strNewFieldCaption;
                    if (rowCounter == 0)
                    {
                        // change name so it shall contain idfLayoutSearchField
                        column.ColumnName = RamPivotGridHelper.CreateFieldName(row.SearchFieldAlias, row.idfLayoutSearchField);
                        column.Caption = caption;
                    }
                    else
                    {
                        // create copy of column with new idfLayoutSearchField
                        // name of new column shall contain new id
                        CreateDataSourceColumnCopy(newDataSource,
                                                   column.ColumnName,
                                                   row.SearchFieldAlias,
                                                   caption,
                                                   row.idfLayoutSearchField);
                    }
                    rowCounter++;
                }
            }
        }

        private static void CheckAggregateRowTranslations(LayoutDetailDataSet.AggregateRow row)
        {
            string msg = EidssMessages.Get("msgEmptyRow", "One of rows has empty translation {0}");
            if (row.IsstrOriginalFieldENCaptionNull() || row.IsstrOriginalFieldCaptionNull())
            {
                throw new RamDbException(String.Format(msg, row.SearchFieldAlias));
            }
        }

        #endregion

        #region Create and delete Field Copy

        public void CreateFieldCopy(WinPivotGridField sourceField)
        {
            Utils.CheckNotNull(sourceField, "sourceField");

            LayoutDetailDataSet.AggregateRow destRow = CreateAggregateInformationCopy(sourceField);

            DataColumn destColumn = CreateDataSourceColumnCopy(sourceField, destRow.idfLayoutSearchField);

            CreatePivotGridFieldCopy(sourceField, destColumn.ColumnName);
        }

        private LayoutDetailDataSet.AggregateRow CreateAggregateInformationCopy(WinPivotGridField sourceField)
        {
            LayoutDetailDataSet.AggregateRow sourceRow = GetAggregateRowByField(sourceField);

            LayoutDetailDataSet.AggregateRow destRow = AddNewAggregateRow(sourceRow.SearchFieldAlias,
                                                                          (long) sourceField.GetSummaryType);

            destRow.strNewFieldCaption = sourceRow.strNewFieldCaption;
            destRow.strNewFieldENCaption = sourceRow.strNewFieldENCaption;
            if (!sourceRow.IsidfUnitQuerySearchFieldNull() && !sourceRow.IsUnitSearchFieldAliasNull())
            {
                destRow.UnitSearchFieldAlias = sourceRow.UnitSearchFieldAlias;
                destRow.idfUnitQuerySearchField = sourceRow.idfUnitQuerySearchField;
            }
            if (!sourceRow.IsidfDenominatorQuerySearchFieldNull() && !sourceRow.IsDenominatorSearchFieldAliasNull())
            {
                destRow.DenominatorSearchFieldAlias = sourceRow.DenominatorSearchFieldAlias;
                destRow.idfDenominatorQuerySearchField = sourceRow.idfDenominatorQuerySearchField;
            }
            if (!sourceRow.IsidfDateQuerySearchFieldNull() && !sourceRow.IsDateSearchFieldAliasNull())
            {
                destRow.DateSearchFieldAlias = sourceRow.DateSearchFieldAlias;
                destRow.idfDateQuerySearchField = sourceRow.idfDateQuerySearchField;
            }
            return destRow;
        }

        private LayoutDetailDataSet.AggregateRow GetAggregateRowByField(WinPivotGridField sourceField)
        {
            Utils.CheckNotNull(sourceField, "sourceField");
            if (sourceField.Id < 0)
            {
                throw new RamException(String.Format("Field {0} doesn't has Id", sourceField.FieldName));
            }
            LayoutDetailDataSet.AggregateRow sourceRow = AggregateTable.FindByidfLayoutSearchField(sourceField.Id);
            if (sourceRow == null)
            {
                throw new RamException(String.Format("Aggregate information not found for field {0} with ID {1}",
                                                     sourceField.FieldName, sourceField.Id));
            }
            return sourceRow;
        }

        private DataColumn CreateDataSourceColumnCopy
            (WinPivotGridField sourceField, long idfLayoutSearchField)
        {
            return CreateDataSourceColumnCopy(m_PivotView.DataSource,
                                              sourceField.FieldName,
                                              sourceField.OriginalName,
                                              sourceField.Caption,
                                              idfLayoutSearchField);
        }

        private static DataColumn CreateDataSourceColumnCopy
            (DataTable dataSource, string fullFieldName, string originalFieldName, string fieldCaption, long idfLayoutSearchField)
        {
            DataColumn sourceColumn = dataSource.Columns[fullFieldName];
            DataColumn destColumn = ReflectionHelper.CreateAndCopyProperties(sourceColumn);

            destColumn.ColumnName = RamPivotGridHelper.CreateFieldName(originalFieldName, idfLayoutSearchField);

            dataSource.Columns.Add(destColumn);

            foreach (DataRow row in dataSource.Rows)
            {
                bool isAddedRow = row.RowState == DataRowState.Added;
                row[destColumn] = row[sourceColumn];
                if (!isAddedRow)
                {
                    row.AcceptChanges();
                }
            }
            destColumn.Caption = fieldCaption;
            return destColumn;
        }

        public void DeleteFieldCopy(WinPivotGridField sourceField)
        {
            string message =
                String.Format(
                    BvMessages.Get("msgDeleteAVRFieldPrompt", "{0} field will be deleted. Delete field?"),
                    sourceField.Caption);
            DialogResult dialogResult = MessageForm.Show(message, BvMessages.Get("Confirmation"),
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            DataColumn sourceColumn = m_PivotView.DataSource.Columns[sourceField.FieldName];
            m_PivotView.DataSource.Columns.Remove(sourceColumn);

            m_PivotView.RemoveField(sourceField);
            m_PivotView.RefreshData();

            // clear Unit, Denoninator, Date and other fields here
            string originalName = sourceField.OriginalName;
            List<LayoutDetailDataSet.AggregateRow> aggregateRows =
                AggregateTable.Rows.Cast<LayoutDetailDataSet.AggregateRow>().ToList();
            List<LayoutDetailDataSet.AggregateRow> denominatorRows =
                aggregateRows.FindAll(
                    denRow =>
                    (!denRow.IsDenominatorSearchFieldAliasNull() && denRow.DenominatorSearchFieldAlias == originalName));

            foreach (LayoutDetailDataSet.AggregateRow denRow in denominatorRows)
            {
                denRow.SetDenominatorSearchFieldAliasNull();
                denRow.SetidfDenominatorQuerySearchFieldNull();
            }
            List<LayoutDetailDataSet.AggregateRow> unitRows =
                aggregateRows.FindAll(uRow => (!uRow.IsUnitSearchFieldAliasNull() && uRow.UnitSearchFieldAlias == originalName));
            foreach (LayoutDetailDataSet.AggregateRow uRow in unitRows)
            {
                uRow.SetUnitSearchFieldAliasNull();
                uRow.SetidfUnitQuerySearchFieldNull();
            }
            List<LayoutDetailDataSet.AggregateRow> dateRows =
                aggregateRows.FindAll(dateRow => (!dateRow.IsDateSearchFieldAliasNull() && dateRow.DateSearchFieldAlias == originalName));

            foreach (LayoutDetailDataSet.AggregateRow dateRow in dateRows)
            {
                dateRow.SetDateSearchFieldAliasNull();
                dateRow.SetidfDateQuerySearchFieldNull();
            }

            // remove corresponding aggregate row
            LayoutDetailDataSet.AggregateRow row = AggregateTable.FindByidfLayoutSearchField(sourceField.Id);
            AggregateTable.RemoveAggregateRow(row);
        }

        private void CreatePivotGridFieldCopy(WinPivotGridField sourceField, string fieldName)
        {
            WinPivotGridField field = ReflectionHelper.CreateAndCopyProperties(sourceField);

            field.Name = "field" + fieldName;
            field.FieldName = fieldName;

            m_PivotView.AddField(field);
            m_PivotView.RefreshData();
        }

        #endregion

        #region Helper Methods

        private static void InitGisTypes()
        {
            GisTypeDictionary = new Dictionary<string, GisCaseType>();
            DataView lookupGisTypes = LookupCache.Get(LookupTables.CaseType.ToString());
            if (lookupGisTypes == null)
            {
                return;
            }
            foreach (DataRowView row in lookupGisTypes)
            {
                string key = row["name"].ToString();
                if (!GisTypeDictionary.ContainsKey(key))
                {
                    var id = (long) row["idfsReference"];
                    switch (id)
                    {
                        case 10012001:
                            GisTypeDictionary.Add(key, GisCaseType.Human);
                            break;
                        case 10012003:
                            GisTypeDictionary.Add(key, GisCaseType.Livestock);
                            break;
                        case 10012004:
                            GisTypeDictionary.Add(key, GisCaseType.Avian);
                            break;
                        case 10012005:
                            GisTypeDictionary.Add(key, GisCaseType.Vet);
                            break;
                        case 10012006:
                            GisTypeDictionary.Add(key, GisCaseType.Vector);
                            break;
                        default:
                            GisTypeDictionary.Add(key, GisCaseType.Unkown);
                            break;
                    }
                }
            }
        }

        public LayoutDetailDataSet.AggregateRow AddNewAggregateRow(string originalFieldName, long aggregateFunctionId)
        {
            return AddNewAggregateRow(AggregateTable, QueryId, LayoutId, originalFieldName, aggregateFunctionId, BaseDbService.NewIntID());
        }

        public LayoutDetailDataSet.AggregateRow AddNewAggregateRow
            (string originalFieldName, long aggregateFunctionId, long idfLayoutSearchField)
        {
            return AddNewAggregateRow(AggregateTable, QueryId, LayoutId, originalFieldName, aggregateFunctionId, idfLayoutSearchField);
        }

        internal static string GetReferenceID(string prefix, Enum reference)
        {
            return String.Format("{0}{1}", prefix, reference);
        }

        internal static PivotGroupInterval GetGroupInterval(object interval)
        {
            try
            {
                string strInterval = ((DBGroupInterval) interval).ToString().Substring(3);
                return (PivotGroupInterval) Enum.Parse(typeof (PivotGroupInterval), strInterval);
            }
            catch (Exception)
            {
                return PivotGroupInterval.Date;
            }
        }

        internal static CustomSummaryType ParseSummaryType(long value)
        {
            IEnumerable<CustomSummaryType> allEnumValues =
                Enum.GetValues(typeof (CustomSummaryType)).Cast<CustomSummaryType>();

            CustomSummaryType result = allEnumValues.Any(current => current == (CustomSummaryType) value)
                                           ? (CustomSummaryType) value
                                           : CustomSummaryType.Max;

            return result;
        }

        internal static int ConvertValueToInt(object oValue)
        {
            return (int) ConvertValueToLong(oValue);
        }

        internal static long ConvertValueToLong(object oValue)
        {
            long value = 0;

            if (!Utils.IsEmpty(oValue))
            {
                double dValue;
                if (Double.TryParse(oValue.ToString(), out dValue))
                {
                    value = (long) Math.Round(dValue);
                }
            }
            return value;
        }

        public static double ConvertValueToDouble(object oValue)
        {
            if (!Utils.IsEmpty(oValue))
            {
                double dValue;
                if (Double.TryParse(oValue.ToString(), out dValue))
                {
                    return dValue;
                }
            }
            return 0;
        }

        private List<WinPivotGridField> GetFieldsInRow(string originalFieldName)
        {
            Utils.CheckNotNullOrEmpty(originalFieldName, "originalFieldName");

            List<WinPivotGridField> fields = m_PivotView.WinFields.ToList();
            List<WinPivotGridField> found = fields.FindAll(field => (field.Visible) &&
                                                                    (field.AreaIndex >= 0) &&
                                                                    (field.Area == PivotArea.RowArea) &&
                                                                    (field.OriginalName == originalFieldName));

            return found;
        }

        public static bool AskQuestion(string text, string caption)
        {
            return MessageForm.Show(text, caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static string AppendLanguageNameTo(string text)
        {
            if (!Utils.IsEmpty(text))
            {
                int bracketInd = text.IndexOf("(", StringComparison.Ordinal);
                if (bracketInd >= 0)
                {
                    text = text.Substring(0, bracketInd).Trim();
                }
                string languageName = Localizer.GetLanguageName(ModelUserContext.CurrentLanguage);
                text = String.Format("{0} ({1})", text, languageName);
            }
            return text;
        }

        #endregion
    }
}