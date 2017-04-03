using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls.FlexFormIntegration;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    public sealed partial class VetAggregateActionsReport : BaseDocumentReport
    {
        private const int DeltaHeight = 12;
        private const int DeltaWidth = 8;

        public VetAggregateActionsReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            tableInterval.Left = lblReportName.Left;
            tableInterval.Width = lblReportName.Width;
            lblUnit.Left = lblReportName.Left;
            lblUnit.Width = lblReportName.Width;

            base.SetParameters(manager, lang, parameters);

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

            long diagnosticObservation = (GetLongParameter(parameters, "@diagnosticObservation"));
            long diagnosticFormTemplate = (GetLongParameter(parameters, "@diagnosticFormTemplate"));
            string diagnosticText = GetStringParameter(parameters, "@diagnosticText" + lang);
            FlexFactory.CreateVetAggregateActionsReport(FlexSubreport, diagnosticFormTemplate, diagnosticObservation,
                tableBaseHeader.Width - DeltaWidth, diagnosticText);

            long sanitaryObservation = (GetLongParameter(parameters, "@sanitaryObservation"));
            long sanitaryFormTemplate = (GetLongParameter(parameters, "@sanitaryFormTemplate"));
            string sanitaryText = GetStringParameter(parameters, "@sanitaryText" + lang);

            FlexFactory.CreateVetAggregateActionsSanReport(FlexSubreportSan, sanitaryFormTemplate, sanitaryObservation,
                tableBaseHeader.Width - DeltaWidth, sanitaryText);

            long prophylacticObservation = (GetLongParameter(parameters, "@prophylacticObservation"));
            long prophylacticFormTemplate = (GetLongParameter(parameters, "@prophylacticFormTemplate"));
            string prophylacticText = GetStringParameter(parameters, "@prophylacticText" + lang);
            FlexFactory.CreateVetAggregateActionsProReport(FlexSubreportPro, prophylacticFormTemplate, prophylacticObservation,
                tableBaseHeader.Width - DeltaWidth, prophylacticText);

            DataAdapter = null;
        }
    }
}