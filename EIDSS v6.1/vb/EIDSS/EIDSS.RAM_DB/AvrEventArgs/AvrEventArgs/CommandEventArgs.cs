using System;
using bv.common.Core;
using eidss.model.Avr.Commands;

namespace eidss.avr.db.AvrEventArgs.AvrEventArgs
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