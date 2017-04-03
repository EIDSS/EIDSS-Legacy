using System.ComponentModel;

namespace EIDSS.FlexibleForms.DesignerHosting
{
    sealed partial class DesignerHost
    {
        /// <summary>
        /// Required isDesignMode variable.
        /// </summary>
        private const IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DesignerHost
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(292, 271);
            this.Name = "DesignerHost";
            this.Text = "Form1"; 
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DesignerHost_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesignerHost_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

