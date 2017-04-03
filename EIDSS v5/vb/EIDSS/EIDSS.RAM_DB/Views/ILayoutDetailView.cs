using System;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface ILayoutDetailView : IRelatedObjectView
    {
        event EventHandler<CopyLayoutEventArgs> CopyLayoutCreating;

        

        void OnLayoutSelected(LayoutEventArgs e);
        void OnChangeOrientation(ChartChangeOrientationEventArgs e);
        void ProcessLayoutCommand(LayoutCommand layoutCommand);
        void ProcessReportViewCommand(ReportViewCommand viewCommand);
        void ProcessPrintCommand(PrintCommand printCommand);
        void ProcessRefreshCommand(RefreshCommand refreshCommand);
        
    }
}