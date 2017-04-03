#region Using

using System;
using bv.common.Core;
using bv.common.win;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Views;

#endregion

namespace EIDSS.RAM.Layout
{
    /// <summary>
    /// Base class for different layout panels
    /// </summary>
    public partial class BaseLayoutForm : BaseRamDetailPanel, IView
    {
        public event EventHandler<CommandEventArgs> SendCommand;

        private  SharedPresenter m_SharedPresenter;
        private  BaseRamPresenter m_BaseRamPresenter;

        protected BaseLayoutForm()
        {

            if (IsDesignMode())
            {
                PresenterFactory.Init(this);
                
            }
            InitializeComponent();
            if (IsDesignMode())
                return;

            m_SharedPresenter = PresenterFactory.SharedPresenter;
            m_BaseRamPresenter = m_SharedPresenter[this];
        }

        public SharedPresenter SharedPresenter
        {
            get { return m_SharedPresenter; }
        }

        public BaseRamPresenter BaseRamPresenter
        {
            get { return m_BaseRamPresenter; }
        }

        public void RaiseSendCommand(Command command)
        {
            if (IsDesignMode())
                return;
            SendCommand.SafeRaise(this, new CommandEventArgs(command));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            eventManager.ClearAllReferences();
            if (m_SharedPresenter != null)
            {
                m_SharedPresenter.UnregisterView(this);
                m_SharedPresenter = null;
                m_BaseRamPresenter = null;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}