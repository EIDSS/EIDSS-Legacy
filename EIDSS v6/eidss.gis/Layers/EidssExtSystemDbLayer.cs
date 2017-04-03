using System;
using System.Drawing;
using eidss.gis.Data.Providers;
using SharpMap.Data.Providers;
using SharpMap.Rendering;
using SharpMap.Styles;
using eidss.gis.Properties;

namespace eidss.gis.Layers
{
    public class EidssExtSystemDbLayer : EidssDbLayer
    {
        private void InitLabelLayer()
        {
            //Use simple label layer, because OtherTranslation table is empty!
            var eidssLabelLayer = new EidssLabelLayer("LabelsFor" + Guid);
            eidssLabelLayer.DataSource = DataSource;
            
            //set style
            eidssLabelLayer.Style = new LabelStyle();
            eidssLabelLayer.LabelFilter = LabelCollisionDetection.ThoroughCollisionDetection;
            //GeometryType2 geomType = LayerUtils.GetLayerType(this);
            //if (geomType == GeometryType2.Polygon || geomType == GeometryType2.MultiPolygon)
            eidssLabelLayer.MultipartGeometryBehaviour =
                    SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
            eidssLabelLayer.Style.CollisionDetection = true;
            eidssLabelLayer.Style.Offset = new PointF(5, -5);
            eidssLabelLayer.Style.CollisionBuffer = new SizeF(3, 3);
            eidssLabelLayer.Style.HorizontalAlignment = LabelStyle.HorizontalAlignmentEnum.Left;
            eidssLabelLayer.Style.ForeColor = Color.Black;
            eidssLabelLayer.Style.Font = new Font("Arial",10);
            eidssLabelLayer.Style.Halo = new Pen(Color.White, 2);
            eidssLabelLayer.Enabled = false;
            

            LabelLayer = eidssLabelLayer;
        }

        public EidssExtSystemDbLayer(string layerName)
            : base(layerName)
        {
            InitLabelLayer();
            //InitDefaultStyle????
        }


        public EidssExtSystemDbLayer(string layerName, Guid initGuid)
            : base(layerName, initGuid)
        {
            InitLabelLayer();
            //InitDefaultStyle(); NOT NEED!
        }

        public EidssExtSystemDbLayer(string layerName, Guid initGuid, Guid labelLayerGuid)
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
                bool isExtSystemLayer = ((EidssSqlServer2008)base.DataSource).Table.Contains("gisWKB");

                if (!isExtSystemLayer)
                    throw new Exception(Resources.gis_EidssExtSystemDbLayer_DataSourceError);
                if (!(m_LabelLayer == null && LabelLayerGuid != Guid.Empty))
                LabelLayer.DataSource = DataSource;
            }
        }

    }
}
