namespace bv.winclient.Core.TranslationTool
{
    partial class PropertyGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.propGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.rowCaption = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.categoryLocation = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowX = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowY = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.categorySize = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowWidth = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowHeight = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.categoryMenuItems = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowMenuItems = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // propGrid
            // 
            this.propGrid.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.propGrid.DefaultEditors.AddRange(new DevExpress.XtraVerticalGrid.Rows.DefaultEditor[] {
            new DevExpress.XtraVerticalGrid.Rows.DefaultEditor(null, this.repositoryItemTextEdit1)});
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.propGrid.Location = new System.Drawing.Point(0, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.propGrid.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCaption,
            this.categoryLocation,
            this.categorySize,
            this.categoryMenuItems});
            this.propGrid.Size = new System.Drawing.Size(295, 192);
            this.propGrid.TabIndex = 1;
            // 
            // rowCaption
            // 
            this.rowCaption.Height = 16;
            this.rowCaption.IsChildRowsLoaded = true;
            this.rowCaption.Name = "rowCaption";
            this.rowCaption.Properties.Caption = "Caption";
            this.rowCaption.Properties.FieldName = "Caption";
            this.rowCaption.Properties.ReadOnly = false;
            // 
            // categoryLocation
            // 
            this.categoryLocation.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowX,
            this.rowY});
            this.categoryLocation.Name = "categoryLocation";
            this.categoryLocation.Properties.Caption = "Location";
            // 
            // rowX
            // 
            this.rowX.Height = 16;
            this.rowX.IsChildRowsLoaded = true;
            this.rowX.Name = "rowX";
            this.rowX.Properties.Caption = "X";
            this.rowX.Properties.FieldName = "X";
            this.rowX.Properties.ReadOnly = false;
            // 
            // rowY
            // 
            this.rowY.IsChildRowsLoaded = true;
            this.rowY.Name = "rowY";
            this.rowY.Properties.Caption = "Y";
            this.rowY.Properties.FieldName = "Y";
            this.rowY.Properties.ReadOnly = false;
            // 
            // categorySize
            // 
            this.categorySize.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowWidth,
            this.rowHeight});
            this.categorySize.Name = "categorySize";
            this.categorySize.Properties.Caption = "Size";
            // 
            // rowWidth
            // 
            this.rowWidth.IsChildRowsLoaded = true;
            this.rowWidth.Name = "rowWidth";
            this.rowWidth.Properties.Caption = "Width";
            this.rowWidth.Properties.FieldName = "Width";
            // 
            // rowHeight
            // 
            this.rowHeight.Height = 16;
            this.rowHeight.IsChildRowsLoaded = true;
            this.rowHeight.Name = "rowHeight";
            this.rowHeight.Properties.Caption = "Height";
            this.rowHeight.Properties.FieldName = "Height";
            // 
            // categoryMenuItems
            // 
            this.categoryMenuItems.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowMenuItems});
            this.categoryMenuItems.Name = "categoryMenuItems";
            this.categoryMenuItems.Properties.Caption = "Menu Items";
            // 
            // rowMenuItems
            // 
            this.rowMenuItems.Name = "rowMenuItems";
            this.rowMenuItems.Properties.Caption = "Items";
            this.rowMenuItems.Properties.FieldName = "MenuItems";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(215, 297);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // BOk
            // 
            this.BOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BOk.Location = new System.Drawing.Point(134, 297);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(75, 23);
            this.BOk.TabIndex = 3;
            this.BOk.Text = "Ok";
            this.BOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // PropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 326);
            this.ControlBox = false;
            this.Controls.Add(this.BOk);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.propGrid);
            this.MinimumSize = new System.Drawing.Size(311, 300);
            this.Name = "PropertyGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowCaption;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.SimpleButton BOk;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propGrid;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowY;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowX;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryLocation;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categorySize;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowWidth;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowHeight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryMenuItems;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowMenuItems;

    }
}