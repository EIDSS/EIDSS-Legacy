using System.Drawing;

namespace eidss.model.Avr.Chart
{
    public interface ILineProperties
    {
        Color Color { get; }
        int ColorArgb { get; set; }
        int LineStyle { get; set; }
        int LineStyleWidth { get; set; }
        bool ShadowVisible { get; set; }
    }
}
