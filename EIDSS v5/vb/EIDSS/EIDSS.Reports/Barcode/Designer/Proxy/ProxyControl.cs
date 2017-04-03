using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using DevExpress.Utils.Design;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Barcode.Designer.Proxy
{
    [
        ToolboxItem(true),
//        XRDesigner("DevExpress.XtraReports.Design.XRLabelDesigner," + AssemblyInfo.SRAssemblyReports),
//        Designer("DevExpress.XtraReports.Design._XRLabelDesigner," + AssemblyInfo.SRAssemblyReportsDesign),
        DefaultBindableProperty("Text"),
        DefaultProperty("Text"),
//        ToolboxBitmap(typeof (ResFinder), ControlConstants.BitmapPath + "XRLabel.bmp"),
        //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRLabel", "Label"),
    ]
    public class ProxyControl
    {
        private readonly XRControl m_Control;
        protected readonly Control m_ParentControl;

        public ProxyControl(XRControl control, Control parentControl)
        {
            Utils.CheckNotNull(control, "control");
            Utils.CheckNotNull(parentControl, "propertyGrid");
            m_Control = control;
            m_ParentControl = parentControl;
        }

        [
            Description("Bindable. Gets or sets the text associated with the XRControl object."),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Text"),
            SRCategory(ReportStringId.CatData),
            DefaultValue(""),
            Bindable(true),
            Localizable(true)
        ]
        public virtual string Text
        {
            get { return m_Control.Text; }
            set
            {
                m_Control.Text = value;
                m_ParentControl.Invalidate(true);
            }
        }

        [
            Description("Gets or sets the control's text alignment."),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XRControl.TextAlignment"),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            Editor(typeof (TextAlignmentEditor), typeof (UITypeEditor)),
            Localizable(true)
        ]
        public virtual TextAlignment TextAlignment
        {
            get { return m_Control.TextAlignment; }
            set { m_Control.TextAlignment = value; }
        }

        [
            Description("Gets or sets the size of the control."),
            SRCategory(ReportStringId.CatLayout),
            Localizable(true),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XRControl.Size"),
            TypeConverter(typeof (SizeTypeConverter)),
        ]
        public virtual Size Size
        {
            get { return m_Control.Size; }
            set { m_Control.Size = value; }
        }

        [
            Description("Gets or sets the coordinates of the control's upper-left corner."),
            SRCategory(ReportStringId.CatLayout),
            Localizable(true),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Location"),
        ]
        public virtual Point Location
        {
            get { return m_Control.Location; }
            set { m_Control.Location = value; }
        }

        [
            Description("Gets or sets the control's font."),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            Editor(typeof (XRFontEditor), typeof (UITypeEditor)),
            Localizable(true),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Font"),
            TypeConverter(typeof (FontTypeConverter)),
        ]
        public Font Font
        {
            get { return m_Control.Font; }
            set { m_Control.Font = value; }
        }

        [
            Description("Gets or sets the control's foreground color."),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            Localizable(true),
            //    DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.ForeColor"),
        ]
        public virtual Color ForeColor
        {
            get { return m_Control.ForeColor; }
            set { m_Control.ForeColor = value; }
        }

        [
            Description("Gets or sets the control's background color."),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            Localizable(true),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.BackColor"),
        ]
        public virtual Color BackColor
        {
            get { return m_Control.BackColor; }
            set { m_Control.BackColor = value; }
        }

        [Description("Gets or sets the control's padding values (measured in report units)."),
         SRCategory(ReportStringId.CatAppearance),
         RefreshProperties(RefreshProperties.All),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Padding"),
        ]
        public virtual PaddingInfo Padding
        {
            get { return m_Control.Padding; }
            set { m_Control.Padding = value; }
        }

        [
            Description("Gets or sets the control's border color."),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            Localizable(true),
//         DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.BorderColor"),
        ]
        public virtual Color BorderColor
        {
            get { return m_Control.BorderColor; }
            set { m_Control.BorderColor = value; }
        }

        [
            Description(
                "Gets or sets a set of borders (top, right, bottom,left), which should be visible for the control."),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            Editor(typeof (BordersEditor), typeof (UITypeEditor)),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Borders"),
        ]
        public virtual BorderSide Borders
        {
            get { return m_Control.Borders; }
            set { m_Control.Borders = value; }
        }

        [
            Description("Gets or sets the control's border width (measured in pixels)."),
            SRCategory(ReportStringId.CatAppearance),
            RefreshProperties(RefreshProperties.All),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.BorderWidth"),
        ]
        public virtual int BorderWidth
        {
            get { return m_Control.BorderWidth; }
            set { m_Control.BorderWidth = value; }
        }

        [
            Description("Bindable. Gets or sets the object that contains data about this control."),
            SRCategory(ReportStringId.CatData),
            DefaultValue(""),
            TypeConverter(typeof (StringConverter)),
            Bindable(true),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Tag"),
        ]
        public object Tag
        {
            get { return m_Control.Tag; }
            set { m_Control.Tag = value; }
        }

        [
            Description("Gets or sets a value indicating whether the current control is displayed in a report."),
            SRCategory(ReportStringId.CatBehavior),
            DefaultValue(true),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XRControl.Visible"),
            TypeConverter(typeof (BooleanTypeConverter)),
            Localizable(true),
        ]
        public bool Visible
        {
            get { return m_Control.Visible; }
            set { m_Control.Visible = value; }
        }
    }
}