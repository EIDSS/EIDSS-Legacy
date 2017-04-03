using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Core;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    public sealed partial class CaseInvestigationReport : BaseDocumentReport
    {
        public CaseInvestigationReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            AddBuildingHouseBinding(CRBuildingCell, CRHouseCell, "CaseInvestigation.BuildingNum", "CaseInvestigation.HouseNum");
            AddBuildingHouseBinding(PRBuildingCell, PRHouseCell, "CaseInvestigation.RegBuld", "CaseInvestigation.RegHouse");
            AddBuildingHouseBinding(EABuildingCell, EAHouseCell, "CaseInvestigation.EmpBuild", "CaseInvestigation.EmpHouse");

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long epiObjID = (GetLongParameter(parameters, "@EPIObjID"));
            long csObjID = (GetLongParameter(parameters, "@CSObjID"));
            long diagnosisID = (GetLongParameter(parameters, "@DiagnosisID"));

            CaseInvestigationAdapter.Connection = (SqlConnection) manager.Connection;
            CaseInvestigationAdapter.Transaction = (SqlTransaction) manager.Transaction;
            CaseInvestigationAdapter.CommandTimeout = CommandTimeout;

            CaseInvestigationDataSet.EnforceConstraints = false;

            var dataTable = CaseInvestigationDataSet.CaseInvestigation;
            CaseInvestigationAdapter.Fill(dataTable, lang, caseId);

           
            if (dataTable.Count == 0 || dataTable[0].IsOutbreakIDNull())
            {
                cellOutbreakId.Visible = false;
            }


            ((TherapyReport) TherapySubreport.ReportSource).SetParameters(manager, lang, caseId); //TherapyReport
            ((SpecimenReport) SpecimenSubreport.ReportSource).SetParameters(manager, lang, caseId); //SpecimenReport
            ((ContactListReport) ContactListSubreport.ReportSource).SetParameters(manager, lang, caseId); //ContactListReport

            FlexFactory.CreateHumanClinicalSignsReport(ClinicalSignsSubreport, csObjID, diagnosisID);
            FlexFactory.CreateHumanEpiObservationsReport(EpiInvestigationsSubreport, epiObjID, diagnosisID);
        }

        private void BuildingHouseCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = (sender as XRTableCell);
            if (cell != null)
            {
                cell.Text = string.Format(EidssSiteContext.Instance.IsUsaAddressFormat ? "{0}/{1}" : "{1}/{0}",
                    BuildingLabel.Text, HouseLabel.Text);
            }
        }
    }
}