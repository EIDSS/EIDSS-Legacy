using System;
using bv.model.Helpers;

namespace eidss.model.Schema
{
    public partial class BasicSyndromicSurveillanceItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? GetYears()
        {
            int? years = 0;
            if ((Patient != null) && (Patient.datDateofBirth != null))
            {
                var yyAge = DateHelper.DateDifference(DateInterval.Year, Patient.datDateofBirth.Value.Date, datDateEntered);
                if (yyAge > 0) years = Convert.ToInt32(yyAge);
            }
            return years;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? GetMonths()
        {
            int? months = 0;
            if ((Patient != null) && (Patient.datDateofBirth != null))
            {
                var yyMonths = DateHelper.DateDifference(DateInterval.Month, Patient.datDateofBirth.Value.Date, datDateEntered) - 12*GetYears();
                if (yyMonths > 0) months = Convert.ToInt32(yyMonths);
            }
            return months;
        }

        public void SetupChildHandlers()
        {
            Accessor.Instance(null).SetupChildHandlers(this);
            this.Patient.RaisePropChanged();
        }

        partial  class Accessor
        {
            public void SetupChildHandlers(BasicSyndromicSurveillanceItem obj)
            {
                _SetupChildHandlers(obj, null);
            }
        }
    }
}
