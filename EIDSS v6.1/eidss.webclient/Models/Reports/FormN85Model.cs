using System;
using eidss.model.Reports.ARM;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class FormN85Model : BaseDateModel
    {
        public FormN85Model()
        {
            Address = new AddressModel();
        }

        public FormN85Model(long? regionId, long? rayonId)
        {
            Address = new AddressModel(regionId, rayonId);
        }

        public FormN85Model
            (string language,
                int year, int? month,
                long? regionId, long? rayonId,
                string userName,
                bool useArchive)
            : base(language, year, month, useArchive)

        {
            Address = new AddressModel(regionId, rayonId);
            UserName = userName;
        }

        public AddressModel Address { get; set; }

        public string UserName { get; set; }

        public override int MinYear
        {
            get { return 2010; }
        }

        public static explicit operator FormN85SurrogateModel(FormN85Model model)
        {
            AddressModel address = model.Address ?? new AddressModel();
            var result = new FormN85SurrogateModel(model.Language, model.Year, model.Month,
                address.RegionId, address.RayonId,
                address.RegionName, address.RayonName,
                model.UserName,
                model.OrganizationId, model.ForbiddenGroups,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}