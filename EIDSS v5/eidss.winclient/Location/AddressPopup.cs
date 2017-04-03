using bv.winclient.BasePanel;
using eidss.model.Schema;
using System;
using bv.common.Diagnostics;

namespace eidss.winclient.Location
{
    public partial class AddressPopup : AddressDetail, IPopupControl
    {
        public AddressPopup()
        {
            InitializeComponent();
        }

        public string GetDisplayText()
        {
            try
            {
                return BusinessObject == null ? "" : ((GeoLocation)BusinessObject).strReadOnlyAdaptiveFullName;
            }
            catch (Exception e)
            {
                Dbg.Debug("can't receive address display text: {0}", e.ToString());
                return "";
            }
        }
        public BasePanelPopup PopupEdit { get; set; }

    }
}
