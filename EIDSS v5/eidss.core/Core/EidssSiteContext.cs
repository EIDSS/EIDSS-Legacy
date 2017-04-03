using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using DataException = BLToolkit.Data.DataException;
using eidss.model.Core.Security;
using System.Web;

namespace eidss.model.Core
{
    [Serializable]
    public class EidssSiteContext
    {
        private long m_CountryID;
        private string m_CountryName;
        private long m_SiteID;
        private long m_RegionID;
        private string m_SiteCode;
        private string m_SiteHascCode;
        private string m_CountryHascCode;
        private string m_SiteName;
        private SiteType m_SiteType;
        private string m_SiteTypeName;
        private string m_OrganizationName;
        private long m_OrganizationID;
        private bool m_IsInitialized;
        private static volatile EidssSiteContext m_Instance;
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
                EidssSiteContext ret = null;
                lock (m_Lock)
                {
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
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
                        if (m_Instance == null)
                        {
                            m_Instance = new EidssSiteContext();
                        }
                        ret = m_Instance;
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
                long customCountryID;
                if (!Int64.TryParse(GetGlobalSiteOption("CustomizationCountry"), out customCountryID))
                {
                    if (!Int64.TryParse(GetSiteOption("CustomizationCountry"), out customCountryID))
                    {
                        customCountryID = CountryID;
                    }
                }
                return customCountryID != CountryID;
            }
        }

        public List<EidssSiteOptions> SiteOptions
        {
            get { return m_SiteOptions ?? (m_SiteOptions = GetSiteOptions("dbo.spLocalSiteOptions_SelectDetail")); }
        }

        public List<EidssSiteOptions> GlobalSiteOptions
        {
            get { return m_GlobalSiteOptions ?? (m_GlobalSiteOptions = GetSiteOptions("dbo.spGlobalSiteOptions_SelectDetail")); }
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
        internal void SetCustomMandatoryFields(List<CustomMandatoryField> list = null, long? idfsCountry = null)
        {
            m_CustomMandatoryFields = list ?? (new EidssSecurityManager()).GetCustomMandatoryFields(idfsCountry);
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
            m_RegionID = 0;
            m_SiteID = 0;
            m_SiteCode = "";
            m_SiteHascCode = "";
            m_SiteType = SiteType.Undefined;
            m_SiteName = "";
            m_SiteTypeName = "";
            m_OrganizationName = "";
            m_OrganizationID = 0;
            m_IsInitialized = false;
        }

        private void GetSiteInfo()
        {
            if (m_IsInitialized)
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
                            m_CountryID = (long) (row["idfsCountry"] == DBNull.Value ? 0 : row["idfsCountry"]);
                            m_CountryHascCode = (row["strHASCCountry"] == DBNull.Value ? "" : row["strHASCCountry"]).ToString();

                            m_CountryName = (row["idfsRegion"] == DBNull.Value ? "" : row["strCountryName"]).ToString();
                            m_RegionID = (long) (row["idfsRegion"] == DBNull.Value ? 0 : row["idfsRegion"]);
                            m_SiteID = (long) (row["idfsSite"] == DBNull.Value ? 0 : row["idfsSite"]);
                            m_SiteCode = (row["strSiteID"] == DBNull.Value ? "" : row["strSiteID"]).ToString();
                            m_SiteHascCode = (row["strHASCsiteID"] == DBNull.Value ? "" : row["strHASCsiteID"]).ToString();
                            m_SiteType = row["idfsSiteType"] == DBNull.Value ? SiteType.Undefined : (SiteType) row["idfsSiteType"];
                            m_SiteName = (row["strSiteName"] == DBNull.Value ? "" : row["strSiteName"]).ToString();
                            m_SiteTypeName = (row["strSiteTypeName"] == DBNull.Value ? "" : row["strSiteTypeName"]).ToString();
                            m_OrganizationName = (row["strOrganizationName"] == DBNull.Value ? "" : row["strOrganizationName"]).ToString();
                            m_OrganizationID = (long) (row["idfOffice"] == DBNull.Value ? 0 : row["idfOffice"]);
                            m_IsInitialized = true;
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
                        throw DbModelException.Create(e as DataException);
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
                        throw DbModelException.Create(e as DataException);
                    }
                    throw;
                }
            }
        }
    }
}