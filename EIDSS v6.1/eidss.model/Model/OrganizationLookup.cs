
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using bv.model.Helpers;

namespace eidss.model.Schema
{
    public partial class OrganizationLookup
    {
        public static string OrganizationNational
        {
            get
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    if (EidssUserContext.User.OrganizationID != null)
                        return Accessor.Instance(null).SelectLookupList(manager, null, null).FirstOrDefault(c => c.idfInstitution == (long)EidssUserContext.User.OrganizationID, c => c.name);
                    return string.Empty;
                }
            }
        }
    }

}
