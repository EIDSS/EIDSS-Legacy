using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using bv.common.Configuration;
using bv.model.Model.Core;

namespace eidss.webclient.Utils
{
    public class ObjectNotFoundException : BvModelException
    {
        public ObjectNotFoundException()
            :base()
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
            public DateTime access { get; set; }
            public ModelStorageItem(long r, string k, object o)
            {
                root = r;
                obj = o;
                isroot = (r.ToString() == k);
                access = DateTime.Now;
            }
        }

        private static readonly Dictionary<string, ModelStorage> m_GStorage = new Dictionary<string, ModelStorage>();
        private readonly Dictionary<string, ModelStorageItem> m_Storage = new Dictionary<string, ModelStorageItem>();
        private readonly string m_SessionId;

        public ModelStorage(string sessionId)
        {
            m_SessionId = sessionId;
            lock(m_GStorage)
            {
                if (m_GStorage.ContainsKey(sessionId))
                    m_GStorage.Remove(sessionId);
                m_GStorage.Add(sessionId, this);
            }
        }

        public static void Put(string sessionId, long root, long key, string additionalKey, object obj)
        {
            if (additionalKey == null)
                additionalKey = "";
            string realkey = key + additionalKey;
            lock (m_GStorage)
            {
                var ms = m_GStorage[sessionId];
                if (ms != null)
                {
                    if (ms.m_Storage.ContainsKey(realkey))
                        ms.m_Storage.Remove(realkey);
                    ms.m_Storage.Add(realkey, new ModelStorageItem(root, realkey, obj));
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
                var ms = m_GStorage[sessionId];
                if (ms != null)
                {
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        var item = ms.m_Storage[realkey];
                        item.access = DateTime.Now;
                        if (!item.isroot)
                        {
                            if (ms.m_Storage.Where(c => c.Key == item.root.ToString()).Count() > 0)
                                ms.m_Storage.Where(c => c.Key == item.root.ToString()).Single().Value.access = item.access;
                        }
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
                var ms = m_GStorage[sessionId];
                if (ms != null)
                {
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        var item = ms.m_Storage[realkey];
                        if (ms.m_Storage.ContainsKey(item.root.ToString()))
                        {
                            var ret = ms.m_Storage[item.root.ToString()];
                            ret.access = DateTime.Now;
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
            lock (m_GStorage)
            {
                var ms = m_GStorage[sessionId];
                if (ms != null)
                {
                    if (ms.m_Storage.ContainsKey(realkey))
                    {
                        ms.m_Storage.Remove(realkey);
                    }
                }
            }
            return null;
        }

        #region Deleteng objects by timeout

        private static readonly int CheckIntervalSeconds = Config.GetIntSetting("CheckIntervalSeconds", 300);
        private static readonly double LifetimeSeconds = Config.GetDoubleSetting("LifetimeSeconds", 600);
        private static void DeleteByTimeout()
        {
            DateTime now = DateTime.Now;
            lock (m_GStorage)
            {
                try
                {
                    foreach (var s in m_GStorage)
                    {
                        var keys = s.Value.m_Storage
                            .Where(c => c.Value.isroot && (now - c.Value.access).TotalSeconds > LifetimeSeconds)
                            .Select(c => c.Key)
                            .ToList();
                        var items = s.Value.m_Storage
                            .Join(keys, c => c.Value.root.ToString(), p => p, (c, p) => c.Key)
                            .ToList();
                        foreach (var i in items)
                            s.Value.m_Storage.Remove(i);
                    }
                }
                catch
                {
                }
            }
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
            lock (m_GStorage)
            {
                m_GStorage.Remove(m_SessionId);
            }
            m_Storage.Clear();
        }

        #endregion
    }
}