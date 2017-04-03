using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class SearchPanelMetaItem
    {
        public string Name { get; protected set; }
        public EditorType EditorType { get; protected set; }
        public EditorControlWidth EditorControlWidth { get; protected set; }
        public bool UseInWeb { get; protected set; }
        public bool UseInWin { get; protected set; }
        public bool IsRange { get; protected set; }
        public bool IsRangeDefDates { get; protected set; }
        public string LabelId { get; protected set; }
        public Func<object, object> DefaultValue { get; protected set; }
        public string DefaultOper { get; protected set; }
        public Func<object, bool> Mandatory { get; protected set; }
        public bool IsMultiple { get; protected set; }
        public bool IsBitMask { get; protected set; }
        public SearchPanelLocation Location { get; protected set; }
        public bool IsParam { get; protected set; }
        public string Dependent { get; protected set; }
        public string LookupName { get; protected set; }
        public Type LookupType { get; protected set; }
        public Func<object, long> LookupValue { get; protected set; }
        public Func<object, string> LookupText { get; protected set; }
        public List<Tuple<string, string>> LookupColumns { get; protected set; }

        public SearchPanelMetaItem(
            string name,
            EditorType edtype,
            EditorControlWidth edwidth,
            bool useInWeb,
            bool useInWin,
            bool range,
            bool rangeDefDates,
            string label,
            Func<object, object> def,
            string oper,
            Func<object, bool> mandatory,
            bool multiple,
            SearchPanelLocation location,
            bool param,
            string dependent,
            string lookupName,
            Type lookupType,
            Func<object, long> lookupValue,
            Func<object, string> lookupText,
            List<Tuple<string, string>> lookupColumns,
            bool bitmask
            )
        {
            Name = name;
            EditorType = edtype;
            EditorControlWidth = edwidth;
            UseInWeb = useInWeb;
            UseInWin = useInWin;
            IsRange = range;
            IsRangeDefDates = rangeDefDates;
            LabelId = label;
            DefaultValue = def;
            DefaultOper = oper;
            Mandatory = mandatory;
            IsMultiple = multiple;
            Location = location;
            IsParam = param;
            Dependent = dependent;
            LookupName = lookupName;
            LookupType = lookupType;
            LookupValue = lookupValue;
            LookupText = lookupText;
            LookupColumns = lookupColumns;
            IsBitMask = bitmask;
        }
    }
}
