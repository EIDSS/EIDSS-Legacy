using bv.model.Model.Core;

namespace bv.winclient.BasePanel
{
    public interface IPopupControl
    {
        IObject BusinessObject { get; set; }
        string GetDisplayText();
        BasePanelPopupHelper PopupEdit { get; set; }
    }
}
