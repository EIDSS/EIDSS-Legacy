using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Page = System.Web.UI.Page;

namespace eidss.ram.web.Components.Export
{
    public abstract class WebBaseExporter
    {
        protected delegate void ExportDelegate(CompositeLink compositeLink, string fileName, bool saveAsFile);

        private readonly Page m_Page;

        protected WebBaseExporter(Page page)
        {
            m_Page = page;
        }

        protected Page Page
        {
            get { return m_Page; }
        }

        protected abstract string ExporterID { get; }

        protected abstract PrintableComponentLink GetPrintableComponentLink();
        protected abstract Link GetImageLink();

        public void Export(WebExportFormat exportFormat, string fileName, List<string> headers, bool saveAs)
        {
            switch (exportFormat)
            {
                case WebExportFormat.Pdf:
                    SaveFile(ExportToPdf, fileName, headers, saveAs);
                    break;
                case WebExportFormat.Xls:
                    SaveFile(ExportToXls, fileName, headers, saveAs);
                    break;
                case WebExportFormat.Rtf:
                    SaveFile(ExportToRtf, fileName, headers, saveAs);
                    break;
                case WebExportFormat.Html:
                    SaveFile(ExportToHtml, fileName, headers, saveAs);
                    break;
                case WebExportFormat.Jpeg:
                    SaveFile(ExportToJpeg, fileName, headers, saveAs);
                    break;
            }
        }

        private void ExportToPdf(CompositeLink compositeLink, string fileName, bool saveAsFile)
        {
            using (var stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToPdf(stream);
                WriteFileToResponse(Page, stream, fileName, saveAsFile, "pdf", "application/pdf");
            }
        }

        private void ExportToXls(CompositeLink compositeLink, string fileName, bool saveAsFile)
        {
            using (var stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToXls(stream);
                WriteFileToResponse(Page, stream, fileName, saveAsFile, "xls", "application/ms-excel");
            }
        }

        private void ExportToRtf(CompositeLink compositeLink, string fileName, bool saveAsFile)
        {
            using (var stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToRtf(stream);
                WriteFileToResponse(Page, stream, fileName, saveAsFile, "rtf", "text/enriched");
            }
        }

        private void ExportToHtml(CompositeLink compositeLink, string fileName, bool saveAsFile)
        {
            using (var stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToHtml(stream);
                WriteFileToResponse(Page, stream, fileName, saveAsFile, "htm", "text/html");
            }
        }

        private void ExportToJpeg(CompositeLink compositeLink, string fileName, bool saveAsFile)
        {
            using (var stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToImage(stream, ImageFormat.Jpeg);
                WriteFileToResponse(Page, stream, fileName, saveAsFile, "jpg", "image/jpeg");
            }
        }

        public static void WriteFileToResponse
            (Page page, MemoryStream stream, string fileName, bool saveAsFile, string fileFormat, string contentType)
        {
            HttpResponse response = GetResponse(page);
            if (response == null)
            {
                return;
            }
            response.Clear();
            response.Buffer = false;
            response.AppendHeader("Content-Type", contentType);
            response.AppendHeader("Content-Transfer-Encoding", "binary");

            string contentDisposition = saveAsFile ? "attachment" : "inline";
            string encodedFilename = HttpUtility.UrlEncode(fileName).Replace("+", "%20");
            string headerValue = string.Format("{0}; filename={1}.{2}", contentDisposition, encodedFilename, fileFormat);
            response.AppendHeader("Content-Disposition",headerValue);

            if (stream.Length > 0)
            {
                response.BinaryWrite(stream.ToArray());
            }
            response.End();
        }

        public static HttpResponse GetResponse(Page page)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Response;
            }
            if (page != null)
            {
                return page.Response;
            }
            return null;
        }

        private void SaveFile(ExportDelegate export, string fileName, IEnumerable<string> headers, bool saveAsFile)
        {
            //  string fileName = PivotGrid.DataSource.TableName;
            using (var printingSystem = new PrintingSystem())
            {
                printingSystem.ExportOptions.Pdf.DocumentOptions.Author = @"EIDSS";
                printingSystem.ExportOptions.Html.CharacterSet = @"utf-8";

                PrintableComponentLink componentLink = GetPrintableComponentLink();
                Link imageLink = GetImageLink();

                var headerLinks = new List<Link>();
                foreach (string header in headers)
                {
                    var link = new Link();
                    string localHeader = header;
                    link.CreateDetailArea +=
                        (o, args) => args.Graph.DrawString(localHeader, Color.Black, new RectangleF(0, 0, 400, 40), BorderSide.None);
                    headerLinks.Add(link);
                }

                var compositeLink = new CompositeLink {PrintingSystem = printingSystem};
                foreach (Link link in headerLinks)
                {
                    compositeLink.Links.Add(link);
                }
                compositeLink.Links.Add(componentLink);
                compositeLink.Links.Add(imageLink);
                compositeLink.Landscape = componentLink.Landscape;

                compositeLink.CreateDocument();

                export(compositeLink, fileName, saveAsFile);
            }
        }
    }
}