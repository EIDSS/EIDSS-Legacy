using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.mobileclient.Attributes;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Schema;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class GeoLocationController : Controller
    {
        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectRayon(long idfGeoLocation, long idfsRegion)
        {
            var geoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            geoLocation.Region = geoLocation.RegionLookup.Where(x => x.idfsRegion == idfsRegion).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(geoLocation.RayonLookup, "idfsRayon", "strRayonName") };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectSettlement(long idfGeoLocation, long idfsRayon)
        {
            var geoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            geoLocation.Rayon = geoLocation.RayonLookup.Where(x => x.idfsRayon == idfsRayon).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(geoLocation.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }
    }
}
