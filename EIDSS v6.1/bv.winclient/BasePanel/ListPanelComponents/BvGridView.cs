using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    class BvGridView:GridView
    {
        public BvGridView() : base()
        {
            
        }
        //protected override void SetupDataController()
        //{
        //    base.SetupDataController();
        //}

        //protected override void SetDataSource(System.Windows.Forms.BindingContext context, object dataSource, string dataMember)
        //{
        //    base.SetDataSource(context, dataSource, dataMember);
        //}
        //protected override BaseGridController CreateDataController()
        //{
        //    //if (useClonedDataController != null) return useClonedDataController;
        //    if (this.requireDataControllerType == DataControllerType.AsyncServerMode) return new AsyncServerModeDataController();
        //    if (this.requireDataControllerType == DataControllerType.ServerMode) return new ServerModeDataController();
        //    if (this.requireDataControllerType == DataControllerType.RegularNoCurrencyManager) return new GridDataController();
        //    return new BvCurrencyDataController();
        //}

    }
}
