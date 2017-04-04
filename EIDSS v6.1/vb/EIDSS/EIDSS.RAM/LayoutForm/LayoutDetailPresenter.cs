using System;
using System.Collections.Generic;
using System.ComponentModel;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Models;
using eidss.model.Avr.Commands.Refresh;

namespace eidss.avr.LayoutForm
{
    public sealed class LayoutDetailPresenter : RelatedObjectPresenter
    {
        private readonly ILayoutDetailView m_LayoutDetailView;
        private readonly Layout_DB m_LayoutDbService;
        private readonly LayoutMediator m_LayoutMediator;

        public LayoutDetailPresenter(SharedPresenter sharedPresenter, ILayoutDetailView view)
            : base(sharedPresenter, view)
        {
            m_LayoutDbService = new WinLayout_DB(m_SharedPresenter.SharedModel);

            m_LayoutDetailView = view;
            m_LayoutDetailView.DBService = m_LayoutDbService;
            m_LayoutMediator = new LayoutMediator(this);
            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public override void Dispose()
        {
            try
            {
            
                m_SharedPresenter.SharedModel.PropertyChanged -= SharedModel_PropertyChanged;
            }
            finally
            {
                base.Dispose();
            }
        }

        public bool StandardReports
        {
            get { return m_SharedPresenter.SharedModel.StandardReports; }
        }

        public Layout_DB LayoutDbService
        {
            get { return m_LayoutDbService; }
        }

        public bool NewClicked { get; set; }


        public override void Process(Command cmd)
        {
            if ((cmd is QueryLayoutCommand))
            {
                var layoutCommand = (cmd as QueryLayoutCommand);
                m_LayoutDetailView.ProcessQueryLayoutCommand(layoutCommand);
            }

            if ((cmd is RefreshPivotCommand))
            {
                var refreshCommand = (cmd as RefreshPivotCommand);
                refreshCommand.State = CommandState.Pending;
                m_LayoutDetailView.PivotDetailView.RaisePivotGridDataLoadedCommand();
                refreshCommand.State = CommandState.Processed;
            }
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.SelectedLayoutId:
                    long layoutId = (m_SharedPresenter.SharedModel.SelectedLayoutId !=
                                     m_SharedPresenter.SharedModel.SelectedFolderId)
                        ? m_SharedPresenter.SharedModel.SelectedLayoutId
                        : -1L;
                    m_LayoutDetailView.OnLayoutSelected(new LayoutEventArgs(layoutId));
                    break;
            }
        }

        public bool ParentHasChanges()
        {
            return m_SharedPresenter.SharedModel.ParentForm.HasChanges();
        }

        internal void PrepareDbService()
        {
            LayoutDbService.SetQueryID(SharedPresenter.SharedModel.SelectedQueryId);
        }

        internal void PrepareLayoutSearchFieldsBeforePost(IList<IAvrPivotGridField> fields)
        {
            LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldTable = m_LayoutMediator.LayoutDataSet.LayoutSearchField;
            long idflQuery = m_SharedPresenter.SharedModel.SelectedQueryId;
            long idflLayout = m_LayoutMediator.LayoutRow.idflLayout;

            AvrPivotGridHelper.PrepareLayoutSearchFieldsBeforePost(fields, searchFieldTable, idflQuery, idflLayout);
        }
    }
}