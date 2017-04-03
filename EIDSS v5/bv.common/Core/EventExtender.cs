using System;

namespace bv.common.Core
{
    public static class EventExtender
    {
        public static void SafeRaise(this EventHandler handler, object sender, EventArgs e)
        {
            EventHandler localHandler = handler;
            if (localHandler != null)
            {
                localHandler(sender, e);
            }
        }

        public static void SafeRaise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e)
            where TEventArgs : EventArgs
        {
            EventHandler<TEventArgs> localHandler = handler;
            if (localHandler != null)
            {
                localHandler(sender, e);
            }
        }
    }
}