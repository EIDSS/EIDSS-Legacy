using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using EIDSS.Web;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;

namespace Eidss.Web
{
    /// <summary>
    /// Summary description for OpenArchitecture
    /// </summary>
    [WebService(Namespace = "http://bv.com/eidss")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class EidssService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public HumanCaseListInfo[] GetHumanCaseList(HumanCaseListInfo filter)
        {
            Check(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase));
            return HumanCaseListInfo.GetAll(filter);
        }
        [WebMethod(EnableSession = true)]
        public VetCaseListInfo[] GetVetCaseList(VetCaseListInfo filter)
        {
            Check(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase));
            return VetCaseListInfo.GetAll(filter);
        }
        [WebMethod(EnableSession = true)]
        public DiagnosisLookupItem[] GetDiagnosisList(int code)
        {
            Check(null);
            return DiagnosisLookupItem.GetDiagnosisList(code);
        }
        [WebMethod(EnableSession = true)]
        public RayonLookupItem[] GetRayonList(long region)
        {
            Check(null);
            return RayonLookupItem.GetListByRegionId(region);
        }
        [WebMethod(EnableSession = true)]
        public RegionLookupItem[] GetRegionList()
        {
            Check(null);
            return RegionLookupItem.GetAll();
        }
        [WebMethod(EnableSession = true)]
        public BaseReferenceItem[] GetBaseReferenceList(long type)
        {
            Check(null);
            return BaseReferenceItem.GetList(type);
        }
        [WebMethod(EnableSession = true)]
        public HumanCaseInfo GetHumanCase(string id)
        {
            Check(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase));
            return HumanCaseInfo.GetById(id);
        }
        [WebMethod(EnableSession = true)]
        public VetCaseInfo GetVetCase(string id)
        {
            Check(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase));
            return VetCaseInfo.GetById(id);
        }
        [WebMethod(EnableSession = true)]
        public string CreateHumanCase(HumanCaseInfo hc)
        {
            Check(PermissionHelper.InsertPermission(EIDSSPermissionObject.HumanCase));
            hc.Save(true);
            return hc.Id.ToString();
        }

        [WebMethod(EnableSession = true)]
        public void EditHumanCase(HumanCaseInfo hc)
        {
            Check(PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
            hc.Save(true);
        }

        [WebMethod(EnableSession = true)]
        public SampleInfo[] GetSampleList(SampleInfo filter)
        {
            Check(PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample));
            return SampleInfo.GetAll(filter);
        }

        [WebMethod(EnableSession = true)]
        public TestInfo[] GetTestList(TestInfo filter)
        {
            Check(PermissionHelper.SelectPermission(EIDSSPermissionObject.Test));
            return TestInfo.GetAll(filter);
        }

        /*
                [WebMethod(EnableSession = true)]
                public AnimalInfo[] GetAnimalList()
                {
                    Check(PermissionHelper.SelectPermission (EIDSSPermissionObject.VetCase));
                    return ((List<AnimalInfo>)AnimalInfo.GetAll()).ToArray();
                }
        */

        protected void Check(string permission)
        {
            if (EidssUserContext.User == null || EidssUserContext.User.ID == null)
                throw new SoapException("Login required", SoapException.ClientFaultCode);
            if (permission != null && EidssUserContext.User.HasPermission(permission) == false)
                throw new SoapException("Access denied", SoapException.ClientFaultCode);
        }
        
        [WebMethod(EnableSession = true)]
        public void Login(string Organization, string User, string Password, string Language)
        {
            if (!Localizer.SupportedLanguages.ContainsKey(Language))
            {
                throw new SoapException("Language is not supported", SoapException.ClientFaultCode);
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[Language]);

            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                //set current language
                EidssUserContext.CurrentLanguage = Language;
            }
            else
            {
                throw new SoapException(SecurityMessages.GetLoginErrorMessage(result), SoapException.ClientFaultCode);
            }
        }


        [WebMethod(EnableSession = true)]
        public bool SaveHumanCases(string Organization, string User, string Password, string Language,
            HumanCaseInfo[] hc_in, out HumanCaseInfo[] hc_out)
        {
            hc_out = null;
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                EidssUserContext.CurrentLanguage = Language;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
                Check(PermissionHelper.InsertPermission(EIDSSPermissionObject.HumanCase));
                Check(PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
                var list = new List<HumanCaseInfo>();
                hc_in.ToList().ForEach(c =>
                {
                    if (c.Id == 0)
                    {
                        c.NotificationDate = DateTime.Today;
                        c.NotificationSentBy.Id = EidssSiteContext.Instance.OrganizationID;
                        c.NotificationSentBy.Name = EidssSiteContext.Instance.OrganizationName;
                        c.NotificationSentByPerson.Id = (long) EidssUserContext.User.ID;
                        c.NotificationSentByPerson.Name = EidssUserContext.User.FullName;
                    }
                    c.Save(c.Id == 0);
                    list.Add(c);
                });
                hc_out = list.ToArray();
                return true;
            }
            return false;
        }


        [WebMethod(EnableSession = true)]
        public bool LoadReferences(string Organization, string User, string Password,
            long[] types, string[] langs,
            out BaseReferenceRaw[] refs, out BaseReferenceTranslationRaw[] refs_trans,
            out GisBaseReferenceRaw[] gis_refs, out GisBaseReferenceTranslationRaw[] gis_refs_trans)
        {
            refs = null;
            refs_trans = null;
            gis_refs = null;
            gis_refs_trans = null;
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                refs = BaseReferenceRaw.GetList(types);
                refs_trans = BaseReferenceTranslationRaw.GetList(types, langs);
                gis_refs = GisBaseReferenceRaw.GetAll();
                gis_refs_trans = GisBaseReferenceTranslationRaw.GetAll(langs);
                return true;
            }
            return false;
        }




        [WebMethod(EnableSession = true)]
        public HumanCaseInfo[] SaveHumanCases2(string Organization, string User, string Password, string Language, HumanCaseInfo[] hc_in)
        {
            //HttpContext.Current.Request.SaveAs(@"C:\Work\temporary\test.txt", true);
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                EidssUserContext.CurrentLanguage = Language;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
                Check(PermissionHelper.InsertPermission(EIDSSPermissionObject.HumanCase));
                Check(PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
                var list = new List<HumanCaseInfo>();
                hc_in.ToList().ForEach(c =>
                {
                    if (c.Id == 0)
                    {
                        c.NotificationDate = DateTime.Today;
                        c.NotificationSentBy.Id = EidssSiteContext.Instance.OrganizationID;
                        c.NotificationSentBy.Name = EidssSiteContext.Instance.OrganizationName;
                        c.NotificationSentByPerson.Id = (long)EidssUserContext.User.ID;
                        c.NotificationSentByPerson.Name = EidssUserContext.User.FullName;
                    }
                    try
                    {
                        c.Save(c.Id == 0);
                    }
                    catch(SoapException)
                    {
                        
                    }
                    list.Add(c);
                });
                return list.ToArray();
            }
            return null;
        }

        [WebMethod(EnableSession = true)]
        public BaseReferenceRaw[] LoadReference(string Organization, string User, string Password, long type)
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                return BaseReferenceRaw.GetList(new[] { type });
            }
            return null;
        }

        [WebMethod(EnableSession = true)]
        public BaseReferenceTranslationRaw[] LoadReferenceTranslation(string Organization, string User, string Password, long type, string lang)
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                return BaseReferenceTranslationRaw.GetList(new[]{type}, new[]{lang});
            }
            return null;
        }

        [WebMethod(EnableSession = true)]
        public GisBaseReferenceRaw[] LoadGisReference(string Organization, string User, string Password)
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                return GisBaseReferenceRaw.GetAll();
            }
            return null;
        }

        [WebMethod(EnableSession = true)]
        public GisBaseReferenceTranslationRaw[] LoadGisReferenceTranslation(string Organization, string User, string Password, string lang)
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, User, Password);
            if (result == 0) //authorized
            {
                return GisBaseReferenceTranslationRaw.GetAll(new []{lang});
            }
            return null;
        }

    }
}
