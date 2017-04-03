using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

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

        public Patient CopyFrom(Patient source)
        {
            // copy all fields, except primaryKey
            var ret = source.Clone() as Patient;
            if (ret == null)
            {
                return null;
            }

            ret.idfHuman = idfHuman;
            ret.idfRootHuman = source.idfRootHuman.HasValue ? source.idfRootHuman : source.idfHuman;
            if (CurrentResidenceAddress != null && source.CurrentResidenceAddress != null)
            {
                ret.CurrentResidenceAddress = CurrentResidenceAddress.CopyFrom(source.CurrentResidenceAddress);
            }
            if (EmployerAddress != null && source.EmployerAddress != null)
            {
                ret.EmployerAddress = EmployerAddress.CopyFrom(source.EmployerAddress);
            }
            if (RegistrationAddress != null && source.RegistrationAddress != null)
            {
                ret.RegistrationAddress = RegistrationAddress.CopyFrom(source.RegistrationAddress);
            }
            else if (source.RegistrationAddress != null)
            {
                ret.RegistrationAddress = source.RegistrationAddress.Clone() as Address;
            }

            ret.SetChange();

            return ret;
        }
    }
}
