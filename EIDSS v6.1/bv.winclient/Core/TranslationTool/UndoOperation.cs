using System;

namespace bv.winclient.Core.TranslationTool
{
    [Flags]
    public enum UndoOperation
    {
        None = 0,
        Text = 1,
        Position = 2,
        Visibility = 4
    }
}
