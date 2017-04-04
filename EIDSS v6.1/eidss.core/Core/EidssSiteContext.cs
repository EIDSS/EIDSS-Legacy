using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Globalization;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using DataException = BLToolkit.Data.DataException;
using eidss.model.Core.Security;

namespace eidss.model.Core
{
    [Serializable]
    public class EidssSiteContext
    {
        private long m_CountryID;
        private string m_CountryName;
        private long m_SiteID;
        private long m_PermissionSiteID;
        private long m_RealSiteID;
        private SiteType m_RealSiteType;
        private long m_RegionID;
        private long m_RayonID;
        private string m_SiteCode;
        private string m_SiteHascCode;
        private string m_CountryHascCode;
        private string m_SiteName;
        private SiteType m_SiteType;
        private string m_SiteTypeName;
        private string m_OrganizationName;
        private long m_OrganizationID;
        private bool m_IsInitialized;
        private string m_Language = string.Empty;
        private static volatile EidssSiteContext g_Instance;
        private List<EidssSiteOptions> m_SiteOptions;
        private List<EidssSiteOptions> m_GlobalSiteOptions;
        private List<CustomMandatoryField> m_CustomMandatoryFields;
        private static IReportFactory m_ReportFactory;
        private static IBarcodeFactory m_BarcodeFactory;
        private static readonly object m_Lock = new object();

        private EidssSiteContext()
        {
        }

        #region Properties

        public static EidssSiteContext Instance
        {
            get
            {
                EidssSiteContext ret;
                lock (m_Lock)
                {
                    if (HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Session != null)
                        {
                            ret = HttpContext.Current.Session["SiteContext"] as EidssSiteContext;
                            if (ret == null)
                            {
                                ret = new EidssSiteContext();
                                HttpContext.Current.Session["SiteContext"] = ret;
                            }
                        }
                        else
                        {
                            ret = ModelUserContext.AddSiteContext(ModelUserContext.ClientID, new EidssSiteContext());
                            /*lock (ModelUserContext.InstanceSiteContextStateless)
                            {
                                if (ModelUserContext.InstanceSiteContextStateless.ContainsKey(ModelUserContext.ClientID))
                                {
                                    ret = ModelUserContext.InstanceSiteContextStateless[ModelUserContext.ClientID] as EidssSiteContext;
                                }
                                else
                                {
                                    ret = new EidssSiteContext();
                                    ModelUserContext.InstanceSiteContextStateless.Add(ModelUserContext.ClientID, ret);
                                }
                            }*/
                        }
                    }
                    else
                    {
                        if (g_Instance == null)
                        {
                            g_Instance = new EidssSiteContext();
                        }
                        ret = g_Instance;
                    }
                }
                return ret;
            }
        }

        public long CountryID
        {
            get
            {
                GetSiteInfo();
                return m_CountryID;
            }
        }

        public string CountryName
        {
            get
            {
                GetSiteInfo();
                return m_CountryName;
            }
        }

        public string OrganizationName
        {
            get
            {
                GetSiteInfo();
                return m_OrganizationName;
            }
        }

        public long OrganizationID
        {
            get
            {
                GetSiteInfo();
                return m_OrganizationID;
            }
        }

        public string SiteABR
        {
            get
            {
                GetSiteInfo();
                return m_SiteName;
            }
        }

        public string SiteHASCCode
        {
            get
            {
                GetSiteInfo();
                return m_SiteHascCode;
            }
        }

        public string CountryHascCode
        {
            get
            {
                GetSiteInfo();
                return m_CountryHascCode;
            }
        }

        public long SiteID
        {
            get
            {
                GetSiteInfo();
                return m_SiteID;
            }
        }
        public long PermissionSiteID
        {
            get
            {
                GetSiteInfo();
                return m_PermissionSiteID;
            }
        }

        public long RealSiteID
        {
            get
            {
                GetSiteInfo();
                return m_RealSiteID;
            }
        }
        public string SiteCode
        {
            get
            {
                GetSiteInfo();
                return m_SiteCode;
            }
        }

        public SiteType SiteType
        {
            get
            {
                GetSiteInfo();
                return m_SiteType;
            }
        }
        public SiteType RealSiteType
        {
            get
            {
                GetSiteInfo();
                return m_RealSiteType;
            }
        }

        public string SiteTypeName
        {
            get
            {
                GetSiteInfo();
                return m_SiteTypeName;
            }
        }

        public long RegionID
        {
            get
            {
                GetSiteInfo();
                return m_RegionID;
            }
        }

        public long RayonID
        {
            get
            {
                GetSiteInfo();
                return m_RayonID;
            }
        }

        public bool IsReadOnlySite
        {
            get
            {
                if (m_SiteType == SiteType.Undefined)
                {
                    return false;
                }
                //TODO:[Mike] Get requirement for readonly site definition
                //Return (m_SiteType = SiteType.CDR AndAlso SiteCode <> "001") OrElse (SiteCode >= "002" AndAlso SiteCode <= "009") '
                return false;
            }
        }
        public bool IsDTRACustomization
        {
            get
            {
                return CustomizationPackageID == (long)CustomizationPackage.DTRA;//!= CountryID;
            }
        }
        public bool IsUsaAddressFormat
        {
            get
            {
                return CustomizationPackageID == (long)CustomizationPackage.DTRA;//!= CountryID;
            }
        }
        public bool IsIraqCustomization
        {
            get
            {
                return CustomizationPackageID == (long)CustomizationPackage.Iraq;//!= CountryID;
            }
        }
        public bool IsGeorgiaCustomization
        {
            get
            {
                return CustomizationPackageID == (long)CustomizationPackage.Georgia;//!= CountryID;
            }
        }
        public bool IsAzerbaijanCustomization
        {
            get
            {
                return CustomizationPackageID == (long)CustomizationPackage.Azerbaijan;//!= CountryID;
            }
        }
        public bool IsThaiCustomization
        {
            get
            {
                return CustomizationPackageID == (long)CustomizationPackage.Thailand;//!= CountryID;
            }
        }

        private int m_FirstDayOfWeek = -1;
        public DayOfWeek FirstDayOfWeek
        {
            get
            {
                if (m_FirstDayOfWeek == -1)
                {
                    if (int.TryParse(GetGlobalSiteOption(GlobalSiteOption.FirstDayOfWeek), out m_FirstDayOfWeek))
                    {
                        if (m_FirstDayOfWeek == 7)
                            m_FirstDayOfWeek = (int)DayOfWeek.Sunday;
                    }
                    else
                        m_FirstDayOfWeek = (int)DayOfWeek.Monday;
                }
                return (DayOfWeek)m_FirstDayOfWeek;
            }
        }

        private int m_WeekRule = -1;
        public CalendarWeekRule WeekRule
        {
            get
            {
                if (m_WeekRule == -1)
                {
                    if (!int.TryParse(GetGlobalSiteOption(GlobalSiteOption.CalendarWeekRule), out m_WeekRule))
                        m_WeekRule = (int)CalendarWeekRule.FirstFourDayWeek;
                }
                return (CalendarWeekRule)m_WeekRule;
            }
        }
        //In seconds
        public int ForcedReplicationPeriod
        {
            get
            {
                string periodOption = string.Empty;
                int defaultPeriod = 0;
                if (SiteType == SiteType.SLVL)
                {
                    periodOption = GlobalSiteOption.ForcedReplicationPeriodSlvl;
                    defaultPeriod = 60;
                }
                else if (SiteType == SiteType.TLVL)
                {
                    periodOption = GlobalSiteOption.ForcedReplicationPeriodTlvl;
                    defaultPeriod = 120;
                }
                if (defaultPeriod != 0)
                    return GetGlobalSiteOptionAsInt(periodOption, defaultPeriod)*1000;//Convert it to milliseconds for timer
                return 0;
            }
        }
        //In minutes
        public int ForcedReplicationExpirationPeriod
        {
            get
            {
                string periodOption = string.Empty;
                int defaultPeriod = 0;
                if (SiteType == SiteType.CDR)
                {
                    periodOption = GlobalSiteOption.ForcedReplicationExpirationPeriodCdr;
                    defaultPeriod = 5;
                }
                else if (SiteType == SiteType.SLVL)
                {
                    periodOption = GlobalSiteOption.ForcedReplicationExpirationPeriodSlvl;
                    defaultPeriod = 5;
                }
                else if (SiteType == SiteType.TLVL)
                {
                    periodOption = GlobalSiteOption.ForcedReplicationExpirationPeriodTlvl;
                    defaultPeriod = 15;
                }
                if (defaultPeriod != 0)
                    return GetGlobalSiteOptionAsInt(periodOption, defaultPeriod);
                return 0;

            }
        }

        public List<EidssSiteOptions> SiteOptions
        {
            get { return m_SiteOptions ?? (m_SiteOptions = GetSiteOptions("dbo.spLocalSiteOptions_SelectDetail")); }
        }

        private const int GlobalSiteOptionRefreshInterval = 30; //in munutes
        private DateTime m_LastOptionsRequest = DateTime.Now;
        public List<EidssSiteOptions> GlobalSiteOptions
        {
            get
            {
                if (m_GlobalSiteOptions == null ||
                    m_LastOptionsRequest.AddMinutes(GlobalSiteOptionRefreshInterval) < DateTime.Now)
                {
                    m_GlobalSiteOptions = GetSiteOptions("dbo.spGlobalSiteOptions_SelectDetail");
                    m_LastOptionsRequest = DateTime.Now;
                }
                return m_GlobalSiteOptions;
            }
        }

        private long m_CustomizationPackageID;
        public long CustomizationPackageID
        {
            get
            {
                //return (long)CustomizationPackage.Iraq;
                if (m_CustomizationPackageID == 0)
                {
                    if (!Int64.TryParse(GetGlobalSiteOption("CustomizationPackage"), out m_CustomizationPackageID))
                    {
                        CustomizationPackage package;
                        if (Enum.TryParse(((Country)CountryID).ToString(), out package))
                            m_CustomizationPackageID = (long)package;
                        else
                            throw new Exception("customization package is not defined");
                    }
                    Dbg.Debug("Receiving current customization is {0}", ((CustomizationPackage)m_CustomizationPackageID).ToString());
                }
                return m_CustomizationPackageID;
            }
        }


        public List<CustomMandatoryField> CustomMandatoryFields
        {
            get
            {
                return m_CustomMandatoryFields ?? new List<CustomMandatoryField>();
            }
        }


        public static IReportFactory ReportFactory
        {
            get
            {
                if (m_ReportFactory == null)
                {
                    const string reportFactory = "ReportFactory";
                    var loadedObject = ClassLoader.LoadClass(reportFactory);
                    Dbg.Assert(loadedObject != null, "class {0} can't be loaded", reportFactory);
                    Dbg.Assert(loadedObject is IReportFactory, "{0} doesn't implement IReportFactory interface", reportFactory);
                    m_ReportFactory = (IReportFactory)loadedObject;
                }
                return m_ReportFactory;
            }
        }



        public static IBarcodeFactory BarcodeFactory
        {
            get
            {
                if (m_BarcodeFactory == null)
                {
                    const string barcodeFactory = "BarcodeFactory";
                    var loadedObject = ClassLoader.LoadClass(barcodeFactory);
                    Dbg.Assert(loadedObject != null, "class {0} can't be loaded", barcodeFactory);
                    Dbg.Assert(loadedObject is IBarcodeFactory, "{0} doesn't implement IBarcodeFactory interface", barcodeFactory);
                    m_BarcodeFactory = (IBarcodeFactory)loadedObject;
                }
                return m_BarcodeFactory;
            }
        }
        #endregion

        public void UpdateDateTimeFormat(System.Globalization.CultureInfo culture)
        {
            culture.DateTimeFormat.CalendarWeekRule = WeekRule;
            culture.DateTimeFormat.FirstDayOfWeek = FirstDayOfWeek;
        }
        internal void SetCustomMandatoryFields(List<CustomMandatoryField> list = null, long? idfCustomizationPackage = null)
        {
            m_CustomMandatoryFields = list ?? (new EidssSecurityManager()).GetCustomMandatoryFields(idfCustomizationPackage);
        }

        public string GetSiteOption(string name)
        {
            return SiteOptions.Where(c => c.strName == name).Select(c => c.strValue).FirstOrDefault();
        }

        public string GetGlobalSiteOption(string name)
        {
            return GlobalSiteOptions.Where(c => c.strName == name).Select(c => c.strValue).FirstOrDefault();
        }

        public int GetGlobalSiteOptionAsInt(string name, int defValue)
        {
            var val = GlobalSiteOptions.Where(c => c.strName == name).Select(c => c.strValue).FirstOrDefault();
            if (val == null) return defValue;
            int ret;
            if (!int.TryParse(val, out ret))
                ret = defValue;
            return ret;
        }

        public void Clear()
        {
            m_CountryID = 0;
            m_CountryName = "";
            m_CountryHascCode = "";
            m_SiteID = 0;
            m_SiteCode = "";
            m_SiteHascCode = "";
            m_SiteType = SiteType.Undefined;
            m_SiteName = "";
            m_SiteTypeName = "";
            m_OrganizationName = "";
            m_OrganizationID = 0;
            m_IsInitialized = false;
            m_CustomizationPackageID = 0;
            m_BarcodeFactory = null;
            m_FirstDayOfWeek = -1;
            m_GlobalSiteOptions = null;
            m_IsInitialized = false;
            m_Language = string.Empty;
            m_RealSiteID = 0;
            m_RegionID = 0;
            m_RayonID = 0;
            m_WeekRule = -1;
        }
        public void Load()
        {
            Clear();
            GetSiteInfo();
        }
        private void GetSiteInfo()
        {
            if (m_IsInitialized && m_Language == ModelUserContext.CurrentLanguage)
            {
                return;
            }
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                try
                {
                    using (DataTable dt = manager.SetSpCommand("dbo.spGetSiteInfo",
                        // todo: change to LangId when new database will be deployed
                                                               manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                        ).ExecuteDataTable())
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            m_CountryID = (long)(row["idfsCountry"] == DBNull.Value ? 0 : row["idfsCountry"]);
                            m_CountryHascCode = (row["strHASCCountry"] == DBNull.Value ? "" : row["strHASCCountry"]).ToString();

                            m_CountryName = (row["idfsRegion"] == DBNull.Value ? "" : row["strCountryName"]).ToString();
                            m_RegionID = (long)(row["idfsRegion"] == DBNull.Value ? 0 : row["idfsRegion"]);
                            m_RayonID = (long)(row["idfsRayon"] == DBNull.Value ? 0 : row["idfsRayon"]);
                            m_SiteID = (long)(row["idfsSite"] == DBNull.Value ? 0 : row["idfsSite"]);
                            m_RealSiteID = (long)(row["idfsRealSiteID"] == DBNull.Value ? 0 : row["idfsRealSiteID"]);
                            m_PermissionSiteID = (long)(row["idfsPermissionSite"] == DBNull.Value ? 1 : row["idfsPermissionSite"]);
                            m_SiteCode = (row["strSiteID"] == DBNull.Value ? "" : row["strSiteID"]).ToString();
                            m_SiteHascCode = (row["strHASCsiteID"] == DBNull.Value ? "" : row["strHASCsiteID"]).ToString();
                            m_SiteType = row["idfsSiteType"] == DBNull.Value ? SiteType.Undefined : (SiteType)row["idfsSiteType"];
                            m_RealSiteType = row["idfsRealSiteType"] == DBNull.Value ? SiteType.Undefined : (SiteType)row["idfsRealSiteType"];
                            m_SiteName = (row["strSiteName"] == DBNull.Value ? "" : row["strSiteName"]).ToString();
                            m_SiteTypeName = (row["strSiteTypeName"] == DBNull.Value ? "" : row["strSiteTypeName"]).ToString();
                            m_OrganizationName = (row["strOrganizationName"] == DBNull.Value ? "" : row["strOrganizationName"]).ToString();
                            m_OrganizationID = (long)(row["idfOffice"] == DBNull.Value ? 0 : row["idfOffice"]);
                            m_IsInitialized = true;
                            m_Language = ModelUserContext.CurrentLanguage;
                        }
                        else
                        {
                            Clear();
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e is DataException)
                    {
                        throw DbModelException.Create(null, e as DataException);
                    }
                    throw;
                }
            }
        }

        private List<EidssSiteOptions> GetSiteOptions(string spName)
        {
            Utils.CheckNotNullOrEmpty(spName, "spName");
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                try
                {
                    List<EidssSiteOptions> eidssSiteOptionses = manager.SetSpCommand(spName).ExecuteList<EidssSiteOptions>();
                    return eidssSiteOptionses;
                }
                catch (Exception e)
                {
                    if (e is DataException)
                    {
                        throw DbModelException.Create(null, e as DataException);
                    }
                    throw;
                }
            }
        }

    }
}