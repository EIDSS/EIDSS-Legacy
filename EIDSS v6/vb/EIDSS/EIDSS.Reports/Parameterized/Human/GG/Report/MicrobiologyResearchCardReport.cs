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
    public partial class MicrobiologyResearchCardReport : BaseSampleReport
    {
        public MicrobiologyResearchCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, HumanLabSampleModel model)
        {
            AjustDateBindings(model.Language, "MicrobiologyResearchCard.datSampleReceived", ReceivedMonthCell, ReceivedDayCell);
            AjustDateBindings(model.Language, "MicrobiologyResearchCard.datSampleCollected", CollectedMonthCell, CollectedDayCell);
            AjustDateBindings(model.Language, "MicrobiologyResearchCard.datResultIssueDate", TestMonthCell, TestDayCell);

            base.SetParameters(manager, model);

            Action<SqlConnection> action = (connection =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
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
                (SqlConnection) manager.Connection,
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
            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}