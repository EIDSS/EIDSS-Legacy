using System;
using System.Linq;
using System.Web.Mvc;
using eidss.model.Schema;
using eidss.webclient.Utils;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace eidss.webclient.Areas.ActiveSurveillence.Controllers
{
    public class CaseController : Controller
    {
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "CaseListItemEditions";

        public ActionResult List(long root, string name, EditableList<eidss.model.Schema.AsSessionCase> items, bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsSessionCase.AsSessionCaseGridModelList(root, items);
            return PartialView(model);
        }



    }
}
