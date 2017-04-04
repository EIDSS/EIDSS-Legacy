using System;

namespace eidss.avr.db.AvrEventArgs.AvrEventArgs
{
    public class AvrPostNeededEventArgs:EventArgs
    {
        public AvrPostNeededEventArgs(bool postNeeded)
        {
            PostNeeded = postNeeded;
        }

        public bool PostNeeded { get; private set; }
    }
}