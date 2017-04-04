using System.Collections.Generic;
using System.Data;
using BLToolkit.Data;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core.CultureInfo;

namespace eidss.model.Core
{
    public static class LanguageDbLoader
    {
        public static IList<string> GetLanguages()
        {
            var result = new List<string>();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager commandLookup = manager.SetSpCommand("spAsLanguageSelectLookup",
                    manager.Parameter("strLanguage", ModelUserContext.CurrentLanguage));
                DataTable supportedLanguagesTable = commandLookup.ExecuteDataTable();

                foreach (string lang in Localizer.AllSupportedLanguages.Keys)
                {
                    DbManager command = manager.SetCommand("select [dbo].[fnGetLanguageCode](@languageCode)",
                        manager.Parameter("languageCode", lang));
                    var langId = command.ExecuteScalar<long>();
                    if (supportedLanguagesTable.Select("idfsReference = " + langId).Length > 0)
                    {
                        result.Add(lang);
                    }
                }
            }
            return result;
        }
    }
}