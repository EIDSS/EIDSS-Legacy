using System.Drawing;
using System.Windows.Forms;
using bv.common.Core;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public class ScreenSaver
    {
        private readonly PictureBox m_ScreenSaver;
        private readonly Control m_SizeControl;
        private Control m_Screen;

        public ScreenSaver(Control parentControl, Control sizeControl)
        {
            Utils.CheckNotNull(parentControl, "parentControl");
            Utils.CheckNotNull(sizeControl, "sizeControl");

            m_SizeControl = sizeControl;

            m_ScreenSaver = new PictureBox();

            CopySizeFrom(sizeControl, m_ScreenSaver);

            m_ScreenSaver.Visible = false;
            m_ScreenSaver.Parent = parentControl;

            m_ScreenSaver.BringToFront();
        }

        public Control DefaultScreen
        {
            get
            {
                var defaultScreen = new Panel();
                CopySizeFrom(m_SizeControl, defaultScreen);
                return defaultScreen;
            }
        }

        public Control Screen
        {
            get { return m_Screen; }
            set
            {
                m_Screen = value;
                bool valueNotNull = (value != null);
                m_ScreenSaver.Visible = valueNotNull;
                if (valueNotNull)
                {
                    CopySizeFrom(value, m_ScreenSaver);

                    var bmp = new Bitmap(value.Width, value.Height);
                    value.DrawToBitmap(bmp, value.ClientRectangle);
                    m_ScreenSaver.Image = bmp;
                    m_ScreenSaver.Visible = true;
                    m_ScreenSaver.BringToFront();
                }
            }
        }

        private static void CopySizeFrom(Control fromControl, Control toControl)
        {
            Utils.CheckNotNull(fromControl, "fromControl");
            Utils.CheckNotNull(toControl, "toControl");

            toControl.Size = fromControl.Size;
            toControl.Left = fromControl.Left;
            toControl.Top = fromControl.Top;
        }
    }
}