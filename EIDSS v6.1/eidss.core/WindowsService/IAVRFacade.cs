using System;
using System.Collections.Generic;
using System.ServiceModel;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;

namespace eidss.model.WindowsService
{
    [ServiceContract]
    public interface IAVRFacade
    {
        /// <summary>
        ///     Perform Export chart
        /// </summary>
        /// <param name="zippedData">Container with chart parameters</param>
        /// <returns>binary representetion of the result image and chart settings</returns>
        [OperationContract]
        ChartExportDTO ExportChartToJpg(ChartTableDTO zippedData);

        /// <summary>
        ///     Load Layout with Data and construct corresponding View
        /// </summary>
        /// <param name="sessionId">ID of current web session</param>
        /// <param name="layoutId">ID of AVR layout</param>
        /// <param name="lang">Language</param>
        /// <returns>default zipped Avr View structure and data for given layout and language</returns>
        [OperationContract]
        ViewDTO GetCachedView(string sessionId, long layoutId, string lang);



        /// <summary>
        ///     Make current Cache of given view invalid for all supported languages.
        ///     So next time method <see cref="GetCachedView" />   will recalculate  View Cache.
        /// </summary>
        /// <param name="layoutId">ID of the AVR layout</param>
        [OperationContract]
        void InvalidateViewCache(long layoutId);

        /// <summary>
        ///     If Cache for given query id and language exists  returns Header with zipped table structure which store Cache
        ///     If Cache doesn't exist - execute query on the EIDSS DB and store execution result in new table of AVR DB.
        ///     Then return table structure
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// <param name="lang">Language</param>
        /// <param name="isArchive">if true - get combined cache of actual and archive data. if false - only actual data</param>
        /// <returns>Zipped table structure of the table with query result Cache</returns>
        [OperationContract]
        QueryTableHeaderDTO GetCachedQueryTableHeader(long queryId, string lang, bool isArchive);

        /// <summary>
        ///     If Cache for given query id and language exists  returns true
        ///     If Cache doesn't exist - returns false.
        ///     Then return table structure
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// <param name="lang">Language</param>
        /// <param name="isArchive">if true - get existance cache of actual and archive data. if false - only existance of actual data</param>
        /// <returns></returns>
        [OperationContract]
        bool  DoesCachedQueryExists(long queryId, string lang, bool isArchive);

        /// <summary>
        ///     Make current Cache of given query and language invalid and recalculate Cache
        ///     Should be called from Scheduler only
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// <param name="lang">Language</param>
        /// <param name="isArchive">if true - refresh cache of actual and archive data. if false - only actual data</param>
        void RefreshCachedQueryTableByScheduler(long queryId, string lang, bool isArchive);

        /// <summary>
        ///     If Cache for given query cache id exists - returns Header with zipped table structure which store Cache
        ///     If Cache doesn't exist - call <see cref="GetCachedQueryTableHeader" />
        /// </summary>
        /// <param name="queryCacheId">ID of the AVR query cache record</param>
        /// <param name="queryId">ID of the AVR query</param>
        /// <param name="lang">Language</param>
        /// <param name="isArchive">if true - get combined cache of actual and archive data. if false - only actual data</param>
        /// <returns>Zipped table structure of the table with query result Cache</returns>
        [OperationContract]
        QueryTableHeaderDTO GetConcreteCachedQueryTableHeader(long queryCacheId, long queryId, string lang, bool isArchive);

        /// <summary>
        ///     Returns one of packet of zipped table with query cache
        /// </summary>
        /// <param name="queryCacheId">ID of the AVR query cache record</param>
        /// <param name="packetNumber">Number of the packet of zipped table body</param>
        /// ///
        /// <param name="totalPacketCount">Total packet count of zipped table body</param>
        /// <returns>Zipped packet of the table with query result Cache</returns>
        [OperationContract]
        QueryTablePacketDTO GetCachedQueryTablePacket(long queryCacheId, int packetNumber, int totalPacketCount);

        /// <summary>
        ///     Make current Cache of given query and language invalid.
        ///     So next time method <see cref="GetCachedQueryTableHeader" />   will recalculate Cache.
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// <param name="lang">Language</param>
        [OperationContract]
        void InvalidateQueryCacheForLanguage(long queryId, string lang);

        /// <summary>
        ///     Make current Cache of given query invalid for all supported languages.
        ///     So next time method <see cref="GetCachedQueryTableHeader" />   will recalculate Cache.
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        [OperationContract]
        void InvalidateQueryCache(long queryId);

        /// <summary>
        ///     Delete old Cache of given query and language.
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// <param name="lang">Language</param>
        /// <param name="leaveLastRecord">Defines is last record of cache should be leaved</param>
        void DeleteQueryCacheForLanguage(long queryId, string lang, bool leaveLastRecord);

        /// <summary>
        ///     Returns Date and Time when query cache was refreshed
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// ///
        /// <param name="lang">Language</param>
        /// <returns></returns>
        [OperationContract]
        DateTime GetQueryRefreshDateTime(long queryId, string lang);

        /// <summary>
        ///     Returns Date  of latest user request of query cache
        /// </summary>
        /// <param name="queryId">ID of the AVR query</param>
        /// <returns></returns>
        DateTime? GetsQueryCacheUserRequestDate(long queryId);

        /// <summary>
        ///     Returns version of the service
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Version GetServiceVersion();

        /// <summary>
        ///     Returns actual EIDSS database name from connection string
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DatabaseNames GetDatabaseName();

        /// <summary>
        ///     Retrieves list of existing queries
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<long> GetQueryIdList();

        /// <summary>
        ///     Retrieves list of existing Layouts and its versions
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<long> GetLayoutIdList();

        /// <summary>
        /// Create layout copy on given language (include pivot, view, chart and map copy)
        /// </summary>
        /// <param name="layoutId">ID of the AVR Layout to copy</param>
        /// <param name="lang">Language</param>
        /// <returns>ID of created Layout Copy</returns>
        [OperationContract]
        long CopyLayout(long layoutId, string lang);
    }
}