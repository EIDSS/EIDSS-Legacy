using System;
using System.Globalization;
using bv.common.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class BaseThaiDateModel : BaseDateModel
    {
        public BaseThaiDateModel()
        {
        }

        public BaseThaiDateModel(string language, int year, int? month, bool useArchive)
            : base(language, year, month,useArchive)
        {
        }

        public override int MinYear
        {
            get { return Language == Localizer.lngThai ? 2550 : 2000; }
        }

        public override int MaxYear
        {
            get
            {
                return Language == Localizer.lngThai
                           ? new ThaiBuddhistCalendar().GetYear(DateTime.Today)
                           : DateTime.Today.Year;
            }
        }
    }
}
