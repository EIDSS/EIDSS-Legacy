using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.webui.Utils;

namespace eidss.webui.Controllers
{
    public class HumanCaseController : Controller
    {
        //
        // GET: /HumanCase/

        public ActionResult Index()
        {
            return View(HumanCaseListItem.Accessor.Instance(null));
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewBag.Filter = SearchPanelHelper.SearchPanelParseValues(Request);

            return View(HumanCaseListItem.Accessor.Instance(null));
        }
        
        public ActionResult Details(long? idfCase) 
        {
            if (!idfCase.HasValue) idfCase = 0;

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = idfCase.Value.Equals(0) ? acc.CreateNewT(manager) : acc.SelectByKey(manager, idfCase.Value); //TODO extender helper для проверки
                ModelStorage.Put(Session.SessionID, hc.idfCase, hc.idfCase, hc);
                return View(hc);
            }
        }

        public ActionResult Duplicates()
        {
            ViewBag.Filter = SearchPanelHelper.DuplicatesFilter(Request);
            return View(HumanCaseListItem.Accessor.Instance(null));
        }
    }
}
