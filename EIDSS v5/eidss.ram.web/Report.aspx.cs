using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxCallback;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.ram.web.Components;
using eidss.ram.web.Components.Export;

namespace eidss.ram.web
{
    public partial class Report : BasePage
    {
        private WebPivotGridExporter m_GridExporter;

        public WebRamFormView WebRamForm
        {
            get
            {
                if (Session[WebRamFormView.SessionObjectName] == null)
                {
                    var newForm = new WebRamFormView(this, PivotGrid, IsUseArchive);
                    Session[WebRamFormView.LayoutWarning] = PivotGrid.Caption;
                    Session[WebRamFormView.SessionObjectName] = newForm;
                }
                return (WebRamFormView) Session[WebRamFormView.SessionObjectName];
            }
        }

        private bool IsUseArchive
        {
            get { return (Session["UseArchive"] != null) && (bool) Session["UseArchive"]; }
            set { Session["UseArchive"] = value; }
        }

        public bool CanReadArchivedData
        {
            get
            {
                var credentials = new ConnectionCredentials(null, "Archive");
                return credentials.IsCorrect && ModelUserContext.Instance.CanDo("CanReadArchivedData.Execute");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !Page.IsCallback)
            {
                UseArchive.Checked = IsUseArchive;
            }
            else if (UseArchive.Checked != IsUseArchive)
            {
                Session[WebRamFormView.SessionObjectName] = null;
                IsUseArchive = UseArchive.Checked;
            }

            UseArchive.Visible = CanReadArchivedData;

            RamPivotGrid winPivotGrid = WebRamForm.WinPivotGrid;
            PivotGrid.CreateWebPivotGridFrom(winPivotGrid);

            if (!IsPostBack && !Page.IsCallback)
            {
                PivotGrid.Criteria = (WebRamForm.IsReportCriteriaChanged)
                                         ? WebRamForm.ReportCriteria
                                         : winPivotGrid.Criteria;
                if (!WebRamForm.IsChartCriteriaChanged)
                {
                    WebRamForm.ChartCriteria = winPivotGrid.Criteria;
                }
                if (!WebRamForm.IsMapCriteriaChanged)
                {
                    WebRamForm.MapCriteria = winPivotGrid.Criteria;
                }

                FilterCaption.Text = PivotGrid.FriendlyCriteriaString;
                if (string.IsNullOrEmpty(CaptionTextBox.Text))
                {
                    CaptionTextBox.Text = WebRamForm.LayoutName;
                }
                SetHeader();
            }

            PivotGrid.AggregateTable = WebRamForm.AggregateTable;
            PivotGrid.DenominatorIndexes = PivotPresenter.GetIndexesDictionary(WebRamForm.AggregateTable,
                                                                               PivotGrid.Fields);

            PivotGrid.DataSource = WebRamForm.PivotPreparedDataSource;
            PivotGrid.NameSummaryTypeDictionary = WebRamForm.PreparedNameSummaryTypeDictionary;
            //  PivotGrid.OptionsView.ShowFilterSeparatorBar = PivotGridScrolling.Control;

            m_GridExporter = new WebPivotGridExporter(this, PivotGrid);

            if (!string.IsNullOrEmpty(Request.QueryString["open"]))
            {
                int formatId = int.Parse(Request.QueryString["open"]);
                m_GridExporter.Export(((WebExportFormat) formatId),
                                      PivotGrid.DataSource.TableName,
                                      new List<string> {CaptionTextBox.Text, FilterCaption.Text},
                                      false);
            }
        }

        protected void UseArchive_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void PivotGrid_PrefilterCriteriaChanged(object sender, EventArgs e)
        {
            WebRamForm.ReportCriteria = PivotGrid.Criteria;
            WebRamForm.WinPivotGrid.Criteria = PivotGrid.Criteria;
        }

        protected void cbControl_Callback(object source, CallbackEventArgs e)
        {
            if (IsCallback)
            {
                cbControl.JSProperties["cpNeedChangeFilterCaptionText"] = true;
                cbControl.JSProperties["cpFilterCaptionText"] = PivotGrid.FriendlyCriteriaString;
            }
            else
            {
                cbControl.JSProperties["cpNeedChangeFilterCaptionText"] = false;
            }
        }

        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            m_GridExporter.Export(((WebExportFormat) int.Parse(listExportFormat.SelectedItem.Value.ToString())),
                                  PivotGrid.DataSource.TableName,
                                  new List<string> {CaptionTextBox.Text, FilterCaption.Text},
                                  true);
        }

        private void SetHeader()
        {
            if (Master != null)
            {
                string queryPath = string.Format("{0}->{1}", "AVR", WebRamForm.QueryName);
                string layoutPath = string.Format("{0}->{1}", queryPath, WebRamForm.LayoutName);
                var master = ((SiteMaster) Master);
                master.QueryPathText = queryPath;
                master.LayoutHeaderText = layoutPath;
                if (!Utils.IsEmpty(Session[WebRamFormView.LayoutWarning]))
                {
                    master.LayoutWarningText = Session[WebRamFormView.LayoutWarning].ToString();
                }
            }
        }
    }
}