using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.ActiveSurveillance
{
    public partial class ActiveSurveillanceDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.ActiveSurveillance.ActiveSurveillanceDataSetTableAdapters
{
    public partial class spRepVetActiveSurveillanceReportTableAdapter
    {
//        private SqlTransaction m_Transaction;
//
//        internal SqlTransaction Transaction
//        {
//            get { return m_Transaction; }
//            set
//            {
//                m_Transaction = value;
//                BaseAdapter.SetTransaction(Adapter, CommandCollection, value);
//            }
//        }

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