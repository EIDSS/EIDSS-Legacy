using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.BasePanel.ListPanelComponents;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using eidss.model.Core;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionGroupAccessionIn : BaseDetailPanel_LaboratorySectionItem
    {
        private IObject ParentObject { get; set; }
        private BaseListGridControl Grid { get; set; }
        private List<LaboratorySectionItem> DataSource { get; set; }
        private EditableList<LaboratorySectionItem> List { get; set; }
        private bool IsMyPref { get; set; }
        private BaseListPanel<LaboratorySectionItem> Panel { get; set; }
        private LayoutViewColumnList LclSample { get; set; }
        private LayoutViewColumnList LclTest { get; set; }

        public LaboratorySectionGroupAccessionIn()
        {
            InitializeComponent();
        }

        public LaboratorySectionGroupAccessionIn(IObject parent, BaseListGridControl grid, List<LaboratorySectionItem> dataSource, EditableList<LaboratorySectionItem> list, bool bIsMyPref, BaseListPanel<LaboratorySectionItem> panel, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            ParentObject = parent;
            Grid = grid;
            DataSource = dataSource;
            List = list;
            IsMyPref = bIsMyPref;
            Panel = panel;
            LclSample = lclSample;
            LclTest = lclTest;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var item = BusinessObject as LaboratorySectionItem;
            if (item == null) return;

            LookupBinder.BindTextEdit(txtFieldBarcode, item, "strFieldBarcode");
            LookupBinder.BindCheckEdit(chSendToCurrentOffice, item, "bSendToCurrentOffice");
        }

        public override void SetCustomActions(System.Collections.Generic.List<bv.model.Model.Core.ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            ActionMetaItem action;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
                SetActionFunction(actions, "ItemGroupAccessionIn", (proxy, o, pars) => LaboratorySectionUtils.ItemGroupAccessionIn(proxy, o, pars, ParentObject, IsMyPref, 0), null, obj);
                action = SetPostActionFunction(actions, "ItemGroupAccessionIn", (proxy, o, pars) =>
                    {
                        LaboratorySectionItem l = o as LaboratorySectionItem;
                        if (l.idfMaterialForGroupAccIn > 0)
                        {
                            lblAddNote.Visible = true;
                            return LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, List, Panel, LclSample, LclTest);
                        }
                        else
                        {
                            LaboratorySectionGetByFieldBarcodeListPanel listForm = new LaboratorySectionGetByFieldBarcodeListPanel();
                            FilterParams filter = new FilterParams();
                            filter.Add("strFieldBarcode", "=", l.strFieldBarcodePrevious);
                            if (l.bSendToCurrentOffice)
                            {
                                filter.Add("idfSendToOffice", "=", EidssSiteContext.Instance.OrganizationID);
                            }
                            listForm.StaticFilter = filter;
                            listForm.SearchPanelVisible = false;
                            IList<IObject> r = BaseFormManager.ShowForMultiSelection(listForm, FindForm(), null, 1024, 800);
                            if (r != null && r.Count > 0)
                            {
                                foreach(IObject i in r)
                                {
                                    LaboratorySectionItem.Accessor.Instance(null).ItemGroupAccessionIn(manager, 
                                        l, l.Parent, (l.Parent as LaboratorySectionMaster).bIsMyPref,
                                        (i as LaboratorySectionGetByFieldBarcodeListItem).idfMaterial);
                                }
                                return LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, List, Panel, LclSample, LclTest);
                            }
                            return false;
                        }
                    }, null, obj);
            }

            txtFieldBarcode.KeyDown += (sender, args) =>
            {
                if (args.KeyData == Keys.Enter)
                {
                    if (action != null)
                    {
                        var item = BusinessObject as LaboratorySectionItem;
                        item.strFieldBarcode = txtFieldBarcode.Text;
                        item.bSendToCurrentOffice = true;
                        if (action != null)
                        {
                            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                action.RunAction(manager, item, new List<object> {ParentObject, IsMyPref, 0L});
                            }
                        }
                        //PerformAction("ItemGroupAccessionIn", new List<object> {ParentObject, IsMyPref});
                    }
                }
            };
        }

    }
}
