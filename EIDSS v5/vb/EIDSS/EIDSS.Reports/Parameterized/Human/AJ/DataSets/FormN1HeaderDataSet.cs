using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets
{
    
    
    public partial class FormN1HeaderDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.FormN1HeaderDataSetTableAdapters
{


    public partial class spRepHumFormN1HeaderTableAdapter
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