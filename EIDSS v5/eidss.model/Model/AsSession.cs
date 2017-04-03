using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using System.Collections;
using eidss.model.Enums;
using BLToolkit.Data;
using eidss.model.Resources;
using BLToolkit.Validation;

namespace eidss.model.Schema
{
    public partial class AsSession
    {
        public const string NO_CASES_CREATED = "NO CASES YET";                

        public static bool ValidateCampaignToSessionDiseasesRules(AsSession session, AsCampaign campaign)
        {
                var campaignDiseasesCount = campaign.Diseases.Where(d => !d.IsMarkedToDelete).Count();

                if (campaignDiseasesCount == 0 && session.Diseases.Count(x => !x.IsMarkedToDelete) > 0)
                {
                    return false;
                }

                if (session.Diseases.Count(x => !x.IsMarkedToDelete) > 0)
                {
                        //if session contains diagnosis which are not in the campaign, error
                        if (session.Diseases.Where(x => !x.IsMarkedToDelete).Count(c => campaign.Diseases.Count(d => d.idfsDiagnosis == c.idfsDiagnosis) == 0) > 0)
                        {
                            return false;
                        }
                  
                    
                    //if diseases+species have at least one difference, error

                        var commonDiseasesWithSpecies = session.Diseases.Where(x => !x.IsMarkedToDelete)
                                .Join(campaign.Diseases,
                                        x => new { x.idfsDiagnosis, x.idfsSpeciesType },
                                        y => new { y.idfsDiagnosis, y.idfsSpeciesType },
                                        (x, y) => x.idfsDiagnosis).Count();

                        if (commonDiseasesWithSpecies < session.Diseases.Count(x => !x.IsMarkedToDelete))
                        {
                            //if (commonDiseasesWithSpecies == campaign.Diseases.Count(d => d.idfsSpeciesType.HasValue && !d.IsMarkedToDelete) &&
                            //    commonDiseasesWithSpecies < campaignDiseasesCount)
                            //{
                                
                                //if Campaign contains diseases without species, all ok
                                var commonDiseaseNoSpecies = session.Diseases.Where(x => !x.IsMarkedToDelete && x.idfsSpeciesType.HasValue)
                                    .Join(campaign.Diseases.Where(d=>!d.IsMarkedToDelete && !d.idfsSpeciesType.HasValue),
                                        s => s.idfsDiagnosis,
                                        c => c.idfsDiagnosis,
                                        (s,c) => s.idfsDiagnosis)
                                    .Count();

                                if (commonDiseaseNoSpecies != session.Diseases.Count(d => !d.IsMarkedToDelete) - commonDiseasesWithSpecies)
                                {
                                    return false;
                                }
                            //}
                            //else
                            //{
                            //    return false;
                            //}
                        }                        
                }
                return true;
        }


        public static void CopyDiseasesFromCampaignToSession(DbManagerProxy manager, AsSession session, AsCampaign campaign)
        {
            if (campaign.Diseases.Count() > 0 && session.Diseases.Count(x => !x.IsMarkedToDelete) == 0)
            {
                AsSessionDisease item = null;

                foreach (var campaignDisease in campaign.Diseases.Where(d => !d.IsMarkedToDelete))
                {
                    item = (AsSessionDisease)AsSessionDisease.Accessor.Instance(null).CreateNew(manager, session);
                    item.idfMonitoringSession = session.idfMonitoringSession;
                    item.idfsDiagnosis = campaignDisease.idfsDiagnosis;
                    item.idfsSpeciesType = campaignDisease.idfsSpeciesType;
                    item.Diagnosis = campaignDisease.Diagnosis;
                    item.SpeciesType = campaignDisease.SpeciesType;
                    session.Diseases.Add(item);
                }

            }             
        }

        private bool CopyCampaignData()
        {
            if (!_blnAllowCampaignReload || !IsDirty)
                return true;

            string[] populateCampaign = new string[] {
                      "strCampaignName",
                      "strCampaignID",
                      "idfsCampaignType",
                      "CampaignType"
                      };

            if (!idfCampaign.HasValue)
                return true;

            if (idfCampaign.Value == 0)
            {
                idfCampaign = null;             
                foreach (var prop in populateCampaign)
                    this.SetValue(prop, string.Empty);                
                return true;
            }



            if (blnForceCampaignAssignment)
                Diseases.ForEach(x => x.MarkToDelete());

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {
                var acc = AsCampaign.Accessor.Instance(null);

                var campaign = (CampaignInRamOnly == null || CampaignInRamOnly.idfCampaign != idfCampaign)
                    ? (AsCampaign)acc.SelectByKey(manager, this.idfCampaign)
                    : CampaignInRamOnly;


                if (campaign.idfsCampaignStatus != (long)AsCampaignStatus.Open)
                    throw new ValidationModelException("msgCampaignIsNotOpen", "idfCampaign", "idfCampaign", new string[] { "Error" }, null, false);
                //validate Disease List

                if (datStartDate < campaign.datCampaignDateStart || datEndDate > campaign.datCampaignDateEnd)
                {
                    throw new ValidationModelException("msgCampaignSessionDatesConflict", "idfCampaign", "idfCampaign", new string[] { "Error" }, null, false);
                }

                if (!AsSession.ValidateCampaignToSessionDiseasesRules(this, campaign))
                {
                    throw new ValidationModelException("AsSession_WrongCampaignAssignment", "idfCampaign", "idfCampaign", new string[] { "Confirmation" }, null, false);
                }            

                this.CampaignInRamOnly = campaign;

                AsSession.CopyDiseasesFromCampaignToSession(manager, this, campaign);  

                foreach (var prop in populateCampaign)
                    if (campaign.GetValue(prop) != null)
                        this.SetValue(prop, campaign.GetValue(prop).ToString());

                blnForceCampaignAssignment = false;
            }

            return true;
        }


        private static bool NewSummaryItemIsValid(AsSession session, AsSessionSummary item)
        {
            //check dates
            if (item.datCollectionDate.HasValue)
            {
                if (session.datStartDate.HasValue && item.datCollectionDate < session.datStartDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", null, typeof(PredicateValidator), false);
                if (session.datEndDate.HasValue && item.datCollectionDate > session.datEndDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", null, typeof(PredicateValidator), false);
            }

            //check duplicates
            if (session.SummaryItems.Where(x => x.idfMonitoringSessionSummary != item.idfMonitoringSessionSummary && x.idfSpecies == item.idfSpecies && x.Diagnosis.Join(item.Diagnosis, a => a.idfsDiagnosis, b => b.idfsDiagnosis, (a, b) => a.idfsDiagnosis).Count() > 0).Count() > 0)
                throw new ValidationModelException("AsSession.SummaryItem.Duplicate_msgId", "datCollectionDate", "datCollectionDate", null, typeof(PredicateValidator), false);

            session.OnPropertyChanged(_str_SummaryItems);
            return true;
        }

        private static bool ASSamplesIsValid(AsSession session, AsSessionSample item)
        {
            if (item.datFieldCollectionDate.HasValue)
            {
                if (session.datStartDate.HasValue && item.datFieldCollectionDate < session.datStartDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", null, typeof(PredicateValidator), false);
                if (session.datEndDate.HasValue && item.datFieldCollectionDate > session.datEndDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", null, typeof(PredicateValidator), false);
            }

            session.OnPropertyChanged(_str_ASSamples);
            return true;
        }

        private static bool NewDiseaseValidation(AsSession session, AsSessionDisease item)
        {
            //check duplicates
            if (session.Diseases.Count(x=>x.idfMonitoringSessionToDiagnosis != item.idfMonitoringSessionToDiagnosis && x.idfsDiagnosis == item.idfsDiagnosis && x.idfsSpeciesType==item.idfsSpeciesType && !x.IsMarkedToDelete) > 0)
                throw new ValidationModelException("AsSession.Diseases.Duplicate_msgId", "idfsSpeciesType", "idfsSpeciesType", null, typeof(PredicateValidator), false);

            if (session.idfCampaign.HasValue && session.Parent == null && session.CampaignInRamOnly == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    session.CampaignInRamOnly = AsCampaign.Accessor.Instance(null).SelectByKey(manager, session.idfCampaign);
                }
            }

            if (    session.idfCampaign.HasValue
                && session.CampaignInRamOnly != null
                && session.CampaignInRamOnly.Diseases.Where(d => !d.IsMarkedToDelete).Count(d => d.idfsDiagnosis == item.idfsDiagnosis && (d.idfsSpeciesType == item.idfsSpeciesType || !d.idfsSpeciesType.HasValue)) == 0)
            {

                throw new ValidationModelException("msgCantAddSessionDiagnosis", "idfCampaign", "idfCampaign", new string[] { "Confirmation" }, null, false);
            }
            return true;
        }

        private static bool DetailsViewIsValid(AsSession session)
        {
            if (session.DetailsTableView.Count(d => !d.IsMarkedToDelete && d.idfsSpeciesType.HasValue && session.Diseases.Count(s => s.idfsSpeciesType == d.idfsSpeciesType && !s.IsMarkedToDelete) == 0) > 0 
                && session.Diseases.Count(d=>!d.IsMarkedToDelete) > 0 
                && session.Diseases.Count(d=>!d.IsMarkedToDelete && !d.idfsSpeciesType.HasValue) == 0)
            {
                var line = session.DetailsTableView.Where(d => session.Diseases.Count(s => s.idfsSpeciesType == d.idfsSpeciesType && !s.IsMarkedToDelete) == 0).FirstOrDefault();
                throw new ValidationModelException("AsSession.DetailsTableView.SpeciesIsNotInTheList", "idfAnimal", line.strSpeciesType, null, typeof(PredicateValidator), false);
            }
            if (session.DetailsTableView
                .Where(x=>!x.IsMarkedToDelete)
                .GroupBy(x=>new 
                            {
                                idfFarm = x.idfFarm,
                                idfAnimal = x.idfAnimal, 
                                idfsSpecimentType = x.idfsSpecimenType, 
                                strFieldBarCode = x.strFieldBarcode.ToLower()})
                .Count(g=>g.Count() > 1) > 0 )
            {
                throw new ValidationModelException("AsSession.DetailsTableView.DuplicateSample", "idfAnimal", "idfAnimal", null, typeof(PredicateValidator), false);
            }
            return true;
        }

        public static bool NewTableItemIsValid(AsSession session, AsSessionTableViewItem item)
        {
            if (!item.idfMaterial.HasValue 
                && session.DetailsTableView.Where(i => i != item && i.idfFarm == item.idfFarm && i.idfAnimal == item.idfAnimal && !i.idfMaterial.HasValue).Count() > 0)
            {
                throw new ValidationModelException("AsSession.DetailsTableView.DuplicateAnimalWithoutSample", "idfAnimal", "idfAnimal", null, typeof(PredicateValidator), false);
            }

            if (session.Diseases.Count(x => (x.idfsSpeciesType == item.idfsSpeciesType || !x.idfsSpeciesType.HasValue) && !x.IsMarkedToDelete) == 0 
                && session.Diseases.Count(x => !x.IsMarkedToDelete) > 0                 
                && item.idfsSpeciesType.HasValue)
            {
                throw new ValidationModelException("AsSession.DetailsTableView.SpeciesIsNotInTheList", "idfAnimal", "idfAnimal", null, typeof(PredicateValidator), false);
            }

            if (session.DetailsTableView.Count(x => x.idfsSpecimenType == item.idfsSpecimenType 
                && x.idfAnimal == item.idfAnimal
                && x.strFieldBarcode.Equals(item.strFieldBarcode, StringComparison.InvariantCultureIgnoreCase)) > 1)
            {
                throw new ValidationModelException("AsSession.DetailsTableView.DuplicateSample", "idfAnimal", "idfAnimal", null, typeof(PredicateValidator), false);
            }

            session.OnPropertyChanged("DetailsTableView.Count");
            return true;
        }

        public static bool CheckFarmInSession(AsSession session, long? idfFarmRoot, out FarmPanel farm)
        {
            if (session.ASFarms.Where(x => x.idfRootFarm == idfFarmRoot).Count() > 0)
            {
                farm = session.ASFarms.Where(x => x.idfRootFarm == idfFarmRoot).First().Farm;
                return true;
            }
            else
            {
                farm = null;
                return false;
            }
        }

        public long GetNewFarmForChild(long idfFarmRoot, long? idfFarm)
        {           
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var accessor = FarmPanel.Accessor.Instance(null);

                if (idfFarm.HasValue && idfFarm.Value > 0)
                {
                    //RefreshFarm(idfFarmRoot, idfFarm.Value);
                    var farm = accessor.SelectByKey(manager, idfFarm, (int)HACode.Livestock);
                    this.ASFarms.RemoveAll(x => x.idfFarm == idfFarm);
                    this.ASFarms.Add(AsSessionFarm.Accessor.Instance(null).CreateFarm(manager, this, farm));

                    this.ASSpecies.RemoveAll(x => x.idfFarm == idfFarm);
                    this.ASSpecies.AddRange(AsSessionFarmSpeciesListItem.Accessor.Instance(null).SelectList(manager, this.idfMonitoringSession, farm.idfFarm));

                    return idfFarm.Value;
                }

                
                if (this.ASFarms.Where(f => f.idfRootFarm == idfFarmRoot).Count() == 0)
                {
                    var farm = FarmPanel.LivestockFarmFromRoot(idfFarmRoot, idfMonitoringSession);

                    this.ASFarms.Add(AsSessionFarm.Accessor.Instance(null).CreateFarm(manager, this, farm));      

                    var farmSpecies = AsSessionFarmSpeciesListItem.Accessor.Instance(null).SelectList(manager, this.idfMonitoringSession, farm.idfFarm);

                    foreach (var spec in farmSpecies)
                    {
                        if (this.ASSpecies.Count(s=>s.idfSpecies == spec.idfSpecies) == 0)
                            this.ASSpecies.Add(spec);
                    }
                    return farm.idfFarm;
                }
                else
                {
                    return this.ASFarms.Single(f => f.idfRootFarm == idfFarmRoot).idfFarm;
                }
            }
        }

        public void RefreshFarm(long idfFarmRoot, long idfFarm)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var accessor = FarmPanel.Accessor.Instance(null);
                var farm = FarmPanel.LivestockFarmRefreshFromRoot(idfFarmRoot, idfFarm);
                farm.idfMonitoringSession = this.idfMonitoringSession;

                this.ASFarms.RemoveAll(x => x.idfFarm == idfFarm);
                this.ASFarms.Add(AsSessionFarm.Accessor.Instance(null).CreateFarm(manager, this, farm));

                this.ASSpecies.RemoveAll(x => x.idfFarm == idfFarm);
                this.ASSpecies.AddRange(AsSessionFarmSpeciesListItem.Accessor.Instance(null).SelectList(manager, this.idfMonitoringSession, farm.idfFarm));
            }
        }

        private bool ValidationMessageForCases()
        {
            if (_strCreatedCases == NO_CASES_CREATED) return true;

            if (String.IsNullOrEmpty(_strCreatedCases) && _idfFarmForCaseCreation.HasValue && !IsDirty)
            {
               // _strCreatedCases = NO_CASES_CREATED;
               // _idfFarmForCaseCreation = null;
                if (Cases.Count(c=>c.idfRootFarm == ASFarms.Where(f=>f.idfFarm == _idfFarmForCaseCreation).First().idfRootFarm) > 0)
                    throw new ValidationModelException("msgFarmHasNoTestResults", "_strCreatedCases", "_strCreatedCases", null, typeof(PredicateValidator), false);
                else
                    throw new ValidationModelException("msgAsSessionNoCaseCreated", "_strCreatedCases", "_strCreatedCases", null, typeof(PredicateValidator), false);
            }
            else
                return true;
        }

        public void CreateDetailsCopy(long idfSample, byte number)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                AsSessionTableViewItem item = this.DetailsTableView.Single(x => x.id == idfSample);
                if (!item.idfAnimal.HasValue)
                    return;

                var accessor = AsSessionTableViewItem.Accessor.Instance(null);
                var materialAccessor = AsSessionSample.Accessor.Instance(null);

                List<AsSessionTableViewItem> copies = new List<AsSessionTableViewItem>();

                for (byte i = 0; i < number; i++)
                {
                    var newAnimal = AsSessionAnimal.Accessor.Instance(null).CreateAnimalCopy(manager, this, item.Animal);
                    //newAnimal.strAnimalCode = manager.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Animal, DBNull.Value, DBNull.Value)
                    //    .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue");
                    newAnimal.strAnimalCode = String.Format("(new {0})", (this.ASAnimals.Count + 1));
                    this.ASAnimals.Add(newAnimal);

                    foreach (var line in this.DetailsTableView.Where(t => t.idfAnimal == item.idfAnimal))
                    {

                        if (line.idfMaterial.HasValue)
                        {
                            var newSample = materialAccessor.CreateCopy(manager, this, line.Sample);
                            this.ASSamples.Add(newSample);

                            var newline = accessor.CreateCopy(manager, this, line, newAnimal.idfAnimal, newSample.idfMaterial);
                            copies.Add(newline);
                        }
                        else
                        {
                            copies.Add(accessor.CreateCopy(manager, this, line, newAnimal.idfAnimal, null));
                        }
                    }
                }
                this.DetailsTableView.AddRange(copies);
            }
        }


        public abstract partial class Accessor
        {
            private void SaveFarms(DbManagerProxy manager, AsSession obj)
            {
                if (obj.ASFarms.Count() > 0)
                {
                    obj.ASFarms.Where(f=>!f.IsMarkedToDelete).ToList().ForEach(farm => farm.Farm.idfMonitoringSession = obj.idfMonitoringSession);

                    //farms which are related to Summary records only have to be unlinked
                    var farmsToUnlink = obj.ASFarms.Where(farm =>
                      obj.DetailsTableView.Count(dt => !dt.IsMarkedToDelete && dt.idfFarm == farm.idfFarm) == 0
                      && obj.SummaryItems.Count(si => !si.IsMarkedToDelete && si.idfFarm == farm.idfFarm) > 0);

                    foreach (var f in farmsToUnlink)
                    {
                        manager
                        .SetSpCommand("spASFarm_Unlink", manager.Parameter("idfFarm", f.idfFarm))
                        .ExecuteNonQuery();

                        f.Farm.idfMonitoringSession = null;
                    }

                    //farms which are related to neither Details nor Summary records have to be deleted
                    var farmsToDelete = obj.ASFarms.Where(farm =>
                      obj.DetailsTableView.Count(dt => !dt.IsMarkedToDelete && dt.idfFarm == farm.idfFarm) == 0
                      && obj.SummaryItems.Count(si => !si.IsMarkedToDelete && si.idfFarm == farm.idfFarm) == 0);
                    foreach (var f in farmsToDelete)
                    {
                        manager
                        .SetSpCommand("spFarm_Delete", manager.Parameter("ID", f.idfFarm))
                        .ExecuteNonQuery();
                        f.MarkToDelete();
                    }

                    var _farmAccessor = FarmPanel.Accessor.Instance(null);

                    foreach (var farm in obj.ASFarms.Where(farm => !farm.IsMarkedToDelete))
                    {                        
                        _farmAccessor.Post(manager, farm.Farm);
                    }

                }
               
            }

            private void CreateCases(DbManagerProxy manager, AsSession obj)
            {
                if (obj._idfFarmForCaseCreation.HasValue)
                {
                    manager.SetSpCommand("spASSession_CreateCase",
                    manager.Parameter("idfFarm", obj._idfFarmForCaseCreation),
                    manager.OutputParameter("CasesList", DBNull.Value)).ExecuteNonQuery();
                    string cases = manager.Parameter("@CasesList").Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cases))
                    {
                        _LoadCases(obj);
                        obj._strCreatedCases = cases;
                    }
                    else
                        obj._strCreatedCases = string.Empty;

                    

                    obj._idfFarmForCaseCreation = null;
                }
            }

        }

    }
    
}
