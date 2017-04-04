namespace bv.winclient.BasePanel
{
    partial class BaseGridPanel<T>
    {
       

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.m_ListGridControl = new bv.winclient.BasePanel.ListPanelComponents.BaseListGridControl();
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            this.m_ListGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ListGridControl.Location = new System.Drawing.Point(0, 0);
            this.m_ListGridControl.Name = "m_ListGridControl";
            this.m_ListGridControl.Size = new System.Drawing.Size(504, 297);
            this.m_ListGridControl.TabIndex = 0;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ListGridControl);
            
            this.Name = "BaseListPanel";
            this.ResumeLayout(false);
        }

        #endregion

        protected winclient.BasePanel.ListPanelComponents.BaseListGridControl m_ListGridControl;
    }
}
