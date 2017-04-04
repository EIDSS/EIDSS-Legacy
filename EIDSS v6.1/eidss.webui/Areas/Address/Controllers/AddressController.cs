using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eidss.webui.Utils;

namespace eidss.webui.Areas.Address.Controllers
{
    public class AddressController : Controller
    {
        //[HttpGet]
        public ActionResult ShowAddress(long root, eidss.model.Schema.Address address)
        {
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, address);
            return PartialView(address);
        }


        [HttpPost]
        public ActionResult SelectRegion(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.RegionLookup, "idfsRegion", "strRegionName") };
        }
        [HttpPost]
        public ActionResult SelectRayon(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.RayonLookup, "idfsRayon", "strRayonName") };
        }
        [HttpPost]
        public ActionResult SelectSettlement(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }
        [HttpPost]
        public ActionResult SelectStreet(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.StreetLookup, "strStreetName", "strStreetName") };
        }
        [HttpPost]
        public ActionResult SelectPostCode(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.PostCodeLookup, "strPostCode", "strPostCode") };
        }

    }
}
