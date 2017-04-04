using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet {
    
    
    public partial class FormN85ThirdDataSet {
    }
}
namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet.FormN85ThirdDataSetTableAdapters
{
    public partial class ThirdTableAdapter
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