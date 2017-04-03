using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.Lim.TestResult
{
    public partial class TestResultAmendmentHistoryDataSet
    {
    }
}

namespace EIDSS.Reports.Document.Lim.TestResult.TestResultAmendmentHistoryDataSetTableAdapters
{
    public partial class TestResultsAmendmentHistoryAdapter
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