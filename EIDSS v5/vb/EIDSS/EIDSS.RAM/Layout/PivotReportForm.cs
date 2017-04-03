using System;
using System.Collections.Generic;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.BaseControls;
using bv.common;
using bv.common.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;

namespace EIDSS.RAM.Layout
{
    public partial class PivotReportForm : BaseLayoutForm, IPivotReportView
    {
        private PivotReport m_Report;
        private readonly PivotReportPresenter m_ReportPresenter;
        private RamPivotGrid m_CustomSummarySource;

        public PivotReportForm()
        {
            Trace.WriteLine(Trace.Kind.Info, "PivotReportForm creating...");
            InitializeComponent();

            m_ReportPresenter = (PivotReportPresenter) BaseRamPresenter;

            if (IsDesignMode())
            {
                return;
            }

            m_Report = new PivotReport();
            // Note: ScaleFactor resetting after document created first time
            // it needs to create empty document and when real document will be created, it will be second, not first time creation
            m_Report.CreateDocument(true);

            nbControlReport_GroupExpanded(this, new NavBarGroupEventArgs(nbGroupSettings));

            ApplyExportPermission();
            AjustToolbar();
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            if (m_CustomSummarySource != null)
            {
                m_Report.PivotGrid.CustomCellDisplayText -= m_CustomSummarySource.OnCustomCellDisplayText;
                m_Report.PivotGrid.FieldValueDisplayText -= m_CustomSummarySource.OnFieldValueDisplayText;
                m_Report.PivotGrid.CustomSummary -= m_CustomSummarySource.OnCustomSummary;
                m_CustomSummarySource = null;
            }

            if (m_Report != null)
            {
                ResetReportData();
                m_Report.Dispose();
                m_Report = null;
            }
            eventManager.ClearAllReferences();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            nbContainerSettings = null;
        }

        public string FilterText
        {
            get { return memFilter.Text; }
            set { memFilter.Text = value; }
        }

        public string PivotName
        {
            get { return tbPivotName.Text; }
            set { tbPivotName.Text = value; }
        }

        public PrintingSystemBase PrintingSystem
        {
            get { return m_Report.PrintingSystem; }
        }

        private ReportPrintTool m_ReportPrintTool;

        public ReportPrintTool ReportPrintTool
        {
            //get { return  new ReportPrintTool(m_Report); }
            get { return m_ReportPrintTool ?? (m_ReportPrintTool = new ReportPrintTool(m_Report)); }
        }

        public PivotReportPresenter ReportPresenter
        {
            get { return m_ReportPresenter; }
        }

        public ExportDelegate GetExportDelegate(ExportType exportType)
        {
            
            switch (exportType)
            {
                case ExportType.PDF:
                    return m_Report.ExportToPdf;

                case ExportType.XLS:
                    return m_Report.ExportToXls;

                case ExportType.RTF:
                    return m_Report.ExportToRtf;

                case ExportType.Html:
                    return m_Report.ExportToHtml;

                case ExportType.Image:
                    return m_Report.ExportToImage;
            }
            throw new RamException("Not supported export type: " + exportType);
        }

        public void ResetReportData()
        {
            if (m_Report != null)
            {
                m_Report.PivotGrid.Clear();
            }
        }

        public void OnPivotDataLoaded(PivotDataEventArgs e)
        {
            Utils.CheckNotNull(e, "e");
            var sourceGrid = e.PivotGrid as RamPivotGrid;
            if (sourceGrid == null)
            {
                throw new ArgumentException("e.PivotGrid should have type RamPivotGrid.");
            }

            Utils.CheckNotNull(sourceGrid, "e.PivotGrid");
            using (m_Report.PivotGrid.BeginTransaction())
            {
                PrintingSystem.ClearContent();

                // check that complexity of the pivot grid is not very big
                if (sourceGrid.Complexity > RamPivotGrid.MaxLayoutComplexity)
                {
                    MessageForm.Show(EidssMessages.Get("msgTooComplexLayout"));
                    return;
                }

                // check that total cells count in the pivot grid is not very big
                if (sourceGrid.TotalCells > RamPivotGrid.MaxLayoutCellCount)
                {
                    string msg = EidssMessages.Get("msgTooComplexLayout");
                    msg = string.Format(msg, RamPivotGrid.MaxLayoutCellCount);
                    MessageForm.Show(msg);
                    return;
                }

                m_Report.PivotGrid.CreateReportGridFrom(sourceGrid);

                m_Report.HeaderText = m_ReportPresenter.GetPivotNameFromDataSource();
                m_Report.Footer = string.Empty;
                m_Report.FilterText = FilterText;

                int pageWidth = PrintingSystem.PageSettings.Bounds.Width - PrintingSystem.PageSettings.LeftMargin -
                                PrintingSystem.PageSettings.RightMargin;
                //magic number :)
                const float coeff = 1.05f;
                float totalWidth = sourceGrid.TotalWidth * coeff;
                float scaleFactor = (pageWidth >= totalWidth)
                                        ? 1
                                        : (pageWidth) / (totalWidth);
                PrintingSystem.Document.ScaleFactor = scaleFactor;

                PrintingSystem.ClearContent();
                printControlReport.PrintingSystem = PrintingSystem;

                
                m_Report.CreateDocument(true);

                m_Report.Visible = true;
                m_Report.PivotGrid.Visible = true;

                if (m_CustomSummarySource == null)
                {
                    m_CustomSummarySource = sourceGrid;
                    m_Report.PivotGrid.CustomCellDisplayText += m_CustomSummarySource.OnCustomCellDisplayText;
                    m_Report.PivotGrid.FieldValueDisplayText += m_CustomSummarySource.OnFieldValueDisplayText;
                    m_Report.PivotGrid.CustomSummary += m_CustomSummarySource.OnCustomSummary;
                }
            }
        }

        private void memFilter_Leave(object sender, EventArgs e)
        {
            if (m_Report.FilterText == FilterText)
            {
                return;
            }
            m_Report.FilterText = FilterText;
            m_Report.CreateDocument(true);
        }

        private void tbPivotName_Leave(object sender, EventArgs e)
        {
            if ((m_Report.HeaderText == PivotName) ||
                ((m_Report.HeaderText == EidssMessages.Get("msgNoReportHeader", "[Untitled]")) &&
                 string.IsNullOrEmpty(PivotName)))
            {
                return;
            }
            m_Report.HeaderText = PivotName;
            m_Report.CreateDocument(true);
        }

        private void biFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Filter));
        }

        private void biSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Save));
        }

        private void biCancelChanges_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Cancel));
        }

        protected override void DefineBinding()
        {
            Trace.WriteLine(Trace.Kind.Undefine, "ReportForm.DefineBinding() call");
            using (SharedPresenter.ContextKeeper.CreateNewContext("DefineBinding"))
            {
                m_ReportPresenter.BindPivotName(tbPivotName);
            }
        }

        private void ApplyExportPermission()
        {
            if (!EidssUserContext.User.HasPermission(
                PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanImportExportData)))
            {
                //printBarManager.Items.Remove(biExportFile);
                LinkPersistInfo linkToRemove = null;
                foreach (LinkPersistInfo linksInfo in previewBar1.LinksPersistInfo)
                {
                    if (biExportFile == linksInfo.Item)
                    {
                        linkToRemove = linksInfo;
                    }
                }
                if (linkToRemove != null)
                {
                    previewBar1.LinksPersistInfo.Remove(linkToRemove);
                }
            }
        }

        private void AjustToolbar()
        {
            var itemsToRemove = new List<BarItem>();

            itemsToRemove.AddRange(new BarItem[] {biExportHtm, biExportMht, biExportCsv, biExportTxt});
            foreach (BarItem item in printBarManager.Items)
            {
                if ((item is PrintPreviewBarItem) && (string.IsNullOrEmpty(item.Name)))
                {
                    itemsToRemove.Add(item);
                }
            }
            ReportView.RemoveFromToolbar(itemsToRemove, printBarManager, previewBar1);
        }

        #region Nav Bar Layout

        private void nbControlReport_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlReport.Height = BaseRamPresenter.NavBarGroupHeaderHeight;
            }
        }

        private void nbControlReport_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlReport.Height = nbGroupSettings.ControlContainer.Height +
                                         BaseRamPresenter.NavBarGroupHeaderHeight;
            }
        }

        #endregion
    }
}