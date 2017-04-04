using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public partial class MicrobiologyResearchCardReport : BaseSampleReport
    {
        public MicrobiologyResearchCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters( HumanLabSampleModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            AjustDateBindings(model.Language, "MicrobiologyResearchCard.datSampleReceived", ReceivedMonthCell, ReceivedDayCell);
            AjustDateBindings(model.Language, "MicrobiologyResearchCard.datSampleCollected", CollectedMonthCell, CollectedDayCell);
            AjustDateBindings(model.Language, "MicrobiologyResearchCard.datResultIssueDate", TestMonthCell, TestDayCell);

            base.SetParameters(model, manager, archiveManager);

              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_Adapter.Fill(
                    m_DataSet.MicrobiologyResearchCard,
                    model.Language,
                    model.SampleId,
                    model.LastName,
                    model.FirstName,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                 manager, archiveManager,
                m_DataSet.MicrobiologyResearchCard,
                model.Mode,
                new[] {"strSampleId"});

            if (m_DataSet.MicrobiologyResearchCard.Count > 0)
            {
                MicrobiologyResearchCardDataSet.MicrobiologyResearchCardRow row = m_DataSet.MicrobiologyResearchCard[0];
                BacteriologyCheckBox.Checked = (!row.IsblnBacteriologyNull() && row.blnBacteriology);
                VirologyCheckBox.Checked = (!row.IsblnVirologyNull() && row.blnVirology);
                MicroscopingCheckBox.Checked = (!row.IsblnMicroscopyNull() && row.blnMicroscopy);
                PCRCheckBox.Checked = (!row.IsblnPCRNull() && row.blnPCR);
                OtherCheckBox.Checked = (!row.IsblnOtherNull() && row.blnOther);
            }
        }
    }
}