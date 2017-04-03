using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet
{
    public partial class FormN85AnnualSecondDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet.FormN85AnnualSecondDataSetTableAdapters
{
    public partial class spRepHumFormN85AnnualSecondTableAdapter

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