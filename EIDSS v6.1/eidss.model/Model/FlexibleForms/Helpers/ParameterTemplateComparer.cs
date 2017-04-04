using System.Collections.Generic;
using eidss.model.Schema;

namespace eidss.model.Model.FlexibleForms.Helpers
{
    public class ParameterTemplateComparer : IComparer<ParameterTemplate>
    {
        public int Compare(ParameterTemplate x, ParameterTemplate y)
        {
            return x.intOrder - y.intOrder;
        }
    }
}
