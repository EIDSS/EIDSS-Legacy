using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class AdditionalAFPIndicatorsDataSet {
    }
}


namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.AdditionalAFPIndicatorsDataSetTableAdapters
{


    public partial class spRepHumAdditionalAFPIndicatorsTableAdapter 
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