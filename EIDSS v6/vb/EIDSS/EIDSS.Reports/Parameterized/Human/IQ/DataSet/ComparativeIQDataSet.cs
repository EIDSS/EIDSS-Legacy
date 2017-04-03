using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.IQ.DataSet {
    
    
    public partial class ComparativeIQDataSet {
    }
}


namespace EIDSS.Reports.Parameterized.Human.IQ.DataSet.ComparativeIQDataSetTableAdapters
{


    public partial class spRepHumIQComparativeTableAdapter 
    {
     

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