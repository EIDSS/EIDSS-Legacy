using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class InfectiousDiseaseMonthHeaderV6DataSet {
    }


}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousDiseaseMonthHeaderV6DataSetTableAdapters
{


    public partial class MonthlyHeaderV6Adapter
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
