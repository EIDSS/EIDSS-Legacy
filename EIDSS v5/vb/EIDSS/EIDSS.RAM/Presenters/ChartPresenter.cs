using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using eidss.model.Resources;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;

namespace EIDSS.RAM.Presenters
{
    public class ChartPresenter : RelatedObjectPresenter
    {
        private readonly IChartView m_ChartView;
        private readonly LayoutMediator m_LayoutMediator;
        private Bitmap m_PrintBitmap;

        public ChartPresenter(SharedPresenter sharedPresenter, IChartView view)
            : base(sharedPresenter, view)
        {
            m_ChartView = view;
            m_ChartView.DBService = new BaseRamDbService();
            m_LayoutMediator = new LayoutMediator(this);

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
            m_ChartView.ChangeOrientation += ChartView_ChangeOrientation;
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.FilterText:
                    m_ChartView.FilterText = m_SharedPresenter.SharedModel.FilterText;
                    break;
                case SharedProperty.ChartName:
                    m_ChartView.ChartName = m_SharedPresenter.SharedModel.ChartName;
                    break;
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

        private void ChartView_ChangeOrientation(ChartChangeOrientationEventArgs e)
        {
            m_SharedPresenter.SharedModel.ChartDataVertical = e.Vertical;
        }

        #region Binding

        public void BindChartName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                                     m_LayoutMediator.LayoutDataSet,
                                     m_LayoutMediator.LayoutTable.TableName,
                                     m_LayoutMediator.LayoutTable.strChartNameColumn.ColumnName);
        }

//        public void BindChartFilter(TextEdit edit)
//        {
//            BindingHelper.BindEditor(edit,
//                                     m_LayoutMediator.LayoutDataSet,
//                                     m_LayoutMediator.LayoutTable.TableName,
//                                     m_LayoutMediator.LayoutTable.strDescriptionColumn.ColumnName);
//        }

        public void BindShowXLabels(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                                        m_LayoutMediator.LayoutDataSet,
                                        m_LayoutMediator.LayoutTable.TableName,
                                        m_LayoutMediator.LayoutTable.blnShowXLabelsColumn.ColumnName);
        }

        public void BindPivotAxis(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                                        m_LayoutMediator.LayoutDataSet,
                                        m_LayoutMediator.LayoutTable.TableName,
                                        m_LayoutMediator.LayoutTable.blnPivotAxisColumn.ColumnName);
        }

        public void BindShowPointLabels(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                                        m_LayoutMediator.LayoutDataSet,
                                        m_LayoutMediator.LayoutTable.TableName,
                                        m_LayoutMediator.LayoutTable.blnShowPointLabelsColumn.ColumnName);
        }

        internal void BindChartType(LookUpEdit comboBox)
        {
            BindingHelper.BindCombobox(comboBox,
                                       m_LayoutMediator.LayoutDataSet,
                                       m_LayoutMediator.LayoutTable.TableName,
                                       m_LayoutMediator.LayoutTable.idfsChartTypeColumn.ColumnName,
                                       BaseReferenceType.rftChart,
                                       (long) DBChartType.chrBar);
        }

        #endregion

        #region  Command handlers

        public override void Process(Command cmd)
        {
            try
            {
                if (cmd is PrintCommand)
                {
                    ProcessPrint((PrintCommand) cmd);
                }
                else if (cmd is ExportCommand)
                {
                    ProcessExport((ExportCommand) cmd);
                }
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

        private void ProcessExport(ExportCommand exportCommand)
        {
            if (exportCommand.ExportObject != ExportObject.Chart)
            {
                return;
            }

            Trace.WriteLine(Trace.Kind.Info, "ChartForm.Process(): executing Chart export command");
            exportCommand.State = CommandState.Pending;
            m_ChartView.RaiseSendCommand(new RefreshCommand(this, RefreshType.Chart));
            ExportChart(exportCommand.ExportType);
            exportCommand.State = CommandState.Processed;
        }

        private void ProcessPrint(PrintCommand printCommand)
        {
            if (printCommand.PrintType != PrintType.Chart)
            {
                return;
            }
            Trace.WriteLine(Trace.Kind.Info, "ChartForm.Process(): executing Chart print command");

            printCommand.State = CommandState.Pending;
            m_ChartView.RaiseSendCommand(new RefreshCommand(this, RefreshType.Chart));

            using (var ms = new MemoryStream())
            {
                m_ChartView.ChartControl.ExportToImage(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                m_PrintBitmap = new Bitmap(ms);
            }
            ShowPreview(m_ChartView.PrintingSystem, CreateDetailArea);
            printCommand.State = CommandState.Processed;
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

        internal void ExportChart(ExportType exportType)
        {
            m_ChartView.ChartControl.OptionsPrint.SizeMode = PrintSizeMode.Zoom;
            switch (exportType)
            {
                case ExportType.PDF:
                    ExportTo("pdf",
                             EidssMessages.Get("msgFilterPdf", "PDF documents|*.pdf"),
                             m_ChartView.ChartControl.ExportToPdf);

                    break;

                case ExportType.XLS:
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
                    throw new RamException("Not supported export type: " + exportType);
            }
        }

        private void ExportToImage(string fileName)
        {
            m_ChartView.ChartControl.ExportToImage(fileName, ImageFormat.Jpeg);
        }

        #endregion
    }
}