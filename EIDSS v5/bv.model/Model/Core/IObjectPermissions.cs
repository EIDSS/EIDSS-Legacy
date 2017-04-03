using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public interface IObjectPermissions
    {
        bool CanSelect { get; }
        bool CanUpdate { get; }
        bool CanDelete { get; }
        bool CanInsert { get; }
        bool CanExecute(string action);
        bool IsReadOnlyForEdit { get; }
    }
}
