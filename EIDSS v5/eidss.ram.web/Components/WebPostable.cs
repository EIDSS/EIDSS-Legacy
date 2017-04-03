using System;
using bv.common;
using bv.common.Core;

namespace eidss.ram.web.Components
{
    public class WebPostable : IPostable
    {
        public bool HasChanges()
        {
            return false;
        }

        public bool Post(PostType PostType)
        {
            return true;
            
        }
    }
}