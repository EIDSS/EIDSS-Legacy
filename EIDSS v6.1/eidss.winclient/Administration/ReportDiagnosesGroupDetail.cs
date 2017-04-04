using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class ReportDiagnosesGroupDetail : BaseGroupPanel_ReportDiagnosesGroup
    {
        public ReportDiagnosesGroupDetail()
        {
            InitializeComponent();
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var translationCol = Grid.GridView.Columns.ColumnByName("strTranslatedName");
            if (translationCol != null && ModelUserContext.CurrentLanguage == Localizer.lngEn)
                translationCol.Visible = false;
            TopPanelVisible = false;
        }
    }
}
