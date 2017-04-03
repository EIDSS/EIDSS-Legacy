using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class FormVet1A : BaseReport
    {
        private bool m_IsFirstRow1 = true;
        private bool m_IsPrintGroup1 = true;
        private int m_DiagnosisCounter1;
        private bool m_IsFirstRow2 = true;
        private bool m_IsPrintGroup2 = true;
        private int m_DiagnosisCounter2;

        public FormVet1A()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, VetCasesSurrogateModel model)
        {
            SetLanguage(manager, model);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);

            ForReportPeriod.Text = VetCaseReport.GetPeriodText(model);

            m_DiagnosisCounter1 = 1;
            m_DiagnosisCounter2 = 1;

            Action<SqlConnection> action1 = (connection =>
            {
                m_DataAdapter1.Connection = connection;
                m_DataAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                m_DataAdapter1.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_DataAdapter1.Fill(m_DataSet.spRepVetForm1ADiagnosticInvestigationsAZ, model.Language,
                    model.StartYear, model.EndYear,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId, model.OrganizationEnteredById, model.OrganizationId, model.UserId);
            });
            Action<SqlConnection> action2 = (connection =>
            {
                m_DataAdapter2.Connection = connection;
                m_DataAdapter2.Transaction = (SqlTransaction) manager.Transaction;
                m_DataAdapter2.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_DataAdapter2.Fill(m_DataSet.spRepVetForm1AVaccinationMeasuresAZ, model.Language,
                    model.StartYear, model.EndYear,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId, model.OrganizationEnteredById, model.OrganizationId);
            });
            Action<SqlConnection> action3 = (connection =>
            {
                m_DataAdapter3.Connection = connection;
                m_DataAdapter3.Transaction = (SqlTransaction) manager.Transaction;
                m_DataAdapter3.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_DataAdapter3.Fill(m_DataSet.spRepVetForm1ASanitaryMeasuresAZ, model.Language,
                    model.StartYear, model.EndYear,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId, model.OrganizationEnteredById, model.OrganizationId);
            });

            FillDataTableWithArchive(action1,
                (SqlConnection) manager.Connection,
                m_DataSet.spRepVetForm1ADiagnosticInvestigationsAZ,
                model.Mode,
                new[] {"strInvestigationName", "strDiagnosisSpeciesKey", "strOIECode", "idfsDiagnosis"},
                new[] {"InvestigationOrderColumn", "DiagnosisOrderColumn", "SpeciesOrderColumn"});
            FillDataTableWithArchive(action2,
                (SqlConnection) manager.Connection,
                m_DataSet.spRepVetForm1AVaccinationMeasuresAZ,
                model.Mode,
                new[] {"strMeasureName", "strDiagnosisSpeciesKey", "strOIECode", "idfsDiagnosis"},
                new[] {"InvestigationOrderColumn", "DiagnosisOrderColumn", "SpeciesOrderColumn"});
            FillDataTableWithArchive(action3,
                (SqlConnection) manager.Connection,
                m_DataSet.spRepVetForm1ASanitaryMeasuresAZ,
                model.Mode,
                new[] {"strMeasureName"},
                new[] {"SanitaryMeasureOrderColumn"});

            VetForm1ADataSet.spRepVetForm1ADiagnosticInvestigationsAZDataTable dataTable1 =
                m_DataSet.spRepVetForm1ADiagnosticInvestigationsAZ;
            VetForm1ADataSet.spRepVetForm1AVaccinationMeasuresAZDataTable dataTable2 = m_DataSet.spRepVetForm1AVaccinationMeasuresAZ;
            dataTable1.DefaultView.Sort =
                "InvestigationOrderColumn, strInvestigationName, DiagnosisOrderColumn, strDiagnosisName, SpeciesOrderColumn, strSpecies";
            dataTable2.DefaultView.Sort =
                "InvestigationOrderColumn, strMeasureName, DiagnosisOrderColumn, strDiagnosisName, SpeciesOrderColumn, strSpecies";
            m_DataSet.spRepVetForm1ASanitaryMeasuresAZ.DefaultView.Sort = "SanitaryMeasureOrderColumn, strMeasureName";
            if (dataTable1.Count > 0)
            {
                SentBy.Text = dataTable1[0].strHeaderSentBy;
                PerformerCell.Text = dataTable1[0].strFooterPerformer;
                if (dataTable1.FirstOrDefault(r => r.idfsDiagnosis < 0) == null)
                {
                    RowNumberCell.Text = 1.ToString();
                }
            }
            if (dataTable2.FirstOrDefault(r => r.idfsDiagnosis < 0) == null)
            {
                RowNumberCell2.Text = 1.ToString();
            }
        }

        private void GroupFooterDiagnosis_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsPrintGroup1 = true;

            m_DiagnosisCounter1++;
            RowNumberCell.Text = m_DiagnosisCounter1.ToString();
        }

        private void GroupFooterDiagnosis2_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsPrintGroup2 = true;

            m_DiagnosisCounter2++;
            RowNumberCell2.Text = m_DiagnosisCounter2.ToString();
        }

        private void RowNumberCell_BeforePrint(object sender, PrintEventArgs e)
        {
            VetCaseReport.AjustGroupBorders(RowNumberCell, m_IsPrintGroup1, m_DiagnosisCounter1 > 1);
            VetCaseReport.AjustGroupBorders(NameInvestigationCell, m_IsPrintGroup1, m_DiagnosisCounter1 > 1);
            VetCaseReport.AjustGroupBorders(DiseaseCell, m_IsPrintGroup1, m_DiagnosisCounter1 > 1);
            VetCaseReport.AjustGroupBorders(OIECell, m_IsPrintGroup1, m_DiagnosisCounter1 > 1);

            m_IsPrintGroup1 = false;
        }

        private void RowNumberCell2_BeforePrint(object sender, PrintEventArgs e)
        {
            VetCaseReport.AjustGroupBorders(RowNumberCell2, m_IsPrintGroup2, m_DiagnosisCounter2 > 1);
            VetCaseReport.AjustGroupBorders(NameMeasureCell, m_IsPrintGroup2, m_DiagnosisCounter2 > 1);
            VetCaseReport.AjustGroupBorders(DiseaseCell2, m_IsPrintGroup2, m_DiagnosisCounter2 > 1);
            VetCaseReport.AjustGroupBorders(OIECell2, m_IsPrintGroup2, m_DiagnosisCounter2 > 1);

            m_IsPrintGroup2 = false;
        }

        private void SpeciesCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsFirstRow1)
            {
                SpeciesCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                NumberTested.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                NumberPositive.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                NoteCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsFirstRow1 = false;
        }

        private void SpeciesCell2_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsFirstRow2)
            {
                SpeciesCell2.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                NumberTaken.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                NoteCell2.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsFirstRow2 = false;
        }
    }
}