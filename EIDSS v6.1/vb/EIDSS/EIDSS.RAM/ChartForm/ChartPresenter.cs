using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using bv.common.Core;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraPrinting;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.DBService;
using eidss.model.Avr.Chart;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;
using eidss.model.AVR.DataBase;
using eidss.model.Resources;

namespace eidss.avr.ChartForm
{
    public sealed class ChartPresenter : RelatedObjectPresenter
    {
        private const int Margin = 50;
        private readonly IChartView m_ChartView;

        private Bitmap m_PrintBitmap;

        public ChartPresenter(SharedPresenter sharedPresenter, IChartView view)
            : base(sharedPresenter, view)
        {
            m_ChartView = view;
            m_ChartView.DBService = new BaseAvrDbService();
        }

        public override void Dispose()
        {
            try
            {
                if (m_PrintBitmap != null)
                {
                    m_PrintBitmap.Dispose();
                    m_PrintBitmap = null;
                }
            }
            finally
            {
                base.Dispose();
            }
        }

        public static ViewType GetChartType(object type)
        {
            try
            {
                string strChartType = ((DBChartType) type).ToString().Substring(3);
                return (ViewType) Enum.Parse(typeof (ViewType), strChartType);
            }
            catch (Exception)
            {
                return ViewType.Line;
            }
        }

        #region  Print Export handlers

        public override void Process(Command cmd)
        {
            // Nothing Here
        }

        public void ExportChart()
        {
            ExportChart(ExportType.Image);
        }

        public void PrintChart(PrintingSystem printingSystem)
        {
            using (var ms = new MemoryStream())
            {
                m_ChartView.ChartControl.ExportToImage(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                m_PrintBitmap = new Bitmap(ms);
            }
            XtraPageSettings settings = m_ChartView.PrintingSystem.PageSettings;
            settings.PaperKind = PaperKind.A4;

            int width = settings.PageSettings.PaperSize.Width - 2 * Margin;
            int height = settings.PageSettings.PaperSize.Height - 2 * Margin;
            bool landscape = m_PrintBitmap.Width > m_PrintBitmap.Height;
            if (landscape)
            {
                int tmp = width;
                width = height;
                height = tmp;
            }

            if ((double) m_PrintBitmap.Width / m_PrintBitmap.Height < (double) width / height)
            {
                var printBitmap = new Bitmap(1 + m_PrintBitmap.Height * width / height, m_PrintBitmap.Height);
                Graphics printGraphics = Graphics.FromImage(printBitmap);
                printGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, printBitmap.Width, printBitmap.Height);
                printGraphics.DrawImage(m_PrintBitmap, 0, 0);
                m_PrintBitmap = printBitmap;
            }

            ShowPreview(m_ChartView.PrintingSystem, CreateDetailArea, landscape, Margin);
        }

        internal void ExportChart(ExportType exportType)
        {
            m_ChartView.ChartControl.OptionsPrint.SizeMode = PrintSizeMode.Zoom;
            switch (exportType)
            {
                case ExportType.Pdf:
                    ExportTo("pdf",
                        EidssMessages.Get("msgFilterPdf", "PDF documents|*.pdf"),
                        m_ChartView.ChartControl.ExportToPdf);

                    break;

                case ExportType.Xls:
                    ExportTo("xls",
                        EidssMessages.Get("msgFilterExcel", "Excel documents|*.xls"),
                        m_ChartView.ChartControl.ExportToXls);
                    break;

                case ExportType.Image:
                    ExportTo("jpg",
                        EidssMessages.Get("msgFilterJpg", "Jpeg images|*.jpg"),
                        ExportToImage);
                    break;

                case ExportType.Html:
                    ExportTo("html",
                        EidssMessages.Get("msgFilterHtml", "HTML documents|*.html"),
                        m_ChartView.ChartControl.ExportToHtml);
                    break;
                default:
                    throw new AvrException("Not supported export type: " + exportType);
            }
        }

        private void CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            var rect = new RectangleF(0, 0, m_PrintBitmap.Width,m_PrintBitmap.Height);
            var imageBrick = new ImageBrick
            {
                Rect = rect,
                Image = m_PrintBitmap
            };
            e.Graph.DrawBrick(imageBrick);
        }

        private void ExportToImage(string fileName)
        {
            m_ChartView.ChartControl.ExportToImage(fileName, ImageFormat.Jpeg);
        }

        #endregion
    }
}