using System;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionAcceptedInPoorCondition : BaseDetailPanel_LaboratorySectionItem
    {
        public LaboratorySectionAcceptedInPoorCondition()
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

            LookupBinder.BindTextEdit(txtComment, item, "strComments");
        }


    }
}
