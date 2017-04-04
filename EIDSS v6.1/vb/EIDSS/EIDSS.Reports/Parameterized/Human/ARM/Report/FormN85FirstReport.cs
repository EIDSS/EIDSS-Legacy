using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.ARM;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    [NullableAdapters]
    public sealed partial class FormN85FirstReport : FormN85BaseReport
    {
        private int m_Counter;

        public FormN85FirstReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(FormN85SurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);
            m_Counter = 0;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataSet.EnforceConstraints = false;
                m_Adapter.Connection = connection;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_Adapter.Transaction = transaction;
                m_Adapter.Fill(m_DataSet.FirstTable,
                    model.Language,
                    model.Year,
                    model.Month,
                    model.RegionId,
                    model.RayonId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.FirstTable,
                model.Mode,
                new[] {KeyField});
            m_DataSet.FirstTable.DefaultView.Sort = SortField;
        }

        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_DataSet.FirstTable.Count > 0)
            {
                var row = m_DataSet.FirstTable[m_Counter];

                DetailHeaderSubBand.Visible = row.blnShowTitle;
                DetailBodySubBand.Visible = !row.blnShowTitle;

                var fontStyle = row.blnBold ? FontStyle.Bold : FontStyle.Regular;
                DiagnosisCell.Font = new Font(DiagnosisCell.Font.Name, DiagnosisCell.Font.Size,fontStyle);

                DetailPageBreakSubBand.Visible = m_Counter == 32;
                m_Counter++;
            }
        }
    }
}