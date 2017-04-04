using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common;
using bv.winclient.Core;
using eidss.gis.Data;
using eidss.gis.Properties;

namespace eidss.gis.Tools.ToolForms
{
    public partial class BufZonesLayer : BvForm
    {
        public BufZonesLayer()
        {
            InitializeComponent();
            comboPivot.SelectedIndex = 0;
        }

        #region Private variables

        private string m_ZoneLayerName, m_Description;
        private PivotLayerType m_PivotalLayer;

        #endregion

        #region Properties

        public bool IsAVR { get; set; }

        public string ZoneLayerName
        {
            get { return m_ZoneLayerName; }
            set
            {
                m_ZoneLayerName = value;
                textName.Text = m_ZoneLayerName;
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

        public PivotLayerType PivotalLayer
        {
            get { return m_PivotalLayer; }
            set
            {
                m_PivotalLayer = value;
                comboPivot.SelectedIndex = (int) m_PivotalLayer;
            }
        }

        [DefaultValue(true)]
        public bool PivotComboEnabled
        {
            get { return comboPivot.Enabled; }
            set { comboPivot.Enabled = value; }
        }

        #endregion

        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            m_ZoneLayerName = textName.Text;
            m_Description = textDescription.Text;
            m_PivotalLayer = (PivotLayerType) comboPivot.SelectedIndex;
            if (!IsAVR && m_PivotalLayer > 0) m_PivotalLayer++; 
        }

        private void BufZonesLayer_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                e.Cancel = false;
                return;
            }
            if (string.IsNullOrEmpty(m_ZoneLayerName))
            {
                WinUtils.ShowMandatoryError(labelControl1.Text);
                e.Cancel = true;
            }

            var dict = (Dictionary<Guid, string>)UserDbLayersManager.GetLayersNames(UserDbLayerType.BuffZones);
            if (dict.ContainsValue(m_ZoneLayerName))
            {
                ErrorForm.ShowWarningFormat("gisErrBufZoneNameDuplication", "", textName.Text);

                e.Cancel = true;
            }
        }

        private void BufZonesLayer_Load(object sender, System.EventArgs e)
        {
            if (comboPivot.Properties.Items.Count > 1 && !IsAVR)
                comboPivot.Properties.Items.Remove(comboPivot.Properties.Items[1]);
        }
    }
}
