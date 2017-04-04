using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class InfectiousDiseaseMonthHeaderV61DataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousDiseaseMonthHeaderV61DataSetTableAdapters
{


    public partial class MonthlyHeaderV61Adapter
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
