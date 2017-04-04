using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Resizing;
using DevExpress.XtraLayout.Utils;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.FlexForms;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionItemListPanel : BaseListPanel_LaboratorySectionItem
    {
        public IObject ParentObject { get; set; }
        private LayoutViewColumnList lclSample = new LayoutViewColumnList();
        private LayoutViewColumnList lclTest = new LayoutViewColumnList();
        private LayoutControlGroup groupFF;

        public LaboratorySectionItemListPanel()
        {
            InitializeComponent();
            m_GridLayoutName = "LaboratorySectionItem";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LaboratorySectionUtils.BindNodes(Grid, this, lclSample, lclTest, out groupFF);
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

        protected override void LoadGridLayout()
        {
            base.LoadGridLayout();

            Grid.GridView.MasterRowGetRelationCount += LaboratorySectionUtils.RelationCount;
            Grid.GridView.MasterRowGetRelationName += LaboratorySectionUtils.RelationName;
            Grid.GridView.MasterRowGetRelationDisplayCaption += LaboratorySectionUtils.RelationDisplayCaption;
            Grid.GridView.MasterRowGetChildList += ChildList;

            //Grid.GridView.MasterRowExpanding += MasterRowExpanded; 
            //Grid.GridView.MasterRowExpanded += MasterRowExpanded; //(sender, args) => 
                //{
                    /*
                    if (groupFF.Items.Count == 0)
                    {
                        var presenter = new XtraUserControl();
                        presenter.Width = 300;
                        presenter.Height = 150;
                        presenter.BorderStyle = BorderStyle.Fixed3D;
                        presenter.Name = Guid.NewGuid().ToString();

                        LayoutControlItem item = new LayoutControlItem();
                        item.Name = Guid.NewGuid().ToString();
                        item.Text = "";
                        item.TextVisible = false;
                        item.Control = presenter;

                        groupFF.GroupBordersVisible = true;
                        groupFF.AddItem(item);
                        //item.Name = " ";
                    }
                    */

                    /*
                    var row = Grid.GridView.GetRow(args.RowHandle) as LaboratorySectionItem;

                    //var presenter = new FFPresenter(row.FFPresenter);
                    var presenter = new BvXtraUserControl();
                    presenter.Width = 400;
                    presenter.Height = 200;
                    presenter.BorderStyle = BorderStyle.FixedSingle;

                    groupFF.AddItem("", presenter);

                    //tpVectorSpecificData.Controls.Add(presenter);

                    //presenter.Dock = DockStyle.Fill;
                    //presenter.Left = 400;
                    //presenter.Top = 100;
                    //presenter.Width = 400;
                    //presenter.Height = 500;
                    //presenter.ShowFlexibleForm();
                    */
                //};
            Grid.GridView.MasterRowCollapsed += (sender, args) =>
                {
                    /*if (groupFF.Items.Count > 0)
                    {
                        //var i = groupFF.Items[0] as LayoutControlItem;
                        //var p = i.Control as FFPresenter;
                        //p.Hide();
                    }
                    groupFF.Items.Clear();
                    */
                };
            
            Grid.GridView.OptionsDetail.ShowDetailTabs = true;
            Grid.GridView.OptionsDetail.EnableMasterViewMode = true;
            Grid.GridView.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            Grid.GridView.OptionsView.ShowDetailButtons = true;

            Grid.GridView.RowStyle += (sender, args) =>
                {
                    if (args.RowHandle >= 0 && args.RowHandle < (ParentObject as LaboratorySectionMaster).LaboratorySectionItems.Count)
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
                DataSource = (ParentObject as LaboratorySectionMaster).LaboratorySectionItems.ToList();
            }
            Grid.GridControl.DataSource = DataSource;
            LaboratorySectionUtils.BindDataSource(ParentObject, BusinessObject, Grid, this, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, lclSample, lclTest, this, false);
        }


        /*void MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            LaboratorySectionUtils.MasterRowExpanded(e, Grid, this, lclSample, lclTest, groupFF);
        }*/
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
                SetActionFunction(actions, "CreateSample", (proxy, o, pars) => LaboratorySectionUtils.CreateSample(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, false, this, lclSample, lclTest), null, obj);
                SetActionFunction(actions, "GroupAccessionIn", (proxy, o, pars) => LaboratorySectionUtils.GroupAccessionIn(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, false, this, lclSample, lclTest), null, obj);
                SetActionFunction(actions, "MenuAssignTest", (proxy, o, pars) => LaboratorySectionUtils.MenuAssignTest(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetActionFunction(actions, "MenuCreateAliquot", (proxy, o, pars) => LaboratorySectionUtils.MenuCreateAliquot(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuCreateDerivative", (proxy, o, pars) => LaboratorySectionUtils.MenuCreateDerivative(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAccessionInGoodCondition", (proxy, o, pars) => LaboratorySectionUtils.AcceptedInGoodCondition(proxy, o, pars, ParentObject, SelectedItems), null, obj);
                SetActionFunction(actions, "MenuAccessionInPoorCondition", (proxy, o, pars) => LaboratorySectionUtils.AcceptedInPoorCondition(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAccessionInRejected", (proxy, o, pars) => LaboratorySectionUtils.AcceptedReject(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRemove", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuDeleteSample", (proxy, o, pars) => LaboratorySectionUtils.ConfirmDelete(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuTransferOutSample", (proxy, o, pars) => LaboratorySectionUtils.MenuTransferOutSample(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuCancelChanges", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRoutineSampleDestruction", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuAcceptDestruction", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuRejectDestruction", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuStartTest", (proxy, o, pars) => LaboratorySectionUtils.StartTest(proxy, o, pars, ParentObject, SelectedItems), null, obj);
                SetActionFunction(actions, "MenuSetTestResult", (proxy, o, pars) => LaboratorySectionUtils.SetTestResult(proxy, o, pars, ParentObject, SelectedItems), null, obj);
                SetActionFunction(actions, "MenuValidateTestResult", (proxy, o, pars) => LaboratorySectionUtils.ValidateTestResult(proxy, o, pars, ParentObject, SelectedItems), null, obj);
                SetActionFunction(actions, "MenuAmendTestResult", (proxy, o, pars) => LaboratorySectionUtils.MenuAmendTestResult(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuExternalTestResult", (proxy, o, pars) => LaboratorySectionUtils.DoNothing(proxy, o, pars, ParentObject), null, obj);
                SetActionFunction(actions, "MenuPrintBarcode", (proxy, o, pars) => LaboratorySectionUtils.MenuPrintBarcode(proxy, o, pars, ParentObject), null, obj);
                /*SetPostActionFunction(actions, "MenuCreateAliquot", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuCreateDerivative", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAccessionInGoodCondition", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAccessionInPoorCondition", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAccessionInRejected", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRemove", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuDeleteSample", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuTransferOutSample", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuCancelChanges", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRoutineSampleDestruction", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAcceptDestruction", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuRejectDestruction", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuAmendTestResult", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);
                SetPostActionFunction(actions, "MenuExternalTestResult", (proxy, o, pars) => LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest), null, obj);*/
            }
        }

        public void RefreshData()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                LaboratorySectionUtils.RefreshData(manager, null, null, ParentObject, Grid, DataSource, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, this, lclSample, lclTest);
            }
        }
        protected override void OnMenuSelected(object sender, DevExpress.XtraBars.ItemClickEventArgs itemClickEventArgs)
        {
            var actionMetaItem = itemClickEventArgs.Item.Tag as ActionMetaItem;
            RefreshData();
        }

        public override void Refresh()
        {
            LaboratorySectionUtils.Refresh(FindForm(), ParentObject, BusinessObject, Grid, this, () => { base.Refresh(); return DataSource; }, (ParentObject as LaboratorySectionMaster).LaboratorySectionItems, lclSample, lclTest, this, false);
        }


        public override ILayout GetLayout()
        {
            var layout =  base.GetLayout();
            layout.ShowCaption = false;
            ((LayoutSimple)layout).ShowBottomPanel = false;
            return layout;
        }

   }
}

