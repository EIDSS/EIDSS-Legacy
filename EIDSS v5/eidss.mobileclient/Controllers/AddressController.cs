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
    public class AddressController : Controller
    {
        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectRegion(long idfGeoLocation, long idfsCountry)
        {
            var address = (Address)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            address.Country = address.CountryLookup.Where(x => x.idfsCountry == idfsCountry).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.RegionLookup, "idfsRegion", "strRegionName") };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectRayon(long idfGeoLocation, long idfsRegion)
        {
            var address = (Address)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            address.Region = address.RegionLookup.Where(x => x.idfsRegion == idfsRegion).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.RayonLookup, "idfsRayon", "strRayonName") };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectSettlement(long idfGeoLocation, long idfsRayon)
        {
            var address = (Address)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            address.Rayon = address.RayonLookup.Where(x => x.idfsRayon == idfsRayon).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectStreet(long idfGeoLocation, long idfsSettlement)
        {
            var address = (Address)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            address.Settlement = address.SettlementLookup.Where(x => x.idfsSettlement == idfsSettlement).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.StreetLookup, "strStreetName", "strStreetName") };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SelectPostCode(long idfGeoLocation, long idfsSettlement)
        {
            var address = (Address)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            address.Settlement = address.SettlementLookup.Where(x => x.idfsSettlement == idfsSettlement).FirstOrDefault();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.PostCodeLookup, "strPostCode", "strPostCode") };
        }
    }
}
