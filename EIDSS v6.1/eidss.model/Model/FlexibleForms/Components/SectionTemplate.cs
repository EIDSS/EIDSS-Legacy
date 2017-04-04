using System.Collections.Generic;
using BLToolkit.EditableObjects;

namespace eidss.model.Schema
{
    public partial class SectionTemplate
    {
        public int Left { get { return intLeft ?? 0; } }
        public int Top { get { return intTop ?? 0; } }
        public int Width { get { return intWidth ?? 200; } }
        public int Height { get { return intHeight ?? 100; } }
        public int Order { get { return intOrder ?? 0; } }

        public EditableList<ActivityParameter> ActivityParameters { get; set; }
        public List<PredefinedStub> PredefinedStubRows { get; set; }

        public int TopAbsolute { get; set; }
    }
}
