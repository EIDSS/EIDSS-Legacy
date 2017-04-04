using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public abstract class BaseGridViewCellDisplayTextEventArgs
    {
        public abstract object Value { get; }
        public abstract string DisplayText { get; set; }
    }
}
