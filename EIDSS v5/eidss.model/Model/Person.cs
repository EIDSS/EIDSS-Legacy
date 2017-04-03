using System.Linq;
using BLToolkit.EditableObjects;

namespace eidss.model.Schema
{
    public partial class Person
    {
        public void RefreshObjectAccessListFiltered()
        {
            if (ObjectAccessListFiltered == null) ObjectAccessListFiltered = new EditableList<ObjectAccess>();
            ObjectAccessListFiltered.Clear();
            ObjectAccessListFiltered.AddRange(ObjectAccessList.Where(m => m.idfsSite == idfsOASite).ToList());
        }
    }
}
