using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using bv.model.Model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.model.Schema;
using eidss.model.Resources;
using eidss.model.Enums;
using BLToolkit.EditableObjects;
using eidss.webclient.Utils;
using bv.model.BLToolkit;
using eidss.model.Core;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class ASSessionSummaryController : BvController
    {
        public ActionResult SummaryDetail(long idfMonitoringSession, string gridName, long? idfSummary)
        {
            ViewBag.GridName = gridName;
            ViewBag.IdfMonitoringSession = idfMonitoringSession;
            ViewBag.IdfRoot = idfMonitoringSession;
            return PickerInternal<AsSessionSummary.Accessor, AsSessionSummary, AsSession>(idfMonitoringSession, idfSummary.HasValue ? idfSummary.Value : 0,
                gridName, AsSessionSummary.Accessor.Instance(null), null,
                null,
                null,
                null
                );
        }

        [HttpPost]
        public ActionResult SummaryDetail(long idfMonitoringSession, long idfSummary, string gridName, FormCollection form)
        {
            return PickerInternal<AsSessionSummary.Accessor, AsSessionSummary, AsSession>(form, AsSessionSummary.Accessor.Instance(null),
                null,
                p => p.SummaryItems,
                (o, i) => o.idfMonitoringSessionSummary == i.idfMonitoringSessionSummary,
                (to, from) => UpdateCheckedLists(to, form),
                (o, p) => UpdateCheckedLists(o, form)
                );
        }

        private void UpdateCheckedLists(AsSessionSummary o, FormCollection form)
        {
            o.Samples.ForEach(c => c.blnChecked = false);
            if (form.AllKeys.Contains(o.ObjectIdent + "Samples"))
            {
                var selected = form[o.ObjectIdent + "Samples"].ToString();
                if (!string.IsNullOrEmpty(selected))
                {
                    selected.Split(',').ToList().ForEach(i => o.Samples.First(c => c.idfsSampleType == Int64.Parse(i)).blnChecked = true);
                }
            }

            o.Diagnosis.ForEach(c => c.blnChecked = false);
            if (form.AllKeys.Contains(o.ObjectIdent + "DiagnosisList"))
            {
                var selected = form[o.ObjectIdent + "DiagnosisList"].ToString();
                if (!string.IsNullOrEmpty(selected))
                {
                    selected.Split(',').ToList().ForEach(i => o.Diagnosis.First(c => c.idfsDiagnosis == Int64.Parse(i)).blnChecked = true);
                }
            }
        }

        public ActionResult SelectDiagnosisList(long id, string keyname, string valuename)
        {
            var o = ModelStorage.Get(Session.SessionID, id, null) as AsSessionSummary;
            var bvList = o.GetList("DiagnosisList");
            return Json(bvList.items.Cast<IObject>().Select(c => new { Value = c.GetValue(keyname), Text = c.GetValue(valuename) }), JsonRequestBehavior.AllowGet);
        }
        

    }
}
