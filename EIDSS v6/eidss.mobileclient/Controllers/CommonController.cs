using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class CommonController : Controller
    {
        public ActionResult ShowAddress(long root, Address address, bool isCountryFieldVisible = false, bool needFillRegionOnCountryChanged = true)
        {
            ViewBag.IsCountryFieldVisible = isCountryFieldVisible;
            address.blnReadOnlyRegion = !needFillRegionOnCountryChanged;
            ModelStorage.Put(Session.SessionID, root, address.idfGeoLocation, null, address);
            return PartialView(address);
        }

        public ActionResult ShowGeoLocation(long root, GeoLocation geoLocation)
        {
            ModelStorage.Put(Session.SessionID, root, geoLocation.idfGeoLocation, null, geoLocation);
            return PartialView(geoLocation);
        }

        public ActionResult ShowCoordinatesAddress(Address address)
        {
            return PartialView(address);
        }

        public ActionResult ShowCoordinatesGeoLocation(GeoLocation geoLocation)
        {
            return PartialView(geoLocation);
        }
    }
}
