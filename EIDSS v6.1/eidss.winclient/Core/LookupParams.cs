using eidss.model.Enums;

namespace eidss.winclient.Core
{
    public class LookupParams
    {
        public LookupParams(string aEditorName, string aLookupCacheName, EIDSSPermissionObject aPermission, object aDefaultId = null)
        {
            EditorName = aEditorName;
            Permission = aPermission;
            LookupCacheName = aLookupCacheName;
            DefaultId = aDefaultId;
        }
        public string EditorName;
        public EIDSSPermissionObject Permission;
        public string LookupCacheName;
        public object DefaultId;
    }
}