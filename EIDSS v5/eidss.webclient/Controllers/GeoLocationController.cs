using System.Web.Mvc;
using bv.model.Model.Core;
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

        [HttpPost]
        public ActionResult SelectCountry(long idfGeoLocation)
        {
            eidss.model.Schema.GeoLocation location = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.GeoLocation;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(location.CountryLookup, "idfsCountry", "strCountryName") };
        }

        [HttpPost]
        public ActionResult SelectRegion(long idfGeoLocation)
        {
            eidss.model.Schema.GeoLocation location = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.GeoLocation;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(location.RegionLookup, "idfsRegion", "strRegionName") };
        }

        [HttpPost]
        public ActionResult SelectRayon(long idfGeoLocation)
        {
            eidss.model.Schema.GeoLocation location = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.GeoLocation;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(location.RayonLookup, "idfsRayon", "strRayonName") };
        }

        [HttpPost]
        public ActionResult SelectSettlement(long idfGeoLocation)
        {
            eidss.model.Schema.GeoLocation location = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.GeoLocation;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(location.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }
    }
}
