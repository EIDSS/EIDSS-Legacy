using System;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.avr.BaseComponents;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.Interfaces;
using eidss.avr.Tools;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Refresh;
using eidss.model.Avr.Export;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.SourceData;
using eidss.model.Resources;
using eidss.winclient.Reports;

namespace eidss.avr.MainForm
{
    public sealed class AvrMainFormPresenter : RelatedObjectPresenter
    {
        private readonly IAvrMainFormView m_FormView;

        public AvrMainFormPresenter(SharedPresenter sharedPresenter, IAvrMainFormView view)
            : base(sharedPresenter, view)
        {
            m_FormView = view;

            m_FormView.DBService = new BaseAvrDbService();
        }

        public override void Process(Command cmd)
        {
            if (cmd is LayoutNewCommand)
            {
                m_FormView.LayoutNewStart();
                cmd.State = CommandState.Processed;
            }
            if (cmd is LayoutCopyCommand)
            {
                m_FormView.LayoutCopyStart();
                cmd.State = CommandState.Processed;
            }

            if (cmd is QueryLayoutCloseCommand)
            {
                m_FormView.CloseQueryLayoutStart();
                cmd.State = CommandState.Processed;
            }
            else if (cmd is QueryLayoutDeleteCommand)
            {
                var deleteCommand = (cmd as QueryLayoutDeleteCommand);
                m_FormView.DeleteQueryLayoutStart(deleteCommand);
                cmd.State = CommandState.Processed;
            }
            else if (cmd is ExecQueryCommand)
            {
                long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
                long layoutId = m_SharedPresenter.SharedModel.SelectedLayoutId;
                InvalidateQuery(queryId);
                ExecQuery(queryId, layoutId);
                cmd.State = CommandState.Processed;
            }
            else if (cmd is RefreshCaptionCommand)
            {
                var refreshCommand = (cmd as RefreshCaptionCommand);

                m_FormView.ChangeFormCaption(refreshCommand);
                cmd.State = CommandState.Processed;
            }
        }

        public void ExportQueryLineListToExcelOrAccess(long queryId, ExportType exportType)
        {
            if (exportType == ExportType.Mdb)
            {
                ExportTo("mdb", EidssMessages.Get("msgFilterAccess", "MS Access database|*.mdb"),
                    s =>
                    {
                        AvrAccessExportResult result = AccessExporter.ExportAnyCPU(queryId, ModelUserContext.CurrentLanguage, s);
                        if (!result.IsOk)
                        {
                            throw new AvrException(result.ErrorMessage + result.ExceptionString);
                        }
                    });
            }
            else
            {
                LayoutBaseValidatorWaiter validatorWaiter = new LayoutDesktopValidatorWaiter(m_FormView);

                var result = ExecQueryInternal(queryId, ModelUserContext.CurrentLanguage,
                    SharedPresenter.SharedModel.UseArchiveData, string.Empty, validatorWaiter, true);

                switch (exportType)
                {
                    case ExportType.Xls:
                        ExportTo("xls", EidssMessages.Get("msgFilterExcel", "Excel documents|*.xls"),
                            s => NpoiExcelWrapper.QueryLineListToExcel(s, result.QueryTable, exportType));
                        break;
                    case ExportType.Xlsx:
                        ExportTo("xlsx", EidssMessages.Get("msgFilterExcelXLSX", "Excel documents|*.xlsx"),
                            s => NpoiExcelWrapper.QueryLineListToExcel(s, result.QueryTable, exportType));
                        break;

                    default:
                        throw new AvrException(String.Format("Not supported export format {0}", exportType));
                }
            }
        }

        #region Check Avr Service

        #endregion

        #region Executing query

        public void RefreshQuery(long queryId)
        {
            InvalidateQuery(queryId);
            ExecQueryForPresenter(m_SharedPresenter, m_FormView, queryId, "0==1");
        }

        public void ExecQuery(long queryId, long layoutId)
        {
            var expression = Layout_DB.GetFilterExpression(layoutId);
            ExecQueryForPresenter(m_SharedPresenter, m_FormView, queryId, expression);
        }
      
        
        public static void ExecQueryForPresenter
            (SharedPresenter sharedPresenter, IAvrInvokable invokable, long queryId, string filter)
        {
            // we should clear QueryResult before executing new QUery
            sharedPresenter.SetQueryResult(null);

            //todo: [ivan] check validator
            LayoutBaseValidatorWaiter validatorWaiter = new LayoutDesktopValidatorWaiter(invokable);
            var result = ExecQueryInternal(queryId, ModelUserContext.CurrentLanguage,
                sharedPresenter.SharedModel.UseArchiveData, filter, validatorWaiter);

            sharedPresenter.SetQueryResult(result);
            sharedPresenter.SharedModel.IgnoreValidationWarnings = validatorWaiter.Validator.IgnoreValidationWarnings;
            sharedPresenter.SharedModel.QueryRefreshDateTime = UpdateQueryRefreshDateTime(queryId);
        }

        public static CachedQueryResult ExecQueryInternal
            (long queryId, string lang, bool isArchive,
                string filter,
                LayoutBaseValidatorWaiter validatorWaiter,
                bool forExport = false,
                Func<long, string, bool, string, CachedQueryResult> queryExecutor = null)
        {
            try
            {
                isArchive &= ArchiveDataHelper.ShowUseArchiveDataCheckbox;
                CachedQueryResult result;
                if (queryId > 0)
                {
                    if (queryExecutor == null)
                    {
                        result = GetAvrServiceQueryResult(queryId, isArchive, filter, validatorWaiter);
                    }
                    else
                    {
                        result = queryExecutor(queryId, lang, isArchive, filter);
                    }

                    result.QueryTable.TableName = QueryProcessor.GetQueryName(queryId);

                    QueryProcessor.SetCopyPropertyForColumnsIfNeeded(result.QueryTable);
                    QueryProcessor.TranslateTableFields(result.QueryTable, queryId);
                    QueryProcessor.SetNullForForbiddenTableFields(result.QueryTable, queryId);
                }
                else
                {
                    result = new CachedQueryResult(queryId, new AvrDataTable());
                }
                QueryProcessor.RemoveNotExistingColumns(result.QueryTable, queryId, forExport);
                return result;
            }
            catch (OutOfMemoryException ex)
            {
                Trace.WriteLine(ex);
                ErrorForm.ShowMessage("msgQueryResultIsTooBig", null);
                return new CachedQueryResult(queryId, new AvrDataTable());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new AvrDbException(String.Format("Error while executing query with id '{0}'", queryId), ex);
            }
        }

        internal static CachedQueryResult GetAvrServiceQueryResult
            (long queryId, bool isArchive, string filter, LayoutBaseValidatorWaiter validatorWaiter)
        {
            try
            {
                CallAvrServiceToForceLOHMemoryAllocations();

                using (var wrapper = new AvrServiceClientWrapper())
                {
                    if (!WinCheckAvrServiceAccessability(wrapper))
                    {
                        return new CachedQueryResult(queryId, new AvrDataTable());
                    }

                    using (CreateAvrServiceReceiveQueryDialog())
                    {
                        var receiver = new AvrCacheReceiver(wrapper);

                        CachedQueryResult result = receiver.GetCachedQueryTable(queryId, ModelUserContext.CurrentLanguage, isArchive,
                            filter, validatorWaiter);
                        return result;
                    }
                }
            }
            catch (TimeoutException ex)
            {
                Trace.WriteLine(ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(EidssMessages.Get("msgQueryResultTimeout"));
                return new CachedQueryResult(queryId, new AvrDataTable());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(EidssMessages.Get("msgAvrServiceError"), ex);
                return new CachedQueryResult(queryId, new AvrDataTable());
            }
        }

        public bool DoesCachedQueryExists(long queryId)
        {
            try
            {
                CallAvrServiceToForceLOHMemoryAllocations();

                using (var wrapper = new AvrServiceClientWrapper())
                {
                    return WinCheckAvrServiceAccessability(wrapper) &&
                           wrapper.DoesCachedQueryExists(queryId,
                               ModelUserContext.CurrentLanguage,
                               m_SharedPresenter.SharedModel.UseArchiveData);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(EidssMessages.Get("msgAvrServiceError"), ex);
                return false;
            }
        }

        private static void CallAvrServiceToForceLOHMemoryAllocations()
        {
// note [ivan] these service calls needed to place some service singletone objects in Large  Object Heap before query cache will be received
            // without these calls Large  Object Heap will be fragmented
            using (var wrapper = new AvrServiceClientWrapper())
            {
                AvrServiceAccessability access = AvrServiceAccessability.Check(wrapper);
                if (access.IsOk)
                {
                    wrapper.GetCachedQueryTableHeader(-1, ModelUserContext.CurrentLanguage, false);
                    wrapper.GetCachedQueryTablePacket(-1, 0, 0);
                    wrapper.GetQueryRefreshDateTime(-1, ModelUserContext.CurrentLanguage);
                }
            }
        }

        internal static DateTime UpdateQueryRefreshDateTime(long queryId)
        {
            try
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    return wrapper.GetQueryRefreshDateTime(queryId, ModelUserContext.CurrentLanguage);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return DateTime.Now;
            }
        }

        public static void InvalidateQuery(long queryId)
        {
            if (queryId > 0)
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    if (WinCheckAvrServiceAccessability(wrapper))
                    {
                        wrapper.InvalidateQueryCache(queryId);
                    }
                }
            }
        }

        public static void InvalidateView(long layoutId)
        {
            if (layoutId > 0)
            {
                using (var wrapper = new AvrServiceClientWrapper())
                {
                    if (WinCheckAvrServiceAccessability(wrapper))
                    {
                        wrapper.InvalidateViewCache(layoutId);
                    }
                }
            }
        }

        #endregion
    }
}