using System;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    [CanWorkWithArchive]
    public sealed partial class InfectiousParasiticKZReport : BaseDateReport
    {
        public InfectiousParasiticKZReport()
        {
            InitializeComponent();
            //      HideBaseHeader();
        }

        public void SetParameters(InfectiousParasiticKZSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters((BaseDateModel)model, manager, archiveManager);

            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            SetLanguage(model, manager);
            ShowWarningIfDataInArchive(manager, new DateTime(model.Year, model.StartMonth ?? 1, 1), model.UseArchive);

            ReportRebinder rebinder = XtraReportExtender.GetDateRebinder(this, model.Language);
            DateTimeLabel.Text = string.Format("{0} {1}", rebinder.ToDateString(DateTime.Now), rebinder.ToTimeString(DateTime.Now));

            PeriodCell.Text = GetPeriodText(model);
            LocationCell.Text = GetLocationText(model);

            InfectiousParasiticKZDataSet.InfectiousDiseasesDataTable table = m_DataSet.InfectiousDiseases;
              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(table, model.Language,
                    model.Year,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                table,
                model.Mode,
                new[] {"idfsBaseReference"},
                new[] {"intRowNumber", "intOrder"});
            table.DefaultView.Sort = "intOrder";
        }

        private static string GetPeriodText(InfectiousParasiticKZSurrogateModel model)
        {
            string period;

            if (model.StartMonth.HasValue)
            {
                string startMonth = FilterHelper.GetMonthName(model.StartMonth.Value);
                if (model.EndMonth.HasValue && model.StartMonth != model.EndMonth)
                {
                    period = model.StartMonth == 1 && model.EndMonth == 12
                        ? model.Year.ToString()
                        : string.Format("{0} - {1} {2}", startMonth, FilterHelper.GetMonthName(model.EndMonth.Value), model.Year);
                }
                else
                {
                    period = string.Format("{0} {1}", startMonth, model.Year);
                }
            }
            else
            {
                period = model.Year.ToString();
            }

            return period;
        }

        private string GetLocationText(InfectiousParasiticKZSurrogateModel model)
        {
            string country = string.Empty;
            if (m_BaseDataSet.sprepGetBaseParameters.Count > 0)
            {
                BaseDataSet.sprepGetBaseParametersRow row = m_BaseDataSet.sprepGetBaseParameters[0];
                country = string.Format("{0} ({1})", row.CountryName, row.SiteName);
            }
            string location = AddressModel.GetLocation(model.Language,
                country,
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName);
            return location;
        }
    }
}