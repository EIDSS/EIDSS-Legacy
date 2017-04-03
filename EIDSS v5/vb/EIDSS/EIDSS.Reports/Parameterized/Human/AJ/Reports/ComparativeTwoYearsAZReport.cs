using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;
using eidss.model.Resources;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class ComparativeTwoYearsAZReport : BaseReport
    {
        public ComparativeTwoYearsAZReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, ComparativeTwoYearsSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            SetLanguage(manager, model.Language);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            BindHeader(model);

            SetBindingFormats(model.Counter);

            Action<SqlConnection> action = (connection =>
                {
                    m_DataAdapter.Connection = connection;
                    m_DataAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    m_DataAdapter.CommandTimeout = CommandTimeout;
                    m_DataSet.EnforceConstraints = false;

                    m_DataAdapter.Fill(m_DataSet.ComparativeTwoYears,
                                       model.Language,
                                       model.Year1, model.Year2,
                                       model.Counter,
                                       model.DiagnosisId,
                                       model.RegionId, model.RayonId,
                                       model.OrganizationCHE);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_DataSet.ComparativeTwoYears,
                                     model.UseArchive,
                                     new[] {"idfsYear"});
            m_DataSet.ComparativeTwoYears.DefaultView.Sort = "idfsYear";


            RoundData(model.Counter);

            FillChartData();


        }

       

        private void BindHeader(ComparativeTwoYearsSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");

            string years = string.Format("{0} - {1}", model.Year1, model.Year2);
            string location = model.OrganizationCHE.HasValue
                                  ? string.Format(EidssMessages.Get("strReportOrganization"), model.OrganizationCHEName)
                                  : LocationHelper.GetLocation(model.Language,
                                                               EidssMessages.Get("strReportRepublic"),
                                                               model.RegionId, model.RegionName,
                                                               model.RayonId, model.RayonName);
            string diagnosis = model.DiagnosisId.HasValue
                                   ? string.Format(EidssMessages.Get("strReportDiagnosisPrefix"), model.DiagnosisName)
                                   : string.Empty;

            HeaderLabel.Text = string.Format(HeaderLabel.Text, years, location, diagnosis);
        }

        private void SetBindingFormats(int counter)
        {
            SetBindingFormatString(counter == 1, new[]
                {
                    JanuaryCell, FebruaryCell, MarchCell, AprilCell, MayCell, JuneCell, JulyCell, 
                    AugustCell,SeptemberCell, OctoberCell, NovemberCell, DecemberCell, TotalCell
                });
        }

        private static void SetBindingFormatString(bool isInt, IEnumerable<XRTableCell> cells)
        {
            foreach (XRTableCell cell in cells)
            {
                foreach (XRBinding dataBinding in cell.DataBindings)
                {
                    dataBinding.FormatString = isInt
                                                   ? string.Empty
                                                   : "{0:0.00}";
                }
            }
        }

        private void RoundData(int counter)
        {
            int digits = counter == 1 ? 0 : 2;
            foreach (ComparativeTroYearsDataSet.ComparativeTwoYearsRow row in m_DataSet.ComparativeTwoYears.Rows)
            {
                row.intJanuary = Math.Round(row.intJanuary, digits);
                row.intFebruary = Math.Round(row.intFebruary, digits);
                row.intMarch = Math.Round(row.intMarch, digits);
                row.intApril = Math.Round(row.intApril, digits);
                row.intMay = Math.Round(row.intMay, digits);
                row.intJune = Math.Round(row.intJune, digits);
                row.intJuly = Math.Round(row.intJuly, digits);
                row.intAugust = Math.Round(row.intAugust, digits);
                row.intSeptember = Math.Round(row.intSeptember, digits);
                row.intOctober = Math.Round(row.intOctober, digits);
                row.intNovember = Math.Round(row.intNovember, digits);
                row.intDecember = Math.Round(row.intDecember, digits);
                row.intTotal = Math.Round(row.intTotal, digits);
            }
            
        }

        private
              void FillChartData()
        {
            if (m_DataSet.ComparativeTwoYears.Rows.Count == 2)
            {

                var year1Row = (ComparativeTroYearsDataSet.ComparativeTwoYearsRow)m_DataSet.ComparativeTwoYears.Rows[0];
                var year2Row = (ComparativeTroYearsDataSet.ComparativeTwoYearsRow)m_DataSet.ComparativeTwoYears.Rows[1];

                var data = m_ChartDataSet.ChartData;
                data.AddChartDataRow(0, JanuaryHeaderCell.Text, year1Row.intJanuary, year2Row.intJanuary);
                data.AddChartDataRow(1, FebruaryHeaderCell.Text, year1Row.intFebruary, year2Row.intFebruary);
                data.AddChartDataRow(2, MarchHeaderCell.Text, year1Row.intMarch, year2Row.intMarch);
                data.AddChartDataRow(3, AprilHeaderCell.Text, year1Row.intApril, year2Row.intApril);
                data.AddChartDataRow(4, MayHeaderCell.Text, year1Row.intMay, year2Row.intMay);
                data.AddChartDataRow(5, JuneHeaderCell.Text, year1Row.intJune, year2Row.intJune);
                data.AddChartDataRow(6, JulyHeaderCell.Text, year1Row.intJuly, year2Row.intJuly);
                data.AddChartDataRow(7, AugustHeaderCell.Text, year1Row.intAugust, year2Row.intAugust);
                data.AddChartDataRow(8, SeptemberHeaderCell.Text, year1Row.intSeptember, year2Row.intSeptember);
                data.AddChartDataRow(9, OctoberHeaderCell.Text, year1Row.intOctober, year2Row.intOctober);
                data.AddChartDataRow(10, NovemberHeaderCell.Text, year1Row.intNovember, year2Row.intNovember);
                data.AddChartDataRow(11, DecemberHeaderCell.Text, year1Row.intDecember, year2Row.intDecember);

                Chart.Series[0].Name = year1Row.idfsYear.ToString();
                Chart.Series[1].Name = year2Row.idfsYear.ToString();

            }
        }
    }
}