using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Core;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    [NullableAdapters]
    public sealed partial class CaseInvestigationReport : BaseDocumentReport
    {
        public CaseInvestigationReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            AddBuildingHouseBinding(CRBuildingCell, CRHouseCell, "CaseInvestigation.BuildingNum", "CaseInvestigation.HouseNum");
            AddBuildingHouseBinding(PRBuildingCell, PRHouseCell, "CaseInvestigation.RegBuld", "CaseInvestigation.RegHouse");
            AddBuildingHouseBinding(EABuildingCell, EAHouseCell, "CaseInvestigation.EmpBuild", "CaseInvestigation.EmpHouse");

            if (EidssSiteContext.Instance.IsIraqCustomization)
            {
                RemoveCellsExcept(PRTable, PRRow, new List<XRTableCell> {PRBuildingHouseCell, PRBuildingCell});
                RemoveCellsExcept(CRTable, CRRow, new List<XRTableCell> {CRBuildingHouseCell, CRBuildingCell});
                RemoveCellsExcept(EATable, EARow, new List<XRTableCell> {EABuildingHouseCell, EABuildingCell});
            }

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long epiObjID = (GetLongParameter(parameters, "@EPIObjID"));
            long csObjID = (GetLongParameter(parameters, "@CSObjID"));
            long diagnosisID = (GetLongParameter(parameters, "@DiagnosisID"));

            CaseInvestigationAdapter.Connection = (SqlConnection) manager.Connection;
            CaseInvestigationAdapter.Transaction = (SqlTransaction) manager.Transaction;
            CaseInvestigationAdapter.CommandTimeout = CommandTimeout;

            CaseInvestigationDataSet.EnforceConstraints = false;

            CaseInvestigationDataSet.CaseInvestigationDataTable dataTable = CaseInvestigationDataSet.CaseInvestigation;
            CaseInvestigationAdapter.Fill(dataTable, lang, caseId);

            if (dataTable.Count == 0 || dataTable[0].IsOutbreakIDNull())
            {
                cellOutbreakId.Visible = false;
            }

            FillBarcode();

            FillCurrentDiagnosis();

            ((TherapyReport)TherapySubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager); //TherapyReport
            ((SpecimenReport)SpecimenSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager); //SpecimenReport
            ((ContactListReport)ContactListSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager); //ContactListReport
            ((DiagnosisHistoryReport)ChangedDiagnosisSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager); //ContactListReport

            FlexFactory.CreateHumanClinicalSignsReport(ClinicalSignsSubreport, csObjID, diagnosisID);
            FlexFactory.CreateHumanEpiObservationsReport(EpiInvestigationsSubreport, epiObjID, diagnosisID);

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }

        private void FillBarcode()
        {
            if (CaseInvestigationDataSet.CaseInvestigation.Count > 0)
            {
                CaseInvestigationDataSet.CaseInvestigationRow row = CaseInvestigationDataSet.CaseInvestigation[0];
                cellBarcode.Text = row.IsCaseIdentifierNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.CaseIdentifier);

                cellOutbreakId.Text = row.IsOutbreakIDNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.OutbreakID);
            }
        }

        private void FillCurrentDiagnosis()
        {
            if (CaseInvestigationDataSet.CaseInvestigation.Count > 0)
            {
                CaseInvestigationDataSet.CaseInvestigationRow row = CaseInvestigationDataSet.CaseInvestigation[0];
                if (!row.IsInitialDiagnosisNull())
                {
                    CurrentDiagnosisCell.Text = row.IsFinalDiagnosisNull()
                        ? row.InitialDiagnosis
                        : row.FinalDiagnosis;
                }
                if (!row.IsInitialDiagDateNull())
                {
                    DateTime date = row.IsFinalDiagDateNull()
                        ? row.InitialDiagDate
                        : row.FinalDiagDate;
                    CurrentDiagnosisDateCell.Text = ReportRebinder.ToDateStringCurrentCulture(date);
                }
            }
        }

        private void BuildingHouseCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = (sender as XRTableCell);
            if (cell != null)
            {
                if (EidssSiteContext.Instance.IsIraqCustomization)
                {
                    cell.Text = FullAddressLabel.Text;
                    cell.Padding = FullAddressLabel.Padding;
                }
                else
                {
                    cell.Text = string.Format(EidssSiteContext.Instance.IsUsaAddressFormat ? "{0}/{1}" : "{1}/{0}",
                        BuildingLabel.Text, HouseLabel.Text);
                }
            }
        }
    }
}