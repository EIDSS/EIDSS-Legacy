using System;
using System.Data;

namespace eidss.avr.db.DBService.DataTableCopier
{
    public interface IDataTableCopier : IDisposable
    {
        bool IsOutOfMemory { get; }
        int QueueCount { get; }

        void ForceStart();
        DataTable GetCopy();
        DataTable GetClone();
    }
}