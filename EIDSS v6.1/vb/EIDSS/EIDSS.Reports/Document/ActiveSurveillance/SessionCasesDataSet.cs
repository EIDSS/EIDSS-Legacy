using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    public partial class SessionCasesDataSet
    {
    }
}

namespace EIDSS.Reports.Document.ActiveSurveillance.SessionCasesDataSetTableAdapters
{
    public partial class SessionCasesAdapter
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