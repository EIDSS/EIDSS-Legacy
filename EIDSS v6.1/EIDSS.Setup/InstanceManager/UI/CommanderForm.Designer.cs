namespace InstanceManager.UI
{
  partial class CommanderForm
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
      this.InstallButton = new System.Windows.Forms.Button();
      this.UpgradeButton = new System.Windows.Forms.Button();
      this.ManageButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // InstallButton
      // 
      this.InstallButton.Location = new System.Drawing.Point(94, 16);
      this.InstallButton.Name = "InstallButton";
      this.InstallButton.Size = new System.Drawing.Size(166, 23);
      this.InstallButton.TabIndex = 0;
      this.InstallButton.Text = "&Install New Instance";
      this.InstallButton.UseVisualStyleBackColor = true;
      this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
      // 
      // UpgradeButton
      // 
      this.UpgradeButton.Location = new System.Drawing.Point(94, 59);
      this.UpgradeButton.Name = "UpgradeButton";
      this.UpgradeButton.Size = new System.Drawing.Size(166, 23);
      this.UpgradeButton.TabIndex = 1;
      this.UpgradeButton.Text = "&Upgrade Installed Instances";
      this.UpgradeButton.UseVisualStyleBackColor = true;
      this.UpgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
      // 
      // ManageButton
      // 
      this.ManageButton.Location = new System.Drawing.Point(94, 101);
      this.ManageButton.Name = "ManageButton";
      this.ManageButton.Size = new System.Drawing.Size(166, 23);
      this.ManageButton.TabIndex = 2;
      this.ManageButton.Text = "&Manage Installed Instances";
      this.ManageButton.UseVisualStyleBackColor = true;
      this.ManageButton.Click += new System.EventHandler(this.ManageButton_Click);
      // 
      // CommanderForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(354, 140);
      this.Controls.Add(this.ManageButton);
      this.Controls.Add(this.UpgradeButton);
      this.Controls.Add(this.InstallButton);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(370, 178);
      this.MinimumSize = new System.Drawing.Size(370, 178);
      this.Name = "CommanderForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Instance Manager";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button InstallButton;
    private System.Windows.Forms.Button UpgradeButton;
    private System.Windows.Forms.Button ManageButton;
  }
}

