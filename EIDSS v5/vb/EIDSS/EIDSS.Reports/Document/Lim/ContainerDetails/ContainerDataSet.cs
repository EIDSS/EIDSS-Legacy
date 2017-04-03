using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.Lim.ContainerDetails {
    
    
    public partial class ContainerDataSet {
    }
}

namespace EIDSS.Reports.Document.Lim.ContainerDetails.ContainerDataSetTableAdapters
{

       public partial class sp_rep_LIM_ContainerLocationTableAdapter

       {
           private SqlTransaction m_Transaction;

           internal SqlTransaction Transaction
           {
               get { return m_Transaction; }
               set
               {
                   m_Transaction = value;
                   sprepGetBaseParametersTableAdapter.SetTransaction(Adapter, CommandCollection, value);
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
