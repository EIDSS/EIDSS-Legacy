using System;
using System.Collections.Generic;
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
    public partial class LaboratorySectionAssignTest : BaseDetailPanel_LaboratorySectionItem
    {
        private IObject ParentObject { get; set; }
        private List<IObject> ListOfObjects { get; set; }
        private BaseListGridControl Grid { get; set; }
        private List<LaboratorySectionItem> DataSource { get; set; }
        private EditableList<LaboratorySectionItem> List { get; set; }
        private BaseListPanel<LaboratorySectionItem> Panel { get; set; }
        private LayoutViewColumnList LclSample { get; set; }
        private LayoutViewColumnList LclTest { get; set; }

        public LaboratorySectionAssignTest()
        {
            InitializeComponent();
        }

        public LaboratorySectionAssignTest(IObject parent, List<IObject> objs, BaseListGridControl grid, List<LaboratorySectionItem> dataSource, EditableList<LaboratorySectionItem> list, BaseListPanel<LaboratorySectionItem> panel, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            ParentObject = parent;
            ListOfObjects = objs;
            Grid = grid;
            DataSource = dataSource;
            List = list;
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

            LookupBinder.BindTestDiagnosisLookup(leDiagnosis, item, "DiagnosisForTest", item.DiagnosisForTestLookup);
            LookupBinder.BindCheckEdit(chTestNameByDiag, item, "bFilterTestByDiagnosis");
            LookupBinder.BindLookup(leTestName, item, "TestNameRef", item.TestNameRefLookup, false);
            LookupBinder.BindLookup(leTestResult, item, "TestResultRef", item.TestResultRefLookup, false);
            LookupBinder.BindLookup(leTestCategory, item, "TestCategoryRef", item.TestCategoryRefLookup, false);
            LookupBinder.BindDate(dtStartedDate, item, "datStartedDate");
            LookupBinder.BindDate(dtResultDate, item, "datConcludedDate");
        }

        public override void SetCustomActions(System.Collections.Generic.List<bv.model.Model.Core.ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
                SetActionFunction(actions, "ItemAssignTest", (proxy, o, pars) => LaboratorySectionUtils.ItemAssignTest(proxy, o, pars, ParentObject, ListOfObjects), null, obj);
                SetPostActionFunction(actions, "ItemAssignTest", (proxy, o, pars) =>
                    {
                        lblAddNote.Visible = true;
                        return LaboratorySectionUtils.RefreshData(proxy, o, pars, ParentObject, Grid, DataSource, List, Panel, LclSample, LclTest);
                    }, null, obj);
            }
        }

    }
}
