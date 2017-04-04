using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraBars;

namespace bv.winclient.Core.TranslationTool
{
    public partial class PropertyGrid : BvForm
    {
        public ControlDesigner SourceControl { get; private set; }

        public ControlModel Model { get; private set; }

        public PropertyGrid()
        {
            InitializeComponent();
        }

        public void RefreshPropertiesGrid(BarItemLinkCollection sourceControl)
        {
            rowCaption.Visible = categoryLocation.Visible = categorySize.Visible = false;
            categoryMenuItems.Visible = true;
            Model = new ControlModel
            {
                CanCaptionChange = false
            };
            foreach (var o in sourceControl)
            {
                var caption = String.Empty;
                if (o is BarSubItemLink)
                {
                    caption = ((BarSubItemLink) o).Item.Caption;
                }
                else if (o is BarLargeButtonItemLink)
                {
                    caption = ((BarLargeButtonItemLink) o).Item.Caption;
                }
                if (caption.Length == 0) continue;
                Model.MenuItems.Add(caption);
            }
            propGrid.SelectedObject = Model;
        }

        public void RefreshPropertiesGrid(ControlDesigner sourceControl)
        {
            SourceControl = sourceControl;
            var control = SourceControl.RealControl;

            Model = new ControlModel
                {
                    X = control.Location.X,
                    Y = control.Location.Y,
                    Width = control.Size.Width,
                    Height = control.Size.Height,
                    CanCaptionChange = TranslationToolHelperWinClient.IsEditableControl(control)
                };

            if (Model.CanCaptionChange)
            {
                Model.OldCaption = 
                Model.Caption =
                    TranslationToolHelperWinClient.GetComponentText(control);
            }
            else
            {
                rowCaption.Visible = false;
            }

            if (SourceControl.MovingEnabled)
            {
                Model.OldLocation = control.Location;
            }
            else
            {
                categoryLocation.Visible = false;
            }

            if (SourceControl.SizingEnabled)
            {
                Model.OldSize = control.Size;
            }
            else
            {
                categorySize.Visible = false;
            }

            //we create a list with all menu items
            if (control is PopUpButton)
            {
                var pb = (PopUpButton) control;
                foreach (BarButtonItemLink action in pb.PopupActions.ItemLinks)
                {
                    Model.MenuItems.Add(action.Item.Caption);
                }
                categoryMenuItems.Visible = true;
            }
            else
            {
                categoryMenuItems.Visible = false;
            }

            propGrid.SelectedObject = Model;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            //todo validation?
            Close();
        }
    }

    public class ControlModel
    {
        public string Caption { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool CanCaptionChange { get; set; }
        public Point OldLocation { get; set; }
        public Size OldSize { get; set; }
        public string OldCaption { get; set; }
        public List<string> MenuItems { get; set; }

        public ControlModel()
        {
            Caption = String.Empty;
            OldCaption = String.Empty;
            X = Y = Width = Height = 0;
            CanCaptionChange = false;
            OldLocation = new Point(0, 0);
            OldSize = new Size(0, 0);
            MenuItems = new List<string>();
        }

        public bool IsLocationChanged()
        {
            return new Point(X, Y) != OldLocation;
        }

        public bool IsSizeChanged()
        {
            return new Size(Width, Height) != OldSize;
        }

        public bool IsCaptionChanged()
        {
            return Caption != OldCaption;
        }
    }
}
