using System;
using System.Drawing;
using eidss.gis.Data;
using eidss.gis.Data.Providers;
using GIS_V4.Serializers.LayerSerializers;
using GIS_V4.Utils;
using SharpMap.Data.Providers;
using SharpMap.Geometries;
using SharpMap.Rendering;
using SharpMap.Styles;
using eidss.gis.Properties;

namespace eidss.gis.Layers
{
    public class EidssUserDbLayer : EidssDbLayer
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
            eidssLabelLayer.Style.Font = new Font("Arial", 10);
            eidssLabelLayer.Style.Halo = new Pen(Color.White, 2);
            eidssLabelLayer.Enabled = false;


            LabelLayer = eidssLabelLayer;
        }

        private Guid m_LayerBbGuid;
        private bool m_SelfInit;

        public Guid LayerDbGuid
        {
            get { return m_LayerBbGuid; }
            private set
            {
                m_LayerBbGuid = value;

                m_SelfInit = true;
                DataSource = new EidssSqlServer2008(UserDbLayersManager.GisDbShema + "." + UserDbLayersManager.UserTablePrefix + LayerDbGuid.ToString("N"));
                m_SelfInit = false;

                if (!(m_LabelLayer == null && LabelLayerGuid != Guid.Empty))
                    LabelLayer.DataSource = DataSource;
            }
        }

        public EidssUserDbLayer(Guid layerDbGuid, string layerName)
            : base(layerName)
        {
            LayerDbGuid = layerDbGuid;
            InitLabelLayer();
        }
        
        public EidssUserDbLayer(Guid layerDbGuid, string layerName, Guid initGuid)
            : base(layerName, initGuid)
        {
            LayerDbGuid = layerDbGuid;
            InitLabelLayer();
        }

        public EidssUserDbLayer(Guid layerDbGuid, string layerName, Guid initGuid, Guid labelLayerGuid)
            : base(layerName, initGuid, labelLayerGuid)
        {
            LayerDbGuid = layerDbGuid;
        }
        
        override public IProvider DataSource
        {
            get { return base.DataSource; }
            set
            {
                if(m_SelfInit)
                    base.DataSource = value;
                else
                    throw new Exception(Resources.gis_EidssUserDbLayer_DataSourceException);
            }
        }
     
    }
}
