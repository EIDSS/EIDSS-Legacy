using BLToolkit.EditableObjects;

namespace eidss.model.Schema
{
    public partial class SectionTemplate
    {
        public int Left { get { return intLeft.HasValue ? intLeft.Value : 0; } }
        public int Top { get { return intTop.HasValue ? intTop.Value : 0; } }
        public int Width { get { return intWidth.HasValue ? intWidth.Value : 200; } }
        public int Height { get { return intHeight.HasValue ? intHeight.Value : 100; } }

        public EditableList<ActivityParameter> ActivityParameters { get; set; }
    }
}
