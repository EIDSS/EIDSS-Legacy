using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using bv.common;
using bv.common.Core;
using bv.common.Enums;
using bv.common.db;
using bv.common.db.Core;

namespace eidss.avr.db.DBService.QueryBuilder
{
    public class QuerySearchObject_DB : BaseDbService
    {
        #region Constants

        public const string tasQuerySearchObject = "tasQuerySearchObject";
        public const string tasQuerySearchField = "tasQuerySearchField";
        public const string tasQueryConditionGroup = "tasQueryConditionGroup";
        public const string tasSubquery = "tasSubquery";
        public const string tasSubquerySearchField = "tasSubquerySearchFields";

        #endregion

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
            base.ObjectName = "QuerySearchObject";
            UseDatasetCopyInPost = false;
        }

        public override DataSet GetDetail(object ID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbDataAdapter querySearchObjectAdapter = null;
                IDbCommand cmd = CreateSPCommand("spAsQuerySearchObject_SelectDetail", null);
                AddParam(cmd, "@ID", ID, ref m_Error, ParameterDirection.Input);
                if (m_Error != null)
                {
                    return (null);
                }
                AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
                if (m_Error != null)
                {
                    return (null);
                }
                querySearchObjectAdapter = CreateAdapter(cmd, true);
                querySearchObjectAdapter.Fill(ds, tasQuerySearchObject);
                ds.EnforceConstraints = false;
                CorrectTable(ds.Tables[0], tasQuerySearchObject, "idfQuerySearchObject");
                CorrectTable(ds.Tables[1], tasQuerySearchField, "idfQuerySearchField");
                CorrectTable(ds.Tables[2], tasQueryConditionGroup, "idfCondition");
                CorrectTable(ds.Tables[3], tasSubquery, "idfQuerySearchObject");
                CorrectTable(ds.Tables[4], tasSubquerySearchField, "idfQuerySearchField");
                ClearColumnsAttibutes(ds);
                ds.Tables[tasQueryConditionGroup].Columns["SearchFieldConditionText"].MaxLength = int.MaxValue;
                ds.Tables[tasQueryConditionGroup].Columns["idfCondition"].AutoIncrementStep = 1;
                ds.Tables[tasQueryConditionGroup].Columns["idfCondition"].AutoIncrement = true;
                ds.Tables[tasQueryConditionGroup].Columns["idfCondition"].AutoIncrementSeed = 0;
                ds.Tables[tasQuerySearchField].Columns["TypeImageIndex"].ReadOnly = false;
                ds.Tables[tasSubquerySearchField].Columns["idfQuerySearchField"].AutoIncrementStep = -1;
                ds.Tables[tasSubquerySearchField].Columns["idfQuerySearchField"].AutoIncrement = true;
                ds.Tables[tasSubquerySearchField].Columns["idfQuerySearchField"].AutoIncrementSeed = -100000;

                if (ds.Tables[tasQuerySearchObject].Rows.Count == 0)
                {
                    if (Utils.IsEmpty(ID) || (!(ID is long)) || ((long)ID >= 0))
                    {
                        ID = m_QuerySearchObjectID;
                    }
                    else if (ID is long)
                    {
                        m_QuerySearchObjectID = (long)ID;
                    }
                    m_IsNewObject = true;

                    DataRow rQSO = ds.Tables[tasQuerySearchObject].NewRow();
                    rQSO["idfQuerySearchObject"] = ID;
                    rQSO["idflQuery"] = m_QueryID;
                    rQSO["intOrder"] = 0;
                    ds.EnforceConstraints = false;
                    ds.Tables[tasQuerySearchObject].Rows.Add(rQSO);
                }
                else
                {
                    m_IsNewObject = false;
                    m_QuerySearchObjectID =
                        (long)ds.Tables[tasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
                    m_QueryID =
                        (long)ds.Tables[tasQuerySearchObject].Rows[0]["idflQuery"];
                }

                InitRootGroupCondition(ds.Tables[tasQueryConditionGroup], ID);
                ds.EnforceConstraints = false;
                m_ID = ID;
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
        public static DataRow InitFilterRow(DataTable dt, object groupID, object parentGroupID, object searchObjectID, object useOr, int order = 0)
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



        private void PostSubQueryWithRootObject(IDbCommand cmdSubQuery, DataRow rSubQuery, DataTable fieldTable, DataTable conditionGroupTable)
        {
            if ((cmdSubQuery == null) || (rSubQuery == null))
            {
                return;
            }
            object subQueryID = -1L;
            object subQueryRootObjectID = -1L;
            object strFunctionName = DBNull.Value;
            object idflSubQueryDescription = DBNull.Value;
            if (rSubQuery.RowState != DataRowState.Deleted)
            {
                subQueryID = rSubQuery["idflQuery"];
                subQueryRootObjectID = rSubQuery["idfQuerySearchObject"];
                SetParam(cmdSubQuery, "@idflSubQuery", subQueryID, ParameterDirection.InputOutput);
                SetParam(cmdSubQuery, "@idfSubQuerySearchObject", subQueryRootObjectID, ParameterDirection.InputOutput);
                SetParam(cmdSubQuery, "@idfsSearchObject", rSubQuery["idfsSearchObject"], ParameterDirection.Input);
                SetParam(cmdSubQuery, "@strFunctionName", strFunctionName, ParameterDirection.InputOutput);
                SetParam(cmdSubQuery, "@idflSubQueryDescription", idflSubQueryDescription, ParameterDirection.InputOutput);

                cmdSubQuery.ExecuteNonQuery();
                long newSubQueryID = (long)((IDataParameter)cmdSubQuery.Parameters["@idflSubQuery"]).Value;
                long newSubQueryRootObjectID = (long)((IDataParameter)cmdSubQuery.Parameters["@idfSubQuerySearchObject"]).Value;
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
            object fieldID = -1L;
            if (rField.RowState == DataRowState.Deleted)
            {
                fieldID = rField["idfQuerySearchField", DataRowVersion.Original];
                SetParam(cmdField, "@idfQuerySearchField", fieldID, ParameterDirection.InputOutput);
                SetParam(cmdField, "@idfQuerySearchObject", -1L, ParameterDirection.Input);
                SetParam(cmdField, "@idfsSearchField", DBNull.Value, ParameterDirection.Input);
                SetParam(cmdField, "@blnShow", 0, ParameterDirection.Input);
                SetParam(cmdField, "@idfsParameter", DBNull.Value, ParameterDirection.Input);

                cmdField.ExecuteNonQuery();
            }
            else
            {
                fieldID = rField["idfQuerySearchField"];
                SetParam(cmdField, "@idfQuerySearchField", fieldID, ParameterDirection.InputOutput);
                SetParam(cmdField, "@idfQuerySearchObject", rField["idfQuerySearchObject"], ParameterDirection.Input);
                SetParam(cmdField, "@idfsSearchField", rField["idfsSearchField"], ParameterDirection.Input);
                SetParam(cmdField, "@blnShow", rField["blnShow"], ParameterDirection.Input);
                SetParam(cmdField, "@idfsParameter", rField["idfsParameter"], ParameterDirection.Input);

                cmdField.ExecuteNonQuery();
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
            SetParam(cmdFieldCondition, "@idfQueryConditionGroup", rFieldCondition["idfParentQueryConditionGroup"],
                     ParameterDirection.Input);
            SetParam(cmdFieldCondition, "@idfQuerySearchField", rFieldCondition["idfQuerySearchField"],
                     ParameterDirection.Input);
            SetParam(cmdFieldCondition, "@intOrder", rFieldCondition["intOrder"], ParameterDirection.Input);
            SetParam(cmdFieldCondition, "@strOperator", rFieldCondition["strOperator"], ParameterDirection.Input);
            SetParam(cmdFieldCondition, "@intOperatorType", rFieldCondition["intOperatorType"], ParameterDirection.Input);
            SetParam(cmdFieldCondition, "@blnUseNot", rFieldCondition["blnFieldConditionUseNot"], ParameterDirection.Input);
            SetParam(cmdFieldCondition, "@varValue", rFieldCondition["varValue"], ParameterDirection.Input);
            cmdFieldCondition.ExecuteNonQuery();
            rFieldCondition["idfQuerySearchFieldCondition"] =
                ((IDataParameter)cmdPostFieldCondition.Parameters["@idfQuerySearchFieldCondition"]).Value;
        }

        private void PostGroup(IDbCommand cmdGroup, DataTable dtGroup, DataRow rGroup)
        {
            if ((cmdGroup == null) || (dtGroup == null) || (rGroup == null))
            {
                return;
            }
            object oldGroupID = rGroup["idfQueryConditionGroup"];

            SetParam(cmdGroup, "@idfQuerySearchObject", rGroup["idfQuerySearchObject"], ParameterDirection.Input);
            SetParam(cmdGroup, "@intOrder", rGroup["intOrder"], ParameterDirection.Input);
            SetParam(cmdGroup, "@idfParentQueryConditionGroup", rGroup["idfParentQueryConditionGroup"],
                     ParameterDirection.Input);
            SetParam(cmdGroup, "@blnJoinByOr", rGroup["blnJoinByOr"], ParameterDirection.Input);
            SetParam(cmdGroup, "@blnUseNot", rGroup["blnUseNot"], ParameterDirection.Input);
            SetParam(cmdGroup, "@idfSubQuerySearchObject", rGroup["idfSubQuerySearchObject"], ParameterDirection.Input);
            cmdGroup.ExecuteNonQuery();

            object groupID = ((IDataParameter)cmdGroup.Parameters["@idfQueryConditionGroup"]).Value;
            rGroup["idfQueryConditionGroup"] = groupID;
            //update all group rows with new groupID value returned by stored procedure
            DataRow[] drGroup = dtGroup.Select(string.Format("idfParentQueryConditionGroup = {0} and idfQueryConditionGroup is null", oldGroupID), "intOrder",
                                               DataViewRowState.CurrentRows);
            foreach (DataRow r in drGroup)
            {
                r["idfParentQueryConditionGroup"] = groupID;
                if (cmdPostFieldCondition == null)
                {
                    cmdPostFieldCondition = CreateSPCommand("spAsQuerySearchFieldCondition_Post", cmdGroup.Transaction);

                    AddTypedParam(cmdPostFieldCondition, "@idfQuerySearchFieldCondition", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmdPostFieldCondition, "@idfQueryConditionGroup", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdPostFieldCondition, "@idfQuerySearchField", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdPostFieldCondition, "@intOrder", SqlDbType.Int, ParameterDirection.Input);
                    AddTypedParam(cmdPostFieldCondition, "@strOperator", SqlDbType.NVarChar, 200, ParameterDirection.Input);
                    AddTypedParam(cmdPostFieldCondition, "@intOperatorType", SqlDbType.Int, ParameterDirection.Input);
                    AddTypedParam(cmdPostFieldCondition, "@blnUseNot", SqlDbType.Bit, ParameterDirection.Input);
                    AddTypedParam(cmdPostFieldCondition, "@varValue", SqlDbType.Variant, ParameterDirection.Input);
                }


                PostFieldCondition(cmdPostFieldCondition, r);
            }
            drGroup = dtGroup.Select(string.Format("idfParentQueryConditionGroup = {0} and idfQueryConditionGroup is not null", oldGroupID), "intOrder",
                                     DataViewRowState.CurrentRows);
            Dictionary<long, int> postedGroups = new Dictionary<long, int>();
            foreach (DataRow r in drGroup)
            {
                r["idfParentQueryConditionGroup"] = groupID;
                if (postedGroups.ContainsKey((long)r["idfQueryConditionGroup"])) continue;
                PostGroup(cmdGroup, dtGroup, r);
                postedGroups.Add((long)r["idfQueryConditionGroup"], 1);
            }
        }

        private IDbCommand cmdPostFieldCondition;

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
        {
            if ((ds == null) ||
                (ds.Tables.Contains(tasQuerySearchObject) == false) ||
                (ds.Tables.Contains(tasQuerySearchField) == false) ||
                (ds.Tables.Contains(tasQueryConditionGroup) == false))
            {
                return true;
            }
            if (IsNewObject)
            {
                // Update ID of object in related tables
                long oldQuerySearchObjectID = -1L;
                if ((ds.Tables[tasQuerySearchObject].Rows[0]["idfQuerySearchObject"] is long) || ds.Tables[tasQuerySearchObject].Rows[0]["idfQuerySearchObject"] is int)
                {
                    oldQuerySearchObjectID = (long)(ds.Tables[tasQuerySearchObject].Rows[0]["idfQuerySearchObject"]);
                }
                ds.Tables[tasQuerySearchObject].Rows[0]["idflQuery"] = m_QueryID;
                ds.Tables[tasQuerySearchObject].Rows[0]["idfQuerySearchObject"] = m_QuerySearchObjectID;
                foreach (DataRow rField in ds.Tables[tasQuerySearchField].Rows)
                {
                    if (rField.RowState != DataRowState.Deleted)
                    {
                        if (Utils.Str(rField["idfQuerySearchObject"]).ToLowerInvariant() == 
                            Utils.Str(oldQuerySearchObjectID).ToLowerInvariant())
                        rField["idfQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                foreach (DataRow rCondition in ds.Tables[tasQueryConditionGroup].Rows)
                {
                    if (rCondition.RowState != DataRowState.Deleted)
                    {
                        if (Utils.Str(rCondition["idfQuerySearchObject"]).ToLowerInvariant() == 
                            Utils.Str(oldQuerySearchObjectID).ToLowerInvariant())
                        rCondition["idfQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                foreach (DataRow rSubQuery in ds.Tables[tasSubquery].Rows)
                {
                    if (rSubQuery.RowState != DataRowState.Deleted)
                    {
                        if (Utils.Str(rSubQuery["idfParentQuerySearchObject"]).ToLowerInvariant() ==
                            Utils.Str(oldQuerySearchObjectID).ToLowerInvariant())
                            rSubQuery["idfParentQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                m_ID = m_QuerySearchObjectID;
            }

            try
            {
                IDbCommand cmdObject = null;
                IDbCommand cmdDeleteSubQueries = null;
                IDbCommand cmdSubQuery = null;
                IDbCommand cmdField = null;
                IDbCommand cmdGroup = null;
                cmdPostFieldCondition = null;

                if (ds.Tables[tasQuerySearchObject].Rows.Count > 0)
                {
                    // Update Report Type for Object
                    DataRow rObject = ds.Tables[tasQuerySearchObject].Rows[0];
                    cmdObject = CreateSPCommand("spAsQuerySearchObject_ReportTypePost", transaction);

                    AddTypedParam(cmdObject, "@idfQuerySearchObject", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdObject, "@idfsReportType", SqlDbType.BigInt, ParameterDirection.Input);

                    SetParam(cmdObject, "@idfQuerySearchObject", m_QuerySearchObjectID, ParameterDirection.Input);
                    SetParam(cmdObject, "@idfsReportType", rObject["idfsReportType"], ParameterDirection.Input);

                    cmdObject.ExecuteNonQuery();


                    // Delete sub-queries with related objects and links from condition groups of object to sub-queries
                    cmdDeleteSubQueries = CreateSPCommand("spAsQuery_DeleteSubqueries", transaction);
                    AddTypedParam(cmdDeleteSubQueries, "@idfParentQuerySearchObject", SqlDbType.BigInt, ParameterDirection.Input);
                    SetParam(cmdDeleteSubQueries, "@idfParentQuerySearchObject", m_QuerySearchObjectID, ParameterDirection.Input);
                    cmdDeleteSubQueries.ExecuteNonQuery();


                    // Sub-queries with root objects
                    if (ds.Tables[tasSubquery].Rows.Count > 0)
                    {

                        cmdSubQuery = CreateSPCommand("spAsSubQuery_PostWithRootObject", transaction);

                        AddTypedParam(cmdSubQuery, "@idflSubQuery", SqlDbType.BigInt, ParameterDirection.InputOutput);
                        AddTypedParam(cmdSubQuery, "@idfSubQuerySearchObject", SqlDbType.BigInt, ParameterDirection.InputOutput);
                        AddTypedParam(cmdSubQuery, "@idfsSearchObject", SqlDbType.BigInt, ParameterDirection.Input);
                        AddTypedParam(cmdSubQuery, "@strFunctionName", SqlDbType.NVarChar, 200, ParameterDirection.InputOutput);
                        AddTypedParam(cmdSubQuery, "@idflSubQueryDescription", SqlDbType.BigInt, ParameterDirection.InputOutput);

                        foreach (DataRow rSubQuery in ds.Tables[tasSubquery].Rows)
                        {
                            PostSubQueryWithRootObject(cmdSubQuery, rSubQuery, ds.Tables[tasSubquerySearchField], ds.Tables[tasQueryConditionGroup]);
                        }
                    }

                    // Fields
                    cmdField = CreateSPCommand("spAsQuerySearchField_Post", transaction);

                    // Fields of object
                    AddTypedParam(cmdField, "@idfQuerySearchField", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmdField, "@idfQuerySearchObject", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdField, "@idfsSearchField", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdField, "@blnShow", SqlDbType.Bit, ParameterDirection.Input);
                    AddTypedParam(cmdField, "@idfsParameter", SqlDbType.BigInt, ParameterDirection.Input);

                    if (ds.Tables[tasQuerySearchField].Rows.Count > 0)
                    {
                        foreach (DataRow rField in ds.Tables[tasQuerySearchField].Rows)
                        {
                            PostField(cmdField, rField, ds.Tables[tasQueryConditionGroup]);
                        }
                    }

                    // Fields of sub-queries
                    if (ds.Tables[tasSubquerySearchField].Rows.Count > 0)
                    {
                        foreach (DataRow rSubQueryField in ds.Tables[tasSubquerySearchField].Rows)
                        {
                            PostField(cmdField, rSubQueryField, ds.Tables[tasQueryConditionGroup]);
                        }
                    }

                    LookupCache.NotifyChange("QuerySearchField", transaction, null);
                }

                // Delete condition groups of object
                IDbCommand cmdDeleteGroups = CreateSPCommand("spAsQuerySearchObject_DeleteConditions", transaction);
                SetParam(cmdDeleteGroups, "@idfQuerySearchObject", m_QuerySearchObjectID, ParameterDirection.Input);
                cmdDeleteGroups.ExecuteNonQuery();

                // Condition groups including sub-queries
                if (ds.Tables[tasQueryConditionGroup].Rows.Count > 0)
                {
                    cmdGroup = CreateSPCommandWithParams("spAsQueryConditionGroup_Post", transaction, null);
                    DataRow[] dr = ds.Tables[tasQueryConditionGroup].Select("idfParentQueryConditionGroup is null",
                                                                           "idfQueryConditionGroup",
                                                                           DataViewRowState.CurrentRows);
                    if (dr.Length > 0)
                    {
                        PostGroup(cmdGroup, ds.Tables[tasQueryConditionGroup], dr[0]);
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
                (ds.Tables.Contains(tasQuerySearchObject) == false) ||
                (ds.Tables.Contains(tasQuerySearchField) == false) ||
                (ds.Tables.Contains(tasQueryConditionGroup) == false) ||
                (ds.Tables.Contains(tasSubquery) == false) ||
                (ds.Tables.Contains(tasSubquerySearchField) == false) ||
                (ds.Tables[tasQuerySearchObject].Rows.Count == 0))
            {
                return;
            }
            if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long)aID >= 0))
            {
                aID = -1L;
            }
            m_QuerySearchObjectID = (long)aID;
            m_QueryID = aQueryID;
            m_IsNewObject = true;

            DataRow rQSO = ds.Tables[tasQuerySearchObject].Rows[0];
            rQSO["idfQuerySearchObject"] = aID;
            rQSO["idflQuery"] = aQueryID;
            m_ID = aID;

            if (ds.Tables[tasQueryConditionGroup].Rows.Count == 0)
            {
                DataRow rQCG = ds.Tables[tasQueryConditionGroup].NewRow();
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
                ds.Tables[tasQueryConditionGroup].Rows.Add(rQCG);
            }
        }
        public static void CreateNewSubQuery(DataSet ds, long queryId, long querySearchObjectId, long parentQuerySearchObjectId, long searchObjectId)
        {
            if (!ds.Tables.Contains(tasSubquery))
                return;
            var dt = ds.Tables[tasSubquery];
            var row = dt.NewRow();
            row["idflQuery"] = queryId;
            row["idfQuerySearchObject"] = querySearchObjectId;
            row["idfParentQuerySearchObject"] = parentQuerySearchObjectId;
            row["idfsSearchObject"] = searchObjectId;
            dt.Rows.Add(row);
        }
        public static DataRow CreateNewSubQuerySearchField(DataSet ds, long querySearchFieldId, long querySearchObjectId, long searchFieldId, string fieldAlias)
        {
            if (!ds.Tables.Contains(tasSubquerySearchField))
                return null;
            var dt = ds.Tables[tasSubquerySearchField];
            var row = dt.NewRow();
            if (querySearchFieldId != 0) //if id is passed explicitly, assign it. In other case it will be calcaulated by autoincrement
                row["idfQuerySearchField"] = querySearchFieldId;

            row["idfQuerySearchObject"] = querySearchObjectId;
            row["idfsSearchField"] = searchFieldId;
            row["FieldAlias"] = fieldAlias;
            row["blnShow"] = false;
            //TODO: Add idfsParameter
            dt.Rows.Add(row);
            return row;
        }
    }
}
