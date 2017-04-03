using System.Collections.Generic;
using bv.common.Core;

namespace eidss.model.Reports.OperationContext
{
    public class ContextKeeper : IContextKeeper
    {
        private readonly List<Context> m_ContextList = new List<Context>();

        public bool ContainsContext(string contextName)
        {
            Utils.CheckNotNullOrEmpty(contextName, "contextName");

            return (this[contextName] != null);
        }

        public Context this[string contextName]
        {
            get
            {
                Utils.CheckNotNullOrEmpty(contextName, "contextName");

                Context found = m_ContextList.Find(match => match.ContextName == contextName);
                return found;
            }
        }

        public Context CreateNewContext(string contextName)
        {
            Utils.CheckNotNullOrEmpty(contextName, "contextName");

            var context = new Context(this, contextName);
            m_ContextList.Add(context);
            return context;
        }

        internal bool Remove(string contextName)
        {
            Utils.CheckNotNullOrEmpty(contextName, "contextName");

            Context context = this[contextName];
            if (context != null)
            {
                return m_ContextList.Remove(context);
            }
            return false;
        }
    }
}