using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.winclient.Core.TranslationTool
{
    [Flags]
    public enum ControlEdge
    {
            None = 0,
            Right = 1,
            Left = 2,
            Top = 4,
            Bottom = 8,
            TopLeft = Left | Top,
            RightBottom = Right | Bottom,
            All = Left | Right | Top | Bottom
    }
}
