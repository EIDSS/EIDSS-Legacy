using System;

namespace eidss.avr.db.Interfaces
{
    public interface IAvrInvokable
    {
        bool InvokeRequired { get; }
        object Invoke(Delegate method);
    }
}