using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.Utils.Design;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Barcode.Designer.Proxy
{
    [
//Designer("DevExpress.XtraReports.Design._ReportDesigner," + AssemblyInfo.SRAssemblyReportsDesign, typeof(IRootDesigner)),
//Designer("DevExpress.XtraReports.Design._ComponentReportDesigner," + AssemblyInfo.SRAssemblyReportsDesign),
//XRDesigner("DevExpress.XtraReports.Design.ReportDesigner," + AssemblyInfo.SRAssemblyReports, typeof(IRootDesigner)),
//XRDesigner("DevExpress.XtraReports.Design.ComponentReportDesigner," + AssemblyInfo.SRAssemblyReports),
        TypeConverter("DevExpress.XtraReports.Design.XtraReportConverter," + AssemblyInfo.SRAssemblyReports),
//DXDisplayName(typeof(ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XtraReport", "Report"),
    ]
    public class ProxyReport : ProxyControl
    {
        private readonly XtraReport m_Report;

        public ProxyReport(XtraReport report, Control parentControl)
            : base(report, parentControl)
        {
            m_Report = report;
        }

        [
            Description(
                "Gets a value that specifies which of the default printer's settings should be used when printing an XtraReport."
                ),
            //DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XtraReport.DefaultPrinterSettingsUsing"),
            SRCategory(ReportStringId.CatPageSettings),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        ]
        public PrinterSettingsUsing DefaultPrinterSettingsUsing
        {
            get { return m_Report.DefaultPrinterSettingsUsing; }
        }

        [
            Description("Gets or sets a value indicating whether the page orientation is landscape."),
            //DXDisplayName(typeof(ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XtraReport.Landscape"),
            SRCategory(ReportStringId.CatPageSettings),
            DefaultValue(false),
            TypeConverter(typeof (LandscapeConverter)),
            RefreshProperties(RefreshProperties.All),
        ]
        public bool Landscape
        {
            get { return m_Report.Landscape; }
            set { m_Report.Landscape = value; }
        }

        [
            Description(
                "Gets or sets the width of the report's pages (measured in report units). This can only be set if the XtraReport.PaperKind is set to Custom."
                ),
            //DXDisplayName(typeof(ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XtraReport.PageWidth"),
            SRCategory(ReportStringId.CatPageSettings),
            TypeConverter(typeof (PageSizeConverter)),
            DefaultValue(-1)
        ]
        public int PageWidth
        {
            get { return m_Report.PageWidth; }
            set { m_Report.PageWidth = value; }
        }

        [
            Description(
                "Gets or sets the height of the report's pages (measured in report units). This can only be set if the XtraReport.PaperKind is set to Custom."
                ),
            //DXDisplayName(typeof(ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XtraReport.PageHeight"),
            SRCategory(ReportStringId.CatPageSettings),
            TypeConverter(typeof (PageSizeConverter)),
            DefaultValue(-1)
        ]
        public int PageHeight
        {
            get { return m_Report.PageHeight; }
            set { m_Report.PageHeight = value; }
        }

        [
            Description("Gets or sets a value indicating whether to snap report controls to the grid at design time."),
            //DXDisplayName(typeof(ResFinder), DXDisplayNameAttribute.DefaultResourceFile, "DevExpress.XtraReports.UI.XtraReport.SnapToGrid"),
            DefaultValue(true),
            SRCategory(ReportStringId.CatDesign),
            TypeConverter(typeof (BooleanTypeConverter)),
        ]
        public bool SnapToGrid
        {
            get { return m_Report.SnapToGrid; }
            set { m_Report.SnapToGrid = value; }
        }

        [
            Description("Gets or sets the margins of the report's pages (measured in report units)."),
            // DXDisplayName(typeof (ResFinder), DXDisplayNameAttribute.DefaultResourceFile,"DevExpress.XtraReports.UI.XtraReport.Margins"),
            SRCategory(ReportStringId.CatPageSettings),
            TypeConverter("DevExpress.XtraReports.Design.XRMarginsConverter," + AssemblyInfo.SRAssemblyReports),
            DefaultValue(typeof (Margins), "100, 100, 100, 100"),
        ]
        public Margins Margins
        {
            get { return m_Report.Margins; }
            set { m_Report.Margins = value; }
        }

        [Browsable(false)]
        public override Point Location
        {
            get { return base.Location; }
            set { base.Location = value; }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false)]
        public override Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }
    }
}