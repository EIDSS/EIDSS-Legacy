using System;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.common.Diagnostics;

namespace eidss.main
{
    class UnhandledExceptionHandler
    {
            // Handles the exception event.
            public void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs t)
            {
                if (BaseFormManager.MainForm != null)
                {
                    Cursor.Current = Cursors.Default;
                }
                DialogResult result;
                try
                {
                    result = ShowThreadExceptionDialog(t.Exception);
                }
                catch (Exception)
                {
                    try
                    {
                        MessageForm.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                    }
                    finally
                    {
                        MainForm.ExitApp(true);
                    }
                    return;
                }

                // Exits the program when the user clicks Abort.
                if ((result == DialogResult.Abort) || BaseFormManager.MainForm == null)
                {
                    MainForm.ExitApp(true);
                }

            }

            // Creates the error message and displays it.
            private DialogResult ShowThreadExceptionDialog(Exception e)
            {
                try
                {
                    if (e is DbModelTimeoutException)
                    {
                        ErrorForm.ShowWarning("msgTimeoutList", "Cannot retrieve records from database because of the timeout. Please change search criteria and try again");
                    }
                    else if(!SqlExceptionHandler.Handle(e))
                    {
                        ErrorForm.ShowError(StandardError.UnprocessedError, e);
                    }
                }
                catch (Exception e1)
                {
                    Dbg.Debug("application error: {0} ", e.ToString());
                    if (e.InnerException != null)
                        Dbg.Debug("Inner exception: {0} ", e.InnerException.ToString());
                    Dbg.Debug("error during displaying application error: {0} ", e1.ToString());
                    return MessageForm.Show(e.Message, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                if (BaseFormManager.MainForm == null || !((MainForm)BaseFormManager.MainForm).m_Loaded)
                {
                    return DialogResult.Abort;
                }
                return DialogResult.Ignore;
            }
        }
}

