using System.Linq;
using BLToolkit.EditableObjects;
using eidss.model.Core;

namespace eidss.model.Schema
{
    public partial class Person
    {
        public void RefreshObjectAccessListFiltered()
        {
            if (ObjectAccessListFiltered == null) ObjectAccessListFiltered = new EditableList<ObjectAccess>();
            ObjectAccessListFiltered.Clear();
            ObjectAccessListFiltered.AddRange(ObjectAccessList.Where(m => m.idfsSite == EidssSiteContext.Instance.PermissionSiteID).ToList());
        }
    }
}
