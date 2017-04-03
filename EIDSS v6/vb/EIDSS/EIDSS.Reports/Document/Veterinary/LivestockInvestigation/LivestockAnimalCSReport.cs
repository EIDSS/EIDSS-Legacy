using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public sealed partial class LivestockAnimalCSReport : XtraReport
    {
        public LivestockAnimalCSReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long cmId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();
            LivestockAnimalCSDataSet.AnimalsLivestockDataTable bindTable = m_DataSet.AnimalsLivestock;

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = BaseReport.CommandTimeout;
            m_DataSet.EnforceConstraints = false;

            m_Adapter.Fill(bindTable, cmId, lang);

            List<long> observationList = GetObservationList(bindTable);

            //Livestock investigation  - Sample Collection (Clinical Signs)
            var templateHelper = new TemplateHelper();
            templateHelper.LoadTemplate(observationList, null, FFType.LivestockAnimalCS);
            FillTableToBind(templateHelper, bindTable);
        }

        private static void FillTableToBind
            (TemplateHelper templateHelper,
                LivestockAnimalCSDataSet.AnimalsLivestockDataTable bindTable)
        {
            Utils.CheckNotNull(templateHelper, "templateHelper");
            Utils.CheckNotNull(bindTable, "bindTable");

            List<DataRow> reportList = templateHelper.GetReportView();
            foreach (LivestockAnimalCSDataSet.AnimalsLivestockRow row in bindTable)
            {
                row.strClinicalSigns = row.IsidfObservationNull()
                    ? string.Empty
                    : FillObservationTable(templateHelper.ActivityParameters, reportList, row.idfObservation);
            }
        }

        private static List<long> GetObservationList(LivestockAnimalCSDataSet.AnimalsLivestockDataTable bindTable)
        {
            Utils.CheckNotNull(bindTable, "bindTable");

            var observationList = new List<long>();
            foreach (LivestockAnimalCSDataSet.AnimalsLivestockRow row in bindTable)
            {
                if (!row.IsidfObservationNull() && !observationList.Contains(row.idfObservation))
                {
                    observationList.Add(row.idfObservation);
                }
            }
            return observationList;
        }

        public static string FillObservationTable
            (FlexibleFormsDS.ActivityParametersDataTable activityParameters,
                List<DataRow> reportList, long observationId)
        {
            Utils.CheckNotNull(activityParameters, "activityParameters");
            Utils.CheckNotNull(reportList, "reportList");

            var result = new StringBuilder();
            foreach (DataRow row in reportList)
            {
                if (!(row is FlexibleFormsDS.ParameterTemplateRow))
                {
                    continue;
                }
                var parameterRow = (FlexibleFormsDS.ParameterTemplateRow) row;
                string name = Utils.IsEmpty(parameterRow.NationalName)
                    ? parameterRow.DefaultName
                    : parameterRow.NationalName;

                foreach (FlexibleFormsDS.ActivityParametersRow activityRow in activityParameters)
                {
                    if ((parameterRow.idfsFormTemplate == activityRow.idfsFormTemplate) &&
                        (parameterRow.idfsParameter == activityRow.idfsParameter) &&
                        (observationId == activityRow.idfObservation))
                    {
                        object value = Utils.IsEmpty(activityRow.strNameValue)
                            ? activityRow.varValue
                            : activityRow.strNameValue;
                        if ((value is bool) && ((bool) value))
                        {
                            result.AppendFormat("{0}; ", name);
                        }
                    }
                }
            }

            return result.ToString();
        }
    }
}