using System.Collections.Generic;
using BLToolkit.EditableObjects;
using bv.model.Model.Core;

namespace bv.model.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListHelper
    {
        public static void ReplaceAndSetChange<T>(this List<T> list, T oldObj, T newObj)
            where T : class, IObject
        {
            if ((oldObj == null) || (newObj == null)) return;
            var i = list.IndexOf(oldObj);
            if (i >= 0)
            {
                newObj.DeepSetChange();
                list.Insert(i, newObj);
                list.RemoveAt(i + 1);
            }
        }

        public static void ReplaceAndSetChange<T>(this EditableList<T> list, T oldObj, T newObj)
            where T : class, IObject
        {
            if ((oldObj == null) || (newObj == null)) return;

            var i = list.IndexOf(oldObj);
            if (i >= 0)
            {
                newObj.DeepSetChange();
                list.Insert(i, newObj);
                list.RemoveAt(i + 1);
            }
        }
    }
}

