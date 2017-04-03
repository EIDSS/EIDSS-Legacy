using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface IRamFormView : IRelatedObjectView
    {
        void OnPivotFieldVisibleChanged(LayoutFieldVisibleChanged e);
        void OnPivotSelected(PivotSelectionEventArgs e);
    }
}