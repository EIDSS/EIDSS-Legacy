using System;
using System.Data;
using bv.common;
using bv.common.Core;

namespace eidss.avr.db.DBService.DataTableCopier
{
    public class DataTableCopierSingleThread : IDataTableCopier
    {
        private DataTable m_SourceTable;
        private bool m_Disposed;

        internal DataTableCopierSingleThread(DataTable sourceTable)
        {
            Utils.CheckNotNull(sourceTable, "sourceTable");
            m_SourceTable = sourceTable;
        }

        public void Dispose()
        {
            try
            {
                m_SourceTable = null;
                m_Disposed = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        public bool IsOutOfMemory
        {
            get { return false; }
        }

        public int QueueCount
        {
            get { return 0; }
        }

        public void ForceStart()
        {
            if (m_Disposed)
            {
                throw new ObjectDisposedException("DataTableCopier");
            }
        }

        public DataTable GetCopy()
        {
            return m_SourceTable.Copy();
        }

        public DataTable GetClone()
        {
            return m_SourceTable.Clone();
        }
    }
}