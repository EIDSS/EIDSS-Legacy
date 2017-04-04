using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.WhoExport
{
    public partial class WhoExportDetail : BaseGroupPanel_WhoExport
    {
        public WhoExportDetail()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            m_ListGridControl.GridView.HorzScrollVisibility = ScrollVisibility.Always;
            m_ListGridControl.GridView.OptionsView.ColumnAutoWidth = false;
            m_ListGridControl.GridView.OptionsSelection.MultiSelect = false;
        }
        

    }
}
