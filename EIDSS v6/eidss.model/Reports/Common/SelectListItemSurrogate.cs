using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class SelectListItemSurrogate
    {
        public bool Selected { set; get; }
        public string Text { set; get; }
        public string Value { set; get; }
        public override string ToString()
        {
            return string.Format("Value={0}, Text={1}, {2}", Value, Text, Selected?"Selected":string.Empty);
        }
    }
}