using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;
using bv.common.Core;
using bv.model.BLToolkit;

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

            RebindBuildingHouse(lang);

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long epiObjID = (GetLongParameter(parameters, "@EPIObjID"));
            long csObjID = (GetLongParameter(parameters, "@CSObjID"));
            long diagnosisID = (GetLongParameter(parameters, "@DiagnosisID"));

            spRepHumCaseFormTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepHumCaseFormTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            spRepHumCaseFormTableAdapter1.CommandTimeout = CommandTimeout;

            caseInvestigationDataSet1.EnforceConstraints = false;

            spRepHumCaseFormTableAdapter1.Fill(caseInvestigationDataSet1.spRepHumCaseForm, lang, caseId);

            therapyReport1.SetParameters(manager, lang, caseId);
            specimenReport1.SetParameters(manager, lang, caseId);
            contactListReport1.SetParameters(manager, lang, caseId);

            FlexFactory.CreateHumanClinicalSignsReport(ClinicalSignsSubreport, csObjID, diagnosisID);
            FlexFactory.CreateHumanEpiObservationsReport(EpiInvestigationsSubreport, epiObjID, diagnosisID);

            if ((caseInvestigationDataSet1.spRepHumCaseForm.Rows.Count == 0) ||
                (caseInvestigationDataSet1.spRepHumCaseForm.Rows[0]["OutbreakID"] is DBNull))
            {
                cellYes.Visible = false;
                cellOutbreakId.Visible = false;
            }
        }

        private void RebindBuildingHouse(string lang)
        {
            if (Localizer.lngEn != lang)
            {
                xrTableCell47.DataBindings.Clear();
                xrTableCell50.DataBindings.Clear();
                xrTableCell71.DataBindings.Clear();
                xrTableCell73.DataBindings.Clear();
                xrTableCell97.DataBindings.Clear();
                xrTableCell95.DataBindings.Clear();

                xrTableCell47.DataBindings.Add(new XRBinding("Text", null, "spRepHumCaseForm.RegBuld"));
                xrTableCell50.DataBindings.Add(new XRBinding("Text", null, "spRepHumCaseForm.RegHouse"));

                xrTableCell71.DataBindings.Add(new XRBinding("Text", null, "spRepHumCaseForm.HouseNum"));
                xrTableCell73.DataBindings.Add(new XRBinding("Text", null, "spRepHumCaseForm.BuildingNum"));

                xrTableCell97.DataBindings.Add(new XRBinding("Text", null, "spRepHumCaseForm.EmpBuild"));
                xrTableCell95.DataBindings.Add(new XRBinding("Text", null, "spRepHumCaseForm.EmpHouse"));
            }
        }
    }
}