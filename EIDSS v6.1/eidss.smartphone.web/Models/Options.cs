using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eidss.model.Core;

namespace eidss.smartphone.web.Models
{
    public class Options
    {
        public long idfsRegionDefault { get; set; }
        public long idfsRayonDefault { get; set; }

        public static Options Get()
        {
            return new Options() { idfsRegionDefault = EidssSiteContext.Instance.RegionID, idfsRayonDefault = EidssSiteContext.Instance.RayonID };
        }
    }
}