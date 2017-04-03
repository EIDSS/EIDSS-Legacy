using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Enums
{
    public enum ContainerStatus : long
    {
        Accessioned = 10015007,
        Destroyed = 10015009,
        OutOfRepository = 10015010,
        Destroy = 10015003,
        Delete = 10015002,
        IsDeleted = 10015008
    }
}
