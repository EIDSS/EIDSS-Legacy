using System;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public class LocationEventArgs : EventArgs
    {
        private readonly long? m_RegionId;
        private readonly long? m_RayonId;

        public LocationEventArgs(long? regionId, long? rayonId)
        {
            m_RegionId = regionId;
            m_RayonId = rayonId;
        }

        public long? RegionId
        {
            get { return m_RegionId; }
        }

        public long? RayonId
        {
            get { return m_RayonId; }
        }
    }
}