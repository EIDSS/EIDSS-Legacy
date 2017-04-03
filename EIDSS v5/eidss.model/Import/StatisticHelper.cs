using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using BLToolkit.Data;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using System.Data;
using eidss.model.Enums;
using System.Data.SqlClient;
using eidss.model.Resources;
using System.Threading;
using bv.common.Core;


namespace eidss.model.Import
{
    public class StatisticHelper : IDisposable
    {
        private List<CsvError> m_Errors;
        //private List<BaseReference> m_StatisticTypes;
        private DataRow m_StatisticTypeRow = null;
        private DateTime m_StartDate;
        private DateTime m_FinishDate;
        private long m_PostedRowsQty;
        private long m_TotalRowsQty;
        public const int MaxErrorsQty = 50;
        private bool m_BreakImport = false;
        public Exception UnprocessedError { get; private set; }
        public int Result { get; private set; }
        public StatisticHelper()
        {
        }
        public event EventHandler ImportCompleted;
        public void DoImport()
        {
            try
            {
                Import(FileName, ForceImport);
            }
            catch (Exception e)
            {
                UnprocessedError = e;
                Result = -1;

            }
            if (ImportCompleted != null)
                ImportCompleted(this, EventArgs.Empty);
        }
        public int Import(string fileName, bool forcePost)
        {

            if (m_Errors != null)
                m_Errors.Clear();
            else
                m_Errors = new List<CsvError>();
            m_Lines = null;
            InitSettings();
            m_BreakImport = false;
            using(var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,
                                           System.IO.FileShare.ReadWrite))
            {
                
            using (var csv = new CsvReader(
                   new StreamReader(fs), true, ';'))
            {
                csv.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
                int fieldCount = csv.FieldCount;
                if (fieldCount != 9)
                {
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, 0, 0, "errStatisticImportFieldsQty", null, null, false));
                    return -1;
                }

                csv.ParseError += new EventHandler<ParseErrorEventArgs>(csv_ParseError);
                string[] headers = csv.GetFieldHeaders();
                m_PostedRowsQty = 0;
                m_TotalRowsQty = 0;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    manager.AuditParams = new object[] { AuditEventType.daeCreate, EIDSSAuditObject.daoStatistic, AuditTable.tlbStatistic, null };

                    manager.BeginTransaction();
                    try
                    {
                        while (csv.ReadNextRecord())
                        {
                            m_TotalRowsQty++;
                            if (!ValidateRecord(csv))
                                continue;
                            if (!PostRecord(csv, manager))
                                continue;
                            if (m_BreakImport || m_Errors.Count >= MaxErrorsQty)
                            {
                                manager.RollbackTransaction();
                                return 1;
                            }
                        }
                        if (m_Errors.Count == 0 || forcePost)
                        {
                            manager.SetEventParams("StatisticImport", new object[] { EventType.StatisticImport, null, string.Format("{0} of {1} records were imported", m_PostedRowsQty, m_TotalRowsQty) });
                            manager.CommitTransaction();
                        }
                        else
                            manager.RollbackTransaction();

                    }
                    catch
                    {
                        manager.RollbackTransaction();
                        throw;
                    }

                }
             }
 
           }

            return 0;
        }

        public string ResultMessage
        {
            get
            {
                if (m_Errors.Count == 0)
                    return EidssMessages.Get("msgImportSuccessfull", "Statistic data was successfully imported.");
                else if (m_Errors.Count < MaxErrorsQty)
                {
                    if (ForceImport)
                        return EidssMessages.Get("msgImportPatial", "Statistic data was patially imported. Some input data contains errors and was not imported.");
                    else
                        return EidssMessages.Get("msgImportPatialConfirm", "The following lines contain errors and will not be imported. Import data?");
                }
                else
                    return EidssMessages.Get("msgImportMaxErrorsExceeded", "Statistic data was not imported. Input data contains too many errors. Maximum errors number exceeded.");
            }
        }

        public string ErrorMessage
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                string lineMsgId = EidssMessages.Get("strLine", "Line");
                string colMsgId = EidssMessages.Get("strColumn", "Column");
                foreach (CsvError err in m_Errors)
                {
                    sb.Append(lineMsgId + " " + (err.LineNumber + 1).ToString()); //Line {0}
                    if (err.FieldNumber > 0)
                        sb.Append(", " + colMsgId + " " + (err.FieldNumber + 1).ToString()); //Line {0}, Column {0}
                    sb.Append(":"); //Line {0}, Column {0}:
                    if (!err.FormattedError)
                        sb.Append(EidssMessages.Get(err.MessageID));
                    else
                        sb.Append(string.Format(EidssMessages.Get(err.MessageID), Utils.Str(err.BadValue)));
                    if (!string.IsNullOrEmpty(err.LineValue))
                    {
                        sb.AppendLine();
                        sb.Append(err.LineValue);
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
        }


        public List<CsvError> Errors
        {
            get { return m_Errors; }
        }

        public long RowsAffected
        {
            get { return m_PostedRowsQty; }
        }

        private enum StatisticFields
        {
            StatisticDataType = 0,
            StartDate = 1,
            Country = 2,
            Region = 3,
            Rayon = 4,
            Settlement = 5,
            AgeGroup = 6,
            Parameter = 7,
            Value = 8
        }

        private DataTable m_SettingsTable;
        private void InitSettings()
        {
            using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                m_SettingsTable = manager.SetSpCommand("spStatisticType_SelectDetail", manager.Parameter("LangID", "en")).ExecuteDataTable();
            }
            m_PostedRowsQty = 0;
        }
        private string[] m_Lines = null;
        private string GetLine(string rawData, long index)
        {
            if (m_Lines == null)
                m_Lines = rawData.Split('\r');
            if (m_Lines != null && m_Lines.LongLength > index)
                return m_Lines[index];
            return "";
        }
        private string GetLine(CsvReader csv)
        {
            long index = csv.HasHeaders ? csv.CurrentRecordIndex + 1 : csv.CurrentRecordIndex;
            if (m_Lines != null && m_Lines.LongLength > index)
                return m_Lines[index];
            else
                return GetLine(csv.GetCurrentRawData(), index);
        }
        private bool ValidateRecord(CsvReader csv)
        {
            for (int i = 0; i < csv.FieldCount; i++)
            {
                string s = csv[i];
                if (csv.ParseErrorFlag)
                    return false;
            }

            DataRow[] rows = m_SettingsTable.Select(string.Format("name='{0}'", csv[(int)StatisticFields.StatisticDataType]));
            if (rows.Length > 0)
                m_StatisticTypeRow = rows[0];
            else
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.StatisticDataType, 0, "errInvalidStatisticType", csv[(int)StatisticFields.StatisticDataType], GetLine(csv)));
                return false;
            }
            if (!ValidateDate(csv))
                return false;
            if (!ValidateArea(csv))
                return false;
            int val;
            if (!int.TryParse(csv[(int)StatisticFields.Value], out val))
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Value, 0, "errInvalidStatisticValue", csv[(int)StatisticFields.Value], GetLine(csv)));
                return false;
            }

            return true;
        }

        private bool ValidateDate(CsvReader csv)
        {
            if (!DateTime.TryParse(csv[(int)StatisticFields.StartDate], System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out m_StartDate))
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.StartDate, 0, "errInvalidDateFormat", csv[(int)StatisticFields.StartDate], GetLine(csv)));
                return false;
            }
            StatisticPeriodType periodType = (StatisticPeriodType)m_StatisticTypeRow["idfsStatisticPeriodType"];
            switch (periodType)
            {
                case StatisticPeriodType.Day:
                    m_FinishDate = m_StartDate;
                    break;
                case StatisticPeriodType.Month:
                    if (m_StartDate.Day != 1)
                    {
                        m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.StartDate, 0, "errInvalidMonthStartDate", csv[(int)StatisticFields.StartDate], GetLine(csv)));
                        return false;
                    }
                    m_FinishDate = m_StartDate.AddMonths(1).AddDays(-1);
                    break;
                case StatisticPeriodType.Quarter:
                    if (m_StartDate.Day != 1 || m_StartDate.Month != 1 || m_StartDate.Month != 4 || m_StartDate.Month != 7 || m_StartDate.Month != 10)
                    {
                        m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.StartDate, 0, "errInvalidQuarterStartDate", csv[(int)StatisticFields.StartDate], GetLine(csv)));
                        return false;
                    }
                    m_FinishDate = m_StartDate.AddMonths(3).AddDays(-1);
                    break;
                case StatisticPeriodType.Week:
                    if (m_StartDate.DayOfWeek != System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                    {
                        m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.StartDate, 0, "errInvalidWeekStartDate", csv[(int)StatisticFields.StartDate], GetLine(csv)));
                        return false;
                    }
                    m_FinishDate = m_StartDate.AddDays(6);
                    break;
                case StatisticPeriodType.Year:
                    if (m_StartDate.DayOfYear != 1)
                    {
                        m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.StartDate, 0, "errInvalidYearStartDate", csv[(int)StatisticFields.StartDate], GetLine(csv)));
                        return false;
                    }
                    m_FinishDate = m_StartDate.AddYears(1).AddDays(-1);
                    break;
            }



            return true;
        }

        private bool ValidateArea(CsvReader csv)
        {
            if (string.IsNullOrEmpty(csv[(int)StatisticFields.Country]))
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Country, 0, "errInvalidCountry", csv[(int)StatisticFields.Country], GetLine(csv)));
                return false;
            }
            StatisticAreaType areaType = (StatisticAreaType)m_StatisticTypeRow["idfsStatisticAreaType"];
            if (string.IsNullOrEmpty(csv[(int)StatisticFields.Region]) && areaType != StatisticAreaType.Country)
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Region, 0, "errInvalidRegion", csv[(int)StatisticFields.Region], GetLine(csv)));
                return false;
            }

            if (string.IsNullOrEmpty(csv[(int)StatisticFields.Rayon]) && (areaType == StatisticAreaType.Rayon || areaType == StatisticAreaType.Settlement))
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Rayon, 0, "errInvalidRayon", csv[(int)StatisticFields.Rayon], GetLine(csv)));
                return false;
            }
            if (string.IsNullOrEmpty(csv[(int)StatisticFields.Settlement]) && areaType == StatisticAreaType.Settlement)
            {
                m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Settlement, 0, "errInvalidSettlement", csv[(int)StatisticFields.Settlement], GetLine(csv)));
                return false;
            }

            return true;

        }
        private bool PostRecord(CsvReader csv, DbManager manager)
        {
            int returnValue = 0;

            int rowAffected = manager.SetSpCommand("spStatistic_Import"
                            , manager.Parameter("idfsStatisticDataType", m_StatisticTypeRow["idfsBaseReference"])
                            , manager.Parameter("strParameterValue", csv[(int)StatisticFields.Parameter])
                            , manager.Parameter("idfsStatisticAreaType", m_StatisticTypeRow["idfsStatisticAreaType"])
                            , manager.Parameter("idfsStatisticPeriodType", m_StatisticTypeRow["idfsStatisticPeriodType"])
                            , manager.Parameter("strCountry", csv[(int)StatisticFields.Country])
                            , manager.Parameter("strRegion", csv[(int)StatisticFields.Region])
                            , manager.Parameter("strRayon", csv[(int)StatisticFields.Rayon])
                            , manager.Parameter("strSettlement", csv[(int)StatisticFields.Settlement])
                            , manager.Parameter("datStatisticStartDate", m_StartDate)
                            , manager.Parameter("datStatisticFinishDate", m_FinishDate)
                            , manager.Parameter("blnRelatedWithAgeGroup", m_StatisticTypeRow["blnRelatedWithAgeGroup"])
                            , manager.Parameter("strStatisticalAgeGroup", csv[(int)StatisticFields.AgeGroup])
                            , manager.Parameter("varValue", int.Parse(csv[(int)StatisticFields.Value]))
                            ).ExecuteNonQuery();
            returnValue = (int)((SqlParameter)(manager.Command.Parameters["@RETURN_VALUE"])).Value;
            if (rowAffected > 0)
                m_PostedRowsQty += 1;
            switch (returnValue)
            {
                case 1:
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Country, 0, "errInvalidCountry", csv[(int)StatisticFields.Country], GetLine(csv)));
                    break;
                case 2:
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Region, 0, "errInvalidRegion", csv[(int)StatisticFields.Region], GetLine(csv)));
                    break;
                case 3:
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Rayon, 0, "errInvalidRayon", csv[(int)StatisticFields.Rayon], GetLine(csv)));
                    break;
                case 4:
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Settlement, 0, "errInvalidSettlement", csv[(int)StatisticFields.Settlement], GetLine(csv)));
                    break;
                case 5:
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.Parameter, 0, "errInvalidParameter", csv[(int)StatisticFields.Parameter], GetLine(csv)));
                    break;
                case 6:
                    m_Errors.Add(new CsvError(csv.CurrentRecordIndex, (int)StatisticFields.AgeGroup, 0, "errInvalidStatisticalAgeGroup", csv[(int)StatisticFields.AgeGroup], GetLine(csv)));
                    break;
            }

            return true;
        }


        void csv_ParseError(object sender, ParseErrorEventArgs e)
        {
            var exMissingField = e.Error as MissingFieldCsvException;
            var exMalrormed = e.Error as MalformedCsvException;
            long lineNumber = e.Error.CurrentRecordIndex + 1;
            if (exMissingField != null)
            {
                m_Errors.Add(new CsvError(exMissingField.CurrentRecordIndex, exMissingField.CurrentFieldIndex, exMissingField.CurrentPosition, "errMissingField", null, GetLine(e.Error.RawData, lineNumber), false));
            }
            else if (exMalrormed != null)
            {
                m_Errors.Add(new CsvError(exMalrormed.CurrentRecordIndex, exMalrormed.CurrentFieldIndex, exMalrormed.CurrentPosition, "errMalFormedCvs", exMalrormed.CurrentPosition.ToString(CultureInfo.InvariantCulture), GetLine(e.Error.RawData, lineNumber)));
            }
            e.Action = ParseErrorAction.AdvanceToNextLine;
        }

        public void Dispose()
        {
            if (m_SettingsTable != null)
                m_SettingsTable.Dispose();
        }

        public void BreakImport()
        {
            m_BreakImport = true;
        }

        public string FileName { get; set; }

        public bool ForceImport { get; set; }
    }

}
