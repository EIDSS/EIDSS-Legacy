using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

using System.Web;
using eidss.model.Schema;

namespace eidss.webclient.Areas.ActiveSurveillence
{
    public static class Extender
    {
        #region Campaign
        public static MvcHtmlString SessionsByCampaign(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsMonitoringSession> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ByCampaign", "Session", args);
        }

        public static string HtmlSessionsByCampaign(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsMonitoringSession> items, bool isReadOnly)
        {
            return htmlHelper.SessionsByCampaign(root, name, items, isReadOnly).ToHtmlString();
        }

        public static MvcHtmlString DiseasesByCampaign(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsDisease> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ByCampaign", "Disease", args);
        }

        public static string HtmlDiseasesByCampaign(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsDisease> items, bool isReadOnly)
        {
            return htmlHelper.DiseasesByCampaign(root, name, items, isReadOnly).ToHtmlString();
        }
        #endregion

        #region Session
        public static MvcHtmlString DiseasesBySession(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionDisease> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("BySession", "Disease", args);
        }

        public static string HtmlDiseasesBySession(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionDisease> items, bool isReadOnly)
        {
            return htmlHelper.DiseasesBySession(root, name, items, isReadOnly).ToHtmlString();
        }

        
        #region Actions
        public static MvcHtmlString Actions(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionAction> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("Index", "Action", args);
        }

        public static string HtmlActions(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionAction> items, bool isReadOnly)
        {
            return htmlHelper.Actions(root, name, items, isReadOnly).ToHtmlString();
        }
        #endregion

        #region Summary
        public static MvcHtmlString SummaryItems(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionSummary> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("Index", "Summary", args);
        }

        public static string HtmlSummaryItems(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionSummary> items, bool isReadOnly)
        {
            return htmlHelper.SummaryItems(root, name, items, isReadOnly).ToHtmlString();
        }

        #endregion

        #region Samples
        public static MvcHtmlString SamplesTableView(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionTableViewItem> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("List", "Samples", args);
        }

        public static string HtmlSamplesTableView(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionTableViewItem> items, bool isReadOnly)
        {
            return htmlHelper.SamplesTableView(root, name, items, isReadOnly).ToHtmlString();
        }
        #endregion

        #region Cases

        public static MvcHtmlString Cases(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionCase> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("List", "Case", args);
        }

        public static string HtmlCases(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AsSessionCase> items, bool isReadOnly)
        {
            return htmlHelper.Cases(root, name, items, isReadOnly).ToHtmlString();
        }
        #endregion

        #endregion

    }
}
