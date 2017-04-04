using System;

namespace eidss.model.Trace
{
    public class EmptyTraceStrategy :ITraceStrategy
    {
        public void TraceError(string title, string message, params object[] args)
        {
            
        }

        public void TraceError(Exception e)
        {
            
        }

        public void Trace(string title, string message, params object[] args)
        {
            
        }
    }
}