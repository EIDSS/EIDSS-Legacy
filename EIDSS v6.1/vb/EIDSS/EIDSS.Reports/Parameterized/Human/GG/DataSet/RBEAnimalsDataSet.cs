using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet
{
    public partial class RBEAnimalsDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.RBEAnimalsDataSetTableAdapters
{
    public partial class RBEAnimalsAdapter
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