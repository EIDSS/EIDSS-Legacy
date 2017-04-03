using System;
using DevExpress.XtraEditors.Controls;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;

namespace eidss.avr.db.Interfaces
{
    public interface ILayoutInfoView : IRelatedObjectView
    {
        event EventHandler<LayoutEventArgs> LayoutSelected;
        event EventHandler<ChangingEventArgs> LayoutSelecting;
        void OnQuerySelected(QueryEventArgs e);
        void SetPivotAccessible(bool visible);
    }
}