using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using System.Collections.Specialized;

namespace bv.model.Model.Core
{
    public interface IObjectEnvironment
    {
        bool ReadOnly { get; }
    }
}
