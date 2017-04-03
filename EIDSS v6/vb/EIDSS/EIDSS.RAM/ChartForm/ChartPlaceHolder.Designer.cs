using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;

namespace eidss.avr.ChartForm
{
    partial class ChartPlaceHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartPlaceHolder));
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.m_ChartControl = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.m_ChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ChartControl
            // 
            this.m_ChartControl.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.m_ChartControl, "m_ChartControl");
            this.m_ChartControl.Name = "m_ChartControl";
            this.m_ChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.m_ChartControl.SeriesTemplate.Label = pointSeriesLabel1;
            this.m_ChartControl.SeriesTemplate.View = areaSeriesView1;
            this.m_ChartControl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.m_ChartControl.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ChartControl_CustomDrawSeriesPoint);
            // 
            // ChartPlaceHolder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ChartControl);
            this.Name = "ChartPlaceHolder";
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ChartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl m_ChartControl;
    }
}
