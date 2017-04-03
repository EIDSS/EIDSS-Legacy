using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.webclient.Models;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class SearchController : Controller
    {
        public ActionResult SearchPanelAlternative(SearchPanelModel model)
        {
            if (Session[model.Id.ToString()] == null)
            {
                Session[model.Id.ToString()] = model;
            }
            return PartialView(model);
        }

        public ActionResult SearchPanelSimple(SearchPanelModel model)
        {
            if (Session[model.Id.ToString()] == null)
            {
                Session[model.Id.ToString()] = model;
            }
            return PartialView(model);
        }

        public ActionResult SearchPanelOperator(string gridName = "Grid")
        {
            ViewBag.spTogglePanel = "spTogglePanel_" + gridName;
            return PartialView();
        }

        public ActionResult GetLookupSourceNew(string modelGuid, string fieldName, string parameterName = null, long? parameterValue = null,
             string initValue = null)
        {
            var model = Session[modelGuid] as SearchPanelModel;
            var lookup = model.SearchPanelItems.Single(x => x.Name == fieldName && x.Location != SearchPanelLocation.Combobox);
            var data = SearchPanelDataExtractor.GetLookup(model.ResultObjectInstance, lookup, parameterName, parameterValue, initValue);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
