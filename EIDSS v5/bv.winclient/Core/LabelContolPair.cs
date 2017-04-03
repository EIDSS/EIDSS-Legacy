using System;
using System.Windows.Forms;

namespace bv.winclient.Core
{
	public class LabelControlPair
	{
		
		private readonly Control m_Label;
		private readonly Control[] m_Controls;
		private readonly int m_YLabelShift;
        private readonly int m_Distance = 4;
		public LabelControlPair(Control aLabel, Control aControl)
		{
			m_Label = aLabel;
			m_Controls = new[] {aControl};
			m_YLabelShift = m_Label.Height / 2 - aControl.Height / 2;
		}
		public LabelControlPair(Control aLabel, Control[] aControls, int distance = 4)
		{
			m_Label = aLabel;
			m_Controls = aControls;
			m_YLabelShift = m_Label.Height / 2 - aControls[0].Height / 2;
            m_Distance = distance;
		}
		private bool m_Visible = true;
		public bool Visible
		{
			get
			{
				return m_Visible;
			}
			set
			{
				m_Visible = value;
				m_Label.Visible = value;
				foreach (Control ctl in m_Controls)
				{
					ctl.Visible = value;
				}
			}
		}
		
		public int CaptionWidth
		{
			get
			{
				return m_Label.Width;
			}
		}
		
		public int ControlWidth
		{
			get
			{
			    if (m_Controls.Length > 1)
			        return m_Controls[m_Controls.Length - 1].Width + m_Controls[m_Controls.Length - 1].Left - m_Controls[0].Left;
			    return m_Controls[0].Width;
			}
		}
		
		public void Arrange(int left, int top, int captionWidth, int controlWidth)
		{
			m_Label.Left = left;
			m_Label.Top = top + m_YLabelShift;
			m_Label.Width = captionWidth;
			int singleControlWidth = Convert.ToInt32((controlWidth - (m_Controls.Length - 1) * m_Distance) / m_Controls.Length);
			int x = left + m_Label.Width;
			int ctlLeft = x;
			for (int i = 0; i < m_Controls.Length; i++)
			{
				Control ctl = m_Controls[i];
				ctl.Left = x;
				ctl.Top = top;
				if (i == m_Controls.Length - 1)
				{
					ctl.Width = ctlLeft + controlWidth - ctl.Left;
				}
				else
				{
					ctl.Width = singleControlWidth;
				}
				x += singleControlWidth + m_Distance;
			}
		}
	}
	
}
