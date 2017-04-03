using DevExpress.XtraCharts.Native;
using DevExpress.XtraCharts.Web;
using DevExpress.XtraPrinting;
using Page = System.Web.UI.Page;

namespace eidss.ram.web.Components.Export
{
    public class WebChartExporter : WebBaseExporter
    {
        private readonly WebChartControl m_WebChart;

        public WebChartExporter(Page page, WebChartControl webChart) : base(page)
        {
            m_WebChart = webChart;
        }

        protected override string ExporterID
        {
            get { return @"WebChartExporter"; }
        }

        protected override PrintableComponentLink GetPrintableComponentLink()
        {
            m_WebChart.DataBind();
            var componentLink = new PrintableComponentLink
                                    {
                                        Component = ((IChartContainer) m_WebChart).Chart,
                                        Landscape = true
                                    };

            return componentLink;
        }

        protected override Link GetImageLink()
        {
            return new Link() { Landscape = true };
        }
    }
}