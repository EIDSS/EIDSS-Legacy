using System.Web.Mvc;
using System.Configuration;
using bv.common.Configuration;
using eidss.webclient.Utils;
using eidss.model.Core;
using System.Data.SqlClient;
using eidss.gis;
using eidss.gis.common;

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

            if (llat == 0 && llon == 0)
            {
                using (var sqlConnection = new SqlConnection(connectionCredentials.ConnectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        var CountryID = EidssSiteContext.Instance.CountryID; 
                        SharpMap.Geometries.Geometry feature = Extents.GetGeomById(sqlConnection, "gisWKBCountry", CountryID);
                        if (feature != null) { feature = DotSpatial.Projections.GeometryTransform.TransformGeometry(feature, GIS_V4.Common.CoordinateSystems.SphericalMercatorCS, GIS_V4.Common.CoordinateSystems.WGS84); }
                        SharpMap.Geometries.Point center_point = feature.GetBoundingBox().GetCentroid();
                        llon = center_point.X;
                        llat = center_point.Y;
                    }
                    catch (System.Exception) {}
                }
            }
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
