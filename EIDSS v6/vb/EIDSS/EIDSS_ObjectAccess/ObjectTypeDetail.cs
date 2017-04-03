using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.win;
using System.Data;
using bv.winclient.BasePanel;
using DevExpress.Utils;

namespace EIDSS
{
	public class ObjectTypeDetail : BaseDetailForm
	{
		private static System.Windows.Forms.Control m_Parent = null;
		private DevExpress.XtraEditors.TextEdit ctlNationalName;
		private DevExpress.XtraEditors.TextEdit ctlDefaultName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private string ParentID;

		public ObjectTypeDetail(string parentID)
		{

			InitializeComponent();
			this.ParentID = parentID;
			base.DbService = new ObjectType_DB(this.ParentID);
            this.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.DataAccess;
        }

        // only for scan mode
        public ObjectTypeDetail()
        {
            InitializeComponent();
        }


		#region Designer
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectTypeDetail));
            this.ctlNationalName = new DevExpress.XtraEditors.TextEdit();
            this.ctlDefaultName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctlNationalName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDefaultName.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ObjectTypeDetail), out resources);
            // Form Is Localizable: True
            // 
            // ctlNationalName
            // 
            resources.ApplyResources(this.ctlNationalName, "ctlNationalName");
            this.ctlNationalName.Name = "ctlNationalName";
            this.ctlNationalName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ctlNationalName.Properties.Appearance.Font")));
            this.ctlNationalName.Properties.Appearance.Options.UseFont = true;
            this.ctlNationalName.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ctlNationalName.Properties.AppearanceDisabled.Font")));
            this.ctlNationalName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ctlNationalName.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ctlNationalName.Properties.AppearanceFocused.Font")));
            this.ctlNationalName.Properties.AppearanceFocused.Options.UseFont = true;
            this.ctlNationalName.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ctlNationalName.Properties.AppearanceReadOnly.Font")));
            this.ctlNationalName.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // ctlDefaultName
            // 
            resources.ApplyResources(this.ctlDefaultName, "ctlDefaultName");
            this.ctlDefaultName.Name = "ctlDefaultName";
            this.ctlDefaultName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ctlDefaultName.Properties.Appearance.Font")));
            this.ctlDefaultName.Properties.Appearance.Options.UseFont = true;
            this.ctlDefaultName.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ctlDefaultName.Properties.AppearanceDisabled.Font")));
            this.ctlDefaultName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ctlDefaultName.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ctlDefaultName.Properties.AppearanceFocused.Font")));
            this.ctlDefaultName.Properties.AppearanceFocused.Options.UseFont = true;
            this.ctlDefaultName.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ctlDefaultName.Properties.AppearanceReadOnly.Font")));
            this.ctlDefaultName.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ObjectTypeDetail
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ObjectTypeDetail.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ctlNationalName);
            this.Controls.Add(this.ctlDefaultName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormID = "A19";
            this.LeftIcon = global::EIDSS_ObjectAccess.Properties.Resources.Data_Access_Types__large__30_1_1;
            this.Name = "ObjectTypeDetail";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ctlDefaultName, 0);
            this.Controls.SetChildIndex(this.ctlNationalName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ctlNationalName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDefaultName.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public static void ShowMe()
		{
		    object id = null;
			BaseFormManager.ShowClient(new ObjectTypeDetail(null), m_Parent, ref id);
		}


		protected override void DefineBinding()
		{
            Core.LookupBinder.BindTextEdit(ctlDefaultName, this.baseDataSet, "ObjectType.strDefault");
            Core.LookupBinder.BindTextEdit(ctlNationalName, this.baseDataSet, "ObjectType.Name");
		}
	}
}
