using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EIDSS.RAM;
using EIDSS.RAM.Presenters.RamForm;
using eidss.ram.web.Components;

namespace eidss.ram.web
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[WebRamFormView.SessionError] != null)
            {
                StandardReportTD.InnerText = Session[WebRamFormView.SessionError].ToString();
            }
            else
            {
                WebReportLink reports = RamMenuRegistrator.RegisterWebStaticReports();
                AddReportList(StandardReportTD, reports);
            }
            Session[WebRamFormView.SessionObjectName] = null;
            PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = -100;
            PresenterFactory.SharedPresenter.SharedModel.SelectedLayoutId = -100;

        }

        private static void AddReportList(Control parentControl, WebReportLink reportLink)
        {
            var table = new Table();
            parentControl.Controls.Add(table);

            foreach (WebReportLink childLink in reportLink.Children)
            {
                var row = new TableRow();
                table.Rows.Add(row);
                var cell = new TableCell {Text = @"&nbsp;", Width = 30};
                row.Cells.Add(cell);
                cell = new TableCell();
                row.Cells.Add(cell);

                string url = string.Format("~/Report.aspx?queryId={0}&layoutId={1}", childLink.QueryId,
                                           childLink.LayoutId);
                Control hyperLink = childLink.IsFolder
                                        ? (Control) new Label {Text = childLink.Name}
                                        : new HyperLink {Text = childLink.Name, NavigateUrl = url};
                cell.Controls.Add(hyperLink);

                AddReportList(cell, childLink);
            }
        }

    }
}