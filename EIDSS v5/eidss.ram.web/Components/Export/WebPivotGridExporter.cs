using System.Web.UI;
using DevExpress.Utils;
using DevExpress.Web.ASPxPivotGrid.Export;
using DevExpress.XtraPrinting;
using Page = System.Web.UI.Page;

namespace eidss.ram.web.Components.Export
{
    public sealed class WebPivotGridExporter : WebBaseExporter
    {
        private readonly WebPivotGrid m_PivotGrid;

        public WebPivotGridExporter(Page page, WebPivotGrid pivotGrid) : base(page)
        {
            m_PivotGrid = pivotGrid;
        }

        protected override string ExporterID
        {
            get { return @"WebPivotGridExporter"; }
        }

        protected override PrintableComponentLink GetPrintableComponentLink()
        {
            var pivotLink = new PrintableComponentLink {Component = PivotGridExporterControl, Landscape = true};
            return pivotLink;
        }
        protected override Link GetImageLink()
        {
            return new Link() { Landscape = true };
        }

        private ASPxPivotGridExporter PivotGridExporterControl
        {
            get
            {
                ASPxPivotGridExporter exporter = null;

                foreach (Control control in Page.Controls)
                {
                    if ((control.ID == ExporterID) && (control is ASPxPivotGridExporter))
                    {
                        exporter = (ASPxPivotGridExporter) control;
                        break;
                    }
                }
                if (exporter == null)
                {
                    exporter = new ASPxPivotGridExporter {ID = ExporterID, ASPxPivotGridID = m_PivotGrid.ID,};

                    Page.Controls.Add(exporter);
                    exporter.OptionsPrint.PrintHeadersOnEveryPage = true;
                    exporter.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
                    exporter.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
                    exporter.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
                    exporter.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;
                }
                return exporter;
            }
        }
    }
}