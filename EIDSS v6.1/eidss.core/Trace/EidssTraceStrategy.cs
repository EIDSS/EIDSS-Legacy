using System;
using bv.common.Diagnostics;

namespace eidss.model.Trace
{
    public class EidssTraceStrategy : ITraceStrategy
    {
        public void TraceError(string title, string message, params object[] args)
        {
            Dbg.Debug(title + Environment.NewLine + message, args);
        }

        public void TraceError(Exception e)
        {
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, e.ToString());
        }

        public void Trace(string title, string message, params object[] args)
        {
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, title + Environment.NewLine + message, args);
        }
    }
}