using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.Uni.Outbreak {


    partial class OutBreakDataSet
    {
    }
}

namespace EIDSS.Reports.Document.Uni.Outbreak.OutBreakDataSetTableAdapters
{
        public partial class OutbreakAdapter

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

        public partial class OutbreakNotesAdapter
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