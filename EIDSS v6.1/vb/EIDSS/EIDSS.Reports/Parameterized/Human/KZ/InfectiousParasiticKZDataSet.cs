using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    public partial class InfectiousParasiticKZDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.KZ.InfectiousParasiticKZDataSetTableAdapters
{
    public partial class InfectiousDiseasesAdapter
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