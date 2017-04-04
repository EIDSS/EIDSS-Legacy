using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Resources;

namespace eidss.model.WcfService
{
    public static class EidssServiceInitializer
    {
        public static void InitEidssCore()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);
            EidssUserContext.Init();

            Localizer.MenuMessages = EidssMenu.Instance;
            BaseFieldValidator.FieldCaptions = EidssFields.Instance;
        }
    }
}