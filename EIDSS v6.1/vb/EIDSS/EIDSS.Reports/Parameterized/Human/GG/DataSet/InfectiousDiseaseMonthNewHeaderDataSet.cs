using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet {
    
    
    public partial class InfectiousDiseaseMonthNewHeaderDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.InfectiousDiseaseMonthNewHeaderDataSetTableAdapters
{


  public partial class spRepHumMonthlyInfectiousDiseaseNewHeaderTableAdapter 
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