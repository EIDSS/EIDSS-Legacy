using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.openapi.bll.Converters;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferenceBll
    {
        public static List<eidss.openapi.contract.Reference> GetList(long type)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return BaseReference.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => c.idfsReferenceType == type)
                    .Where(c => c.intRowStatus == 0)
                    .OrderBy(c => c.intOrder)
                    .Select(c => BaseReferenceConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }

        public static List<eidss.openapi.contract.Diagnosis> GetDignosisList()
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return DiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => c.intRowStatus == 0)
                    .Select(c => DiagnosisConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }

        public static List<eidss.openapi.contract.Reference> GetSampleTypeForDiagnosisList(int haCode, long diagnosis)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return SampleTypeForDiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => c.intRowStatus == 0)
                    .Where(c => (c.intHACode & haCode) != 0)
                    .Where(c => c.idfsDiagnosis == diagnosis)
                    .Select(c => SampleTypeForDiagnosisConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }

        public static List<eidss.openapi.contract.GisReference> GetCountryList()
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return CountryLookup.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => c.intRowStatus == 0)
                    .Select(c => CountryConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }

        public static List<eidss.openapi.contract.GisReference> GetRegionList(long country)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return RegionLookup.Accessor.Instance(null).SelectLookupList(manager, country, null)
                    .Where(c => c.intRowStatus == 0)
                    .Select(c => RegionConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }

        public static List<eidss.openapi.contract.GisReference> GetRayonList(long region)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return RayonLookup.Accessor.Instance(null).SelectLookupList(manager, region, null)
                    .Where(c => c.intRowStatus == 0)
                    .Select(c => RayonConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }

        public static List<eidss.openapi.contract.GisReference> GetSettlementList(long rayon)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return SettlementLookup.Accessor.Instance(null).SelectLookupList(manager, rayon, null)
                    .Where(c => c.intRowStatus == 0)
                    .Select(c => SettlementConverter.Instance.ToContract(manager, c))
                    .ToList();
            }
        }
    }
}