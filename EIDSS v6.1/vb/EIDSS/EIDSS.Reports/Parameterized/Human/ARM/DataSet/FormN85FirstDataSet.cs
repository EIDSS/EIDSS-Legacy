using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet
{
    public partial class FormN85FirstDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.ARM.DataSet.FormN85FirstDataSetTableAdapters
{
    public partial class FirstTableAdapter
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