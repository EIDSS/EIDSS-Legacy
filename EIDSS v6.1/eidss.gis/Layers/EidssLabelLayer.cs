using System;
using DotSpatial.Projections;
using eidss.gis.Data.Providers;
using GIS_V4.Common;
using SharpMap.Data.Providers;
using eidss.gis.Properties;

namespace eidss.gis.Layers
{
        public class EidssLabelLayer : GIS_V4.Layers.LabelLayer
        {
            public override ICoordinateTransformation CoordinateTransformation
            {
                get
                {
                    return null; // CoordinateSystems.Wgs2SphericalMercator;
                }
                set
                {
                    //base.CoordinateTransformation = value;
                }
            }

            public EidssLabelLayer(string layername)
                : base(layername)
            {
                MaxScale = double.MaxValue;
                VisibleInTOC = false;
                MultipartGeometryBehaviour = MultipartGeometryBehaviourEnum.Largest;
            }

            public EidssLabelLayer(string layername, Guid initGuid)
                : this(layername)
            {
                _guid = initGuid;
            }

            override public IProvider DataSource
            {
                get { return base.DataSource; }
                set
                {
                    if (value!=null && !(value is EidssSqlServer2008))
                        throw new Exception(Resources.gis_EidssLabelLayer_DataSourceException);
                    base.DataSource = value;
                }
            }

        }
    
}
