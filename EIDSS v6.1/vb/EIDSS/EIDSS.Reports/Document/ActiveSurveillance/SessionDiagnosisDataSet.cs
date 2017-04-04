using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    public partial class SessionDiagnosisDataSet
    {
    }
}

namespace EIDSS.Reports.Document.ActiveSurveillance.SessionDiagnosisDataSetTableAdapters
{
    public partial class SessionDiagnosisAdapter
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