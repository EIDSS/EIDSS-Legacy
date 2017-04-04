using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.Common
{
    public static class Configuration
    {
        private static readonly NameValueCollection m_SummaryTypeSection;
        private static readonly NameValueCollection m_FieldSummaryTypeSection;
        private static readonly CustomSummaryType m_DefaltSummaryType;
        private static readonly Dictionary<Type, CustomSummaryType> m_SummaryTypeDictionary;
        private static readonly Dictionary<string, CustomSummaryType> m_FieldSummaryTypeDictionary;

        static Configuration()
        {
            m_SummaryTypeSection = (NameValueCollection) ConfigurationManager.GetSection("PivotValueTypeSummaryTypeSection");
            if (m_SummaryTypeSection == null)
            {
                throw new ConfigurationErrorsException("Cannot find section PivotValueTypeSummaryTypeSection");
            }

            m_FieldSummaryTypeSection = (NameValueCollection) ConfigurationManager.GetSection("PivotFieldSummaryTypeSection");
            if (m_FieldSummaryTypeSection == null)
            {
                throw new ConfigurationErrorsException("Cannot find section PivotFieldSummaryTypeSection");
            }

            m_DefaltSummaryType = GetDefaultSummaryType();
            m_SummaryTypeDictionary = GetSummaryTypeDictionary();
            m_FieldSummaryTypeDictionary = GetFieldSummaryTypeDictionary();
        }

        internal static CustomSummaryType DefaltSummaryType
        {
            get { return m_DefaltSummaryType; }
        }

        internal static Dictionary<Type, CustomSummaryType> SummaryTypeDictionary
        {
            get { return m_SummaryTypeDictionary; }
        }

        public static Dictionary<string, CustomSummaryType> FieldSummaryTypeDictionary
        {
            get { return m_FieldSummaryTypeDictionary; }
        }

        public static CustomSummaryType GetDefaultSummaryTypeFor(string name, Type type)
        {
            CustomSummaryType result;
            string originalName = AvrPivotGridFieldHelper.GetOriginalNameFromCopyForFilterName(name);
            if (AvrPivotGridHelper.TryGetDefaultSummaryTypeFor(name, out result))
            {
                return result;
            }
            if (FieldSummaryTypeDictionary.TryGetValue(originalName, out result))
            {
                return result;
            }

            return SummaryTypeDictionary.TryGetValue(type, out result)
                ? result
                : DefaltSummaryType;
        }

        private static CustomSummaryType GetDefaultSummaryType()
        {
            string defaultType = m_SummaryTypeSection["Default"];
            if (string.IsNullOrEmpty(defaultType))
            {
                throw new ConfigurationErrorsException(
                    "Default key is not present in PivotValueTypeSummaryTypeSection");
            }

            var summaryTypeType = (CustomSummaryType) Enum.Parse(typeof (CustomSummaryType), defaultType);

            return summaryTypeType;
        }

        private static Dictionary<Type, CustomSummaryType> GetSummaryTypeDictionary()
        {
            var dictionary = new Dictionary<Type, CustomSummaryType>();
            foreach (string key in m_SummaryTypeSection.AllKeys)
            {
                Type type = Type.GetType(key, false, true);
                if (type != null)
                {
                    string value = m_SummaryTypeSection[key];
                    var summaryTypeType =
                        (CustomSummaryType) Enum.Parse(typeof (CustomSummaryType), value);
                    dictionary.Add(type, summaryTypeType);
                }
            }
            return dictionary;
        }

        private static Dictionary<string, CustomSummaryType> GetFieldSummaryTypeDictionary()
        {
            var dictionary = new Dictionary<string, CustomSummaryType>();

            foreach (string key in m_FieldSummaryTypeSection.AllKeys)
            {
                string value = m_FieldSummaryTypeSection[key];
                var summaryTypeType = (CustomSummaryType) Enum.Parse(typeof (CustomSummaryType), value);
                dictionary.Add(key, summaryTypeType);
            }
            return dictionary;
        }
    }
}