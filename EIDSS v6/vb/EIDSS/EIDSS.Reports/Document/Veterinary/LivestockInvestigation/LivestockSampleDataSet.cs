using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public partial class LivestockSampleDataSet
    {
    }
}

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation.LivestockSampleDataSetTableAdapters
{
    public partial class SamplesLivestockAdapter
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