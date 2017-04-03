using System;
using System.Collections.Generic;
using System.Data;
using bv.common.Core;

namespace EIDSS.RAM.QueryBuilder
{
    public class FilterValueHash : IDisposable
    {
        private readonly Dictionary<string, object[]> m_Objects = new Dictionary<string, object[]>();
        private readonly Dictionary<GisRefereneceType, DataView> m_GisDataView = new Dictionary<GisRefereneceType, DataView>();

        public object[] this[string key]
        {
            get
            {
                Utils.CheckNotNullOrEmpty(key, "key");
                if (!ContainsKey(key))
                {
                    throw new KeyNotFoundException("Value with given key is not exists.");
                }

                return m_Objects[key];
            }
            set
            {
                Utils.CheckNotNullOrEmpty(key, "key");
                m_Objects[key] = value;
            }
        }

        public DataView this[GisRefereneceType key]
        {
            get
            {
                var result = m_GisDataView.ContainsKey(key) 
                    ? m_GisDataView[key] 
                    : null;
                return result;
            }
            set { m_GisDataView[key] = value; }
        }

        public bool ContainsKey(string key)
        {
            Utils.CheckNotNullOrEmpty(key, "key");
            return m_Objects.ContainsKey(key);
        }

        public void Clear()
        {
            m_Objects.Clear();
            m_GisDataView.Clear();
        }

        public void Dispose()
        {
            Clear();
        }
    }
}