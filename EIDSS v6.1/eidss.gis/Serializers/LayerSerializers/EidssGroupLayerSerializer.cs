using GIS_V4.Serializers.LayerSerializers;

namespace eidss.gis.Serializers.LayerSerializers
{
    public class EidssLayerGroupSerializer : LayerGroupSerializer
    {
        public new static EidssLayerGroupSerializer Instance = new EidssLayerGroupSerializer();

        protected override LayerSerializer DefaultLayerSerializer
        {
            get
            {
                return EidssLayerSerializer.Instance;
            }
        }
    }
}
