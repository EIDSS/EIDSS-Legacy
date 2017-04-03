using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.Model.Core;

namespace bv.winclient.BasePanel
{
    public interface IPopupControl
    {
        IObject BusinessObject { get; set; }
        string GetDisplayText();
        BasePanelPopup PopupEdit { get; set; }
    }
}
