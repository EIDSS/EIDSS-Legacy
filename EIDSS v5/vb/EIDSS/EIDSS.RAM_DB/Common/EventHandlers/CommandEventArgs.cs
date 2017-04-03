using System;
using bv.common;
using bv.common.Core;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class CommandEventArgs : EventArgs
    {
        private readonly Command m_Command;

        public CommandEventArgs(Command command)
        {
            Utils.CheckNotNull(command, "command");
            m_Command = command;
        }

        public Command Command
        {
            get { return m_Command; }
        }
    }
}