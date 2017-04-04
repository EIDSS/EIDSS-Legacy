using System.Windows.Forms;
using eidss.avr.db.Interfaces;

namespace eidss.avr.BaseComponents.Views
{
    public interface IPivotInfoDetailView : IRelatedObjectView
    {
        string CorrectedLayoutName { get; }
        void AddCopyPrefixForLayoutNames();
        void UpdateQueryRefreshDateTime();
        Form ParentForm { get; }
    }
}