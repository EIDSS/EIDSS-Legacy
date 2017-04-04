using System;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using System.ComponentModel;
using System.Windows.Forms;

namespace bv.winclient.BasePanel
{
    public partial class BaseDetailPanel<T> : BasePanel<T>, IDetailPanel
        where T : class, IObject
    {
        protected IObjectSelectDetail m_SelectDetail;
        protected IObjectPost m_Post;

        public BaseDetailPanel()
        {
            InitializeComponent();
            VisibleChanged += BaseDetailPanel_VisibleChanged;
        }

        //this property is overriden in LaboratorySectionMasterDetail to avoid extra RtlHelper.SetRTL() call.
        //In this form RtlHelper.SetRTL is called by child list panels themselves.
        protected virtual bool SkipDefaultRtlInitialization { get { return false; } }
        protected override void InitLayout()
        {
            base.InitLayout();
            if(!SkipDefaultRtlInitialization)
                RtlHelper.SetRTL(this);
        }
        private bool m_ClosingEventAssigned;
        private void BaseDetailPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (!m_ClosingEventAssigned && ParentForm != null)
            {
                m_ClosingEventAssigned = true;
                ParentForm.Closing += FormClosing;
            }
        }

        private void FormClosing(object sender, CancelEventArgs e)
        {
            if (BaseFormManager.FormClosing)
                return;
            if (sender == BaseFormManager.MainForm || e.Cancel)
                return;
            if (LifeTimeState == LifeTimeState.DataLoading)
                e.Cancel = true;
            else if (LifeTimeState != LifeTimeState.Closing)
            {
                e.Cancel = true;
                BeginInvoke(new MethodInvoker(() => PerformAction("Cancel")));
            }
        }

        public override void LoadData(ref object id, int? HAcode = null)
        {
            try
            {
                using (DbManagerProxy manager = CreateDbManagerProxy())
                {
                    IObjectSelectDetail accessor = ObjectAccessor.SelectDetailInterface(typeof(T));
                    if (accessor != null)
                    {
                        LifeTimeState = LifeTimeState.DataLoading;
                        BusinessObject = accessor.SelectDetail(manager, id, HAcode) as T;
                        Dbg.Assert(BusinessObject != null, "unable to get BusinessObject");
                        // ReSharper disable PossibleNullReferenceException
                        id = BusinessObject.Key;
                        // ReSharper restore PossibleNullReferenceException
                    }
                }
            }
            catch (Exception ex)
            {
                if (!bv.common.Configuration.BaseSettings.ScanFormsMode)
                    ErrorForm.ShowError(StandardError.DataRetrievingError, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ILayout GetLayout()
        {
            if (Parent == null/*Create layout only if panel is not placed to other control already*/
                && ParentLayout == null)
            {
                ParentLayout = this.CreateLayoutSimple(BusinessObject, Caption, FormID, Icon);
                OnAfterLayoutCreated();
            }
            return ParentLayout;
        }


        protected override void VisualizePermissions()
        {
            var permissions = BusinessObject as IObjectPermissions;
            if (permissions != null)
            {

                if ((!Utils.IsEmpty(BusinessObject.Key) && !permissions.CanUpdate) || (Utils.IsEmpty(BusinessObject.Key) && !permissions.CanInsert))
                    ReadOnly = true;
            }
        }
        public override bool Post()
        {
            if (BusinessObject == null)
                return true;
            var postObject = BusinessObject.GetAccessor() as IObjectPost;
            if (postObject == null)
                return true;
            if (ReadOnly)
                return true;
            if (!Utils.IsCalledFromUnitTest() && FindForm() == null)
                return true;
            if (!BusinessObject.HasChanges)
                return true;
            try
            {
                using (var manager = CreateDbManagerProxy())
                {
                    postObject.Post(manager, BusinessObject);
                }
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(StandardError.DataSavingtError, ex);
            }
            return true;
        }

        public override bool Delete(object key)
        {
            if (!(BusinessObject is IObjectPost))
                return true;
            try
            {
                if (!BusinessObject.MarkToDelete())
                    return false;
                using (DbManagerProxy manager = CreateDbManagerProxy())
                {
                    var postObject = BusinessObject as IObjectPost;
                    postObject.Post(manager, BusinessObject);
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(StandardError.DataSavingtError, ex);
                return false;
            }
        }
        protected string[] m_RelatedLists;
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] RelatedLists
        {
            get
            {
                return m_RelatedLists;
            }
        }

        public override void AfterPost(object senter, EventArgs e)
        {
            if (m_RelatedLists != null)
            {
                foreach (string name in m_RelatedLists)
                    BaseFormManager.RefreshList(name);
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object Key
        {
            get
            {
                var master = this as IMasterDetail;
                if (master != null)
                    return ((IApplicationForm)master.Child).Key;
                return base.Key;
            }
        }

    }
}
