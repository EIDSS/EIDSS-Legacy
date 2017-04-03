using System.Windows.Forms;
using bv.common;
using bv.common.win;
using SharpMap.Geometries;
using eidss.gis.Properties;

namespace eidss.gis.Tools.ToolForms
{
    public partial class CircleBufZone : DevExpress.XtraEditors.XtraForm
    {
        public CircleBufZone()
        {
            InitializeComponent();
        }

        #region Private

        private string m_ZoneName, m_Description;
        private double m_Radius;
        
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

        public double Radius
        {
            get { return m_Radius; }
            set 
            { 
                m_Radius = value;
                spinRadius.Value = (decimal) (m_Radius / 1000);
            }
        }

        #endregion

        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            m_ZoneName = textName.Text;
            m_Description = textDescription.Text;
            m_Radius = (double) (spinRadius.Value * 1000);
        }

        private void CircleBufZone_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                e.Cancel = false;
                return;
            }
            if (string.IsNullOrEmpty(m_ZoneName))
            {
                ErrorForm.ShowError(
                    new ErrorMessage("ErrMandatoryFieldRequired",
                        Resources.gis_BufZonesLayer_MandatoryFieldRequiredError, null, 
                        labelControl1.Text));

                e.Cancel = true;
            }
        }
    }
}
