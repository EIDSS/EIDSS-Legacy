using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Helpers;
using bv.common.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class HumanCase
    {
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

    }
}
