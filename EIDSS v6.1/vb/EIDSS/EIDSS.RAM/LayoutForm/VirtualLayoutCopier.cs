using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using eidss.avr.BaseComponents;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr;
using eidss.model.Avr.View;
using eidss.model.AVR.DataBase;
using eidss.model.Core;
using eidss.model.Core.CultureInfo;
using eidss.model.Trace;
using StructureMap;

namespace eidss.avr.LayoutForm
{
    public class VirtualLayoutCopier : IDisposable
    {
        private readonly ITraceStrategy m_TraceStrategy;
        public const string TraceTitle = "Virtual Layout Copier";
        private readonly WinLayout_DB m_LayoutDB;
        private readonly View_DB m_ViewDB;
        private readonly SharedPresenter m_SharedPresenter;

        internal VirtualLayoutCopier(IContainer container)
        {
            Utils.CheckNotNull(container, "container");
            m_TraceStrategy = container.GetInstance<ITraceStrategy>();

            // Note: [Ivan] init model factory for each copy of Virtual chart or pivot.
            // when next copy of pivot created, previous copy already inited so they does not need ModelFactory

            using (PresenterFactory.BeginSharedPresenterTransaction(container, new EmptyPostableForm()))
            {
                m_SharedPresenter = PresenterFactory.SharedPresenter;
                m_LayoutDB = new WinLayout_DB(m_SharedPresenter.SharedModel);
                m_ViewDB = new View_DB();
            }
        }

        public void Dispose()
        {
            if (m_SharedPresenter != null)
            {
                m_SharedPresenter.Dispose();
            }
        }

        public static long CreateLayoutCopyInAvrService(long layoutId, string lang, IContainer container)
        {
            if (!CustomCultureHelper.SupportedLanguages.ContainsKey(lang))
            {
                throw new ArgumentOutOfRangeException("lang", string.Format("Language '{0}' is not supported", lang));
            }
            using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
            {
                return CreateLayoutCopy(layoutId, container);
            }
        }

        public static long CreateLayoutCopy(long layoutId, IContainer container)
        {
            using (var copier = new VirtualLayoutCopier(container))
            {
                return copier.CreateLayoutCopyInternal(layoutId);
            }
        }

        private long CreateLayoutCopyInternal(long layoutId)
        {
            m_TraceStrategy.Trace(TraceTitle, string.Format("Starting copying layout '{0}'", layoutId));
            LayoutDetailDataSet layoutDataSet;
            lock (ConnectionManager.DefaultInstance.Connection)
            {
                layoutDataSet = GetLayoutDataSet(layoutId);
            }
            LayoutDetailDataSet.LayoutRow layoutRow = GetLayoutRow(layoutDataSet);
            if (!layoutRow.IsidfPersonNull())
            {
                EidssUserContext.User.EmployeeID = layoutRow.idfPerson;
            }
            m_SharedPresenter.SharedModel.SelectedQueryId = layoutRow.idflQuery;
            m_SharedPresenter.SharedModel.SelectedFolderId = layoutRow.IsidflLayoutFolderNull()
                ? -1
                : layoutRow.idflLayoutFolder;
            long queryId = layoutRow.idflQuery;
            m_LayoutDB.SetQueryID(queryId);
            Dictionary<long, long> changedIds = m_LayoutDB.CreateCopyLayout(layoutDataSet);
            layoutRow.strPivotGridSettings = AvrBinarySettings.ReplaceIds(layoutRow.strPivotGridSettings, changedIds);

            long layoutIdCopy = layoutRow.idflLayout;
            m_SharedPresenter.SharedModel.SelectedLayoutId = layoutIdCopy;

            layoutRow.strDefaultLayoutName = AvrQueryLayoutTreeDbHelper.GetLayoutNameWithPrefix(layoutRow.strDefaultLayoutName, queryId,
                layoutIdCopy, Localizer.lngEn, true);

            layoutRow.strLayoutName = (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                ? layoutRow.strDefaultLayoutName
                : AvrQueryLayoutTreeDbHelper.GetLayoutNameWithPrefix(layoutRow.strLayoutName, queryId,
                    layoutIdCopy, ModelUserContext.CurrentLanguage, true);

            lock (ConnectionManager.DefaultInstance.Connection)
            {
                IDbTransaction tran = ConnectionManager.DefaultInstance.Connection.BeginTransaction();

                bool result = m_LayoutDB.PostDetail(layoutDataSet, (int) PostType.FinalPosting, tran);
                if (!result)
                {
                    tran.Rollback();
                    ThrowPostException(layoutId, m_LayoutDB.LastError);
                }

                List<string> languages = m_LayoutDB.GetViewLanguages(layoutId, tran);
                // current language should be at the end of the dictionary, because view on current language should be saved last
                languages.Remove(ModelUserContext.CurrentLanguage);
                languages.Add(ModelUserContext.CurrentLanguage);

                foreach (string lang in languages)
                {
                    if (!CustomCultureHelper.SupportedLanguages.ContainsKey(lang))
                    {
                        string message = string.Format("Language '{0}' of View with layout ID '{1}' is not supported", lang, layoutId);
                        throw new AvrDbException(message);
                    }
                    using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
                    {
                        m_ViewDB.GetDetail(layoutId, tran);
                        AvrView viewData = m_ViewDB.avrView;

                        if (!m_ViewDB.IsNewObject)
                        {
                            viewData.ViewID = layoutIdCopy;
                            ChangeViewParametersIds(viewData, changedIds);
                            ChangeViewStructureIds(viewData, changedIds);

                            result = m_ViewDB.PostDetail(tran);
                            if (!result)
                            {
                                tran.Rollback();
                                ThrowPostException(layoutId, m_ViewDB.LastError);
                            }
                        }
                    }
                }

                tran.Commit();
            }

            m_TraceStrategy.Trace(TraceTitle, "Copy of Layout '{0}' successfully created. New layout id '{1}', name '{2}'",
                layoutId, layoutIdCopy, layoutRow.strDefaultLayoutName);
            return layoutIdCopy;
        }

        private LayoutDetailDataSet GetLayoutDataSet(long layoutId)
        {
            LayoutDetailDataSet layoutDataSet;
            lock (ConnectionManager.DefaultInstance.Connection)
            {
                layoutDataSet = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
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
                throw new ArgumentException("Couldn't get table Layout from dataset ");
            }
            return layoutDataSet.Layout[0];
        }

        private void ChangeViewParametersIds(AvrView view, Dictionary<long, long> changedIds)
        {
            view.GlobalView = null;
            view.ChartXAxisViewColumn = AvrBinarySettings.ReplaceIds(view.ChartXAxisViewColumn, changedIds);
            view.FullPath = AvrBinarySettings.ReplaceIds(view.FullPath, changedIds);
            view.MapAdminUnitViewColumn = AvrBinarySettings.ReplaceIds(view.MapAdminUnitViewColumn, changedIds);
            view.SelectedColBand = AvrBinarySettings.ReplaceIds(view.SelectedColBand, changedIds);

            view.ChartLocalSettingsXml = AvrBinarySettings.ReplaceIds(view.ChartLocalSettingsXml, changedIds);
            view.GisLayerLocalSettingsXml = AvrBinarySettings.ReplaceIds(view.GisLayerLocalSettingsXml, changedIds);
            view.GisMapLocalSettingsXml = AvrBinarySettings.ReplaceIds(view.GisMapLocalSettingsXml, changedIds);
            view.ViewSettingsXml = AvrBinarySettings.ReplaceIds(view.ViewSettingsXml, changedIds);
            view.SetChanges();
        }

        private void ChangeViewStructureIds(BaseBand parentBand, Dictionary<long, long> changedIds)
        {
            foreach (AvrViewBand band in parentBand.Bands)
            {
                ChangeViewStructureIds(band, changedIds);
            }
            foreach (AvrViewColumn column in parentBand.Columns)
            {
                column.SourceViewColumn = AvrBinarySettings.ReplaceIds(column.SourceViewColumn, changedIds);
                column.DenominatorViewColumn = AvrBinarySettings.ReplaceIds(column.DenominatorViewColumn, changedIds);
            }

            var items = new List<IAvrViewItem>();
            items.AddRange(parentBand.Bands);
            items.AddRange(parentBand.Columns);
            foreach (IAvrViewItem item in items)
            {
                item.ID = -1;
                item.UniquePath = AvrBinarySettings.ReplaceIds(item.UniquePath, changedIds);
                if (changedIds.ContainsKey(item.LayoutSearchFieldId))
                {
                    item.LayoutSearchFieldId = changedIds[item.LayoutSearchFieldId];
                }
                item.SetChanges();
            }
        }

        private void ThrowPostException(long layoutId, ErrorMessage innerError)
        {
            string errorMessage = string.Format("Could not create copy of Layout '{0}' because of error: {1}", layoutId, innerError.Text);
            m_TraceStrategy.TraceError(TraceTitle, errorMessage);
            m_TraceStrategy.TraceError(innerError.Exception);
            throw new AvrDbException(errorMessage, innerError.Exception);
        }
    }
}