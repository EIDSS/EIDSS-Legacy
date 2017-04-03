using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class AddressController : Controller
    {
        //[HttpGet]
        public ActionResult Address(long root, model.Schema.Address address, bool isCountryFieldVisible = false, bool isForeignAddressFieldVisible = false,
            bool needFillRegionOnCountryChanged = true, bool isCoordinatesFieldsVisible = false)
        {
            ViewBag.IsCountryFieldVisible = isCountryFieldVisible;
            ViewBag.IsForeignAddressFieldVisible = isForeignAddressFieldVisible;
            ViewBag.IsForeignAddressFieldVisibleCss = isForeignAddressFieldVisible ? (address.blnForeignAddress ? "foreignAddressFieldInvisible invisible" : "foreignAddressFieldInvisible") : "foreignAddressFieldVisible";
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            address.blnReadOnlyRegion = isCountryFieldVisible && !needFillRegionOnCountryChanged;
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        public ActionResult AddressInTwoColumns(long root, model.Schema.Address address, bool isCountryFieldVisible = false, bool isForeignAddressFieldVisible = false,
            bool needFillRegionOnCountryChanged = true, bool isCoordinatesFieldsVisible = false)
        {
            ViewBag.IsCountryFieldVisible = isCountryFieldVisible;
            ViewBag.IsForeignAddressFieldVisible = isForeignAddressFieldVisible;
            ViewBag.IsForeignAddressFieldVisibleCss = isForeignAddressFieldVisible ? (address.blnForeignAddress ? "foreignAddressFieldInvisible invisible" : "foreignAddressFieldInvisible") : "foreignAddressFieldVisible";
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            address.blnReadOnlyRegion = isCountryFieldVisible && !needFillRegionOnCountryChanged;
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        public ActionResult AddressWithCountry(long root, model.Schema.Address address)
        {
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        public ActionResult ReadOnlyAddress(long root, model.Schema.Address address)
        {
            return PartialView(address);
        }

    }
}
