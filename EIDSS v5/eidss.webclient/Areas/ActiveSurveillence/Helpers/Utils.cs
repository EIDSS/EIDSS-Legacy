using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eidss.model.Schema;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.model.Enums;

namespace eidss.webclient.Areas.ActiveSurveillence.Helpers
{
    public static class Utils
    {
        public static Dictionary<string, object> GetSpeciesListDictionarySessionChildRefresh(AsSession session, long idfFarm, string strFarmCode, string prefix)
        {
            SelectList species = null;
            var sessionSpecies = session.ASSpecies.Where(s => s.idfFarm == idfFarm && !s.IsMarkedToDelete);

            if (session.Diseases.Count(x => x.idfsSpeciesType.HasValue && !x.IsMarkedToDelete) > 0 && session.Diseases.Count(x => !x.IsMarkedToDelete && !x.idfsSpeciesType.HasValue) == 0)
            {
                species = new SelectList(
                   sessionSpecies.Join(session.Diseases, x => x.idfsReference, y => y.idfsSpeciesType, (x, y) => new { id = x.idfSpecies, name = x.DisplayName }),
                   "id",
                   "name"
                );
            }
            else
                species = new SelectList(sessionSpecies, "idfSpecies", "DisplayName");

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add(prefix + "idfFarm", idfFarm);
            data.Add(prefix + "strFarmCode", strFarmCode);
            data.Add(prefix + "idfSpecies", species);

            return data;
        }
    }
}