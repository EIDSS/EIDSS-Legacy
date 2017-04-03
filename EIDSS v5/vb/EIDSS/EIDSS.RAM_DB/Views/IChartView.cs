using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface IChartView : IRelatedObjectView
    {
        event ChangeOrientationEventHandler ChangeOrientation;
        string FilterText { get; set;}
        ChartControl ChartControl { get; }
        PrintingSystem PrintingSystem { get; }
        string ChartName { get; set;}
        void RaiseSendCommand(Command command);
    }
}