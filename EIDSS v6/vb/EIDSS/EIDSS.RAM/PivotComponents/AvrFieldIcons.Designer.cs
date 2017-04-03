namespace eidss.avr.PivotComponents
{
    partial class AvrFieldIcons
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvrFieldIcons));
            this.m_InternalImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // Form Is Localizable: False
            // 
            // m_InternalImageList
            // 
            this.m_InternalImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_InternalImageList.ImageStream")));
            this.m_InternalImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_InternalImageList.Images.SetKeyName(0, "String4.png");
            this.m_InternalImageList.Images.SetKeyName(1, "numeric.png");
            this.m_InternalImageList.Images.SetKeyName(2, "date.png");
            this.m_InternalImageList.Images.SetKeyName(3, "Boolean2.png");
            this.m_InternalImageList.Images.SetKeyName(4, "String4_bordered.png");
            this.m_InternalImageList.Images.SetKeyName(5, "numeric_bordered.png");
            this.m_InternalImageList.Images.SetKeyName(6, "date_bordered.png");
            this.m_InternalImageList.Images.SetKeyName(7, "Boolean2_bordered.png");
            // 
            // AvrFieldIcons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AvrFieldIcons";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList m_InternalImageList;
    }
}