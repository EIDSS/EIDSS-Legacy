using System;
using System.Data;
using System.Windows.Forms;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.Core;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using bv.winclient.BasePanel;

namespace EIDSS.RAM.QueryBuilder
{
    public partial class QueryInfo : BaseRamDetailPanel, IQueryInfoView
    {
        public event EventHandler<QueryEventArgs> QuerySelected;
        private  SharedPresenter m_SharedPresenter;
        private QueryInfoPresenter m_QueryPresenter;
        public QueryInfo_DB m_QueryInfoDbService;

        #region Events

        public event EventHandler<CommandEventArgs> SendCommand;
        public event EventHandler<ChangingEventArgs> QuerySelecting;

        public virtual void RaiseQuerySelectedEvent(long queryId)
        {
            if (!IsRAMLoading)
            {
                QuerySelected.SafeRaise(this, new QueryEventArgs(queryId));
            }
        }

        public virtual void RaiseQuerySelectingEvent(ChangingEventArgs e)
        {
            if (!IsRAMLoading)
            {
                QuerySelecting.SafeRaise(this, e);
            }
        }

        protected override void DefineBinding()
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext("DefineBinding"))
            {
                RemoveEditValueChangedHandler(cbQuery, cbQuery_EditValueChanged);
                RemoveEditValueChangingHandler(cbQuery, cbQuery_EditValueChanging);

                LookupBinder.BindQueryLookup(cbQuery, m_QueryPresenter.ShowAllItems);

                object queryId;
                if (m_SharedPresenter.TryGetStartUpParameter("QueryId", out queryId))
                {
                    cbQuery.EditValue = queryId;
                    cbQuery_EditValueChanged(null, null);
                }
                else
                {
                    SetDefaultQuery();
                }

                AddEditValueChangingHandler(cbQuery, cbQuery_EditValueChanging);
                AddEditValueChangedHandler(cbQuery, cbQuery_EditValueChanged);
            }
        }

        #endregion

        public QueryInfo()
        {
            if (IsDesignMode())
            {
                PresenterFactory.Init(this);
            }
            m_SharedPresenter = PresenterFactory.SharedPresenter;
            m_QueryPresenter = (QueryInfoPresenter) m_SharedPresenter[this];

            InitializeComponent();
            // Note: [Ivan] no need to initialize DbService here because it already have been initialized in Presenter
//            QueryInfoDbService = new QueryInfo_DB();
//            DbService = QueryInfoDbService;
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
//            if (Utils.IsCalledFromUnitTest())
//                return;
            eventManager.ClearAllReferences();
            m_SharedPresenter.UnregisterView(this);
            m_QueryPresenter = null;
            m_SharedPresenter = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IsRAMLoading
        {
            get
            {
                if ((ParentObject is BaseForm) == false)
                {
                    return true;
                }

                return ((BaseForm) ParentObject).Loading;
            }
        }

        public override bool ReadOnly
        {
            get
            {
                return false;
            }
            set
            {
                base.ReadOnly = false;
            }
        }

        private static void RemoveEditValueChangingHandler(LookUpEdit cb, ChangingEventHandler handler)
        {
            cb.EditValueChanging -= handler;
        }

        public long SelectedQueryID
        {
            get
            {
                if (!Utils.IsEmpty(cbQuery.EditValue))
                {
                    long result;
                    if (long.TryParse(cbQuery.EditValue.ToString(), out result))
                    {
                        return result;
                    }
                }
                return -1L;
            }
        }

        public QueryInfo_DB QueryInfoDbService
        {
            get { return (QueryInfo_DB) DbService; }
        }

        #region Handlers

        private static void AddEditValueChangedHandler(LookUpEdit cb, EventHandler handler)
        {
            try
            {
                cb.EditValueChanged -= handler;
            }
            finally
            {
                cb.EditValueChanged += handler;
            }
        }

        private static void RemoveEditValueChangedHandler(LookUpEdit cb, EventHandler handler)
        {
            cb.EditValueChanged -= handler;
        }

        private static void AddEditValueChangingHandler(LookUpEdit cb, ChangingEventHandler handler)
        {
            try
            {
                cb.EditValueChanging -= handler;
            }
            finally
            {
                cb.EditValueChanging += handler;
            }
        }

        private void cbQuery_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (cbQuery.Properties.DataSource == null)
            {
                return;
            }
            if (Utils.IsEmpty(e.NewValue) && (Utils.IsEmpty(e.OldValue)))
            {
                return;
            }
            RaiseQuerySelectingEvent(e);
        }

        internal bool PredefinedChanged(out long queryId)
        {
            object val = cbQuery.EditValue;
            bool changed;

            string rowFilter = !m_QueryPresenter.ShowAllItems
                                   ? " (blnReadOnly = 1) "
                                   : string.Empty;
            if (Utils.IsEmpty(val) || (!(val is long) || (cbQuery.Properties.DataSource == null)))
            {
                changed = true;
                queryId = -1;
                if (cbQuery.Properties.DataSource != null)
                {
                    ((DataView) cbQuery.Properties.DataSource).RowFilter = rowFilter;
                }
            }
            else
            {
                queryId = (long) val;
                var dv = (DataView) cbQuery.Properties.DataSource;
                dv.RowFilter = rowFilter;
                dv.Sort = "idflQuery";
                changed = ((dv.Count == 0) || (!Utils.IsEmpty(val) && (dv.Find(val) == -1)));
                dv.Sort = "QueryName";
            }
            return changed;
        }

        #endregion

        public DataSet BaseDataSet
        {
            get { return baseDataSet; }
        }

        public void RaiseSendCommand(Command command)
        {
            if (IsDesignMode())
                return;
            SendCommand.SafeRaise(this, new CommandEventArgs(command));
        }

        private bool IsQuerySelected()
        {
            bool res = true;
            var dv = (DataView) cbQuery.Properties.DataSource;
            dv.Sort = "idflQuery";
            object val = cbQuery.EditValue;
            if ((dv.Count > 0) && (Utils.IsEmpty(val) || (dv.Find(val) < 0)))
            {
                res = false;
            }
            dv.Sort = "QueryName";
            return res;
        }

        internal void SetDefaultQuery()
        {
            cbQuery.EditValue = DBNull.Value;
            // Note: [Ivan] because of CR 2514
            //if (GlobalSettings.SelectDefaultQuery)
            //{
            //    if (cbQuery.Properties.DataSource == null)
            //    {
            //        return;
            //    }
            //    DataView dv = (DataView) cbQuery.Properties.DataSource;
            //    dv.Sort = "idflQuery";
            //    object val = cbQuery.EditValue;
            //    if ((dv.Count > 0) && (Utils.IsEmpty(val) || (dv.Find(val) < 0)))
            //    {
            //        cbQuery.EditValue = dv[0]["idflQuery"];
            //    }
            //    dv.Sort = "QueryName";
            //}
            cbQuery_EditValueChanged(null, null);
        }

        private void cbQuery_EditValueChanged(object sender, EventArgs e)
        {
            object val = cbQuery.EditValue;
            if (Utils.IsEmpty(val) || (!(val is long) || (cbQuery.Properties.DataSource == null)))
            {
                memDescription.Properties.ReadOnly = false;
                memDescription.EditValue = "";
                memDescription.Properties.ReadOnly = true;

                RaiseQuerySelectedEvent(-1);
            }
            else
            {
                var queryId = (long) val;
                DataRow r = ((DataView) cbQuery.Properties.DataSource).Table.Rows.Find(val);
                if (r != null)
                {
                    string description = r["strDescription"].ToString();

                    memDescription.Properties.ReadOnly = false;
                    memDescription.EditValue = description;
                    memDescription.Properties.ReadOnly = true;
                    RaiseQuerySelectedEvent(queryId);
                }
                else
                {
                    memDescription.Properties.ReadOnly = false;
                    memDescription.EditValue = "";
                    memDescription.Properties.ReadOnly = true;
                    RaiseQuerySelectedEvent(-1);
                }
            }
        }

        private Form GetParentWinForm()
        {
            BaseForm bf = this;
            while (bf.ParentObject is BaseForm)
            {
                bf = (BaseForm) bf.ParentObject;
            }
            return bf.FindForm();
        }

        public void CreateQuery()
        {
            object aID = null;
            using (var bf = new QueryDetail())
            {
                if (BaseFormManager.ShowModal(bf, GetParentWinForm(), ref aID, null, null))
                {
                    if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long) aID < 0))
                    {
                        SetDefaultQuery();
                        return;
                    }
                    cbQuery.EditValue = aID;
                }
            }
            if (IsQuerySelected() == false)
            {
                SetDefaultQuery();
            }
        }

        public void EditQuery()
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.EditQuery))
            {
                using (var bf = new QueryDetail())
                {
                    object aID = cbQuery.EditValue;
                    if (BaseFormManager.ShowModal(bf, GetParentWinForm(), ref aID, null, null))
                    {
                        if (Utils.IsEmpty(aID) || (!(aID is long)) || ((long) aID < 0))
                        {
                            SetDefaultQuery();
                            return;
                        }
                        if ((Utils.Str(cbQuery.EditValue) == Utils.Str(aID)) && bf.Modified)
                        {
                            cbQuery_EditValueChanged(cbQuery, new EventArgs());
                            return;
                        }
                        cbQuery.EditValue = aID;
                    }
                }
                if (IsQuerySelected() == false)
                {
                    SetDefaultQuery();
                }
            }
        }

        public void DeleteQuery()
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.DeleteQuery))
            {
                object aID = cbQuery.EditValue;
                if (Utils.IsEmpty(aID))
                {
                    return;
                }
                if (DeletePromptDialog() != DialogResult.Yes)
                {
                    return;
                }
                if (QueryInfoDbService.CanDelete(aID, QueryInfoDbService.ObjectName) == false)
                {
                    ErrorMessage err = QueryInfoDbService.LastError;
                    if (err != null)
                    {
                        ErrorForm.ShowError(err);
                    }
                    else
                    {
                        ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted");
                    }
                    return;
                }
                if (QueryInfoDbService.Delete(aID))
                {
                    LookupCache.NotifyDelete("Query", null, aID);
                    SetDefaultQuery();
                }
                else
                {
                    ErrorForm.ShowError(QueryInfoDbService.LastError);
                }
            }
        }

      
    }
}
