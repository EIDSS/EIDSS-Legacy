using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.common.Resources.TranslationTool
{
    public class ResourceValue
    {
        /// <summary>
        /// Stores resource value, in can be as string as any other usable type like Point or Location
        /// For strings it stores formatted value - as it will be displayed in interface 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Contains unformatted resource value for strings
        /// </summary>
        private string m_EnglishCaption;
        public string EnglishText
        {
            get
            {
                if (string.IsNullOrEmpty(m_EnglishCaption) && Value is string) 
                    return (string) Value;
                return m_EnglishCaption;
            }
            set { m_EnglishCaption = value; }
        }
        /// <summary>
        /// Optional comment for resource item
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Stores file name for exclusion items. The empty value means that resource is taken from resource file related with ITranslationView
        /// </summary>
        //public string SourceFileName { get; set; }
        /// <summary>
        /// Stores key for extracting value from SourceFileName
        /// </summary>
        public string SourceKey { get; set; }

        public string ResourceName { get; set; }

        public bool IsSplitted { get; set; }
        public bool Modified { get; set; }
    }
}
