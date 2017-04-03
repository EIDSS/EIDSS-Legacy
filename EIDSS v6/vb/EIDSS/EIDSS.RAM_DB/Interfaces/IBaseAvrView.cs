using System;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;

namespace eidss.avr.db.Interfaces
{
    public interface IBaseAvrView
    {
        event EventHandler<CommandEventArgs> SendCommand;
    }
}