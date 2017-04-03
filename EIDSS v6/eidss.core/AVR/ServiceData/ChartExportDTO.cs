using System;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class ChartExportDTO
    {
        public ChartExportDTO()
        {
            JpgBytes = new byte[0];
            ChartSettings = new byte[0];
        }

        public ChartExportDTO(byte[] jpgBytes, byte[] chartSettings)
        {
            JpgBytes = jpgBytes;
            ChartSettings = chartSettings;
        }

        public byte[] JpgBytes { get; set; }
        public byte[] ChartSettings { get; set; }
    }
}