using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Schema
{
    public class SectionDeletedFromTemplate
    {
        public Int32? intLeft { get; set; }
        public Int32? intTop { get; set; }
        public Int32? intWidth { get; set; }
        public Int32? intHeight { get; set; }
        public Int32? intOrder { get; set; }
        public int Left { get { return intLeft ?? 4; } }
        public int Top { get { return intTop ?? 4; } }
        public int Width { get { return intWidth ?? 200; } }
        public int Height { get { return intHeight ?? 100; } }
        public int Order { get { return intOrder ?? 0; } }
        public String DefaultName { get; set; }

        public SectionDeletedFromTemplate(String name)
        {
            DefaultName = name;
        }
    }
}
