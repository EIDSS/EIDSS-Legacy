using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Lim.Batch
{
    public sealed partial class BatchTestReport : BaseDocumentReport
    {
        public BatchTestReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            long idfBatch = (GetLongParameter(parameters, "@ObjID"));

            long typeId = (GetLongParameter(parameters, "@TypeID"));

            spRepLimBatchTestTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepLimBatchTestTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            spRepLimBatchTestTableAdapter1.CommandTimeout = CommandTimeout;

            batchDataSet1.EnforceConstraints = false;
            spRepLimBatchTestTableAdapter1.Fill(batchDataSet1.spRepLimBatchTest, idfBatch, lang);
            FillBarcode();

            if (batchDataSet1.spRepLimBatchTest.Rows.Count > 0)
            {
                long idfBatchObservation =
                    ((BatchTestDataSet.spRepLimBatchTestRow) batchDataSet1.spRepLimBatchTest.Rows[0]).
                        idfBatchObservation;

                FlexFactory.CreateLimBatchReport(BatchFlexSubreport, idfBatchObservation, typeId);
            }
            ((TestDetailsReport) TestDetailSubreport.ReportSource).SetParameters(lang, typeId, idfBatch, manager, archiveManager);

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }

        private void FillBarcode()
        {
            if (batchDataSet1.spRepLimBatchTest.Count > 0)
            {
                var row = batchDataSet1.spRepLimBatchTest[0];

                cellBarcode.Text = row.IsBatchTestIDNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.BatchTestID);
            }
        }
    }
}