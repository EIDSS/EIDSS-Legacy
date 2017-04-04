using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.FlexFormIntegration
{
    public static class FlexConverter
    {
        /*
        public static FlexParamDataSet FillObservationAggregateTable
            (FlexParamDataSet sourceData,
                TemplateHelper templateHelper,
                string lang)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNull(sourceData, "sourceData");
            Utils.CheckNotNull(templateHelper, "templateHelper");
            Utils.CheckNotNull(templateHelper.ActivityParameters, "templateHelper.ActivityParameters");
            Utils.CheckNotNull(templateHelper.ParameterTemplate, "templateHelper.ParameterTemplate");
            Utils.CheckNotNullOrEmpty(lang, "lang");

            var existingParameters = new List<long>();
            foreach (FlexibleFormsDS.ActivityParametersRow row in templateHelper.ActivityParameters)
            {
                if (row.IsintNumRowNull())
                {
                    continue;
                }

                FlexibleFormsDS.ParameterTemplateRow parameterRow = FindParameterTemplate(lang, templateHelper, row);

                string paramName = string.Empty;
                long intOrder = 0;
                if (parameterRow != null)
                {
                    paramName = parameterRow.NationalName;
                    intOrder = parameterRow.intOrder;
                }
                object value = string.IsNullOrEmpty(row.strNameValue) ? row.varValue : row.strNameValue;

                sourceData.tblObservation.AddtblObservationRow(row.idfObservation,
                    row.idfsParameter,
                    paramName,
                    value,
                    row.intNumRow,
                    intOrder);
                if (!existingParameters.Contains(row.idfsParameter))
                {
                    existingParameters.Add(row.idfsParameter);
                }
            }
            foreach (FlexibleFormsDS.ParameterTemplateRow parameterRow in templateHelper.ParameterTemplate)
            {
                if (existingParameters.Contains(parameterRow.idfsParameter))
                {
                    continue;
                }
                existingParameters.Add(parameterRow.idfsParameter);
                sourceData.tblObservation.AddtblObservationRow(-1,
                    parameterRow.idfsParameter,
                    parameterRow.NationalName,
                    string.Empty,
                    0,
                    parameterRow.intOrder);
            }

            sourceData.AcceptChanges();
            return sourceData;
        }
        */

        public static void FillCaseTable
            (DbManagerProxy manager, FlexParamDataSet sourceData, IDictionary<string, string> parameters, string lang)
        {
            Utils.CheckNotNull(sourceData, "sourceData");
            Utils.CheckNotNull(parameters, "parameters");
            Utils.CheckNotNullOrEmpty(lang, "lang");

            if (parameters.ContainsKey("@ObjID"))
            {
                long caseId = long.Parse(parameters["@ObjID"]);

                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                    command.Transaction = (SqlTransaction) manager.Transaction;
                    command.CommandTimeout = BaseReport.CommandTimeout;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from dbo.fnRepGetAggParams (@idfAggrCase, @LangID)";
                    command.Parameters.Add(new SqlParameter("@idfAggrCase", caseId));
                    command.Parameters.Add(new SqlParameter("@LangID", lang));

                    var aggParamsDataSet = new DataSet();
                    adapter.SelectCommand = command;
                    adapter.Fill(aggParamsDataSet);
                    if (aggParamsDataSet.Tables.Count == 0)
                    {
                        throw new ApplicationException(string.Format("{0} returns no tables.", command.CommandText));
                    }
                    if (aggParamsDataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = aggParamsDataSet.Tables[0].Rows[0];
                        sourceData.tblCase.AddtblCaseRow((long) dataRow["idfActivity"],
                            dataRow["AdmUnitName"].ToString(),
                            (DateTime) dataRow["datStartDate"],
                            (DateTime) dataRow["datFinishDate"],
                            Utils.Str(dataRow["strCaseID"]),
                            (long) dataRow["idfsAdministrativeUnit"],
                            (int) dataRow["idfsAdmUnitType"]);
                    }
                }
            }

            sourceData.AcceptChanges();
        }
        /*
        private static FlexibleFormsDS.ParameterTemplateRow FindParameterTemplate
            (string lang,
                TemplateHelper templateHelper,
                FlexibleFormsDS.ActivityParametersRow
                    row)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNull(templateHelper, "templateHelper");
            Utils.CheckNotNull(row, "row");

            FlexibleFormsDS.ParameterTemplateRow result =
                templateHelper.ParameterTemplate.FindByidfsParameteridfsFormTemplatelangid(row.idfsParameter,
                    row.idfsFormTemplate,
                    lang);
            // not found national parameter name
            if (result == null)
            {
                result = templateHelper.ParameterTemplate.FindByidfsParameteridfsFormTemplatelangid(row.idfsParameter,
                    row.idfsFormTemplate,
                    Localizer.lngEn);
            }
            return result;
        }
        */
    }
}