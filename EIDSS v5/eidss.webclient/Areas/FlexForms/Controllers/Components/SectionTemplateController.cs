using System;
using System.Web.Mvc;
using bv.model.Model.Extenders;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Schema;
using eidss.webclient.Utils;
using System.Linq;

namespace eidss.webclient.Areas.FlexForms.Controllers.Components
{
    public class SectionTemplateController : Controller
    {
        //
        // GET: /SectionTemplate/

        //public ActionResult SectionTemplateRender(FFRenderModel renderModel, SectionTemplate sectionTemplate)
        public ActionResult SectionTemplateRender(FlexNode flexNode)
        {
            return PartialView(flexNode);
        }

        public ActionResult SectionTemplateTableRender(FlexNode flexNode)
        {
            return PartialView(flexNode);
        }

        public ActionResult SectionTemplateTableNodeRender(string idfsSection, long key, string ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            var flexNode = ff != null ? ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection)) : null;
            return PartialView("SectionTemplateTableRender", flexNode);
        }
    }
}
