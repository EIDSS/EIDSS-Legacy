using System;

namespace eidss.model.Reports.Common
{
     [Serializable]
    public class LimContainerContentModel :BaseModel
    {
        public LimContainerContentModel(string language, long? containerId, long? freezerId, bool useArchive)
            : base(language, useArchive)
        {
            ContainerId = containerId;
            FreezerId = freezerId;
        }

        public long? ContainerId { get; set; }
        public long? FreezerId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, ContainerId={1} FreezerId={2}", base.ToString(), ContainerId, FreezerId);
        }

    }
}