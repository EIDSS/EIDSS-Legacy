using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.winclient.Core.TranslationTool
{
    public class ControlDesignerEventArgs:EventArgs
    {
        public bool ForceEditorClosing { get; set; }
        public UndoControlState UndoState { get; set; }
    }
}
