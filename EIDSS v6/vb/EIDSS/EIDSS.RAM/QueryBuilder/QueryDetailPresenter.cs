using System;
using bv.common.Configuration;
using bv.winclient.Core;
using eidss.avr.BaseComponents;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.QueryBuilder
{
    public sealed class QueryDetailPresenter : RelatedObjectPresenter
    {
        private readonly IQueryDetailView m_QueryView;
        private readonly Query_DB m_QueryDbService;

        public QueryDetailPresenter(SharedPresenter sharedPresenter, IQueryDetailView view)
            : base(sharedPresenter, view)
        {
            m_QueryView = view;

            m_QueryDbService =  new Query_DB();
            m_QueryView.DBService = m_QueryDbService;
        }

        public Query_DB QueryDbService
        {
            get { return m_QueryDbService; }
        }

       

        public override void Process(Command cmd)
        {
            try
            {
                if ((cmd is QueryLayoutCommand))
                {
                    var layoutCommand = (cmd as QueryLayoutCommand);
                    m_QueryView.ProcessQueryLayoutCommand(layoutCommand);
                }
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }
    }
}