using System.Data;
using bv.common.Core;

namespace eidss.model.Avr.View
{
    public class AvrPivotViewModel
    {
        public AvrPivotViewModel(AvrView viewHeader, DataTable viewData)
        {
            Utils.CheckNotNull(viewHeader, "viewHeader");
            Utils.CheckNotNull(viewData, "data");

            ViewHeader = viewHeader;
            ViewData = viewData;
        }

        public AvrView ViewHeader { get; set; }

        public DataTable ViewData { get; set; }
    }
}