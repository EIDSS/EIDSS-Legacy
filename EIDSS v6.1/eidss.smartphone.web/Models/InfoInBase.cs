using bv.model.Model.Core;
using eidss.model.Resources;
using System;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
    public class InfoInBase
    {
        protected long GetLong(XElement xml, string name, long def)
        {
            if (xml.Attribute(name) != null) return long.Parse(xml.Attribute(name).Value);
            return def;
        }
        protected int GetInt(XElement xml, string name, int def)
        {
            if (xml.Attribute(name) != null) return int.Parse(xml.Attribute(name).Value);
            return def;
        }
        protected double GetDouble(XElement xml, string name, double def)
        {
            if (xml.Attribute(name) != null)
            {
                double testNum = 0.5;
                char decimalSepparator;
                decimalSepparator = testNum.ToString()[1];
                string val = xml.Attribute(name).Value;
                val = val.Replace(',', decimalSepparator);
                val = val.Replace('.', decimalSepparator);
                return double.Parse(val);
            }
            return def;
        }
        protected string GetString(XElement xml, string name, string def)
        {
            if (xml.Attribute(name) != null) return xml.Attribute(name).Value;
            return def;
        }
        protected DateTime GetDateTime(XElement xml, string name, DateTime def)
        {
            if (xml.Attribute(name) != null) return DateTime.ParseExact(xml.Attribute(name).Value, "yyyy-MM-ddTHH:mm:ss", null); ;
            return def;
        }
        protected bool GetBool(XElement xml, string name, bool def)
        {
            if (xml.Attribute(name) != null)
                return Convert.ToBoolean(int.Parse(xml.Attribute(name).Value));
            return def;
        }

        protected static string GetErrorMessage(ValidationEventArgs args)
        {
            return args.Pars == null 
                ? EidssMessages.Get(args.MessageId)
                : string.Format(EidssMessages.Get(args.MessageId), args.Pars);
        }

   }
}