using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

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
            FormN1InfectiousDataSet.spRepHumFormN1InfectiousDiseasesDataTable dataTable1 =
                formN1InfectiousDataSet1.spRepHumFormN1InfectiousDiseases;

            Action<SqlConnection> action1 = (connection =>
            {
                m_Adapter1.Connection = connection;
                m_Adapter1.Transaction = (SqlTransaction) manager.Transaction;
                m_Adapter1.CommandTimeout = BaseReport.CommandTimeout;

                m_Adapter1.Fill(dataTable1,
                    model.Language,
                    model.Year,
                    model.StartMonth,
                    model.EndMonth,
                    model.RegionId,
                    model.RayonId,
                    model.OrganizationCHE);
            });

            BaseReport.FillDataTableWithArchive(action1,
                (SqlConnection) manager.Connection,
                dataTable1,
                model.Mode,
                new[] { "strDiseaseName", "strICD10"}, new[] {"intRowNumber","intOrder"});
            dataTable1.DefaultView.Sort = "intOrder";

            FormN1InfectiousDataSet.spRepHumFormN1InfectiousDiseases_IntrahospitalInfectionsDataTable dataTable2 =
                formN1InfectiousDataSet1.spRepHumFormN1InfectiousDiseases_IntrahospitalInfections;

            Action<SqlConnection> action2 = (connection =>
            {
                m_Adapter2.Connection = connection;
                m_Adapter2.Transaction = (SqlTransaction) manager.Transaction;
                m_Adapter2.CommandTimeout = BaseReport.CommandTimeout;

                m_Adapter2.Fill(dataTable2,
                    model.Language,
                    model.Year,
                    model.StartMonth,
                    model.EndMonth,
                    model.RegionId,
                    model.RayonId,
                    model.OrganizationCHE);
            });

            BaseReport.FillDataTableWithArchive(action2,
                (SqlConnection) manager.Connection,
                dataTable2,
                model.Mode,
                new[] { "strDiseaseName", "strICD10"}, new[] {"intRowNumber","intOrder"});

            dataTable2.DefaultView.Sort = "intOrder";

            int removeCount = Math.Min(FormN1Page2.MaxRows, dataTable1.Rows.Count);

            for (int i = 0; i < removeCount; i++)
            {
                dataTable1.Rows.RemoveAt(0);
            }
        }
    }
}