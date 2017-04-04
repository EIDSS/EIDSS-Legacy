using System;
using System.ServiceModel;
using System.Web;
using bv.common;
using bv.model.Model.Core;
using eidss.avr.db.Common;
using eidss.avr.db.Complexity;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Resources;

namespace eidss.avr.db.CacheReceiver
{
    public static class ServiceClientHelper
    {
        #region Properties

        public static bool IsWeb
        {
            get { return HttpContext.Current != null; }
        }

        public static string MsgNotAccessable
        {
            get
            {
                string name = IsWeb ? "msgAvrServiceNotAccessableWeb" : "msgAvrServiceNotAccessable";
                return EidssMessages.Get(name);
            }
        }

        public static string MsgError
        {
            get
            {
                string name = IsWeb ? "msgAvrServiceErrorWeb" : "msgAvrServiceError";
                return EidssMessages.Get(name);
            }
        }

        #endregion

        #region Exec Query

        public static CachedQueryResult ExecQuery(long queryId, bool isArchive, bool forExport = false)
        {
            try
            {
                CachedQueryResult result;
                if (queryId > 0)
                {
                    CallAvrServiceToForceLOHMemoryAllocations();

                    result = GetAvrServiceQueryResult(queryId, isArchive);

                    result.QueryTable.TableName = QueryProcessor.GetQueryName(queryId);
                    QueryProcessor.SetCopyPropertyForColumnsIfNeeded(result.QueryTable);
                    QueryProcessor.TranslateTableFields(result.QueryTable, queryId);
                    QueryProcessor.SetNullForForbiddenTableFields(result.QueryTable, queryId);
                }
                else
                {
                    result = new CachedQueryResult(queryId, new AvrDataTable());
                }
                QueryProcessor.RemoveNotExistingColumns(result.QueryTable, queryId, forExport);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new AvrDbException(String.Format("Error while executing query with id '{0}'", queryId), ex);
            }
        }

        public static void RefreshQuery(long queryId)
        {
            try
            {
                if (queryId > 0)
                {
                    CallAvrServiceToForceLOHMemoryAllocations();

                    bool isArchive = QueryLookupHelper.HasQueryArchiveLayouts();
                    RefreshAvrServiceQueryCashe(queryId, isArchive);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new AvrDbException(String.Format("Error while refreshing query with id '{0}'", queryId), ex);
            }
        }

        #endregion

        #region Avr Service wrappers

        public static CachedQueryResult GetAvrServiceQueryResult(long queryId, bool isArchive, long queryCacheId = -1)
        {
            using (var wrapper = new AvrServiceClientWrapper())
            {
                var receiver = new AvrCacheReceiver(wrapper);
                LayoutBaseValidatorWaiter validatorWaiter = new LayoutSilentValidatorWaiter();
                CachedQueryResult result = receiver.GetCachedQueryTable(queryId, ModelUserContext.CurrentLanguage, isArchive,
                    string.Empty, validatorWaiter, queryCacheId);
                return result;
            }
        
        }

        public static bool DoesCachedQueryExists(long queryId, string lang, bool isArchive)
        {
            using (var wrapper = new AvrServiceClientWrapper())
            {
                var exists = wrapper.DoesCachedQueryExists(queryId, lang, isArchive);
                return exists;
            }
        }

        

        public static void RefreshAvrServiceQueryCashe(long queryId, bool isArchive)
        {
            using (var wrapper = new AvrServiceClientWrapper())
            {
                var receiver = new AvrCacheReceiver(wrapper);
                LayoutBaseValidatorWaiter validatorWaiter = new LayoutSilentValidatorWaiter();
                receiver.GetCachedQueryTable(queryId, ModelUserContext.CurrentLanguage, isArchive, "0=1", validatorWaiter);
            }
        }

        public static void CallAvrServiceToForceLOHMemoryAllocations()
        {
            using (var wrapper = new AvrServiceClientWrapper())
            {
                wrapper.GetCachedQueryTableHeader(-1, ModelUserContext.CurrentLanguage, false);
                wrapper.GetCachedQueryTablePacket(-1, 0, 0);
                wrapper.GetQueryRefreshDateTime(-1, ModelUserContext.CurrentLanguage);
            }
        }

        public static AvrServiceCopyLayoutResult AvrServiceCopyLayout(long layoutId)
        {
            try
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    long copyId = wrapper.CopyLayout(layoutId, ModelUserContext.CurrentLanguage);
                    return new AvrServiceCopyLayoutResult(copyId);
                }
            }
            catch (EndpointNotFoundException)
            {
                return new AvrServiceCopyLayoutResult(MsgNotAccessable);
            }
            catch (CommunicationException ex)
            {
                return new AvrServiceCopyLayoutResult(MsgError + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                return new AvrServiceCopyLayoutResult(MsgError, ex);
            }
        }

        public static AvrServicePivotResult GetAvrServicePivotResult(string sessionId, long layoutId)
        {
            try
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    wrapper.GetServiceVersion();
                    var receiver = new AvrCacheReceiver(wrapper);
                    AvrPivotViewModel model = receiver.GetCachedView(sessionId, layoutId, ModelUserContext.CurrentLanguage);
                    return new AvrServicePivotResult(model);
                }
            }

            catch (EndpointNotFoundException)
            {
                return new AvrServicePivotResult(MsgNotAccessable);
            }
            catch (CommunicationException ex)
            {
                return new AvrServicePivotResult(MsgError + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                return new AvrServicePivotResult(MsgError, ex);
            }
        }

        public static AvrServiceChartResult GetAvrServiceChartResult(ChartTableModel tableModel)
        {
            try
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    wrapper.GetServiceVersion();
                    var receiver = new AvrCacheReceiver(wrapper);
                    ChartExportDTO model = receiver.ExportChartToJpg(tableModel);
                    return new AvrServiceChartResult(model);
                }
            }

            catch (EndpointNotFoundException)
            {
                return new AvrServiceChartResult(MsgNotAccessable);
            }
            catch (CommunicationException ex)
            {
                return new AvrServiceChartResult(MsgError + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                return new AvrServiceChartResult(MsgError, ex);
            }
        }

        public static void AvrServiceClearQueryCache(long queryId)
        {
            try
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    wrapper.InvalidateQueryCacheForLanguage(queryId, ModelUserContext.CurrentLanguage);
                }
            }

            catch (Exception)
            {
            }
        }

        public static void AvrServiceClearViewCache(long layoutId)
        {
            try
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    wrapper.InvalidateViewCache(layoutId);
                }
            }

            catch (Exception)
            {
            }
        }

        #endregion
    }
}