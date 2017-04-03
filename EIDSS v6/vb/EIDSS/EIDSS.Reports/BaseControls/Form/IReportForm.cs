using System.Windows.Forms;

namespace EIDSS.Reports.BaseControls.Form
{
    public interface IReportForm
    {
        event FormClosedEventHandler FormClosed;

        string Text { get; set; }

        void ShowReport(Control reportKeeper);
        void ApplyResources();
        
        void Close();
    }
}