namespace EIDSS.RAM.QueryBuilder
{
    partial class QueryInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryInfo));
            this.cbQuery = new DevExpress.XtraEditors.LookUpEdit();
            this.lblQuery = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbQuery
            // 
            resources.ApplyResources(this.cbQuery, "cbQuery");
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbQuery.Properties.Buttons"))))});
            this.cbQuery.Properties.NullText = resources.GetString("cbQuery.Properties.NullText");
            // 
            // lblQuery
            // 
            resources.ApplyResources(this.lblQuery, "lblQuery");
            this.lblQuery.Name = "lblQuery";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // memDescription
            // 
            resources.ApplyResources(this.memDescription, "memDescription");
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.ReadOnly = true;
            // 
            // QueryInfo
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbQuery);
            this.Controls.Add(this.memDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblQuery);
            this.KeyFieldName = "idflQuery";
            this.Name = "QueryInfo";
            this.ObjectName = "Query";
            this.Sizable = true;
            this.TableName = "Query";
            this.UseParentBackColor = true;
            ((System.ComponentModel.ISupportInitialize)(this.cbQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbQuery;
        private System.Windows.Forms.Label lblQuery;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private System.Windows.Forms.Label lblDescription;



    }
}
