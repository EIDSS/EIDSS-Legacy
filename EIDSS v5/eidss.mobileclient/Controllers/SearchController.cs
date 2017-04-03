using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.mobileclient.Attributes;
using eidss.mobileclient.Utils;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private const string MODEL_STORAGE = "ModelSessionStorage";

        #region Adjavant methods
        private SearchPanelMetaItem GetCurrentItem(string fieldName, string sessionKey = null, bool comboPanelOnly = false)
        {
            if (Session[sessionKey ?? MODEL_STORAGE] == null)
            {
                return null;
            }

            var obj = (IObjectMeta)Session[sessionKey ?? MODEL_STORAGE];

            return obj.SearchPanelMeta.Where(x => x.Name == fieldName && (!comboPanelOnly || x.Location == SearchPanelLocation.Combobox)).FirstOrDefault();

        }

        private IEnumerable<SelectListItem> GetCurrentLookupSource(string valueFieldName, string sessionKey = null, string parameterName = null, long? parameterValue = null)
        {
            var item = GetCurrentItem(valueFieldName, sessionKey);

            if (item != null)
            {
                if (item.EditorType == EditorType.Lookup)
                {
                    return SearchPanelHelper.GetLookup((IObjectCreator) Session[sessionKey ?? MODEL_STORAGE], item, parameterName, parameterValue);
                }
            }

            return null;
        }

        #endregion

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult GetLookupSource(string valueFieldName, string sessionKey = null, string parameterName = null, string parameterValue = null, string initValue = null)
        {
            if (valueFieldName == null)
            {
                return new JsonResult {Data = new List<SelectListItem> {new SelectListItem {Text = "", Value = "0"}}};
            }

            long paramVal = 0;
            
            var selectList = long.TryParse(parameterValue, out paramVal) ? GetCurrentLookupSource(valueFieldName, sessionKey, parameterName, paramVal) : GetCurrentLookupSource(valueFieldName, sessionKey);
            if (!string.IsNullOrEmpty(initValue))
            {
                selectList.Where(x => x.Value.Equals(initValue, StringComparison.InvariantCultureIgnoreCase)).First().Selected = true;
            }
            return new JsonResult { Data = selectList };
        }

        [SessionExpireFilter]
        public ActionResult SearchPanelMetaItem(string valueFieldName, string objIndex, string sessionKey)
        {
            var selectList = GetCurrentLookupSource(valueFieldName);
            var item = GetCurrentItem(valueFieldName, sessionKey, true);

            if (item != null && selectList != null)
            {
                ViewData["LookupList"] = selectList;
            }

            ViewData["ObjNameIndex"] = objIndex;

            return PartialView(item);            
        }
    }
}
