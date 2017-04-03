using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Resources;

namespace eidss.mobileclient.Utils
{
    public static class Translator
    {
        public static string GetString(string key)
        {
            var value = EidssFields.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
            {
                return key;
            }
            return value;
        }

        public static string GetMessageString(string key)
        {
            var value = EidssMessages.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
            {
                return key;
            }
            return value;
        }

        public static string GetErrorMessage(ValidationEventArgs args)
        {
            if (args.Type == typeof(RequiredValidator))
            {
                return string.Format(EidssMessages.Get(args.MessageId), GetString(args.Pars[0].ToString()));
            }
            return EidssMessages.Get(args.MessageId);
        }
    }
}