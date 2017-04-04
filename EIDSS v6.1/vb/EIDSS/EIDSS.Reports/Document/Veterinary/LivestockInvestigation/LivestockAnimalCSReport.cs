using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using bv.common.Core;
using bv.model.BLToolkit;
using BLToolkit.EditableObjects;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;
using eidss.model.Model.Report;
using eidss.model.Schema;
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

        public void SetParameters(string lang, long cmId, DbManagerProxy manager, DbManagerProxy archiveManager)
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
            templateHelper.LoadTemplate(observationList, null, FFTypeEnum.LivestockAnimalCS);
            FillTableToBind(templateHelper, bindTable);
        }

        private static void FillTableToBind
            (TemplateHelper templateHelper,
                LivestockAnimalCSDataSet.AnimalsLivestockDataTable bindTable)
        {
            Utils.CheckNotNull(templateHelper, "templateHelper");
            Utils.CheckNotNull(bindTable, "bindTable");

            var reportList = templateHelper.GetReportView();
            foreach (LivestockAnimalCSDataSet.AnimalsLivestockRow row in bindTable)
            {
                row.strClinicalSigns = row.IsidfObservationNull()
                    ? string.Empty
                    : FillObservationTable(templateHelper.Model.ActivityParameters, reportList, row.idfObservation);
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
            (EditableList<ActivityParameter> activityParameters,
                List<object> reportList, long observationId)
        {
            Utils.CheckNotNull(activityParameters, "activityParameters");
            Utils.CheckNotNull(reportList, "reportList");

            var result = new StringBuilder();
            foreach (var row in reportList)
            {
                var parameter = row as ParameterTemplate;
                if (parameter == null)
                {
                    continue;
                }
                var name = Utils.IsEmpty(parameter.NationalName)
                    ? parameter.DefaultName
                    : parameter.NationalName;

                foreach (var activityRow in activityParameters)
                {
                    if ((parameter.idfsFormTemplate == activityRow.idfsFormTemplate) &&
                        (parameter.idfsParameter == activityRow.idfsParameter) &&
                        (observationId == activityRow.idfObservation))
                    {
                        var value = Utils.IsEmpty(activityRow.strNameValue)
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