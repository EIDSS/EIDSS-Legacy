using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklySituationDiseasesByAgeGroupAndSexDataSetTableAdapters
{

    public partial class spRepHumWeeklyDiseasesByAgeGroupAndSexTableAdapter 
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