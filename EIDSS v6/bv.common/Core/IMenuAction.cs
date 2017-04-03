using System.Collections.Generic;

namespace bv.common.Core
{
    public interface IMenuAction
    {
        IMenuAction Parent { get; set; }
        IMenuAction Category { get; }
        List<IMenuAction> Items { get; }
        string Caption { get; set; }
        string Shortcut { get; set; }
        string ResourceKey { get; set; }
        string Name { get; set; }
        string SelectPermission { get; set; }
        string ActionUrl { get; }
        bool ShowInToolbar { get; set; }
        bool IsCheckBoxAction { get; set; }
        bool BeginGroup { get; set; }
        bool ShowInMenu { get; set; }
        bool IsCategory { get; }
        int Order { get; set; }

        IMenuActionManager Manager { get; set; }

        int SmallIconIndex { get; set; }
        int BigIconIndex { get; set; }
        int Group { get; set; }
    }
}