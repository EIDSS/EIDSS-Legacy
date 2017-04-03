using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService.Models.Export;
using bv.common.Core;

namespace EIDSS.RAM_DB.DBService.Models
{
    public delegate DataTable GetMapDataTableHandler(string fieldName, out bool isSingle);

    public delegate DataView GetAvailableMapFieldViewHandler(bool isMap);

    public delegate DataView GetDenominatorDataViewHandler();

    public delegate DataView GetStatDateDataViewHandler();

    public delegate void ResetReportDataHandler();

    public class SharedModel : INotifyPropertyChanged, IDisposable
    {
        private readonly IPostable m_ParentForm;
        private DataTable m_QueryResult;
        private bool m_ShowAllItems = true;
        private bool m_StandardReports;
        private Dictionary<string, object> m_StartUpParameters;
        private long m_SelectedQueryId = -100;
        private long m_SelectedLayoutId = -100;
        private long m_SelectedFolderId = -100;
        private bool m_UseArchiveData;
        private bool m_ChartDataVertical;
        private bool m_PivotAccessible;
        private PivotSelectionEventArgs m_ControlsView;
        private PivotDataEventArgs m_PivotData;
        private GetMapDataTableHandler m_GetMapDataTableCallback;
        private GetAvailableMapFieldViewHandler m_GetAvailableMapFieldViewCallback;
        private GetDenominatorDataViewHandler m_GetDenominatorDataViewCallback;
        private GetStatDateDataViewHandler m_GetStatDateDataViewCallback;
        private ResetReportDataHandler m_ResetReportDataCallback;
        private IExportStrategy m_ExportStrategy;
        private string m_FilterText;
        private string m_PivotName;
        private string m_MapName;
        private string m_ChartName;
        private bool m_MapHasChanges;
        
        

        private bool m_AtLeastOneFieldVisible;

        public SharedModel(IPostable parentForm)
        {
            m_ParentForm = parentForm;
            ExportStrategy = new ExportDialogStrategy();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IPostable ParentForm
        {
            get { return m_ParentForm; }
        }

        public bool ChartDataVertical
        {
            get { return m_ChartDataVertical; }
            set
            {
                m_ChartDataVertical = value;
                RaisePropertyChangedEvent(SharedProperty.ChartDataVertical);
            }
        }

        public DataTable QueryResult
        {
            get { return m_QueryResult; }
            set
            {
                m_QueryResult = value;
                if (m_QueryResult != null)
                {
                    foreach (DataColumn column in m_QueryResult.Columns)
                    {
                        column.ReadOnly = false;
                    }
                    if (TableCopier != null)
                    {
                        TableCopier.Dispose();
                    }
                    TableCopier = new DataTableCopier(m_QueryResult);
                    TableCopier.ForceStart();
                }
                RaisePropertyChangedEvent(SharedProperty.QueryResult);
            }
        }

        public long SelectedQueryId
        {
            get { return m_SelectedQueryId; }
            set
            {
                m_SelectedQueryId = value;
                m_SelectedLayoutId = -100;
                RaisePropertyChangedEvent(SharedProperty.SelectedQueryId);
            }
        }

        public long SelectedLayoutId
        {
            get { return m_SelectedLayoutId; }
            set
            {
                if (m_SelectedLayoutId != value)
                {
                    m_SelectedLayoutId = value;
                    RaisePropertyChangedEvent(SharedProperty.SelectedLayoutId);
                }
            }
        }

        public long SelectedFolderId
        {
            get { return m_SelectedFolderId; }
            set
            {
                m_SelectedFolderId = value;
                RaisePropertyChangedEvent(SharedProperty.SelectedFolderId);
            }
        }

        public bool UseArchiveData
        {
            get { return m_UseArchiveData; }
            set
            {
                m_UseArchiveData = value;
                RaisePropertyChangedEvent(SharedProperty.UseArchiveData);
            }
        }

        public bool ShowAllItems
        {
            get { return m_ShowAllItems; }
            set
            {
                m_ShowAllItems = value;
                RaisePropertyChangedEvent(SharedProperty.ShowAllItems);
            }
        }

        public bool StandardReports
        {
            get { return m_StandardReports; }
            set
            {
                m_StandardReports = value;
                RaisePropertyChangedEvent(SharedProperty.StandardReports);
            }
        }

        public Dictionary<string, object> StartUpParameters
        {
            get { return m_StartUpParameters; }
            set
            {
                m_StartUpParameters = value;
                RaisePropertyChangedEvent(SharedProperty.StartUpParameters);
            }
        }

        public bool AtLeastOneFieldVisible
        {
            get { return m_AtLeastOneFieldVisible; }
            set
            {
                m_AtLeastOneFieldVisible = value;
                RaisePropertyChangedEvent(SharedProperty.AtLeastOneFieldVisible);
            }
        }

        public PivotSelectionEventArgs ControlsView
        {
            get { return m_ControlsView; }
            set
            {
                m_ControlsView = value;
                RaisePropertyChangedEvent(SharedProperty.ControlsView);
            }
        }

        public PivotDataEventArgs PivotData
        {
            get { return m_PivotData; }
            set
            {
                m_PivotData = value;
                RaisePropertyChangedEvent(SharedProperty.PivotData);
            }
        }

        public GetMapDataTableHandler GetMapDataTableCallback
        {
            get { return m_GetMapDataTableCallback; }
            set
            {
                m_GetMapDataTableCallback = value;
                RaisePropertyChangedEvent(SharedProperty.GetMapDataTableCallback);
            }
        }

        public GetAvailableMapFieldViewHandler GetAvailableMapFieldViewCallback
        {
            get { return m_GetAvailableMapFieldViewCallback; }
            set
            {
                m_GetAvailableMapFieldViewCallback = value;
                RaisePropertyChangedEvent(SharedProperty.GetAvailableMapFieldViewCallback);
            }
        }

        public GetDenominatorDataViewHandler GetDenominatorDataViewCallback
        {
            get { return m_GetDenominatorDataViewCallback; }
            set
            {
                m_GetDenominatorDataViewCallback = value;
                RaisePropertyChangedEvent(SharedProperty.GetDenominatorDataViewCallback);
            }
        }

        public GetStatDateDataViewHandler GetStatDateDataViewCallback
        {
            get { return m_GetStatDateDataViewCallback; }
            set
            {
                m_GetStatDateDataViewCallback = value;
                RaisePropertyChangedEvent(SharedProperty.GetDenominatorDataViewCallback);
            }
        }

        public ResetReportDataHandler ResetReportDataCallback
        {
            get { return m_ResetReportDataCallback; }
            set
            {
                m_ResetReportDataCallback = value;
                RaisePropertyChangedEvent(SharedProperty.ResetReportDataCallback);
            }
        }

        public bool PivotAccessible
        {
            get { return m_PivotAccessible; }
            set
            {
                m_PivotAccessible = value;
                RaisePropertyChangedEvent(SharedProperty.PivotAccessible);
            }
        }

        public IExportStrategy ExportStrategy
        {
            get { return m_ExportStrategy; }
            internal set
            {
                m_ExportStrategy = value;
                RaisePropertyChangedEvent(SharedProperty.ExportStrategy);
            }
        }

        public string FilterText
        {
            get { return m_FilterText; }
            set
            {
                m_FilterText = value;
                RaisePropertyChangedEvent(SharedProperty.FilterText);
            }
        }

        public string PivotName
        {
            get { return m_PivotName; }
            set
            {
                m_PivotName = value;
                RaisePropertyChangedEvent(SharedProperty.PivotName);
            }
        }

        public string MapName
        {
            get { return m_MapName; }
            set
            {
                m_MapName = value;
                RaisePropertyChangedEvent(SharedProperty.MapName);
            }
        }

        public string ChartName
        {
            get { return m_ChartName; }
            set
            {
                m_ChartName = value;
                RaisePropertyChangedEvent(SharedProperty.ChartName);
            }
        }

        public bool MapHasChanges
        {
            get { return m_MapHasChanges; }
            set
            {
                m_MapHasChanges = value;
                RaisePropertyChangedEvent(SharedProperty.MapHasChanges);
            }
        }


        public DataTableCopier TableCopier { get; private set; }

        public DataView GetAvailableMapFieldView(bool isMap)
        {
            if (GetAvailableMapFieldViewCallback == null)
            {
                throw new RamException("GetAvailableMapFieldViewCallback is not initialized for SharedModel.");
            }

            return GetAvailableMapFieldViewCallback(isMap);
        }

        public DataView GetDenominatorDataView()
        {
            if (GetDenominatorDataViewCallback == null)
            {
                throw new RamException("GetDenominatorDataViewCallback is not initialized for SharedModel.");
            }

            return GetDenominatorDataViewCallback();
        }

        public DataView GetStatDateDataView()
        {
            if (GetStatDateDataViewCallback == null)
            {
                throw new RamException("GetDenominatorDataViewCallback is not initialized for SharedModel.");
            }

            return GetStatDateDataViewCallback();
        }

        public void ResetReportData()
        {
            ResetReportDataHandler handler = ResetReportDataCallback;
            if (handler != null)
            {
                handler();
            }
        }

        public DataTable GetMapDataTable(string fieldAlias, out bool isSingle)
        {
            Utils.CheckNotNullOrEmpty(fieldAlias, "fieldName");

            if (GetMapDataTableCallback == null)
            {
                throw new RamException("GetMapDataTableCallback is not initialized for SharedModel.");
            }

            return GetMapDataTableCallback(fieldAlias, out isSingle);
        }

        protected virtual void RaisePropertyChangedEvent(SharedProperty property)
        {
            PropertyChangedEventHandler eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }

        public void Dispose()
        {
            GetAvailableMapFieldViewCallback = null;
            GetDenominatorDataViewCallback = null;
            GetMapDataTableCallback = null;
            GetStatDateDataViewCallback = null;

            QueryResult = null;

            if (TableCopier != null)
            {
                TableCopier.Dispose();
            }
            
        }
    }
}