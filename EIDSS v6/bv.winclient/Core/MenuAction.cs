using System;
using bv.common.Core;
namespace bv.winclient.Core
{

    public class MenuAction:MenuActionBase
    {
      
        public delegate void Handler();
        public delegate void ActionHandler(MenuAction action);
        public DevExpress.XtraBars.BarItem MenuItem { get; set; }
        public DevExpress.XtraBars.BarLargeButtonItem ToolbarItem { get; set; }
        public override bool IsCategory { get { return base.IsCategory || (Activate == null && ActivateAction == null); } }
        private class ActionProxy
        {

            public Handler m_RealHandler;
            public ActionHandler m_RealActionHandler;
            protected internal MenuAction m_Action;
            public void Handle(object sender, EventArgs args)
            {
                if (m_RealHandler != null && MenuActionManager.Instance.LockActions())
                {
                    try
                    {
                        m_RealHandler();
                    }
                    finally
                    {
                        MenuActionManager.Instance.UnlockActions();
                    }
                }
                else if (m_RealActionHandler != null && MenuActionManager.Instance.LockActions())
                {
                    try
                    {
                        m_RealActionHandler(m_Action);
                    }
                    finally
                    {
                        MenuActionManager.Instance.UnlockActions();
                    }

                }
            }
            public void ItemClickHandler(object sender, DevExpress.XtraBars.ItemClickEventArgs args)
            {
                if (m_RealHandler != null && MenuActionManager.Instance.LockActions())
                {
                    try
                    {
                        m_RealHandler();
                    }
                    finally
                    {
                        MenuActionManager.Instance.UnlockActions();
                    }
                }
                else if (m_RealActionHandler != null && MenuActionManager.Instance.LockActions())
                {
                    try
                    {
                        m_RealActionHandler(m_Action);
                    }
                    finally
                    {
                        MenuActionManager.Instance.UnlockActions();
                    }
                }
            }
        }

        readonly ActionProxy m_Proxy = new ActionProxy();

        public EventHandler Click
        {
            get
            {
                return m_Proxy.Handle;
            }
        }
        public DevExpress.XtraBars.ItemClickEventHandler BarClick
        {
            get
            {
                return m_Proxy.ItemClickHandler;
            }
        }

        public Handler Activate
        {
            get
            {
                return m_Proxy.m_RealHandler;
            }
            set
            {
                m_Proxy.m_RealHandler = value;
            }
        }
        public ActionHandler ActivateAction
        {
            get
            {
                return m_Proxy.m_RealActionHandler;
            }
            set
            {
                m_Proxy.m_RealActionHandler = value;
            }
        }
        private void BaseInit(int smallImageIndex, int bigImageIndex)
        {
            SmallIconIndex = smallImageIndex;
            m_Proxy.m_Action = this;
            BigIconIndex = bigImageIndex;
            ShowInMenu = true;
        }
        public MenuAction(Handler actionHandler, MenuActionManager manager, IMenuAction parent, string resourceKey, int order, bool showInToolbar = false, int smallImageIndex = -1, int bigImageIndex = -1):
            base(manager, parent, resourceKey,order,showInToolbar)
        {
            SelectPermission = "Always";
            BaseInit(smallImageIndex, bigImageIndex);
            Activate = actionHandler;
            ActivateAction = null;
        }
        public MenuAction(ActionHandler actionHandler, MenuActionManager manager, IMenuAction parent, string resourceKey, int order, bool showInToolbar = false, int smallImageIndex = -1, int bigImageIndex = -1) :
            base(manager, parent, resourceKey, order, showInToolbar)
        {
            SelectPermission = "Always";
            BaseInit(smallImageIndex, bigImageIndex);
            Activate = null;
            ActivateAction = actionHandler;
        }

        public MenuAction(MenuActionManager manager, IMenuAction parent, string resourceKey, int order, bool showInToolbar = false, int smallImageIndex = -1, int bigImageIndex = -1) :
            base(manager, parent, resourceKey, order, showInToolbar)
        {
            SelectPermission = "Always";
            BaseInit(smallImageIndex, bigImageIndex);
            Activate = null;
            ActivateAction = null;
        }
    }
}
