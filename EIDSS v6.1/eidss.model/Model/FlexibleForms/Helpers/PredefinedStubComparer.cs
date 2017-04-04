using System.Collections.Generic;
using eidss.model.Schema;

namespace eidss.model.Model.FlexibleForms.Helpers
{
    public class PredefinedStubComparer : IComparer<PredefinedStub>
    {
        public int Compare(PredefinedStub x, PredefinedStub y)
        {
            return x.intOrder - y.intOrder;
        }
    }
}
