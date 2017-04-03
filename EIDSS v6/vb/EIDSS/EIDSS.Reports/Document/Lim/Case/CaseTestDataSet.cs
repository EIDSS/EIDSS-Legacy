using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.Lim.Case {


    partial class CaseTestDataSet
    {
        partial class spRepLimCaseTestsDataTable
        {
        }
    }
}

namespace EIDSS.Reports.Document.Lim.Case.CaseTestDataSetTableAdapters
{
     public partial class spRepLimCaseTestsTableAdapter

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
