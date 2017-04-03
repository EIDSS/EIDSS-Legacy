using System;
using System.Collections.Generic;
using System.Web.Mvc;
using eidss.model.Schema;
using eidss.webclient.Utils;
using eidss.model.Resources;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class AggregateCaseController : Controller
    {
        [HttpPost]
        public ActionResult SelectRegion(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(cs.RegionLookup, "idfsRegion", "strRegionName") };
        }

        [HttpPost]
        public ActionResult SelectRayon(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(cs.RayonLookup, "idfsRayon", "strRayonName") };
        }

        [HttpPost]
        public ActionResult SelectSettlement(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(cs.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }

        [HttpPost]
        public ActionResult SelectYear(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            var list = new List<int>();
            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                list.Add(i);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(list, cs.YearForAggr) };
        }

        [HttpPost]
        public ActionResult SelectQuarter(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            var list = new List<int>();
            for (int i = 1; i <= 4; i++)
            {
                list.Add(i);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(list, cs.QuarterForAggr) };
        }

        [HttpPost]
        public ActionResult SelectMonth(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            var list = new[] {
                new {val = 1, name = EidssMessages.Instance.GetString("January")},
                new {val = 2, name = EidssMessages.Instance.GetString("February")},
                new {val = 3, name = EidssMessages.Instance.GetString("March")},
                new {val = 4, name = EidssMessages.Instance.GetString("April")},
                new {val = 5, name = EidssMessages.Instance.GetString("May")},
                new {val = 6, name = EidssMessages.Instance.GetString("June")},
                new {val = 7, name = EidssMessages.Instance.GetString("July")},
                new {val = 8, name = EidssMessages.Instance.GetString("August")},
                new {val = 9, name = EidssMessages.Instance.GetString("September")},
                new {val = 10, name = EidssMessages.Instance.GetString("October")},
                new {val = 11, name = EidssMessages.Instance.GetString("November")},
                new {val = 12, name = EidssMessages.Instance.GetString("December")}
            };
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(list, "val", "name", cs.MonthForAggr) };
        }

        [HttpPost]
        public ActionResult SelectWeek(long idfAggrCase)
        {
            AggregateCaseHeader cs = ModelStorage.Get(Session.SessionID, idfAggrCase, null) as AggregateCaseHeader;
            var list = new List<int>();
            for (int i = 1; i <= 53; i++)
            {
                list.Add(i);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(list, cs.WeekForAggr) };
        }
    }
}
