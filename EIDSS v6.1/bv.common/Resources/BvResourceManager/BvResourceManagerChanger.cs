using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace bv.common.Resources
{
    [DesignerSerializer(typeof(BvResourceManagerSerializer), typeof(CodeDomSerializer))]
    public partial class BvResourceManagerChanger : Component
    {
        public static void GetResourceManager(Type type, out ComponentResourceManager manager)
        {
            manager = new BvResourceManager(type);
        }
    }
}
