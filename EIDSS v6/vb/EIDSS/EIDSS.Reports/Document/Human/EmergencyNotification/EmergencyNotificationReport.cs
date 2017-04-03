using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Core;
using eidss.model.Enums;
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

            AddBuildingHouseBinding(CRBuildingCell, CRHouseCell, "UrgentNotification.BuildingNum", "UrgentNotification.HouseNum");
            AddBuildingHouseBinding(EABuildingCell, EAHouseCell, "UrgentNotification.EmpBuild", "UrgentNotification.EmpHouse");

            string caseId = GetStringParameter(parameters, "@ObjID");

            NotificationAdapter.Connection = (SqlConnection) manager.Connection;
            NotificationAdapter.Transaction = (SqlTransaction) manager.Transaction;
            NotificationAdapter.CommandTimeout = CommandTimeout;

            NotificationDataSet.EnforceConstraints = false;
            NotificationAdapter.Fill(NotificationDataSet.UrgentNotification, lang, long.Parse(caseId));

            AjustHomeHospitalOtherVisibility();
        }

      

        private void AjustHomeHospitalOtherVisibility()
        {
            if (NotificationDataSet.UrgentNotification.Count > 0)
            {
                EmergencyNotificationDataSet.UrgentNotificationRow row = NotificationDataSet.UrgentNotification[0];

                bool isHome = ((!row.IsHomeHospitalOtherNull()) && (row.HomeHospitalOther == (long) PatientLocationTypeEnum.Home));
                bool isHospital = ((!row.IsHomeHospitalOtherNull()) && (row.HomeHospitalOther == (long) PatientLocationTypeEnum.Hospital));
                bool isOther = ((!row.IsHomeHospitalOtherNull()) && (row.HomeHospitalOther == (long) PatientLocationTypeEnum.Other));

                if (!isHome)
                {
                    cellHomeYes.Text = string.Empty;
                }
                if (!isHospital)
                {
                    cellHospitalYes.Text = string.Empty;
                    cellIfHospitalName.Text = string.Empty;
                    cellIfHospitalName.DataBindings.Clear();
                }
                if (!isOther)
                {
                    cellOtherYes.Text = string.Empty;
                    cellIfOtherName.Text = string.Empty;
                    cellIfOtherName.DataBindings.Clear();
                }
            }
        }

        private void BuildingHouseCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = (sender as XRTableCell);
            if (cell != null)
            {
                cell.Text = string.Format(EidssSiteContext.Instance.IsUsaAddressFormat ? "{0}/{1}" : "{1}/{0}", 
                    BuildingLabel.Text,HouseLabel.Text);
            }
        }
    }
}