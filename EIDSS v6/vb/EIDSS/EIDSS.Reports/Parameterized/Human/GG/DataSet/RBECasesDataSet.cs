using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class RBECasesDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.RBECasesDataSetTableAdapters
{
    public partial class RBECasesAdapter
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
