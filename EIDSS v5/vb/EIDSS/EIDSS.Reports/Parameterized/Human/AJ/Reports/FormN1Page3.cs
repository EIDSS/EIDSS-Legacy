using System;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class FormN1Page3 : XtraReport
    {
        public FormN1Page3()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, FormNo1SurrogateModel model)
        {
            PageFooter.Visible = !model.IsA3Format;

            formN1InfectiousDataSet1.EnforceConstraints = false;
            FormN1InfectiousDataSet.spRepHumFormN1InfectiousDiseasesDataTable dataTable =
                formN1InfectiousDataSet1.spRepHumFormN1InfectiousDiseases;

            Action<SqlConnection> action = (connection =>
                {
                    spRepHumFormN1InfectiousDiseasesTableAdapter1.Connection = connection;
                    spRepHumFormN1InfectiousDiseasesTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
                    spRepHumFormN1InfectiousDiseasesTableAdapter1.CommandTimeout = BaseReport.CommandTimeout;

                    spRepHumFormN1InfectiousDiseasesTableAdapter1.Fill(dataTable,
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
                                                model.UseArchive,
                                                  new[] { "intRowNumber", "strDiseaseName", "strICD10" });

        //    dataTable.DefaultView.Sort = "intRowNumber";

            int removeCount = Math.Min(FormN1Page2.MaxRows, dataTable.Rows.Count);

            for (int i = 0; i < removeCount; i++)
            {
                dataTable.Rows.RemoveAt(0);
            }
        }
    }
}