using DevExpress.XtraGrid.Columns;
using bv.winclient.BasePanel;

namespace eidss.winclient.Location
{
    public class LocationRepositoryLookup : BasePanelRepositoryPopup
    {
        public LocationRepositoryLookup(GridColumn col, GetBusinessObjectHandler getLocation)
            : base(col, getLocation)
        {
            PopupPanel = new LocationPopup();
            ValidationFieldName = "LocationDisplayName";
        }
    }
}
