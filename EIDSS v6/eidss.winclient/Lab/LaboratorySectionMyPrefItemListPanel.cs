using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionMyPrefItemListPanel : BaseListPanel_LaboratorySectionMyPrefItem
    {
        public IObject ParentObject { get; set; }
        private LayoutViewColumnList lclSample = new LayoutViewColumnList();
        private LayoutViewColumnList lclTest = new LayoutViewColumnList();
        private LayoutControlGroup groupFF;

        public LaboratorySectionMyPrefItemListPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LaboratorySectionUtils.BindNodes(Grid, this, lclSample, lclTest, out groupFF);
        }

        public override Func<IObject, IObject> AdjustObject
        {
            get
            {
                return  c =>
                    {
                        (c as LaboratorySectionItem).bIsMyPref = true; return c; 
                    };
            }
        }


        public override bool Collapsed
        {
            get
            {
                return true;
            }
            set
            {
                base.Collapsed = value;
            }
        }

        public override ISearchPanel CreateSearchPanel(bv.winclient.ActionPanel.ActionPanel panel, Func<SearchPanelMetaItem, SearchPanelMetaItem> item, Func<IObject, IObject> AdjustObject)
        {
            return base.CreateSearchPanel(panel, i =>
            {
                if (i.Name == "idfsSampleStatus" && i.Location == SearchPanelLocation.Main)
                {
                    var ret = new SearchPanelMetaItem(i.Name, i.EditorType, i.EditorControlWidth, true, true, i.IsRange, i.IsRangeDefDates, i.LabelId,
                                                      null, i.DefaultOper, c => false, i.IsMultiple, i.Location,
                                                      i.IsParam, i.Dependent, i.LookupName, i.LookupType, i.LookupValue,
                                                      i.LookupText, i.LookupColumns, i.IsBitMask);
                    return ret;
                }
                return i;
            }, AdjustObject);
        }

        protected override void LoadGridLayout()
        {
            base.LoadGridLayout();

            Grid.GridView.MasterRowGetRelationCount += LaboratorySectionUtils.RelationCount;
            Grid.GridView.MasterRowGetRelationName += LaboratorySectionUtils.RelationName;
            Grid.GridView.MasterRowGetRelationDisplayCaption += LaboratorySectionUtils.RelationDisplayCaption;
            Grid.GridView.MasterRowGetChildList += ChildList;
            Grid.GridView.OptionsDetail.ShowDetailTabs = true;
            Grid.GridView.OptionsDetail.EnableMasterViewMode = true;
            Grid.GridView.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            Grid.GridView.OptionsView.ShowDetailButtons = true;

            Grid.GridView.RowStyle += (sender, args) =>
            {
                if (args.RowHandle >= 0 && args.RowHandle < (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Count)
                    if (GetItemByRowHandle(args.RowHandle).HasChanges)
                        LaboratorySectionUtils.SetRowStyle(args, Grid.GridView);
            };

            Grid.GridView.OptionsBehavior.Editable = true;
            Grid.GridView.OptionsBehavior.ReadOnly = false;

            //LaboratorySectionUtils.BindNodes(Grid, this, lclSample, lclTest, out groupFF);
        }

        internal void BindDataSource()
        {
            if (DataSource == null)
            {
                DataSource = (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems.ToList();
            }
            Grid.GridControl.DataSource = DataSource;
            LaboratorySectionUtils.BindDataSource(ParentObject, BusinessObject, Grid, this, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, lclSample, lclTest, this, true);
        }

        void ChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            LaboratorySectionUtils.ChildList(e, Grid, this, lclSample, lclTest, groupFF);
        }

        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
                SetActionFunction(actions, "CreateSample", (proxy, o, pars) => LaboratorySectionUtils.CreateSample(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, true, this, lclSample, lclTest), null, obj);
                SetActionFunction(actions, "GroupAccessionIn", (proxy, o, pars) => LaboratorySectionUtils.GroupAccessionIn(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, true, this, lclSample, lclTest), null, obj);
                SetActionFunction(actions, "MenuAssignTest", (proxy, o, pars) => LaboratorySectionUtils.MenuAssignTest(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetActionFunction(actions, "MenuCreateAliquot", (proxy, o, pars) => LaboratorySectionUtils.MenuCreateAliquot(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuCreateDerivative", (proxy, o, pars) => LaboratorySectionUtils.MenuCreateDerivative(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAccessionInGoodCondition", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAccessionInPoorCondition", (proxy, o, pars) => LaboratorySectionUtils.AcceptedInPoorCondition(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAccessionInRejected", (proxy, o, pars) => LaboratorySectionUtils.AcceptedReject(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRemoveFromPreferences", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRemove", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuDeleteSample", (proxy, o, pars) => LaboratorySectionUtils.ConfirmDelete(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuTransferOutSample", (proxy, o, pars) => LaboratorySectionUtils.MenuTransferOutSample(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuCancelChanges", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRoutineSampleDestruction", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAcceptDestruction", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRejectDestruction", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAmendTestResult", (proxy, o, pars) => LaboratorySectionUtils.MenuAmendTestResult(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuExternalTestResult", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuPrintBarcode", (proxy, o, pars) => LaboratorySectionUtils.MenuPrintBarcode(proxy, o, pars, ParentObject), null, obj);
                /*SetPostActionFunction(actions, "MenuCreateAliquot", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuCreateDerivative", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAccessionInGoodCondition", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAccessionInPoorCondition", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAccessionInRejected", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRemoveFromPreferences", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRemove", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuDeleteSample", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuTransferOutSample", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuCancelChanges", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRoutineSampleDestruction", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAcceptDestruction", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRejectDestruction", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAmendTestResult", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuExternalTestResult", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest), null, obj);*/
            }
        }

        protected override void OnMenuSelected(object sender, DevExpress.XtraBars.ItemClickEventArgs itemClickEventArgs)
        {
            var actionMetaItem = itemClickEventArgs.Item.Tag as ActionMetaItem;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                LaboratorySectionUtils.RefreshData(manager, null, null, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, this, lclSample, lclTest);
            }
        }

        public override void Refresh()
        {
            LaboratorySectionUtils.Refresh(FindForm(), ParentObject, BusinessObject, Grid, this,
                () =>
                {
                    StaticFilter = new FilterParams().Add("MyPref", "=", true);
                    base.Refresh();
                    return DataSource;
                },
                (ParentObject as LaboratorySectionMaster).LaboratorySectionMyPrefItems, lclSample, lclTest, this, true);
        }
        public override ILayout GetLayout()
        {
            var layout = base.GetLayout();
            layout.ShowCaption = false;
            ((LayoutSimple)layout).ShowBottomPanel = false;
            return layout;
        }


   }
}