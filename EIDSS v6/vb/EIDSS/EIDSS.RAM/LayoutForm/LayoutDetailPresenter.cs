using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using bv.common.Core;
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
using eidss.model.Avr.Pivot;

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

            m_LayoutDetailView.CopyLayoutCreating += m_LayoutDetailView_CopyLayoutCreating;
            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public override void Dispose()
        {
            try
            {
                m_LayoutDetailView.CopyLayoutCreating -= m_LayoutDetailView_CopyLayoutCreating;
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

        private void m_LayoutDetailView_CopyLayoutCreating(object sender, CopyLayoutEventArgs e)
        {
            Dictionary<long, long> changedIds = LayoutDbService.CreateCopyLayout(m_LayoutMediator.LayoutDataSet);

            //Rename DataSource tables layout according to new idfLayoutSearchField
            if (e.PivotGrid.DataSource != null)
            {
                DataTable dataSource = e.PivotGrid.DataSource.RealPivotData.Copy();
                foreach (DataColumn column in dataSource.Columns)
                {
                    long oldId = AvrPivotGridFieldHelper.GetIdFromFieldName(column.ColumnName);
                    if (!changedIds.ContainsKey(oldId))
                    {
                        throw new AvrException(string.Format("Pivot DataSource column with Id {0} not found", oldId));
                    }
                    long newId = changedIds[oldId];

                    column.ColumnName = ReplaceIdInString(column.ColumnName, oldId, newId);
                }
                e.PivotGrid.DataSource = new AvrPivotGridData(dataSource);
            }

            //Rename fields in layout according to new idfLayoutSearchField
            foreach (IAvrPivotGridField field in e.PivotGrid.BaseFields)
            {
                long oldId = field.GetFieldId();
                if (!changedIds.ContainsKey(oldId))
                {
                    throw new AvrException(string.Format("Field with Id {0} not found", oldId));
                }
                long newId = changedIds[oldId];

                field.Name = ReplaceIdInString(field.Name, oldId, newId);
                field.FieldName = ReplaceIdInString(field.FieldName, oldId, newId);
            }
            //chage filters of layout  according to new idfLayoutSearchField
            string criteriaString = e.PivotGrid.CriteriaString;
            if (!string.IsNullOrEmpty(criteriaString))
            {
                foreach (KeyValuePair<long, long> pair in changedIds)
                {
                    criteriaString = ReplaceIdInString(criteriaString, pair.Key, pair.Value);
                    e.DisabledCriteria = ReplaceIdInString(criteriaString, pair.Key, pair.Value);
                }
                e.PivotGrid.CriteriaString = criteriaString;
            }
            if (!string.IsNullOrEmpty(e.DisabledCriteria))
            {
                foreach (KeyValuePair<long, long> pair in changedIds)
                {
                    e.DisabledCriteria = ReplaceIdInString(e.DisabledCriteria, pair.Key, pair.Value);
                }
            }
        }

        private static string ReplaceIdInString(string oldString, long oldId, long newId)
        {
            Utils.CheckNotNullOrEmpty(oldString, "oldString");
            return oldString.Replace(oldId.ToString(CultureInfo.InvariantCulture), newId.ToString(CultureInfo.InvariantCulture));
        }

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