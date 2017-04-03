using System.Windows.Forms;
using bv.common.Resources;
using bv.winclient.Layout;

namespace bv.winclient.Core
{
	public class Splash : DevExpress.XtraEditors.XtraForm
	{
		
		private static Splash m_Splash = null;
		private static readonly object m_SyncObject = new object();
		#region  Windows Form Designer generated code
		
		public Splash()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			//Text = GlobalSettings.AppCaption
			lbVersionNumber.Text = Application.ProductVersion;
            lbCopyright.Text = BvMessages.Get("msgEIDSSCopyright");
			//Add any initialization after the InitializeComponent() call
			LayoutCorrector.ApplySystemFont(this);
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
		internal DevExpress.XtraEditors.LabelControl lblRepMsg;
		internal System.Windows.Forms.Timer Timer1;
		internal DevExpress.XtraEditors.LabelControl lbVersion;
		internal DevExpress.XtraEditors.LabelControl lbVersionNumber;
		internal DevExpress.XtraEditors.LabelControl lbCopyright;
		internal DevExpress.XtraEditors.MarqueeProgressBarControl MarqueeProgressBarControl1;
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			base.Click += new System.EventHandler(Splash_Click);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
			this.lblRepMsg = new DevExpress.XtraEditors.LabelControl();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbVersion = new DevExpress.XtraEditors.LabelControl();
			this.lbVersionNumber = new DevExpress.XtraEditors.LabelControl();
			this.lbCopyright = new DevExpress.XtraEditors.LabelControl();
			this.MarqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
			((System.ComponentModel.ISupportInitialize) this.MarqueeProgressBarControl1.Properties).BeginInit();
			this.SuspendLayout();
			//
			//lblRepMsg
			//
			this.lblRepMsg.Appearance.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
			this.lblRepMsg.Appearance.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (26)), System.Convert.ToInt32((byte) (26)), System.Convert.ToInt32((byte) (26)));
			this.lblRepMsg.Appearance.Options.UseFont = true;
			this.lblRepMsg.Appearance.Options.UseForeColor = true;
			this.lblRepMsg.Appearance.Options.UseTextOptions = true;
			this.lblRepMsg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lblRepMsg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
			resources.ApplyResources(this.lblRepMsg, "lblRepMsg");
			this.lblRepMsg.Name = "lblRepMsg";
			//
			//Timer1
			//
			this.Timer1.Interval = 5;
			//
			//lbVersion
			//
			this.lbVersion.Appearance.Font = new System.Drawing.Font("Arial", 10.0F);
			this.lbVersion.Appearance.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (0)), System.Convert.ToInt32((byte) (27)), System.Convert.ToInt32((byte) (95)));
			this.lbVersion.Appearance.Options.UseFont = true;
			this.lbVersion.Appearance.Options.UseForeColor = true;
			resources.ApplyResources(this.lbVersion, "lbVersion");
			this.lbVersion.Name = "lbVersion";
			//
			//lbVersionNumber
			//
			this.lbVersionNumber.Appearance.Font = new System.Drawing.Font("Arial", 10.0F);
			this.lbVersionNumber.Appearance.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (0)), System.Convert.ToInt32((byte) (27)), System.Convert.ToInt32((byte) (95)));
			this.lbVersionNumber.Appearance.Options.UseFont = true;
			this.lbVersionNumber.Appearance.Options.UseForeColor = true;
			resources.ApplyResources(this.lbVersionNumber, "lbVersionNumber");
			this.lbVersionNumber.Name = "lbVersionNumber";
			//
			//lbCopyright
			//
			this.lbCopyright.Appearance.Font = new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
			this.lbCopyright.Appearance.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (236)), System.Convert.ToInt32((byte) (236)), System.Convert.ToInt32((byte) (236)));
			this.lbCopyright.Appearance.Options.UseFont = true;
			this.lbCopyright.Appearance.Options.UseForeColor = true;
			this.lbCopyright.Appearance.Options.UseTextOptions = true;
			this.lbCopyright.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lbCopyright.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
			resources.ApplyResources(this.lbCopyright, "lbCopyright");
			this.lbCopyright.Name = "lbCopyright";
			//
			//MarqueeProgressBarControl1
			//
			resources.ApplyResources(this.MarqueeProgressBarControl1, "MarqueeProgressBarControl1");
			this.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1";
			this.MarqueeProgressBarControl1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.MarqueeProgressBarControl1.Properties.EndColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (0)), System.Convert.ToInt32((byte) (145)), System.Convert.ToInt32((byte) (10)));
			this.MarqueeProgressBarControl1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
			this.MarqueeProgressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.MarqueeProgressBarControl1.Properties.MarqueeAnimationSpeed = 50;
			this.MarqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong;
			this.MarqueeProgressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
			this.MarqueeProgressBarControl1.Properties.StartColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (0)), System.Convert.ToInt32((byte) (145)), System.Convert.ToInt32((byte) (10)));
			//
			//Splash
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.None;
			this.BackgroundImageStore = (System.Drawing.Image) (resources.GetObject("$this.BackgroundImageStore"));
			resources.ApplyResources(this, "$this");
			this.ControlBox = false;
			this.Controls.Add(this.MarqueeProgressBarControl1);
			this.Controls.Add(this.lbCopyright);
			this.Controls.Add(this.lbVersionNumber);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.lblRepMsg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Splash";
			this.ShowInTaskbar = false;
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize) this.MarqueeProgressBarControl1.Properties).EndInit();
			this.ResumeLayout(false);
			
		}
		
		#endregion
		
		public static void ShowSplash(bool reportMsg = false)
		{
			
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
					if (m_Splash == null)
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
