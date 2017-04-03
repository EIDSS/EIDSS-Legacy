using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets
{
    
    
    public partial class VetForm1ADataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetForm1ADataSetTableAdapters
{
    public partial class spRepVetForm1ADiagnosticInvestigationsAZTableAdapter : global::System.ComponentModel.Component
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
    public partial class spRepVetForm1AVaccinationMeasuresAZTableAdapter : global::System.ComponentModel.Component
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
    public partial class spRepVetForm1ASanitaryMeasuresAZTableAdapter : global::System.ComponentModel.Component
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