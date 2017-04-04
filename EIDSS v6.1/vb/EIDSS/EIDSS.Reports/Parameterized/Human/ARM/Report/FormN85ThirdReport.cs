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
    public sealed partial class FormN85ThirdReport : FormN85BaseReport
    {
        private int m_Counter;

        public FormN85ThirdReport()
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
                m_Adapter.Fill(m_DataSet.ThirdTable,
                    model.Language,
                    model.Year,
                    model.Month,
                    model.RegionId,
                    model.RayonId);
            });
            FillDataTableWithArchive(action,
                 manager, archiveManager,
                m_DataSet.ThirdTable,
                model.Mode,
                new[] {KeyField});
            m_DataSet.ThirdTable.DefaultView.Sort = SortField;
        }

        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_DataSet.ThirdTable.Count > 0)
            {
                var fontStyle = m_DataSet.ThirdTable[m_Counter].blnBold ? FontStyle.Bold : FontStyle.Regular;
                DiagnosisCell.Font = new Font(DiagnosisCell.Font.Name, DiagnosisCell.Font.Size, fontStyle);

                m_Counter++;
            }
        }
    }
}