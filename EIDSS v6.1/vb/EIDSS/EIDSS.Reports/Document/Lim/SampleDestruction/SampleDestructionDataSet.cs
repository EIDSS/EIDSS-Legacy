using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.Lim.SampleDestruction.SampleDestructionDataSetTableAdapters
{
    public partial class SampleDestructionAdapter
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
}namespace EIDSS.Reports.Document.Lim.SampleDestruction {
    
    
    public partial class SampleDestructionDataSet {
    }
}
