using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using DevExpress.XtraEditors;

namespace bv.winclient.Core
{
    public partial class BvForm : XtraForm, IApplicationForm
    {
        public BvForm()
        {
            InitializeComponent();
            KeyDown += BaseForm_KeyDown;
            KeyPreview = true;

        }

        public bool Close(FormClosingMode closeMode)
        {
            Close();
            return true;
        }

        public new Control Activate()
        {
            base.Activate();
            BringToFront();
            return this;
        }

        [Browsable(true), Localizable(false)]
        public bool Sizable { get; set; }

        [Browsable(false)]
        public virtual string Caption
        {
            get { return Text; }
        }

        [Browsable(false)]
        public object Key
        {
            get { return null; }
        }
        public Dictionary<string, object> StartUpParameters { get; set; }


        public void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (!string.IsNullOrWhiteSpace(HelpTopicId))
                    ShowHelp(HelpTopicId);
            }            
        }
        [Browsable(true), Localizable(false)]
        public string HelpTopicId { get; set; }
        public void Release()
        {
            
        }
        protected void ShowHelp(string helpTopicID)
        {
            if (!WinClientContext.HelpNames.ContainsKey(ModelUserContext.CurrentLanguage))
                return;
            BV.Tools.MSHelp2Support.Help2.ShowHelp(this, WinClientContext.HelpNames[ModelUserContext.CurrentLanguage], helpTopicID);
        }



        public void ShowHelp()
        {
            ShowHelp(HelpTopicId);
        }

        [Browsable(false), DefaultValue(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisableDelayedDisposing { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinHeight { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinWidth { get; set; }

        public virtual bool IsSingleTone
        {
            get { return true; }
        }
    }
}