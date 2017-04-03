using System;
using System.Collections.Generic;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class BaseModel
    {
        public BaseModel()
        {
            CanWorkWithArchive = true;
        }

        public BaseModel(string language, bool useArchive)
        {
            Utils.CheckNotNullOrEmpty(language, "lang");

            Language = language;
            UseArchive = useArchive;

            CanWorkWithArchive = true;
        }

        public BaseModel(string language, string exportFormat, bool useArchive, bool isOpenInNewWindow)
        {
            Utils.CheckNotNullOrEmpty(language, "lang");
            Utils.CheckNotNullOrEmpty(exportFormat, "exportFormat");

            Language = language;
            ExportFormat = exportFormat;
            UseArchive = useArchive;
            IsOpenInNewWindow = isOpenInNewWindow;
        }

        [LocalizedDisplayName("PreferredLanguage")]
        public string Language { get; set; }

        [LocalizedDisplayName("ExportTo")]
        public string ExportFormat { get; set; }

        public ReportExportType ExportFormatEnum
        {
            get
            {
                ReportExportType result;
                if (!Enum.TryParse(ExportFormat, out result))
                {
                    result = ReportExportType.Pdf;
                }
                return result;
            }
        }

        [LocalizedDisplayName("UseArchive")]
        public bool UseArchive { get; set; }

        public bool IsOpenInNewWindow { get; set; }

        public List<PersonalDataGroup> ForbiddenGroups { get; set; }

        public long? OrganizationId { get; set; }

        public bool CanWorkWithArchive { get; set; }

        public bool ShowUseArchiveDataCheckbox
        {
            get
            {
                bool hasPermission =
                    EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReadArchivedData));
                var credentials = new ConnectionCredentials(null, "Archive");

                return CanWorkWithArchive &&
                       !ModelUserContext.Instance.IsArchiveMode &&
                       hasPermission &&
                       credentials.IsCorrect;
            }
        }

        protected string CurrentCultureName
        {
            get
            {
                string cultureName = Localizer.SupportedLanguages.ContainsKey(Language)
                                         ? Localizer.SupportedLanguages[Language]
                                         : "en-US";
                return cultureName;
            }
        }

        public List<SelectListItemSurrogate> SupportedLanguages
        {
            get { return FilterHelper.GetSupportedLanguages(); }
        }

        public List<SelectListItemSurrogate> SupportedExportFormats
        {
            get { return FilterHelper.GetExportFormats(); }
        }

        public override string ToString()
        {
            return string.Format("Language:{0}, Format:{1}, UseArchive:{2}", Language, ExportFormatEnum, UseArchive);
        }
    }
}