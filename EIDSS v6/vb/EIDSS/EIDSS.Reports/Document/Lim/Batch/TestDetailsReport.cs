using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Lim.Batch
{
    public sealed partial class TestDetailsReport : XtraReport
    {
        private readonly FlexTestReportContainer m_SubreportContainer;

        public TestDetailsReport()
        {
            InitializeComponent();

            m_SubreportContainer = new FlexTestReportContainer(Detail, new Size(767, 75), new Point(0, 130));
        }

        internal void SetParameters(DbManagerProxy manager, string lang, long determinant, long id)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");

            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            spRepLimBatchTestDetailsTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepLimBatchTestDetailsTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            spRepLimBatchTestDetailsTableAdapter1.CommandTimeout = BaseReport.CommandTimeout;

            testDetailsDataSet1.EnforceConstraints = false;
            spRepLimBatchTestDetailsTableAdapter1.Fill(testDetailsDataSet1.spRepLimBatchTestDetails, id, lang);

            var observationList = new List<long>();
            foreach (TestDetailsDataSet.spRepLimBatchTestDetailsRow rowView in
                testDetailsDataSet1.spRepLimBatchTestDetails.Rows)
            {
                observationList.Add(rowView.idfObservation);
            }

            m_SubreportContainer.SetObservations(observationList, determinant);
        }

        private void xrTableCell9_BeforePrint(object sender, PrintEventArgs e)
        {
            m_SubreportContainer.BeforePrintNextReport();
        }
    }
}