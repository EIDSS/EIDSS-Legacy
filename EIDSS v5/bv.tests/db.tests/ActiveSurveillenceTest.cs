using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Schema;
using eidss.model.Enums;
using bv.model.Model.Core;


namespace bv.tests.db.tests
{
    /// <summary>
    /// Summary description for ActiveSurveillence
    /// </summary>
    [TestClass]
    public class ActiveSurveillenceTest : EidssEnvWithLogin
    {
        private AsCampaign.Accessor campaignAccessor;
        private AsSession.Accessor sessionAccessor;
        private AsCampaign campaign;
        private AsSession session;
        private AsSessionListItem.Accessor sessionListAccesor;
        private IEnumerable<AsSessionListItem> sessionList;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            campaignAccessor = AsCampaign.Accessor.Instance(null);
            campaign = campaignAccessor.CreateNewT(manager, null);
            Assert.IsNotNull(campaign);

            sessionAccessor = AsSession.Accessor.Instance(null);
            session = sessionAccessor.CreateNewT(manager, null);
            Assert.IsNotNull(session);

            sessionListAccesor = AsSessionListItem.Accessor.Instance(null);

        }

        [TestCleanup]
        public override void TestCleanup()
        {
            campaignAccessor = null;
            campaign = null;
            sessionAccessor = null;
            session = null;
            base.TestCleanup();
        }

        [TestMethod]
        public void ShortSession_CheckHandlers()
        {
            campaign.strCampaignName = "New Campaign";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            campaign.CampaignType = campaign.CampaignTypeLookup[1];

            session.Region = session.RegionLookup[1];
            sessionAccessor.Post(manager, session);
            if (campaign.ValidateSessionAssignment(session))
            {
                AsCampaign.AssignCampaignToSession(campaign, session);
            }

            Assert.AreEqual(1, campaign.Sessions.Count);
            campaignAccessor.Post(manager, campaign);

            campaign = campaignAccessor.SelectByKey(manager, campaign.idfCampaign);
            Assert.AreEqual(1, campaign.Sessions.Count);

            session = campaign.Sessions[0].FullSession;            

            session.Region = session.RegionLookup[3];
            session.Rayon = session.RayonLookup[1];
            session.Settlement = session.SettlementLookup[1];

            Assert.AreEqual(session.Region.ToString(), campaign.Sessions[0].strRegion);
            Assert.AreEqual(session.Rayon.ToString(), campaign.Sessions[0].strRayon);
            Assert.AreEqual(session.Settlement.ToString(), campaign.Sessions[0].strSettlement);
        }       
        
        [TestMethod]
        public void CampaignWithDiseases_AssignmentToEmptySession()
        {
            session.CampaignInRamOnly = CampaignWithDiseasesNoSpecies(campaign);
            session.idfCampaign = campaign.idfCampaign;

            Assert.AreEqual(session.idfCampaign, campaign.idfCampaign);
            Assert.AreEqual(session.strCampaignName, campaign.strCampaignName);
            Assert.AreEqual(session.Diseases.Count, campaign.Diseases.Count);

            Assert.AreEqual(5,session.Diseases.Count);
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void CampaignWithDiseases_AssignmentToSessionWithDiseases()
        {
            
            for (int i = 0; i < 5; i++)
            {
                AsSessionDisease disease = AsSessionDisease.Accessor.Instance(null).CreateNewT(manager, campaign);
                disease.idfMonitoringSession = session.idfMonitoringSession;
                disease.Diagnosis = disease.DiagnosisLookup[disease.DiagnosisLookup.Count - i - 1];
                session.Diseases.Add(disease);
            }

            session.Validation += AsSession_CampaignHasDifferentDiseasesList;
                        
            session.CampaignInRamOnly = CampaignWithDiseasesNoSpecies(campaign);
            Assert.AreEqual(5, campaign.Diseases.Count);            
            session.idfCampaign = campaign.idfCampaign;

            session.Validation -= AsSession_CampaignHasDifferentDiseasesList;
            
            Assert.IsNull(session.idfCampaign);            
        }

        [TestMethod]
        public void CampaignWithDiseases_AssignmentToSessionWithSubsetDiseases()
        {

            for (int i = 0; i < 3; i++)
            {
                AsSessionDisease disease = AsSessionDisease.Accessor.Instance(null).CreateNewT(manager, campaign);
                disease.idfMonitoringSession = session.idfMonitoringSession;
                disease.Diagnosis = disease.DiagnosisLookup[i];
                session.Diseases.Add(disease);
            }

            campaign = CampaignWithDiseasesNoSpecies(campaign); 
            Assert.AreEqual(5, campaign.Diseases.Count);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(campaign.Diseases[i].idfsDiagnosis, session.Diseases[i].idfsDiagnosis);
            }            
            
            session.CampaignInRamOnly = campaign;            
            session.idfCampaign = campaign.idfCampaign;            

            Assert.AreEqual(session.idfCampaign, campaign.idfCampaign);
            Assert.AreEqual(session.strCampaignName, campaign.strCampaignName);
        }

        [TestMethod]
        public void Campaign_RemoveSessions()
        {
            campaign.strCampaignName = "Thursday";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            campaign.CampaignType = campaign.CampaignTypeLookup[1];

            session = SelectSession(true);

            long idfsession = session.idfMonitoringSession;

            if (campaign.ValidateSessionAssignment(session))
            {
                AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
            }

            Assert.AreEqual(1, campaign.Sessions.Count);

            campaignAccessor.Post(manager, campaign);


            campaign = campaignAccessor.SelectByKey(manager, campaign.idfCampaign);
            Assert.AreEqual(1, campaign.Sessions.Count);

            campaign.Sessions[0].MarkToDelete();

            campaignAccessor.Post(manager, campaign);
            campaign = campaignAccessor.SelectByKey(manager, campaign.idfCampaign);

            Assert.AreEqual(0, campaign.Sessions.Count);

            session = sessionAccessor.SelectByKey(manager, idfsession);
            Assert.IsNull(session.idfCampaign);
        }

        [TestMethod]
        public void Campaign_SelectAndAddEmptySession()
        {
            campaign.strCampaignName = "Thursday";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            campaign.CampaignType = campaign.CampaignTypeLookup[1];

            session = SelectSession(true);

            if (campaign.ValidateSessionAssignment(session))
            {
                AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
            }

            Assert.AreEqual(1,campaign.Sessions.Count);

            campaignAccessor.Post(manager, campaign);


            campaign = campaignAccessor.SelectByKey(manager, campaign.idfCampaign);
            Assert.AreEqual(1, campaign.Sessions.Count);

        }

        [TestMethod]
        public void Campaign_SelectAndAddSessionWithDiseases()
        {
            campaign.strCampaignName = "Thursday";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            campaign.datCampaignDateStart = DateTime.Today.AddMonths(-2);
            campaign.datCampaignDateEnd = DateTime.Today.AddMonths(2);

            session = SelectSession(false);
            
            try
            {
                if (campaign.ValidateSessionAssignment(session))
                {
                    AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
                }
            }
            catch (ValidationModelException e)
            {
                Assert.AreEqual("errNotMatchSessionDiagnosis", e.MessageId);
            }            

            Assert.AreEqual(0, campaign.Sessions.Count);

            session = SelectSession(true);
            session.datStartDate = DateTime.Today.AddMonths(-3);

            try
            {
                if (campaign.ValidateSessionAssignment(session))
                {
                    AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
                }
            }
            catch (ValidationModelException e)
            {
                Assert.AreEqual("msgCampaignSessionDatesConflict", e.MessageId);
            }
            Assert.AreEqual(0, campaign.Sessions.Count);

            session.datStartDate = campaign.datCampaignDateStart;
            session.datEndDate = DateTime.Today.AddMonths(4);

            try
            {
                if (campaign.ValidateSessionAssignment(session))
                {
                    AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
                }
            }
            catch (ValidationModelException e)
            {
                Assert.AreEqual("msgCampaignSessionDatesConflict", e.MessageId);
            }

            Assert.AreEqual(0, campaign.Sessions.Count);

            session.datEndDate = DateTime.Today.AddMonths(1);
            if (campaign.ValidateSessionAssignment(session))
            {
                AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
            }

            Assert.AreEqual(1, campaign.Sessions.Count);

            session = SessionWithCampaign();
            try
            {
                if (campaign.ValidateSessionAssignment(session))
                {
                    AsCampaign.AssignCampaignToSession(campaign, session.idfMonitoringSession);
                }
            }
            catch (ValidationModelException e)
            {
                Assert.AreEqual("msgASSessionAlreadyBelongsToCampaign", e.MessageId);
            }
            Assert.AreEqual(1, campaign.Sessions.Count);

            campaignAccessor.Post(manager, campaign);            
        }

        [TestMethod]
        public void SessionWithCampaign_AddNewDiseases()
        {
            campaign = CampaignWithDiseasesNoSpecies(campaign);

            session.CampaignInRamOnly = campaign;
            session.idfCampaign = campaign.idfCampaign;

            Assert.AreEqual(session.idfCampaign, campaign.idfCampaign);
            Assert.AreEqual(session.strCampaignName, campaign.strCampaignName);

            Assert.AreEqual(5, session.Diseases.Count);

            AsSessionDisease disease = AsSessionDisease.Accessor.Instance(null).CreateNewT(manager, campaign);
            disease.idfMonitoringSession = session.idfMonitoringSession;
            disease.Diagnosis = disease.DiagnosisLookup[5];

            session.Validation += AsSession_DiagnosisNotInTheList;
            session.Diseases.Add(disease);
            session.Validation -= AsSession_DiagnosisNotInTheList;

            Assert.AreEqual(5, session.Diseases.Count);

            disease.Diagnosis = disease.DiagnosisLookup[1];

            session.Validation += AsSession_DiagnosisDuplicate;
            session.Diseases.Add(disease);
            session.Validation -= AsSession_DiagnosisDuplicate;

            Assert.AreEqual(5, session.Diseases.Count);

            disease.SpeciesType = disease.SpeciesTypeLookup[1];
            session.Diseases.Add(disease);

            Assert.AreEqual(6, session.Diseases.Count);
        }

        [TestMethod]
        public void Campaign_PostWithNewSession()
        {
            campaign.strCampaignName = "New Campaign";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            campaign.CampaignType = campaign.CampaignTypeLookup[1];

            session.Region = session.RegionLookup[1];
            sessionAccessor.Post(manager, session);

            if (campaign.ValidateSessionAssignment(session))
            {
                AsCampaign.AssignCampaignToSession(campaign, session);
            }

            Assert.AreEqual(1, campaign.Sessions.Count);
            campaignAccessor.Post(manager, campaign);

            campaign = campaignAccessor.SelectByKey(manager, campaign.idfCampaign);
            Assert.AreEqual(1, campaign.Sessions.Count);

            session = sessionAccessor.SelectByKey(manager, campaign.Sessions[0].idfMonitoringSession);
            Assert.AreEqual(session.strCampaignName, campaign.strCampaignName);

        }

        private void AsSession_DiagnosisNotInTheList(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("msgCantAddSessionDiagnosis", args.MessageId);
        }

        private void AsSession_DiagnosisDuplicate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("AsSession.Diseases.Duplicate_msgId", args.MessageId);
        }

        private AsCampaign CampaignWithDiseasesNoSpecies(AsCampaign campaign)
        {
            campaign.strCampaignName = "Initial Campaign";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            
            if (campaign == null)
            {
                campaign = campaignAccessor.CreateNewT(manager, null);
            }

            for (int i = 0; i < 5; i++)
            {
                AsDisease disease = AsDisease.Accessor.Instance(null).CreateNewT(manager, campaign);
                disease.idfCampaign = campaign.idfCampaign;
                disease.Diagnosis = disease.DiagnosisLookup[i];
                campaign.Diseases.Add(disease);
            }
            return campaign;
        }
        private AsSession SelectSession(bool empty)
        {
            if (sessionList == null)
            {
                CreateSessions();

                sessionList = sessionListAccesor.SelectListT(manager, null)
                    .Where(x => !x.idfsCampaignType.HasValue && String.IsNullOrEmpty(x.strDisease));
            }
            long? sessionId = null;

            AsSession result = null;
            foreach (var sl in sessionList.Where(x => !x.idfsCampaignType.HasValue).OrderByDescending(s => s.strCampaignName))
            {
                sessionId = sl.idfMonitoringSession;

                result = sessionAccessor.SelectByKey(manager, sessionId);

                if ((result.Diseases.Count == 0 && empty) || (result.Diseases.Count > 0 && !empty))
                    break;
            }
            return result;
        }
        
        private void AsSession_CampaignHasDifferentDiseasesList(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("AsSession_WrongCampaignAssignment", args.MessageId);
        }

        private void AsSession_HasDiseaseList(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("errNotMatchSessionDiagnosis", args.MessageId);
        }

        private void AsSession_HasBiggerPeriod(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("msgCampaignSessionDatesConflict", args.MessageId);
        }

        private void AsSession_HasCampaignAlready(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("msgCampaignSessionDatesConflict", args.MessageId);
        }

        private void CreateSessions()
        {
            AsSession assession = null;
            for (int i = 0; i < 10; i++)
            {
                assession = sessionAccessor.CreateNewT(manager, null);
                assession.Region = assession.RegionLookup[1];
                if (i % 2 == 0)
                {
                    AsSessionDisease disease = AsSessionDisease.Accessor.Instance(null).CreateNewT(manager, assession);
                    disease.Diagnosis = disease.DiagnosisLookup[i+1];
                    disease.SpeciesType = disease.SpeciesTypeLookup[i+1];
                    disease.idfMonitoringSession = assession.idfMonitoringSession;
                    assession.Diseases.Add(disease);
                }
                sessionAccessor.Post(manager, assession);
            }
        }

        private AsSession SessionWithCampaign()
        {
            AsCampaign campaign = campaignAccessor.CreateNewT(manager, null);

            campaign.strCampaignName = "New Campaign";
            campaign.idfsCampaignStatus = (long)AsCampaignStatus.Open;
            campaign.CampaignType = campaign.CampaignTypeLookup[1];

            campaign.Validation += campaign_validation;
            campaignAccessor.Post(manager, campaign);
            campaign.Validation -= campaign_validation;

            AsSession result = sessionAccessor.CreateNewT(manager, null);            
            result.idfCampaign = campaign.idfCampaign;
            result.Region = result.RegionLookup[1];
            sessionAccessor.Post(manager, result);
            
            return result;
        }

        private void campaign_validation(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("msgCampaignSessionDatesConflict", args.MessageId);
        }

    }
}
