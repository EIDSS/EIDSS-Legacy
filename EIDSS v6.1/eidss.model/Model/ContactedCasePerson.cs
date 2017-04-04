using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class ContactedCasePerson
    {
        /*public ContactedCasePerson DeepClone()
        {
            ContactedCasePerson ret = base.Clone() as ContactedCasePerson;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            ret.Person = Person.DeepClone();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/
        public partial class Accessor
        {
            public void SetupChildHandlers(ContactedCasePerson obj, object newobj)
            {
                _SetupChildHandlers(obj, newobj);
                _SetupRequired(obj);
            }
        }

    }
}
