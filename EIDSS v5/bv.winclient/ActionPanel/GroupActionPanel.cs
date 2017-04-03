using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Layout;
using bv.winclient.BasePanel;

namespace bv.winclient.ActionPanel
{
    public partial class GroupActionPanel : ActionPanel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessObject"></param>
        /// <param name="layout">layout, на котором располагается панель</param>
        public GroupActionPanel(IObject businessObject, LayoutGroup layout) : base(businessObject, layout)
        {
            BusinessObject = businessObject;
            ParentLayout = layout;

            InitializeComponent();

            ////пробуем подписаться на нужные события BasePanel
            //if (BaseGridPanel != null)
            //{
            //    BaseGridPanel.FocusedItemChanged += OnBaseListPanelFocusedItemChanged;
            //}
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
                if (action != null)
                {
                    button.Enabled = action.IsEnable(e.FocusedItem, Permissions);
                }
            }
            //var buttonDelete = GetButtonAction(ActionTypes.Delete);
            //var buttonEdit = GetButtonAction(ActionTypes.Edit);
            //if (buttonDelete != null) buttonDelete.Enabled = e.FocusedItem != null;
            //if (buttonEdit != null) buttonEdit.Enabled = e.FocusedItem != null;
        }

        /// <summary>
        /// Вычисляем положение кнопок на панели
        /// </summary>
        protected override void RecalculateActionsPositions()
        {
            if (m_Buttons == null)
                return;
            //размещение слева направо, сверху вниз, согласно порядковым номерам кнопок
            var top = (Height - m_ButtonHeight) / 2;
            const int margin = 5;
            var leftEdge = 0;
            var rightEdge = Width;

            //формируем единую коллекцию для всех элементов, участвующих в рендеринге действий

            var actionControls = new List<Control>();
            actionControls.AddRange(m_Buttons);

            for (var i = actionControls.Count - 1; i >= 0; i--)
            {
                var actionControl = actionControls[i];
                var action = (ActionMetaItem)actionControl.Tag;
                if (action.Alignment.Equals(ActionsAlignment.Left))
                {
                    actionControl.Location = new Point(leftEdge + margin, top);
                    leftEdge += actionControl.Width + margin;
                }
                else if (action.Alignment.Equals(ActionsAlignment.Right))
                {
                    actionControl.Location = new Point(rightEdge - margin - actionControl.Width, top);
                    rightEdge -= actionControl.Width + margin;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public override bool IsActionVisible(ActionMetaItem action)
        {
            if (!action.IsVisible(BusinessObject, Permissions)) return false;
            switch (action.ActionType)
            {
                case ActionTypes.Create:
                   return !(BaseGridPanel != null && BaseGridPanel.InlineMode == InlineMode.UseNewRow);
                case ActionTypes.Edit:
                   return (BaseGridPanel != null && BaseGridPanel.InlineMode == InlineMode.None);
                default:
                    return base.IsActionVisible(action);
            }
        }

    }
}
