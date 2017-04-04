using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eidss.model.Resources;

namespace eidss.webui.Utils
{
    public static class Translator
    {
        public static string GetString(string key)
        {
            var value = EidssFields.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
                return key;
            else
                return value;
        }
    }
}