using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.ActionPanel;
using bv.winclient.BasePanel;
using System.ComponentModel;
using bv.winclient.Core;

namespace bv.winclient.Layout
{
    public partial class LayoutEmpty : BvXtraUserControl, ILayout
    {
        /// <summary>
        /// 
        /// </summary>
        public LayoutEmpty()
        {
            InitializeComponent();
            LastExecutedAction = null;
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessObject"></param>
        public LayoutEmpty(IObject businessObject)
        {
            InitializeComponent();
            BusinessObject = businessObject;
            LastExecutedAction = null;
        }

        /// <summary>
        /// Делегат для передачи входных параметров действия от БО, находящегося на BasePanel, к действиям на ActionPanel
        /// </summary>
        /// <returns></returns>
        public delegate List<object> ParamsAction();

        /// <summary>
        /// 
        /// </summary>
        public IObject BusinessObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Init(IBasePanel basePanel)
        {
            //TODO придумать куда его поместить, чтобы принудительно этот метод не надо было вызывать
            ParentBasePanel = basePanel;
            //изначально контейнеры для ActionPanel не видны; они отображаются только в момент добавления соответствующих ActionPanel
            //panelBottom.Visible = false;
            //создаём панели
            CreateActionPanels();
        }

        /// <summary>
        /// Ссылка на BasePanel, которая лежит в данном Layout
        /// </summary>
        public IBasePanel ParentBasePanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CreateActionPanels()
        {
            var actions = new List<ActionMetaItem>();
            if (BusinessObject != null)
            {
                //получаем действия из объекта
                var meta = (IObjectMeta)BusinessObject.GetAccessor();
                meta.Actions.ForEach(a => actions.Add(new ActionMetaItem(a)));
            }
            //определяем, есть ли дополнительные действия, определённые в самой BasePanel
            if (ParentBasePanel != null)
            {
                //собираем действия, которые требуется добавить к базовым
                ParentBasePanel.SetCustomActions(actions);
                foreach (var act in ParentBasePanel.CustomActions)
                {
                    if (actions.All(a => a.Name != act.Name)) actions.Add(act);
                }
            }
            
            //добавляем действия
            AddActions(actions);
        }

        private readonly List<ActionMetaItem> m_Actions = new List<ActionMetaItem>();
        public List<ActionMetaItem> Actions 
        { 
            get { return m_Actions; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public virtual void AddActions(List<ActionMetaItem> actions)
        {
            if (actions != null) m_Actions.AddRange(actions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePanel"></param>
        /// <param name="bo"></param>
        public void AddActions(IBasePanel basePanel, IObject bo)
        {
            //ObjectAccessor.MetaInterface(typeBO);
            var objectMeta = ObjectAccessor.MetaInterface(bo.GetType());

            if (objectMeta != null)
            {
                var layout = basePanel.GetLayout();
                if (layout != null) layout.AddActions(objectMeta.Actions);
            }
        }

        /// <summary>
        /// Последнее выполненное действие
        /// </summary>
        public ActionMetaItem LastExecutedAction { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePanel"></param>
        /// <param name="id"></param>
        public void AddActions(IBasePanel basePanel, object id)
        {
            IObject bo;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var objectSelectDetail = ObjectAccessor.SelectDetailInterface(basePanel.GetBusinessObjectType());
                bo = objectSelectDetail.SelectDetail(manager, id); //в случае нового объекта он будет создан тут
            }

            AddActions(basePanel, bo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionPanelControl"></param>
        /// <param name="position"></param>
        public virtual void AddActionPanel(Control actionPanelControl, ActionPanelPosition position)
        {
            var actionPanel = (BaseActionPanel)actionPanelControl;
            actionPanel.OnLastExecutedActionChanged += OnLastExecutedActionChanged;
            actionPanel.OnBeforeActionExecuting += OnBeforeActionExecutingRaised;
            actionPanel.OnAfterActionExecuted += OnAfterActionExecutedRaised;
        }

        /// <summary>
        /// Добавление произвольного контрола на указанную панель
        /// </summary>
        /// <param name="control"></param>
        /// <param name="panelType"></param>
        public virtual void AddCustomControlToActionPanel(Control control, ActionsPanelType panelType)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        internal void OnAfterActionExecutedRaised(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            if (OnAfterActionExecuted != null) OnAfterActionExecuted(panel, action, bo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        /// <param name="cancel"></param>
        internal void OnBeforeActionExecutingRaised(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            if (OnBeforeActionExecuting != null) OnBeforeActionExecuting(panel, action, bo, ref cancel);
        }

        public event BaseActionPanel.BeforeActionExecutingDelegate OnBeforeActionExecuting;
        public event BaseActionPanel.AfterActionExecutedDelegate OnAfterActionExecuted;

        /// <summary>
        /// Последнее действие, выполненное на любой панели, располагающейся на этом Layout
        /// </summary>
        /// <param name="result"></param>
        void OnLastExecutedActionChanged(ActionMetaItem result)
        {
            LastExecutedAction = result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public virtual void AddControlToMainContainer(Control control)
        {

        }
        public virtual void PerformAction(string actionMame, List<object> parameters)
        {

        }

        public virtual void UpdateActionsState()
        {
        }

        [Browsable(true), DefaultValue(true), Localizable(false)]
        public virtual bool SearchPanelVisible
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }
        public virtual void RefreshActionButtons(bool forceReadOnly = false)
        {

        }

        public virtual bool ShowCaption { get; set; }
    }
}
