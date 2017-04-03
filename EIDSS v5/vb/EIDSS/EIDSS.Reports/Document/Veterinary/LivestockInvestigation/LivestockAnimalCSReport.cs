using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DevExpress.XtraReports.UI;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using EIDSS.Reports.BaseControls;
using bv.common.Core;
using bv.model.BLToolkit;
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
            LivestockAnimalCSDataSet.spRepVetSamplesCollectionLivestockDataTable bindTable =
                sampleDataSet1.spRepVetSamplesCollectionLivestock;

            sp_rep_VET_SamplesCollectionLivestockTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_VET_SamplesCollectionLivestockTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_VET_SamplesCollectionLivestockTableAdapter.CommandTimeout = BaseReport.CommandTimeout;
            sampleDataSet1.EnforceConstraints = false;

            sp_rep_VET_SamplesCollectionLivestockTableAdapter.Fill(bindTable, cmId, lang);

            var observationList = GetObservationList(bindTable);

            //Livestock investigation  - Sample Collection (Clinical Signs)
            var templateHelper = new TemplateHelper();
            templateHelper.LoadTemplate(observationList, null, FFType.LivestockAnimalCS);
            FillTableToBind(templateHelper, bindTable);
        }

        private static void FillTableToBind
            (TemplateHelper templateHelper,
             LivestockAnimalCSDataSet.spRepVetSamplesCollectionLivestockDataTable
                 bindTable)
        {
            Utils.CheckNotNull(templateHelper, "templateHelper");
            Utils.CheckNotNull(bindTable, "bindTable");

            bindTable.CSstringColumn.ReadOnly = false;
            List<DataRow> reportList = templateHelper.GetReportView();
            foreach (LivestockAnimalCSDataSet.spRepVetSamplesCollectionLivestockRow row in bindTable)
            {
                row.CSstring = string.Empty;
                long observation;
                if (long.TryParse(row.idfObservation, out observation))
                {
                    row.CSstring = FillObservationTable(templateHelper.ActivityParameters, reportList, observation);
                }
            }
        }

        private static List<long> GetObservationList
            (
            LivestockAnimalCSDataSet.spRepVetSamplesCollectionLivestockDataTable bindTable)
        {
            Utils.CheckNotNull(bindTable, "bindTable");

            var observationList = new List<long>();
            foreach (LivestockAnimalCSDataSet.spRepVetSamplesCollectionLivestockRow row in bindTable)
            {
                long observation;
                if (long.TryParse(row.idfObservation, out observation))
                {
                    if (!observationList.Contains(observation))
                    {
                        observationList.Add(observation);
                    }
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