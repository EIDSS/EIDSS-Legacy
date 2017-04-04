using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public partial class SerologyResearchCardReport : BaseSampleReport
    {
        public SerologyResearchCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(HumanLabSampleModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            AjustDateBindings(model.Language, "SerologyResearchCard.datSampleReceived", ReceivedMonthCell, ReceivedDayCell);
            AjustDateBindings(model.Language, "SerologyResearchCard.datSampleCollected", CollectedMonthCell, CollectedDayCell);
            AjustDateBindings(model.Language, "SerologyResearchCard.datResultDate", TestMonthCell, TestDayCell);

            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_Adapter.Fill(
                    m_DataSet.SerologyResearchCard,
                    model.Language,
                    model.SampleId,
                    model.LastName,
                    model.FirstName,
                    model.SiteId);
            });

            const string keyName = "strKey";

            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.SerologyResearchCard,
                model.Mode,
                new[] {keyName});

            m_DataSet.SerologyResearchCard.DefaultView.Sort = keyName;
        }
    }
}