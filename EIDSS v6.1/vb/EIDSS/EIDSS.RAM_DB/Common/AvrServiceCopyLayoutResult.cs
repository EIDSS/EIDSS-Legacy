using System;

namespace eidss.avr.db.Common
{
    public class AvrServiceCopyLayoutResult : AvrModelResult<long>
    {
        public AvrServiceCopyLayoutResult(long model)
            : base(model)
        {
        }

        public AvrServiceCopyLayoutResult(string errorMessage, Exception innerException = null)
            : base(errorMessage, innerException)
        {
            Model = -1;
        }
    }
}