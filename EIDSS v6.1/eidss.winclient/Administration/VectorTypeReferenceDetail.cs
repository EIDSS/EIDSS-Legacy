using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class VectorTypeReferenceDetail : BaseGroupPanel_VectorTypeReference
    {
        public VectorTypeReferenceDetail()
        {
            InitializeComponent();
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            var column = Grid.GridView.Columns.ColumnByName("bitCollectionByPool");
            if (column != null)
                LookupBinder.BindRepositoryCheckEdit(column.SetCheckEditor());


            column = Grid.GridView.Columns.ColumnByName("intOrder");
            if (column != null)
                LookupBinder.BindRepositorySpinEdit(column.SetSpinEditor());

            var translationCol = Grid.GridView.Columns.ColumnByName("strTranslatedName");
            if (translationCol != null && ModelUserContext.CurrentLanguage == Localizer.lngEn)
                translationCol.Visible = false;
        }
    }
}
