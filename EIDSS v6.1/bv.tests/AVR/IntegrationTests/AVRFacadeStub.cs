using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using bv.common.Configuration;
using BLToolkit.Data;
using bv.model.BLToolkit;
using eidss.avr.db.CacheReceiver;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.Avr.View;
using eidss.model.WindowsService;
using eidss.model.WindowsService.Serialization;

namespace bv.tests.AVR.IntegrationTests
{
    public class AVRFacadeStub : IAVRFacade
    {
        private readonly QueryTableHeaderDTO m_ZippedHeader;
        private readonly List<QueryTablePacketDTO> m_ZippedBody;

        private static readonly SemaphoreSlim m_ViewSemaphore;
        private static readonly long m_Ticks = DateTime.Now.Ticks;

        static AVRFacadeStub()
        {
            var max = Config.GetIntSetting("MaxViewSimultaneouslyRequests", 1);
            m_ViewSemaphore = new SemaphoreSlim(max, max);
            
        }
        public AVRFacadeStub(long queryCacheId, int multiplier = 1)
        {
            QueryTableModel tableModel;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                using (DbManager command = manager.SetCommand(@"select  * from dbo.AVR_HumanCaseReport"))
                {
                    tableModel = BinarySerializer.SerializeFromCommand(command, 123, "en", false, 10);
                }
            }

            m_ZippedBody = tableModel.BodyPackets.Select(BinaryCompressor.Zip).ToList();

            m_ZippedHeader = new QueryTableHeaderDTO(BinaryCompressor.Zip(tableModel.Header), queryCacheId, m_ZippedBody.Count * multiplier);
        }


        public ChartExportDTO ExportChartToJpg(ChartTableDTO zippedData)
        {
            using (var bitmap = new Bitmap(zippedData.Width, zippedData.Height))
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    stream.Flush();
                    stream.Seek(0, SeekOrigin.Begin);

                    var buffer = new byte[stream.Length];
                    int readed = stream.Read(buffer, 0, (int)stream.Length);
                    Debug.Assert(stream.Length == readed, "not all bytes readed");

                    return new ChartExportDTO(buffer, new byte[0]);
                }
            }
        }

        public ViewDTO GetCachedView(string sessionId, long layoutId, string lang)
        {
            try
            {
                m_ViewSemaphore.Wait();

                Console.WriteLine(" Waited {0} tics for the semaphore", (DateTime.Now.Ticks - m_Ticks) / 100000 * 100000);

                Thread.Sleep(100);
                byte[] viewBytes = BinarySerializer.SerializeFromString(SerializedViewStub.ViewXml);
                byte[] viewZippedBytes = BinaryCompressor.Zip(viewBytes);

                DataTable sourceData = DataTableSerializer.Deserialize(SerializedViewStub.DataXml);

                BaseTableDTO serializedDTO = BinarySerializer.SerializeFromTable(sourceData);
                BaseTableDTO zippedDTO = BinaryCompressor.Zip(serializedDTO);

                var result = new ViewDTO(zippedDTO, viewZippedBytes);

                return result;
            }
            finally
            {
                m_ViewSemaphore.Release();
            }
            
        }

        public void InvalidateViewCache(long layoutId)
        {
            
        }

        public QueryTableHeaderDTO GetCachedQueryTableHeader(long queryId, string lang, bool isArchive)
        {
            return m_ZippedHeader;
        }


        public bool DoesCachedQueryExists(long queryId, string lang, bool isArchive)
        {
            return true;
        }

        public void RefreshCachedQueryTableByScheduler(long queryId, string lang, bool isArchive)
        {
            
        }

        public QueryTableHeaderDTO GetConcreteCachedQueryTableHeader(long queryCacheId, long queryId, string lang, bool isArchive)
        {
            return m_ZippedHeader;
        }

        public QueryTablePacketDTO GetCachedQueryTablePacket(long queryCacheId, int packetNumber, int  totalPacketCount)
        {
            //Thread.Sleep(1);
            return m_ZippedBody[packetNumber % m_ZippedBody.Count];
        }

        public void InvalidateQueryCacheForLanguage(long queryId, string lang)
        {
        }

        public void InvalidateQueryCache(long queryId)
        {
        }

        public void DeleteQueryCacheForLanguage(long queryId, string lang, bool leaveLastRecord)
        {
            
        }

        public DateTime? GetsQueryCacheUserRequestDate(long queryId)
        {
            return DateTime.Now;
        }

        public Version GetServiceVersion()
        {
            throw new NotImplementedException();
        }

        public DatabaseNames GetDatabaseName()
        {
            throw new NotImplementedException();
        }

        public DateTime GetQueryRefreshDateTime(long queryId, string lang)
        {
            return DateTime.Now;
        }

        public List<long> GetQueryIdList()
        {
            return new List<long> {1};
        }

        public List<long> GetLayoutIdList()
        {
            return new List<long> {1};
        }

        public long CopyLayout(long layoutId, string lang)
        {
            return 1;
        }
    }
}