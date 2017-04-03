using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.winclient.Lab
{
    public partial class SampleLogBookTabPanel : UserControl, IApplicationForm, IListFormsContainer
    {
        private IApplicationForm m_IApplicationForm;
        //private IBaseListPanel m_IBaseListPanel;

        private SampleLogBookListPanel m_SampleLogBookListPanel;
        private SampleLogBookMyPrefListPanel m_SampleLogBookMyPrefListPanel;

        public SampleLogBookTabPanel()
        {
            InitializeComponent();

            m_SampleLogBookListPanel = new SampleLogBookListPanel();
            Control c1 = m_SampleLogBookListPanel.GetLayout() as Control;
            c1.Dock = DockStyle.Fill;
            tpSampleLogBook.Controls.Add(c1);

            m_IApplicationForm = m_SampleLogBookListPanel;
            //m_IBaseListPanel = m_SampleLogBookListPanel;

            m_SampleLogBookMyPrefListPanel = new SampleLogBookMyPrefListPanel();
            Control c2 = m_SampleLogBookMyPrefListPanel.GetLayout() as Control;
            c2.Dock = DockStyle.Fill;
            tpMyPreferences.Controls.Add(c2);
            m_List = new List<IBaseListPanel>(){m_SampleLogBookListPanel, m_SampleLogBookMyPrefListPanel};
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            var panel = e.Page.Controls[0].Controls[0].Controls[0] as SampleLogBookMyPrefListPanel;
            if (panel != null)
            {
                panel.Refresh();
            }
            //m_IApplicationForm = e.Page.Controls[0] as IApplicationForm;
            //m_IBaseListPanel = e.Page.Controls[0] as IBaseListPanel;
        }

        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuLabSampleLogBook", 1075, true, (int)MenuIconsSmall.LabSampleLogBook,
                           (int)MenuIcons.LabSampleLogBook)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample),
                ShowInMenu = true,
                BeginGroup = BaseSettings.LabSimplifiedMode
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(SampleLogBookTabPanel), BaseFormManager.MainForm,
                                       LabSampleLogBookListItem.CreateInstance());
        }

        /*
        #region IBaseListPanel
        public IList<bv.model.Model.Core.IObject> SelectedItems
        {
            get { return m_IBaseListPanel.SelectedItems; }
        }

        public bv.model.Model.Core.IObject FocusedItem
        {
            get { return m_IBaseListPanel.FocusedItem; }
        }

        public bv.model.Model.Core.SelectMode SelectMode
        {
            get
            {
                return m_IBaseListPanel.SelectMode;
            }
            set
            {
                m_IBaseListPanel.SelectMode = value;
            }
        }

        public bv.model.Model.Core.ISearchPanel SearchPanel
        {
            get { return m_IBaseListPanel.SearchPanel; }
        }

        public bv.winclient.BasePanel.ListPanelComponents.BaseListGridControl Grid
        {
            get { return m_IBaseListPanel.Grid; }
        }

        public InlineMode InlineMode
        {
            get
            {
                return m_IBaseListPanel.InlineMode;
            }
            set
            {
                m_IBaseListPanel.InlineMode = value;
            }
        }

        public event EventHandler<bv.winclient.BasePanel.ListPanelComponents.FocusedItemChangedEventArgs<bv.model.Model.Core.IObject>> FocusedItemChanged;

        public event EventHandler<bv.winclient.BasePanel.ListPanelComponents.SelectedItemsChangedEventArgs<bv.model.Model.Core.IObject>> SelectedItemsChanged;

        public void RefreshFocusedItem()
        {
            m_IBaseListPanel.RefreshFocusedItem();
        }

        public void LoadData()
        {
            m_IBaseListPanel.LoadData();
        }

        public void Edit(object key, List<object> parameters, bv.common.Enums.ActionTypes actionType, bool readOnly)
        {
            m_IBaseListPanel.Edit(key, parameters, actionType, readOnly);
        }

        public bv.model.Model.Core.IObject GetItem(object key)
        {
            return m_IBaseListPanel.GetItem(key);
        }

        public void SelectAll()
        {
            m_IBaseListPanel.SelectAll();
        }

        public bool EnableMultiEdit
        {
            get
            {
                return m_IBaseListPanel.EnableMultiEdit;
            }
            set
            {
                m_IBaseListPanel.EnableMultiEdit = value;
            }
        }

        public string HelpTopicID
        {
            get
            {
                return m_IBaseListPanel.HelpTopicID;
            }
            set
            {
                m_IBaseListPanel.HelpTopicID = value;
            }
        }
        */
        public string Caption
        {
            get
            {
                return m_IApplicationForm.Caption;
            }
            /*set
            {
                m_IBaseListPanel.Caption = value;
            }*/
        }
        /*
        public string FormID
        {
            get
            {
                return m_IBaseListPanel.FormID;
            }
            set
            {
                m_IBaseListPanel.FormID = value;
            }
        }
        */
        public Dictionary<string, object> StartUpParameters
        {
            get
            {
                return m_IApplicationForm.StartUpParameters;
            }
            set
            {
                m_IApplicationForm.StartUpParameters = value;
            }
        }
        /*
        public bool ReadOnly
        {
            get
            {
                return m_IBaseListPanel.ReadOnly;
            }
            set
            {
                m_IBaseListPanel.ReadOnly = value;
            }
        }

        public LifeTimeState LifeTimeState
        {
            get
            {
                return m_IBaseListPanel.LifeTimeState;
            }
            set
            {
                m_IBaseListPanel.LifeTimeState = value;
            }
        }

        public Image Icon
        {
            get
            {
                return m_IBaseListPanel.Icon;
            }
            set
            {
                m_IBaseListPanel.Icon = value;
            }
        }

        public void DefineBinding()
        {
            m_IBaseListPanel.DefineBinding();
        }

        public bool Post()
        {
            return m_IBaseListPanel.Post();
        }

        public bool Delete(object key)
        {
            return m_IBaseListPanel.Delete(key);
        }

        public void LoadData(object id, int? hAcode = null)
        {
            m_IBaseListPanel.LoadData(id, hAcode);
        }

        public bv.winclient.Layout.ILayout GetLayout()
        {
            return m_IBaseListPanel.GetLayout();
        }

        public Type GetBusinessObjectType()
        {
            return m_IBaseListPanel.GetBusinessObjectType();
        }

        public List<bv.model.Model.Core.ActionMetaItem> CustomActions
        {
            get { return m_IBaseListPanel.CustomActions; }
        }

        public void SetCustomActions()
        {
            m_IBaseListPanel.SetCustomActions();
        }

        public void ShowReport()
        {
            m_IBaseListPanel.ShowReport();
        }

        public bv.model.Model.Core.IObject BusinessObject
        {
            get
            {
                return m_IBaseListPanel.BusinessObject;
            }
            set
            {
                m_IBaseListPanel.BusinessObject = value;
            }
        }

        public void UpdateControlsState()
        {
            m_IBaseListPanel.UpdateControlsState();
        }

        public IBasePanel RootPanel
        {
            get { return m_IBaseListPanel.RootPanel; }
        }

        public IBasePanel ParentBasePanel
        {
            get { return m_IBaseListPanel.ParentBasePanel; }
        }

        public List<object> GetParamsAction()
        {
            return m_IBaseListPanel.GetParamsAction();
        }

        public List<object> GetParamsAction(bv.model.Model.Core.IObject o)
        {
            return m_IBaseListPanel.GetParamsAction(o);
        }

        public void CheckActionPermission(bv.model.Model.Core.ActionMetaItem action, ref bool showAction)
        {
            m_IBaseListPanel.CheckActionPermission(action, ref showAction);
        }

        public void VisitControls(Control ctl, string boName, VisitControlFunction[] functions)
        {
            m_IBaseListPanel.VisitControls(ctl, boName, functions);
        }
        #endregion
        */

        #region IApplicationForm


        public bool Close(FormClosingMode closeMode)
        {
            m_SampleLogBookListPanel.Close(FormClosingMode.Save);
            m_SampleLogBookMyPrefListPanel.Close(FormClosingMode.Save);
            Dispose();
            return true;
        }

        public bool Cancel()
        {
            throw new NotImplementedException();
        }

        public Control Activate()
        {
            this.BringToFront();
            return this;
        }

        public bool Sizable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public bv.model.Model.Core.ActionMetaItem GetLastExecutedAction()
        {
            return m_IApplicationForm.GetLastExecutedAction();
        }

        public object Key
        {
            get { return 0; }
        }

        public void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void Release()
        {
            
        }

        public void ShowHelp()
        {
            if (m_SampleLogBookListPanel.Visible)
                m_SampleLogBookListPanel.ShowHelp();
            else if(m_SampleLogBookMyPrefListPanel.Visible)
                m_SampleLogBookMyPrefListPanel.ShowHelp();
        }

        [Browsable(false), DefaultValue(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisableDelayedDisposing { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinHeight { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinWidth { get; set; }

        public bool IsSingleTone
        {
            get { return true; }
        }

        #endregion

        private readonly List<IBaseListPanel> m_List;
        public List<IBaseListPanel> ListPanels
        {
            get
            {
                return m_List;
            }
        }
    }
}
