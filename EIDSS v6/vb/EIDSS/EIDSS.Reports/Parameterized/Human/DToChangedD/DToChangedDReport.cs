using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.DToChangedD
{
    [CanWorkWithArchive]
    public partial class DToChangedDReport : BaseDateReport
    {
        public DToChangedDReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, DToChangedDSurrogateModel model)
        {
            SetParameters(manager, (BaseDateModel) model);

            DToChangedDDataSet.DiagnosisToChangedDiagnosisDataTable dataTable = DiagnosisDataSet.DiagnosisToChangedDiagnosis;
            Action<SqlConnection> action = (connection =>
            {
                DiagnosisAdapter.Connection = connection;
                DiagnosisAdapter.Transaction = (SqlTransaction) manager.Transaction;
                DiagnosisAdapter.CommandTimeout = CommandTimeout;
                DiagnosisDataSet.EnforceConstraints = false;
                 
                DiagnosisAdapter.Fill(dataTable, model.Language,
                    model.Year, model.Month,
                    model.RegionId, model.RayonId, model.SettlementId,
                    model.InitialDiagnoses.ToXml(), model.FinalDiagnoses.ToXml());
            });
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                dataTable,
                model.Mode,
                new[] {"strDiagnosisToDiagnosisKey"});

            long totalCount = 0;
            if (dataTable.Count > 0 && !dataTable[0].IsintTotalCountNull())
            {
                totalCount = dataTable[0].intTotalCount;
            }
            if (totalCount > 0)
            {
                foreach (DToChangedDDataSet.DiagnosisToChangedDiagnosisRow row in dataTable)
                {
                    row.dblPercent = (double) 100 * row.intCount / totalCount;
                }
            }
            CountTotalCell.Text = totalCount.ToString();

            dataTable.DefaultView.Sort = "strInitialDiagnosisName, strFinalDiagnosisName";
            dataTable.DefaultView.RowFilter = string.Format("dblPercent >= {0}", model.Concordance);

            DiagnosisDetailReport.DataAdapter = null;
            DataAdapter = null;

            string month = FilterHelper.GetMonthName(model.Month);
            PeriodCell.Text = string.IsNullOrEmpty(month)
                ? model.Year.ToString()
                : string.Format("{0}, {1}", model.Year, month);

            string countryName = m_BaseDataSet.sprepGetBaseParameters.Rows.Count > 0
                ? m_BaseDataSet.sprepGetBaseParameters[0].CountryName
                : string.Empty;
            AdmUnitCell.Text = string.IsNullOrEmpty(model.Location)
                ? countryName
                : string.Format("{0}, {1}", countryName, model.Location);
            string initialDiagnoses = model.InitialDiagnoses.ToString();
            InitialDiagnosesCell.Text = string.IsNullOrEmpty(initialDiagnoses)
                ? EidssMessages.Get("msgAllInitialDiagnosis ", "All Initial Diagnosis")
                : initialDiagnoses;

            string finalDiagnoses = model.FinalDiagnoses.ToString();
            FinalDiagnosesCell.Text = string.IsNullOrEmpty(finalDiagnoses)
                ? EidssMessages.Get("msgAllFinalDiagnosis ", "All Final Diagnosis")
                : finalDiagnoses;


            
            var isSingleDiagnosis = model.FinalDiagnoses.CheckedItems.Length == 1 || model.InitialDiagnoses.CheckedItems.Length == 1;
            DetailSingleHeaderTable.Visible = isSingleDiagnosis;
            DetailMultipleHeaderTable.Visible = !isSingleDiagnosis;
            DetailSingleHeaderTable.Top = DetailMultipleHeaderTable.Top + DetailMultipleHeaderTable.Height - DetailSingleHeaderTable.Height;
            
            CorcondanceHeaderCell.Text = model.FinalDiagnoses.CheckedItems.Length == 1
                ? EidssMessages.Get("msgConcordanceBasedOnFinalDiagnosis", "Concordance Based on Final Diagnosis")
                : EidssMessages.Get("msgConcordanceBasedOnInitialDiagnosis ", "Concordance Based on Initial Diagnosis");

            DiagnosisReportHeader.Height = 100;
        }
    }
}