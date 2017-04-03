using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Veterinary.Situation
{
    public sealed partial class VetSituationReport : BaseYearReport
    {
        public VetSituationReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    vetSituationDataSet1.EnforceConstraints = false;
                    sp_rep_VET_YearlyVeterinarySituationTableAdapter1.Connection = connection;
                    sp_rep_VET_YearlyVeterinarySituationTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                    sp_rep_VET_YearlyVeterinarySituationTableAdapter1.CommandTimeout = CommandTimeout;

                    sp_rep_VET_YearlyVeterinarySituationTableAdapter1.Fill(
                        vetSituationDataSet1.spRepVetYearlyVeterinarySituation,
                        model.Language, model.Year);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     vetSituationDataSet1.spRepVetYearlyVeterinarySituation,
                                     model.UseArchive,
                                     new[] {"Disease"});

            vetSituationDataSet1.spRepVetYearlyVeterinarySituation.DefaultView.Sort = "Disease";

            DetailReport.DataAdapter = null;
        }
    }
}