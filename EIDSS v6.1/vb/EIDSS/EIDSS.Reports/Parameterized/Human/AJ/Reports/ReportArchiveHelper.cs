using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using bv.common.Core;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public static class ReportArchiveHelper
    {
        private static readonly Regex m_IndexRegex = new Regex(@"\.*_(?<Id>-?\d+)", RegexOptions.RightToLeft);

        public const string DiagnosisNamePrefix = "strDiagnosis_";
        public const string SpeciesNamePrefix = "strSpecies_";
        public const string FirstSubColumnPrefix = "intFirstSubcolumn_";
        public const string SecondSubColumnPrefix = "intSecondSubcolumn_";

        public const string TempPrefix = "TEMP_";

        public static List<string> GetCaptionsAndAssignToColumns(DataTable data, string columnPrefix)
        {
            Dictionary<string, string> captions = GetCaptionsDictionaryAndAssignToColumns(data, columnPrefix);
            return captions.Keys.ToList();
        }

        public static Dictionary<string, string> GetCaptionsDictionaryAndAssignToColumns(DataTable data, string columnPrefix)
        {
            Dictionary<string, string> captions = GetCaptions(data, columnPrefix);
            foreach (KeyValuePair<string, string> pair in captions)
            {
                string columnName = pair.Value;
                data.Columns[columnName].Caption = pair.Key;
            }
            return captions;
        }

        public static Dictionary<string, string> GetCaptions(DataTable data, string columnPrefix)
        {
            var result = new Dictionary<string, string>();
            if (data.Rows.Count > 0)
            {
                IEnumerable<DataColumn> columns = data.Columns
                    .Cast<DataColumn>()
                    .Where(c => c.ColumnName.Contains(columnPrefix));
                foreach (DataColumn column in columns)
                {
                    column.ReadOnly = false;
                    string firstValue = Utils.Str(data.Rows[0][column]);
                    if (!string.IsNullOrEmpty(firstValue))
                    {
                        if (result.ContainsKey(firstValue))
                        {
                            throw new ApplicationException(String.Format("Duplicate column {0}", firstValue));
                        }
                        result.Add(firstValue, column.ColumnName);
                    }
                }
            }
            return result;
        }

        public static void RemoveAndAddColumnToArchive(DataTable actualData, DataTable archiveData)
        {
            var archiveColumnList = new List<DataColumn>();

            Dictionary<string, string> actualSpeciesCaptions = GetCaptionsDictionaryAndAssignToColumns(actualData, SpeciesNamePrefix);
            Dictionary<string, string> archiveSpeciesCaptions = GetCaptionsDictionaryAndAssignToColumns(archiveData, SpeciesNamePrefix);
            foreach (KeyValuePair<string, string> speciesPair in actualSpeciesCaptions)
            {
                DataColumn archiveSpeciesColumn = FindOrCreateColumn(archiveData, archiveSpeciesCaptions, speciesPair.Key);

                string actualSpecies = speciesPair.Value;
                long actualSpeciesIndex = GetIndexSuffixFromName(actualSpecies);
                long archiveSpeciesIndex = GetIndexSuffixFromName(archiveSpeciesColumn.ColumnName);
                archiveSpeciesColumn.ColumnName = TempPrefix + actualSpecies;
                archiveColumnList.Add(archiveSpeciesColumn);

                DataColumn firstSubColumn = FindOrCreateSubColumn(FirstSubColumnPrefix, actualSpeciesIndex,
                    archiveData, archiveSpeciesIndex);
                archiveColumnList.Add(firstSubColumn);
                DataColumn secondSubColumn = FindOrCreateSubColumn(SecondSubColumnPrefix, actualSpeciesIndex,
                    archiveData, archiveSpeciesIndex);
                archiveColumnList.Add(secondSubColumn);
            }
            for (int i = archiveColumnList.Count - 1; i >= 0; i--)
            {
                DataColumn column = archiveColumnList[i];
                string columnName = column.ColumnName.Replace(TempPrefix, string.Empty);
                if (archiveData.Columns.Contains(columnName))
                {
                    archiveData.Columns.Remove(columnName);
                }

                column.ColumnName = columnName;
                column.SetOrdinal(archiveData.Columns.Count - archiveColumnList.Count + i);
            }

            List<DataColumn> columnsToRemove = archiveData.Columns.Cast<DataColumn>()
                .Where(column => !actualData.Columns.Contains(column.ColumnName))
                .ToList();

            foreach (DataColumn column in columnsToRemove)
            {
                archiveData.Columns.Remove(column);
            }
        }

        private static DataColumn FindOrCreateColumn
            (DataTable archiveData, Dictionary<string, string> archiveCaptions, string actualCaption)
        {
            DataColumn archiveDiagnosisColumn;
            if (archiveCaptions.ContainsKey(actualCaption))
            {
                string name = archiveCaptions[actualCaption];
                archiveDiagnosisColumn = archiveData.Columns[name];
            }
            else
            {
                archiveDiagnosisColumn = archiveData.Columns.Add(TempPrefix, typeof (String));
                archiveDiagnosisColumn.Caption = actualCaption;
            }
            return archiveDiagnosisColumn;
        }

        private static DataColumn FindOrCreateSubColumn
            (string subcolumnPrefix, long actualSpeciesIndex, DataTable archiveData, long archiveSpeciesIndex)
        {
            string archiveSubcolumnName = string.Format("{0}{1}", subcolumnPrefix, archiveSpeciesIndex);
            DataColumn archiveFirstSubcolumn = archiveData.Columns.Contains(archiveSubcolumnName)
                ? archiveData.Columns[archiveSubcolumnName]
                : archiveData.Columns.Add(TempPrefix, typeof (int));
            archiveFirstSubcolumn.ColumnName = string.Format("{0}{1}{2}",
                TempPrefix, subcolumnPrefix, actualSpeciesIndex);
            return archiveFirstSubcolumn;
        }

        public static long GetIndexSuffixFromName(string fieldName)
        {
            if (String.IsNullOrEmpty(fieldName))
            {
                return -1;
            }

            Match match = m_IndexRegex.Match(fieldName);
            Group idGroup = match.Groups["Id"];

            long id;
            return idGroup.Success && (idGroup.Captures.Count == 1) &&
                   (Int64.TryParse(idGroup.Captures[0].Value, out id))
                ? id
                : -1;
        }
    }
}