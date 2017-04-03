using System;
using System.Data;
using System.Linq;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.model.BLToolkit;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class DataQualityIndicatorsChartReport : BaseReport
    {
        protected bool m_IsRegionPrint = true;
        protected bool m_IsRayonPrint = true;

        public DataQualityIndicatorsChartReport()
        {
            InitializeComponent();
        }

        public void SetParameters
            (DbManagerProxy manager, string lang, DataView dataSource)
        {
            SetLanguage(manager, lang);
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(lang, this);
            DateTimeLabel.Text = rebinder.ToDateTimeString(DateTime.Now);

            FillChartDataSource(dataSource);
        }

        protected void FillChartDataSource(DataView dqiView)
        {
            DataRowCollection chartRows = m_DQIChartDataSet.ChartData.Rows;
            foreach (DataRowView sourceRow in dqiView)
            {
                DQIChartDataSet.ChartDataRow destRow = m_DQIChartDataSet.ChartData.NewChartDataRow();
                destRow.RegionOrder = (sourceRow["intRegionOrder"] is DBNull)
                                          ? 0
                                          : (int) sourceRow["intRegionOrder"];
                destRow.RegionName = sourceRow["strRegion"].ToString();
                destRow.RayonName = sourceRow["strRayon"].ToString();
                destRow.Value = (sourceRow["dbl_AVG_SummaryScoreByIndicators"] is DBNull)
                                    ? 0
                                    : (double)sourceRow["dbl_AVG_SummaryScoreByIndicators"];

                chartRows.Add(destRow);
            }

            if (chartRows.Count > 0)
            {
                double avg = chartRows.Cast<DQIChartDataSet.ChartDataRow>().Sum(row => row.Value) / chartRows.Count;
                foreach (DQIChartDataSet.ChartDataRow row in chartRows)
                {
                    row.AverageValue = avg;
                }
            }

            m_DQIChartDataSet.ChartData.DefaultView.Sort = "RegionOrder, RegionName, Value desc, RayonName";
        }
    }
}