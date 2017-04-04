using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    public static class AutoConverter
    {
        internal static D Construct<S,D>(ResolutionContext context, Func<S, D, bool> predicate, Func<S, long> id)
            where S : class
            where D : class
        {
            var source = context.SourceValue as S;
            var parent = context.Parent.DestinationValue as IObject;
            if (parent == null)
                parent = context.Parent.Parent.DestinationValue as IObject;
            var list = parent.GetValue(context.MemberName + "Lookup") as List<D>;
            var ret = list.SingleOrDefault(i => predicate(source, i));
            if (ret == null)
            {
                throw new ReferenceNotFoundException(id(source), context.MemberName);
            }
            return ret;
        }

        internal static bool CheckReadOnly<M>(ResolutionContext context)
            where M : class, IObject
        {
            M o = null;
            foreach (var i in context.InstanceCache.Reverse().Select(c => c.Value))
            {
                o = i as M;
                if (o != null)
                    break;
            }
            if (o == null)
                throw new GeneralException();

            bool enable = !o.IsReadOnly(context.MemberName) && !o.IsInvisible(context.MemberName);
            if (!enable)
            {
                var org = o.GetValue(context.MemberName);
                var src = context.SourceValue;
                if (src != null)
                {
                    var orgStr = org.ToNullSafeString();
                    var srcStr = src.ToNullSafeString();
                    if (src is Reference)
                        srcStr = (src as Reference).RecordID.ToNullSafeString();
                    if (src is GisReference)
                        srcStr = (src as GisReference).RecordID.ToNullSafeString();
                    if (src is OrganizationReference)
                        srcStr = (src as OrganizationReference).RecordID.ToNullSafeString();
                    if (src is PersonReference)
                        srcStr = (src as PersonReference).RecordID.ToNullSafeString();
                    if (orgStr != srcStr)
                    {
                        throw new ReadOnlyFieldException(context.MemberName);
                    }
                }
            }
            return enable;
        }

        public static void Nop()
        {
        }

        public static void Check()
        {
            Mapper.AssertConfigurationIsValid();
        }

        static AutoConverter()
        {
            HumanCaseConverter.Register();
            HumanCaseListItemConverter.Register();
            VetCaseConverter.Register();
            VetCaseListItemConverter.Register();
            PatientConverter.Register();
            PatientListItemConverter.Register();
            FarmPanelConverter.Register();
            FarmRootConverter.Register();
            FarmListItemConverter.Register();
            GeoLocationConverter.Register();
            AddressConverter.Register();
            HumanCaseSampleConverter.Register();
            VetCaseSampleConverter.Register();
            PensideTestConverter.Register();
            HerdConverter.Register();
            SpeciesConverter.Register();
            AnimalConverter.Register();
            CaseTestConverter.Register();
            CaseTestValidationConverter.Register();
            OrganizationConverter.Register();
            OrganizationListItemConverter.Register();
            OrganizationPersonConverter.Register();

            BaseReferenceConverter.Register();
            CountryConverter.Register();
            RegionConverter.Register();
            RayonConverter.Register();
            SettlementConverter.Register();
            DiagnosisConverter.Register();
            AnimalAgeConverter.Register();
            SampleTypeForDiagnosisConverter.Register();
            TestResultConverter.Register();
            InitialCaseClassificationConverter.Register();
            FinalCaseClassificationConverter.Register();
            OrganizationReferenceConverter.Register();
            PersonConverter.Register();
            WiderPersonConverter.Register();
        }
    }
}
