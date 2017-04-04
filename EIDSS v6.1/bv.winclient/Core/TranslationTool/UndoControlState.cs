using System.ComponentModel;
using System.Drawing;


namespace bv.winclient.Core.TranslationTool
{
    public class UndoControlState
    {
        public Component Element { get; set;}
        public Rectangle Bounds { get; set; }
        public string Caption { get; set; }
        public bool Visible { get; set; }
        public UndoOperation Operation { get; set; }
        public UndoControlState[] RelatedChanges { get; set; }
    }
}
