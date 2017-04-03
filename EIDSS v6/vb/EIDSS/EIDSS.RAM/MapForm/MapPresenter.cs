using System.Drawing;
using System.Drawing.Imaging;
using DevExpress.XtraPrinting;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.DBService;
using eidss.model.Avr.Commands;
using eidss.model.Resources;

namespace eidss.avr.MapForm
{
    public sealed class MapPresenter : RelatedObjectPresenter
    {
        private readonly IMapView m_MapView;
        private Image m_PrintImage;
        private readonly BaseAvrDbService m_MapFormService;

        public MapPresenter(SharedPresenter sharedPresenter, IMapView view)
            : base(sharedPresenter, view)
        {
            m_MapFormService = new BaseAvrDbService();

            m_MapView = view;
            m_MapView.DBService = MapFormService;
        }

       

        public BaseAvrDbService MapFormService
        {
            get { return m_MapFormService; }
        }

        public void PrintMap(PrintingSystem printingSystem)
        {
            m_PrintImage = GetPrintBitmap();
            ShowPreview(printingSystem, CreateDetailArea);
        }

        public void ExportMap()
        {
            m_PrintImage = GetPrintBitmap();
            string filter = EidssMessages.Get("msgFilterJpg", "Jpeg images|*.jpg");
            ExportTo("jpg", filter, fileName => m_PrintImage.Save(fileName, ImageFormat.Jpeg));
        }

        public override void Process(Command cmd)
        {
            // no operations should be done
        }

        private Bitmap GetPrintBitmap()
        {
            const float mmWidth = 297;
            const float mmHeight = 210;
            const int dpi = 300;
            const float inch = 25.4f;
            const int pixelWidth = (int) ((mmWidth * dpi) / inch);
            const int pixelHeight = (int) ((mmHeight * dpi) / inch);

            var printBitmap = new Bitmap(pixelWidth, pixelHeight);

            Graphics printGraphics = Graphics.FromImage(printBitmap);

            printGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, printBitmap.Width, printBitmap.Height);

            Bitmap mapImage = m_MapView.MapControl.GetMapImage(mmWidth, mmHeight, dpi);

            mapImage.SetResolution(printBitmap.HorizontalResolution, printBitmap.VerticalResolution);

            printGraphics.DrawImage(mapImage, 0, 0);

            return printBitmap;
        }

        private void CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            var imageBrick = new ImageBrick
            {
                Rect = new RectangleF(0, 0, m_PrintImage.Width, m_PrintImage.Height),
                Image = m_PrintImage
            };
            e.Graph.DrawBrick(imageBrick);
        }
    }
}