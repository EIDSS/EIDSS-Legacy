using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using bv.common.Core;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;

namespace EIDSS.RAM_DB.Components
{
    public class RamPivotGridHelper
    {
        public const string FieldSuffix = "_idfLayoutSearchField_";
        public const string CopySuffix = "_Copy";

        public static List<PivotGridFieldBase> GetFieldCollectionFromArea
            (IEnumerable<PivotGridFieldBase> ramFields, PivotArea pivotArea)
        {
            var dataField = new SortedDictionary<int, PivotGridFieldBase>();
            foreach (PivotGridFieldBase field in ramFields)
            {
                if ((field.Visible) && (field.Area == pivotArea))
                    dataField.Add(field.AreaIndex, field);
            }
            return new List<PivotGridFieldBase>(dataField.Values);
        }

        public static PivotGridFieldBase GetGenderField(IEnumerable<PivotGridFieldBase> fields)
        {
            return GetCulumnField(fields, @"sflHC_PatientSex");
        }
        public static PivotGridFieldBase GetAgeGroupField(IEnumerable<PivotGridFieldBase> fields)
        {
            return GetCulumnField(fields, @"sflHCAG_AgeGroup");
        }

        private static PivotGridFieldBase GetCulumnField(IEnumerable<PivotGridFieldBase> fields, string fieldAlias)
        {
            PivotGridFieldBase genderField =
                fields.ToList().SingleOrDefault(
                    field =>
                    field.Visible &&
                    field.Area == PivotArea.ColumnArea &&
                    field.FieldName.Contains(fieldAlias));

            return genderField;
        }
       

        public static PivotGridFieldBase GetEventTypeField(IEnumerable<PivotGridFieldBase> fields)
        {
            PivotGridFieldBase typeField =
                fields.ToList().SingleOrDefault(
                    field =>
                    field.Visible &&
                    field.Area == PivotArea.RowArea &&
                    (field.FieldName.Contains(@"sflCVEnt_Type") || field.FieldName.Contains(@"sflZD_CaseType")));
            
            return typeField;
        }

        public static string GetCorrectFilter(CriteriaOperator criteria)
        {
            if (Utils.IsEmpty(criteria))
                return null;
            string filter = criteria.LegacyToString();
            if (!Utils.IsEmpty(filter))
            {
                int ind = filter.IndexOf(" ?", System.StringComparison.InvariantCulture);
                while (ind >= 0)
                {
                    string substrFilter = filter.Substring(0, ind);
                    if (substrFilter.EndsWith("] =") || substrFilter.EndsWith("] <=") || substrFilter.EndsWith("] >=") ||
                        substrFilter.EndsWith("] <>") || substrFilter.EndsWith("] >") || substrFilter.EndsWith("] <"))
                    {
                        int bracketInd = substrFilter.LastIndexOf("[", System.StringComparison.InvariantCulture);
                        if (bracketInd >= 0)
                            substrFilter = substrFilter.Substring(0, bracketInd) + "1 = 1";
                    }
                    if (filter.Length > ind + 2)
                    {
                        filter = substrFilter + filter.Substring(ind + 2);
                        ind = filter.IndexOf(" ?", substrFilter.Length, System.StringComparison.InvariantCulture);
                    }
                    else
                    {
                        filter = substrFilter;
                        ind = -1;
                    }
                }
            }
            return filter;
        }

        public static long GetIdFromFieldName(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
                return -1;

            Match match = GetMatch(fieldName);
            Group idGroup = match.Groups["Id"];

            long id;
            return idGroup.Success && (idGroup.Captures.Count == 1) &&
                   (long.TryParse(idGroup.Captures[0].Value, out id))
                       ? id
                       : -1;
        }



        public static bool GetIsCopyForFilter(string fieldName)
        {
            string originalName = GetOriginalNameFromFieldName(fieldName);
            return (originalName.Length > CopySuffix.Length && originalName.Substring(originalName.Length - CopySuffix.Length) == CopySuffix);
        }
        public static string GetOriginalNameFromCopyForFilterName(string fieldName)
        {
            string originalName = GetOriginalNameFromFieldName(fieldName);
            return GetIsCopyForFilter(originalName)
                ? originalName.Substring(0, originalName.Length - CopySuffix.Length)
                : originalName;
        }

        public static string GetOriginalNameFromFieldName(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
                return fieldName;

            Match match = GetMatch(fieldName);
            Group fieldGroup = match.Groups["Field"];
            return fieldGroup.Success && (fieldGroup.Captures.Count == 1)
                       ? fieldGroup.Captures[0].Value
                       : fieldName;
        }

        public static CustomSummaryType GetFieldSummaryType(PivotGridFieldBase field)
        {
            CustomSummaryType summaryType = Configuration.GetSummaryTypeFor(field.FieldName, field.DataType);
            return summaryType;
        }

        public static string CreateFieldName(string name, long id)
        {
            return string.Format("{0}{1}{2}", name, FieldSuffix, id);
        }

        private static Match GetMatch(string fieldName)
        {
            Utils.CheckNotNullOrEmpty(fieldName, "fieldName");

            string pattern = string.Format(@"(?<Field>\w+)(?<Suffix>{0})(?<Id>-?\d+)", FieldSuffix);
            return Regex.Match(fieldName, pattern);
        }

       
        
    }
}