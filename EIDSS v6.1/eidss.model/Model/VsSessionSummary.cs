using bv.model.BLToolkit;
using eidss.model.Helpers;

namespace eidss.model.Schema
{
    public partial class VsSessionSummary
    {
        
        

        /// <summary>
        /// 
        /// </summary>
        public partial class Accessor
        {
            public VsSessionSummary Create
                (
                DbManagerProxy manager
                , VsSession session
                , GeoLocation location
                )
            {
                var summary = (Instance(null)).CreateNewT(manager, session);
                LocationHelper.CopyLocation(session.Location, summary.Location);
                return summary;
            }
        }
    }
}