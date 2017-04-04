using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class InfectiousDiseaseMonthV6DataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousDiseaseMonthV6DataSetTableAdapters
{

    public partial class MonthlyV6Adapter 
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