using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class InfectiousDiseaseMonthV61DataSet {
    }
}
namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousDiseaseMonthV61DataSetTableAdapters
{

    public partial class MonthlyV61Adapter
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