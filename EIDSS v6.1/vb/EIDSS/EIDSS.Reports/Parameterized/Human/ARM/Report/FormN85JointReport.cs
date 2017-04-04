using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.ARM;
using eidss.model.Reports.Common;
using eidss.model.Resources;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    [NullableAdapters]
    public sealed partial class FormN85JointReport : FormN85BaseReport
    {
        public FormN85JointReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(FormN85SurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            BindHeader(model);

            var firstReport = new FormN85FirstReport();
            FirstSectionSubreport.ReportSource = firstReport;
            firstReport.SetParameters(model, manager, archiveManager);

            var secondReport = new FormN85SecondReport();
            SecondSectionSubreport.ReportSource = secondReport;
            secondReport.SetParameters(model, manager, archiveManager);

            var thirdReport = new FormN85ThirdReport();
            ThirdSectionSubreport.ReportSource = thirdReport;
            thirdReport.SetParameters(model, manager, archiveManager);

            var fourthReport = new FormN85FourthReport();
            FourthSectionSubreport.ReportSource = fourthReport;
            fourthReport.SetParameters(model, manager, archiveManager);
        }

        private void BindHeader(FormN85SurrogateModel model)
        {
            DateHeaderCell.Text = model.Month.HasValue
                ? string.Format("{0} {1}", FilterHelper.GetMonthName(model.Month), model.Year)
                : string.Format("{0} - {1} {2}", FilterHelper.GetMonthName(1), FilterHelper.GetMonthName(12), model.Year);

            PreparedByHeaderCell.Text = model.UserName;

            RegionCell.Text = model.RegionId.HasValue
                ? model.RegionName
                : EidssMessages.Get("strRepublicOfArmenia", "Republic of Armenia ");

            if (model.RayonId.HasValue)
            {
                RayonCell.Text = model.RayonName;
            }
        }
    }
}