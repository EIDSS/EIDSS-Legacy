using System;
using System.Windows.Forms;
using System.Data;
using bv.common;
using bv.common.Core;
using bv.common.win;
using bv.common.Objects;
using System.Collections;
using bv.winclient.BasePanel;

namespace EIDSS
{
	/// <summary>
	/// Summary description for ObjectAccessDetail.
	/// </summary>
	public class ObjectAccessDetail : BaseDetailForm
	{
		private ObjectAccessPanel panel=new ObjectAccessPanel();

		private static System.Windows.Forms.Control m_Parent = null;
		//private System.ComponentModel.IContainer components;
	
		public ObjectAccessDetail(ObjectType objectType)
		{

			InitializeComponent();
            this.ShowDeleteButton = false;
            panel.Parent = this;
            panel.Visible = true;
            panel.Dock = DockStyle.Fill;

            this.DbService = new ObjectAccessDetail_DB();
            this.RegisterChildObject(panel, RelatedPostOrder.PostLast);
            this.AuditObject = new bv.common.Objects.AuditObject((long)EIDSSAuditObject.daoDataAccess, (long)AuditTable.tstObjectAccess);
            this.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.DataAccess;
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
            this.ShowDeleteButton = false;
            panel.Parent = this;
            panel.Visible = true;
            panel.Dock = DockStyle.Fill;

            this.DbService = new ObjectAccessDetail_DB();
            this.RegisterChildObject(panel, RelatedPostOrder.PostLast);
            this.AuditObject = new bv.common.Objects.AuditObject((long)EIDSSAuditObject.daoDataAccess, (long)AuditTable.tstObjectAccess);
            this.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.SystemFunction;
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
			set
			{
				panel.ObjectType=value;
			}
		}

		#region Designer
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectAccessDetail));
            this.SuspendLayout();
            // 
            // ObjectAccessDetail
            // 
            resources.ApplyResources(this, "$this");
            this.FormID = "A20";
            this.HelpTopicID = "DataAccessManagementForm";
            this.LeftIcon = global::EIDSS_ObjectAccess.Properties.Resources.Permissions__large__68_;
            this.Name = "ObjectAccessDetail";
            this.Sizable = true;
            this.ResumeLayout(false);

		}
		#endregion

		public static void ShowMe()
		{
		    object id = null;
			BaseFormManager.ShowClient(new ObjectAccessDetail(EIDSS.ObjectType.None), ObjectAccessDetail.m_Parent, ref id);
		}

	
		public override object GetChildKey(IRelatedObject child)
		{
			return this.DbService.ID;
		}
	
	}
}
