using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using bv.common.Core;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Core;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.CacheReceiver
{
    public class AvrCacheConverter
    {
        private const int BufferQueueSize = 4;
        private long m_InputBufferSize;
        private long m_OutputBufferSize;

        private int m_CallCounter;
        private int m_DeserializeTableCounter;
        private int m_UnzipTableCounter;
        private bool m_ValidationFailed;

        private readonly object m_InitBufferSyncLock = new object();
        private readonly object m_ValidtorSyncLock = new object();

        protected readonly object m_ReceiveSyncLock = new object();
        protected readonly Queue<QueryTablePacketDTO> m_ReceivedQueue = new Queue<QueryTablePacketDTO>();

        private readonly object m_UnzipBufferSyncLock = new object();
        private readonly Queue<KeyValuePair<byte[], byte[]>> m_UnzipBufferQueue = new Queue<KeyValuePair<byte[], byte[]>>();

        private readonly object m_UnzipSyncLock = new object();
        private readonly Queue<StreamTablePacketDTO> m_UnzipedQueue = new Queue<StreamTablePacketDTO>();

        public CachedQueryResult GetCachedQueryTable
            (long queryId, QueryTableHeaderDTO headerDTO, QueryTablePacketDTO[] queryPackets, string filter)
        {
            return GetCachedQueryTable(queryId, headerDTO, filter, tokenSource => ReceiveTableBodyPackets(queryPackets, tokenSource));
        }

        protected CachedQueryResult GetCachedQueryTable
            (long queryId,
                QueryTableHeaderDTO headerDTO,
                string filter,
                Func<CancellationTokenSource, QueryTablePacketDTO[]> receivePacketFunc,
                LayoutBaseValidatorWaiter validatorWaiter = null)
        {
            CheckCallCount();
            m_UnzipTableCounter = 0;
            m_DeserializeTableCounter = 0;

            var header = new QueryTableHeaderModel(headerDTO);
            const int missingRowsCapacity = 10240;
            var avrTable = new AvrDataTable(header, BinarySerializer.MaxPacketRows * header.PacketCount + missingRowsCapacity)
            {
                RowFilterExpression = filter
            };

            CancellationTokenSource ts = new CancellationTokenSource();
            ts.Token.Register(PulseAllTasks);

            Task<QueryTablePacketDTO[]> receivePackets = Task.Factory.StartNew(() => receivePacketFunc(ts), ts.Token);
            var runningTasks = new[]
            {
                receivePackets,
                Task.Factory.StartNew(() => UnzipTableBodyPackets(header, ts), ts.Token),
                Task.Factory.StartNew(() => UnzipTableBodyPackets(header, ts), ts.Token),
                Task.Factory.StartNew(() => UnzipTableBodyPackets(header, ts), ts.Token),
                Task.Factory.StartNew(() => DeserializeTableBodyPackets(header, avrTable, validatorWaiter, ts), ts.Token),
                Task.Factory.StartNew(() => DeserializeTableBodyPackets(header, avrTable, validatorWaiter, ts), ts.Token)
            };

            try
            {
                if (validatorWaiter != null && validatorWaiter.NeedWait)
                {
                    while (runningTasks.Any(t => !t.IsCompleted))
                    {
                        validatorWaiter.Wait();
                    }
                }
                Task.WaitAll(runningTasks);
            }
            catch (AggregateException ex)
            {
                var cancelException = (AvrCacheCancelException) ex.InnerExceptions.FirstOrDefault(e => e is AvrCacheCancelException);
                if (cancelException != null)
                {
                    //cleanup before exit
                    avrTable.ThreadSafeClear();
                    GC.Collect();
                    var emptyTable = new AvrDataTable(header, 1);
                    QueryTableHeaderDTO emptyHeaderDTO = new QueryTableHeaderDTO(headerDTO.BinaryHeader, headerDTO.QueryCacheId, 0);
                    return new CachedQueryResult(queryId, emptyTable, emptyHeaderDTO, cancelException.ValidatorResult.ErrorMessage);
                }
                throw;
            }

            avrTable.AcceptChanges();
            return new CachedQueryResult(queryId, avrTable, headerDTO, receivePackets.Result);
        }

        private void PulseAllTasks()
        {
            lock (m_ReceiveSyncLock)
            {
                Monitor.PulseAll(m_ReceiveSyncLock);
            }
            lock (m_UnzipSyncLock)
            {
                Monitor.PulseAll(m_UnzipSyncLock);
            }
            lock (m_UnzipBufferSyncLock)
            {
                Monitor.PulseAll(m_UnzipBufferSyncLock);
            }
        }

        private QueryTablePacketDTO[] ReceiveTableBodyPackets(QueryTablePacketDTO[] queryPackets, CancellationTokenSource tokenSource)
        {
            foreach (var packet in queryPackets)
            {
                QueueHelper.ThreadSafeEnqueue(m_ReceivedQueue, packet, m_ReceiveSyncLock, tokenSource);
            }
            return queryPackets;
        }

        protected void UnzipTableBodyPackets(QueryTableHeaderModel header, CancellationTokenSource tokenSource)
        {
            while (!tokenSource.IsCancellationRequested)
            {
                try
                {
                    if (Interlocked.Increment(ref m_UnzipTableCounter) > header.PacketCount)
                    {
                        return;
                    }
                    QueryTablePacketDTO packetDTO = QueueHelper.ThreadSafeDequeue(m_ReceivedQueue, m_ReceiveSyncLock, tokenSource);
                    if (tokenSource.IsCancellationRequested)
                    {
                        return;
                    }

                    InitUnzipBuffers(packetDTO);
                    var buffer = QueueHelper.ThreadSafeDequeue(m_UnzipBufferQueue, m_UnzipBufferSyncLock, tokenSource);
                    if (tokenSource.IsCancellationRequested)
                    {
                        return;
                    }

                    StreamTablePacketDTO unzipped = BinaryCompressor.UnzipStream(packetDTO, buffer.Key, buffer.Value);
                    QueueHelper.ThreadSafeEnqueue(m_UnzipedQueue, unzipped, m_UnzipSyncLock, tokenSource);
                }
                catch (Exception)
                {
                    tokenSource.Cancel();

                    throw;
                }
            }
        }

        private void InitUnzipBuffers(QueryTablePacketDTO packetDTO)
        {
            lock (m_InitBufferSyncLock)
            {
                if (m_OutputBufferSize == 0 || m_InputBufferSize == 0)
                {
                    m_InputBufferSize = 1024 * 1024 * (1 + (packetDTO.BinaryBody.Length >> 20));
                    var outputSize = BinaryCompressor.GetUncompressedSize(packetDTO.BinaryBody);
                    m_OutputBufferSize = 4 * 1024 * 1024 * (1 + (outputSize >> 22));
                    for (int i = 0; i < BufferQueueSize; i++)
                    {
                        var buff = new KeyValuePair<byte[], byte[]>(new byte[m_InputBufferSize], new byte[m_OutputBufferSize]);
                        m_UnzipBufferQueue.Enqueue(buff);
                    }
                }
            }
        }

        protected void DeserializeTableBodyPackets
            (QueryTableHeaderModel header, AvrDataTable table, LayoutBaseValidatorWaiter validatorWaiter,
                CancellationTokenSource tokenSource)
        {
            while (!tokenSource.IsCancellationRequested)
            {
                try
                {
                    if (Interlocked.Increment(ref m_DeserializeTableCounter) > header.PacketCount)
                    {
                        return;
                    }

                    StreamTablePacketDTO packetDTO = QueueHelper.ThreadSafeDequeue(m_UnzipedQueue, m_UnzipSyncLock, tokenSource);
                    if (tokenSource.IsCancellationRequested)
                    {
                        return;
                    }

                    ValidateMemory(validatorWaiter, tokenSource);

                    BinarySerializer.DeserializeBodyPacket(packetDTO, header.ColumnTypes, table);
                    var buffer = new KeyValuePair<byte[], byte[]>(packetDTO.InputBuffer, packetDTO.OutputBuffer);
                    QueueHelper.ThreadSafeEnqueue(m_UnzipBufferQueue, buffer, m_UnzipBufferSyncLock, tokenSource);
                }
                catch (Exception)
                {
                    tokenSource.Cancel();
                    throw;
                }
            }
        }

        private void ValidateMemory(LayoutBaseValidatorWaiter validatorWaiter, CancellationTokenSource tokenSource)
        {
            lock (m_ValidtorSyncLock)
            {
                if (validatorWaiter != null && validatorWaiter.Validator != null &&
                    !tokenSource.IsCancellationRequested &&
                    !m_ValidationFailed)
                {
                    var validatorResult = validatorWaiter.Validator.Validate(new LayoutBaseComplexity());
                    if (!validatorResult.IsOk())
                    {
                        validatorWaiter.Validator.IgnoreValidationWarnings = true;
                        if (!validatorResult.IsUserDialogOk())
                        {
                            m_ValidationFailed = true;
                            throw new AvrCacheCancelException(validatorResult);
                        }
                    }
                }
            }
        }

        protected void CheckCallCount()
        {
            if (Interlocked.Increment(ref m_CallCounter) > 1)
            {
                throw new AvrException(
                    "Cannot call AVR cache converter or AVR cache receiver more then one time. Please create another object.");
            }
        }
    }
}