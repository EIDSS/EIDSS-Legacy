using System;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class RBEModel : BaseYearQuarterModel
    {
        public RBEModel()
        {
            Init();
        }

        public RBEModel
            (string language, int year, bool firstQuarter, bool secondQuarter, bool thirdQuarter, bool fourthQuarter, string[] regions, string[] rayons, bool addSignature,
                bool useArchive)
            : base(language, year, firstQuarter, secondQuarter, thirdQuarter, fourthQuarter, useArchive)
        {
            Init(regions, rayons, addSignature);
        }

        private void Init(string[] regions = null, string[] rayons = null, bool addSignature = false)
        {
            Regions = regions ?? new string[0];
            Rayons = rayons ?? new string[0];
            AddSignature = addSignature;
            Address = new AddressMultiselectModel();
        }

        public string[] Regions { get; set; }

        public string[] Rayons { get; set; }

        public string QuarterList { get; set; }

        public string RegionList { get; set; }

        public string RayonList { get; set; }

        public bool AddSignature { get; set; }

//        public static explicit operator BaseIntervalModel(RBEModel model)
//        {
//            bv.common.Core.Utils.CheckNotNull(model, "model");
//            var result = new BaseIntervalModel
//            {
//                StartDate = model.StartDate1,
//                EndDate = model.EndDate1,
//                Language = model.Language,
//                ExportFormat = model.ExportFormat,
//                UseArchive = model.UseArchive,
//                IsOpenInNewWindow = model.IsOpenInNewWindow,
//                OrganizationId = model.OrganizationId,
//                ForbiddenGroups = model.ForbiddenGroups,
//            };
//
//            return result;
//        }

        public AddressMultiselectModel Address { get; set; }

        public static explicit operator RBESurrogateModel(RBEModel model)
        {
            var result = new RBESurrogateModel(
                model.Language
                , model.Year
                , model.Quarters
                , model.Regions
                , model.Rayons
                , model.AddSignature
                , model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}