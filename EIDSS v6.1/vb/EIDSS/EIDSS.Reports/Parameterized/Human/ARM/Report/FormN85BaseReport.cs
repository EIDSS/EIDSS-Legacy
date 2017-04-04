using bv.model.BLToolkit;
using eidss.model.Reports.ARM;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.ARM.Report
{
    public partial class FormN85BaseReport : BaseDateReport
    {
        protected const string KeyField = "idfsDiagnosis";
        protected const string SortField = "intOrder";
        public FormN85BaseReport()
        {
            InitializeComponent();
            HideBaseHeader();
        }

        public virtual void SetParameters(FormN85SurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);
        }
    }
}