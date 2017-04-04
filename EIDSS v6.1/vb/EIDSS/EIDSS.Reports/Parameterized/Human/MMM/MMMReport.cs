using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Parameterized.Human.MMM
{
    [CanWorkWithArchive]
    public sealed partial class MMMReport : BaseDateReport
    {
        public MMMReport()
        {
            InitializeComponent();
            //Note [Ivan] it fixing spreading of report bands
            Detail.Visible = false;
            Detail.Height = 0;
            Detail1.Height = 0;
            Detail2.Height = 0;
            ReportHeader.Height = 0;
            PageHeader.Height = 0;
        }

        public override void SetParameters(BaseDateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            const string sortField = "DiagnosisID";
            const string keyField = "Disease";

            // fill morbidity table
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                mmmDataSet1.EnforceConstraints = false;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.Connection = connection;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.Transaction = transaction;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.CommandTimeout = CommandTimeout;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.Fill(
                    mmmDataSet1.spRepHumMonthlyMorbidityMortality, model.Language, model.Year, model.Month, false);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                mmmDataSet1.spRepHumMonthlyMorbidityMortality,
                model.Mode,
                new[] {keyField});
            mmmDataSet1.spRepHumMonthlyMorbidityMortality.DefaultView.Sort = sortField;

            //fill morbidity mortal
            Action<SqlConnection, SqlTransaction> mortal = ((connection, transaction) =>
            {
                mmmDataSet1.EnforceConstraints = false;
                spRepHumMonthlyMorbidityMortalityMortalTableAdapter1.Connection = connection;
                spRepHumMonthlyMorbidityMortalityMortalTableAdapter1.Transaction = transaction;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.CommandTimeout = CommandTimeout;
                spRepHumMonthlyMorbidityMortalityMortalTableAdapter1.Fill(
                    mmmDataSet1.spRepHumMonthlyMorbidityMortalityMortal, model.Language, model.Year, model.Month, true);
            });
            FillDataTableWithArchive(mortal,
                manager, archiveManager,
                mmmDataSet1.spRepHumMonthlyMorbidityMortalityMortal,
                model.Mode,
                new[] {keyField});
            mmmDataSet1.spRepHumMonthlyMorbidityMortalityMortal.DefaultView.Sort = sortField;

            ReportRtlHelper.SetRTL(this);
        }
    }
}