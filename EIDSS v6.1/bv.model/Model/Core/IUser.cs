using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public interface IUser
    {
        bool HasPermission(string permission);
        string FullName { get; }
        string LoginName { get; }
        object ID { get; }
        string OrganizationEng { get; }
        object OrganizationID { get; }
        object EmployeeID { get; }
        
        void RevokeWritePermissions();
        void RestoreWritePermissions();
    }
}
