using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.webclient.Utils;

namespace eidss.webclient.Areas.Address.Controllers
{
    public class AddressController : Controller
    {
        //[HttpGet]
        public ActionResult ShowAddress(long root, model.Schema.Address address, bool isCountryFieldVisible = false, bool isForeignAddressFieldVisible = false,
            bool needFillRegionOnCountryChanged = true, bool isCoordinatesFieldsVisible = false)
        {
            ViewBag.IsCountryFieldVisible = isCountryFieldVisible;
            ViewBag.IsForeignAddressFieldVisible = isForeignAddressFieldVisible;
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            address.blnReadOnlyRegion = isCountryFieldVisible && !needFillRegionOnCountryChanged;
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        public ActionResult ShowAddressInTwoColumns(long root, model.Schema.Address address, bool countryIsVisible = false)
        {
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            ViewBag.IsCountryFieldVisible = countryIsVisible;
            return PartialView(address);
        }

        public ActionResult ShowAddressWithCountry(long root, model.Schema.Address address)
        {
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        public ActionResult ShowReadOnlyAddress(long root, model.Schema.Address address)
        {
            return PartialView(address);
        }

        public ActionResult ShowInlineAddressPicker(long root, model.Schema.Address address)
        {
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        [HttpPost]
        public ActionResult SelectRegion(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.RegionLookup, "idfsRegion", "strRegionName") };
        }

        [HttpPost]
        public ActionResult SelectRayon(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.RayonLookup, "idfsRayon", "strRayonName") };
        }

        [HttpPost]
        public ActionResult SelectSettlement(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }

        [HttpPost]
        public ActionResult SelectStreet(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.StreetLookup, "strStreetName", "strStreetName") };
        }

        [HttpPost]
        public ActionResult SelectPostCode(long idfGeoLocation)
        {
            eidss.model.Schema.Address address = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as eidss.model.Schema.Address;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(address.PostCodeLookup, "strPostCode", "strPostCode") };
        }
    }
}
