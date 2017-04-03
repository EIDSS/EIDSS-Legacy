using bv.common.Core;
using bv.common.Enums;

namespace eidss.avr.service.VirtualLayout
{
    public class EmptyPostableForm : IPostable
    {
        public static readonly object SyncRoot = new object();

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