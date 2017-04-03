using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.BaseControls.BaseDataSetTableAdapters
{
    partial class sprepGetBaseParametersTableAdapter
    {
        private SqlTransaction m_Transaction;

        internal SqlTransaction Transaction
        {
            get { return m_Transaction; }
            set
            {
                m_Transaction = value;
                SetTransaction(Adapter, CommandCollection, value);
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
        internal static void SetTransaction(SqlDataAdapter adapter, SqlCommand[] commandCollection, SqlTransaction transaction)
        {
            if ((adapter.InsertCommand != null))
            {
                adapter.InsertCommand.Transaction = transaction;
            }
            if ((adapter.DeleteCommand != null))
            {
                adapter.DeleteCommand.Transaction = transaction;
            }
            if ((adapter.UpdateCommand != null))
            {
                adapter.UpdateCommand.Transaction = transaction;
            }
            for (int i = 0; (i < commandCollection.Length); i = (i + 1))
            {
                if ((commandCollection[i] != null))
                {
                    ((commandCollection[i])).Transaction = transaction;
                }
            }
        }
    }
}
namespace EIDSS.Reports.BaseControls {
    
    
    public partial class BaseDataSet {
        partial class sprepGetBaseParametersDataTable
        {
        }
    }
}
