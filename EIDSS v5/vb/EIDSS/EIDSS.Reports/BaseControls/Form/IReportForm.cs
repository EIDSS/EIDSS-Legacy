using System.Windows.Forms;

namespace EIDSS.Reports.BaseControls.Form
{
    public interface IReportForm
    {
        event FormClosedEventHandler FormClosed;

        void ShowReport(Control reportKeeper);
        void ApplyResources();
        void Close();
    }
}