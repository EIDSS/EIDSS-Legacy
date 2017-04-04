using System;
using System.Threading;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Pivot;
using eidss.model.Resources;

namespace eidss.avr.Tools
{
    public class LayoutDesktopValidator : LayoutBaseValidator
    {
        private readonly IAvrInvokable m_Invokable;
        private int m_InvokeFlag;

        public LayoutDesktopValidator(IAvrInvokable invokable)
        {
            m_Invokable = invokable;
        }

        public override LayoutValidateResult Validate(LayoutBaseComplexity complexity)
        {
            if (BaseSettings.ShowBigLayoutWarning)
            {

                if (complexity.MemoryInMB > BaseSettings.AvrErrorMemoryLimit)
                {
                    SetInvokeFlag();
                    ShowCancelMemoryUsageDialog();
                    return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooMuchMemoryLayoutMessage());
                }
                if (complexity.CellCount > BaseSettings.AvrErrorCellCountLimit)
                {
                    SetInvokeFlag();
                    ShowCancelLoadBigLayoutDialog();
                    return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooBigLayoutMessage());
                }
                if (complexity.Complexity > BaseSettings.AvrErrorLayoutComplexity)
                {
                    SetInvokeFlag();
                    ShowCancelLoadComplexLayoutDialog();
                    return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooComplexLayoutMessage());
                }

                if (!IgnoreValidationWarnings)
                {
                    if (complexity.MemoryInMB > BaseSettings.AvrWarningMemoryLimit)
                    {
                        SetInvokeFlag();
                        if (ShowConfirmationMemoryUsageDialog(complexity.MemoryInMB) == DialogResult.OK)
                        {
                            return new LayoutValidateResult(LayoutValidateCode.UserDialogOk);
                        }
                        return new LayoutValidateResult(LayoutValidateCode.UserDialogCancel, GetTooMuchMemoryLayoutMessage());
                    }
                    if (complexity.CellCount > BaseSettings.AvrWarningCellCountLimit)
                    {
                        SetInvokeFlag();

                        if (ShowConfirmationLoadBigLayoutDialog(complexity.CellCount) == DialogResult.OK)
                        {
                            return new LayoutValidateResult(LayoutValidateCode.UserDialogOk);
                        }
                        return new LayoutValidateResult(LayoutValidateCode.UserDialogCancel, GetTooBigLayoutMessage());

                    }

                    if (complexity.Complexity > BaseSettings.AvrWarningLayoutComplexity)
                    {
                        SetInvokeFlag();

                        if (ShowConfirmationLoadComplexLayoutDialog() == DialogResult.OK)
                        {
                            return new LayoutValidateResult(LayoutValidateCode.UserDialogOk);
                        }
                        return new LayoutValidateResult(LayoutValidateCode.UserDialogCancel, GetTooComplexLayoutMessage());
                    }
                }
            }
            return new LayoutValidateResult();
        }

        public bool GetAndResetInvokeFlag()
        {
            return (Interlocked.Exchange(ref m_InvokeFlag, 0) == 1);
        }

        private void SetInvokeFlag()
        {
            Interlocked.Exchange(ref m_InvokeFlag, 1);
        }

        private void ShowCancelMemoryUsageDialog()
        {
            string message = GetTooMuchMemoryLayoutMessage();
            string caption = BvMessages.Get("Warning", "Warning", ModelUserContext.CurrentLanguage);

            var method = (Action) (() => MessageForm.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            Invoke(method);
        }

       

        private void ShowCancelLoadBigLayoutDialog()
        {
            string message = GetTooBigLayoutMessage();
            string caption = BvMessages.Get("Warning", "Warning", ModelUserContext.CurrentLanguage);

            var method = (Action) (() => MessageForm.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            Invoke(method);
        }

       

        private void ShowCancelLoadComplexLayoutDialog()
        {
            string message = GetTooComplexLayoutMessage();
            string caption = BvMessages.Get("Warning", "Warning", ModelUserContext.CurrentLanguage);

            var method = (Action) (() => MessageForm.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            Invoke(method);
        }

      

        private DialogResult ShowConfirmationMemoryUsageDialog(long megabytes)
        {
            string resourceMessage = EidssMessages.Get("msgApproximatelyALotOfMemoryLayout", null, ModelUserContext.CurrentLanguage);
            string message = String.Format(resourceMessage, megabytes);
            string caption = BvMessages.Get("Confirmation", "Confirmation", ModelUserContext.CurrentLanguage);

            var method =
                (Func<DialogResult>) (() => MessageForm.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question));

            return Invoke(method);
        }

        private DialogResult ShowConfirmationLoadBigLayoutDialog(long count)
        {
            const long roundTo = 100000;
            long roundedCount = count > roundTo ? roundTo * (count / roundTo + 1) : roundTo;

            string resourceMessage = EidssMessages.Get("msgApproximatelyTooBigLayout", null, ModelUserContext.CurrentLanguage);
            string message = String.Format(resourceMessage, roundedCount);
            string caption = BvMessages.Get("Confirmation", "Confirmation", ModelUserContext.CurrentLanguage);

            // return MessageForm.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            var method =
                (Func<DialogResult>) (() => MessageForm.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question));
            return Invoke(method);
        }

        private DialogResult ShowConfirmationLoadComplexLayoutDialog()
        {
            string message = EidssMessages.Get("msgApproximatelyTooComplexLayout", null, ModelUserContext.CurrentLanguage);
            string caption = BvMessages.Get("Confirmation", "Confirmation", ModelUserContext.CurrentLanguage);
            var method =
                (Func<DialogResult>) (() => MessageForm.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question));

            return Invoke(method);
        }
      
        private void Invoke(Action method)
        {
            if (m_Invokable != null && m_Invokable.InvokeRequired)
            {
                m_Invokable.Invoke(method);
            }
            else
            {
                method();
            }
        }

        private DialogResult Invoke(Func<DialogResult> method)
        {
            return m_Invokable != null && m_Invokable.InvokeRequired
                ? (DialogResult) m_Invokable.Invoke(method)
                : method();
        }
    }
}