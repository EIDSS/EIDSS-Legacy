using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using bv.common.Configuration;
using bv.model.Model.Core;

namespace eidss.web.common.Utils
{
    public class ObjectNotFoundException : BvModelException
    {
        public ObjectNotFoundException()
            : base()
        {
        }

    }

    public class ModelStorage : IDisposable
    {
        protected class ModelStorageItem
        {
            public bool isroot { get; protected set; }
            public long root { get; protected set; }
            public object obj { get; protected set; }
            //public DateTime access { get; set; }
            public DateTime heartbeat { get; set; }
            public ModelStorageItem(long r, string k, object o)
            {
                root = r;
                obj = o;
                isroot = (r.ToString() == k);
                //access = DateTime.Now;
                heartbeat = DateTime.Now;
            }
        }

        private static readonly Dictionary<string, ModelStorage> m_GStorage = new Dictionary<string, ModelStorage>();
        private readonly Dictionary<string, ModelStorageItem> m_Storage = new Dictionary<string, ModelStorageItem>();
        private readonly string m_SessionId;
        private DateTime m_access { get; set; }

        public ModelStorage(string sessionId)
        {
            m_SessionId = sessionId;
            m_access = DateTime.Now;
            List<IDisposable> listForDispose = null;
            lock (m_GStorage)
            {
                if (m_GStorage.ContainsKey(sessionId))
                {
                    listForDispose = removeInternalSelf(sessionId);
                }
                m_GStorage.Add(sessionId, this);
            }
            disposeForDispose(listForDispose);
        }

        public static void Put(string sessionId, long root, long key, string additionalKey, object obj)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            List<IDisposable> listForDispose = null;
            lock (m_GStorage)
            {
                if (!m_GStorage.ContainsKey(sessionId))
                {
                    new ModelStorage(sessionId);
                }

                var ms = GetModelStorage(sessionId);
                if (ms != null)
                {
                    ms.m_access = DateTime.Now;
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        var testObj = ms.m_Storage[realkey].obj;
                        if (ReferenceEquals(obj, testObj))
                            return;

                        listForDispose = ms.removeInternal(realkey);
                    }
                    ms.m_Storage.Add(realkey, new ModelStorageItem(root, realkey, obj));
                }
            }
            disposeForDispose(listForDispose);
        }

        private List<IDisposable> removeInternalSelf(string sessionId)
        {
            var ret = new List<IDisposable>();
            lock (m_GStorage)
            {
                m_Storage.ToList().ForEach(c =>
                {
                    if (c.Value.obj is IDisposable)
                        ret.Add(c.Value.obj as IDisposable);
                });
                m_GStorage.Remove(sessionId);
            }
            return ret;
        }
        private List<IDisposable> removeInternal(string realkey)
        {
            var ret = new List<IDisposable>();
            lock (m_GStorage)
            {
                if (m_Storage[realkey].obj is IDisposable)
                    ret.Add(m_Storage[realkey].obj as IDisposable);
                m_Storage.Remove(realkey);
            }
            return ret;
        }
        private static void disposeForDispose(List<IDisposable> list)
        {
            if (list != null && list.Count > 0)
            {
                list.ForEach(c => c.Dispose());
                list.Clear();
            }
        }

        public static void Remove(string sessionId)
        {
            List<IDisposable> listForDispose = null;
            lock (m_GStorage)
            {
                var ms = GetModelStorage(sessionId);
                if (ms != null)
                    listForDispose = ms.removeInternalSelf(sessionId);
            }
            disposeForDispose(listForDispose);
        }

        public static bool Heartbeat(string sessionId, long key)
        {
            var realkey = key.ToString();
            lock (m_GStorage)
            {
                var ms = GetModelStorage(sessionId);
                if (ms != null)
                {
                    if ((DateTime.Now - ms.m_access).TotalSeconds > LifetimeSeconds)
                    {
                        return false;
                    }

                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        var item = ms.m_Storage[realkey];
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
            lock (m_GStorage)
            {
                var ms = GetModelStorage(sessionId);
                if (ms != null)
                {
                    ms.m_access = DateTime.Now;
                }
            }
        }

        public static object Get(string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            lock (m_GStorage)
            {
                var ms = GetModelStorage(sessionId);
                if (ms != null)
                {
                    ms.m_access = DateTime.Now;
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        var item = ms.m_Storage[realkey];
                        //item.access = DateTime.Now;
                        //if (!item.isroot)
                        //{
                        //    object root = Get(sessionId, item.root, null, false);
                        //    if (ms.m_Storage.Where(c => c.Key == item.root.ToString()).Count() > 0)
                        //        ms.m_Storage.Where(c => c.Key == item.root.ToString()).Single().Value.access = item.access;
                        //}

                        return item.obj;
                    }
                }
            }
            if (bThrowIfNotFound)
                throw new ObjectNotFoundException();
            return null;
        }
        public static object GetRoot(string sessionId, long key, string additionalKey, bool bThrowIfNotFound = true)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            lock (m_GStorage)
            {
                var ms = GetModelStorage(sessionId);
                if (ms != null)
                {
                    ms.m_access = DateTime.Now;
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        var item = ms.m_Storage[realkey];
                        if (ms.m_Storage.ContainsKey(item.root.ToString()))
                        {
                            var ret = ms.m_Storage[item.root.ToString()];
                            //ret.access = DateTime.Now;
                            return ret.obj;
                        }
                    }
                }
            }
            if (bThrowIfNotFound)
                throw new ObjectNotFoundException();
            return null;
        }

        public static object Remove(string sessionId, long key, string additionalKey)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            List<IDisposable> listForDispose = null;
            lock (m_GStorage)
            {
                var ms = GetModelStorage(sessionId);
                if (ms != null)
                {
                    ms.m_access = DateTime.Now;
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        listForDispose = ms.removeInternal(realkey);
                    }
                }
            }
            disposeForDispose(listForDispose);

            return null;
        }
        private static ModelStorage GetModelStorage(string sessionId)
        {
            lock (m_GStorage)
            {
                if (m_GStorage.ContainsKey(sessionId))
                    return m_GStorage[sessionId];
            }
            return null;
        }
        #region Deleteng objects by timeout

        private static readonly int CheckIntervalSeconds = Config.GetIntSetting("CheckIntervalSeconds", 300);
        private static readonly int LifetimeSeconds = Config.GetIntSetting("LifetimeSeconds", 1200);
        private static void DeleteByTimeout()
        {
            DateTime now = DateTime.Now;
            var listForDispose = new List<IDisposable>();
            lock (m_GStorage)
            {
                try
                {
                    foreach (var s in m_GStorage)
                    {
                        var keys = s.Value.m_Storage
                            //.Where(c => c.Value.isroot && (now - c.Value.access).TotalSeconds > LifetimeSeconds)
                            .Where(c => c.Value.isroot && (now - c.Value.heartbeat).TotalSeconds > LifetimeSeconds)
                            .Select(c => c.Key)
                            .ToList();
                        var items = s.Value.m_Storage
                            .Join(keys, c => c.Value.root.ToString(), p => p, (c, p) => c.Key)
                            .ToList();
                        foreach (var i in items)
                        {
                            listForDispose.AddRange(s.Value.removeInternal(i));
                        }
                    }
                }
                catch
                {
                }
            }
            disposeForDispose(listForDispose);
        }
        private static Timer m_DeletedTimer = new Timer(t =>
            {
                DeleteByTimeout();
                m_DeletedTimer.Change(CheckIntervalSeconds * 1000, Timeout.Infinite);
            }, null, CheckIntervalSeconds * 1000, Timeout.Infinite);

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            List<IDisposable> listForDispose = null;
            lock (m_GStorage)
            {
                if (m_GStorage.ContainsKey(m_SessionId))
                {
                    listForDispose = removeInternalSelf(m_SessionId);
                }
                m_Storage.Clear();
            }
            disposeForDispose(listForDispose);
        }

        #endregion
    }
}