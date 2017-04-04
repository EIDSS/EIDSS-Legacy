using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.TH.DataSets {
    
    
    public partial class NumberOfCasesDeathsMonthTHDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.TH.DataSets.NumberOfCasesDeathsMonthTHDataSetTableAdapters
{


    public partial class NumberOfCasesAdapter
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