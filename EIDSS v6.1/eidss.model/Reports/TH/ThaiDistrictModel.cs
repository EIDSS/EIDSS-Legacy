using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class ThaiDistrictModel : BaseModel
    {
        private List<ThaiDistrictLookup> m_DistrictList;

        public ThaiDistrictModel()
        {
            InitProvinceDistrict();
        }

        public bool ShowSubDistricts { get; set; }
        public bool IsRequired { get; set; }
        public RegionLookup Province { get; set; }
        public ThaiDistrictLookup District { get; set; }

        [LocalizedDisplayName("idfsRegion")]
        public long? ProvinceId
        {
            get { return (Province != null) ? (long?) Province.idfsRegion : null; }
            set
            {
                Province = ProvinceList.Find(r => r.idfsRegion == value);
                District = null;
            }
        }

        public string ProvinceName
        {
            get { return Province != null ? Province.strRegionName : null; }
        }

        [LocalizedDisplayName("strDistrict")]
        public long? DistrictId
        {
            get { return District != null ? (long?) District.idfsDistrict : null; }
            set { District = m_DistrictList.Find(d => d.idfsDistrict == value); }
        }

        public string DistrictName
        {
            get { return District != null ? District.strDistrictName : null; }
        }

        public List<RegionLookup> ProvinceList { get; private set; }

        public List<ThaiDistrictLookup> DistrictList
        {
            get
            {
                return m_DistrictList != null
                    ? m_DistrictList.Where(
                        d => d.idfsProvince == ProvinceId && d.idfsParentDistrict == (ShowSubDistricts ? d.idfsParentDistrict : null))
                        .ToList()
                    : null;
            }
        }

        public List<SelectListItemSurrogate> GetDistricts()
        {
            var result = DistrictList.Select(district => new SelectListItemSurrogate
            {
                Text = district.strDistrictName,
                Value = (district.idfsDistrict > 0)
                    ? district.idfsDistrict.ToString()
                    : null,
                Selected = (district.idfsDistrict == DistrictId)
            }).ToList();
            if (!IsRequired)
            {
                FilterHelper.InsertEmptyItem(result);
            }
            return result;
        }

        public List<SelectListItemSurrogate> GetProvinces()
        {
            var result = ProvinceList.Select(province => new SelectListItemSurrogate
            {
                Text = province.strRegionName,
                Value = (province.idfsRegion > 0)
                    ? province.idfsRegion.ToString()
                    : null,
                Selected = (province.idfsRegion == ProvinceId)
            }).ToList();
            if (!IsRequired)
            {
                FilterHelper.InsertEmptyItem(result);
            }
            return result;
        }

        public void InitProvinceDistrict()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                ProvinceList = RegionLookup.Accessor.Instance(null).SelectList(manager, EidssSiteContext.Instance.CountryID, null);
                m_DistrictList = ThaiDistrictLookup.Accessor.Instance(null).SelectList(manager, null, null, null);
                Province = ProvinceList.Find(p => p.idfsRegion == EidssSiteContext.Instance.RegionID);
                var organization = Organization.Accessor.Instance(null)
                    .SelectDetail(manager, EidssSiteContext.Instance.OrganizationID) as Organization;
                long? defRayon = null;
                if (organization != null && organization.Address != null && organization.Address.Rayon != null)
                {
                    defRayon = organization.Address.Rayon.idfsRayon;
                }
                District = DistrictList.Find(
                    d =>
                        (d.idfsDistrict == defRayon && d.idfsParentDistrict == null) ||
                        (d.idfsParentDistrict != null && d.idfsParentDistrict == defRayon));
            }
        }
    }
}