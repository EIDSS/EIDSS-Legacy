using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

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

        public override void SetParameters(DbManagerProxy manager, BaseDateModel model)
        {
            base.SetParameters(manager, model);

            const string sortField = "DiagnosisID";
            const string keyField = "Disease";

            // fill morbidity table
            Action<SqlConnection> main = (connection =>
            {
                mmmDataSet1.EnforceConstraints = false;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.Connection = connection;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.CommandTimeout = CommandTimeout;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.Fill(
                    mmmDataSet1.spRepHumMonthlyMorbidityMortality, model.Language, model.Year, model.Month, false);
            });
            FillDataTableWithArchive(main,
                (SqlConnection) manager.Connection,
                mmmDataSet1.spRepHumMonthlyMorbidityMortality,
                model.Mode,
                new[] {keyField});
            mmmDataSet1.spRepHumMonthlyMorbidityMortality.DefaultView.Sort = sortField;

            //fill morbidity mortal
            Action<SqlConnection> mortal = (connection =>
            {
                mmmDataSet1.EnforceConstraints = false;
                spRepHumMonthlyMorbidityMortalityMortalTableAdapter1.Connection = connection;
                spRepHumMonthlyMorbidityMortalityMortalTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                spRepHumMonthlyMorbidityMortalityTableAdapter1.CommandTimeout = CommandTimeout;
                spRepHumMonthlyMorbidityMortalityMortalTableAdapter1.Fill(
                    mmmDataSet1.spRepHumMonthlyMorbidityMortalityMortal, model.Language, model.Year, model.Month, true);
            });
            FillDataTableWithArchive(mortal,
                (SqlConnection) manager.Connection,
                mmmDataSet1.spRepHumMonthlyMorbidityMortalityMortal,
                model.Mode,
                new[] {keyField});
            mmmDataSet1.spRepHumMonthlyMorbidityMortalityMortal.DefaultView.Sort = sortField;

            DetailReport.DataAdapter = null;
            DetailReport1.DataAdapter = null;
            DataAdapter = null;
        }
    }
}