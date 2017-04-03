using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;
using eidss.avr.BaseComponents;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.MainForm;
using eidss.avr.PivotComponents;
using EIDSS.AVR.Service.WcfFacade;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.View;

namespace eidss.avr.service.VirtualLayout
{
    public class VirtualPivot : IDisposable
    {
        private VirtualPivotPlaceHolder m_PivotPlaceHolder;
        private AvrPivotGrid m_AvrPivot;
        private readonly WinLayout_DB m_DBService;
        private readonly SharedPresenter m_SharedPresenter;

        public VirtualPivot()
        {
            m_PivotPlaceHolder = new VirtualPivotPlaceHolder();

            // Note: [Ivan] init model factory for each copy of Virtual pivot or chart.
            // when next copy of pivot created, 
            //previous copy already inited so they does not need ModelFactory
            lock (EmptyPostableForm.SyncRoot)
            {
                PresenterFactory.Init(m_PivotPlaceHolder);
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
                    lock (EmptyPostableForm.SyncRoot)
                    {
                        PresenterFactory.RemovePresenterLink(m_SharedPresenter);
                    }
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

        private DataTable QueryExecutor(long queryId, string lang, bool isArchive)
        {
            var receiver = new AvrCacheReceiver(new AVRFacade());

            CachedQueryResult result = receiver.GetCachedQueryTable(queryId, lang, isArchive);
            return result.QueryTable;
        }

        public AvrPivotViewModel CreateAvrPivotViewModel(long layoutId, string lang)
        {
            // using (new StopwathTransaction("++ VirtualPivot  - CreateAvrPivotViewModel "))
            {
                LayoutDetailDataSet layoutDataSet = GetLayoutDataSet(layoutId);
                LayoutDetailDataSet.LayoutRow layoutRow = GetLayoutRow(layoutDataSet);

                m_SharedPresenter.SharedModel.SelectedQueryId = layoutRow.idflQuery;
                m_SharedPresenter.SharedModel.SelectedLayoutId = layoutId;

                DataTable queryResult =
                    AvrMainFormPresenter.ExecQueryInternal(layoutRow.idflQuery, lang, layoutRow.blnUseArchivedData, QueryExecutor);

                DataTable preparedQueryResult = AvrPivotGridHelper.GetPreparedDataSource(layoutDataSet.LayoutSearchField,
                    layoutRow.idflQuery, layoutId, queryResult, false);

                m_AvrPivot.SetDataSourceAndCreateFields(preparedQueryResult);

                using (m_AvrPivot.BeginTransaction())
                {
                    RestorePivotSettings(layoutDataSet);
                }

                using (m_AvrPivot.BeginTransaction())
                {
                    if (layoutRow.blnShowMissedValuesInPivotGrid)
                    {
                        AvrPivotGridHelper.AddMissedValuesInRowColumnArea(m_AvrPivot.DataSource, m_AvrPivot.AvrFields.ToList());
                    }

                    m_AvrPivot.RefreshData();
                }
                PivotGridDataLoadedCommand command = m_AvrPivot.CreatePivotDataLoadedCommand(layoutRow.strLayoutName);
                return command.Model;
            }
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

                if (!layoutRow.IsstrPivotGridSettingsNull() && layoutRow.blnApplyPivotGridFilter)
                {
                    m_AvrPivot.Criteria = CriteriaOperator.Parse(layoutRow.strPivotGridSettings);
                }
                AvrPivotGridHelper.LoadExstraSearchFieldsProperties(avrFields, layoutDataSet.LayoutSearchField);

                AvrPivotGridHelper.SwapOriginalAndCopiedFieldsIfReversed(avrFields);

                m_AvrPivot.PivotGridPresenter.UpdatePivotCaptions();

                RestoreTotals(layoutRow);
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