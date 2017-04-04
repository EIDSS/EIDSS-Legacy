using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet {
    
    
    public partial class FormN85SecondDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet.FormN85SecondDataSetTableAdapters
{
    public partial class SecondTableAdapter
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