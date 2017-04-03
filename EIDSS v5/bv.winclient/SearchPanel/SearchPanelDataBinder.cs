using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using bv.model.Model.Core;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using bv.common.Resources;
using System.Windows.Forms;

namespace bv.winclient.SearchPanel
{
    public class SearchPanelDataBinder
    {
        private IObject obj = null;
        private LinkedContent linkedContent = null;
        private BaseSearchPanel m_searchPanel;
        public SearchPanelDataBinder(IObject currentObject, LinkedContent linkedContent, BaseSearchPanel searchPanel)
        {
            obj = currentObject;
            this.linkedContent = linkedContent;
            m_searchPanel = searchPanel;
            this.obj.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PropertyChanged);

        }

        private void BindData(object obj)
        {
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string metaLabelId = e.PropertyName;

            var dependentControlsName = linkedContent.m_LinkedItems.
                Where(d => d.MetaItem.Name == metaLabelId).
                Select(f => f.MetaItem.Dependent).ToArray();

            if (dependentControlsName.Any())
            {
                var linkedItems = linkedContent.m_LinkedItems.Where(d => dependentControlsName.Contains(d.MetaItem.Name)).ToArray();

                foreach (var linkedItem in linkedItems)
                {
                    foreach (var ctl in linkedItem.Controls)
                        ctl.EditValue = null;
                    Bind(linkedItem, false, null);
                }
            }
        }
        internal bool SetInitialFilter(LinkedItem item, FilterParams initialFilter)
        {
            if (initialFilter != null && initialFilter.Contains(item.MetaItem.Name))
            {
                for (int i = 0; i < initialFilter.ValueCount(item.MetaItem.Name); i++)
                {
                    if (item.Controls.Count > i)
                    {
                        item.Controls[i].EditValue = initialFilter.Value(item.MetaItem.Name);
                    }
                    else
                        break;
                }
                return true;
            }
            return false;
        }


        internal void Bind(LinkedItem linkedItem, bool bFirstBinding, FilterParams initialFilter)
        {

            if (!linkedItem.MetaItem.Name.Contains("Custom"))
            {
                BaseEdit ctrl = (BaseEdit)linkedItem.Controls.First();
                if (linkedItem.MetaItem.Location == SearchPanelLocation.Combobox)
                {
                    ctrl = (BaseEdit)linkedItem.Controls.Last();
                }


                if (ctrl is LookUpEdit)
                {
                    /*
                    var control = (LookUpEdit)ctrl;

                    PropertyInfo pi = this.obj.GetType().GetProperty(linkedItem.MetaItem.LookupName);
                    if (pi != null)
                    {
                        object ds = pi.GetValue(this.obj, null);
                        string identName = "";
                        if ((ds as IList).Count > 0)
                        {
                            control.Enabled = true;
                            identName = ((ds as IList)[0] as IObject).KeyName;
                        }
                        else control.Enabled = false;

                        control.Properties.Columns.Clear();
                        control.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                    {
                                                        new LookUpColumnInfo("ToStringProp", BvMessages.Get("colName", "Name"), 74)
                                                    });

                        control.Properties.DataSource = ds;
                        control.Properties.DisplayMember = "ToStringProp";
                        control.Properties.ValueMember = "";// identName;

                        control.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                        control.Properties.SearchMode = SearchMode.AutoComplete;
                        control.Properties.AutoSearchColumnIndex = 0;
                        control.Properties.NullText = "";
                        //control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                        var v = control.Properties.Columns;

                        if (bFirstBinding)
                        {
                            if (!SetInitialFilter(linkedItem, initialFilter))
                            {
                                if (linkedItem.MetaItem.DefaultValue != null)
                                {
                                    control.EditValue = linkedItem.MetaItem.DefaultValue.Invoke();
                                }
                                //else if (list.selectedValue != null)
                                //{
                                //    dynamic val = list.selectedValue;
                                //    control.EditValue = val.Key;
                                //}
                            }
                        }
                        control.Tag = "";
                    }

                    */
                    /*
                    BvSelectList list = SearchPanelHelper.GetList(this.obj, linkedItem.MetaItem);
                    if (list!=null && list.items != null)
                    {
                        List<object> objectList = new List<object>();

                        var s = list.items.GetEnumerator();
                        while (s.MoveNext())
                        {
                            var item = s.Current;
                            dynamic d = item;

                            objectList.Add(new { Value = d.GetValue(list.dataValueField), Name = item.ToString() });
                        }

                        if (objectList.Count > 0)
                            control.Enabled = true;
                        else control.Enabled = false;

                        control.Properties.Columns.Clear();

                        control.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                    {
                                                        new LookUpColumnInfo("Name", BvMessages.Get("colName", "Name"), 74)
                                                    });

                        control.Properties.DataSource = objectList;
                        control.Properties.DisplayMember = "Name";
                        control.Properties.ValueMember = "Value";

                        control.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                        control.Properties.SearchMode = SearchMode.AutoComplete;
                        control.Properties.AutoSearchColumnIndex = 0;
                        control.Properties.NullText = "";
                        //control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                        var v = control.Properties.Columns;

                        if (bFirstBinding)
                        {
                            if (!SetInitialFilter(linkedItem, initialFilter))
                            {
                                if (linkedItem.MetaItem.DefaultValue != null)
                                {
                                    control.EditValue = linkedItem.MetaItem.DefaultValue.Invoke();
                                }
                                else if (list.selectedValue != null)
                                {
                                    dynamic val = list.selectedValue;
                                    control.EditValue = val.Key;
                                }
                            }
                        }
                        control.Tag = "";

                    }
                    */
                }
                bool isReadOnly = m_searchPanel.IsFieldReadonly(obj, linkedItem.MetaItem.Name); 
                ctrl.Enabled = !isReadOnly;
                if (isReadOnly)
                {
                    var lookup = ctrl as LookUpEdit;
                    if (lookup != null)
                    {
                        lookup.EditValue = null;
                    }
                }

                if (linkedItem.MetaItem.Location == SearchPanelLocation.Main)
                {
                    bool isInvisible = obj.IsInvisible(linkedItem.MetaItem.Name);
                    ctrl.Visible = !isInvisible;
                }
            }
            if(obj.IsHiddenPersonalData(linkedItem.MetaItem.Name))
            {
                foreach (var ctl  in linkedItem.Controls)
                {
                    ctl.Enabled = false;
                }
            }
        }



        internal void BindAllData(bool bFirstBinding, FilterParams initialFilter)
        {
            foreach (var l in linkedContent.m_LinkedItems)
            {
                Bind(l, bFirstBinding, initialFilter);
            }
        }
    }
}
