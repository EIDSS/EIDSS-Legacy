using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    [NullableAdapters]
    public partial class VetCountryPreventiveMeasures : BaseIntervalReport
    {
        public VetCountryPreventiveMeasures()
        {
            InitializeComponent();
        }

        public void SetParameters(ProphylacticModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {

            base.SetParameters(model, manager, archiveManager);

            spRepVetPreventiveMeasuresTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetPreventiveMeasuresTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            spRepVetPreventiveMeasuresTableAdapter1.CommandTimeout = CommandTimeout;

            vetPrevMeasureDataSet1.EnforceConstraints = false;

            string diagnosisXml = FilterHelper.GetXmlFromList(model.CheckedDiagnosis);
            string speciesXml = FilterHelper.GetXmlFromList(model.CheckedSpecies);
            string typesXml = FilterHelper.GetXmlFromList(model.CheckedMeasureTypes);

            spRepVetPreventiveMeasuresTableAdapter1.Fill(vetPrevMeasureDataSet1.spRepVetPreventiveMeasures_Country,
                model.Language, model.StartDate, model.EndDate,
                diagnosisXml, speciesXml, typesXml, null);

            bool visible = vetPrevMeasureDataSet1.spRepVetPreventiveMeasures_Country.Count > 0;
            DetailReport.Visible = visible;
            PageHeader.Visible = visible;
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
            CalculateSummary(cellIntNumOfVactAnimYearTotal.Text, cellIntNumOfVactAnimForVactTotal.Text, e);
        }

        internal static void CalculateSummary(string nominatorString, string denominatorString, TextFormatEventArgs e)
        {
            string result = string.Empty;
            double nominator;
            double denominator;
            if (double.TryParse(nominatorString, out nominator) &&
                double.TryParse(denominatorString, out denominator))
            {
                if (denominator != 0)
                {
                    result = string.Format("{0:0.00}", 100 * nominator / denominator);
                }
            }
            e.Text = result;
        }
    }
}