using System;
using System.Linq;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class CustomReportRow
    {
        protected static void CustomValidations(CustomReportRow crr)
        {
            if (crr.Master == null) return;
            if (crr.Master.CustomReportRows == null) return;
            if (crr.Master.CustomReportRows.Count(s => (s.GetKey() == crr.GetKey()) && (s.idfReportRows != crr.idfReportRows) && !s.IsMarkedToDelete) > 0)
            {
                throw new ValidationModelException("msgCustomReportRowsUniqueID", "idfsCustomReportType", "idfsCustomReportType", new object[] { }, null, ValidationEventType.Error, crr);
            }
        }

        public string GetKey()
        {
            return String.Format("{0}_{1}", idfsCustomReportType, idfsDiagnosisOrReportDiagnosisGroup);
        }
    }
}
