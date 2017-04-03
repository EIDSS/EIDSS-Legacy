using System.Xml;
using GIS_V4.Serializers;
using GIS_V4.Serializers.LayerSerializers;
using SharpMap;

namespace eidss.gis.Serializers
{
    public class EidssMapSerializer:MapSerializer
    {
        public new static EidssMapSerializer Instance = new EidssMapSerializer();

        protected override LayerSerializer DefaultLayerSerializer
        {
            get
            {
                return EidssLayerSerializer.Instance;
            }
        }

        //TODO[enikulin]: may be need serialize EIDSS version? need override Serialize method!
    }
}
