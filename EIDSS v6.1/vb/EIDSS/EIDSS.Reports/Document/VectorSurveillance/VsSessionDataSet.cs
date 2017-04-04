using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.VectorSurveillance.VsSessionDataSetTableAdapters
{


    public partial class SessionAdapter 
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