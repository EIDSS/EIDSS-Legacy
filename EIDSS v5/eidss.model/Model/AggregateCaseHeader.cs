using System.Collections.Generic;
using System.Data;
using BLToolkit.Data;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using bv.model.BLToolkit;

namespace eidss.model.Schema
{
    public partial class AggregateCaseHeader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffType"></param>
        /// <param name="idVersion"></param>
        /// <param name="idFormTemplate"></param>
        /// <param name="idObservation"></param>
        /// <param name="manager"></param>
        private FFPresenterModel SetFFModel(FFTypeEnum ffType, long? idObservation, DbManagerProxy manager, long? idVersion, out long? idFormTemplate)
        {
            idFormTemplate = null;
            var ffModel = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, idObservation);
            var observations = new List<long>();
            if (idObservation.HasValue) observations.Add(idObservation.Value);
            ffModel.SetProperties(EidssSiteContext.Instance.CountryID, null, ffType, observations);
            if (ffModel.CurrentTemplate != null)
            {
                idFormTemplate = ffModel.CurrentTemplate.idfsFormTemplate;
            }

            if (idVersion.HasValue)
            {
                #region Настройка показа аггрегатных случаев

                switch (ffType)
                {
                    case FFTypeEnum.HumanAggregateCase:
                        ffModel.PrepareAggregateCase(AggregateCaseSectionEnum.HumanCase, idVersion.Value);
                        break;
                    case FFTypeEnum.VetAggregateCase:
                        ffModel.PrepareAggregateCase(AggregateCaseSectionEnum.VetCase, idVersion.Value);
                        break;
                    case FFTypeEnum.VetEpizooticAction:
                        ffModel.PrepareAggregateCase(AggregateCaseSectionEnum.SanitaryAction, idVersion.Value);
                        break;
                    case FFTypeEnum.VetEpizooticActionDiagnosisInv:
                        ffModel.PrepareAggregateCase(AggregateCaseSectionEnum.DiagnosticAction, idVersion.Value);
                        break;
                    case FFTypeEnum.VetEpizooticActionTreatment:
                        ffModel.PrepareAggregateCase(AggregateCaseSectionEnum.ProphylacticAction, idVersion.Value);
                        break;
                }

                #endregion
            }
            return ffModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="obj"></param>
        private void CreateFF(DbManagerProxy manager, AggregateCaseHeader obj)
        {
            long? idFormTemplate;
            switch (obj.idfsAggrCaseType)
            {
                case (long)AggregateCaseType.HumanAggregateCase: obj.FFPresenterCase = obj.SetFFModel(FFTypeEnum.HumanAggregateCase, obj.idfCaseObservation, manager, obj.idfVersion, out idFormTemplate);
                    obj.idfsCaseObservationFormTemplate = idFormTemplate;
                    break;

                case (long)AggregateCaseType.VetAggregateCase: obj.FFPresenterCase = obj.SetFFModel(FFTypeEnum.VetAggregateCase, obj.idfCaseObservation, manager, obj.idfVersion, out idFormTemplate);
                    obj.idfsCaseObservationFormTemplate = idFormTemplate;
                    break;
                case (long)AggregateCaseType.VetAggregateAction:
                    obj.FFPresenterDiagnostic = obj.SetFFModel(FFTypeEnum.VetEpizooticActionDiagnosisInv, obj.idfDiagnosticObservation, manager, obj.idfDiagnosticVersion, out idFormTemplate);
                    obj.idfsDiagnosticObservationFormTemplate = idFormTemplate;
                    obj.FFPresenterProphylactic = obj.SetFFModel(FFTypeEnum.VetEpizooticActionTreatment, obj.idfProphylacticObservation, manager, obj.idfProphylacticVersion, out idFormTemplate);
                    obj.idfsProphylacticObservationFormTemplate = idFormTemplate;
                    obj.FFPresenterSanitary = obj.SetFFModel(FFTypeEnum.VetEpizooticAction, obj.idfSanitaryObservation, manager, obj.idfSanitaryVersion, out idFormTemplate);
                    obj.idfsSanitaryObservationFormTemplate = idFormTemplate;
                    break;
            }
        }

        public partial class Accessor
        {
            protected void CheckDuplicates(DbManagerProxy manager, AggregateCaseHeader h)
            {
                int ret = manager.SetSpCommand("dbo.spAggregateCaseExists",
                    manager.Parameter("@StartDate", h.datStartDateCalc),
                    manager.Parameter("@FinishDate", h.datFinishDateCalc),
                    manager.Parameter("@AdminUnit", h.idfsAdministrativeUnitCalc),
                    manager.Parameter("@AggrCaseType", h.idfsAggrCaseType),
                    manager.Parameter("@CaseID", h.idfAggrCase)
                    ).ExecuteScalar<int>(ScalarSourceType.ReturnValue);
                if (ret == 1)
                {
                    throw new ValidationModelException("Agg_Case_already_exists", "", "", null, null, false);
                }
            }
        }

    }
}
