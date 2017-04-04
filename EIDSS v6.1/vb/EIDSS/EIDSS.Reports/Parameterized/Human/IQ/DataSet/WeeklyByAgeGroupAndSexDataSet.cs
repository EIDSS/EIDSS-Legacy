using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.IQ.DataSet
{
    public partial class WeeklyByAgeGroupAndSexDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.IQ.DataSet.WeeklyByAgeGroupAndSexDataSetTableAdapters
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