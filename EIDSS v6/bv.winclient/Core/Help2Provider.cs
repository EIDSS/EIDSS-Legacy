using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bv.winclient.Core
{
    public class Help2Provider : System.ComponentModel.Component, System.ComponentModel.IExtenderProvider
    {
        public bool CanExtend(object extendee)
        {
            return true;
        }

        public string HelpNamespace { get; set; }
        public void SetHelpKeyword(Control ctl, string value)
        {
            
        }
        public void SetHelpString(Control ctl, string value)
        {

        }
        public void SetHelpNavigator(Control ctl, HelpNavigator value)
        {

        }
        public void SetShowHelp(Control ctl, bool value)
        {

        }

        public string  GetHelpKeyword(Control ctl)
        {
            return null;
        }
        public string GetHelpString(Control ctl)
        {
            return null;
        }
        public HelpNavigator GetHelpNavigator(Control ctl)
        {
            return HelpNavigator.AssociateIndex;
        }
        public bool GetShowHelp(Control ctl)
        {
            return false;
        }
    }
}
