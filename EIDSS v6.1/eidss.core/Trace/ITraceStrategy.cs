using System;

namespace eidss.model.Trace
{
    public interface ITraceStrategy
    {
        void TraceError(string title, string message, params object[] args);
        void TraceError(Exception e);
        void Trace(string title, string message, params object[] args);
    }
}