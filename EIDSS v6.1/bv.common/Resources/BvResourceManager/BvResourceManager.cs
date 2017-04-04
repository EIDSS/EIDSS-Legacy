using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using bv.common.Core;

namespace bv.common.Resources
{
    public class BvResourceManager : ComponentResourceManager
    {
        public BvResourceManager(Type t) : base(t)
        {
        }
/*
        public override string GetString(string name)
        {
            return base.GetString(name);
        }
        public override object GetObject(string name)
        {
            return base.GetObject(name);
        }
        public override string GetString(string name, CultureInfo culture)
        {
            return base.GetString(name, culture);
        }
        public override object GetObject(string name, CultureInfo culture)
        {
            return base.GetObject(name, culture);
        }
*/
        public override void ApplyResources(object value, string objectName, CultureInfo culture)
        {
            if (value is System.Windows.Forms.ContainerControl && ((System.Windows.Forms.Control)value).Visible && bv.common.Configuration.BaseSettings.TranslationMode && ((System.Windows.Forms.ContainerControl)value).AutoScaleMode != System.Windows.Forms.AutoScaleMode.Inherit)
            {
                ((System.Windows.Forms.ContainerControl)value).AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            }

            base.ApplyResources(value, objectName, culture);
            if (value is System.Windows.Forms.Control && ((System.Windows.Forms.Control)value).Visible)
            {
                using (var value1 = new System.Windows.Forms.Control())
                {
                    base.ApplyResources(value1, objectName, new CultureInfo(CustomCultureHelper.SupportedLanguages[Localizer.lngEn]));
                    if(!value1.Visible)
                        ((System.Windows.Forms.Control)value).Visible = value1.Visible;
                }
            }
        }
/*
        public override System.Resources.ResourceSet GetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
        {
            return base.GetResourceSet(culture, createIfNotExists, tryParents);
        }
*/    }
}
