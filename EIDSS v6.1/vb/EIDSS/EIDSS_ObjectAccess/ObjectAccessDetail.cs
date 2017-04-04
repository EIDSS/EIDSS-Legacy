using System.ComponentModel;
using System.Windows.Forms;
using bv.common;
using bv.common.db;
using bv.common.Objects;
using bv.common.Resources;
using bv.common.win;
using bv.winclient.BasePanel;
using eidss.model.Enums;
using EIDSS_ObjectAccess.Properties;

namespace EIDSS
{
    /// <summary>
    ///     Summary description for ObjectAccessDetail.
    /// </summary>
    public class ObjectAccessDetail : BaseDetailForm
    {
        private ObjectAccessPanel panel = new ObjectAccessPanel();

        private static Control m_Parent = null;
        //private System.ComponentModel.IContainer components;

        public ObjectAccessDetail(ObjectType objectType)
        {
            InitializeComponent();
            ShowDeleteButton = false;
            panel.Parent = this;
            panel.Visible = true;
            panel.Dock = DockStyle.Fill;

            DbService = new ObjectAccessDetail_DB();
            RegisterChildObject(panel, RelatedPostOrder.PostLast);
            AuditObject = new AuditObject((long) EIDSSAuditObject.daoDataAccess, (long) AuditTable.tstObjectAccess);
            PermissionObject = EIDSSPermissionObject.DataAccess;
            //this.Permissions = new StandardAccessPermissions(
            //    PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.UpdatePermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.DeletePermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.ExecutePermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess)
            //    );
            panel.ObjectType = objectType;
        }

        public ObjectAccessDetail()
        {
            InitializeComponent();
            ShowDeleteButton = false;
            panel.Parent = this;
            panel.Visible = true;
            panel.Dock = DockStyle.Fill;

            DbService = new ObjectAccessDetail_DB();
            RegisterChildObject(panel, RelatedPostOrder.PostLast);
            AuditObject = new AuditObject((long) EIDSSAuditObject.daoDataAccess, (long) AuditTable.tstObjectAccess);
            PermissionObject = EIDSSPermissionObject.SystemFunction;
            //this.Permissions = new StandardAccessPermissions(
            //    PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.UpdatePermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.DeletePermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess),
            //    PermissionHelper.ExecutePermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess)
            //    );
        }

        public ObjectType ObjectType
        {
            set { panel.ObjectType = value; }
        }

        #region Designer

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectAccessDetail));
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ObjectAccessDetail), out resources);
            // Form Is Localizable: True
            // 
            // ObjectAccessDetail
            // 
            resources.ApplyResources(this, "$this");
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.FormID = "A20";
            this.HelpTopicID = "Security";
            this.LeftIcon = global::EIDSS_ObjectAccess.Properties.Resources.Permissions__large__68_;
            this.Name = "ObjectAccessDetail";
            this.Sizable = true;
            this.Status = bv.common.win.FormStatus.Draft;
            this.ResumeLayout(false);

        }

        #endregion

        public static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowClient(new ObjectAccessDetail(ObjectType.None), m_Parent, ref id);
        }

        public override object GetChildKey(IRelatedObject child)
        {
            return DbService.ID;
        }
    }
}