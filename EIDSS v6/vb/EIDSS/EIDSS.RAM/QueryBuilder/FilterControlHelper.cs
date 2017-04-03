using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.PivotComponents;
using EIDSS.Core;
using EIDSS.Enums;
using eidss.model.AVR.Db;

namespace eidss.avr.QueryBuilder
{
    internal class FilterControlHelper : IDisposable
    {
        private static readonly FilterValueHash m_ValueHash = new FilterValueHash();

        private class FieldInfo
        {
            private readonly string m_Caption;

            public FieldInfo(long conditionID, string caption, RepositoryItem editor)
            {
                SearchFieldConditionID = conditionID;
                m_Caption = caption;
                Editor = editor;
            }

            public string Caption
            {
                get { return m_Caption; }
            }

            public RepositoryItem Editor { get; set; }

            public long SearchFieldConditionID { get; set; }
        }

        private enum DataSourceType
        {
            Unbound,
            PivotGrid
        }

        private readonly FilterControl m_FilterControl;

        private DataView m_SearchFields;
        //contains the list of query search fields returned by procedure spAsQuerySearchObject_SelectDetail

        //list of columns:idfQuerySearchField,idfQuerySearchObject,idfsSearchField,FieldAlias,FieldENCaption,FieldCaption,blnShow,idfsParameter

        private DataView m_SearchCriteria;
        //contains the list of query search fields returned by procedure spAsQuerySearchObject_SelectDetail

        //list of columns:idfParentQueryConditionGroup,idfQueryConditionGroup,intOrder,idfQuerySearchObject,blnJoinByOr,blnUseNot,idfQuerySearchFieldCondition,
        //SearchFieldConditionText,strOperator,intOperatorType,idfQuerySearchField,blnFieldConditionUseNot,varValue

        private long m_SearchObjectID;
        private readonly Dictionary<string, FieldInfo> m_FieldInfo = new Dictionary<string, FieldInfo>();
        private readonly DataSourceType m_DataSourceType;
        private PivotGridControl m_PivotGrid;
        private BarManager m_MenuManager;
        private static DataView m_SearchFieldsLookupView;

        private void InitMenuManager()
        {
            m_MenuManager = new BarManager();
            m_FilterControl.VisibleChanged += FilterControlVisibleChanged;
            m_MenuManager.Form = m_FilterControl.FindForm();
            m_MenuManager.Controller = new BarAndDockingController();
            m_MenuManager.Controller.AppearancesBar.ItemsFont = WinClientContext.CurrentFont;
            m_FilterControl.MenuManager = m_MenuManager;
            InitSearchFieldsLookupView();
        }

        private void FilterControlVisibleChanged(object sender, EventArgs e)
        {
            if (m_MenuManager.Form == null)
            {
                m_MenuManager.Form = m_FilterControl.FindForm();
            }
        }

        #region Public Methods

        public FilterControlHelper(FilterControl ctl)
        {
            m_FilterControl = ctl;
            if (WinUtils.IsComponentInDesignMode(m_FilterControl))
            {
                return;
            }
            InitMenuManager();
            m_FilterControl.FilterChanged += FilterChanged;
            m_DataSourceType = DataSourceType.Unbound;
            InitSearchFieldsLookupView();
        }

        public FilterControlHelper(FilterControl ctl, AvrPivotGrid pivotGrid, bool createEditors, CriteriaOperator filterCriteria = null)
        {
            m_FilterControl = ctl;
            if (WinUtils.IsComponentInDesignMode(m_FilterControl))
            {
                return;
            }

            InitMenuManager();
            m_FilterControl.FilterChanged += FilterChanged;

            //take filter from parameter if it passed. Owerwithe teke it from pivot grid
            m_FilterControl.FilterCriteria = filterCriteria ?? pivotGrid.Criteria;

            m_DataSourceType = DataSourceType.PivotGrid;
            m_PivotGrid = pivotGrid;
            BindPivotGrid(pivotGrid, createEditors);

            //important! - exsting pivot grid filter criteria is displayed incorrectly if binding
            //is applied over it.
            //We must save filter criteria and apply it explictly after binding pivot grid columns
            //to display filter criteria correctly
            m_FilterControl.FilterCriteria = m_FilterControl.FilterCriteria;

            // disable control if no pivotgrid fields bound
            ProcessEnablingFor(m_FilterControl);
        }

        public void Dispose()
        {
            m_FilterControl.VisibleChanged -= FilterControlVisibleChanged;
            m_FilterControl.FilterChanged -= FilterChanged;
            m_FilterControl.FilterCriteria = null;
            m_FilterControl.MenuManager = null;
            m_FilterControl.SourceControl = null;

            m_MenuManager.Controller.Dispose();
            m_MenuManager.Form = null;
            m_MenuManager.Dispose();

            m_SearchFieldsLookupView = new DataView();

            m_PivotGrid = null;
        }

        public static FilterValueHash ValueHash
        {
            get { return m_ValueHash; }
        }

        public CriteriaOperator FilterCriteria
        {
            get
            {
                return m_FilterControl == null
                    ? null
                    : m_FilterControl.FilterCriteria;
            }
        }

        public static void ProcessEnablingFor(FilterControl filterControl)
        {
            Utils.CheckNotNull(filterControl, "filterControl");
            filterControl.Enabled = filterControl.FilterColumns.Count > 0;
        }

        #region Filter columns unitialization

        public void Bind(long searchObjectID, DataView searchFields, DataView searchCriteria)
        {
            m_SearchObjectID = searchObjectID;
            m_FilterControl.SourceControl = null;
            if (searchFields == null)
            {
                m_SearchFields = null;
                m_SearchCriteria = null;
                return;
            }
            m_SearchFields = searchFields;
            m_SearchFields.Sort = "idfQuerySearchField";
            m_SearchCriteria = searchCriteria;
            GenerateColumns();
            m_FilterControl.FilterCriteria = InitSearchCriteria(-1, null);

            FilterChangedEventHandler handler = OnFilterChanged;
            if (handler != null)
            {
                OnFilterChanged(m_FilterControl, new FilterChangedEventArgs(FilterChangedAction.ValueChanged, null));
            }
            m_HasChanges = false;
        }

        //private long FieldName2FieldID(string fieldName)
        //{
        //    DataRow[] rows = m_SearchFieldsLookupView.Table.Select(string.Format("strSearchFieldAlias = {0}", fieldName));
        //    if (rows.Length > 0)
        //        return (long)rows[0]["idfsSearchField"];
        //    rows = m_SearchFields.Table.Select(string.Format("FieldAlias = {0}", fieldName));
        //    if (rows.Length > 0)
        //        return (long)rows[0]["idfsSearchField"];
        //    return -1;
        //}

        //private string FieldID2FieldName(long fieldID)
        //{
        //    int rowNum = m_SearchFields.Find(fieldID);
        //    Dbg.Assert(rowNum < 0, "field with id {0} is not found in search fields table", fieldID);
        //    DataRow searchFieldRow = m_SearchFields[rowNum].Row;
        //    DataRow fieldRow = LookupCache.GetLookupRow(fieldID, LookupTables.SearchField.ToString());
        //    SearchFieldType fieldType = (SearchFieldType)(fieldRow["idfsSearchFieldType"]);
        //    if (fieldType != SearchFieldType.FFField) //field is not related with flexible form
        //    {
        //        return fieldRow["strSearchFieldAlias"].ToString();
        //    }
        //    //field is related with flexible form
        //    return Utils.Str(searchFieldRow["FieldAlias"]);
        //}

        private void GenerateColumns()
        {
            //important! - setting filter columns doesn't affect to fields list in popup menu if FilterCriteria!=null
            //by this reason we should save FilterCriteria and restore it after columns adding
            CriteriaOperator criteria = m_FilterControl.FilterCriteria;
            m_FilterControl.FilterCriteria = null;
            m_FilterControl.SetFilterColumnsCollection(null);
            m_FieldInfo.Clear();
            var columns = new QueryFilterColumnCollection(null);
            foreach (DataRowView row in m_SearchFields)
            {
                if (row.Row.RowState != DataRowState.Deleted)
                {
                    AddFilterColumn(columns, row);
                }
            }
            m_FilterControl.SetFilterColumnsCollection(columns);
            m_FilterControl.FilterCriteria = criteria;
        }

        private void AddFilterColumn(FilterColumnCollection columns, DataRowView row)
        {
            string fieldID = Utils.Str(row["idfsSearchField"]);
            DataRow fieldRow = LookupCache.GetLookupRow(fieldID, LookupTables.SearchField.ToString());
            var fieldType = (SearchFieldType) (fieldRow["idfsSearchFieldType"]);
            UnboundQueryFilterColumn col;
            if (fieldType != SearchFieldType.FFField) //field is not related with flexible form
            {
                col = CreateUsualColumn((long) row["idfQuerySearchField"], fieldRow);
            }
            else //field is related with flexible form
            {
                var parameterID = (long) (row["idfsParameter"]);
                string fieldAlias = Utils.Str(row["FieldAlias"]);
                col = CreateFFParameterColumn((long) row["idfQuerySearchField"], fieldRow, fieldAlias, parameterID);
            }
            if (col != null)
            {
                columns.Add(col);
            }
        }

        private static RepositoryItemDateEdit m_DateEdit;

        private static RepositoryItemDateEdit DefaultDateEditor
        {
            get
            {
                if (m_DateEdit == null)
                {
                    m_DateEdit = new RepositoryItemDateEdit {EditMask = "d"};

                    m_DateEdit.DisplayFormat.Format = CultureInfo.CurrentCulture.DateTimeFormat;
                    m_DateEdit.DisplayFormat.FormatString = "d";
                    m_DateEdit.EditFormat.Format = CultureInfo.CurrentCulture.DateTimeFormat;
                    m_DateEdit.EditFormat.FormatString = "d";
                    m_DateEdit.Mask.UseMaskAsDisplayFormat = true;
                }
                return m_DateEdit;
            }
        }

        private static readonly RepositoryItemSpinEdit m_DefaultIntEditor = new RepositoryItemSpinEdit();
        private static readonly RepositoryItemSpinEdit m_DefaultDoubleEditor = new RepositoryItemSpinEdit();
        private static readonly RepositoryItemCheckEdit m_DefaultCheckEditor = new RepositoryItemCheckEdit();
        private static readonly RepositoryItemTextEdit m_DefaultStringEditor = new RepositoryItemTextEdit();

        private static RepositoryItem GetEditor(SearchFieldType fieldType)
        {
            switch (fieldType)
            {
                case SearchFieldType.Date:
                    return DefaultDateEditor;
                case SearchFieldType.ID:
                    return m_DefaultStringEditor;
                case SearchFieldType.Bit:
                    return m_DefaultCheckEditor;
                case SearchFieldType.Float:
                    return m_DefaultDoubleEditor;
                case SearchFieldType.Integer:
                    return m_DefaultIntEditor;
                default:
                    return m_DefaultStringEditor;
            }
        }

        private static UnboundQueryFilterColumn CreateUnboundColumn
            (SearchFieldType fieldType, string fieldName, string fieldCaption, RepositoryItem editor)
        {
            if (Utils.IsEmpty(fieldName))
            {
                return null;
            }
            UnboundQueryFilterColumn col;
            switch (fieldType)
            {
                case SearchFieldType.Date:
                    if (editor == null)
                    {
                        editor = DefaultDateEditor;
                    }
                    col = new UnboundQueryFilterColumn(fieldCaption, fieldName, typeof (DateTime), editor,
                        FilterColumnClauseClass.DateTime);
                    break;
                case SearchFieldType.ID:
                    if (editor == null)
                    {
                        editor = m_DefaultStringEditor;
                    }
                    col = new UnboundQueryFilterColumn(fieldCaption, fieldName, typeof (long), editor,
                        FilterColumnClauseClass.Lookup);
                    break;
                case SearchFieldType.Bit:
                    if (editor == null)
                    {
                        editor = m_DefaultCheckEditor;
                    }
                    col = new UnboundQueryFilterColumn(fieldCaption, fieldName, typeof (Boolean), editor,
                        FilterColumnClauseClass.Generic);
                    break;
                case SearchFieldType.Float:
                    if (editor == null)
                    {
                        editor = m_DefaultDoubleEditor;
                    }
                    col = new UnboundQueryFilterColumn(fieldCaption, fieldName, typeof (double), editor,
                        FilterColumnClauseClass.Generic);
                    break;
                case SearchFieldType.Integer:
                    if (editor == null)
                    {
                        editor = m_DefaultIntEditor;
                    }
                    col = new UnboundQueryFilterColumn(fieldCaption, fieldName, typeof (int), editor,
                        FilterColumnClauseClass.Generic);
                    break;
                default:
                    if (editor == null)
                    {
                        editor = m_DefaultStringEditor;
                    }
                    col = new UnboundQueryFilterColumn(fieldCaption, fieldName, typeof (String), editor,
                        FilterColumnClauseClass.String);
                    break;
            }
            return col;
        }

        private UnboundQueryFilterColumn CreateFFParameterColumn
            (long conditionID, DataRow searchFieldRow, string fieldAlias, long parameterID)
        {
            //long fieldID = (long)(searchFieldRow["idfsSearchField"]);
            DataRow paramRow = LookupCache.GetLookupRow(fieldAlias, LookupTables.ParameterForFFType.ToString());
            var fieldType = SearchFieldType.String;
            RepositoryItem cb = GetFFFieldEditor(paramRow, searchFieldRow, ref fieldType);
            //object paramType = paramRow["idfsParameterType"];
            //object referenceType = paramRow["idfsReferenceType"];
            //bool isLookupField = false;
            //SearchFieldType fieldType = (SearchFieldType)searchFieldRow["idfsSearchFieldType"];
            //if (!Utils.IsEmpty(referenceType))
            //    isLookupField = true;
            //else
            //    fieldType = ParamType2FieldType(paramType);

            //RepositoryItem cb = null;
            //if (isLookupField)
            //{
            //    cb = new RepositoryItemLookUpEdit();
            //    cb.Enter += LookupEditor_Enter;
            //    if (referenceType.Equals((long)BaseReferenceType.rftParametersFixedPresetValue))
            //        BindFFFixedValueLookup((RepositoryItemLookUpEdit)cb, paramType);
            //    else
            //        BindBaseValueLookup((RepositoryItemLookUpEdit)cb, (long)referenceType, ObjectHACode);
            //}
            m_FieldInfo.Add(fieldAlias, new FieldInfo(conditionID, Utils.Str(paramRow["ParameterName"]), cb));

            UnboundQueryFilterColumn col = CreateUnboundColumn(fieldType, fieldAlias,
                Utils.Str(paramRow["ParameterName"]), cb);

            return col;
            //return null;
        }

        private RepositoryItem GetFFFieldEditor(DataRow paramRow, DataRow searchFieldRow, ref SearchFieldType fieldType)
        {
            object paramType = paramRow["idfsParameterType"];
            object referenceType = paramRow["idfsReferenceType"];
            bool isLookupField = false;
            fieldType = (SearchFieldType) searchFieldRow["idfsSearchFieldType"];
            if (!Utils.IsEmpty(referenceType))
            {
                isLookupField = true;
            }
            else
            {
                fieldType = ParamType2FieldType(paramType);
            }

            RepositoryItem cb = null;
            if (isLookupField)
            {
                cb = new RepositoryItemLookUpEdit();
                cb.Enter += LookupEditor_Enter;
                if (referenceType.Equals((long) BaseReferenceType.rftParametersFixedPresetValue))
                {
                    BindFFFixedValueLookup((RepositoryItemLookUpEdit) cb, paramType);
                }
                else
                {
                    BindBaseValueLookup((RepositoryItemLookUpEdit) cb, (long) referenceType, ObjectHACode);
                }
            }
            return cb;
        }

        private RepositoryItem GetLookupEditor(DataRow searchFieldRow)
        {
            object referenceType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"],
                LookupTables.SearchField, "idfsReferenceType");
            object gisReferenceType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"],
                LookupTables.SearchField, "idfsGISReferenceType");
            object lookupType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"], LookupTables.SearchField,
                "strLookupTable");

            var cb = new RepositoryItemLookUpEdit();
            cb.Enter += LookupEditor_Enter;
            if (!Utils.IsEmpty(lookupType) && !Utils.Str(lookupType).StartsWith("rft"))
            {
                BindSpecialLookup(cb, lookupType.ToString());
            }
            else if (!Utils.IsEmpty(referenceType))
            {
                BindBaseValueLookup(cb, Convert.ToInt64(referenceType), ObjectHACode);
            }
            else if (!Utils.IsEmpty(gisReferenceType))
            {
                BindBaseValueLookup(cb, Convert.ToInt64(gisReferenceType), ObjectHACode);
            }
            return cb;
        }

        private UnboundQueryFilterColumn CreateUsualColumn(long conditionID, DataRow searchFieldRow)
        {
            var fieldType = (SearchFieldType) searchFieldRow["idfsSearchFieldType"];
            var fieldID = (long) searchFieldRow["idfsSearchField"];
            string fieldName = Utils.Str(searchFieldRow["strSearchFieldAlias"]);
            if (m_FieldInfo.ContainsKey(fieldName))
            {
                Dbg.Debug("column with fieldName [{0}] is already exists", fieldName);
                return null;
            }
            m_FieldInfo.Add(fieldName, new FieldInfo(conditionID, Utils.Str(searchFieldRow["FieldCaption"]), null));
            if (IsLookupField(searchFieldRow))
            {
                fieldType = SearchFieldType.ID;
                m_FieldInfo[fieldName].Editor = GetLookupEditor(searchFieldRow);
                //object referenceType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"], LookupTables.SearchField, "idfsReferenceType");
                //object gisReferenceType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"], LookupTables.SearchField, "idfsGISReferenceType");
                //object lookupType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"], LookupTables.SearchField, "strLookupTable");

                //RepositoryItemLookUpEdit cb = new RepositoryItemLookUpEdit();
                //cb.Enter += LookupEditor_Enter;

                //if (!Utils.IsEmpty(lookupType))
                //    BindSpecialLookup(cb, lookupType.ToString());
                //else if (!Utils.IsEmpty(referenceType))
                //    BindBaseValueLookup(cb, Convert.ToInt64(referenceType), ObjectHACode);
                //else if (!Utils.IsEmpty(gisReferenceType))
                //    BindBaseValueLookup(cb, Convert.ToInt64(gisReferenceType), ObjectHACode);
            }
            return CreateUnboundColumn(fieldType, fieldName, Utils.Str(searchFieldRow["FieldCaption"]),
                m_FieldInfo[fieldName].Editor);
        }

        private void BindPivotGrid(AvrPivotGrid pivotGrid, bool createEditors)
        {
            m_FilterControl.SourceControl = pivotGrid;
            using (pivotGrid.BeginTransaction())
            {
                m_FieldInfo.Clear();
                var columns = new QueryFilterColumnCollection(null);
                int i = 1;
                var processedFieldNames = new List<string>();
                foreach (IAvrPivotGridField field in pivotGrid.AvrFields)
                {
                    //do not process non-filter fields
                    if (!field.IsHiddenFilterField)
                    {
                        continue;
                    }
                    //do not process fields copies
                    if (processedFieldNames.Contains(field.Name))
                    {
                        continue;
                    }
                    processedFieldNames.Add(field.Name);

                    UnboundQueryFilterColumn column = CreatePivotGridColumn(i++, field, createEditors);
                    columns.Add(column);
                }
                // ???
                DeleteNodesWithAbsentFields();
                m_FilterControl.SetFilterColumnsCollection(columns);
            }
        }

        private UnboundQueryFilterColumn CreatePivotGridColumn
            (int conditionID, IAvrPivotGridField field, bool createEditors)
        {
            string fieldName = field.Name;

            DataRow fieldRow;
            DataRow paramRow = null;
            SearchFieldType fieldType;
            string caption = field.Caption;
            int pos = fieldName.IndexOf("__", StringComparison.Ordinal);
            if (pos > 0)
            {
                string[] fieldParts = field.GetOriginalName().Split(new[] {"__"}, StringSplitOptions.RemoveEmptyEntries);
                int i = m_SearchFieldsLookupView.Find(fieldParts[0]);
                Dbg.Assert(i >= 0, "search field with alias {0} is not found in lookup table", fieldName);
                paramRow = LookupCache.GetLookupRow(field.GetOriginalName(), LookupTables.ParameterForFFType.ToString());
                object paramType = paramRow["idfsParameterType"];
                object referenceType = paramRow["idfsReferenceType"];
                // Commented because now caption should be taken directrly from the field caption 
                //  caption = Utils.Str(paramRow["ParameterName"]);
                fieldType = !Utils.IsEmpty(referenceType)
                    ? SearchFieldType.ID
                    : ParamType2FieldType(paramType);
                fieldRow = m_SearchFieldsLookupView[i].Row;
            }
            else
            {
                int i = m_SearchFieldsLookupView.Find(field.GetOriginalName());
                Dbg.Assert(i >= 0, "search field with alias {0} is not found in lookup table", fieldName);
                fieldRow = m_SearchFieldsLookupView[i].Row;
                // Commented because now caption should be taken directrly from the field caption 
                //caption = Utils.Str(fieldRow["FieldCaption"]);
                if (IsLookupField(fieldRow))
                {
                    fieldType = SearchFieldType.ID;
                }
                else
                {
                    fieldType = (SearchFieldType) fieldRow["idfsSearchFieldType"];
                    // commented because calendar editor should be used for all datetime fields
//                    if (fieldType == SearchFieldType.Date && interval != PivotGroupInterval.Date)
//                    {
//                        fieldType = interval == PivotGroupInterval.DateDayOfWeek
//                                        ? SearchFieldType.String
//                                        : SearchFieldType.Integer;
//                    }
                }
            }

            m_FieldInfo.Add(fieldName, new FieldInfo(conditionID, caption, null));

            UnboundPivotGridColumn col;

            if (fieldType == SearchFieldType.Date) //field.DataType.Equals(typeof(DateTime))
            {
                col = new UnboundPivotGridColumn(caption, fieldName, typeof (DateTime), DefaultDateEditor,
                    FilterColumnClauseClass.DateTime);
            }
            else
            {
                if (fieldType == SearchFieldType.ID)
                {
                    var cb = new RepositoryItem();
                    if (createEditors)
                    {
                        cb = (paramRow != null)
                            ? GetFFFieldEditor(paramRow, fieldRow, ref fieldType)
                            : GetLookupEditor(fieldRow);
                    }
                    col = new UnboundPivotGridColumn(caption, fieldName, field.DataType, cb,
                        FilterColumnClauseClass.Lookup);
                }
                else
                {
                    var cb = new RepositoryItemTextEdit();
                    col = new UnboundPivotGridColumn(caption, fieldName, field.DataType, cb,
                        FilterColumnClauseClass.String);
                    // Note: Commented by Ivan to change lookup edit to text edit for  all text fields 
                    //                    var cb = new RepositoryItemComboBox();
                    //                    if (createEditors)
                    //                    {
                    //                        field.FilterValues.FilterType = PivotFilterType.Included;
                    //                        field.FilterValues.FilterType = PivotFilterType.Excluded;
                    //
                    //                        string key = queryId.HasValue
                    //                                         ? queryId.Value.ToString(CultureInfo.InvariantCulture)
                    //                                         : string.Empty;
                    //                        key = key + RamPivotGridHelper.GetOriginalNameFromFieldName(field.FieldName);
                    //
                    //                        if (!ValueHash.ContainsKey(key))
                    //                        {
                    //                            ValueHash[key] = field.FilterValues.ValuesIncluded;
                    //                        }
                    //                        cb.Items.AddRange(ValueHash[key]);
                    //
                    //                    }
                    //                    col = new UnboundPivotGridColumn(caption, fieldName, SearchFieldType2Type(fieldType), cb,
                    //                                                     FilterColumnClauseClass.Generic);
                }
            }
            return col;
        }

        #endregion

        public void Flush(CriteriaOperator op, object parentGroupID)
        {
            if (!HasChanges || m_DataSourceType != DataSourceType.Unbound)
            {
                return;
            }
            int order = 0;
            if (ReferenceEquals(op, null))
            {
                op = m_FilterControl.FilterCriteria;
                m_FilterControl.FilterCriteria = op;
                op = m_FilterControl.FilterCriteria;
                FilterChanged(op, new FilterChangedEventArgs(FilterChangedAction.ValueChanged, null));
                m_SearchCriteria.RowFilter = null;
                m_SearchCriteria.Table.Clear();
                //while (m_SearchCriteria.Count > 0)
                //{
                //    m_SearchCriteria[0].Delete();
                //}
                m_SearchCriteria.Table.AcceptChanges();
                parentGroupID = DBNull.Value;
                m_GroupID = -1;
                if (ReferenceEquals(op, null))
                {
                    return;
                }
                DataRow rootRow = QuerySearchObject_DB.InitRootGroupCondition(m_SearchCriteria.Table, m_SearchObjectID);
                if (op is UnaryOperator &&
                    ((UnaryOperator) op).OperatorType == UnaryOperatorType.Not &&
                    ((UnaryOperator) op).Operand is GroupOperator)
                {
                    if ((((UnaryOperator) op).Operand as GroupOperator).OperatorType == GroupOperatorType.Or)
                    {
                        rootRow["blnJoinByOr"] = true;
                    }

                    rootRow["blnUseNot"] = true;
                    rootRow.EndEdit();
                }
                if (op is GroupOperator)
                {
                    if ((op as GroupOperator).OperatorType == GroupOperatorType.Or)
                    {
                        rootRow["blnJoinByOr"] = true;
                        rootRow.EndEdit();
                    }
                }
                m_SearchCriteria = new DataView(m_SearchCriteria.Table);
            }
            else
            {
                m_GroupID--;
            }

            bool useNot = false;
            if ((op is UnaryOperator && ((UnaryOperator) op).OperatorType == UnaryOperatorType.Not &&
                 ((UnaryOperator) op).Operand is GroupOperator) 
                //||
                //op is UnaryOperator && ((UnaryOperator)op).OperatorType == UnaryOperatorType.Not &&
                //((UnaryOperator)op).Operand is FunctionOperator
                )
            {
                op = ((UnaryOperator) op).Operand;
                useNot = true;
            }
            if (!(op is GroupOperator))
            {
                FlushFieldCriteria(op, m_GroupID, parentGroupID, false, useNot, 0);
                return;
            }
            var parentGroupOp = (GroupOperator) op;
            bool useOr = parentGroupOp.OperatorType == GroupOperatorType.Or;
            int groupID = m_GroupID;
            foreach (CriteriaOperator child in parentGroupOp.Operands)
            {
                if (child is UnaryOperator && ((UnaryOperator) child).OperatorType == UnaryOperatorType.Not &&
                    ((UnaryOperator) child).Operand is GroupOperator)
                {
                    //FlushGroupCriteria(child, m_GroupID, useOr, useNot, order++);
                    Flush(child, groupID);
                    continue;
                }
                var groupOp = child as GroupOperator;
                if (ReferenceEquals(groupOp, null))
                {
                    FlushFieldCriteria(child, groupID, parentGroupID, useOr, useNot, order++);
                }
                else
                {
                    // FlushGroupCriteria(groupOp, m_GroupID, useOr, useNot, order++);
                    Flush(groupOp, groupID);
                }
            }
        }

        private int m_GroupID;

        private void FlushFieldCriteria
            (CriteriaOperator node, object groupID, object parentGroupID, bool useOr, bool useNot, int order)
        {
            DataRowView row = m_SearchCriteria.AddNew();
            row["idfQueryConditionGroup"] = groupID;
            row["idfParentQueryConditionGroup"] = parentGroupID;
            row["blnJoinByOr"] = useOr;
            row["blnUseNot"] = useNot;
            row["intOrder"] = order;
            row["idfQuerySearchObject"] = m_SearchObjectID;
            switch (node.GetType().Name)
            {
                case "BinaryOperator":
                    row["strOperator"] = SearchOperator.Binary.ToString();
                    row["intOperatorType"] = ((BinaryOperator) node).OperatorType;
                    row["idfQuerySearchField"] =
                        GetFieldByName(((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName).
                            SearchFieldConditionID;
                    row["varValue"] = ((OperandValue) ((BinaryOperator) node).RightOperand).Value;
                    break;
                case "UnaryOperator":
                    if (((UnaryOperator) node).Operand is OperandProperty)
                    {
                        row["intOperatorType"] = ((UnaryOperator) node).OperatorType;
                        row["strOperator"] = SearchOperator.Unary.ToString();
                        row["idfQuerySearchField"] =
                            GetFieldByName(((OperandProperty) ((UnaryOperator) node).Operand).PropertyName).
                                SearchFieldConditionID;
                    }
                    else if (((UnaryOperator) node).OperatorType == UnaryOperatorType.Not)
                    {
                        node = ((UnaryOperator) node).Operand;
                        if (node is UnaryOperator)
                        {
                            Dbg.Assert(((UnaryOperator) node).Operand is OperandProperty,
                                "field name operand is expected for Not condition, but {0} is received",
                                ((UnaryOperator) node).Operand.ToString());
                            row["blnFieldConditionUseNot"] = 1;
                            row["intOperatorType"] = ((UnaryOperator) node).OperatorType;
                            row["strOperator"] = SearchOperator.Unary.ToString();
                            row["idfQuerySearchField"] =
                                GetFieldByName(((OperandProperty) ((UnaryOperator) node).Operand).PropertyName).
                                    SearchFieldConditionID;
                        }
                        else if (node is BinaryOperator)
                        {
                            row["blnFieldConditionUseNot"] = 1;
                            row["strOperator"] = SearchOperator.Binary.ToString();
                            row["intOperatorType"] = ((BinaryOperator) node).OperatorType;
                            row["idfQuerySearchField"] =
                                GetFieldByName(((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName).
                                    SearchFieldConditionID;
                            row["varValue"] = ((OperandValue) ((BinaryOperator) node).RightOperand).Value;
                        }
                        else if (node is FunctionOperator)
                        {
                            var functionOp = (FunctionOperator) node;
                            string fieldName = ((OperandProperty) functionOp.Operands[0]).PropertyName;
                            row["blnFieldConditionUseNot"] = 1;
                            row["intOperatorType"] = functionOp.OperatorType;
                            row["strOperator"] = SearchOperator.OutlookInterval.ToString();
                            if (functionOp.Operands.Count > 1 && functionOp.Operands[1] is OperandValue)
                            {
                                row["varValue"] = ((OperandValue) functionOp.Operands[1]).Value;
                            }
                            row["idfQuerySearchField"] = GetFieldByName(fieldName).SearchFieldConditionID;
                            break;
                        }
                        else
                        {
                            Dbg.Fail("unexpected operator type {0}", node.ToString());
                        }
                    }
                    break;
                default:
                    if (node is FunctionOperator)
                    {
                        var functionOp = (FunctionOperator) node;
                        string fieldName = ((OperandProperty) functionOp.Operands[0]).PropertyName;
                        row["intOperatorType"] = functionOp.OperatorType;
                        row["strOperator"] = SearchOperator.OutlookInterval.ToString();
                        if (functionOp.Operands.Count > 1 && functionOp.Operands[1] is OperandValue)
                        {
                            row["varValue"] = ((OperandValue) functionOp.Operands[1]).Value;
                        }
                        row["idfQuerySearchField"] = GetFieldByName(fieldName).SearchFieldConditionID;
                        break;
                    }
                    Dbg.Fail("unsupported search operator type: {0}", node.GetType().Name);
                    break;
            }
            row.EndEdit();
        }

        //        private void FlushGroupCriteria(CriteriaOperator node, object parentGroupID, bool useOr, bool useNot, int order)
        //        {
        //            parentGroupID = m_GroupID;
        //            m_GroupID--;
        //            DataRowView row = m_SearchCriteria.AddNew();
        //            row["idfQueryConditionGroup"] = m_GroupID;
        //            row["idfParentQueryConditionGroup"] = parentGroupID;
        //            row["blnJoinByOr"] = useOr;
        //            row["blnUseNot"] = useNot;
        //            row["intOrder"] = order;
        //            row["idfQuerySearchObject"] = m_SearchObjectID;
        //            row["SearchFieldConditionText"] = "()";
        //            row.EndEdit();
        //
        //        }

        public void Refresh()
        {
            if (m_DataSourceType == DataSourceType.Unbound)
            {
                m_SearchCriteria.RowFilter = null;
                for (int i = m_SearchCriteria.Count - 1; i >= 0; i--)
                {
                    DataRowView row = m_SearchCriteria[i];
                    if (row["idfQuerySearchField"] == DBNull.Value ||
                        m_SearchFields.Find(row["idfQuerySearchField"]) < 0)
                    {
                        row.Delete();
                    }
                }
                DeleteNodesWithAbsentFields();
                GenerateColumns();
            }
            else if (m_DataSourceType == DataSourceType.PivotGrid)
            {
                DeleteNodesWithAbsentFields();
            }
        }

        public bool Validate()
        {
            return Validate(true);
        }

        public void UpdateFieldInfo()
        {
            foreach (string fieldName in m_FieldInfo.Keys)
            {
                if (m_FieldInfo[fieldName].SearchFieldConditionID < 0)
                {
                    m_FieldInfo[fieldName].SearchFieldConditionID = GetSearchFieldConditionID(fieldName);
                }
            }
        }

        private long GetSearchFieldConditionID(string fieldName)
        {
            //long fieldID = FieldName2FieldID(fieldName);
            foreach (DataRowView row in m_SearchFields)
            {
                if (!Utils.IsEmpty(row["FieldAlias"]) && row["FieldAlias"].Equals(fieldName))
                {
                    return (long) row["idfQuerySearchField"];
                }
                //if (row["idfsSearchField"].Equals(fieldID))
                //    return (long)row["idfQuerySearchField"];
            }
            Dbg.Fail("invalid search field Name {0}", fieldName);
            return 0;
        }

        public bool Validate(bool showErrorForm)
        {
            PropertyInfo pi = typeof (FilterControl).GetProperty("FocusInfo",
                BindingFlags.Instance |
                BindingFlags.NonPublic);
            var focus = (FilterControlFocusInfo) pi.GetValue(m_FilterControl, null);
            if (focus.Node == null)
            {
                return true;
            }
            INode rootNode = focus.Node;
            while (rootNode.ParentNode != null)
            {
                rootNode = (Node) rootNode.ParentNode;
            }
            return ValidateNode((Node) rootNode, showErrorForm);
        }

        public static string GetFilterTextForPivotGrid(AvrPivotGrid grid)
        {
            using (var filter = new FilterControl())
            {
                using (var helper = new FilterControlHelper(filter, grid, false))
                {
                    return helper.GetFilterText(filter.FilterCriteria, null, Environment.NewLine);
                }
            }
        }

        public static string GetFilterTextForPivotGrid(AvrPivotGrid grid, CriteriaOperator criteria)
        {
            using (var filter = new FilterControl())
            {
                using (var helper = new FilterControlHelper(filter, grid, false))
                {
                    return helper.GetFilterText(criteria, null, Environment.NewLine);
                }
            }
        }

        public static bool CheckPivotGridPrefilter(AvrPivotGrid grid)
        {
            using (var filter = new FilterControl())
            {
                using (var helper = new FilterControlHelper(filter, grid, false))
                {
                    helper.Refresh();

                    if (filter.FilterString != grid.CriteriaString)
                    {
                        grid.Criteria = filter.FilterCriteria;
                        return true;
                    }
                }
            }
            return false;
        }

        public string GetFilterText(CriteriaOperator op, CriteriaOperator fieldOp, string conditionSeparator)
        {
            if (ReferenceEquals(op, null))
            {
                return "";
            }
            switch (op.GetType().Name)
            {
                case "GroupOperator":
                    var groupOp = (GroupOperator) op;
                    string groupText = "";
                    foreach (CriteriaOperator childOp in groupOp.Operands)
                    {
                        if (groupText == "")
                        {
                            groupText = string.Format("{0}", GetFilterText(childOp, null, conditionSeparator));
                        }
                        else
                        {
                            string groupOperatorText = "StringId." + (groupOp.OperatorType == GroupOperatorType.And
                                ? StringId.FilterGroupAnd.ToString()
                                : StringId.FilterGroupOr.ToString());

                            groupText = string.Format("{0} {1}{2}{3}", groupText,
                                XtraStrings.Get(groupOperatorText, groupOperatorText),
                                conditionSeparator,
                                GetFilterText(childOp, null, conditionSeparator));
                        }
                    }
                    return groupOp.Operands.Count == 1 ? groupText : string.Format("({0})", groupText);
                case "UnaryOperator":
                    var unaryOp = (UnaryOperator) op;
                    string unaryOpType =
                        XtraStrings.Get("StringId.FilterCriteriaToStringUnaryOperator" + unaryOp.OperatorType, null);
                    return unaryOp.OperatorType == UnaryOperatorType.IsNull
                        ? string.Format("{1} {0}", unaryOpType,
                            GetFilterText(unaryOp.Operand, null, conditionSeparator))
                        : string.Format("{0} {1}", unaryOpType,
                            GetFilterText(unaryOp.Operand, null, conditionSeparator));
                case "BinaryOperator":
                    var binaryOp = (BinaryOperator) op;
                    string opType =
                        XtraStrings.Get("StringId.FilterCriteriaToStringBinaryOperator" + binaryOp.OperatorType, null);
                    return string.Format("{0} {1} {2}", GetFilterText(binaryOp.LeftOperand, null, conditionSeparator),
                        opType,
                        GetFilterText(binaryOp.RightOperand, binaryOp.LeftOperand, conditionSeparator));
                case "OperandProperty":
                    var opField = (OperandProperty) op;
                    return GetOperandPropertyText(opField);
                case "OperandValue":
                case "ConstantValue":
                    return GetOperandValueText(fieldOp, (OperandValue) op);
                case "AggregateOperand":
                    var aggrOp = (AggregateOperand) op;
                    string existText =
                        XtraStrings.Get("StringId.FilterAggregateExists", null);
                    return string.Format("{0} {1}", GetFilterText(aggrOp.AggregatedExpression, null, conditionSeparator),
                        existText);
                default:
                    if (op is FunctionOperator)
                    {
                        var functionOp = (FunctionOperator) op;
                        string functionOpType =
                            functionOp.OperatorType == FunctionOperatorType.Contains
                                ? XtraStrings.Get("StringId.FilterClauseContains", null)
                                : XtraStrings.Get("StringId.FilterCriteriaToStringFunction" + functionOp.OperatorType, null);
                        if (functionOp.Operands.Count == 2)
                        {
                            return string.Format("{0} {1} {2}", GetOperandPropertyText((OperandProperty) functionOp.Operands[0]),
                                functionOpType, functionOp.Operands[1]);
                        }
                        return string.Format("{0} {1}", GetOperandPropertyText((OperandProperty) functionOp.Operands[0]),
                            functionOpType);
                    }
                    Dbg.Fail("unexpected criteria operator {0}", op.GetType().Name);
                    break;
            }
            return "";
        }

        private string GetOperandPropertyText(OperandProperty op)
        {
            string caption = op.PropertyName;
            if (m_FilterControl.SourceControl is PivotGridControl)
            {
                PivotGridField field = GetPivotGridField((m_FilterControl.SourceControl as PivotGridControl), caption);
                if (field != null)
                {
                    caption = field.Caption;
                }
            }
            else
            {
                string fieldName = op.PropertyName.StartsWith("field") ? op.PropertyName.Substring(5) : op.PropertyName;
                if (m_FieldInfo.ContainsKey(caption))
                {
                    caption = m_FieldInfo[caption].Caption;
                }
                else if (m_FieldInfo.ContainsKey(fieldName))
                {
                    caption = m_FieldInfo[fieldName].Caption;
                }
            }
            return string.Format("[{0}]", caption);
        }

        //private string GetPivotFieldTextValue(string fieldName, object value)
        //{
        //    if (Utils.IsEmpty(value))
        //        return "";
        //    int pos = fieldName.IndexOf("__");
        //    DataRow paramRow = null;
        //    DataRow fieldRow = null;
        //    bool isLookup = false;
        //    if (pos > 0)
        //    {
        //        string[] fieldParts = fieldName.Split(new string[] { "__" }, StringSplitOptions.RemoveEmptyEntries);
        //        int i = m_SearchFieldsLookupView.Find(fieldParts[0]);
        //        Dbg.Assert(i >= 0, "search field with alias {0} is not found in lookup table", fieldName);
        //        paramRow = LookupCache.GetLookupRow(fieldName, LookupTables.ParameterForFFType.ToString());
        //        object paramType = paramRow["idfsParameterType"];
        //        object referenceType = paramRow["idfsReferenceType"];
        //        isLookup = !Utils.IsEmpty(referenceType);
        //        fieldRow = m_SearchFieldsLookupView[i].Row;
        //    }
        //    else
        //    {
        //        int i = m_SearchFieldsLookupView.Find(fieldName);
        //        Dbg.Assert(i >= 0, "search field with alias {0} is not found in lookup table", fieldName);
        //        fieldRow = m_SearchFieldsLookupView[i].Row;
        //        isLookup = IsLookupField(fieldRow);
        //    }
        //    if(isLookup)
        //    {
        //        object referenceType = null;
        //        object gisReferenceType = null;
        //        object lookupType = null;
        //        object paramType = null;
        //        if (paramRow != null)
        //        {
        //            paramType = paramRow["idfsParameterType"];
        //            referenceType = paramRow["idfsReferenceType"];
        //        }
        //        else
        //        {
        //            referenceType = LookupCache.GetLookupValue(fieldRow["idfsSearchField"], LookupTables.SearchField, "idfsReferenceType");
        //            gisReferenceType = LookupCache.GetLookupValue(fieldRow["idfsSearchField"], LookupTables.SearchField, "idfsGISReferenceType");
        //            lookupType = LookupCache.GetLookupValue(fieldRow["idfsSearchField"], LookupTables.SearchField, "strLookupTable");
        //        }
        //        if (!Utils.IsEmpty(paramType))
        //            return GetFFPresetLookupValue(paramType, value);
        //        else if (!Utils.IsEmpty(lookupType))
        //            return GetSpecialLookupValue(lookupType, value);
        //        else if (!Utils.IsEmpty(referenceType))
        //            return GetBaseLookupValue(referenceType, value);
        //        else if (!Utils.IsEmpty(gisReferenceType))
        //            return GetGisLookupValue(value);

        //    }
        //    return Utils.Str(value);
        //}

        //private static string GetGisLookupValue( object value)
        //{
        //    if (Utils.IsEmpty(value))
        //        return "";
        //    return LookupCache.GetLookupValue(Convert.ChangeType(value, typeof(Int64)), LookupTables.AVRGIS, "ExtendedName");
        //}

        //private static string GetBaseLookupValue(object type, object value)
        //{
        //    return LookupCache.GetLookupValue(Convert.ChangeType(value, typeof(Int64)), (BaseReferenceType)type, "Name");
        //}

        //private static string GetSpecialLookupValue(object type, object value)
        //{
        //    LookupTables lookupType = (LookupTables)Enum.Parse(typeof(LookupTables), Utils.Str(type));
        //    switch (lookupType)
        //    { 
        //        case LookupTables.Country:
        //        case LookupTables.Region:
        //        case LookupTables.Rayon:
        //        case LookupTables.Settlement:
        //            return GetGisLookupValue(value);
        //        default:
        //            return LookupCache.GetLookupValue(Convert.ChangeType(value, typeof(Int64)), (LookupTables)Enum.Parse(typeof(LookupTables), Utils.Str(type)), "Name");
        //    }
        //}

        //private static string GetFFPresetLookupValue(object type, object value)
        //{
        //    return LookupCache.GetLookupValue(Convert.ChangeType(value, typeof(Int64)), LookupTables.ParametersFixedPresetValue, "Name");
        //}

        private string GetOperandValueText(CriteriaOperator opField, OperandValue opValue)
        {
            if (!ReferenceEquals(opField, null))
            {
                var opFieldName = opField as OperandProperty;
                if (!ReferenceEquals(opFieldName, null))
                {
                    RepositoryItemLookUpEdit editor = GetFieldLookupEditor(opFieldName.PropertyName);
                    if (editor != null)
                    {
                        var dv =
                            (DataView)
                                editor.DataSource;
                        if (dv == null)
                        {
                            return "";
                        }
                        string displayMember =
                            editor.DisplayMember;
                        string valueMember =
                            editor.ValueMember;
                        string savedFilter = dv.RowFilter;
                        long value = -1;
                        if (!Utils.IsEmpty(opValue.Value))
                        {
                            value = (long) Convert.ChangeType(opValue.Value, typeof (long));
                        }
                        dv.RowFilter = string.Format("{0}={1}", valueMember,
                            value);
                        string val = Utils.Str(opValue.Value);
                        if (dv.Count == 1)
                        {
                            val = Utils.Str(dv[0][displayMember]);
                        }
                        dv.RowFilter = savedFilter;
                        return string.Format("'{0}'", val);
                    }
                }
            }
            //if (m_DataSourceType == DataSourceType.PivotGrid)
            //    return string.Format("'{0}'", GetPivotFieldTextValue(((OperandProperty)opField).PropertyName, opValue.Value));
            if (opValue.Value is string)
            {
                return string.Format("'{0}'", opValue.Value);
            }
            if (opValue.Value is DateTime)
            {
                return ((DateTime) opValue.Value).ToString("d");
            }
            return opValue.LegacyToString();
        }

        private RepositoryItemLookUpEdit GetFieldLookupEditor(string fieldName)
        {
            if (m_FieldInfo.ContainsKey(fieldName) && m_FieldInfo[fieldName].Editor is RepositoryItemLookUpEdit)
            {
                return (RepositoryItemLookUpEdit) m_FieldInfo[fieldName].Editor;
            }
            if (m_FilterControl.SourceControl is PivotGridControl)
            {
                PivotGridField field = GetPivotGridField((m_FilterControl.SourceControl as PivotGridControl), fieldName);
                if ((field != null) && (field.Area != PivotArea.DataArea))
                {
                    return field.FieldEdit as RepositoryItemLookUpEdit;
                }
            }
            return null;
        }

        private static PivotGridField GetPivotGridField(PivotGridControl grid, string fieldName)
        {
            PivotGridField field = grid.Fields.GetFieldByName(fieldName);
            if (field == null && fieldName.StartsWith("field"))
            {
                field = grid.Fields.GetFieldByName(fieldName.Substring("field".Length));
            }
            return field;
        }

        private static IAvrPivotGridField GetWinPivotGridField(PivotGridControl grid, string fieldName)
        {
            return (IAvrPivotGridField) GetPivotGridField(grid, fieldName);
        }

        #endregion

        #region Public Properties

        public string FilterString
        {
            get { return GetFilterText(m_FilterControl.FilterCriteria, null, " "); }
            // (m_FilterControl == null) ? "" : m_FilterControl.FilterString;
        }

        public string[] FilterLines
        {
            get { return GetFilterText(m_FilterControl.FilterCriteria, null, "\r").Split('\r'); }
            // (m_FilterControl == null) ? "" : m_FilterControl.FilterString;
        }

        private bool m_HasChanges;

        public bool HasChanges
        {
            get { return m_HasChanges; }
            set { m_HasChanges = value; }
        }

        private HACode m_ObjectHACode = HACode.None;

        public HACode ObjectHACode
        {
            get { return m_ObjectHACode; }
            set
            {
                if (m_ObjectHACode != value)
                {
                    m_ObjectHACode = value;
                    Bind(m_SearchObjectID, m_SearchFields, m_SearchCriteria);
                }
            }
        }

        #endregion

        #region Private Methods

        private static void RemoveAdditionalButtons(RepositoryItemButtonEdit cb)
        {
            for (int i = cb.Buttons.Count - 1; i >= 0; i--)
            {
                if (cb.Buttons[i].Kind == ButtonPredefines.Plus)
                {
                    cb.Buttons.RemoveAt(i);
                    break;
                }
            }
        }

        private void BindSpecialLookup(RepositoryItemLookUpEdit cb, string type)
        {
            string valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsReference";
            switch (type)
            {
                case "Country":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "ExtendedName" : "idfsReference";
                    if (m_ValueHash[GisRefereneceType.Country] == null)
                    {
                        m_ValueHash[GisRefereneceType.Country] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Country,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Country, valueMember,
                            m_ValueHash[GisRefereneceType.Country]);
                    }
                    break;
                case "Region":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "ExtendedName" : "idfsReference";
                    if (m_ValueHash[GisRefereneceType.Region] == null)
                    {
                        m_ValueHash[GisRefereneceType.Region] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Region,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Region, valueMember,
                            m_ValueHash[GisRefereneceType.Region]);
                    }

                    break;
                case "Rayon":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "ExtendedName" : "idfsReference";
                    if (m_ValueHash[GisRefereneceType.Rayon] == null)
                    {
                        m_ValueHash[GisRefereneceType.Rayon] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Rayon,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Rayon, valueMember,
                            m_ValueHash[GisRefereneceType.Rayon]);
                    }
                    break;
                case "Settlement":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "ExtendedName" : "idfsReference";
                    if (m_ValueHash[GisRefereneceType.Settlement] == null)
                    {
                        m_ValueHash[GisRefereneceType.Settlement] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Settlement,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Settlement, valueMember,
                            m_ValueHash[GisRefereneceType.Settlement]);
                    }
                    break;
                case "Organization":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfInstitution";
                    LookupBinder.BindOrganizationRepositoryLookup(cb, valueMember, 0 /*ObjectHACode*/);
                    cb.ValueMember = valueMember; // "idfsOffice_Name";
                    break;
                case "Site":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "strSiteName" : "idfsOfficeAbbreviation";
                    LookupBinder.BindSiteRepositoryLookup(cb);
                    cb.ValueMember = valueMember; // "idfsOfficeAbbreviation";
                    break;
                case "AnimalAgeList":
                    LookupBinder.BindAnimalAgeRepositoryLookup(cb, false);
                    cb.ValueMember = valueMember;
                    break;
                case "HumanStandardDiagnosis":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosis";
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.HumanStandardDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "HumanVetDiagnoses":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosis";
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.HumanVetDiagnoses, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "VetStandardDiagnosis":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosis";
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.VetStandardDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "PensideTestType":
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftPensideTestType, false);
                    cb.ValueMember = valueMember;
                    break;
                case "TestResult":
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftTestResult, false);
                    cb.ValueMember = valueMember;
                    break;
                    //case "VetCaseType":
                    //    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.VetCaseType, false);
                    //    cb.ValueMember = valueMember;
                    //    break;

                case "CaseType":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.CaseType, false);
                    cb.ValueMember = valueMember;
                    break;

                case "FinalCaseClassification":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.FinalCaseClassification, false);
                    cb.ValueMember = valueMember;
                    break;

                case "InitialCaseClassification":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.InitialCaseClassification, false);
                    cb.ValueMember = valueMember;
                    break;
                case "ZoonoticDiagnosis":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosis";
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.ZoonoticDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "CDCAgeGroup":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.CDCAgeGroup, false);
                    cb.ValueMember = valueMember;
                    break;
                case "WHOAgeGroup":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.WHOAgeGroup, false);
                    cb.ValueMember = valueMember;
                    break;
                case "DiagnosisAgeGroup":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.DiagnosisAgeGroup, false);
                    cb.ValueMember = valueMember;
                    break;
                case "DiagnosesAndGroups":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosisOrDiagnosisGroup";
                    LookupBinder.BindDiagnosisAndGroupsRepositoryLookup(cb, false);
                    cb.ValueMember = valueMember;
                    break;
                case "AccessoryCode":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "CodeName" : "intHACode";
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.AccessoryCode, false, valueMember);
                    break;
                case "HumanAggregateCaseParameter":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.HumanAggregateCaseParameter, false, valueMember);
                    break;
                case "VectorSubType":
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftVectorSubType, false);
                    break;
                case "HumanAggregatedDiagnosis":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosis";
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.HumanAggregatedDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "VectorDiagnosis":
                    valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsDiagnosis";
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.VectorDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                default:
                    Dbg.Fail("unsupported lookup type ({0}) for filter editor", type);
                    break;
            }

            if (cb != null)
            {
                RemoveAdditionalButtons(cb);
            }
        }

        private void BindBaseValueLookup(RepositoryItemLookUpEdit cb, long refType, HACode haCode)
        {
            //Dbg.Assert(refType != DBNull.Value, "reference type is not defined for lookup field");
            string valueMember = m_DataSourceType == DataSourceType.PivotGrid ? "name" : "idfsReference";
            LookupBinder.BindBaseRepositoryLookup(cb, (BaseReferenceType) refType, haCode, false);
            cb.ValueMember = valueMember;
            var dvValue = (DataView) cb.DataSource;
            dvValue.Sort = "name";
        }

        private void AddNoneLookupValue(RepositoryItemLookUpEditBase cb, string pkFieldName)
        {
            //None value is not needed in v5
            //var dataView = (DataView)cb.DataSource;
            ////if (String.IsNullOrEmpty(dataView.RowFilter))
            ////    dataView.RowFilter = string.Format("{0} <> {1}", pkFieldName, LookupCache.EmptyLineKey);
            ////else
            ////    dataView.RowFilter = string.Format("({0}) and ({1} <> {2})", dataView.RowFilter, pkFieldName, LookupCache.EmptyLineKey);
            //if (dataView.Count > 0 && dataView[0][pkFieldName].Equals(LookupCache.EmptyLineKey))
            //    dataView.Delete(0);
            //if (m_DataSourceType != DataSourceType.PivotGrid)
            //{
            //    return;
            //}

            //DataRowView viweRow = dataView.AddNew();
            //DataRow noneRow = viweRow.Row;

            //noneRow[cb.DisplayMember] = LookupCache.GetLookupValue(10044002, BaseReferenceType.rftInformationString,
            //                                                       "name");
            //noneRow[pkFieldName] = -10000;
            //foreach (DataColumn col in dataView.Table.Columns)
            //{
            //    if (noneRow[col.ColumnName] == DBNull.Value && !col.AllowDBNull && col.DataType == typeof(long))
            //    {
            //        noneRow[col.ColumnName] = -10000;
            //    }
            //}

            /*
             * Old implementation before performance optimization
                        if (m_DataSourceType != DataSourceType.PivotGrid)
                            return;

                        DataTable sourceTable = ((DataView)cb.DataSource).Table;
                        string rowFilter = ((DataView)cb.DataSource).RowFilter;
                        DataTable copyTable = sourceTable.Copy();
                        DataRow noneRow = copyTable.NewRow();




                        noneRow[cb.DisplayMember] = LookupCache.GetLookupValue(10044002, BaseReferenceType.rftInformationString, "Name");
                        noneRow[pkFieldName] = -10000;
                        foreach (DataColumn col in copyTable.Columns)
                        {
                            if (noneRow[col.ColumnName] == DBNull.Value && !col.AllowDBNull && col.DataType == typeof(long))
                            {
                                noneRow[col.ColumnName] = -10000;
                            }
                        }
                        copyTable.Rows.Add(noneRow);
                        cb.DataSource = new DataView(copyTable);
                        ((DataView)cb.DataSource).RowFilter = rowFilter;
                        */
        }

        private void BindFFFixedValueLookup(RepositoryItemLookUpEdit cb, object paramType)
        {
            Dbg.Assert(paramType != DBNull.Value, "parameter type is not defined for FF field");
            string valueMember = m_DataSourceType == DataSourceType.PivotGrid
                ? "NationalName"
                : "idfsParameterFixedPresetValue";
            LookupBinder.BindParametersFixedPresetValueRepositoryLookup(cb, false);
            cb.ValueMember = valueMember;
            AddNoneLookupValue(cb, "idfsParameterFixedPresetValue");
            var dvValue = (DataView) cb.DataSource;
            dvValue.RowFilter = string.Format("idfsParameterType = {0} and idfsParameterFixedPresetValue <> {1} ",
                paramType, LookupCache.EmptyLineKey);
            dvValue.Sort = "NationalName";
        }

        private readonly Dictionary<CriteriaOperator, GroupOperator> m_NodesToDelete =
            new Dictionary<CriteriaOperator, GroupOperator>();

        private void DeleteNodesWithAbsentFields()
        {
            m_NodesToDelete.Clear();
            CriteriaOperator opreatorsCopy = m_FilterControl.FilterCriteria;
            FindInvalidNodes(opreatorsCopy);

            while (m_NodesToDelete.Count > 0)
            {
                foreach (CriteriaOperator op in m_NodesToDelete.Keys)
                {
                    if (ReferenceEquals(m_NodesToDelete[op], null))
                    {
                        opreatorsCopy = null;
                    }
                    else
                    {
                        m_NodesToDelete[op].Operands.Remove(op);
                    }
                }
                m_FilterControl.FilterCriteria = opreatorsCopy;
                FilterChanged(m_FilterControl, new FilterChangedEventArgs(FilterChangedAction.RemoveNode, null));

                m_NodesToDelete.Clear();
                opreatorsCopy = m_FilterControl.FilterCriteria;
                FindInvalidNodes(opreatorsCopy);
            }
        }

        public void FindInvalidNodes(CriteriaOperator op)
        {
            if (ReferenceEquals(op, null))
            {
                return;
            }
            if (op is UnaryOperator && ((UnaryOperator) op).OperatorType == UnaryOperatorType.Not &&
                ((UnaryOperator) op).Operand is GroupOperator)
            {
                op = ((UnaryOperator) op).Operand;
            }
            if (!(op is GroupOperator))
            {
                if ((!IsNodeValid(op)) && (!m_NodesToDelete.ContainsKey(op)))
                {
                    m_NodesToDelete.Add(op, null);
                }
                return;
            }
            var parentGroupOp = (GroupOperator) op;
            foreach (CriteriaOperator child in parentGroupOp.Operands)
            {
                if (child is UnaryOperator && ((UnaryOperator) child).OperatorType == UnaryOperatorType.Not &&
                    ((UnaryOperator) child).Operand is GroupOperator)
                {
                    FindInvalidNodes(child);
                    continue;
                }
                var groupOp = child as GroupOperator;
                if (ReferenceEquals(groupOp, null))
                {
                    if ((!IsNodeValid(child)) && (!m_NodesToDelete.ContainsKey(child)))
                    {
                        m_NodesToDelete.Add(child, parentGroupOp);
                    }
                }
                else
                {
                    FindInvalidNodes(groupOp);
                }
            }
        }

        private bool IsNodeValid(CriteriaOperator node)
        {
            long fieldID = 0;
            if (m_DataSourceType == DataSourceType.Unbound)
            {
                switch (node.GetType().Name)
                {
                    case "BinaryOperator":
                        FieldInfo info =
                            GetFieldByName(((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName);
                        if (info != null)
                        {
                            fieldID = info.SearchFieldConditionID;
                        }
                        break;
                    case "UnaryOperator":
                        if (((UnaryOperator) node).Operand is OperandProperty)
                        {
                            info =
                                GetFieldByName(((OperandProperty) ((UnaryOperator) node).Operand).PropertyName);
                            if (info != null)
                            {
                                fieldID = info.SearchFieldConditionID;
                            }
                        }
                        else
                        {
                            return IsNodeValid(((UnaryOperator) node).Operand);
                        }
                        break;
                    case "FunctionOperator":
                        info =
                            GetFieldByName(((OperandProperty) ((FunctionOperator) node).Operands[0]).PropertyName);
                        if (info != null)
                        {
                            fieldID = info.SearchFieldConditionID;
                        }
                        break;
                    default:
                        Dbg.Fail("unsupported search operator type: {0}", node.GetType().Name);
                        break;
                }
                return m_SearchFields.Find(fieldID) >= 0;
            }
            if (m_DataSourceType == DataSourceType.PivotGrid)
            {
                string fieldName = "";
                switch (node.GetType().Name)
                {
                    case "BinaryOperator":
                        fieldName = ((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName;
                        break;
                    case "UnaryOperator":
                        if (((UnaryOperator) node).Operand is OperandProperty)
                        {
                            fieldName = ((OperandProperty) ((UnaryOperator) node).Operand).PropertyName;
                        }
                        else
                        {
                            return IsNodeValid(((UnaryOperator) node).Operand);
                        }
                        break;
                    default:
                        if (node is FunctionOperator)
                        {
                            var functionOp = (FunctionOperator) node;
                            fieldName = ((OperandProperty) functionOp.Operands[0]).PropertyName;
                            break;
                        }
                        Dbg.Fail("unsupported search operator type: {0}", node.GetType().Name);
                        break;
                }

                PivotGridField field = GetPivotGridField(m_PivotGrid, fieldName);
                return (field != null) &&
                       (field.Area != PivotArea.DataArea);
                // following commented code removes datetime fields from the filter when group interval changes
                //&&   (!field.DateGroupIntervalChanging || field.FieldDataType != typeof (DateTime));
            }
            return true;
        }

        private string GetFieldNameByFieldConditionID(long fieldConditionID)
        {
            foreach (string name in m_FieldInfo.Keys)
            {
                if (m_FieldInfo[name].SearchFieldConditionID == fieldConditionID)
                {
                    return name;
                }
            }
            return "";
        }

        private static SearchFieldType ParamType2FieldType(object paramType)
        {
            if (paramType == DBNull.Value)
            {
                return SearchFieldType.String;
            }
            switch ((long) paramType)
            {
                case (long) ParameterType.Boolean:
                    return SearchFieldType.Bit;
                case (long) ParameterType.Date:
                case (long) ParameterType.DateTime:
                    return SearchFieldType.Date;
                case (long) ParameterType.Numeric:
                    return SearchFieldType.Float;
                case (long) ParameterType.NumericInteger:
                case (long) ParameterType.NumericNatural:
                case (long) ParameterType.NumericPositive:
                    return SearchFieldType.Integer;
                default:
                    return SearchFieldType.String;
            }
        }

        private static Type SearchFieldType2Type(SearchFieldType fieldType)
        {
            switch (fieldType)
            {
                case SearchFieldType.Bit:
                    return typeof (bool);
                case SearchFieldType.Date:
                    return typeof (DateTime);
                case SearchFieldType.Float:
                    return typeof (double);
                case SearchFieldType.Integer:
                    return typeof (long);
                default:
                    return typeof (string);
            }
        }

        private static bool IsLookupField(DataRow searchFieldRow)
        {
            return !Utils.IsEmpty(searchFieldRow["idfsReferenceType"]) |
                   !Utils.IsEmpty(searchFieldRow["idfsGISReferenceType"]) |
                   !Utils.IsEmpty(searchFieldRow["strLookupTable"]);
        }

        private static void LookupEditor_Enter(object sender, EventArgs e)
        {
            ((LookUpEdit) sender).Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private FieldInfo GetFieldByName(string fieldName)
        {
            if (m_FieldInfo.ContainsKey((fieldName)))
            {
                return m_FieldInfo[fieldName];
            }
            return null;
        }

        private bool ValidateNode(Node node, bool showErrorMessage)
        {
            if (node is ClauseNode)
            {
                if (Utils.IsEmpty(((ClauseNode) node).FirstOperand.PropertyName))
                {
                    const string err = @"Filter criteria field name can't be empty";
                    if (BaseSettings.ThrowExceptionOnError)
                    {
                        throw new AvrException(err);
                    }

                    ErrorForm.ShowError("ErrUndefinedFilterField", err);
                    PropertyInfo pi = typeof (FilterControl).GetProperty("FocusInfo",
                        BindingFlags.Instance |
                        BindingFlags.NonPublic);
                    pi.SetValue(m_FilterControl, new FilterControlFocusInfo(node, 1), null);
                    return false;
                }
                foreach (CriteriaOperator op in ((ClauseNode) node).AdditionalOperands)
                {
                    if (ValidateOperator(op) == false)
                    {
                        if (showErrorMessage)
                        {
                            string fieldCaption = GetFieldByName(((ClauseNode) node).FirstOperand.PropertyName).Caption;
                            string err = string.Format("Filter criteria value for [{0}] field can't be empty",
                                fieldCaption);
                            if (BaseSettings.ThrowExceptionOnError)
                            {
                                throw new AvrException(err);
                            }

                            ErrorForm.ShowWarningFormat("ErrFilterValidatioError", "Filter criteria value for [{0}] field can't be empty",
                                fieldCaption);

                            PropertyInfo pi = typeof (FilterControl).GetProperty("FocusInfo",
                                BindingFlags.Instance |
                                BindingFlags.NonPublic);
                            pi.SetValue(m_FilterControl, new FilterControlFocusInfo(node, 2), null);
                        }
                        return false;
                    }
                }
                return true;
            }
            var groupNode = node as GroupNode;
            if (groupNode != null)
            {
                IEnumerable<Node> nodes = (groupNode).SubNodes.Cast<Node>();
                return nodes.All(child => ValidateNode(child, showErrorMessage));
            }
            return true;
        }

        private static bool ValidateOperator(CriteriaOperator op)
        {
            if (op is GroupOperator)
            {
                CriteriaOperatorCollection operands = ((GroupOperator) op).Operands;
                return operands.All(ValidateOperator);
            }
            if (op is UnaryOperator)
            {
                return ValidateOperator(((UnaryOperator) op).Operand);
            }
            if (op is BinaryOperator)
            {
                return ValidateOperator(((BinaryOperator) op).RightOperand);
            }
            if (op is OperandValue)
            {
                return !Utils.IsEmpty(((OperandValue) op).Value);
            }
            return true;
        }

        private static void InitSearchFieldsLookupView()
        {
            DataTable table = LookupCache.Get(LookupTables.SearchField).Table.Copy();
            table.PrimaryKey = new DataColumn[0]; //new[] { table.Columns["idfsSearchField"], table.Columns["strSearchFieldAlias"] };
            DataTable copyTable = table.Copy();
            table.BeginLoadData();
            foreach (DataRow row in copyTable.Rows)
            {
                row["strSearchFieldAlias"] = row["strSearchFieldAlias"] + QueryHelper.CopySuffix;
                table.ImportRow(row);
            }
            table.EndLoadData();
            m_SearchFieldsLookupView = new DataView(table) {Sort = "strSearchFieldAlias"};
        }

        #endregion

        #region Events

        public event FilterChangedEventHandler OnFilterChanged;

        private void FilterChanged(object sender, FilterChangedEventArgs e)
        {
            bool shouldRefresh = false;
            if (e.Action == FilterChangedAction.AddNode && e.CurrentNode is ClauseNode) //AddConditionNode
            {
                if (e.CurrentNode != null)
                {
                    ((ClauseNode) e.CurrentNode).Operation = ClauseType.Equals;
                    shouldRefresh = true;
                }
            }
            if (e.Action == FilterChangedAction.FieldNameChange)
            {
                if (e.CurrentNode != null)
                {
                    foreach (CriteriaOperator op in ((ClauseNode) e.CurrentNode).AdditionalOperands)
                    {
                        var operandValue = op as OperandValue;
                        if (!ReferenceEquals(operandValue, null))
                        {
                            (operandValue).Value = null;
                        }
                    }
                    //TODO(mike): find how to correct this
                    //if(!((ClauseNode)e.CurrentNode).Column.IsValidClause(((ClauseNode)e.CurrentNode).Operation))
                    //    ((ClauseNode)e.CurrentNode).Operation = ClauseType.Equals;
                    shouldRefresh = true;
                }
            }
            if (e.Action == FilterChangedAction.ValueChanged)
            {
                if (e.CurrentNode != null)
                {
                    foreach (CriteriaOperator op in ((ClauseNode) e.CurrentNode).AdditionalOperands)
                    {
                        if (op is OperandValue && ((OperandValue) op).Value != null
                            && Utils.Str(((OperandValue) op).Value) == "")
                        {
                            ((OperandValue) op).Value = null;
                        }
                    }
                    shouldRefresh = true;
                }
            }

            if (shouldRefresh)
            {
                //TODO (Mike): is it needed here now?
                ((FilterControl) sender).Model.RebuildElements(); // RefreshNodes();
            }
            FilterChangedEventHandler handler = OnFilterChanged;
            if (handler != null)
            {
                handler(sender, e);
                m_HasChanges = true;
            }
        }

        #endregion

        #region For Refactoring

        private CriteriaOperator m_FilterCriteria;

        private CriteriaOperator InitSearchCriteria(long parentSearchGroup, GroupOperator parentOperator)
        {
            long searchGroup;
            GroupOperator groupOperator;
            if (ReferenceEquals(parentOperator, null)) // Select data for root conditions
            {
                m_FilterCriteria = null;
                m_SearchCriteria.RowFilter = "idfParentQueryConditionGroup is Null";
                if (m_SearchCriteria.Count == 0)
                {
                    return m_FilterCriteria;
                }
                groupOperator = AddGroupOperator(m_SearchCriteria[0], null, ref m_FilterCriteria);
                searchGroup = (long) m_SearchCriteria[0]["idfQueryConditionGroup"];
            }
            else //select data for child conditions
            {
                m_SearchCriteria.RowFilter = string.Format("idfParentQueryConditionGroup = {0}", parentSearchGroup);
                if (m_SearchCriteria.Count == 0)
                {
                    return m_FilterCriteria;
                }
                CriteriaOperator op = null;
                groupOperator = AddGroupOperator(m_SearchCriteria[0], parentOperator, ref op);
                searchGroup = (long) m_SearchCriteria[0]["idfQueryConditionGroup"];
            }
            foreach (DataRowView row in m_SearchCriteria)
            {
                if ((long) row["idfQueryConditionGroup"] != searchGroup)
                {
                    InitSearchCriteria(searchGroup, groupOperator);
                    CriteriaOperator tmp = null;
                    groupOperator = AddGroupOperator(row, parentOperator, ref tmp);
                    searchGroup = (long) row["idfQueryConditionGroup"];
                }
                if (row["strOperator"] == DBNull.Value || row["idfQuerySearchField"] == DBNull.Value ||
                    m_SearchFields.Find(row["idfQuerySearchField"]) < 0)
                {
                    continue; //if row contains no field condition process the next row in the group 
                }
                SearchOperator op;
                try
                {
                    op = (SearchOperator) Enum.Parse(typeof (SearchOperator), row["strOperator"].ToString());
                }
                catch (Exception ex)
                {
                    Dbg.Debug("search operator is not parsed: {0}", ex.ToString());
                    continue;
                }
                string fieldName = GetFieldNameByFieldConditionID((long) row["idfQuerySearchField"]);
                switch (op)
                {
                    case SearchOperator.Binary:
                        if (row["blnFieldConditionUseNot"] == DBNull.Value ||
                            ((bool) row["blnFieldConditionUseNot"]) == false)
                        {
                            groupOperator.Operands.Add(new BinaryOperator(fieldName, row["varValue"],
                                (BinaryOperatorType) row["intOperatorType"]));
                        }
                        else
                        {
                            groupOperator.Operands.Add(new NotOperator(new BinaryOperator(fieldName, row["varValue"],
                                (BinaryOperatorType)
                                    row["intOperatorType"])));
                        }
                        break;
                    case SearchOperator.Unary:
                        if (row["blnFieldConditionUseNot"] == DBNull.Value ||
                            ((bool) row["blnFieldConditionUseNot"]) == false)
                        {
                            groupOperator.Operands.Add(new UnaryOperator((UnaryOperatorType) row["intOperatorType"],
                                fieldName));
                        }
                        else
                        {
                            groupOperator.Operands.Add(
                                new NotOperator(new UnaryOperator((UnaryOperatorType) row["intOperatorType"], fieldName)));
                        }
                        break;
                    case SearchOperator.OutlookInterval:
                        if (row["blnFieldConditionUseNot"] == DBNull.Value || ((bool) row["blnFieldConditionUseNot"]) == false)
                        {
                            if (row["varValue"] == DBNull.Value)
                            {
                                groupOperator.Operands.Add(
                                    new FunctionOperator((FunctionOperatorType) row["intOperatorType"],
                                        new CriteriaOperator[] {new OperandProperty(fieldName)}));
                            }
                            else
                            {
                                groupOperator.Operands.Add(
                                    new FunctionOperator((FunctionOperatorType) row["intOperatorType"],
                                        new CriteriaOperator[]
                                        {
                                            new OperandProperty(fieldName),
                                            new OperandValue(row["varValue"].ToString())
                                        }));
                            }
                        }
                        else
                        {
                            if (row["varValue"] == DBNull.Value)
                            {
                                groupOperator.Operands.Add(
                                    new NotOperator(new FunctionOperator((FunctionOperatorType) row["intOperatorType"],
                                        new CriteriaOperator[] {new OperandProperty(fieldName)})));
                            }
                            else
                            {
                                groupOperator.Operands.Add(
                                    new NotOperator(new FunctionOperator((FunctionOperatorType) row["intOperatorType"],
                                        new CriteriaOperator[]
                                        {
                                            new OperandProperty(fieldName),
                                            new OperandValue(row["varValue"].ToString())
                                        })));
                            }
                        }
                        break;

                    case SearchOperator.Group:
                        break;
                }
            }
            if (parentSearchGroup != searchGroup)
            {
                InitSearchCriteria(searchGroup, groupOperator);
            }
            return m_FilterCriteria;
        }

        private static GroupOperator AddGroupOperator
            (DataRowView criteriaRow, GroupOperator parentOperator, ref CriteriaOperator rootOperator)
        {
            var groupOperator = new GroupOperator();
            rootOperator = groupOperator;
            if (criteriaRow["blnJoinByOr"] != DBNull.Value && (bool) criteriaRow["blnJoinByOr"])
            {
                groupOperator.OperatorType = GroupOperatorType.Or;
            }
            if (criteriaRow["blnUseNot"] != DBNull.Value && (bool) criteriaRow["blnUseNot"])
            {
                rootOperator = new NotOperator(groupOperator);
            }
            if (!ReferenceEquals(parentOperator, null))
            {
                parentOperator.Operands.Add(rootOperator);
            }
            return groupOperator;
        }

        #endregion

        //public string GetFilterText(Node filterNode)
        //{
        //    if (filterNode == null)
        //    {
        //        PropertyInfo pi = typeof(FilterControl).GetProperty("FocusInfo",
        //                                                                    BindingFlags.Instance |
        //                                                                    BindingFlags.NonPublic);
        //        FilterControlFocusInfo focus = (FilterControlFocusInfo)pi.GetValue(m_FilterControl, null);
        //        if (focus.Node == null)
        //            return "";
        //        filterNode = focus.Node;
        //        while (filterNode.ParentNode != null)
        //            filterNode = (Node)filterNode.ParentNode;
        //    }
        //    if (filterNode is GroupNode)
        //    {
        //        string groupText = "";
        //        string groupOperatorText = (filterNode as GroupNode).LabelInfo.Text;
        //        foreach (Node node in (filterNode as GroupNode).SubNodes)
        //        {
        //            if (groupText == "")
        //                groupText = string.Format("({0})", GetFilterText(node));
        //            else
        //            {

        //                groupText = string.Format("{0} {1} ({2})", groupText,
        //                                          groupOperatorText, GetFilterText(node));
        //            }

        //        }
        //        return groupText;
        //    }
        //    if (filterNode is ClauseNode)
        //    {
        //        return (filterNode as ClauseNode).LabelInfo.Text;
        //    }
        //    return "";
        //}
    }
}