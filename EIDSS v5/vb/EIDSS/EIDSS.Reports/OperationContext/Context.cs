using System;
using bv.common;
using bv.common.Core;

namespace EIDSS.Reports.OperationContext
{
    public class Context : IDisposable
    {
        private readonly string m_ContextName;
        private readonly ContextKeeper m_ContextKeeper;

        internal Context(ContextKeeper contextKeeper, string contextName)
        {
            Utils.CheckNotNull(contextKeeper, "contextKeeper");
            Utils.CheckNotNullOrEmpty(contextName, "contextName");

            m_ContextName = contextName;
            m_ContextKeeper = contextKeeper;
        }

        public string ContextName
        {
            get { return m_ContextName; }
        }

        public IContextKeeper ContextKeeper
        {
            get { return m_ContextKeeper; }
        }

        public void Dispose()
        {
            m_ContextKeeper.Remove(ContextName);
        }
    }
}