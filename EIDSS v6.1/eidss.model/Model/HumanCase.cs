using System;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Helpers;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class HumanCase
    {
        protected static void CustomValidations(HumanCase hc)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (!eidss.model.Core.EidssUserContext.SmartphoneContext && !eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.UseSimplifiedHumanCaseReportForm)))
                {
                    acc.Validate(manager, hc.FFPresenterCs, true, false, true);
                    acc.Validate(manager, hc.FFPresenterEpi, true, false, true);
                }
            }
        }

        /*
        partial void Created(bv.model.BLToolkit.DbManagerProxy manager)
        {
            SetParent();
        }
        partial void Loaded(bv.model.BLToolkit.DbManagerProxy manager)
        {
            SetParent();
        }

        private void SetParent()
        {
            Patient.HCase = this;
            Patient.CurrentResidenceAddress.HCase = this;
            Patient.EmployerAddress.HCase = this;
            Patient.RegistrationAddress.HCase = this;
            RegistrationAddress.HCase = this;
        }
        private void ClearParent()
        {
            Patient.HCase = null;
            Patient.CurrentResidenceAddress.HCase = null;
            Patient.EmployerAddress.HCase = null;
            Patient.RegistrationAddress.HCase = null;
            RegistrationAddress.HCase = null;
        }
        */
        /*
        public override object Clone()
        {
            ClearParent();
            HumanCase ret = base.Clone() as HumanCase;
            SetParent();
            ret.SetParent();
            return ret;
        }

        partial void Cloned(bv.model.BLToolkit.DbManagerProxy manager, IObject clone)
        {
            var ret = clone as HumanCase;
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            Samples.ForEach(c => ret.Samples.Add(c.DeepClone(manager)));
            CaseTests.ForEach(c => ret.CaseTests.Add(c.DeepClone(manager)));
        }
        */
        /*public HumanCase DeepClone()
        {
            HumanCase ret = base.Clone() as HumanCase;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            ret.Patient = Patient.DeepClone();
            ret.PointGeoLocation = PointGeoLocation.DeepClone();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/

        public int? CalcPatientAge()
        {
            int _intPatientAge = 0;
            long _idfsHumanAgeType = 0;
            if (GetDOBandAge(ref _intPatientAge, ref _idfsHumanAgeType))
                return _intPatientAge;
            return this.Patient.intPatientAgeFromCase;
        }

        public long? CalcPatientAgeType()
        {
            int _intPatientAge = 0;
            long _idfsHumanAgeType = 0;
            if (GetDOBandAge(ref _intPatientAge, ref _idfsHumanAgeType))
                return _idfsHumanAgeType;
            return this.Patient.idfsHumanAgeTypeFromCase;
        }

        private bool GetDOBandAge(ref int _intPatientAge, ref long _idfsHumanAgeType)
        {
            double ddAge = -1;
            DateTime? datUp = null;
            if (this.Patient.datDateofBirth.HasValue && this.datD.HasValue)
            {
                datUp = this.datD;
                ddAge = - this.Patient.datDateofBirth.Value.Date.Subtract(this.datD.Value.Date).TotalDays;

                if (ddAge > -1)
                {
                    long yyAge = DateHelper.DateDifference(DateInterval.Year, this.Patient.datDateofBirth.Value.Date, datUp.Value);
                    if (yyAge > 0)
                    {
                        //'Years
                        _intPatientAge = (int)yyAge;
                        _idfsHumanAgeType = (long)HumanAgeTypeEnum.Years;
                        return true;
                    }
                    else
                    {
                        long mmAge = DateHelper.DateDifference(DateInterval.Month, this.Patient.datDateofBirth.Value.Date, datUp.Value);
                        if (mmAge > 0) 
                        {
                            //'Months
                            _intPatientAge = (int)mmAge;
                            _idfsHumanAgeType = (long)HumanAgeTypeEnum.Month;
                            return true;
                        }
                        else
                        {
                            //'Days
                            _intPatientAge = (int)ddAge;
                            _idfsHumanAgeType = (long)HumanAgeTypeEnum.Days;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected void ChangeOutbreakDiagnosis()
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var outbreak = Outbreak.Accessor.Instance(null).SelectByKey(manager, idfOutbreak);
                var idfsDiagnosisGroup = outbreak.DiagnosisLookup.Single(
                        c => c.idfsDiagnosisOrDiagnosisGroup == outbreak.idfsDiagnosisOrDiagnosisGroup).idfsDiagnosisGroup;
                manager.SetSpCommand("spOutbreak_Diagnosis_Update",
                                     manager.Parameter("@idfOutbreak", idfOutbreak),
                                     manager.Parameter("@idfsDiagnosisGroup", idfsDiagnosisGroup)
                    ).ExecuteNonQuery();
            }
        }

        public partial class Accessor
        {
            public void SetupChildHandlers(HumanCase obj, object newobj)
            {
                _SetupChildHandlers(obj, newobj);
                _SetupRequired(obj);
            }

            protected void CheckOutbreak(HumanCase obj)
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    if (obj.idfOutbreak.HasValue && obj.idfOutbreak.Value != 0)
                    {
                        var idfsCaseDiagnosis = manager.SetCommand("select dbo.fnIsCaseSessionDiagnosesInGroupOutbreak(@idfCase, @idfOutbreak)",
                            manager.Parameter("@idfCase", obj.idfCase),
                            manager.Parameter("@idfOutbreak", obj.idfOutbreak))
                            .ExecuteScalar<long>();
                        if (idfsCaseDiagnosis == 0)
                        {
                            Outbreak outbreak = Outbreak.Accessor.Instance(null).SelectByKey(manager, obj.idfOutbreak);
                            throw new ValidationModelException("msgOutbreakDiagnosisErrorCases", "idfOutbreak", "idfOutbreak",
                                new object[]
                                {
                                    obj.strCaseID,
                                    outbreak.strOutbreakID,
                                    outbreak.Diagnosis == null ? "" : outbreak.Diagnosis.name
                                }, GetType(), ValidationEventType.Error, obj);
                        }
                        if (idfsCaseDiagnosis > 0)
                        {
                            Outbreak outbreak = Outbreak.Accessor.Instance(null).SelectByKey(manager, obj.idfOutbreak);
                            throw new ValidationModelException("msgUpOutbreakDiagnosisToGroup", "idfOutbreak", "idfOutbreak",
                                new object[]
                                {
                                    outbreak.Diagnosis.name,
                                    obj.strCaseID,
                                    obj.strDiagnosis,
                                    outbreak.DiagnosisLookup.Single(i => i.idfsDiagnosisOrDiagnosisGroup == outbreak.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == outbreak.idfsDiagnosisOrDiagnosisGroup).idfsDiagnosisGroup).name
                                }, GetType(), ValidationEventType.Question, obj);
                        }
                    }
                }
            }

        }

    }
}
