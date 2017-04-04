using System;
using System.Data;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using eidss.model.Avr.Tree;
using eidss.model.Enums;

namespace eidss.avr.db.DBService.QueryBuilder
{
    public class Query_DB : BaseAvrDbService
    {
        public const string TasQuery = @"tasQuery";
        public const string TasQueryObjectTree = @"tasQueryObjectTree";

        public Query_DB()
        {
            ObjectName = @"AsQuery";
        }

        public override AvrTreeElementType ElementType
        {
            get { return AvrTreeElementType.Query; }
        }

        #region Get Detail

        public override DataSet GetDetail(object id)
        {
            var ds = new DataSet();
            try
            {
                IDbCommand cmd = CreateSPCommand("spAsQuery_SelectDetail");
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
                FillDataset(cmd, ds, TasQuery);
                CorrectTable(ds.Tables[0], TasQuery, "idflQuery");
                CorrectTable(ds.Tables[1], TasQueryObjectTree, "idfQuerySearchObject");
                ClearColumnsAttibutes(ds);

                if (ds.Tables[TasQuery].Rows.Count == 0)
                {
                    if (Utils.IsEmpty(id) || (!(id is long)) || ((long) id >= 0))
                    {
                        id = -1L;
                    }
                    m_IsNewObject = true;

                    DataRow rQuery = ds.Tables[TasQuery].NewRow();
                    rQuery["idflQuery"] = id;
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
                    rObject["idflQuery"] = id;
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

                m_ID = id;
                return (ds);
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            return null;
        }

        #endregion

        #region Post

        private void PostObject(IDbCommand cmdObj, DataTable dtObj, DataRow rObj)
        {
            if ((cmdObj == null) || (dtObj == null) || (rObj == null))
            {
                return;
            }
            object objID;
            if (rObj.RowState == DataRowState.Deleted)
            {
                objID = rObj["idfQuerySearchObject", DataRowVersion.Original];
                if ((Utils.IsEmpty(objID) == false) && (objID is long) && ((long) objID > 0))
                {
                    SetParam(cmdObj, "@idfQuerySearchObject", objID, ParameterDirection.InputOutput);
                    SetParam(cmdObj, "@idflQuery", -1L);
                    SetParam(cmdObj, "@idfsSearchObject", DBNull.Value);
                    SetParam(cmdObj, "@intOrder", 0);
                    SetParam(cmdObj, "@idfParentQuerySearchObject", DBNull.Value);

                    ExecCommand(cmdObj, cmdObj.Connection, cmdObj.Transaction, true);
                }
                return;
            }

            objID = rObj["idfQuerySearchObject"];
            rObj["idflQuery"] = m_ID;

            SetParam(cmdObj, "@idfQuerySearchObject", objID, ParameterDirection.InputOutput);
            SetParam(cmdObj, "@idflQuery", m_ID);
            SetParam(cmdObj, "@idfsSearchObject", rObj["idfsSearchObject"]);
            SetParam(cmdObj, "@intOrder", rObj["intOrder"]);
            SetParam(cmdObj, "@idfParentQuerySearchObject", rObj["idfParentQuerySearchObject"]);

            ExecCommand(cmdObj, cmdObj.Connection, cmdObj.Transaction, true);
            rObj["idfQuerySearchObject"] = ((IDataParameter)cmdObj.Parameters["@idfQuerySearchObject"]).Value;

            foreach (ServiceParam service in m_LinkedServices)
            {
                if (service.m_ServiceType == RelatedPostOrder.PostLast)
                {
                    if (service.m_Service is QuerySearchObject_DB)
                    {
                        var qsoDBService = service.m_Service as QuerySearchObject_DB;
                        if (Utils.Str(qsoDBService.ID) == Utils.Str(objID))
                        {
                            qsoDBService.QueryID = (long) m_ID;
                            qsoDBService.QuerySearchObjectID = (long) rObj["idfQuerySearchObject"];
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

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
        {
            if ((ds == null))
            {
                return true;
            }
            try
            {
                if (ds.Tables[TasQuery].Rows.Count > 0)
                {
                    DataRow rQuery = ds.Tables[TasQuery].Rows[0];
                    IDbCommand cmd = CreateSPCommand("spAsQuery_Post", transaction);

                    AddTypedParam(cmd, "@idflQuery", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmd, "@strFunctionName", SqlDbType.NVarChar, 200, ParameterDirection.InputOutput);
                    AddTypedParam(cmd, "@idflDescription", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmd, "@QueryName", SqlDbType.NVarChar, 2000);
                    AddTypedParam(cmd, "@DefQueryName", SqlDbType.NVarChar, 2000);
                    AddTypedParam(cmd, "@QueryDescription", SqlDbType.NVarChar, 2000);
                    AddTypedParam(cmd, "@DefQueryDescription", SqlDbType.NVarChar, 2000);
                    AddTypedParam(cmd, "@blnAddAllKeyFieldValues", SqlDbType.Bit);
                    AddTypedParam(cmd, "@LangID", SqlDbType.NVarChar, 50);

                    SetParam(cmd, "@idflQuery", rQuery["idflQuery"], ParameterDirection.InputOutput);
                    SetParam(cmd, "@strFunctionName", rQuery["strFunctionName"], ParameterDirection.InputOutput);
                    SetParam(cmd, "@idflDescription", rQuery["idflDescription"], ParameterDirection.InputOutput);
                    SetParam(cmd, "@QueryName", rQuery["QueryName"]);
                    SetParam(cmd, "@DefQueryName", rQuery["DefQueryName"]);
                    SetParam(cmd, "@QueryDescription", rQuery["QueryDescription"]);
                    SetParam(cmd, "@DefQueryDescription", rQuery["DefQueryDescription"]);
                    SetParam(cmd, "@blnAddAllKeyFieldValues", rQuery["blnAddAllKeyFieldValues"]);
                    SetParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);

                    ExecCommand(cmd, cmd.Connection, transaction, true);
                    m_ID = ((IDataParameter)cmd.Parameters["@idflQuery"]).Value;
                    rQuery["idflQuery"] = m_ID;
                    rQuery["strFunctionName"] = ((IDataParameter) cmd.Parameters["@strFunctionName"]).Value;

                    IDbCommand cmdObj = CreateSPCommand("spAsQuerySearchObject_Post", transaction);

                    AddTypedParam(cmdObj, "@idfQuerySearchObject", SqlDbType.BigInt, ParameterDirection.InputOutput);
                    AddTypedParam(cmdObj, "@idflQuery", SqlDbType.BigInt);
                    AddTypedParam(cmdObj, "@idfsSearchObject", SqlDbType.VarChar, 36);
                    AddTypedParam(cmdObj, "@intOrder", SqlDbType.Int);
                    AddTypedParam(cmdObj, "@idfParentQuerySearchObject", SqlDbType.BigInt);

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
                    LookupCache.NotifyChange("Query", transaction, ID);
                }
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
            return true;
        }

        public bool CreateFunction()
        {
            IDbCommand cmd = CreateSPCommand("spAsQueryFunction_Post", Connection);
            AddTypedParam(cmd, "@QueryID", SqlDbType.BigInt);
            SetParam(cmd, "@QueryID", m_ID);
            m_Error = ExecCommand(cmd, Connection, null, true);
            return (m_Error == null);
        }

        #endregion

        #region create Copy

        public void Copy(DataSet ds, object aID)
        {
            if ((ds == null) || (ds.Tables.Contains(TasQuery) == false) || (ds.Tables[TasQuery].Rows.Count == 0))
            {
                return;
            }
            if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long) aID >= 0))
            {
                aID = -1L;
            }
            m_IsNewObject = true;

            DataRow rQuery = ds.Tables[TasQuery].Rows[0];
            rQuery["idflQuery"] = aID;
            rQuery["idflDescription"] = DBNull.Value;
            m_ID = aID;
        }

        #endregion

        #region Publish Unpublish

        protected override long Unpublish(long publishedId, IDbTransaction transaction)
        {
            long id;
            using (IDbCommand cmd = CreateSPCommand("spAsQueryUnpublish", transaction))
            {
                AddAndCheckParam(cmd, "@idfsQuery", publishedId);
                AddTypedParam(cmd, "@idflQuery", SqlDbType.BigInt, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                id = (long)GetParamValue(cmd, "@idflQuery");
            }

            AfterPublishUnpublish(EventType.AVRQueryUnpublishedLocal, id, publishedId, transaction);
            return id;
        }

        protected override long Publish(long id, IDbTransaction transaction)
        {
            long publishedId;
            using (IDbCommand cmd = CreateSPCommand("spAsQueryPublish", transaction))
            {
                AddAndCheckParam(cmd, "@idflQuery", id);
                AddTypedParam(cmd, "@idfsQuery", SqlDbType.BigInt, ParameterDirection.Output);

                cmd.ExecuteNonQuery();
                publishedId = (long)GetParamValue(cmd, "@idfsQuery");
            }

            AfterPublishUnpublish(EventType.AVRQueryPublishedLocal, id, publishedId, transaction);
            return publishedId;
        }

        #endregion
    }
}