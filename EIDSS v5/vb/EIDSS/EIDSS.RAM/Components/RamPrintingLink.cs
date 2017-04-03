#region Using

using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using bv.common.Core;

#endregion

namespace EIDSS.RAM.Components
{
    /// <summary>
    ///   Printing Link to show custom print preview for printing system
    /// </summary>
    public partial class RamPrintingLink : Link
    {
        /// <summary>
        ///   Initializes a new instance of the Link class with additional bar items
        /// </summary>
        /// <param name="barItemList"> Custom bar Items which need to show in toolbar </param>
        public RamPrintingLink(params BarItem[] barItemList)
        {
            InitializeComponent();
            Init(PrintBarManager, barItemList);
        }

        /// <summary>
        ///   Initializes a new instance of the Link class with the specified container and additional bar items
        /// </summary>
        /// <param name="ps"> An object implementing the System.ComponentModel.IContainer interface which specifies the owner container of a Link class instance. </param>
        /// <param name="barItemList"> Custom bar Items which need to show in toolbar </param>
        public RamPrintingLink(PrintingSystemBase ps, params BarItem[] barItemList)
        {
            InitializeComponent();
            base.PrintingSystemBase = ps;
            Init(PrintBarManager, barItemList);
        }

        /// <summary>
        ///   Initializes a new instance of the Link class with the specified printing system and additional bar items
        /// </summary>
        /// <param name="container"> A DevExpress.XtraPrinting.PrintingSystem object which specifies the printing system used to draw the current link. </param>
        /// <param name="barItemList"> Custom bar Items which need to show in toolbar </param>
        public RamPrintingLink(IContainer container, params BarItem[] barItemList)
            : base(container)
        {
            InitializeComponent();
            Init(PrintBarManager, barItemList);
        }

        /// <summary>
        ///   PrintBarManager of current preview form
        /// </summary>
        private PrintBarManager PrintBarManager
        {
            get
            {
                if (Utils.IsCalledFromUnitTest())
                {
                    return new PrintBarManager();
                }

                if (PrintingSystem == null)
                {
                    throw new RamException("Printing System is not initialized");
                }
                if (PrintingSystem.PreviewFormEx == null)
                {
                    throw new RamException("PreviewForm of Printing System is not initialized");
                }
                if (PrintingSystem.PreviewFormEx.PrintBarManager == null)
                {
                    throw new RamException("PrintBarManager of PreviewForm of Printing System is not initialized");
                }

                return PrintingSystem.PreviewFormEx.PrintBarManager;
            }
        }

        /// <summary>
        ///   Disable some non-used standard tool bar items and show custom bar items
        /// </summary>
        /// <param name="printBarManager"> </param>
        /// <param name="barItemList"> </param>
        internal static void Init(PrintBarManager printBarManager, IEnumerable<BarItem> barItemList = null)
        {
            if (Utils.IsCalledFromUnitTest())
            {
                return;
            }
            IEnumerable<BarItem> correctedList = (barItemList == null)
                                                     ? new List<BarItem>()
                                                     : new List<BarItem>(barItemList);

            printBarManager.AllowCustomization = false;
            printBarManager.AllowMoveBarOnToolbar = false;
            printBarManager.AllowQuickCustomization = false;
            printBarManager.AllowShowToolbarsPopup = false;
            printBarManager.StatusBar.Visible = false;
            printBarManager.MainMenu.Visible = false;

            Bar toolBar = printBarManager.PreviewBar;

            BarOptions barOptions = toolBar.OptionsBar;
            barOptions.AllowQuickCustomization = false;
            barOptions.DisableClose = true;
            barOptions.DisableCustomization = true;
            barOptions.DrawDragBorder = false;

            //Dirty fix of error when print preview shows twice
            if (toolBar.ItemLinks.Count <= 25)
                return;

            var itemsToRemove = new[] {25, 24, 22, 9, 5, 4};
            foreach (int item in itemsToRemove)
            {
                toolBar.ItemLinks.RemoveAt(item);
            }
            var itemsToHide = new[] {41, 42, 45, 46, 47};
            foreach (int item in itemsToHide)
            {
                printBarManager.Items[item].Visibility = BarItemVisibility.Never;
            }

            foreach (BarItem barItem in correctedList)
            {
                toolBar.AddItem(barItem);
            }
        }
    }
}