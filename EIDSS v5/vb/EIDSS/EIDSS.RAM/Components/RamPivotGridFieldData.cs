using System.ComponentModel;
using DevExpress.XtraPivotGrid;

namespace EIDSS.RAM.Components
{
    public class RamPivotGridFieldData
    {
        [Description("Gets or sets whether the field is visible.")]
        [DefaultValue(true)]
        public bool Visible { get; set; }

        [Description("Gets or sets the name of the database field that is assigned to the current field object.")]
        public string FieldName { get; set; }

        [Description("Gets or sets the field\'s display caption.")]
        public string Caption { get; set; }

        [Description("Gets or sets the field\'s name.")]
        public string Name { get; set; }

        public bool IsFilter { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Caption);
        }
    }
}