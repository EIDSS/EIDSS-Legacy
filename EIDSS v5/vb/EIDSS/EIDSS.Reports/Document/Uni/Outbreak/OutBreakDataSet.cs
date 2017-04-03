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
        public partial class spRepUniOutbreakReportTableAdapter

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

        public partial class spRepUniOutbreakNotesReportTableAdapter
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