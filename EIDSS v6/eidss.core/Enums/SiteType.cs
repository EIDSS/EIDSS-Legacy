using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Enums
{
    public enum SiteType:long
    {
        Undefined = 0,
        CDR = 10085001,
        SLVL = 10085002,
        GDR = 10085003,
        TRV = 10085004,
        PACS = 10085005,
        ProxyEMS = 10085006,
        TLVL = 10085007
    }
}
