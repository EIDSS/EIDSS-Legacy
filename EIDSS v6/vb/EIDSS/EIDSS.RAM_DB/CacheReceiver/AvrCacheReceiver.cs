using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using eidss.model.AVR.Db;
using eidss.model.AVR.ServiceData;
using eidss.model.Avr.View;
using eidss.model.WindowsService;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.CacheReceiver
{
    public class AvrCacheReceiver
    {
        private readonly object m_ReceiveSyncLock = new object();
        private readonly object m_UnzipSyncLock = new object();
        private readonly object m_DeserializeSyncLock = new object();
        private readonly Queue<QueryTablePacketDTO> m_ReceivedQueue = new Queue<QueryTablePacketDTO>();
        private readonly Queue<QueryTablePacketDTO> m_UnzipedQueue = new Queue<QueryTablePacketDTO>();
        private readonly Queue<object[,]> m_DeserializedQueue = new Queue<object[,]>();

        private readonly IAVRFacade m_Facade;

        public AvrCacheReceiver(IAVRFacade facade)
        {
            m_Facade = facade;
        }

        public ChartExportDTO ExportChartToJpg(ChartTableModel tableModel)
        {
            BaseTableDTO serializedDTO = BinarySerializer.SerializeFromTable(tableModel.Table);
            BaseTableDTO zippedDTO = BinaryCompressor.Zip(serializedDTO);

            var zippedData = new ChartTableDTO(tableModel.ViewId, tableModel.Lang, zippedDTO, tableModel.ChartSettings, tableModel.ChartType, tableModel.Width, tableModel.Height);
            ChartExportDTO result = m_Facade.ExportChartToJpg(zippedData);
            return result;
        }

        public AvrPivotViewModel GetCachedView(string sessionId, long layoutId, string lang)
        {
            ViewDTO viewDTO = m_Facade.GetCachedView(sessionId, layoutId, lang);

            string xmlViewStructure = BinaryCompressor.UnzipString(viewDTO.BinaryViewStructure);
            AvrView view = AvrViewSerializer.Deserialize(xmlViewStructure);

            BaseTableDTO unzippedDTO = BinaryCompressor.Unzip(viewDTO);
            DataTable viewData = BinarySerializer.DeserializeToTable(unzippedDTO);

            var model = new AvrPivotViewModel(view, viewData);

            return model;
        }

        public CachedQueryResult GetCachedQueryTable(long queryId, string lang, bool isArchive, long queryCacheId = -1)
        {
            QueryTableHeaderDTO headerDTO = (queryCacheId > 0)
                ? m_Facade.GetConcreteCachedQueryTableHeader(queryCacheId, queryId, lang, isArchive)
                : m_Facade.GetCachedQueryTableHeader(queryId, lang, isArchive);

            var headerModel = new QueryTableHeaderModel(headerDTO);

            Task<DataTable> createDataTable = Task<DataTable>.Factory.StartNew(() => CreateDataTableFromPackets(headerModel));
            var runningTasks = new[]
            {
                Task.Factory.StartNew(() => ReceiveTableBodyPackets(headerModel)),
                Task.Factory.StartNew(() => UnzipTableBodyPackets(headerModel)),
                Task.Factory.StartNew(() => DeserializeTableBodyPackets(headerModel)),
                createDataTable
            };

            Task.WaitAll(runningTasks);

            return new CachedQueryResult(headerDTO.QueryCacheId, createDataTable.Result);
        }

        private void ReceiveTableBodyPackets(QueryTableHeaderModel header)
        {
            for (int counter = 0; counter < header.PacketCount; counter++)
            {
                QueryTablePacketDTO packet;
                // using (new StopwathTransaction(string.Format("Receive Packet #{0}", counter)))
                {
                    packet = m_Facade.GetCachedQueryTablePacket(header.QueryCacheId, counter);
                }
                ThreadSafeEnqueue(m_ReceivedQueue, packet, m_ReceiveSyncLock);
            }
        }

        private void UnzipTableBodyPackets(QueryTableHeaderModel header)
        {
            int counter = 0;
            while (counter < header.PacketCount)
            {
                QueryTablePacketDTO packetDTO = ThreadSafeDequeue(m_ReceivedQueue, m_ReceiveSyncLock);

                QueryTablePacketDTO unzipped;
                // using (new StopwathTransaction(string.Format("-Unzip Packet #{0}", counter)))
                {
                    unzipped = BinaryCompressor.Unzip(packetDTO);
                }
                ThreadSafeEnqueue(m_UnzipedQueue, unzipped, m_UnzipSyncLock);
                counter++;
            }
        }

        private void DeserializeTableBodyPackets(QueryTableHeaderModel header)
        {
            int counter = 0;
            while (counter < header.PacketCount)
            {
                QueryTablePacketDTO packetDTO = ThreadSafeDequeue(m_UnzipedQueue, m_UnzipSyncLock);

                object[,] deserialized;
                //  using (new StopwathTransaction(string.Format("--Deserialize Packet #{0}", counter)))
                {
                    deserialized = BinarySerializer.DeserializeBodyPacket(packetDTO, header.ColumnTypes);
                }
                ThreadSafeEnqueue(m_DeserializedQueue, deserialized, m_DeserializeSyncLock);

                counter++;
            }
        }

        private DataTable CreateDataTableFromPackets(QueryTableHeaderModel header)
        {
            DataTable table = CreateEmptyDataTable(header);
            table.BeginLoadData();

            int counter = 0;
            while (counter < header.PacketCount)
            {
                object[,] deserialized = ThreadSafeDequeue(m_DeserializedQueue, m_DeserializeSyncLock);

                // using (new StopwathTransaction(string.Format("---Insert Packet #{0} into DataTable", counter)))
                {
                    int rowCount = deserialized.GetLength(0);
                    int columnCount = deserialized.GetLength(1);

                    for (int i = 0; i < rowCount; i++)
                    {
                        var rowData = new object[2 * columnCount];
                        for (int j = 0; j < columnCount; j++)
                        {
                            rowData[2 * j] = deserialized[i, j];
                            rowData[2 * j + 1] = deserialized[i, j];
                        }
                        table.Rows.Add(rowData);
                    }
                }
                counter++;
            }

            table.EndLoadData();
            return table;
        }

        private static DataTable CreateEmptyDataTable(QueryTableHeaderModel header)
        {
            var table = new DataTable();
            foreach (BaseColumnModel columnModel in header.ColumnTypeByName)
            {
                var originalColumn = new DataColumn(columnModel.Name, columnModel.Type) {Caption = columnModel.Caption};
                table.Columns.Add(originalColumn);
                var copyColumn = new DataColumn(columnModel.Name + QueryHelper.CopySuffix, columnModel.Type) {Caption = columnModel.Caption};
                table.Columns.Add(copyColumn);
            }
            return table;
        }

        private void ThreadSafeEnqueue<T>(Queue<T> queue, T item, object locker)
        {
            lock (locker)
            {
                queue.Enqueue(item);
                Monitor.PulseAll(locker);
            }
        }

        private T ThreadSafeDequeue<T>(Queue<T> queue, object locker)
        {
            lock (locker)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(locker);
                }
                T item = queue.Dequeue();
                return item;
            }
        }
    }
}