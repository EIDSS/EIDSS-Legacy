using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets
{


    public partial class VetForm1ReportDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetForm1ReportDataSetTableAdapters
{



    public partial class spRepVetForm1ReportAZTableAdapter : global::System.ComponentModel.Component
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