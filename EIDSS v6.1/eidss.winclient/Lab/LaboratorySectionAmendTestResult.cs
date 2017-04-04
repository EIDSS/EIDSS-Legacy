using System;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionAmendTestResult : BaseDetailPanel_LaboratorySectionItem
    {
        public LaboratorySectionAmendTestResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            FormID = "L23";
            var item = BusinessObject as LaboratorySectionItem;
            if (item == null) return;

            LookupBinder.BindTextEdit(txtComment, item, "strReason");
            LookupBinder.BindLookup(leTestResult, item, "TestResultForAmend", item.TestResultForAmendLookup, false);
        }


    }
}
