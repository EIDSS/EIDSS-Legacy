using System;
using System.Collections;

namespace bv.model.Model.Core
{
    public class BvSelectList
    {
        public IList items { get; protected set; }
        public string dataValueField { get; protected set; }
        public string dataTextField { get; protected set; }
        public object selectedValue { get; protected set; }
        public string dataValueFieldRef { get; protected set; }
        public BvSelectList(IList items, string dataValueField, string dataTextField, object selectedValue, string dataValueFieldRef)
        {
            this.items = items;
            this.dataValueField = dataValueField;
            this.dataTextField = dataTextField;
            this.selectedValue = selectedValue;
            this.dataValueFieldRef = dataValueFieldRef;
        }
    }
}