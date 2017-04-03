using System.Collections.Generic;
using bv.common.Resources;

namespace bv.common.Core
{
    public class MenuActionBase : IMenuAction
    {
        private List<IMenuAction> m_Items;
        private string m_Caption;

        public MenuActionBase(IMenuActionManager manager, IMenuAction parent, string resourceKey, int order, bool showInToolbar)
        {
            ResourceKey = resourceKey;
            ShowInToolbar = showInToolbar;
            ShowInMenu = true;
            Order = order;
            if (manager != null)
            {
                manager.RegisterAction(this, parent);
            }
        }

        public IMenuAction Parent { get; set; }
        public string SelectPermission { get; set; }
        public string ActionUrl { get;  set; }

        public List<IMenuAction> Items
        {
            get { return m_Items ?? (m_Items = new List<IMenuAction>()); }
        }

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
                if (Manager != null && Manager.ItemsStorage != null)
                {
                    return Manager.ItemsStorage.GetString(ResourceKey);
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
        public bool BeginGroup { get; set; }
        public bool ShowInMenu { get; set; }
        public IMenuActionManager Manager { get; set; }
        public int Order { get; set; }
        public BaseStringsStorage ItemsStorage { get; set; }

        public virtual bool IsCategory
        {
            get { return m_Items != null && m_Items.Count > 0; }
        }
    }
}