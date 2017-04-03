using System;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class FormN1Page2 : XtraReport
    {
        internal const int MaxRows = 38;

        public FormN1Page2()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, FormNo1SurrogateModel model)
        {
            labelFooterPage3.Visible = model.IsA3Format;
            labelFooterInfo.Visible = model.IsA3Format;

            formN1InfectiousDataSet1.EnforceConstraints = false;

            FormN1InfectiousDataSet.spRepHumFormN1InfectiousDiseasesDataTable dataTable =
                formN1InfectiousDataSet1.spRepHumFormN1InfectiousDiseases;

            Action<SqlConnection> action = (connection =>
                {
                    spRepHumFormN1InfectiousDiseasesTableAdapter.Connection = connection;
                    spRepHumFormN1InfectiousDiseasesTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
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
                                                (SqlConnection) manager.Connection,
                                                dataTable,
                                                model.Mode,
                                                new[] { "intRowNumber", "strDiseaseName", "strICD10" });

        //    dataTable.DefaultView.Sort = "intRowNumber";
            while (dataTable.Rows.Count > MaxRows)
            {
                dataTable.Rows.RemoveAt(MaxRows);
            }
        }
    }
}