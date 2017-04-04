namespace eidss.winclient.Location
{
    public partial class AddressLookup : bv.winclient.BasePanel.BasePanelPopup
    {
        public AddressLookup()
        {
            InitializeComponent();
            PopupControl = new AddressPopup();
        }
    }
}
