using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class LabSampleListItem
    {
        private static BaseReferenceList _CaseStatusLookupTemplate;
        public static BaseReferenceList CaseStatusLookupTemplate
        {
            get
            {
                if (_CaseStatusLookupTemplate == null)
                {
                    _CaseStatusLookupTemplate = new BaseReferenceList("rftSampleStatus");
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        _CaseStatusLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 1, bv.common.Resources.BvMessages.Get("msgCaseModeActive", "Active")));
                        _CaseStatusLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 2, bv.common.Resources.BvMessages.Get("msgCaseModePassive", "Passive")));
                        _CaseStatusLookupTemplate.Add(BaseReference.Accessor.Instance(null).CreateDummy(manager, null, 3, bv.common.Resources.BvMessages.Get("msgCaseModeVector", "Vector")));
                    }
                }
                return _CaseStatusLookupTemplate;
            }
        }
    }
}
