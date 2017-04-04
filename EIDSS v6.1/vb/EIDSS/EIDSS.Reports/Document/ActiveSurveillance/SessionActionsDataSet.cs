using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.ActiveSurveillance {
    
    
    public partial class SessionActionsDataSet {
    }
}

namespace EIDSS.Reports.Document.ActiveSurveillance.SessionActionsDataSetTableAdapters
{


    public partial class SessionActionsAdapter
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