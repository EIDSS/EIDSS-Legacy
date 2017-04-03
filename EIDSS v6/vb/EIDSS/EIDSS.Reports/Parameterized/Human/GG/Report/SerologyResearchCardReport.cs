using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    public partial class SerologyResearchCardReport : BaseSampleReport
    {
        public SerologyResearchCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, HumanLabSampleModel model)
        {
            AjustDateBindings(model.Language, "SerologyResearchCard.datSampleReceived", ReceivedMonthCell, ReceivedDayCell);
            AjustDateBindings(model.Language, "SerologyResearchCard.datSampleCollected", CollectedMonthCell, CollectedDayCell);
            AjustDateBindings(model.Language, "SerologyResearchCard.datResultDate", TestMonthCell, TestDayCell);

            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
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
                (SqlConnection) manager.Connection,
                m_DataSet.SerologyResearchCard,
                model.Mode,
                new[] {keyName});

            m_DataSet.SerologyResearchCard.DefaultView.Sort = keyName;

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}