using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using EIDSS.Reports.Barcode.Designer.Events;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.BaseControls.Keeper;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.Barcode.Designer
{
    public partial class DesignForm
    {
        private readonly List<float> m_AvaliableZoom = new List<float>(new[] {1, 2, 2.8f});
        private ReportState m_RealState;
        public event EventHandler<DesignerSaveEventArgs> OnReportSave;
        public event EventHandler OnReportLoadDefault;
        private Control m_Statusbar;

        public DesignForm()
        {
            InitializeComponent();
        }

        public DesignForm(XtraReport report)
        {
            using (BarCodeForm.CreateDialog())
            {
                InitializeComponent();

                xrDesignMdiController1.OpenReport(report);
                Zoom = BaseBarcodeKeeper.BarcodeZoom;

                DesignPanel.ReportStateChanged += ActiveXRDesignPanel_ReportStateChanged;
            }
        }

        protected override void Dispose(bool disposing)
        {
            HidePopupTimer.Stop();
            if (DesignPanel != null)
            {
                DesignPanel.ReportStateChanged -= ActiveXRDesignPanel_ReportStateChanged;
            }
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public float Zoom
        {
            set
            {
                float newZoom = m_AvaliableZoom.Contains(value) ? value : 1;
                DesignPanel.ExecCommand(ReportCommand.Zoom, new object[] {newZoom});
            }
        }

        public XRDesignPanel DesignPanel
        {
            get { return xrDesignMdiController1.ActiveDesignPanel; }
        }

        private void ActiveXRDesignPanel_ReportStateChanged(object sender, ReportStateEventArgs e)
        {
            switch (e.ReportState)
            {
                case ReportState.Changed:
                    m_RealState = e.ReportState;
                    DesignPanel.ReportState = ReportState.Opened;
                    biSave.Enabled = true;
                    break;
                case ReportState.Saved:
                    m_RealState = e.ReportState;
                    biSave.Enabled = false;
                    break;
            }
        }

        private void biSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnReportSave.SafeRaise(this, new DesignerSaveEventArgs(DesignPanel.Report));
            DesignPanel.ReportState = ReportState.Saved;
        }

        private void biRestoreDefault_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageForm.Show(BvMessages.Get("msgLoadDefaultReport", "Load default report?"),
                                                         BvMessages.Get("Confirmation"),
                                                         MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                m_RealState = ReportState.None;
                Hide();
                OnReportLoadDefault.SafeRaise(this, EventArgs.Empty);
                Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_RealState != ReportState.Changed)
            {
                return;
            }

            DialogResult dialogResult = MessageForm.Show(BvMessages.Get("Save data?"),
                                                         BvMessages.Get("Confirmation"),
                                                         MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;

                    break;
                case DialogResult.Yes:
                    OnReportSave.SafeRaise(this, new DesignerSaveEventArgs(DesignPanel.Report));
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HideAllToolBoxExceptLabelButton();

            HideDesignerExtraTabPages();

            HideTray(this);

            HideStatusBar(this);

            HideSplitter(this);

            SubscribeMouseClickOnReport(this);

            AjustButtonsVisibility();

            DesignPanel.RemoveService(typeof (IMenuCommandService));
            DesignPanel.AddService(typeof (IMenuCommandService), new MenuCommandServiceStub());

            HidePopupTimer.Start();
        }

        private void HideAllToolBoxExceptLabelButton()
        {
            if (bar2.ItemLinks.Count > 1)
            {
                for (int i = bar2.ItemLinks.Count - 1; i >= 0; i--)
                {
                    BarItemLink labelLink = bar2.ItemLinks[i];
                    if (i != 1)
                    {
                        bar2.RemoveLink(labelLink);
                    }
                    else
                    {
                        labelLink.Item.Glyph = null;
                        labelLink.Item.ImageIndex = 3;
                        labelLink.Item.Caption = EidssMessages.Get("msgBarcodeAddLabelCaption", "Add new label");
                        labelLink.Item.Hint = EidssMessages.Get("msgBarcodeAddLabelHint", "Add new label");
                    }
                }
            }
        }

        private void HideDesignerExtraTabPages()
        {
            if ((DesignPanel.Controls.Count > 0) && (DesignPanel.Controls[0] is ReportTabControl))
            {
                var tabControl = (ReportTabControl) DesignPanel.Controls[0];
                tabControl.ShowPrintPreviewBar = false;
                tabControl.ShowTabButtons = false;
                // Note: need to switch selected index to force internal logic for hiding tab buttons
                tabControl.SelectedIndex = 3;
                tabControl.SelectedIndex = 0;
            }
        }

        private void HideTray(Control parent)
        {
            if (parent == null)
            {
                return;
            }

            if (parent.GetType().ToString() == "DevExpress.XtraReports.Design.ComponentTrayEx")
            {
                parent.Visible = false;
            }
            else
            {
                foreach (Control child in parent.Controls)
                {
                    HideTray(child);
                }
            }
        }

        private void HideSplitter(Control parent)
        {
            if (parent == null)
            {
                return;
            }

            if (parent is Splitter && (parent).Dock == DockStyle.Bottom && parent.Parent is ReportFrame)
            {
                parent.Visible = false;
            }
            else
            {
                foreach (Control child in parent.Controls)
                {
                    HideSplitter(child);
                }
            }
        }

        private void AjustButtonsVisibility()
        {
            biSave.Enabled = false;
            biGetOriginal.Enabled = true;
        }

        private void HideStatusBar(Control parent)
        {
            if (parent == null)
            {
                return;
            }

            if (m_Statusbar == null)
            {
                if (parent is DockedBarControl)
                {
                    var barControl = ((DockedBarControl) parent);
                    if ((barControl.Bar != null) && (barControl.Bar.BarName == @"Status Bar"))
                    {
                        m_Statusbar = barControl.Parent;

                        m_Statusbar.Visible = false;
                        barControl.Parent.VisibleChanged += StatusBar_VisibleChanged;
                    }
                }
                else
                {
                    foreach (Control child in parent.Controls)
                    {
                        HideStatusBar(child);
                    }
                }
            }
        }

        private void StatusBar_VisibleChanged(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                ((Control) sender).Visible = false;
            }
        }

        private void SubscribeMouseClickOnReport(Control parent)
        {
            if (parent == null)
            {
                return;
            }
            if (parent.GetType().ToString() == @"DevExpress.XtraReports.Design.FramePanel")
            {
                parent.MouseClick += FramePanel_MouseClick;
                parent.MouseMove += FramePanel_MouseMove;
            }

            foreach (Control child in parent.Controls)
            {
                SubscribeMouseClickOnReport(child);
            }
        }

        private void FramePanel_MouseClick(object sender, MouseEventArgs e)
        {
            var service = (XRSmartTagService) DesignPanel.GetService(typeof (XRSmartTagService));
            if (service != null)
            {
                service.HidePopup(false);
            }
        }

        private void FramePanel_MouseMove(object sender, MouseEventArgs e)
        {
            HidePopupTimer_Tick(sender, e);
        }

        private void HidePopupTimer_Tick(object sender, EventArgs e)
        {
            if (DesignPanel == null)
                return;
            var service = (XRSmartTagService) DesignPanel.GetService(typeof (XRSmartTagService));
            if (service != null && service.PopupIsVisible)
            {
                service.HidePopup(false);
            }
        }
    }
}