using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class AssignmentLabDiagnosticDataSet {
        partial class AssignmentDiagnosticDataTable
        {
        }
    }

    
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.AssignmentLabDiagnosticDataSetTableAdapters
{
    public partial class AssignmentDiagnosticAdapter
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