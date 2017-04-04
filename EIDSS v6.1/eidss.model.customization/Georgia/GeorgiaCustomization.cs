using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Configuration;
using eidss.model.customization.Core;
using eidss.model.Core;
using System.ServiceModel;
using System.Net;
using eidss.model.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.common.Core;

namespace eidss.model.customization.Georgia
{
    class GeorgiaCustomization : BaseCustomization
    {
        public override PersonIdentityServiceFeatures PersonIdentityServiceFeatures
        {
            get
            {
                return new PersonIdentityServiceFeatures()
                {
                    IsAvailable = true,
                    IsOnHumanCase = false,
                    IsOnPatient = false,
                    IsOnHumanCasePatient = true,
                    IsOnContactedPerson = true,
                    ButtonResId = "btTitleFindInPersonIdentityServiceGG",
                };
            }
        }

        public override Tuple<Schema.Patient, string> GetFromPersonIdentityService(Schema.Patient p)
        {
            //for (int i = 0; i < 3; i++)
            //{
                try
                {
                    var ret = _getFromPersonIdentityServiceInternal(p);
                    if (ret == null)
                        return new Tuple<Schema.Patient, string>(null, "strPinNoRecordsFound");

                    return new Tuple<Schema.Patient, string>(ret, null);
                }
                catch(Exception)
                {

                }
            //}

            //using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            //{
            //}

            return new Tuple<Schema.Patient, string>(null, "strPinNotResponding");

        }

        private Schema.Patient _getFromPersonIdentityServiceInternal(Schema.Patient p)
        {
            string pin = p.strPersonID;
            string form = p.Parent is Schema.HumanCase ? "H02" : "H04";
            string caseID = p.Parent is Schema.HumanCase ? 
                (p.Parent as Schema.HumanCase).strCaseID : 
                (p.Parent is Schema.ContactedCasePerson ? 
                    ((p.Parent as Schema.ContactedCasePerson).Parent as Schema.HumanCase).strCaseID : 
                    "");
            DateTime? dtResponse = null;
            string resultCode = "";

            PersonInfoServiceSoapClient client = null;
            try
            {
                var timeout = Config.GetIntSetting("GgPinServiceTimeout", 1000);
                var encryptedUserAndPwd = Config.GetSetting("GgPinServiceUsrAndPwd");//"NCDC:EIDSS";
                var usr = Cryptor.Decrypt(encryptedUserAndPwd);
                client = new PersonInfoServiceSoapClient();
                var res = client.GetPersonInfoDataUsingPrivateNumber_V01(p.strPersonID, timeout, PersonDataSource.Cra, false, usr);
                dtResponse = res.PersonInfoDate;
                resultCode = res.Shedegi;

                if (res.Shedegi == "OK")
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        FilterParams filters = new FilterParams();
                        filters.Add("strPersonID", "=", p.strPersonID);
                        var items = Schema.PatientListItem.Accessor.Instance(null).SelectListT(manager, filters);
                        if (items != null && items.Count == 1)
                        {
                            var proot = Schema.Patient.Accessor.Instance(null).SelectByKey(manager, items[0].idfHumanActual);
                            p = proot;
                        }
                    }

                    p.PersonIDType = p.PersonIDTypeLookup.FirstOrDefault(i => i.idfsBaseReference != 0 && i.idfsBaseReference != (long)PersonalIDType.Unknown);
                    p.strPersonID = res.PersonInformacia.PrivateNumber;
                    p.strFirstName = res.PersonInformacia.FirstName;
                    p.strLastName = res.PersonInformacia.LastName;
                    p.datDateofBirth = res.PersonInformacia.BirthDate;
                    p.Gender = p.GenderLookup.FirstOrDefault(c => c.idfsBaseReference == (res.PersonInformacia.Gender == 1 ? (long)GenderType.Male : (res.PersonInformacia.Gender == 2 ? (long)GenderType.Female : 0)));
                    p.bPINMode = true;
                    return p;
                }
            }
            catch (Exception ex)
            {
                LogError.Log("ErrorLog_PinService_", ex, stream =>
                {
                    stream.WriteLine(String.Format("PIN = {0}, Form = {1}, CaseID = {2}, UserID = {3}, UserName = {4}, UserOrganization = {5}, EIDSSDateTime = {6}, PINServiceDateTime = {7}, Result = {8}",
                        pin, form, caseID, 
                        EidssUserContext.Instance.CurrentUser.LoginName, 
                        EidssUserContext.Instance.CurrentUser.FullName, 
                        EidssUserContext.Instance.CurrentUser.OrganizationEng, 
                        DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                        dtResponse.HasValue ? dtResponse.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        resultCode
                        ));
                });
                resultCode = "Exception:" + ex.Message;
                throw;
            }
            finally
            {
                if (client != null && client.State != System.ServiceModel.CommunicationState.Closed)
                    client.Close();

                LogError.Log("Log_PinService_", null, stream =>
                {
                    stream.WriteLine(String.Format("PIN = {0}, form = {1}, CaseID = {2}, UserID = {3}, UserName = {4}, UserOrganization = {5}, EIDSSDateTime = {6}, PINServiceDateTime = {7}, Result = {8}",
                        pin, form, caseID,
                        EidssUserContext.Instance.CurrentUser.LoginName,
                        EidssUserContext.Instance.CurrentUser.FullName,
                        EidssUserContext.Instance.CurrentUser.OrganizationEng,
                        DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                        dtResponse.HasValue ? dtResponse.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        resultCode
                        ));
                }, "{0}{3}.txt");
            }

            return null;
        }


    }
}
