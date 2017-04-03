using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
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

        public void SetParameters(DbManagerProxy manager, VetCasesSurrogateModel model)
        {
            SetLanguage(manager, model.Language);

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeLabel.Text = rebinder.ToDateTimeString(DateTime.Now);
            periodCell.Text = GetPeriodText(model);
            organizationCell.Text = model.OrganizationEnteredByName;

            locationCell.Text = LocationHelper.GetLocation(model.Language,
                                                           baseDataSet1.sprepGetBaseParameters[0].CountryName,
                                                           model.RegionId, model.RegionName,
                                                           model.RayonId, model.RayonName);
            m_DiagnosisCounter = 1;

            Action<SqlConnection> action = (connection =>
                {
                    m_DataAdapter.Connection = connection;
                    m_DataAdapter.Transaction = (SqlTransaction)manager.Transaction;
                    m_DataAdapter.CommandTimeout = CommandTimeout;

                    m_DataSet.EnforceConstraints = false;

                    m_DataAdapter.Fill(m_DataSet.spRepVetCaseReportAZ, model.Language,
                                       model.StartYear, model.EndYear,
                                       model.StartMonth, model.EndMonth,
                                       model.RegionId, model.RayonId, model.OrganizationEnteredById);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_DataSet.spRepVetCaseReportAZ,
                                     model.UseArchive,
                                     new[] { "strDiagnosisSpeciesKey", "strOIECode", "idfsDiagnosis", "DiagnosisOrderColumn", "SpeciesOrderColumn"});

            DataView defaultView = m_DataSet.spRepVetCaseReportAZ.DefaultView;

            FillNumberOfCasesAndSamples(model, defaultView);
            
            var totals = GetTotals(defaultView);
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

        private static Totals GetTotals( DataView defaultView)
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
                    totals.NumberCases += (int)row["intNumberCases"];
                    totals.NumberSamples += (int)row["intNumberSamples"];
                    totals.NumberSpecies += (int)row["intNumberSpecies"];
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
            AjustGroupBorders(RowNumberCell, m_IsPrintGroup);
            AjustGroupBorders(DiseaseCell, m_IsPrintGroup);
            AjustGroupBorders(OIECell, m_IsPrintGroup);
            AjustGroupBorders(NumberCasesCell, m_IsPrintGroup);
            AjustGroupBorders(NumberSamplesCell, m_IsPrintGroup);

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

        private void AjustGroupBorders(XRTableCell cell, bool isPrinted)
        {
            if (!isPrinted)
            {
                cell.Text = string.Empty;
                cell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                cell.Borders = m_DiagnosisCounter > 1
                                   ? BorderSide.Left | BorderSide.Top | BorderSide.Right
                                   : BorderSide.Left | BorderSide.Right;
            }
        }

        #region helper methods

        private static string GetPeriodText(VetCasesSurrogateModel model)
        {
            List<ItemWrapper> month = BaseDateKeeper.CreateMonthCollection();
            string period;
            if (model.StartYear == model.EndYear)
            {
                if (model.StartMonth == model.EndMonth)
                {
                    period = model.StartMonth.HasValue
                                 ? string.Format("{0} {1}", month[model.StartMonth.Value - 1], model.StartYear)
                                 : model.StartYear.ToString();
                }
                else
                {
                    period = model.StartMonth.HasValue && model.EndMonth.HasValue
                                 ? string.Format("{0} - {1} {2}",
                                                 month[model.StartMonth.Value - 1], month[model.EndMonth.Value - 1], model.StartYear)
                                 : model.StartYear.ToString();
                }
            }
            else
            {
                period = model.StartMonth.HasValue && model.EndMonth.HasValue
                             ? string.Format("{0} {1} - {2} {3}",
                                             month[model.StartMonth.Value - 1], model.StartYear, month[model.EndMonth.Value - 1],
                                             model.EndYear)
                             : string.Format("{0} - {1}", model.StartYear, model.EndYear);
            }
            return period;
        }

        #endregion
    }
}