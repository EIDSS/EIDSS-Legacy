using System;
using System.Drawing;
using eidss.gis.Data.Providers;
using GIS_V4.Utils;
using SharpMap.Data.Providers;
using SharpMap.Geometries;
using SharpMap.Rendering;
using SharpMap.Styles;
using eidss.gis.Properties;

namespace eidss.gis.Layers
{
    public class EidssSystemDbLayer : EidssDbLayer
    {
        private void InitLabelLayer()
        {
            var eidssLabelLayer = new EidssSystemLabelLayer("LabelsFor" + Guid);
            eidssLabelLayer.DataSource = DataSource;
            
            //set style
            eidssLabelLayer.Style = new LabelStyle();
            eidssLabelLayer.LabelFilter = LabelCollisionDetection.ThoroughCollisionDetection;
            //GeometryType2 geomType = LayerUtils.GetLayerType(this);
            //if (geomType == GeometryType2.Polygon || geomType == GeometryType2.MultiPolygon)
            //eidssLabelLayer.MultipartGeometryBehaviour =
            //        SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
            eidssLabelLayer.Style.CollisionDetection = true;
            eidssLabelLayer.Style.Offset = new PointF(5, -5);
            eidssLabelLayer.Style.CollisionBuffer = new SizeF(3, 3);
            eidssLabelLayer.Style.HorizontalAlignment = LabelStyle.HorizontalAlignmentEnum.Left;
            eidssLabelLayer.Style.ForeColor = Color.Black;
            eidssLabelLayer.Style.Font = new Font("Arial",12);
            eidssLabelLayer.Style.Halo = new Pen(Color.White, 2);

            //eidssLabelLayer.LabelColumn = "idfsGeoObject";
            eidssLabelLayer.Enabled = false;
            

            LabelLayer = eidssLabelLayer;
        }

        public EidssSystemDbLayer(string layerName)
            : base(layerName)
        {
            InitLabelLayer();
            //InitDefaultStyle????
        }


        public EidssSystemDbLayer(string layerName, Guid initGuid)
            : base(layerName, initGuid)
        {
            InitLabelLayer();
            //InitDefaultStyle(); NOT NEED!
        }

        public EidssSystemDbLayer(string layerName, Guid initGuid, Guid labelLayerGuid)
            : base(layerName, initGuid, labelLayerGuid)
        {
            //InitLabelLayer(); NOT NEED!
            //InitDefaultStyle(); NOT NEED!
        }


        override public IProvider DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                //check data table name
                bool isSystemLayer = SystemLayerNames.IsSystemLayerName(((EidssSqlServer2008) base.DataSource).Table);
                if (!isSystemLayer)
                    throw new Exception(Resources.gis_EidssSystemDbLayer_DataSourceException);
                if (!(m_LabelLayer == null && LabelLayerGuid != Guid.Empty))
                LabelLayer.DataSource = DataSource;
            }
        }

    }
}
