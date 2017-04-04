using DevExpress.XtraEditors;
using eidss.avr.db.Interfaces;
using eidss.gis.Forms;

namespace eidss.avr.BaseComponents.Views
{
    public interface IMapView : IRelatedObjectView
    {
        LookUpEdit AdministrativeUnit { get; }
        AvrMapControl MapControl { get; }
    }
}