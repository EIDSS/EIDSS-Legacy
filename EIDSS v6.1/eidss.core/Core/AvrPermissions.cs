using bv.common.Core;
using eidss.model.Enums;

namespace eidss.model.Core
{
    public class AvrPermissions
    {
        public static bool InsertPermission
        {
            get
            {
                return UpdatePermission &&
                       EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.AVRReport));
            }
        }

        public static bool UpdatePermission
        {
            get
            {
                return
                    EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSSPermissionObject.AVRReport));
            }
        }

        public static bool DeletePermission
        {
            get
            {
                return UpdatePermission &&
                       EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSSPermissionObject.AVRReport));
            }
        }

        public static bool AccessToAVRAdministrationPermission
        {
            get { return EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessToAVRAdministration)); }
        }
    }
}