using System.Drawing;

namespace eidss.model.Avr.Chart
{
    public interface IBarProperties
    {
        double BarWidth { get; set; }
        Color Color { get; }
        int ColorArgb { get; set; }
        int FillMode { get; set; }
    }
}
