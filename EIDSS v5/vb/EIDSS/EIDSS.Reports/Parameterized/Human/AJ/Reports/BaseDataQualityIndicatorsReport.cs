using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class BaseDataQualityIndicatorsReport : BaseIntervalReport
    {
        protected bool m_IsRegionPrint = true;
        protected bool m_IsRayonPrint = true;

        public BaseDataQualityIndicatorsReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, DataQualityIndicatorsModel model)
        {
            base.SetParameters(manager, (BaseIntervalModel) model);

            HeaderPeriodLabel.Text = model.Header;

            string diagnosisXml = FilterHelper.GetXmlFromList(model.MultipleDiagnosisFilter.CheckedDiagnosis);
            

            var indicatorsTable = FillReportDataSource(manager, model, diagnosisXml);
            var childDataView = indicatorsTable.DefaultView.ToTable(true, "intRegionOrder", "idfsRegion", "strRegion", "idfsRayon", "strRayon",
                                                                    "dbl_AVG_SummaryScoreByIndicators").DefaultView;
            var chartreport = new DataQualityIndicatorsChartReport {Landscape = true};
            chartreport.SetParameters(manager, model.Language, childDataView);
            ChildReport = chartreport;


            BindSummaty(indicatorsTable);

            AjustPadding();

            HideDiagnosisIfEmpty(model.MultipleDiagnosisFilter.CheckedDiagnosis);
        }

        protected DQIDataSet.spRepHumDataQualityIndicatorsDataTable FillReportDataSource
            (DbManagerProxy manager, DataQualityIndicatorsModel model, string diagnosisXml)
        {
            Action<SqlConnection> action = (connection =>
                {
                    m_DQIAdapter.Connection = connection;
                    m_DQIAdapter.Transaction = (SqlTransaction)manager.Transaction;
                    m_DQIAdapter.CommandTimeout = CommandTimeout;
                    m_DQIDataSet.EnforceConstraints = false;

                    m_DQIAdapter.Fill(m_DQIDataSet.spRepHumDataQualityIndicators, model.Language,
                                      model.StartDate.ToString("s"), model.EndDate.ToString("s"),
                                      diagnosisXml);
                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_DQIDataSet.spRepHumDataQualityIndicators,
                                     model.UseArchive,
                                     new[] {"strRegion", "strRayon", "strDiagnosis"});

            m_DQIDataSet.spRepHumDataQualityIndicators.DefaultView.Sort = "intRegionOrder, strRegion, strRayon, strDiagnosis";
            return m_DQIDataSet.spRepHumDataQualityIndicators;
        }

        protected virtual void AjustPadding()
        {
        }

        protected virtual void BindSummaty(DQIDataSet.spRepHumDataQualityIndicatorsDataTable source)
        {
        }

        protected void HideDiagnosisIfEmpty(string[] checkedDiagnosis)
        {
            if (checkedDiagnosis == null || checkedDiagnosis.Length == 0)
            {
                DynamicTopTableRow.Cells.Remove(DiagnosisHeaderCell);
                DetailDynamicTableRow.Cells.Remove(DiagnosisDetailCell);
                MaximumDynamicRow.Cells.Remove(DiagnosisMaxCell);
                TotalDynamicRow.Cells.Remove(DiagnosisTotalCell);
            }
        }

        protected void RegionDetailCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsRegionPrint)
            {
                RegionDetailCell.Text = string.Empty;
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsRegionPrint = false;
        }

        protected void RayonDetailCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsRayonPrint)
            {
                RayonDetailCell.Text = string.Empty;
                RayonDetailCell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                RayonDetailCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsRayonPrint = false;
        }

        protected void GroupFooterRegion_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsRegionPrint = true;
        }

        protected void GroupHeaderRayon_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsRayonPrint = true;
        }

        private void MaximumDynamicTable_AfterPrint(object sender, EventArgs e)
        {
            m_DQIDataSet.spRepHumDataQualityIndicators.DefaultView.RowFilter = "idfsRegion > 0";
        }


    }
}