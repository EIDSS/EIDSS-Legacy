using System;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionValidateTestResult : BaseDetailPanel_LaboratorySectionItem
    {
        public LaboratorySectionValidateTestResult()
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

            LookupBinder.BindDate(dtResultDate, item, "datConcludedDate");
        }


    }
}
