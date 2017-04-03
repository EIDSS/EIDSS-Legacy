using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls.FlexFormIntegration;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Human.Aggregate
{
    public sealed partial class CaseAggregateReport : BaseDocumentReport
    {
        private const int DeltaHeight = 12;

        public CaseAggregateReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);
            tableInterval.Left = lblReportName.Left;
            tableInterval.Width = lblReportName.Width;
            lblUnit.Left = lblReportName.Left;
            lblUnit.Width = lblReportName.Width;

            var sourceTable = new FlexParamDataSet();
            FlexConverter.FillCaseTable(manager, sourceTable, parameters, lang);
            bool hasData = sourceTable.tblCase.Rows.Count > 0;
            if (hasData)
            {
                FlexParamDataSet.tblCaseRow firstRow = sourceTable.tblCase[0];
                cellInputStartDate.Text = (firstRow.datStartDate).ToShortDateString();
                cellInputEndDate.Text = (firstRow.datFinishDate).ToShortDateString();
                lblUnit.Text = firstRow.strAdmUnitName;

                CaseIdCell.Text = firstRow.strCaseID;
                CaseIdBarcodeCell.Text = string.Format("*{0}*", firstRow.strCaseID);
                PlaceCell.Text = GetFullLocationFromAdmUnitId(firstRow.idfsAdministrativeUnit, (GisReferenceType) firstRow.idfsAdmUnitType);
            }
            PageHeader.Visible = false;
            tableInterval.Visible = hasData;
            lblUnit.Visible = hasData;
            CaseIdCell.Visible = hasData;
            CaseIdBarcodeCell.Visible = hasData;
            PlaceCell.Visible = hasData;

            AjustLeftHeaderHeight(DeltaHeight);

            long observationId = (GetLongParameter(parameters, "@observationId"));
            long idFormTemplate = (GetLongParameter(parameters, "@idFormTemplate"));
            FlexFactory.CreateHumanAggregateReport(FlexSubreport, idFormTemplate, observationId, tableBaseHeader.Width);

            DataAdapter = null;
        }
    }
}