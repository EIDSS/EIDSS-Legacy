using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    public partial class DiagnosisHistory
    {
    }
}

namespace EIDSS.Reports.Document.Human.CaseInvestigation.DiagnosisHistoryTableAdapters
{
    public partial class DiagnosisHistoryAdapter : Component
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