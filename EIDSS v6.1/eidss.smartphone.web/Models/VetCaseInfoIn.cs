using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using System.Xml.Linq;
using eidss.model.Enums;
using eidss.model.Model.FlexibleForms.Helpers;

namespace eidss.smartphone.web.Models
{
    public partial class VetCaseInfoIn : InfoInBase
    {
        public List<SpeciesInfoIn> species { get; set; }
        public List<AnimalInfoIn> animals { get; set; }
        public List<VetCaseSampleInfoIn> samples { get; set; }

        private long find_by_offline_id(DbManagerProxy manager)
        {
            long ret = VetCaseListItem.Accessor.Instance(null)
                .SelectListT(manager, new FilterParams().Add("uidOfflineCaseID", "=", uidOfflineCaseID))
                .Select(c => c.idfCase).FirstOrDefault();
            return ret;
        }

        public VetCaseInfoIn()
        {
            species = new List<SpeciesInfoIn>();
            animals = new List<AnimalInfoIn>();
            samples = new List<VetCaseSampleInfoIn>();
        }

        public static IList<VetCaseInfoOut> Save(XDocument doc)
        {
            var ret = new List<VetCaseInfoOut>();
            XElement vet = doc.Root.Element("vet");
            if (vet != null)
                vet.Elements("case").ToList().ForEach(c => ret.Add(Init(c)));
            return ret;
        }

        public static VetCaseInfoOut Init(XElement xml)
        {
            VetCaseInfoIn ret = new VetCaseInfoIn(xml);
            ret.species = new List<SpeciesInfoIn>();
            xml.Element("species").Elements("kind").ToList().ForEach(c => ret.species.Add(SpeciesInfoIn.Init(c)));
            ret.animals = new List<AnimalInfoIn>();
            xml.Element("animals").Elements("animal").ToList().ForEach(c => ret.animals.Add(AnimalInfoIn.Init(c)));
            ret.samples = new List<VetCaseSampleInfoIn>();
            xml.Element("samples").Elements("sample").ToList().ForEach(c => ret.samples.Add(VetCaseSampleInfoIn.Init(c)));
            xml.Elements("ffmodel").ToList().ForEach(c =>
            {
                            if((string)c.Attribute("idfsFormType") == "10034014")
                                ret.FFControlMeasures = new FFModelIn(c);
                            else if((string)c.Attribute("idfsFormType") == "10034015" || (string)c.Attribute("idfsFormType") == "10034007")
                                ret.FFFarmEpi = new FFModelIn(c);
            });
            return ret.Save();
        }

        public VetCaseInfoOut Save()
        {

            var ret = new VetCaseInfoOut(this);
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vftacc = VetFarmTree.Accessor.Instance(null);
                VetCase vc = null;
                VetFarmTree herd = null;
                var find = find_by_offline_id(manager);
                if (find != 0)
                {
                    vc = acc.SelectByKey(manager, find);
                    ret.isUpdated = true;
                }
                else
                {
                    if (idfCase != 0)
                    {
                        var audit_acc = DataAuditListItem.Accessor.Instance(null);
                        DataAuditListItem item = audit_acc.CreateNewT(manager, null);
                        var filters = new FilterParams();
                        filters.Add("idfMainObject", "=", idfCase);
                        filters.Add("idfsObjectType", "=", (long)EIDSSAuditObject.daoVetCase);
                        filters.Add("idfsActionName", "=", (long)AuditEventType.daeDelete);
                        var list = audit_acc.SelectListT(manager, filters,
                            new[] { new KeyValuePair<string, System.ComponentModel.ListSortDirection>("datEnteringDate", System.ComponentModel.ListSortDirection.Descending) });
                        if (list.Count > 0)
                        {
                            DataAuditListItem.Accessor.Instance(null).Restore(manager, list[0]);

                            find = find_by_offline_id(manager);
                            if (find != 0)
                            {
                                vc = acc.SelectByKey(manager, find);
                                ret.isUpdated = true;
                            }
                        }
                    }

                    if (vc == null)
                    {
                        vc = acc.CreateNewT(manager, null, (int)(idfCaseType == (long)CaseTypeEnum.Avian ? HACode.Avian : HACode.Livestock));
                        ret.isCreated = true;
                        var farm = vc.Farm.FarmTree.First(t => t.idfsPartyType == (long)PartyTypeEnum.Farm);
                        herd = vftacc.CreateHerd(manager, vc.Farm, farm);
                        vc.Farm.FarmTree.Add(herd);
                    }
                }

                if (!ret.isFailed)
                    vc.Validation += (sender, args) =>
                    {
                        if (args.ShouldAsk)
                            args.Continue = true;
                        else
                        {
                            ret.lastErrorDescription = GetErrorMessage(args);
                            ret.isCreated = false;
                            ret.isUpdated = false;
                            ret.isFailed = true;
                        }
                    };

                vc.uidOfflineCaseID = new Guid(uidOfflineCaseID);
                vc.CaseType = idfCaseType == 0 ? null
                    : vc.CaseTypeLookup.SingleOrDefault(c => c.idfsBaseReference == idfCaseType);
                vc.CaseReportType = idfsCaseReportType == 0 ? null
                    : vc.CaseReportTypeLookup.SingleOrDefault(c => c.idfsBaseReference == idfsCaseReportType);
                vc.strFieldAccessionID = strLocalIdentifier;
                vc.TentativeDiagnosis = idfsTentativeDiagnosis == 0 ? null
                    : vc.TentativeDiagnosisLookup.SingleOrDefault(c => c.idfsDiagnosis == idfsTentativeDiagnosis);
                vc.datTentativeDiagnosisDate = datTentativeDiagnosisDate == DateTime.MinValue ? new DateTime?() : datTentativeDiagnosisDate;
                vc.strSummaryNotes = strComment;

                if (idfRootFarm > 0)
                    vc.Farm.idfRootFarm = idfRootFarm;
                vc.Farm.strNationalName = strFarmName;
                vc.Farm.strOwnerLastName = strOwnerLastName;
                vc.Farm.strOwnerFirstName = strOwnerFirstName;
                vc.Farm.strOwnerMiddleName = strOwnerMiddleName;

                vc.Farm.Address.CountryLookup.SingleOrDefault(c => c.idfsCountry == EidssSiteContext.Instance.CountryID);
                vc.Farm.Address.Region = idfsRegion == 0 ? null :
                    vc.Farm.Address.RegionLookup.SingleOrDefault(c => c.idfsRegion == idfsRegion);
                vc.Farm.Address.Rayon = idfsRayon == 0 ? null :
                    vc.Farm.Address.RayonLookup.SingleOrDefault(c => c.idfsRayon == idfsRayon);
                vc.Farm.Address.Settlement = idfsSettlement == 0 ? null :
                    vc.Farm.Address.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == idfsSettlement);
                vc.Farm.Address.strBuilding = strBuilding;
                vc.Farm.Address.strHouse = strHouse;
                vc.Farm.Address.strApartment = strApartment;
                vc.Farm.Address.strStreetName = strStreetName;
                vc.Farm.Address.strPostCode = strPostCode;
                vc.Farm.strContactPhone = strPhone;
                vc.Farm.Address.dblLongitude = dblLongitude == 0 ? new double?() : dblLongitude;
                vc.Farm.Address.dblLatitude = dblLatitude == 0 ? new double?() : dblLatitude;
                vc.datReportDate = datReportDate == DateTime.MinValue ? new DateTime?() : datReportDate;

                if (herd == null)   //earlier existed case
                    herd = vc.Farm.FarmTree.FirstOrDefault(t => t.idfParty == idfsHerd /*(long)0*//*ret.herd*/);
                if (herd == null)   //if herd id was not transfered to android (it can be if synchronization was by file)
                    herd = vc.Farm.FarmTree.FirstOrDefault(t => t.idfsPartyType == (long)PartyTypeEnum.Herd);
                if (herd == null)   // very strange situation: earlier synchronized case doesn't have any herd
                {
                    var farm = vc.Farm.FarmTree.First(t => t.idfsPartyType == (long)PartyTypeEnum.Farm);
                    herd = vftacc.CreateHerd(manager, vc.Farm, farm);
                    vc.Farm.FarmTree.Add(herd);
                }

                // FF
                if (vc.idfObservationFarm > 0)
                {
                    ret.idfObservationFarm = vc.idfObservationFarm;
                    vc.Farm.FFPresenterEpi.SetProperties(EidssSiteContext.Instance.CountryID, vc.idfsDiagnosis, vc.IsLiveStock ? FFTypeEnum.LivestockFarmEPI : FFTypeEnum.AvianFarmEPI, vc.idfObservationFarm, vc.idfCase);
                    foreach (var p in FFFarmEpi.parameters)
                    {
                        var ap = vc.Farm.FFPresenterEpi.ActivityParameters.SetActivityParameterValue(
                            vc.Farm.FFPresenterEpi.CurrentTemplate
                            , vc.idfObservationFarm
                            , p.idfsParameter
                            , p.Value
                            );
                        if (ap != null) ap.IsDynamicParameter = true; //just in case
                    }
                }

                if (vc.FFPresenterControlMeasures != null && vc.idfObservation.HasValue && vc.idfObservation.Value > 0)
                {
                    ret.idfObservation = vc.idfObservation.Value;
                    vc.FFPresenterControlMeasures.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.LivestockControlMeasures, vc.idfObservation.Value, vc.idfCase);
                    foreach (var p in FFControlMeasures.parameters)
                    {
                        var ap = vc.FFPresenterControlMeasures.ActivityParameters.SetActivityParameterValue(
                            vc.FFPresenterControlMeasures.CurrentTemplate
                            , vc.idfObservation.Value
                            , p.idfsParameter
                            , p.Value
                            );
                        if (ap != null) ap.IsDynamicParameter = true; //just in case
                    }
                }

                if (!ret.isFailed)
                    foreach (var s in species.Where(i => i.intChanged == 1).ToList())
                    {
                        var vetFarmTree = vc.Farm.FarmTree.FirstOrDefault(t =>
                                    t.idfsPartyType == (long)PartyTypeEnum.Species && t.idfParentParty == herd.idfParty
                                    && t.idfsSpeciesTypeReference == s.idfsSpeciesType);
                        if (vetFarmTree == null)
                        {
                            vetFarmTree = vftacc.CreateSpecies(manager, vc.Farm, herd);
                            vetFarmTree.SpeciesType =
                                vetFarmTree.SpeciesTypeLookup.SingleOrDefault(c => c.idfsBaseReference == s.idfsSpeciesType);
                            vc.Farm.FarmTree.Add(vetFarmTree);
                        }
                        vetFarmTree.datStartOfSignsDate = s.datStartOfSignsDate == DateTime.MinValue
                            ? new DateTime?()
                            : s.datStartOfSignsDate;
                        vetFarmTree.intTotalAnimalQty = s.intTotalAnimalQty == 0 ? new int?() : s.intTotalAnimalQty;
                        vetFarmTree.intDeadAnimalQty = s.intDeadAnimalQty == 0 ? new int?() : s.intDeadAnimalQty;
                        vetFarmTree.intSickAnimalQty = s.intSickAnimalQty == 0 ? new int?() : s.intSickAnimalQty;
                        vetFarmTree.strAverageAge = s.intAverageAge == 0 ? new int?() : s.intAverageAge;
                        vetFarmTree.strNote = s.strNote;

                        //FF
                        if (vetFarmTree.idfObservation.HasValue && vetFarmTree.idfObservation.Value > 0)
                        {
                            foreach (var p in s.FFPresenterCs.parameters)
                            {
                                var ap = vetFarmTree.FFPresenterCs.ActivityParameters.SetActivityParameterValue(
                                    vetFarmTree.FFPresenterCs.CurrentTemplate
                                    , vetFarmTree.idfObservation.Value
                                    , p.idfsParameter
                                    , p.Value
                                    );
                                if (ap != null) ap.IsDynamicParameter = true; //just in case
                            }
                            s.idfObservation = vetFarmTree.idfObservation.Value;
                        }
                        //s.idfsHerd = vetFarmTree.idfParentParty.Value;
                    }

                if (!ret.isFailed)
                    foreach (var a in animals.Where(i => i.intChanged == 1 || i.idfAnimal <= 0).ToList())
                    {
                        var vetFarmTree = vc.Farm.FarmTree
                            .FirstOrDefault(
                                t =>
                                    t.idfsPartyType == (long)PartyTypeEnum.Species && t.idfParentParty == herd.idfParty
                                    && t.idfsSpeciesTypeReference == a.idfsSpeciesType);

                        AnimalListItem animal;
                        if (a.idfAnimal <= 0)
                            animal = vc.AnimalList.FirstOrDefault(i => i.uidOfflineCaseID.HasValue && !string.IsNullOrEmpty(a.uidOfflineCaseID) && i.uidOfflineCaseID.Value == new Guid(a.uidOfflineCaseID));
                        else
                            animal = vc.AnimalList.FirstOrDefault(i => i.idfAnimal == a.idfAnimal);

                        if (animal == null)
                        {
                            animal = AnimalListItem.Accessor.Instance(null).CreateAnimal(manager, vc, vc.idfsDiagnosis);
                            a.FillVetCaseAnimal(animal, herd.idfParty, vetFarmTree.idfParty);
                            vc.AnimalList.Add(animal);
                        }
                        else
                        {
                            a.FillVetCaseAnimal(animal, herd.idfParty, vetFarmTree.idfParty);
                        }
                        // Fill in server idfAnimal in samples
                        if (a.idfAnimal <= 0)
                        {
                            samples.FindAll(s => s.idfAnimal == a.idfAnimal).ForEach(s => s.idfAnimal = animal.idfAnimal);
                        }

                    }

                if (!ret.isFailed)
                    foreach (var a in samples.Where(i => i.intChanged == 1).ToList())
                    {
                        var vetFarmTree = vc.Farm.FarmTree
                            .FirstOrDefault(
                                t =>
                                    t.idfsPartyType == (long)PartyTypeEnum.Species && t.idfParentParty == herd.idfParty
                                    && t.idfsSpeciesTypeReference == a.idfsSpeciesType);

                        VetCaseSample sample;
                        if (a.idfMaterial <= 0)
                            sample = vc.Samples.FirstOrDefault(i => i.uidOfflineCaseID.HasValue && !string.IsNullOrEmpty(a.uidOfflineCaseID) && i.uidOfflineCaseID.Value == new Guid(a.uidOfflineCaseID));
                        else
                            sample = vc.Samples.FirstOrDefault(i => i.idfMaterial == a.idfMaterial);

                        if (sample == null)
                        {
                            long? sentOffice = a.idfSendToOffice;
                            if (a.idfSendToOffice == 0)
                                sentOffice = null;
                            sample = VetCaseSample.Accessor.Instance(null).Create(manager, vc,
                                sentOffice, null, null, "_organization", "", "");
                            a.FillVetCaseSample(sample, vc._HACode, vetFarmTree.idfParty);
                            vc.Samples.Add(sample);
                        }
                        else
                        {
                            a.FillVetCaseSample(sample, vc._HACode, vetFarmTree.idfParty);
                        }
                    }
                
                if (idfCase == 0)
                {
                    vc.idfReportedByOffice = EidssSiteContext.Instance.OrganizationID;
                    vc.strReportedByOffice = EidssSiteContext.Instance.OrganizationName;
                    vc.idfPersonReportedBy = (long)EidssUserContext.User.EmployeeID;
                    vc.strPersonReportedBy = EidssUserContext.User.FullName;
                }

                try
                {
                    acc.Post(manager, vc);
                }
                catch (Exception e)
                {
                    ret.lastErrorDescription = e.InnerException == null ? e.Message : e.InnerException.Message;
                    ret.isCreated = false;
                    ret.isUpdated = false;
                    ret.isFailed = true;
                }

                // Sync group 3
                if (!ret.isFailed)
                {
                    ret.idfCase = vc.idfCase;
                    ret.strCaseID = vc.strCaseID;
                    ret.idfsHerd = herd.idfParty;
                    ret.strFarmCode = vc.Farm.strFarmCode;
                    //ret.idfFarm = vc.Farm.idfFarm;
                    //ret.idfRootFarm = vc.Farm.idfRootFarm.GetValueOrDefault();
                    ret.strSentByOffice = vc.strReportedByOffice;
                    ret.strSentByPerson = vc.strPersonReportedBy;
                    ret.datModificationDate = vc.datModificationForArchiveDate.HasValue ? vc.datModificationForArchiveDate.Value : ret.datModificationDate;

                    foreach (VetFarmTree s in vc.Farm.FarmTree)
                    {
                        if (s.idfsPartyType.HasValue && s.idfsPartyType.Value == (long)PartyTypeEnum.Species && s.idfParentParty == herd.idfParty)
                        {
                            ret.species.Add(new SpeciesInfoIn(s));
                        }
                    }

                    foreach (var anml in vc.AnimalList)
                    {
                        ret.animals.Add(new AnimalInfoIn(anml));
                    }

                    foreach (var s in vc.Samples)
                    {
                        ret.samples.Add(new VetCaseSampleInfoIn(s));
                    }
                }
            }

            return ret;
        }

        public FFModelIn FFControlMeasures { get; set; }
        public FFModelIn FFFarmEpi { get; set; }
    }
}