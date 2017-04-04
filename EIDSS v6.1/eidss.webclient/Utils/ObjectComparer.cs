using System;
using System.Collections.Generic;
using bv.model.Model.Core;

namespace eidss.webclient.Utils
{
    class ObjectComparer : IEqualityComparer<IObject>
    {

        public bool Equals(IObject x, IObject y)
        {
            //Check whether the compared objects reference the same data.

            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;


            return x.Key.Equals(y.Key);
        }

        public int GetHashCode(IObject obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            return obj.Key == null ? 0 : obj.Key.GetHashCode();
        }
    }
}