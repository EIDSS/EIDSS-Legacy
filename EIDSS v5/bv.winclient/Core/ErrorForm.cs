using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using BLToolkit.Aspects;
using bv.common;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.common.Enums;

namespace bv.winclient.Core
{
    public partial class ErrorForm : DevExpress.XtraEditors.XtraForm
    {
        public ErrorForm()
        {
            InitializeComponent();
            Splash.HideSplash();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                cmdDetail.Click += cmdDetail_Click;
                if (BaseFormManager.MainForm != null)
                    Icon = BaseFormManager.MainForm.Icon;
            }
        }
        public enum FormType
        {
            Error,
            Message,
            Warning,
            Confirmation
        }
        bool m_ShowDetail = false;
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ErrorText
        {
            get
            {
                return lbErrorText.Text;
            }
            set
            {
                lbErrorText.Text = value;
                //    if (value != null)
                //    {
                //        cmdDetail_Click(null, EventArgs.Empty);
                //        //cmdSend.Visible = value.IsCriticalError;
                //    }
            }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullErrorText
        {
            get
            {
                return txtFullErrorText.Text;
            }
            set
            {
                txtFullErrorText.Text = value;
                if (value != null)
                {
                    DefineButtonsVisibility();
                    //cmdDetail_Click(null, EventArgs.Empty);
                    //cmdSend.Visible = value.IsCriticalError;
                }
            }
        }


        private FormType m_FormType;
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FormType Type
        {
            get
            {
                return m_FormType;
            }
            set
            {
                m_FormType = value;
                Text = GetMessage(m_FormType.ToString());
                DefineButtonsVisibility();

            }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static BaseStringsStorage Messages { get; set; }

        static ErrorForm()
        {
            UnitTestMode = false;
        }

        public static bool UnitTestMode { get; set; }

        private void DefineButtonsVisibility()
        {
            //if (m_FormType != FormType.Error)
            //{
            cmdDetail.Visible = txtFullErrorText.Text != "";
            cmdDetail_Click(null, EventArgs.Empty);
            cmdSend.Visible = false;
            cmdOk.Visible = m_FormType != FormType.Confirmation;
            btnNo.Visible = m_FormType == FormType.Confirmation;
            btnYes.Visible = m_FormType == FormType.Confirmation;
            //}
            //else
            //{
            //cmdDetail.Visible = txtFullErrorText.Text != "";
            //cmdDetail_Click(null, EventArgs.Empty);
            //cmdSend.Visible = false;
            //if (m_Error != null)
            //{
            //    cmdSend.Visible = m_Error.IsCriticalError;
            //}
            //else
            //{
            //    cmdSend.Visible = false;
            //}
            //}

        }

        #region "Shared methods"
        private static Exception GetInnerException(Exception ex)
        {
            while (ex != null && ex.InnerException != null)
                return GetInnerException(ex.InnerException);
            return ex;
        }
        private static bool HandleException(Exception ex)
        {
            if (ex == null)
                return false;
            ex = GetInnerException(ex);
            if (ex is SqlException)
            {
                string msgId = SqlExceptionMessage.Get(ex as SqlException);
                if (msgId != null)
                {
                    ShowError(msgId);
                    return true;
                }
            }
            return false;
        }


        public static string GetMessage(string resourceKey, string resourceValue = null)
        {
            if (resourceKey == null) return String.Empty;
            var s = BvMessages.Get(resourceKey, resourceValue);
            if (BvMessages.Instance.IsValueExists)
                return s;
            if (Messages != null)
            {
                s = Messages.GetString(resourceKey, resourceValue);
                return s;
            }
            return String.Empty;
        }

        private static DialogResult ShowForm(ErrorForm f, Form owner)
        {
            if (owner == null)
                owner = Form.ActiveForm;
            f.TopMost = true;
            if (UnitTestMode)
            {
                f.Show(owner);
                System.Threading.Thread.Sleep(2000);
                return DialogResult.OK;
            }
            return f.ShowDialog(owner);
        }
        private static ErrorForm Create(Form owner, string msg, FormType fType, string detailError = null)
        {
            if(owner ==null)
            {
                owner = Form.ActiveForm;
            }
            var f = new ErrorForm();

            f.ErrorText = msg;
            f.Type = fType;
            //f.cmdDetail.Visible = !string.IsNullOrEmpty(detailError);
            if (!string.IsNullOrEmpty(detailError))
            {
                f.FullErrorText = detailError;
            }
            //f.cmdDetail_Click(null, EventArgs.Empty);
            f.StartPosition = owner != null ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen;
            return f;
        }

        public static void ShowMessageDirect(Form owner, string msg, FormType fType, string detailError = null)
        {
            if (BaseFormManager.IsReportsServiceRunning || BaseFormManager.IsAvrServiceRunning)
            {
                string error = string.Format("Could not show message form from the service.{0}Error message:{0}'{1}'{0} Error details:{0}'{2}'",
                    Environment.NewLine, msg, detailError);
                throw new ApplicationException(error);
            }

            using (ErrorForm f = Create(owner, msg, fType, detailError))
            {
                ShowForm(f, owner);
            }
        }
        public static void ShowMessageDirect(string msg, FormType fType, string detailError = null)
        {
            ShowMessageDirect(null, msg, fType, detailError);
        }
        public static void ShowMessageDirect(string msg)
        {
            ShowMessageDirect(msg, FormType.Message);
        }

        public static void ShowMessage(string str, string defaultStr)
        {
            ShowMessageDirect(GetMessage(str, defaultStr));
        }


        public static void ShowWarning(string str, string defaultStr = null)
        {
            ShowWarningDirect(GetMessage(str, defaultStr));
        }
        public static void ShowWarningFormat(string str, string defaultStr, params object[] args)
        {
            ShowMessageDirect(
                                args == null
                                    ? GetMessage(str, defaultStr)
                                    : String.Format(GetMessage(str, defaultStr), args)
                                    , FormType.Warning);

        }

        public static void ShowWarningDirect(string str)
        {
            ShowMessageDirect(str, FormType.Warning);
        }

        public static void ShowError(StandardError errType, Exception ex)
        {
            if (HandleException(ex))
                return;
            string error = StandardErrorHelper.Error(errType);
            string detailError = ex.ToString();
            ShowMessageDirect(error, FormType.Error, detailError);
        }
        public static void ShowError(Exception ex)
        {
            ShowError(StandardError.UnprocessedError, ex);
        }



        public static void ShowError(string errResourceName)
        {
            ShowMessageDirect(GetMessage(errResourceName), FormType.Error);
        }

        public static void ShowError(string errResourceName, string errMsg)
        {
            ShowMessageDirect(GetMessage(errResourceName, errMsg), FormType.Error);
        }

        private static Exception m_currentException = null;
        public static void ShowError(string errResourceName, string errMsg, Exception ex)
        {
            if (m_currentException != null)
                return;
            if (HandleException(ex))
                return;

            m_currentException = ex;
            string detailError = null;
            if (ex != null)
                detailError = ex.ToString();
            ShowMessageDirect(GetMessage(errResourceName, errMsg), FormType.Error, detailError);
            m_currentException = null;
        }

        public static void ShowError(string errResourceName, string errMsg, params object[] args)
        {
            ShowMessageDirect(
                args == null
                    ? GetMessage(errResourceName, errMsg)
                    : String.Format(GetMessage(errResourceName, errMsg), args)
                    , FormType.Error);
        }

        public static void ShowErrorDirect(string errMessage, Exception ex = null)
        {
            string detailError = null;
            if (ex != null)
                detailError = ex.ToString();
            ShowMessageDirect(errMessage, FormType.Error, detailError);
        }
        public static void ShowErrorDirect(Form owner, string errMessage, Exception ex = null)
        {
            string detailError = null;
            if (ex != null)
                detailError = ex.ToString();
            ShowMessageDirect(owner, errMessage, FormType.Error, detailError);
        }
        public static void ShowErrorDirect(string errMessage, params object[] args)
        {
            ShowMessageDirect(String.Format(errMessage, args), FormType.Error);
        }
        public static void ShowErrorDirect(Form owner, string errMessage, params object[] args)
        {
            ShowMessageDirect(owner, String.Format(errMessage, args), FormType.Error);
        }

        public static void ShowError(string errMsg, Exception ex)
        {
            if (HandleException(ex))
                return;
            ShowMessageDirect(errMsg, FormType.Error, ex.ToString());
        }

        public static DialogResult ShowConfirmationDialog(Form owner, string msg, string detailError)
        {
            using (var f = Create(owner, msg, FormType.Confirmation, detailError))
            {
                return ShowForm(f, owner);
            }
        }

        private delegate void ExceptionDelegate(Exception ex);

        public static void ShowErrorThreadSafe(Exception ex)
        {
            ExceptionDelegate o = ShowError;

            if (BaseFormManager.MainForm == null)
            {
                throw (ex);
            }
            BaseFormManager.MainForm.BeginInvoke(o, ex);
        }
        #endregion

        #region "Private methods"
        private void cmdDetail_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            if (string.IsNullOrEmpty(txtFullErrorText.Text))
            {
                m_ShowDetail = false;
                cmdDetail.Visible = false;
                pnDetails.Visible = false;
                if (Height - pnDetails.Height > 100)
                    Height -= pnDetails.Height;
                ResumeLayout();
                return;
            }
            if (m_ShowDetail)
            {
                cmdDetail.Text = GetMessage("btnShowErrDetail", "Show Details");
                Height -= pnDetails.Height;
            }
            else
            {
                cmdDetail.Text = GetMessage("btnHideErrDetail", "Hide Details");
                Height += pnDetails.Height;
            }
            m_ShowDetail = !m_ShowDetail;
            pnDetails.Visible = m_ShowDetail;
            ResumeLayout();
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            PerformLayout();
        }

    }
}
