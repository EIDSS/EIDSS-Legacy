using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;

namespace Eidss.Web
{
    public class BaseReferenceItem 
    {
        public long? Id  { get; set; }
        public string Name  { get; set; }

        public static BaseReferenceItem[] GetList(long type)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return BaseReference.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => c.idfsReferenceType == type && c.intRowStatus == 0)
                    .Select(
                    c => new BaseReferenceItem()
                    {
                        Id = c.idfsBaseReference,
                        Name = c.name
                    }
                    ).ToArray();
            }
        }
    }

    public class DiagnosisLookupItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string ICD10Code { get; set; }
        public bool IsAggregate { get; set; }

        public static DiagnosisLookupItem[] GetDiagnosisList(int code)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return DiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => (c.intHACode & code) != 0 && c.intRowStatus == 0)
                    .Select(
                        c => new DiagnosisLookupItem()
                             {
                                 Id = c.idfsDiagnosis,
                                 Name = c.name,
                                 ICD10Code = c.strIDC10,
                                 IsAggregate = c.idfsUsingType == (long)DiagnosisUsingTypeEnum.AggregatedCase
                             }
                    ).ToArray();
            }
        }
    }

    public class RegionLookupItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public static RegionLookupItem[] GetAll()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return RegionLookup.Accessor.Instance(null).SelectLookupList(manager, null, null)
                    .Where(c => c.intRowStatus == 0)
                    .Select(
                    c => new RegionLookupItem()
                    {
                        Id = c.idfsRegion,
                        Name = c.strRegionName
                    }
                    ).ToArray();
            }
        }
    }

    public class RayonLookupItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public static RayonLookupItem[] GetListByRegionId(long region)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return RayonLookup.Accessor.Instance(null).SelectLookupList(manager, region, null)
                    .Where(c => c.intRowStatus == 0)
                    .Select(
                    c => new RayonLookupItem()
                    {
                        Id = c.idfsRayon,
                        Name = c.strRayonName
                    }
                    ).ToArray();
            }
        }
    }

    public class BaseReferenceRaw
    {
        public long idfsBaseReference { get; set; }
        public long idfsReferenceType { get; set; }
        public int intHACode { get; set; }
        public string strDefault { get; set; }

        public static BaseReferenceRaw[] GetList(long[] types)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var list = new List<BaseReferenceRaw>();
                foreach (long type in types)
                {
                    if (type == 19000019) // Diagnosis
                    {
                        list.AddRange(
                            manager.SetCommand(@"
select idfsBaseReference, idfsReferenceType, intHACode, strDefault 
from trtBaseReference 
inner join trtDiagnosis
	on trtDiagnosis.idfsDiagnosis = trtBaseReference.idfsBaseReference
where trtBaseReference.intRowStatus = 0 and idfsReferenceType = @idfsReferenceType
and trtDiagnosis.idfsUsingType = 10020001"
                                , manager.Parameter("@idfsReferenceType", type))
                                .ExecuteList<BaseReferenceRaw>());
                    }
                    else
                    {
                        list.AddRange(
                            manager.SetCommand(@"
select idfsBaseReference, idfsReferenceType, intHACode, strDefault 
from trtBaseReference 
where intRowStatus = 0 and idfsReferenceType = @idfsReferenceType"
                                , manager.Parameter("@idfsReferenceType", type))
                                .ExecuteList<BaseReferenceRaw>());
                    }
                }
                return list.ToArray();
            }
        }
    }

    public class BaseReferenceTranslationRaw
    {
        public long idfsBaseReference { get; set; }
        public string strTranslation { get; set; }
        public string strLanguage { get; set; }

        public static BaseReferenceTranslationRaw[] GetList(long[] types, string[] langs)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var list = new List<BaseReferenceTranslationRaw>();
                foreach (string lang in langs)
                {
                    foreach (long type in types)
                    {
                        list.AddRange(manager.SetCommand(@"
select br.idfsBaseReference, bt.strTextString as strTranslation, @lang as strLanguage
from trtBaseReference br
inner join trtStringNameTranslation bt on bt.idfsBaseReference = br.idfsBaseReference
    and bt.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where br.intRowStatus = 0 and br.idfsReferenceType = @idfsReferenceType
"
                            , manager.Parameter("@idfsReferenceType", type), manager.Parameter("@lang", lang))
                                          .ExecuteList<BaseReferenceTranslationRaw>());
                    }
                }
                return list.ToArray();
            }
        }
    }

    public class GisBaseReferenceRaw
    {
        public long idfsBaseReference { get; set; }
        public long idfsReferenceType { get; set; }
        public long idfsCountry { get; set; }
        public long idfsRegion { get; set; }
        public long idfsRayon { get; set; }
        public string strDefault { get; set; }

        public static GisBaseReferenceRaw[] GetAll()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var list = new List<GisBaseReferenceRaw>();

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, b.idfsGISReferenceType as idfsReferenceType, 
c.idfsCountry as idfsCountry, 0 as idfsRegion, 0 as idfsRayon, b.strDefault as strDefault
from gisBaseReference b
inner join gisCountry c on c.idfsCountry = b.idfsGISBaseReference
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, b.idfsGISReferenceType as idfsReferenceType, 
c.idfsCountry as idfsCountry, c.idfsRegion as idfsRegion, 0 as idfsRayon, b.strDefault as strDefault
from gisBaseReference b
inner join gisRegion c on c.idfsRegion = b.idfsGISBaseReference
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, b.idfsGISReferenceType as idfsReferenceType, 
c.idfsCountry as idfsCountry, d.idfsRegion as idfsRegion, d.idfsRayon as idfsRayon, b.strDefault as strDefault
from gisBaseReference b
inner join gisRayon d on d.idfsRayon = b.idfsGISBaseReference
inner join gisRegion c on c.idfsRegion = d.idfsRegion
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, b.idfsGISReferenceType as idfsReferenceType, 
c.idfsCountry as idfsCountry, c.idfsRegion as idfsRegion, d.idfsRayon as idfsRayon, b.strDefault as strDefault
from gisBaseReference b
inner join gisSettlement e on e.idfsSettlement = b.idfsGISBaseReference
inner join gisRayon d on d.idfsRayon = e.idfsRayon
inner join gisRegion c on c.idfsRegion = d.idfsRegion
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                return list.ToArray();
            }
        }
    }

    public class GisBaseReferenceTranslationRaw
    {
        public long idfsBaseReference { get; set; }
        public string strTranslation { get; set; }
        public string strLanguage { get; set; }

        public static GisBaseReferenceTranslationRaw[] GetAll(string[] langs)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var list = new List<GisBaseReferenceTranslationRaw>();
                foreach (string lang in langs)
                {
                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, o.strTextString as strTranslation, @lang as strLanguage
from gisBaseReference b
inner join gisCountry c on c.idfsCountry = b.idfsGISBaseReference
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, o.strTextString as strTranslation, @lang as strLanguage
from gisBaseReference b
inner join gisRegion c on c.idfsRegion = b.idfsGISBaseReference
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, o.strTextString as strTranslation, @lang as strLanguage
from gisBaseReference b
inner join gisRayon d on d.idfsRayon = b.idfsGISBaseReference
inner join gisRegion c on c.idfsRegion = d.idfsRegion
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as idfsBaseReference, o.strTextString as strTranslation, @lang as strLanguage
from gisBaseReference b
inner join gisSettlement e on e.idfsSettlement = b.idfsGISBaseReference
inner join gisRayon d on d.idfsRayon = e.idfsRayon
inner join gisRegion c on c.idfsRegion = d.idfsRegion
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                }
                return list.ToArray();
            }
        }
    }

}
