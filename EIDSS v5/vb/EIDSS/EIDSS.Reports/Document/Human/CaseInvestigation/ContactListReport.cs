using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Human.CaseInvestigation.SpecimenDataSetTableAdapters;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    public sealed partial class ContactListReport : XtraReport
    {
        public ContactListReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long caseId)
        {
            this.RebindDateAndFont(lang);
            RebindAccessRigths();

            sp_rep_HUM_CaseForm_ContactsTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_HUM_CaseForm_ContactsTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_HUM_CaseForm_ContactsTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            sp_rep_HUM_CaseForm_ContactsTableAdapter.Fill(contactListDataSet1.spRepHumCaseFormContacts, lang, caseId);
        }

        public void RebindAccessRigths()
        {
            XtraReportExtender.RebindAccessRigths(this);

            if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_Contact_Details))
            {
                xrTableCell10.DataBindings.Clear();
                xrTableCell10.DataBindings.Add(new XRBinding("Text", null,
                                                             "spRepHumCaseFormContacts.ContactInformationDenyRightsDetailed", ""));
            }
            if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_Contact_Settlement))
            {
                xrTableCell10.DataBindings.Clear();
                xrTableCell10.DataBindings.Add(new XRBinding("Text", null,
                                                             "spRepHumCaseFormContacts.ContactInformationDenyRightsSettlement", ""));
            }
        }
    }
}