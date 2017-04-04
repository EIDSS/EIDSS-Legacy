using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using bv.common.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;

namespace EIDSS.Reports.BaseControls
{
    public class AccessRigthsRebinder
    {
        private readonly XtraReport m_Report;

        public AccessRigthsRebinder(XtraReport report)
        {
            Utils.CheckNotNull(report, "report");
            m_Report = report;
        }

        public void Process()
        {
            List<string> denyValues = GetForbiddenFields(m_Report.GetType().Name);

            if (denyValues.Count > 0)
            {
                const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
                Type labelType = typeof (XRLabel);
                FieldInfo[] fields = m_Report.GetType().GetFields(flags);

                foreach (FieldInfo info in fields)
                {
                    if (labelType.IsAssignableFrom(info.FieldType))
                    {
                        var label = (XRLabel) info.GetValue(m_Report);
                        if (label.DataBindings.Any(b => denyValues.Contains(b.DataMember)))
                        {
                            label.DataBindings.Clear();
                            label.Text = "*";
                        }
                    }
                }
            }
        }

        public static bool ForbiddenAccess(PersonalDataGroup group)
        {
            return EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group);
        }

        private List<string> GetForbiddenFields(string objectName)
        {
            var result = new List<string>();
            foreach (KeyValuePair<PersonalDataGroup, Dictionary<string, List<string>>> pair in EidssSecurityManager.PersonalDataDictionary)
            {
                if (ForbiddenAccess(pair.Key))
                {
                    Dictionary<string, List<string>> objectRights = pair.Value;
                    foreach (KeyValuePair<string, List<string>> right in objectRights)
                    {
                        if (right.Key == objectName)
                        {
                            result.AddRange(right.Value);
                        }
                    }
                }
            }
            return result;
        }
    }
}