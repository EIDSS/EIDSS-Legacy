namespace eidss.gis.Forms
{
    partial class SearchResult
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listSearchResults = new DevExpress.XtraEditors.ListBoxControl();
            this.moreButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.listSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // listSearchResults
            // 
            this.listSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSearchResults.Location = new System.Drawing.Point(3, 3);
            this.listSearchResults.Name = "listSearchResults";
            this.listSearchResults.Size = new System.Drawing.Size(215, 493);
            this.listSearchResults.TabIndex = 0;
            this.listSearchResults.SelectedIndexChanged += new System.EventHandler(this.listSearchResults_SelectedIndexChanged);
            this.listSearchResults.SelectedValueChanged += new System.EventHandler(this.listSearchResults_SelectedValueChanged);
            this.listSearchResults.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.listSearchResults_DrawItem);
            this.listSearchResults.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listSearchResults_MeasureItem);
            // 
            // moreButton
            // 
            this.moreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moreButton.Location = new System.Drawing.Point(143, 502);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(75, 23);
            this.moreButton.TabIndex = 1;
            this.moreButton.Text = "More";
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // SearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moreButton);
            this.Controls.Add(this.listSearchResults);
            this.Name = "SearchResult";
            this.Size = new System.Drawing.Size(221, 528);
            ((System.ComponentModel.ISupportInitialize)(this.listSearchResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listSearchResults;
        private DevExpress.XtraEditors.SimpleButton moreButton;
    }
}
