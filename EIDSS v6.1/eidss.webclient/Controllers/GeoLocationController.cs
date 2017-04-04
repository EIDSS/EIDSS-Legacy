using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using System.Globalization;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class GeoLocationController : Controller
    {
        //
        // GET: /GeoLocation/GeoLocation/

        public ActionResult Details(long root, eidss.model.Schema.GeoLocation location)
        {
            ObjectStorage.Put(ModelUserContext.ClientID, root, location.idfGeoLocation, null, location);
            return PartialView(location);
        }
        
        public ActionResult Coordinates(long root, eidss.model.Schema.GeoLocation location)
        {
            ObjectStorage.Put(ModelUserContext.ClientID, root, location.idfGeoLocation, null, location);
            return PartialView(location);
        }

        public ActionResult InlineGeoLocationPicker(long root, model.Schema.GeoLocation location)
        {
            ObjectStorage.Put(ModelUserContext.ClientID, root, location.idfGeoLocation, null, location);
            IObjectPermissions permission = location.GetPermissions();
            ViewBag.IsReadOnlyForEdit = location.Parent.IsReadOnly("buttonGeoLocationPicker") ? true : (permission == null ? false : permission.IsReadOnlyForEdit);
            return PartialView(location);
        }

        private double parseDouble(string val)
        {
            double ret;
            if (double.TryParse(val, out ret))
                return ret;
            if (double.TryParse(val, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out ret))
                return ret;
            return 0;
        }
        [HttpPost]
        public ActionResult SetFromMap(long idfGeoLocation, string strLatitude, string strLongitude)
        {
            //eidss.model.Schema.GeoLocation location = ModelStorage.Get(ModelUserContext.ClientID, idfGeoLocation, null) as eidss.model.Schema.GeoLocation;
            double dblLatitude = parseDouble(strLatitude);
            double dblLongitude = parseDouble(strLongitude);
            return ObjectStorage.Using<GeoLocation, ActionResult>(location =>
                {
                    using (var clone = location.Clone() as IObject)
                    {
                        location.dblLatitude = dblLatitude;
                        location.dblLongitude = dblLongitude;
                        CompareModel data = location.Compare(clone);
                        return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
                    }
                }, ModelUserContext.ClientID, idfGeoLocation, null);
        }

    }
}
