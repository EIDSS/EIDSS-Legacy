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
        }

        public override void SetCustomActions(System.Collections.Generic.List<bv.model.Model.Core.ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            ActionMetaItem action;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
                SetActionFunction(actions, "ItemGroupAccessionIn", (proxy, o, pars) => LaboratorySectionUtils.ItemGroupAccessionIn(proxy, o, pars, ParentObject, IsMyPref), null, obj);
                action = SetPostActionFunction(actions, "ItemGroupAccessionIn", (proxy, o, pars) =>
                    {
                        lblAddNote.Visible = true;
                        return LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, List, Panel, LclSample, LclTest);
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
                        if (action != null)
                        {
                            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                action.RunAction(manager, item, new List<object> {ParentObject, IsMyPref});
                            }
                        }
                        //PerformAction("ItemGroupAccessionIn", new List<object> {ParentObject, IsMyPref});
                    }
                }
            };
        }

    }
}
