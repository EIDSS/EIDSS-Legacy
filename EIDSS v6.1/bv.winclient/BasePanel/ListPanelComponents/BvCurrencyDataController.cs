using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DevExpress.Data;
using DevExpress.Data.Helpers;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    internal class BvCurrencyDataController : CurrencyDataController
    {
//        public override void PopulateColumns()
//        {
//            base.PopulateColumns();
//        }

//        protected override BaseDataControllerHelper CreateHelper()
//        {
//            if(ListSource == null) return new BvBaseDataControllerHelper(this);
//#if !SL
//            if(ListSource is DataView) return new DataViewDataControllerHelper(this);
//#if DXWhidbey
//            System.Windows.Forms.BindingSource bs = ListSource as System.Windows.Forms.BindingSource;
//            try {
//                if(bs != null && bs.SyncRoot is DataView) return new BindingSourceDataControllerHelper(this);
//            }
//            catch { }
//#endif
//#endif
//            return new BvListDataControllerHelper(this);
//        }
//        protected  override bool UseFirstRowTypeWhenPopulatingColumns(Type rowType)
//        {
//            return base.UseFirstRowTypeWhenPopulatingColumns(rowType);
//        }
    }
}
