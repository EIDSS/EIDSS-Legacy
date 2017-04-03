using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.ActionPanel;
using bv.winclient.BasePanel;

namespace bv.winclient.Layout
{
    public interface ILayout
    { 
        void Init(IBasePanel basePanel);
        void AddControlToMainContainer(Control basePanel);
        void CreateActionPanels();
        IBasePanel ParentBasePanel { get; set; }
        IObject BusinessObject { get; set; }
        List<ActionMetaItem> Actions { get; }
        void AddActions(List<ActionMetaItem> actions);
        void AddActions(IBasePanel basePanel, IObject bo);
        void AddActions(IBasePanel basePanel, object id);
        void AddActionPanel(Control actionPanel, ActionPanelPosition position);
        void AddCustomControlToActionPanel(Control control, ActionsPanelType panelType);
       
        event BaseActionPanel.BeforeActionExecutingDelegate OnBeforeActionExecuting;
        event BaseActionPanel.AfterActionExecutedDelegate OnAfterActionExecuted;
        void PerformAction(string actionName, List<object> parameters);
        void UpdateActionsState();
        bool SearchPanelVisible { get; set; }
        void RefreshActionButtons(bool forceReadOnly = false);
        bool ShowCaption { get; set; }

    }
}
