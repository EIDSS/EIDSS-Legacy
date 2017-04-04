using System;
using System.Data;
using eidss.model.Avr.View;

namespace eidss.avr.db.Common
{
    public class AvrServicePivotResult : AvrModelResult<AvrPivotViewModel>
    {
        public AvrServicePivotResult(AvrPivotViewModel model) : base(model)
        {
        }

        public AvrServicePivotResult(string errorMessage, Exception innerException = null) : base(errorMessage, innerException)
        {
            Model = new AvrPivotViewModel(new AvrView(), new DataTable());
        }
    }
}