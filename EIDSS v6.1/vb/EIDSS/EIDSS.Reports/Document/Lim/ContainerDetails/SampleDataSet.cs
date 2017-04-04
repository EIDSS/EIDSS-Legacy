using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;
namespace EIDSS.Reports.Document.Lim.ContainerDetails
{
}

namespace EIDSS.Reports.Document.Lim.ContainerDetails
{
}

namespace EIDSS.Reports.Document.Lim.ContainerDetails.SampleDataSetTableAdapters
{
    


    public partial class ContainerDetailsAdapter
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
