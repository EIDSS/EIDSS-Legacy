using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands;

namespace eidss.avr.BaseComponents.Views
{
    public interface IChartView : IRelatedObjectView
    {
        ChartControl ChartControl { get; }
        PrintingSystem PrintingSystem { get; }
        string ChartName { get; set; }
        void RaiseSendCommand(Command command);
    }
}