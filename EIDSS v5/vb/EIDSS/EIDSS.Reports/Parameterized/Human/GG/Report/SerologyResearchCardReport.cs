using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public partial class SerologyResearchCardReport : BaseSampleReport
    {
        public SerologyResearchCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, LabSampleModel model)
        {
            AjustDateBindings(model.Language, "spRepHumSerologyResearchCard.datSampleReceived", ReceivedMonthCell, ReceivedDayCell);
            AjustDateBindings(model.Language, "spRepHumSerologyResearchCard.datSampleCollected", CollectedMonthCell, CollectedDayCell);
            AjustDateBindings(model.Language, "spRepHumSerologyResearchCard.datDateTested", TestMonthCell, TestDayCell);

            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    spRepHumSerologyResearchCardTableAdapter1.Connection = connection;
                    spRepHumSerologyResearchCardTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumSerologyResearchCardTableAdapter1.CommandTimeout = CommandTimeout;

                    serologyResearchCardDataSet1.EnforceConstraints = false;
                    spRepHumSerologyResearchCardTableAdapter1.Fill(
                        serologyResearchCardDataSet1.spRepHumSerologyResearchCard,
                        model.Language,
                        model.SampleId,
                        model.LastName,
                        model.FirstName);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     serologyResearchCardDataSet1.spRepHumSerologyResearchCard,
                                     model.UseArchive,
                                     new[] {"strKey"});
            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}