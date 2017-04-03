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

            InitContextProperties();
        }

        public BaseModel(string language, bool useArchive) : this()
        {
            Utils.CheckNotNullOrEmpty(language, "lang");

            Language = language;
            UseArchive = useArchive;
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

        public bool IsOpenInNewWindow { get; set; }

        public List<PersonalDataGroup> ForbiddenGroups { get; set; }

        public long? OrganizationId { get; set; }

        public long? SiteId { get; set; }

        public long? UserId { get; set; }

        public ReportArchiveMode Mode
        {
            get
            {
                if (IsArchiveMode)
                {
                    return ReportArchiveMode.ArchiveOnly;
                }
                return UseArchive
                    ? ReportArchiveMode.ActualWithArchive
                    : ReportArchiveMode.ActualOnly;
            }
        }

        /// <summary>
        ///     is current report uses archive data
        /// </summary>
        [LocalizedDisplayName("UseArchive")]
        public bool UseArchive { get; set; }

        /// <summary>
        ///     Is current report running in archive mode
        /// </summary>
        public bool IsArchiveMode { get; set; }

        /// <summary>
        ///     can report, based on this model, work with archive (i.e. show actual and archived data)
        /// </summary>
        public bool CanWorkWithArchive { get; set; }

        /// <summary>
        ///     visibility of checkbox "use archive data"
        /// </summary>
        public bool ShowUseArchiveDataCheckbox
        {
            get
            {
                bool hasPermission = EidssUserContext.User != null &&
                                     EidssUserContext.User.HasPermission(
                                         PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReadArchivedData));
                var credentials = new ConnectionCredentials(null, "Archive");

                return CanWorkWithArchive &&
                       ModelUserContext.Instance != null &&
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

        public void InitContextProperties()
        {
            if (EidssSiteContext.Instance != null)
            {
                SiteId = EidssSiteContext.Instance.SiteID;
            }
            ModelUserContext model = ModelUserContext.Instance;
            if (model != null)
            {
                IsArchiveMode = model.IsArchiveMode;
            }

            EidssUser user = EidssUserContext.User;
            if (user != null)
            {
                if (user.OrganizationID != null)
                {
                    OrganizationId = Convert.ToInt64(user.OrganizationID);
                }
                if (user.ID != null)
                {
                    UserId = Convert.ToInt64(user.ID);
                }
                ForbiddenGroups = user.ForbiddenPersonalDataGroups ?? new List<PersonalDataGroup>();
            }
        }

        public override string ToString()
        {
            return string.Format("Language:{0}, Format:{1}, ArchiveMode:{2}, Organization:{3}, User:{4}",
                Language, ExportFormatEnum, Mode, OrganizationId, UserId);
        }
    }
}