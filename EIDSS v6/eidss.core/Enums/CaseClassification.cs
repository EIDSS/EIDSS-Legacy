using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Enums
{
    //Only system values are added to this enum
    //if other system values will apperar, enum shall be updated
    public enum CaseClassification: long
    {
        Confirmed = 350000000,
        Probabale = 360000000,
        Suspect = 380000000
    }
}
