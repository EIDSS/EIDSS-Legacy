using System;
using System.Data;
using System.Text;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using EIDSS;

using eidss.model.Avr;
using eidss.model.AVR.Db;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.WindowsService.Serialization;
using Ionic.Zlib;

namespace eidss.avr.db.DBService
{
    public class BaseAvrDbService : BaseDbService
    {
        public BaseAvrDbService()
        {
            UseDatasetCopyInPost = false;
        }

        public override DataSet GetDetail(object id)
        {
            var ds = new DataSet();
            m_ID = id;
            return (ds);
        }

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            return true;
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

        #region publish & unpublish

        public void PublishUnpublish(long id, AvrTreeElementType type, bool isPublish)
        {
            long globalId = -1;
            if (!isPublish)
            {
                globalId = AvrQueryLayoutTreeDbHelper.GetGlobalId(id, type);
            }
            // todo: refactor to use new framework here
            lock (Connection)
            {
                try
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    using (IDbTransaction transaction = Connection.BeginTransaction())
                    {
                        try
                        {
                            if (isPublish)
                            {
                                Publish(id, transaction, type);
                            }
                            else
                            {
                                Unpublish(globalId, transaction, type);
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                finally
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                }
            }
        }

        private void Publish(long id, IDbTransaction transaction, AvrTreeElementType type)
        {
            string spName;
            string inputParamName;
            string outputParamName;

            EventType eventType;

            switch (type)
            {
                case AvrTreeElementType.Layout:
                    spName = "spAsLayoutPublish";
                    inputParamName = "@idflLayout";
                    outputParamName = "@idfsLayout";
                    eventType = EventType.AVRLayoutPublishedLocal;
                    break;
                case AvrTreeElementType.Folder:
                    spName = "spAsFolderPublish";
                    inputParamName = "@idflLayoutFolder";
                    outputParamName = "@idfsLayoutFolder";
                    eventType = EventType.AVRLayoutFolderPublishedLocal;
                    break;
                case AvrTreeElementType.Query:
                    spName = "spAsQueryPublish";
                    inputParamName = "@idflQuery";
                    outputParamName = "@idfsQuery";
                    eventType = EventType.AVRQueryPublishedLocal;
                    break;
                default:
                    throw new AvrException("Unsupported AvrTreeElementType " + type);
            }

            object publishedId;
            using (IDbCommand cmd = CreateSPCommand(spName, transaction))
            {
                AddAndCheckParam(cmd, inputParamName, id);

                AddTypedParam(cmd, outputParamName, SqlDbType.BigInt, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                publishedId = GetParamValue(cmd, outputParamName);
            }

            LookupCache.NotifyChange("Layout", transaction);
            LookupCache.NotifyChange("LayoutFolder", transaction);
            LookupCache.NotifyChange("Query", transaction);

            if (publishedId != null)
            {

                EidssEventLog.Instance.CreateProcessedEvent(eventType,
                    id, 0, 0, null,
                    EidssUserContext.User.ID,
                    transaction);

            }
        }

        private void Unpublish(long publisedId, IDbTransaction transaction, AvrTreeElementType type)
        {
            string spName;
            string inputParamName;
            string outputParamName;
            EventType eventType;

            switch (type)
            {
                case AvrTreeElementType.Layout:
                    spName = "spAsLayoutUnpublish";
                    inputParamName = "@idfsLayout";
                    outputParamName = "@idflLayout";
                    eventType = EventType.AVRLayoutUnpublishedLocal;
                    break;
                case AvrTreeElementType.Folder:
                    spName = "spAsFolderUnpublish";
                    inputParamName = "@idfsLayoutFolder";
                    outputParamName = "@idflLayoutFolder";
                    eventType = EventType.AVRLayoutFolderUnpublishedLocal;
                    break;
                case AvrTreeElementType.Query:
                    spName = "spAsQueryUnpublish";
                    inputParamName = "@idfsQuery";
                    outputParamName = "@idflQuery";
                    eventType = EventType.AVRQueryUnpublishedLocal;
                    break;
                default:
                    throw new AvrException("Unsupported AvrTreeElementType " + type);
            }
            object id = null;
            using (IDbCommand cmd = CreateSPCommand(spName, transaction))
            {
                AddAndCheckParam(cmd, inputParamName, publisedId);
                AddTypedParam(cmd, outputParamName, SqlDbType.BigInt, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                id = GetParamValue(cmd, outputParamName);
            }

            LookupCache.NotifyChange("Layout", transaction);
            LookupCache.NotifyChange("LayoutFolder", transaction);
            LookupCache.NotifyChange("Query", transaction);
            //Create event for local element, because local element shall be opened when we click to event
            EidssEventLog.Instance.CreateProcessedEvent(eventType,
                id, 0, 0, null,
                EidssUserContext.User.ID,
                transaction);

        }

        #endregion

        #region Helper Methods

        internal void ChangeIdForNewObject(long newId)
        {
            m_ID = m_IsNewObject
                ? newId
                : CorrectId(m_ID, newId);
        }

        internal static long CorrectId(object id, long defaultId)
        {
            if (Utils.IsEmpty(id) || (!(id is long)) || ((long)id <= 0))
            {
                id = defaultId;
            }
            return (long)id;
        }






        public void AddAndCheckParam(IDbCommand cmd, DataColumn paramColumn, object paramValue)
        {
            Utils.CheckNotNullOrEmpty(paramColumn.ColumnName, "paramColumn.ColumnName");
            AddAndCheckParam(cmd, string.Format("@{0}", paramColumn.ColumnName), paramValue);
        }

        public void AddAndCheckParam(IDbCommand cmd, string paramName, object paramValue)
        {
            AddAndCheckParam(cmd, paramName, paramValue, ParameterDirection.Input);
        }

        public void AddAndCheckParam(IDbCommand cmd, string paramName, object paramValue, ParameterDirection direction)
        {
            Utils.CheckNotNull(cmd, "cmd");
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(paramValue, "paramValue");

            AddParam(cmd, paramName, paramValue, ref m_Error, direction);

            if (m_Error != null)
            {
                throw new AvrDbException(m_Error.Text);
            }
        }

        #endregion
    }
}