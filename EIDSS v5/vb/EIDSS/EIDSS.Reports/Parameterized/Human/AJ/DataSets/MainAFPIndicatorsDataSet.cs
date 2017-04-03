using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class MainAFPIndicatorsDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.MainAFPIndicatorsDataSetTableAdapters
{


    
    public partial class spRepHumMainAFPIndicatorsTableAdapter 
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