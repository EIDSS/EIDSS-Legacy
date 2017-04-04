using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eidss.model.AVR.SourceData;
using eidss.model.Core;

namespace eidss.avr.db.Common
{
    public class AvrColumnRowIntersectionFinder:IDisposable
    {
        private readonly Queue<AvrColumnRowIntersectionPair> m_Queue = new Queue<AvrColumnRowIntersectionPair>();
        private readonly object m_SyncLock = new object();
        private readonly AvrPivotGridData m_DataSource;
        private readonly CancellationTokenSource m_TokenSource = new CancellationTokenSource();
        private readonly Task[] m_Tasks;

        public AvrColumnRowIntersectionFinder(AvrPivotGridData dataSource)
        {
            m_DataSource = dataSource;
           

            m_Tasks = new[]
            {
                Task.Factory.StartNew(()=>FindIntersection(m_TokenSource), m_TokenSource.Token),
                Task.Factory.StartNew(()=>FindIntersection(m_TokenSource), m_TokenSource.Token),
                Task.Factory.StartNew(()=>FindIntersection(m_TokenSource), m_TokenSource.Token),
                Task.Factory.StartNew(()=>FindIntersection(m_TokenSource), m_TokenSource.Token)
            };
        }

        public void Enqueue(AvrColumnRowIntersectionPair intersectionPair)
        {
            QueueHelper.ThreadSafeEnqueue(m_Queue, intersectionPair, m_SyncLock, m_TokenSource);
        }

        public void WaitAll()
        {
            QueueHelper.ThreadSafeEnqueue(m_Queue, AvrColumnRowIntersectionPair.NullObject, m_SyncLock,m_TokenSource);
            Task.WaitAll(m_Tasks, m_TokenSource.Token);
        }

        public void KillAll()
        {
            lock (m_SyncLock)
            {
                m_Queue.Clear();
            }
            WaitAll();
        }

        private void FindIntersection(CancellationTokenSource tokenSource)
        {
            while (true)
            {
                AvrColumnRowIntersectionPair intersectionPair = QueueHelper.ThreadSafeDequeue(m_Queue, m_SyncLock, tokenSource);
                if (AvrColumnRowIntersectionPair.NullObject == intersectionPair)
                {
                    QueueHelper.ThreadSafeEnqueue(m_Queue, AvrColumnRowIntersectionPair.NullObject, m_SyncLock, tokenSource);
                    return;
                }

                int[] rowValuesIndexes = intersectionPair.RowValues.RowIndexesList.ToArray();
                foreach (AvrFieldValueCollectionWithRowsWrapper colValues in intersectionPair.ColValues)
                {
                    bool foundEqualRows = AreColumnAndRowAreaHasEqualRows(rowValuesIndexes, colValues.RowIndexesList);
                    if (!foundEqualRows)
                    {
                        AvrDataRow row = m_DataSource.NewRow();
                        FillRowFromExistingValues(intersectionPair.RowValues, row);
                        FillRowFromExistingValues(colValues, row);

                        m_DataSource.ThreadSafeAddRow(row);
                    }
                }
            }
        }

        private static bool AreColumnAndRowAreaHasEqualRows(int[] rowValuesList, IList<int> colValuesList)
        {
            bool foundEqualRows = false;
            int rowValuesCount = rowValuesList.Length;
            int colValuesCount = colValuesList.Count;
            if (colValuesCount > 0 && rowValuesCount > 0)
            {
                int colMaxVal = colValuesList[colValuesCount - 1];
                int rowMaxVal = rowValuesList[rowValuesCount - 1];
                if (rowValuesList[0] <= colMaxVal && colValuesList[0] <= rowMaxVal)
                {
                    int colIndex = 0;
                    int oldColIndex = 0;

                    int rowIndex = 0;
                    int oldRowIndex = 0;
                    int colStep = Math.Max(colValuesCount >> 1, 1);
                    int rowStep = Math.Max(rowValuesCount >> 1, 1);

                    while (colIndex < colValuesCount && rowIndex < rowValuesCount)
                    {
                        int rowVal = rowValuesList[rowIndex];
                        int colVal = colValuesList[colIndex];
                        if (rowVal > colMaxVal || colVal > rowMaxVal)
                        {
                            break;
                        }

                        if (rowVal < colVal)
                        {
                            if (rowStep == 1)
                            {
                                rowIndex++;
                            }
                            else
                            {
                                if (oldColIndex != colIndex)
                                {
                                    rowStep = Math.Max((rowValuesCount - rowIndex) >> 1, 1);
                                    oldColIndex = colIndex;
                                }

                                while (rowVal < colVal && rowIndex < rowValuesCount - 1)
                                {
                                    rowIndex += rowStep;
                                    if (rowIndex >= rowValuesCount)
                                    {
                                        rowIndex = rowValuesCount - 1;
                                    }
                                    rowVal = rowValuesList[rowIndex];
                                }
                                rowIndex = rowIndex - rowStep + 1;
                                rowStep = Math.Max(rowStep >> 1, 1);
                            }
                        }
                        else if (rowVal > colVal)
                        {
                            if (colStep == 1)
                            {
                                colIndex++;
                            }
                            else
                            {
                                if (oldRowIndex != rowIndex)
                                {
                                    colStep = Math.Max((colValuesCount - colIndex) >> 1, 1);
                                    oldRowIndex = rowIndex;
                                }
                                while (rowVal > colVal && colIndex < colValuesCount - 1)
                                {
                                    colIndex += colStep;
                                    if (colIndex >= colValuesCount)
                                    {
                                        colIndex = colValuesCount - 1;
                                    }
                                    colVal = colValuesList[colIndex];
                                }
                                colIndex = colIndex - colStep + 1;
                                colStep = Math.Max(colStep >> 1, 1);
                            }
                        }
                        else
                        {
                            foundEqualRows = true;
                            break;
                        }
                    }
                }
            }
            return foundEqualRows;
        }

        private static void FillRowFromExistingValues(AvrFieldValueCollectionWithRowsWrapper colection, AvrDataRow row)
        {
            foreach (AvrFieldValuePair pair in colection.Collection)
            {
                var value = pair.Value ?? DBNull.Value;
                row.SetValue(pair.Field.Ordinal, value);
            }
        }

        public void Dispose()
        {
            KillAll();
            m_TokenSource.Dispose();
        }
    }
}