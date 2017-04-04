using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using bv.common.Configuration;
using bv.model.Model.Core;

namespace eidss.web.common.Utils
{
    public enum ForceReadWriteLockType
    {
        Default = 0,
        Read = 1,
        Write = 2
    }

    public sealed class ObjectStorage
    {
        private class ObjectStorageSession
        {
            internal DateTime LastAccess { get; set; }
            internal Dictionary<string, ObjectStorage> ListOfObjects { get; private set; }
            internal ObjectStorageSession()
            {
                LastAccess = DateTime.Now;
                ListOfObjects = new Dictionary<string, ObjectStorage>();
            }
        }
        private sealed class ObjectStorageDisposable : IDisposable
        {
            private ReaderWriterLockSlim locker;
            private bool lockToWrite = true; // готовимся к худшему
            internal ObjectStorageDisposable(ObjectStorage root, ForceReadWriteLockType ForceLock)
            {
                if (root != null)
                {
                    locker = root.locker;
                }
                if (locker != null)
                {
                    if (ForceLock == ForceReadWriteLockType.Read)
                    {
                        lockToWrite = false;
                    }
                    else if (ForceLock != ForceReadWriteLockType.Write && HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Request.RequestType == "GET")
                        {
                            lockToWrite = false;
                        }
                    }

                    if (lockToWrite)
                        locker.EnterWriteLock();
                    else
                        locker.EnterReadLock();
                }
            }
            public void Dispose()
            {
                if (locker != null)
                {
                    if (lockToWrite)
                        locker.ExitWriteLock();
                    else
                        locker.ExitReadLock();
                }
            }
        }

        private static readonly int CheckIntervalSeconds = Config.GetIntSetting("CheckIntervalSeconds", 300);
        private static readonly int LifetimeSeconds = Config.GetIntSetting("LifetimeSeconds", 1200);
        private static readonly Dictionary<string, ObjectStorageSession> sGStorage = new Dictionary<string, ObjectStorageSession>();
        private bool isroot { get; set; }
        private long root { get; set; }
        private object obj { get; set; }
        private DateTime heartbeat { get; set; }
        private ReaderWriterLockSlim locker { get; set; }
        private ObjectStorage(long r, string k, object o)
        {
            root = r;
            obj = o;
            isroot = (r.ToString() == k);
            heartbeat = DateTime.Now;
            if (isroot)
            {
                locker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            }
        }



        public static void Remove(string sessionId)
        {
            var listForDispose = new List<IDisposable>();

            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    foreach (var i in sGStorage[sessionId].ListOfObjects)
                    {
                        if (i.Value.obj is IDisposable)
                            listForDispose.Add(i.Value.obj as IDisposable);
                    }

                    sGStorage.Remove(sessionId);
                }
            }

            try
            {
                listForDispose.ForEach(c => c.Dispose());
                listForDispose.Clear();
            }
            catch
            {
            }
        }

        public static bool Heartbeat(string sessionId, long key)
        {
            var realkey = key.ToString();
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    if ((DateTime.Now - s.LastAccess).TotalSeconds > LifetimeSeconds)
                    {
                        return false;
                    }

                    if (s.ListOfObjects.ContainsKey(realkey))
                    {
                        var item = s.ListOfObjects[realkey];
                        item.heartbeat = DateTime.Now;
                        if (!item.isroot)
                        {
                            return Heartbeat(sessionId, item.root);
                        }
                        return true;
                    }

                }
            }
            return false;
        }

        public static void Access(string sessionId)
        {
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;
                }
            }
        }

        public static void Put(string sessionId, long root, long key, string additionalKey, object obj)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            lock (sGStorage)
            {
                if (!sGStorage.ContainsKey(sessionId))
                {
                    sGStorage.Add(sessionId, new ObjectStorageSession());
                }
                var s = sGStorage[sessionId];
                s.LastAccess = DateTime.Now;
                if (s.ListOfObjects.ContainsKey(realkey))
                {
                    var testObj = s.ListOfObjects[realkey].obj;
                    if (ReferenceEquals(obj, testObj))
                        return;

                    s.ListOfObjects.Remove(realkey);
                }
                s.ListOfObjects.Add(realkey, new ObjectStorage(root, realkey, obj));
            }
        }

        public static object Remove(string sessionId, long key, string additionalKey)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;
                    if (s.ListOfObjects.ContainsKey(realkey))
                    {
                        s.ListOfObjects.Remove(realkey);
                    }
                }
            }

            return null;
        }


        public static R UsingAlternative<O, R>(Func<O> getter, Func<O, R> action, string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true, ForceReadWriteLockType ForceLock = ForceReadWriteLockType.Default)
        {
            O o = getter();
            return (o == null)
                ? Using(action, sessionId, key, additionalKey, bThrowIfNotFound, ForceLock)
                : action(o);
        }

        public static R Using<O, R>(Func<O, R> action, string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true, ForceReadWriteLockType ForceLock = ForceReadWriteLockType.Default)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            ObjectStorage item = null;
            ObjectStorage root = null;
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;
                    if (s.ListOfObjects.ContainsKey(realkey))
                    {
                        item = s.ListOfObjects[realkey];
                        item.heartbeat = DateTime.Now;
                        if (item.isroot)
                        {
                            root = item;
                        }
                        else
                        {
                            if (s.ListOfObjects.ContainsKey(item.root.ToString()))
                            {
                                root = s.ListOfObjects[item.root.ToString()];
                            }
                        }
                        if (root != null)
                        {
                            root.heartbeat = DateTime.Now;
                        }
                    }
                }
            }

            if (item == null && bThrowIfNotFound)
                throw new ObjectNotFoundException();

            using (var disposable = new ObjectStorageDisposable(root, ForceLock))
            {
                return action(item == null ? default(O) : (O)item.obj);
            }
        }

        public static R UsingList<O, R>(Func<List<O>, R> action, string sessionId, IEnumerable<Tuple<long, string>> keys, bool bThrowIfNotFound = true, ForceReadWriteLockType ForceLock = ForceReadWriteLockType.Default)
        {
            List<ObjectStorage> items = new List<ObjectStorage>();
            List<ObjectStorage> roots = new List<ObjectStorage>();
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;

                    foreach (var k in keys)
                    {
                        string realkey = k.Item1 + k.Item2 ?? "";

                        if (s.ListOfObjects.ContainsKey(realkey))
                        {
                            ObjectStorage root = null;
                            ObjectStorage item = s.ListOfObjects[realkey];
                            item.heartbeat = DateTime.Now;
                            if (item.isroot)
                            {
                                root = item;
                            }
                            else
                            {
                                if (s.ListOfObjects.ContainsKey(item.root.ToString()))
                                {
                                    root = s.ListOfObjects[item.root.ToString()];
                                }
                            }
                            if (root != null)
                            {
                                root.heartbeat = DateTime.Now;
                            }

                            if (!items.Contains(item))
                                items.Add(item);
                            if (!roots.Contains(root))
                                roots.Add(root);
                        }
                    }
                }
            }

            if (items.Count == 0 && bThrowIfNotFound)
                throw new ObjectNotFoundException();

            using (var disposable = new ObjectStorageDisposable(roots[0], ForceLock))
            {
                return action(items.Select(i => i.obj).Cast<O>().ToList());
            }
        }


        public static R UsingWithRoot<O, T, R>(Func<O, T, R> action, string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true, ForceReadWriteLockType ForceLock = ForceReadWriteLockType.Default)
            where T: class
            where O: class
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            ObjectStorage item = null;
            ObjectStorage root = null;
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;
                    if (s.ListOfObjects.ContainsKey(realkey))
                    {
                        item = s.ListOfObjects[realkey];
                        item.heartbeat = DateTime.Now;
                        if (item.isroot)
                        {
                            root = item;
                        }
                        else
                        {
                            if (s.ListOfObjects.ContainsKey(item.root.ToString()))
                            {
                                root = s.ListOfObjects[item.root.ToString()];
                            }
                        }
                        if (root != null)
                        {
                            root.heartbeat = DateTime.Now;
                        }
                    }
                }
            }

            if ((item == null || root == null) && bThrowIfNotFound)
                throw new ObjectNotFoundException();

            using (var disposable = new ObjectStorageDisposable(root, ForceLock))
            {
                return action(item == null ? default(O) : item.obj as O, root == null ? default(T) : root.obj as T);
            }
        }

        public static R Using2WithRoot<O, A, T, R>(Func<O, A, T, R> action, string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true, ForceReadWriteLockType ForceLock = ForceReadWriteLockType.Default)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            ObjectStorage obj = null;
            ObjectStorage item = null;
            ObjectStorage root = null;
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;
                    if (s.ListOfObjects.ContainsKey(key.ToString()))
                    {
                        obj = s.ListOfObjects[key.ToString()];
                        obj.heartbeat = DateTime.Now;
                        if (obj.isroot)
                        {
                            root = obj;
                        }
                        else
                        {
                            if (s.ListOfObjects.ContainsKey(obj.root.ToString()))
                            {
                                root = s.ListOfObjects[obj.root.ToString()];
                            }
                        }
                        if (root != null)
                        {
                            root.heartbeat = DateTime.Now;
                        }
                    }
                    if (s.ListOfObjects.ContainsKey(realkey))
                    {
                        item = s.ListOfObjects[realkey];
                        item.heartbeat = DateTime.Now;
                        if (root == null)
                        {
                            if (item.isroot)
                            {
                                root = item;
                            }
                            else
                            {
                                if (s.ListOfObjects.ContainsKey(item.root.ToString()))
                                {
                                    root = s.ListOfObjects[item.root.ToString()];
                                }
                            }
                            if (root != null)
                            {
                                root.heartbeat = DateTime.Now;
                            }
                        }
                    }
                }
            }

            if ((obj == null || item == null || root == null) && bThrowIfNotFound)
                throw new ObjectNotFoundException();

            using (var disposable = new ObjectStorageDisposable(root, ForceLock))
            {
                return action(obj == null ? default(O) : (O)obj.obj, item == null ? default(A) : (A)item.obj, root == null ? default(T) : (T)root.obj);
            }
        }

        public static R UsingRoot<T, R>(Func<T, R> action, string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true, ForceReadWriteLockType ForceLock = ForceReadWriteLockType.Default)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            ObjectStorage item = null;
            ObjectStorage root = null;
            lock (sGStorage)
            {
                if (sGStorage.ContainsKey(sessionId))
                {
                    var s = sGStorage[sessionId];
                    s.LastAccess = DateTime.Now;
                    if (s.ListOfObjects.ContainsKey(realkey))
                    {
                        item = s.ListOfObjects[realkey];
                        item.heartbeat = DateTime.Now;
                        if (item.isroot)
                        {
                            root = item;
                        }
                        else
                        {
                            if (s.ListOfObjects.ContainsKey(item.root.ToString()))
                            {
                                root = s.ListOfObjects[item.root.ToString()];
                            }
                        }
                        if (root != null)
                        {
                            root.heartbeat = DateTime.Now;
                        }
                    }
                }
            }

            if (root == null && bThrowIfNotFound)
                throw new ObjectNotFoundException();

            using (var disposable = new ObjectStorageDisposable(root, ForceLock))
            {
                return action(root == null ? default(T) : (T)root.obj);
            }
        }


       public static List<T> Find<T>(Func<T, bool> condition)
        {
            var list = new List<T>();
            lock (sGStorage)
            {
                try
                {
                    foreach (var s in sGStorage)
                    {
                        list.AddRange(
                            s.Value.ListOfObjects.Where(i => i.Value.obj is T && condition((T) i.Value.obj))
                             .Select(i => (T) i.Value.obj)
                             .ToList());
                    }
                }
                catch
                {

                }
                return list;
            }
        }

        #region Deleteng objects by timeout

 
        private static void DeleteByTimeout()
        {
            var now = DateTime.Now;
            var listForDispose = new List<IDisposable>();
            var listForRemove = new List<string>();
            var listForDeleteSession = new List<string>();
            lock (sGStorage)
            {
                try
                {
                    foreach (var s in sGStorage)
                    {
                        if ((now - s.Value.LastAccess).TotalSeconds > LifetimeSeconds)
                        {
                            foreach (var i in s.Value.ListOfObjects)
                            {
                                if (i.Value.obj is IDisposable)
                                    listForDispose.Add(i.Value.obj as IDisposable);
                                listForRemove.Add(i.Key);
                                //s.Value.ListOfObjects.Remove(i.Key);
                            }
                        }
                        else
                        {
                            var keys = s.Value.ListOfObjects
                                .Where(c => c.Value.isroot && (now - c.Value.heartbeat).TotalSeconds > LifetimeSeconds)
                                .Select(c => c.Key)
                                .ToList();
                            var items = s.Value.ListOfObjects
                                .Join(keys, c => c.Value.root.ToString(), p => p, (c, p) => c.Key)
                                .ToList();
                            foreach (var i in items)
                            {
                                if (s.Value.ListOfObjects[i].obj is IDisposable)
                                    listForDispose.Add(s.Value.ListOfObjects[i].obj as IDisposable);
                                listForRemove.Add(i);
                                //s.Value.ListOfObjects.Remove(i);
                            }
                        }

                        listForRemove.ForEach(c => s.Value.ListOfObjects.Remove(c));
                        listForRemove.Clear();

                        if (s.Value.ListOfObjects.Count == 0)
                        {
                            listForDeleteSession.Add(s.Key);
                        }
                    }

                    listForDeleteSession.ForEach(c => sGStorage.Remove(c));
                }
                catch
                {
                }
            }

            try
            {
                listForDispose.ForEach(c => c.Dispose());
                listForDispose.Clear();
            }
            catch
            {
            }

            GC.Collect();
        }
        private static Timer gDeletedTimer = new Timer(t =>
        {
            DeleteByTimeout();
            gDeletedTimer.Change(CheckIntervalSeconds * 1000, Timeout.Infinite);
        }, null, CheckIntervalSeconds * 1000, Timeout.Infinite);

        #endregion

    }
}
