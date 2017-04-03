using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Extenders;

namespace eidss.model.Schema
{
    public partial class Patient
    {
        /*public Patient DeepClone()
        {
            Patient ret = base.Clone() as Patient;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            if (CurrentResidenceAddress != null)
                ret.CurrentResidenceAddress = CurrentResidenceAddress.DeepClone();
            if (EmployerAddress != null)
                ret.EmployerAddress = EmployerAddress.DeepClone();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/

        public Patient CopyFrom(DbManagerProxy manager, Patient source)
        {
            // copy all fields, except primaryKey
            var ret = source.CloneWithSetup(manager) as Patient;
            if (ret == null)
            {
                return null;
            }

            ret.idfHuman = idfHuman;
            ret.idfRootHuman = source.idfRootHuman.HasValue ? source.idfRootHuman : source.idfHuman;
            if (CurrentResidenceAddress != null && source.CurrentResidenceAddress != null)
            {
                ret.CurrentResidenceAddress = CurrentResidenceAddress.CopyFrom(manager, source.CurrentResidenceAddress);
            }
            if (EmployerAddress != null && source.EmployerAddress != null)
            {
                ret.EmployerAddress = EmployerAddress.CopyFrom(manager, source.EmployerAddress);
            }
            if (RegistrationAddress != null && source.RegistrationAddress != null)
            {
                ret.RegistrationAddress = RegistrationAddress.CopyFrom(manager, source.RegistrationAddress);
            }
            else if (source.RegistrationAddress != null)
            {
                ret.RegistrationAddress = source.RegistrationAddress.CloneWithSetup(manager) as Address;
            }

            return ret;
        }

        public Patient Clear(DbManagerProxy manager, long id)
        {
            var ret = Accessor.Instance(null).Create(manager, Parent, id);
            ret.idfHuman = idfHuman;
            if (CurrentResidenceAddress != null && ret.CurrentResidenceAddress != null)
            {
                ret.CurrentResidenceAddress.idfGeoLocation = CurrentResidenceAddress.idfGeoLocation;
            }
            if (EmployerAddress != null && ret.EmployerAddress != null)
            {
                ret.EmployerAddress.idfGeoLocation = EmployerAddress.idfGeoLocation;
            }
            if (RegistrationAddress != null && ret.RegistrationAddress != null)
            {
                ret.RegistrationAddress.idfGeoLocation = RegistrationAddress.idfGeoLocation;
            }

            return ret;
        }

        internal void RaisePropChanged()
        {
            this.OnPropertyChanged("datDateofBirth");
            this.OnPropertyChanged("Gender");
        }
        public Patient Clear(DbManagerProxy manager)
        {
            return Clear(manager, (Parent as HumanCase).idfCase);
        }

    }
}
