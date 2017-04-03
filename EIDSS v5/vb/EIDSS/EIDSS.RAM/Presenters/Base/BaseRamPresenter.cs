using System;
using System.Collections.Generic;
using EIDSS.RAM.Presenters.RamForm;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using eidss.model.Resources;
using EIDSS.RAM_DB.Common.CommandProcessing;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using AggregateRow = EIDSS.RAM_DB.DBService.DataSource.LayoutDetailDataSet.AggregateRow;
using AggregateDataTable = EIDSS.RAM_DB.DBService.DataSource.LayoutDetailDataSet.AggregateDataTable;

namespace EIDSS.RAM.Presenters.Base
{
    public abstract class BaseRamPresenter : ICommandProcessor
    {
        public const int NavBarGroupHeaderHeight = 28;

        protected readonly SharedPresenter m_SharedPresenter;

        protected BaseRamPresenter(SharedPresenter sharedPresenter)
        {
            Utils.CheckNotNull(sharedPresenter, "sharedPresenter");
            m_SharedPresenter = sharedPresenter;
        }

        internal SharedPresenter SharedPresenter
        {
            get { return m_SharedPresenter; }
        }

        public abstract void Process(Command cmd);

        internal void ExportTo(string defaultExt, string filter, ExportDelegate exportDelegate)
        {
            Utils.CheckNotNullOrEmpty(defaultExt, "defaultExt");
            Utils.CheckNotNullOrEmpty(filter, "filter");
            Utils.CheckNotNull(exportDelegate, "exportDelegate");

            string fileName;
            if (m_SharedPresenter.SharedModel.ExportStrategy.ExportDialogOk(defaultExt, filter, out fileName))
            {
                try
                {
                    exportDelegate(fileName);
                }
                catch (Exception ex)
                {
                    string msg = EidssMessages.Get("msgCannotExport", "Cannot export file {0}");
                    Trace.WriteLine(Trace.Kind.Info, msg, fileName);
                    Trace.WriteLine(ex);
                    ErrorForm.ShowError(new EIDSSErrorMessage("msgCannotExport", "Cannot export file {0}",ex, fileName));
                }
            }
        }

        internal static AggregateRow AddNewAggregateRow
            (AggregateDataTable aggregateTable, long queryId, long layoutId, string originalFieldName, long aggregateFunctionId, long idfLayoutSearchField)
        {
            AggregateRow newRow = aggregateTable.NewAggregateRow();

            newRow.idflLayout = layoutId;
            newRow.SearchFieldAlias = originalFieldName;
            newRow.idfsAggregateFunction = aggregateFunctionId;
            newRow.idfLayoutSearchField = idfLayoutSearchField;
            
            KeyValuePair<string, string> translations = QueryProcessor.GetTranslations(queryId, originalFieldName);
            newRow.strOriginalFieldENCaption = translations.Key;
            newRow.strOriginalFieldCaption = translations.Value;

            aggregateTable.AddAggregateRow(newRow);
            return newRow;


        }
    }
}