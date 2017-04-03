using System;
using DotSpatial.Projections;
using eidss.gis.Data.Providers;
using SharpMap.Data.Providers;
using eidss.gis.Properties;

namespace eidss.gis.Layers
{
    /// <summary>
    /// Base class for all EIDSS layers
    /// </summary>
    public abstract class EidssDbLayer:GIS_V4.Layers.VectorLayer
    {
        public EidssDbLayer(string layerName):base(layerName) {}

        public EidssDbLayer(string layerName, Guid initGuid):base (layerName, initGuid) {}

        public EidssDbLayer(string layerName, Guid initGuid, Guid labelLayerGuid):base (layerName, initGuid, labelLayerGuid) {}

        public override ICoordinateTransformation CoordinateTransformation
        {
            get
            {
                return null;// CoordinateSystems.Wgs2SphericalMercator;
            }
            set
            {
                //base.CoordinateTransformation = value;
            }
        }

        override public IProvider DataSource
        {
            get { return base.DataSource; }
            set
            {
                if (value != null && !(value is EidssSqlServer2008))
                    throw new Exception(Resources.gis_EidssDbLayer_DataSourceException);
                base.DataSource = value;
            }
        }

        /// <summary>
        /// Load default style from DB
        /// </summary>
        public void LoadDefaultStyle()
        {
            if (DataSource == null)
                throw new Exception(Resources.gis_EidssDbLayer_NULLDataProvider);
            //TODO
            //((EidssSqlServer2008) DataSource).ConnectionString;
        }
    }
}
