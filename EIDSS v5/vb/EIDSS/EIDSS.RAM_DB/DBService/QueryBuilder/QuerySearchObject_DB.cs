using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;

namespace EIDSS.RAM_DB.DBService.QueryBuilder
{
    public class QuerySearchObject_DB : BaseDbService
    {
        #region Constants

        public const string tasQuerySearchObject = "tasQuerySearchObject";
        public const string tasQuerySearchField = "tasQuerySearchField";
        public const string tasQueryConditionGroup = "tasQueryConditionGroup";

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
                DbDataAdapter QuerySearchObjectAdapter = null;
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
                QuerySearchObjectAdapter = CreateAdapter(cmd, true);
                QuerySearchObjectAdapter.Fill(ds, tasQuerySearchObject);
                ds.EnforceConstraints = false;
                CorrectTable(ds.Tables[0], tasQuerySearchObject, "idfQuerySearchObject");
                CorrectTable(ds.Tables[1], tasQuerySearchField, "idfQuerySearchField");
                CorrectTable(ds.Tables[2], tasQueryConditionGroup, "idfCondition");
                ClearColumnsAttibutes(ds);
                ds.Tables[tasQueryConditionGroup].Columns["SearchFieldConditionText"].MaxLength = int.MaxValue;
                ds.Tables[tasQueryConditionGroup].Columns["idfCondition"].AutoIncrementStep = 1;
                ds.Tables[tasQueryConditionGroup].Columns["idfCondition"].AutoIncrement  = true;
                ds.Tables[tasQueryConditionGroup].Columns["idfCondition"].AutoIncrementSeed = 0;
                ds.Tables[tasQuerySearchField].Columns["TypeImageIndex"].ReadOnly = false;

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
                row["blnJoinByOr"] = DBNull.Value;
                row["blnUseNot"] = false;
                row["idfQuerySearchFieldCondition"] = DBNull.Value;
                row["SearchFieldConditionText"] = "()";
                dt.Rows.Add(row);
            }
            return dt.Rows[0];
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
                SetParam(cmdField, "@idfQuerySearchObject", m_ID, ParameterDirection.Input);
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
                        row["idfQuerySearchField"] = newFieldID;
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
            SetParam(cmdFieldCondition, "@idfQueryConditionGroup", rFieldCondition["idfQueryConditionGroup"],
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
                ((IDataParameter) cmdPostFieldCondition.Parameters["@idfQuerySearchFieldCondition"]).Value;
        }

        private void PostGroup(IDbCommand cmdGroup, DataTable dtGroup, DataRow rGroup)
        {
            if ((cmdGroup == null) || (dtGroup == null) || (rGroup == null))
            {
                return;
            }
            object oldGroupID = rGroup["idfQueryConditionGroup"];

            SetParam(cmdGroup, "@idfQuerySearchObject", m_ID, ParameterDirection.Input);
            SetParam(cmdGroup, "@intOrder", rGroup["intOrder"], ParameterDirection.Input);
            SetParam(cmdGroup, "@idfParentQueryConditionGroup", rGroup["idfParentQueryConditionGroup"],
                     ParameterDirection.Input);
            SetParam(cmdGroup, "@blnJoinByOr", rGroup["blnJoinByOr"], ParameterDirection.Input);
            SetParam(cmdGroup, "@blnUseNot", rGroup["blnUseNot"], ParameterDirection.Input);
            cmdGroup.ExecuteNonQuery();

            object groupID = ((IDataParameter) cmdGroup.Parameters["@idfQueryConditionGroup"]).Value;
            //update all group rows with new groupID value returned by stored procedure
            DataRow[] drGroup = dtGroup.Select(string.Format("idfQueryConditionGroup = {0} ", oldGroupID), "intOrder",
                                               DataViewRowState.CurrentRows);
            foreach (DataRow r in drGroup)
            {
                r["idfQueryConditionGroup"] = groupID;
                if (cmdPostFieldCondition == null)
                    cmdPostFieldCondition = CreateSPCommandWithParams("spAsQuerySearchFieldCondition_Post",
                                                                      cmdGroup.Transaction, null);
                PostFieldCondition(cmdPostFieldCondition, r);
            }
            drGroup = dtGroup.Select(string.Format("idfParentQueryConditionGroup = {0} ", oldGroupID), "intOrder",
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

        public override bool PostDetail(DataSet ds, int PostType, IDbTransaction transaction)
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
                ds.Tables[tasQuerySearchObject].Rows[0]["idflQuery"] = m_QueryID;
                ds.Tables[tasQuerySearchObject].Rows[0]["idfQuerySearchObject"] = m_QuerySearchObjectID;
                foreach (DataRow rCondition in ds.Tables[tasQueryConditionGroup].Rows)
                {
                    if (rCondition.RowState != DataRowState.Deleted)
                    {
                        rCondition["idfQuerySearchObject"] = m_QuerySearchObjectID;
                    }
                }
                m_ID = m_QuerySearchObjectID;
            }

            try
            {
                IDbCommand cmdField = null;
                IDbCommand cmdGroup = null;
                cmdPostFieldCondition = null;
                if (ds.Tables[tasQuerySearchObject].Rows.Count > 0)
                {
                    cmdField = CreateSPCommand("spAsQuerySearchField_Post", transaction);

                    AddTypedParam(cmdField, "@idfQuerySearchField", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmdField, "@idfQuerySearchObject", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdField, "@idfsSearchField", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdField, "@blnShow", SqlDbType.Bit, ParameterDirection.Input);
                    AddTypedParam(cmdField, "@idfsParameter", SqlDbType.BigInt, ParameterDirection.Input);

                    if (ds.Tables[tasQuerySearchField].Rows.Count > 0)
                    {
                        foreach (DataRow rField in ds.Tables[tasQuerySearchField].Rows)
                        {
                            object fieldID = -1L;
                            if (rField.RowState == DataRowState.Deleted)
                            {
                                fieldID = rField["idfQuerySearchField", DataRowVersion.Original];
                            }
                            else
                            {
                                fieldID = rField["idfQuerySearchField"];
                                rField["idfQuerySearchObject"] = m_ID;
                            }
                            PostField(cmdField, rField, ds.Tables[tasQueryConditionGroup]);
                        }
                    }
                    LookupCache.NotifyChange("QuerySearchField", transaction, null);
                }

                IDbCommand cmd = CreateSPCommand("spAsQuerySearchObject_DeleteConditions", transaction);
                SetParam(cmd, "@idfQuerySearchObject", m_QuerySearchObjectID, ParameterDirection.Input);
                cmd.ExecuteNonQuery();

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
                (ds.Tables[tasQuerySearchObject].Rows.Count == 0))
            {
                return;
            }
            if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long)aID >= 0))
            {
                aID = -1L;
            }
            m_QuerySearchObjectID = (long) aID;
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
                rQCG["SearchFieldConditionText"] = "()";
                ds.EnforceConstraints = false;
                ds.Tables[tasQueryConditionGroup].Rows.Add(rQCG);
            }
        }
    }
}
