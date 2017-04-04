using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Resources;

namespace eidss.mobileclient.Utils
{
    public static class NumericHelper
    {
        public static bool TryParseInteger(FormCollection form, out string errorMessage)
        {
            string[] formKeys = form.AllKeys;
            List<string> intNumeric = formKeys.Where(x => x.Contains("_int")).ToList();
            foreach (string key in intNumeric)
            {
                if(string.IsNullOrEmpty(form[key]))
                {
                    continue;
                }
                int value;
                if (!Int32.TryParse(form[key], out value))
                {
                    string[] keyparts = key.Split('_');
                    string fieldName = keyparts[2];
                    errorMessage = string.Format(Translator.GetMessageString("errInvalidNumberFormat"), Translator.GetString(fieldName));
                    return false;
                }
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}