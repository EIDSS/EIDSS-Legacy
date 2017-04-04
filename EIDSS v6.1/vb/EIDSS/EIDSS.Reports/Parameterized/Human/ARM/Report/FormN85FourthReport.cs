using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.ARM;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    [NullableAdapters]
    public sealed partial class FormN85FourthReport : FormN85BaseReport
    {
        private int m_Counter;

        public FormN85FourthReport()
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
                m_Adapter.Fill(m_DataSet.FourthTable,
                    model.Language,
                    model.Year,
                    model.Month,
                    model.RegionId,
                    model.RayonId);
            });
            FillDataTableWithArchive(action,
                 manager, archiveManager,
                m_DataSet.FourthTable,
                model.Mode,
                new[] {KeyField});
            m_DataSet.FourthTable.DefaultView.Sort = SortField;
        }

        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_DataSet.FourthTable.Count > 0)
            {
                var blnShowTitle = m_DataSet.FourthTable[m_Counter].blnShowTitle;
                DetailHeaderSubBand.Visible = blnShowTitle;
                DetailBodySubBand.Visible = !blnShowTitle;
                m_Counter++;
            }
        }
    }
}