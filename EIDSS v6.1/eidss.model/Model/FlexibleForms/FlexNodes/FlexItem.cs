using System.Drawing;
using eidss.model.Model.Report;

namespace eidss.model.Model.FlexibleForms.FlexNodes
{
    /// <summary>
    /// base class for item that represents flex form entity
    /// </summary>
    public class FlexItem
    {
        public FlexItem(object ffObject)
        {
            LinkedObject = ffObject;
        }

        public int Order { get; protected set; }
        public object LinkedObject { get; protected set; }

        private int m_Width = ReportSettings.DefaultItemWidth;
        private int m_Height = ReportSettings.DefaultItemHeight;
        private Color m_Color = ReportSettings.DefaultItemColor;

        public Color Color
        {
            get { return m_Color; }
            protected set { m_Color = value; }
        }

        public int Top { get; internal set; }

        public int Left { get; internal set; }

        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }

        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }

        public override string ToString()
        {
            return string.Format("({0},{1}) {2}x{3}", Left, Top, Width, Height);
        }
    }
}