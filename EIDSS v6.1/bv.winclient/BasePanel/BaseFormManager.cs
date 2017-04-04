using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraBars;

namespace bv.winclient.BasePanel
{
    public class BaseFormManager
    {

        private static readonly List<IApplicationForm> m_FormList = new List<IApplicationForm>();
        private static Form m_MainForm;

        public static void Init(Form mainForm)
        {
            m_MainForm = mainForm;
        }

        public static Form MainForm
        {
            get { return m_MainForm; }
        }

        public static BarManager MainBarManager { get; set; }
        private static IApplicationForm m_CurrentForm;

        public static IApplicationForm CurrentForm
        {
            get
            {
                if (m_CurrentForm != null)
                {
                    if (((Control)m_CurrentForm).IsDisposed)
                    {
                        //IApplicationForm form = GetPreviousForm(m_CurrentForm);
                        UnRegister(m_CurrentForm);
                        //m_CurrentForm = form;
                        //return m_CurrentForm;
                    }
                    return m_CurrentForm;
                }
                return null;
            }
        }

        private static IApplicationForm GetPreviousForm(IApplicationForm form)
        {
            IApplicationForm nextForm = null;

            int i = m_FormList.IndexOf(form);
            if (i > 0)
            {
                nextForm = m_FormList[i - 1];
            }
            else if (i == 0 && m_FormList.Count > 1)
            {
                nextForm = m_FormList[1];
            }
            while (nextForm != null)
            {
                if (!((Control)nextForm).IsDisposed)
                {
                    return nextForm;
                }
                m_FormList.Remove(nextForm);
                nextForm = m_FormList.Count > 0 ? m_FormList[m_FormList.Count - 1] : null;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Register(IApplicationForm frm, object id)
        {
            if (m_CurrentForm != null)
            {
                var listPanel = m_CurrentForm as IBaseListPanel;
                if (listPanel != null)
                    listPanel.HideCustomization();
            }
            var ctl = FindFormByID(frm.GetType(), id);
            if (ctl == null)
            {
                m_FormList.Add(frm);
                m_CurrentForm = frm;
                return true;
            }
            ctl.Activate();
            m_CurrentForm = ctl;
            return false;
        }

        //It is possible the situation when form is closed after pressing one of the 
        //child form buttons (SampleLogBook for example containes 2 other IApplicationForms and closed after closing
        //one of these forms)
        //In this case we should close the parent form, not the current one because parent form is registered in the forms list.
        //This method returns top level IApplicationForm and used in Close method.
        private static IApplicationForm GetRootAppForm(IApplicationForm form)
        {
            var parent = ((Control)form).Parent;
            while (parent != null)
            {
                if (parent is IApplicationForm && !(parent is BvForm))
                    form = (IApplicationForm)parent;
                parent = parent.Parent;
            }
            return form;
        }


        public static void UnRegister(IApplicationForm frm)
        {
            if (frm == null)
                return;
            var parentForm = ((Control)frm).FindForm();
            if (parentForm != null)
                parentForm.KeyDown -= frm.BaseForm_KeyDown;
            if (frm is ITranslationView && ((ITranslationView)frm).DCManager != null)
            {
                ((ITranslationView)frm).DCManager.Release();
            }
            m_FormList.Remove(frm);

            if (ReferenceEquals(frm, m_CurrentForm))
            {
                m_CurrentForm = null;
            }
        }

        private static bool m_FormClosing;

        public static bool FormClosing
        {
            get { return m_FormClosing; }
        }

        public static bool Close
            (IApplicationForm form, DialogResult result = DialogResult.Cancel, FormClosingMode closeMode = FormClosingMode.NoSave)
        {
            if (m_FormClosing)
                return true;
            m_FormClosing = true;
            //IApplicationForm nextForm = GetPreviousForm(form);
            try
            {
                form = GetRootAppForm(form);
                var basePanel = form as IBasePanel;
                if (basePanel != null)
                {
                    (basePanel).LifeTimeState = LifeTimeState.Closing;
                }
                if (!form.Close(closeMode))
                    return false;
                var baseFormContainer = ((Control)form).FindForm();
                bool disposed = false;
                if (baseFormContainer != null)
                {
                    if (m_ModalFormCount > 0)
                    {
                        baseFormContainer.DialogResult = result;
                        baseFormContainer.Close();
                        disposed = true;
                    }
                    else if (baseFormContainer != m_MainForm)
                    {
                        baseFormContainer.Close();
                        disposed = true;
                    }
                }
                UnRegister(form);
                var panel = form as IBasePanel;
                if (panel != null)
                    (panel).LifeTimeState = LifeTimeState.Closed;
                if (!disposed)
                {
                    ((Control)form).Dispose();
                    form = null;
                }
            }
            finally
            {
                if (form != null)
                {
                    var basePanel = form as IBasePanel;
                    if (basePanel != null)
                        (basePanel).LifeTimeState = (basePanel).LifeTimeState & (~LifeTimeState.Closing);
                }
                //else
                //    Activate(nextForm);
                m_FormClosing = false;
            }
            return true;

        }

        public static bool CloseAll(bool needSave)
        {
            while (m_FormList.Count > 0)
            {
                if (!Close(m_FormList[0], DialogResult.Cancel, needSave ? FormClosingMode.SaveWithConfirmation : FormClosingMode.NoSave))
                    return false;
            }
            m_CurrentForm = null;
            return true;
        }

        public static bool CloseNonListForms(bool needSave)
        {
            var openedFoms = new IApplicationForm[m_FormList.Count];
            m_FormList.CopyTo(openedFoms);
            try
            {
                foreach (IApplicationForm frm in openedFoms)
                {
                    //if (!(frm is IBaseListPanel || frm is IListFormsContainer))
                    if (((Control)frm).FindForm() != MainForm)
                        if (!Close(frm, DialogResult.Cancel, needSave ? FormClosingMode.SaveWithConfirmation : FormClosingMode.NoSave))
                            return false;
                }
            }
            catch (Exception ex)
            {
                Dbg.Trace();
                Dbg.Debug(ex.ToString());

            }
            m_CurrentForm = null;
            return true;
        }

        private static int CompareFormByID(IApplicationForm form, object id)
        {
            object key = form.Key;
            if (form.IsSingleTone) //list forms are considered as equals if their types are equals
                return 0;
            //    key = (form as IBasePanel).BusinessObject.Key;
            if (Utils.IsEmpty(id))
                return -1;
            if ((key != null && key.Equals(id)))
                return 0;
            return -1;
        }

        public static IApplicationForm FindFormByType(Type formType)
        {
            foreach (IApplicationForm form in m_FormList)
            {
                if (form.GetType() == formType)
                    return form;
            }
            return null;
        }

        public static IApplicationForm FindFormByID(Type formType, object id)
        {
            return FindForm(formType, id, CompareFormByID);
        }

        public static IApplicationForm FindForm(Type formType, object x, CompareFunction compare)
        {
            foreach (IApplicationForm form in m_FormList)
            {
                if (form.GetType() != formType)
                    continue;
                if (compare(form, x) == 0)
                {
                    Activate(form);
                    return form;
                }
            }
            return null;
        }

        //This method is used for searching detail form with not empty ID
        //to check is it possible to delete it
        public static IApplicationForm FindFormByID(IApplicationForm sourceForm, object id)
        {
            if (id == null)
                return null;
            return m_FormList.Where(form => form.Key != null && form != sourceForm).FirstOrDefault(form => id.Equals(form.Key));
        }

        public delegate int CompareFunction(IApplicationForm form, object x);

        public static IApplicationForm FindForm(IApplicationForm formToFind, Comparison<IApplicationForm> compare)
        {
            foreach (IApplicationForm form in m_FormList)
            {
                if (form.GetType() != formToFind.GetType())
                    continue;
                if (compare != null)
                {
                    if (compare(form, formToFind) == 0)
                        return form;
                    continue;
                }
                return form;
            }
            return null;
        }

        private static void Activate(IApplicationForm form)
        {
            if (form == null)
            {
                if (MainForm != null)
                {
                    MainForm.Activate();
                    MainForm.BringToFront();
                }
                return;
            }
            if (m_ModalFormCount > 0)
                return;
            if (m_FormList.IndexOf(form) >= 0)
            {
                form.Activate();
                ((Control)form).BringToFront();
                m_CurrentForm = form;
            }
        }

        public static void ShowClient(Type typeForm, Control parentControl, IObject bo, Dictionary<string, object> @params = null)
        {
            if (typeForm == null)
            {
                return;
            }
            IApplicationForm appForm = null;
            try
            {
                using (new WaitDialog())
                {
                    var o = ClassLoader.LoadClass(typeForm);
                    appForm = o as IApplicationForm;
                    if (appForm == null) return;
                    if (!Register(appForm, bo.Key))
                        return;
                    if (bo.Key == null || (bo.Key is long && ((long)bo.Key) <= 0))
                    {
                        object id = null;
                        if (!LoadData(appForm, ref id))
                        {
                            UnRegister(appForm);
                            return;
                        }
                    }

                    var basePanel = appForm as IBasePanel;
                    if (basePanel != null)
                    {
                        basePanel.BusinessObject = bo;
                        if (ReadOnly)
                            basePanel.ReadOnly = true;
                    }

                    DisplayClientForm(appForm, parentControl);
                    //if (!CanViewObject(frm))
                    //{
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                UnRegister(appForm);
                Dbg.Debug("error during form showing", ex.ToString());
                throw;
            }
        }

        public static void ShowClient(IApplicationForm frm, Control parentControl, ref object id, Dictionary<string, object> @params = null)
        {
            if (frm == null) return;

            //if (!CanViewObject(frm))
            //{
            //    return;
            //}
            if (!Register(frm, id)) return;
            try
            {
                if (!LoadData(frm, ref id)) return;

                //if (frm is IBasePanel)
                //{
                //    (frm as IBasePanel).StartUpParameters = @params;
                //    (frm as IBasePanel).LoadData(ref id);
                //}
                using (new WaitDialog())
                {
                    DisplayClientForm(frm, parentControl);
                    frm.Activate();
                }

            }
            catch (Exception ex)
            {
                UnRegister(frm);
                Dbg.Debug("error during form showing", ex.ToString());
                throw;
            }
        }
        //private static int counter = 1;

        private static void DisplayClientForm(IApplicationForm frm, Control parentControl)
        {
            var formCtl = (Control)frm;
            var form = parentControl.FindForm();
            var layout = GetFormLayout(frm);
            if (form != null)
            {
                form.SuspendLayout();
            }
            formCtl.Visible = false;
            if (parentControl != form)
                parentControl.SuspendLayout();
            layout.Dock = DockStyle.Fill;
            layout.Parent = parentControl;
            layout.BringToFront();
            layout.Visible = true;
            formCtl.Visible = true;
            DisplayCaption(frm);
            if (parentControl != form)
                parentControl.ResumeLayout();
            if (form != null)
            {
                form.ResumeLayout();
                //This is the workaround for bring up layout when RTL mode is used
                if (Localizer.IsRtl)
                {
                    form.ActiveControl = layout;
                    WindowsAPI.SendMessage(form.Handle, 0x7 /*WM_SETFOCUS*/, (IntPtr)null, (IntPtr)null);
                }
            }
            InitDesignManager(frm);
        }


        /// <summary>
        /// Показывает форму с панелью и layout в модальном режиме (используется для тестов)
        /// </summary>
        /// <param name="appForm"></param>
        public static void ShowSimpleFormModal(IApplicationForm appForm)
        {
            //var container = GetContainer(appForm);
            //var frm = new Form
            //{
            //    Size = new Size(800, 600),
            //    StartPosition = FormStartPosition.CenterScreen,
            //};
            //frm.Controls.Add(container);
            //container.Dock = DockStyle.Fill;
            var frm = PrepareFormShowing(appForm, true, null, 800, 600);
            frm.ShowDialog();
        }

        private static Control GetContainer(IApplicationForm appForm)
        {
            ILayout layout = null;
            var bp = appForm as IBasePanel;
            if (bp != null)
            {
                layout = bp.GetLayout();
            }

            //Контейнер, содержащий всю смысловую часть формы, который требуется разместить либо в теле главной формы, либо на подложке созданной формы
            return (Control)layout ?? (Control)appForm;
        }

        private static bool LoadData(IApplicationForm appForm, ref object id)
        {
            using (new WaitDialog())
            {
                try
                {
                    bool ret = true;
                    if (appForm is IBasePanel)
                    {
                        (appForm as IBasePanel).LoadData(ref id);
                    }
                    else if (appForm is IListFormsContainer)
                    {
                        //we doesn't check the ListPanel existence - it must exist
                        (appForm as IListFormsContainer).ListPanels[0].LoadData(ref id);
                    }
                    else if (ReflectionHelper.HasMethod(appForm, "LoadData"))
                    {
                        var @params = new[] { id };
                        ret = (bool)ReflectionHelper.InvokeMethod(appForm, "LoadData", @params);
                        id = @params[0];
                    }
                    return ret;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static IApplicationForm FindChildIApplicationForm(object sender)
        {
            if (sender == null)
            {
                return null;
            }
            var appForm = sender as IApplicationForm;
            if (appForm != null && appForm != MainForm && !(appForm is BvForm))
            {
                return appForm;
            }
            if ((sender) is Control)
            {
                var ctl = (Control)sender;
                appForm = (from Control c in ctl.Controls
                           where (c) is IApplicationForm
                           select ((IApplicationForm)c)).FirstOrDefault();
                if (appForm != null)
                    return appForm;
                foreach (var c in ctl.Controls)
                {
                    appForm = FindChildIApplicationForm(c);
                    if (appForm != null)
                        return appForm;
                }
            }
            return sender as BvForm;
        }

        public static void OnFormActivate(object sender, EventArgs e)
        {
            IApplicationForm form = FindChildIApplicationForm(sender);
            if (form != null)
            {
                //if (form.LifeTimeState == LifeTimeState.DataLoading)
                //{
                //    return;
                //}
                //if (form.BusinessObject.ObjectType == BusinessObjectType.List)
                //{
                //    try
                //    {
                //        form.LoadData(null);
                //    }
                //    catch (Exception)
                //    {
                //        Close(form);
                //        return;
                //    }
                //}
                m_CurrentForm = form;
            }
        }

        public static void OnFormClosing(object sender, CancelEventArgs e)
        {
            IApplicationForm form = FindChildIApplicationForm(sender);
            if (form != null)
            {
                if (!m_FormClosing)
                {
                    e.Cancel = true;
                    //Close(form, DialogResult.Cancel, FormClosingMode.SaveWithConfirmation);
                    //e.Cancel = false;
                    (sender as Control).BeginInvoke(
                        new MethodInvoker(() => BaseFormManager.Close(form, DialogResult.Cancel, FormClosingMode.SaveWithConfirmation)));
                }
                //if(form is IBasePanel)
                //    (form as IBasePanel).LifeTimeState = LifeTimeState.Closing;
                //form.Release();
                //UnRegister(form);
            }
        }


        //private static bool CanViewObject(IApplicationForm frm)
        //{
        //    if (frm.BusinessObject == null)
        //    {
        //        return true;
        //    }
        //    if (!frm.BusinessObject.AccessPermissions.CanSelect)
        //    {
        //        MessageBox.Show(BvMessages.Get("msgNoSelectPermission", "You have no rights to view this form",null));
        //        return false;
        //    }
        //    return true;
        //}
        private static void DisplayCaption(IApplicationForm frm)
        {
            //Form f = ((Control)frm).FindForm();
            //if (f == null)
            //{
            //    return;
            //}
            //if (((Control)frm).Visible && frm.Caption != "")
            //{
            //    f.Text = string.Format("[{2}]{0} - [{1}]", ApplicationContext.ApplicationCaption, frm.Caption, frm.FormID);
            //}
            //else
            //{
            //    f.Text = string.Format("[{1}]{0}", ApplicationContext.ApplicationCaption, frm.FormID);
            //}

        }

        public static Control GetFormLayout(IApplicationForm child)
        {
            Debug.Assert(child != null, "base form can\'t be null");
            var bp = child as IBasePanel;
            ILayout layout = null;
            if (bp != null)
            {
                layout = bp.GetLayout();
                layout.ParentBasePanel = bp;
            }
            if (layout != null)
                return (Control)layout;
            return ((Control)child);
        }

        //private static string m_DefaultLayout;
        //public static string DefaultLayout
        //{
        //    get
        //    {
        //        return m_DefaultLayout;
        //    }
        //    set
        //    {
        //        m_DefaultLayout = value;
        //    }
        //}
        public static void ResetLanguage()
        {
            LayoutCorrector.Init();
            var openedFoms = new IApplicationForm[m_FormList.Count];
            m_FormList.CopyTo(openedFoms);
            try
            {
                foreach (IApplicationForm frm in openedFoms)
                {
                    //if (!(frm is IBaseListPanel || frm is IListFormsContainer))
                    if (((Control)frm).FindForm() != MainForm)
                        Close(frm);
                    else
                        ResetLanguage(frm);
                }
            }

            catch (Exception ex)
            {
                Dbg.Trace();
                Dbg.Debug(ex.ToString());

            }
        }

        public static void ResetLanguage(IApplicationForm panel)
        {
            IObject bo = null;
            var frm = ((Control)panel).FindForm();
            Control parent = ((Control)panel).Parent;
            var basePanel = panel as IBasePanel;
            if (basePanel != null)
            {
                bo = (basePanel).BusinessObject;
                parent = (((Control)(basePanel).GetLayout())).Parent;
            }
            Close(panel);
            if (bo != null)
            {
                if (frm == m_MainForm)
                    ShowClient(panel.GetType(), parent, bo);
                else
                    ShowNormal(panel.GetType(), bo, null, ((Control)panel).Width, ((Control)panel).Height);
            }
            else
            {
                object key = panel.Key;
                panel = (IApplicationForm)ClassLoader.LoadClass(panel.GetType());
                if (frm == m_MainForm)
                    ShowClient(panel, parent, ref key);
                else
                    ShowNormal(panel, ref key, null, ((Control)panel).Width, ((Control)panel).Height);
            }
        }

        public static void RefreshList(string businessObjectName)
        {
            foreach (IApplicationForm appForm in m_FormList)
            {
                if (appForm is IBaseListPanel && (appForm as IBaseListPanel).BusinessObject.GetType().Name == businessObjectName)
                {
                    var t = new Thread((appForm as IBaseListPanel).LoadData);
                    t.Start();
                }
                if (appForm is IListFormsContainer)
                {
                    foreach (var list in (appForm as IListFormsContainer).ListPanels)
                    {
                        if (list.BusinessObject.GetType().Name == businessObjectName)
                        {
                            var t = new Thread(list.LoadData);
                            t.Start();
                        }

                    }
                }

            }
        }

        #region Show methods

        private static Form PrepareFormShowing
            (IApplicationForm appForm, bool isModal, Dictionary<string, object> parameters, int width, int height)
        {
            //DebugTimer.Start(string.Format("{0} before load", form.GetType().Name));
            if (appForm is Form)
            {
                var form = appForm as Form;
                form.KeyDown += appForm.BaseForm_KeyDown;
                form.Activated += OnFormActivate;
                form.Closing += OnFormClosing;
                RtlHelper.SetRTL(form);

                return appForm as Form;
            }

            //Контейнер, содержащий всю смысловую часть формы, который требуется разместить либо в теле главной формы, либо на подложке созданной формы
            var container = GetContainer(appForm);

            var screenSize = Screen.GetWorkingArea(new Point(0, 0));

            if (appForm.Sizable)
            {
                if (width > 0)
                    container.Width = width;
                else if (width < 0 || container.Width > screenSize.Width)
                    container.Width = screenSize.Width;
                if (height > 0)
                    container.Height = height;
                else if (height < 0 || container.Height > screenSize.Height)
                    container.Height = screenSize.Height;

            }

            if (container.MinimumSize.Height != 0 && container.Height < container.MinimumSize.Height)
                container.Height = container.MinimumSize.Height;

            if (container.MinimumSize.Width != 0 && container.Width < container.MinimumSize.Width)
                container.Width = container.MinimumSize.Width;

            //подложка, на которой располагается контейнер formCtl
            var baseFormContainer = new BvForm
            {
                StartPosition = FormStartPosition.CenterScreen,
                ClientSize = new Size(width > 0 ? width : container.Width, height > 0 ? height : container.Height),
                MinimumSize = new Size(appForm.MinWidth == 0 ? 0 : appForm.MinWidth,
                    appForm.MinHeight == 0 ? 0 : appForm.MinHeight)
            };

            if (appForm.Sizable)
                baseFormContainer.FormBorderStyle = FormBorderStyle.Sizable;
            else
            {
                baseFormContainer.FormBorderStyle = FormBorderStyle.FixedDialog;
                baseFormContainer.MaximizeBox = false;
            }
            //baseFormContainer.ControlBox =false;
            baseFormContainer.Controls.Add(container);

            container.Dock = DockStyle.Fill;

            //}
            //TODO разобраться нужно ли создавать форму baseFormContainer, если нужно положить контейнер внутрь главной формы);
            if (m_MainForm != null)
            {
                //if (isModal)
                //    baseFormContainer.Owner = m_MainForm;
                baseFormContainer.Icon = m_MainForm.Icon;
            }


            //Control formContainer = GetFormLayout(form);
            baseFormContainer.ShowInTaskbar = !isModal;
            baseFormContainer.KeyPreview = true;
            baseFormContainer.MinimizeBox = !isModal;

            var basePanel = appForm as IBasePanel;
            //if (basePanel != null)
            //{
            //    baseFormContainer.ClientSize = new Size(container.Width, container.Height);
            //    container.Dock = DockStyle.Fill;
            //}

            if (baseFormContainer.Width > screenSize.Width)
            {
                if ((basePanel != null) && !appForm.Sizable)
                {
                    container.Location = new Point(0, 0);
                    container.Dock = DockStyle.None;
                }
                baseFormContainer.Width = screenSize.Width;
                baseFormContainer.Left = screenSize.Left;
            }
            if (baseFormContainer.Height > screenSize.Height)
            {
                if (!appForm.Sizable)
                {
                    container.Location = new Point(0, 0);
                    container.Dock = DockStyle.None;
                }
                baseFormContainer.Height = screenSize.Height;
                baseFormContainer.Top = screenSize.Top;
            }
            if (!appForm.Sizable)
            {
                baseFormContainer.AutoScroll = true;
            }
            baseFormContainer.KeyDown += appForm.BaseForm_KeyDown;
            baseFormContainer.Activated += OnFormActivate;
            baseFormContainer.Closing += OnFormClosing;
            //AddHandler baseFormContainer.KeyDown, AddressOf form.BaseFom_KeyDown
            //if ((form) is BasePanel)
            //{
            container.Parent = baseFormContainer;
            //}
            //DebugTimer.Start(string.Format("{0} set visible", form.GetType().Name));
            container.Visible = true;
            if (parameters != null)
            {
                if (basePanel != null)
                    basePanel.StartUpParameters = parameters;
                else if (ReflectionHelper.HasProperty(appForm, "StartUpParameters"))
                    ReflectionHelper.SetProperty(appForm, "StartUpParameters", parameters);
            }
            //DebugTimer.Stop();
            //form.ParentKey = ParentID;
            //form.StartUpParameters = Params;
            //form.ParentBaseForm = m_CurrentForm;
            //if (form is ISearchable)
            //{
            //    ((ISearchable)form).LoadSearchPanel();
            //    if (Params != null)
            //    {
            //        if (Params.ContainsKey("FromCondition"))
            //        {
            //            form.BusinessObject.ListFromCondition = Params["FromCondition"].ToString();
            //        }
            //        if (Params.ContainsKey("FilterCondition"))
            //        {
            //            form.BusinessObject.ListFilterCondition = Params["FilterCondition"].ToString();
            //        }
            //    }
            //}
            baseFormContainer.WindowState = FormWindowState.Normal; //form.DefaultFormState
            if (baseFormContainer != appForm)
                baseFormContainer.Text = appForm.Caption;
            return baseFormContainer;
        }

        private static int m_ModalFormCount;



        public static bool ShowModal_ReadOnly
            (IApplicationForm form, Control owner, ref object id, object parentID, Dictionary<string, object> @params, int width = 0,
                int height = 0)
        {
            if (form == null)
            {
                return false;
            }
            return ShowModal(form, owner, ref id, @params, true, width, height);
        }

        public static Form ShowModal
            (IApplicationForm appForm, IObject bo, Dictionary<string, object> parameters = null, int width = 0, int height = 0)
        {
            return Show(appForm, bo, true, bo.ReadOnly, parameters, width, height);
        }

        public static bool ShowModal(IApplicationForm form, Control owner)
        {
            object id = null;
            return ShowModal(form, owner, ref id, null, null);
        }

        public static IObject ShowForSelection
            (IBaseListPanel form, Control owner, Dictionary<string, object> @params = null, int width = 0, int height = 0)
        {
            object id = null;
            form.SelectMode = SelectMode.SimpleSelect;
            if (ShowModal(form as IApplicationForm, owner, ref id, null, @params, 1000, 700))
            {
                return form.FocusedItem;
            }
            return null;
        }

        public static IList<IObject> ShowForMultiSelection
            (IBaseListPanel form, Control owner, Dictionary<string, object> @params = null, int width = 0, int height = 0)
        {
            object id = null;
            form.SelectMode = SelectMode.MultiSelect;
            if (ShowModal(form as IApplicationForm, owner, ref id, null, @params, 1000, 700))
            {
                return form.SelectedItems;
            }
            return null;
        }

        public static bool ShowModal
            (IApplicationForm appForm, Control owner, ref object id, object parentID, Dictionary<string, object> @params, int width = 0,
                int height = 0)
        {
            return ShowModal(appForm, owner, ref id, @params, false, width, height);
        }

        private static bool ShowModal
            (IApplicationForm appForm, Control owner, ref object id, Dictionary<string, object> @params, bool readOnly, int width,
                int height)
        {
            if (appForm == null) return false;

            //if (!CanViewObject(form))
            //{
            //    return false;
            //}
            if (@params != null)
                appForm.StartUpParameters = @params;
            if (readOnly || ReadOnly)
                SetReadOnly(appForm, true);
            if (!LoadData(appForm, ref id))
                //it is important to call Load data before placing BasePanel to Layout, in other case default search filters are ignored for list forms
                return false;

            try
            {
                Form baseFormContainer;
                using (new WaitDialog())
                {
                    baseFormContainer = PrepareFormShowing(appForm, true, @params, width, height);
                    m_ModalFormCount++;
                    InitDesignManager(appForm);
                }
                var ret = baseFormContainer.ShowDialog(owner);

                FormDisposer.Add(appForm as Control);
                if (ret == DialogResult.OK)
                {
                    id = appForm.Key;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(StandardError.UnprocessedError, ex);
                return false;
            }
            finally
            {
                m_ModalFormCount--;
            }
        }


        public static int ModalFormCount
        {
            get { return m_ModalFormCount; }
        }

        public static Form ShowNormal
            (Type typeForm, ref object id, Dictionary<string, object> parameters = null, int width = 0, int height = 0)
        {
            if (typeForm == null) return null;
            using (new WaitDialog())
            {
                var o = ClassLoader.LoadClass(typeForm);
                return ShowNormal(o as IApplicationForm, ref id, parameters, width, height);

            }
        }

        public static Form ShowNormal
            (Type typeForm, IObject bo, Dictionary<string, object> parameters = null, int width = 0, int height = 0)
        {
            if (typeForm == null) return null;
            using (new WaitDialog())
            {
                var o = ClassLoader.LoadClass(typeForm);
                return ShowNormal(o as IApplicationForm, bo, parameters, width, height);
            }
        }

        public static Form ShowNormal
            (IApplicationForm appForm, ref object id, Dictionary<string, object> parameters = null, int width = 0, int height = 0)
        {
            if (appForm == null)
                return null;
            appForm.StartUpParameters = parameters;
            if (LoadData(appForm, ref id))
                return ShowNormal(appForm, null, parameters, width, height);
            return null;
        }

        public static Form ShowNormal_ReadOnly
            (IApplicationForm appForm, ref object id, Dictionary<string, object> parameters = null, int width = 0, int height = 0)
        {
            if (appForm == null)
                return null;
            appForm.StartUpParameters = parameters;
            if (LoadData(appForm, ref id))
                return ShowNormal(appForm, null, parameters, width, height, true);
            return null;
        }

        public static Form ShowNormal_ReadOnly
            (IApplicationForm appForm, IObject bo, Dictionary<string, object> parameters = null, int width = 0, int height = 0)
        {
            if (width < 0)
                width = ((Control)appForm).Width;
            if (height < 0)
                height = ((Control)appForm).Height;
            return Show(appForm, bo, false, true, parameters, width, height);
        }

        public static Form ShowNormal
            (IApplicationForm appForm, IObject bo, Dictionary<string, object> parameters = null, int width = 0, int height = 0,
                bool readOnly = false)
        {
            if (width < 0)
                width = ((Control)appForm).Width;
            if (height < 0)
                height = ((Control)appForm).Height;
            return Show(appForm, bo, false, readOnly, parameters, width, height);
        }

        private static Form Show
            (IApplicationForm appForm, IObject bo, bool isModal, bool readOnly, Dictionary<string, object> parameters = null, int width = 0,
                int height = 0)
        {
            if (appForm == null) return null;

            if (appForm is IBasePanel && bo == null)
                bo = ((IBasePanel)appForm).BusinessObject;
            var id = (bo != null && bo.Key != null) ? bo.Key : appForm.Key;

            if (!Register(appForm, id))
            {
                var frm = ((Control)m_CurrentForm).FindForm();
                if (frm != null)
                    return frm;
            }
            try
            {
                Form baseFormContainer;
                using (new WaitDialog())
                {
                    if (appForm is IBasePanel && ((IBasePanel)appForm).BusinessObject != bo)
                    {
                        var basePanel = (IBasePanel)appForm;
                        basePanel.BusinessObject = bo;
                    }

                    if (readOnly || ReadOnly) SetReadOnly(appForm, true);
                    baseFormContainer = PrepareFormShowing(appForm, false, parameters, width, height);

                    appForm.Activate();
                    InitDesignManager(appForm);
                }
                if (isModal)
                {
                    m_ModalFormCount++;
                    baseFormContainer.ShowDialog();
                    FormDisposer.Add(appForm as Control);
                }
                else
                {
                    baseFormContainer.Show();
                }
                baseFormContainer.BringToFront();
                //активируем форму и готовим её к отображению
                return baseFormContainer;
            }
            catch (Exception ex)
            {
                UnRegister(appForm);
                Dbg.Debug("error during form showing", ex.ToString());
                return null;
            }
            finally
            {
                if (isModal)
                    m_ModalFormCount--;

            }
        }

        private static void InitDesignManager(IApplicationForm form)
        {
            DesignControlManager.Create(form as ITranslationView);
        }
        private static void SetReadOnly(IApplicationForm form, bool readOnly)
        {
            if (form is IBasePanel)
                ((IBasePanel)form).ReadOnly = readOnly;
            else if (ReflectionHelper.HasProperty(form, "ReadOnly"))
                ReflectionHelper.SetProperty(form, "ReadOnly", readOnly);
        }

        #endregion

        private static bool m_ReadOnly;

        public static bool ReadOnly
        {
            get { return m_ReadOnly || ArchiveMode; }
            set { m_ReadOnly = value; }
        }

        public static bool ArchiveMode { get; set; }

        public static bool IsReportsServiceRunning
        {
            get
            {
                var assembly = Assembly.GetEntryAssembly();
                return assembly != null && assembly.FullName.ToLowerInvariant().Contains("eidss.reports.service");
            }
        }
        public static bool IsAvrServiceRunning
        {
            get
            {
                var assembly = Assembly.GetEntryAssembly();
                return assembly != null && assembly.FullName.ToLowerInvariant().Contains("eidss.avr.service");
            }
        }
    }
}
