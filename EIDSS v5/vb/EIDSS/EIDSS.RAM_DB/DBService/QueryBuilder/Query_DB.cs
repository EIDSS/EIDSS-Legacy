using System;
using System.Data;
using System.Data.Common;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;


namespace EIDSS.RAM_DB.DBService.QueryBuilder
{
    public class Query_DB : BaseDbService
    {
        public const string TasQuery = @"tasQuery";
        public const string TasQueryObjectTree = @"tasQueryObjectTree";

        public Query_DB()
        {
            ObjectName = @"Query";
            UseDatasetCopyInPost = false;
        }

        public override DataSet GetDetail(object ID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbDataAdapter queryAdapter = null;
                IDbCommand cmd = CreateSPCommand("spAsQuery_SelectDetail", null);
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
                queryAdapter = CreateAdapter(cmd, false);
                queryAdapter.Fill(ds, TasQuery);
                CorrectTable(ds.Tables[0], TasQuery, "idflQuery");
                CorrectTable(ds.Tables[1], TasQueryObjectTree, "idfQuerySearchObject");
                ClearColumnsAttibutes(ds);

                if (ds.Tables[TasQuery].Rows.Count == 0)
                {
                    if (Utils.IsEmpty(ID) || (!(ID is long)) || ((long)ID >= 0))
                    {
                        ID = -1L;
                    }
                    m_IsNewObject = true;

                    DataRow rQuery = ds.Tables[TasQuery].NewRow();
                    rQuery["idflQuery"] = ID;
                    ds.EnforceConstraints = false;
                    ds.Tables[TasQuery].Rows.Add(rQuery);
                }
                else
                {
                    m_IsNewObject = false;
                }
                if (ds.Tables[TasQueryObjectTree].Rows.Count == 0)
                {
                    DataRow rObject = ds.Tables[TasQueryObjectTree].NewRow();
                    rObject["idflQuery"] = ID;
                    rObject["idfQuerySearchObject"] = -1L;
                    rObject["idfParentQuerySearchObject"] = DBNull.Value;
                    rObject["idfsSearchObject"] = 10082000; // "sobHumanCases"
                    rObject["intOrder"] = 0;
                    ds.EnforceConstraints = false;
                    ds.Tables[TasQueryObjectTree].Rows.Add(rObject);
                }

                //ds.Tables[tasQuery].Columns["QueryName"].ReadOnly = false;
                //ds.Tables[tasQuery].Columns["QueryName"].AllowDBNull = true;
                ds.Tables[TasQuery].Columns["blnReadOnly"].ReadOnly = false;
                ds.Tables[TasQuery].Columns["blnReadOnly"].AllowDBNull = true;
                ds.Tables[TasQuery].Columns["QueryName"].ReadOnly = false;
                ds.Tables[TasQuery].Columns["QueryName"].AllowDBNull = true;
                ds.Tables[TasQuery].Columns["DefQueryName"].ReadOnly = false;
                ds.Tables[TasQuery].Columns["DefQueryName"].AllowDBNull = true;
                ds.Tables[TasQuery].Columns["QueryDescription"].ReadOnly = false;
                ds.Tables[TasQuery].Columns["QueryDescription"].AllowDBNull = true;
                ds.Tables[TasQuery].Columns["DefQueryDescription"].ReadOnly = false;
                ds.Tables[TasQuery].Columns["DefQueryDescription"].AllowDBNull = true;

                m_ID = ID;
                return (ds);
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            return null;
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


        private void PostObject(IDbCommand cmdObj, DataTable dtObj, DataRow rObj)
        {
            if ((cmdObj == null) || (dtObj == null) || (rObj == null))
            {
                return;
            }
            object objID = null;
            if (rObj.RowState == DataRowState.Deleted)
            {
                objID = rObj["idfQuerySearchObject", DataRowVersion.Original];
                if ((Utils.IsEmpty(objID) == false) && (objID is long) && ((long)objID > 0))
                {
                    SetParam(cmdObj, "@idfQuerySearchObject", objID, ParameterDirection.InputOutput);
                    SetParam(cmdObj, "@idflQuery", -1L, ParameterDirection.Input);
                    SetParam(cmdObj, "@idfsSearchObject", DBNull.Value, ParameterDirection.Input);
                    SetParam(cmdObj, "@intOrder", 0, ParameterDirection.Input);
                    SetParam(cmdObj, "@idfParentQuerySearchObject", DBNull.Value, ParameterDirection.Input);

                    cmdObj.ExecuteNonQuery();
                }
                return;
            }

            objID = rObj["idfQuerySearchObject"];
            rObj["idflQuery"] = m_ID;

            SetParam(cmdObj, "@idfQuerySearchObject", objID, ParameterDirection.InputOutput);
            SetParam(cmdObj, "@idflQuery", m_ID, ParameterDirection.Input);
            SetParam(cmdObj, "@idfsSearchObject", rObj["idfsSearchObject"], ParameterDirection.Input);
            SetParam(cmdObj, "@intOrder", rObj["intOrder"], ParameterDirection.Input);
            SetParam(cmdObj, "@idfParentQuerySearchObject", rObj["idfParentQuerySearchObject"],
                     ParameterDirection.Input);

            cmdObj.ExecuteNonQuery();
            rObj["idfQuerySearchObject"] = ((IDataParameter) cmdObj.Parameters["@idfQuerySearchObject"]).Value;

            foreach (ServiceParam service in m_LinkedServices)
            {
                if (service.serviceType == RelatedPostOrder.PostLast)
                {
                    if (service.service is QuerySearchObject_DB)
                    {
                        QuerySearchObject_DB qsoDBService = service.service as QuerySearchObject_DB;
                        if (Utils.Str(qsoDBService.ID) == Utils.Str(objID))
                        {
                            qsoDBService.QueryID = (long)m_ID;
                            qsoDBService.QuerySearchObjectID = (long)rObj["idfQuerySearchObject"];
                            break;
                        }
                    }
                }
            }

            DataRow[] drObjDel = dtObj.Select(string.Format("idfParentQuerySearchObject = {0} ", objID),
                                              "idfQuerySearchObject", DataViewRowState.Deleted);
            foreach (DataRow r in drObjDel)
            {
                PostObject(cmdObj, dtObj, r);
            }
            DataRow[] drObj = dtObj.Select(string.Format("idfParentQuerySearchObject = {0} ", objID), "intOrder",
                                           DataViewRowState.CurrentRows);
            foreach (DataRow r in drObj)
            {
                DataRow childObj = dtObj.Rows.Find(r["idfQuerySearchObject"]);
                if (childObj != null)
                {
                    childObj["idfParentQuerySearchObject"] = rObj["idfQuerySearchObject"];
                }
                PostObject(cmdObj, dtObj, childObj);
            }
        }

        public override bool PostDetail(DataSet ds, int PostType, IDbTransaction transaction)
        {
            if ((ds == null))
            {
                return true;
            }
            try
            {
                IDbCommand cmd = null;
                IDbCommand cmdObj = null;

                if (ds.Tables[TasQuery].Rows.Count > 0)
                {
                    DataRow rQuery = ds.Tables[TasQuery].Rows[0];
                    cmd = CreateSPCommand("spAsQuery_Post", transaction);

                    AddTypedParam(cmd, "@idflQuery", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmd, "@strFunctionName", SqlDbType.NVarChar, 200, ParameterDirection.InputOutput);
                    AddTypedParam(cmd, "@idflDescription", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmd, "@QueryName", SqlDbType.NVarChar, 2000, ParameterDirection.Input);
                    AddTypedParam(cmd, "@DefQueryName", SqlDbType.NVarChar, 2000, ParameterDirection.Input);
                    AddTypedParam(cmd, "@QueryDescription", SqlDbType.NVarChar, 2000, ParameterDirection.Input);
                    AddTypedParam(cmd, "@DefQueryDescription", SqlDbType.NVarChar, 2000, ParameterDirection.Input);
                    AddTypedParam(cmd, "@blnAddAllKeyFieldValues", SqlDbType.Bit, ParameterDirection.Input);
                    AddTypedParam(cmd, "@LangID", SqlDbType.NVarChar, 50, ParameterDirection.Input);

                    SetParam(cmd, "@idflQuery", rQuery["idflQuery"], ParameterDirection.InputOutput);
                    SetParam(cmd, "@strFunctionName", rQuery["strFunctionName"], ParameterDirection.InputOutput);
                    SetParam(cmd, "@idflDescription", rQuery["idflDescription"], ParameterDirection.InputOutput);
                    SetParam(cmd, "@QueryName", rQuery["QueryName"], ParameterDirection.Input);
                    SetParam(cmd, "@DefQueryName", rQuery["DefQueryName"], ParameterDirection.Input);
                    SetParam(cmd, "@QueryDescription", rQuery["QueryDescription"], ParameterDirection.Input);
                    SetParam(cmd, "@DefQueryDescription", rQuery["DefQueryDescription"], ParameterDirection.Input);
                    SetParam(cmd, "@blnAddAllKeyFieldValues", rQuery["blnAddAllKeyFieldValues"], ParameterDirection.Input);
                    SetParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                    m_ID = ((IDataParameter) cmd.Parameters["@idflQuery"]).Value;
                    rQuery["idflQuery"] = m_ID;
                    rQuery["strFunctionName"] = ((IDataParameter) cmd.Parameters["@strFunctionName"]).Value;

                    LookupCache.NotifyChange("Query", transaction, ID);

                    cmdObj = CreateSPCommand("spAsQuerySearchObject_Post", transaction);

                    AddTypedParam(cmdObj, "@idfQuerySearchObject", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmdObj, "@idflQuery", SqlDbType.BigInt, ParameterDirection.Input);
                    AddTypedParam(cmdObj, "@idfsSearchObject", SqlDbType.VarChar, 36, ParameterDirection.Input);
                    AddTypedParam(cmdObj, "@intOrder", SqlDbType.Int, ParameterDirection.Input);
                    AddTypedParam(cmdObj, "@idfParentQuerySearchObject", SqlDbType.BigInt, ParameterDirection.Input);

                    if (ds.Tables[TasQueryObjectTree].Rows.Count > 0)
                    {
                        DataRow[] dr = ds.Tables[TasQueryObjectTree].Select("idfParentQuerySearchObject is null",
                                                                           "idfQuerySearchObject",
                                                                           DataViewRowState.CurrentRows);
                        if (dr.Length > 0)
                        {
                            DataRow rRoot = ds.Tables[TasQueryObjectTree].Rows.Find(dr[0]["idfQuerySearchObject"]);
                            if (rRoot != null)
                            {
                                PostObject(cmdObj, ds.Tables[TasQueryObjectTree], rRoot);
                            }
                        }
                    }
                    m_IsNewObject = false;
                }
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
            return true;
        }

        public void Copy(DataSet ds, object aID)
        {
            if ((ds == null) || (ds.Tables.Contains(TasQuery) == false) || (ds.Tables[TasQuery].Rows.Count == 0))
            {
                return;
            }
            if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long)aID >= 0))
            {
                aID = -1L;
            }
            m_IsNewObject = true;

            DataRow rQuery = ds.Tables[TasQuery].Rows[0];
            rQuery["idflQuery"] = aID;
            m_ID = aID;
        }

        public bool CreateFunction()
        {
            IDbCommand cmd = CreateSPCommand("spAsQueryFunction_Post", Connection, null);
            AddTypedParam(cmd, "@QueryID", SqlDbType.BigInt, ParameterDirection.Input);
            SetParam(cmd, "@QueryID", m_ID, ParameterDirection.Input);
            m_Error = ExecCommand(cmd, Connection, null, false);
            return (m_Error == null);
        }
    }
}
