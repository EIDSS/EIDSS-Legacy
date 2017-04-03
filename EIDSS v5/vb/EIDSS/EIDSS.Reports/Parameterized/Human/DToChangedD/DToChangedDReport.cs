using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.DToChangedD
{
    public sealed partial class DToChangedDReport : BaseIntervalReport
    {
        public DToChangedDReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, BaseIntervalModel model)
        {
            base.SetParameters(manager, model);

            Action<SqlConnection> fillTableAction = (connection =>
                {
                    dToChangedDDataSet1.EnforceConstraints = false;
                    sp_rep_HUM_DToChangedDTableAdapter1.Connection = connection;
                    sp_rep_HUM_DToChangedDTableAdapter1.CommandTimeout = CommandTimeout;
                    sp_rep_HUM_DToChangedDTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;

                    sp_rep_HUM_DToChangedDTableAdapter1.Fill(
                        dToChangedDDataSet1.spRepHumChangedDiagnosis,
                        model.Language,
                        model.StartDate.ToString("s"),
                        model.EndDate.ToString("s"));
                });

            FillDataTableWithArchive(fillTableAction,
                                     (SqlConnection) manager.Connection,
                                     dToChangedDDataSet1.spRepHumChangedDiagnosis,
                                     model.UseArchive);

            dToChangedDDataSet1.spRepHumChangedDiagnosis.DefaultView.Sort = "strCaseID";

            DetailReport.DataAdapter = null;
        }
    }
}