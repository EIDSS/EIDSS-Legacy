using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.common.Core
{
    public interface IMenuAction
    {
        IMenuAction Parent { get; set; }
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
    }
}
