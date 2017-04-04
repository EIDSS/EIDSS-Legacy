using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.ARM;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    [NullableAdapters]
    public sealed partial class FormN85SecondReport : FormN85BaseReport
    {

        public FormN85SecondReport()
        {
            InitializeComponent();
        }

        public override void SetParameters( FormN85SurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);



            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataSet.EnforceConstraints = false;
                m_Adapter.Connection = connection;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_Adapter.Transaction = transaction;
                m_Adapter.Fill(m_DataSet.SecondTable,
                    model.Language,
                    model.Year,
                    model.Month,
                    model.RegionId,
                    model.RayonId);
            });
            FillDataTableWithArchive(action,
                 manager, archiveManager,
                m_DataSet.SecondTable,
                model.Mode,
                new[] {KeyField});
            m_DataSet.SecondTable.DefaultView.Sort = SortField;
        }
    }
}