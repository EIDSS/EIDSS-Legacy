using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using bv.common;
using bv.common.Enums;
using bv.model.Model.Core;
using EIDSS.FlexibleForms.DataBase.FlexibleFormsDSTableAdapters;
using EIDSS.FlexibleForms.Helpers;
using eidss.model.Enums;

namespace EIDSS.FlexibleForms.DataBase
{
    public class DbServiceUserData : DbService
    {
        /// <summary>
        /// Шаблон, для которого вводились данные
        /// </summary>
        internal long? TemplateID { get; set; }

        private SqlCommand m_CommandRemoveActivityParameters;
        private SqlCommand m_CommandSaveActivityParameters;
        private ActivityParametersTableAdapter m_ActivityParametersTableAdapter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        protected override void Init(SqlConnection connection)
        {
            base.Init(connection);

            #region Инициализация адаптеров
            
            m_ActivityParametersTableAdapter = new ActivityParametersTableAdapter
                                                   {
                                                       Connection = connection,
                                                       ClearBeforeFill = false
                                                   };
            #endregion
        }

        /// <summary>
        /// Команда для удаления данных
        /// </summary>
        private SqlCommand CommandRemoveActivityParameters
        {
            get
            {
                if (m_CommandRemoveActivityParameters == null)
                {
                    #region Перечень параметров для процедуры удаления

                    m_CommandRemoveActivityParameters = new SqlCommand
                                                            {
                                                                CommandText = "dbo.spFFRemoveActivityParameters",
                                                                Connection = (SqlConnection) Connection,
                                                                CommandType = CommandType.StoredProcedure
                                                            };
                    m_CommandRemoveActivityParameters.Parameters.Add(new SqlParameter("@idfsParameter", SqlDbType.BigInt,
                                                                                    0, ParameterDirection.Input, 0, 0,
                                                                                    "idfsParameter",
                                                                                    DataRowVersion.Current, false, null,
                                                                                    "", "", ""));
                    m_CommandRemoveActivityParameters.Parameters.Add(new SqlParameter("@idfObservation", SqlDbType.BigInt,
                                                                                    0, ParameterDirection.Input, 0, 0,
                                                                                    "idfObservation",
                                                                                    DataRowVersion.Current, false, null,
                                                                                    "", "", ""));
                    m_CommandRemoveActivityParameters.Parameters.Add(new SqlParameter("@idfRow", SqlDbType.BigInt, 0,
                                                                                    ParameterDirection.Input, 0, 0,
                                                                                    "idfRow", DataRowVersion.Current,
                                                                                    false, null, "", "", ""));

                    #endregion
                }
                return m_CommandRemoveActivityParameters;
            }
        }

        /// <summary>
        /// Команда для сохранения данных (Insert+Update)
        /// </summary>
        private SqlCommand CommandSaveActivityParameters
        {
            get
            {
                if (m_CommandSaveActivityParameters == null)
                {
                    #region Перечень параметров для процедуры сохранения

                    m_CommandSaveActivityParameters = new SqlCommand
                                                          {
                                                              CommandText = "dbo.spFFSaveActivityParameters",
                                                              Connection = (SqlConnection) Connection,
                                                              CommandType = CommandType.StoredProcedure
                                                          };
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4,
                                                                                  ParameterDirection.ReturnValue, 10, 0,
                                                                                  null, DataRowVersion.Current, false,
                                                                                  null, "", "", ""));
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@idfsParameter", SqlDbType.BigInt, 8,
                                                                                  ParameterDirection.Input, 19, 0,
                                                                                  "idfsParameter",
                                                                                  DataRowVersion.Current, false, null,
                                                                                  "", "", ""));
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@idfObservation", SqlDbType.BigInt, 8,
                                                                                  ParameterDirection.Input, 19, 0,
                                                                                  "idfObservation",
                                                                                  DataRowVersion.Current, false, null,
                                                                                  "", "", ""));
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@idfsFormTemplate", SqlDbType.BigInt,
                                                                                  8, ParameterDirection.Input, 19, 0,
                                                                                  "idfsFormTemplate",
                                                                                  DataRowVersion.Current, false, null,
                                                                                  "", "", ""));
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@varValue", SqlDbType.Variant, 8016,
                                                                                  ParameterDirection.Input, 0, 0,
                                                                                  "varValue", DataRowVersion.Current,
                                                                                  false, null, "", "", ""));
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@idfRow", SqlDbType.BigInt, 8,
                                                                                  ParameterDirection.InputOutput, 10, 0,
                                                                                  "idfRow", DataRowVersion.Current,
                                                                                  false, null, "", "", ""));
                    m_CommandSaveActivityParameters.Parameters.Add(new SqlParameter("@IsDynamicParameter", SqlDbType.Bit,
                                                                                  1, ParameterDirection.Input, 10, 0,
                                                                                  "IsDynamicParameter",
                                                                                  DataRowVersion.Current, false, null,
                                                                                  "", "", ""));

                    #endregion
                }
                return m_CommandSaveActivityParameters;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="postType"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
        {
            try
            {
                var da = new SqlDataAdapter();
                //Generate events if aggregate case data was changed
                var changes = MainDataSet.ActivityParameters.GetChanges();
                if (changes != null && changes.Rows.Count > 0)
                {
                    if (MainDataSet.SectionTemplate.Rows.Count > 0)
                    {
                        var formType = MainDataSet.SectionTemplate[0].idfsFormType;
                        switch (formType)
                        {
                            case (long)FFType.HumanAggregateCase:
                                AddEvent(EventType.HumanAggregateCaseChangedLocal, null, false);
                                break;
                            case (long)FFType.VetAggregateCase:
                                AddEvent(EventType.VetAggregateCaseChangedLocal, null, false);
                                break;
                            case (long)FFType.VetEpizooticAction:
                            case (long)FFType.VetEpizooticActionDiagnosisInv:
                            case (long)FFType.VetEpizooticActionTreatment:
                                AddEvent(EventType.VetAggregateActionChangedLocal, null, false);
                                break;
                        }
                        
                    }
                }

                //обновим у данных шаблон, заменим его тем, что был вычислен
                for (var i = MainDataSet.ActivityParameters.Count - 1; i >= 0; i--)
                {
                    var row = MainDataSet.ActivityParameters[i];
                    if (!row.IsRowAlive()) continue;
                    //удалим данные, которые относятся к summary или групповому редактированию
                    if (row.idfObservation.Equals(IdfObservationSummary) || row.idfObservation.Equals(IdfObservationGroup))
                    {
                        row.Delete();
                        continue;
                    }
                    //удаляем данные, помеченные на удаление
                    if (!row.IsintRowStateNull() && (row.intRowState == 1))
                    {
                        row.Delete();
                        continue;
                    }

                    if (row.IsidfsFormTemplateNull() && TemplateID.HasValue) row.idfsFormTemplate = TemplateID.Value;
                    var parameterTemplateRow = this.GetParameterTemplateRow(row.idfsParameter, row.idfsFormTemplate);
                    if (parameterTemplateRow != null) row.IsDynamicParameter = parameterTemplateRow.blnDynamicParameter;
                }

                #region Сохранение пользовательских данных

                da.InsertCommand = da.UpdateCommand = CommandSaveActivityParameters;
                da.DeleteCommand = CommandRemoveActivityParameters;
                ApplyTransaction(da, transaction);
                da.Update(MainDataSet.ActivityParameters);

                #endregion
            }
            catch (Exception exc)
            {
                m_Error = new ErrorMessage(StandardError.PostError, exc);

                return false;
            }
            return true;
        }

        /// <summary>
        /// Заполняет таблицу ActivityParameters, в которую помещаются пользовательские данные
        /// </summary>
        /// <returns></returns>
        public FlexibleFormsDS.ActivityParametersDataTable LoadUserData(long idfObservation, long idfsFormTemplate,
                                                                        bool bufferingUserData)
        {
            // Адаптер для сохранения данных, связанных с шаблоном
            //using (var activityParametersTableAdapter = new ActivityParametersTableAdapter())
            //{

            //using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            //{
            //    activityParametersTableAdapter.Connection = (SqlConnection) manager.Connection;
            //отключаем очистку перед обновлением
            //они наполняются (дозаполняются) новыми значениями во время работы приложения


            //проверять надо только по idfObservation, потому что в процессе работы может меняться форма у этого idfObservation
            var apsCount = MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", idfObservation)).Length;
            if (!bufferingUserData || (apsCount == 0))
            {
                m_ActivityParametersTableAdapter.Fill(MainDataSet.ActivityParameters,
                                                      String.Format("{0};", idfObservation),
                                                      ModelUserContext.CurrentLanguage);
            }
            //требуется перемаркировать шаблон, если он не совпадает с тем, что возвращён (такая ситуация возникает, когда у Observation меняется шаблон во время работы)
            //}
            //}
            for (var i = 0; i < MainDataSet.ActivityParameters.Count; i++)
            {
                var row = MainDataSet.ActivityParameters[i];
                if (!row.IsRowAlive()) continue;
                if (!row.idfObservation.Equals(idfObservation)) continue;
                //row.idfsFormTemplate должен быть заполнен, иначе это ошибка. данную проверку сделали, чтобы не падало.
                if (row.IsidfsFormTemplateNull() || (!row.idfsFormTemplate.Equals(idfsFormTemplate)))
                {
                    row.idfsFormTemplate = idfsFormTemplate;
                }
            }

            return MainDataSet.ActivityParameters;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="observations"></param>
        /// <returns></returns>
        private FlexibleFormsDS.ActivityParametersDataTable FillActivityParametersTable(string observations)
        {
            var prms = new Dictionary<string, object>
                           {
                               {"@observationList", observations},
                               {"@LangID", ModelUserContext.CurrentLanguage}
                           };
            var cmd = (SqlCommand)CreateSPCommandWithParams("dbo.spFFGetActivityParameters", Connection, null, prms);
            var adapter = new SqlDataAdapter();
            var tableMapping = new DataTableMapping {SourceTable = "Table", DataSetTable = "ActivityParameters"};
            tableMapping.ColumnMappings.Add("idfObservation", "idfObservation");
            tableMapping.ColumnMappings.Add("idfsParameter", "idfsParameter");
            tableMapping.ColumnMappings.Add("varValue", "varValue");
            tableMapping.ColumnMappings.Add("idfRow", "idfRow");
            tableMapping.ColumnMappings.Add("idfsFormTemplate", "idfsFormTemplate");
            tableMapping.ColumnMappings.Add("intNumRow", "intNumRow");
            tableMapping.ColumnMappings.Add("strNameValue", "strNameValue");
            adapter.TableMappings.Add(tableMapping);
            adapter.SelectCommand = cmd;
            var resultTable = new FlexibleFormsDS.ActivityParametersDataTable();
            adapter.Fill(resultTable);

            return resultTable;
        }

        /// <summary>
        /// Загружает пользовательские данные по набору observation (очищает все пользовательские данные!)
        /// (используется для summary)
        /// </summary>
        /// <param name="observationList"></param>
        /// <returns></returns>
        public FlexibleFormsDS.ActivityParametersDataTable LoadUserData(List<long> observationList)
        {
            //выставляем большой таймаут
          

            //очищает все пользовательские данные!
            
            var strObservationsList = observationList.ParseToStringList();

            MainDataSet.ActivityParameters.Clear();

            for(int i=0; i < strObservationsList.Count; i++)
            {
                var dt = FillActivityParametersTable(strObservationsList[i]);
                MainDataSet.ActivityParameters.Merge(dt);
                //using (FlexibleFormsDS.ActivityParametersDataTable dt = new FlexibleFormsDS.ActivityParametersDataTable())
                //{
                //    activityParametersTableAdapter.Fill(dt, strObservationsList[i], bv.model.Model.Core.ModelUserContext.CurrentLanguage);
                //    MainDataSet.ActivityParameters.Merge(dt);
                //}
            }

            return MainDataSet.ActivityParameters;
        }

        /// <summary>
        /// Очистка данных формы
        /// </summary>
        private void ClearUserData(long observationID)
        {
            if (MainDataSet.ActivityParameters.Count == 0) return;
            for (int i = MainDataSet.ActivityParameters.Count - 1; i >= 0; i--)
            {
                var row = MainDataSet.ActivityParameters[i];
                if (!row.IsRowAlive()) continue;
                if (row.idfObservation.Equals(observationID)) row.Delete();
            }
        }

        /// <summary>
        /// Удаляет пользовательские данные, которые касаются боковика
        /// </summary>
        public void DeleteStubData(long idfsFormTemplate, long idfsObservation)
        {
            //метод используется как предварительная очистка шаблона перед помещением туда нового боковика
            //это необходимо, когда при одном и том же observation меняется версия боковика в одном сеансе работы
            var userData =
                (FlexibleFormsDS.ActivityParametersRow[])
                MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", idfsObservation));
            foreach (var row in userData)
            {
                if (!row.IsRowAlive()) continue;
                //если строка пользовательских данных относится к параметру с отрицательным порядковым номером, то это данные боковика
                var parameterTemplateRow = DataHelper.GetParameterTemplateRow(this,row.idfsParameter,idfsFormTemplate);
                if (parameterTemplateRow == null) continue;
                if (parameterTemplateRow.intOrder < 0)
                {
                    row.Delete();
                }
            }
        }

        /// <summary>
        /// Расчёт сводных данных
        /// </summary>
        /// <param name="observationList">observation, участвующие в вычислениях</param>
        public void CalculateSummary(List<long> observationList)
        {
            //TODO использовать только те Observation, которые требовались для Summary
            //Удалим строки для Summary Observation, чтобы не было наложения данных
            ClearUserData(IdfObservationSummary);

            //получаем перечень строк боковика
            var stubIfdRows = new List<long>();
            var stubNums = new Dictionary<long, int>();
            foreach (var predefinedStubRow in MainDataSet.PredefinedStub)
            {
                if (!predefinedStubRow.IsRowAlive()) continue;
                if (!stubIfdRows.Contains(predefinedStubRow.idfRow))
                {
                    stubIfdRows.Add(predefinedStubRow.idfRow);
                    stubNums.Add(predefinedStubRow.idfRow, predefinedStubRow.NumRow);
                }
            }

            //фильтр по Observations
            string filterStringObservations = HelperFunctions.ConvertToFilterString("idfObservation", observationList);

            //проходим по всем параметрам, выявляя те, что относятся к шаблону idfsFormTemplateSummary, куда они помещены ранее
            foreach (var parameterTemplateRow in MainDataSet.ParameterTemplate)
            {
                if (!parameterTemplateRow.IsRowAlive()) continue;
                if (!parameterTemplateRow.idfsFormTemplate.Equals(IdfsFormTemplateSummary)) continue;
                //отрицательный порядок означает, что это боковик
                if (parameterTemplateRow.intOrder < 0) continue;
                if (!this.IsParameterNumeric(parameterTemplateRow.idfsParameter)) continue;

                //проходим по всем строкам боковика и суммируем значения по ячейкам
                foreach (long idfRow in stubIfdRows)
                {
                    //после суммирования создадим новую строку данных в шаблоне-саммари и присвоим ей реальный номер строки, взятый из боковика
                    //отыскиваем реальный номер строки по боковику (ключ Параметр + IdfRow)
                    //если строку данных не удалось свести со строкой боковика, то не выводим её
                    //строк может быть найдено по числу колонок боковика, но у всех один номер строки
                    if (!stubNums.ContainsKey(idfRow)) continue;

                    //string filterString = String.Format("{0} and {1}",
                    //                                    DataHelper.Filter("idfsParameter",
                    //                                                      parameterTemplateRow.idfsParameter, "idfRow",
                    //                                                      idfRow, "intRowState", 0), filterStringObservations);
                    var filterString = String.Format("{0} and {1} and ({2})",
                                                        DataHelper.Filter("idfsParameter",
                                                                          parameterTemplateRow.idfsParameter, "idfRow",
                                                                          idfRow), filterStringObservations, DataHelper.FilterOr("intRowState", 0, "intRowState", null));

                    var activityParametersRows =
                        (FlexibleFormsDS.ActivityParametersRow[]) MainDataSet.ActivityParameters.Select(filterString);
                    if (activityParametersRows.Length == 0) continue;
                    double summ = 0;
                    for (var i = 0; i < activityParametersRows.Length; i++)
                    {
                        var rowAP = activityParametersRows[i];
                        if (!rowAP.IsRowAlive()) continue;
                        if (rowAP.varValue == null) continue;
                        double value;
                        if (Double.TryParse(rowAP.varValue.ToString(), out value)) summ += value;
                    }

                    #region Создание новой строки с данными

                    FlexibleFormsDS.ActivityParametersRow activityParametersRow =
                        MainDataSet.ActivityParameters.NewActivityParametersRow();
                    activityParametersRow.idfObservation = IdfObservationSummary;
                    activityParametersRow.idfsParameter = parameterTemplateRow.idfsParameter;
                    activityParametersRow.idfsFormTemplate = IdfsFormTemplateSummary;
                    activityParametersRow.varValue = summ;
                    activityParametersRow.idfRow = idfRow;
                    activityParametersRow.intNumRow = stubNums[idfRow];
                    MainDataSet.ActivityParameters.AddActivityParametersRow(activityParametersRow);

                    #endregion
                }
            }
        }
    }
}