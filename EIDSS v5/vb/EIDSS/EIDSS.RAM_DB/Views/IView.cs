using System;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface IView
    {
        event EventHandler<CommandEventArgs> SendCommand;
    }
}