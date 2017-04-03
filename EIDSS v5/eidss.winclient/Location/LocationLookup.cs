namespace eidss.winclient.Location
{
    public partial class LocationLookup : bv.winclient.BasePanel.BasePanelPopup
    {
        public LocationLookup()
        {
            InitializeComponent();
            PopupControl = new LocationPopup();
            ValidationFieldName = "LocationDisplayName";
        }
    }
}
