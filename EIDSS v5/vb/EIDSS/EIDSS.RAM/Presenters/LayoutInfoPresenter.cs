using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using DevExpress.XtraEditors.Controls;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;

namespace EIDSS.RAM.Presenters
{
    public class LayoutInfoPresenter : RelatedObjectPresenter
    {
        private readonly ILayoutInfoView m_LayoutInfoView;

        private readonly LayoutInfo_DB m_LayoutInfoService;

        public LayoutInfoPresenter(SharedPresenter sharedPresenter, ILayoutInfoView view)
            : base(sharedPresenter, view)
        {
            m_LayoutInfoService = new LayoutInfo_DB(m_SharedPresenter.SharedModel);

            m_LayoutInfoView = view;
            m_LayoutInfoView.DBService = m_LayoutInfoService;

            m_LayoutInfoView.LayoutSelecting += LayoutInfoLayoutSelecting;
            m_LayoutInfoView.LayoutSelected += LayoutInfoLayoutSelected;

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public bool ShowAllItems
        {
            get { return m_SharedPresenter.SharedModel.ShowAllItems; }
        }

        public long NewId()
        {
            return BaseDbService.NewIntID();
        }

        public override void Process(Command cmd)
        {
        }

        public List<LayoutTreeElement> LoadLayoutsAndFolders(long queryId, long userId, bool readOnly)
        {
            List<LayoutTreeElement> treeElements = LayoutInfo_DB.LoadFolders(queryId, readOnly);
            treeElements.AddRange(LayoutInfo_DB.LoadLayouts(queryId, userId, readOnly));
            return treeElements;
        }

        internal void SaveLayoutAndFolders
            (IEnumerable<LayoutTreeElement> original, IEnumerable<LayoutTreeElement> final)
        {
            var originalCopy = new List<LayoutTreeElement>(original);
            var finalCopy = new List<LayoutTreeElement>(final);
            m_LayoutInfoService.SaveLayoutAndFolders(originalCopy, finalCopy);
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.SelectedQueryId:
                    long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
                    m_LayoutInfoView.OnQuerySelected(new QueryEventArgs(queryId));
                    break;
                case SharedProperty.PivotAccessible:
                    m_LayoutInfoView.SetPivotAccessible(m_SharedPresenter.SharedModel.PivotAccessible);
                    break;
            }
        }

        private void LayoutInfoLayoutSelecting(object sender, ChangingEventArgs e)
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info,
                                "RamReportControl.LayoutInfoLayoutSelecting(): Selecting layout with id {0} from list",
                                Utils.Str(e.NewValue));

                if (!m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.OnQuerySelected))
                {
                    e.Cancel = e.Cancel || !m_SharedPresenter.SharedModel.ParentForm.Post();
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

        private void LayoutInfoLayoutSelected(object sender, LayoutEventArgs e)
        {
            m_SharedPresenter.SharedModel.SelectedLayoutId = e.LayoutId;
        }
    }
}