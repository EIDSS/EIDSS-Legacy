using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraEditors;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.common.Resources.Images;
using DevExpress.XtraBars;
using bv.winclient.BasePanel;
using DevExpress.Utils;

namespace bv.winclient.ActionPanel
{
    /// <summary>
    /// 
    /// </summary>
    public class DropDownActionHelper
    {
        private readonly DropDownButton m_ButtonMain;

        private readonly PopupMenu m_PopupActions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bo"></param>
        /// <param name="actions"></param>
        /// <param name="parentActionPanel"></param>
        public DropDownActionHelper(IObject bo, List<ActionMetaItem> actions, ActionPanel parentActionPanel)
        {
            m_ButtonMain = new DropDownButton();
            m_PopupActions = new PopupMenu { Manager = BaseFormManager.MainBarManager ?? new BarManager() };
            m_ButtonMain.DropDownControl = m_PopupActions;
            m_PopupActions.BeforePopup += m_PopupActionsBeforePopup;
            m_ButtonMain.Click += ShowDropDown;
            BusinessObject = bo;
            ParentActionPanel = parentActionPanel;
            ButtonLinks = new Dictionary<ActionMetaItem, BarItemLink>();
            InitRoutines(actions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_PopupActionsBeforePopup(object sender, CancelEventArgs e)
        {
            InvokeOnBeforePopup();
        }

        public delegate void BeforePopupDelegate();
        public event BeforePopupDelegate OnBeforePopup;

        /// <summary>
        /// 
        /// </summary>
        public void InvokeOnBeforePopup()
        {
            if (OnBeforePopup != null) OnBeforePopup();
        }

        private void ShowDropDown(object sender, EventArgs e)
        {
            m_ButtonMain.ShowDropDown();
        }

        public DropDownButton Button
        {
            get { return m_ButtonMain; }
        }

        internal ActionPanel ParentActionPanel { get; private set; }

        private List<ActionMetaItem> m_ActionsList;

        /// <summary>
        /// Действия, которые располагаются в этой группе
        /// </summary>
        public List<ActionMetaItem> Actions
        {
            get { return m_ActionsList ?? (m_ActionsList = new List<ActionMetaItem>()); }
            set { m_ActionsList = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private IObject BusinessObject { get; set; }

        private IObjectPermissions Permissions { get { return BusinessObject != null ? BusinessObject.GetAccessor() as IObjectPermissions : null; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        private void InitRoutines(List<ActionMetaItem> actions)
        {
            Actions = actions;

            if (Actions == null) return;
            foreach (var action in Actions)
            {
                AddAction(action, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringId"></param>
        /// <returns></returns>
        private string GetCaption(string stringId)
        {
            var result = ParentActionPanel.GetMessage(stringId);
            if (result.Length == 0) result = stringId;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="needAddAction"></param>
        public void AddAction(ActionMetaItem action, bool needAddAction)
        {
            int index = Actions.Count;
            var image = ImagesStorage.Get(action.IconId(BusinessObject, Permissions));
            if (action.ActionType == ActionTypes.Container)
            {
                m_ButtonMain.Tag = action;
                m_ButtonMain.Text = GetCaption(action.CaptionId(BusinessObject, Permissions));
                m_ButtonMain.Name = String.Format("btn{0}", action.Name);
                if (image != null)
                    m_ButtonMain.Image = image;
                if (!string.IsNullOrEmpty(action.TooltipId(BusinessObject, Permissions)))
                {
                    var superToolTip = new SuperToolTip();
                    //TODO получать текст специальным методом
                    superToolTip.Items.Add(GetCaption(action.TooltipId(BusinessObject, Permissions)));
                    m_ButtonMain.SuperTip = superToolTip;
                }
                return;
            }
            var button = new BarButtonItem(m_PopupActions.Manager, GetCaption(action.CaptionId(BusinessObject, Permissions))) { Id = index, Tag = action };
            if (image != null) button.Glyph = image;
            button.ItemClick += OnButtonItemClick;
            button.Enabled = action.IsEnable(BusinessObject, BusinessObject.GetPermissions());

            ButtonLinks.Add(action, m_PopupActions.AddItem(button));
            if (needAddAction) Actions.Add(action);

            //TODO правильно ли следующее
            if (String.IsNullOrEmpty(m_ButtonMain.Text) && Actions.Count >= 1)
            {
                m_ButtonMain.Tag = Actions[0];
                m_ButtonMain.Text = GetCaption(Actions[0].Container);
            }
        }

        /// <summary>
        /// Хранилище ссылок на кнопки
        /// </summary>
        public Dictionary<ActionMetaItem, BarItemLink> ButtonLinks { get; private set; } 

        /// <summary>
        /// Удаляет действие из коллекции
        /// </summary>
        /// <param name="action"></param>
        public void DeleteAction(ActionMetaItem action)
        {
            if (Actions.Contains(action))
            {
                //отыскиваем соответствующую кнопку
                if (ButtonLinks.ContainsKey(action))
                {
                    m_PopupActions.RemoveLink(ButtonLinks[action]);
                    Actions.Remove(action);
                    ButtonLinks.Remove(action);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnButtonItemClick(object sender, ItemClickEventArgs e)
        {
            var button = e.Item as BarButtonItem;
            if (button == null) return;
            var action = button.Tag as ActionMetaItem;
            if ((action != null) && (ParentActionPanel != null)) ParentActionPanel.RunAction(action, null);
        }

    }
}
