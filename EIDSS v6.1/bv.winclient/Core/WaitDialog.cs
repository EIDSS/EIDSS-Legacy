using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using bv.winclient.BasePanel;
using DevExpress.Utils;
using bv.common.Core;
using bv.common.Resources;
using System.Web;
using bv.model.Helpers;
using bv.winclient.Layout;

namespace bv.winclient.Core
{
    public class WaitDialog : IDisposable
    {
        private class BvWaitDialog : WaitDialogForm
        {
            private const int MaxWidth = 800;

            public BvWaitDialog(string caption, string title)
                : base(caption, title, new Size(260, 50), null)
            {
                LayoutCorrector.ApplySystemFont(this);
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                using (var bmp = new Bitmap(10, 10))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                        using (var sf = new StringFormat())
                        {
                            sf.Alignment = sf.LineAlignment = StringAlignment.Center;
                            sf.Trimming = StringTrimming.EllipsisCharacter;
                            Type type = typeof (WaitDialogForm);
                            var fi = type.GetField("title", BindingFlags.Instance | BindingFlags.NonPublic);

                            var titleWidth = (int)g.MeasureString(fi.GetValue(this).ToString(), new Font(WinClientContext.CurrentFont.FontFamily, WinClientContext.CurrentFont.Size, FontStyle.Bold), MaxWidth, sf).Width;
                            var captionWidth = (int)g.MeasureString(Caption, WinClientContext.CurrentFont, MaxWidth, sf).Width;

                            ClientSize = new Size(Math.Max(captionWidth, titleWidth) + 60, ClientSize.Height);
                        }
                }
            }
        }

        private BvWaitDialog m_DialogForm;
        private string m_Caption;
        public static BaseStringsStorage Messages { get; set; }
        private static readonly List<BvWaitDialog> m_WaitFormsList = new List<BvWaitDialog>();
        public WaitDialog()
        {
            Title = BvMessages.Get("msgWaitFormCaption", "Please wait");
            m_Caption = BvMessages.Get("msgFormLoading", "The form is loading");
            Init();
        }
        public WaitDialog(WaitDialogType type)
        {
            m_DialogForm = null;
            if (type != WaitDialogType.None)
            {
                Title = GetMessage("msgWaitFormCaption");
                m_Caption = GetMessage("msg" + type);
                Init();
            }
        }

        private void Init()
        {
            m_DialogForm = null;
            if (HttpContext.Current == null && 
                !Utils.IsCalledFromUnitTest()  && 
                !BaseFormManager.IsReportsServiceRunning && 
                !BaseFormManager.IsAvrServiceRunning)
            {
                m_DialogForm = new BvWaitDialog(m_Caption, Title);
                m_WaitFormsList.Add(m_DialogForm);
            }
        }
        public WaitDialog(string caption, string title = null)
        {

            Title = string.IsNullOrEmpty(title) ? GetMessage("msgWaitFormCaption") : title;
            m_Caption = caption;
            Init();
        }
        public static string GetMessage(string resourceKey)
        {
            if (resourceKey == null) return String.Empty;
            var s = BvMessages.Get(resourceKey);
            if (BvMessages.Instance.IsValueExists)
                return s;
            if (Messages != null)
            {
                s = Messages.GetString(resourceKey);
                return s;
            }
            return String.Empty;
        }


        public static void CloseWaitDialog(object waitDialog)
        {
            if (waitDialog != null) ((WaitDialog)waitDialog).Dispose();
        }

        public static object ShowWaitDialog(WaitDialogType type)
        {
            return new WaitDialog(type);
        }

        public string Title { get; private set; }

        public string Caption
        {
            get { return m_Caption; }
            set
            {
                m_Caption = value;
                if (m_DialogForm != null)
                {
                    m_DialogForm.SetCaption(m_Caption);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (m_DialogForm != null)
            {
                m_WaitFormsList.Remove(m_DialogForm);
                m_DialogForm.Close();
                m_DialogForm = null;
                Application.DoEvents();
            }
        }

        public static void Hide()
        {
            for (int i = m_WaitFormsList.Count - 1; i >= 0; i--)
            {
                m_WaitFormsList[i].Hide();
            }
        }
        public static void Restore()
        {
            foreach (BvWaitDialog t in m_WaitFormsList)
            {
                t.Visible = true;
                Application.DoEvents();
            }
        }
    }
}
