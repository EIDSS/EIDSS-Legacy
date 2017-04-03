using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.common.Core;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.model.Model
{
    /// <summary>
    /// Класс для таблицы суммирования
    /// </summary>
    public class SummaryTable
    {
        public long idTestName { get; private set; }

        public string TestName { get; private set; }

        public DataTable DataSource { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldTest"></param>
        /// <returns></returns>
        public string GetColumnName(VectorFieldTest fieldTest)
        {
            return 
                fieldTest.idfsPensideTestResult.HasValue ?
                GetColumnName(fieldTest.idfsPensideTestResult.Value, fieldTest.strPensideTestResultName)
                : fieldTest.strPensideTestResultName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labTest"></param>
        /// <returns></returns>
        public string GetColumnName(VectorLabTest labTest)
        {
            return
                labTest.idfsTestResult.HasValue ?
                GetColumnName(labTest.idfsTestResult.Value, labTest.strTestResultName)
                : labTest.strTestResultName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public string GetColumnName(TypeFieldTestToResultMatrixLookup matrix)
        {
            return GetColumnName(matrix.idfsPensideTestResult, matrix.strPensideTestResultName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public string GetColumnName(TypeLabTestToResultMatrixLookup matrix)
        {
            return GetColumnName(matrix.idfsTestResult, matrix.strTestResultName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idResult"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetColumnName(long idResult, string name)
        {
            return String.Format("Result_{0}_{1}", idResult, name);
        }

        /// <summary>
        /// Создаёт таблицу на основе тестов определённого типа
        /// </summary>
        /// <param name="fieldTests"></param>
        /// <param name="idfsTestName"></param>
        /// <param name="strTestName"></param>
        public void ParseTestTable(EditableList<VectorFieldTest> fieldTests, long idfsTestName, string strTestName)
        {
            /* TODO
            idTestName = idfsTestName;
            TestNameName = strTestName;

            if (DataSource == null) DataSource = new DataTable();
            else DataSource.Clear();

            var fieldTestsFiltered = fieldTests.Where(c => c.idfsPensideTestName == idTestName).ToList();
            if (fieldTestsFiltered.Count == 0) return;

            //в столбцах -- возможные результаты теста для этого типа теста (не только заполненные)
            var results = fieldTests[0].TypeFieldTestToResultMatrix.Where(c => c.idfsPensideTestName == idTestName).ToList();
            if (results.Count == 0) return;
            DataSource.Columns.Add(new DataColumn("Caption", typeof (string)) {Caption = String.Empty}); //названия типов семплов
            foreach (var matrixItem in results)
            {
                var column = new DataColumn(GetColumnName(matrixItem), typeof (Int32))
                                 {Caption = matrixItem.strPensideTestResultName};

                DataSource.Columns.Add(column);
            }
            //добавляем столбец для суммирования
            DataSource.Columns.Add(new DataColumn("Summary", typeof (Int32)));

            //в строках -- типы семплов (кровь,..)
            var usedSpecimenTypes = new List<long>();
            foreach (var fieldTest in fieldTestsFiltered)
            {
                if (fieldTest.IsMarkedToDelete) continue;
                var idSpecimenType = fieldTest.idfsSampleType;
                if (usedSpecimenTypes.Contains(idSpecimenType)) continue;
                var row = DataSource.NewRow();
                row["Caption"] = fieldTest.strSampleName;
                //по каждому столбцу вычисляем количество и заполняем таблицу
                var i = 1; //потому что первый столбец -- заголовок типа семпла
                var sum = 0;
                foreach (var matrix in results)
                {
                    //результат в конкретном столбце (порядок совпадает)
                    var idResult = matrix.idfsPensideTestResult;
                    var count = fieldTestsFiltered.Count(c => (c.idfsPensideTestResult == idResult) && (c.idfsSampleType == idSpecimenType));
                    sum += count;
                    row[i] = count;

                    i++;
                }
                row["Summary"] = sum;
                DataSource.Rows.Add(row);
                usedSpecimenTypes.Add(idSpecimenType);
            }

            //добавляем строку финального итого
            var rowSummary = DataSource.NewRow();
            rowSummary["Caption"] = EidssFields.Get("SummaryCaption", "Summary");
            var sumTotal = 0;
            for (var numColumn = 1; numColumn < DataSource.Columns.Count - 1; numColumn++) //потому что первый столбец -- заголовок
            {
                var sumColumn = 0;
                for (var numRow = 0; numRow < DataSource.Rows.Count; numRow++)
                {
                    var value = DataSource.Rows[numRow][numColumn];
                    if (!Utils.IsEmpty(value) && (value is Int32)) sumColumn += Convert.ToInt32(value);
                }

                rowSummary[numColumn] = sumColumn;
                sumTotal += sumColumn;
            }
            rowSummary["Summary"] = sumTotal;
            DataSource.Rows.Add(rowSummary);
            */
        }


        /// <summary>
        /// Создаёт таблицу на основе тестов определённого типа
        /// </summary>
        /// <param name="labTests"></param>
        /// <param name="idfsTestName"></param>
        /// <param name="strTestName"></param>
        public void ParseTestTable(EditableList<VectorLabTest> labTests, long idfsTestName, string strTestName)
        {
            idTestName = idfsTestName;
            TestName = strTestName;

            if (DataSource == null) DataSource = new DataTable();
            else DataSource.Clear();

            var labTestsFiltered = labTests.Where(c => c.idfsTestName == idTestName).ToList();
            if (labTestsFiltered.Count == 0) return;

            //в столбцах -- возможные результаты теста для этого типа теста (не только заполненные)
            var results = labTests[0].TypeLabTestToResultMatrix.Where(c => c.idfsTestName == idTestName).ToList();
            if (results.Count == 0) return;
            DataSource.Columns.Add(new DataColumn("Caption", typeof(string)) { Caption = String.Empty }); //названия типов семплов
            foreach (var matrixItem in results)
            {
                var column = new DataColumn(GetColumnName(matrixItem), typeof(Int32)) { Caption = matrixItem.strTestResultName };

                DataSource.Columns.Add(column);
            }
            //добавляем столбец для суммирования
            DataSource.Columns.Add(new DataColumn("Summary", typeof(Int32)) { Caption = EidssFields.Get("TotalCaption", "Summary") });

            //в строках -- типы семплов (кровь,..)
            var usedSampleTypes = new List<long>();
            foreach (var labTest in labTestsFiltered)
            {
                if (labTest.IsMarkedToDelete) continue;
                var idSampleType = labTest.idfsSampleType;
                if (usedSampleTypes.Contains(idSampleType)) continue;
                var row = DataSource.NewRow();
                row["Caption"] = labTest.strSampleType;
                //по каждому столбцу вычисляем количество и заполняем таблицу
                var i = 1; //потому что первый столбец -- заголовок типа семпла
                var sum = 0;
                foreach (var matrix in results)
                {
                    //результат в конкретном столбце (порядок совпадает)
                    var idResult = matrix.idfsTestResult;
                    var count = labTestsFiltered.Count(c => (c.idfsTestResult == idResult) && (c.idfsSampleType == idSampleType));
                    sum += count;
                    row[i] = count;

                    i++;
                }
                row["Summary"] = sum;
                DataSource.Rows.Add(row);
                usedSampleTypes.Add(idSampleType);
            }

            //добавляем строку финального итого
            var rowSummary = DataSource.NewRow();
            rowSummary["Caption"] = EidssFields.Get("SummaryCaption", "Summary");
            var sumTotal = 0;
            for (var numColumn = 1; numColumn < DataSource.Columns.Count - 1; numColumn++) //потому что первый столбец -- заголовок
            {
                var sumColumn = 0;
                for (var numRow = 0; numRow < DataSource.Rows.Count; numRow++)
                {
                    var value = DataSource.Rows[numRow][numColumn];
                    if (!Utils.IsEmpty(value) && (value is Int32)) sumColumn += Convert.ToInt32(value);
                }

                rowSummary[numColumn] = sumColumn;
                sumTotal += sumColumn;
            }
            rowSummary["Summary"] = sumTotal;
            DataSource.Rows.Add(rowSummary);
        }

        /// <summary>
        /// Составляет промежуточные таблицы для таблицы тестов
        /// </summary>
        /// <param name="fieldTests"></param>
        /// <returns></returns>
        public static List<SummaryTable> GetSummaryTables(EditableList<VectorFieldTest> fieldTests)
        {
            var summaryTables = new List<SummaryTable>();

            /*TODO
            foreach (var fieldTest in fieldTests)
            {
                if (fieldTest.IsMarkedToDelete) continue;
                if (!fieldTest.idfsPensideTestName.HasValue) continue;
                var idTestName = fieldTest.idfsPensideTestName.Value;
                if (summaryTables.Count(c => c.idTestName == idTestName) > 0) continue;
                var summaryTable = new SummaryTable();
                summaryTable.ParseTestTable(fieldTests, idTestName, fieldTest.PensideTestName.name);
                summaryTables.Add(summaryTable);
            }
            */

            return summaryTables;
        }

        /// <summary>
        /// Составляет промежуточные таблицы для таблицы тестов
        /// </summary>
        /// <param name="labTests"></param>
        /// <returns></returns>
        public static List<SummaryTable> GetSummaryTables(EditableList<VectorLabTest> labTests)
        {
            var summaryTables = new List<SummaryTable>();

            foreach (var labTest in labTests)
            {
                if (labTest.IsMarkedToDelete) continue;
                if (!labTest.idfsTestName.HasValue) continue;
                var idTestName = labTest.idfsTestName.Value;
                if (summaryTables.Count(c => c.idTestName == idTestName) > 0) continue;
                var summaryTable = new SummaryTable();
                summaryTable.ParseTestTable(labTests, idTestName, labTest.strTestName);
                summaryTables.Add(summaryTable);
            }


            return summaryTables;
        }
    
    }
}
