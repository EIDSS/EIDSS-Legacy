using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eidss.openapi.contract;

namespace eidss.openapi.wintest
{
    public partial class HumanCaseList : Form
    {
        private Api _api;

        public HumanCaseList(Api api)
        {
            _api = api;
            InitializeComponent();
        }

        private new void Refresh()
        {
            var filter = new HumanCaseListFilter();
            filter.DateEnteredFrom = dateFrom.Value.Date;
            filter.DateEnteredTo = dateTo.Value.Date;
            bindingSourceHumanCaseList.DataSource = _api.HumanCaseList(filter);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

    }
}
