using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using eidss.openapi.contract;

namespace eidss.openapi.web
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ISoapService
    {
        #region Login
        [OperationContract]
        void Login(Login value);
        #endregion
        #region HumanCase
        [OperationContract]
        HumanCase HumanCaseCreate(HumanCase value);
        [OperationContract]
        HumanCase HumanCaseUpdate(long id, HumanCase value);
        [OperationContract]
        HumanCase HumanCaseGet(long id);
        [OperationContract]
        void HumanCaseDelete(long id);
        [OperationContract]
        List<HumanCaseListItem> HumanCaseList(HumanCaseListFilter filter);
        #endregion
        #region HumanCaseSample
        [OperationContract]
        Sample HumanCaseSampleCreate(long idHumanCase, Sample value);
        [OperationContract]
        void HumanCaseSampleDelete(long idHumanCase, long id);
        #endregion
        #region HumanCaseTest
        [OperationContract]
        Test HumanCaseTestCreate(long idHumanCase, Test value);
        [OperationContract]
        void HumanCaseTestDelete(long idHumanCase, long id);
        #endregion
        #region HumanCaseTestInterpretation
        [OperationContract]
        TestInterpretation HumanCaseTestInterpretationCreate(long idHumanCase, TestInterpretation value);
        [OperationContract]
        void HumanCaseTestInterpretationDelete(long idHumanCase, long id);
        #endregion
        #region VetCase
        [OperationContract]
        VetCase VetCaseCreate(VetCase value);
        [OperationContract]
        VetCase VetCaseUpdate(long id, VetCase value);
        [OperationContract]
        VetCase VetCaseGet(long id);
        [OperationContract]
        void VetCaseDelete(long id);
        [OperationContract]
        List<VetCaseListItem> VetCaseList(VetCaseListFilter filter);
        #endregion
        #region VetCaseSample
        [OperationContract]
        Sample VetCaseSampleCreate(long idHumanCase, Sample value);
        [OperationContract]
        void VetCaseSampleDelete(long idHumanCase, long id);
        #endregion
        #region VetCaseTest
        [OperationContract]
        Test VetCaseTestCreate(long idVetCase, Test value);
        [OperationContract]
        void VetCaseTestDelete(long idVetCase, long id);
        #endregion
        #region VetCaseTestInterpretation
        [OperationContract]
        TestInterpretation VetCaseTestInterpretationCreate(long idVetCase, TestInterpretation value);
        [OperationContract]
        void VetCaseTestInterpretationDelete(long idVetCase, long id);
        #endregion
        #region VetCasePensideTest
        [OperationContract]
        PensideTest VetCasePensideTestCreate(long idVetCase, PensideTest value);
        [OperationContract]
        void VetCasePensideTestDelete(long idVetCase, long id);
        #endregion
        #region Farm
        [OperationContract]
        Farm FarmGet(long id);
        [OperationContract]
        List<FarmListItem> FarmList(FarmListFilter filter);
        #endregion
        #region Organization
        [OperationContract]
        Organization OrganizationCreate(Organization value);
        [OperationContract]
        Organization OrganizationUpdate(long id, Organization value);
        [OperationContract]
        Organization OrganizationGet(long id);
        [OperationContract]
        void OrganizationDelete(long id);
        [OperationContract]
        List<OrganizationListItem> OrganizationList(OrganizationListFilter filter);
        #endregion
        #region OrganizationPerson
        [OperationContract]
        Person OrganizationPersonCreate(long idOrganization, Person value);
        [OperationContract]
        void OrganizationPersonDelete(long idOrganization, long id);
        #endregion
        #region Patient
        [OperationContract]
        Patient PatientGet(long id);
        [OperationContract]
        List<PatientListItem> PatientList(PatientListFilter filter);
        #endregion
        #region Reference
        [OperationContract]
        List<Reference> ReferenceList(long type);
        [OperationContract]
        List<Diagnosis> DiagnosisList();
        [OperationContract]
        List<Reference> SampleTypeForDiagnosisList(int haCode, long diagnosis);
        [OperationContract]
        List<GisReference> CountryList();
        [OperationContract]
        List<GisReference> RegionList(long country);
        [OperationContract]
        List<GisReference> RayonList(long region);
        [OperationContract]
        List<GisReference> SettlementList(long rayon);
        #endregion
    }
}
