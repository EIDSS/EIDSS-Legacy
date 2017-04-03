using System;
using System.Drawing;
using System.Drawing.Imaging;
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
using eidss.model.Resources;

namespace eidss.avr.ChartForm
{
    public sealed class ChartPresenter : RelatedObjectPresenter
    {
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
                var strChartType = ((DBChartType) type).ToString().Substring(3);
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
            ShowPreview(m_ChartView.PrintingSystem, CreateDetailArea);
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
            var rect = new RectangleF(0, 0, m_ChartView.ChartControl.Width,
                m_ChartView.ChartControl.Height);
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