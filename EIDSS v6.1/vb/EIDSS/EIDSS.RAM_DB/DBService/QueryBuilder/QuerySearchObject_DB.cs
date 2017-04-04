using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Enums;
using bv.model.Model.Core;

namespace eidss.avr.db.DBService.QueryBuilder
{
    public class QuerySearchObject_DB : BaseDbService
    {
        #region Constants

        public const string TasQuerySearchObject = "tasQuerySearchObject";
        public const string TasQuerySearchField = "tasQuerySearchField";
        public const string TasQueryConditionGroup = "tasQueryConditionGroup";
        public const string TasSubquery = "tasSubquery";
        public const string TasSubquerySearchField = "tasSubquerySearchFields";

        #endregion

        private IDbCommand m_CmdPostFieldCondition;

        #region ID Properties

        private long m_QuerySearchObjectID = -1L;

        public long QuerySearchObjectID
        {
            get { return m_QuerySearchObjectID; }
            set { m_QuerySearchObjectID = value; }
        }

        private long m_QueryID = -1L;

        public long QueryID
        {
            get { return m_QueryID; }
            set { m_QueryID = value; }
        }

        #endregion

        public QuerySearchObject_DB()
        {
            ObjectName = "QuerySearchObject";
            UseDatasetCopyInPost = false;
        }

        public override DataSet GetDetail(object id)
        {
            var ds = new DataSet();
            try
            {
                IDbCommand cmd = CreateSPCommand("spAsQuerySearchObject_SelectDetail");
                AddParam(cmd, "@ID", id, ref m_Error);
                if (m_Error != null)
                {
                    return (null);
                }
                AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage, ref m_Error);
                if (m_Error != null)
                {
                    return (null);
                }
                DbDataAdapter querySearchObjectAdapter = CreateAdapter(cmd, true);
                querySearchObjectAdapter.Fill(ds, TasQuerySearchObject);
                ds.EnforceConstraints = false;
                CorrectTable(ds.Tables[0], TasQuerySearchObject, "idfQuerySearchObject");
                CorrectTable(ds.Tables[1], TasQuerySearchField, "idfQuerySearchField");
                CorrectTable(ds.Tables[2], TasQueryConditionGroup, "idfCondition");
                CorrectTable(ds.Tables[3], TasSubquery, "idfQuerySearchObject");
                CorrectTable(ds.Tables[4], TasSubquerySearchField, "idfQuerySearchField");
                ClearColumnsAttibutes(ds);
                ds.Tables[TasQueryConditionGroup].Columns["SearchFieldConditionText"].MaxLength = int.MaxValue;
                ds.Tables[TasQueryConditionGroup].Columns["idfCondition"].AutoIncrementStep = 1;
                ds.Tables[TasQueryConditionGroup].Columns["idfCondition"].AutoIncrement = true;
                ds.Tables[TasQueryConditionGroup].Columns["idfCondition"].AutoIncrementSeed = 0;
                ds.Tables[TasQuerySearchField].Columns["TypeImageIndex"].ReadOnly = false;
                ds.Tables[TasSubquerySearchField].Columns["idfQuerySearchField"].AutoIncrementStep = -1;
                ds.Tables[TasSubquerySearchField].Columns["idfQuerySearchField"].AutoIncrement = true;
                ds.Tables[TasSubquerySearchField].Columns["idfQuerySearchField"].AutoIncrementSeed = -100000;

                if (ds.Tables[TasQuerySearchObject].Rows.Count == 0)
                {
                    if (Utils.IsEmpty(id) || (!(id is long)) || ((long) id >= 0))
                    {
                        id = m_QuerySearchObjectID;
                    }
                    else
                    {
                        m_QuerySearchObjectID = (long) id;
                    }
                    m_IsNewObject = true;

                    DataRow rQso = ds.Tables[TasQuerySearchObject].NewRow();
                    rQso["idfQuerySearchObject"] = id;
                    rQso["idflQuery"] = m_QueryID;
                    rQso["intOrder"] = 0;
                    ds.EnforceConstraints = false;
                    ds.Tables[TasQuerySearchObject].Rows.Add(rQso);
                }
                else
                {
                    m_IsNewObject = false;
                    m_QuerySearchObjectID =
                        (long) ds.Tables[TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
                    m_QueryID =
                        (long) ds.Tables[TasQuerySearchObject].Rows[0]["idflQuery"];
                }

                InitRootGroupCondition(ds.Tables[TasQueryConditionGroup], id);
                ds.EnforceConstraints = false;
                m_ID = id;
                return (ds);
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            return null;
        }

        public static DataRow InitRootGroupCondition(DataTable dt, object searchObjectID)
        {
            if (dt.Rows.Count == 0)
            {
                DataRow row = dt.NewRow();
                row["idfCondition"] = 0L;
                row["idfQueryConditionGroup"] = -1L;
                row["idfQuerySearchObject"] = searchObjectID;
                row["intOrder"] = 0;
                row["idfParentQueryConditionGroup"] = DBNull.Value;
                row["blnJoinByOr"] = false;
                row["blnUseNot"] = false;
                row["idfQuerySearchFieldCondition"] = DBNull.Value;
                row["SearchFieldConditionText"] = "()";
                dt.Rows.Add(row);
            }
            return dt.Rows[0];
        }

        public static DataRow InitFilterRow
            (DataTable dt, object groupID, object parentGroupID, object searchObjectID, object useOr, int order = 0)
        {
            DataRow row = dt.NewRow();
            row["idfQueryConditionGroup"] = groupID;
            row["idfParentQueryConditionGroup"] = parentGroupID;
            row["blnJoinByOr"] = useOr;
            row["blnUseNot"] = false;
            row["intOrder"] = order;
            row["idfQuerySearchObject"] = searchObjectID;
            row["idfSubQuerySearchObject"] = DBNull.Value;
            dt.Rows.Add(row);
            return row;
        }

        public override void AcceptChanges(DataSet ds)
        {
            // this method shoul duplicate base method bu WITHOUT line m_IsNewObject = false
            foreach (DataTable table in ds.Tables)
            {
                if (!SkipAcceptChanges(table))
                {
                    table.AcceptChanges();
                }
            }
            RaiseAcceptChangesEvent(ds);
        }

        private void PostSubQueryWithRootObject
            (IDbCommand cmdSubQuery, DataRow rSubQuery, DataTable fieldTable, DataTable conditionGroupTable)
        {
            if ((cmdSubQuery == null) || (rSubQuery == null))
            {
                return;
            }
            object strFunctionName = DBNull.Value;
            object idflSubQueryDescription = DBNull.Value;
            if (rSubQuery.RowState != DataRowState.Deleted)
            {
                object subQueryID = rSubQuery["idflQuery"];
                object subQueryRootObjectID = rSubQuery["idfQuerySearchObject"];
                SetParam(cmdSubQuery, "@idflSubQuery", subQueryID, ParameterDirection.InputOutput);
                SetParam(cmdSubQuery, "@idfSubQuerySearchObject", subQueryRootObjectID, ParameterDirection.InputOutput);
                SetParam(cmdSubQuery, "@idfsSearchObject", rSubQuery["idfsSearchObject"]);
                SetParam(cmdSubQuery, "@strFunctionName", strFunctionName, ParameterDirection.InputOutput);
                SetParam(cmdSubQuery, "@idflSubQueryDescription", idflSubQueryDescription, ParameterDirection.InputOutput);

                ExecCommand(cmdSubQuery, cmdSubQuery.Connection, cmdSubQuery.Transaction, true);
                var newSubQueryID = (long)((IDataParameter)cmdSubQuery.Parameters["@idflSubQuery"]).Value;
                var newSubQueryRootObjectID = (long)((IDataParameter)cmdSubQuery.Parameters["@idfSubQuerySearchObject"]).Value;
                if (newSubQueryRootObjectID != (long)subQueryRootObjectID)
                {
                    rSubQuery["idflQuery"] = newSubQueryID;
                    rSubQuery["idfQuerySearchObject"] = newSubQueryRootObjectID;
                    DataRow[] fieldRows = fieldTable.Select(string.Format("idfQuerySearchObject = {0} ", subQueryRootObjectID));
                    foreach (DataRow fieldRow in fieldRows)
                    {
                        if ((fieldRow.RowState != DataRowState.Deleted)
                            && (Utils.Str(fieldRow["idfQuerySearchObject"]).ToLowerInvariant() == 
                                Utils.Str(subQueryRootObjectID).ToLowerInvariant()))
                        {
                            fieldRow["idfQuerySearchObject"] = newSubQueryRootObjectID;
                        }
                    }
                    DataRow[] groupRows = conditionGroupTable.Select(string.Format("idfQuerySearchObject = {0} ", subQueryRootObjectID));
                    foreach (DataRow groupRow in groupRows)
                    {
                        if (groupRow.RowState != DataRowState.Deleted)
                        {
                                groupRow["idfQuerySearchObject"] = newSubQueryRootObjectID;
                        }
                    }
                    groupRows = conditionGroupTable.Select(string.Format("idfSubQuerySearchObject = {0} ", subQueryRootObjectID));
                    foreach (DataRow groupRow in groupRows)
                    {
                        if (groupRow.RowState != DataRowState.Deleted)
                        {
                            groupRow["idfSubQuerySearchObject"] = newSubQueryRootObjectID;
                        }
                    }
                }
            }
        }

        private void PostField(IDbCommand cmdField, DataRow rField, DataTable fieldConditionTable)
        {
            if ((cmdField == null) || (rField == null))
            {
                return;
            }
            object fieldID;
            if (rField.RowState == DataRowState.Deleted)
            {
                fieldID = rField["idfQuerySearchField", DataRowVersion.Original];
                SetParam(cmdField, "@idfQuerySearchField", fieldID, ParameterDirection.InputOutput);
                SetParam(cmdField, "@idfQuerySearchObject", -1L);
                SetParam(cmdField, "@idfsSearchField", DBNull.Value);
                SetParam(cmdField, "@blnShow", 0);
                SetParam(cmdField, "@idfsParameter", DBNull.Value);

                ExecCommand(cmdField, cmdField.Connection, cmdField.Transaction, true);
            }
            else
            {
                fieldID = rField["idfQuerySearchField"];
                SetParam(cmdField, "@idfQuerySearchField", fieldID, ParameterDirection.InputOutput);
                SetParam(cmdField, "@idfQuerySearchObject", rField["idfQuerySearchObject"]);
                SetParam(cmdField, "@idfsSearchField", rField["idfsSearchField"]);
                SetParam(cmdField, "@blnShow", rField["blnShow"]);
                SetParam(cmdField, "@idfsParameter", rField["idfsParameter"]);

                ExecCommand(cmdField, cmdField.Connection, cmdField.Transaction, true);
                long newFieldID = (long)((IDataParameter)cmdField.Parameters["@idfQuerySearchField"]).Value;
                if (newFieldID != (long)fieldID)
                {
                    rField["idfQuerySearchField"] = newFieldID;
                    DataRow[] rows = fieldConditionTable.Select(string.Format("idfQuerySearchField = {0} ", fieldID));
                    foreach (DataRow row in rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            row["idfQuerySearchField"] = newFieldID;
                        }
                    }
                }
            }
        }

        private void PostFieldCondition(IDbCommand cmdFieldCondition, DataRow rFieldCondition)
        {
            if ((cmdFieldCondition == null) || (rFieldCondition == null) || rFieldCondition["idfQuerySearchField"] == DBNull.Value)
            {
                return;
            }
            SetParam(cmdFieldCondition, "@idfQueryConditionGroup", rFieldCondition["idfParentQueryConditionGroup"]);
            SetParam(cmdFieldCondition, "@idfQuerySearchField", rFieldCondition["idfQuerySearchField"]);
            SetParam(cmdFieldCondition, "@intOrder", rFieldCondition["intOrder"]);
            SetParam(cmdFieldCondition, "@strOperator", rFieldCondition["strOperator"]);
            SetParam(cmdFieldCondition, "@intOperatorType", rFieldCondition["intOperatorType"]);
            SetParam(cmdFieldCondition, "@blnUseNot", rFieldCondition["blnFieldConditionUseNot"]);
            SetParam(cmdFieldCondition, "@varValue", rFieldCondition["varValue"]);
            ExecCommand(cmdFieldCondition, cmdFieldCondition.Connection, cmdFieldCondition.Transaction, true);
            rFieldCondition["idfQuerySearchFieldCondition"] =
                ((IDataParameter) m_CmdPostFieldCondition.Parameters["@idfQuerySearchFieldCondition"]).Value;
        }

        private void PostGroup(IDbCommand cmdGroup, DataTable dtGroup, DataRow rGroup)
        {
            if ((cmdGroup == null) || (dtGroup == null) || (rGroup == null))
            {
                return;
            }
            object oldGroupID = rGroup["idfQueryConditionGroup"];

            SetParam(cmdGroup, "@idfQuerySearchObject", rGroup["idfQuerySearchObject"]);
            SetParam(cmdGroup, "@intOrder", rGroup["intOrder"]);
            SetParam(cmdGroup, "@idfParentQueryConditionGroup", rGroup["idfParentQueryConditionGroup"]);
            SetParam(cmdGroup, "@blnJoinByOr", rGroup["blnJoinByOr"]);
            SetParam(cmdGroup, "@blnUseNot", rGroup["blnUseNot"]);
            SetParam(cmdGroup, "@idfSubQuerySearchObject", rGroup["idfSubQuerySearchObject"]);
            
            ExecCommand(cmdGroup, cmdGroup.Connection, cmdGroup.Transaction, true);

            object groupID = ((IDataParameter) cmdGroup.Parameters["@idfQueryConditionGroup"]).Value;
            rGroup["idfQueryConditionGroup"] = groupID;
            //update all group rows with new groupID value returned by stored procedure
            DataRow[] drGroup =
                dtGroup.Select(string.Format("idfParentQueryConditionGroup = {0} and idfQueryConditionGroup is null", oldGroupID),
                    "intOrder",
                                               DataViewRowState.CurrentRows);
            foreach (DataRow r in drGroup)
            {
                r["idfParentQueryConditionGroup"] = groupID;
                if (m_CmdPostFieldCondition == null)
                {
                    m_CmdPostFieldCondition = CreateSPCommand("spAsQuerySearchFieldCondition_Post", cmdGroup.Transaction);

                    AddTypedParam(m_CmdPostFieldCondition, "@idfQuerySearchFieldCondition", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(m_CmdPostFieldCondition, "@idfQueryConditionGroup", SqlDbType.BigInt);
                    AddTypedParam(m_CmdPostFieldCondition, "@idfQuerySearchField", SqlDbType.BigInt);
                    AddTypedParam(m_CmdPostFieldCondition, "@intOrder", SqlDbType.Int);
                    AddTypedParam(m_CmdPostFieldCondition, "@strOperator", SqlDbType.NVarChar, 200);
                    AddTypedParam(m_CmdPostFieldCondition, "@intOperatorType", SqlDbType.Int);
                    AddTypedParam(m_CmdPostFieldCondition, "@blnUseNot", SqlDbType.Bit);
                    AddTypedParam(m_CmdPostFieldCondition, "@varValue", SqlDbType.Variant);
                }

                PostFieldCondition(m_CmdPostFieldCondition, r);
            }
            drGroup = dtGroup.Select(
                string.Format("idfParentQueryConditionGroup = {0} and idfQueryConditionGroup is not null", oldGroupID), "intOrder",
                                     DataViewRowState.CurrentRows);
            var postedGroups = new Dictionary<long, int>();
            foreach (DataRow r in drGroup)
            {
                r["idfParentQueryConditionGroup"] = groupID;
                if (postedGroups.ContainsKey((long) r["idfQueryConditionGroup"]))
                {
                    continue;
                }
                PostGroup(cmdGroup, dtGroup, r);
                postedGroups.Add((long) r["idfQueryConditionGroup"], 1);
            }
        }

      

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction = null)
        {
            if ((ds == null) ||
                (ds.Tables.Contains(TasQuerySearchObject) == false) ||
                (ds.Tables.Contains(TasQuerySearchField) == false) ||
                (ds.Tables.Contains(TasQueryConditionGroup) == false))
            {
                return true;
            }
            if (IsNewObject)
            {
                // Update ID of object in related tables
                long oldQuerySearchObjectID = -1L;
                if ((ds.Tables[TasQuerySearchObject].Rows[0]["idfQuerySearchObject"] is long) ||
                    ds.Tables[TasQuerySearchObject].Rows[0]["idfQuerySearchObject"] is int)
                {
                    oldQuerySearchObjectID = (long) (ds.Tables[TasQuerySearchObject].Rows[0]["idfQuerySearchObject"]);
                }
                ds.Tables[TasQuerySearchObject].Rows[0]["idflQuery"] = m_QueryID;
                ds.Tables[TasQuerySearchObject].Rows[0]["idfQuerySearchObject"] = m_QuerySearchObjectID;
                foreach (DataRow rField in ds.Tables[TasQuerySearchField].Rows)
                {
                    if (rField.RowState != DataRowState.Deleted)
                    {
                        if (Utils.Str(rField["idfQuerySearchObject"]).ToLowerInvariant() == 
                            Utils.Str(oldQuerySearchObjectID).ToLowerInvariant())
                        {
                        rField["idfQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                }
                foreach (DataRow rCondition in ds.Tables[TasQueryConditionGroup].Rows)
                {
                    if (rCondition.RowState != DataRowState.Deleted)
                    {
                        if (Utils.Str(rCondition["idfQuerySearchObject"]).ToLowerInvariant() == 
                            Utils.Str(oldQuerySearchObjectID).ToLowerInvariant())
                        {
                        rCondition["idfQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                }
                foreach (DataRow rSubQuery in ds.Tables[TasSubquery].Rows)
                {
                    if (rSubQuery.RowState != DataRowState.Deleted)
                    {
                        if (Utils.Str(rSubQuery["idfParentQuerySearchObject"]).ToLowerInvariant() ==
                            Utils.Str(oldQuerySearchObjectID).ToLowerInvariant())
                        {
                            rSubQuery["idfParentQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                }
                m_ID = m_QuerySearchObjectID;
            }

            try
            {
                m_CmdPostFieldCondition = null;

                if (ds.Tables[TasQuerySearchObject].Rows.Count > 0)
                {
                    // Update Report Type for Object
                    DataRow rObject = ds.Tables[TasQuerySearchObject].Rows[0];
                    IDbCommand cmdObject = CreateSPCommand("spAsQuerySearchObject_ReportTypePost", transaction);

                    AddTypedParam(cmdObject, "@idfQuerySearchObject", SqlDbType.BigInt);
                    AddTypedParam(cmdObject, "@idfsReportType", SqlDbType.BigInt);

                    SetParam(cmdObject, "@idfQuerySearchObject", m_QuerySearchObjectID);
                    SetParam(cmdObject, "@idfsReportType", rObject["idfsReportType"]);

                    ExecCommand(cmdObject, cmdObject.Connection, cmdObject.Transaction, true);

                    // Delete sub-queries with related objects and links from condition groups of object to sub-queries
                    IDbCommand cmdDeleteSubQueries = CreateSPCommand("spAsQuery_DeleteSubqueries", transaction);
                    AddTypedParam(cmdDeleteSubQueries, "@idfParentQuerySearchObject", SqlDbType.BigInt);
                    SetParam(cmdDeleteSubQueries, "@idfParentQuerySearchObject", m_QuerySearchObjectID);
                    
                    ExecCommand(cmdDeleteSubQueries, cmdDeleteSubQueries.Connection, cmdDeleteSubQueries.Transaction, true);

                    // Sub-queries with root objects
                    if (ds.Tables[TasSubquery].Rows.Count > 0)
                    {
                        IDbCommand cmdSubQuery = CreateSPCommand("spAsSubQuery_PostWithRootObject", transaction);

                        AddTypedParam(cmdSubQuery, "@idflSubQuery", SqlDbType.BigInt, ParameterDirection.InputOutput);
                        AddTypedParam(cmdSubQuery, "@idfSubQuerySearchObject", SqlDbType.BigInt, ParameterDirection.InputOutput);
                        AddTypedParam(cmdSubQuery, "@idfsSearchObject", SqlDbType.BigInt);
                        AddTypedParam(cmdSubQuery, "@strFunctionName", SqlDbType.NVarChar, 200, ParameterDirection.InputOutput);
                        AddTypedParam(cmdSubQuery, "@idflSubQueryDescription", SqlDbType.BigInt, ParameterDirection.InputOutput);

                        foreach (DataRow rSubQuery in ds.Tables[TasSubquery].Rows)
                        {
                            PostSubQueryWithRootObject(cmdSubQuery, rSubQuery, ds.Tables[TasSubquerySearchField],
                                ds.Tables[TasQueryConditionGroup]);
                        }
                    }

                    // Fields
                    IDbCommand cmdField = CreateSPCommand("spAsQuerySearchField_Post", transaction);

                    // Fields of object
                    AddTypedParam(cmdField, "@idfQuerySearchField", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmdField, "@idfQuerySearchObject", SqlDbType.BigInt);
                    AddTypedParam(cmdField, "@idfsSearchField", SqlDbType.BigInt);
                    AddTypedParam(cmdField, "@blnShow", SqlDbType.Bit);
                    AddTypedParam(cmdField, "@idfsParameter", SqlDbType.BigInt);

                    if (ds.Tables[TasQuerySearchField].Rows.Count > 0)
                    {
                        foreach (DataRow rField in ds.Tables[TasQuerySearchField].Rows)
                        {
                            PostField(cmdField, rField, ds.Tables[TasQueryConditionGroup]);
                        }
                    }

                    // Fields of sub-queries
                    if (ds.Tables[TasSubquerySearchField].Rows.Count > 0)
                    {
                        foreach (DataRow rSubQueryField in ds.Tables[TasSubquerySearchField].Rows)
                        {
                            PostField(cmdField, rSubQueryField, ds.Tables[TasQueryConditionGroup]);
                        }
                    }

                    LookupCache.NotifyChange("QuerySearchField", transaction);
                }

                // Delete condition groups of object
                IDbCommand cmdDeleteGroups = CreateSPCommand("spAsQuerySearchObject_DeleteConditions", transaction);
                SetParam(cmdDeleteGroups, "@idfQuerySearchObject", m_QuerySearchObjectID);
                
                ExecCommand(cmdDeleteGroups, cmdDeleteGroups.Connection, cmdDeleteGroups.Transaction, true);

                // Condition groups including sub-queries
                if (ds.Tables[TasQueryConditionGroup].Rows.Count > 0)
                {
                    IDbCommand cmdGroup = CreateSPCommandWithParams("spAsQueryConditionGroup_Post", transaction);
                    DataRow[] dr = ds.Tables[TasQueryConditionGroup].Select("idfParentQueryConditionGroup is null",
                                                                           "idfQueryConditionGroup",
                                                                           DataViewRowState.CurrentRows);
                    if (dr.Length > 0)
                    {
                        PostGroup(cmdGroup, ds.Tables[TasQueryConditionGroup], dr[0]);
                    }
                }
                m_IsNewObject = false;
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
            return true;
        }

        public void Copy(DataSet ds, object aID, long aQueryID)
        {
            if ((ds == null) ||
                (ds.Tables.Contains(TasQuerySearchObject) == false) ||
                (ds.Tables.Contains(TasQuerySearchField) == false) ||
                (ds.Tables.Contains(TasQueryConditionGroup) == false) ||
                (ds.Tables.Contains(TasSubquery) == false) ||
                (ds.Tables.Contains(TasSubquerySearchField) == false) ||
                (ds.Tables[TasQuerySearchObject].Rows.Count == 0))
            {
                return;
            }
            if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long) aID >= 0))
            {
                aID = -1L;
            }
            m_QuerySearchObjectID = (long) aID;
            m_QueryID = aQueryID;
            m_IsNewObject = true;

            DataRow rQSO = ds.Tables[TasQuerySearchObject].Rows[0];
            rQSO["idfQuerySearchObject"] = aID;
            rQSO["idflQuery"] = aQueryID;
            m_ID = aID;

            if (ds.Tables[TasQueryConditionGroup].Rows.Count == 0)
            {
                DataRow rQCG = ds.Tables[TasQueryConditionGroup].NewRow();
                rQCG["idfQueryConditionGroup"] = -1L;
                rQCG["idfQuerySearchObject"] = aID;
                rQCG["intOrder"] = 0;
                rQCG["idfParentQueryConditionGroup"] = DBNull.Value;
                rQCG["blnJoinByOr"] = DBNull.Value;
                rQCG["blnUseNot"] = false;
                rQCG["idfQuerySearchFieldCondition"] = DBNull.Value;
                rQCG["idfSubQuerySearchObject"] = DBNull.Value;
                rQCG["SearchFieldConditionText"] = "()";
                ds.EnforceConstraints = false;
                ds.Tables[TasQueryConditionGroup].Rows.Add(rQCG);
            }
        }

        public static void CreateNewSubQuery
            (DataSet ds, long queryId, long querySearchObjectId, long parentQuerySearchObjectId, long searchObjectId)
        {
            if (!ds.Tables.Contains(TasSubquery))
        {
                return;
            }
            DataTable dt = ds.Tables[TasSubquery];
            DataRow row = dt.NewRow();
            row["idflQuery"] = queryId;
            row["idfQuerySearchObject"] = querySearchObjectId;
            row["idfParentQuerySearchObject"] = parentQuerySearchObjectId;
            row["idfsSearchObject"] = searchObjectId;
            dt.Rows.Add(row);
        }

        public static DataRow CreateNewSubQuerySearchField
            (DataSet ds, long querySearchFieldId, long querySearchObjectId, long searchFieldId, string fieldAlias)
        {
            if (!ds.Tables.Contains(TasSubquerySearchField))
        {
                return null;
            }
            DataTable dt = ds.Tables[TasSubquerySearchField];
            DataRow row = dt.NewRow();
            if (querySearchFieldId != 0) //if id is passed explicitly, assign it. In other case it will be calcaulated by autoincrement
            {
                row["idfQuerySearchField"] = querySearchFieldId;
            }

            row["idfQuerySearchObject"] = querySearchObjectId;
            row["idfsSearchField"] = searchFieldId;
            row["FieldAlias"] = fieldAlias;
            row["blnShow"] = false;
            dt.Rows.Add(row);
            return row;
        }
    }
}
