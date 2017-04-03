using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using bv.common;
using bv.common.Core;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using bv.common.db;

namespace EIDSS.RAM.Presenters
{
    public class LayoutDetailPresenter : RelatedObjectPresenter
    {
        private readonly ILayoutDetailView m_LayoutDetailView;
        private bool m_NewClicked;
        private readonly Layout_DB m_LayoutDbService;
        private readonly LayoutMediator m_LayoutMediator;

        public LayoutDetailPresenter(SharedPresenter sharedPresenter, ILayoutDetailView view)
            : base(sharedPresenter, view)
        {
            m_LayoutDbService = new Layout_DB(m_SharedPresenter.SharedModel);

            m_LayoutDetailView = view;
            m_LayoutDetailView.DBService = m_LayoutDbService;
            m_LayoutMediator = new LayoutMediator(this);

            m_LayoutDetailView.CopyLayoutCreating += m_LayoutDetailView_CopyLayoutCreating;
            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public bool StandardReports
        {
            get { return m_SharedPresenter.SharedModel.StandardReports; }
        }

        public Layout_DB LayoutDbService
        {
            get { return m_LayoutDbService; }
        }
       

        public bool LayoutAccessible
        {
            get { return m_NewClicked || !IsNewObject; }
        }

        public bool NewClicked
        {
            get { return m_NewClicked; }
            set { m_NewClicked = value; }
        }

        public void SetPivotAccessible(bool value)
        {
             m_SharedPresenter.SharedModel.PivotAccessible = value; 
        }
        private void m_LayoutDetailView_CopyLayoutCreating(object sender, CopyLayoutEventArgs e)
        {
            Dictionary<long, long> changedIds = LayoutDbService.CreateCopyLayout(m_LayoutMediator.LayoutDataSet);

            //Rename DataSource tables layout according to new idfLayoutSearchField
            if (e.PivotGrid.DataSource != null)
            {
                DataTable dataSource = e.PivotGrid.DataSource.Copy();
                foreach (DataColumn column in dataSource.Columns)
                {
                    long oldId = RamPivotGridHelper.GetIdFromFieldName(column.ColumnName);
                    if (!changedIds.ContainsKey(oldId))
                        throw new RamException(string.Format("Pivot DataSource column with Id {0} not found", oldId));
                    long newId = changedIds[oldId];

                    column.ColumnName = ReplaceIdInString(column.ColumnName, oldId, newId);
                }
                e.PivotGrid.DataSource = dataSource;
            }

            //Rename fields in layout according to new idfLayoutSearchField
            foreach (WinPivotGridField field in e.PivotGrid.BaseFields)
            {
                long oldId = field.Id;
                if (!changedIds.ContainsKey(oldId))
                    throw new RamException(string.Format("Field with Id {0} not found", oldId));
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
            if ((cmd is LayoutCommand))
            {
                var layoutCommand = (cmd as LayoutCommand);
                m_LayoutDetailView.ProcessLayoutCommand(layoutCommand);
            }
            if (cmd is ReportViewCommand)
            {
                var viewCommand = (cmd as ReportViewCommand);
                m_LayoutDetailView.ProcessReportViewCommand(viewCommand);
            }
            if ((cmd is PrintCommand))
            {
                var printCommand = (cmd as PrintCommand);
                m_LayoutDetailView.ProcessPrintCommand(printCommand);
            }
            if ((cmd is RefreshCommand))
            {
                var refreshCommand = (cmd as RefreshCommand);
                m_LayoutDetailView.ProcessRefreshCommand(refreshCommand);
            }
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.SelectedQueryId:
                    long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
                    m_LayoutDbService.QueryID = queryId;
                    break;
                case SharedProperty.SelectedLayoutId:
                    long layoutId = (m_SharedPresenter.SharedModel.SelectedLayoutId !=
                                     m_SharedPresenter.SharedModel.SelectedFolderId)
                                        ? m_SharedPresenter.SharedModel.SelectedLayoutId
                                        : -1L;
                    m_LayoutDetailView.OnLayoutSelected(new LayoutEventArgs(layoutId));
                    break;
                case SharedProperty.ChartDataVertical:
                    bool vertical = m_SharedPresenter.SharedModel.ChartDataVertical;
                    m_LayoutDetailView.OnChangeOrientation(new ChartChangeOrientationEventArgs(vertical));
                    break;
            }
        }

        public bool ParentHasChanges()
        {
            return m_SharedPresenter.SharedModel.ParentForm.HasChanges();
        }

        public bool Post(PostType postType)
        {
            try
            {
                return m_SharedPresenter.SharedModel.ParentForm.Post(postType);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return false;
            }
        }

        internal void PrepareAggregateList(IList<WinPivotGridField> fields)
        {
            LayoutDetailDataSet.AggregateDataTable aggregateTable = m_LayoutMediator.LayoutDataSet.Aggregate;
            var rowsToRemove = new List<LayoutDetailDataSet.AggregateRow>();

            List<string> originalFieldnames = fields.Select(field => field.OriginalName).ToList();
            foreach (LayoutDetailDataSet.AggregateRow row in aggregateTable.Rows)
            {
                LayoutDetailDataSet.AggregateRow localRow = row;
                if (!originalFieldnames.Contains(localRow.SearchFieldAlias))
                    rowsToRemove.Add(localRow);
            }
            foreach (LayoutDetailDataSet.AggregateRow row in rowsToRemove)
            {
                aggregateTable.RemoveAggregateRow(row);
            }
          

            int length = 0;
            foreach (WinPivotGridField field in fields)
            {
                string filter = string.Format("{0}='{1}'", aggregateTable.SearchFieldAliasColumn.ColumnName, field.OriginalName);
                if (aggregateTable.Select(filter).Length == 0)
                {
                    length++;
                }
            }

            var ids = BaseDbService.NewListIntID(length);
            int count = 0;
            foreach (WinPivotGridField field in fields)
            {
                string filter = string.Format("{0}='{1}'", aggregateTable.SearchFieldAliasColumn.ColumnName,field.OriginalName);
                if (aggregateTable.Select(filter).Length == 0)
                {
                    AddNewAggregateRow(aggregateTable, m_LayoutMediator.LayoutRow.idflQuery, m_LayoutMediator.LayoutRow.idflLayout,
                                       field.OriginalName, (long)field.GetSummaryType, ids[count]);
                    count++;
                    
                }
            }
        }
    }
}