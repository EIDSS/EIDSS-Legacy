using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    public sealed partial class LaboratoryResearchReport : BaseReport
    {
        public LaboratoryResearchReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, VetLaboratoryResearchResultModel model)
        {
            SetLanguage(manager, model);

            const string sortField = "intRow";
            const string keyField = "intRow";

            LaboratoryResearchDataSet.LaboratoryResearchResultDataTable dataTable = m_DataSet.LaboratoryResearchResult;
            Action<SqlConnection> action = (connection =>
            {
                m_DataAdapter.Connection = connection;
                m_DataAdapter.CommandTimeout = CommandTimeout;
                m_DataAdapter.Transaction = (SqlTransaction) manager.Transaction;
                m_DataSet.EnforceConstraints = false;
                m_DataAdapter.Fill(dataTable,
                    model.Language,
                    model.CaseId,
                    model.SessionId,
                    model.RegistrationNumber,
                    model.ConditionSampleReceived,
                    model.ResultRecipient,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                dataTable,
                model.Mode,
                new[] {keyField});

            if (dataTable.Count > 1)
            {
                List<LaboratoryResearchDataSet.LaboratoryResearchResultRow> rowsToDelete =
                    dataTable.Where(row => row.IsintRowNull()).ToList();
                foreach (LaboratoryResearchDataSet.LaboratoryResearchResultRow row in rowsToDelete)
                {
                    dataTable.Rows.Remove(row);
                }
            }

            dataTable.DefaultView.Sort = sortField;
            DataAdapter = null;
        }
    }
}