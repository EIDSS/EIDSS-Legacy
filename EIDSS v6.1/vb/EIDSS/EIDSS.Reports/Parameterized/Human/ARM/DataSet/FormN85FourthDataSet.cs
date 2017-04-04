using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet {
    
    
    public partial class FormN85FourthDataSet {
    }
}
namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet.FormN85FourthDataSetTableAdapters
{
    public partial class FourthTableAdapter
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