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
using bv.common.Core;
using bv.model.Helpers;
using System.Diagnostics;

namespace eidss.model.Schema
{
    public partial class AsSessionDisease
    {
        public bool ValidateOnDelete()
        {
            return _ValidateOnDelete();
        }

        public bool DeleteNoValidate(bool isForceDelete)
        {
            //if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
    }

    public partial class AsSession
    {
        /*public static void Check(object fromModelStorage, object fromParent)
        {
            if (fromModelStorage is AsSession && fromParent is AsSessionDisease)
            {
                if (!ReferenceEquals(fromModelStorage, (fromParent as AsSessionDisease).Parent))
                {
                    Debugger.Break();
                }
            }
            if (fromModelStorage is AsSession && fromParent is AsSessionAnimalSample)
            {
                if (!ReferenceEquals(fromModelStorage, (fromParent as AsSessionAnimalSample).Parent))
                {
                    Debugger.Break();
                }
                if (!ReferenceEquals(fromModelStorage, ((AsSession)(fromParent as AsSessionAnimalSample).Parent).Diseases[0].Parent))
                {
                    Debugger.Break();
                }
            }
        }*/

        public const string NO_CASES_CREATED = "NO CASES YET";

        #region campaign
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
                                // this rule is wrong - see bug #13095
                                /*var commonDiseaseNoSpecies = session.Diseases.Where(x => !x.IsMarkedToDelete && x.idfsSpeciesType.HasValue)
                                    .Join(campaign.Diseases.Where(d=>!d.IsMarkedToDelete && !d.idfsSpeciesType.HasValue),
                                        s => s.idfsDiagnosis,
                                        c => c.idfsDiagnosis,
                                        (s,c) => s.idfsDiagnosis)
                                    .Count();

                                if (commonDiseaseNoSpecies != session.Diseases.Count(d => !d.IsMarkedToDelete) - commonDiseasesWithSpecies)
                                {*/
                                    return false;
                                /*}*/
                            //}
                            //else
                            //{
                            //    return false;
                            //}
                        }                        
                }
                return true;
        }

        public static bool ValidateCheckToDeleteDiagnosis(AsSession session, AsCampaign campaign)
        {
            foreach (AsSessionDisease d in session.Diseases.Where(x => !x.IsMarkedToDelete 
                && !campaign.Diseases.Any(y => !y.IsMarkedToDelete && y.idfsDiagnosis == x.idfsDiagnosis && y.idfsSpeciesType == x.idfsSpeciesType)
                && !campaign.Diseases.Any(y => !y.IsMarkedToDelete && y.idfsDiagnosis == x.idfsDiagnosis && !y.idfsSpeciesType.HasValue)
                ))
            {
                if (!d.ValidateOnDelete())
                    return false;
            }
            return true;
        }

        public static bool ValidateCheckAnimalSampleList(AsSession session, AsCampaign campaign)
                {
            foreach(var item in session.ASAnimalsSamples.Where(x => !x.IsMarkedToDelete))
                    {
                if (item.idfsSampleType.HasValue)
                {
                    if (!campaign.Diseases.Any(x => !x.IsMarkedToDelete && (x.idfsSpeciesType == item.idfsSpeciesType || !x.idfsSpeciesType.HasValue) && (x.idfsSampleType == item.idfsSampleType || !x.idfsSampleType.HasValue)))
                        return false;
                    }
                else
                {
                    if (!campaign.Diseases.Any(x => !x.IsMarkedToDelete && (x.idfsSpeciesType == item.idfsSpeciesType || !x.idfsSpeciesType.HasValue)))
                        return false;
                }
        }

            foreach (var item in session.SummaryItems.Where(x => !x.IsMarkedToDelete))
        {
                foreach (var s in item.Samples.Where(x => !x.IsMarkedToDelete && x.blnChecked.HasValue && x.blnChecked.Value))
            {
                    if (!campaign.Diseases.Any(x => !x.IsMarkedToDelete && (x.idfsSpeciesType == item.idfsSpeciesType || !x.idfsSpeciesType.HasValue) && (x.idfsSampleType == s.idfsSampleType || !x.idfsSampleType.HasValue)))
                        return false;

                    if (!campaign.Diseases.Any(x => !x.IsMarkedToDelete && (x.idfsSpeciesType == item.idfsSpeciesType || !x.idfsSpeciesType.HasValue)))
                    return false;
            }
            }

            return true;
        }


        public static void CopyDiseasesFromCampaignToSession(DbManagerProxy manager, AsSession session, AsCampaign campaign)
        {
            foreach (var sessionDisease in session.Diseases.Where(d => !d.IsMarkedToDelete))
            {
                sessionDisease.DeleteNoValidate(false);
            }

            if (campaign.Diseases.Count(x => !x.IsMarkedToDelete) > 0 && session.Diseases.Count(x => !x.IsMarkedToDelete) == 0)
            {
                AsSessionDisease item = null;

                foreach (var campaignDisease in campaign.Diseases.Where(d => !d.IsMarkedToDelete))
                {
                    item = (AsSessionDisease)AsSessionDisease.Accessor.Instance(null).CreateNew(manager, session);
                    item.idfMonitoringSession = session.idfMonitoringSession;
                    //item.idfsDiagnosis = campaignDisease.idfsDiagnosis;
                    //item.idfsSpeciesType = campaignDisease.idfsSpeciesType;
                    item.Diagnosis = item.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == campaignDisease.idfsDiagnosis);
                    item.SpeciesType = item.SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == campaignDisease.idfsSpeciesType);
                    item.SampleType = item.SampleTypeLookup.FirstOrDefault(c => c.idfsReference == campaignDisease.idfsSampleType);
                    session.Diseases.Add(item);
                }

            }             
        }

        public AsCampaign CampaignInRamOnly
        {
            get 
            {
                if (!b_stackOverflowPreventer)
                {
                    b_stackOverflowPreventer = true;
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var saveCampaign = m_CampaignInRamOnly;
                        m_CampaignInRamOnly = idfCampaign.HasValue ?
                            (
                                (m_CampaignInRamOnly == null || m_CampaignInRamOnly.idfCampaign != idfCampaign)
                                ? AsCampaign.Accessor.Instance(null).SelectByKey(manager, idfCampaign)
                                : m_CampaignInRamOnly)
                            : null;
                        if (saveCampaign == null && m_CampaignInRamOnly != null ||
                            saveCampaign != null && m_CampaignInRamOnly == null ||
                            saveCampaign != null && m_CampaignInRamOnly != null && saveCampaign.idfCampaign != m_CampaignInRamOnly.idfCampaign)
                        {
                            Diseases.Where(i => !i.IsMarkedToDelete).ToList().ForEach(i =>
                            {
                                var acc = AsSessionDisease.Accessor.Instance(null);
                                acc.LoadLookup_Diagnosis(manager, i);
                                acc.LoadLookup_SpeciesType(manager, i);
                                acc.LoadLookup_SampleType(manager, i);
                            });
                        }
                    }
                    b_stackOverflowPreventer = false;
                }
                return m_CampaignInRamOnly; 
            }
            //set { if (m_CampaignInRamOnly != value) { m_CampaignInRamOnly = value; OnPropertyChanged("CampaignInRamOnly"); } }
            }             
        private AsCampaign m_CampaignInRamOnly;
        private bool b_stackOverflowPreventer;
        public void SetCampaignForTest(AsCampaign campaign)
        {
            if (m_CampaignInRamOnly != campaign) { m_CampaignInRamOnly = campaign; OnPropertyChanged("CampaignInRamOnly"); }
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

                var campaign = CampaignInRamOnly;
                    /*(CampaignInRamOnly == null || CampaignInRamOnly.idfCampaign != idfCampaign)
                    ? (AsCampaign)acc.SelectByKey(manager, this.idfCampaign)
                    : CampaignInRamOnly;*/


                if (campaign.idfsCampaignStatus != (long)AsCampaignStatus.Open)
                    throw new ValidationModelException("msgCampaignIsNotOpen", "idfCampaign", "idfCampaign", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                //validate Disease List

                if (!DateHelper.ValidateDateInRange(datStartDate, campaign.datCampaignDateStart, campaign.datCampaignDateEnd) ||
                    !DateHelper.ValidateDateInRange(datEndDate, campaign.datCampaignDateStart, campaign.datCampaignDateEnd))
                {
                    throw new ValidationModelException("msgCampaignSessionDatesConflict", "idfCampaign", "idfCampaign", new object[] { datStartDate, datEndDate, campaign.datCampaignDateStart, campaign.datCampaignDateEnd, "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                }

                if (!AsSession.ValidateCheckAnimalSampleList(this, campaign))
                {
                    throw new ValidationModelException("msgCampaignDoesntContainDiagnosis", "idfCampaign", "idfCampaign", new object[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                }

                if (!AsSession.ValidateCheckToDeleteDiagnosis(this, campaign))
                {
                    throw new ValidationModelException("msgCampaignDoesntContainDiagnosis", "idfCampaign", "idfCampaign", new object[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                }

                if (!AsSession.ValidateCampaignToSessionDiseasesRules(this, campaign))
                {
                    try
                    {
                        throw new ValidationModelException("AsSession_WrongCampaignAssignment", "idfCampaign", "idfCampaign", new string[] { "Confirmation" }, typeof(PredicateValidator), ValidationEventType.Question, this);
                    }
                    catch (ValidationModelException ex)
                    {
                        if (!OnValidation(ex))
                        {
                            throw;
                        }

                    }
                }


                /*if (!AsSession.ValidateCampaignToSessionDiseasesStrongRules(this, campaign))
                {
                    throw new ValidationModelException("AsSession_CampaignAssignmentError", "idfCampaign", "idfCampaign", new object[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                }*/

                //this.CampaignInRamOnly = campaign;

                AsSession.CopyDiseasesFromCampaignToSession(manager, this, campaign);  

                foreach (var prop in populateCampaign)
                    if (campaign.GetValue(prop) != null)
                        this.SetValue(prop, campaign.GetValue(prop).ToString());

                blnForceCampaignAssignment = false;
            }

            return true;
        }
        #endregion

        #region validation
        private static bool NewSummaryItemIsValid(AsSession session, AsSessionSummary item)
        {
            //check dates
            if (item.datCollectionDate.HasValue)
            {
                if (session.datStartDate.HasValue && item.datCollectionDate < session.datStartDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", new object[] { item.datCollectionDate, session.datStartDate, session.datEndDate }, typeof(PredicateValidator), ValidationEventType.Error, session);
                if (session.datEndDate.HasValue && item.datCollectionDate > session.datEndDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", new object[] { item.datCollectionDate, session.datStartDate, session.datEndDate }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }

            //check duplicates
            // bug 10689
            //if (session.SummaryItems.Count(x => !x.IsMarkedToDelete && x.idfMonitoringSessionSummary != item.idfMonitoringSessionSummary && x.idfFarm == item.idfFarm && x.idfSpecies == item.idfSpecies && x.Diagnosis.Join(item.Diagnosis, a => a.idfsDiagnosis, b => b.idfsDiagnosis, (a, b) => a.idfsDiagnosis).Any()) > 0)
            //    throw new ValidationModelException("AsSession.SummaryItem.Duplicate_msgId", "", "", new string[] { "Error" }, typeof(PredicateValidator), false);

            session.OnPropertyChanged(_str_SummaryItems);
            return true;
        }


        private static bool ASSamplesIsValid(AsSession session, AsSessionAnimalSample item)
        {
            if (item.datFieldCollectionDate.HasValue)
            {
                if (session.datStartDate.HasValue && item.datFieldCollectionDate < session.datStartDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", new object[] { item.datFieldCollectionDate, session.datStartDate, session.datEndDate }, typeof(PredicateValidator), ValidationEventType.Error, session);
                if (session.datEndDate.HasValue && item.datFieldCollectionDate > session.datEndDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", new object[] { item.datFieldCollectionDate, session.datStartDate, session.datEndDate }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }

            session.OnPropertyChanged(_str_ASAnimalsSamples);
            return true;
        }
        

        internal static bool NewDiseaseValidation(AsSession session, AsSessionDisease item)
        {
            //check duplicates
            if (session.Diseases.Count(x => x.idfMonitoringSessionToDiagnosis != item.idfMonitoringSessionToDiagnosis && x.idfsDiagnosis == item.idfsDiagnosis && x.idfsSpeciesType == item.idfsSpeciesType && x.idfsSampleType == item.idfsSampleType && !x.IsMarkedToDelete) > 0)
                throw new ValidationModelException("AsSession.Diseases.Duplicate_msgId", "idfsSpeciesType", "idfsSpeciesType", null, typeof(PredicateValidator), ValidationEventType.Error, session);

            /*if (session.idfCampaign.HasValue && session.Parent == null && session.CampaignInRamOnly == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    session.CampaignInRamOnly = AsCampaign.Accessor.Instance(null).SelectByKey(manager, session.idfCampaign);
                }
            }*/

            if (    session.idfCampaign.HasValue
                && session.CampaignInRamOnly != null
                && session.CampaignInRamOnly.Diseases.Where(d => !d.IsMarkedToDelete).Count(d => d.idfsDiagnosis == item.idfsDiagnosis && (d.idfsSpeciesType == item.idfsSpeciesType || !d.idfsSpeciesType.HasValue) && (d.idfsSampleType == item.idfsSampleType || !d.idfsSampleType.HasValue)) == 0)
            {
                string diagnosis = item.Diagnosis.name;
                string sample = item.SampleType == null ? "" : ": " + Utils.InsertSeparator("/", item.SampleType.name);
                string species = item.SpeciesType == null ? "" : ": " + Utils.InsertSeparator("/", item.SpeciesType.name);
                throw new ValidationModelException("msgCantAddSessionDiagnosis", "idfCampaign", "idfCampaign", new object[] { diagnosis, species, sample }, null, ValidationEventType.Error, session);
            }
            return true;
        }

        
        private static bool DetailsViewIsValid(AsSession session)
        {
            if (session.ASAnimalsSamples.Count(d => !d.IsMarkedToDelete && d.idfsSpeciesType != 0 && session.Diseases.Count(s => s.idfsSpeciesType == d.idfsSpeciesType && !s.IsMarkedToDelete) == 0) > 0 
                && session.Diseases.Count(d=>!d.IsMarkedToDelete) > 0 
                && session.Diseases.Count(d=>!d.IsMarkedToDelete && !d.idfsSpeciesType.HasValue) == 0)
            {
                var line = session.ASAnimalsSamples.FirstOrDefault(d => session.Diseases.Count(s => s.idfsSpeciesType == d.idfsSpeciesType && !s.IsMarkedToDelete) == 0);
                throw new ValidationModelException("AsSession.DetailsTableView.SpeciesIsNotInTheList", "idfAnimal", line.strSpeciesType, new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }
            if (session.ASAnimalsSamples
                .Where(x => !x.IsMarkedToDelete && !Utils.IsEmpty(x.strFieldBarcode))
                .GroupBy(x => new 
                            {
                                idfAnimal = x.idfAnimal,
                                idfsSampletType = x.idfsSampleType,
                                strFieldBarCode = x.strFieldBarcode.ToLowerInvariant()
                            })
                .Count(g => g.Count() > 1) > 0 )
            {
                throw new ValidationModelException("AsSession.DetailsTableView.DuplicateSample", "idfAnimal", "idfAnimal", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }
            return true;
        }


        public static bool NewTableItemIsValid(AsSession session, AsSessionAnimalSample item)
        {
            if (!item.idfMaterial.HasValue
                && session.ASAnimalsSamples.Any(i => i != item && i.idfFarm == item.idfFarm && i.idfAnimal == item.idfAnimal && !i.idfMaterial.HasValue))
            {
                throw new ValidationModelException("AsSession.DetailsTableView.DuplicateAnimalWithoutSample", "idfAnimal", "idfAnimal", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }

            if (session.Diseases.Count(x => (x.idfsSpeciesType == item.idfsSpeciesType || !x.idfsSpeciesType.HasValue) && !x.IsMarkedToDelete) == 0 
                && session.Diseases.Count(x => !x.IsMarkedToDelete) > 0                 
                && item.idfsSpeciesType != 0)
            {
                throw new ValidationModelException("AsSession.DetailsTableView.SpeciesIsNotInTheList", "idfAnimal", "idfAnimal", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }

            if (session.ASAnimalsSamples.Count(x => !Utils.IsEmpty(x.strFieldBarcode) && !Utils.IsEmpty(item.strFieldBarcode)
                && x.idfsSampleType == item.idfsSampleType 
                && x.idfAnimal == item.idfAnimal
                && x.strFieldBarcode.Equals(item.strFieldBarcode, StringComparison.InvariantCultureIgnoreCase)) > 1)
            {
                throw new ValidationModelException("AsSession.DetailsTableView.DuplicateSample", "idfAnimal", "idfAnimal", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, session);
            }

            session.OnPropertyChanged("DetailsTableView.Count");
            return true;
        }
         
        private bool ValidationMessageForCases()
        {
            if (_strCreatedCases == NO_CASES_CREATED) return true;

            if (String.IsNullOrEmpty(_strCreatedCases) && _idfFarmForCaseCreation.HasValue && !IsDirty)
            {
                if (Cases.Count(c => c.idfRootFarm == ASFarmsDetails.First(f => f.idfFarm == _idfFarmForCaseCreation).idfRootFarm) > 0)
                    throw new ValidationModelException("msgFarmHasNoTestResults", "_strCreatedCases", "_strCreatedCases", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                else
                    throw new ValidationModelException("msgAsSessionNoCaseCreated", "_strCreatedCases", "_strCreatedCases", new string[] { "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
            }
            else
                return true;
        }

        private bool ValidationCampaignDates()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {
                var acc = AsCampaign.Accessor.Instance(null);
                var campaign = (AsCampaign)acc.SelectByKey(manager, this.idfCampaign);
                if (campaign == null)
                    return true;

                if (!DateHelper.ValidateDateInRange(datStartDate, campaign.datCampaignDateStart, campaign.datCampaignDateEnd) ||
                    !DateHelper.ValidateDateInRange(datEndDate, campaign.datCampaignDateStart, campaign.datCampaignDateEnd))
                {
                    throw new ValidationModelException("msgCampaignSessionDatesConflict", "idfCampaign", "idfCampaign", new object[] { datStartDate, datEndDate, campaign.datCampaignDateStart, campaign.datCampaignDateEnd, "Error" }, typeof(PredicateValidator), ValidationEventType.Error, this);
                }
                else
                    return true;
            }
        }

        #endregion

        public void SetParent()
        {
            _setParent();
        }

        public abstract partial class Accessor
        {
            public void CreateCases(DbManagerProxy manager, AsSession obj)
            {
                if (obj._idfFarmForCaseCreation.HasValue)
                {
                    manager.SetSpCommand("spASSession_CreateCase",
                    manager.Parameter("idfFarm", obj._idfFarmForCaseCreation),
                    manager.Parameter("idfPersonEnteredBy", obj.idfPersonEnteredBy),
                    manager.OutputParameter("CasesList", DBNull.Value)).ExecuteNonQuery();
                    string cases = manager.Parameter("@CasesList").Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cases))
                    {
                        _LoadCases(obj);
                        _LoadCaseTestValidations(obj);
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
