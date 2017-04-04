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
            ObjectStorage.Put(ModelUserContext.ClientID, 0, 0, model.Id.ToString(), model);
            return PartialView(model);
        }

        public ActionResult SearchPanelSimple(SearchPanelModel model)
        {
            ObjectStorage.Put(ModelUserContext.ClientID, 0, 0, model.Id.ToString(), model);
            return PartialView(model);
        }

        public ActionResult SearchPanelOperator(string gridName = "Grid")
        {
            ViewBag.spTogglePanel = "spTogglePanel_" + gridName;
            return PartialView();
        }

        [CompressFilter]
        public ActionResult GetLookupSourceNew(string modelGuid, string fieldName, string parameterName = null, long? parameterValue = null,
             string initValue = null)
        {
            //var model = ModelStorage.Get(ModelUserContext.ClientID, 0, modelGuid) as SearchPanelModel;
            return ObjectStorage.Using<SearchPanelModel, ActionResult>(model =>
                {
                    var lookup = model.SearchPanelItems.Single(x => x.Name == fieldName && x.Location != SearchPanelLocation.Combobox);
                    var data = SearchPanelDataExtractor.GetLookup(model.ResultObjectInstance, lookup, parameterName, parameterValue, initValue);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }, ModelUserContext.ClientID, 0, modelGuid);
        }
    }
}
