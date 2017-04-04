using bv.common.Enums;

namespace bv.common.Core
{
    public interface IPostable
    {
        bool HasChanges();
        bool Post(PostType postType = PostType.FinalPosting);
    }
}