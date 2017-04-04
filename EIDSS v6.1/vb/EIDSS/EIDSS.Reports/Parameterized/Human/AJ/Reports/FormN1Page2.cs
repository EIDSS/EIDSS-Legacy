using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [NullableAdapters]
    public partial class FormN1Page2 : XtraReport
    {
        internal const int MaxRows = 38;

        public FormN1Page2()
        {
            InitializeComponent();
        }

        public void SetParameters(FormNo1SurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            labelFooterPage3.Visible = model.IsA3Format;
            labelFooterInfo.Visible = model.IsA3Format;

            formN1InfectiousDataSet1.EnforceConstraints = false;

            FormN1InfectiousDataSet.spRepHumFormN1InfectiousDiseasesDataTable dataTable =
                formN1InfectiousDataSet1.spRepHumFormN1InfectiousDiseases;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                spRepHumFormN1InfectiousDiseasesTableAdapter.Connection = connection;
                spRepHumFormN1InfectiousDiseasesTableAdapter.Transaction = transaction;
                spRepHumFormN1InfectiousDiseasesTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

                spRepHumFormN1InfectiousDiseasesTableAdapter.Fill(
                    dataTable,
                    model.Language,
                    model.Year,
                    model.StartMonth,
                    model.EndMonth,
                    model.RegionId,
                    model.RayonId,
                    model.OrganizationCHE);
            });

            BaseReport.FillDataTableWithArchive(action,
                manager, archiveManager,
                dataTable,
                model.Mode,
                new[] {"intRowNumber", "strDiseaseName", "strICD10"});

            //    dataTable.DefaultView.Sort = "intRowNumber";
            while (dataTable.Rows.Count > MaxRows)
            {
                dataTable.Rows.RemoveAt(MaxRows);
            }
        }
    }
}