using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eidss.model.Core;
using bv.common.Core;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace eidss.avr.mweb.Utils
{
    public class MultiCultureMvcRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string culture = requestContext.RouteData.Values["culture"].ToString();
            //var ci = new CultureInfo(culture);
            var ci = (culture.Substring(0, 2).ToLowerInvariant() == Localizer.lngThai)
                ? ThailandCultureWithGregorianCalendar.Instance
                : new CultureInfo(culture);

            EidssSiteContext.Instance.UpdateDateTimeFormat(ci);
            Thread.CurrentThread.CurrentUICulture = ci;

            //CultureInfo specificCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            var specificCulture = (culture.Substring(0, 2).ToLowerInvariant() == Localizer.lngThai)
                ? ci
                : CultureInfo.CreateSpecificCulture(ci.Name);

            EidssSiteContext.Instance.UpdateDateTimeFormat(specificCulture);
            Thread.CurrentThread.CurrentCulture = specificCulture;

            return base.GetHttpHandler(requestContext);
        }
    }


    // from here: http://stackoverflow.com/questions/15817348/how-to-customize-cultureinfos-default-calendar
    public class ThailandCultureWithGregorianCalendar : CultureInfo
    {
        private readonly System.Globalization.Calendar cal;
        private readonly System.Globalization.Calendar[] optionals;

        private static ThailandCultureWithGregorianCalendar _instance = new ThailandCultureWithGregorianCalendar();
        public static ThailandCultureWithGregorianCalendar Instance { get { return _instance; } }

        public ThailandCultureWithGregorianCalendar()
            : this("th-TH", true)
        {

        }
        public ThailandCultureWithGregorianCalendar(string cultureName, bool useUserOverride)
            : base(cultureName, useUserOverride)
        {
            cal = base.OptionalCalendars[0];
            var optionalCalendars = new List<System.Globalization.Calendar>();
            optionalCalendars.AddRange(base.OptionalCalendars);

            optionalCalendars.Insert(0, new GregorianCalendar());

            Type formatType = typeof(DateTimeFormatInfo);
            Type calendarType = typeof(System.Globalization.Calendar);
            PropertyInfo idProperty = calendarType.GetProperty("ID", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo optionalCalendarfield = formatType.GetField("optionalCalendars", BindingFlags.Instance | BindingFlags.NonPublic);
            var newOptionalCalendarIDs = new Int32[optionalCalendars.Count];

            for (int i = 0; i < newOptionalCalendarIDs.Length; i++)
                newOptionalCalendarIDs[i] = (Int32)idProperty.GetValue(optionalCalendars[i], null);
            optionalCalendarfield.SetValue(DateTimeFormat, newOptionalCalendarIDs);

            optionals = optionalCalendars.ToArray();

            cal = optionals[0];

            DateTimeFormat.Calendar = optionals[0];
        }
        public override System.Globalization.Calendar Calendar
        {
            get { return cal; }
        }
        public override System.Globalization.Calendar[] OptionalCalendars
        {
            get { return optionals; }
        }
    }
}