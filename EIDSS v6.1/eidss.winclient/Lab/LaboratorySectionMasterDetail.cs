using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionMasterDetail : BaseDetailPanel_LaboratorySectionMaster
    {
        private LaboratorySectionItemListPanel m_LaboratorySectionItemListPanel;
        private LaboratorySectionMyPrefItemListPanel m_LaboratorySectionMyPrefItemListPanel;
        //private IObject ParentForList;
        //private IObject ParentForListMyPref;

        /// <summary>
        /// 
        /// </summary>
        public LaboratorySectionMasterDetail()
        {
            InitializeComponent();

            m_LaboratorySectionItemListPanel = new LaboratorySectionItemListPanel();
            var c1 = m_LaboratorySectionItemListPanel.GetLayout() as Control;
            c1.Dock = DockStyle.Fill;
            xtraTabLabSec.Controls.Add(c1);

            m_LaboratorySectionMyPrefItemListPanel = new LaboratorySectionMyPrefItemListPanel();
            var c2 = m_LaboratorySectionMyPrefItemListPanel.GetLayout() as Control;
            c2.Dock = DockStyle.Fill;
            xtraTabMyPref.Controls.Add(c2);
            /*
            xtraTabLabSec.TabControl.SelectedPageChanged += (sender, args) =>
                {
                    if (xtraTabLabSec.TabControl.SelectedTabPageIndex == 0)
                    {
                        BusinessObject = ParentForList;
                        ParentLayout.BusinessObject = ParentForList;
                        m_LaboratorySectionItemListPanel.BindDataSource();
                    }
                    else
                    {
                        BusinessObject = ParentForListMyPref;
                        ParentLayout.BusinessObject = ParentForListMyPref;
                        m_LaboratorySectionMyPrefItemListPanel.BindDataSource();
                    }
                };
            */
            //this.Controls.Add(c1);

            m_ReportMenu = new ContextMenu();
            var sampleReportIem = new MenuItem(EidssMessages.Get("rptSampleReport"));
            sampleReportIem.Click += ShowSampleReport;
            m_testResultReportIem = new MenuItem(EidssMessages.Get("rptTestResultReport"));
            m_testResultReportIem.Click += ShowTestResultReport;
            m_sampleDestructionReportIem = new MenuItem(EidssMessages.Get("rptSampleDestructionReport"));
            m_sampleDestructionReportIem.Click += ShowSampleDestructionReport;
            m_ReportMenu.MenuItems.Add(sampleReportIem);
            m_ReportMenu.MenuItems.Add(m_testResultReportIem);
            m_ReportMenu.MenuItems.Add(m_sampleDestructionReportIem);

        }
        //Skip default RTL initialization
        protected override bool SkipDefaultRtlInitialization { get { return true; } }

        private ContextMenu m_ReportMenu;
        private MenuItem m_sampleDestructionReportIem;
        private MenuItem m_testResultReportIem;
        public override void ShowReport()
        {
            LaboratorySectionItem item;
            if (xtraTabMyPref.TabControl.SelectedTabPageIndex == 0)
                item = (LaboratorySectionItem)m_LaboratorySectionItemListPanel.FocusedItem;
            else
                item = (LaboratorySectionItem)m_LaboratorySectionMyPrefItemListPanel.FocusedItem;

            if (item != null)
            {
                m_testResultReportIem.Visible = item.idfTesting.HasValue && !item.bTestInserted;
                m_sampleDestructionReportIem.Visible = item.idfsSampleStatus == (long)SampleStatus.RoutineDestruction ||
                                                       item.idfsSampleStatus == (long)SampleStatus.Destroyed;
            }
            else
            {
                m_testResultReportIem.Visible = false;
                m_sampleDestructionReportIem.Visible = false;
            }
            var menu = new PopupMenuWrapper(m_ReportMenu);
            {
                menu.ShowPopup(MousePosition);
            }
        }

        private void ShowTestResultReport(object sender, EventArgs e)
        {
            LaboratorySectionItem item;
            if (xtraTabMyPref.TabControl.SelectedTabPageIndex == 0)
                item = (LaboratorySectionItem)m_LaboratorySectionItemListPanel.FocusedItem;
            else
                item = (LaboratorySectionItem)m_LaboratorySectionMyPrefItemListPanel.FocusedItem;

            if (item != null)
            {
                EidssSiteContext.ReportFactory.LimTestResult(item.idfTesting ?? 0, item.idfObservation ?? 0, item.idfsTestName ?? 0);
            }
        }

        private void ShowSampleDestructionReport(object sender, EventArgs e)
        {
            LaboratorySectionItem item;
            if (xtraTabMyPref.TabControl.SelectedTabPageIndex == 0)
                item = (LaboratorySectionItem)m_LaboratorySectionItemListPanel.FocusedItem;
            else
                item = (LaboratorySectionItem)m_LaboratorySectionMyPrefItemListPanel.FocusedItem;

            if (item != null)
            {
                EidssSiteContext.ReportFactory.LimSampleDestruction(new[] { item.idfMaterial });
            }
        }

        private void ShowSampleReport(object sender, EventArgs e)
        {
            LaboratorySectionItem item;
            if (xtraTabMyPref.TabControl.SelectedTabPageIndex == 0)
                item = (LaboratorySectionItem)m_LaboratorySectionItemListPanel.FocusedItem;
            else
                item = (LaboratorySectionItem)m_LaboratorySectionMyPrefItemListPanel.FocusedItem;

            if (item != null)
            {
                EidssSiteContext.ReportFactory.LimSample(item.idfMaterial);
            }
        }

        public override void LoadData(ref object id, int? HAcode = null)
        {
            base.LoadData(ref id, HAcode);
            BusinessObject.DeepAcceptChanges();
            /*
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                ParentForList = BusinessObject.CloneWithSetup(manager);
                ParentForListMyPref = BusinessObject.CloneWithSetup(manager);
                ParentForList.DeepAcceptChanges();
                ParentForListMyPref.DeepAcceptChanges();
            }
            m_LaboratorySectionItemListPanel.ParentObject = ParentForList;
            m_LaboratorySectionMyPrefItemListPanel.ParentObject = ParentForListMyPref;

            BusinessObject = ParentForList;
            */

            m_LaboratorySectionItemListPanel.ParentObject = BusinessObject;
            m_LaboratorySectionMyPrefItemListPanel.ParentObject = BusinessObject;

            m_LaboratorySectionItemListPanel.BindDataSource();
            m_LaboratorySectionMyPrefItemListPanel.BindDataSource();
        }

        public override bool Close(FormClosingMode closeMode)
        {
            var ret = base.Close(closeMode);
            if (ret)
            {
                m_LaboratorySectionItemListPanel.Close(closeMode);
                m_LaboratorySectionMyPrefItemListPanel.Close(closeMode);
            }
            return ret;
        }

        public override void ShowValidationError(object sender, ValidationEventArgs args)
        {
            var item = args.Obj as LaboratorySectionItem;
            var prefix = "";
            if (item != null)
            {
                prefix = String.Format(EidssMessages.Get("strLabSectionErrorPrefix"), item.strBarcode, item.strSampleName);
                if (item.bIsMyPref)
                {
                    var selectedRows = m_LaboratorySectionMyPrefItemListPanel.Grid.GridView.GetSelectedRows();
                    foreach (int i in selectedRows)
                        m_LaboratorySectionMyPrefItemListPanel.Grid.GridView.UnselectRow(i);

                    var ds = m_LaboratorySectionMyPrefItemListPanel.Grid.GridView.DataSource;
                    var rows = ds as IList<LaboratorySectionItem>;
                    int index = 0;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (rows[i].ID == item.ID)
                        {
                            index = i;
                            break;
                        }
                    }
                    index = m_LaboratorySectionMyPrefItemListPanel.Grid.GridView.GetRowHandle(index);
                    m_LaboratorySectionMyPrefItemListPanel.Grid.GridView.SelectRow(index);
                    m_LaboratorySectionMyPrefItemListPanel.Grid.GridView.TopRowIndex = index;
                }
                else
                {
                    var selectedRows = m_LaboratorySectionItemListPanel.Grid.GridView.GetSelectedRows();
                    foreach (int i in selectedRows)
                        m_LaboratorySectionItemListPanel.Grid.GridView.UnselectRow(i);

                    var ds = m_LaboratorySectionItemListPanel.Grid.GridView.DataSource;
                    var rows = ds as IList<LaboratorySectionItem>;
                    int index = 0;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (rows[i].ID == item.ID)
                        {
                            index = i;
                            break;
                        }
                    }
                    index = m_LaboratorySectionItemListPanel.Grid.GridView.GetRowHandle(index);
                    m_LaboratorySectionItemListPanel.Grid.GridView.SelectRow(index);
                    m_LaboratorySectionItemListPanel.Grid.GridView.TopRowIndex = index;
                }
            }
            ShowValidationErrorWithoutSetFocus(sender, args, prefix);
        }
        public override void ValidationEnd(object sender, ValidationEventArgs args)
        {
        }


        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "SelectAll", SelectAll);
            SetActionFunction(actions, "Save", (proxy, o, pars) => new ActResult(true, o));
            SetPostActionFunction(actions, "Save", (proxy, o, pars) =>
                {
                    if (xtraTabLabSec.TabControl.SelectedTabPageIndex == 0)
                        m_LaboratorySectionItemListPanel.RefreshData();
                    else
                        m_LaboratorySectionMyPrefItemListPanel.RefreshData();
                    return true;
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuLaboratorySection", 160, true, (int)MenuIconsSmall.LabSampleLogBook,
                           (int)MenuIcons.LabSampleLogBook)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample),
                ShowInMenu = true,
                ShowInToolbar = false,
                Group = (int)MenuGroup.MenuJournalsLabSection
                //BeginGroup = BaseSettings.LabSimplifiedMode
            };
            //Toolbar menu
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuLaboratorySection", 100300, true, (int)MenuIconsSmall.LabSampleLogBook,
                           (int)MenuIcons.LabSampleLogBook)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample),
                ShowInMenu = false,
                ShowInToolbar = true,
                Group = (int)MenuGroup.ToolbarLab
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(new LaboratorySectionMasterDetail(), ref id, null, 10000, 10000);
        }

        private ActResult SelectAll(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (xtraTabMyPref.TabControl.SelectedTabPageIndex == 0)
                m_LaboratorySectionItemListPanel.SelectAll();
            else
                m_LaboratorySectionMyPrefItemListPanel.SelectAll();
            return true;
        }

        
    }

}
