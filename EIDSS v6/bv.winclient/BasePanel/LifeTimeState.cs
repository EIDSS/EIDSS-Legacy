using System;

namespace bv.winclient.BasePanel
{
    [Flags]
    public enum LifeTimeState
    {
        NotInitialized = 0,
        DataLoading = 1,
        DataLoaded = 2,
        Closing = 4,
        Closed = 8
    }
}