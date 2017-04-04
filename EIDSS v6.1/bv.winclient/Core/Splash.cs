using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Layout;

namespace bv.winclient.Core
{
	public class Splash : BvForm
	{
		
		private static Splash m_Splash;
        private Panel panel1;
        internal DevExpress.XtraEditors.LabelControl lbVersion;
        internal DevExpress.XtraEditors.LabelControl lbVersionNumber;
		private static readonly object m_SyncObject = new object();
		#region  Windows Form Designer generated code
		
		public Splash()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
            this.HelpTopicId = Help2.HomePage;
			//Text = GlobalSettings.AppCaption
			lbVersionNumber.Text = Application.ProductVersion;
            lbCopyright.Text = BvMessages.Get("msgEIDSSCopyright");
			//Add any initialization after the InitializeComponent() call
			LayoutCorrector.ApplySystemFont(this);
		    if (Localizer.IsRtl)
		    {
		        var l = lbVersionNumber.Left + lbVersionNumber.Width;
		        lbVersionNumber.Left = lbVersion.Left;
		        lbVersion.Left = l - lbVersion.Width;
		    }
		}
		
		//Form overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
        }

        private DevExpress.XtraEditors.LabelControl lblRepMsg;
        internal System.Windows.Forms.Timer Timer1;
		internal DevExpress.XtraEditors.LabelControl lbCopyright;
		internal DevExpress.XtraEditors.MarqueeProgressBarControl MarqueeProgressBarControl1;
        private System.ComponentModel.IContainer components = null;

        //Required by the Windows Form Designer
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.lblRepMsg = new DevExpress.XtraEditors.LabelControl();
            this.Timer1 = new System.Windows.Forms.Timer();
            this.lbCopyright = new DevExpress.XtraEditors.LabelControl();
            this.MarqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbVersion = new DevExpress.XtraEditors.LabelControl();
            this.lbVersionNumber = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.MarqueeProgressBarControl1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRepMsg
            // 
            this.lblRepMsg.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblRepMsg.Appearance.Font")));
            this.lblRepMsg.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblRepMsg.Appearance.ForeColor")));
            this.lblRepMsg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblRepMsg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            resources.ApplyResources(this.lblRepMsg, "lblRepMsg");
            this.lblRepMsg.Name = "lblRepMsg";
            // 
            // Timer1
            // 
            this.Timer1.Interval = 5;
            // 
            // lbCopyright
            // 
            this.lbCopyright.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbCopyright.Appearance.Font")));
            this.lbCopyright.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbCopyright.Appearance.ForeColor")));
            this.lbCopyright.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbCopyright.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            resources.ApplyResources(this.lbCopyright, "lbCopyright");
            this.lbCopyright.Name = "lbCopyright";
            // 
            // MarqueeProgressBarControl1
            // 
            resources.ApplyResources(this.MarqueeProgressBarControl1, "MarqueeProgressBarControl1");
            this.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1";
            this.MarqueeProgressBarControl1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MarqueeProgressBarControl1.Properties.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(10)))));
            this.MarqueeProgressBarControl1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.MarqueeProgressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MarqueeProgressBarControl1.Properties.MarqueeAnimationSpeed = 50;
            this.MarqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong;
            this.MarqueeProgressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.MarqueeProgressBarControl1.Properties.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(10)))));
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.MarqueeProgressBarControl1);
            this.panel1.Controls.Add(this.lbCopyright);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.lblRepMsg);
            this.panel1.Controls.Add(this.lbVersionNumber);
            this.panel1.Name = "panel1";
            // 
            // lbVersion
            // 
            this.lbVersion.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbVersion.Appearance.Font")));
            this.lbVersion.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbVersion.Appearance.ForeColor")));
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.Name = "lbVersion";
            // 
            // lbVersionNumber
            // 
            this.lbVersionNumber.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbVersionNumber.Appearance.Font")));
            this.lbVersionNumber.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbVersionNumber.Appearance.ForeColor")));
            resources.ApplyResources(this.lbVersionNumber, "lbVersionNumber");
            this.lbVersionNumber.Name = "lbVersionNumber";
            // 
            // Splash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Click += new System.EventHandler(this.Splash_Click);
            ((System.ComponentModel.ISupportInitialize)(this.MarqueeProgressBarControl1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		
		#endregion
		
		public static void ShowSplash(bool reportMsg = false)
		{
		    if (BaseSettings.DoNotShowSplash)
		        return;
			lock(m_SyncObject)
			{
				Instance.lblRepMsg.Visible = reportMsg;
				Instance.TopMost = true;
				Instance.Show();
			}
			Application.DoEvents();
		}
		
		public static void HideSplash()
		{
            if (BaseSettings.DoNotShowSplash)
                return;
            if (m_Splash == null)
			{
				return;
			}
		    if (m_Splash.InvokeRequired)
		    {
		        CloseDelegate hideMethod = m_Splash.HideSplashHandle;
		        m_Splash.Invoke(hideMethod);
		    }
		    else
		        m_Splash.HideSplashHandle();

		}
        private void HideSplashHandle()
        {
			if (m_Splash == null)
			{
				return;
			}
			lock(m_SyncObject)
			{
				Instance.Activate();
				Instance.TopMost = false;
				Instance.Hide();
			}
        }
		
		public static void CloseSplash()
		{
            if (BaseSettings.DoNotShowSplash)
                return;
            if (m_Splash == null)
			{
				return;
			}
			lock(m_SyncObject)
			{
				Splash s = Instance;
				m_Splash = null;
				CloseDelegate closeDelegate = s.Close;
				s.BeginInvoke(closeDelegate);
				//s.Dispose()
			}
			Application.DoEvents();
		}
		delegate void CloseDelegate();
		
		public static void SetTopmost(bool topmost)
		{
            if (BaseSettings.DoNotShowSplash)
                return;
            if (m_Splash == null)
			{
				return;
			}
			lock(m_SyncObject)
			{
				Instance.TopMost = topmost;
			}
		}
		
		private static Splash Instance
		{
			get
			{
				lock(m_SyncObject)
				{
					if (m_Splash == null || m_Splash.IsDisposed)
					{
					    m_Splash = new Splash {AllowFormSkin = true, DoubleBuffered = true};
					}
				}
				return m_Splash;
			}
		}
		
		private void Splash_Click(object sender, System.EventArgs e)
		{
			HideSplash();
		}
		
		//Private Sub Splash_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
		//    If Visible Then
		//        Me.ProgressBar.Position = ProgressBar.Properties.Minimum
		//        Timer1.Start()
		//    Else
		//        Timer1.Stop()
		//    End If
		//End Sub
		
		//Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
		//    ProgressBar.Position += CInt(ProgressBar.Properties.Maximum / 10)
		//    If ProgressBar.Position >= ProgressBar.Properties.Maximum Then
		//        ProgressBar.Position = ProgressBar.Properties.Minimum
		//    End If
		//End Sub
	}
	
}
