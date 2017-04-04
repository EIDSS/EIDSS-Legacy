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
    [NullableAdapters]
    public sealed partial class AntibioticResistanceCardReport : BaseSampleReport
    {
        private const int DeltaTop = 8;

        public AntibioticResistanceCardReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(HumanLabSampleModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            PageHeader.Controls.Remove(HeaderLabel);
            LogoPicture.Top = DeltaTop;
            HeaderTable.Top = DeltaTop;
            PageHeader.Height = LogoPicture.Height + 2 * DeltaTop;

            AjustDateBindings(model.Language, "spRepAntibioticResistanceCard.datDateTestConducted", xrTableCell5, xrTableCell6);
              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_AdapterNcdc.Connection = connection;
                m_AdapterNcdc.Transaction = transaction;
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
                 manager, archiveManager,
                m_DataSet.spRepAntibioticResistanceCard,
                model.Mode, new[] {"strCulture"});

            m_DataSet.spRepAntibioticResistanceCard.DefaultView.Sort = "strCulture desc";

        }

        public override void SetParameters(VetLabSampleModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters( model, manager, archiveManager);
            PageHeader.Controls.Remove(LogoPicture);
            PageHeader.Controls.Remove(HeaderTable);
            PageHeader.Height = HeaderLabel.Height + 2 * DeltaTop;

            AjustDateBindings(model.Language, "spRepAntibioticResistanceCard.datDateTestConducted", xrTableCell5, xrTableCell6);
              Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_AdapterLma.Connection = connection;
                m_AdapterLma.Transaction = transaction;
                m_AdapterLma.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;
                m_AdapterLma.Fill(
                    m_DataSet.spRepAntibioticResistanceCardLma,
                    model.Language,
                    model.SampleId,
                    model.SiteId);
            });

            FillDataTableWithArchive(action,
               manager, archiveManager,
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

        }
    }
}