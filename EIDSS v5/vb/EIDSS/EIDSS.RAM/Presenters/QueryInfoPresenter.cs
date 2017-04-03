using System;
using System.ComponentModel;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using EIDSS.RAM_DB.Views;

namespace EIDSS.RAM.Presenters
{
    public class QueryInfoPresenter : RelatedObjectPresenter
    {
        private readonly IQueryInfoView m_QueryInfoView;

        public QueryInfoPresenter(SharedPresenter sharedPresenter, IQueryInfoView view)
            : base(sharedPresenter, view)
        {
            m_QueryInfoView = view;
            m_QueryInfoView.DBService = new QueryInfo_DB();

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public bool ShowAllItems
        {
            get { return m_SharedPresenter.SharedModel.ShowAllItems; }
        }

        public override void Process(Command cmd)
        {
            if ((cmd is QueryCommand))
            {
                var queryCommand = (cmd as QueryCommand);
                queryCommand.State = CommandState.Pending;
                switch (queryCommand.Operation)
                {
                    case QueryOperation.New:
                        m_QueryInfoView.CreateQuery();
                        break;
                    case QueryOperation.Edit:
                        m_QueryInfoView.EditQuery();
                        break;
                    case QueryOperation.Delete:
                        m_QueryInfoView.DeleteQuery();
                        break;
                }
                queryCommand.State = CommandState.Processed;
            }
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty)(Enum.Parse(typeof(SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.UseArchiveData:
                    // reload query
                    m_QueryInfoView.RaiseQuerySelectedEvent(m_SharedPresenter.SharedModel.SelectedQueryId);    
                    break;
            }
        }
    }
}