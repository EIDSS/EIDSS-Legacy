using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Layout;

namespace bv.winclient.ActionPanel
{
    public partial class ActionPanel : BaseActionPanel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessObject"></param>
        /// <param name="layout">layout, на котором располагается панель</param>
        public ActionPanel(IObject businessObject, LayoutEmpty layout)
        {
            m_ActionGroups = new Dictionary<string, DropDownActionHelper>();
            BusinessObject = businessObject;
            ParentLayout = layout;

            InitializeComponent();

            //пробуем подписаться на нужные события BasePanel
            if (BaseGridPanel != null)
            {
                BaseGridPanel.FocusedItemChanged += OnBaseListPanelFocusedItemChanged;
                BaseGridPanel.SelectedItemsChanged += OnBaseListPanelSelectedItemsChanged;
            }
        }

        private void OnBaseListPanelSelectedItemsChanged(object sender, SelectedItemsChangedEventArgs<IObject> e)
        {
            foreach (var button in m_Buttons)
            {
                if (BaseGridPanel != null)
                {
                    BaseGridPanel.RaiseActionButtonStateChangedEvent(button, e.FocusedItem, e.SelectedItems);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnBaseListPanelFocusedItemChanged(object sender, FocusedItemChangedEventArgs<IObject> e)
        {
            //TODO может быть перенести в базовый класс
            foreach (var button in m_Buttons)
            {
                var action = button.Tag as ActionMetaItem;
                if(action!=null)
                {
                    button.Enabled = action.IsEnable(e.FocusedItem, Permissions);
                }
                BaseGridPanel.RaiseActionButtonStateChangedEvent(button, e.FocusedItem, null);
            }
            //var buttonDelete = GetButtonAction(ActionTypes.Delete);
            //var buttonEdit = GetButtonAction(ActionTypes.Edit);
            //if (buttonDelete != null) buttonDelete.Enabled = e.FocusedItem != null;
            //if (buttonEdit != null) buttonEdit.Enabled = e.FocusedItem != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public override Control AddAction(ActionMetaItem action)
        {
            var actionControl = base.AddAction(action);
            //если это действие принадлежит группе, то добавляем его в группу
            if ((actionControl == null) && (!string.IsNullOrEmpty(action.Container)) || action.ActionType == ActionTypes.Container)
            {
                //иначе отыскиваем или создаём группу и помещаем туда это действие

                #region Добавление действия в группу

                var actionGroup = GetActionGroup(action.ActionType == ActionTypes.Container ? action.Name : action.Container);
                actionGroup.AddAction(action, true);
                SetControlWidth(actionGroup.Button);
                actionControl = actionGroup.Button;

                #endregion

                if (!Controls.Contains(actionControl))
                    Controls.Add(actionControl);
            }

            return actionControl;
        }

        /// <summary>
        /// Отыскивает или создаёт группу действий
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public DropDownActionHelper GetActionGroup(string groupCode)
        {
            DropDownActionHelper actionGroup;
            if (m_ActionGroups.ContainsKey(groupCode))
            {
                actionGroup = m_ActionGroups[groupCode];
            }
            else
            {
                actionGroup = new DropDownActionHelper(BusinessObject, null, this);
                m_ActionGroups.Add(groupCode, actionGroup);
                m_Buttons.Add(actionGroup.Button); 
                SetControlWidth(actionGroup.Button);
            }

            return actionGroup;
        }

        private bool updateLayout = false;
        /// <summary>
        /// Вычисляем положение кнопок на панели
        /// </summary>
        protected override void RecalculateActionsPositions()
        {
            if (updateLayout)
                return;
            if (m_Buttons == null || m_Buttons.Count ==0 || Parent == null)
                return;
            var findForm = FindForm();
            if (findForm != null && findForm.WindowState == FormWindowState.Minimized)
                return;
            updateLayout = true;
            SuspendLayout();
            //размещение слева направо, сверху вниз, согласно порядковым номерам кнопок
            const int margin = 4;
            int top = margin;// (Height - m_ButtonHeight) / 2;
            int leftEdge = 0;
            int rightEdge = Width;
            int hDelta = Parent.Height - Height;
            //формируем единую коллекцию для всех элементов, участвующих в рендеринге действий

            var actionControls = new List<Control>();
            actionControls.AddRange(m_Buttons);
            //foreach (var group in m_ActionGroups)
            //    actionControls.Add(group.Value.Button);
            m_ButtonHeight = m_Buttons[0].Height;
            for (int i = actionControls.Count - 1; i >= 0; i--)
            {
                var actionControl = actionControls[i];
                var action = (ActionMetaItem)actionControl.Tag;
                if (action.Alignment.Equals(ActionsAlignment.Left))
                {
                    actionControl.Location = new Point(leftEdge + margin, top);
                    leftEdge += actionControl.Width + margin;
                }
            }
            for (int i = actionControls.Count - 1; i >= 0; i--)
            {
                var actionControl = actionControls[i];
                var action = (ActionMetaItem)actionControl.Tag;
                if (action.Alignment.Equals(ActionsAlignment.Right))
                {
                    rightEdge -= actionControl.Width + margin;
                    if(rightEdge<leftEdge + margin)
                    {
                        rightEdge = Width - actionControl.Width - margin;
                        top += m_ButtonHeight + margin;
                        if (Parent.Height != (top + m_ButtonHeight + margin + hDelta ))
                        {
                            Parent.Height = top + m_ButtonHeight + margin + hDelta ;
                            Height = Parent.Height;
                        }
                    }

                    actionControl.Location = new Point(rightEdge, top);
                }
            }
            if (Parent.Height != (top + m_ButtonHeight + margin + hDelta))
            {
                Parent.Height = top + m_ButtonHeight + margin + hDelta;
                Height = Parent.Height;
            }
            ResumeLayout();
            updateLayout = false;
        }

        private readonly Dictionary<string, DropDownActionHelper> m_ActionGroups;
    }
}
