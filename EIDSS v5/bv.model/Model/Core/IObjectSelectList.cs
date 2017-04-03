using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;

namespace bv.model.Model.Core
{
    public interface IObjectSelectList
    {
        List<IObject> SelectList(DbManagerProxy manager
            , FilterParams filters = null
            , KeyValuePair<string, ListSortDirection>[] sorts = null
            , bool serverSort = false
            );
        long? SelectCount(DbManagerProxy manager);
    }
}
