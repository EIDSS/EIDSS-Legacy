using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.Human.EmergencyNotification {
    
    
    public partial class EmergencyNotificationDataSet {
    }
}


namespace EIDSS.Reports.Document.Human.EmergencyNotification.EmergencyNotificationDataSetTableAdapters
{
    public partial class UrgentNotificationAdapter
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