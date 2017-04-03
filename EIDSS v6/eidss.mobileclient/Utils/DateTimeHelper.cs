using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eidss.mobileclient.Utils
{
    public static class DateTimeHelper
    {
        public static bool TryParseCustomDates(FormCollection form, out string errorMessage)
        {
            string[] formKeys = form.AllKeys;
            List<string> days = formKeys.Where(x => x.EndsWith("_Day")).ToList();
            foreach (string dayKey in days)
            {
                string fieldId = dayKey.Replace("_Day", "");
                int day = Convert.ToInt32(form[fieldId + "_Day"]);
                int month = Convert.ToInt32(form[fieldId + "_Month"]);
                int year = Convert.ToInt32(form[fieldId + "_Year"]);
                bool containsTime = formKeys.Contains(fieldId + "_Hour");
                int hour = containsTime && !string.IsNullOrEmpty(form[fieldId + "_Hour"]) ? Convert.ToInt32(form[fieldId + "_Hour"]) : -1;
                int minute = containsTime && !string.IsNullOrEmpty(form[fieldId + "_Minute"]) ? Convert.ToInt32(form[fieldId + "_Minute"]) : -1;
                if (day == 0 && month == 0 && year == 0 && hour == -1 && minute == -1)
                {
                    form[fieldId] = null;
                    continue;
                }
                string[] keyparts = fieldId.Split('_');
                string fieldName = keyparts[2];
                if (hour == -1 && minute >= 0 || hour >= 0 && minute == -1)
                {
                    errorMessage = string.Format(Translator.GetMessageString("errInvalidDateTimeFormat"), Translator.GetString(fieldName));
                    return false;
                }
                if (day == 0 || month == 0 || year == 0)
                {
                    errorMessage = string.Format(containsTime ? Translator.GetMessageString("errInvalidDateTimeFormat") : 
                        Translator.GetMessageString("errInvalidDateFormat"), Translator.GetString(fieldName));
                    return false;
                }
                DateTime date;
                try
                {
                    hour = hour == -1 ? 0 : hour;
                    minute = minute == -1 ? 0 : minute;
                    date = containsTime ? new DateTime(year, month, day, hour, minute, 0) : new DateTime(year, month, day);
                }
                catch (Exception)
                {
                    errorMessage = string.Format(Translator.GetMessageString("errInvalidDateFormat"), Translator.GetString(fieldName));
                    return false;
                }
                form[fieldId] = date.ToString("MM/dd/yyyy HH:mm:ss");
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool TryParseMobileSafariDates(FormCollection form, out string errorMessage)
        {
            string[] formKeys = form.AllKeys;
            List<string> dates = formKeys.Where(x => x.EndsWith("_Date")).ToList();
            foreach (string dateKey in dates)
            {
                string fieldId = dateKey.Replace("_Date", "");
                string dateText = form[fieldId + "_Date"];
                if (string.IsNullOrEmpty(dateText))
                {
                    form[fieldId] = null;
                    errorMessage = string.Empty;
                    continue;
                }
                string time = formKeys.Contains(fieldId + "_Time") && !string.IsNullOrEmpty(form[fieldId + "_Time"]) ? string.Format(" {0}", form[fieldId + "_Time"]) : " 00:00:00";
                form[fieldId] = dateText + time;
            }
            errorMessage = string.Empty;
            return true;
        }

        private static bool IsTimeValid(string time)
        {
            string pattern = "^(([0-9])|([0-1][0-9])|([2][0-3])):(([0-9])|([0-5][0-9]))?( )?(AM|PM)$";
            if (System.Text.RegularExpressions.Regex.IsMatch(time.Trim().ToUpper(), pattern))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Important! Method doesn't throw Exception if date in wrong format
        /// </summary>
        public static DateTime? GetDateForFilterByKey(NameValueCollection collection, string key)
        {
            int day = Convert.ToInt32(collection[key + "_Day"]);
            int month = Convert.ToInt32(collection[key + "_Month"]);
            int year = Convert.ToInt32(collection[key + "_Year"]);
            if (day == 0 && month == 0 && year == 0)
            {
                return null;
            }
            if (day == 0 || month == 0 || year == 0)
            {
                return null;
            }
            try
            {
                var date = new DateTime(year, month, day);
                return date;
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}