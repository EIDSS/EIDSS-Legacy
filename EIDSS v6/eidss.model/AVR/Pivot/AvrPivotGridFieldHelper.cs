using System;
using System.Text.RegularExpressions;
using bv.common.Core;
using eidss.model.AVR.Db;

namespace eidss.model.Avr.Pivot
{
    public class AvrPivotGridFieldHelper
    {
        
        public const string FieldSuffix = "_idfLayoutSearchField_";
        public const string CopySuffix = QueryHelper.CopySuffix;
        public const string VirtualCountryFieldName = "sflVirtualCountry_idfLayoutSearchField_-1";

        #region Get Search Field Properties

        public static long GetIdFromFieldName(string fieldName)
        {
            if (String.IsNullOrEmpty(fieldName))
            {
                return -1;
            }

            Match match = GetMatch(fieldName);
            Group idGroup = match.Groups["Id"];

            long id;
            return idGroup.Success && (idGroup.Captures.Count == 1) &&
                   (Int64.TryParse(idGroup.Captures[0].Value, out id))
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
            if (String.IsNullOrEmpty(fieldName))
            {
                return fieldName;
            }

            Match match = GetMatch(fieldName);
            Group fieldGroup = match.Groups["Field"];
            return fieldGroup.Success && (fieldGroup.Captures.Count == 1)
                ? fieldGroup.Captures[0].Value
                : fieldName;
        }

        public static string CreateFieldName(string name, long id)
        {
            return String.Format("{0}{1}{2}", name, FieldSuffix, id);
        }

        private static Match GetMatch(string fieldName)
        {
            Utils.CheckNotNullOrEmpty(fieldName, "fieldName");

            string pattern = String.Format(@"(?<Field>\w+)(?<Suffix>{0})(?<Id>-?\d+)", FieldSuffix);
            return Regex.Match(fieldName, pattern);
        }

        #endregion

    }
}