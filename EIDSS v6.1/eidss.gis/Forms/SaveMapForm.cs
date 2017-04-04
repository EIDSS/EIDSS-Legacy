using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.winclient.Core;

namespace eidss.gis.Forms
{
    public partial class SaveMapForm : BvForm
    {
        public SaveMapForm()
        {
            InitializeComponent();
        }

        private List<string> m_MapProjectsList;
        public void SetMapList(List<string> list)
        {
            m_MapProjectsList = list;
            mapsListBox.DataSource = m_MapProjectsList;
        }


        private bool m_Flag; 
        private void mapsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( m_Flag )
                mapEdit.Text = mapsListBox.SelectedItem.ToString(); //it's ugly!
            else
                m_Flag = true;
        }

        private void mapsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mapsListBox.SelectedItem != null)
            {
                mapEdit.Text = mapsListBox.SelectedItem.ToString();
            }
        }

        public string MapName
        {
            get { return mapEdit.Text; }
            set { mapEdit.Text = value; }
        }


        private void mapEdit_TextChanged(object sender, EventArgs e)
        {
            //okButton.Enabled = !string.IsNullOrEmpty(mapEdit.Text);
        }
    }
}