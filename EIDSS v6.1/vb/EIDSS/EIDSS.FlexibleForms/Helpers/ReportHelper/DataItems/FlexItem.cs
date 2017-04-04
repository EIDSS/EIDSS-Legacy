using System.Data;
using System.Drawing;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems
{
    /// <summary>
    /// base class for item that represents flex form entity
    /// </summary>
    public abstract class FlexItem
    {
        private int m_Width = ReportSettings.DefaultItemWidth;
        private int m_Height = ReportSettings.DefaultItemHeight;
        private Color m_Color = ReportSettings.DefaultItemColor;

        /// <summary>
        /// 
        /// </summary>
        public int Order { get; protected set; }

        /// <summary>
        /// Связанный объект
        /// </summary>
        public DataRow LinkedObject { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
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