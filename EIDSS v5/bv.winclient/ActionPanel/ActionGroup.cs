using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using bv.common.Resources.Images;
using bv.model.Model.Core;
using DevExpress.XtraBars;

namespace bv.winclient.ActionPanel
{
    public partial class ActionGroup : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ActionGroup()
        {
            InitializeComponent();
            InitRoutines(null);
        }

        internal ActionPanel ParentActionPanel { get; private set; }

        private List<ActionMetaItem> m_ActionsList;

        /// <summary>
        /// Действия, которые располагаются в этой группе
        /// </summary>
        private List<ActionMetaItem> Actions
        {
            get { return m_ActionsList ?? (m_ActionsList = new List<ActionMetaItem>()); }
            set{m_ActionsList = value;}
        }

        /// <summary>
        /// 
        /// </summary>
        private IObject BusinessObject { get; set; }

        private IObjectPermissions Permissions { get { return BusinessObject != null ? BusinessObject.GetAccessor() as IObjectPermissions : null; } }

        /// <summary>
        /// 
        /// </summary>
        public ActionGroup(IObject bo, List<ActionMetaItem> actions, ActionPanel parentActionPanel)
        {
            InitializeComponent();
            BusinessObject = bo;
            ParentActionPanel = parentActionPanel;
            InitRoutines(actions);
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// <param name="action"></param>
        /// <param name="needAddAction"></param>
        public void AddAction(ActionMetaItem action, bool needAddAction)
        {
            int index = Actions.Count;
            //TODO доставать настоящий заголовок
            var button = new BarButtonItem(barManager, action.CaptionId(BusinessObject, Permissions)) { Id = index, Tag = action};
            var image = ImagesStorage.Get(action.IconId(BusinessObject, Permissions));
            if (image != null)
            {
                imageCollection.AddImage(image);
                button.ImageIndex = imageCollection.Images.Count - 1;
            }
            
            button.ItemClick += OnButtonItemClick;
            //popupActions.LinksPersistInfo.Add(new LinkPersistInfo(button));
            popupActions.ItemLinks.Add(button);
            barManager.Items.Add(button);
            barManager.MaxItemId = index + 1;

            if (needAddAction) Actions.Add(action);

            //TODO правильно ли следующее
            if ((Tag == null) && (Actions.Count >= 1))
            {
                Tag = Actions[0];
                //кнопке приписываем название группы
                //TODO получать настоящее название группы
                buttonMain.Text = Actions[0].Container;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonMainMouseDown(object sender, MouseEventArgs e)
        {
            var point = GetAbsoluteCoords((Control)sender);
            popupActions.ShowPopup(barManager, new Point(point.X + e.X, point.Y + e.Y + 20)); //величина заголовка формы
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private Point GetAbsoluteCoords(Control control)
        {
            Point result = control.Location;
            if (control.Parent != null)
            {
                var point = GetAbsoluteCoords(control.Parent);
                result = new Point(result.X + point.X, result.Y + point.Y);
            }
            return result;
        }
    }
}
