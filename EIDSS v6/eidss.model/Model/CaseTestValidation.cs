using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class CaseTestValidation
    {
        /*public CaseTestValidation DeepClone()
        {
            CaseTestValidation ret = base.Clone() as CaseTestValidation;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }

        partial void Cloned(DbManagerProxy manager, IObject clone)
        {
            (clone as CaseTestValidation).m_IsNew = this.m_IsNew;
        }
        */
    }
}
