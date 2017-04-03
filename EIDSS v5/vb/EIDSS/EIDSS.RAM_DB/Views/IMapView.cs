using System;
using System.Data;
using System.Drawing;
using bv.common.Core;
using bv.common.win;
using DevExpress.XtraPrinting;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM_DB.Views
{
    public interface IMapView : IRelatedObjectView
    {
        event EventHandler<ComboBoxEventArgs> InitAdmUnit;
        event EventHandler<EventArgs> RefreshMap;
        string FilterText { get; set;}
        string MapName { get; set;}
        PrintingSystem PrintingSystem { get; }
        object AdmUnitValue { get; }
        void UpdateMap(DataTable dataSource, EventLayerSettings settings, bool isSingle);
        
        Bitmap GetMapImage(double mmWidth, double mmHeight, int dpi);
        EventLayerSettings MapSettings { get;}
        void RaiseInitAdmUnitComboBox();
        
    }
}