using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.winclient.Core;
using bv.winclient.Localization;
using DevExpress.XtraPivotGrid;
using eidss.avr.BaseComponents;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.Complexity;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.MainForm;
using eidss.avr.PivotComponents;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;
using eidss.model.AVR.SourceData;
using eidss.model.Core.CultureInfo;
using eidss.model.Trace;
using EIDSS.AVR.Service.WcfFacade;
using StructureMap;

namespace eidss.avr.service.VirtualLayout
{
    public class VirtualPivot : IDisposable
    {
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);
        public const string TraceTitle = "Virtual Pivot Grid";
        private VirtualPivotPlaceHolder m_PivotPlaceHolder;
        private AvrPivotGrid m_AvrPivot;
        private readonly WinLayout_DB m_DBService;
        private readonly SharedPresenter m_SharedPresenter;

        private readonly IContainer m_Container;

        public VirtualPivot(IContainer container)
        {
            DevXLocalizer.Init();
            m_Container = container;
            m_PivotPlaceHolder = new VirtualPivotPlaceHolder();

            using (PresenterFactory.BeginSharedPresenterTransaction(m_Container, m_PivotPlaceHolder))
            {
                m_SharedPresenter = PresenterFactory.SharedPresenter;
                m_DBService = new WinLayout_DB(m_SharedPresenter.SharedModel);
                m_AvrPivot = new AvrPivotGrid();
                m_PivotPlaceHolder.Controls.Add(m_AvrPivot);
            }
        }

        public void Dispose()
        {
            if (m_AvrPivot != null)
            {
                AvrPivotGridData oldDataSource = m_AvrPivot.DataSource;
                if (oldDataSource != null)
                {
                    m_AvrPivot.DataSource = null;
                    oldDataSource.Dispose();
                }
                if (m_SharedPresenter != null)
                {
                    m_SharedPresenter.UnregisterView(m_AvrPivot);
                    m_SharedPresenter.Dispose();
                }
                m_AvrPivot = null;
            }
            if (m_PivotPlaceHolder != null)
            {
                m_PivotPlaceHolder.Dispose();
                m_PivotPlaceHolder = null;
            }
        }

        private CachedQueryResult QueryExecutor(long queryId, string lang, bool isArchive, string filter)
        {
            var receiver = new AvrCacheReceiver(new AVRFacade(m_Container));
            var validatorWaiter = new LayoutSilentValidatorWaiter();
            CachedQueryResult result = receiver.GetCachedQueryTable(queryId, lang, isArchive, filter, validatorWaiter);
            // todo: [ivan] check validator if needed
            return result;
        }

        public static AvrPivotViewModel CreateAvrPivotViewModel(long layoutId, string lang, IContainer container)
        {
            using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
            {
                using (var virtualPivot = new VirtualPivot(container))
                {
                    AvrPivotViewModel model = virtualPivot.CreateAvrPivotViewModelInternal(layoutId, lang);
                    return model;
                }
            }
        }

        private AvrPivotViewModel CreateAvrPivotViewModelInternal(long layoutId, string lang)
        {
            LayoutDetailDataSet layoutDataSet = GetLayoutDataSet(layoutId);
            LayoutDetailDataSet.LayoutRow layoutRow = GetLayoutRow(layoutDataSet);

            m_SharedPresenter.SharedModel.SelectedQueryId = layoutRow.idflQuery;
            m_SharedPresenter.SharedModel.SelectedLayoutId = layoutId;

            m_Trace.Trace(TraceTitle, string.Format("Layout {0} structure read from DB", layoutId));

            var validatorWaiter = new LayoutSilentValidatorWaiter();

            var queryResult = AvrMainFormPresenter.ExecQueryInternal(layoutRow.idflQuery, lang,
                layoutRow.blnUseArchivedData, layoutRow.strPivotGridSettings, validatorWaiter, false, QueryExecutor);

            m_Trace.Trace(TraceTitle, string.Format("Data for layout {0} received from AVR Cashe ", layoutId));

            AvrDataTable preparedQueryTable = AvrPivotGridHelper.GetPreparedDataSource(layoutDataSet.LayoutSearchField,
                layoutRow.idflQuery, layoutId, queryResult.QueryTable, false);

            m_AvrPivot.SetDataSourceAndCreateFields(preparedQueryTable);

            RestorePivotSettings(layoutDataSet);

            using (m_AvrPivot.BeginTransaction())
            {
                List<IAvrPivotGridField> fields = m_AvrPivot.AvrFields.ToList();

                var result = new LayoutValidateResult();
                if (layoutRow.blnShowMissedValuesInPivotGrid)
                {
                    result = AvrPivotGridHelper.AddMissedValuesAndValidateComplexity(m_AvrPivot.DataSource, fields,
                        validatorWaiter.Validator);
                }
                if (!result.IsCancelOrUserDialogCancel())
                {
                    result = AvrPivotGridHelper.FillEmptyValuesAndValidateComplexity(m_AvrPivot.DataSource, fields,
                        validatorWaiter.Validator);
                }
                if (result.IsCancelOrUserDialogCancel())
                {
                    m_AvrPivot.HideData = true;
                }

                m_AvrPivot.RefreshData();
            }
            m_Trace.Trace(TraceTitle, string.Format("Layout {0} builded", layoutId));

            PivotGridDataLoadedCommand command = m_AvrPivot.CreatePivotDataLoadedCommand(layoutRow.strLayoutName);
            m_Trace.Trace(TraceTitle, string.Format("View model for layout {0}, language {1} created", layoutId, lang));
            return command.Model;
        }

        private LayoutDetailDataSet GetLayoutDataSet(long layoutId)
        {
            if (m_AvrPivot == null)
            {
                throw new AvrException("Pivot grid already disposed.");
            }

            LayoutDetailDataSet layoutDataSet;
            lock (ConnectionManager.DefaultInstance.Connection)
            {
                layoutDataSet = (LayoutDetailDataSet) m_DBService.GetDetail(layoutId);
            }

            LayoutDetailDataSet.LayoutRow layoutRow = GetLayoutRow(layoutDataSet);
            if (string.IsNullOrEmpty(layoutRow.strLayoutName))
            {
                throw new ArgumentException(string.Format("Couldn't find Layout '{0}'", layoutId));
            }

            return layoutDataSet;
        }

        private LayoutDetailDataSet.LayoutRow GetLayoutRow(LayoutDetailDataSet layoutDataSet)
        {
            if (layoutDataSet.Layout.Rows.Count == 0)
            {
                throw new ArgumentException("Couldn't get Layout from dataset ");
            }
            return (LayoutDetailDataSet.LayoutRow) layoutDataSet.Layout.Rows[0];
        }

        private void RestorePivotSettings(LayoutDetailDataSet layoutDataSet)
        {
            try
            {
                LayoutDetailDataSet.LayoutRow layoutRow = GetLayoutRow(layoutDataSet);
                List<IAvrPivotGridField> avrFields = m_AvrPivot.AvrFields.ToList();

                AvrPivotGridHelper.LoadSearchFieldsVersionSixFromDB(avrFields, layoutDataSet.LayoutSearchField,
                    layoutRow.idfsDefaultGroupDate);

                using (m_AvrPivot.BeginTransaction())
                {
                    AvrPivotGridHelper.LoadExstraSearchFieldsProperties(avrFields, layoutDataSet.LayoutSearchField);

                    AvrPivotGridHelper.SwapOriginalAndCopiedFieldsIfReversed(avrFields);

                    m_AvrPivot.PivotGridPresenter.UpdatePivotCaptions();

                    RestoreTotals(layoutRow);
                }
            }
            catch (XmlException ex)
            {
                Trace.WriteLine(ex);
                ErrorForm.ShowError("errCantParseLayout", "Cannot parse Layout retrived from Database", ex);
            }
        }

        private void RestoreTotals(LayoutDetailDataSet.LayoutRow layoutRow)
        {
            PivotGridOptionsView options = m_AvrPivot.OptionsView;
            if (layoutRow.blnCompactPivotGrid)
            {
                options.ShowRowTotals = true;
                options.ShowTotalsForSingleValues = true;
                options.RowTotalsLocation = PivotRowTotalsLocation.Tree;
            }
            else
            {
                options.RowTotalsLocation = PivotRowTotalsLocation.Far;

                options.ShowColumnTotals = (!layoutRow.IsblnShowColsTotalsNull()) && layoutRow.blnShowColsTotals;
                options.ShowRowTotals = (!layoutRow.IsblnShowRowsTotalsNull()) && layoutRow.blnShowRowsTotals;
                options.ShowColumnGrandTotals = (!layoutRow.IsblnShowColGrandTotalsNull()) && layoutRow.blnShowColGrandTotals;
                options.ShowRowGrandTotals = (!layoutRow.IsblnShowRowGrandTotalsNull()) && layoutRow.blnShowRowGrandTotals;
                options.ShowTotalsForSingleValues = (!layoutRow.IsblnShowForSingleTotalsNull()) && layoutRow.blnShowForSingleTotals;
                options.ShowGrandTotalsForSingleValues = (!layoutRow.IsblnShowForSingleTotalsNull()) && layoutRow.blnShowForSingleTotals;
            }
        }
    }
}