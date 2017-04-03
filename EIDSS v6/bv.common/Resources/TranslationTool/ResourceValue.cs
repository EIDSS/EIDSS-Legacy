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
        //public string RawValue { get; set; }
        public string EnglishText { get; set; }
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
    }
}
