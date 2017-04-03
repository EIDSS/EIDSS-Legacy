using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using eidss.model.Resources;

namespace EIDSS.RAM.Layout
{
    public partial class LayoutInfoForm : XtraForm
    {
        private readonly LayoutInfoPresenter m_LayoutInfoPresenter;
        private readonly string m_Header;

        public LayoutInfoForm()
        {
            InitializeComponent();
            m_Header = EidssMessages.Get("LayoutTreeEditorHeader", "Layout Tree Editor - ");
            LayoutTreeListKeeper.ReadOnly = false;
         //   Text = m_Header;
        }

        public LayoutInfoForm(LayoutInfoPresenter layoutInfoPresenter) : this()
        {
            m_LayoutInfoPresenter = layoutInfoPresenter;
            LayoutTreeListKeeper.LayoutInfoPresenter = m_LayoutInfoPresenter;
            LayoutTreeListKeeper.OnSelect += LayoutTreeListKeeper_OnSelect;
            LayoutTreeListKeeper.OnSelectChanged += LayoutTreeListKeeper_OnSelectChanged;
            LayoutTreeListKeeper_OnSelect(this, EventArgs.Empty);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            LayoutTreeListKeeper.OnSelect -= LayoutTreeListKeeper_OnSelect;
            LayoutTreeListKeeper.OnSelectChanged -= LayoutTreeListKeeper_OnSelectChanged;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public LayoutTreeListKeeper LayoutTreeListKeeper
        {
            get { return m_LayoutTreeListKeeper; }
        }

        private void LayoutTreeListKeeper_OnSelect(object sender, EventArgs e)
        {
            Text = m_Header + LayoutTreeListKeeper.SelectedPath;
            btnNewFolder.Enabled = RamPermissions.InsertPermission;
            btnDeleteFolder.Enabled = LayoutTreeListKeeper.AllowDeleteFolder;
        }

        private void LayoutTreeListKeeper_OnSelectChanged(object sender, QueryResultValueEventArgs e)
        {
            if (LayoutTreeListKeeper.Cancel)
            {
                btnCancel_Click(sender, e);
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                btnOK_Click(sender, e);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LayoutTreeListKeeper.Cancel = false;
            m_LayoutInfoPresenter.SaveLayoutAndFolders(LayoutTreeListKeeper.DataSourceOriginal,
                                                       LayoutTreeListKeeper.DataSource);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LayoutTreeListKeeper.Cancel = true;
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            LayoutTreeListKeeper.CreateFolder();
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            LayoutTreeListKeeper.DeleteFolder();
        }

      
    }
}