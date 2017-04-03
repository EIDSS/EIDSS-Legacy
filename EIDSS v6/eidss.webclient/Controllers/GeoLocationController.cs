using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class GeoLocationController : Controller
    {
        //
        // GET: /GeoLocation/GeoLocation/

        public ActionResult Details(long root, eidss.model.Schema.GeoLocation location)
        {
            ModelStorage.Put(Session.SessionID, root, location.idfGeoLocation, null, location);
            return PartialView(location);
        }
        
        public ActionResult Coordinates(long root, eidss.model.Schema.GeoLocation location)
        {
            ModelStorage.Put(Session.SessionID, root, location.idfGeoLocation, null, location);
            return PartialView(location);
        }

        public ActionResult InlineGeoLocationPicker(long root, model.Schema.GeoLocation location)
        {
            ModelStorage.Put(Session.SessionID, root, location.idfGeoLocation, null, location);
            IObjectPermissions permission = location.GetPermissions();
            ViewBag.IsReadOnlyForEdit = location.Parent.IsReadOnly("buttonGeoLocationPicker") ? true : (permission == null ? false : permission.IsReadOnlyForEdit);
            return PartialView(location);
        }

        public ActionResult InlineGeoLocationFullPicker(long root, model.Schema.GeoLocation location)
        {
            ModelStorage.Put(Session.SessionID, root, location.idfGeoLocation, null, location);
            IObjectPermissions permission = location.GetPermissions();
            ViewBag.IsReadOnlyForEdit = location.Parent.IsReadOnly("buttonGeoLocationPicker") ? true : (permission == null ? false : permission.IsReadOnlyForEdit);
            return PartialView(location);
        }

        public ActionResult SetFromMap(long idfGeoLocation, double dblLatitude, double dblLongitude)
        {
            eidss.model.Schema.GeoLocation location = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.GeoLocation;
            var clone = location.Clone() as IObject;
            location.dblLatitude = dblLatitude;
            location.dblLongitude = dblLongitude;
            CompareModel data = location.Compare(clone);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

    }
}
