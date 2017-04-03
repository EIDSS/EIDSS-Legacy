using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class CommonAggregateController : BvController
    {
        public ActionResult GetFlexFormCase(long root)
        {
            var aggCase = ModelStorage.Get(Session.SessionID, root, null, false) as AggregateCaseHeader;
            if ((aggCase != null) && (aggCase.FFPresenterCase != null) && (aggCase.FFPresenterCase.CurrentObservation.HasValue))
            {
                ModelStorage.Put(Session.SessionID, aggCase.idfAggrCase, aggCase.idfAggrCase, aggCase.FFPresenterCase.CurrentObservation.Value.ToString(), aggCase.FFPresenterCase);
                var ffDivContent = this.RenderPartialView("FlexFormCase", aggCase);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        public ActionResult GetFlexFormDiagnostic(long root)
        {
            var aggCase = ModelStorage.Get(Session.SessionID, root, null, false) as AggregateCaseHeader;
            if ((aggCase != null) && (aggCase.FFPresenterDiagnostic != null) && (aggCase.FFPresenterDiagnostic.CurrentObservation.HasValue))
            {
                ModelStorage.Put(Session.SessionID, aggCase.idfAggrCase, aggCase.idfAggrCase, aggCase.FFPresenterDiagnostic.CurrentObservation.Value.ToString(), aggCase.FFPresenterDiagnostic);
                var ffDivContent = this.RenderPartialView("FlexFormDiagnostic", aggCase);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }
        public ActionResult GetFlexFormProphylactic(long root)
        {
            var aggCase = ModelStorage.Get(Session.SessionID, root, null, false) as AggregateCaseHeader;
            if ((aggCase != null) && (aggCase.FFPresenterProphylactic != null) && (aggCase.FFPresenterProphylactic.CurrentObservation.HasValue))
            {
                ModelStorage.Put(Session.SessionID, aggCase.idfAggrCase, aggCase.idfAggrCase, aggCase.FFPresenterProphylactic.CurrentObservation.Value.ToString(), aggCase.FFPresenterProphylactic);
                var ffDivContent = this.RenderPartialView("FlexFormProphylactic", aggCase);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }
        public ActionResult GetFlexFormSanitary(long root)
        {
            var aggCase = ModelStorage.Get(Session.SessionID, root, null, false) as AggregateCaseHeader;
            if ((aggCase != null) && (aggCase.FFPresenterSanitary != null) && (aggCase.FFPresenterSanitary.CurrentObservation.HasValue))
            {
                ModelStorage.Put(Session.SessionID, aggCase.idfAggrCase, aggCase.idfAggrCase, aggCase.FFPresenterSanitary.CurrentObservation.Value.ToString(), aggCase.FFPresenterSanitary);
                var ffDivContent = this.RenderPartialView("FlexFormSanitary", aggCase);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }
    }
}
