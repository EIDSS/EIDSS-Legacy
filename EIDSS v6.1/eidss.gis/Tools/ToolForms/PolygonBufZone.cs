using System.Windows.Forms;
using bv.common;
using bv.winclient.Core;
using eidss.gis.Properties;

namespace eidss.gis.Tools.ToolForms
{
    public partial class PolygonBufZone : BvForm
    {
        public PolygonBufZone()
        {
            InitializeComponent();
        }

        #region Private

        private string m_ZoneName, m_Description;
        
        #endregion

        #region Properties

        public string ZoneName
        {
            get { return m_ZoneName; }
            set
            {
                m_ZoneName = value;
                textName.Text = m_ZoneName;
            }
        }

        public string Description
        {
            get { return m_Description; }
            set
            {
                m_Description = value;
                textDescription.Text = m_Description;
            }
        }

        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            m_ZoneName = textName.Text;
            m_Description = textDescription.Text;
        }

        private void PolygonBufZone_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                e.Cancel = false;
                return;
            }
            if (string.IsNullOrEmpty(m_ZoneName))
            {
                WinUtils.ShowMandatoryError(labelControl1.Text);
                e.Cancel = true;
            }
        }


        #endregion
    }
}