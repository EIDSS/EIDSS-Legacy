using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class ExternalComparativeDataSet {
    }
}


namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.ExternalComparativeDataSetTableAdapters
{

    public partial class spRepHumExternalComparativeTableAdapter 
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