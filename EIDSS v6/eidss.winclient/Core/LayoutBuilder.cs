using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.Utils;
using DevExpress.XtraLayout;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.FlexForms;

namespace eidss.winclient.Core
{
    public class SupportInitializeList : List<ISupportInitialize>
    {
        public new void Add(ISupportInitialize i)
        {
            i.BeginInit();
            base.Add(i);
        }
    }
    public class LayoutViewFieldDict : Dictionary<string, LayoutViewField>
    {
        
    }

    public class LayoutViewColumnList : List<LayoutViewColumn>
    {
        
    }


    public static class LayoutBuilder
    {

        public static GridLevelNode Node(BaseView template, string relation)
        {
            var ret = new GridLevelNode();
            ret.LevelTemplate = template;
            ret.RelationName = relation;
            template.Name = "Template_" + relation;
            if (template is LayoutView)
                (template as LayoutView).TemplateCard.Name = "TemplateCard_" + relation;
            return ret;
        }

        public static LayoutView LayoutView(SupportInitializeList sil, GridControl grid, LayoutViewCard card, LayoutViewColumn[] columns)
        {
            var ret = new LayoutView();
            sil.Add(ret);
            //ret.CardMinSize = new System.Drawing.Size(732, 244);
            ret.GridControl = grid;
            ret.Columns.AddRange(columns);
            grid.ViewCollection.Add(ret);
            ret.TemplateCard = card;
            ret.OptionsView.ViewMode = LayoutViewMode.SingleRecord;
            ret.OptionsView.ShowCardCaption = false;
            ret.OptionsView.ShowCardExpandButton = false;
            ret.OptionsView.ShowHeaderPanel = false;
            ret.OptionsView.ShowViewCaption = false;
            ret.FieldCaptionFormat = "{0}";

            ret.CustomDrawCardFieldValue += (sender, args) =>
                {
                    if (args.Column.FieldName != "blnExternalTest")
                    {
                        var view = (LayoutView) sender;
                        int index = view.GetDataSourceRowIndex(args.RowHandle);
                        var item = grid.Views[1].GetRow(index) as LaboratorySectionItem;
                        bool bReadObly = item.IsReadOnly(args.Column.FieldName);
                        bool bMandatory = item.IsRequired(args.Column.FieldName);

                        args.Appearance.FillRectangle(args.Cache, args.Bounds);
                        if (!bReadObly)
                        {
                            args.Graphics.FillRectangle(SystemBrushes.Window, args.Bounds);
                        }
                        if (bMandatory)
                        {
                            var bnd = args.Bounds;
                            bnd.Inflate(2, 2);
                            args.Graphics.DrawRectangle(Pens.Red, bnd);
                        }
                        args.Appearance.DrawString(args.Cache, args.DisplayText, args.Bounds);
                        args.Handled = true;
                    }
                };
            /*
            ret.CellValueChanging += (sender, args) =>
                {
                    if (args.Column.FieldName == "blnExternalTest")
                    {
                        var view = sender as LayoutView;
                        grid.Invoke((Action)delegate =>
                            {
                                
                            });
                        var saveCol = view.FocusedColumn;
                        view.FocusedColumn = view.Columns["strContactPerson"];
                        Application.DoEvents();
                        view.FocusedColumn = saveCol;
                        //ret.FocusedColumn = 
                        //view.PostEditor();
                    }
                };
            */
            /*ret.CellValueChanged += (sender, args) =>
                {
                    if (args.Column.FieldName == "blnExternalTest")
                    {
                        ret.PostEditor();
                    }
                };
            */
            //ret.OptionsItemText.TextToControlDistance = 3;
            //ret.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            //ret.Appearance.Card.Options.UseTextOptions = true;
            //ret.Appearance.Card.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //ret.Appearance.FieldCaption.Options.UseTextOptions = true;
            //ret.Appearance.FieldCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            return ret;
        }

        public static LayoutViewCard LayoutViewCard(SupportInitializeList sil, BaseLayoutItem[] items)
        {
            var ret = new LayoutViewCard();
            sil.Add(ret);
            //ret.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ret.Items.AddRange(items);
            ret.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            ret.TextVisible = false;
            //ret.TextLocation = DevExpress.Utils.Locations.Default;
            return ret;
        }

        private static int g_groupNextName = 1;
        public static BaseLayoutItem LayoutControlGroup(SupportInitializeList sil, System.Drawing.Point location, System.Drawing.Size size, BaseLayoutItem[] items)
        {
            var ret = new LayoutControlGroup();
            sil.Add(ret);
            ret.Items.AddRange(items);
            ret.Location = location;
            ret.Size = size;
            ret.TextVisible = false;
            ret.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            ret.OptionsItemText.TextToControlDistance = 20;
            ret.OptionsItemText.TextAlignMode = TextAlignModeGroup.CustomSize;
            ret.GroupBordersVisible = false; // true;
            ret.Name = string.Format("Group_{0}", g_groupNextName++);
            return ret;
        }

        public static BaseLayoutItem LayoutControlGroup(SupportInitializeList sil, System.Drawing.Point location, System.Drawing.Size size, BaseLayoutItem[] items, out LayoutControlGroup groupFF)
        {
            var ret = LayoutControlGroup(sil, location, size, items) as LayoutControlGroup;
            groupFF = ret;
            return ret;
        }

        public static BaseLayoutItem LayoutViewField(SupportInitializeList sil, LayoutViewColumnList lcl, System.Drawing.Point location, System.Drawing.Size size, System.Drawing.Size textsize, string field)
        {
            var ret = new LayoutViewField();
            sil.Add(ret);
            ret.Location = location;
            ret.Name = "layoutViewField_" + field;
            ret.Size = size;
            ret.TextSize = textsize;
            ret.TextVisible = true;
            ret.MinSize = size;
            ret.MaxSize = size;
            ret.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;

            var column = new LayoutViewColumn();
            column.LayoutViewField = ret;
            column.Name = "layoutViewColumn_" + field;
            column.FieldName = field;
            column.OptionsFilter.AllowFilter = false;
            column.OptionsFilter.AllowAutoFilter = false;
            column.OptionsField.SortFilterButtonShowMode = SortFilterButtonShowMode.Nowhere;
            column.OptionsColumn.AllowSort = DefaultBoolean.False;
            lcl.Add(column);

            return ret;
        }

        public static GridView GridView(SupportInitializeList sil, GridControl grid, GridColumn[] columns)
        {
            var ret = new GridView();
            sil.Add(ret);
            ret.Columns.AddRange(columns);
            ret.GridControl = grid;
            ret.GroupCount = 1;
            ret.OptionsView.ShowViewCaption = false;
            ret.OptionsView.ShowChildrenInGroupPanel = false;
            ret.OptionsView.ShowAutoFilterRow = false;
            ret.OptionsView.ShowDetailButtons = false;
            ret.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            ret.OptionsView.ShowGroupPanel = false;
            ret.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            ret.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
            ret.OptionsBehavior.Editable = false;
            ret.OptionsDetail.EnableMasterViewMode = false;
            ret.OptionsMenu.EnableColumnMenu = false;
            return ret;
        }

        public static GridColumn GridColumn(string field, string caption = null)
        {
            var ret = new GridColumn();
            ret.Caption = EidssFields.Get(caption ?? field);
            ret.Name = "gridColumn_" + field;
            ret.FieldName = field;
            ret.OptionsColumn.ShowCaption = true;
            ret.Visible = true;
            //ret.VisibleIndex = 0;
            ret.OptionsFilter.AllowAutoFilter = false;
            ret.OptionsFilter.AllowFilter = false;
            return ret;
        }

    }


}
