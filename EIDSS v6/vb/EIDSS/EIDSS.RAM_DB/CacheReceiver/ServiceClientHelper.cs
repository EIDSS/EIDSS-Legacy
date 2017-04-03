using System;
using System.Data;
using System.ServiceModel;
using System.Web;
using bv.common;
using bv.model.Model.Core;
using eidss.avr.db.Common;
using eidss.model.AVR.Db;
using eidss.model.AVR.ServiceData;
using eidss.model.Avr.View;
using eidss.model.Resources;

namespace eidss.avr.db.CacheReceiver
{
    public static class ServiceClientHelper
    {
        public static CachedQueryResult ExecQuery(long queryId, bool isArchive, long queryCacheId = -1)
        {
            try
            {
                CachedQueryResult result;
                if (queryId > 0)
                {
                    result = GetAvrServiceQueryResult(queryId, isArchive);

                    result.QueryTable.TableName = QueryProcessor.GetQueryName(queryId);
                    QueryProcessor.SetCopyPropertyForColumnsIfNeeded(result.QueryTable);
                    QueryProcessor.TranslateTableFields(result.QueryTable, queryId);
                    QueryProcessor.SetNullForForbiddenTableFields(result.QueryTable, queryId);
                }
                else
                {
                    result = new CachedQueryResult(-1, new DataTable());
                }
                QueryProcessor.RemoveNotExistingColumns(result.QueryTable, queryId);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new AvrDbException(String.Format("Error while executing query with id '{0}'", queryId), ex);
            }
        }

        #region Avr Service wrappers

        public static CachedQueryResult GetAvrServiceQueryResult(long queryId, bool isArchive, long queryCacheId = -1)
        {
            using (var wrapper = new ServiceClientWrapper())
            {
                var receiver = new AvrCacheReceiver(wrapper);
                var result = receiver.GetCachedQueryTable(queryId, ModelUserContext.CurrentLanguage, isArchive, queryCacheId);
                return result;
            }
        }

       

        public static AvrServicePivotResult GetAvrServicePivotResult(string sessionId, long layoutId)
        {
            bool isWeb = HttpContext.Current != null;
            string msgNotAccessable = isWeb ? "msgAvrServiceNotAccessableWeb" : "msgAvrServiceNotAccessable";
            try
            {
                using (var wrapper = new ServiceClientWrapper())
                {
                    wrapper.GetServiceVersion();
                    var receiver = new AvrCacheReceiver(wrapper);
                    AvrPivotViewModel model = receiver.GetCachedView(sessionId, layoutId, ModelUserContext.CurrentLanguage);
                    return new AvrServicePivotResult(model);
                }
            }

            catch (EndpointNotFoundException)
            {
                return new AvrServicePivotResult(EidssMessages.Get(msgNotAccessable));
            }
            catch (CommunicationException ex)
            {
                return new AvrServicePivotResult(EidssMessages.Get(msgNotAccessable) + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                return new AvrServicePivotResult(EidssMessages.Get(msgNotAccessable), ex);
            }
        }

        public static AvrServiceChartResult GetAvrServiceChartResult(ChartTableModel tableModel)
        {
            bool isWeb = HttpContext.Current != null;
            string msgNotAccessable = isWeb ? "msgAvrServiceNotAccessableWeb" : "msgAvrServiceNotAccessable";
            try
            {
                using (var wrapper = new ServiceClientWrapper())
                {
                    wrapper.GetServiceVersion();
                    var receiver = new AvrCacheReceiver(wrapper);
                    ChartExportDTO model = receiver.ExportChartToJpg(tableModel);
                    return new AvrServiceChartResult(model);
                }
            }

            catch (EndpointNotFoundException)
            {
                return new AvrServiceChartResult(EidssMessages.Get(msgNotAccessable));
            }
            catch (CommunicationException ex)
            {
                return new AvrServiceChartResult(EidssMessages.Get(msgNotAccessable) + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                return new AvrServiceChartResult(EidssMessages.Get(msgNotAccessable), ex);
            }
        }

        #endregion
    }
}