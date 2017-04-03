using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using bv.winclient.Layout;
using eidss.model.Schema;

namespace eidss.winclient.Lab
{
    public partial class LabTestAmendmentHistoryPanel : eidss.winclient.Schema.BaseGroupPanel_LabTestAmendment
    {
        public LabTestAmendmentHistoryPanel()
        {
            InitializeComponent();
            EditByDoubleClick = false;
            TopPanelVisible = false;
            //таблица не редактируется
            Grid.GridView.OptionsBehavior.Editable = false;
            Grid.GridView.OptionsBehavior.ReadOnly = true;
            Grid.GridView.OptionsView.ShowGroupPanel = false;

        }
        private void BindOldResult()
        {
            LabTestAmendment history = null;
            if (DataSource != null && DataSource.Count > 0)
                history = DataSource[0] as LabTestAmendment;
            if (history != null)
                Core.LookupBinder.BindTextEdit(txtOldResult, history, "strOldTestResult");
            else
                txtOldResult.DataBindings.Clear();
            
        }
        public override ILayout GetLayout()
        {
            return ParentLayout ??
                   (ParentLayout = this.CreateLayoutSimple(BusinessObject, Caption, FormID, Icon));
        }
        public override void LoadData(ref object id, int? hAcode = null)
        {
            base.LoadData(ref id,hAcode);
            BindOldResult();
        }
    }

}
