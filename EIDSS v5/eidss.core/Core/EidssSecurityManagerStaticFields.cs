using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.Model.Core;
using eidss.model.Enums;

namespace eidss.model.Core
{
    namespace Security
    {
        public partial class EidssSecurityManager : ISecurityManager
        {
            public static Dictionary<PersonalDataGroup, Dictionary<string, List<string>>> PersonalDataDictionary = new Dictionary<PersonalDataGroup, Dictionary<string, List<string>>>()
            {
                {PersonalDataGroup.Human_PersonName, new Dictionary<string, List<string>>
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.strLastName",
                                    "Patient.strFirstName",
                                    "Patient.strMiddleName",
                                    "Patient.strName"
                                }
                            },
                            {"HumanCaseListItem", new List<string> 
                                {
                                    "PatientName"
                                }
                            },
                            {"Outbreak", new List<string> 
                                {
                                    "strPatientName"
                                }
                            },
                            {"OutbreakListItem", new List<string>
                                {
                                    "strPatientName"
                                }
                            },
                            {"HumanCaseSample", new List<string>
                                {
                                    "strPatientName"
                                }
                            },
                            {"LabSampleListItem", new List<string>
                                {
                                    "HumanName"
                                }                            
                            },
                            {"LabTestListItem", new List<string>
                                {
                                    "HumanName"
                                }                            
                            },
                            {"LabTest", new List<string>
                                {
                                    "HumanName"
                                }                            
                            },
                             {"LabTestSample", new List<string>
                                {
                                    "HumanName"
                                }                            
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.NameOfPatient",
                                }                            
                            },
                            {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.NameOfPatient",
                                }                            
                            },
                            
                        } 
                },
                {PersonalDataGroup.Human_PersonAge, new Dictionary<string, List<string>>
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.datDateofBirth",
                                    "Patient.intPatientAgeFromCase",
                                    "Patient.idfsHumanAgeTypeFromCase",
                                    "Patient.HumanAgeType"
                                }
                            },
                            {"HumanCaseListItem", new List<string> 
                                {
                                    "datDateofBirth",
                                    "Age"
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.Age",
                                    "spRepHumCaseForm.AgeType",
                                    "spRepHumCaseForm.DOB",
                                }                            
                            },
                            {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.Age",
                                    "spRepHumNotificationForm.AgeType",
                                    "spRepHumNotificationForm.DOB",
                                }                            
                            },
                        }
                },
                {PersonalDataGroup.Human_PersonSex, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.Gender",
                                    "Patient.idfsGender"
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.Sex",
                                }                            
                            },
                            {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.Sex",
                                }                            
                            },
                        
                        } 
                },
                {PersonalDataGroup.Human_CurrentResidence_Settlement, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.CurrentResidenceAddress.Settlement",
                                    "Patient.CurrentResidenceAddress.idfsSettlement",
                                    "Patient.CurrentResidenceAddress.strPostCode",
                                    "Patient.CurrentResidenceAddress.strStreetName",
                                    "Patient.CurrentResidenceAddress.strApartment",
                                    "Patient.CurrentResidenceAddress.strHouse",
                                    "Patient.CurrentResidenceAddress.strBuilding"
                                }
                            },
                            {"HumanCaseListItem", new List<string> 
                                {
                                    "idfsSettlement"
                                }
                            },
                            {"Outbreak", new List<string> //filling required
                                {
                                
                                }

                            },
                            {"OutbreakListItem", new List<string> //refactoring required to get necessary fields from DB
                                {
                                
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.City",
                                    "spRepHumCaseForm.Street",
                                    "spRepHumCaseForm.strPost_Code",
                                    "spRepHumCaseForm.BuildingNum",
                                    "spRepHumCaseForm.HouseNum",
                                    "spRepHumCaseForm.AptNum",
                                    "spRepHumCaseForm.PhoneNumber",
                                }                            
                            },
                            {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.City",
                                    "spRepHumNotificationForm.Street",
                                    "spRepHumNotificationForm.strPost_Code",
                                    "spRepHumNotificationForm.BuildingNum",
                                    "spRepHumNotificationForm.HouseNum",
                                    "spRepHumNotificationForm.AptNum",
                                    "spRepHumNotificationForm.PhoneNumber",
                                }                            
                            },
                            {"OutbreakReport", new List<string>
                                {
                                    "spRepUniOutbreakReport.Location",
                                }                            
                            },

                        } 
                },
                {PersonalDataGroup.Human_CurrentResidence_Details, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.CurrentResidenceAddress.strPostCode",
                                    "Patient.CurrentResidenceAddress.strStreetName",
                                    "Patient.CurrentResidenceAddress.strApartment",
                                    "Patient.CurrentResidenceAddress.strHouse",
                                    "Patient.CurrentResidenceAddress.strBuilding"
                                }
                            },
                            {"Outbreak", new List<string> //filling required
                                {
                                
                                }

                            },
                            {"OutbreakListItem", new List<string> //refactoring required to get necessary fields from DB
                                {
                                
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.Street",
                                    "spRepHumCaseForm.strPost_Code",
                                    "spRepHumCaseForm.BuildingNum",
                                    "spRepHumCaseForm.HouseNum",
                                    "spRepHumCaseForm.AptNum",
                                    "spRepHumCaseForm.PhoneNumber",
                                }                            
                            },
                             {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.Street",
                                    "spRepHumNotificationForm.strPost_Code",
                                    "spRepHumNotificationForm.BuildingNum",
                                    "spRepHumNotificationForm.HouseNum",
                                    "spRepHumNotificationForm.AptNum",
                                    "spRepHumNotificationForm.PhoneNumber",
                                }                            
                            },
                            {"OutbreakReport", new List<string>
                                {
                                    "spRepUniOutbreakReport.Location",
                                }                            
                            },

                        } 
                },            
                {PersonalDataGroup.Human_CurrentResidence_Coordinates, new Dictionary<string, List<string>> 
                        {
                             {"HumanCase", new List<string> 
                                {
                                    "Patient.CurrentResidenceAddress.dblLongitude",
                                    "Patient.CurrentResidenceAddress.dblLatitude"
                                }
                            }
                        } 
                },
                {PersonalDataGroup.Human_Employer_Settlement, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.EmployerAddress.Settlement",
                                    "Patient.EmployerAddress.idfsSettlement",
                                    "Patient.EmployerAddress.strPostCode",
                                    "Patient.EmployerAddress.strStreetName",
                                    "Patient.EmployerAddress.strApartment",
                                    "Patient.EmployerAddress.strHouse",
                                    "Patient.EmployerAddress.strBuilding",
                                    "Patient.strEmployerName"
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.EmpVillage",
                                    "spRepHumCaseForm.EmpStreet",
                                    "spRepHumCaseForm.EmpPostalCode",
                                    "spRepHumCaseForm.EmpBuild",
                                    "spRepHumCaseForm.EmpHouse",
                                    "spRepHumCaseForm.EmpApp",
                                    "spRepHumCaseForm.EmpPhone",
                                }                            
                            },
                            {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.EmpVillage",
                                    "spRepHumNotificationForm.EmpStreet",
                                    "spRepHumNotificationForm.EmpPostalCode",
                                    "spRepHumNotificationForm.EmpBuild",
                                    "spRepHumNotificationForm.EmpHouse",
                                    "spRepHumNotificationForm.EmpApp",
                                    "spRepHumNotificationForm.EmpPhone",
                                }                            
                            },
                        } 
                },
                {PersonalDataGroup.Human_Employer_Details, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.EmployerAddress.strPostCode",
                                    "Patient.EmployerAddress.strStreetName",
                                    "Patient.EmployerAddress.strApartment",
                                    "Patient.EmployerAddress.strHouse",
                                    "Patient.EmployerAddress.strBuilding",
                                    "Patient.strEmployerName"
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.EmpStreet",
                                    "spRepHumCaseForm.EmpPostalCode",
                                    "spRepHumCaseForm.EmpBuild",
                                    "spRepHumCaseForm.EmpHouse",
                                    "spRepHumCaseForm.EmpApp",
                                    "spRepHumCaseForm.EmpPhone",
                                }                            
                            },
                             {"EmergencyNotificationReport", new List<string>
                                {
                                    "spRepHumNotificationForm.EmpStreet",
                                    "spRepHumNotificationForm.EmpPostalCode",
                                    "spRepHumNotificationForm.EmpBuild",
                                    "spRepHumNotificationForm.EmpHouse",
                                    "spRepHumNotificationForm.EmpApp",
                                    "spRepHumNotificationForm.EmpPhone",
                                }                            
                            },
                        } 

                },           
                {PersonalDataGroup.Human_PermanentResidence_Settlement, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.RegistrationAddress.Settlement",
                                    "Patient.RegistrationAddress.idfsSettlement",
                                    "Patient.RegistrationAddress.strPostCode",
                                    "Patient.RegistrationAddress.strStreetName",
                                    "Patient.RegistrationAddress.strApartment",
                                    "Patient.RegistrationAddress.strHouse",
                                    "Patient.RegistrationAddress.strBuilding"
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.RegVillage",
                                    "spRepHumCaseForm.RegStreet",
                                    "spRepHumCaseForm.RegPostalCode",
                                    "spRepHumCaseForm.RegBuld",
                                    "spRepHumCaseForm.RegHouse",
                                    "spRepHumCaseForm.RegApp",
                                    "spRepHumCaseForm.RegPhone",
                                }                            
                            },
                        } 
                },
                {PersonalDataGroup.Human_PermanentResidence_Details, new Dictionary<string, List<string>> 
                        {
                             {"HumanCase", new List<string> 
                                {
                                    "Patient.RegistrationAddress.strPostCode",
                                    "Patient.RegistrationAddress.strStreetName",
                                    "Patient.RegistrationAddress.strApartment",
                                    "Patient.RegistrationAddress.strHouse",
                                    "Patient.RegistrationAddress.strBuilding"
                                }
                            },
                            {"CaseInvestigationReport", new List<string>
                                {
                                    "spRepHumCaseForm.RegStreet",
                                    "spRepHumCaseForm.RegPostalCode",
                                    "spRepHumCaseForm.RegBuld",
                                    "spRepHumCaseForm.RegHouse",
                                    "spRepHumCaseForm.RegApp",
                                    "spRepHumCaseForm.RegPhone",
                                }                            
                            },
                        } 
                },
                {PersonalDataGroup.Human_PermanentResidence_Coordinates, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "Patient.RegistrationAddress.dblLongitude",
                                    "Patient.RegistrationAddress.dblLatitude"
                                }
                            }
                        } 
                },
                {PersonalDataGroup.Human_Contact_Settlement, new Dictionary<string, List<string>> 
                        {
                            {"HumanCase", new List<string> 
                                {
                                    "ContactedCasePerson.strFullName",
                                    "ContactedCasePerson.Person.RegistrationAddress.Settlement",
                                    "ContactedCasePerson.Person.RegistrationAddress.idfsSettlement",
                                    "ContactedCasePerson.Person.RegistrationAddress.strPostCode",
                                    "ContactedCasePerson.Person.RegistrationAddress.strStreetName",
                                    "ContactedCasePerson.Person.RegistrationAddress.strApartment",
                                    "ContactedCasePerson.Person.RegistrationAddress.strHouse",
                                    "ContactedCasePerson.Person.RegistrationAddress.strBuilding"
                                    //strRegistrationAddress - has to be redefined
                                }
                            },
                            {"ContactListReport", new List<string>
                                {
                                    "spRepHumCaseFormContacts.ContactName",
                                }                            
                            },
                        } 
                },
                {PersonalDataGroup.Human_Contact_Details, new Dictionary<string, List<string>> 
                        {
                             {"HumanCase", new List<string> 
                                {
                                    "ContactedCasePerson.strFullName",
                                    "ContactedCasePerson.Person.RegistrationAddress.strPostCode",
                                    "ContactedCasePerson.Person.RegistrationAddress.strStreetName",
                                    "ContactedCasePerson.Person.RegistrationAddress.strApartment",
                                    "ContactedCasePerson.Person.RegistrationAddress.strHouse",
                                    "ContactedCasePerson.Person.RegistrationAddress.strBuilding"
                                    //strRegistrationAddress - has to be redefined
                                }
                            },
                            {"ContactListReport", new List<string>
                                {
                                    "spRepHumCaseFormContacts.ContactName",
                                }                            
                            },
                        } 
                },
                {PersonalDataGroup.Vet_Farm_Settlement, new Dictionary<string, List<string>> 
                        {
                             {"VetCase", new List<string> 
                                {
                                    "Farm.strOwnerLastName",
                                  "Farm.strOwnerFirstName",
                                  "Farm.strOwnerMiddleName",
                                  "Farm.strFarmCode",
                                  "Farm.strNationalName",
                                  "Farm.Address.Settlement",
                                  "Farm.Address.idfsSettlement",
                                  "Farm.Address.PostCode",
                                  "Farm.Address.Street",
                                  "Farm.Address.strPostCode",
                                  "Farm.Address.strStreetName",
                                  "Farm.Address.strApartment",
                                  "Farm.Address.strHouse",
                                  "Farm.Address.strBuilding",
                                  "Farm.strFax",
                                  "Farm.strEmail",
                                  "Farm.strContactPhone"
                                }
                            },
                            {"VetCaseListItem", new List<string>
                            {
                                  "strOwnerLastName",
                                  "strOwnerFirstName",
                                  "AddressName",          
                                  "Settlement",
                                  "idfsSettlement"
                            }
                            },
                             {"Outbreak", new List<string> //filling required
                                {
                                
                                }

                            },
                            {"OutbreakListItem", new List<string> //refactoring required to get necessary fields from DB
                                {
                                
                                }
                            },
                             {"LabTest", new List<string>
                                {
                                    "HumanName"
                                }                            
                            },
                            {"VetCaseSample", new List<string>
                                {
                                    
                                }                            
                            },
                            {"AvianInvestigationReport", new List<string>
                                {
                                    "spRepVetAvianCase.Settlement",
                                    "spRepVetAvianCase.FarmName",
                                    "spRepVetAvianCase.FarmCode",
                                    "spRepVetAvianCase.FarmerName",
                                    "spRepVetAvianCase.FarmAddress",
                                    "spRepVetAvianCase.FarmPhone",
                                    "spRepVetAvianCase.FarmFax",
                                    "spRepVetAvianCase.FarmEMail",
                                }                            
                            },
                            {"LivestockInvestigationReport", new List<string>
                                {
                                    "spRepVetLivestockCase.Settlement",
                                    "spRepVetLivestockCase.FarmName",
                                    "spRepVetLivestockCase.FarmCode",
                                    "spRepVetLivestockCase.FarmerName",
                                    "spRepVetLivestockCase.FarmAddress",
                                    "spRepVetLivestockCase.FarmPhone",
                                    "spRepVetLivestockCase.FarmFax",
                                    "spRepVetLivestockCase.FarmEMail",
                                }                            
                            },
                        }
                    },
                     {PersonalDataGroup.Vet_Farm_Details, new Dictionary<string, List<string>> 
                        {
                             {"VetCase", new List<string> 
                                {
                                    "Farm.strOwnerLastName",
                                      "Farm.strOwnerFirstName",
                                      "Farm.strOwnerMiddleName",
                                      "Farm.strFarmCode",
                                      "Farm.strNationalName",
                                      "Farm.Address.PostCode",
                                      "Farm.Address.Street",
                                      "Farm.Address.strPostCode",
                                      "Farm.Address.strStreetName",
                                      "Farm.Address.strApartment",
                                      "Farm.Address.strHouse",
                                      "Farm.Address.strBuilding",
                                      "Farm.strFax",
                                      "Farm.strEmail",
                                      "Farm.strContactPhone"
                                }
                            },
                             {"VetCaseListItem", new List<string>
                            {
                                        "strOwnerLastName",
                                        "strOwnerFirstName",
                                        "AddressName"
                            }
                            },
                            {"LabTest", new List<string>
                                {
                                    "HumanName"
                                }                            
                            },
                            {"VetCaseSample", new List<string>
                                {
                                    
                                }                            
                            },
                            {"Outbreak", new List<string> //filling required
                                {
                                
                                }

                            },
                            {"OutbreakListItem", new List<string> //refactoring required to get necessary fields from DB
                                {
                                
                                }
                            },
                             {"AvianInvestigationReport", new List<string>
                                {
                                    "spRepVetAvianCase.FarmName",
                                    "spRepVetAvianCase.FarmCode",
                                    "spRepVetAvianCase.FarmerName",
                                    "spRepVetAvianCase.FarmAddress",
                                    "spRepVetAvianCase.FarmPhone",
                                    "spRepVetAvianCase.FarmFax",
                                    "spRepVetAvianCase.FarmEMail",
                                }                            
                            },
                             {"LivestockInvestigationReport", new List<string>
                                {
                                    "spRepVetLivestockCase.FarmName",
                                    "spRepVetLivestockCase.FarmCode",
                                    "spRepVetLivestockCase.FarmerName",
                                    "spRepVetLivestockCase.FarmAddress",
                                    "spRepVetLivestockCase.FarmPhone",
                                    "spRepVetLivestockCase.FarmFax",
                                    "spRepVetLivestockCase.FarmEMail",
                                }                            
                            },
                        }
                    },
                    { PersonalDataGroup.Vet_Farm_Coordinates, new Dictionary<string, List<string>> 
                        {
                             {"VetCase", new List<string> 
                                {              
                                    "Farm.Location.dblLatitude",
                                    "Farm.Location.dblLongtitude"
                                }
                            },
                             {"AvianInvestigationReport", new List<string>
                                {
                                    "spRepVetAvianCase.FarmLatitude",
                                    "spRepVetAvianCase.FarmLongitude",
                                }                            
                            },
                             {"LivestockInvestigationReport", new List<string>
                                {
                                    "spRepVetLivestockCase.FarmLatitude",
                                    "spRepVetLivestockCase.FarmLongitude",
                                }                            
                            },
                        }
                    }
        
            };
        }
    }
}
