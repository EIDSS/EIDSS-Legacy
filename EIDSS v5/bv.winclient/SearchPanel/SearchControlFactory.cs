using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.SearchPanel.Validate;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;
using System.Reflection;

namespace bv.winclient.SearchPanel
{
    internal class SearchControlFactory: ISearchControlFactory
    {
        private BaseSearchPanel searchPanel { get; set; }

        public SearchControlFactory(BaseSearchPanel baseSearchPanel)
        {
            this.searchPanel = baseSearchPanel;
        }

        public void AddClearButton(ButtonEdit cb, bool forceAddClearButton)
        {
            AddKeyDownHandler(cb, KeyDown);
            //return;
            //if (!forceAddClearButton && !BaseSettings.ShowClearLookupButton)
            //{
            //    return;
            //}
            //if (cb.Properties.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Delete))
            //{
            //    return;
            //}
            //cb.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete, BvMessages.Get("btnClear", "Clear the field contents")));
            //AddButtonClickHandler(cb, ClearLookup);

        }
        private void AddKeyDownHandler(Control cb, KeyEventHandler handler)
        {
            try
            {
                cb.KeyDown -= handler;
            }
            finally
            {
                cb.KeyDown += handler;
            }
        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Delete)
            {
                if (sender is BaseEdit)
                {
                    BaseEdit cb = (BaseEdit)sender;
                    cb.EditValue = DBNull.Value;
                    WinUtils.SetClearTooltip(cb);
                    e.Handled = true;
                }
            }
        }
        private void AddButtonClickHandler(ButtonEdit cb, ButtonPressedEventHandler handler)
        {
            try
            {
                cb.ButtonClick -= handler;
            }
            finally
            {
                cb.ButtonClick += handler;
            }
        }

        private void ClearLookup(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                var item = searchPanel.m_LContent.m_LinkedItems.Where(s => s.Controls.Contains(sender as BaseEdit)).FirstOrDefault();
                string msg;
                if (item != null && item.MetaItem.DefaultValue != null && item.MetaItem.IsMandatory)
                    msg = BvMessages.Get("msgConfirmResetLookup", "Reset the content to default value?");
                else
                    msg = BvMessages.Get("msgConfirmClearLookup", "Clear the content?");
                if (
                    MessageForm.Show(msg, BvMessages.Get("Confirmation"),
                                     MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                var cb = (BaseEdit)sender;
                var e1 = new ChangingEventArgs(cb.EditValue, null);
                var mi = cb.GetType().GetMethod("OnEditValueChanging", BindingFlags.Instance | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(cb, new object[] { e1 });
                    if (e1.Cancel)
                    {
                        return;
                    }
                }
                if (cb.DataBindings.Count > 0)
                {
                    //TODO:correct this for BusinessObject
                    //DataRow row = BaseForm.GetControlCurrentRow(cb);
                    //if (row != null && !(row[cb.DataBindings[0].BindingMemberInfo.BindingField] == DBNull.Value))
                    //{
                    //    row.BeginEdit();
                    //    row[cb.DataBindings[0].BindingMemberInfo.BindingField] = DBNull.Value;
                    //    row.EndEdit();
                    //}
                }
                searchPanel.ClearControl(cb);
            }
        }
        public DevExpress.XtraEditors.LookUpEdit CreateLookUpEdit(List<object> items, object currentValue)
        {
            var control = new LookUpEdit();

            control.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                    {
                                                        new LookUpColumnInfo("Name", BvMessages.Get("colName", "Name"), 74)
                                                    });

            control.Properties.DataSource = items;
            control.Properties.DisplayMember = "Name";
            control.Properties.ValueMember = "Value";

            control.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            control.Properties.SearchMode = SearchMode.AutoComplete;
            control.Properties.AutoSearchColumnIndex = 0;
            control.Properties.SortColumnIndex = 0;
            control.Properties.Columns[0].SortOrder = ColumnSortOrder.Ascending;
            control.Properties.NullText = "";
            //control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            var v = control.Properties.Columns;
            if (currentValue != null && !string.IsNullOrWhiteSpace(currentValue.ToString()))
            {
                dynamic val = currentValue;
                control.EditValue = val.Key;
            }
            control.Tag = "";
            AddClearButton(control, true);
            return control;
        }

        public DevExpress.XtraEditors.LookUpEdit CreateLookUpEdit(IObject obj, string lookupName, object currentValue, bool bBinding)
        {
            var control = new LookUpEdit();

            control.Properties.Columns.Clear();
            control.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                    {
                                                        new LookUpColumnInfo("ToStringProp", BvMessages.Get("colName", "Name"), 74)
                                                    });
            PropertyInfo pi = obj.GetType().GetProperty(lookupName);
            if (pi != null)
            {
                object ds = pi.GetValue(obj, null);
                string identName = "";

                if ((ds as IList).Count > 0)
                {
                    control.Enabled = true;
                    identName = ((ds as IList)[0] as IObject).KeyName;
                }
                else control.Enabled = false;

                control.Properties.DataSource = null;
                control.Properties.DataSource = ds;
                control.Properties.DisplayMember = "ToStringProp";
                control.Properties.ValueMember = "";// identName;
                control.Properties.NullText = String.Empty;
                control.Properties.ShowDropDown = ShowDropDown.SingleClick;

                control.DataBindings.Clear();
                string bindProp = lookupName.Replace("Lookup", "");
                if (bBinding)
                    control.DataBindings.Add("EditValue", obj, bindProp, false, DataSourceUpdateMode.OnPropertyChanged);
            }
            /*
            control.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                    {
                                                        new LookUpColumnInfo("ToStringProp", BvMessages.Get("colName", "Name"), 74)
                                                    });
            PropertyInfo pi = obj.GetType().GetProperty(lookupName);
            if (pi != null)
            {
                object ds = pi.GetValue(obj, null);

                if ((ds as IList).Count == 0)
                    control.Enabled = false;

            //if (items != null)
            //{
                
                //List<object> objectList = new List<object>();

                //var s = items.items.GetEnumerator();
                //while (s.MoveNext())
                //{
                //    var item = s.Current;
                //    dynamic d = item;

                //    objectList.Add(new { Value = d.Key, Name = item.ToString() });
                //}
                //return CreateLookUpEdit(objectList, items.selectedValue);
                
                control.Properties.DataSource = ds;
                control.Properties.DisplayMember = "ToStringProp";
                control.Properties.ValueMember = obj.KeyName;
                //if (items.dataTextField != null) 
                //    control.Properties.DisplayMember = items.dataTextField;
                //control.Properties.ValueMember = items.dataValueField;

                //control.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                control.Properties.SearchMode = SearchMode.AutoComplete;
                control.Properties.AutoSearchColumnIndex = 0;
                control.Properties.NullText = "";
                //control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                //var v = control.Properties.Columns;

                //if (items.selectedValue != null && !string.IsNullOrWhiteSpace(items.selectedValue.ToString()))
                //{
                //    dynamic val = items.selectedValue;
                //    control.EditValue = val.GetValue(control.Properties.ValueMember);
                //}
                control.Tag = "";
                
            }
            */

            AddClearButton(control, true);
            return control;
        }

        private void DisplayMultipleText(PopupContainerEdit cont)
        {
            var list = cont.Properties.PopupControl.Controls[0] as CheckedListBoxControl;
            string dispVal = "";
            foreach (var i in list.CheckedItems)
            {
                if (dispVal.Length > 0) dispVal += ", ";
                dispVal += i.ToString();
            }
            cont.EditValue = dispVal;
        }

        public DevExpress.XtraEditors.PopupContainerEdit CreateMultipleLookUpEdit(IObject obj, string lookupName, object currentValue)
        {
            var control = new PopupContainerEdit();
            control.Properties.PopupControl = new PopupContainerControl();
            var list = new CheckedListBoxControl();
            list.Dock = DockStyle.Fill;
            list.CheckOnClick = true;
            control.Properties.PopupControl.Controls.Add(list);
            control.Closed += (sender, args) => DisplayMultipleText(sender as PopupContainerEdit);
            bool bManualChange = false;
            bool bPopup = false;
            control.QueryPopUp += (sender, args) =>
            {
                if (!bManualChange)
                {
                    bPopup = true;
                    control.Properties.PopupControl.Width = control.Width - 4;
                    bPopup = false;
                }
            };
            control.Properties.PopupControl.SizeChanged += (sender, args) =>
            {
                if (!bPopup)
                    bManualChange = true;
            };

            //if (items != null)
            //{
            //    list.DataSource = items.items;
            //    list.DisplayMember = items.dataTextField ?? "name";
            //    list.ValueMember = items.dataValueField;
            //}
            PropertyInfo pi = obj.GetType().GetProperty(lookupName);
            if (pi != null)
            {
                object ds = pi.GetValue(obj, null);

                if ((ds as IList).Count == 0)
                    control.Enabled = false;
                list.DataSource = ds;
                list.DisplayMember = "ToStringProp";
                list.ValueMember = obj.KeyName;
            }


            DisplayMultipleText(control);
            AddClearButton(control, true);
            
            return control;
        }

    }

}
