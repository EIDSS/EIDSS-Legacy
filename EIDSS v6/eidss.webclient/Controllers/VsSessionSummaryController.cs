using System;
using System.Web.Mvc;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class VsSessionSummaryController : BvController
    {
        [HttpGet]
        public ActionResult Details(long key, string name, long id)
        {
            return PickerInternal<VsSessionSummary.Accessor, VsSessionSummary, VsSession>(key, id, name, VsSessionSummary.Accessor.Instance(null),
                null
                , null
                , (manager, accessor, vector) =>
                {
                    var session = ModelStorage.GetRoot(Session.SessionID, key, String.Empty) as VsSession;
                    if (session == null) return null;
                    var acc = VsSessionSummary.Accessor.Instance(null);
                    var summary = acc.Create(manager, session, session.Location);
                    return summary;
                }
                ,
                null);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            var result = PickerInternal<VsSessionSummary.Accessor, VsSessionSummary, VsSession>(form, VsSessionSummary.Accessor.Instance(null), null,
                p => p.Summaries,
                (i, o) => i.idfsVSSessionSummary == o.idfsVSSessionSummary,
                (to, from) =>
                    {
                        to.DiagnosisList.Clear(); 
                        to.DiagnosisList.AddRange(from.DiagnosisList);
                        to.DiagnosisList.ForEach(i => i.SetChange());
                    }
                );
            Session["SelectedIndex"] = 1;
            return result;
        }

        [HttpPost]
        public ActionResult SetVsVSessionSummary(FormCollection form)
        {
            return PickerInternal<VsSessionSummary.Accessor, VsSessionSummary, VsSession>(form, VsSessionSummary.Accessor.Instance(null), null,
                p => p.Summaries,
                (i, o) => i.idfsVSSessionSummary == o.idfsVSSessionSummary,
                null);
        }

        [HttpGet]
        public ActionResult DiagnosisPicker(long key, string name, long id)
        {
            return PickerInternal<VsSessionSummaryDiagnosis.Accessor, VsSessionSummaryDiagnosis, VsSessionSummary>(key, id, name, VsSessionSummaryDiagnosis.Accessor.Instance(null),
                null
                , null
                , (manager, accessor, summary) => accessor.CreateNewT(manager, summary),
                null);
        }

        [HttpPost]
        public ActionResult SetDiagnosis(FormCollection form)
        {
            return PickerInternal<VsSessionSummaryDiagnosis.Accessor, VsSessionSummaryDiagnosis, VsSessionSummary>(form, VsSessionSummaryDiagnosis.Accessor.Instance(null), null,
                p => p.DiagnosisList,
                (i, o) => i.idfsVSSessionSummaryDiagnosis == o.idfsVSSessionSummaryDiagnosis,
                null);
        }

        [HttpPost]
        public ActionResult StoreInSession(FormCollection form)
        {
            var key = long.Parse(form["idfsVSSessionSummary"]);
            var summary = (VsSessionSummary)ModelStorage.Get(Session.SessionID, key, null);
            summary.ParseFormCollection(form);
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
