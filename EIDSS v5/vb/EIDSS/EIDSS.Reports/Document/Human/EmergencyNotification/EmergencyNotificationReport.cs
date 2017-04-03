using System.Collections.Generic;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Human.EmergencyNotification
{
    public sealed partial class EmergencyNotificationReport : BaseDocumentReport
    {
        public EmergencyNotificationReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            RebindBuildingHouse(lang);

            string caseId = GetStringParameter(parameters, "@ObjID");

            sp_rep_HUM_NotificationFormTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_HUM_NotificationFormTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_HUM_NotificationFormTableAdapter1.CommandTimeout = CommandTimeout;


            emergencyNotificationDataSet1.EnforceConstraints = false;
            sp_rep_HUM_NotificationFormTableAdapter1.Fill(emergencyNotificationDataSet1.spRepHumNotificationForm,
                                                          lang, long.Parse(caseId));

            AjustHomeHospitalOtherVisibility();
        }

        private void RebindBuildingHouse(string lang)
        {
            if (Localizer.lngEn != lang)
            {
                xrTableCell47.DataBindings.Clear();
                xrTableCell50.DataBindings.Clear();
                xrTableCell118.DataBindings.Clear();
                xrTableCell120.DataBindings.Clear();

                xrTableCell47.DataBindings.Add(new XRBinding("Text", null, "spRepHumNotificationForm.BuildingNum"));
                xrTableCell50.DataBindings.Add(new XRBinding("Text", null, "spRepHumNotificationForm.HouseNum"));
                xrTableCell118.DataBindings.Add(new XRBinding("Text", null, "spRepHumNotificationForm.EmpHouse"));
                xrTableCell120.DataBindings.Add(new XRBinding("Text", null, "spRepHumNotificationForm.EmpBuild"));
            }
        }

        private void AjustHomeHospitalOtherVisibility()
        {
            if (emergencyNotificationDataSet1.spRepHumNotificationForm.Rows.Count > 0)
            {
                var row =
                    (EmergencyNotificationDataSet.spRepHumNotificationFormRow)
                    emergencyNotificationDataSet1.spRepHumNotificationForm.Rows[0];
                bool isHome = ((!row.IsHomeHospitalOtherNull()) && (row.HomeHospitalOther == 5340000000));
                bool isHospital = ((!row.IsHomeHospitalOtherNull()) && (row.HomeHospitalOther == 5350000000));
                bool isOther = ((!row.IsHomeHospitalOtherNull()) && (row.HomeHospitalOther == 5360000000));

                if (!isHome)
                {
                    cellHomeYes.Text = string.Empty;
                }
                if (!isHospital)
                {
                    cellHospitalYes.Text = string.Empty;
                    //cellIfHospitalYes.Text = string.Empty;
                    cellIfHospitalName.Text = string.Empty;
                    cellIfHospitalName.DataBindings.Clear();
                }
                if (!isOther)
                {
                    cellOtherYes.Text = string.Empty;
                    //cellIfOtherYes.Text = string.Empty;
                    cellIfOtherName.Text = string.Empty;
                    cellIfOtherName.DataBindings.Clear();
                }
            }
        }
    }
}