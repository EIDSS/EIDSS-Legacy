using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    public sealed partial class VetRegionPreventiveMeasures : BaseIntervalReport
    {
        public VetRegionPreventiveMeasures()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, ProphylacticModel model)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            spRepVetPreventiveMeasuresTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetPreventiveMeasuresTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            spRepVetPreventiveMeasuresTableAdapter1.CommandTimeout = CommandTimeout;
            vetPrevMeasureDataSet1.EnforceConstraints = false;

            string diagnosisXml = FilterHelper.GetXmlFromList(model.CheckedDiagnosis);
            string speciesXml = FilterHelper.GetXmlFromList(model.CheckedSpecies);
            string typesXml = FilterHelper.GetXmlFromList(model.CheckedMeasureTypes);
            spRepVetPreventiveMeasuresTableAdapter1.Fill(
                vetPrevMeasureDataSet1.spRepVetPreventiveMeasures,
                model.Language, model.StartDate, model.EndDate, diagnosisXml, speciesXml, typesXml, model.RegionFilter.RegionId);

            bool visible = vetPrevMeasureDataSet1.spRepVetPreventiveMeasures.Count > 0;
            DetailReport.Visible = visible;
            PageHeader.Visible = visible;

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        private void cellIntNumOfVactAnimForVactTotal_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            cellIntNumOfVactAnimForVactTotal.Text = e.Text;
        }

        private void cellIntNumOfVactAnimYearTotal_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            cellIntNumOfVactAnimYearTotal.Text = e.Text;
        }

        private void cellIntPlanExecTotal_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            VetCountryPreventiveMeasures.CalculateSummary(cellIntNumOfVactAnimYearTotal.Text,
                                                          cellIntNumOfVactAnimForVactTotal.Text, e);
        }
    }
}