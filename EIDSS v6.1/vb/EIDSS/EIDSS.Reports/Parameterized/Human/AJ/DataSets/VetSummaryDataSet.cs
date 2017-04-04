using System.Data.SqlClient;
using System.Linq;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets
{
    public partial class VetSummaryDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetSummaryDataSetTableAdapters
{
    public partial class spRepVetSummaryAZTableAdapter
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

        public int Fill(VetSummaryDataSet.spRepVetSummaryAZDataTable dataTable, VetSummaryModel model)
        {
            switch (model.SurveillanceType)
            {
                case VetSummarySurveillanceType.PassiveSurveillanceIndex:
                    CommandCollection[0].CommandText = "dbo.spRepVetSummaryPassiveSurveillanceAZ";
                    break;
                case VetSummarySurveillanceType.ActiveSurveillanceIndex:
                    CommandCollection[0].CommandText = "dbo.spRepVetSummaryActiveSurveillanceAZ";
                    break;
                case VetSummarySurveillanceType.AggregateActionsIndex:
                    CommandCollection[0].CommandText = "dbo.spRepVetSummaryAggregateActionsAZ";
                    break;
            }

            string speciesXml = FilterHelper.GetXmlFromList(model.TakeLimitedCheckedItems);
            
            return Fill(dataTable, model.Language, model.StartDate, model.EndDate, model.DiagnosisId, speciesXml, model.ActionMethodId);
        }
    }
}