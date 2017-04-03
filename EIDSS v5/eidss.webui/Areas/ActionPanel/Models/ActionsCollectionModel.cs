using System.Collections.Generic;
using bv.common.Enums;
using bv.model.Model.Core;

namespace eidss.webui.Areas.ActionPanel.Models
{
    public sealed class ActionsCollectionModel
    {
        public IEnumerable<ActionMetaItem> Collection { get; private set; }
        public ActionsPanelType PanelType { get; private set; }
        public IObjectSelectList ObjectSelectList { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="panelType"></param>
        /// <param name="objectSelectList"></param>
        public ActionsCollectionModel(IEnumerable<ActionMetaItem> collection, ActionsPanelType panelType, IObjectSelectList objectSelectList)
        {
            Collection = collection;
            PanelType = panelType;
            ObjectSelectList = objectSelectList;
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