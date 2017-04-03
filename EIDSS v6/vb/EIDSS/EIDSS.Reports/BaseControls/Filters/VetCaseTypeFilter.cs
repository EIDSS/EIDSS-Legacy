using System;
using System.ComponentModel;
using System.Drawing;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class VetCaseTypeFilter : BaseFilter
    {
        /// <summary>
        ///     Fires immediately after lookup edit value has been changed
        /// </summary>
        public event EventHandler<SingleFilterEventArgs> ValueChanged;

        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetCaseTypeFilter));

        public VetCaseTypeFilter()
        {
            InitializeComponent();
            radioGroup.BackColor = Color.Transparent;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long? EditValue
        {
            get { return (long?) radioGroup.EditValue; }
            set { radioGroup.EditValue = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get
            {
                if (radioGroup.SelectedIndex < 0)
                {
                    return "";
                }
                return radioGroup.Properties.Items[radioGroup.SelectedIndex].Description;
            }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(this, "$this");
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = radioGroup.Properties.Items[radioGroup.SelectedIndex].Description;
            EventHandler<SingleFilterEventArgs> tmpHandler = ValueChanged;
            if (tmpHandler != null)
            {
                tmpHandler(sender, new SingleFilterEventArgs((long) radioGroup.EditValue, value, false));
            }
        }
    }
}