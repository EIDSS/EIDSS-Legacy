using bv.winclient.BasePanel;
using eidss.model.Schema;
using bv.common.Diagnostics;
using System;

namespace eidss.winclient.Location
{
    public partial class LocationPopup : LocationDetail, IPopupControl
    {
        public LocationPopup()
        {
            InitializeComponent();
            //BackColor = System.Drawing.Color.Azure;
        }

        public string GetDisplayText()
        {
            try
            {
                return ((GeoLocation)BusinessObject).LocationDisplayName;
            }
            catch (Exception e)
            {
                Dbg.Debug("can't receive location display text: {0}", e.ToString());
                return "";
            }
        }


        public BasePanelPopup PopupEdit{get;set;}
    }
}
