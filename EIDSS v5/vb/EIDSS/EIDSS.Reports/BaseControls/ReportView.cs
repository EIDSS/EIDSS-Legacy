using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using HScrollBar = DevExpress.XtraEditors.HScrollBar;
using VScrollBar = DevExpress.XtraEditors.VScrollBar;

namespace EIDSS.Reports.BaseControls
{
    public partial class ReportView : UserControl
    {
        private const float ZoomLandscape = 0.75f;
        private const float ZoomDefault = 1f;

        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ReportView));
        private bool m_IsBarcode;
        private bool m_ReportInitializing;
        private XtraReport m_Report;
        public event EventHandler OnReportEdit;
        public event EventHandler OnReportLoadDefault;

        public ReportView()
        {
            InitializeComponent();
            printControlReport.VScrollBar.Visible = false;
            printControlReport.HScrollBar.Visible = false;
            timerScroll.Start();
        }

        [DefaultValue(false)]
        [Browsable(true)]
        public bool IsBarcode
        {
            get { return m_IsBarcode; }
            set
            {
                m_IsBarcode = value;
                AjustToolbar();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public XtraReport Report
        {
            get { return m_Report; }
            set
            {
                if (m_Report == value)
                    return;
                try
                {
                    m_ReportInitializing = true;
                    if (m_Report != null)
                        m_Report.Dispose();
                    m_Report = value;
                    if (m_Report != null)
                    {
                        printControlReport.PrintingSystem = m_Report.PrintingSystem;
                        m_Report.PrintingSystem.ClearContent();
                        Invalidate();
                        Update();

                        var baseReport = m_Report as BaseReport;
                        if (baseReport != null && baseReport.ChildReport != null)
                        {
                            baseReport.CreateDocument();

                            baseReport.ChildReport.CreateDocument();
                            baseReport.Pages.AddRange(baseReport.ChildReport.Pages);
                            baseReport.PrintingSystem.ContinuousPageNumbering = true;
                        }
                        else
                        {
                            m_Report.CreateDocument(true);    
                        }
                        
                        
                        

                        m_Report.PrintingSystem.PageSettings.Landscape = m_Report.Landscape;
                        printControlReport.Zoom = m_Report.Landscape ? ZoomLandscape : ZoomDefault;
                        printControlReport.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
                        if (printControlReport.Zoom > 1)
                            printControlReport.Zoom = 1;
                        AjustToolbar();
                        biLoadDefault.Enabled = true;
                        biEdit.Enabled = true;
                    }
                }
                finally
                {
                    m_ReportInitializing = false;
                }
            }
        }

        [Browsable(false)]
        internal float Zoom
        {
            get { return printControlReport.Zoom; }
            set { printControlReport.Zoom = value; }
        }

        private void AjustToolbar()
        {
            if (WinUtils.IsComponentInDesignMode(this))
                return;

            BarItemVisibility visibility = (IsBarcode) ? BarItemVisibility.Always : BarItemVisibility.Never;
            biEdit.Visibility = visibility;
            biLoadDefault.Visibility = visibility;

            var itemsToRemove = new List<BarItem>();
            itemsToRemove.AddRange(new BarItem[] {biExportHtm, biExportMht});
            foreach (BarItem item in printBarManager.Items)
            {
                if ((item is PrintPreviewBarItem) && (string.IsNullOrEmpty(item.Name)))
                    itemsToRemove.Add(item);
            }

            if (IsBarcode)
            {
                itemsToRemove.AddRange(new BarItem[]
                                           {
                                               biFind, biPageSetup, biScale, biMagnifier,
                                               biMultiplePages,
                                               biMultiplePages, biFillBackground, biExportFile
                                           });
            }
            if (
                !EidssUserContext.User.HasPermission(
                    PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanImportExportData)))
                itemsToRemove.Add(biExportFile);
            RemoveFromToolbar(itemsToRemove, printBarManager, previewBar1);
        }

        private void timerScroll_Tick(object sender, EventArgs e)
        {
            if (m_ReportInitializing && m_Report.PrintingSystem.Document.IsCreating)
                return;

            
            VScrollBar vScrollBar = printControlReport.VScrollBar;
            bool verticalVisible = (vScrollBar.Maximum >
                                    vScrollBar.Bounds.Height - vScrollBar.Bounds.Y +
                                    2 * SystemInformation.HorizontalScrollBarHeight);
            if (vScrollBar.Visible != verticalVisible)
                vScrollBar.Visible = verticalVisible;

            HScrollBar hScrollBar = printControlReport.HScrollBar;
            bool horisontalVisible = (hScrollBar.Maximum >
                                      hScrollBar.ClientSize.Width + SystemInformation.VerticalScrollBarWidth);
            if (hScrollBar.Visible != horisontalVisible)
                hScrollBar.Visible = horisontalVisible;
        }

        public static void RemoveFromToolbar
            (ICollection<BarItem> itemsToRemove, PrintBarManager barManager, PreviewBar previewBar)
        {
            foreach (BarItem item in itemsToRemove)
            {
                barManager.Items.Remove(item);
            }

            var linksToRemove = new List<LinkPersistInfo>();
            foreach (LinkPersistInfo linksInfo in previewBar.LinksPersistInfo)
            {
                if (itemsToRemove.Contains(linksInfo.Item))
                    linksToRemove.Add(linksInfo);
            }

            foreach (LinkPersistInfo linksInfo in linksToRemove)
            {
                previewBar.LinksPersistInfo.Remove(linksInfo);
            }
        }

        private void biEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EventHandler handler = OnReportEdit;
            if (handler != null)
                handler(sender, e);
        }

        private void biLoadDefault_ItemClick(object sender, ItemClickEventArgs e)
        {
            EventHandler handler = OnReportLoadDefault;
            if (handler != null)
                handler(sender, e);
        }

        internal void ApplyResources()
        {
            m_Resources.ApplyResources(printControlReport, "printControlReport");
            m_Resources.ApplyResources(previewBar1, "previewBar1");
            m_Resources.ApplyResources(biFind, "biFind");
            m_Resources.ApplyResources(biPrint, "biPrint");
            m_Resources.ApplyResources(biPrintDirect, "biPrintDirect");
            m_Resources.ApplyResources(biPageSetup, "biPageSetup");
            m_Resources.ApplyResources(biScale, "biScale");
            m_Resources.ApplyResources(biHandTool, "biHandTool");
            m_Resources.ApplyResources(biMagnifier, "biMagnifier");
            m_Resources.ApplyResources(biZoomOut, "biZoomOut");
            m_Resources.ApplyResources(biZoom, "biZoom");
            m_Resources.ApplyResources(ZoomIn, "ZoomIn");
            m_Resources.ApplyResources(biShowFirstPage, "biShowFirstPage");
            m_Resources.ApplyResources(biShowPrevPage, "biShowPrevPage");
            m_Resources.ApplyResources(biShowNextPage, "biShowNextPage");
            m_Resources.ApplyResources(biShowLastPage, "biShowLastPage");
            m_Resources.ApplyResources(biMultiplePages, "biMultiplePages");
            m_Resources.ApplyResources(biExportFile, "biExportFile");
            m_Resources.ApplyResources(barStatus, "previewBar2");
            m_Resources.ApplyResources(biPage, "printPreviewStaticItem1");
            m_Resources.ApplyResources(biProgressBar, "progressBarEditItem1");
            m_Resources.ApplyResources(biStatusStatus, "printPreviewBarItem1");
            m_Resources.ApplyResources(biStatusZoom, "printPreviewStaticItem2");
            m_Resources.ApplyResources(barMainMenu, "previewBar3");
            m_Resources.ApplyResources(printPreviewSubItem4, "printPreviewSubItem4");
            m_Resources.ApplyResources(printPreviewBarItem27, "printPreviewBarItem27");
            m_Resources.ApplyResources(printPreviewBarItem28, "printPreviewBarItem28");
            m_Resources.ApplyResources(barToolbarsListItem1, "barToolbarsListItem1");
            m_Resources.ApplyResources(biExportPdf, "biExportPdf");
            m_Resources.ApplyResources(biExportHtm, "biExportHtm");
            m_Resources.ApplyResources(biExportMht, "biExportMht");
            m_Resources.ApplyResources(biExportRtf, "biExportRtf");
            m_Resources.ApplyResources(biExportXls, "biExportXls");
            m_Resources.ApplyResources(biExportCsv, "biExportCsv");
            m_Resources.ApplyResources(biExportTxt, "biExportTxt");
            m_Resources.ApplyResources(biExportGraphic, "biExportGraphic");
            m_Resources.ApplyResources(biFillBackground, "biFillBackground");

            m_Resources.ApplyResources(printPreviewBarItem2, "printPreviewBarItem2");
            m_Resources.ApplyResources(this, "$this");
        }
    }
}