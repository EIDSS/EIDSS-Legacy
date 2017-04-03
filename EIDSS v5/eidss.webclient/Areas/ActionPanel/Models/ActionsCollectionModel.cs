using System.Collections.Generic;
using bv.common.Enums;
using bv.model.Model.Core;

namespace eidss.webclient.Areas.ActionPanel.Models
{
    public sealed class ActionsCollectionModel
    {
        public IEnumerable<ActionMetaItem> Collection { get; private set; }
        public ActionsPanelType PanelType { get; private set; }
        public IObject Obj { get; private set; }
        public IObjectAccessor Accessor { get; private set; }
        public IObjectSelectList ObjectSelectList { get { return Accessor as IObjectSelectList; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="panelType"></param>
        /// <param name="accessor"></param>
        public ActionsCollectionModel(IEnumerable<ActionMetaItem> collection, ActionsPanelType panelType, IObjectAccessor accessor, IObject obj)
        {
            Collection = collection;
            PanelType = panelType;
            Accessor = accessor;
            Obj = obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsListForm()
        {
            return ObjectSelectList != null;
        }
    }
}