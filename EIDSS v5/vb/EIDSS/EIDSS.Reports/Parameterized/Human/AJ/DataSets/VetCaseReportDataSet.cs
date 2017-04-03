using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class VetCaseReportDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetCaseReportDataSetTableAdapters
{



    public partial class spRepVetCaseReportAZTableAdapter : global::System.ComponentModel.Component
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