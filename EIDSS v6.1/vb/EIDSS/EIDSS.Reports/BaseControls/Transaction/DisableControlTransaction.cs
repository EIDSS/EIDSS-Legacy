using System;
using System.Windows.Forms;
using eidss.model.Reports.OperationContext;
using bv.common.Core;

namespace EIDSS.Reports.BaseControls.Transaction
{
    public class DisableControlTransaction : IDisposable
    {
        private readonly Control m_Control;
        private readonly IContextKeeper m_ContextKeeper;


        public DisableControlTransaction(Control control, IContextKeeper contextKeeper)
        {
            Utils.CheckNotNull(control, "control");
            Utils.CheckNotNull(contextKeeper, "contextKeeper");
            m_Control = control;
            m_ContextKeeper = contextKeeper;
            using (m_ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                m_Control = control;
                m_Control.Enabled = false;
                Application.DoEvents();
            }
        }

        public void Dispose()
        {
            using (m_ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                m_Control.Enabled = true;

                ContainerControl parent = GetParentContainerControl(m_Control);
                if (parent != null)
                {
                    parent.ActiveControl = m_Control;
                }
                Application.DoEvents();
            }
        }

        private ContainerControl GetParentContainerControl(Control control)
        {
            Utils.CheckNotNull(control, "control");

            Control parent = control.Parent;
            if (parent == null)
                return null;

            return parent is ContainerControl 
                ? (ContainerControl) parent 
                : GetParentContainerControl(parent);
        }
    }
}