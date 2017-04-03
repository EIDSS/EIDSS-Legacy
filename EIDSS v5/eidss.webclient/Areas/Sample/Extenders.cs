using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Areas.Sample
{
    public static class Extenders
    {
        public static MvcHtmlString LabSampleReceiveGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.LabSampleReceiveItem> samples, bool isReadOnly, int HACode)
        {
            var args = new RouteValueDictionary { { "area", "Sample" }, { "root", root }, { "name", name }, { "samples", samples }, { "isReadOnly", isReadOnly }, { "HACode", HACode } };
            return htmlHelper.Action("ShowLabSampleReceiveGrid", "Sample", args);
        }

        public static string HtmlLabSampleReceiveGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.LabSampleReceiveItem> samples, bool isReadOnly, int HACode)
        {
            return htmlHelper.LabSampleReceiveGrid(root, name, samples, isReadOnly, HACode).ToHtmlString();
        }


        public static MvcHtmlString CaseTestsGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.CaseTest> tests, bool isReadOnly, int HACode, bool showSearchButton = false)
        {
            var args = new RouteValueDictionary { { "area", "Sample" }, { "root", root }, { "name", name }, { "tests", tests }, { "isReadOnly", isReadOnly }, { "HACode", HACode }, { "showSearchButton", showSearchButton } };
            return htmlHelper.Action("ShowCaseTestsGrid", "Sample", args);
        }

        public static string HtmlCaseTestsGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.CaseTest> tests, bool isReadOnly, int HACode, bool showSearchButton = false)
        {
            return htmlHelper.CaseTestsGrid(root, name, tests, isReadOnly, HACode, showSearchButton).ToHtmlString();
        }


        public static MvcHtmlString PensideTestsGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.PensideTest> tests, bool isReadOnly, int HACode)
        {
            var args = new RouteValueDictionary { { "area", "Sample" }, { "root", root }, { "name", name }, { "tests", tests }, { "isReadOnly", isReadOnly }, { "HACode", HACode } };
            return htmlHelper.Action("ShowPensideTestsGrid", "Sample", args);
        }

        public static string HtmlPensideTestsGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.PensideTest> tests, bool isReadOnly, int HACode)
        {
            return htmlHelper.PensideTestsGrid(root, name, tests, isReadOnly, HACode).ToHtmlString();
        }


        public static MvcHtmlString CaseTestValidationsGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.CaseTestValidation> validations, bool isReadOnly)
        {
            var args = new RouteValueDictionary { { "area", "Sample" }, { "root", root }, { "name", name }, { "validations", validations }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ShowCaseTestValidationsGrid", "Sample", args);
        }

        public static string HtmlCaseTestValidationsGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.CaseTestValidation> validations, bool isReadOnly)
        {
            return htmlHelper.CaseTestValidationsGrid(root, name, validations, isReadOnly).ToHtmlString();
        }


        public static MvcHtmlString LabTestAmendmentHistoryGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.LabTestAmendmentHistory> history, bool isReadOnly)
        {
            var args = new RouteValueDictionary { { "area", "Sample" }, { "root", root }, { "name", name }, { "history", history }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ShowLabTestAmendmentHistoryGrid", "Sample", args);
        }

        public static string HtmlLabTestAmendmentHistoryGrid(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.LabTestAmendmentHistory> history, bool isReadOnly)
        {
            return htmlHelper.LabTestAmendmentHistoryGrid(root, name, history, isReadOnly).ToHtmlString();
        }

    }
}