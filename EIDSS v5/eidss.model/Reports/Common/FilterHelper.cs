using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Resources;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class FilterHelper
    {
        public const string PageSizeA3 = "A3";
        public const string PageSizeA4 = "A4";

        public static long? GetDefaultRegion()
        {
            long? regionId;
            long? rayonId;
            GetDefaultLocation(out regionId, out rayonId);
            return regionId;
        }

        public static long? GetDefaultRayon()
        {
            long? regionId;
            long? rayonId;
            GetDefaultLocation(out regionId, out rayonId);
            return rayonId;
        }

        public static void GetDefaultLocation(out long? regionId, out long? rayonId)
        {
            regionId = null;
            rayonId = null;

            DataTable locationTable = ExecSp("spRepHumFormN1Location", new Dictionary<string, object> {{"@LangID", Localizer.lngEn}});
            if (locationTable.Rows.Count != 0)
            {
                DataRow dataRow = locationTable.Rows[0];
                if (!(dataRow["idfsRegion"] is DBNull))
                {
                    regionId = (long) dataRow["idfsRegion"];
                }
                if (!(dataRow["idfsRayon"] is DBNull))
                {
                    rayonId = (long) dataRow["idfsRayon"];
                }
            }
        }

        public static List<SelectListItemSurrogate> GetKzFilterList(string lang, ReportFilterType reportFilterType)
        {
            string spName;
            switch (reportFilterType)
            {
                case ReportFilterType.DiagnosticInvestigationDiagnosis:
                    spName = "spRepVetDiagnosisInvDiagnosisSelectLookup";
                    break;
                case ReportFilterType.DiagnosticInvestigationSpecies:
                    spName = "spRepVetDiagnosisInvSpeciesSelectLookup";
                    break;
                case ReportFilterType.DiagnosticInvestigationType:
                    spName = "spRepVetDiagnosisInvTypeSelectLookup";
                    break;
                case ReportFilterType.ProphylacticDiagnosis:
                    spName = "spRepVetProphylacticDiagnosisSelectLookup";
                    break;
                case ReportFilterType.ProphylacticMeasureType:
                    spName = "spRepVetProphylacticTypeSelectLookup";
                    break;
                case ReportFilterType.ProphylacticSpecies:
                    spName = "spRepVetProphylacticSpeciesSelectLookup";
                    break;
                case ReportFilterType.SanitaryMeasureTypeName:
                    spName = "spRepVetSanitarySelectLookup";
                    break;
                default:
                    throw new ArgumentException(string.Format("Unsupported Report Filter Type '{0}'", reportFilterType), "reportFilterType");
            }
            var parameters = new Dictionary<string, object> {{"@LangID", lang}};
            DataTable diagnosisTable = ExecSp(spName, parameters);
            List<SelectListItemSurrogate> result = diagnosisTable.Rows.Cast<DataRow>().Select(
                r => new SelectListItemSurrogate
                    {
                        Text = r["strName"].ToString(),
                        Value = r["idfsReference"].ToString(),
                    }).ToList();
            return result;
        }

        public static List<SelectListItemSurrogate> GetHumanDiagnosisList(string lang)
        {
            var parameters = new Dictionary<string, object> {{"@LangID", lang}, {"@HACode", (int) HACode.Human}};
            DataTable diagnosisTable = ExecSp("spDiagnosis_SelectLookup", parameters);
            List<SelectListItemSurrogate> result = diagnosisTable.Rows.Cast<DataRow>().Select(
                r => new SelectListItemSurrogate
                    {
                        Text = r["name"].ToString(),
                        Value = r["idfsDiagnosis"].ToString(),
                    }).ToList();
            result.Sort((item1, item2)=>String.CompareOrdinal(item1.Text, item2.Text));
            return result;
        }

        public static List<SelectListItemSurrogate> GetAllRegions(string lang)
        {
            var parameters = new Dictionary<string, object> {{"@LangID", lang}, {"@CountryID", EidssSiteContext.Instance.CountryID}};
            DataTable diagnosisTable = ExecSp("spRegion_SelectLookup", parameters);
            IEnumerable<DataRow> rows = diagnosisTable.Rows.Cast<DataRow>();
            List<SelectListItemSurrogate> result = rows
                .Select(
                    r => new SelectListItemSurrogate
                        {
                            Text = r["strRegionName"].ToString(),
                            Value = r["idfsRegion"].ToString(),
                        }).ToList();
            return result;
        }

        public static List<SelectListItemSurrogate> GetAllRayons(string lang)
        {
            var parameters = new Dictionary<string, object> {{"@LangID", lang}};
            DataTable diagnosisTable = ExecSp("spRayon_SelectLookup", parameters);
            IEnumerable<DataRow> rows = diagnosisTable.Rows.Cast<DataRow>();
            List<SelectListItemSurrogate> result = rows
                .Where(r => ((long) (r["idfsCountry"])) == EidssSiteContext.Instance.CountryID)
                .Select(
                    r => new SelectListItemSurrogate
                        {
                            Text = r["strRayonName"].ToString(),
                            Value = string.Format("{0}__{1}", r["idfsRegion"], r["idfsRayon"]),
                        }).ToList();
            return result;
        }

        public static List<SelectListItemSurrogate> GetVetOrganizationList(VetReportType reportType, string lang)
        {
            string filter = string.Format("intRowStatus <> 1 AND strReportType like '%{0}%'", (long)reportType);
            var organizations = GetOrganizationList("spRepVetOrganizationSelectLookup", lang, filter);
           
            return organizations;
        }

        public static List<SelectListItemSurrogate> GetHumOrganizationList(string lang)
        {
            return GetOrganizationList("spRepHumOrganizationSelectLookup", lang);
        }

        private static List<SelectListItemSurrogate> GetOrganizationList(string spLookupName, string lang, string rowFilter = null)
        {
            var parameters = new Dictionary<string, object> {{"@LangID", lang}};
            DataTable table = ExecSp(spLookupName, parameters);
            if (!string.IsNullOrEmpty(rowFilter))
            {
                table.DefaultView.RowFilter = rowFilter;
            }
            var result = new List<SelectListItemSurrogate> {new SelectListItemSurrogate {Text = string.Empty, Value = null,}};
            foreach (DataRowView row in table.DefaultView)
            {
                result.Add(new SelectListItemSurrogate
                    {
                        Text = row["name"].ToString(),
                        Value = row["idfInstitution"].ToString(),
                    });
            }
            
            return result;
        }

        public static string GetVetOrganizationName(long id, string lang)
        {
            return GetOrganizationName("spRepVetOrganizationSelectLookup", id, lang);
        }
        public static string GetHumOrganizationName(long id, string lang)
        {
            return GetOrganizationName("spRepHumOrganizationSelectLookup", id, lang);
        }

        public static string GetOrganizationName(string spLookupName, long id, string lang)
        {
            var parameters = new Dictionary<string, object> { { "@LangID", lang }, { "@ID", id } };
            DataTable diagnosisTable = ExecSp(spLookupName, parameters);
            return diagnosisTable.Rows.Count == 0
                       ? string.Empty
                       : diagnosisTable.Rows[0]["name"].ToString();
        }

       
        public static long? GetRegionIdFromComplexId(string complexId)
        {
            return GetRayonRegionMatch(complexId, "RegionId");
        }

        public static long? GetRayonIdFromComplexId(string complexId)
        {
            return GetRayonRegionMatch(complexId, "RayonId");
        }

        private static long? GetRayonRegionMatch(string rayonRegionId, string searchName)
        {
            if (string.IsNullOrEmpty(rayonRegionId))
            {
                return null;
            }

            const string pattern = @"(?<RegionId>-?\d*)__(?<RayonId>-?\d*)";
            Match match = Regex.Match(rayonRegionId, pattern);
            Group fieldGroup = match.Groups[searchName];
            return fieldGroup.Success && (fieldGroup.Captures.Count == 1)
                       ? long.Parse(fieldGroup.Captures[0].Value)
                       : (long?) null;
        }

        public static List<SelectListItemSurrogate> GetSupportedLanguages()
        {
            List<SelectListItemSurrogate> languages = Localizer.SupportedLanguages.Keys
                                                      .Select(c => new SelectListItemSurrogate
                                                          {
                                                              Text = Localizer.GetMenuLanguageName(c),
                                                              Value = c,
                                                              Selected = c == Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName
                                                          })
                                                      .ToList();

            return languages;
        }

        public static List<SelectListItemSurrogate> GetExportFormats()
        {
            List<SelectListItemSurrogate> items = Enum.GetNames(typeof (ReportExportType))
                                             .Select(c => new SelectListItemSurrogate
                                                 {
                                                     Text = c,
                                                     Value = c,
                                                     Selected = c == ReportExportType.Pdf.ToString()
                                                 })
                                             .ToList();
            return items;
        }

        public static List<SelectListItemSurrogate> GetPageSizeList()
        {
            var collection = new List<SelectListItemSurrogate>
                {
                    new SelectListItemSurrogate {Text = PageSizeA3, Value = PageSizeA3, Selected = false},
                    new SelectListItemSurrogate {Text = PageSizeA4, Value = PageSizeA4, Selected = true}
                };

            return collection;
        }

        public static List<SelectListItemSurrogate> GetPeriodTypeList(int selectedIndex)
        {
            var defaults = new[] {"cbPeriodType0", "cbPeriodType1", "cbPeriodType2", "cbPeriodType3"};
            return GetCollectionFromEidssMessages(defaults, selectedIndex);
        }

        public static List<SelectListItemSurrogate> GetCounterList(int selectedIndex)
        {
            var defaults = new[] {"cbCounter0", "cbCounter1", "cbCounter2", "cbCounter3"};
            return GetCollectionFromEidssMessages(defaults, selectedIndex);
        }

        public static List<SelectListItemSurrogate> GetHalfYearList(int selectedIndex)
        {
            var defaults = new[] {"I", "II"};
            return GetCollectionFromEidssMessages(defaults, selectedIndex);
        }

        public static List<SelectListItemSurrogate> GetQuarterList(int selectedIndex)
        {
            var defaults = new[] {"1", "2", "3", "4"};
            return GetCollectionFromEidssMessages(defaults, selectedIndex);
        }

        public static List<SelectListItemSurrogate> GetMonthList(int selectedIndex, bool isMandatory = true)
        {
            var defaultMonth = new[]
                {
                    "January", "February", "March", "April", "May", "June", "July", "August",
                    "September", "October", "November", "December"
                };
            return GetCollectionFromEidssMessages(defaultMonth, selectedIndex, isMandatory);
        }

        public static string GetXmlFromList(string[] diagnosisList)
        {
            var xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine(@"<ItemList>");
            if (diagnosisList != null)
            {
                foreach (string diagnosis in diagnosisList)
                {
                    xmlBuilder.AppendFormat(@"<Item key=""{0}"" value=""""/>", SecurityElement.Escape(diagnosis));
                    xmlBuilder.AppendLine();
                }
            }
            xmlBuilder.AppendLine(@"</ItemList>");
            return xmlBuilder.ToString();
        }

        private static DataTable ExecSp(string spName, Dictionary<string, object> parameters)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    var dataSet = new DataSet();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataSet);
                    if (dataSet.Tables.Count == 0)
                    {
                        throw new ApplicationException(String.Format("{0} returns no tables.", command.CommandText));
                    }
                    return dataSet.Tables[0];
                }
            }
        }

        private static List<SelectListItemSurrogate> GetCollectionFromEidssMessages
            (IEnumerable<string> englishDefaults, int selectedIndex, bool isMandatory = true)
        {
            var collection = new List<SelectListItemSurrogate>();
            int index = 0;
            if (!isMandatory)
            {
                collection.Add(new SelectListItemSurrogate {Text = string.Empty, Value = null,});
                index++;
                selectedIndex++;
            }
            foreach (string englishDefault in englishDefaults)
            {
                var item = new SelectListItemSurrogate
                    {
                        Text = EidssMessages.Instance.GetString(englishDefault),
                        Value = index.ToString(),
                        Selected = (index == selectedIndex)
                    };
                collection.Add(item);
                index++;
            }

            return collection;
        }
    }
}