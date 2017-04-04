using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.BLToolkit
{
    public class CacheScope : IDisposable
    {
        private Dictionary<Type, object> m_Accessors = new Dictionary<Type, object>();

        public object Get(Type t)
        {
            if (m_Accessors.ContainsKey(t))
                return m_Accessors[t];
            return null;
        }
        public void Add(Type t, object acc)
        {
            m_Accessors.Add(t, acc);
        }


        #region IDisposable Members

        public void Close()
        {
            Dispose();
        }

        private bool m_bDisposed;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (m_Accessors)
                {
                    foreach(Type t in m_Accessors.Keys)
                    {
                        BvCacheAspect.ClearCache(t, m_Accessors[t]);
                    }
                }
            }
        }
        
        public void Dispose()
        {
            Dispose(!m_bDisposed);
            m_bDisposed = true;
        }

        #endregion
    }
}
