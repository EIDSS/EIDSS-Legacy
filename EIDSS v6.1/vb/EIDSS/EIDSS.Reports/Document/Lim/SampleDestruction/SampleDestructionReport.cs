using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Document.Lim.SampleDestruction
{
    public sealed partial class SampleDestructionReport : BaseDocumentReport
    {
        public SampleDestructionReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            if (!parameters.ContainsKey("@Samples"))
            {
                throw new ArgumentException("Could not get parameter '@Samples' from input dictionary.", "parameters");
            }
            string xml = parameters["@Samples"];

            SampleDestructionDataSet.EnforceConstraints = false;
            SampleDestructionAdapter.Connection = (SqlConnection) manager.Connection;
            SampleDestructionAdapter.Transaction = (SqlTransaction) manager.Transaction;
            SampleDestructionAdapter.CommandTimeout = CommandTimeout;

            SampleDestructionAdapter.Fill(SampleDestructionDataSet.SampleDestruction, lang, xml);

            foreach (SampleDestructionDataSet.SampleDestructionRow row in SampleDestructionDataSet.SampleDestruction)
            {
                if (!row.IsstrLabSampleIDBarcodeNull())
                {
                    row.strLabSampleIDBarcode = m_BarCode.Code128(row.strLabSampleIDBarcode);
                }
            }
            ReportRtlHelper.SetRTL(this);
        }
    }
}