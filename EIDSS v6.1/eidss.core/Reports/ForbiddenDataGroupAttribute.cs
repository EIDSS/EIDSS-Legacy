using System;
using System.Collections.Generic;
using eidss.model.Enums;

namespace eidss.model.Reports
{
  [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ForbiddenDataGroupAttribute : Attribute
    {
        private readonly IList<PersonalDataGroup> m_DataGroups;

        public ForbiddenDataGroupAttribute(params PersonalDataGroup[] dataGroup)
        {
            m_DataGroups = new List<PersonalDataGroup>(dataGroup);
        }

        public IList<PersonalDataGroup> DataGroups
        {
            get { return m_DataGroups; }
        }
    }
}