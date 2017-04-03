using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    public sealed partial class AntibioticResistanceCardReport : BaseSampleReport
    {
        private const int DeltaTop = 8;

        public AntibioticResistanceCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, HumanLabSampleModel model)
        {
            base.SetParameters(manager, model);

            PageHeader.Controls.Remove(HeaderLabel);
            LogoPicture.Top = DeltaTop;
            HeaderTable.Top = DeltaTop;
            PageHeader.Height = LogoPicture.Height + 2 * DeltaTop;

            AjustDateBindings(model.Language, "spRepAntibioticResistanceCard.datDateTestConducted", xrTableCell5, xrTableCell6);
            Action<SqlConnection> action = (connection =>
            {
                m_AdapterNcdc.Connection = connection;
                m_AdapterNcdc.Transaction = (SqlTransaction) manager.Transaction;
                m_AdapterNcdc.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_AdapterNcdc.Fill(
                    m_DataSet.spRepAntibioticResistanceCard,
                    model.Language,
                    model.SampleId,
                    model.LastName,
                    model.FirstName,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_DataSet.spRepAntibioticResistanceCard,
                model.Mode, new[] {"strCulture"});

            m_DataSet.spRepAntibioticResistanceCard.DefaultView.Sort = "strCulture desc";

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }

        public override void SetParameters(DbManagerProxy manager, VetLabSampleModel model)
        {
            base.SetParameters(manager, model);
            PageHeader.Controls.Remove(LogoPicture);
            PageHeader.Controls.Remove(HeaderTable);
            PageHeader.Height = HeaderLabel.Height + 2 * DeltaTop;

            AjustDateBindings(model.Language, "spRepAntibioticResistanceCard.datDateTestConducted", xrTableCell5, xrTableCell6);
            Action<SqlConnection> action = (connection =>
            {
                m_AdapterLma.Connection = connection;
                m_AdapterLma.Transaction = (SqlTransaction) manager.Transaction;
                m_AdapterLma.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_AdapterLma.Fill(
                    m_DataSet.spRepAntibioticResistanceCardLma,
                    model.Language,
                    model.SampleId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_DataSet.spRepAntibioticResistanceCardLma,
                model.Mode, new[] {"strCulture"});

            foreach (AntibioticResistanceCardDataSet.spRepAntibioticResistanceCardLmaRow row 
                in m_DataSet.spRepAntibioticResistanceCardLma.Rows)
            {
                AntibioticResistanceCardDataSet.spRepAntibioticResistanceCardRow newRow =
                    m_DataSet.spRepAntibioticResistanceCard.NewspRepAntibioticResistanceCardRow();

                for (int i = 0; i < m_DataSet.spRepAntibioticResistanceCard.Columns.Count; i++)
                {
                    newRow[i] = row[i];
                }

                m_DataSet.spRepAntibioticResistanceCard.AddspRepAntibioticResistanceCardRow(newRow);
            }

            m_DataSet.spRepAntibioticResistanceCard.DefaultView.Sort = "strCulture desc";

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}