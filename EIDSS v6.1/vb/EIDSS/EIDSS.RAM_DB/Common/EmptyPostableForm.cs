using bv.common.Core;
using bv.common.Enums;

namespace eidss.avr.db.Common
{
    public class EmptyPostableForm : IPostable
    {
        public bool HasChanges()
        {
            return false;
        }

        public bool Post(PostType postType = PostType.FinalPosting)
        {
            return true;
        }
    }
}