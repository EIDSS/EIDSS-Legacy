using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace bv.tests.Reports
{
    public class BaseReportStub : BaseReport
    {
        private readonly StubDataSet m_DataSet = new StubDataSet();
        private readonly DbManagerProxy m_Manager;
        private readonly DbManagerProxy m_ArchiveManager;

        public BaseReportStub()
        {
            m_Manager = DbManagerFactory.Factory.Create();
            m_ArchiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create();
        }

        public StubDataSet DataSet
        {
            get { return m_DataSet; }
        }

        public void FillPlainData(ReportArchiveMode useArchive)
        {
            FillDataTableWithArchive(FillAction,
                m_Manager, m_ArchiveManager,
                DataSet.Table,
                useArchive);

            DataSet.Table.DefaultView.Sort = "Disease";
        }

        public void FillSummaryData(ReportArchiveMode useArchive)
        {
            FillDataTableWithArchive(FillAction,
                m_Manager, m_ArchiveManager,
                DataSet.Table,
                useArchive, new[] {"Disease"});

            DataSet.Table.DefaultView.Sort = "Disease";
        }

        public void FillSummaryDataWithMultiKey(ReportArchiveMode useArchive)
        {
            FillDataTableWithArchive(FillAction,
                m_Manager, m_ArchiveManager,
                DataSet.Table,
                useArchive, new[] {"Disease", "Description"});

            DataSet.Table.DefaultView.Sort = "Disease, Description";
        }

        private void FillAction(SqlConnection connection, SqlTransaction transaction)
        {
            DataSet.EnforceConstraints = false;

            DataSet.Table.Rows.Clear();
            if (ReferenceEquals(connection, m_Manager.Connection))
            {
                StubDataSet.TableRow row = DataSet.Table.AddTableRow(2, "B", 2, "d2", new DateTime(2000, 02, 02), 2.1);
                row.SetNumberNull();
                DataSet.Table.AddTableRow(3, "C", 3, "d3", new DateTime(2000, 03, 02), 3.1);
                DataSet.Table.AddTableRow(1, "A", 1, "d1", new DateTime(2000, 01, 02), 1.1);
                StubDataSet.TableRow nullRow = DataSet.Table.AddTableRow(0, "E", 0, "", new DateTime(2000, 01, 01), 0);
                nullRow.SetDateNull();
                nullRow.SetDescriptionNull();
                nullRow.SetDiseaseNull();
                nullRow.SetKeyNull();
                nullRow.SetNumberNull();
                //no need to set "Double " to null
            }
            else
            {
                DataSet.Table.AddTableRow(4, "D", 40, "d40", new DateTime(2000, 04, 20), 40.1);
                StubDataSet.TableRow row = DataSet.Table.AddTableRow(2, "B", 20, "d20", new DateTime(2000, 02, 20), 20.1);
                row.SetDoubleNull();
                DataSet.Table.AddTableRow(3, "C", 30, "d3", new DateTime(2000, 03, 20), 30.1);
                StubDataSet.TableRow nullRow = DataSet.Table.AddTableRow(0, "E", 0, "", new DateTime(2000, 01, 01), 0);
                nullRow.SetDateNull();
                nullRow.SetDescriptionNull();
                nullRow.SetDiseaseNull();
                nullRow.SetDoubleNull();
                nullRow.SetKeyNull();
                nullRow.SetNumberNull();
            }
        }
    }
}