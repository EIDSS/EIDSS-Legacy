using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    public partial class SessionSummaryDataSet
    {
        partial class SessionSummaryDataTable
        {
        }
    }
}

namespace EIDSS.Reports.Document.ActiveSurveillance.SessionSummaryDataSetTableAdapters
{
    public partial class SessionSummaryAdapter
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