using System.Collections.Generic;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.FlexFormIntegration;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    public sealed partial class VetAggregateActionsReport : BaseDocumentReport
    {
        private const int Delta = 12;

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
            }
            PageHeader.Visible = false;
            tableInterval.Visible = hasData;
            lblUnit.Visible = hasData;

            AjustLeftHeaderHeight(Delta);

            int delteWidth = 8;

            long diagnosticObservation = (GetLongParameter(parameters, "@diagnosticObservation"));
            long diagnosticFormTemplate = (GetLongParameter(parameters, "@diagnosticFormTemplate"));
            string diagnosticText = GetStringParameter(parameters, "@diagnosticText" + lang);
            FlexFactory.CreateVetAggregateActionsReport(FlexSubreport, diagnosticFormTemplate, diagnosticObservation,
                tableBaseHeader.Width - delteWidth, diagnosticText);

            long sanitaryObservation = (GetLongParameter(parameters, "@sanitaryObservation"));
            long sanitaryFormTemplate = (GetLongParameter(parameters, "@sanitaryFormTemplate"));
            string sanitaryText = GetStringParameter(parameters, "@sanitaryText" + lang);

            FlexFactory.CreateVetAggregateActionsSanReport(FlexSubreportSan, sanitaryFormTemplate, sanitaryObservation,
                tableBaseHeader.Width - delteWidth, sanitaryText);

            long prophylacticObservation = (GetLongParameter(parameters, "@prophylacticObservation"));
            long prophylacticFormTemplate = (GetLongParameter(parameters, "@prophylacticFormTemplate"));
            string prophylacticText = GetStringParameter(parameters, "@prophylacticText" + lang);
            FlexFactory.CreateVetAggregateActionsProReport(FlexSubreportPro, prophylacticFormTemplate, prophylacticObservation,
                tableBaseHeader.Width - delteWidth, prophylacticText);
        }
    }
}