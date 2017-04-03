using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface IPivotReportView : IRelatedObjectView
    {
        string FilterText { get; set;}
        string PivotName{ get; set;}
        PrintingSystemBase PrintingSystem { get; }
        ReportPrintTool ReportPrintTool { get; }
        ExportDelegate GetExportDelegate(ExportType exportType);
        void RaiseSendCommand(Command command);
        void OnPivotDataLoaded(PivotDataEventArgs e);
        void ResetReportData();
    }
}