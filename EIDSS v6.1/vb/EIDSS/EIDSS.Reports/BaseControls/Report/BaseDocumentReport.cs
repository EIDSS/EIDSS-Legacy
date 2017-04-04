using System;
using System.Collections.Generic;
using System.Data;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Core;
using eidss.model.Enums;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseDocumentReport : BaseReport
    {
        public BaseDocumentReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNull(parameters, "parameters");

            long organizationId;
            bool hasOrganization = TryGetLongParameter(parameters, "@OrganizationID", out organizationId);
            long siteId;
            bool hasSite = TryGetLongParameter(parameters, "@SiteID", out siteId);

            DateTime printDate = DateTime.Now;
            long ticks;
            if (TryGetLongParameter(parameters, "@PrintDate", out ticks))
            {
                printDate = new DateTime(ticks);
            }
            long? orgId = hasOrganization ? (long?) organizationId : null;
            long? sId = hasSite ? (long?) siteId : null;
            SetLanguage(lang, printDate, orgId, sId, manager);

            ReportRtlHelper.SetRTL(this);
        }

        protected internal static string GetFullLocationFromAdmUnitId(long admUnitId, GisReferenceType admUnitType)
        {
            switch (admUnitType)
            {
                case GisReferenceType.Country:
                    return LookupCache.GetLookupValue(admUnitId, LookupTables.Country, "strCountryName");

                case GisReferenceType.Region:
                    DataRow regionRow = LookupCache.GetLookupRow(admUnitId, LookupTables.Region.ToString());
                    if (regionRow == null)
                    {
                        return string.Empty;
                    }
                    string region = Utils.Str(regionRow["strRegionName"]);
                    string country = GetFullLocationFromAdmUnitId((long) regionRow["idfsCountry"], GisReferenceType.Country);
                    return string.Format("{0}, {1}", country, region);

                case GisReferenceType.Rayon:
                    DataRow rayonRow = LookupCache.GetLookupRow(admUnitId, LookupTables.Rayon.ToString());
                    if (rayonRow == null)
                    {
                        return string.Empty;
                    }
                    string rayon = Utils.Str(rayonRow["strRayonName"]);
                    string regionLocation = GetFullLocationFromAdmUnitId((long) rayonRow["idfsRegion"], GisReferenceType.Region);
                    return string.Format("{0}, {1}", regionLocation, rayon);

                case GisReferenceType.Settlement:
                    DataRow settlementRow = LookupCache.GetLookupRow(admUnitId, LookupTables.Settlement.ToString());
                    if (settlementRow == null)
                    {
                        return string.Empty;
                    }
                    string settlement = Utils.Str(settlementRow["strSettlementName"]);
                    string rayonLocation = GetFullLocationFromAdmUnitId((long) settlementRow["idfsRayon"], GisReferenceType.Rayon);
                    return string.Format("{0}, {1}", rayonLocation, settlement);

                default:
                    return string.Empty;
            }
        }

        protected internal static void AddBuildingHouseBinding
            (XRTableCell buildingCell, XRTableCell houseCell, string buildingMember, string houseMember)
        {
            buildingCell.DataBindings.Clear();
            houseCell.DataBindings.Clear();

            if (EidssSiteContext.Instance.IsIraqCustomization)
            {
                buildingCell.DataBindings.Add(new XRBinding("Text", null, buildingMember));
                buildingCell.TextAlignment = TextAlignment.MiddleLeft;
            }
            else if (EidssSiteContext.Instance.IsUsaAddressFormat)
            {
                buildingCell.DataBindings.Add(new XRBinding("Text", null, buildingMember));
                houseCell.DataBindings.Add(new XRBinding("Text", null, houseMember));
            }
            else
            {
                buildingCell.DataBindings.Add(new XRBinding("Text", null, houseMember));
                houseCell.DataBindings.Add(new XRBinding("Text", null, buildingMember));
            }
        }

        protected internal long? GetOrganizationId(IDictionary<string, string> parameters)
        {
            long organizationId;
            return TryGetLongParameter(parameters, "@OrganizationID", out organizationId)
                ? (long?) organizationId
                : null;
        }

        protected internal static string GetStringParameter(IDictionary<string, string> parameters, string paramName)
        {
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(parameters, "parameters");

            string outValue;
            if (!parameters.TryGetValue(paramName, out outValue))
            {
                throw new ArgumentException(string.Format("Could not get parameter {0}.", paramName));
            }
            if (string.IsNullOrEmpty(outValue))
            {
                throw new ArgumentException(string.Format("Parameter {0} contains empty value", paramName));
            }
            return outValue;
        }

        protected internal static long GetLongParameter(IDictionary<string, string> parameters, string paramName)
        {
            return long.Parse(GetStringParameter(parameters, paramName));
        }

        protected internal static bool TryGetStringParameter
            (IDictionary<string, string> parameters, string paramName, out string paramValue)
        {
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(parameters, "parameters");

            if (parameters.TryGetValue(paramName, out paramValue) && !string.IsNullOrEmpty(paramValue))
            {
                return true;
            }
            return false;
        }

        protected internal static bool TryGetLongParameter(IDictionary<string, string> parameters, string paramName, out long paramValue)
        {
            string param;
            paramValue = 0;
            if (TryGetStringParameter(parameters, paramName, out param))
            {
                return long.TryParse(param, out paramValue);
            }
            return false;
        }
    }
}