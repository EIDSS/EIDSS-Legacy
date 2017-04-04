using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.Tools;
using eidss.model.Avr;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Models;
using eidss.model.Avr.Tree;
using eidss.model.Resources;

namespace eidss.avr.PivotForm
{
    public sealed class PivotInfoPresenter : RelatedObjectPresenter
    {
        private readonly IPivotInfoDetailView m_PivotView;

        private readonly BaseAvrDbService m_PivotFormService;
        private readonly LayoutMediator m_LayoutMediator;

        public PivotInfoPresenter(SharedPresenter sharedPresenter, IPivotInfoDetailView view)
            : base(sharedPresenter, view)
        {
            m_PivotFormService = new BaseAvrDbService();

            m_PivotView = view;
            m_PivotView.DBService = PivotFormService;
            m_LayoutMediator = new LayoutMediator(this);

            m_SharedPresenter.SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        public override void Dispose()
        {
            try
            {
                m_SharedPresenter.SharedModel.PropertyChanged -= SharedModel_PropertyChanged;
            }
            finally
            {
                base.Dispose();
            }
        }

        public BaseAvrDbService PivotFormService
        {
            get { return m_PivotFormService; }
        }

        public string CorrectedLayoutName
        {
            get
            {
                return (Utils.IsEmpty(LayoutName))
                    ? EidssMessages.Get("msgNoReportHeader", "[Untitled]")
                    : LayoutName;
            }
        }

        public string LayoutName
        {
            get
            {
                return (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                    ? m_LayoutMediator.LayoutRow.strDefaultLayoutName
                    : m_LayoutMediator.LayoutRow.strLayoutName;
            }
        }

        public long LayoutId
        {
            get { return m_LayoutMediator.LayoutRow.idflLayout; }
        }

        public long QueryId
        {
            get { return m_SharedPresenter.SharedModel.SelectedQueryId; }
        }

        public bool ApplyFilter
        {
            get { return m_LayoutMediator.LayoutRow.blnApplyPivotGridFilter; }
        }

        public LayoutDetailDataSet.LayoutSearchFieldDataTable LayoutSearchFieldTable
        {
            get { return m_LayoutMediator.LayoutDataSet.LayoutSearchField; }
        }

        public bool ReadOnly
        {
            get { return m_LayoutMediator.LayoutRow.blnReadOnly; }
        }

        public bool CopyPivotName { get; set; }

        public bool CopyMapName { get; set; }

        public bool CopyChartName { get; set; }

        #region Binding

        public void BindShareLayout(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.blnShareLayoutColumn.ColumnName);
        }

        public void BindUseArchive(CheckEdit checkEdit)
        {
            BindingHelper.BindCheckEdit(checkEdit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.blnUseArchivedDataColumn.ColumnName);
        }

        public void BindDefaultLayoutName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.strDefaultLayoutNameColumn.ColumnName);

            edit.Text = m_LayoutMediator.LayoutRow.strDefaultLayoutName;
        }

        public void BindNationalLayoutName(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.strLayoutNameColumn.ColumnName);

            edit.Text = m_LayoutMediator.LayoutRow.strLayoutName;
        }

        public void BindLayoutDescription(TextEdit edit)
        {
            BindingHelper.BindEditor(edit,
                m_LayoutMediator.LayoutDataSet,
                m_LayoutMediator.LayoutTable.TableName,
                m_LayoutMediator.LayoutTable.strDescriptionColumn.ColumnName);
        }

        public void BindDefaultQueryName(TextEdit edit)
        {
            AvrTreeElement query = GetSelectedQuery();
            edit.Text = query.DefaultName;
        }

        public void BindNationalQueryName(TextEdit edit)
        {
            AvrTreeElement query = GetSelectedQuery();
            edit.Text = query.NationalName;
        }

        public void BindQueryDescription(TextEdit edit)
        {
            AvrTreeElement query = GetSelectedQuery();
            edit.Text = query.Description;
        }

        private AvrTreeElement GetSelectedQuery()
        {
            long queryId = m_SharedPresenter.SharedModel.SelectedQueryId;
            if (queryId > 0)
            {
                List<AvrTreeElement> queries = AvrQueryLayoutTreeDbHelper.LoadQueries();
                AvrTreeElement query = queries.Single(q => q.ID == queryId);
                return query;
            }
            return new AvrTreeElement(-1, null, null, AvrTreeElementType.Query, -1, string.Empty, string.Empty, string.Empty, false);
        }

        #endregion

        /// <summary>
        ///     It's workaround method. don't use it
        /// </summary>
        /// <param name="layoutName"> </param>
        public void SetLayoutName(string layoutName)
        {
            m_LayoutMediator.LayoutRow.strLayoutName = layoutName;
        }

        /// <summary>
        ///     It's workaround method. don't use it
        /// </summary>
        /// <param name="layoutName"> </param>
        public void SetDefaultLayoutName(string layoutName)
        {
            m_LayoutMediator.LayoutRow.strDefaultLayoutName = layoutName;
        }

        /// <summary>
        ///     Returns layout name with prefix "Copy of" on corresponding language
        /// </summary>
        /// <param name="layoutName"></param>
        /// <param name="lngName"></param>
        /// <returns></returns>
        public string GetLayoutNameWithPrefix(string layoutName, string lngName)
        {
            return AvrQueryLayoutTreeDbHelper.GetLayoutNameWithPrefix(layoutName,
                m_SharedPresenter.SharedModel.SelectedQueryId, m_LayoutMediator.LayoutRow.idflLayout, lngName, IsNewObject);
        }

        private void SharedModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = (SharedProperty) (Enum.Parse(typeof (SharedProperty), e.PropertyName));
            switch (property)
            {
                case SharedProperty.QueryRefreshDateTime:
                    m_PivotView.UpdateQueryRefreshDateTime();
                    break;
            }
        }

        internal bool ValidateLayoutName()
        {
            var layout = new AvrTreeElement(m_LayoutMediator.LayoutRow.idflLayout, null, null,
                AvrTreeElementType.Layout,
                m_SharedPresenter.SharedModel.SelectedQueryId,
                m_LayoutMediator.LayoutRow.strDefaultLayoutName,
                m_LayoutMediator.LayoutRow.strLayoutName, string.Empty, false);

            string message = AvrQueryLayoutTreeDbHelper.ValidateElementName(layout, IsNewObject);
            if (string.IsNullOrEmpty(message))
            {
                return true;
            }
            MessageForm.Show(message);
            return false;
        }

        public override void Process(Command cmd)
        {
            if ((cmd is QueryLayoutCommand))
            {
                var layoutCommand = (cmd as QueryLayoutCommand);
                if (layoutCommand.Operation == QueryLayoutOperation.AddCopyPrefixForLayoutNames)
                {
                    m_PivotView.AddCopyPrefixForLayoutNames();
                    layoutCommand.State = CommandState.Processed;
                }
            }
        }

        #region Helper Methods

        public static bool AskQuestion(string text, string caption)
        {
            return MessageForm.Show(text, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static string AppendLanguageNameTo(string text)
        {
            if (!Utils.IsEmpty(text))
            {
                int bracketInd = text.IndexOf("(", StringComparison.Ordinal);
                if (bracketInd >= 0)
                {
                    text = text.Substring(0, bracketInd).Trim();
                }
                string languageName = Localizer.GetLanguageName(ModelUserContext.CurrentLanguage);
                text = String.Format("{0} ({1})", text, languageName);
            }
            return text;
        }

        #endregion
    }
}