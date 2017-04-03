using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.Lim.Batch {
    
    
    public partial class TestDetailsDataSet {
        partial class spRepLimBatchTestDetailsDataTable
        {
        }
    }
}

namespace EIDSS.Reports.Document.Lim.Batch.TestDetailsDataSetTableAdapters
{
      public partial class spRepLimBatchTestDetailsTableAdapter

      {
          private SqlTransaction m_Transaction;

          internal SqlTransaction Transaction
          {
              get { return m_Transaction; }
              set
              {
                  m_Transaction = value;
                  BaseAdapter.SetTransaction(Adapter, CommandCollection, value);
              }
          }

          internal int CommandTimeout
          {
              get { return CommandCollection.Select(c => c.CommandTimeout).FirstOrDefault(); }
              set
              {
                  foreach (SqlCommand command in CommandCollection)
                  {
                      command.CommandTimeout = value;
                  }
              }
          }
      }
}
