using System;
using DevExpress.XtraEditors.Controls;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface ILayoutInfoView : IRelatedObjectView
    {
        event EventHandler<LayoutEventArgs> LayoutSelected;
        event EventHandler<ChangingEventArgs> LayoutSelecting;
        void OnQuerySelected(QueryEventArgs e);
        void SetPivotAccessible(bool visible);
    }
}