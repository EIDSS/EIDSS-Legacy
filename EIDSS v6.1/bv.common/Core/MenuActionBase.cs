using System.Collections.Generic;
using bv.common.Resources;

namespace bv.common.Core
{
    public class MenuActionBase : IMenuAction
    {
        public MenuActionBase(IMenuActionManager manager, IMenuAction parent, string resourceKey, int order,
                              bool showInToolbar)
        {
            ResourceKey = resourceKey;
            ShowInToolbar = showInToolbar;
            ShowInMenu = true;
            Order = order;
            Group = 0;
            if (manager != null)
            {
                manager.RegisterAction(this, parent);
            }
        }

        public int SmallIconIndex { get; set; }
        public int BigIconIndex { get; set; }
        public int Group { get; set; }
        public IMenuAction Parent { get; set; }
        public string SelectPermission { get; set; }
        public string ActionUrl { get; set; }

        private List<IMenuAction> m_Items;

        public IMenuAction Category
        {
            get
            {
                if (IsCategory)
                    return null;
                var parent = Parent;
                while (parent != null)
                {
                    if (parent.IsCategory)
                        return parent;
                    parent = parent.Parent;
                }
                return null;
            }
        }

        public List<IMenuAction> Items
        {
            get { return m_Items ?? (m_Items = new List<IMenuAction>()); }
        }

        private string m_Caption;

        public string Caption
        {
            get
            {
                if (Utils.Str(m_Caption) != "")
                {
                    return m_Caption;
                }
                if (ItemsStorage != null)
                {
                    return ItemsStorage.GetString(ResourceKey);
                }
                return ResourceKey;
            }
            set { m_Caption = value; }
        }

        public string Shortcut { get; set; }
        public string ResourceKey { get; set; }
        public string Name { get; set; }
        public bool ShowInToolbar { get; set; }
        public bool IsCheckBoxAction { get; set; }

        public virtual bool IsCategory
        {
            get { return m_Items != null && m_Items.Count > 0; }
        }

        public bool BeginGroup { get; set; }
        public bool ShowInMenu { get; set; }
        public IMenuActionManager Manager { get; set; }
        public int Order { get; set; }
        private BaseStringsStorage m_ItemsStorage;
        public BaseStringsStorage ItemsStorage
        {
            get { return m_ItemsStorage ?? (Manager != null ? Manager.ItemsStorage : null); }
            set { m_ItemsStorage = value; }
        }
    }
}
