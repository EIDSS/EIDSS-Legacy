namespace InstanceManager.UI
{
  partial class InstanceManagerForm
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
      this.UpgradeButton = new System.Windows.Forms.Button();
      this.MaintainButton = new System.Windows.Forms.Button();
      this.InstanceSelectorsBox = new System.Windows.Forms.GroupBox();
      this.SuspendLayout();
      // 
      // UpgradeButton
      // 
      this.UpgradeButton.Enabled = false;
      this.UpgradeButton.Location = new System.Drawing.Point(140, 125);
      this.UpgradeButton.Name = "UpgradeButton";
      this.UpgradeButton.Size = new System.Drawing.Size(75, 23);
      this.UpgradeButton.TabIndex = 1;
      this.UpgradeButton.Text = "&Upgrade";
      this.UpgradeButton.UseVisualStyleBackColor = true;
      this.UpgradeButton.Visible = false;
      this.UpgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
      // 
      // MaintainButton
      // 
      this.MaintainButton.Enabled = false;
      this.MaintainButton.Location = new System.Drawing.Point(140, 125);
      this.MaintainButton.Name = "MaintainButton";
      this.MaintainButton.Size = new System.Drawing.Size(75, 23);
      this.MaintainButton.TabIndex = 1;
      this.MaintainButton.Text = "&Maintain";
      this.MaintainButton.UseVisualStyleBackColor = true;
      this.MaintainButton.Visible = false;
      this.MaintainButton.Click += new System.EventHandler(this.MaintainButton_Click);
      // 
      // InstanceSelectorsBox
      // 
      this.InstanceSelectorsBox.Location = new System.Drawing.Point(10, 10);
      this.InstanceSelectorsBox.Name = "InstanceSelectorsBox";
      this.InstanceSelectorsBox.Size = new System.Drawing.Size(332, 100);
      this.InstanceSelectorsBox.TabIndex = 0;
      this.InstanceSelectorsBox.TabStop = false;
      // 
      // InstanceManagerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(354, 162);
      this.Controls.Add(this.InstanceSelectorsBox);
      this.Controls.Add(this.UpgradeButton);
      this.Controls.Add(this.MaintainButton);
      this.MaximizeBox = false;
      this.Name = "InstanceManagerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Instance Manager";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button UpgradeButton;
    private System.Windows.Forms.Button MaintainButton;
    private System.Windows.Forms.GroupBox InstanceSelectorsBox;
  }
}