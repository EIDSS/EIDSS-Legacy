using System.ComponentModel;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class HumSingleMeaslesDiagnosisFilter : HumSingleDiagnosisFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumSingleMeaslesDiagnosisFilter));

        public HumSingleMeaslesDiagnosisFilter()
        {
            InitializeComponent();
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}