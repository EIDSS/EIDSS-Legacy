using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class VetCaseReport : BaseReport
    {
        private bool m_IsFirstRow = true;
        private bool m_IsPrintGroup = true;
        private int m_DiagnosisCounter;

        private class Totals
        {
            public int NumberCases { get; set; }
            public int NumberSamples { get; set; }
            public int NumberSpecies { get; set; }
        }

        public VetCaseReport()
        {
            InitializeComponent();
        }

        public void SetParameters(VetCasesSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetLanguage(model, manager);

            DateTimeLabel.Text = ReportRebinder.ToDateTimeString(DateTime.Now);
            periodCell.Text = GetPeriodText(model);
            organizationCell.Text = model.OrganizationEnteredByName;

            locationCell.Text = AddressModel.GetLocation(model.Language,
                m_BaseDataSet.sprepGetBaseParameters[0].CountryName,
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName);
            m_DiagnosisCounter = 1;

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataAdapter.Connection = connection;
                m_DataAdapter.Transaction = transaction;
                m_DataAdapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_DataAdapter.Fill(m_DataSet.spRepVetCaseReportAZ, model.Language,
                    model.StartYear, model.EndYear,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId, model.OrganizationEnteredById);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.spRepVetCaseReportAZ,
                model.Mode,
                new[] {"strDiagnosisSpeciesKey", "strOIECode", "idfsDiagnosis", "DiagnosisOrderColumn", "SpeciesOrderColumn"});

            DataView defaultView = m_DataSet.spRepVetCaseReportAZ.DefaultView;

            FillNumberOfCasesAndSamples(model, defaultView);

            Totals totals = GetTotals(defaultView);
            NumberCasesTotalCell.Text = totals.NumberCases.ToString();
            NumberSamplesTotalCell.Text = totals.NumberSamples.ToString();
            NumberSpeciesTotalCell.Text = totals.NumberSpecies.ToString();

            defaultView.Sort = "DiagnosisOrderColumn, strDiagnosisName, SpeciesOrderColumn, strSpecies";
        }

        private static void FillNumberOfCasesAndSamples(VetCasesSurrogateModel model, DataView defaultView)
        {
            defaultView.Sort = "idfsDiagnosis, SpeciesOrderColumn desc";
            if (model.UseArchive)
            {
                long diagnosisId = -1;
                int numberCases = 0;
                int numberSamples = 0;
                foreach (DataRowView row in defaultView)
                {
                    var currentDiagnosisId = (long) row["idfsDiagnosis"];
                    if (currentDiagnosisId != diagnosisId)
                    {
                        diagnosisId = currentDiagnosisId;
                        numberCases = (int) row["intNumberCases"];
                        numberSamples = (int) row["intNumberSamples"];
                    }
                    else
                    {
                        row["intNumberCases"] = numberCases;
                        row["intNumberSamples"] = numberSamples;
                    }
                }
            }
        }

        private static Totals GetTotals(DataView defaultView)
        {
            defaultView.Sort = "idfsDiagnosis, SpeciesOrderColumn desc";

            long diagnosisId = -1;
            var totals = new Totals();
            foreach (DataRowView row in defaultView)
            {
                var currentDiagnosisId = (long) row["idfsDiagnosis"];
                if (currentDiagnosisId != diagnosisId)
                {
                    diagnosisId = currentDiagnosisId;
                    totals.NumberCases += (int) row["intNumberCases"];
                    totals.NumberSamples += (int) row["intNumberSamples"];
                    totals.NumberSpecies += (int) row["intNumberSpecies"];
                }
            }
            return totals;
        }

        private void GroupFooterDiagnosis_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsPrintGroup = true;

            m_DiagnosisCounter++;
            RowNumberCell.Text = m_DiagnosisCounter.ToString();
        }

        private void RowNumberCell_BeforePrint(object sender, PrintEventArgs e)
        {
            AjustGroupBorders(RowNumberCell, m_IsPrintGroup, m_DiagnosisCounter > 1);
            AjustGroupBorders(DiseaseCell, m_IsPrintGroup, m_DiagnosisCounter > 1);
            AjustGroupBorders(OIECell, m_IsPrintGroup, m_DiagnosisCounter > 1);
            AjustGroupBorders(NumberCasesCell, m_IsPrintGroup, m_DiagnosisCounter > 1);
            AjustGroupBorders(NumberSamplesCell, m_IsPrintGroup, m_DiagnosisCounter > 1);

            m_IsPrintGroup = false;
        }

        private void SpeciesCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsFirstRow)
            {
                SpeciesCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
                NumberSpeciesCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsFirstRow = false;
        }

        private void TotalNumberCell_BeforePrint(object sender, PrintEventArgs e)
        {
            TotalNumberCell.Text = m_DiagnosisCounter.ToString();
        }

        public static void AjustGroupBorders(XRTableCell cell, bool isPrinted, bool notFirstDiagnosis)
        {
            if (!isPrinted)
            {
                cell.Text = string.Empty;
                cell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                cell.Borders = notFirstDiagnosis
                    ? BorderSide.Left | BorderSide.Top | BorderSide.Right
                    : BorderSide.Left | BorderSide.Right;
            }
        }

        #region helper methods

        public static string GetPeriodText(VetCasesSurrogateModel model)
        {
            string period;
            if (model.StartYear == model.EndYear)
            {
                if (model.StartMonth == model.EndMonth)
                {
                    period = model.StartMonth.HasValue
                        ? string.Format("{0} {1}", FilterHelper.GetMonthName(model.StartMonth.Value), model.StartYear)
                        : model.StartYear.ToString();
                }
                else
                {
                    period = model.StartMonth.HasValue && model.EndMonth.HasValue
                        ? string.Format("{0} - {1} {2}",
                            FilterHelper.GetMonthName(model.StartMonth.Value), FilterHelper.GetMonthName(model.EndMonth.Value),
                            model.StartYear)
                        : model.StartYear.ToString();
                }
            }
            else
            {
                period = model.StartMonth.HasValue && model.EndMonth.HasValue
                    ? string.Format("{0} {1} - {2} {3}",
                        FilterHelper.GetMonthName(model.StartMonth.Value), model.StartYear, FilterHelper.GetMonthName(model.EndMonth.Value),
                        model.EndYear)
                    : string.Format("{0} - {1}", model.StartYear, model.EndYear);
            }
            return period;
        }

        #endregion
    }
}