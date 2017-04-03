using System;
using bv.common.db.Core;

namespace EIDSS.Reports.BaseControls.Transaction
{
    public class EidssConnectionTransaction : IDisposable
    {
        public EidssConnectionTransaction()
        {
            ConnectionManager.DefaultInstance.OpenConnection();
        }

        public void Dispose()
        {
            ConnectionManager.DefaultInstance.CloseConnection();
        }
    }
}