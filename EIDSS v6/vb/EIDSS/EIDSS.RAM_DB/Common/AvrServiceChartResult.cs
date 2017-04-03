using System;
using eidss.model.AVR.ServiceData;

namespace eidss.avr.db.Common
{
    public class AvrServiceChartResult : AvrModelResult<ChartExportDTO>
    {
        public AvrServiceChartResult(ChartExportDTO model)
            : base(model)
        {
        }

        public AvrServiceChartResult(string errorMessage, Exception innerException = null) : base(errorMessage, innerException)
        {
            Model = new ChartExportDTO();
        }
    }
}