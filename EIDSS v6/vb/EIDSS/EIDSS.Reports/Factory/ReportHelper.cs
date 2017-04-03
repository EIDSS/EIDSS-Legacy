using System;
using System.Collections.Generic;
using System.Globalization;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Factory
{
    public static class ReportHelper
    {
        public delegate BaseReport CreateReportDelegate(DbManagerProxy manager, string lang);

        public static Dictionary<string, string> CreateHumCaseInvestigationParameters(long caseId, long epiId, long csId, long diagnosisId)
        {
            Dictionary<string, string> parameters = CreateParameters(caseId);
            parameters.Add("@EPIObjID", epiId.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@CSObjID", csId.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@DiagnosisID", diagnosisId.ToString(CultureInfo.InvariantCulture));
            return parameters;
        }

        public static Dictionary<string, string> CreateParameters(long id)
        {
            var parameters = new Dictionary<string, string> {{"@ObjID", id.ToString(CultureInfo.InvariantCulture)}};
            return parameters;
        }

        public static Dictionary<string, string> CreateAggrParameters(string aggrXml)
        {
            Utils.CheckNotNullOrEmpty(aggrXml, "aggrXml");
            var parameters = new Dictionary<string, string> {{"@AggrXml", aggrXml}};
            return parameters;
        }

        public static Dictionary<string, string> CreateHumAggregateCaseParameters(AggregateReportParameters aggrParams)
        {
            var parameterList = new Dictionary<string, string>
                                    {
                                        {"@ObjID", aggrParams.CaseId.ToString(CultureInfo.InvariantCulture)},
                                        {"@observationId", aggrParams.ObservationId.ToString(CultureInfo.InvariantCulture)},
                                        {"@idFormTemplate", aggrParams.FormTemplateId.ToString(CultureInfo.InvariantCulture)},
                                        {
                                            "@idfsAggrCaseType",
                                            ((long) AggregateCaseType.AggregateCase).ToString(CultureInfo.InvariantCulture)
                                            }
                                    };

            return parameterList;
        }

        public static Dictionary<string, string> CreateVetAggregateCaseParameters(AggregateReportParameters parameters)
        {
            Dictionary<string, string> parameterList = CreateParameters(parameters.CaseId);
            parameterList.Add("@observationId", parameters.ObservationId.ToString(CultureInfo.InvariantCulture));
            parameterList.Add("@idFormTemplate", parameters.FormTemplateId.ToString(CultureInfo.InvariantCulture));
            parameterList.Add("@idfsAggrCaseType", ((long) AggregateCaseType.VetAggregateCase).ToString(CultureInfo.InvariantCulture));
            return parameterList;
        }

        public static Dictionary<string, string> CreateVetAggregateCaseActionsParameters(AggregateActionsParameters aggrParams)
        {
            Dictionary<string, string> parameters = CreateParameters(aggrParams.CaseId);

            parameters.Add("@idfsAggrCaseType", ((long) AggregateCaseType.VetAggregateAction).ToString(CultureInfo.InvariantCulture));
            parameters.Add("@diagnosticObservation", aggrParams.DiagnosticObservation.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@prophylacticObservation", aggrParams.ProphylacticObservation.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@sanitaryObservation", aggrParams.SanitaryObservation.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@diagnosticFormTemplate", aggrParams.DiagnosticFormTemplate.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@sanitaryFormTemplate", aggrParams.SanitaryFormTemplate.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@prophylacticFormTemplate", aggrParams.ProphylacticFormTemplate.ToString(CultureInfo.InvariantCulture));
            foreach (KeyValuePair<string, string> pair in aggrParams.Labels)
            {
                parameters.Add(pair.Key, pair.Value);
            }
            return parameters;
        }

        public static Dictionary<string, string> CreateLimTestResultParameters(long id, long csId, long typeId)
        {
            Dictionary<string, string> parameters = CreateParameters(id);
            parameters.Add("@CSObjID", csId.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@TypeID", typeId.ToString(CultureInfo.InvariantCulture));
            return parameters;
        }

        public static Dictionary<string, string> CreateVetAggregateCaseActionsSummaryPs(AggregateActionsSummaryParameters aggrParams)
        {
            Dictionary<string, string> parameters = CreateAggrParameters(aggrParams.AggrXml);

            AddObservationListToParameters(aggrParams.DiagnosticObservation, parameters, "@diagnosticObservation");
            AddObservationListToParameters(aggrParams.ProphylacticObservation, parameters, "@prophylacticObservation");
            AddObservationListToParameters(aggrParams.SanitaryObservation, parameters, "@sanitaryObservation");
            foreach (KeyValuePair<string, string> pair in aggrParams.Labels)
            {
                parameters.Add(pair.Key, pair.Value);
            }
            return parameters;
        }

        public static Dictionary<string, string> CreateLimSampleParameters(long? contId, long? freeserId)
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     {"@ContID", (contId == null) ? String.Empty : contId.ToString()},
                                     {"@FreezerID", (freeserId == null) ? String.Empty : freeserId.ToString()}
                                 };
            return parameters;
        }

        public static void AddObservationListToParameters
            (IEnumerable<long> observationList,
             IDictionary<string, string> parameters,
             string observationName)
        {
            Utils.CheckNotNull(parameters, "parameters");
            Utils.CheckNotNullOrEmpty(observationName, "observationName");

            long index = 0;
            foreach (long observationId in observationList)
            {
                parameters.Add(String.Format("{0}{1}", observationName, index), observationId.ToString(CultureInfo.InvariantCulture));
                index++;
            }
        }

        public static void AppendOrganizationIdToParameters(BaseModel model, Dictionary<string, string> parameterList)
        {
            if (model.OrganizationId.HasValue)
            {
                parameterList.Add("@OrganizationID", model.OrganizationId.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (model.SiteId.HasValue)
            {
                parameterList.Add("@SiteID", model.SiteId.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (model.UserId.HasValue)
            {
                parameterList.Add("@UserID", model.UserId.Value.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}