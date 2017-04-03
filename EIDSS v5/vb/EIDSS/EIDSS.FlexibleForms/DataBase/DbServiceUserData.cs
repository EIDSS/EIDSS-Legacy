using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using bv.common;
using bv.model.Model.Core;
using EIDSS.FlexibleForms.DataBase.FlexibleFormsDSTableAdapters;
using EIDSS.FlexibleForms.Helpers;

namespace EIDSS.FlexibleForms.DataBase
{
    public class DbServiceUserData : DbService
    {
        /// <summary>
        /// ������, ��� �������� ��������� ������
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

            #region ������������� ���������
            
            m_ActivityParametersTableAdapter = new ActivityParametersTableAdapter
                                                   {
                                                       Connection = connection,
                                                       ClearBeforeFill = false
                                                   };
            #endregion
        }

        /// <summary>
        /// ������� ��� �������� ������
        /// </summary>
        private SqlCommand CommandRemoveActivityParameters
        {
            get
            {
                if (m_CommandRemoveActivityParameters == null)
                {
                    #region �������� ���������� ��� ��������� ��������

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
        /// ������� ��� ���������� ������ (Insert+Update)
        /// </summary>
        private SqlCommand CommandSaveActivityParameters
        {
            get
            {
                if (m_CommandSaveActivityParameters == null)
                {
                    #region �������� ���������� ��� ��������� ����������

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

                //������� � ������ ������, ������� ��� ���, ��� ��� ��������
                for (var i = MainDataSet.ActivityParameters.Count - 1; i >= 0; i--)
                {
                    var row = MainDataSet.ActivityParameters[i];
                    if (!row.IsRowAlive()) continue;
                    //������ ������, ������� ��������� � summary ��� ���������� ��������������
                    if (row.idfObservation.Equals(IdfObservationSummary) || row.idfObservation.Equals(IdfObservationGroup))
                    {
                        row.Delete();
                        continue;
                    }
                    //������� ������, ���������� �� ��������
                    if (!row.IsintRowStateNull() && (row.intRowState == 1))
                    {
                        row.Delete();
                        continue;
                    }

                    if (row.IsidfsFormTemplateNull() && TemplateID.HasValue) row.idfsFormTemplate = TemplateID.Value;
                    var parameterTemplateRow = this.GetParameterTemplateRow(row.idfsParameter, row.idfsFormTemplate);
                    if (parameterTemplateRow != null) row.IsDynamicParameter = parameterTemplateRow.blnDynamicParameter;
                }

                #region ���������� ���������������� ������

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
        /// ��������� ������� ActivityParameters, � ������� ���������� ���������������� ������
        /// </summary>
        /// <returns></returns>
        public FlexibleFormsDS.ActivityParametersDataTable LoadUserData(long idfObservation, long idfsFormTemplate,
                                                                        bool bufferingUserData)
        {
            // ������� ��� ���������� ������, ��������� � ��������
            //using (var activityParametersTableAdapter = new ActivityParametersTableAdapter())
            //{

            //using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            //{
            //    activityParametersTableAdapter.Connection = (SqlConnection) manager.Connection;
            //��������� ������� ����� �����������
            //��� ����������� (�������������) ������ ���������� �� ����� ������ ����������


            //��������� ���� ������ �� idfObservation, ������ ��� � �������� ������ ����� �������� ����� � ����� idfObservation
            var apsCount = MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", idfObservation)).Length;
            if (!bufferingUserData || (apsCount == 0))
            {
                m_ActivityParametersTableAdapter.Fill(MainDataSet.ActivityParameters,
                                                      String.Format("{0};", idfObservation),
                                                      ModelUserContext.CurrentLanguage);
            }
            //��������� ��������������� ������, ���� �� �� ��������� � ���, ��� ��������� (����� �������� ���������, ����� � Observation �������� ������ �� ����� ������)
            //}
            //}
            for (var i = 0; i < MainDataSet.ActivityParameters.Count; i++)
            {
                var row = MainDataSet.ActivityParameters[i];
                if (!row.IsRowAlive()) continue;
                if (!row.idfObservation.Equals(idfObservation)) continue;
                //row.idfsFormTemplate ������ ���� ��������, ����� ��� ������. ������ �������� �������, ����� �� ������.
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
        /// ��������� ���������������� ������ �� ������ observation (������� ��� ���������������� ������!)
        /// (������������ ��� summary)
        /// </summary>
        /// <param name="observationList"></param>
        /// <returns></returns>
        public FlexibleFormsDS.ActivityParametersDataTable LoadUserData(List<long> observationList)
        {
            //���������� ������� �������
          

            //������� ��� ���������������� ������!
            
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
        /// ������� ������ �����
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
        /// ������� ���������������� ������, ������� �������� ��������
        /// </summary>
        public void DeleteStubData(long idfsFormTemplate, long idfsObservation)
        {
            //����� ������������ ��� ��������������� ������� ������� ����� ���������� ���� ������ ��������
            //��� ����������, ����� ��� ����� � ��� �� observation �������� ������ �������� � ����� ������ ������
            var userData =
                (FlexibleFormsDS.ActivityParametersRow[])
                MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", idfsObservation));
            foreach (var row in userData)
            {
                if (!row.IsRowAlive()) continue;
                //���� ������ ���������������� ������ ��������� � ��������� � ������������� ���������� �������, �� ��� ������ ��������
                var parameterTemplateRow = DataHelper.GetParameterTemplateRow(this,row.idfsParameter,idfsFormTemplate);
                if (parameterTemplateRow == null) continue;
                if (parameterTemplateRow.intOrder < 0)
                {
                    row.Delete();
                }
            }
        }

        /// <summary>
        /// ������ ������� ������
        /// </summary>
        /// <param name="observationList">observation, ����������� � �����������</param>
        public void CalculateSummary(List<long> observationList)
        {
            //TODO ������������ ������ �� Observation, ������� ����������� ��� Summary
            //������ ������ ��� Summary Observation, ����� �� ���� ��������� ������
            ClearUserData(IdfObservationSummary);

            //�������� �������� ����� ��������
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

            //������ �� Observations
            string filterStringObservations = HelperFunctions.ConvertToFilterString("idfObservation", observationList);

            //�������� �� ���� ����������, ������� ��, ��� ��������� � ������� idfsFormTemplateSummary, ���� ��� �������� �����
            foreach (var parameterTemplateRow in MainDataSet.ParameterTemplate)
            {
                if (!parameterTemplateRow.IsRowAlive()) continue;
                if (!parameterTemplateRow.idfsFormTemplate.Equals(IdfsFormTemplateSummary)) continue;
                //������������� ������� ��������, ��� ��� �������
                if (parameterTemplateRow.intOrder < 0) continue;
                if (!this.IsParameterNumeric(parameterTemplateRow.idfsParameter)) continue;

                //�������� �� ���� ������� �������� � ��������� �������� �� �������
                foreach (long idfRow in stubIfdRows)
                {
                    //����� ������������ �������� ����� ������ ������ � �������-������� � �������� �� �������� ����� ������, ������ �� ��������
                    //���������� �������� ����� ������ �� �������� (���� �������� + IdfRow)
                    //���� ������ ������ �� ������� ������ �� ������� ��������, �� �� ������� �
                    //����� ����� ���� ������� �� ����� ������� ��������, �� � ���� ���� ����� ������
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

                    #region �������� ����� ������ � �������

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