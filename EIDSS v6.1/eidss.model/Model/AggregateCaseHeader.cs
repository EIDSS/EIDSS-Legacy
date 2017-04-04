using System;
using System.Linq;
using System.Collections.Generic;
using BLToolkit.Data;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using bv.common.Core;

namespace eidss.model.Schema
{
    public partial class AggregateCaseHeader
    {
        protected static void CustomValidations(AggregateCaseHeader obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenterCase, true, false, true);
                acc.Validate(manager, obj.FFPresenterDiagnostic, true, false, true);
                acc.Validate(manager, obj.FFPresenterProphylactic, true, false, true);
                acc.Validate(manager, obj.FFPresenterSanitary, true, false, true);
            }
        }

        #region Year-Month-Quarter-Week
        private static BaseReferenceList _YearLookupTemplate;
        public static BaseReferenceList YearLookupTemplate
        {
            get
            {
                if (_YearLookupTemplate == null)
                {
                    _YearLookupTemplate = new BaseReferenceList("rftSampleStatus");
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        for (int i = DateTime.Now.Year + Localizer.YearShift; i >= 1900 + Localizer.YearShift; i--)
                            _YearLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, (long)i, i.ToString()));
                    }
                }
                return _YearLookupTemplate;
            }
        }

        private static Dictionary<string, BaseReferenceList> _MonthLookupTemplate = new Dictionary<string, BaseReferenceList>();
        public static void MonthLookupTemplate(ref AggregateCaseHeader obj)
        {
            lock (_MonthLookupTemplate)
            {
                if (!_MonthLookupTemplate.ContainsKey(ModelUserContext.CurrentLanguage))
                {
                    _MonthLookupTemplate.Add(ModelUserContext.CurrentLanguage, new BaseReferenceList("rftSampleStatus"));
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 1L, EidssMessages.Instance.GetString("January")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 2L, EidssMessages.Instance.GetString("February")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 3L, EidssMessages.Instance.GetString("March")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 4L, EidssMessages.Instance.GetString("April")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 5L, EidssMessages.Instance.GetString("May")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 6L, EidssMessages.Instance.GetString("June")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 7L, EidssMessages.Instance.GetString("July")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 8L, EidssMessages.Instance.GetString("August")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 9L, EidssMessages.Instance.GetString("September")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 10L, EidssMessages.Instance.GetString("October")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 11L, EidssMessages.Instance.GetString("November")));
                        _MonthLookupTemplate[ModelUserContext.CurrentLanguage].Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 12L, EidssMessages.Instance.GetString("December")));
                    }
                }
            }
            long thisYear = (long)System.DateTime.Now.Year;

            obj.MonthAggrLookup.RemoveAll(m => (long)m.Key > 0L);
            if (obj.YearForAggr == thisYear)
                obj.MonthAggrLookup.AddRange(_MonthLookupTemplate[ModelUserContext.CurrentLanguage].Where(m => m.idfsBaseReference <= (long)System.DateTime.Now.Month));
            else
                obj.MonthAggrLookup.AddRange(_MonthLookupTemplate[ModelUserContext.CurrentLanguage]);

            long? val = obj.MonthForAggr;
            obj.MonthAggr = obj.MonthAggrLookup
                .Where(c => c.idfsBaseReference == val)
                .SingleOrDefault();
        }

        private static BaseReferenceList _QuarterLookupTemplate;
        public static void QuarterLookupTemplate(ref AggregateCaseHeader obj)
        {
            if (_QuarterLookupTemplate == null)
            {
                _QuarterLookupTemplate = new BaseReferenceList("rftSampleStatus");
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _QuarterLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 1L, "1"));
                    _QuarterLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 2L, "2"));
                    _QuarterLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 3L, "3"));
                    _QuarterLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 4L, "4"));
                }
            }
            long thisYear = (long)System.DateTime.Now.Year;

            obj.QuarterAggrLookup.RemoveAll(m => (long)m.Key > 0L);
            if (obj.YearForAggr == thisYear)
                obj.QuarterAggrLookup.AddRange(_QuarterLookupTemplate.Where(m => (m.idfsBaseReference - 1) * 3 < (long)DateTime.Now.Month));
            else
                obj.QuarterAggrLookup.AddRange(_QuarterLookupTemplate);

            long? val = obj.QuarterForAggr;
            obj.QuarterAggr = obj.QuarterAggrLookup
                            .Where(c => c.idfsBaseReference == val)
                            .SingleOrDefault();
        }

        private static BaseReferenceList _WeekLookupTemplate;
        public static void WeekLookupTemplate(ref AggregateCaseHeader obj)
        {
            if (_WeekLookupTemplate == null)
                _WeekLookupTemplate = new BaseReferenceList("rftSampleStatus");
            _WeekLookupTemplate.Clear();
            if (obj.YearForAggr != null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    foreach (WeekPeriod wp in DatePeriodHelper.GetWeeksList((int)obj.YearForAggr))
                    {
                        _WeekLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, (long)wp.WeekNumber, String.Format("{0:d}-{1:d}", wp.WeekStartDate, wp.WeekStartDate.AddDays(6))));
                    }
                }
            }

            long thisYear = (long)DateTime.Now.Year;

            obj.WeekAggrLookup.RemoveAll(m => (long)m.Key > 0L);
            if (obj.YearForAggr == thisYear)
                obj.WeekAggrLookup.AddRange(_WeekLookupTemplate.Where(m => m.idfsBaseReference <= (long)DatePeriodHelper.GetWeekOfYear(DateTime.Now)));
            else
                obj.WeekAggrLookup.AddRange(_WeekLookupTemplate);

            long? val = obj.WeekForAggr;
            obj.WeekAggr = obj.WeekAggrLookup
                .Where(c => c.idfsBaseReference == val)
                .SingleOrDefault();
        }
        #endregion

        #region FF

        public static FFPresenterModel SetFFModel(FFTypeEnum ffType, long? idObservation, DbManagerProxy manager, long? idVersion, long idfAggrCase, out long? idFormTemplate)
        {
            idFormTemplate = null;
            var ffModel = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, idObservation);
            var observations = new List<long>();
            if (idObservation.HasValue) observations.Add(idObservation.Value);
            if (ffModel.CurrentTemplate == null)
            {
                ffModel.SetProperties(EidssSiteContext.Instance.CountryID, null, ffType, observations, idfAggrCase);
            }

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
                case (long)AggregateCaseType.HumanAggregateCase:
                    obj.FFPresenterCase = SetFFModel(FFTypeEnum.HumanAggregateCase, obj.idfCaseObservation, manager, obj.idfVersion, obj.idfAggrCase, out idFormTemplate);
                    obj.idfsCaseObservationFormTemplate = idFormTemplate;
                    break;

                case (long)AggregateCaseType.VetAggregateCase:
                    obj.FFPresenterCase = SetFFModel(FFTypeEnum.VetAggregateCase, obj.idfCaseObservation, manager, obj.idfVersion, obj.idfAggrCase, out idFormTemplate);
                    obj.idfsCaseObservationFormTemplate = idFormTemplate;
                    break;
                case (long)AggregateCaseType.VetAggregateAction:
                    obj.FFPresenterDiagnostic = SetFFModel(FFTypeEnum.VetEpizooticActionDiagnosisInv, obj.idfDiagnosticObservation, manager, obj.idfDiagnosticVersion, obj.idfAggrCase, out idFormTemplate);
                    obj.idfsDiagnosticObservationFormTemplate = idFormTemplate;
                    obj.FFPresenterProphylactic = SetFFModel(FFTypeEnum.VetEpizooticActionTreatment, obj.idfProphylacticObservation, manager, obj.idfProphylacticVersion, obj.idfAggrCase, out idFormTemplate);
                    obj.idfsProphylacticObservationFormTemplate = idFormTemplate;
                    obj.FFPresenterSanitary = SetFFModel(FFTypeEnum.VetEpizooticAction, obj.idfSanitaryObservation, manager, obj.idfSanitaryVersion, obj.idfAggrCase, out idFormTemplate);
                    obj.idfsSanitaryObservationFormTemplate = idFormTemplate;
                    break;
            }
        }
        #endregion

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
                    throw new ValidationModelException("Agg_Case_already_exists", "", "", null, null, ValidationEventType.Error, h);
                }
            }
        }

    }
}
