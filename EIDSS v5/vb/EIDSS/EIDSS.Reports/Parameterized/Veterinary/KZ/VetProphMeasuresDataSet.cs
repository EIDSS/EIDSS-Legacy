using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ {


    partial class VetProphMeasuresDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.VetProphMeasuresDataSetTableAdapters
{


    public partial class spRepVetProphilacticMeasuresTableAdapter 
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