using System.Windows.Forms;
using eidss.gis.Properties;

namespace eidss.gis.Forms
{
    partial class CustomizeMapForm
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
            DotSpatial.Projections.ProjectionInfo projectionInfo1 = new DotSpatial.Projections.ProjectionInfo();
            DotSpatial.Projections.GeographicInfo geographicInfo1 = new DotSpatial.Projections.GeographicInfo();
            DotSpatial.Projections.Datum datum1 = new DotSpatial.Projections.Datum();
            DotSpatial.Projections.Spheroid spheroid1 = new DotSpatial.Projections.Spheroid();
            DotSpatial.Projections.Meridian meridian1 = new DotSpatial.Projections.Meridian();
            DotSpatial.Projections.AngularUnit angularUnit1 = new DotSpatial.Projections.AngularUnit();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeMapForm));
            DotSpatial.Projections.LinearUnit linearUnit1 = new DotSpatial.Projections.LinearUnit();
            this.mapControl = new eidss.gis.Forms.EidssMapControl();
            this.SuspendLayout();
            // 
            // mapControl
            // 
            this.mapControl.CoordinateBarStyle = GIS_V4.Tools.CoordBar.CoordBarStyleEnum.CbsDecDegres;
            this.mapControl.CoordinateBarVisible = true;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.LegendTitle = null;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            projectionInfo1.Authority = null;
            projectionInfo1.AuxiliarySphereType = DotSpatial.Projections.AuxiliarySphereType.NotSpecified;
            projectionInfo1.CentralMeridian = null;
            projectionInfo1.EpsgCode = 0;
            projectionInfo1.FalseEasting = null;
            projectionInfo1.FalseNorthing = null;
            projectionInfo1.Geoc = false;
            datum1.DatumType = DotSpatial.Projections.DatumType.WGS84;
            datum1.Description = "WGS 1984";
            datum1.NadGrids = null;
            datum1.Name = "D_WGS_1984";
            spheroid1.Code = "WE";
            spheroid1.EquatorialRadius = 6378137D;
            spheroid1.KnownEllipsoid = DotSpatial.Projections.Proj4Ellipsoid.WGS_1984;
            spheroid1.Name = "WGS_1984";
            spheroid1.PolarRadius = 6356752.3142451793D;
            datum1.Spheroid = spheroid1;
            datum1.ToWGS84 = new double[] {
        0D,
        0D,
        0D};
            geographicInfo1.Datum = datum1;
            meridian1.Code = 0;
            meridian1.Longitude = 0D;
            meridian1.Name = "Greenwich";
            geographicInfo1.Meridian = meridian1;
            geographicInfo1.Name = "GCS_WGS_1984";
            angularUnit1.Name = "Degree";
            angularUnit1.Radians = 0.017453292519943295D;
            geographicInfo1.Unit = angularUnit1;
            projectionInfo1.GeographicInfo = geographicInfo1;
            projectionInfo1.IsGeocentric = false;
            projectionInfo1.IsLatLon = true;
            projectionInfo1.IsSouth = false;
            projectionInfo1.LatitudeOfOrigin = null;
            projectionInfo1.Name = null;
            projectionInfo1.NoDefs = true;
            projectionInfo1.Over = false;
            //projectionInfo1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("projectionInfo1.Parameters")));
            projectionInfo1.ScaleFactor = 1D;
            projectionInfo1.StandardParallel1 = null;
            projectionInfo1.StandardParallel2 = null;
            //projectionInfo1.Transform = longLat1;
            linearUnit1.Meters = 1D;
            linearUnit1.Name = "Meter";
            projectionInfo1.Unit = linearUnit1;
            projectionInfo1.Zone = null;
            this.mapControl.MapSpatRef = projectionInfo1;
            this.mapControl.MapTitle = null;
            this.mapControl.MinimumSize = new System.Drawing.Size(300, 200);
            this.mapControl.Name = "mapControl";
            this.mapControl.ScaleBarVisible = true;
            this.mapControl.Size = new System.Drawing.Size(665, 430);
            this.mapControl.TabIndex = 0;
            // 
            // CustomizeMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.mapControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomizeMapForm";
            this.Text = Resources.gis_CustomizeMapForm_Caption;
            this.ResumeLayout(false);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        #endregion

        public EidssMapControl mapControl;
        
    }
}