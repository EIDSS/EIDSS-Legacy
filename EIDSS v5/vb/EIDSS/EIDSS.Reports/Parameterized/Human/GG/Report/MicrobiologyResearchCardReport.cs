using System;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public partial class MicrobiologyResearchCardReport : BaseSampleReport
    {
        public MicrobiologyResearchCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, LabSampleModel model)
        {
            AjustLinesHeader(model.Language);

            AjustDateBindings(model.Language, "spRepHumMicrobiologyResearchCard.datSampleReceived", ReceivedMonthCell, ReceivedDayCell);
            AjustDateBindings(model.Language, "spRepHumMicrobiologyResearchCard.datSampleCollected", CollectedMonthCell, CollectedDayCell);
            AjustDateBindings(model.Language, "spRepHumMicrobiologyResearchCard.datDateTested", TestMonthCell, TestDayCell);

            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
                {
                    spRepHumMicrobiologyResearchCardTableAdapter.Connection = connection;
                    spRepHumMicrobiologyResearchCardTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
                    spRepHumMicrobiologyResearchCardTableAdapter.CommandTimeout = CommandTimeout;

                    microbiologyResearchCardDataSet.EnforceConstraints = false;
                    spRepHumMicrobiologyResearchCardTableAdapter.Fill(
                        microbiologyResearchCardDataSet.spRepHumMicrobiologyResearchCard_,
                        model.Language,
                        model.SampleId,
                        model.LastName,
                        model.FirstName);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     microbiologyResearchCardDataSet.spRepHumMicrobiologyResearchCard_,
                                     model.UseArchive,
                                     new[] {"strSampleId"});

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        private void AjustLinesHeader(string lang)
        {
            const int ggLineHeight = 112;
            const int defaultLineHeight = 95;
            tblLines.Height = (lang == Localizer.lngGe) ? ggLineHeight : defaultLineHeight;
        }
    }
}