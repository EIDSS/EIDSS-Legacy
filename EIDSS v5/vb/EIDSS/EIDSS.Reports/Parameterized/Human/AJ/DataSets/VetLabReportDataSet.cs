using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class VetLabReportDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetLabReportDataSetTableAdapters
{

    public partial class VetLabAdapter 
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