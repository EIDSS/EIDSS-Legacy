using System;
using System.Data;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using eidss.avr.db.Common;
using eidss.model.Avr;
using eidss.model.AVR.DataBase;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.avr.db.DBService
{
    public class BaseAvrDbService : BaseDbService
    {
        public BaseAvrDbService()
        {
            UseDatasetCopyInPost = false;
        }

        public virtual AvrTreeElementType ElementType
        {
            get { throw new NotImplementedException("Base DB service doesn't have ElementType. Use concrete DB service"); }
        }

        #region Get 

        public override DataSet GetDetail(object id)
        {
            var ds = new DataSet();
            m_ID = id;
            return (ds);
        }

        protected AvrBinarySettings GetLayoutGlobalBinarySettings(object layoutId, IDbTransaction transaction)
        {
            return GetLayoutBinarySettings(layoutId, true, transaction);
        }

        protected AvrBinarySettings GetLayoutLocalBinarySettings(object layoutId, IDbTransaction transaction)
        {
            return GetLayoutBinarySettings(layoutId, false, transaction);
        }

        private AvrBinarySettings GetLayoutBinarySettings(object layoutId, bool isGlobal = false, IDbTransaction transaction = null)
        {
            var settings = new AvrBinarySettings();
            string spName = isGlobal ? "spAsGlobalLayoutBinarySelect" : "spAsLayoutBinarySelect";
            string paramName = isGlobal ? "@idfsLayout" : "@idflLayout";
            using (IDbCommand cmd = CreateSPCommand(spName, transaction))
            {
                AddAndCheckParam(cmd, paramName, layoutId);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["blbChartGeneralSettings"] is byte[])
                        {
                            settings.ChartSettings = (byte[]) reader["blbChartGeneralSettings"];
                        }
                        if (reader["blbGisLayerGeneralSettings"] is byte[])
                        {
                            settings.GisLayerSettings = (byte[]) reader["blbGisLayerGeneralSettings"];
                        }
                        if (reader["blbGisMapGeneralSettings"] is byte[])
                        {
                            settings.GisMapSettings = (byte[]) reader["blbGisMapGeneralSettings"];
                        }
                        var ids = reader["intGisLayerPosition"];
                        if (!Utils.IsEmpty(ids))
                        {
                            settings.GisLayerPosition = (int?)ids;
                        }
                        if (reader["blbPivotGridSettings"] is byte[])
                        {
                            settings.MainSettings = (byte[]) reader["blbPivotGridSettings"];
                        }
                        settings.Version = (PivotGridXmlVersion) (int) reader["intPivotGridXmlVersion"];
                    }
                }
            }
            return settings;
        }

        #endregion

        #region Post

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            return true;
        }

        #endregion

        #region Base methods

        public override void AcceptChanges(DataSet ds)
        {
            // this method should duplicate base method but WITHOUT line m_IsNewObject = false
            foreach (DataTable table in ds.Tables)
            {
                if (!SkipAcceptChanges(table))
                {
                    table.AcceptChanges();
                }
            }
            RaiseAcceptChangesEvent(ds);
        }

        #endregion

        #region Publish & unpublish

        public long PublishUnpublish(long id, bool isPublish)
        {
            long result;
            long globalId = -1;
            if (!isPublish)
            {
                globalId = AvrQueryLayoutTreeDbHelper.GetGlobalId(id, ElementType);
            }
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
                            result = isPublish
                                ? Publish(id, transaction)
                                : Unpublish(globalId, transaction);

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
            return result;
        }

        protected virtual long Publish(long id, IDbTransaction transaction)
        {
            throw new NotImplementedException("Publish method not implemented in base DB service. Use concrete DB service");
        }

        protected virtual long Unpublish(long publishedId, IDbTransaction transaction)
        {
            throw new NotImplementedException("Unpublish method not implemented in base DB service. Use concrete DB service");
        }

        protected static void AfterPublishUnpublish(EventType eventType, object localId, object publishedId, IDbTransaction transaction)
        {
            LookupCache.NotifyChange("Layout", transaction);
            LookupCache.NotifyChange("LayoutFolder", transaction);
            LookupCache.NotifyChange("Query", transaction);
            //Create event for local element, because local element shall be opened when we click to event
            EidssEventLog.Instance.CreateProcessedEvent(eventType,
                localId, 0, 0, null,
                EidssUserContext.User.ID,
                transaction, Utils.Str(publishedId));
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
            if (Utils.IsEmpty(id) || (!(id is long)) || ((long) id <= 0))
            {
                id = defaultId;
            }
            return (long) id;
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