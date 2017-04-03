using System;
using System.Collections.Generic;
using System.Linq;
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
                //newObj.Environment = oldObj.Environment;
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
                //newObj.Environment = oldObj.Environment;
                list.Insert(i, newObj);
                list.RemoveAt(i + 1);
            }
        }

        public static void DeepAcceptChanges<T>(this EditableList<T> list)
            where T : class, IObject
        {
            list.AcceptChanges();
            foreach (var item in list)
            {
                item.DeepAcceptChanges();
            }
        }
        public static void DeepRejectChanges<T>(this EditableList<T> list)
            where T : class, IObject
        {
            list.RejectChanges();
            foreach (var item in list)
            {
                item.DeepRejectChanges();
            }
        }

        public static TRet SingleOrDefault<TSource, TRet>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TRet> value)
        {
            var o = source.SingleOrDefault(predicate);
            return o == null ? default(TRet) : value(o);
        }

        public static TRet FirstOrDefault<TSource, TRet>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TRet> value)
        {
            var o = source.FirstOrDefault(predicate);
            return o == null ? default(TRet) : value(o);
        }

    }
}

