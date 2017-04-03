using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace eidss.webclient.Areas.Address
{
    public static class Extenders
    {
        public static MvcHtmlString Address(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address, bool isCountryFieldVisible = false,
            bool isForeignAddressFieldVisible = false, bool needFillRegionOnCountryChanged = false, bool isCoordinatesFieldsVisible = false)
        {
            var args = new RouteValueDictionary { { "area", "Address" }, { "root", root }, { "address", address }, { "isCountryFieldVisible", isCountryFieldVisible }, 
                { "isForeignAddressFieldVisible", isForeignAddressFieldVisible }, { "needFillRegionOnCountryChanged", needFillRegionOnCountryChanged },
                {"isCoordinatesFieldsVisible", isCoordinatesFieldsVisible}};
            return htmlHelper.Action("ShowAddress", "Address", args);
        }

        public static string HtmlAddress(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address, bool isCountryFieldVisible = false,
            bool isForeignAddressFieldVisible = false, bool needFillRegionOnCountryChanged = false, bool isCoordinatesFieldsVisible = false)
        {
            return htmlHelper.Address(root, address, isCountryFieldVisible, isForeignAddressFieldVisible, needFillRegionOnCountryChanged).ToHtmlString();
        }

        public static MvcHtmlString ReadOnlyAddress(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "area", "Address" }, { "root", root }, { "address", address } };
            return htmlHelper.Action("ShowReadOnlyAddress", "Address", args);
        }

        public static string HtmlReadOnlyAddress(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            return htmlHelper.ReadOnlyAddress(root, address).ToHtmlString();
        }

        public static MvcHtmlString InlineAddressPicker(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "area", "Address" }, { "root", root }, { "address", address } };
            return htmlHelper.Action("ShowInlineAddressPicker", "Address", args);
        }

        public static string HtmlInlineAddressPicker(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            return htmlHelper.InlineAddressPicker(root, address).ToHtmlString();
        }

        public static MvcHtmlString AddressInTwoColumns(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address, bool showCountry = false)
        {
            var args = new RouteValueDictionary { { "area", "Address" }, { "root", root }, { "address", address }, {"countryIsVisible", showCountry} };
            return htmlHelper.Action("ShowAddressInTwoColumns", "Address", args);
        }

        public static string HtmlAddressInTwoColumns(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address, bool showCountry = false)
        {
            return htmlHelper.AddressInTwoColumns(root, address, showCountry).ToHtmlString();
        }
        public static MvcHtmlString AddressWithCountry(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "area", "Address" }, { "root", root }, { "address", address } };
            return htmlHelper.Action("ShowAddressWithCountry", "Address", args);
        }

        public static string HtmlAddressWithCountry(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            return htmlHelper.AddressWithCountry(root, address).ToHtmlString();
        }
    }
}
