using System.Web.Mvc;
using System.Configuration;
using bv.common.Configuration;
using bv.common.db.Core;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class MapController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }
        [HttpGet]
        public ActionResult Get(double? lat, double? lon, long? region, long? rayon, long? settlement)
        {
            double llat = 0, llon = 0;
            var connectionCredentials = new ConnectionCredentials();
            gis.common.CoordinatesUtils.GetRegionCoordinates(connectionCredentials.ConnectionString, out llon, out llat, region, rayon, settlement);
            if (lat.HasValue && lat != null) { llat = lat.Value; }
            if (lon.HasValue && lon != null) { llon = lon.Value; }
            return View(new eidss.webclient.Models.VetMap() { m_VetLat = llat, m_VetLon = llon });
        }

        public ActionResult InfoMap(double? lat, double? lon)
        {
            double llat = 0, llon = 0;
            if (lat.HasValue && lat != null) { llat = lat.Value; }
            if (lon.HasValue && lon != null) { llon = lon.Value; }

            return View(new eidss.webclient.Models.InfoMap(llon, llat));
        }

    }
}
