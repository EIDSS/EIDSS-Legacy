using System;
using bv.common.Enums;
using bv.common.win;

namespace bv.tests.AVR.Helpers.Fake
{
    public class BaseFormStub : BaseForm
    {
        public override bool Post(PostType postType = PostType.FinalPosting)
        {
            switch (postType)
            {
                case PostType.FinalPosting:
                    return true;
                case PostType.IntermediatePosting:
                    return false;
            }
            throw new ApplicationException("not implemented");
        }
    }
}