using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using DevExpress.Utils.Design;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Barcode.Designer.Proxy
{
    public class ProxyLabel : ProxyControl
    {
        private readonly XRLabel m_Label;

        public ProxyLabel(XRLabel label, Control parentControl)
            : base(label, parentControl)
        {
            m_Label = label;
        }

        [
            Description("Gets or sets the angle by which the XRLabel's text is rotated."),
            //  DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRLabel.Angle"),
            DefaultValue(0f),
            SRCategory(ReportStringId.CatBehavior),
        ]
        public float Angle
        {
            get { return m_Label.Angle; }
            set
            {
                m_Label.Angle = value;
                m_ParentControl.Invalidate(true);
            }
        }

        [
            Description("Gets or sets the text lines in the XRLabel control."),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRLabel.Lines"),
            SRCategory(ReportStringId.CatData),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            Editor("DevExpress.XtraReports.Design.StringArrayEditor," + AssemblyInfo.SRAssemblyReports,
                typeof (UITypeEditor))
        ]
        public string[] Lines
        {
            get { return m_Label.Lines; }
            set { m_Label.Lines = value; }
        }

        [
            Description(
                "Gets or sets a value specifying whether carriage returns (CRLF) stored in a label's text should be processed."
                ),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRLabel.Multiline"),
            SRCategory(ReportStringId.CatBehavior),
            DefaultValue(false),
            TypeConverter(typeof (BooleanTypeConverter)),
        ]
        public bool Multiline
        {
            get { return m_Label.Multiline; }
            set { m_Label.Multiline = value; }
        }
    }
}