using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using bv.common.Core;
using eidss.model.Avr.Export;

namespace eidss.model.Avr.Commands.Models
{
    public delegate bool TryToPrepareMapDataHandler(string columnName, out DataSet data);

    public class SharedModel : INotifyPropertyChanged, IDisposable
    {
        private readonly IPostable m_ParentForm;

        private bool m_StandardReports;
        private Dictionary<string, object> m_StartUpParameters;
        private long m_SelectedQueryId = -100;
        private long m_SelectedLayoutId = -100;
        private long m_SelectedFolderId = -100;
        private bool m_UseArchiveData;
        

        private DateTime m_QueryRefreshDateTime = DateTime.Now;

        private IExportStrategy m_ExportStrategy;

        public SharedModel(IPostable parentForm, IExportStrategy exportStrategy)
        {
            Utils.CheckNotNull(parentForm, "parentForm");
            Utils.CheckNotNull(exportStrategy, "exportStrategy");
            m_ParentForm = parentForm;
            ExportStrategy = exportStrategy;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IPostable ParentForm
        {
            get { return m_ParentForm; }
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

        public IExportStrategy ExportStrategy
        {
            get { return m_ExportStrategy; }
            internal set
            {
                m_ExportStrategy = value;
                RaisePropertyChangedEvent(SharedProperty.ExportStrategy);
            }
        }

        public DateTime QueryRefreshDateTime
        {
            get { return m_QueryRefreshDateTime; }
            set
            {
                m_QueryRefreshDateTime = value;
                RaisePropertyChangedEvent(SharedProperty.QueryRefreshDateTime);
            }
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
        }
    }
}