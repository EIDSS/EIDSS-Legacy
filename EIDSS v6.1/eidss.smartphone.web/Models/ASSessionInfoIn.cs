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
using bv.model.Helpers;

namespace eidss.smartphone.web.Models
{
    public partial class ASSessionInfoIn : InfoInBase
    {
        public List<ASDiseaseInfoIn> asdiseases { get; set; }
        public List<FarmInfoIn> farms { get; set; }
        public List<ASSampleInfoIn> assamples { get; set; }
        public DateTime datCreateDate { get; set; }

        public static IEnumerable<ASSessionInfoIn> GetList(long idfsRegion)
        {
            var list = new List<long>();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                list = AsSessionListItem.Accessor.Instance(null)
                    .SelectListT(manager, new FilterParams().Add("idfsRegion", "=", idfsRegion))
                    .Select(c => c.idfMonitoringSession).ToList();
                return list.Select(c => new ASSessionInfoIn(AsSession.Accessor.Instance(null).SelectByKey(manager, c))).ToList();
            }
        }

        private long find_by_offline_id_or_id(DbManagerProxy manager)
        {
            if (string.IsNullOrEmpty(uidOfflineCaseID))
            {
                return AsSessionListItem.Accessor.Instance(null)
                     .SelectListT(manager, new FilterParams().Add("idfMonitoringSession", "=", idfMonitoringSession))
                     .Select(c => c.idfMonitoringSession).FirstOrDefault();
            }
            else
            {
                return AsSessionListItem.Accessor.Instance(null)
                     .SelectListT(manager, new FilterParams().Add("uidOfflineCaseID", "=", uidOfflineCaseID))
                     .Select(c => c.idfMonitoringSession).FirstOrDefault();
            }
        }

        public ASSessionInfoIn()
        {
            asdiseases = new List<ASDiseaseInfoIn>();
            farms = new List<FarmInfoIn>();
            assamples = new List<ASSampleInfoIn>();
        }

        public ASSessionInfoIn(AsSession a)
        {
            datCreateDate = a.datEnteredDate.ValueOrDefault();
            uidOfflineCaseID = a.uidOfflineCaseID.StrOrEmpty();
            strMonitoringSessionID = a.strMonitoringSessionID;
            idfMonitoringSession = a.idfMonitoringSession;
            idfsMonitoringSessionStatus = a.idfsMonitoringSessionStatus.ValueOrDefault();
            datStartDate = a.datStartDate.ValueOrDefault();
            datEndDate = a.datEndDate.ValueOrDefault();
            idfCampaign = a.idfCampaign.ValueOrDefault();
            idfsCampaignType = a.idfsCampaignType.ValueOrDefault();
            idfsRegion = a.idfsRegion.ValueOrDefault();
            idfsRayon = a.idfsRayon.ValueOrDefault();
            idfsSettlement = a.idfsSettlement.ValueOrDefault();
            datModificationDate = a.datModificationForArchiveDate.ValueOrDefault();

            asdiseases = new List<ASDiseaseInfoIn>();
            a.Diseases.ForEach(c => asdiseases.Add(new ASDiseaseInfoIn(c)));

            farms = new List<FarmInfoIn>();
            a.ASFarmsDetails.ForEach(c => farms.Add(new FarmInfoIn(c)));

            assamples = new List<ASSampleInfoIn>();
        }

        public static IList<ASSessionInfoOut> Save(XDocument doc)
        {
            var ret = new List<ASSessionInfoOut>();
            XElement sess = doc.Root.Element("as");
            if (sess != null)
                sess.Elements("case").ToList().ForEach(c => ret.Add(Init(c)));
            return ret;
        }

        public static ASSessionInfoOut Init(XElement xml)
        {
            ASSessionInfoIn ret = new ASSessionInfoIn(xml);
            ret.asdiseases = new List<ASDiseaseInfoIn>();
            xml.Element("asdiseases").Elements("asdisease").ToList().ForEach(c => ret.asdiseases.Add(ASDiseaseInfoIn.Init(c)));
            ret.farms = new List<FarmInfoIn>();
            xml.Element("farms").Elements("farm").ToList().ForEach(c => ret.farms.Add(FarmInfoIn.Init(c)));
            ret.assamples = new List<ASSampleInfoIn>();
            xml.Element("assamples").Elements("assample").ToList().ForEach(c => ret.assamples.Add(ASSampleInfoIn.Init(c)));
            return ret.Save();
        }

        public ASSessionInfoOut Save()
        {

            var ret = new ASSessionInfoOut(this);
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = AsSession.Accessor.Instance(null);
                AsSession vc = null;
                var find = find_by_offline_id_or_id(manager);
                if (find != 0)
                {
                    vc = acc.SelectByKey(manager, find);
                    ret.isUpdated = true;
                }
                else
                {
                    if (idfMonitoringSession != 0)
                    {
                        var audit_acc = DataAuditListItem.Accessor.Instance(null);
                        DataAuditListItem item = audit_acc.CreateNewT(manager, null);
                        var filters = new FilterParams();
                        filters.Add("idfMainObject", "=", idfMonitoringSession);
                        filters.Add("idfsObjectType", "=", (long)EIDSSAuditObject.daoMonitoringSession);
                        filters.Add("idfsActionName", "=", (long)AuditEventType.daeDelete);
                        var list = audit_acc.SelectListT(manager, filters,
                            new[] { new KeyValuePair<string, System.ComponentModel.ListSortDirection>("datEnteringDate", System.ComponentModel.ListSortDirection.Descending) });
                        if (list.Count > 0)
                        {
                            DataAuditListItem.Accessor.Instance(null).Restore(manager, list[0]);

                            find = find_by_offline_id_or_id(manager);
                            if (find != 0)
                            {
                                vc = acc.SelectByKey(manager, find);
                                ret.isUpdated = true;
                            }
                        }
                    }

                    if (vc == null)
                    {
                        vc = acc.CreateNewT(manager, null);
                        ret.isCreated = true;
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


                var bCaseModifyedInServer = false;
                if (!ret.isFailed)
                    bCaseModifyedInServer = vc.datModificationForArchiveDate.HasValue
                        && vc.datModificationForArchiveDate.Value.AddMilliseconds(-vc.datModificationForArchiveDate.Value.Millisecond) != datModificationDate;

                // Sync group 1
                if (idfMonitoringSession == 0)
                {
                    if (!ret.isFailed)
                        vc.uidOfflineCaseID = new Guid(uidOfflineCaseID);
                    if (!ret.isFailed)
                        vc.datStartDate = datStartDate == DateTime.MinValue ? new DateTime?() : datStartDate;
                    if (!ret.isFailed)
                        vc.datEndDate = datEndDate == DateTime.MinValue ? new DateTime?() : datEndDate;
                    if (!ret.isFailed)
                        vc.idfCampaign = idfCampaign;

                    if (!ret.isFailed)
                        vc.Region = idfsRegion == 0 ? null : vc.RegionLookup.SingleOrDefault(c => c.idfsRegion == idfsRegion);
                    if (!ret.isFailed)
                        vc.Rayon = idfsRayon == 0 ? null : vc.RayonLookup.SingleOrDefault(c => c.idfsRayon == idfsRayon);
                    if (!ret.isFailed)
                        vc.Settlement = idfsSettlement == 0 ? null : vc.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == idfsSettlement);

                    if (!ret.isFailed)
                    {
                        vc.Diseases.Clear();
                        asdiseases.ForEach(c => {
                            var asd = AsSessionDisease.Accessor.Instance(null).CreateNewT(manager, vc);
                            c.FillAsSessionDisease(asd);
                            vc.Diseases.Add(asd);
                        });
                    }
                }

                // Sync group 2
                if (!bCaseModifyedInServer)
                {
                    if (!ret.isFailed)
                        vc.datStartDate = datStartDate == DateTime.MinValue ? new DateTime?() : datStartDate;
                    if (!ret.isFailed)
                        vc.datEndDate = datEndDate == DateTime.MinValue ? new DateTime?() : datEndDate;
                }

                List<long> herdIdents = new List<long>();
                if (!ret.isFailed)
                {
                    farms.Where(i => i.intChanged == 1).ToList().ForEach(c => {
                        AsSessionFarm farm;
                        if (c.idfFarm <= 0)
                        {
                            farm = vc.ASFarmsAll.FirstOrDefault(i => i.Farm.uidOfflineCaseID.HasValue && !string.IsNullOrEmpty(c.uidOfflineCaseID) && i.Farm.uidOfflineCaseID.Value == new Guid(c.uidOfflineCaseID));
                            if (farm == null)
                            {
                                farm = AsSessionFarm.Accessor.Instance(null).CreateNewT(manager, vc);
                                c.FillAsSessionFarm(farm);
                                farm.blnIsDetailsFarm = true;
                                farm.blnNewFarm = true;
                                vc.ASFarmsAll.Add(farm);
                            }
                            else
                            {
                                c.FillAsSessionFarm(farm);
                                farm.blnIsDetailsFarm = true;
                            }

                            assamples.Where(i => i.intChanged == 1 && i.idfFarm == c.idfFarm).ToList().ForEach(i => { i.idfFarm = farm.idfFarm; });
                        }
                        else
                        {
                            farm = vc.ASFarmsAll.FirstOrDefault(i => i.idfFarm == c.idfFarm);
                            if (farm == null)
                            {
                                farm = AsSessionFarm.Accessor.Instance(null).CreateNewT(manager, vc);
                                c.FillAsSessionFarm(farm);
                                farm.blnIsDetailsFarm = true;
                                farm.blnNewFarm = true;
                                vc.ASFarmsAll.Add(farm);
                            }
                            else
                            {
                                c.FillAsSessionFarm(farm);
                                farm.blnIsDetailsFarm = true;
                            }
                        }



                        var herd = farm.Farm.FarmTree.FirstOrDefault(t => t.idfsPartyType == (long)PartyTypeEnum.Herd && t.idfParty == c.idfsHerd);
                        if (herd == null)
                        {
                            var f = farm.Farm.FarmTree.First(t => t.idfsPartyType == (long)PartyTypeEnum.Farm);
                            herd = VetFarmTree.Accessor.Instance(null).CreateHerd(manager, farm.Farm, f);
                            farm.Farm.FarmTree.Add(herd);
                        }
                        herdIdents.Add(herd.idfParty);

                        foreach (var s in c.species.Where(i => i.intChanged == 1).ToList())
                        {
                            var vetFarmTree = farm.Farm.FarmTree.FirstOrDefault(t =>
                                        t.idfsPartyType == (long)PartyTypeEnum.Species && t.idfParentParty == c.idfsHerd
                                        && t.idfsSpeciesTypeReference == s.idfsSpeciesType);

                            if (vetFarmTree == null)
                            {
                                vetFarmTree = VetFarmTree.Accessor.Instance(null).CreateSpecies(manager, farm.Farm, herd);
                                vetFarmTree.SpeciesType = vetFarmTree.SpeciesTypeLookup.SingleOrDefault(i => i.idfsBaseReference == s.idfsSpeciesType);
                                farm.Farm.FarmTree.Add(vetFarmTree);
                            }

                            vetFarmTree.datStartOfSignsDate = s.datStartOfSignsDate == DateTime.MinValue
                                ? new DateTime?()
                                : s.datStartOfSignsDate;
                            vetFarmTree.intTotalAnimalQty = s.intTotalAnimalQty == 0 ? new int?() : s.intTotalAnimalQty;
                            vetFarmTree.intDeadAnimalQty = s.intDeadAnimalQty == 0 ? new int?() : s.intDeadAnimalQty;
                            vetFarmTree.intSickAnimalQty = s.intSickAnimalQty == 0 ? new int?() : s.intSickAnimalQty;
                        }
                    });
                }

                if (!ret.isFailed)
                {
                    assamples.Where(i => i.intChanged == 1).ToList().ForEach(c =>
                    {
                        AsSessionAnimalSample a = null;
                        if (c.idfAnimal >= 0 && c.idfMaterial >= 0)
                        {
                            a = vc.ASAnimalsSamples.FirstOrDefault(i => i.idfAnimal == c.idfAnimal && i.idfMaterial == c.idfMaterial);
                            // update
                        }

                        if (a == null)
                        {
                            a = AsSessionAnimalSample.Accessor.Instance(null).CreateNewT(manager, vc);
                            vc.ASAnimalsSamples.Add(a);
                            // insert
                        }
                        c.FillAsSessionSample(a);
                    });
                }

                if (!ret.isFailed)
                {
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
                }

                // Sync group 3
                if (!ret.isFailed)
                {
                    ret.idfMonitoringSession = vc.idfMonitoringSession;
                    ret.strMonitoringSessionID = vc.strMonitoringSessionID;
                    ret.datModificationDate = vc.datModificationForArchiveDate.HasValue ? vc.datModificationForArchiveDate.Value : ret.datModificationDate;

                    vc.Diseases.ForEach(c => {
                        ret.asdiseases.Add(new ASDiseaseInfoIn(c));
                    });

                    vc.ASFarmsDetails.ForEach(c => {
                        var farm = new FarmInfoIn(c);

                        var herd = c.Farm.FarmTree.FirstOrDefault(t => t.idfsPartyType == (long)PartyTypeEnum.Herd && herdIdents.Contains(t.idfParty));
                        if (herd != null)
                        {
                            farm.idfsHerd = herd.idfParty;

                            foreach (VetFarmTree s in c.Farm.FarmTree)
                            {
                                if (s.idfsPartyType.HasValue && s.idfsPartyType.Value == (long)PartyTypeEnum.Species && s.idfParentParty == herd.idfParty)
                                {
                                    farm.species.Add(new SpeciesInfoIn()
                                    {
                                        //idfsHerd = s.idfParentParty.HasValue ? s.idfParentParty.Value : 0,
                                        idfsFormTemplate = s.idfsFormTemplate.HasValue ? s.idfsFormTemplate.Value : 0,
                                        idfsSpeciesType = s.idfsSpeciesTypeReference.HasValue ? s.idfsSpeciesTypeReference.Value : 0,
                                        datStartOfSignsDate = s.datStartOfSignsDate.HasValue ? s.datStartOfSignsDate.Value : DateTime.MinValue,
                                        intTotalAnimalQty = s.intTotalAnimalQty.HasValue ? s.intTotalAnimalQty.Value : 0,
                                        intSickAnimalQty = s.intSickAnimalQty.HasValue ? s.intSickAnimalQty.Value : 0,
                                        intDeadAnimalQty = s.intDeadAnimalQty.HasValue ? s.intDeadAnimalQty.Value : 0,
                                        idfObservation = s.idfObservation.HasValue ? s.idfObservation.Value : 0
                                    });
                                }
                            }
                        }

                        ret.farms.Add(farm);
                    });


                    vc.ASAnimalsSamples.Where(i => i.uidOfflineCaseID.HasValue).ToList().ForEach(c =>
                    {
                        var assample = new ASSampleInfoIn(c);
                        ret.assamples.Add(assample);
                    });

                    // Sync group 2
                    ret.datStartDate = vc.datStartDate.HasValue ? vc.datStartDate.Value : DateTime.MinValue;
                    ret.datEndDate = vc.datEndDate.HasValue ? vc.datEndDate.Value : DateTime.MinValue;
                    if (bCaseModifyedInServer && !ret.isFailed)
                    {
                        var listOfChanges = new List<Tuple<string, string, string>>();
                        if (ret.datStartDate != datStartDate)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("datStartDate"),
                                datStartDate == DateTime.MinValue ? "" : datStartDate.ToShortDateString(),
                                ret.datStartDate == DateTime.MinValue ? "" : ret.datStartDate.ToShortDateString()
                                ));
                        if (ret.datEndDate != datEndDate)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("datEndDate"),
                                datEndDate == DateTime.MinValue ? "" : datEndDate.ToShortDateString(),
                                ret.datEndDate == DateTime.MinValue ? "" : ret.datEndDate.ToShortDateString()
                                ));
                        if (listOfChanges.Count > 0)
                        {
                            var fldList = "";
                            listOfChanges.ForEach(c => fldList += (fldList.Length > 0 ? ", " : "") + c.Item1 + " = " + " '" + c.Item2 + "'");
                            ret.lastErrorDescription = string.Format(EidssMessages.Get("msgSyncGroup2"), fldList);
                        }
                    }
                }

            }

            return ret;
        }

    }
}