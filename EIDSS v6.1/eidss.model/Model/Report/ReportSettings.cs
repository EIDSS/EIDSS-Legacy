using System.Drawing;

namespace eidss.model.Model.Report
{
    public static class ReportSettings
    {
        public const int Padding = 2;
        public const int DeltaRowHeight = 10;
        public const int DeltaFontSize = 2;
        public const int DefaultFontSize = 8;

        public const int DefaultItemWidth = 100;
        public const int DefaultItemHeight = 50;
        public static Color DefaultItemColor { get; set; }

        static ReportSettings()
        {
            DefaultItemColor = Color.Black;
        }
    }   
}
