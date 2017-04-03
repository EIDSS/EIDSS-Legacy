using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public sealed partial class FormN1Page1 : XtraReport
    {
        public FormN1Page1()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, FormNo1SurrogateModel model, string countryName)
        {
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeLabel.Text = string.Format("{0} {1}", rebinder.ToDateString(DateTime.Now), rebinder.ToTimeString(DateTime.Now));

            cellHeaderParameters.DataBindings.Clear();
            cellHeaderParameters.DataBindings.Add(
                new XRBinding("Text", null, "spRepHumFormN1Header.strParameters", cellHeaderParameters.Text));

            spRepHumFormN1HeaderTableAdapter.Connection = (SqlConnection) manager.Connection;
            spRepHumFormN1HeaderTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            spRepHumFormN1HeaderTableAdapter.CommandTimeout = BaseReport.CommandTimeout;
            formN1HeaderDataSet1.EnforceConstraints = false;

            spRepHumFormN1HeaderTableAdapter.Fill(formN1HeaderDataSet1.spRepHumFormN1Header,
                model.Language,
                model.Year,
                FilterHelper.GetMonthName(model.StartMonth),
                FilterHelper.GetMonthName(model.EndMonth),
                model.RegionId,
                model.RayonId,
                model.OrganizationCHE,
                model.SiteId);

            if (formN1HeaderDataSet1.spRepHumFormN1Header.Rows.Count > 0)
            {
                var row = (FormN1HeaderDataSet.spRepHumFormN1HeaderRow) formN1HeaderDataSet1.spRepHumFormN1Header.Rows[0];
                string location = model.OrganizationCHE.HasValue
                    ? model.OrganizationCHEName
                    : AddressModel.GetLocation(model.Language, countryName,
                        model.RegionId, model.RegionName, model.RayonId, model.RayonName);
                cellOrganization.Text = string.Format("{0} ({1})", location, row.strOrganizationName);
            }
        }
    }
}