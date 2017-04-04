using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.IO;
using System.Threading.Tasks;
//using eidss.openapi.contract;
using eidss.openapi.test.OpenApiService;

namespace eidss.openapi.test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var client = new SoapServiceClient();
                //client.Login(new Login() { organization = "NCDC&PH", user = "test_admin", password = "test", language = "en" });
                //client.Login(new Login() { organization = "MOLHSA", user = "Administrator", password = "EIDSS", language = "en", externalSystem = "e-TB" });
                client.Login(new Login() { organization = "Republican APS", user = "OAUserLogin", password = "EIDSS", language = "en", externalSystem = "e-TB" });
                //var list = client.HumanCaseList(new HumanCaseListFilter());
                var list = client.HumanCaseList(new HumanCaseListFilter() 
                    { 
                        DateEnteredFrom = new DateTime(2014, 11, 20), DateEnteredTo = new DateTime(2014, 11, 25),
                        Diagnosis = 7721290000000 
                    });
                foreach (var p in list)
                {
                    Console.WriteLine("{0} - {1} - {2}", p.CaseID, p.FinalDiagnosis.RecordID, p.FinalDiagnosis.DiagnosisName);
                }
            }
            catch(FaultException e)
            {
                string code = e.Code.Name;
                string mess = e.Reason.ToString();
                Console.WriteLine("{0} - {1}", code, mess);
            }
            
            //var handler = new HttpClientHandler();
            //handler.Credentials = new NetworkCredential("NCDC&PH@test_admin@en", "test");

            /*
            var organization = "NCDC&PH";
            var username = "test_admin";
            var language = "en";
            var externalSystem = ""; // optional
            var password = "test";
            var authInfo = string.Format("{0}@{1}@{2}@{3}:{4}", organization, username, language, externalSystem, password);
            // NCDC&PH@test_admin@en:test
            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:64763/") };
            var basic = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
            client.DefaultRequestHeaders.Add("Authorization", basic);

            HumanCase humanCase = null;
            var hcin = new HumanCase();
            hcin.Diagnosis = new Diagnosis() { RecordID = 786450000000 };
            hcin.Patient = new Patient()
                {
                    PatientLastName = "last",
                    PatientCurrentResidence = new Address()
                        {
                            Country = new GisReference() { RecordID = 780000000 },
                            Region = new GisReference() { RecordID = 37020000000 },
                            Rayon = new GisReference() { RecordID = 3260000000 },
                        }
                };
            hcin.SamplesCollected = new Reference() { RecordID = 10100001 };
            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            //StringBuilder sb = new StringBuilder();
            //StringWriter writer = new StringWriter(sb);
            MemoryStream stream = new MemoryStream();
            formatter.WriteToStreamAsync(typeof (HumanCase), hcin, stream, null, null);
            stream.Seek(0, SeekOrigin.Begin);
            var sr = new StreamReader(stream);
            var myStr = sr.ReadToEnd();
*/
            /*
{"idfCase":0,"uidOfflineCaseID":null,"strCaseID":null,"strLocalIdentifier":null,"strCurrentLocation":null,"strHospitalizationPlace":null,"strSoughtCareFacility":null,"strSentByFirstName":null,"strSentByPatronymicName":null,"strSentByLastName":null,"strReceivedByFirstName":null,"strReceivedByPatronymicName":null,"strReceivedByLastName":null,"strEpidemiologistsName":null,"strNote":null,"strClinicalNotes":null,"strSummaryNotes":null,"strSampleNotes":null,"blnClinicalDiagBasis":null,"blnLabDiagBasis":null,"blnEpiDiagBasis":null,"blnPermantentAddressAsCurrent":null,"TentativeDiagnosis":{"id":786450000000,"name":null,"IDC10Code":null,"HACode":0,"isAggregate":false},"FinalDiagnosis":null,"CaseProgressStatus":null,"InitialCaseClassification":null,"FinalCaseClassification":null,"PatientState":null,"PatientLocationType":null,"AntimicrobialTherapyUsed":null,"Hospitalization":null,"SpecimenCollected":{"id":10100001,"name":null},"RelatedToOutbreak":null,"TestsConducted":null,"Outcome":null,"NonNotifiableDiagnosis":null,"OccupationType":null,"NotCollectedReason":null,"SentByOffice":null,"ReceivedByOffice":null,"InvestigatedByOffice":null,"SentByPerson":null,"ReceivedByPerson":null,"datTentativeDiagnosisDate":null,"datFinalDiagnosisDate":null,"datNotificationDate":null,"datCompletionPaperFormDate":null,"datFirstSoughtCareDate":null,"datModificationDate":null,"datHospitalizationDate":null,"datFacilityLastVisit":null,"datExposureDate":null,"datDischargeDate":null,"datOnSetDate":null,"datInvestigationStartDate":null,"datDateOfDeath":null,"datEnteredDate":null,"strOutbreakID":null,"Patient":{"strFirstName":null,"strSecondName":null,"strLastName":"last","CurrentResidenceAddress":{"Country":{"id":780000000,"name":null},"Region":{"id":37020000000,"name":null},"Rayon":{"id":3260000000,"name":null},"Settlement":null,"strPostCode":null,"strStreetName":null,"strApartment":null,"strBuilding":null,"strHouse":null,"strForeignAddress":null,"dblLatitude":null,"dblLongitude":null},"RegistrationAddress":null,"strHomePhone":null,"strWorkPhone":null,"strRegistrationPhone":null,"Gender":null,"Nationality":null,"OccupationType":null,"intPatientAge":null,"HumanAgeType":null,"datDateOfBirth":null,"datDateOfDeath":null,"EmployerAddress":null,"strEmployerName":null},"Samples":null}
{"TentativeDiagnosis":{"id":786450000000},"Patient":{"strLastName":"last","CurrentResidenceAddress":{"Country":{"id":780000000},"Region":{"id":37020000000},"Rayon":{"id":3260000000}}}}
            */
/*
            var response = client.PostAsync("api/HumanCase", hcin, new JsonMediaTypeFormatter()).Result;
            if (response.IsSuccessStatusCode)
            {
                humanCase = response.Content.ReadAsAsync<HumanCase>().Result;
                Console.WriteLine("{0}", humanCase.CaseID);
            }
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Sample smp = new Sample() { SampleType = new Reference() { RecordID = 799980000000 } };
            response = client.PostAsync("api/HumanCase/" + humanCase.RecordID + "/Sample", smp, new JsonMediaTypeFormatter()).Result;
            if (response.IsSuccessStatusCode)
            {
                smp = response.Content.ReadAsAsync<Sample>().Result;
                Console.WriteLine("{0}", smp.RecordID);
            }
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);


            response = client.DeleteAsync("api/HumanCase/" + humanCase.RecordID + "/Sample/" + smp.RecordID).Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Sample Deleted");
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            

            response = client.DeleteAsync("api/HumanCase/" + humanCase.RecordID).Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Case Deleted");
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            
*/
            /*
            var response = client.GetAsync("api/Gis").Result;
            if (response.IsSuccessStatusCode)
            {
                // get country list
                var list = response.Content.ReadAsAsync<IEnumerable<Reference>>().Result;
                foreach (var p in list) {
                    Console.WriteLine("{0}", p.name);
                }
                var countryGeorgia = list.Single(c => c.name == "Georgia").id;
                // get region list for Georgia
                response = client.GetAsync(string.Format("api/Gis/{0}", countryGeorgia)).Result;
                if (response.IsSuccessStatusCode)
                {
                    list = response.Content.ReadAsAsync<IEnumerable<Reference>>().Result;
                    foreach (var p in list) {
                        Console.WriteLine("{0}", p.name);
                    }
                    var regionAdjara = list.Single(c => c.name == "Adjara").id;
                    // get rayon list for Georgia and Adjara
                    response = client.GetAsync(string.Format("api/Gis/{0}/{1}", countryGeorgia, regionAdjara)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        list = response.Content.ReadAsAsync<IEnumerable<Reference>>().Result;
                        foreach (var p in list) {
                            Console.WriteLine("{0}", p.name);
                        }
                        var rayonBatumi = list.Single(c => c.name == "Batumi").id;
                        // get settlement list for Georgia, Adjara and Batumi
                        response = client.GetAsync(string.Format("api/Gis/{0}/{1}/{2}", countryGeorgia, regionAdjara, rayonBatumi)).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            list = response.Content.ReadAsAsync<IEnumerable<Reference>>().Result;
                            foreach (var p in list) {
                                Console.WriteLine("{0}", p.name);
                            }
                        }
                        else
                            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                    else
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                else
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            */
            /*
            var response = client.DeleteAsync("api/HumanCase/126876900000001").Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Deleted");
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            */
            /*
            response = client.GetAsync("api/HumanCase/12687690000000").Result;
            if (response.IsSuccessStatusCode) {
                var humanCase = response.Content.ReadAsAsync<HumanCase>().Result;
                Console.WriteLine("{0}", humanCase.strCaseID);
            }
            else
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            
            
            var filter = new HumanCaseListFilter() { strCaseID = "HGETBTB0130005" };
            var serializer = new JavaScriptSerializer();
            var filterJson = string.Format("?filter={0}", serializer.Serialize(filter));
            
            response = client.GetAsync("api/HumanCase/list" + filterJson).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var list = response.Content.ReadAsAsync<IEnumerable<HumanCaseListItem>>().Result;
                foreach (var p in list)
                {
                    Console.WriteLine("{0}", p.strCaseID);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            */
            Console.ReadLine();
        }
    }
}
