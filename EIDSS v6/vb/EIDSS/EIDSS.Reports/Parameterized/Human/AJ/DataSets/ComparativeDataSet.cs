using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets {
    
    
    public partial class ComparativeDataSet {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.ComparativeDataSetTableAdapters
{
     public partial class spRepHumComparativeTableAdapter

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
