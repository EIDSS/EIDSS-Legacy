using System;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.win.BaseForms;
using bv.winclient.Core;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Tree;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;

namespace eidss.avr.BaseComponents
{
    /// <summary>
    ///     Base class for different layout panels
    /// </summary>
    public partial class BaseAvrDetailPresenterPanel : BaseAvrDetailPanel, IBaseAvrView
    {
        public event EventHandler<CommandEventArgs> SendCommand;

        private SharedPresenter m_SharedPresenter;
        private BaseAvrPresenter m_BaseAvrPresenter;

        public BaseAvrDetailPresenterPanel()
        {
            if (IsDesignMode() || BaseSettings.ScanFormsMode)
            {
                PresenterFactory.Init(this);
            }
            InitializeComponent();
            if (IsDesignMode() || BaseSettings.ScanFormsMode)
            {
                return;
            }

            m_SharedPresenter = PresenterFactory.SharedPresenter;
            m_BaseAvrPresenter = m_SharedPresenter[this];
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                eventManager.ClearAllReferences();
                if (m_SharedPresenter != null)
                {
                    m_SharedPresenter.UnregisterView(this);
                    m_SharedPresenter = null;
                    m_BaseAvrPresenter = null;
                }

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
            }
            finally
            {
                 base.Dispose(disposing);
            }
           
        }

        public SharedPresenter SharedPresenter
        {
            get { return m_SharedPresenter; }
        }

        public BaseAvrPresenter BaseAvrPresenter
        {
            get { return m_BaseAvrPresenter; }
        }

        public void RaiseSendCommand(Command command)
        {
            if (!IsDesignMode())
            {
                SendCommand.SafeRaise(this, new CommandEventArgs(command));
            }
        }

        public override void ApplyStyle(Control p, bool ignoreReadOnly = false)
        {
            if (BaseSettings.ScanFormsMode)
                return;
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ApplyStyle))
            {
                base.ApplyStyle(p, ignoreReadOnly);
            }
        }

        protected void ShowCannotDeleteErrorMessage(BaseDbService dbService)
        {
            ErrorMessage err = dbService.LastError;
            string msg = (err == null) ? "The record can't be deleted" : err.Text;
            if (BaseSettings.ThrowExceptionOnError)
            {
                throw new AvrException(msg);
            }

            if (err == null)
            {
                ErrorForm.ShowMessage("msgCantDeleteRecord", msg);
            }
            else
            {
                ErrorForm.ShowErrorDirect(err.Text, err.Exception);
            }
        }

        public static bool UserConfirmPublishUnpublish(AvrTreeElementType type, bool isPublishing)
        {
            string msg = string.Empty;
            switch (type)
            {
                case AvrTreeElementType.Layout:
                    msg = isPublishing
                        ? EidssMessages.Get("msgPublishLayout", "Are you sure you want to publish Layout?")
                        : EidssMessages.Get("msgUnpublishLayout", "Are you sure you want to unpublish Layout?");
                    break;
                case AvrTreeElementType.Folder:
                    msg = isPublishing
                        ? EidssMessages.Get("msgPublishFolder", "Are you sure you want to publish Folder?")
                        : EidssMessages.Get("msgUnpublishFolder", "Are you sure you want to unpublish Folder?");
                    break;
                case AvrTreeElementType.Query:
                    msg = isPublishing
                        ? EidssMessages.Get("msgPublishQuery", "Are you sure you want to publish Query?")
                        : EidssMessages.Get("msgUnpublishQuery", "Are you sure you want to unpublish Query?");
                    break;
            }

            bool answer = (MessageForm.Show(msg, string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes);
            return answer;
        }
    }
}