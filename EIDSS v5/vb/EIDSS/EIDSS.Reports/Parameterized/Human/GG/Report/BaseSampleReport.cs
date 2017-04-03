using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public partial class BaseSampleReport : BaseReport
    {
        public BaseSampleReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(DbManagerProxy manager, LabSampleModel model)
        {
            SetLanguage(manager, model.Language);
        }

        internal static void AjustDateBindings(string lang, string fieldName, XRTableCell cellMonth, XRTableCell cellDay)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNullOrEmpty(fieldName, "fieldName");
            Utils.CheckNotNull(cellMonth, "cellMonth");
            Utils.CheckNotNull(cellDay, "cellDay");

            cellMonth.DataBindings.Clear();
            cellDay.DataBindings.Clear();

            var monthBinding = new XRBinding("Text", null, fieldName, "{0:MM}");
            var dayBinding = new XRBinding("Text", null, fieldName, "{0:dd}");

            if (lang == Localizer.lngEn)
            {
                cellMonth.DataBindings.Add(monthBinding);
                cellDay.DataBindings.Add(dayBinding);
            }
            else
            {
                cellMonth.DataBindings.Add(dayBinding);
                cellDay.DataBindings.Add(monthBinding);
            }
        }
    }
}