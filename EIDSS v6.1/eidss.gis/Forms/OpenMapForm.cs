using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.winclient.Core;

namespace eidss.gis.Forms
{
    public partial class OpenMapForm : BvForm
    {
        public OpenMapForm()
        {
            InitializeComponent();
        }

        private List<string> m_MapProjectsList;
        public void SetMapList(List<string> list)
        {
            m_MapProjectsList = list;
            mapsListBox.DataSource = m_MapProjectsList;
        }

        private string m_MapName;

        public string MapName
        {
            get { return m_MapName; } 
        }

        private void mapsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mapsListBox.SelectedItem != null)
            {
                m_MapName = mapsListBox.SelectedItem.ToString();
                okButton.Enabled = true;
            }
        }

        //private bool m_Flag;
        private void mapsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if (m_Flag)
                m_MapName = mapsListBox.SelectedItem.ToString();
                okButton.Enabled = true;
            //else
                //m_Flag = true;
        }
    }
}