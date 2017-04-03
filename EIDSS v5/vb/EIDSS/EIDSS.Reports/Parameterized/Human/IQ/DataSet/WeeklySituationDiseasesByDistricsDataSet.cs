using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklySituationDiseasesByDistricsDataSetTableAdapters
{



    public partial class spRepHumWeeklyDiseasesByDistricsTableAdapter
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