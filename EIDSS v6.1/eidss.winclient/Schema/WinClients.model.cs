
    using System;
    using System.Text;
    using System.IO;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;
    using bv.winclient.BasePanel;
    using eidss.model.Schema;

    namespace eidss.winclient.Schema
    {
    
      public partial class BaseListPanel_VetCaseListItem : BaseListPanel<VetCaseListItem>
      {
      
        public BaseListPanel_VetCaseListItem() : base()
        {
          FormID = "V01";
        }
      
      
      }
    
      public partial class BaseDetailPanel_VetCase : BaseDetailPanel<VetCase>
      {
      
        public BaseDetailPanel_VetCase() : base()
        {
          m_RelatedLists = new string[]{"VetCaseListItem"};
        
          FormID = "V02";
        }
      
      
      }
    
      public partial class BaseListPanel_HumanCaseListItem : BaseListPanel<HumanCaseListItem>
      {
      
        public BaseListPanel_HumanCaseListItem() : base()
        {
          FormID = "H01";
        }
      
      
      }
    
      public partial class BaseDetailPanel_HumanCase : BaseDetailPanel<HumanCase>
      {
      
        public BaseDetailPanel_HumanCase() : base()
        {
          m_RelatedLists = new string[]{"HumanCaseListItem"};
        
          FormID = "H02";
        }
      
      
      }
    
      public partial class BaseListPanel_OutbreakListItem : BaseListPanel<OutbreakListItem>
      {
      
        public BaseListPanel_OutbreakListItem() : base()
        {
          FormID = "C10";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Outbreak : BaseDetailPanel<Outbreak>
      {
      
        public BaseDetailPanel_Outbreak() : base()
        {
          m_RelatedLists = new string[]{"OutbreakListItem"};
        
          FormID = "C11";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Address : BaseDetailPanel<Address>
      {
      
        public BaseDetailPanel_Address() : base()
        {
          m_RelatedLists = new string[]{"AddressListItem"};
        
          FormID = "";
        }
      
      
      }
    
      public partial class BaseListPanel_PatientListItem : BaseListPanel<PatientListItem>
      {
      
        public BaseListPanel_PatientListItem() : base()
        {
          FormID = "H03";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Patient : BaseDetailPanel<Patient>
      {
      
        public BaseDetailPanel_Patient() : base()
        {
          m_RelatedLists = new string[]{"PatientListItem"};
        
          FormID = "H04";
        }
      
      
      }
    
      public partial class BaseListPanel_VsSessionListItem : BaseListPanel<VsSessionListItem>
      {
      
        public BaseListPanel_VsSessionListItem() : base()
        {
          FormID = "W01";
        }
      
      
      }
    
      public partial class BaseDetailPanel_VsSession : BaseDetailPanel<VsSession>
      {
      
        public BaseDetailPanel_VsSession() : base()
        {
          m_RelatedLists = new string[]{"VsSessionListItem"};
        
          FormID = "W02";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Vector : BaseDetailPanel<Vector>
      {
      
        public BaseDetailPanel_Vector() : base()
        {
          m_RelatedLists = new string[]{"VectorListItem"};
        
          FormID = "W03";
        }
      
      
      }
    
      public partial class BaseListPanel_LabBatchListItem : BaseListPanel<LabBatchListItem>
      {
      
        public BaseListPanel_LabBatchListItem() : base()
        {
          FormID = "L21";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LabBatch : BaseDetailPanel<LabBatch>
      {
      
        public BaseDetailPanel_LabBatch() : base()
        {
          m_RelatedLists = ("LabTestListItem,LabBatchListItem").Split(',');
        
          FormID = "L22";
        }
      
      
      }
    
      public partial class BaseListPanel_LabTestListItem : BaseListPanel<LabTestListItem>
      {
      
        public BaseListPanel_LabTestListItem() : base()
        {
          FormID = "L03";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LabTest : BaseDetailPanel<LabTest>
      {
      
        public BaseDetailPanel_LabTest() : base()
        {
          m_RelatedLists = new string[]{"LabTestListItem"};
        
          FormID = "L04";
        }
      
      
      }
    
      public partial class BaseListPanel_LabSampleListItem : BaseListPanel<LabSampleListItem>
      {
      
        public BaseListPanel_LabSampleListItem() : base()
        {
          FormID = "L01";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LabSample : BaseDetailPanel<LabSample>
      {
      
        public BaseDetailPanel_LabSample() : base()
        {
          m_RelatedLists = new string[]{"LabSampleListItem"};
        
          FormID = "L02";
        }
      
      
      }
    
      public partial class BaseListPanel_AsSessionListItem : BaseListPanel<AsSessionListItem>
      {
      
        public BaseListPanel_AsSessionListItem() : base()
        {
          FormID = "V17";
        }
      
      
      }
    
      public partial class BaseDetailPanel_AsSession : BaseDetailPanel<AsSession>
      {
      
        public BaseDetailPanel_AsSession() : base()
        {
          m_RelatedLists = new string[]{"AsSessionListItem"};
        
          FormID = "V18";
        }
      
      
      }
    
      public partial class BaseListPanel_AsCampaignListItem : BaseListPanel<AsCampaignListItem>
      {
      
        public BaseListPanel_AsCampaignListItem() : base()
        {
          FormID = "V15";
        }
      
      
      }
    
      public partial class BaseDetailPanel_AsCampaign : BaseDetailPanel<AsCampaign>
      {
      
        public BaseDetailPanel_AsCampaign() : base()
        {
          m_RelatedLists = new string[]{"AsCampaignListItem"};
        
          FormID = "V16";
        }
      
      
      }
    
      public partial class BaseGroupPanel_Vector : BaseGroupPanel<Vector>
      {
      
      
      }
    
      public partial class BaseGroupPanel_VectorSample : BaseGroupPanel<VectorSample>
      {
      
      
      }
    
      public partial class BaseListPanel_LabSampleTransferListItem : BaseListPanel<LabSampleTransferListItem>
      {
      
        public BaseListPanel_LabSampleTransferListItem() : base()
        {
          FormID = "L09";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LabSampleTransfer : BaseDetailPanel<LabSampleTransfer>
      {
      
        public BaseDetailPanel_LabSampleTransfer() : base()
        {
          m_RelatedLists = new string[]{"LabSampleTransferListItem"};
        
          FormID = "L08";
        }
      
      
      }
    
      public partial class BaseListPanel_LabSampleDispositionListItem : BaseListPanel<LabSampleDispositionListItem>
      {
      
        public BaseListPanel_LabSampleDispositionListItem() : base()
        {
          FormID = "L07";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LabSampleDisposition : BaseDetailPanel<LabSampleDisposition>
      {
      
        public BaseDetailPanel_LabSampleDisposition() : base()
        {
          m_RelatedLists = new string[]{"LabSampleDispositionListItem"};
        
          FormID = "L10";
        }
      
      
      }
    
      public partial class BaseDetailPanel_GeoLocation : BaseDetailPanel<GeoLocation>
      {
      
        public BaseDetailPanel_GeoLocation() : base()
        {
          m_RelatedLists = new string[]{"GeoLocationListItem"};
        
          FormID = "";
        }
      
      
      }
    
      public partial class BaseDetailPanel_VectorTypeReferenceMaster : BaseDetailPanel<VectorTypeReferenceMaster>
      {
      
        public BaseDetailPanel_VectorTypeReferenceMaster() : base()
        {
          m_RelatedLists = new string[]{"VectorTypeReferenceMasterListItem"};
        
          FormID = "A33";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_VectorTypeReference : BaseGroupPanel<VectorTypeReference>
      {
      
      
      }
    
      public partial class BaseListPanel_RepositorySchemeListItem : BaseListPanel<RepositorySchemeListItem>
      {
      
        public BaseListPanel_RepositorySchemeListItem() : base()
        {
          FormID = "L11";
        }
      
      
      }
    
      public partial class BaseDetailPanel_RepositoryScheme : BaseDetailPanel<RepositoryScheme>
      {
      
        public BaseDetailPanel_RepositoryScheme() : base()
        {
          m_RelatedLists = new string[]{"RepositorySchemeListItem"};
        
          FormID = "L12";
        }
      
      
      }
    
      public partial class BaseListPanel_OrganizationListItem : BaseListPanel<OrganizationListItem>
      {
      
        public BaseListPanel_OrganizationListItem() : base()
        {
          FormID = "A06";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Personnel : BaseDetailPanel<Personnel>
      {
      
        public BaseDetailPanel_Personnel() : base()
        {
          m_RelatedLists = new string[]{"PersonnelListItem"};
        
          FormID = "A07";
        }
      
      
      }
    
      public partial class BaseListPanel_PersonListItem : BaseListPanel<PersonListItem>
      {
      
        public BaseListPanel_PersonListItem() : base()
        {
          FormID = "A08";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Person : BaseDetailPanel<Person>
      {
      
        public BaseDetailPanel_Person() : base()
        {
          m_RelatedLists = new string[]{"PersonListItem"};
        
          FormID = "A09";
        }
      
      
      }
    
      public partial class BaseListPanel_UserGroupListItem : BaseListPanel<UserGroupListItem>
      {
      
        public BaseListPanel_UserGroupListItem() : base()
        {
          FormID = "A39";
        }
      
      
      }
    
      public partial class BaseDetailPanel_UserGroupDetail : BaseDetailPanel<UserGroupDetail>
      {
      
        public BaseDetailPanel_UserGroupDetail() : base()
        {
          m_RelatedLists = ("UserGroupListItem").Split(',');
        
          FormID = "A40";
        }
      
      
      }
    
      public partial class BaseListPanel_UsersAndGroupsListItem : BaseListPanel<UsersAndGroupsListItem>
      {
      
        public BaseListPanel_UsersAndGroupsListItem() : base()
        {
          FormID = "A17";
        }
      
      
      }
    
      public partial class BaseGroupPanel_UserGroupMember : BaseGroupPanel<UserGroupMember>
      {
      
      
      }
    
      public partial class BaseListPanel_SiteActivationServerListItem : BaseListPanel<SiteActivationServerListItem>
      {
      
        public BaseListPanel_SiteActivationServerListItem() : base()
        {
          FormID = "A13";
        }
      
      
      }
    
      public partial class BaseDetailPanel_SiteActivationServer : BaseDetailPanel<SiteActivationServer>
      {
      
        public BaseDetailPanel_SiteActivationServer() : base()
        {
          m_RelatedLists = new string[]{"SiteActivationServerListItem"};
        
          FormID = "A14";
        }
      
      
      }
    
      public partial class BaseListPanel_SecurityEventLogListItem : BaseListPanel<SecurityEventLogListItem>
      {
      
        public BaseListPanel_SecurityEventLogListItem() : base()
        {
          FormID = "S06";
        }
      
      
      }
    
      public partial class BaseDetailPanel_SecurityEventLog : BaseDetailPanel<SecurityEventLog>
      {
      
        public BaseDetailPanel_SecurityEventLog() : base()
        {
          m_RelatedLists = new string[]{"SecurityEventLogListItem"};
        
          FormID = "S07";
        }
      
      
      }
    
      public partial class BaseListPanel_EventLogListItem : BaseListPanel<EventLogListItem>
      {
      
        public BaseListPanel_EventLogListItem() : base()
        {
          FormID = "S01";
        }
      
      
      }
    
      public partial class BaseDetailPanel_EventLog : BaseDetailPanel<EventLog>
      {
      
        public BaseDetailPanel_EventLog() : base()
        {
          m_RelatedLists = new string[]{"EventLogListItem"};
        
          FormID = "S01";
        }
      
      
      }
    
      public partial class BaseListPanel_NextNumbersListItem : BaseListPanel<NextNumbersListItem>
      {
      
        public BaseListPanel_NextNumbersListItem() : base()
        {
          FormID = "C07";
        }
      
      
      }
    
      public partial class BaseDetailPanel_NextNumbers : BaseDetailPanel<NextNumbers>
      {
      
        public BaseDetailPanel_NextNumbers() : base()
        {
          m_RelatedLists = new string[]{"NextNumbersListItem"};
        
          FormID = "C08";
        }
      
      
      }
    
      public partial class BaseListPanel_StatisticListItem : BaseListPanel<StatisticListItem>
      {
      
        public BaseListPanel_StatisticListItem() : base()
        {
          FormID = "C12";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Statistic : BaseDetailPanel<Statistic>
      {
      
        public BaseDetailPanel_Statistic() : base()
        {
          m_RelatedLists = new string[]{"StatisticListItem"};
        
          FormID = "C13";
        }
      
      
      }
    
      public partial class BaseListPanel_SettlementListItem : BaseListPanel<SettlementListItem>
      {
      
        public BaseListPanel_SettlementListItem() : base()
        {
          FormID = "C15";
        }
      
      
      }
    
      public partial class BaseDetailPanel_Settlement : BaseDetailPanel<Settlement>
      {
      
        public BaseDetailPanel_Settlement() : base()
        {
          m_RelatedLists = new string[]{"SettlementListItem"};
        
          FormID = "C16";
        }
      
      
      }
    
      public partial class BaseListPanel_DataAuditListItem : BaseListPanel<DataAuditListItem>
      {
      
        public BaseListPanel_DataAuditListItem() : base()
        {
          FormID = "A24";
        }
      
      
      }
    
      public partial class BaseDetailPanel_DataAudit : BaseDetailPanel<DataAudit>
      {
      
        public BaseDetailPanel_DataAudit() : base()
        {
          m_RelatedLists = new string[]{"DataAuditListItem"};
        
          FormID = "A25";
        }
      
      
      }
    
      public partial class BaseListPanel_HumanAggregateCaseListItem : BaseListPanel<HumanAggregateCaseListItem>
      {
      
        public BaseListPanel_HumanAggregateCaseListItem() : base()
        {
          FormID = "H15";
        }
      
      
      }
    
      public partial class BaseListPanel_FarmListItem : BaseListPanel<FarmListItem>
      {
      
        public BaseListPanel_FarmListItem() : base()
        {
          FormID = "V04";
        }
      
      
      }
    
      public partial class BaseDetailPanel_FarmRoot : BaseDetailPanel<FarmRoot>
      {
      
        public BaseDetailPanel_FarmRoot() : base()
        {
          m_RelatedLists = ("FarmListItem").Split(',');
        
          FormID = "V05";
        }
      
      
      }
    
      public partial class BaseDetailPanel_FarmPanel : BaseDetailPanel<FarmPanel>
      {
      
        public BaseDetailPanel_FarmPanel() : base()
        {
          m_RelatedLists = ("FarmListItem").Split(',');
        
          FormID = "V06";
        }
      
      
      }
    
      public partial class BaseListPanel_VetAggregateCaseListItem : BaseListPanel<VetAggregateCaseListItem>
      {
      
        public BaseListPanel_VetAggregateCaseListItem() : base()
        {
          FormID = "V09";
        }
      
      
      }
    
      public partial class BaseListPanel_VetAggregateActionListItem : BaseListPanel<VetAggregateActionListItem>
      {
      
        public BaseListPanel_VetAggregateActionListItem() : base()
        {
          FormID = "V13";
        }
      
      
      }
    
      public partial class BaseGroupPanel_VectorFieldTest : BaseGroupPanel<VectorFieldTest>
      {
      
      
      }
    
      public partial class BaseGroupPanel_VectorLabTest : BaseGroupPanel<VectorLabTest>
      {
      
      
      }
    
      public partial class BaseDetailPanel_FFPresenterModel : BaseDetailPanel<FFPresenterModel>
      {
      
        public BaseDetailPanel_FFPresenterModel() : base()
        {
          m_RelatedLists = new string[]{"FFPresenterModelListItem"};
        
          FormID = "";
        }
      
      
      }
    
      public partial class BaseGroupPanel_LabTestAmendment : BaseGroupPanel<LabTestAmendment>
      {
      
      
      }
    
      public partial class BaseDetailPanel_VectorSubTypeMaster : BaseDetailPanel<VectorSubTypeMaster>
      {
      
        public BaseDetailPanel_VectorSubTypeMaster() : base()
        {
          m_RelatedLists = new string[]{"VectorSubTypeMasterListItem"};
        
          FormID = "A34";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_VectorSubType : BaseGroupPanel<VectorSubType>
      {
      
      
      }
    
      public partial class BaseDetailPanel_VectorType2CollectionMethodMaster : BaseDetailPanel<VectorType2CollectionMethodMaster>
      {
      
        public BaseDetailPanel_VectorType2CollectionMethodMaster() : base()
        {
          m_RelatedLists = new string[]{"VectorType2CollectionMethodMasterListItem"};
        
          FormID = "A35";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_VectorType2CollectionMethod : BaseGroupPanel<VectorType2CollectionMethod>
      {
      
      
      }
    
      public partial class BaseDetailPanel_VectorType2SampleTypeMaster : BaseDetailPanel<VectorType2SampleTypeMaster>
      {
      
        public BaseDetailPanel_VectorType2SampleTypeMaster() : base()
        {
          m_RelatedLists = new string[]{"VectorType2SampleTypeMasterListItem"};
        
          FormID = "A36";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_VectorType2SampleType : BaseGroupPanel<VectorType2SampleType>
      {
      
      
      }
    
      public partial class BaseDetailPanel_VectorType2PensideTestMaster : BaseDetailPanel<VectorType2PensideTestMaster>
      {
      
        public BaseDetailPanel_VectorType2PensideTestMaster() : base()
        {
          m_RelatedLists = new string[]{"VectorType2PensideTestMasterListItem"};
        
          FormID = "A37";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_VectorType2PensideTest : BaseGroupPanel<VectorType2PensideTest>
      {
      
      
      }
    
      public partial class BaseDetailPanel_Diagnosis2PensideTestMaster : BaseDetailPanel<Diagnosis2PensideTestMaster>
      {
      
        public BaseDetailPanel_Diagnosis2PensideTestMaster() : base()
        {
          m_RelatedLists = new string[]{"Diagnosis2PensideTestMasterListItem"};
        
          FormID = "A38";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_Diagnosis2PensideTest : BaseGroupPanel<Diagnosis2PensideTest>
      {
      
      
      }
    
      public partial class BaseDetailPanel_DataArchiveSettings : BaseDetailPanel<DataArchiveSettings>
      {
      
        public BaseDetailPanel_DataArchiveSettings() : base()
        {
          m_RelatedLists = new string[]{"DataArchiveSettingsListItem"};
        
          FormID = "D01";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_ObjectAccess : BaseGroupPanel<ObjectAccess>
      {
      
      
      }
    
      public partial class BaseGroupPanel_LoginInfo : BaseGroupPanel<LoginInfo>
      {
      
      
      }
    
      public partial class BaseGroupPanel_PersonGroupInfo : BaseGroupPanel<PersonGroupInfo>
      {
      
      
      }
    
      public partial class BaseDetailPanel_LoginInfo : BaseDetailPanel<LoginInfo>
      {
      
        public BaseDetailPanel_LoginInfo() : base()
        {
          m_RelatedLists = new string[]{"LoginInfoListItem"};
        
          FormID = "A31";
        }
      
      
      }
    
      public partial class BaseDetailPanel_DiagnosisAgeGroupMaster : BaseDetailPanel<DiagnosisAgeGroupMaster>
      {
      
        public BaseDetailPanel_DiagnosisAgeGroupMaster() : base()
        {
          m_RelatedLists = new string[]{"DiagnosisAgeGroupMasterListItem"};
        
          FormID = "A41";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_DiagnosisAgeGroup : BaseGroupPanel<DiagnosisAgeGroup>
      {
      
      
      }
    
      public partial class BaseDetailPanel_Diagnosis2DiagnosisAgeGroupMaster : BaseDetailPanel<Diagnosis2DiagnosisAgeGroupMaster>
      {
      
        public BaseDetailPanel_Diagnosis2DiagnosisAgeGroupMaster() : base()
        {
          m_RelatedLists = new string[]{"Diagnosis2DiagnosisAgeGroupMasterListItem"};
        
          FormID = "A42";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_DiagnosisAgeGroupToDiagnosis : BaseGroupPanel<DiagnosisAgeGroupToDiagnosis>
      {
      
      
      }
    
      public partial class BaseDetailPanel_DiagnosisAgeGroup2StatisticalAgeGroupMaster : BaseDetailPanel<DiagnosisAgeGroup2StatisticalAgeGroupMaster>
      {
      
        public BaseDetailPanel_DiagnosisAgeGroup2StatisticalAgeGroupMaster() : base()
        {
          m_RelatedLists = new string[]{"DiagnosisAgeGroup2StatisticalAgeGroupMasterListItem"};
        
          FormID = "A43";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_DiagnosisAgeGroup2StatisticalAgeGroup : BaseGroupPanel<DiagnosisAgeGroup2StatisticalAgeGroup>
      {
      
      
      }
    
      public partial class BaseDetailPanel_CopyDialogWindowItem : BaseDetailPanel<CopyDialogWindowItem>
      {
      
        public BaseDetailPanel_CopyDialogWindowItem() : base()
        {
          m_RelatedLists = new string[]{"CopyDialogWindowItemListItem"};
        
          FormID = "W05";
        }
      
      
      }
    
      public partial class BaseGroupPanel_VsSessionSummary : BaseGroupPanel<VsSessionSummary>
      {
      
      
      }
    
      public partial class BaseGroupPanel_VsSessionSummaryDiagnosis : BaseGroupPanel<VsSessionSummaryDiagnosis>
      {
      
      
      }
    
      public partial class BaseDetailPanel_Diagnosis2DiagnosisGroupMaster : BaseDetailPanel<Diagnosis2DiagnosisGroupMaster>
      {
      
        public BaseDetailPanel_Diagnosis2DiagnosisGroupMaster() : base()
        {
          m_RelatedLists = new string[]{"Diagnosis2DiagnosisGroupMasterListItem"};
        
          FormID = "A49";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_Diagnosis2DiagnosisGroup : BaseGroupPanel<Diagnosis2DiagnosisGroup>
      {
      
      
      }
    
      public partial class BaseDetailPanel_CaseClassificationMaster : BaseDetailPanel<CaseClassificationMaster>
      {
      
        public BaseDetailPanel_CaseClassificationMaster() : base()
        {
          m_RelatedLists = new string[]{"CaseClassificationMasterListItem"};
        
          FormID = "A45";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_CaseClassification : BaseGroupPanel<CaseClassification>
      {
      
      
      }
    
      public partial class BaseDetailPanel_BasicSyndromicSurveillanceItem : BaseDetailPanel<BasicSyndromicSurveillanceItem>
      {
      
        public BaseDetailPanel_BasicSyndromicSurveillanceItem() : base()
        {
          m_RelatedLists = ("BasicSyndromicSurveillanceListItem").Split(',');
        
          FormID = "B02";
        }
      
      
      }
    
      public partial class BaseListPanel_BasicSyndromicSurveillanceListItem : BaseListPanel<BasicSyndromicSurveillanceListItem>
      {
      
        public BaseListPanel_BasicSyndromicSurveillanceListItem() : base()
        {
          FormID = "B01";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LaboratorySectionMaster : BaseDetailPanel<LaboratorySectionMaster>
      {
      
        public BaseDetailPanel_LaboratorySectionMaster() : base()
        {
          m_RelatedLists = ("LabTestListItem,LabSampleListItem,LabSampleTransferListItem,LabSampleDispositionListItem").Split(',');
        
          FormID = "L25";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseListPanel_BasicSyndromicSurveillanceAggregateList : BaseListPanel<BasicSyndromicSurveillanceAggregateList>
      {
      
        public BaseListPanel_BasicSyndromicSurveillanceAggregateList() : base()
        {
          FormID = "B03";
        }
      
      
      }
    
      public partial class BaseListPanel_LaboratorySectionItem : BaseListPanel<LaboratorySectionItem>
      {
      
        public BaseListPanel_LaboratorySectionItem() : base()
        {
          FormID = "";
        }
      
      
      }
    
      public partial class BaseListPanel_LaboratorySectionMyPrefItem : BaseListPanel<LaboratorySectionItem>
      {
      
        public BaseListPanel_LaboratorySectionMyPrefItem() : base()
        {
          FormID = "";
        }
      
      
      }
    
      public partial class BaseDetailPanel_LaboratorySectionItem : BaseDetailPanel<LaboratorySectionItem>
      {
      
        public BaseDetailPanel_LaboratorySectionItem() : base()
        {
          m_RelatedLists = new string[]{"LaboratorySectionItemListItem"};
        
          FormID = "";
        }
      
      
      }
    
      public partial class BaseListPanel_LaboratorySectionGetByFieldBarcodeListItem : BaseListPanel<LaboratorySectionGetByFieldBarcodeListItem>
      {
      
        public BaseListPanel_LaboratorySectionGetByFieldBarcodeListItem() : base()
        {
          FormID = "L27";
        }
      
      
      }
    
      public partial class BaseGroupPanel_BasicSyndromicSurveillanceAggregateDetail : BaseGroupPanel<BasicSyndromicSurveillanceAggregateDetail>
      {
      
      
      }
    
      public partial class BaseDetailPanel_BasicSyndromicSurveillanceAggregateHeader : BaseDetailPanel<BasicSyndromicSurveillanceAggregateHeader>
      {
      
        public BaseDetailPanel_BasicSyndromicSurveillanceAggregateHeader() : base()
        {
          m_RelatedLists = ("BasicSyndromicSurveillanceAggregateList").Split(',');
        
          FormID = "B04";
        }
      
      
      }
    
      public partial class BaseDetailPanel_WhoExportMaster : BaseDetailPanel<WhoExportMaster>
      {
      
        public BaseDetailPanel_WhoExportMaster() : base()
        {
          m_RelatedLists = new string[]{"WhoExportMasterListItem"};
        
          FormID = "E01";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_WhoExport : BaseGroupPanel<WhoExport>
      {
      
      
      }
    
      public partial class BaseListPanel_HumanAggregateCaseDeduplicationListItem : BaseListPanel<HumanAggregateCaseDeduplicationListItem>
      {
      
        public BaseListPanel_HumanAggregateCaseDeduplicationListItem() : base()
        {
          FormID = "H16";
        }
      
      
      }
    
      public partial class BaseListPanel_VetAggregateCaseDeduplicationListItem : BaseListPanel<VetAggregateCaseDeduplicationListItem>
      {
      
        public BaseListPanel_VetAggregateCaseDeduplicationListItem() : base()
        {
          FormID = "V19";
        }
      
      
      }
    
      public partial class BaseListPanel_VetAggregateActionDeduplicationListItem : BaseListPanel<VetAggregateActionDeduplicationListItem>
      {
      
        public BaseListPanel_VetAggregateActionDeduplicationListItem() : base()
        {
          FormID = "V20";
        }
      
      
      }
    
      public partial class BaseDetailPanel_ReportDiagnosesGroupMaster : BaseDetailPanel<ReportDiagnosesGroupMaster>
      {
      
        public BaseDetailPanel_ReportDiagnosesGroupMaster() : base()
        {
          m_RelatedLists = new string[]{"ReportDiagnosesGroupMasterListItem"};
        
          FormID = "A47";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_ReportDiagnosesGroup : BaseGroupPanel<ReportDiagnosesGroup>
      {
      
      
      }
    
      public partial class BaseDetailPanel_ReportDiagnosesGroup2DiagnosisMaster : BaseDetailPanel<ReportDiagnosesGroup2DiagnosisMaster>
      {
      
        public BaseDetailPanel_ReportDiagnosesGroup2DiagnosisMaster() : base()
        {
          m_RelatedLists = new string[]{"ReportDiagnosesGroup2DiagnosisMasterListItem"};
        
          FormID = "A48";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_ReportDiagnosesGroup2Diagnosis : BaseGroupPanel<ReportDiagnosesGroup2Diagnosis>
      {
      
      
      }
    
      public partial class BaseDetailPanel_CustomReportRowsMaster : BaseDetailPanel<CustomReportRowsMaster>
      {
      
        public BaseDetailPanel_CustomReportRowsMaster() : base()
        {
          m_RelatedLists = new string[]{"CustomReportRowsMasterListItem"};
        
          FormID = "A46";
        }
      
        public override bool IsSingleTone {get { return true; }}
      
      
      }
    
      public partial class BaseGroupPanel_CustomReportRow : BaseGroupPanel<CustomReportRow>
      {
      
      
      }
    
    }
  