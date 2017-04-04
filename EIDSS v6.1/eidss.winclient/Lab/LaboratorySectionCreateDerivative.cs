using System;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionCreateDerivative : BaseDetailPanel_LaboratorySectionItem
    {
        public LaboratorySectionCreateDerivative()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var item = BusinessObject as LaboratorySectionItem;
            if (item == null) return;

            LookupBinder.BindSpinEdit(seNumber, item, "intNewSample");
            LookupBinder.BindLookup(leSampleTypes, item, "DerivativeType", item.DerivativeTypeLookup, false);
            LookupBinder.BindDate(dtAccessionDate, item, "datAccession");
        }


    }
}
