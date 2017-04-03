using System.Collections.Generic;
using bv.common.Enums;
using bv.model.Model.Core;

namespace eidss.webui.Areas.ActionPanel.Models
{
    public sealed class ActionPanelModel
    {
        public List<ActionMetaItem> Actions { get; private set; }
        public ActionsPanelType PanelType{ get; private set; }
        public IObjectAccessor Accessor { get; private set; }
        public IObjectSelectList ObjectSelectList { get { return Accessor as IObjectSelectList; }  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="actions"></param>
        /// <param name="panelType"></param>
        public ActionPanelModel(IObjectAccessor accessor, List<ActionMetaItem> actions, ActionsPanelType panelType)
        {
            Accessor = accessor;
            Actions = actions;
            PanelType = panelType;
        }
    }
}