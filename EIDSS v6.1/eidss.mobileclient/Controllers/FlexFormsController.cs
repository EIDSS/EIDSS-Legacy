using System.Web.Mvc;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.mobileclient.Utils;
using eidss.model.Schema;
using System;

namespace eidss.mobileclient.Controllers
{
    public class FlexFormsController : Controller
    {
        public ActionResult ParameterTemplateRender(FlexNode flexNode, bool canUpdate = true)
        {
            return PartialView(flexNode);
        }

        public ActionResult SectionTemplateRender(FlexNode flexNode, bool canUpdate = true)
        {
            return PartialView(flexNode);
        }

        public ActionResult SectionTemplateTableRender(FlexNode flexNode, bool canUpdate = true)
        {
            ViewBag.CanUpdate = canUpdate;
            return PartialView(flexNode);
        }

        public ActionResult SectionTemplateTableNodeRender(string idfsSection, long key, string ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            var flexNode = ff != null ? ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection)) : null;
            return PartialView("SectionTemplateTableRender", flexNode);
        }

        public ActionResult LabelRender(FlexNode flexNode, bool canUpdate = true)
        {
            return PartialView(flexNode);
        }
    }
}
