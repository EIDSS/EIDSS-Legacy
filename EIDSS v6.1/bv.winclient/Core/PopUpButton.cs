using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using bv.common.Resources;
using DevExpress.XtraEditors;

namespace bv.winclient.Core
{
    public partial class PopUpButton : DropDownButton
    {
        private ContextMenu m_PopUpMenu;

        public PopUpButton()
        {
            InitializeComponent();
            Init();
        }

        public PopUpButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Init();
        }

        private void Init()
        {
            DropDownArrowStyle = DropDownArrowStyle.Show;
            PrpButtonType = PopUpButtonStyles.Reports;
            DefaultText = Text;
            DefaultToolTip = ToolTip;
            ImageList = ImageList1;

            PopupActions = new PopupMenu { Manager = MainBarManager };
            PopupActions.BeforePopup += PopupActions_BeforePopup;
            DropDownControl = PopupActions;

            VisibleChanged += PopUpButton_VisibleChanged;
        }

        void PopUpButton_VisibleChanged(object sender, EventArgs e)
        {
            RefreshMenuButtons();
        }

        private void RefreshMenuButtons()
        {
            if (m_PopUpMenu == null || PopupActions.ItemLinks.Count > 0) return;
            foreach (MenuItem mi in m_PopUpMenu.MenuItems)
            {
                var button = new BarButtonItem(PopupActions.Manager, mi.Text) {Tag = mi};
                button.ItemClick += ButtonOnItemClick;
                PopupActions.AddItem(button);
            }
        }

        private void ButtonOnItemClick(object sender, ItemClickEventArgs e)
        {
            var mi = e.Item.Tag as MenuItem;
            if (mi == null) return;
            mi.PerformClick();
        }

        private void PopupActions_BeforePopup(object sender, CancelEventArgs e)
        {
            if (BeforePopup != null) BeforePopup(sender, e);
        }

        private string DefaultText { get;  set; }
        private string DefaultToolTip { get; set; }

        private PopUpButtonStyles PrpButtonType { get; set; }

        public PopUpButtonStyles ButtonType
        {
            get { return PrpButtonType; }
            set
            {
                PrpButtonType = value;
                switch (value)
                {
                    case PopUpButtonStyles.Reports:
                        ImageIndex = 0;
                        break;
                    case PopUpButtonStyles.PrintBarcodes:
                        ImageIndex = 1;
                        var caption = BvMessages.Get("PrintBarcodes");
                        if (Text == DefaultText)
                        {
                            Text = caption;
                        }
                        if (ToolTip == DefaultToolTip)
                        {
                            ToolTip = caption;
                        }
                        break;
                    case PopUpButtonStyles.Browse:
                        ImageIndex = 2;
                        caption = BvMessages.Get("AddCaseSession");
                        if (Text == DefaultText)
                        {
                            Text = caption;
                        }
                        if (ToolTip == DefaultToolTip)
                        {
                            ToolTip = caption;
                        }
                        break;
                }
            }
        }

        public event EventHandler BeforePopup;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string ToolTip
        {
            get
            {
                return base.ToolTip;
            }
            set
            {
                base.ToolTip = value;
            }
        }

        public PopupMenu PopupActions { get; set; }

        public ContextMenu PopUpMenu
        {
            get { return m_PopUpMenu; }
            set
            {
                m_PopUpMenu = value;
                RefreshMenuButtons();
            }
        }

        public enum PopUpButtonStyles
        {
            Reports = 0,
            PrintBarcodes = 1,
            Browse = 2
        }

        
    }

    
}
