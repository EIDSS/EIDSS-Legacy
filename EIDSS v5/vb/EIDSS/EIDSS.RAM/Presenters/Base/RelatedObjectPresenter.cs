using System;
using System.Windows.Forms;
using bv.common.Core;
using DevExpress.XtraPrinting;
using EIDSS.RAM.Components;
using EIDSS.RAM_DB.Views;

namespace EIDSS.RAM.Presenters.Base
{
    public abstract class RelatedObjectPresenter : BaseRamPresenter
    {
        private readonly IRelatedObjectView m_RelatedObjectView;
        private static readonly Timer m_Timer;

        static RelatedObjectPresenter()
        {
            m_Timer = new Timer {Interval = 100};
            m_Timer.Tick += m_Timer_Tick;
        }

        protected RelatedObjectPresenter(SharedPresenter sharedPresenter, IRelatedObjectView view)
            : base(sharedPresenter)
        {
            Utils.CheckNotNull(sharedPresenter, "sharedPresenter");
            Utils.CheckNotNull(view, "view");

            m_RelatedObjectView = view;
        }

        public IRelatedObjectView RelatedObjectView
        {
            get { return m_RelatedObjectView; }
        }

        public bool IsNewObject
        {
            get
            {
                bool result = RelatedObjectView.UseParentDataset
                                  ? RelatedObjectView.DBService.ParentService.IsNewObject
                                  : RelatedObjectView.DBService.IsNewObject;
                return result;
            }
        }

        protected static void ShowPreview(PrintingSystem printingSystem, CreateAreaEventHandler handler)
        {
            printingSystem.Links.Clear();

            var link = new RamPrintingLink(printingSystem);
            link.CreateDetailArea += handler;
            if (!Utils.IsCalledFromUnitTest())
                link.ShowPreview();
            printingSystem.PageSettings.Landscape = true;
            printingSystem.PageSettings.LeftMargin = 50;
            printingSystem.PageSettings.RightMargin = 50;
            printingSystem.PageSettings.TopMargin = 50;
            printingSystem.PageSettings.BottomMargin = 50;

            if (!Utils.IsCalledFromUnitTest())
            {
                m_Timer.Tag = printingSystem;
                m_Timer.Start();
            }
        }

        private static void m_Timer_Tick(object sender, EventArgs e)
        {
            if (!(m_Timer.Tag is PrintingSystem))
                return;

            var printingSystem = (PrintingSystem) m_Timer.Tag;

            if (printingSystem.Document.IsCreating)
                return;

            m_Timer.Stop();

            printingSystem.ExecCommand(PrintingSystemCommand.Scale, new object[] {1});
            printingSystem.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
            if (printingSystem.PreviewFormEx != null)
            {
                if (printingSystem.PreviewFormEx.WindowState == FormWindowState.Minimized)
                {
                    printingSystem.PreviewFormEx.WindowState = FormWindowState.Normal;
                }
                printingSystem.PreviewFormEx.Activate();
            }
        }
    }
}