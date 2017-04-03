using System.Collections.Generic;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Lim.Batch
{
    public sealed partial class BatchTestReport : BaseDocumentReport
    {
        public BatchTestReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            long idfBatch = (GetLongParameter(parameters, "@ObjID"));

            long typeId = (GetLongParameter(parameters, "@TypeID"));

            spRepLimBatchTestTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepLimBatchTestTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            spRepLimBatchTestTableAdapter1.CommandTimeout = CommandTimeout;

            batchDataSet1.EnforceConstraints = false;
            spRepLimBatchTestTableAdapter1.Fill(batchDataSet1.spRepLimBatchTest, idfBatch, lang);

            if (batchDataSet1.spRepLimBatchTest.Rows.Count > 0)
            {
                long idfBatchObservation =
                    ((BatchTestDataSet.spRepLimBatchTestRow) batchDataSet1.spRepLimBatchTest.Rows[0]).
                        idfBatchObservation;

                FlexFactory.CreateLimBatchReport(BatchFlexSubreport, idfBatchObservation, typeId);

               
            }
            m_TestDetailsReport.SetParameters(manager, lang, typeId, idfBatch);
        }
    }
}