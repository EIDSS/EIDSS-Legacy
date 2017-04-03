using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class ReportDiagnosesGroupDetail : BaseGroupPanel_ReportDiagnosesGroup
    {
        public ReportDiagnosesGroupDetail()
        {
            InitializeComponent();
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups)
        {
            var matrix = dummyObjectWithLookups as ReportDiagnosesGroup;
            if (matrix == null) return;
            var translationCol = Grid.GridView.Columns.ColumnByName("strTranslatedName");
            if (translationCol != null && ModelUserContext.CurrentLanguage == Localizer.lngEn)
                translationCol.Visible = false;
            TopPanelVisible = false;
        }
    }
}
