using System;
using System.Collections.Generic;
using System.Data;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Diagnostics;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using EIDSS;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.QueryBuilder;
using EIDSS.Enums;

namespace eidss.avr.FilterForm
{
    public class QueryFilterControl : FilterControlBase
    {
        private const string HeaderId = " ";
        private const string DetailId = "DetailRowId";
        private const string ParentId = "HeaderRowId";

        //lookup list of all search fields
        private readonly DataView m_SearchFieldsLookup;
        //lookup list of all FF search fields
        private readonly DataView m_FFSearchFieldsLookup;

        //list of columns:idfParentQueryConditionGroup,idfQueryConditionGroup,intOrder,idfQuerySearchObject,blnJoinByOr,blnUseNot,idfQuerySearchFieldCondition,
        //SearchFieldConditionText,strOperator,intOperatorType,idfQuerySearchField,blnFieldConditionUseNot,varValue
        private DataView m_SearchCriteria;

        private DataSet m_QueryDataSet;

        public DataSet QueryDataset
        {
            get { return m_QueryDataSet; }
        }

        //contains the list of query search fields for returned by procedure spAsQuerySearchObject_SelectDetail
        private DataView m_QuerySearchFields;
        private DataView m_SubQuerySearchFields;

        private long m_QuerySearchObjectID;
        private long m_SearchObjectID; //can be changed during root object changing

        public QueryFilterControl()
        {
            FilterChanged += FilterChangedHandler;
            PopupMenuShowing += ShowPopupMenu;
            m_SearchFieldsLookup = LookupCache.Get(LookupTables.SearchField);
            m_FFSearchFieldsLookup = LookupCache.Get(LookupTables.ParameterForFFType);
            if (!WinUtils.IsComponentInDesignMode(this) && !bv.common.Configuration.BaseSettings.ScanFormsMode)
            {
                m_SearchFieldsLookup.Sort = "idfsSearchField";
                m_FFSearchFieldsLookup.Sort = "FieldAlias";
            }
        }

        protected override WinFilterTreeNodeModel CreateModel()
        {
            return new QueryFilterControlModel(this);
        }

        //protected override DevExpress.XtraEditors.Drawing.BaseControlPainter CreatePainter()
        //{
        //    return new QueryFilterControlPainter(this);
        //}

        private void ShowPopupMenu(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == FilterControlMenuType.Column)
            {
                for (int i = e.Menu.Items.Count - 1; i >= 0; i--)
                {
                    if (IsSpecialColumn(e.Menu.Items[i].Caption))
                    {
                        e.Menu.Items.RemoveAt(i);
                    }
                }
            }
            else if (e.MenuType == FilterControlMenuType.Aggregate)
            {
                for (int i = e.Menu.Items.Count - 1; i >= 0; i--)
                {
                    if (!Aggregate.Exists.Equals(e.Menu.Items[i].Tag))
                    {
                        e.Menu.Items.RemoveAt(i);
                    }
                }
            }
        }

        private bool IsSpecialColumn(string columnCaption)
        {
            return columnCaption == HeaderId ||
                   columnCaption == DetailId ||
                   columnCaption == ParentId;
        }

        protected override void Dispose(bool disposing)
        {
            FilterChanged -= FilterChangedHandler;
            base.Dispose(disposing);
        }

        private void OnQueryFilterChanged(object sender, FilterChangedEventArgs e)
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
            RaiseFilterChangedEvent(sender, e);
        }

        public override RepositoryItemLookUpEditBase GetFieldLookupEditor(string fieldNameAlias)
        {
            if (m_FieldInfo.ContainsKey(fieldNameAlias))
            {
                return m_FieldInfo[fieldNameAlias].Editor as RepositoryItemLookUpEditBase;
            }
            return null;
        }

        private FilterDataColumn CreateSearchFieldColumn(long querySearchFieldId, DataRow fieldRow, bool isFlexibleFormField = false)
        {
            //TODO: Add code for search fields connected to FF parameters
            string fieldName = Utils.Str(isFlexibleFormField ? fieldRow["ParameterName"] : fieldRow["FieldCaption"]);

            var fieldType = SearchFieldType.String;
            if (!isFlexibleFormField)
            {
                fieldType = (SearchFieldType) (fieldRow["idfsSearchFieldType"]);
            }
            string fieldNameAlias = Utils.Str(fieldRow["strSearchFieldAlias"]);
            if (isFlexibleFormField)
            {
                fieldNameAlias = Utils.Str(fieldRow["FieldAlias"]);
            }
            if (querySearchFieldId == 0)
            {
                fieldNameAlias = string.Format("{0}_{1}", fieldNameAlias, (long) fieldRow["idfsSearchObject"]);
            }
            if (IsLookupField(fieldRow, isFlexibleFormField))
            {
                fieldType = SearchFieldType.ID;
            }
            var col = new FilterDataColumn(fieldNameAlias, GetDataColumnType(fieldType), fieldNameAlias);
            if (!m_FieldInfo.ContainsKey(fieldNameAlias))
            {
                if (querySearchFieldId == 0) //child search object
                {
                    m_FieldInfo.Add(fieldNameAlias,
                        new FilterFieldInfo((long) fieldRow["idfsSearchField"],
                            (long) fieldRow["idfsSearchObject"], fieldName,
                            GetFilterEditor(fieldRow, isFlexibleFormField)));
                }
                else
                {
                    m_FieldInfo.Add(fieldNameAlias,
                        new FilterFieldInfo(querySearchFieldId, fieldName,
                            GetFilterEditor(fieldRow, isFlexibleFormField)));
                }
                //m_FieldCaption2Alias.Add(fieldName, fieldNameAlias);
            }
            return col;
        }

        private RepositoryItem GetFilterEditor(DataRow fieldRow, bool isFlexibleFormField = false)
        {
            var fieldType = SearchFieldType.FFField;
            if (!isFlexibleFormField)
            {
                fieldType = (SearchFieldType) (fieldRow["idfsSearchFieldType"]);
            }
            if (fieldType == SearchFieldType.FFField)
            {
                string fieldAlias = Utils.Str(fieldRow["FieldAlias"]);
                DataRow paramRow = LookupCache.GetLookupRow(fieldAlias, LookupTables.ParameterForFFType.ToString());
                if ((paramRow != null) && (!Utils.IsEmpty(paramRow["idfsReferenceType"])))
                {
                    return GetFFFieldEditor(paramRow, fieldRow, out fieldType);
                }
                else
                {
                    fieldType = ParamType2FieldType(fieldRow["idfsParameterType"]);
                }
            }
            if ((!isFlexibleFormField) && IsLookupField(fieldRow))
            {
                return GetLookupEditor(fieldRow, GetValueMemberForBaseLookup());
            }
            return GetDefaultEditor(fieldType);
        }

        private Type GetDataColumnType(SearchFieldType fieldType)
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
                    return typeof (int);
                case SearchFieldType.String:
                    return typeof (string);
                case SearchFieldType.ID:
                    return typeof (long);
                default:
                    return typeof (string);
            }
        }

        private void GenerateDatasource(long searchObjectID, DataSet searchQueryDs)
        {
            DataRow[] mainObjectQuerySearchFields =
                searchQueryDs.Tables[QuerySearchObject_DB.tasQuerySearchField].Select(
                    string.Format("idfQuerySearchObject={0} and blnShow = 1", searchObjectID));
            var ds = new DataSet();
            var header = new DataTable("MainTable");
            m_FieldInfo.Clear();
            foreach (DataRow querySearchFieldRow in mainObjectQuerySearchFields)
            {
                DataRow fieldRow;
                bool isFlexibleFormField = false;
                if (
                    m_FFSearchFieldsLookup.Table.Select(string.Format("idfsSearchField = {0}", querySearchFieldRow["idfsSearchField"]))
                        .Length > 0)
                {
                    fieldRow = m_FFSearchFieldsLookup.Table.Rows.Find(querySearchFieldRow["FieldAlias"]);
                    isFlexibleFormField = true;
                }
                else
                {
                    fieldRow = m_SearchFieldsLookup.Table.Rows.Find(querySearchFieldRow["idfsSearchField"]);
                }
                FilterDataColumn col = CreateSearchFieldColumn((long) querySearchFieldRow["idfQuerySearchField"], fieldRow,
                    isFlexibleFormField);
                if (col != null)
                {
                    header.Columns.Add(col);
                }
            }
            header.Columns.Add(HeaderId, typeof (int));
            header.PrimaryKey = new[] {header.Columns[HeaderId]};
            ds.Tables.Add(header);

            DataView detailRows = LookupCache.Get(LookupTables.SearchObjectRelationForSubQuery);
            if ((detailRows != null) && (searchQueryDs.Tables.Contains(QuerySearchObject_DB.tasQuerySearchObject))
                && (searchQueryDs.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows.Count > 0))
            {
                DataRow qsoRow = searchQueryDs.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows.Find(searchObjectID);
                long idfsSearchObject = -1L;
                if ((qsoRow != null) && ((qsoRow["idfsSearchObject"] is long) || (qsoRow["idfsSearchObject"] is int)))
                {
                    idfsSearchObject = (long) qsoRow["idfsSearchObject"];
                }
                detailRows.RowFilter = string.Format("idfsParentSearchObject={0}",
                    idfsSearchObject);
                int i = 1;
                foreach (DataRowView detailRow in detailRows)
                {
                    var detail = new DataTable("DetailTable" + i++);

                    DataRow[] detailSearchFields =
                        m_SearchFieldsLookup.Table.Select(string.Format("idfsSearchObject={0}",
                            detailRow["idfsChildSearchObject"]));
                    foreach (DataRow fieldRow in detailSearchFields)
                    {
                        FilterDataColumn col = CreateSearchFieldColumn(0, fieldRow);
                        if (col != null)
                        {
                            detail.Columns.Add(col);
                        }
                    }
                    detail.Columns.Add(DetailId, typeof (int));
                    detail.Columns.Add(ParentId, typeof (int));
                    detail.PrimaryKey = new[] {detail.Columns[DetailId]};
                    ds.Tables.Add(detail);
                    string detailObjectName = Utils.Str(detailRow["ChildSearchObjectName"]);
                    var rel = new DataRelation(detailObjectName, header.Columns[HeaderId], detail.Columns[ParentId]);
                    ds.Relations.Add(rel);
                }
            }
            SourceControl = header;
        }

        public void Bind(long querySearchObjectID, DataSet queryDs)
        {
            m_QueryDataSet = queryDs;
            m_QuerySearchObjectID = querySearchObjectID;
            m_SearchObjectID =
                Utils.IsEmpty(queryDs.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"])
                    ? -1L
                    : (long) queryDs.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"];
            m_SearchCriteria = new DataView(queryDs.Tables[QuerySearchObject_DB.tasQueryConditionGroup]);
            m_QuerySearchFields = new DataView(queryDs.Tables[QuerySearchObject_DB.tasQuerySearchField])
            {
                Sort = "idfQuerySearchField"
            };
            m_SubQuerySearchFields = new DataView(queryDs.Tables[QuerySearchObject_DB.tasSubquerySearchField])
            {
                Sort = "idfQuerySearchField"
            };
            AllowAggregateEditing = FilterControlAllowAggregateEditing.AggregateWithCondition;
            GenerateDatasource(querySearchObjectID, queryDs);
            foreach (FilterColumn col in FilterColumns)
            {
                if (col.IsList)
                {
                    foreach (FilterColumn childCol in col.Children)
                    {
                        InitFilterColumn(childCol);
                    }
                }
                else
                {
                    InitFilterColumn(col);
                }
            }
            FilterCriteria = null;
            FilterCriteria = InitSearchCriteria();
            //RaiseFilterChangedEvent(this, new FilterChangedEventArgs(FilterChangedAction.ValueChanged, null));
            //HasChanges = false;
        }

        private void InitFilterColumn(FilterColumn col)
        {
            if (!IsSpecialColumn(col.FieldName))
            {
                col.SetColumnEditor(m_FieldInfo[col.FieldName].Editor);
                col.SetColumnCaption(m_FieldInfo[col.FieldName].Caption);
            }
        }

        protected override string GetValueMemberForSpecialLookup(string type)
        {
            switch (type)
            {
                case "Organization":
                    return "idfInstitution";

                case "Site":
                    return "idfsOfficeAbbreviation";
                case "AccessoryCode":
                    return "intHACode";
                case "HumanStandardDiagnosis":
                case "HumanVetDiagnoses":
                case "VetStandardDiagnosis":
                case "ZoonoticDiagnosis":
                case "HumanAggregatedDiagnosis":
                case "VectorDiagnosis":
                    return "idfsDiagnosis";
                case "DiagnosesAndGroups":
                    return "idfsDiagnosisOrDiagnosisGroup";
                case "HumanAggregateCaseParameter":
                    return "idfsParameter";
                default:
                    return base.GetValueMemberForSpecialLookup(type);
            }
        }

        protected override string GetValueMemberForBaseLookup()
        {
            return "idfsReference";
        }

        protected override string GetValueMemberForFFFixedPresetValue()
        {
            return "idfsParameterFixedPresetValue";
        }

        private CriteriaOperator InitSearchCriteria()
        {
            CriteriaOperator rootCriteria = null;
            m_SearchCriteria.RowFilter = "idfParentQueryConditionGroup is Null";
            if (m_SearchCriteria.Count == 0)
            {
                return null;
            }
            GroupOperator groupOperator = AddGroupOperator(m_SearchCriteria[0].Row, null, out rootCriteria);
            InitSearchCriteria((long) m_SearchCriteria[0]["idfQueryConditionGroup"], groupOperator);
            return rootCriteria;
        }

        private CriteriaOperator InitSearchCriteria
            (long parentSearchGroup, GroupOperator parentOperator)
        {
            //select data for child conditions
            DataRow[] rows = m_SearchCriteria.Table.Select(string.Format("idfParentQueryConditionGroup = {0}", parentSearchGroup));
            if (rows.Length == 0)
            {
                return null;
            }
            //GroupOperator groupOperator = parentOperator;
            //long searchGroup = parentSearchGroup;

            foreach (DataRow row in rows)
            {
                if (IsAggregateSearchCriteriaRow(row))
                {
                    string aggregateFieldName =
                        GetAggregateFieldNameByQuerySearchObjectId((long) row["idfSubQuerySearchObject"]);
                    AggregateOperand aggrOp = AddAggregateOperand(parentOperator, aggregateFieldName, row["blnUseNot"]);
                    var searchGroup = (long) row["idfQueryConditionGroup"];
                    CriteriaOperator groupOperator = InitSearchCriteria(searchGroup, null);
                    aggrOp.Condition = groupOperator;
                    continue;
                }
                if (row["idfQueryConditionGroup"] != DBNull.Value && (long) row["idfQueryConditionGroup"] != parentSearchGroup)
                {
                    CriteriaOperator tmp;
                    GroupOperator groupOperator = AddGroupOperator(row, parentOperator, out tmp);
                    InitSearchCriteria((long) row["idfQueryConditionGroup"], groupOperator);
                    //root group ia passed for initalization
                    if (ReferenceEquals(parentOperator, null))
                    {
                        return tmp;
                    }
                }
                if (row["strOperator"] == DBNull.Value || row["idfQuerySearchField"] == DBNull.Value ||
                    (m_QuerySearchFields.Find(row["idfQuerySearchField"]) < 0 &&
                     m_SubQuerySearchFields.Find(row["idfQuerySearchField"]) < 0))
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
                var searchObjectId =
                    (long)
                        (Utils.IsEmpty(row["idfQuerySearchObject"]) ? m_QuerySearchObjectID : row["idfQuerySearchObject"]);
                string fieldName = GetFieldAliasNameByQuerySearchFieldID((long) row["idfQuerySearchField"],
                    searchObjectId);
                AddFieldOperator(parentOperator, fieldName, row["varValue"], op, row["intOperatorType"],
                    row["blnFieldConditionUseNot"]);
            }
            return parentOperator;
        }

        private static bool IsTrue(object condition)
        {
            return (condition != null && condition != DBNull.Value && (bool) condition);
        }

        private static bool IsAggregateSearchCriteriaRow(DataRow row)
        {
            return row != null && SearchOperator.Exists.ToString().Equals(row["strOperator"]) &&
                   row["idfSubQuerySearchObject"] is long;
        }

        private static bool IsGroupCriteriaRow(DataRow row)
        {
            return row != null && !Utils.IsEmpty(row["idfQueryConditionGroup"]);
        }

        public static void AddFieldOperator
            (GroupOperator groupOperator, string fieldName, object fieldValue, SearchOperator op, object operatorType,
                object useNot)
        {
            switch (op)
            {
                case SearchOperator.Binary:
                    if (!IsTrue(useNot))
                    {
                        groupOperator.Operands.Add(new BinaryOperator(fieldName, fieldValue,
                            (BinaryOperatorType) operatorType));
                    }
                    else
                    {
                        groupOperator.Operands.Add(new NotOperator(new BinaryOperator(fieldName, fieldValue,
                            (BinaryOperatorType)
                                operatorType)));
                    }
                    break;
                case SearchOperator.Unary:
                    if (!IsTrue(useNot))
                    {
                        groupOperator.Operands.Add(new UnaryOperator((UnaryOperatorType) operatorType,
                            fieldName));
                    }
                    else
                    {
                        groupOperator.Operands.Add(
                            new NotOperator(new UnaryOperator((UnaryOperatorType) operatorType, fieldName)));
                    }
                    break;
                case SearchOperator.OutlookInterval:
                    if (!IsTrue(useNot))
                    {
                        if (fieldValue == DBNull.Value)
                        {
                            groupOperator.Operands.Add(
                                new FunctionOperator((FunctionOperatorType) operatorType,
                                    new CriteriaOperator[] {new OperandProperty(fieldName)}));
                        }
                        else
                        {
                            groupOperator.Operands.Add(
                                new FunctionOperator((FunctionOperatorType) operatorType,
                                    new CriteriaOperator[]
                                    {
                                        new OperandProperty(fieldName),
                                        new OperandValue(fieldValue.ToString())
                                    }));
                        }
                    }
                    else
                    {
                        if (fieldValue == DBNull.Value)
                        {
                            groupOperator.Operands.Add(
                                new NotOperator(new FunctionOperator((FunctionOperatorType) operatorType,
                                    new CriteriaOperator[] {new OperandProperty(fieldName)})));
                        }
                        else
                        {
                            groupOperator.Operands.Add(
                                new NotOperator(new FunctionOperator((FunctionOperatorType) operatorType,
                                    new CriteriaOperator[]
                                    {
                                        new OperandProperty(fieldName),
                                        new OperandValue(fieldValue.ToString())
                                    })));
                        }
                    }
                    break;

                case SearchOperator.Group:
                    break;
            }
        }

        //Group can be started by GroupOperator or by AggregateOperand
        //private static GroupOperator AddGroup
        //    (CriteriaOperator parentOperator, object useOr, object useNot, out CriteriaOperator rootOperator)
        //{
        //    if (parentOperator is GroupOperator)
        //        return AddGroupOperator(parentOperator as GroupOperator, useOr, useNot, out rootOperator);
        //    if(parentOperator is AggregateOperand)

        //}
        private static GroupOperator AddGroupOperator
            (DataRow criteriaRow, GroupOperator parentOperator, out CriteriaOperator rootOperator)
        {
            return AddGroupOperator(parentOperator, criteriaRow["blnJoinByOr"], criteriaRow["blnUseNot"],
                out rootOperator);
        }

        public static GroupOperator AddGroupOperator
            (GroupOperator parentOperator, object useOr, object useNot, out CriteriaOperator rootOperator)
        {
            var groupOperator = new GroupOperator();
            rootOperator = groupOperator;
            if (IsTrue(useOr))
            {
                groupOperator.OperatorType = GroupOperatorType.Or;
            }
            if (IsTrue(useNot))
            {
                rootOperator = new NotOperator(groupOperator);
            }
            if (!ReferenceEquals(parentOperator, null))
            {
                parentOperator.Operands.Add(rootOperator);
            }
            return groupOperator;
        }

        public static AggregateOperand AddAggregateOperand
            (GroupOperator parentOperator, string objectName, object useNot)
        {
            var aggregateOperand = new AggregateOperand
            {
                AggregateType = Aggregate.Exists,
                CollectionProperty = new OperandProperty(objectName)
            };
            CriteriaOperator rootOperator = aggregateOperand;
            if (IsTrue(useNot))
            {
                rootOperator = new NotOperator(aggregateOperand);
            }
            if (!ReferenceEquals(parentOperator, null))
            {
                parentOperator.Operands.Add(rootOperator);
            }
            return aggregateOperand;
        }

        private bool FlushUnaryNotOperator(ref CriteriaOperator op)
        {
            var uOp = op as UnaryOperator;
            if (!ReferenceEquals(uOp, null) && (uOp.OperatorType == UnaryOperatorType.Not))
            {
                op = uOp.Operand;
                return true;
            }
            return false;
        }

        private long m_CurrentSubQueryId;
        private long m_CurrentSubQuerySearchObjectID = -10000L;

        internal void ResetEnumerations()
        {
            m_CurrentSubQuerySearchObjectID = -10000L;
            m_GroupID = 0;
            m_CurrentSubQueryId = 0;
            m_QueryDataSet.Tables[QuerySearchObject_DB.tasSubquerySearchField].Columns["idfQuerySearchField"]
                .AutoIncrementSeed = -1;
        }

        private bool FlushAgregateOperand(CriteriaOperator op, DataRow destRow, int order, object parentGroupId)
        {
            var aggreOp = op as AggregateOperand;
            if (ReferenceEquals(aggreOp, null))
            {
                return false;
            }
            m_CurrentSubQueryId -= 1;
            m_CurrentSubQuerySearchObjectID -= 1;

            long idfsSearchObject = -1L;
            if ((m_QueryDataSet != null)
                && (m_QueryDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchObject))
                && (m_QueryDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows.Count > 0))
            {
                DataRow qsoRow = m_QueryDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0];
                if ((qsoRow != null) && ((qsoRow["idfsSearchObject"] is long) || (qsoRow["idfsSearchObject"] is int)))
                {
                    idfsSearchObject = (long) qsoRow["idfsSearchObject"];
                }
            }
            DataView rows = LookupCache.Get(LookupTables.SearchObjectRelationForSubQuery);
            rows.RowFilter = string.Format(
                "idfsParentSearchObject = {0} and ChildSearchObjectName = '{1}'",
                idfsSearchObject,
                aggreOp.CollectionProperty.PropertyName);
            Dbg.Assert(rows.Count == 1, "child search object is not found by name");
            var searchObjectId = (long) rows[0]["idfsChildSearchObject"];
            QuerySearchObject_DB.CreateNewSubQuery(m_QueryDataSet, m_CurrentSubQueryId, m_CurrentSubQuerySearchObjectID,
                m_QuerySearchObjectID, searchObjectId);
            destRow["idfSubQuerySearchObject"] = m_CurrentSubQuerySearchObjectID;
            //object parentGroupID = destRow["idfQueryConditionGroup"];//current group became parent
            destRow["idfQueryConditionGroup"] = --m_GroupID;
            destRow["idfParentQueryConditionGroup"] = parentGroupId;
            destRow["strOperator"] = SearchOperator.Exists.ToString();

            destRow.EndEdit();
            order = 0;

            // Add root group for subquery if there is no conditions or single condition under subquery
            if (!ReferenceEquals(aggreOp.Condition, null))
            {
                //var useOr = false;
                bool useNot = false;

                CriteriaOperator aggrOpCond = aggreOp.Condition;

                var groupOp = aggrOpCond as GroupOperator;
                //if (!ReferenceEquals(groupOp, null))
                //{
                //    if (groupOp.OperatorType == GroupOperatorType.Or)
                //        useOr = true;
                //}

                if (FlushUnaryNotOperator(ref aggrOpCond))
                {
                    useNot = true;
                }

                if (ReferenceEquals(groupOp, null))
                {
                    //Aggregate operand contains no group (group  And is assumed by default)
                    //Create group row that will be parent of the  aggregate operand condition
                    DataRow row = QuerySearchObject_DB.InitFilterRow(m_SearchCriteria.Table, --m_GroupID, destRow["idfQueryConditionGroup"],
                        m_CurrentSubQuerySearchObjectID, false);
                    if (useNot)
                    {
                        row["blnUseNot"] = true;
                    }
                    row.EndEdit();
                    // Flush child condition
                    FlushRecursive(m_CurrentSubQuerySearchObjectID, null, aggrOpCond, DBNull.Value,
                        row["idfQueryConditionGroup"], false, order);
                }
                else
                {
                    // Flush root group of subquery
                    //FlushGroupOperator(m_CurrentSubQuerySearchObjectID, aggrOpCond, row);
                    FlushRecursive(m_CurrentSubQuerySearchObjectID, null, groupOp, m_GroupID,
                        m_GroupID, DBNull.Value, order);
                }
            }

            return true;
        }

        private bool FlushGroupOperator(long querySearchObject, CriteriaOperator op, DataRow destRow)
        {
            var groupOp = op as GroupOperator;
            if (ReferenceEquals(groupOp, null))
            {
                return false;
            }
            destRow["blnJoinByOr"] = groupOp.OperatorType == GroupOperatorType.Or;
            object parentGroupId = DBNull.Value;
            if (destRow["idfQueryConditionGroup"] != DBNull.Value
                && !(-1L).Equals(destRow["idfQueryConditionGroup"]))
            {
                parentGroupId = destRow["idfQueryConditionGroup"]; //current group became parent
            }
            else if (destRow["idfQueryConditionGroup"] == DBNull.Value
                     && destRow["idfParentQueryConditionGroup"] != DBNull.Value)
            {
                parentGroupId = destRow["idfParentQueryConditionGroup"];
            }
            long groupId = --m_GroupID;
            destRow["idfQueryConditionGroup"] = groupId;
            destRow["idfParentQueryConditionGroup"] = parentGroupId;
            FlashChildOperands(querySearchObject, groupOp.Operands, DBNull.Value,
                groupId, destRow["blnJoinByOr"]);
            return true;
        }

        private void FlashChildOperands
            (long querySearchObject, IEnumerable<CriteriaOperator> opCollection, object groupId,
                object parentGroupId, object useOr)
        {
            int order = 0;
            foreach (CriteriaOperator child in opCollection)
            {
                FlushRecursive(querySearchObject, null, child, groupId, parentGroupId, useOr, order++);
            }
        }

        private DataRow InitRootCriteriaRow(out CriteriaOperator op)
        {
            op = FilterCriteria;
            FilterCriteria = op;
            op = FilterCriteria;
            RaiseFilterChangedEvent(op, new FilterChangedEventArgs(FilterChangedAction.ValueChanged, null));
            m_SearchCriteria.RowFilter = null;
            m_SearchCriteria.Table.Clear();
            m_SearchCriteria.Table.AcceptChanges();
            m_GroupID = 0;
            if (ReferenceEquals(op, null))
            {
                return null;
            }
            DataRow rootRow = QuerySearchObject_DB.InitRootGroupCondition(m_SearchCriteria.Table, m_QuerySearchObjectID);
            m_SearchCriteria = new DataView(m_SearchCriteria.Table);
            return rootRow;
        }

        private bool IsGroupOrAggregateOperator(CriteriaOperator op)
        {
            if (op is UnaryOperator)
            {
                op = ((UnaryOperator) op).Operand;
            }
            return op is GroupOperator || op is AggregateOperand;
        }

        public void Flush()
        {
            if (!HasChanges)
            {
                return;
            }
            CriteriaOperator op;
            QueryDataset.Tables[QuerySearchObject_DB.tasSubquery].Clear();
            QueryDataset.Tables[QuerySearchObject_DB.tasSubquerySearchField].Clear();
            DataRow row = InitRootCriteriaRow(out op);
            FlushRecursive(m_QuerySearchObjectID, row, op, -1L, DBNull.Value, false);
        }

        private void FlushRecursive
            (long querySearchObject, DataRow row, CriteriaOperator op, object groupId, object parentGroupId, object useOr,
                int order = 0)
        {
            //int order = 0;
            if (row == null)
            {
                row = QuerySearchObject_DB.InitFilterRow(m_SearchCriteria.Table, groupId, parentGroupId,
                    querySearchObject, useOr, order);
            }

            if (FlushUnaryNotOperator(ref op))
            {
                if (op is GroupOperator || op is AggregateOperand)
                {
                    row["blnUseNot"] = true;
                }
                else
                {
                    row["blnFieldConditionUseNot"] = true;
                }
            }
            if (!FlushGroupOperator(querySearchObject, op, row))
            {
                //if first operand is not group (single condition)
                //we should crate new child row for and left root row as is
                if (parentGroupId == DBNull.Value)
                {
                    parentGroupId = groupId;
                    groupId = DBNull.Value;
                    m_GroupID--;
                    object useNot = row["blnFieldConditionUseNot"];
                    row["blnFieldConditionUseNot"] = DBNull.Value;
                    row = QuerySearchObject_DB.InitFilterRow(m_SearchCriteria.Table, groupId, parentGroupId,
                        querySearchObject, useOr, order);
                    row["blnFieldConditionUseNot"] = useNot; //copy UseNot from parent row, which became group row.
                }
                if (!FlushAgregateOperand(op, row, order, parentGroupId))
                {
                    FlushFieldCriteria(querySearchObject, op, row, order);
                }
            }
            row.EndEdit();
        }

        private int m_GroupID;

        private void FlushFieldCriteria
            (long querySearchObject, CriteriaOperator node, DataRow row, int order)
        {
            if (ReferenceEquals(node, null))
            {
                return;
            }
            row["intOrder"] = order;
            //if (querySearchObject != m_SearchObjectID)
            //{
            //    row["idfSubQuerySearchObject"] = querySearchObject;
            //    //QuerySearchObject_DB.CreateNewSubQuerySearchField(m_QueryDataSet, m_CurrentSubQueryId, m_CurrentSubQuerySearchObjectID, m_SearchObjectID, searchObjectId);

            //}
            switch (node.GetType().Name)
            {
                case "BinaryOperator":
                    row["strOperator"] = SearchOperator.Binary.ToString();
                    row["intOperatorType"] = ((BinaryOperator) node).OperatorType;
                    row["idfQuerySearchField"] =
                        GetQuerySearchFieldIDByFieldAliasName(
                            ((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName, querySearchObject);
                    row["varValue"] = ((OperandValue) ((BinaryOperator) node).RightOperand).Value;
                    break;
                case "UnaryOperator":
                    if (((UnaryOperator) node).Operand is OperandProperty)
                    {
                        row["intOperatorType"] = ((UnaryOperator) node).OperatorType;
                        row["strOperator"] = SearchOperator.Unary.ToString();
                        row["idfQuerySearchField"] =
                            GetQuerySearchFieldIDByFieldAliasName(
                                ((OperandProperty) ((UnaryOperator) node).Operand).PropertyName, querySearchObject);
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
                                GetQuerySearchFieldIDByFieldAliasName(
                                    ((OperandProperty) ((UnaryOperator) node).Operand).PropertyName, querySearchObject);
                        }
                        else if (node is BinaryOperator)
                        {
                            row["blnFieldConditionUseNot"] = 1;
                            row["strOperator"] = SearchOperator.Binary.ToString();
                            row["intOperatorType"] = ((BinaryOperator) node).OperatorType;
                            row["idfQuerySearchField"] =
                                GetQuerySearchFieldIDByFieldAliasName(
                                    ((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName,
                                    querySearchObject);
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
                            row["idfQuerySearchField"] = GetQuerySearchFieldIDByFieldAliasName(fieldName,
                                querySearchObject);
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
                        row["idfQuerySearchField"] = GetQuerySearchFieldIDByFieldAliasName(fieldName, querySearchObject);
                        break;
                    }
                    Dbg.Fail("unsupported search operator type: {0}", node.GetType().Name);
                    break;
            }
            row.EndEdit();
        }

        protected string GetAggregateFieldNameByQuerySearchObjectId(long querySearchObject)
        {
            DataRow[] rows =
                QueryDataset.Tables[QuerySearchObject_DB.tasSubquery].Select(
                    string.Format("idfQuerySearchObject = {0}", querySearchObject));
            if (rows.Length > 0)
            {
                var searchObjectId = (long) rows[0]["idfsSearchObject"];
                string aggregateFieldName = string.Format("<{0}>",
                    LookupCache.GetLookupValue(searchObjectId, LookupTables.SearchObject, "name"));
                if (String.Compare(aggregateFieldName.ToLowerInvariant(), "<>", StringComparison.Ordinal) != 0)
                {
                    return aggregateFieldName;
                }
            }
            return "";
        }

        protected long GetQuerySearchFieldIDByFieldAliasName(string fieldAliasName, long querySearchObject)
        {
            FilterFieldInfo fieldInfo = GetFieldInfoByFieldAliasName(fieldAliasName);
            if (fieldInfo != null)
            {
                if (fieldInfo.QuerySearchFieldID != 0)
                {
                    return fieldInfo.QuerySearchFieldID; //query search field from main query search object
                }
                //Process fields from child objects
                DataRow[] rows =
                    QueryDataset.Tables[QuerySearchObject_DB.tasSubquerySearchField].Select(
                        string.Format("idfQuerySearchObject = {0} and idfsSearchField = {1}", querySearchObject,
                            fieldInfo.SearchFieldID));
                if (rows.Length > 0)
                {
                    return (long) rows[0]["idfQuerySearchField"];
                }
                DataRow row = QuerySearchObject_DB.CreateNewSubQuerySearchField(QueryDataset, 0, querySearchObject,
                    fieldInfo.SearchFieldID, fieldAliasName);
                if (row != null)
                {
                    return (long) row["idfQuerySearchField"];
                }
            }
            return 0;
        }

        private string GetFieldAliasNameByQuerySearchFieldID(long querySearchFieldID, long querySearchObjectId)
        {
            if (querySearchObjectId == m_QuerySearchObjectID)
            {
                foreach (string name in m_FieldInfo.Keys)
                {
                    if (m_FieldInfo[name].QuerySearchFieldID == querySearchFieldID)
                    {
                        return name;
                    }
                }
            }
            else
            {
                DataRow[] rows =
                    QueryDataset.Tables[QuerySearchObject_DB.tasSubquerySearchField].Select(
                        string.Format("idfQuerySearchObject = {0} and idfQuerySearchField = {1}", querySearchObjectId,
                            querySearchFieldID));
                if (rows.Length > 0)
                {
                    foreach (string name in m_FieldInfo.Keys)
                    {
                        if (m_FieldInfo[name].SearchFieldID == (long) rows[0]["idfsSearchField"])
                        {
                            return name;
                        }
                    }
                }
            }
            return "";
        }

        private bool QuerySearchFieldExists(object querySearchFieldId)
        {
            if (Utils.IsEmpty(querySearchFieldId))
            {
                return false;
            }
            return
                QueryDataset.Tables[QuerySearchObject_DB.tasQuerySearchField].Select(
                    string.Format("idfQuerySearchField = {0}", querySearchFieldId)).Length == 1;
        }

        public override void RefreshNodes()
        {
            m_SearchCriteria.RowFilter = null;
            for (int i = m_SearchCriteria.Count - 1; i >= 0; i--)
            {
                DataRowView row = m_SearchCriteria[i];
                //Group and aggergate nodes are always exist
                if (IsGroupCriteriaRow(row.Row))
                {
                    continue;
                }
                //aggregate fields that belongs to child objects are always exist
                if (!m_QuerySearchObjectID.Equals(row["idfQuerySearchObject"]))
                {
                    continue;
                }
                if (!QuerySearchFieldExists(row["idfQuerySearchField"]))
                {
                    row.Delete();
                }
            }

            if (
                !m_SearchObjectID.Equals(
                    QueryDataset.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"]))
            {
                FilterCriteria = null;
            }
            else
            {
                DeleteNodesWithAbsentFields();
            }
            Flush();
            Bind(m_QuerySearchObjectID, QueryDataset);
        }

        protected override bool IsNodeValid(CriteriaOperator node)
        {
            long fieldID = 0;
            switch (node.GetType().Name)
            {
                case "BinaryOperator":
                    FilterFieldInfo info =
                        GetFieldInfoByFieldAliasName(
                            ((OperandProperty) ((BinaryOperator) node).LeftOperand).PropertyName);
                    if (info != null)
                    {
                        fieldID = info.QuerySearchFieldID;
                    }
                    break;
                case "UnaryOperator":
                    if (((UnaryOperator) node).Operand is OperandProperty)
                    {
                        info =
                            GetFieldInfoByFieldAliasName(((OperandProperty) ((UnaryOperator) node).Operand).PropertyName);
                        if (info != null)
                        {
                            fieldID = info.QuerySearchFieldID;
                        }
                    }
                    else
                    {
                        return IsNodeValid(((UnaryOperator) node).Operand);
                    }
                    break;
                case "FunctionOperator":
                    info =
                        GetFieldInfoByFieldAliasName(
                            ((OperandProperty) ((FunctionOperator) node).Operands[0]).PropertyName);
                    if (info != null)
                    {
                        fieldID = info.QuerySearchFieldID;
                    }
                    break;
                case "AggregateOperand":
                    return true;
                default:
                    Dbg.Fail("unsupported search operator type: {0}", node.GetType().Name);
                    break;
            }
            //field belongs to aggregate node and always exists
            if (fieldID == 0)
            {
                return true;
            }
            return QuerySearchFieldExists(fieldID);
        }

        protected override string GetOperandPropertyText(OperandProperty op)
        {
            string caption = op.PropertyName;

            string fieldName = op.PropertyName.StartsWith("field") ? op.PropertyName.Substring(5) : op.PropertyName;
            if (m_FieldInfo.ContainsKey(caption))
            {
                caption = m_FieldInfo[caption].Caption;
            }
            else if (m_FieldInfo.ContainsKey(fieldName))
            {
                caption = m_FieldInfo[fieldName].Caption;
            }
            return caption;
        }

        public void UpdateFieldInfo()
        {
            foreach (string fieldAlias in m_FieldInfo.Keys)
            {
                if (m_FieldInfo[fieldAlias].QuerySearchFieldID < 0)
                {
                    m_FieldInfo[fieldAlias].QuerySearchFieldID = GetQuerySearchFieldIDForFieldAlias(fieldAlias);
                }
            }
        }

        private long GetQuerySearchFieldIDForFieldAlias(string fieldName)
        {
            DataTable t = QueryDataset.Tables[QuerySearchObject_DB.tasQuerySearchField];
            foreach (DataRow row in t.Rows)
            {
                if ((row.RowState == DataRowState.Deleted) && (!Utils.IsEmpty(row["FieldAlias", DataRowVersion.Original])) &&
                    row["FieldAlias", DataRowVersion.Original].Equals(fieldName))
                {
                    return 0;
                }
                if ((row.RowState != DataRowState.Deleted) && (!Utils.IsEmpty(row["FieldAlias"])) && row["FieldAlias"].Equals(fieldName))
                {
                    return (long) row["idfQuerySearchField"];
                }
            }
            Dbg.Fail("invalid search field Name {0}", fieldName);
            return 0;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);
        }

        //public class QueryFilterControlPainter : FilterControlPainter
        //{
        //    public QueryFilterControlPainter(FilterControl owner):base(owner)
        //    {
        //    }
        //    public override void Draw(ControlGraphicsInfoArgs info)
        //    {
        //        base.Draw(info);
        //    }
        //}
    }
}