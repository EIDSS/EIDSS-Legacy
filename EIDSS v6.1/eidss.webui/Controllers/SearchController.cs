using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.webui.Utils;

namespace eidss.webui.Controllers
{
    public class SearchController : Controller
    {
        private const string MODEL_STORAGE = "ModelSessionStorage";

        #region Adjavant methods
        private SearchPanelMetaItem GetCurrentItem(string fieldName, bool comboPanelOnly = false)
        {
            if (Session[MODEL_STORAGE] == null)
                return null;

            IObjectMeta obj = (IObjectMeta)Session[MODEL_STORAGE];

            return obj.SearchPanelMeta.Where(x => x.Name == fieldName && (!comboPanelOnly || x.Location == SearchPanelLocation.Combobox)).FirstOrDefault();

        }

        private IEnumerable<SelectListItem> GetCurrentLookupSource(string valueFieldName, string parameterName = null, long? parameterValue = null)
        {
            var item = GetCurrentItem(valueFieldName);

            if (item != null)
                if (item.EditorType == EditorType.Lookup)
                    return SearchPanelHelper.GetLookup((IObjectCreator)Session[MODEL_STORAGE], item, parameterName, parameterValue);

            return null;
        }

        #endregion

        [HttpPost]
        public ActionResult GetLookupSource(string valueFieldName, string parameterName = null, string parameterValue = null, string initValue = null)
        {
            if (valueFieldName == null)
                return new JsonResult { Data = new List<SelectListItem> { new SelectListItem { Text = "test" } } };

            long paramVal = 0;

            var selectList = long.TryParse(parameterValue, out paramVal) ? GetCurrentLookupSource(valueFieldName, parameterName, paramVal) : GetCurrentLookupSource(valueFieldName);
            if (initValue != null)
                selectList.Where(x => x.Value.Equals(initValue, StringComparison.InvariantCultureIgnoreCase)).First().
                    Selected = true;
            return new JsonResult { Data = selectList };
        }


        public ActionResult SearchPanelMetaItem(string valueFieldName, string objIndex)
        {
            var selectList = GetCurrentLookupSource(valueFieldName);
            var item = GetCurrentItem(valueFieldName, true);

            if (item != null && selectList != null)
                ViewData["LookupList"] = selectList;

            ViewData["ObjNameIndex"] = objIndex;

            return PartialView(item);
        }
    }
}
