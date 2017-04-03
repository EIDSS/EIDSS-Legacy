using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class CaseTest
    {
        /*protected void CheckCanDelete(CaseTest obj)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (!Accessor.Instance(this.m_CS).ValidateCanDelete(manager, obj))
                {
                    throw new ValidationModelException("msgCantDeleteRecord", "_on_delete", "_on_delete", null, null, false);
                }
            }
        }*/
    }
}
