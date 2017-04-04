using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraCharts;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public sealed partial class ZoonoticAZReport : BaseReport
    {
        public ZoonoticAZReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ZoonoticSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            BindHeader(model);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(m_DataSet.ZoonoticByMonthTable,
                    model.Language,
                    model.Year,
                    model.RegionId, model.RayonId,
                    model.DiagnosisId,
                    model.SiteId);
            });
            FillDataTableWithArchive(action,
                 manager, archiveManager,
                m_DataSet.ZoonoticByMonthTable,
                model.Mode,
                new[] { "intDataType" },
                new[] { "idfsRegion", "idfsRayon", "idfsDiagnosis" });
            m_DataSet.ZoonoticByMonthTable.DefaultView.Sort = "intDataType";

            FillChartData();
        }

        private void BindHeader(ZoonoticSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");

            string location = AddressModel.GetLocation(model.Language,
                EidssMessages.Get("strReportRepublic"),
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName, true, false);

            HeaderCell2.Text = string.Format(HeaderCell2.Text, model.Year, location);
            HeaderCell3.Text = model.DiagnosisName;    
        }

        private void FillChartData()
        {
            ZoonoticMonthsDataSet.ZoonoticByMonthTableDataTable table = m_DataSet.ZoonoticByMonthTable;

            ((ISupportInitialize) (Chart)).BeginInit();
            ((ISupportInitialize) (Chart.Diagram)).BeginInit();

            var maxValues = new List<int>();
            IList<int> humValues = table.Rows.Count > 0
                ? ZoonoticAZChartHelper.GetMonthValues(table[0])
                : GetEmptyValues();
            IList<int> animalValues = table.Rows.Count > 1
                ? ZoonoticAZChartHelper.GetMonthValues(table[1])
                : GetEmptyValues();
            foreach (KeyValuePair<int, string> month in GetMonthNames())
            {
                ZoonoticMonthsChartDataSet.ChartDataRow row = m_ChartDataSet.ChartData.NewChartDataRow();
                row.Order = month.Key;
                row.Month = month.Value;
                row.Human = humValues[month.Key];
                row.Vet = animalValues[month.Key];
                m_ChartDataSet.ChartData.AddChartDataRow(row);

                maxValues.Add(row.Human);
                maxValues.Add(row.Vet);
            }

            ChartHelper.DesignAxisY(Chart.Diagram as XYDiagram, maxValues.Max());

            if (table.Count > 1)
            {
                Chart.Series["Human"].LegendText = table[0].strDataType;
                Chart.Series["Animal"].LegendText = table[1].strDataType;
            }

            ((ISupportInitialize) (Chart.Diagram)).EndInit();
            ((ISupportInitialize) (Chart)).EndInit();
        }

        private List<int> GetEmptyValues()
        {
            var result = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                result.Add(0);
            }
            return result;
        }

        private Dictionary<int, string> GetMonthNames()
        {
            return new Dictionary<int, string>
            {
                {0, JanuaryHeaderCell.Text},
                {1, FebruaryHeaderCell.Text},
                {2, MarchHeaderCell.Text},
                {3, AprilHeaderCell.Text},
                {4, MayHeaderCell.Text},
                {5, JuneHeaderCell.Text},
                {6, JulyHeaderCell.Text},
                {7, AugustHeaderCell.Text},
                {8, SeptemberHeaderCell.Text},
                {9, OctoberHeaderCell.Text},
                {10, NovemberHeaderCell.Text},
                {11, DecemberHeaderCell.Text}
            };
        }
    }
}