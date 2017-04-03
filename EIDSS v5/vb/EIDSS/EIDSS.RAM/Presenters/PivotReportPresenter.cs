

using System;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Resources;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;



namespace EIDSS.RAM.Presenters
{
    public class PivotReportPresenter : RelatedObjectPresenter
    {
        private readonly IPivotReportView m_PivotReportView;
        private readonly LayoutMediator m_LayoutMediator;

        private readonly Timer m_TimerPrinting;
        //private PivotGridCustomSummaryEventHandler m_PivotGridCustomSummaryCallback;

        public PivotReportPresenter(SharedPresenter sharedPresenter, IPivotReportView view)
            : base(sharedPresenter, view)
        {
            m_TimerPrinting = new Timer {Interval = 200};
            m_TimerPrinting.Tick += TimerPrintingTick;

            m_PivotReportView = view;
            m_PivotReportView.DBService = new BaseRamDbService();

            m_LayoutMediator = new LayoutMediator(this);

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
            m_SharedPresenter.SharedModel.ResetReportDataCallback = OnResetReportDataCallback;
        }

      

        public string GetPivotNameFromDataSource()
        {
             return m_LayoutMediator.LayoutRow.strPivotName; 
            
        }
        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.PivotData:
                    PivotDataEventArgs args = m_SharedPresenter.SharedModel.PivotData;
                    m_PivotReportView.OnPivotDataLoaded(args);
                    break;
                case SharedProperty.FilterText:
                    m_PivotReportView.FilterText = m_SharedPresenter.SharedModel.FilterText;
                    break;
                case SharedProperty.PivotName:
                    m_PivotReportView.PivotName = m_SharedPresenter.SharedModel.PivotName;
                    break;
            }
        }

        private void OnResetReportDataCallback()
        {
            m_PivotReportView.ResetReportData();
        }

        #region Binding

        public void BindPivotName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                                     m_LayoutMediator.LayoutDataSet,
                                     m_LayoutMediator.LayoutTable.TableName,
                                     m_LayoutMediator.LayoutTable.strPivotNameColumn.ColumnName);
        }

        #endregion

        #region  Command handlers

        public override void Process(Command cmd)
        {
            try
            {
                if (cmd is ExportCommand)
                {
                    PrecessExport((ExportCommand) cmd);
                }
                else if (cmd is PrintCommand)
                {
                    ProcessPrint((PrintCommand) cmd);
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

        private void ProcessPrint(PrintCommand printCommand)
        {
            if (printCommand.PrintType != PrintType.Grid)
            {
                return;
            }

            Trace.WriteLine(Trace.Kind.Info, "PivotReportForm.Process(): executing Pivot Grid print command");

            printCommand.State = CommandState.Pending;
            m_PivotReportView.RaiseSendCommand(new RefreshCommand(this, RefreshType.Grid));
            m_PivotReportView.PrintingSystem.PageSettings.Landscape = true;
            m_TimerPrinting.Start();

            printCommand.State = CommandState.Processed;
        }

        private void PrecessExport(ExportCommand exportCommand)
        {
            if (exportCommand.ExportObject != ExportObject.Report)
            {
                return;
            }

            Trace.WriteLine(Trace.Kind.Info,
                            "PivotReportForm.Process(): executing Pivot Grid export command");

            exportCommand.State = CommandState.Pending;
            m_PivotReportView.RaiseSendCommand(new RefreshCommand(this, RefreshType.Grid));
            ExportGrid(exportCommand.ExportType);
            exportCommand.State = CommandState.Processed;
        }

        internal void ExportGrid(ExportType exportType)
        {
            ExportDelegate exportDelegate = m_PivotReportView.GetExportDelegate(exportType);
            switch (exportType)
            {
                case ExportType.PDF:
                    ExportTo("pdf",
                             EidssMessages.Get("msgFilterPdf", "PDF documents|*.pdf"),
                             exportDelegate);
                    break;

                case ExportType.XLS:
                    ExportTo("xls",
                             EidssMessages.Get("msgFilterExcel", "Excel documents|*.xls"),
                             exportDelegate);
                    break;

                case ExportType.RTF:
                    ExportTo("rtf",
                             EidssMessages.Get("msgFilterRtf", "Rich text documents|*.rtf"),
                             exportDelegate);
                    break;

                case ExportType.Html:
                    ExportTo("html",
                             EidssMessages.Get("msgFilterHtml", "HTML documents|*.html"),
                             exportDelegate);
                    break;
                case ExportType.Image:
                    ExportTo("jpg",
                             EidssMessages.Get("msgFilterJpg", "Jpeg images|*.jpg"),
                             exportDelegate);
                    break;
                default:
                    throw new RamException("Not supported export type: " + exportType);
            }
        }

        private void TimerPrintingTick(object sender, EventArgs e)
        {
            if (Utils.IsCalledFromUnitTest())
            {
                m_TimerPrinting.Stop();
                return;
            }

            if (m_PivotReportView.PrintingSystem.Document.IsCreating)
                return;

            m_TimerPrinting.Stop();

            ReportPrintTool printTool = m_PivotReportView.ReportPrintTool;
            if (printTool.PreviewForm == null)
                throw new RamException("PreviewForm of ReportPrintTool is not initialized");
            if (printTool.PreviewForm.PrintBarManager == null)
                throw new RamException("PrintBarManager of PreviewForm of ReportPrintTool is not initialized");
            
            if (printTool.PreviewForm.Visible)
            {
                printTool.PreviewForm.BringToFront();
                return;
            }
            RamPrintingLink.Init(printTool.PreviewForm.PrintBarManager);
            m_PivotReportView.PrintingSystem.PageSettings.Landscape = true;
            m_PivotReportView.PrintingSystem.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
            printTool.PreviewForm.Show();
        }

        #endregion
    }
}