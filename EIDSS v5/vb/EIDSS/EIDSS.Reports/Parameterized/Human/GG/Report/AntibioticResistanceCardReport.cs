using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public sealed partial class AntibioticResistanceCardReport : BaseSampleReport
    {
        public AntibioticResistanceCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, LabSampleModel model)
        {
            base.SetParameters(manager, model);

            AjustDateBindings(model.Language, "spRepAntibioticResistanceCard.datDateTestConducted", xrTableCell5, xrTableCell6);
            Action<SqlConnection> action = (connection =>
                {
                    spRepAntibioticResistanceCardTableAdapter1.Connection = connection;
                    spRepAntibioticResistanceCardTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                    spRepAntibioticResistanceCardTableAdapter1.CommandTimeout = CommandTimeout;

                    antibioticResistanceCardDataSet1.EnforceConstraints = false;
                    spRepAntibioticResistanceCardTableAdapter1.Fill(
                        antibioticResistanceCardDataSet1.spRepAntibioticResistanceCard,
                        model.Language,
                        model.SampleId,
                        model.LastName,
                        model.FirstName);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     antibioticResistanceCardDataSet1.spRepAntibioticResistanceCard,
                                     model.UseArchive, new[] {"strCulture"});

            antibioticResistanceCardDataSet1.spRepAntibioticResistanceCard.DefaultView.Sort = "strCulture desc";

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}