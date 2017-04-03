using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Enums
{
    public enum TestStatus:long
    {
        Completed = 10001001,
        Declined = 10001002,
        InProgress = 10001003,
        PendingApproval = 10001004,
        Undefined = 10001005,
        Amended = 10001006
    }
}
