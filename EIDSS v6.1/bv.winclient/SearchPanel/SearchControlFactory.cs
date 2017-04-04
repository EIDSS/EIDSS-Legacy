using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using bv.common.Resources;
using bv.model.Model.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using bv.winclient.Core;
using System.Reflection;

namespace bv.winclient.SearchPanel
{
    internal class SearchControlFactory: ISearchControlFactory
    {
        private BaseSearchPanel m_SearchPanel { get; set; }

        public SearchControlFactory(BaseSearchPanel baseSearchPanel)
        {
            m_SearchPanel = baseSearchPanel;
        }

        public void AddClearButton(ButtonEdit cb, bool forceAddClearButton)
        {
            AddKeyDownHandler(cb, KeyDown);
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
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                var edit = sender as BaseEdit;
                if (edit != null)
                {
                    var cb = edit;
                    cb.EditValue = DBNull.Value;
                    WinUtils.SetClearTooltip(cb);
                    e.Handled = true;
                }
            }
        }
        //private void AddButtonClickHandler(ButtonEdit cb, ButtonPressedEventHandler handler)
        //{
        //    try
        //    {
        //        cb.ButtonClick -= handler;
        //    }
        //    finally
        //    {
        //        cb.ButtonClick += handler;
        //    }
        //}

        //private void ClearLookup(object sender, ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == ButtonPredefines.Delete)
        //    {
        //        //var item = searchPanel.m_LContent.m_LinkedItems.Where(s => s.Controls.Contains(sender as BaseEdit)).FirstOrDefault();
        //        //string msg;
        //        ////if (item != null && item.MetaItem.DefaultValue != null && item.MetaItem.IsMandatory)
        //        ////    msg = BvMessages.Get("msgConfirmResetLookup", "Reset the content to default value?");
        //        ////else
        //        ////    msg = BvMessages.Get("msgConfirmClearLookup", "Clear the content?");
        //        ////if (
        //        ////    MessageForm.Show(msg, BvMessages.Get("Confirmation"),
        //        ////                     MessageBoxButtons.YesNo) != DialogResult.Yes)
        //        ////    return;
        //        var cb = (BaseEdit)sender;
        //        var e1 = new ChangingEventArgs(cb.EditValue, null);
        //        var mi = cb.GetType().GetMethod("OnEditValueChanging", BindingFlags.Instance | BindingFlags.NonPublic);
        //        if (mi != null)
        //        {
        //            mi.Invoke(cb, new object[] { e1 });
        //            if (e1.Cancel)
        //            {
        //                return;
        //            }
        //        }
        //        if (cb.DataBindings.Count > 0)
        //        {
        //            //TODO:correct this for BusinessObject
        //            //DataRow row = BaseForm.GetControlCurrentRow(cb);
        //            //if (row != null && !(row[cb.DataBindings[0].BindingMemberInfo.BindingField] == DBNull.Value))
        //            //{
        //            //    row.BeginEdit();
        //            //    row[cb.DataBindings[0].BindingMemberInfo.BindingField] = DBNull.Value;
        //            //    row.EndEdit();
        //            //}
        //        }
        //        searchPanel.ClearControl(cb);
        //    }
        //}
        public LookUpEdit CreateLookUpEdit(List<object> items, object currentValue, bool bSorting = true)
        {
            var control = new LookUpEdit();

            control.Properties.Columns.AddRange(new[]
                                                    {
                                                        new LookUpColumnInfo("Name", BvMessages.Get("colName", "Name"), 74)
                                                    });

            control.Properties.DataSource = items;
            control.Properties.DisplayMember = "Name";
            control.Properties.ValueMember = "Value";

            control.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            control.Properties.SearchMode = SearchMode.AutoComplete;
            control.Properties.AutoSearchColumnIndex = 0;
            if (bSorting)
            {
                control.Properties.SortColumnIndex = 0;
                control.Properties.Columns[0].SortOrder = ColumnSortOrder.Ascending;
            }
            control.Properties.NullText = "";
            if (currentValue != null && !string.IsNullOrWhiteSpace(currentValue.ToString()))
            {
                dynamic val = currentValue;
                control.EditValue = val.Key;
            }
            control.Tag = "";
            AddClearButton(control, true);
            return control;
        }

        public LookUpEdit CreateLookUpEdit(IObject obj, string lookupName, List<Tuple<string, string>> columns, object currentValue, bool bBinding)
        {
            var control = new LookUpEdit();

            control.Properties.Columns.Clear();
            if (columns != null && columns.Count > 0)
            {
                control.Properties.Columns.AddRange(
                    columns.Select(c => new LookUpColumnInfo(c.Item1, c.Item2, 74)).ToArray());
            }
            else
            {
                control.Properties.Columns.AddRange(new[]
                                                    {
                                                        new LookUpColumnInfo("ToStringProp", BvMessages.Get("colName", "Name"), 74)
                                                    });
            }
            PropertyInfo pi = obj.GetType().GetProperty(lookupName);
            if (pi != null)
            {
                var ds = pi.GetValue(obj, null);
                //string identName = "";

                var dsl = ds as IList;
                if ((dsl != null) && dsl.Count > 0)
                {
                    control.Enabled = true;
                    //var dsli = dsl[0] as IObject;
                    //if (dsli != null) identName = dsli.KeyName;
                }
                else control.Enabled = false;

                control.Properties.DataSource = null;
                control.Properties.DataSource = ds;
                control.Properties.DisplayMember = "ToStringProp";
                control.Properties.ValueMember = String.Empty;// identName;
                control.Properties.NullText = String.Empty;
                control.Properties.ShowDropDown = ShowDropDown.SingleClick;

                control.DataBindings.Clear();
                var bindProp = lookupName.Replace("Lookup", String.Empty);
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

        private bool m_ListUpdated;
        public PopupContainerEdit CreateMultipleLookUpEdit(IObject obj, string lookupName, object currentValue)
        {
            var control = new PopupContainerEdit();
            control.Properties.PopupControl = new PopupContainerControl();
            var checkedListBoxControl = new CheckedListBoxControl {Dock = DockStyle.Fill, CheckOnClick = true};
            checkedListBoxControl.ItemCheck += (sender, args) =>
                {
                    if (m_ListUpdated)
                        return;
                    m_ListUpdated = true;
                    try
                    {
                        var items = checkedListBoxControl.DataSource as IList;
                        if (items != null && items.Count > 0)
                        {
                            if (args.Index == 0 && (0L.Equals(((IObject)items[args.Index]).Key)))
                            {
                                if (args.State == CheckState.Checked)
                                    checkedListBoxControl.CheckAll();
                                else if (args.State == CheckState.Unchecked)
                                    checkedListBoxControl.UnCheckAll();
                            }
                            else if (0L.Equals(((IObject)items[0]).Key))
                            {
                                checkedListBoxControl.SetItemCheckState(0, CheckState.Indeterminate);
                            }
                        }
                    }
                    finally
                    {
                        m_ListUpdated = false;
                    }
            };
            control.Properties.PopupControl.Controls.Add(checkedListBoxControl);
            control.Closed += (sender, args) => SearchPanelHelper.DisplayMultipleText(sender as PopupContainerEdit);
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
                    {
                        bManualChange = true;
                    }
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
                var keyName = "idfsBaseReference";
                var list1 = ds as IList;
                if (list1 != null && list1.Count == 0)
                    control.Enabled = false;
                else
                    keyName = ((ds as IList)[0] as IObject).KeyName;

                checkedListBoxControl.DataSource = ds;
                checkedListBoxControl.DisplayMember = "ToStringProp";
                checkedListBoxControl.ValueMember = keyName;
            }


            SearchPanelHelper.DisplayMultipleText(control);
            AddClearButton(control, true);
            
            return control;
        }

    }

}
