using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Enums;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPivotGrid;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.PivotComponents;
using eidss.avr.Tools;
using eidss.model.Avr.Chart;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.model.Enums;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using EIDSS;
using BaseReferenceType = bv.common.db.BaseReferenceType;
using Localizer = bv.common.Core.Localizer;

namespace eidss.avr.PivotForm
{
    public sealed class PivotDetailPresenter : RelatedObjectPresenter
    {
        private readonly IPivotDetailView m_PivotView;

        private readonly BaseAvrDbService m_PivotFormService;
        private readonly LayoutMediator m_LayoutMediator;

        static PivotDetailPresenter()
        {
            InitGisTypes();
        }

        public PivotDetailPresenter(SharedPresenter sharedPresenter, IPivotDetailView view)
            : base(sharedPresenter, view)
        {
            m_PivotFormService = new BaseAvrDbService();

            m_PivotView = view;
            m_PivotView.DBService = PivotFormService;
            m_LayoutMediator = new LayoutMediator(this);
        }

        public bool Changed { get; set; }

        public static Dictionary<string, GisCaseType> GisTypeDictionary { get; private set; }

        public BaseAvrDbService PivotFormService
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

        public long LayoutId
        {
            get { return m_LayoutMediator.LayoutRow.idflLayout; }
        }

        public bool ApplyFilter
        {
            get { return m_LayoutMediator.LayoutRow.blnApplyPivotGridFilter; }
        }

        public bool ShowDataInPivotGrid
        {
            get { return m_LayoutMediator.LayoutRow.blnShowDataInPivotGrid; }
        }
        public bool CompactPivotGrid
        {
            get { return m_LayoutMediator.LayoutRow.blnCompactPivotGrid; }
            set { m_LayoutMediator.LayoutRow.blnCompactPivotGrid = value; }
        }

        private PivotGridXmlVersion PivotGridXmlVersion
        {
            get { return (PivotGridXmlVersion) m_LayoutMediator.LayoutRow.intPivotGridXmlVersion; }
        }

        public LayoutDetailDataSet.LayoutSearchFieldDataTable LayoutSearchFieldTable
        {
            get { return m_LayoutMediator.LayoutDataSet.LayoutSearchField; }
        }

        public string SettingsXml
        {
            get
            {
                string basicXml = m_LayoutMediator.LayoutRow.IsstrPivotGridSettingsNull()
                    ? String.Empty
                    : m_LayoutMediator.LayoutRow.strPivotGridSettings;

                return basicXml;
            }
            set { m_LayoutMediator.LayoutRow.strPivotGridSettings = value; }
        }

        public bool ReadOnly
        {
            get { return m_LayoutMediator.LayoutRow.blnReadOnly; }
        }

        public bool FreezeRowHeaders
        {
            get { return m_LayoutMediator.LayoutRow.blnFreezeRowHeaders; }
        }

        public bool ShowMissedValues
        {
            get { return m_LayoutMediator.LayoutRow.blnShowMissedValuesInPivotGrid; }
            set {  m_LayoutMediator.LayoutRow.blnShowMissedValuesInPivotGrid = value; }
        }

        public bool CopyPivotName { get; set; }

        public bool CopyMapName { get; set; }

        public bool CopyChartName { get; set; }

        #region Binding

        public void BindFreezeRowHeaders(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.blnFreezeRowHeadersColumn.ColumnName);
        }

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
                m_LayoutMediator.LayoutTable.blnApplyPivotGridFilterColumn.ColumnName);
        }
        public void BindShowDataInPivotGrid(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.blnShowDataInPivotGridColumn.ColumnName);
        }

        public void BindCompactPivotGrid(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.blnCompactPivotGridColumn.ColumnName);
        }

        public void BindShowMissedValues(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.blnShowMissedValuesInPivotGridColumn.ColumnName);
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
                m_LayoutMediator.LayoutTable.idfsDefaultGroupDateColumn.ColumnName,
                BaseReferenceType.rftGroupInterval,
                (long) DBGroupInterval.gitDateYear);
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
        ///     It's workaround method. don't use it
        /// </summary>
        /// <param name="layoutName"> </param>
        public void SetLayoutName(string layoutName)
        {
            m_LayoutMediator.LayoutRow.strLayoutName = layoutName;
        }

        /// <summary>
        ///     It's workaround method. don't use it
        /// </summary>
        /// <param name="layoutName"> </param>
        public void SetDefaultLayoutName(string layoutName)
        {
            m_LayoutMediator.LayoutRow.strDefaultLayoutName = layoutName;
        }

        public void InitAdmUnit(LookUpEdit cbAdministrativeUnit, IAvrPivotGridField selectedField)
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.InitAdmUnit))
            {
                long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
                DataView dataView = AvrPivotGridHelper.GetAdministrativeUnitView(queryId, m_PivotView.AvrFields.ToList());

                string fieldAlias = SharedPresenter.GetSelectedAdministrativeFieldAlias(dataView, selectedField);

                BindComboBox(cbAdministrativeUnit, dataView, fieldAlias);
            }
        }

        public void InitStatDate(LookUpEdit cbStatDate, IAvrPivotGridField selectedField)
        {
            DataView dataView = AvrPivotGridHelper.GetStatisticDateView(m_PivotView.AvrFields);

            string fieldAlias = selectedField == null
                ? null
                : selectedField.GetSelectedDateFieldAlias();
            BindComboBox(cbStatDate, dataView, fieldAlias);
        }

        private static void BindComboBox(LookUpEdit combo, DataView dataView, string fieldAlias)
        {
            combo.DataBindings.Clear();

            combo.Properties.Columns.Clear();
            var info = new LookUpColumnInfo("Caption", EidssMessages.Get("colCaption", "Caption"),
                200, FormatType.None, "", true, HorzAlignment.Near);
            combo.Properties.Columns.AddRange(new[] {info});
            combo.Properties.PopupWidth = combo.Width;
            combo.Properties.NullText = string.Empty;

            combo.Properties.DataSource = dataView;
            combo.Properties.ValueMember = "Alias";
            combo.Properties.DisplayMember = "Caption";

            DataRow[] found = dataView.Table.Select(string.Format("Alias='{0}'", fieldAlias));
            if (found.Length > 0)
            {
                combo.EditValue = found[0]["Alias"];
            }
            else
            {
                combo.EditValue = (dataView.Count > 0)
                    ? dataView[0]["Alias"]
                    : DBNull.Value;
            }
        }

        public override void Process(Command cmd)
        {
            try
            {
                var fieldCommand = cmd as PivotFieldCommand;
                if (fieldCommand != null)
                {
                    switch (fieldCommand.FieldOperation)
                    {
                        case PivotFieldOperation.Rename:
                            ProcessRenameFieldCaption(fieldCommand);
                            break;
                        case PivotFieldOperation.Copy:
                            ProcessCopyField(fieldCommand);
                            break;
                        case PivotFieldOperation.DeleteCopy:
                            ProcessDeleteField(fieldCommand);
                            break;
                        case PivotFieldOperation.AddMissedValues:
                        case PivotFieldOperation.EditMissedValues:
                            ProcessAddEditMissedValues(fieldCommand);
                            break;
                        case PivotFieldOperation.DeleteMissedValues:
                            ProcessDeleteMissedValues(fieldCommand);
                            break;
                    }
                }
                var fieldGroupDateCommand = cmd as PivotFieldGroupIntervalCommand;
                if (fieldGroupDateCommand != null)
                {
                    ProcessGroupInterval(fieldGroupDateCommand);
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

        private void ProcessRenameFieldCaption(PivotFieldCommand command)
        {
            if (command == null || command.Field == null)
            {
                return;
            }
            command.State = CommandState.Pending;

            LayoutDetailDataSet.LayoutSearchFieldRow row = GetLayoutSearchFieldRowByField(command.Field);
            using (var form = new RenameFieldDialog(row.strOriginalFieldENCaption, row.strOriginalFieldCaption,
                row.strNewFieldENCaption, row.strNewFieldCaption))
            {
                if (form.ShowDialog(m_PivotView.ParentForm) == DialogResult.OK)
                {
                    row.strNewFieldENCaption = form.NewEnglishCaption;
                    row.strNewFieldCaption = ModelUserContext.CurrentLanguage == Localizer.lngEn
                        ? form.NewEnglishCaption
                        : form.NewNationalCaption;

                    command.Field.Caption = row.strNewFieldCaption;
                }
            }

            command.State = CommandState.Processed;
        }

        private void ProcessCopyField(PivotFieldCommand command)
        {
            if (command == null || command.Field == null)
            {
                return;
            }
            command.State = CommandState.Pending;

            using (m_PivotView.PivotGridView.BeginTransaction())
            {
                CreateFieldCopy<WinPivotGridField>(command.Field);
                m_PivotView.PivotGridView.ClearCacheDataRowColumnAreaFields();
            }
            m_PivotView.ClickOnFocusedCell(true);

            command.State = CommandState.Processed;
        }

        private void ProcessDeleteField(PivotFieldCommand command)
        {
            if (command == null || command.Field == null)
            {
                return;
            }
            command.State = CommandState.Pending;

            using (m_PivotView.PivotGridView.BeginTransaction())
            {
                DeleteFieldCopy(command.Field);
                m_PivotView.PivotGridView.ClearCacheDataRowColumnAreaFields();
            }
            m_PivotView.ClickOnFocusedCell(true);

            //AjustCreateDeleteFieldsEnable();

            command.State = CommandState.Processed;
        }

        private void ProcessAddEditMissedValues(PivotFieldCommand command)
        {
            if (command == null || command.Field == null)
            {
                return;
            }
            command.State = CommandState.Pending;

            IAvrPivotGridField field = command.Field;
            bool needToChange = !field.IsDateTimeField;

            if (field.IsDateTimeField)
            {
                using (var form = new DateDiapasonDialog(field.DiapasonStartDate, field.DiapasonEndDate))
                {
                    if (form.ShowDialog(m_PivotView.ParentForm) == DialogResult.OK)
                    {
                        if (field.DiapasonStartDate != form.DateFrom || field.DiapasonEndDate != form.DateTo)
                        {
                            field.DiapasonStartDate = form.DateFrom;
                            field.DiapasonEndDate = form.DateTo;

                            needToChange = true;
                        }
                    }
                }
            }

            if (needToChange)
            {
                foreach (IAvrPivotGridField change in GetFieldCopiesExceptHidden(command))
                {
                    if (change.Visible && (change.Area == PivotArea.ColumnArea || change.Area == PivotArea.RowArea))
                    {
                        change.AddMissedValues = true;
                        change.DiapasonStartDate = field.DiapasonStartDate;
                        change.DiapasonEndDate = field.DiapasonEndDate;
                        change.UpdateImageIndex();
                    }
                }
                Changed = true;
                if (m_PivotView.ShowMissedValues && m_PivotView.ShowData)
                {
                    using (m_PivotView.BeginTransaction())
                    {
                        m_PivotView.FillAbsentAndMissingValues();
                        m_PivotView.RefreshPivotData();
                    }
                }
            }

            command.State = CommandState.Processed;
        }

        private void ProcessDeleteMissedValues(PivotFieldCommand command)
        {
            if (command == null || command.Field == null)
            {
                return;
            }
            command.State = CommandState.Pending;

            foreach (IAvrPivotGridField change in GetFieldCopiesExceptHidden(command))
            {
                change.DiapasonStartDate = null;
                change.DiapasonEndDate = null;
                change.AddMissedValues = false;
                change.UpdateImageIndex();
            }

            Changed = true;

            if (m_PivotView.ShowMissedValues && m_PivotView.ShowData)
            {
                using (m_PivotView.BeginTransaction())
                {
                    m_PivotView.FillAbsentAndMissingValues();
                    m_PivotView.RefreshPivotData();
                }
            }

            command.State = CommandState.Processed;
        }

        internal IEnumerable<IAvrPivotGridField> GetFieldCopiesExceptHidden(PivotFieldCommand command)
        {
            return GetFieldCopiesExceptHidden(command.Field);
        }

        internal IEnumerable<IAvrPivotGridField> GetFieldCopiesExceptHidden(IAvrPivotGridField field)
        {
            return m_PivotView.AvrFields.Where(f => !f.IsHiddenFilterField && f.OriginalFieldName == field.OriginalFieldName);
        }

        private void ProcessGroupInterval(PivotFieldGroupIntervalCommand command)
        {
            if (command == null || command.Field == null)
            {
                return;
            }
            command.State = CommandState.Pending;

            IAvrPivotGridField field = command.Field;

            using (m_PivotView.BeginTransaction())
            {
                field.PrivateGroupInterval = command.GroupInterval;

                m_PivotView.FillAbsentAndMissingValues();
            }
            command.State = CommandState.Processed;
        }

        #region Prepare Data Source For Pivot Grid 

        public AvrDataTable GetPreparedDataSource()
        {
            if (m_SharedPresenter.IsQueryResultNull)
            {
                return null;
            }
            bool isNewObject = IsNewObject || LayoutSearchFieldTable.Count == 0;

            var filter = isNewObject
                ? null
                : m_LayoutMediator.LayoutRow.strPivotGridSettings;
            AvrDataTable newDataSource = m_SharedPresenter.GetQueryResultCopy(filter);
            long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;

            var res = AvrPivotGridHelper.GetPreparedDataSource(LayoutSearchFieldTable, queryId, LayoutId, newDataSource, isNewObject);
            return res;
        }

        public AvrDataTable GetPreparedDataSourceFiltered(string expression)
        {
            if (m_SharedPresenter.IsQueryResultNull)
            {
                return null;
            }
            AvrDataTable newDataSource = m_SharedPresenter.GetQueryResultCopy(expression);
            long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;

            var res = AvrPivotGridHelper.GetPreparedDataSource(LayoutSearchFieldTable, queryId, LayoutId, newDataSource, false);
            return res;
        }

        #endregion

        #region Load Pivot Grid 

        public void LoadPivotFromDB()
        {
            List<IAvrPivotGridField> avrFields = m_PivotView.AvrFields.ToList();
            if (!IsNewObject)
            {
                if (PivotGridXmlVersion == PivotGridXmlVersion.Version5)
                {
                    LoadPivotVersionFiveFromDB();
                }
                else
                {
                    long intervalId = m_LayoutMediator.LayoutRow.idfsDefaultGroupDate;
                    AvrPivotGridHelper.LoadSearchFieldsVersionSixFromDB(avrFields, LayoutSearchFieldTable, intervalId);

                    LoadPivotFilterVersionSixFromDB();
                }
            }

            AvrPivotGridHelper.LoadExstraSearchFieldsProperties(avrFields, LayoutSearchFieldTable);
        }

        private void LoadPivotFilterVersionSixFromDB()
        {
            try
            {
                m_PivotView.FilterCriteria = CriteriaOperator.Parse(SettingsXml);
            }
            catch (Exception ex)
            {
                m_PivotView.FilterCriteria = null;
                Trace.WriteLine(ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                string msg = EidssMessages.Get("errCannotRestoreAvrFilterFromDb", "Pivot Grid filter can't be restored from Database");
                ErrorForm.ShowErrorDirect(msg, ex);
            }
        }

        private void LoadPivotVersionFiveFromDB()
        {
            if (!string.IsNullOrEmpty(SettingsXml))
            {
                using (var stream = new MemoryStream())
                {
                    using (var streamWriter = new StreamWriter(stream))
                    {
                        streamWriter.Write(SettingsXml);
                        streamWriter.Flush();
                        stream.Position = 0;
                        m_PivotView.PivotGridView.RestoreLayoutFromStream(stream);
                    }
                }
            }
        }

        #endregion

        #region Save Pivot Grid

        public void SavePivotFilterToDB(CriteriaOperator filter)
        {
            Changed = false;
            SettingsXml = (ReferenceEquals(filter, null)) ? null : filter.ToString();
        }

        #endregion

        #region Create and delete Field Copy

        public Dictionary<IAvrPivotGridField, IAvrPivotGridField> GetFieldsAndCopies()
        {
            var fieldsAndCopies = new Dictionary<IAvrPivotGridField, IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in m_PivotView.AvrFields.Where(f => !f.IsHiddenFilterField))
            {
                IAvrPivotGridField fieldCopy =
                    m_PivotView.AvrFields.FirstOrDefault(f => f.IsHiddenFilterField && f.OriginalFieldName == field.OriginalFieldName);
                if (fieldCopy != null)
                {
                    fieldsAndCopies.Add(field, fieldCopy);
                }
            }
            return fieldsAndCopies;
        }

        public void CreateFieldCopy<T>(IAvrPivotGridField sourceField) where T : IAvrPivotGridField, new()
        {
            var copy = AvrPivotGridHelper.CreateFieldCopy<T>(sourceField,
                m_LayoutMediator.LayoutDataSet,
                m_PivotView.DataSource,
                m_SharedPresenter.SharedModel.SelectedQueryId,
                LayoutId);
            m_PivotView.AddField(copy);
            m_PivotView.RefreshPivotData();
        }

        private LayoutDetailDataSet.LayoutSearchFieldRow GetLayoutSearchFieldRowByField(IAvrPivotGridField sourceField)
        {
            return AvrPivotGridHelper.GetLayoutSearchFieldRowByField(sourceField, m_LayoutMediator.LayoutDataSet);
        }

        public void DeleteFieldCopy(IAvrPivotGridField sourceField)
        {
            string message = String.Format(BvMessages.Get("msgDeleteAVRFieldPrompt", "{0} field will be deleted. Delete field?"),
                sourceField.Caption);
            DialogResult dialogResult = MessageForm.Show(message, BvMessages.Get("Confirmation"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            AvrPivotGridHelper.DeleteFieldCopy(sourceField, m_LayoutMediator.LayoutDataSet, m_PivotView.DataSource);
            m_PivotView.RemoveField(sourceField);
            m_PivotView.RefreshPivotData();
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
                        case (long) CaseTypeEnum.Human:
                            GisTypeDictionary.Add(key, GisCaseType.Human);
                            break;
                        case (long) CaseTypeEnum.Livestock:
                            GisTypeDictionary.Add(key, GisCaseType.Livestock);
                            break;
                        case (long) CaseTypeEnum.Avian:
                            GisTypeDictionary.Add(key, GisCaseType.Avian);
                            break;
                        case (long) CaseTypeEnum.Veterinary:
                            GisTypeDictionary.Add(key, GisCaseType.Vet);
                            break;
                        case (long) CaseTypeEnum.Vector:
                            GisTypeDictionary.Add(key, GisCaseType.Vector);
                            break;
                        default:
                            GisTypeDictionary.Add(key, GisCaseType.Unkown);
                            break;
                    }
                }
            }
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