using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using eidss.model.Resources;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using Convert = BLToolkit.Common.Convert;

namespace EIDSS.RAM.Presenters
{
    public class MapPresenter : RelatedObjectPresenter
    {
        private readonly IMapView m_MapView;
        private Image m_PrintImage;
        private readonly BaseRamDbService m_MapFormService;
        private readonly LayoutMediator m_LayoutMediator;

        public MapPresenter(SharedPresenter sharedPresenter, IMapView view)
            : base(sharedPresenter, view)
        {
            m_MapFormService = new BaseRamDbService();
            m_LayoutMediator = new LayoutMediator(this);

            m_MapView = view;
            m_MapView.DBService = MapFormService;

            m_MapView.InitAdmUnit += View_InitAdmUnit;
            m_MapView.RefreshMap += View_RefreshMap;
            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.FilterText:
                    m_MapView.FilterText = m_SharedPresenter.SharedModel.FilterText;
                    break;
                case SharedProperty.MapName:
                    m_MapView.MapName = m_SharedPresenter.SharedModel.MapName;
                    break;
            }
        }

        public BaseRamDbService MapFormService
        {
            get { return m_MapFormService; }
        }

        public bool MapHasChanges
        {
            get { return m_SharedPresenter.SharedModel.MapHasChanges; }
            set { m_SharedPresenter.SharedModel.MapHasChanges = value; }
        }

       

        private void View_InitAdmUnit(object sender, ComboBoxEventArgs e)
        {
            m_SharedPresenter.BindAdmUnitComboBox(e);
        }

        private void View_RefreshMap(object sender, EventArgs e)
        {
            if (Utils.IsEmpty(m_MapView.AdmUnitValue))
            {
                throw new RamException("Map field name is empty");
            }

            string fieldAlias = Utils.Str(m_MapView.AdmUnitValue);
            bool isSingle;
            DataTable dataSource = m_SharedPresenter.SharedModel.GetMapDataTable(fieldAlias, out isSingle);

            var mapSettings = new EventLayerSettings();
            if (!m_LayoutMediator.LayoutRow.IsintGisLayerPositionNull())
            {
                mapSettings.Position = m_LayoutMediator.LayoutRow.intGisLayerPosition;
            }
            if (!m_LayoutMediator.LayoutRow.IsstrGisLayerSettingsNull())
            {
                mapSettings.LayerSettings = Convert.ToXmlDocument(m_LayoutMediator.LayoutRow.strGisLayerSettings);
            }
            if (!m_LayoutMediator.LayoutRow.IsstrGisMapSettingsNull())
            {
                mapSettings.MapSettings = Convert.ToXmlDocument(m_LayoutMediator.LayoutRow.strGisMapSettings);
            }
           

            m_MapView.UpdateMap(dataSource, mapSettings, isSingle);
        }

        #region Binding

        public void BindMapName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                                     m_LayoutMediator.LayoutDataSet,
                                     m_LayoutMediator.LayoutTable.TableName,
                                     m_LayoutMediator.LayoutTable.strMapNameColumn.ColumnName);
        }

        #endregion

        #region  Command handlers

        public override void Process(Command cmd)
        {
            try
            {
                ProcessMapSettings(cmd);

                ProcessPrintExport(cmd);
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        private void ProcessMapSettings(Command cmd)
        {
            if (!((cmd is RefreshCommand) && ((RefreshCommand) cmd).RefreshType == RefreshType.MapSettings))
            {
                return;
            }

            cmd.State = CommandState.Pending;
            EventLayerSettings mapSettings = m_MapView.MapSettings;
            if (mapSettings != null)
            {
                m_LayoutMediator.LayoutRow.intGisLayerPosition = mapSettings.Position;
                m_LayoutMediator.LayoutRow.strGisLayerSettings = Utils.IsEmpty(mapSettings.LayerSettings)
                                                                     ? string.Empty
                                                                     : Convert.ToString(mapSettings.LayerSettings);

                m_LayoutMediator.LayoutRow.strGisMapSettings = Utils.IsEmpty(mapSettings.MapSettings)
                                                                   ? string.Empty
                                                                   : Convert.ToString(mapSettings.MapSettings);
            }

            cmd.State = CommandState.Processed;
        }

        public void ProcessPrintExport(Command cmd)
        {
            if ((!(cmd is PrintCommand)) && (!(cmd is ExportCommand)))
            {
                return;
            }

            if (cmd is PrintCommand && ((PrintCommand) cmd).PrintType != PrintType.Map)
            {
                return;
            }
            if (cmd is ExportCommand &&
                (((ExportCommand) cmd).ExportType != ExportType.Image ||
                 ((ExportCommand) cmd).ExportObject != ExportObject.Map))
            {
                return;
            }

            Trace.WriteLine(Trace.Kind.Info, "MapForm.Process(): executing map print command");
            cmd.State = CommandState.Pending;

            if (m_MapView.AdmUnitValue == null)
            {
                m_MapView.RaiseInitAdmUnitComboBox();
            }
            View_RefreshMap(this, EventArgs.Empty);

            m_PrintImage = GetPrintBitmap();
            if (cmd is PrintCommand)
            {
                ShowPreview(m_MapView.PrintingSystem, CreateDetailArea);
            }
            if (cmd is ExportCommand)
            {
                ExportTo("jpg",
                         EidssMessages.Get("msgFilterJpg", "Jpeg images|*.jpg"),
                         fileName => m_PrintImage.Save(fileName, ImageFormat.Jpeg));
            }
            cmd.State = CommandState.Processed;
        }

        private Bitmap GetPrintBitmap()
        {
            const float mmWidth = 297;
            const float mmHeight = 210;
            const int dpi = 300;
            const float inch = 25.4f;
            const int pixelWidth = (int) ((mmWidth * dpi) / inch);
            const int pixelHeight = (int) ((mmHeight * dpi) / inch);

            var fontBitmap = new Bitmap(pixelWidth, 1);
            Graphics fontGraphics = Graphics.FromImage(fontBitmap);

            var font = new Font(BaseSettings.SystemFontName, 40);
            SizeF headerSize = fontGraphics.MeasureString(m_MapView.MapName, font, pixelWidth);
            SizeF filterSize = fontGraphics.MeasureString(m_MapView.FilterText, font, pixelWidth);

            var printBitmap = new Bitmap(pixelWidth, pixelHeight);
            
            Graphics printGraphics = Graphics.FromImage(printBitmap);

          //  printBitmap.HorizontalResolution = printGraphics.

            printGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, printBitmap.Width, printBitmap.Height);

            var strFormat = new StringFormat {Alignment = StringAlignment.Center};

            var mmTextHeight = (int) ((inch * (filterSize.Height + headerSize.Height)) / dpi);

            if (mmTextHeight < mmHeight)
            {
                printGraphics.DrawString(m_MapView.MapName, font, Brushes.Black,
                                         new RectangleF(0, 0, pixelWidth, pixelHeight), strFormat);
                printGraphics.DrawString(m_MapView.FilterText, font, Brushes.Black,
                                         new RectangleF(0, headerSize.Height, pixelWidth, pixelHeight), strFormat);
                Bitmap mapImage = m_MapView.GetMapImage(mmWidth, mmHeight - mmTextHeight, dpi);

                mapImage.SetResolution(printBitmap.HorizontalResolution, printBitmap.VerticalResolution);

                printGraphics.DrawImage(mapImage, 0, filterSize.Height + headerSize.Height);
            }
            else
            {
                string error = EidssMessages.Get("msgRamMapHeaderTooBig",
                                                 @"Header and filter are too big. Please change them and try again.");
                printGraphics.DrawString(error, font, Brushes.Black, new RectangleF(0, 0, pixelWidth, pixelHeight),
                                         strFormat);
            }

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

        #endregion
    }
}