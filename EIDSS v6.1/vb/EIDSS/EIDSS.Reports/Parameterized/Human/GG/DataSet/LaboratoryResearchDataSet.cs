using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class LaboratoryResearchDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.LaboratoryResearchDataSetTableAdapters
{


    public partial class LaboratoryResearchResultAdapter 
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
        
      