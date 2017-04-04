using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class BorderRayonsComparativeAZDataSet {
        partial class ChartBarTableDataTable
        {
        }
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.BorderRayonsComparativeAZDataSetTableAdapters
{


    public partial class BorderRayonsAdapter
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
