using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace EIDSS.RAM.Components
{
    public class RamPermissions
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
    }
}