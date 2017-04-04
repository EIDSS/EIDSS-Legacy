using System;
using System.IO;
using System.Security;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.Common.CommandProcessing.Commands.Export;
using eidss.model.Avr.Commands;
using eidss.model.AVR.DataBase;
using eidss.model.Resources;

namespace eidss.avr.BaseComponents
{
    public abstract class BaseAvrPresenter : ICommandProcessor, IDisposable
    {
        public const int NavBarGroupHeaderHeight = 28;
        protected static readonly string m_WaitTitle = EidssMessages.Get("msgPleaseWait");

        protected SharedPresenter m_SharedPresenter;

        protected BaseAvrPresenter(SharedPresenter sharedPresenter)
        {
            Utils.CheckNotNull(sharedPresenter, "sharedPresenter");
            m_SharedPresenter = sharedPresenter;
        }

        internal SharedPresenter SharedPresenter
        {
            get { return m_SharedPresenter; }
        }

        public abstract void Process(Command cmd);

        public virtual void Dispose()
        {
            m_SharedPresenter = null;
        }

        internal void ExportTo(string defaultExt, string filter, ExportDelegate exportDelegate)
        {
            Utils.CheckNotNullOrEmpty(defaultExt, "defaultExt");
            Utils.CheckNotNullOrEmpty(filter, "filter");
            Utils.CheckNotNull(exportDelegate, "exportDelegate");

            string fileName;
            if (m_SharedPresenter.SharedModel.ExportStrategy.ExportDialogOk(defaultExt, filter, out fileName))
            {
                Action<Exception, bool> exceptionAction = (ex, isDetail) =>
                {
                    string msg = String.Format(EidssMessages.Get("msgCannotExport", "Cannot export file {0}"), fileName);
                    msg = msg + Environment.NewLine + ex.Message;
                    Trace.WriteLine(Trace.Kind.Warning, msg);
                    Trace.WriteLine(ex);
                    if (isDetail)
                    {
                        ErrorForm.ShowErrorDirect(msg, ex);
                    }
                    else
                    {
                        ErrorForm.ShowErrorDirect(msg);
                    }
                };
                try
                {
                    using (CreateExportingDialog())
                    {
                        exportDelegate(fileName);
                    }
                }
                catch (IOException ex)
                {
                    exceptionAction(ex, false);
                }
                catch (UnauthorizedAccessException ex)
                {
                    exceptionAction(ex, false);
                }
                catch (SecurityException ex)
                {
                    exceptionAction(ex, false);
                }
                catch (Exception ex)
                {
                    exceptionAction(ex, true);
                }
            }
        }

        public static bool WinCheckAvrServiceAccessability(AvrServiceClientWrapper wrapper = null)
        {
            if (!BaseSettings.ScanFormsMode)
            {
                try
                {
                    AvrServiceAccessability access = AvrServiceAccessability.Check(wrapper);

                    if (access.IsOk)
                    {
                        return true;
                    }
                    if (BaseSettings.ThrowExceptionOnError)
                    {
                        throw new AvrDataException(EidssMessages.Get("msgAvrServiceNotAccessable"));
                    }

                    if (access.CanWorkAtYourOwnRisk)
                    {
                        return (ErrorForm.ShowConfirmationDialog(null, access.ErrorMessage, null) == DialogResult.Yes);
                    }

                    if (access.InnerException != null)
                    {
                        Trace.WriteLine(access.InnerException);
                        ErrorForm.ShowError(access.ErrorMessage, access.InnerException);
                    }
                    else
                    {
                        ErrorForm.ShowError(access.ErrorMessage);
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    if (BaseSettings.ThrowExceptionOnError)
                    {
                        throw;
                    }
                    ErrorForm.ShowError(EidssMessages.Get("msgAvrServiceNotAccessable"), ex);
                    return false;
                }
            }
            return true;
        }


        public static WaitDialog CreateLoadingDialog()
        {
            string message = EidssMessages.Get("msgLoading");
            return new WaitDialog(message, m_WaitTitle);
        }

        public static WaitDialog CreateAvrServiceReceiveQueryDialog()
        {
            string message = EidssMessages.Get("msgAvrServiceReceiveQuery");
            return new WaitDialog(message, m_WaitTitle);
        }

        public static WaitDialog CreateExportingDialog()
        {
            string message = EidssMessages.Get("msgAvrExporting");
            return new WaitDialog(message, m_WaitTitle);
        }
    }
}