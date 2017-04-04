using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
    public class FFModelIn
    {
        public long idfObservation { get; set; }
        public long idfsFormType { get; set; }
        public List<FFActivityParameter> parameters { get; set; }

        public FFModelIn()
        {
        }

        public FFModelIn(XElement xml)
        {
          idfObservation = GetLong(xml, "idfObservation", idfObservation);
          idfsFormType = GetLong(xml, "idfsFormType", idfsFormType);
          parameters = new List<FFActivityParameter>();
          xml.Element("activityparameters").Elements("ap").ToList().ForEach(c => parameters.Add(new FFActivityParameter(c)));
        }

        private long GetLong(XElement xml, string name, long def)
        {
            if (xml.Attribute(name) != null) return long.Parse(xml.Attribute(name).Value);
            return def;
        }
    }

    public class FFActivityParameter
    {
        public long idfsParameter { get; set; }
        public long idfRow { get; set; }
        public string Value { get; set; }

        public FFActivityParameter()
        {
        }

        public FFActivityParameter(XElement xml)
        {
            idfsParameter = GetLong(xml, "idfsParameter", idfsParameter);
            idfRow = GetLong(xml, "idfRow", idfRow);
            Value = GetString(xml, "Value", Value);
        }

        private long GetLong(XElement xml, string name, long def)
        {
            if (xml.Attribute(name) != null) return long.Parse(xml.Attribute(name).Value);
            return def;
        }
        private string GetString(XElement xml, string name, string def)
        {
            if (xml.Attribute(name) != null) return xml.Attribute(name).Value;
            return def;
        }
    }
}