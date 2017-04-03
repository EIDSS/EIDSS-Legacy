using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using EIDSS;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.Views;
using bv.common;
using bv.common.Core;
using bv.common.Resources;
using bv.common.db;
using bv.common.db.Core;
using bv.common.win;
using eidss.model.Resources;

namespace eidss.ram.web.Components
{
    public class WebRamFormView : IRamFormView
    {
        public const string SessionObjectName = "WebRamForm";
        public const string LayoutWarning = "LayoutWarning";
        public const string SessionError = "SessionError";
        public event EventHandler<CommandEventArgs> SendCommand;

        private CriteriaOperator m_ReportCriteria;
        private CriteriaOperator m_ChartCriteria;
        private CriteriaOperator m_MapCriteria;

        private readonly Page m_ParentPage;
        private readonly LayoutDetailDataSet m_DataSet;
        
        private readonly Dictionary<string, CustomSummaryType> m_PreparedNameSummaryTypeDictionary;

        public WebRamFormView(Page parentPage, WebPivotGrid pivotGrid, bool isArchive)
        {
            Utils.CheckNotNull(parentPage, "parentPage");
            Utils.CheckNotNull(pivotGrid, "pivotGrid");

            m_ParentPage = parentPage;
            PivotGrid = pivotGrid;

            SharedPresenter = PresenterFactory.SharedPresenter;
            RamPresenter = (RamFormPresenter) SharedPresenter[this];

            SharedPresenter.SharedModel.ShowAllItems = true;
            LayoutDBService = new Layout_DB(SharedPresenter.SharedModel);
            DBService = LayoutDBService;

            QueryName = LookupCache.GetLookupValue(QueryId, LookupTables.Query, "QueryName");

            var layoutId = GetLayoutId();
            RamPresenter.ExecQuery(QueryId, isArchive);
            SharedPresenter.SharedModel.SelectedQueryId = QueryId;
            SharedPresenter.SharedModel.SelectedLayoutId = layoutId;

            m_DataSet = (LayoutDetailDataSet)LayoutDBService.GetDetail(layoutId);

            using (PivotGrid.BeginTransaction())
            {
                WinPivotGrid = new RamPivotGrid();
                WinPivotGrid.OptionsLayout.StoreAllOptions = true;
                WinPivotGrid.OptionsLayout.StoreAppearance = true;

                // todo: [ivan] dispose previous datasource if needed

                WinPivotGrid.DataSourceWithFields = PivotPreparedDataSource =
                    PivotPresenter.GetWebPreparedDataSource(AggregateTable, SharedPresenter.SharedModel.QueryResult);

                WinPivotGrid.NameSummaryTypeDictionary = PivotPresenter.GetNameSummaryTypeDictionary(AggregateTable);
                m_PreparedNameSummaryTypeDictionary = WinPivotGrid.NameSummaryTypeDictionary;

                RestorePivotSettings(WinPivotGrid);

                FillDataSourceWithAbsentValues();
                
            }
        }

        private void FillDataSourceWithAbsentValues()
        {
            try
            {
                if (WinPivotGrid.CellsCount <= RamPivotGrid.MaxLayoutCellCount)
                {
                    WinPivotGrid.FillDataSourceWithAbsentValues();
                }
                else
                {
                    PivotGrid.Caption = string.Format(EidssMessages.Get("msgTooManyLayoutCells"),
                                                      WinPivotGrid.CellsCount.ToString(),
                                                      RamPivotGrid.MaxLayoutCellCount.ToString());
                }
            }
            catch (OutOfMemoryException)
            {
                PivotGrid.Caption = string.Format(BvMessages.Get("ErrAVROutOfMemory"));
            }
        }

        public RamFormPresenter RamPresenter { get; private set; }

        public SharedPresenter SharedPresenter { get; private set; }

        public BaseRamDbService LayoutDBService { get; private set; }

        public WebPivotGrid PivotGrid { get; private set; }

        public RamPivotGrid WinPivotGrid { get; private set; }

        public bool IsReportCriteriaChanged { get; private set; }
        public bool IsChartCriteriaChanged { get; private set; }
        public bool IsMapCriteriaChanged { get; private set; }

        public CriteriaOperator ReportCriteria
        {
            get { return m_ReportCriteria; }
            set
            {
                m_ReportCriteria = value;
                IsReportCriteriaChanged = true;
            }
        }

        public CriteriaOperator ChartCriteria
        {
            get { return m_ChartCriteria; }
            set
            {
                m_ChartCriteria = value;
                IsChartCriteriaChanged = true;
            }
        }

        public CriteriaOperator MapCriteria
        {
            get { return m_MapCriteria; }
            set
            {
                m_MapCriteria = value;
                IsMapCriteriaChanged = true;
            }
        }

        public DataTable PivotPreparedDataSource { get; private set; }

        public Dictionary<string, CustomSummaryType> PreparedNameSummaryTypeDictionary
        {
            get { return m_PreparedNameSummaryTypeDictionary; }
        }

        public LayoutDetailDataSet LayoutDataSet
        {
            get { return m_DataSet; }
        }

        public LayoutDetailDataSet.LayoutDataTable LayoutTable
        {
            get { return LayoutDataSet.Layout; }
        }

        public LayoutDetailDataSet.AggregateDataTable AggregateTable
        {
            get { return LayoutDataSet.Aggregate; }
        }

        public LayoutDetailDataSet.LayoutRow LayoutRow
        {
            get
            {
                if (LayoutTable.Count == 0)
                {
                    throw new RamDbException("Table Layout of BaseDataSet is empty");
                }
                return (LayoutDetailDataSet.LayoutRow) LayoutDataSet.Layout.Rows[0];
            }
        }

        public string LayoutXml
        {
            get
            {
                string basicXml = LayoutRow.IsstrBasicXmlNull()
                                      ? string.Empty
                                      : LayoutRow.strBasicXml;
                return basicXml;
            }
        }

        public string QueryName { get; private set; }

        public string LayoutName
        {
            get
            {
                string name = LayoutRow.IsstrPivotNameNull()
                                  ? string.Empty
                                  : LayoutRow.strLayoutName;
                return name;
            }
        }

        public string ChartName
        {
            get
            {
                string name = LayoutRow.IsstrChartNameNull()
                                  ? LayoutName
                                  : LayoutRow.strChartName;
                return name;
            }
        }

        public string MapName
        {
            get
            {
                string name = LayoutRow.IsstrMapNameNull()
                                  ? LayoutName
                                  : LayoutRow.strMapName;
                return name;
            }
        }


        public long QueryId
        {
            get
            {
                long queryId = PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId;
                if (queryId < 0)
                {
                    long.TryParse(m_ParentPage.Request["queryId"], out queryId);
                }
                return queryId;
            }
        }

        public bool PivotAxis
        {
            get { return !LayoutRow.IsblnPivotAxisNull() && LayoutRow.blnPivotAxis; }
        }

        public bool ShowPointLabels
        {
            get { return !LayoutRow.IsblnShowPointLabelsNull() && LayoutRow.blnShowPointLabels; }
        }

        public DBChartType ChartType
        {
            get
            {
                return LayoutRow.IsidfsChartTypeNull()
                           ? DBChartType.chrBar
                           : (DBChartType) LayoutRow.idfsChartType;
            }
        }

        public void OnSendCommand(CommandEventArgs e)
        {
            EventHandler<CommandEventArgs> handler = SendCommand;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private long GetLayoutId()
        {

            long layoutId = PresenterFactory.SharedPresenter.SharedModel.SelectedLayoutId;
            if (layoutId < 0)
            {
                long.TryParse(m_ParentPage.Request["layoutId"], out layoutId);
            }
            return layoutId;

        }

        private void RestorePivotSettings(RamPivotGrid winPivotGrid)
        {
            using (winPivotGrid.BeginTransaction())
            {
                if (!string.IsNullOrEmpty(LayoutXml))
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var streamWriter = new StreamWriter(stream))
                        {
                            streamWriter.Write(LayoutXml);
                            streamWriter.Flush();
                            stream.Position = 0;
                            winPivotGrid.RestoreLayoutFromStream(stream);
                        }
                    }
                }
                winPivotGrid.Appearance.Cell.TextOptions.HAlignment = HorzAlignment.Near;
                winPivotGrid.OptionsLayout.StoreAllOptions = true;
                winPivotGrid.OptionsLayout.StoreAppearance = true;
                winPivotGrid.OptionsView.ShowFilterHeaders = false;
                winPivotGrid.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;

                winPivotGrid.PivotGridPresenter.UpdatePivotCaptions();
            }
        }

        #region IRamFormView members

        public void RegisterChildObject(IRelatedObject child, RelatedPostOrder childPostingType)
        {
        }

        public void UnRegisterChildObject(IRelatedObject child)
        {
        }

        public bool HasChanges()
        {
            return false;
        }

        public bool ValidateData()
        {
            return true;
        }

        public bool LoadData(ref object id)
        {
            throw new NotImplementedException();
        }

        public object GetChildKey(IRelatedObject child)
        {
            throw new NotImplementedException();
        }

        public BaseDbService DBService { get; set; }
        public IRelatedObject ParentObject { get; set; }
        public DataSet baseDataSet { get; set; }
        public bool ReadOnly { get; set; }

        public List<IRelatedObject> Children
        {
            get { return new List<IRelatedObject>(); }
        }

        public bool UseParentDataset
        {
            get { return true; }
        }

        public void OnPivotFieldVisibleChanged(LayoutFieldVisibleChanged e)
        {
        }

        public void OnPivotSelected(PivotSelectionEventArgs e)
        {
        }

        #endregion
    }
}