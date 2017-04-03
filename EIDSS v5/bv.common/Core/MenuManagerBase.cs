using System.Collections.Generic;
using bv.common.Resources;

namespace bv.common.Core
{
    public class MenuManagerBase : IMenuActionManager
    {
        public List<IMenuAction> MenuItems { get; protected set; }
        protected static int m_ItemOrder = 1;
        public IMenuAction RegisterAction(IMenuAction a, IMenuAction parent = null)
        {
            a.Manager = this;
            if (parent != null)
                a.Parent = parent;
            if (a.Order == 0)
            {
                m_ItemOrder++;
                a.Order = m_ItemOrder;
            }
            else
            {
                m_ItemOrder = a.Order;
            }
            if (a.Parent == null)
            {
                MenuItems.Add(a);
            }
            else
            {
                a.Parent.Items.Add(a);
            }
            return a;
        }

        public void PrepareActions()
        {
            SortActions(MenuItems);
        }

        public BaseStringsStorage ItemsStorage { get; set; }

        protected readonly ActionLocker m_ActionLocker = new ActionLocker();

        protected class MenuActionComparer : IComparer<IMenuAction>
        {
            public int Compare(IMenuAction x, IMenuAction y)
            {
                return x.Order - y.Order;
            }
        }
        protected static void SortActions(List<IMenuAction> actions)
        {
            actions.Sort(new MenuActionComparer());
            foreach (IMenuAction a in actions)
            {
                if (a.Items != null && a.Items.Count > 0)
                {
                    SortActions(a.Items);
                }
            }
        }
        protected IMenuAction FindAction(IEnumerable<IMenuAction> actions, string resourceKey)
        {
            if (actions == null)
            {
                return null;
            }
            foreach (IMenuAction action in actions)
            {
                if (string.IsNullOrEmpty(action.ResourceKey))
                {
                    if (resourceKey == action.Caption)
                    {
                        return action;
                    }
                }
                else if (resourceKey == action.ResourceKey)
                {
                    return action;
                }
                IMenuAction found = FindAction(action.Items, resourceKey);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }
        public IMenuAction FindAction(string resourceKey)
        {
            return FindAction(MenuItems, resourceKey);
        }

        protected IMenuAction m_File;

        public IMenuAction File
        {
            get { return m_File; }
        }

        protected IMenuAction m_Edit;

        public IMenuAction Edit
        {
            get { return m_Edit; }
        }

        protected IMenuAction m_Journals;

        public IMenuAction Journals
        {
            get { return m_Journals; }
        }

        protected IMenuAction m_View;

        public IMenuAction View
        {
            get { return m_View; }
        }

        protected IMenuAction m_Operations;

        public IMenuAction Operations
        {
            get { return m_Operations; }
        }

        protected IMenuAction m_Create;

        public IMenuAction Create
        {
            get { return m_Create; }
        }

        protected IMenuAction m_Search;

        public IMenuAction Search
        {
            get { return m_Search; }
        }

        protected IMenuAction m_Reports;

        public IMenuAction Reports
        {
            get { return m_Reports; }
        }

        protected IMenuAction m_Maps;

        public IMenuAction Maps
        {
            get { return m_Maps; }
        }

        protected IMenuAction m_Documents;

        public IMenuAction Documents
        {
            get { return m_Documents; }
        }

        protected IMenuAction m_Options;

        public IMenuAction Options
        {
            get { return m_Options; }
        }

        protected IMenuAction m_System;

        public IMenuAction System
        {
            get { return m_System; }
        }

        protected IMenuAction m_Security;

        public IMenuAction Security
        {
            get { return m_Security; }
        }

        protected IMenuAction m_Window;

        public IMenuAction Window
        {
            get { return m_Window; }
        }

        protected IMenuAction m_Help;

        public IMenuAction Help
        {
            get { return m_Help; }
        }
        protected IMenuAction m_DataExport;

        public IMenuAction DataExport
        {
            get { return m_DataExport; }
        }

        protected IMenuAction m_Avr;
        public IMenuAction AVR
        {
            get { return m_Avr; }
        }

    }
}
