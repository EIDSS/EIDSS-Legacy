using System.Drawing;

namespace EIDSS.Reports.BaseControls.Report
{
    public static class ReportChartColors
    {
        static readonly Color[] m_Color =
        {
            Color.Blue,
            Color.Red,
            Color.Green,
            Color.Turquoise,
            Color.Thistle,
            Color.Gold,
            Color.Salmon,
            Color.Navy,
            Color.MediumSeaGreen,
            Color.Orange,
            Color.HotPink,
            Color.Goldenrod,
            Color.IndianRed,
            Color.YellowGreen,
            Color.DarkCyan,
            Color.Maroon,
            Color.RoyalBlue,
            Color.MediumSpringGreen
        };

        public static Color[] SeriesColor
        {
            get { return m_Color; }
        }
    }
}