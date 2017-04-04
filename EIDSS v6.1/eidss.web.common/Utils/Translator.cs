using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Resources;
using System.Reflection;

namespace eidss.web.common.Utils
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

        public static string GetBvOrEidssMessageString(string key)
        {
            var value = BvMessages.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value) || value == key)
            {
                value = EidssMessages.Instance.GetString(key);
            }
            return value;
        }


        public static string GetBvMessageString(string key)
        {
            var value = BvMessages.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
                return key;
            else
                return value;
        }

        public static string GetMessageString(string key)
        {
            var value = EidssMessages.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
                return key;
            else
                return value;
        }

        public static string GetMenuName(string key, string en)
        {
            var value = EidssMenu.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
                return en;
            else
                return value.Replace("&", "");
        }
        public static string GetErrorMessage(ValidationEventArgs args)
        {
            var str = EidssMessages.Get(args.MessageId);
            if (args.MessageId.CompareTo(str) == 0)
                str = BvMessages.Get(args.MessageId);
            return string.Format(str, args.Pars ?? new object[]{});
            /*
            if (args.Type == typeof(RequiredValidator))
            {
                return string.Format(EidssMessages.Get(args.MessageId), args.Pars[0]);
                //return string.Format(EidssMessages.Get("ErrMandatoryFieldRequired2"), EidssFields.Get(args.PropertyName, null));
            }
            if (args.Type == typeof(ChainsValidator))
            {
                return string.Format(EidssMessages.Get(args.MessageId), args.Pars);
            }
            return EidssMessages.Get(args.MessageId);
            */
        }

        public static string GetAssemblyVersion()
        {
            AssemblyName assembly = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
            return assembly.Version.ToString();
        }
    }
}