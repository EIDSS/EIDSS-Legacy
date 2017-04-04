using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class FilterHelper
    {
        public const string PageSizeA3 = "A3";
        public const string PageSizeA4 = "A4";

        private static readonly string[] m_Months =
        {
            "January", "February", "March", "April", "May", "June", "July", "August",
            "September", "October", "November", "December"
        };

        private static readonly string[] m_ReportCondition =
        {
            "cbReportCondition0", "cbReportCondition1", "cbReportCondition2",
            "cbReportCondition3", "cbReportCondition4"
        };

        private static readonly string[] m_Quarters = { "cbQuarter0", "cbQuarter1", "cbQuarter2", "cbQuarter3" };
        private static readonly string[] m_HalfYear = { "I", "II" };
        private static readonly string[] m_Counter = { "cbCounter0", "cbCounter1", "cbCounter2", "cbCounter3" };
        private static readonly string[] m_CounterThai = { "cbCounterThai0", "cbCounterThai1" };
        private static readonly string[] m_PeriodType = { "cbPeriodType0", "cbPeriodType1", "cbPeriodType2", "cbPeriodType3" };
        private static readonly string[] m_ReportSource = { "cbReportSource0", "cbReportSource1" };
        private static readonly string[] m_TimeUnits = { "day", "week", "month" };
        private static readonly string[] m_AnalysisMethods = { "CUSUM" };

        public static long? GetDefaultRegion(bool hasChe = false)
        {
            long? regionId;
            long? rayonId;
            GetDefaultLocation(out regionId, out rayonId, hasChe);
            return regionId;
        }

        public static long? GetDefaultRayon(bool hasChe = false)
        {
            long? regionId;
            long? rayonId;
            GetDefaultLocation(out regionId, out rayonId, hasChe);
            return rayonId;
        }

        public static void GetDefaultLocation(out long? regionId, out long? rayonId, bool hasChe = false)
        {
            regionId = null;
            rayonId = null;

            var parameters = new Dictionary<string, object>
            {
                {"@LangID", Localizer.lngEn},
                {"@IsCHE", hasChe ? 1 : 0},
                {"@SiteID", DBNull.Value}
            };
            DataTable locationTable = ExecSp("spRepSelectLocation", parameters);
            if (locationTable.Rows.Count != 0)
            {
                DataRow dataRow = locationTable.Rows[0];
                if (!(dataRow["idfsRegion"] is DBNull))
                {
                    regionId = (long)dataRow["idfsRegion"];
                }
                if (!(dataRow["idfsRayon"] is DBNull))
                {
                    rayonId = (long)dataRow["idfsRayon"];
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
                    throw new ArgumentException(String.Format("Unsupported Report Filter Type '{0}'", reportFilterType), "reportFilterType");
            }
            var parameters = new Dictionary<string, object> { { "@LangID", lang } };
            DataTable diagnosisTable = ExecSp(spName, parameters);
            List<SelectListItemSurrogate> result = diagnosisTable.Rows.Cast<DataRow>().Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["strName"].ToString(),
                    Value = r["idfsReference"].ToString(),
                }).ToList();
            return result;
        }

        public static List<SelectListItemSurrogate> GetTuberculosisDiagnosisList(string lang)
        {
            var parameters = new Dictionary<string, object> { { "@LangID", lang } };
            var diagnosisTable = ExecSp("spRepTuberculosisDiagnosisSelectLookup", parameters);
            var result = diagnosisTable.Rows.Cast<DataRow>().Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["strName"].ToString(),
                    Value = r["idfsReference"].ToString(),
                }).ToList();
            return result;
        }

        public static List<SelectListItemSurrogate> GetHumanDiagnosisList
            (string lang, bool sortAlphabetically = true, bool zoonoticDiseases = false, string additionalFilter = "")
        {
            var parameters = new Dictionary<string, object> { { "@LangID", lang }, { "@HACode", (int)HACode.Human } };
            var diagnosisTable = ExecSp("spDiagnosis_SelectLookup", parameters);
            var filter = zoonoticDiseases ? "blnZoonotic = 1" : string.Empty;
            if (additionalFilter.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter = string.Concat(filter, " and ");
                }
                filter = string.Concat(filter, additionalFilter);
            }
            var dv = diagnosisTable.Select(filter);
            var result = dv.Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["name"].ToString(),
                    Value = r["idfsDiagnosis"].ToString(),
                }).ToList();

            if (sortAlphabetically)
            {
                result.Sort((item1, item2) => string.CompareOrdinal(item1.Text, item2.Text));
            }
            return result;
        }

        public static List<SelectListItemSurrogate> GetHumanDiagnosisListStandardCaseOnly
            (string lang, bool sortAlphaBetically = true, bool needEmptyItem = true)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@LangID", lang}
                ,
                {"@HACode", (int) HACode.Human}
                ,
                {"@DiagnosisUsingType", (long) DiagnosisUsingTypeEnum.StandardCase}
            };
            var diagnosisTable = ExecSp("spDiagnosisRepare_SelectLookup", parameters);
            var dv = diagnosisTable.Select("[intRowStatus] = 0");
            var result = dv.Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["name"].ToString(),
                    Value = r["idfsDiagnosis"].ToString(),
                })
                .ToList();
            if (sortAlphaBetically)
            {
                result.Sort((item1, item2) => String.CompareOrdinal(item1.Text, item2.Text));
            }
            if (needEmptyItem)
            {
                InsertEmptyItem(result);
            }
            return result;
        }

        public static List<SelectListItemSurrogate> GetDiagnosisList
            (string lang, int hacode, DiagnosisUsingTypeEnum? usingType, bool zoonoticDiseases = false, bool addSelectAllItem = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@LangID", lang},
                {"@HACode", hacode},
                {"@DiagnosisUsingType", usingType}
            };
            var filter = zoonoticDiseases ? "blnZoonotic = 1" : string.Empty;
            var diagnosisTable = ExecSp("spDiagnosis_SelectLookup", parameters);
            var dv = diagnosisTable.Select(filter);
            var result = dv.Where(c => Convert.ToInt32(c["intRowStatus"]) == 0).Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["name"].ToString(),
                    Value = r["idfsDiagnosis"].ToString(),
                }).ToList();
            result.Sort((item1, item2) => string.CompareOrdinal(item1.Text, item2.Text));
            if (addSelectAllItem)
            {
                result.Insert(0, SelectAllItem);
            }
            return result;
        }

        public static List<SelectListItemSurrogate> GetZoonoticDiagnosisOrGroupList(string lang, bool addEmptyItem = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@LangID", lang},
            };
            var diagnosisTable = ExecSp("spZoonoticDiagnosesAndGroups_SelectLookup", parameters);
            var dv = diagnosisTable.Select("");
            var result = dv.Where(c => Convert.ToInt32(c["intRowStatus"]) == 0).Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["name"].ToString(),
                    Value = r["idfsDiagnosisOrDiagnosisGroup"].ToString(),
                    ClassName = (r["blnGroup"] != DBNull.Value && true.Equals(r["blnGroup"])
                        ? "clsGroup"
                        : (r["idfsDiagnosisGroup"] != DBNull.Value && (long)r["idfsDiagnosisGroup"] > 0)
                            ? "clsItemInGroup"
                            : "clsItemAsGroup")
                }).ToList();
            //result.Sort((item1, item2) => string.CompareOrdinal(item1.Text, item2.Text));
            if (addEmptyItem)
            {
                result.Insert(0, EmptyItem);
            }
            return result;
        }

        public static List<SelectListItemSurrogate> GetCaseClassificationsList
            (string lang, int hacode, bool isInitial, bool isFinal, bool needEmptyItem)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@LangID", lang},
                {"@HACode", hacode},
                {"@IsInitial", isInitial},
                {"@IsFinal", isFinal}
            };
            DataTable table = ExecSp("spCaseClassification_SelectLookup", parameters);
            List<SelectListItemSurrogate> result = table.Rows.Cast<DataRow>().Select(
                r => new SelectListItemSurrogate
                {
                    Text = r["name"].ToString(),
                    Value = r["idfsReference"].ToString(),
                }).ToList();
            result.Sort((item1, item2) => String.CompareOrdinal(item1.Text, item2.Text));
            if (needEmptyItem)
            {
                InsertEmptyItem(result);
            }
            return result;
        }

        public static List<SelectListItemSurrogate> GetAllRegions(string lang)
        {
            var parameters = new Dictionary<string, object> { { "@LangID", lang }, { "@CountryID", EidssSiteContext.Instance.CountryID } };
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

        public static List<SelectListItemSurrogate> GetAllRayons(string lang, long currentRayon = 0)
        {
            var parameters = new Dictionary<string, object> { { "@LangID", lang } };
            var diagnosisTable = ExecSp("spRayon_SelectLookup", parameters);
            var rows = diagnosisTable.Rows.Cast<DataRow>();
            var result = rows
                .Where(r => ((long)r["idfsCountry"]) == EidssSiteContext.Instance.CountryID)
                .Select(
                    r => new SelectListItemSurrogate
                    {
                        Text = r["strRayonName"].ToString(),
                        Value = String.Format("{0}__{1}", r["idfsRegion"], r["idfsRayon"]),
                        Selected = currentRayon > 0 && ((long)r["idfsRayon"] == currentRayon)
                    }).ToList();
            return result;
        }

        public static List<SelectListItemSurrogate> GetVetOrganizationList(VetReportType reportType, string lang)
        {
            string filter = String.Format("intRowStatus <> 1 AND strReportType = {0}", (long)reportType);
            List<SelectListItemSurrogate> organizations = GetOrganizationList("spRepVetOrganizationSelectLookup", lang, filter);

            return organizations;
        }

        public static List<SelectListItemSurrogate> GetHumOrganizationList(string lang)
        {
            return GetOrganizationList("spRepHumOrganizationSelectLookup", lang);
        }

        private static List<SelectListItemSurrogate> GetOrganizationList(string spLookupName, string lang, string rowFilter = null)
        {
            var parameters = new Dictionary<string, object> { { "@LangID", lang } };
            DataTable table = ExecSp(spLookupName, parameters);
            if (!String.IsNullOrEmpty(rowFilter))
            {
                table.DefaultView.RowFilter = rowFilter;
            }
            var result = new List<SelectListItemSurrogate> { EmptyItem };
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
                ? String.Empty
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
            if (String.IsNullOrEmpty(rayonRegionId))
            {
                return null;
            }

            const string pattern = @"(?<RegionId>-?\d*)__(?<RayonId>-?\d*)";
            Match match = Regex.Match(rayonRegionId, pattern);
            Group fieldGroup = match.Groups[searchName];
            return fieldGroup.Success && (fieldGroup.Captures.Count == 1)
                ? Int64.Parse(fieldGroup.Captures[0].Value)
                : (long?)null;
        }

        public static List<SelectListItemSurrogate> GetSupportedLanguages()
        {
            string[] configLanguages =
                Config.GetSetting("SupportedLanguages", Localizer.SupportedLanguages.Keys.Aggregate("", (s, i) => s + "," + i)).Split(',');
            IEnumerable<string> intersect = Localizer.SupportedLanguages.Keys.Intersect(configLanguages);
            List<SelectListItemSurrogate> languages = intersect
                .Select(c => new SelectListItemSurrogate
                {
                    Text = Localizer.GetMenuLanguageName(c),
                    Value = c,
                    Selected = String.Equals(c, Localizer.CurrentCultureLanguageID, StringComparison.InvariantCultureIgnoreCase),
                    //                    Selected = c == Thread.CurrentThread.CurrentCulture.Name.Substring(0, c.Length),
                })
                .ToList();

            return languages;
        }

        public static List<SelectListItemSurrogate> GetExportFormats()
        {
            List<SelectListItemSurrogate> items = Enum.GetNames(typeof(ReportExportType))
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

        public static List<ItemWrapper> GetWinAberrationDateFieldsList(int typeKeeper)
        {
            switch (typeKeeper)
            {
                case 1: //Human
                    return
                        GetWinCollectionFromEidssMessages(new[] { "cbDateFields10", "cbDateFields11", "cbDateFields12", "cbDateFields13", "cbDateFields14" });
                case 2: //Vet
                    return GetWinCollectionFromEidssMessages(new[] { "cbDateFields20", "cbDateFields21", "cbDateFields22" });
                case 3: // Syndromic
                    return GetWinCollectionFromEidssMessages(new[] { "cbDateFields30", "cbDateFields31", "cbDateFields32" });
                case 4: // todo: implement for ILISyndromicAberrationKeeper
                    return new List<ItemWrapper>();
                default:
                    throw new ArgumentOutOfRangeException("typeKeeper");
            }
        }

        public static List<SelectListItemSurrogate> GetWebAnalysisMethodsList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_AnalysisMethods, selectedIndex);
        }

        public static List<ItemWrapper> GetWinAnalysisMethodsList()
        {
            return GetWinCollectionFromEidssMessages(m_AnalysisMethods);
        }

        public static List<SelectListItemSurrogate> GetWebTimeUnitsList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_TimeUnits, selectedIndex);
        }

        public static List<ItemWrapper> GetWinTimeUnitsList()
        {
            return GetWinCollectionFromEidssMessages(m_TimeUnits);
        }

        public static List<SelectListItemSurrogate> GetWebReportConditionList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_ReportCondition, selectedIndex);
        }

        public static List<ItemWrapper> GetWinReportConditionList()
        {
            return GetWinCollectionFromEidssMessages(m_ReportCondition);
        }

        public static List<SelectListItemSurrogate> GetWebReportSourceList(int selectedIndex, bool addEmptyItem = false)
        {
            return GetWebCollectionFromEidssMessages(m_ReportSource, selectedIndex, addEmptyItem);
        }

        public static List<ItemWrapper> GetWinReportSourceList()
        {
            return GetWinCollectionFromEidssMessages(m_ReportSource);
        }

        public static List<SelectListItemSurrogate> GetWebPeriodTypeList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_PeriodType, selectedIndex);
        }

        public static List<ItemWrapper> GetWinPeriodTypeList()
        {
            return GetWinCollectionFromEidssMessages(m_PeriodType);
        }

        public static List<SelectListItemSurrogate> GetWebCounterList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_Counter, selectedIndex, false, 1);
        }

        public static List<ItemWrapper> GetWinCounterList()
        {
            return GetWinCollectionFromEidssMessages(m_Counter);
        }

        public static List<SelectListItemSurrogate> GetWebCounterThaiList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_CounterThai, selectedIndex, false, 1);
        }

        public static List<ItemWrapper> GetWinCounterThaiList()
        {
            return GetWinCollectionFromEidssMessages(m_CounterThai);
        }

        public static List<SelectListItemSurrogate> GetWebHalfYearList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_HalfYear, selectedIndex);
        }

        public static List<ItemWrapper> GetWinHalfYearList()
        {
            return GetWinCollectionFromEidssMessages(m_HalfYear);
        }

        public static List<SelectListItemSurrogate> GetWebQuarterList(int selectedIndex)
        {
            return GetWebCollectionFromEidssMessages(m_Quarters, selectedIndex);
        }

        public static List<ItemWrapper> GetWinQuarterList()
        {
            return GetWinCollectionFromEidssMessages(m_Quarters);
        }

        public static List<SelectListItemSurrogate> GetWebMonthList
            (int selectedIndex, bool isMandatory = true)
        {
            return GetWebCollectionFromEidssMessages(m_Months, selectedIndex, !isMandatory, 1);
        }

        public static List<ItemWrapper> GetWinMonthList()
        {
            return GetWinCollectionFromEidssMessages(m_Months);
        }

        public static string GetMonthName(int? month)
        {
            string monthName = month.HasValue && month.Value > 0 && month.Value < 13
                ? EidssMessages.Instance.GetString(m_Months[month.Value - 1])
                : string.Empty;

            return monthName;
        }

        public static string GetXmlFromList(IEnumerable<string> idList)
        {
            return GetXmlFromList("key", idList);
        }

        public static string GetXmlFromList(string keyName, IEnumerable<string> idList)
        {
            var xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine(@"<ItemList>");
            if (idList != null)
            {
                foreach (string diagnosis in idList)
                {
                    xmlBuilder.AppendFormat(@"<Item {0}=""{1}"" />", keyName, SecurityElement.Escape(diagnosis));
                    xmlBuilder.AppendLine();
                }
            }
            xmlBuilder.AppendLine(@"</ItemList>");
            return xmlBuilder.ToString();
        }

        private static void FillDataset(SqlDataAdapter adapter, DataSet ds)
        {
            try
            {
                adapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 1205)
                {
                    Thread.Sleep(BaseSettings.DeadlockDelay);
                    adapter.Fill(ds);
                }
                throw;
            }
        }
        private static void FillTable(SqlDataAdapter adapter, DataTable dt)
        {
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 1205)
                {
                    Thread.Sleep(BaseSettings.DeadlockDelay);
                    adapter.Fill(dt);
                }
                throw;
            }
        }

        private static DataTable ExecSp(string spName, Dictionary<string, object> parameters)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection)manager.Connection).CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    var dataSet = new DataSet();
                    adapter.SelectCommand = command;
                    FillDataset(adapter, dataSet);
                    if (dataSet.Tables.Count == 0)
                    {
                        throw new ApplicationException(String.Format("{0} returns no tables.", command.CommandText));
                    }
                    return dataSet.Tables[0];
                }
            }
        }
        private static DataTable ExecCommand(string cmdText, Dictionary<string, object> parameters)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection)manager.Connection).CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = cmdText;
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    var table = new DataTable();
                    adapter.SelectCommand = command;
                    FillTable(adapter, table);
                    return table;
                }
            }
        }

        private static List<SelectListItemSurrogate> GetWebCollectionFromEidssMessages
            (IEnumerable<string> englishDefaults, int selectedIndex, bool needEmptyValue = false,
                int initialIndex = 0)
        {
            var collection = new List<SelectListItemSurrogate>();
            int index = initialIndex;
            if (needEmptyValue)
            {
                collection.Add(EmptyItem);
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

        private static List<ItemWrapper> GetWinCollectionFromEidssMessages(string[] englishDefaults)
        {
            var collection = new List<ItemWrapper>();

            for (int index = 0; index < englishDefaults.Length; index++)
            {
                string itemName = EidssMessages.Instance.GetString(englishDefaults[index]);
                if (String.IsNullOrEmpty(itemName))
                {
                    itemName = englishDefaults[index];
                }
                collection.Add(new ItemWrapper(itemName, index + 1));
            }
            return collection;
        }

        public static SelectListItemSurrogate SelectAllItem
        {
            get
            {
                return new SelectListItemSurrogate()
                {
                    Text = EidssFields.Get("SelectAll"),
                    Value = "0",
                    Selected = false
                };
            }
        }

        public static SelectListItemSurrogate EmptyItem
        {
            get
            {
                return new SelectListItemSurrogate()
                {
                    Text = string.Empty,
                    Value = null
                };
            }
        }

        public static void InsertEmptyItem(List<SelectListItemSurrogate> list)
        {
            if (list.Find(i => i.Value == null) == null)
            {
                list.Insert(0, EmptyItem);
            }
        }

        public static List<SelectListItemSurrogate> GetAssignmentLabDiagnosticAZSendToLookup(string caseId, string lang)
        {

            var result = new List<SelectListItemSurrogate> { };
            if (string.IsNullOrWhiteSpace(caseId))
                return result;
            var parameters = new Dictionary<string, object> { { "@LangID", lang }, { "@CaseID", caseId } };
            DataTable table = ExecSp("spRepLabAssignmentDiagnosticAZSendToLookup", parameters);
            foreach (DataRowView row in table.DefaultView)
            {
                result.Add(new SelectListItemSurrogate
                {
                    Text = row["strName"].ToString(),
                    Value = row["idfsReference"].ToString(),
                });
            }

            return result;
        }

        public static List<SelectListItemSurrogate> GetActionMethods()
        {
            var result = new List<SelectListItemSurrogate> { };
            var parameters = new Dictionary<string, object> { { "@LangID", Localizer.CurrentCultureLanguageID }, { "@type", (long)BaseReferenceType.rftDiagnosticActionList } };
            DataTable table = ExecCommand("select idfsReference, name from dbo.fnReference(@LangID, @type)", parameters);
            result.AddRange(from DataRowView row in table.DefaultView
                            select new SelectListItemSurrogate
                            {
                                Text = row["name"].ToString(),
                                Value = row["idfsReference"].ToString(),
                            });
            table.Dispose();
            parameters["@type"] = (long)BaseReferenceType.rftProphilacticActionList;
            table = ExecCommand("select idfsReference, name from dbo.fnReference(@LangID, @type)", parameters);
            result.AddRange(from DataRowView row in table.DefaultView
                            select new SelectListItemSurrogate
                            {
                                Text = row["name"].ToString(),
                                Value = row["idfsReference"].ToString(),
                            });
            table.Dispose();
            return result;
        }

        public static List<SelectListItemSurrogate> GetSpeciesTypes(HACode accessory)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                int code = (int)accessory;
                var result = SpeciesTypeLookup.Accessor.Instance(null).SelectLookupList(manager)
                    .Where(c => c.intHACode.HasValue && (c.intHACode.Value & code) > 0).Select(r => new SelectListItemSurrogate
                {
                    Text = r.name,
                    Value = r.idfsBaseReference.ToString(),
                }).ToList();
                if (result.Count>0)
                    result.Insert(0, SelectAllItem);
                return result;
            }
        }

        public static List<SelectListItemSurrogate> GetLabSampleDepartments(string sampleId, string lang)
        {
            var result = new List<SelectListItemSurrogate> { };
            if (string.IsNullOrWhiteSpace(sampleId))
                return result;
            var parameters = new Dictionary<string, object> { { "@LangID", lang }, { "@SampleID", sampleId } };
            DataTable table = ExecSp("spRepLabTestingResultsDepartmentLookup", parameters);
            foreach (DataRowView row in table.DefaultView)
            {
                result.Add(new SelectListItemSurrogate
                {
                    Text = row["strName"].ToString(),
                    Value = row["idfsReference"].ToString(),
                });
            }

            return result;
        }
    }
}