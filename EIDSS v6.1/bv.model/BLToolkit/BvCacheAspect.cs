using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using bv.model.Model.Core;
using BLToolkit.Aspects;
using BLToolkit.Common;
using System.Web;

namespace bv.model.BLToolkit
{
    public interface ILookupUsage
    {
        void ReloadLookupItem(DbManagerProxy manager, string lookup_object);
    }

    public static class LookupManager
    {
        private static Dictionary<string, List<WeakReference>> g_LookupUsages = new Dictionary<string, List<WeakReference>>();
        private static Dictionary<string, KeyValuePair<MethodInfo, MethodInfo>> g_Lookups = new Dictionary<string, KeyValuePair<MethodInfo, MethodInfo>>();
        private static Dictionary<string, Dictionary<string, string>> g_LookupTables = new Dictionary<string, Dictionary<string, string>>();
        private static Dictionary<string, string> g_LookupsToClear = new Dictionary<string, string>();
        private const string rftPrefix = "rft";
        private const string rftObject = "BaseReference";

        public static void AddObject(string lookup_object, object o, Type lookup, string method,
            string base_method = null)
        {
            lock(g_Lookups)
            {
                if (!g_Lookups.ContainsKey(lookup_object))
                {
                    if (base_method != null)
                    {
                        g_Lookups.Add(lookup_object, new KeyValuePair<MethodInfo, MethodInfo>(lookup.GetMethod(method), lookup.GetMethod(base_method)));
                    }
                    else
                    {
                        g_Lookups.Add(lookup_object, new KeyValuePair<MethodInfo, MethodInfo>(lookup.GetMethod(method), null));
                    }

                    MethodInfo mi = lookup.BaseType.GetMethod("GetLookupTableName", BindingFlags.Public | BindingFlags.Static);
                    if (mi != null)
                    {
                        string table = mi.Invoke(null, new object[] { method }) as string;
                        lock (g_LookupTables)
                        {
                            if (!g_LookupTables.ContainsKey(table))
                            {
                                g_LookupTables.Add(table, new Dictionary<string, string>());
                                g_LookupTables[table].Add(lookup_object, lookup_object);
                            }
                            else
                            {
                                if (!g_LookupTables[table].ContainsKey(lookup_object))
                                    g_LookupTables[table].Add(lookup_object, lookup_object);
                            }
                        }
                    }
                }
            }

            if (lookup_object.StartsWith(rftPrefix) && lookup_object != rftPrefix)
            {
                AddObject(rftPrefix, null, lookup, base_method, null);
            }

            if (o != null)
            {
                lock (g_LookupUsages)
                {
                    List<WeakReference> list = null;
                    if (!g_LookupUsages.ContainsKey(lookup_object))
                    {
                        g_LookupUsages.Add(lookup_object, new List<WeakReference>());
                    }
                    list = g_LookupUsages[lookup_object];
                    WeakReference w = list.Find(c => c.IsAlive && ReferenceEquals(c.Target, o));
                    if (w == null)
                    {
                        list.Add(new WeakReference(o));
                    }
                }
            }
        }

        public static void RemoveObject(string lookup_object, object o)
        {
            lock (g_LookupUsages)
            {
                try
                {
                    List<WeakReference> list = null;
                    if (g_LookupUsages.ContainsKey(lookup_object))
                    {
                        list = g_LookupUsages[lookup_object];
                        WeakReference w = list.Find(c => /*c.IsAlive &&*/ ReferenceEquals(c.Target, o));
                        while (w != null)
                        {
                            list.Remove(w);
                            w = list.Find(c => /*c.IsAlive &&*/ ReferenceEquals(c.Target, o));
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public static void ClearByTable(string lookup_table)
        {
            Dictionary<string, string> lookup_objects = null;
            lock (g_LookupTables)
            {
                if (g_LookupTables.ContainsKey(lookup_table))
                {
                    lookup_objects = new Dictionary<string, string>(g_LookupTables[lookup_table]);
                }
                else if (lookup_table.StartsWith(rftPrefix))
                {
                    if (g_LookupTables.ContainsKey(rftObject))
                    {
                        lookup_objects = new Dictionary<string, string>(g_LookupTables[rftObject]);
                    }
                }
            }
            if (lookup_objects != null)
            {
                /*
                lock (g_Lookups)
                {
                    if (g_Lookups.ContainsKey(lookup_object))
                    {
                        CacheAspect.ClearAllCache(g_Lookups[lookup_object].Key);
                        if (g_Lookups[lookup_object].Value != null)
                            CacheAspect.ClearAllCache(g_Lookups[lookup_object].Value);
                    }
                }
                */
                /*using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    ClearAndReload(manager, lookup_object);
                }*/
                foreach (string lookup_object in lookup_objects.Keys)
                {
                    if (HttpContext.Current != null)
                    {
                        ThreadPool.QueueUserWorkItem(o =>
                                                         {
                                                             string obj = (string) o;
                                                             using (
                                                                 DbManagerProxy manager =
                                                                     DbManagerFactory.Factory.Create(
                                                                         ModelUserContext.Instance))
                                                             {
                                                                 ClearAndReload(manager, obj);
                                                             }
                                                         }, lookup_object
                            );
                    }
                    else
                    {
                        lock (g_LookupsToClear)
                        {
                            if (!g_LookupsToClear.ContainsKey(lookup_object))
                            {
                                g_LookupsToClear.Add(lookup_object, lookup_object);
                            }
                        }
                    }
                }
            }
        }

        public static void ClearAndReloadOnIdle()
        {
            lock(g_LookupsToClear)
            {
                if (g_LookupsToClear.Count > 0)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        foreach (var obj in g_LookupsToClear.Keys)
                        {
                            ClearAndReload(manager, obj);
                        }
                    }
                    g_LookupsToClear.Clear();
                }
            }
        }

        public static void ClearAndReload(DbManagerProxy manager, string lookup_object)
        {
            lock(g_Lookups)
            {
                if (g_Lookups.ContainsKey(lookup_object))
                {
                    CacheAspect.ClearAllCache(g_Lookups[lookup_object].Key);
                    if (g_Lookups[lookup_object].Value != null)
                    {
                        CacheAspect.ClearAllCache(g_Lookups[lookup_object].Value);
                    }
                }
            }
            lock (g_LookupUsages)
            {
                if (g_LookupUsages.ContainsKey(lookup_object))
                {
                    var list = g_LookupUsages[lookup_object];
                    foreach(var w in list)
                    {
                        if (w.IsAlive)
                        {
                            var icu = w.Target as ILookupUsage;
                            if (icu != null)
                            {
                                try
                                {
                                    icu.ReloadLookupItem(manager, lookup_object);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Clear(DbManagerProxy manager, string lookup_object)
        {
            lock (g_Lookups)
            {
                if (g_Lookups.ContainsKey(lookup_object))
                {
                    CacheAspect.ClearAllCache(g_Lookups[lookup_object].Key);
                    if (g_Lookups[lookup_object].Value != null)
                    {
                        CacheAspect.ClearAllCache(g_Lookups[lookup_object].Value);
                    }
                }
            }
        }
        public static void ClearAndReload(string[] lookup_objects)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                foreach (var obj in lookup_objects)
                {
                    ClearAndReload(manager, obj);
                }
            }
        }
        public static void ClearAndReload(string lookup_object)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                ClearAndReload(manager, lookup_object);
            }
        }
        public static void Clear(string lookup_object)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Clear(manager, lookup_object);
            }
        }
    }

    public class BvCacheAspect : CacheAspect
    {
        public BvCacheAspect()
            : base()
        {
        }

        protected override CompoundValue GetKey(InterceptCallInfo info)
        {
            var ret = base.GetKey(info);
            object[] keyValues = new object[ret.Count + 1];
            for(int i = 0; i < ret.Count; i++)
            {
                keyValues[i] = ret[i];
            }
            keyValues[ret.Count] = ModelUserContext.CurrentLanguage;
            return new CompoundValue(keyValues);
        }

    }
}
