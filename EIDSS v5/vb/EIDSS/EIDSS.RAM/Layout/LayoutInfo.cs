using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.win;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Resources;
using LayoutEventArgs = EIDSS.RAM_DB.Common.EventHandlers.LayoutEventArgs;
using Localizer = bv.common.Core.Localizer;

namespace EIDSS.RAM.Layout
{
    public partial class LayoutInfo : BaseLayoutForm, ILayoutInfoView
    {
        private readonly Graphics m_Graphics;
        private const int PopupDeltaWidht = 20;
        private const int NullLayoutId = -1;
        private readonly LayoutInfoPresenter m_LayoutInfoPresenter;

        private bool m_NeedPost = true;

        public event EventHandler<LayoutEventArgs> LayoutSelected;
        public event EventHandler<ChangingEventArgs> LayoutSelecting;
        public event EventHandler<PathChangedEventArgs> PathChanged;

        public LayoutInfo()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "LayoutInfo creating...");
                var label = new Label();
                m_Graphics = label.CreateGraphics();

                m_LayoutInfoPresenter = (LayoutInfoPresenter) BaseRamPresenter;
                InitializeComponent();
                TreeEditorButton.Enabled = false;
                layoutTreeListKeeper.LayoutInfoPresenter = m_LayoutInfoPresenter;
                layoutTreeListKeeper.ReadOnly = true;
                layoutTreeListKeeper.OnSelectChanged += LayoutTreeListKeeperOnSelectChanged;
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

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            pceLayout.QueryPopUp -= pceLayout_QueryPopUp;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region LayoutChangedEvent

        protected virtual void RaiseLayoutSelectedEvent(long layoutId)
        {
            if (!IsAvrLoading)
            {
                LayoutSelected.SafeRaise(this, new LayoutEventArgs(layoutId));
            }
        }

        protected virtual void RaiseLayoutSelectingEvent(ChangingEventArgs e)
        {
            if (!IsAvrLoading)
            {
                LayoutSelecting.SafeRaise(this, e);
            }
        }

        protected virtual void RaisePathChangedEvent(long queryId, string layoutPath, long folderId)
        {
            if (!IsAvrLoading)
            {
                PathChanged.SafeRaise(this, new PathChangedEventArgs(queryId, layoutPath, folderId));
            }
        }

        private bool IsAvrLoading
        {
            get
            {
                if (!(ParentObject is BaseForm))
                {
                    return true;
                }

                return ((BaseForm) ParentObject).Loading;
            }
        }

        private long SelectedQueryId
        {
            get { return m_LayoutInfoPresenter.SharedPresenter.SharedModel.SelectedQueryId; }
        }

        #endregion

        private EditorButton TreeEditorButton
        {
            get
            {
                foreach (EditorButton button in pceLayout.Properties.Buttons)
                {
                    if (button.Kind == ButtonPredefines.Ellipsis)
                    {
                        return button;
                    }
                }
                throw new RamException(@"Cannot find button for edit layout tree");
            }
        }

        private long SelectedLayoutId
        {
            get
            {
                var selectedElement = pceLayout.EditValue as LayoutPopupElement;
                return (selectedElement == null) ? NullLayoutId : selectedElement.ID;
            }
            set
            {
                LoadLayoutTreeDataSource(layoutTreeListKeeper, SelectedQueryId, value);

                long currentFolderId = (value == NullLayoutId)
                                           ? m_LayoutInfoPresenter.SharedPresenter.SharedModel.SelectedFolderId
                                           : layoutTreeListKeeper.SelectedFolderId;
                RaisePathChangedEvent(SelectedQueryId, layoutTreeListKeeper.SelectedPath, currentFolderId);
                if (value == NullLayoutId)
                {
                    pceLayout.EditValue = DBNull.Value;
                }
                else
                {
                    string layoutName = LookupCache.GetLookupValue(value, LookupTables.Layout, "strLayoutName");
                    pceLayout.EditValue = new LayoutPopupElement(value, layoutName);
                }
            }
        }

        public override bool ReadOnly
        {
            get { return false; }
            set { base.ReadOnly = false; }
        }

        public void OnQuerySelected(QueryEventArgs e)
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.OnQuerySelected))
            {
                try
                {
                    TraceOnQuerySelected(e);
                    TreeEditorButton.Enabled = (e.QueryId > 0) && RamPermissions.UpdatePermission;

                    RaisePathChangedEvent(e.QueryId, string.Empty, -1);

                    LoadLayoutTreeDataSource(layoutTreeListKeeper, e.QueryId, -1);

                    object layoutId;
                    if (SharedPresenter.TryGetStartUpParameter("LayoutId", out layoutId))
                    {
                        SelectedLayoutId = (long) layoutId;
                    }

                    grcLayout.Enabled = (e.QueryId > 0);

                    SelectNullLayoutIfNeeded();

                    if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.EditQuery))
                    {
                        RaiseLayoutSelectedEvent(SelectedLayoutId);
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
        }

        public void SetPivotAccessible(bool visible)
        {
            pceLayout.Properties.NullText = visible
                                                ? EidssMessages.Get("NoSavedLayoutMessage")
                                                : string.Empty;
        }

        internal void LayoutDetailLayoutInfoChanged(object sender, LayoutInfoChangedEventArgs e)
        {
            try
            {
                m_NeedPost = false;
                switch (e.LayoutState)
                {
                    case DataRowState.Added:
                    case DataRowState.Deleted:
                        SelectedLayoutId = NullLayoutId;
                        break;

                    case DataRowState.Modified:
                        SelectedLayoutId = e.LayoutId;
                        break;
                }
            }
            finally
            {
                m_NeedPost = true;
            }
        }

        internal void LayoutDetailCopyLayoutCreating(object sender, CopyLayoutEventArgs e)
        {
            using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.CopyLayoutCreating))
            {
                SelectedLayoutId = NullLayoutId;
            }
        }

        private void pceLayout_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button != TreeEditorButton)
            {
                return;
            }
            using (var form = new LayoutInfoForm(m_LayoutInfoPresenter))
            {
                LoadLayoutTreeDataSource(form.LayoutTreeListKeeper, SelectedQueryId, layoutTreeListKeeper.SelectedId);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    LoadLayoutTreeDataSource(layoutTreeListKeeper, SelectedQueryId, form.LayoutTreeListKeeper.SelectedId);
                    RaisePathChangedEvent(SelectedQueryId, layoutTreeListKeeper.SelectedPath,
                                          layoutTreeListKeeper.SelectedFolderId);
                    pceLayout.EditValue = layoutTreeListKeeper.SelectedElement;
                }
            }
        }

        private void pceLayout_QueryPopUp(object sender, CancelEventArgs e)
        {
            popupContainerControl1.Width = GetPopupWidth();

            LoadLayoutTreeDataSource(layoutTreeListKeeper, SelectedQueryId, layoutTreeListKeeper.SelectedId);
        }

        private int GetPopupWidth()
        {
            var maxSize = new SizeF(pceLayout.Width, 1);
            var font = new Font(layoutTreeListKeeper.Font.Name, layoutTreeListKeeper.Font.Size, FontStyle.Bold);

            Dictionary<long, LayoutTreeElement> elements = layoutTreeListKeeper.DataSource.ToDictionary(element => element.ID);

            foreach (LayoutTreeElement element in layoutTreeListKeeper.DataSource)
            {
                string elementText = (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                                         ? element.NationalName
                                         : element.NationalName + element.DefaultName;
                SizeF elementSize = m_Graphics.MeasureString(elementText, font);
                elementSize.Width += 2 * PopupDeltaWidht;
                long parentId = element.ParentID.HasValue ? element.ParentID.Value : -1;
                while (elements.ContainsKey(parentId))
                {
                    LayoutTreeElement parent = elements[parentId];
                    parentId = parent.ParentID.HasValue ? parent.ParentID.Value : -1;
                    elementSize.Width += PopupDeltaWidht;
                    if (elementSize.Width > Screen.PrimaryScreen.Bounds.Width)
                    {
                        break;
                    }
                }

                if (elementSize.Width > maxSize.Width)
                {
                    maxSize = elementSize;
                }
            }
            return (int) maxSize.Width;
        }

        private void LayoutTreeListKeeperOnSelectChanged(object sender, QueryResultValueEventArgs e)
        {
            if (popupContainerControl1.OwnerEdit != null)
            {
                popupContainerControl1.OwnerEdit.ClosePopup();
            }
        }

        private void pceLayout_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            if (layoutTreeListKeeper.Cancel)
            {
                return;
            }

            e.Value = layoutTreeListKeeper.SelectedElement;
            RaisePathChangedEvent(SelectedQueryId, layoutTreeListKeeper.SelectedPath,
                                  layoutTreeListKeeper.SelectedFolderId);
            if (!layoutTreeListKeeper.ReadOnly)
            {
                m_LayoutInfoPresenter.SaveLayoutAndFolders(layoutTreeListKeeper.DataSourceOriginal,
                                                           layoutTreeListKeeper.DataSource);
            }
        }

        private void pceLayout_EditValueChanging(object sender, ChangingEventArgs e)
        {
            TraceLayoutChanging();

            if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.CopyLayoutCreating))
            {
                return;
            }

            if (Utils.IsEmpty(e.NewValue) && (Utils.IsEmpty(e.OldValue)))
            {
                return;
            }

            if (m_NeedPost)
            {
                RaiseLayoutSelectingEvent(e);
            }
        }

        private void pceLayout_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TraceLayoutChanged();

                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.CopyLayoutCreating))
                {
                    return;
                }

                memDescription.Properties.ReadOnly = false;
                memDescription.EditValue =
                    LookupCache.GetLookupValue(SelectedLayoutId, LookupTables.Layout, "strDescription");
                memDescription.Properties.ReadOnly = true;

                RaiseLayoutSelectedEvent(SelectedLayoutId);
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

        private void SelectNullLayoutIfNeeded()
        {
            LayoutTreeElement element = layoutTreeListKeeper.DataSource.Find(tmp => tmp.ID == SelectedLayoutId);

            if (element == null)
            {
                if (SelectedLayoutId == NullLayoutId)
                {
                    pceLayout_EditValueChanged(this, EventArgs.Empty);
                }
                else
                {
                    SelectedLayoutId = NullLayoutId;
                }
            }
        }

        private void LoadLayoutTreeDataSource(LayoutTreeListKeeper keeper, long queryId, long elementId)
        {
            EidssUserContext.CheckUserLoggedIn();
            keeper.DataSource = m_LayoutInfoPresenter.LoadLayoutsAndFolders(queryId, (long) EidssUserContext.User.ID,
                                                                            !m_LayoutInfoPresenter.ShowAllItems);
            keeper.Cancel = true;
            keeper.SelectedId = elementId;
        }

        #region Trace Methods

        private static void TraceOnQuerySelected(QueryEventArgs e)
        {
            string queryName = LookupCache.GetLookupValue(e.QueryId, LookupTables.Query, "QueryName");
            Trace.WriteLine(Trace.Kind.Undefine,
                            "LayoutInfo.OnQuerySelected(): Selecting query item {0} with id {1} from list",
                            queryName, Utils.Str(e.QueryId));
        }

        private void TraceLayoutChanging()
        {
            Trace.WriteLine(Trace.Kind.Undefine,
                            "Layout item {0} with id {1} selecting...",
                            layoutTreeListKeeper.SelectedLayoutName, layoutTreeListKeeper.SelectedId.ToString());
        }

        private void TraceLayoutChanged()
        {
            Trace.WriteLine(Trace.Kind.Undefine,
                            "Layout item {0} with id {1} selected",
                            layoutTreeListKeeper.SelectedLayoutName, layoutTreeListKeeper.SelectedId.ToString());
        }

        #endregion
    }
}