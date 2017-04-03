using System.Drawing;
using DevExpress.XtraPrinting;
using Page = System.Web.UI.Page;

namespace eidss.ram.web.Components.Export
{
    public class WebMapExporter : WebBaseExporter
    {
        public WebMapExporter(Page page) : base(page)
        {
        }

        public Image ImageToExport { get; set; }

        protected override string ExporterID
        {
            get { return @"WebMapExporter"; }
        }

        protected override PrintableComponentLink GetPrintableComponentLink()
        {
            return new PrintableComponentLink {Landscape = true};
        }

        protected override Link GetImageLink()
        {
            var link = new Link {Landscape = true};

            if (ImageToExport != null)
            {
                var imgRect = new RectangleF(0, 0, ImageToExport.Width, ImageToExport.Height);
                link.CreateDetailArea +=
                    delegate(object o, CreateAreaEventArgs args)
                        {
                            args.Graph.DrawString("xx", Color.Black, imgRect, BorderSide.None);

                            args.Graph.DrawImage(ImageToExport, imgRect);
                        };
            }

            return link;
        }
    }
}