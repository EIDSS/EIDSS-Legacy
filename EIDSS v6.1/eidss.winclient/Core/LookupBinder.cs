using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Localization;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Administration;
using eidss.winclient.Properties;
using FilterItem = DevExpress.XtraGrid.Views.Grid.FilterItem;
using FilterPopupListBoxEventArgs = DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs;

namespace eidss.winclient.Core
{
    public class LookupBinder
    {
        public delegate void RefreshCacheDelegate();

        private static readonly Dictionary<Type, LookupParams> m_LookupParams = new Dictionary<Type, LookupParams>();
        private static LookupParams GetLookupParam(Type t)
        {
            lock (m_LookupParams)
            {
                if (m_LookupParams.Count == 0)
                {

                    m_LookupParams.Add(typeof(DepartmentLookup),
                                       new LookupParams("DepartmentDetail", "DepartmentLookup",
                                                        EIDSSPermissionObject.Organization));
                    m_LookupParams.Add(typeof(PersonLookup),
                                       new LookupParams("PersonDetailPanel", "PersonLookup",
                                                        EIDSSPermissionObject.Person));
                    m_LookupParams.Add(typeof(OrganizationLookup),
                                       new LookupParams("OrganizationDetail", "OrganizationLookup",
                                                        EIDSSPermissionObject.Organization));
                    m_LookupParams.Add(typeof(BaseReferenceList),
                                       new LookupParams("VectorTypeReferenceMasterDetail", "rftVectorType",
                                                        EIDSSPermissionObject.Reference, 0));
                    m_LookupParams.Add(typeof(DiagnosisLookup),
                                       new LookupParams("DiagnosisReferenceDetail", "HumanDiagnoses,HumanVetDiagnoses,HumanStandardDiagnosis,AvianStandardDiagnosis,LivestockStandardDiagnosis,VetStandardDiagnosis,HumanAggregatedDiagnosis,AvianAggregatedDiagnosis,LivestockAggregatedDiagnosis,VetAggregatedDiagnosis,VectorDiagnosis,OutbreakDiagnoses,TuberculesisDiagnosis",
                                                        EIDSSPermissionObject.Reference, 0));
                    m_LookupParams.Add(typeof(DiagnosisAgeGroupLookup),
                                       new LookupParams("DiagnosisAgeGroupMasterDetail", "rftDiagnosisAgeGroup",
                                                        EIDSSPermissionObject.Reference, 0));
                    m_LookupParams.Add(typeof(VectorTypeLookup),
                                       new LookupParams("VectorTypeReferenceMasterDetail", "rftVectorType",
                                                        EIDSSPermissionObject.Reference, 0));
                }
                if (m_LookupParams.ContainsKey(t))
                    return m_LookupParams[t];
                return null;
            }
        }
        #region Private methods
        private static void AddButtonClickHandler(ButtonEdit cb, ButtonPressedEventHandler handler)
        {
            if (handler.Method.Name == "AddBaseReference")
            {
                if (!EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Reference)))
                {
                    cb.HidePlusButton();
                    return;
                }
            }
            try
            {
                cb.ButtonClick -= handler;
            }
            finally
            {
                cb.ButtonClick += handler;
            }
        }
        private static void AddButtonClickHandler(RepositoryItemButtonEdit cb, ButtonPressedEventHandler handler)
        {
            if (handler.Method.Name == "AddBaseReference")
            {
                if (!EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Reference)))
                {
                    cb.HidePlusButton();
                    return;
                }
            }
            try
            {
                cb.ButtonClick -= handler;
            }
            finally
            {
                cb.ButtonClick += handler;
            }
        }
        private static void AddKeyDownHandler(Control cb, KeyEventHandler handler)
        {
            try
            {
                cb.KeyDown -= handler;
            }
            finally
            {
                cb.KeyDown += handler;
            }
        }
        private static void AddKeyDownHandler(RepositoryItemButtonEdit cb, KeyEventHandler handler)
        {
            try
            {
                cb.KeyDown -= handler;
            }
            finally
            {
                cb.KeyDown += handler;
            }
        }
        private static void AddPlusButton(ButtonEdit cb)
        {
            if (cb.Properties.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Plus))
            {
                return;
            }
            cb.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
        }

        private static void AddPlusButton(RepositoryItemButtonEdit cb)
        {
            if (cb.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Plus))
            {
                return;
            }
            cb.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
        }
        private static void AddEditButton(ButtonEdit cb)
        {
            if (cb.Properties.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Ellipsis))
            {
                return;
            }
            cb.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
        }

        private static void AddPEditButton(RepositoryItemButtonEdit cb)
        {
            if (cb.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Ellipsis))
            {
                return;
            }
            cb.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
        }

        public static void AddClearButton(ButtonEdit cb, bool forceAddClearButton)
        {
            //return;
            //AddKeyDownHandler(cb, KeyDown);
            //WinUtils.SetClearTooltip(cb);
            //if (!forceAddClearButton && !BaseSettings.ShowClearLookupButton)
            //{
            //    return;
            //}
            //if (cb.Properties.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Delete))
            //{
            //    return;
            //}
            //cb.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete, BvMessages.Get("btnClear", "Clear the field contents")));
            //AddButtonClickHandler(cb, ClearLookup);

        }
        public static void AddClearButton(RepositoryItemButtonEdit cb, bool forceAddClearButton)
        {
            return;
            /*
            AddKeyDownHandler(cb, KeyDown);
            if (!forceAddClearButton && !BaseSettings.ShowClearRepositoryLookupButton)
                return;
            if (cb.Buttons.Cast<EditorButton>().Any(btn => btn.Kind == ButtonPredefines.Delete))
                return;
            cb.Buttons.Add(new EditorButton(ButtonPredefines.Delete, BvMessages.Get("btnClear", "Clear the field contents")));
            AddButtonClickHandler(cb, ClearLookup);
            */
        }

        public static void SetDataSource(LookUpEdit cb, object ds, string displayMember, string valueMember)
        {
            cb.Properties.DataSource = null;
            cb.Properties.DataSource = ds;
            cb.Properties.DisplayMember = displayMember;
            cb.Properties.ValueMember = valueMember;
            cb.Properties.NullText = String.Empty;
            cb.Properties.ShowDropDown = ShowDropDown.SingleClick;
        }
        public static void SetDataSource(GridLookUpEdit cb, object ds, string displayMember, string valueMember)
        {
            cb.Properties.DataSource = null;
            cb.Properties.DataSource = ds;
            cb.Properties.DisplayMember = displayMember;
            cb.Properties.ValueMember = valueMember;
            cb.Properties.NullText = String.Empty;
        }
        private static void SetDataSource(RepositoryItemLookUpEditBase cb, object ds, string displayMember, string valueMember)
        {
            cb.DataSource = ds;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;
            cb.NullText = String.Empty;
            AddLookupClosedHandler(cb);
        }
        public static void AddLookupClosedHandler(RepositoryItemLookUpEditBase cb)
        {
            try
            {
                cb.Closed -= RelositoryItemLookupEdit_Closed;
            }
            finally
            {
                cb.Closed += RelositoryItemLookupEdit_Closed;
            }
        }
        public static void RelositoryItemLookupEdit_Closed(object sender, ClosedEventArgs e)
        {
            var cb = (LookUpEditBase)sender;
            if ((cb.Parent) is GridControl)
            {
                ((GridControl)cb.Parent).FocusedView.PostEditor();
            }
            else if ((cb.Parent) is TreeList)
            {
                ((TreeList)cb.Parent).CloseEditor();
                ((TreeList)cb.Parent).EndCurrentEdit();
            }

        }
        public static void AddEditValueChangedHandler(BaseEdit edit)
        {
            try
            {
                edit.EditValueChanged -= BaseEdit_EditValueChanged;
            }
            finally
            {
                edit.EditValueChanged += BaseEdit_EditValueChanged;
            }
        }

        private static void BaseEdit_EditValueChanged(object sender, EventArgs e)
        {
            ((Control)sender).BeginInvoke(new MethodInvoker(delegate
            {
                if (((Control)sender).DataBindings.Count > 0)
                {
                    var binding = ((Control)sender).DataBindings[0];
                    binding.BindingManagerBase.EndCurrentEdit();
                    var panel = FindParentBasePanel((Control)sender);
                    if (panel != null)
                        panel.UpdateControlsState();
                }
            }));

        }
        private static IBasePanel FindParentBasePanel(Control sender)
        {
            var basePanel = sender as IBasePanel;
            if (basePanel != null)
                return basePanel;
            return sender.Parent != null ? FindParentBasePanel(sender.Parent) : null;
        }

        private static IBasePanel FindTopLevelBasePanel(Control sender)
        {
            if (sender.Parent != null)
            {
                if (sender.Parent is PopupContainerControl && ((PopupContainerControl)sender.Parent).OwnerEdit != null)
                {
                    return FindTopLevelBasePanel(((PopupContainerControl)sender.Parent).OwnerEdit);
                }
                IBasePanel panel = null;
                panel = FindTopLevelBasePanel(sender.Parent);
                if (panel == null && sender.Parent is IBasePanel)
                    panel = (IBasePanel)sender.Parent;
                return panel;
            }
            return null;
        }


        public static void AddBinding(LookUpEdit cb, object ds, string bindField, bool showClearButton)
        {
            cb.DataBindings.Clear();
            if (Utils.IsEmpty(bindField))
                cb.EditValue = null;
            else
            {
                Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
                var b = cb.DataBindings.Add("EditValue", ds, bindField, false, DataSourceUpdateMode.OnPropertyChanged);

            }
            if (showClearButton)
                AddClearButton(cb, false);
            //AddEditValueChangedHandler(cb);
        }

        private static void AddBinding(PopupContainerEdit popup, object ds, string bindField)
        {
            popup.DataBindings.Clear();
            if (Utils.IsEmpty(bindField))
                popup.EditValue = null;
            else
            {
                Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
                var b = popup.DataBindings.Add("EditValue", ds, bindField, false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }
        public static void AddBinding(ComboBoxEdit cb, object ds, string bindField, bool showClearButton)
        {
            cb.DataBindings.Clear();
            if (Utils.IsEmpty(bindField))
                cb.EditValue = null;
            else
            {
                Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
                var b = cb.DataBindings.Add("EditValue", ds, bindField, false, DataSourceUpdateMode.OnPropertyChanged);

            }
            if (showClearButton)
                AddClearButton(cb, false);
            //AddEditValueChangedHandler(cb);

        }

        public static void AddBinding(GridLookUpEdit cb, object ds, string bindField, bool showClearButton)
        {
            cb.DataBindings.Clear();
            if (Utils.IsEmpty(bindField))
                cb.EditValue = null;
            else
            {
                Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
                cb.DataBindings.Add("EditValue", ds, bindField, false, DataSourceUpdateMode.OnPropertyChanged);
            }
            if (showClearButton)
                AddClearButton(cb, false);
        }
        public static void BindTextEdit(TextEdit txt, object ds, string bindField)
        {
            txt.DataBindings.Clear();
            Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
            // ReSharper disable AssignNullToNotNullAttribute
            txt.DataBindings.Add("EditValue", ds, bindField, false, DataSourceUpdateMode.OnValidation);
            // ReSharper restore AssignNullToNotNullAttribute
            // ReSharper disable PossibleNullReferenceException
            var meta = ((IObject)ds).GetAccessor() as IObjectMeta;
            // ReSharper restore PossibleNullReferenceException
            if (meta != null)
            {
                var maxLen = meta.MaxSize(bindField);
                if (maxLen.HasValue && maxLen.Value > 0)
                {
                    txt.Properties.MaxLength = maxLen.Value;
                }

            }

            if (WinUtils.GetControlLanguage(txt) == "en")
            {
                txt.Properties.Mask.SetEnglishEditorMask();
            }
        }
        public static void BindMemoEdit(MemoEdit memo, object ds, string bindField)
        {
            memo.DataBindings.Clear();
            Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
            // ReSharper disable AssignNullToNotNullAttribute
            memo.DataBindings.Add("EditValue", ds, bindField, false, DataSourceUpdateMode.OnValidation);
            // ReSharper restore AssignNullToNotNullAttribute
            // ReSharper disable PossibleNullReferenceException
            var meta = ((IObject)ds).GetAccessor() as IObjectMeta;
            // ReSharper restore PossibleNullReferenceException
            if (meta != null)
            {
                var maxLen = meta.MaxSize(bindField);
                if (maxLen.HasValue && maxLen.Value > 0)
                {
                    memo.Properties.MaxLength = maxLen.Value;
                }

            }

            if (WinUtils.GetControlLanguage(memo) == "en")
            {
                memo.Properties.Mask.SetEnglishEditorMask();
            }
        }
        //public static int GetFieldLength(DataSet ds, string fieldName)
        //{
        //    string[] n = fieldName.Split(System.Convert.ToChar(".").ToString().ToCharArray());
        //    if (n.Length != 2)
        //    {
        //        throw (new SystemException("Invalid column specification: \'" + fieldName + "\'"));
        //    }
        //    DataTable table = ds.Tables[n[0]];
        //    if (table == null)
        //    {
        //        throw (new SystemException("no such table: \'" + n[0] + "\'"));
        //    }
        //    DataColumn col = table.Columns[n[1]];
        //    if (col == null)
        //    {
        //        throw (new SystemException("no such column \'" + n[1] + "\' in table \'" + n[0] + "\'"));
        //    }
        //    if (col.DataType == typeof(string) && col.MaxLength > 0)
        //    {
        //        return col.MaxLength;
        //    }
        //    return 0;
        //}


        //private static bool IsPrintButton(EditorButton btn)
        //{
        //    return btn.Kind == ButtonPredefines.Glyph; //AndAlso Not btn.Tag Is Nothing AndAlso TypeOf (btn.Tag) Is String AndAlso btn.Tag.ToString().StartsWith("print:")
        //}

        //Private Shared Sub AddPrintButton(ByVal cb As ButtonEdit)
        //    For Each btn As EditorButton In cb.Properties.Buttons
        //        If IsPrintButton(btn) Then
        //            Return
        //        End If
        //    Next
        //    Dim btn1 As EditorButton = New EditorButton(ButtonPredefines.Glyph)
        //    btn1.Image = Utils.LoadBitmapFromResource("EIDSS.print.gif", GetType(LookupBinder))
        //    cb.Properties.Buttons.Add(btn1)
        //End Sub
        //private static BaseLookupForm FindParentPopupContol(Control ctl)
        //{
        //    Control lookupCtl = ctl.Parent;
        //    while (lookupCtl != null)
        //    {
        //        if (lookupCtl is BaseLookupForm)
        //        {
        //            if (((BaseLookupForm)lookupCtl).LookupLayout == LookupFormLayout.DropDownList)
        //            {
        //                return ((BaseLookupForm)lookupCtl);
        //            }
        //        }
        //        else if (lookupCtl is PopupContainerControl)
        //        {
        //            PopupContainerControl pc = (PopupContainerControl)lookupCtl;
        //            if (pc.OwnerEdit != null)
        //            {
        //                return ((BaseLookupForm)pc.OwnerEdit.Parent);
        //            }
        //        }
        //        lookupCtl = lookupCtl.Parent;
        //    }
        //    return null;
        //}
        private static void AddPerson(object sender, ButtonPressedEventArgs e)
        {
            ShowReferenceEditor<PersonLookup>(sender, e);
        }


        #endregion

        #region Handlers
        //private ChangingEventHandler ClearingValueEventEvent;
        //public static event ChangingEventHandler ClearingValueEvent
        //{
        //    add
        //    {
        //        ClearingValueEventEvent +=value;
        //    }
        //    remove
        //    {
        //        ClearingValueEventEvent -=value;
        //    }
        //}

        private static void ClearLookup(object sender, ButtonPressedEventArgs e)
        {
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Delete)
                    {
                        if (!WinUtils.ConfirmLookupClear())
                            return;
                        var cb = (BaseEdit)sender;
                        var e1 = new ChangingEventArgs(cb.EditValue, null);
                        var mi = cb.GetType().GetMethod("OnEditValueChanging", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (mi != null)
                        {
                            mi.Invoke(cb, new object[] { e1 });
                            if (e1.Cancel)
                            {
                                return;
                            }
                        }
                        if (cb.DataBindings.Count > 0)
                        {
                            //TODO:correct this for BusinessObject
                            //DataRow row = BaseForm.GetControlCurrentRow(cb);
                            //if (row != null && !(row[cb.DataBindings[0].BindingMemberInfo.BindingField] == DBNull.Value))
                            //{
                            //    row.BeginEdit();
                            //    row[cb.DataBindings[0].BindingMemberInfo.BindingField] = DBNull.Value;
                            //    row.EndEdit();
                            //}
                        }
                        cb.EditValue = null;// DBNull.Value;
                    }
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }
        }

        private static void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Delete)
            {
                if (sender is BaseEdit)
                {
                    BaseEdit cb = (BaseEdit)sender;
                    cb.EditValue = DBNull.Value;
                    e.Handled = true;
                }
                else if (sender is RepositoryItemButtonEdit)
                {
                    var cb = (RepositoryItemButtonEdit)sender;
                    if (cb.OwnerEdit != null)
                    {
                        cb.OwnerEdit.EditValue = DBNull.Value;
                        WinUtils.SetClearTooltip(cb.OwnerEdit);
                    }
                    e.Handled = true;
                }
            }
        }

        private static void RefreshCache(string lookupName)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                LookupManager.ClearAndReload(manager, lookupName);
            }
        }
        public static object ShowBaseReferenceEditor(object sender, BaseReferenceType tableID)
        {
            object id = null;
            object bf = ClassLoader.LoadClass("ReferenceDetail");
            if (bf == null)
            {
                throw (new Exception("Can\'t load ReferenceDetail form"));
            }
            var startUpParam = new Dictionary<string, object> { { "ReferenceType", (long)tableID } };
            if (BaseFormManager.ShowModal((IApplicationForm)bf, ((Control)sender).FindForm(), ref id, null, startUpParam))
            {
                return id;
            }
            return null;
        }

        public static void AddBaseReference(object sender, ButtonPressedEventArgs e)
        {

            if (((BaseEdit)sender).Properties.ReadOnly)
            {
                return;
            }
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Plus)
                    {
                        var lookupList = (BaseReferenceList)((LookUpEdit)sender).Properties.DataSource;
                        var tableSection = lookupList.Section;
                        BaseReferenceType tableID;
                        if (Enum.TryParse(tableSection, out tableID))
                        {
                            object id = ShowBaseReferenceEditor(sender, tableID);
                            if (id != null)
                            {
                                RefreshCache(tableSection);
                                SetEditValueAsync(sender, id);
                            }
                        }
                    }
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }
        }

        //public static void AddSpecies(object sender, ButtonPressedEventArgs e)
        //{
        //TODO: implement this
        //if (((BaseEdit)sender).Properties.ReadOnly == true)
        //{
        //    return;
        //}
        //if (e.Button.Kind == ButtonPredefines.Plus)
        //{
        //    object ID = null;
        //    if (BaseForm.ShowModal(((BaseForm)(AppStructure.LoadControl("SpeciesTypeDetail"))), ((Control)sender).FindForm(), ID))
        //    {
        //        LookUpEdit cb = (LookUpEdit)sender;
        //        DataRow r = ((DataView)cb.Properties.DataSource).Table.Rows.Find(ID.ToString());
        //        if (r != null)
        //        {
        //            ((LookUpEdit)sender).EditValue = r[((LookUpEdit)sender).Properties.ValueMember]; //ID
        //            if (!(((LookUpEdit)sender).Parent == null))
        //            {
        //                if (((LookUpEdit)sender).Parent is DevExpress.XtraTreeList.TreeList)
        //                {
        //                    ((DevExpress.XtraTreeList.TreeList)(((LookUpEdit)sender).Parent)).ShowEditor();
        //                    ((DevExpress.XtraTreeList.TreeList)(((LookUpEdit)sender).Parent)).EditingValue = r[((LookUpEdit)sender).Properties.ValueMember]; //ID
        //                    ((DevExpress.XtraTreeList.TreeList)(((LookUpEdit)sender).Parent)).CloseEditor();
        //                    ((DevExpress.XtraTreeList.TreeList)(((LookUpEdit)sender).Parent)).EndCurrentEdit();
        //                }
        //            }
        //        }
        //        DataEventManager.SubmitCurrentEdit(cb);
        //    }
        //}
        //}
        public static void ShowReferenceEditor<T>(object sender, ButtonPressedEventArgs e)
        {
            if (((BaseEdit)sender).Properties.ReadOnly)
                return;
            var lookupParam = GetLookupParam(typeof(T));
            if (lookupParam == null)
                return;
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Plus)
                    {
                        if (
                            !EidssUserContext.User.HasPermission(
                                PermissionHelper.InsertPermission(lookupParam.Permission)))
                        {
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission",
                                                            "You have no rights to create this object"));
                            return;
                        }
                    }
                    else if (e.Button.Kind == ButtonPredefines.Ellipsis)
                    {
                        if (
                            !EidssUserContext.User.HasPermission(
                                PermissionHelper.UpdatePermission(lookupParam.Permission)))
                        {
                            MessageForm.Show(BvMessages.Get("msgNoUpdatePermission",
                                                            "You have no rights to edit this object"));
                            return;
                        }
                    }
                    else
                        return;
                    object id = null;
                    if (e.Button.Kind == ButtonPredefines.Ellipsis)
                    {
                        if (((BaseEdit)sender).EditValue != null)
                            id = ((IObject)((BaseEdit)sender).EditValue).Key;
                    }

                    var editor = ClassLoader.LoadClass(lookupParam.EditorName) as IApplicationForm;
                    if (editor != null && ReflectionHelper.HasMethod(editor, "ShowModal"))
                    {

                        var res = ReflectionHelper.InvokeMethod(editor, "ShowModal", new object[] { ((Control)sender).FindForm() });
                        if (true.Equals(res))
                        {
                            //string[] lookups = lookupParam.LookupCacheName.Split(new[] { ',' });
                            //foreach (var lookup in lookups)
                            //{
                            //    RefreshCache(lookup);
                            //}
                            if (((LookUpEdit)sender).Properties.DataSource is BaseReferenceList)
                                SetEditValueAsync(sender, editor.Key);
                            else
                                SetEditValueAsync<T>(sender, editor.Key);
                        }
                        return;
                    }

                    if (editor is IBasePanel)
                        id = lookupParam.DefaultId;

                    var pars = new Dictionary<string, object>();
                    pars.Add("NotDeleteAction", true);
                    if (sender is LookUpEdit)
                    {
                        var cb = (sender as LookUpEdit);
                        if (cb.Properties.Tag != null)
                        {
                            pars.Add("HACode", cb.Properties.Tag);
                        }
                    }

                    if (BaseFormManager.ShowModal(editor, ((Control)sender).FindForm(), ref id, null, pars))
                    {
                        string[] lookups = lookupParam.LookupCacheName.Split(new[] { ',' });
                        foreach (var lookup in lookups)
                        {
                            RefreshCache(lookup);
                        }
                        SetEditValueAsync<T>(sender, id);
                    }

                }
                catch (Exception ex)
                {
                    Dbg.Debug("error during reference edtor loading {0}: {1}", lookupParam.EditorName, ex);
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }

        }

        public static void AddVectorType(object sender, ButtonPressedEventArgs e)
        {
            ShowReferenceEditor<VectorTypeLookup>(sender, e);
        }
        public static void AddSampleType(object sender, ButtonPressedEventArgs e)
        {
            if (((BaseEdit)sender).Properties.ReadOnly)
                return;
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Plus)
                    {
                        if (!EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Reference)))
                        {
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"));
                            return;
                        }

                        object id = null;
                        if (BaseFormManager.ShowModal(((IApplicationForm)(ClassLoader.LoadClass("SampleTypeDetail"))), ((Control)sender).FindForm(), ref id, null, null))
                        {
                            var cb = (LookUpEdit)sender;

                            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                LookupManager.ClearAndReload(manager, "rftSampleType");
                            }
                            SetEditValueAsync(sender, id);
                        }
                    }
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }

        }

        public delegate void SetEditValueDelegate(object sender, object value);

        public static void SetEditValue(object sender, object id)
        {
            if (((LookUpEdit)sender).DataBindings.Count == 0)
            {
                ((BaseEdit)sender).EditValue = id;
                return;
            }
            var lookupList = (BaseReferenceList)((LookUpEdit)sender).Properties.DataSource;
            var value = lookupList.FirstOrDefault(c => c.idfsBaseReference.Equals(id));
            Application.DoEvents();
            if (value != null)
            {
                ((BaseEdit)sender).EditValue = value;
            }
        }
        public static void SetEditValue<T>(object sender, object id)
        {
            if (((LookUpEdit)sender).DataBindings.Count == 0)
            {
                ((BaseEdit)sender).EditValue = id;
                return;
            }
            var lookupList = (List<T>)((LookUpEdit)sender).Properties.DataSource;
            var value = lookupList.FirstOrDefault(c => ((IObject)c).Key.Equals(id));
            Application.DoEvents();
            if (value != null)
            {
                ((BaseEdit)sender).EditValue = value;
            }
        }
        public static void SetEditValueAsync<T>(object sender, object id)
        {
            if (!Utils.IsEmpty(id) && !id.Equals(0))
            {
                Application.DoEvents();
                ((LookUpEdit)sender).Invoke(new SetEditValueDelegate(SetEditValue<T>), new[] { sender, id });
            }

        }

        public static void SetPersonEditValue(object sender, object id)
        {
            SetEditValue<PersonLookup>(sender, id);
            //var lookupList = (List<PersonLookup>)((LookUpEdit)sender).Properties.DataSource;
            //var value = lookupList.FirstOrDefault(c => c.idfPerson.Equals(id));
            //Application.DoEvents();
            //if (value != null)
            //{
            //    ((BaseEdit)sender).EditValue = value;
            //}
        }
        public static void SetPersonEditValueAsync(object sender, object id)
        {
            if (!Utils.IsEmpty(id) && !id.Equals(0))
            {
                Application.DoEvents();
                ((LookUpEdit)sender).Invoke(new SetEditValueDelegate(SetPersonEditValue), new[] { sender, id });
            }
        }
        public static void SetOrganizationEditValue(object sender, object id)
        {
            SetEditValue<OrganizationLookup>(sender, id);
        }
        public static void SetOrganizationEditValueAsync(object sender, object id)
        {
            if (!Utils.IsEmpty(id) && !id.Equals(0))
            {
                Application.DoEvents();
                ((LookUpEdit)sender).Invoke(new SetEditValueDelegate(SetOrganizationEditValue), new[] { sender, id });
            }
        }
        public static void SetDepartmentEditValue(object sender, object id)
        {
            SetEditValue<DepartmentLookup>(sender, id);
        }
        public static void SetDepartmentEditValueAsync(object sender, object id)
        {
            if (!Utils.IsEmpty(id) && !id.Equals(0))
            {
                Application.DoEvents();
                ((LookUpEdit)sender).Invoke(new SetEditValueDelegate(SetDepartmentEditValue), new[] { sender, id });
            }
        }
        public static void SetEditValueAsync(object sender, object id)
        {
            if (!Utils.IsEmpty(id) && !id.Equals(0))
            {
                Application.DoEvents();
                ((LookUpEdit)sender).Invoke(new SetEditValueDelegate(SetEditValue), new[] { sender, id });
            }

        }

        #endregion

        //#region Control lookup properties
        //private static Hashtable m_LookupControls = new Hashtable();
        //public static string LookupTableName(Control ctl)
        //{
        //    return TagHelper.GetTagHelper(ctl).LookupTableName;
        //}
        //public static void SetLookupTableName(string Value, Control ctl)
        //{
        //    TagHelper.GetTagHelper(ctl).LookupTableName = Value;
        //}

        //public static string LookupTableName(RepositoryItemLookUpEdit ctl)
        //{
        //    return Utils.Str(m_LookupControls[ctl]);
        //}
        //public static void SetLookupTableName(string Value, RepositoryItemLookUpEdit ctl)
        //{
        //    if (m_LookupControls.Contains(ctl) == false)
        //    {
        //        ctl.Disposed += new System.EventHandler(Lookup_Disposed);
        //    }
        //    m_LookupControls[ctl] = Value;
        //}
        ////Private Shared Function GetLookupTableName(ByVal ctl As Object) As String
        ////    If TypeOf (ctl) Is Control Then
        ////        Return LookupTableName(CType(ctl, Control))
        ////    ElseIf TypeOf (ctl) Is RepositoryItemLookUpEdit Then
        ////        Return LookupTableName(CType(ctl, RepositoryItemLookUpEdit))
        ////    End If
        ////    Throw New Exception("Invalid looup object type")
        ////End Function

        //public static BaseReferenceType LookupTableID(Control ctl)
        //{
        //    TagHelper Tag = TagHelper.GetTagHelper(ctl);
        //    if (Utils.Str(Tag.LookupTableName) == "")
        //    {
        //        if (Tag.Tag != null && Tag.Tag is RepositoryItemLookUpEdit)
        //        {
        //            return LookupTableID((RepositoryItemLookUpEdit)Tag.Tag);
        //        }
        //    }
        //    return ((BaseReferenceType)(BaseReferenceType.Parse(typeof(BaseReferenceType), Tag.LookupTableName)));
        //}
        //public static void SetLookupTableID(BaseReferenceType Value, Control ctl)
        //{
        //    TagHelper.GetTagHelper(ctl).LookupTableName = Value.ToString();
        //}

        //public static BaseReferenceType LookupTableID(RepositoryItemLookUpEdit ctl)
        //{
        //    if (m_LookupControls.Contains(ctl))
        //    {
        //        return ((BaseReferenceType)(BaseReferenceType.Parse(typeof(BaseReferenceType), Utils.Str(m_LookupControls[ctl]))));
        //    }
        //    return null;
        //}
        //public static void SetLookupTableID(BaseReferenceType Value, RepositoryItemLookUpEdit ctl)
        //{
        //    SetLookupTableName(Value.ToString(), ctl);
        //}

        //private static void Lookup_Disposed(object sender, System.EventArgs e)
        //{
        //    m_LookupControls.Remove(sender);
        //}

        //private static BaseReferenceType GetLookupTableID(object ctl)
        //{
        //    if ((ctl) is Control)
        //    {
        //        return LookupTableID((Control)ctl);
        //    }
        //    else if ((ctl) is RepositoryItemLookUpEdit)
        //    {
        //        return LookupTableID((RepositoryItemLookUpEdit)ctl);
        //    }
        //    throw (new Exception("Invalid lookup object type"));

        //}

        ////--------------------Added by Olga 27.07.2007
        //public static string HACodeName(Control ctl)
        //{
        //    return TagHelper.GetTagHelper(ctl).HACodeName;
        //}
        //public static void SetHACodeName(string Value, Control ctl)
        //{
        //    TagHelper.GetTagHelper(ctl).HACodeName = Value;
        //}

        //private static Hashtable m_HACodeControls = new Hashtable();
        //public static string HACodeName(RepositoryItemLookUpEdit ctl)
        //{
        //    return Utils.Str(m_HACodeControls[ctl]);
        //}
        //public static void SetHACodeName(string Value, RepositoryItemLookUpEdit ctl)
        //{
        //    if (m_HACodeControls.Contains(ctl) == false)
        //    {
        //        ctl.Disposed += new System.EventHandler(HACode_Disposed);
        //    }
        //    m_HACodeControls[ctl] = Value;
        //}
        ////Private Shared Function GetHACodeName(ByVal ctl As Object) As String
        ////    If TypeOf (ctl) Is Control Then
        ////        Return HACodeName(CType(ctl, Control))
        ////    ElseIf TypeOf (ctl) Is RepositoryItemLookUpEdit Then
        ////        Return HACodeName(CType(ctl, RepositoryItemLookUpEdit))
        ////    End If
        ////    Throw New Exception("Invalid object HACode")
        ////End Function

        //private static void HACode_Disposed(object sender, System.EventArgs e)
        //{
        //    m_HACodeControls.Remove(sender);
        //}

        //public static HACode HACodeValue(Control ctl)
        //{
        //    TagHelper Tag = TagHelper.GetTagHelper(ctl);
        //    if (Utils.Str(Tag.HACodeName) == "")
        //    {
        //        if (Tag.Tag != null && Tag.Tag is RepositoryItemLookUpEdit)
        //        {
        //            return HACodeValue((RepositoryItemLookUpEdit)Tag.Tag);
        //        }
        //        else
        //        {
        //            return HACode.None;
        //        }
        //    }
        //    return ((HACode)(HACode.Parse(typeof(HACode), Tag.HACodeName)));
        //}
        //public static void SetHACodeValue(HACode Value, Control ctl)
        //{
        //    TagHelper.GetTagHelper(ctl).HACodeName = Value.ToString();
        //}

        //public static HACode HACodeValue(RepositoryItemLookUpEdit ctl)
        //{
        //    if (m_HACodeControls.Contains(ctl))
        //    {
        //        if (Utils.IsEmpty(m_HACodeControls[ctl]))
        //        {
        //            return HACode.None;
        //        }
        //        return ((HACode)(HACode.Parse(typeof(HACode), Utils.Str(m_HACodeControls[ctl]))));
        //    }
        //    return null;
        //}
        //public static void SetHACodeValue(HACode Value, RepositoryItemLookUpEdit ctl)
        //{
        //    SetHACodeName(Value.ToString(), ctl);
        //}

        //private static HACode GetHACode(object ctl)
        //{
        //    if ((ctl) is Control)
        //    {
        //        return HACodeValue((Control)ctl);
        //    }
        //    else if ((ctl) is RepositoryItemLookUpEdit)
        //    {
        //        return HACodeValue((RepositoryItemLookUpEdit)ctl);
        //    }
        //    throw (new Exception("Invalid object HACode"));
        //}

        //#endregion

        #region Base lookup binding
        private static void InitBaseLookup(LookUpEdit cb, List<BaseReference> lookupList)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.Properties.PopupWidth = 400;
            SetDataSource(cb, lookupList, "name", ""); //idfsBaseReference
        }
        public static void BindBaseLookup(LookUpEdit cb, object ds, string bindField, List<BaseReference> lookupList, bool showPlusButton = true, bool showClearButton = true)
        {
            InitBaseLookup(cb, lookupList);
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, AddBaseReference);
            }
            AddBinding(cb, ds, bindField, showClearButton);
        }
        public static void BindBaseLookup(LookUpEdit cb, object dataSource, string bindField, List<BaseReference> lookupList, ButtonPressedEventHandler addButtonHandler)
        {
            InitBaseLookup(cb, lookupList);
            if (addButtonHandler != null)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, addButtonHandler);
            }
            AddBinding(cb, dataSource, bindField, true);
        }

        public static void BindBaseLookup(RadioGroup rg, object ds, string bindField, List<BaseReference> lookupList)
        {
            rg.Properties.Items.Clear();
            foreach (var row in lookupList)
            {
                rg.Properties.Items.Add(new RadioGroupItem(row.idfsBaseReference, row.name));
            }
            rg.DataBindings.Clear();
            if (!Utils.IsEmpty(bindField))
            {
                rg.DataBindings.Add("EditValue", ds, bindField);
            }
        }

        public static void BindBaseLookup(CheckedListBoxControl cb, object ds, string bindField, List<BaseReference> lookupList)
        {
            cb.Items.Clear();
            foreach (var row in lookupList)
            {
                cb.Items.Add(new CheckedListBoxItem(row.idfsBaseReference, row.name));
            }
            cb.DataBindings.Clear();
            if (!Utils.IsEmpty(bindField) && (ds != null))
            {
                cb.DataBindings.Add("EditValue", ds, bindField);
            }
        }

        private static void InitBaseRepositoryLookup(RepositoryItemLookUpEdit cb, List<BaseReference> lookupList)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.PopupWidth = 400;
            SetDataSource(cb, lookupList, "name", "idfsBaseReference"); //"idfsReference"
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="lookupList"></param>
        /// <param name="showPlusButton"></param>
        /// <param name="showClearButton"></param>
        public static void BindBaseRepositoryLookup(RepositoryItemLookUpEdit cb, List<BaseReference> lookupList, bool showPlusButton = false, bool showClearButton = false)
        {
            InitBaseRepositoryLookup(cb, lookupList);
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, AddBaseReference);
            }
            AddClearButton(cb, showClearButton);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="lookupList"></param>
        /// <param name="addButtonHandler"></param>
        public static void BindBaseRepositoryLookup(RepositoryItemLookUpEdit cb, List<BaseReference> lookupList, ButtonPressedEventHandler addButtonHandler)
        {
            InitBaseRepositoryLookup(cb, lookupList);
            if (addButtonHandler != null)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, addButtonHandler);
            }
            AddClearButton(cb, false);
        }

        #endregion

        //#region CheckListBox Binding
        //public static void BindCheckListLookup(CheckedListBoxControl lst, DataTable dt, string valueMember, string displayMember, bool AddEmptyString, List<BaseReference> lookupList)
        //{
        //    if (AddEmptyString)
        //    {
        //        AddOtherValue(dt);
        //        try
        //        {
        //            lst.ItemChecking -= new ItemCheckingEventHandler(CheckList_ItemChecking);
        //        }
        //        finally
        //        {
        //            lst.ItemChecking += new ItemCheckingEventHandler(CheckList_ItemChecking);
        //        }
        //    }
        //    lst.DataSource =lookupList;
        //    lst.DisplayMember = displayMember;
        //    lst.ValueMember = valueMember;
        //    BasePanel bf = BaseForm.FindBaseForm(lst);
        //    //If bf.Created Then
        //    MarkCheckListBoxes(bf, lst);
        //    //End If
        //    if (bf != null)
        //    {
        //        try
        //        {
        //            bf.Load -= new System.EventHandler(CheckList_Load);
        //        }
        //        finally
        //        {
        //            bf.Load += new System.EventHandler(CheckList_Load);
        //        }
        //    }
        //    try
        //    {
        //        lst.ItemCheck -= new ItemCheckEventHandler(CheckList_ItemCheck);
        //    }
        //    finally
        //    {
        //        lst.ItemCheck += new ItemCheckEventHandler(CheckList_ItemCheck);
        //    }
        //}
        //public const string Other = "Other";
        //private static void AddOtherValue(DataTable dt)
        //{
        //    if (dt.Select(string.Format("idfsReference=\'{0}\'", Other)).Length == 0)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["idfsReference"] = Other;
        //        dt.Columns["Name"].ReadOnly = false;
        //        row["Name"] = EidssMessages.Get(Other);
        //        dt.Rows.Add(row);
        //        row.AcceptChanges();
        //    }

        //}

        //private static void CheckList_ItemChecking(object sender, ItemCheckingEventArgs e)
        //{
        //    CheckedListBoxControl lst = (CheckedListBoxControl)sender;
        //    BaseForm bf = BaseForm.FindBaseForm(lst);
        //    if (bf == null || bf.Loading)
        //    {
        //        return;
        //    }
        //    DataTable dt = ((DataView)lst.DataSource).Table;
        //    TagHelper t = new TagHelper(lst);
        //    BaseReferenceType TableId = (BaseReferenceType)t.IntTag;

        //    if (dt.Rows[e.Index]["idfsReference"].ToString() == LookupBinder.Other && TableId != BaseReferenceType.rftNone)
        //    {
        //        e.Cancel = true;
        //        object ID = LookupBinder.ShowBaseReferenceEditor(sender, TableId);
        //        if (ID != null)
        //        {
        //            //Currently this chek list boxes are not using in the program
        //            //if there will be need in this the commented text should be rewwritten for using with LookupCache
        //            //Using ds As New DataSet()
        //            //    Lookup_Db.FillBaseLookup(ds, TableId)
        //            //    For Each r As DataRow In ds.Tables(0).Rows
        //            //        If dt.Select(String.Format("idfsReference={0}", r("idfsReference"))).Length = 0 Then
        //            //            dt.BeginLoadData()
        //            //            Dim dr As DataRow = dt.NewRow()
        //            //            dr("idfsReference") = r("idfsReference")
        //            //            dr("Name") = r("Name")
        //            //            dr("intStatus") = 1
        //            //            dt.Rows.Add(dr)
        //            //            dt.EndLoadData()
        //            //        End If
        //            //    Next
        //            //    DbDisposeHelper.ClearDataset(ds)
        //            //End Using
        //            lst.BeginUpdate();
        //            int i = 0;
        //            while (!(lst.GetItem(i) == null))
        //            {
        //                lst.SetItemChecked(i, System.Convert.ToBoolean((true.Equals(lst.GetItemValue(i))) ? true : false));
        //                i++;
        //            }
        //            lst.EndUpdate();
        //        }
        //    }
        //}
        //private static void CheckList_Load(object sender, System.EventArgs e)
        //{
        //    BaseForm bf = (BaseForm)sender;
        //    VisitCheckLlists(bf, bf);
        //}

        //private static void VisitCheckLlists(BaseForm bf, Control parentCtl)
        //{
        //    foreach (Control ctl in parentCtl.Controls)
        //    {
        //        if (ctl is CheckedListBoxControl)
        //        {
        //            MarkCheckListBoxes(bf, (CheckedListBoxControl)ctl);
        //        }
        //        else
        //        {
        //            VisitCheckLlists(bf, ctl);
        //        }
        //    }

        //}
        //public static void MarkCheckListBoxes(BaseForm bf, CheckedListBoxControl lst)
        //{
        //    bf.BeginUpdate();
        //    int i = 0;
        //    if (lst.DataSource != null && ((DataView)lst.DataSource).Count > 0)
        //    {
        //        lst.BeginUpdate();
        //        while (!(lst.GetItem(i) == null))
        //        {
        //            lst.SetItemChecked(i, System.Convert.ToBoolean((true.Equals(lst.GetItemValue(i))) ? true : false));
        //            i++;
        //        }
        //        lst.EndUpdate();
        //    }
        //    bf.EndUpdate();

        //}

        //private static void CheckList_ItemCheck(System.Object sender, ItemCheckEventArgs e)
        //{
        //    CheckedListBoxControl lst = (CheckedListBoxControl)sender;
        //    //Dim bf As BaseForm = BaseForm.FindBaseForm(lst)
        //    //If bf Is Nothing OrElse bf.Loading Then Return
        //    //If bf.Loading Then Return
        //    DataTable dt = ((DataView)lst.DataSource).Table;
        //    dt.Rows[e.Index]["intStatus"] = e.State == CheckState.Checked;
        //}

        //#endregion

        #region Special Bindings

        public static void BindCountryLookup(LookUpEdit cb, object ds, string bindField, List<CountryLookup> countryLookup)
        {
            cb.Properties.Columns.Clear();

            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("strCountryName", EidssMessages.Get("colCountryName", "Country Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.Properties.PopupWidth = cb.Width;
            SetDataSource(cb, countryLookup, "strCountryName", null);//"idfsCountry"
            AddBinding(cb, ds, bindField, true);
        }
        public static void BindCountryRepositoryLookup(RepositoryItemLookUpEdit cb, List<CountryLookup> countryLookup)
        {
            cb.Columns.Clear();

            cb.Columns.AddRange(new[] { new LookUpColumnInfo("strCountryName", EidssMessages.Get("colCountryName", "Country Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.PopupWidth = 400;
            SetDataSource(cb, countryLookup, "strCountryName", "");//idfsCountry
        }

        public static void BindRegionLookup(LookUpEdit cb, object ds, string bindField, List<RegionLookup> regionLookup)
        {
            cb.Properties.Columns.Clear();

            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("strRegionName", EidssMessages.Get("colRegionName", "Region Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });

            cb.Properties.PopupWidth = cb.Width;
            SetDataSource(cb, regionLookup, "strRegionName", null);//idfsRegion
            AddBinding(cb, ds, bindField, true);
        }
        public static void BindRegionRepositoryLookup(RepositoryItemLookUpEdit cb, List<RegionLookup> regionLookup)
        {
            cb.Columns.Clear();

            cb.Columns.AddRange(new[] { new LookUpColumnInfo("strRegionName", EidssMessages.Get("colRegionName", "Region Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });

            cb.PopupWidth = 400;
            SetDataSource(cb, regionLookup, "strRegionName", "");//idfsRegion
        }

        public static void BindRayonLookup(LookUpEdit cb, object ds, string bindField, List<RayonLookup> rayonLookup)
        {
            cb.Properties.Columns.Clear();

            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("strRayonName", EidssMessages.Get("colRayonName", "Rayon Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });

            cb.Properties.PopupWidth = cb.Width;
            SetDataSource(cb, rayonLookup, "strRayonName", null);//idfsRayon
            AddBinding(cb, ds, bindField, true);
        }

        public static void BindRayonRepositoryLookup(RepositoryItemLookUpEdit cb, List<RayonLookup> rayonLookup)
        {
            cb.Columns.Clear();

            cb.Columns.AddRange(new[] { new LookUpColumnInfo("strRayonName", EidssMessages.Get("colRayonName", "Rayon Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });

            cb.PopupWidth = 400;
            SetDataSource(cb, rayonLookup, "strRayonName", "");//idfsRayon
        }

        public static void BindSettlementLookup(LookUpEdit cb, object ds, string bindField, List<SettlementLookup> settlementLookup)
        {
            cb.Properties.Columns.Clear();

            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("strSettlementName", EidssMessages.Get("colSettlementName", "Settlement Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.Properties.PopupWidth = cb.Width;
            SetDataSource(cb, settlementLookup, "strSettlementName", "");//idfsSettlement
            AddBinding(cb, ds, bindField, true);
            //var val = GetBindedValue(cb);
            //if (!Utils.IsEmpty(bindField) && !Utils.IsEmpty(val))
            //    ((DataView)cb.Properties.DataSource).RowFilter = String.Format("(intRowStatus = 0 or {0} = {1})", bindField, val);
            //else
            //    ((DataView)cb.Properties.DataSource).RowFilter = String.Format("intRowStatus = 0");

        }

        private static object GetBindedValue(LookUpEdit lookup)
        {
            if (lookup.DataBindings.Count > 0 &&
               lookup.DataBindings[0].BindingManagerBase != null &&
               lookup.DataBindings[0].BindingManagerBase.Position >= 0)
            {
                var bo = lookup.DataBindings[0].BindingManagerBase.Current as IObject;
                if (bo != null)
                    return bo.GetValue(lookup.DataBindings[0].BindingMemberInfo.BindingField);
            }

            else
            {
                var list = lookup.DataBindings[0].DataSource as List<IObject>;
                if (list != null && list.Count > 0)
                {
                    return list[0].GetValue(lookup.DataBindings[0].BindingMemberInfo.BindingField);
                }
            }
            return null;
        }

        public static void BindSettlementRepositoryLookup(RepositoryItemLookUpEdit cb, List<SettlementLookup> settlementLookup)
        {
            cb.Columns.Clear();

            cb.Columns.AddRange(new[] { new LookUpColumnInfo("strSettlementName", EidssMessages.Get("colSettlementName", "Settlement Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });

            cb.PopupWidth = 400;
            SetDataSource(cb, settlementLookup, "strSettlementName", "");//idfsSettlement
        }

        public static void BindPersonLookup(LookUpEdit cb, object ds, string bindField, List<PersonLookup> personLookup, HACode haCode, bool showClearButton = true, bool showEditButton = false)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("FullName", EidssMessages.Get("colPersonFullName", "Name"), 200), new LookUpColumnInfo("Organization", EidssMessages.Get("strOrganization", "Organization"), 80), new LookUpColumnInfo("Position", EidssMessages.Get("colPosition", "Position"), 50) });
            cb.Properties.PopupWidth = 350;
            SetDataSource(cb, personLookup, "FullName", "");//idfPerson

            AddPlusButton(cb);
            cb.Properties.Tag = haCode;
            AddButtonClickHandler(cb, AddPerson);
            if (showEditButton)
            {
                AddEditButton(cb);
                AddButtonClickHandler(cb, AddPerson);

            }
            AddBinding(cb, ds, bindField, showClearButton);
        }

        public static void BindSiteLookup(LookUpEdit cb, object ds, string bindField, List<SiteLookup> siteLookup, bool showClearButton = true)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[]
                                               {
                                                   new LookUpColumnInfo("strSiteName",EidssMessages.Get("colSiteName", "Name"), 80)
                                                   ,new LookUpColumnInfo("strSiteType",  EidssFields.Get("strSiteType", "Site Type"), 150)
                                                   ,new LookUpColumnInfo("strHASCsiteID", EidssMessages.Get("colSiteID", "Site ID"), 150)
                                               });
            cb.Properties.PopupWidth = 350;
            SetDataSource(cb, siteLookup, "strSiteName", "");//idfPerson

            //AddPlusButton(cb);
            //AddButtonClickHandler(cb, AddPerson);
            AddBinding(cb, ds, bindField, showClearButton);
        }

        public static void BindLookup<T>(LookUpEdit cb, object ds, string bindField, List<T> lookup, bool showClearButton = true)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.Properties.PopupWidth = 350;
            SetDataSource(cb, lookup, "name", "");
            AddBinding(cb, ds, bindField, showClearButton);
        }

        public static void BindRepositoryLookup<T>(RepositoryItemLookUpEdit cb, string valueMember, string displayMember, List<T> lookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo(displayMember, EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.PopupWidth = 350;
            SetDataSource(cb, lookup, displayMember, valueMember);
        }

        public static void BindRepositoryLookup<T>(RepositoryItemLookUpEdit cb, List<T> lookup)
        {
            BindRepositoryLookup(cb, "idfsReference", "name", lookup);
        }
      public static void BindPersonRepositoryLookup(RepositoryItemLookUpEdit cb, List<PersonLookup> personLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo("FullName", EidssMessages.Get("colPersonFullName", "Name"), 200), new LookUpColumnInfo("Organization", EidssMessages.Get("strOrganization", "Organization"), 80), new LookUpColumnInfo("Position", EidssMessages.Get("colPosition", "Position"), 50) });
            cb.PopupWidth = 400;
            SetDataSource(cb, personLookup, "FullName", "idfPerson");//
            AddPlusButton(cb);
            AddButtonClickHandler(cb, AddPerson);
        }

        public static void BindSpeciesVectorInfoRepositoryLookup(RepositoryItemLookUpEdit cb, List<SpeciesVectorInfoLookup> speciesLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo("SpeciesOrVectorType", EidssMessages.Get("colSpeciesOrVectorType", "Species/Vector Type"), 100), 
                    new LookUpColumnInfo("AnimalOrVectorSpecies", EidssMessages.Get("colAnimalOrVectorSpecies", "Animal ID/Vector Species"), 100),
                });
            cb.PopupWidth = 400;
            SetDataSource(cb, speciesLookup, "name", "");//idfSpeciesVectorInfo
        }

        public static string GetControlBindingField(Control ctrl)
        {
            if (ctrl.DataBindings.Count == 0)
            {
                return null;
            }
            return ctrl.DataBindings[0].BindingMemberInfo.BindingField;
        }

        private static void AddOrganization(object sender, ButtonPressedEventArgs e)
        {
            if (((BaseEdit)sender).Properties.ReadOnly)
            {
                return;
            }
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Plus)
                    {
                        if (!EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Organization)))
                        {
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"));
                            return;
                        }
                        object id = null;
                        if (BaseFormManager.ShowModal(((IApplicationForm)(ClassLoader.LoadClass("OrganizationDetail"))), ((Control)sender).FindForm(), ref id, null, null))
                        {
                            var cb = (LookUpEdit)sender;
                            if (cb.Tag != null && cb.Tag is RefreshCacheDelegate)
                                ((RefreshCacheDelegate)cb.Tag)();

                            RefreshCache("OrganizationLookup");
                            SetOrganizationEditValueAsync(sender, id);

                        }
                    }
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }
        }

        private static void AddOrganizationSearchButton(EditorButtonCollection buttons, HACode haCode)
        {
            var btn = buttons.Cast<EditorButton>().FirstOrDefault(b => b.Kind == ButtonPredefines.Glyph);
            if (btn != null)
            {
                btn.Tag = (int)haCode;
                return;
            }
            btn = new EditorButton(ButtonPredefines.Glyph) { Image = Resources.Browse5 };
            btn.Tag = (int)haCode;
            buttons.Add(btn);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        private static void AddOutbreakSearchButton(EditorButtonCollection buttons)
        {
            if (buttons.Cast<EditorButton>().Any(b => b.Kind == ButtonPredefines.Glyph)) return;
            var btn = new EditorButton(ButtonPredefines.Glyph) { Image = Resources.Browse5 };
            buttons.Insert(0, btn);
        }

        private static void SearchOrganization(object sender, ButtonPressedEventArgs e)
        {
            if (((BaseEdit)sender).Properties.ReadOnly)
                return;
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Glyph)
                    {
                        int haCode = 0;
                        if (e.Button.Tag != null)
                            haCode = (int)e.Button.Tag;
                        var param = new Dictionary<string, object>();
                        if (haCode != 0)
                            param.Add("HACode", haCode);
                        var filter = new FilterParams();
                        filter.Add("intHACode", "&", haCode);
                        var orgList = ClassLoader.LoadClass("OrganizationListPanel") as IBaseListPanel;
                        if (orgList != null)
                        {
                            orgList.InitialSearchFilter = filter;
                            var bo = BaseFormManager.ShowForSelection(orgList, ((Control)sender).FindForm(), param);
                            if (bo != null)
                            {
                                var cb = (LookUpEdit)sender;
                                if (Utils.IsEmpty(cb.Properties.ValueMember))
                                {
                                    var selected = ((List<OrganizationLookup>)cb.Properties.DataSource).Find(c => c.idfInstitution == (long)bo.Key);
                                    if (selected == null)
                                    {
                                        var listItem = (OrganizationListItem)bo;
                                        selected = OrganizationLookup.CreateInstance();

                                        selected.idfInstitution = listItem.idfInstitution;
                                        selected.FullName = listItem.FullName;
                                        selected.name = listItem.name;

                                        ((List<OrganizationLookup>)cb.Properties.DataSource).Add(selected);

                                    }
                                    cb.EditValue = selected;
                                }
                                else
                                    cb.EditValue = bo.Key;

                            }
                        }
                    }
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }
        }

        /// <summary>
        /// Настройка контрола ввода outbreaks
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="bindField"></param>
        public static void BindOutbreakLookup(ButtonEdit cb, object dataSource, string bindField)
        {
            //для вспышек заболеваний тоже можно использовать этот метод
            AddOutbreakSearchButton(cb.Properties.Buttons);
            cb.DataBindings.Clear();
            Dbg.Assert(true, "datasource for binding field {0} is not defined", bindField);
            // ReSharper disable AssignNullToNotNullAttribute
            cb.DataBindings.Add("EditValue", dataSource, bindField, false, DataSourceUpdateMode.OnValidation);
        }

        public static void BindOrganizationLookup(LookUpEdit cb, object dataSource, string bindField, List<OrganizationLookup> organizationLookup, HACode haCode, bool showPlusButton = true, RefreshCacheDelegate refreshCache = null)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colOrganizationShortName", "Short Name"), 150), new LookUpColumnInfo("FullName", EidssMessages.Get("strOrganization", "Organization"), 200) });
            cb.Properties.PopupWidth = 350;
            SetDataSource(cb, organizationLookup, "name", "");//idfInstitution
            AddOrganizationSearchButton(cb.Properties.Buttons, haCode);
            AddButtonClickHandler(cb, SearchOrganization);
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, AddOrganization);
                cb.Tag = refreshCache;
            }
            AddBinding(cb, dataSource, bindField, true);
        }

        /// <summary>
        /// Выбор из списка векторов
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="bindField"></param>
        /// <param name="vectorLookup"></param>
        public static void BindVectorTypesLookup(LookUpEdit cb, Vector dataSource, string bindField, List<VectorTypeLookup> vectorLookup)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("strTranslatedName", EidssMessages.Get("colName", "Name"), 100)
                    });
            cb.Properties.PopupWidth = 380;
            SetDataSource(cb, vectorLookup, "strTranslatedName", String.Empty);//idfVector
            AddBinding(cb, dataSource, bindField, true);
            //cb.EditValue = dataSource.HostVector; это зачем вообще?
        }

        /// <summary>
        /// Выбор из списка векторов
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="vectorLookup"></param>
        public static void BindVectorTypesRepositoryLookup(RepositoryItemLookUpEdit cb, List<VectorTypeLookup> vectorLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("strTranslatedName", EidssMessages.Get("colName", "Name"), 100)
                    });
            cb.PopupWidth = 380;
            SetDataSource(cb, vectorLookup, "strTranslatedName", "idfsBaseReference");
        }

        /// <summary>
        /// Выбор из списка векторов
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="bindField"></param>
        /// <param name="vectorLookup"></param>
        public static void BindVectorsLookup(LookUpEdit cb, Vector dataSource, string bindField, List<Vector> vectorLookup)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(
                new[]
                    {
                        //new LookUpColumnInfo("idfVector", EidssFields.Get("idfVector", "idfVector"), 80,FormatType.None, String.Empty, false, HorzAlignment.Default)
                        //,
                        new LookUpColumnInfo("strVectorID", EidssFields.Get("strVectorID", "Vector ID"), 100)
                        , new LookUpColumnInfo("strVectorType", EidssFields.Get("idfsVectorType", "Vector type"), 100)
                        , new LookUpColumnInfo("strSpecies", EidssFields.Get("Species", "Species"), 100)
                    });
            cb.Properties.PopupWidth = 380;
            SetDataSource(cb, vectorLookup, "strVectorID", "");//idfVector
            AddBinding(cb, dataSource, bindField, true);
            cb.EditValue = dataSource.HostVector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="bindField"></param>
        /// <param name="collectionMethodLookup"></param>
        public static void BindCollectionMethodLookup(LookUpEdit cb, Vector dataSource, string bindField, List<CollectionMethodLookup> collectionMethodLookup)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("CMName", EidssMessages.Get("colName", "Name"), 100)
                    });
            cb.Properties.PopupWidth = 380;
            SetDataSource(cb, collectionMethodLookup, "CMName", "");//idfsCollectionMethod
            AddBinding(cb, dataSource, bindField, true);
            cb.EditValue = dataSource.CollectionMethod;
        }

        public static void BindVectorSubTypeLookup(LookUpEdit cb, Vector dataSource, string bindField, List<VectorSubTypeLookup> vectorSubTypeLookup)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.Properties.PopupWidth = 380;
            SetDataSource(cb, vectorSubTypeLookup, "name", "");//idfVector
            AddBinding(cb, dataSource, bindField, true);
        }

        public static void BindVectorSubTypeRepositoryLookup(RepositoryItemLookUpEdit cb, List<VectorSubTypeLookup> vectorSubTypeLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", true, HorzAlignment.Near) });
            cb.PopupWidth = 380;
            SetDataSource(cb, vectorSubTypeLookup, "name", "idfsBaseReference");
        }

        public static void BindOrganizationRepositoryLookup(RepositoryItemLookUpEdit cb, List<OrganizationLookup> organizationLookup, HACode haCode, string valueMember = "idfInstitution")
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colOrganizationShortName", "Short Name"), 150), new LookUpColumnInfo("FullName", EidssMessages.Get("strOrganization", "Organization"), 200) });
            cb.PopupWidth = 350;
            SetDataSource(cb, organizationLookup, "name", valueMember);//valueMember
            AddOrganizationSearchButton(cb.Buttons, haCode);
            AddButtonClickHandler(cb, SearchOrganization);
            AddPlusButton(cb);
            AddButtonClickHandler(cb, AddOrganization);
        }

        //private static int GetDiagnosisHACode(List<DiagnosisLookup> diagnosisLookup)
        //{
        //    int code = System.Convert.ToInt32(HACode.None);
        //    try
        //    {
        //        LookupTableInfo t = LookupCache.LookupTables(DiagnosisType.ToString());
        //        object stored = t.Parameters("@HACode");
        //        if ((stored) is HACode)
        //        {
        //            code = System.Convert.ToInt32(stored);
        //        }
        //        else
        //        {
        //            code = int.Parse(stored.ToString());
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //    }
        //    return code;
        //}

        private static void CreateDiagnosisColumns(RepositoryItemLookUpEdit cb, bool showICDColumn, bool showOIEColumn)
        {
            cb.Columns.Clear();
            cb.Columns.Add(new LookUpColumnInfo("name", EidssMessages.Get("colDiseaseName", "Diagnosis"), 200, FormatType.None, String.Empty, true, HorzAlignment.Near));
            if (showICDColumn) cb.Columns.Add(new LookUpColumnInfo("strIDC10", EidssMessages.Get("colIDC10"), 200, FormatType.None, String.Empty, true, HorzAlignment.Near));
            if (showOIEColumn) cb.Columns.Add(new LookUpColumnInfo("strOIECode", EidssMessages.Get("colOIECode"), 200, FormatType.None, String.Empty, true, HorzAlignment.Near));


            /*
            if (showAdditionalColumns == false)
            {
                return;
            }
            if (((HACode)aHACode & HACode.Human) == HACode.Human)
            {
                cb.Columns.Add(new LookUpColumnInfo("strIDC10", EidssMessages.Get("colIDC10"), 200, FormatType.None, "", true, HorzAlignment.Near));
            }
            if (((HACode)aHACode & HACode.Avian & HACode.Livestock) != 0)
            {
                cb.Columns.Add(new LookUpColumnInfo("strOIECode", EidssMessages.Get("colOIECode"), 200, FormatType.None, "", true, HorzAlignment.Near));
            }
            */
        }

        //public static void BindDiagnosisLookup(LookUpEdit cb, DataSet ds, string BindField, bool ShowAdditionalColumns)
        //{
        //    CreateDiagnosisColumns(cb.Properties, GetDiagnosisHACode(LookupTables.HumanVetDiagnoses), ShowAdditionalColumns);
        //    cb.Properties.PopupWidth = 500;
        //    SetDataSource(cb, LookupCache.Get(LookupTables.HumanVetDiagnoses), "Name", "idfsDiagnosis");
        //    AddBinding(cb, ds, BindField, true);
        //}

        //public static void BindDiagnosisHACodeRepositoryLookup(RepositoryItemLookUpEdit cb, LookupTables DiagnosisType, bool ShowAdditionalColumns, bool ShowClearButton, string displayMember)
        //{
        //    CreateDiagnosisColumns(cb, GetDiagnosisHACode(DiagnosisType), ShowAdditionalColumns);

        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(DiagnosisType), displayMember, "idfsDiagnosis");
        //    if (ShowClearButton)
        //    {
        //        AddClearButton(cb, true);
        //    }
        //}

        public static void BindDiagnosisHACodeLookup(LookUpEdit cb, object ds, List<DiagnosisLookup> diagnosisLookup, string bindField, HACode aHACode, bool showICDColumn = false, bool showOIEColumn = false, bool showClearButton = true, bool showPlusButton = false)
        {
            CreateDiagnosisColumns(cb.Properties, showICDColumn, showOIEColumn);
            cb.Properties.PopupWidth = 500;
            SetDataSource(cb, diagnosisLookup, "name", "");//"idfsDiagnosis"
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, ShowReferenceEditor<DiagnosisLookup>);
            }
            if (showClearButton)
            {
                AddClearButton(cb, true);
            }
            AddBinding(cb, ds, bindField, true);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="cb"></param>
        ///// <param name="dataSource"></param>
        ///// <param name="bindField"></param>
        ///// <param name="diagnosisAgeGroupLookup"></param>
        public static void BindDiagnosisAgeGroupRepositoryLookup(RepositoryItemLookUpEdit cb, List<DiagnosisAgeGroupLookup> diagnosisAgeGroupLookup, bool showPlusButton)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("idfsDiagnosisAgeGroup", EidssFields.Get("idfsDiagnosisAgeGroup", "idfsDiagnosisAgeGroup"), 80,FormatType.None, String.Empty, false, HorzAlignment.Default)
                        , new LookUpColumnInfo("DiagnosisAgeGroupNameTranslated", EidssFields.Get("DiagnosisAgeGroupNameTranslated", "Name"), 100)
                    });
            cb.PopupWidth = 380;
            SetDataSource(cb, diagnosisAgeGroupLookup, "DiagnosisAgeGroupNameTranslated", "idfsDiagnosisAgeGroup");
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, ShowReferenceEditor<DiagnosisAgeGroupLookup>);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="bindField"></param>
        /// <param name="diagnosisAgeGroupLookup"></param>
        /// <param name="showPlusButton"></param>
        public static void BindDiagnosisAgeGroupLookup(LookUpEdit cb, Object dataSource, string bindField, List<DiagnosisAgeGroupLookup> diagnosisAgeGroupLookup, bool showPlusButton)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("idfsDiagnosisAgeGroup", EidssFields.Get("idfsDiagnosisAgeGroup", "idfsDiagnosisAgeGroup"), 80,FormatType.None, String.Empty, false, HorzAlignment.Default)
                        , new LookUpColumnInfo("DiagnosisAgeGroupNameTranslated", EidssFields.Get("DiagnosisAgeGroupNameTranslated", "Name"), 100)
                    });
            cb.Properties.PopupWidth = 380;
            SetDataSource(cb, diagnosisAgeGroupLookup, "DiagnosisAgeGroupNameTranslated", "idfsDiagnosisAgeGroup");
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, ShowReferenceEditor<DiagnosisAgeGroupLookup>);
            }
            //AddBinding(cb, dataSource, bindField, true);
            //cb.EditValue = dataSource.DiagnosisAgeGroup;
        }


        public static void BindRepositoryGridLookup<T>(RepositoryItemGridLookUpEdit cb, List<T> list, string displayMember = "name", string valueMember = "idfsReference")
        {
            cb.View.Columns.Clear();
            cb.View.Columns.Add(new GridColumn() { FieldName = displayMember, Caption = BvMessages.Get("colName"), Width = 200, Visible = true });
            cb.View.OptionsView.ShowIndicator = false;
            cb.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
            cb.PopupFormWidth = 400;
            SetDataSource(cb, list, displayMember, valueMember);
        }

        public static void BindDiagnosisRepositoryLookup(RepositoryItemLookUpEdit cb, List<DiagnosisLookup> diagnosisLookup, HACode aHACode, string displayMember = "name", bool showAdditionalColumns = false, bool addClearBtn = true, bool showPlusButton = false)
        {
            CreateDiagnosisColumns(cb, showAdditionalColumns, showAdditionalColumns);
            cb.PopupWidth = 400;
            SetDataSource(cb, diagnosisLookup, displayMember, "idfsDiagnosis");
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, ShowReferenceEditor<DiagnosisLookup>);
            }
            if (addClearBtn)
            {
                AddClearButton(cb, false);
            }
        }

        public static void BindDepartmentRepositoryLookup(RepositoryItemLookUpEdit cb, List<DepartmentLookup> departmentLookup, string displayMember = "name", bool showAdditionalColumns = false, bool addClearBtn = true, bool showPlusButton = false)
        {
            cb.PopupWidth = 400;
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colDepartmentName", "Department"), 200) });
            SetDataSource(cb, departmentLookup, displayMember, "idfDepartment");
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, AddDepartment);
            }
            if (addClearBtn)
            {
                AddClearButton(cb, false);
            }
        }


        public static void BindDepartmentLookup(LookUpEdit cb, object ds, List<DepartmentLookup> departmentLookup, string bindField, bool showPlusButton = true)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colDepartmentName", "Department"), 200) });
            cb.Properties.PopupWidth = cb.Width;
            SetDataSource(cb, departmentLookup, "name", String.Empty);//"idfDepartment"
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, AddDepartment);
            }
            AddBinding(cb, ds, bindField, true);
        }

        public static void BindDepartmentRepositoryLookup(RepositoryItemLookUpEdit cb, List<DepartmentLookup> departmentLookup, bool showPlusButton)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(new[] { new LookUpColumnInfo("name", EidssMessages.Get("colDepartmentName", "Department"), 150) });
            cb.PopupWidth = 350;
            SetDataSource(cb, departmentLookup, "name", "idfDepartment");//valueMember
            if (showPlusButton)
            {
                AddPlusButton(cb);
                AddButtonClickHandler(cb, AddDepartment);
            }
            AddClearButton(cb, false);
        }

        private static void AddDepartment(object sender, ButtonPressedEventArgs e)
        {
            if (((BaseEdit)sender).Properties.ReadOnly == true)
            {
                return;
            }
            if (ActionLocker.LockAction(sender))
            {

                try
                {
                    if (e.Button.Kind == ButtonPredefines.Plus)
                    {
                        if (!EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Organization)))
                        {
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"));
                            return;
                        }

                        var cb = (LookUpEdit)sender;
                        object id = null;
                        object parentID = null; 
                        if (cb.DataBindings.Count > 0)
                        {
                            var person = cb.DataBindings[0].DataSource as Person;
                            if (person != null && person.idfInstitution != null)
                            {
                                parentID = person.idfInstitution;
                            }
                        }
                        if (parentID == null)
                            parentID = EidssUserContext.User.OrganizationID;
                        var param = new Dictionary<string, object>();
                        param.Add("OrganizationID", parentID);
                        if (BaseFormManager.ShowModal(((IApplicationForm)(ClassLoader.LoadClass("DepartmentDetail"))), cb.FindForm(), ref id, parentID, param))
                        {

                            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                LookupManager.ClearAndReload(manager, "DepartmentLookup");
                            }
                            SetDepartmentEditValueAsync(sender, id);
                        }
                    }
                }
                finally
                {
                    ActionLocker.UnlockAction(sender);
                }
            }
        }



        public static void BindTestForDiseaseRepositoryLookup(RepositoryItemLookUpEdit cb, List<TestForDiseaseLookup> testForDiseaseLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                         new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, testForDiseaseLookup, "name", "idfsReference");
        }

        public static void BindTestResultRepositoryLookup(RepositoryItemLookUpEdit cb, List<TestResultLookup> testResultLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                         new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, testResultLookup, "name", "idfsReference");
        }

        public static void BindTestDiagnosisRepositoryLookup(RepositoryItemGridLookUpEdit cb, List<TestDiagnosisLookup> testDiagnosisLookup, long? idfsVetFinalDiagnosis)
        {
            BindRepositoryGridLookup(cb, testDiagnosisLookup,"name", "idfsDiagnosis");
            cb.PopupFormSize = new Size(600, 50);
            cb.View.CustomDrawCell += (sender, args) =>
                {
                    if (idfsVetFinalDiagnosis.HasValue)
                    {
                        var row = testDiagnosisLookup[args.RowHandle];
                        if (row != null && idfsVetFinalDiagnosis.Value.Equals(row.idfsDiagnosis))
                        {
                            args.Appearance.Font = WinClientContext.CurrentBoldFont;
                        }
                    }
                };
        }
        public static void BindTestDiagnosisLookup(GridLookUpEdit cb, LaboratorySectionItem item, string bindField, List<TestDiagnosisLookup> lookup)
        {
            BindTestDiagnosisRepositoryLookup(cb.Properties, lookup, item.idfsVetFinalDiagnosis);//, "name", "idfsDiagnosis");
            //cb.Properties.View.CustomDrawCell += (sender, args) =>
            //{
            //    if (item.idfsVetFinalDiagnosis.HasValue)
            //    {
            //        var row = lookup[args.RowHandle];
            //        if (row != null && item.idfsVetFinalDiagnosis.Value.Equals(row.idfsDiagnosis))
            //        {
            //            args.Appearance.Font = WinClientContext.CurrentBoldFont;
            //        }
            //    }
            //};
            AddBinding(cb, item, bindField, false);
        }


        public static void BindSampleTypeForDiagnosisRepositoryLookup(RepositoryItemLookUpEdit cb, List<SampleTypeForDiagnosisLookup> sampleTypeLookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                         new LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, sampleTypeLookup, "name", "idfsReference");
        }

        //public static void BindTestResultLookup(LookUpEdit cb, object dataSource, List<TestResultLookup> testResultLookup, string BindField)
        //{
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 400;
        //    DataSet ds;
        //    SetDataSource(cb, testResultLookup, "Name", "idfsReference");
        //    AddPlusButton(cb);
        //    AddButtonClickHandler(cb, new ButtonPressedEventHandler(AddBaseReference));
        //    AddBinding(cb, ds, BindField, false);
        //}

        //public static void BindPatientRepositoryLookup(RepositoryItemLookUpEdit cb, List<PersonLookup> personLookup, string valueMember)
        //{
        //    cb.Columns.Clear();
        //    cb.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("PatientName", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, personLookup, "PatientName", "");// valueMember;
        //}

        //public static void BindPatientLookup(LookUpEdit cb, object dataSource, List<PersonLookup> personLookup, string bindField, string valueMember)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("PatientName", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 400;
        //    SetDataSource(cb, personLookup, "PatientName", valueMember);
        //    AddBinding(cb, dataSource, bindField, false);
        //}

        //public static void BindPatientAdditionalInfoRepositoryLookup(RepositoryItemLookUpEdit cb, string valueMember)
        //{
        //    cb.Columns.Clear();
        //    cb.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("PatientInformation", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(LookupTables.PatientAdditionalInfo), "PatientInformation", valueMember);
        //}

        //public static void BindPatientAdditionalInfoLookup(LookUpEdit cb, object dataSource, string BindField, string valueMember)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("PatientInformation", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 400;
        //    DataSet ds = null;
        //    if (dataSource is DataView)
        //    {
        //        ds = ((DataView)dataSource).Table.DataSet;
        //    }
        //    else if ((dataSource) is DataSet)
        //    {
        //        ds = (DataSet)dataSource;
        //    }
        //    else
        //    {
        //        throw (new Exception("unsupported datasource type"));
        //    }
        //    SetDataSource(cb, LookupCache.Get(LookupTables.PatientAdditionalInfo), "PatientInformation", valueMember);
        //    Core.LookupBinder.AddBinding(cb, ds, BindField, false);
        //}

        //public static void BindOutbreakLookup(LookUpEdit cb, object dataSource, string BindField)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("strOutbreakID", EidssMessages.Get("colOutbreakID", "Outbreak ID"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 350;
        //    DataSet ds;
        //    if (dataSource is DataView)
        //    {
        //        ds = ((DataView)dataSource).Table.DataSet;
        //    }
        //    else if ((dataSource) is DataSet)
        //    {
        //        ds = (DataSet)dataSource;
        //    }
        //    else
        //    {
        //        throw (new Exception("unsupported datasource type"));
        //    }
        //    SetDataSource(cb, LookupCache.Get(LookupTables.Outbreak), "strOutbreakID", "idfOutbreak");
        //    AddBinding(cb, dataSource, BindField, true);
        //}
        //public static void AddQuery(object sender, EventArgs e)
        //{
        //    if (!((sender) is Control))
        //    {
        //        return;
        //    }
        //    TagHelper th = TagHelper.GetTagHelper((Control)sender);
        //    if (th == null)
        //    {
        //        return;
        //    }
        //    if (!((th.Tag) is LookUpEdit))
        //    {
        //        return;
        //    }
        //    ShowRAMQueryEditor((LookUpEdit)th.Tag);
        //}
        //private static void ShowRAMQueryEditor(LookUpEdit cb)
        //{
        //    object ID = null;
        //    object objBF = AppStructure.LoadClass("QueryDetail");
        //    if ((objBF == null) || (!((objBF) is BaseDetailForm)))
        //    {
        //        throw (new Exception("Can\'t load QueryDetail form"));
        //    }
        //    BaseDetailForm bf = (BaseDetailForm)objBF;
        //    if (BaseForm.ShowModal(bf, cb.FindForm(), ID))
        //    {
        //        //LookupCache.Fill(LookupCache.LookupTables(LookupTables.Query.ToString()), True)
        //        cb.EditValue = ID;
        //    }
        //}

        //private static void AddQuery(object sender, ButtonPressedEventArgs e)
        //{
        //    if (!((sender) is LookUpEdit))
        //    {
        //        return;
        //    }
        //    if (((LookUpEdit)sender).Properties.ReadOnly)
        //    {
        //        return;
        //    }

        //    if (e.Button.Kind == ButtonPredefines.Plus)
        //    {
        //        ShowRAMQueryEditor((LookUpEdit)sender);
        //    }
        //}


        //public static void BindQueryLookup(LookUpEdit cb, bool showAllItems)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("QueryName", EidssMessages.Get("colQueryName", "Query name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = cb.Width;
        //    cb.DataBindings.Clear();

        //    SetDataSource(cb, GetQueryDataView(showAllItems), "QueryName", "idflQuery");
        //    AddButtonClickHandler(cb, new EIDSS.Core.LookupBinder.ButtonPressedEventHandler(AddQuery));
        //}

        //public static DataView GetQueryDataView(bool showAllItems)
        //{


        //    List<string> permissionList = new List<string>();
        //    if (HasNoPermission(EIDSSPermissionObject.Outbreak))
        //    {
        //        permissionList.Add(" (blnIsOutbreak = 0)");
        //    }
        //    if (HasNoPermission(EIDSSPermissionObject.HumanCase))
        //    {
        //        permissionList.Add(" (blnIsHumanCase = 0)");
        //    }
        //    if (HasNoPermission(EIDSSPermissionObject.VetCase))
        //    {
        //        permissionList.Add(" (blnIsVetCase = 0)");
        //    }
        //    if (HasNoPermission(EIDSSPermissionObject.Sample))
        //    {
        //        permissionList.Add(" (blnIsSample = 0)");
        //    }
        //    if (HasNoPermission(EIDSSPermissionObject.Test))
        //    {
        //        permissionList.Add(" (blnIsTest = 0)");
        //    }
        //    if (HasNoPermission(EIDSSPermissionObject.Campaign))
        //    {
        //        permissionList.Add(" (blnIsASCampaign = 0)");
        //    }
        //    if (HasNoPermission(EIDSSPermissionObject.MonitoringSession))
        //    {
        //        permissionList.Add(" (blnIsASSession = 0)");
        //    }

        //    StringBuilder sbFilter = new StringBuilder();
        //    if (showAllItems == false)
        //    {
        //        sbFilter.Append(" (blnReadOnly = 1) ");
        //    }
        //    foreach (string permission in permissionList)
        //    {
        //        if (sbFilter.Length > 0)
        //        {
        //            sbFilter.Append(" and ");
        //        }
        //        sbFilter.Append(permission);
        //    }

        //    DataView dv = LookupCache.Get(LookupTables.Query.ToString());
        //    dv.RowFilter = sbFilter.ToString();
        //    return dv;
        //}

        //private static bool HasNoPermission(EIDSS.Core.LookupBinder.HasNoPermission permissionObject)
        //{
        //    return !EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(permissionObject));
        //}

        //public static void BindSearchFieldLookup(LookUpEdit cb, DataSet ds, string BindField, bool ShowClearButton)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("FieldCaption", EidssMessages.Get("colFieldName", "Field name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });

        //    cb.Properties.PopupWidth = cb.Width;

        //    SetDataSource(cb, LookupCache.Get(LookupTables.SearchField.ToString()), "FieldCaption", "idfsSearchField");
        //    AddBinding(cb, ds, BindField, ShowClearButton);
        //}

        //public static void BindSearchFieldLookup(ListBoxControl lbc)
        //{
        //    lbc.Items.Clear();
        //    DataView dv = LookupCache.Get(LookupTables.SearchField);
        //    if (dv == null)
        //    {
        //        return;
        //    }
        //    if (dv.Table.Columns.Contains("blnAvailable") == false)
        //    {
        //        DataColumn colAvailable = new DataColumn("blnAvailable", typeof(bool));
        //        dv.Table.Columns.Add(colAvailable);
        //        foreach (DataRow r in dv.Table.Rows)
        //        {
        //            r["blnAvailable"] = 1;
        //        }
        //    }
        //    dv.RowFilter = "blnAvailable = 1";
        //    dv.Sort = "FieldCaption";
        //    dv.RowStateFilter = DataViewRowState.CurrentRows;
        //    SetDataSource(lbc, dv, "FieldCaption", "idfsSearchField");
        //    lbc.DataBindings.Clear();
        //}

        //public static void BindSearchFieldLookup(ImageListBoxControl imlbc)
        //{
        //    imlbc.Items.Clear();
        //    DataView dv = LookupCache.Get(LookupTables.SearchField);
        //    if (dv == null)
        //    {
        //        return;
        //    }
        //    if (dv.Table.Columns.Contains("blnAvailable") == false)
        //    {
        //        DataColumn colAvailable = new DataColumn("blnAvailable", typeof(bool));
        //        dv.Table.Columns.Add(colAvailable);
        //        foreach (DataRow r in dv.Table.Rows)
        //        {
        //            r["blnAvailable"] = 1;
        //        }
        //    }
        //    dv.RowFilter = "blnAvailable = 1";
        //    dv.Sort = "FieldCaption";
        //    dv.RowStateFilter = DataViewRowState.CurrentRows;
        //    SetDataSource(imlbc, dv, "FieldCaption", "idfsSearchField", "TypeImageIndex");
        //    imlbc.DataBindings.Clear();
        //}

        //public static void BindParameterForFFTypeLookup(ListBoxControl lbc)
        //{
        //    lbc.Items.Clear();
        //    DataView dv = LookupCache.Get(LookupTables.ParameterForFFType);
        //    if ((dv == null) || (dv.Table == null))
        //    {
        //        return;
        //    }
        //    if ((dv.Table.PrimaryKey == null) || (dv.Table.PrimaryKey.Length != 1) || (dv.Table.PrimaryKey(0).ColumnName != "FieldAlias"))
        //    {
        //        dv.Table.PrimaryKey = null;
        //        if (dv.Table.Columns.Contains("FieldAlias"))
        //        {
        //            dv.Table.Columns["FieldAlias"].AllowDBNull = false;
        //            dv.Table.PrimaryKey = new DataColumn[] { dv.Table.Columns["FieldAlias"] };
        //        }
        //    }

        //    if (dv.Table.Columns.Contains("blnAvailable") == false)
        //    {
        //        DataColumn colAvailable = new DataColumn("blnAvailable", typeof(bool));
        //        dv.Table.Columns.Add(colAvailable);
        //        foreach (DataRow r in dv.Table.Rows)
        //        {
        //            r["blnAvailable"] = 1;
        //        }
        //    }
        //    dv.RowFilter = "blnAvailable = 1";
        //    dv.Sort = "ParameterName";
        //    dv.RowStateFilter = DataViewRowState.CurrentRows;
        //    SetDataSource(lbc, dv, "ParameterName", "idfsParameter");
        //    lbc.DataBindings.Clear();
        //}

        //public static void BindParameterForFFTypeLookup(ImageListBoxControl imlbc)
        //{
        //    imlbc.Items.Clear();
        //    DataView dv = LookupCache.Get(LookupTables.ParameterForFFType);
        //    if ((dv == null) || (dv.Table == null))
        //    {
        //        return;
        //    }
        //    if ((dv.Table.PrimaryKey == null) || (dv.Table.PrimaryKey.Length != 1) || (dv.Table.PrimaryKey(0).ColumnName != "FieldAlias"))
        //    {
        //        dv.Table.PrimaryKey = null;
        //        if (dv.Table.Columns.Contains("FieldAlias"))
        //        {
        //            dv.Table.Columns["FieldAlias"].AllowDBNull = false;
        //            dv.Table.PrimaryKey = new DataColumn[] { dv.Table.Columns["FieldAlias"] };
        //        }
        //    }

        //    if (dv.Table.Columns.Contains("blnAvailable") == false)
        //    {
        //        DataColumn colAvailable = new DataColumn("blnAvailable", typeof(bool));
        //        dv.Table.Columns.Add(colAvailable);
        //        foreach (DataRow r in dv.Table.Rows)
        //        {
        //            r["blnAvailable"] = 1;
        //        }
        //    }
        //    dv.RowFilter = "blnAvailable = 1";
        //    dv.Sort = "ParameterName";
        //    dv.RowStateFilter = DataViewRowState.CurrentRows;
        //    SetDataSource(imlbc, dv, "ParameterName", "idfsParameter", "TypeImageIndex");
        //    imlbc.DataBindings.Clear();
        //}



        //public static void BindLayoutLookup(LookUpEdit cb, object userId, bool showAllItems)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("strLayoutName", EidssMessages.Get("colLayoutName", "Layout name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });

        //    cb.Properties.PopupWidth = cb.Width;

        //    DataView dv = LookupCache.Get(LookupTables.Layout.ToString());
        //    string filter = string.Format("((idfUserID is null) or (idfUserID = \'{0}\'))", userId);
        //    if (showAllItems == false)
        //    {
        //        filter = filter + " and (blnReadOnly = 1)";
        //    }

        //    dv.RowFilter = filter;
        //    // dv.Table.Rows.


        //    SetDataSource(cb, dv, "strLayoutName", "idflLayout");
        //    //cb.Properties.NullText = EidssMessages.Get("NoSavedLayoutMessage")

        //    cb.DataBindings.Clear();
        //}


        //public static void BindQuerySearchFieldLookup(LookUpEdit cb, DataView dv, DataSet ds, string BindField, bool ShowClearButton)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("FieldCaption", EidssMessages.Get("colFieldName", "Field Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });

        //    cb.Properties.PopupWidth = cb.Width;
        //    if ((dv == null) || (dv.Table == null) || (!dv.Table.Columns.Contains("idfnQuerySearchField")) || (!dv.Table.Columns.Contains("FieldCaption")))
        //    {
        //        dv = LookupCache.Get(LookupTables.QuerySearchField.ToString());
        //    }
        //    SetDataSource(cb, dv, "FieldCaption", "idfnQuerySearchField");
        //    if ((!Utils.IsEmpty(BindField)) || (ShowClearButton == true))
        //    {
        //        AddBinding(cb, ds, BindField, ShowClearButton);
        //    }
        //    else
        //    {
        //        cb.DataBindings.Clear();
        //    }
        //}

        //public static void BindSearchCriteriaLookup(LookUpEdit cb, DataSet ds, string BindField, bool ShowClearButton)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("strCriteriaText", EidssMessages.Get("colCriteria", "Criteria"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });

        //    cb.Properties.PopupWidth = cb.Width;

        //    SetDataSource(cb, LookupCache.Get(LookupTables.SearchCriteria.ToString()), "strCriteriaText", "idfSearchCriteria");
        //    if ((!Utils.IsEmpty(BindField)) || (ShowClearButton == true))
        //    {
        //        AddBinding(cb, ds, BindField, ShowClearButton);
        //    }
        //    else
        //    {
        //        cb.DataBindings.Clear();
        //    }
        //}


        //public static void BindParametersFixedPresetValueLookup(LookUpEdit cb, DataSet ds, string BindField, bool ShowClearButton)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });

        //    cb.Properties.PopupWidth = cb.Width;

        //    SetDataSource(cb, LookupCache.Get(LookupTables.ParametersFixedPresetValue.ToString()), "Name", "idfsReference");
        //    if ((!Utils.IsEmpty(BindField)) || (ShowClearButton == true))
        //    {
        //        AddBinding(cb, ds, BindField, ShowClearButton);
        //    }
        //    else
        //    {
        //        cb.DataBindings.Clear();
        //    }
        //}

        //public static void BindParametersFixedPresetValueRepositoryLookup(RepositoryItemLookUpEdit cb, bool ShowClearButton)
        //{
        //    cb.Columns.Clear();
        //    cb.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("NationalName", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(LookupTables.ParametersFixedPresetValue.ToString()), "NationalName", "idfsParameterFixedPresetValue");
        //    if (ShowClearButton)
        //    {
        //        AddClearButton(cb, false);
        //    }
        //}

        //public static void BindBaseValueLookup(LookUpEdit cb, DataSet ds, string BindField, BaseReferenceType TableId, HACode aHACode, bool ShowPlusButton, bool ShowClearButton)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    SetLookupTableID(TableId, cb);
        //    SetHACodeValue(aHACode, cb);
        //    cb.Properties.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(TableId, aHACode), "Name", "idfsReference");
        //    if (ShowPlusButton)
        //    {
        //        AddPlusButton(cb);
        //        AddButtonClickHandler(cb, new EIDSS.Core.LookupBinder.ButtonPressedEventHandler(AddBaseReference));
        //    }
        //    if ((!Utils.IsEmpty(BindField)) || (ShowClearButton == true))
        //    {
        //        AddBinding(cb, ds, BindField, ShowClearButton);
        //    }
        //    else
        //    {
        //        cb.DataBindings.Clear();
        //    }
        //}
        //public static void BindActionBaseRepositoryLookup(RepositoryItemLookUpEdit cb, LookupTables TableId, HACode aHACode, string ActionColumnName, string ActionCodeFieldName, string CodeColumnName, string displayMember, string valueMember, bool AddClearBtn, bool AddPlusBtn, bool AddActionHandler)
        //{
        //    cb.Columns.Clear();
        //    cb.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo(displayMember, EidssMessages.Get(ActionColumnName), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo(ActionCodeFieldName, EidssMessages.Get(CodeColumnName), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    if (TableId == LookupTables.VetSanitaryAction)
        //    {
        //        SetLookupTableID(BaseReferenceType.rftSanitaryActionList, cb);
        //    }
        //    else if (TableId == LookupTables.VetProphilacticAction)
        //    {
        //        SetLookupTableID(BaseReferenceType.rftProphilacticActionList, cb);
        //    }
        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(TableId.ToString()), displayMember, valueMember);
        //    if (AddPlusBtn)
        //    {
        //        AddPlusButton(cb);
        //        if (AddActionHandler)
        //        {
        //            AddButtonClickHandler(cb, new EIDSS.Core.LookupBinder.ButtonPressedEventHandler(AddActionReference));
        //        }
        //    }
        //    if (AddClearBtn)
        //    {
        //        AddClearButton(cb, false);
        //    }
        //}
        //public static object ShowActionReferenceEditor(BaseReferenceType TableID)
        //    {
        //        object ID = null;
        //        object bf = AppStructure.LoadClass("ActionDetail");
        //        if (bf == null)
        //        {
        //            throw (new Exception("Can\'t load ActionDetail form"));
        //        }
        //        Hashtable startUpParam = new Hashtable();
        //        startUpParam["ReferenceType"] = System.Convert.ToInt32(TableID);
        //        if (BaseForm.ShowModal(((BaseForm) bf), BaseForm.MainForm, ID,, startUpParam))
        //        {
        //            return ID;
        //        }
        //        return null;
        //    }

        //private static void AddActionReference(object sender, ButtonPressedEventArgs e)
        //{
        //    if (((BaseEdit)sender).Properties.ReadOnly == true)
        //    {
        //        return;
        //    }
        //    if (e.Button.Kind == ButtonPredefines.Plus)
        //    {
        //        BaseReferenceType TableID = GetLookupTableID(sender);
        //        object ID = ShowActionReferenceEditor(TableID);
        //        SetLookupEditValue(sender, TableID, ID);
        //    }
        //}

        //private static void SetLookupEditValue(object sender, Enum TableID, object ID)
        //{
        //    if (ID != null)
        //    {
        //        DataRow r = null;
        //        LookUpEdit owner = null;
        //        if (sender is RepositoryItemLookUpEdit)
        //        {
        //            RepositoryItemLookUpEdit cb = (RepositoryItemLookUpEdit)sender;
        //            r = ((DataView)cb.DataSource).Table.Rows.Find(ID);
        //            if (r == null)
        //            {
        //                LookupCache.Refresh(TableID, 0, false);
        //                r = ((DataView)cb.DataSource).Table.Rows.Find(ID);
        //            }
        //            owner = cb.OwnerEdit;
        //        }
        //        else if (sender is LookUpEdit)
        //        {
        //            LookUpEdit cb = (LookUpEdit)sender;
        //            owner = cb;
        //            r = ((DataView)cb.Properties.DataSource).Table.Rows.Find(ID);
        //            if (r == null)
        //            {
        //                LookupCache.Refresh(TableID, 0, false);
        //                r = ((DataView)cb.Properties.DataSource).Table.Rows.Find(ID);
        //            }
        //        }
        //        if (owner != null)
        //        {
        //            if (r == null)
        //            {
        //                owner.EditValue = DBNull.Value;
        //            }
        //            else
        //            {
        //                owner.EditValue = ID;
        //            }
        //            if (owner.Parent != null && (owner.Parent) is GridControl)
        //            {
        //                ((GridControl)owner.Parent).FocusedView.PostEditor();
        //            }
        //            else
        //            {
        //                DataEventManager.SubmitCurrentEdit(owner);
        //            }
        //        }
        //    }
        //}


        //public static void ActionReference_PlusClick(object sender, ButtonPressedEventArgs e)
        //{
        //    AddActionReference(sender, e);
        //}

        //public static void BindSiteLookup(LookUpEdit cb, DataSet ds, string BindField, bool ShowClearButton)
        //{
        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("strSiteID", EidssMessages.Get("colSiteID", "Site ID"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo("strSiteType", EidssMessages.Get("colSiteType", "Site Type"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo("strSiteName", EidssMessages.Get("colSiteName", "Site Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(LookupTables.Site), "strSiteID", "idfsSite");
        //    AddBinding(cb, ds, BindField, ShowClearButton);

        //}
        //public static void BindSiteRepositoryLookup(RepositoryItemLookUpEdit cb, bool ShowClearButton)
        //{
        //    cb.Columns.Clear();
        //    cb.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("strSiteID", EidssMessages.Get("colSiteID", "Site ID"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo("strSiteType", EidssMessages.Get("colSiteType", "Site Type"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo("strSiteName", EidssMessages.Get("colSiteName", "Site Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(LookupTables.Site), "strSiteID", "idfsSite");
        //}

        //private static System.Windows.Forms.ImageList imageList1;
        //public static void BindAggregateMatrixVersionLookup(GridLookUpEdit cb, DataSet ds, string BindField, AggregateCaseSection MatrixType, bool ShowActiveMatrixOnly)
        //{

        //    RepositoryItemImageComboBox chkDefault = new RepositoryItemImageComboBox();
        //    if (imageList1 == null)
        //    {
        //        imageList1 = new System.Windows.Forms.ImageList();
        //        imageList1.TransparentColor = System.Drawing.Color.Magenta;
        //        imageList1.ImageSize = new Size(14, 14);
        //        imageList1.Images.Add("state_nonactive", global::My.Resources.Resources.state_nonactive);
        //        imageList1.Images.Add("state_activated", global::My.Resources.Resources.state_activated);
        //        imageList1.Images.Add("state_default", global::My.Resources.Resources.state_default);
        //    }
        //    chkDefault.SmallImages = imageList1;
        //    chkDefault.Items.AddRange(new ImageComboBoxItem[] { new ImageComboBoxItem(EidssMessages.Get("strMatrixNotActive", "Not Active"), 0, 0), new ImageComboBoxItem(EidssMessages.Get("strMatrixActive", "Active"), 1, 1), new ImageComboBoxItem(EidssMessages.Get("strDefault", "Default"), 2, 2) });
        //    chkDefault.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
        //    cb.Properties.RepositoryItems.AddRange(new RepositoryItem[] { chkDefault });

        //    GridColumn colDefault = new GridColumn();
        //    colDefault.Caption = (string)(EidssMessages.Get("colState", "State"));
        //    colDefault.FieldName = "intState";
        //    colDefault.ColumnEdit = chkDefault;
        //    colDefault.Width = 25;
        //    colDefault.VisibleIndex = 0;
        //    colDefault.ImageIndex = 0;
        //    colDefault.ImageAlignment = StringAlignment.Center;
        //    colDefault.OptionsColumn.AllowSize = false;
        //    colDefault.OptionsFilter.AllowFilter = false;

        //    GridColumn colMatrixName = new GridColumn();
        //    colMatrixName.Caption = (string)(EidssMessages.Get("colMatrixName", "Name"));
        //    colMatrixName.FieldName = "MatrixName";
        //    colMatrixName.Width = 200;
        //    colMatrixName.VisibleIndex = 1;

        //    GridColumn colMatrixDate = new GridColumn();
        //    colMatrixDate.Caption = (string)(EidssMessages.Get("colMatrixDate", "Activation Date"));
        //    colMatrixDate.FieldName = "datStartDate";
        //    colMatrixDate.Width = 100;
        //    colMatrixDate.VisibleIndex = 2;

        //    DevExpress.XtraGrid.Views.Grid.GridView gridView = new DevExpress.XtraGrid.Views.Grid.GridView();

        //    gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDefault, colMatrixName, colMatrixDate });
        //    gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        //    gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
        //    gridView.OptionsView.ShowGroupPanel = false;
        //    gridView.OptionsView.ShowIndicator = false;
        //    gridView.Images = imageList1;

        //    cb.Properties.View = gridView;

        //    cb.Properties.PopupFormSize = new Size(400, 0);

        //    DataView view = LookupCache.Get(LookupTables.AggregateMatrixVersion);
        //    string Filter = string.Format("idfsAggrCaseSection={0}", System.Convert.ToInt32(MatrixType));
        //    if (ShowActiveMatrixOnly)
        //    {
        //        Filter += " and blnIsActive=1";
        //    }
        //    view.RowFilter = Filter;
        //    SetDataSource(cb, view, "MatrixName", "idfVersion");
        //    AddBinding(cb, ds, BindField, false);
        //}

        //public static void BindFFTemplatesLookup(LookUpEdit cb, DataSet ds, string BindField, FFType formType)
        //{

        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("NationalName", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 400;
        //    DataView view = LookupCache.Get(LookupTables.FFTemplate);
        //    string Filter = string.Format("idfsFormType={0}", System.Convert.ToInt32(formType));
        //    view.RowFilter = Filter;
        //    SetDataSource(cb, view, "NationalName", "idfsFormTemplate");
        //    AddBinding(cb, ds, BindField, false);

        //}
        //public static void BindASCampaignLookup(LookUpEdit cb, DataSet ds, string BindField)
        //{

        //    cb.Properties.Columns.Clear();
        //    cb.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("strCampaignID", EidssMessages.Get("colCampaignID", "Campaign ID"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo("strCampaignName", EidssMessages.Get("colCampaignName", "Campaign Name"), 200, DevExpress.Utils.FormatType.DateTime, "d", true, DevExpress.Utils.HorzAlignment.Near), new LookUpColumnInfo("strCampaignStatus", EidssMessages.Get("colCampaignStatus", "Campaign Status"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });
        //    cb.Properties.PopupWidth = 400;
        //    DataView view = LookupCache.Get(LookupTables.ASCampaign);
        //    SetDataSource(cb, view, "strCampaignID", "idfCampaign");
        //    AddBinding(cb, ds, BindField, false);

        //}

        #endregion
        //#region HACode lookup binder
        //private static int HACodePopupHeight = 0;

        //public static void BindReprositoryHACodeLookup(RepositoryItemPopupContainerEdit popupContainer, DataView dv, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        //{
        //    PopupContainerControl popup = new PopupContainerControl();
        //    popupContainer.PopupControl = popup;
        //    HACodePopupHeight = 0;
        //    int HACodePopupWidth = 0;
        //    dv.Sort = "intHACode";
        //    popup.Tag = new List<CheckEdit>();
        //    AddHACode(dv, popupContainer, System.Convert.ToInt32(HACode.Animal), ref HACodePopupWidth);
        //    AddHACode(dv, popupContainer, System.Convert.ToInt32(HACode.Avian), ref HACodePopupWidth);
        //    AddHACode(dv, popupContainer, System.Convert.ToInt32(HACode.Livestock), ref HACodePopupWidth);

        //    Hashtable listed = new Hashtable();
        //    listed[System.Convert.ToInt32(HACode.Animal)] = null;
        //    listed[System.Convert.ToInt32(HACode.Avian)] = null;
        //    listed[System.Convert.ToInt32(HACode.Livestock)] = null;

        //    int code = 1;
        //    while (true)
        //    {
        //        if (listed.Contains(code) == false)
        //        {
        //            if (AddHACode(dv, popupContainer, code, ref HACodePopupWidth) == false)
        //            {
        //                break;
        //            }
        //        }
        //        code = code * 2;
        //    }
        //    popup.AutoScroll = true;
        //    popup.AutoScrollMinSize = new System.Drawing.Size(HACodePopupWidth, HACodePopupHeight);
        //    popupContainer.QueryResultValue -= new QueryResultValueEventHandler(PopupContainerEdit_QueryResultValue);
        //    popupContainer.QueryResultValue += new QueryResultValueEventHandler(PopupContainerEdit_QueryResultValue);
        //    popupContainer.QueryPopUp -= new System.ComponentModel.CancelEventHandler(PopupContainer_QueryPopUp);
        //    popupContainer.QueryPopUp += new System.ComponentModel.CancelEventHandler(PopupContainer_QueryPopUp);
        //    popupContainer.QueryDisplayText -= new QueryDisplayTextEventHandler(PopupContainer_QueryDisplayText);
        //    popupContainer.QueryDisplayText += new QueryDisplayTextEventHandler(PopupContainer_QueryDisplayText);
        //    gridView.ShowFilterPopupListBox -= new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(HACodeColumn_ShowFilterPopupListBox);
        //    gridView.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(HACodeColumn_ShowFilterPopupListBox);
        //}
        //private static void HACodeColumn_ShowFilterPopupListBox(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs e)
        //{
        //    if (e.Column.FieldName == "intHACode" && e.ComboBox.Items.Count > 0)
        //    {
        //        foreach (DevExpress.XtraGrid.Views.Grid.FilterItem item in e.ComboBox.Items)
        //        {
        //            if ((item.Value) is DevExpress.XtraGrid.Views.Grid.FilterItem && ((DevExpress.XtraGrid.Views.Grid.FilterItem)item.Value).Value.Equals(1))
        //            {
        //                e.ComboBox.Items.Remove(item);
        //                return;
        //            }
        //        }
        //    }
        //}

        //private static bool AddHACode(DataView dv, RepositoryItemPopupContainerEdit popupContainer, int code, ref int HACodePopupWidth)
        //{
        //    DataRowView[] found = dv.FindRows(code);
        //    if (found.Length == 0)
        //    {
        //        return false;
        //    }
        //    DevExpress.XtraEditors.CheckEdit check = new DevExpress.XtraEditors.CheckEdit();
        //    check.Tag = code;
        //    check.Text = (string)(found[0].Row("CodeName").ToString());
        //    check.Top = HACodePopupHeight;
        //    check.Width = System.Convert.ToInt32(check.CalcBestSize().Width);
        //    if (check.Width > HACodePopupWidth)
        //    {
        //        HACodePopupWidth = check.Width;
        //    }
        //    HACodePopupHeight += check.Height;
        //    popupContainer.PopupControl.Controls.Add(check);
        //    ((List<CheckEdit>)popupContainer.PopupControl.Tag).Add(check);
        //    check.CheckedChanged += new System.EventHandler(CheckedHandler);
        //    return true;
        //}

        //private static void CheckedHandler(object sender, System.EventArgs e)
        //{
        //    DevExpress.XtraEditors.CheckEdit check = (DevExpress.XtraEditors.CheckEdit)sender;
        //    PopupContainerControl popup = (PopupContainerControl)check.Parent;
        //    int code = System.Convert.ToInt32(check.Tag);
        //    if (code == HACode.Animal)
        //    {
        //        SetChecked(((List<CheckEdit>)popup.Tag)(1), check.Checked);
        //        SetChecked(((List<CheckEdit>)popup.Tag)(2), check.Checked);
        //    }
        //    if (code == HACode.Avian || code == HACode.Livestock)
        //    {
        //        SetChecked(((List<CheckEdit>)popup.Tag)(0), ((List<CheckEdit>)popup.Tag)(1).Checked || ((List<CheckEdit>)popup.Tag)(2).Checked);
        //    }
        //}

        //private static void PopupContainerEdit_QueryResultValue(object sender, QueryResultValueEventArgs e)
        //{
        //    //If Closing Then
        //    //    Return
        //    //End If
        //    int HACode = 0;
        //    if (sender is PopupContainerEdit && !(((PopupContainerEdit)sender) == null))
        //    {
        //        sender = ((PopupContainerEdit)sender).Tag;
        //    }
        //    if (sender is RepositoryItemPopupContainerEdit)
        //    {
        //        RepositoryItemPopupContainerEdit popupContainer = (RepositoryItemPopupContainerEdit)sender;
        //        foreach (DevExpress.XtraEditors.CheckEdit check in ((List<CheckEdit>)popupContainer.PopupControl.Tag))
        //        {
        //            if (check.Checked)
        //            {
        //                HACode += System.Convert.ToInt32(check.Tag);
        //            }
        //        }
        //        if (Utils.IsEmpty(e.Value) && HACode == 0)
        //        {
        //            return;
        //        }
        //        e.Value = HACode;
        //    }
        //}

        //private static void PopupContainer_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        //{
        //    int HACode = 0;
        //    if (Utils.IsEmpty(e.EditValue) == false)
        //    {
        //        HACode = System.Convert.ToInt32(e.EditValue);
        //    }
        //    if (sender is PopupContainerEdit && !(((PopupContainerEdit)sender) == null))
        //    {
        //        sender = ((PopupContainerEdit)sender).Tag;
        //    }

        //    if (sender is RepositoryItemPopupContainerEdit)
        //    {
        //        RepositoryItemPopupContainerEdit popupContainer = (RepositoryItemPopupContainerEdit)sender;
        //        e.DisplayText = "";
        //        foreach (CheckEdit check in ((List<CheckEdit>)popupContainer.PopupControl.Tag))
        //        {
        //            bool bitSet = System.Convert.ToBoolean((System.Convert.ToInt32(check.Tag) && HACode) != 0);
        //            //SetChecked(check, bitSet)
        //            if (bitSet)
        //            {
        //                Utils.AppendLine(e.DisplayText, check.Text, ", ");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Dbg.Dbg("unexpected type");
        //    }
        //}

        //private static void PopupContainer_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    int HACode = 0;
        //    if (sender is PopupContainerEdit && !(((PopupContainerEdit)sender) == null))
        //    {
        //        if (Utils.IsEmpty(((PopupContainerEdit)sender).EditValue) == false)
        //        {
        //            HACode = System.Convert.ToInt32(((PopupContainerEdit)sender).EditValue);
        //        }
        //        sender = ((PopupContainerEdit)sender).Tag;
        //    }

        //    if (sender is RepositoryItemPopupContainerEdit)
        //    {
        //        RepositoryItemPopupContainerEdit popupContainer = (RepositoryItemPopupContainerEdit)sender;
        //        popupContainer.PopupControl.Size = new System.Drawing.Size(200, popupContainer.PopupControl.AutoScrollMinSize.Height);
        //        foreach (CheckEdit check in ((List<CheckEdit>)popupContainer.PopupControl.Tag))
        //        {
        //            bool bitSet = System.Convert.ToBoolean((System.Convert.ToInt32(check.Tag) && HACode) != 0);
        //            SetChecked(check, bitSet);
        //        }
        //    }
        //    else
        //    {
        //        Dbg.Dbg("unexpected type");
        //    }
        //}

        //private static void SetChecked(DevExpress.XtraEditors.CheckEdit check, bool status)
        //{
        //    if (check.Checked == status)
        //    {
        //        return;
        //    }
        //    check.CheckedChanged -= new System.EventHandler(CheckedHandler);
        //    check.Checked = status;
        //    check.CheckedChanged += new System.EventHandler(CheckedHandler);
        //}

        //#endregion
        //#region Repository check list lookup binder
        //public static void BindReprositoryCheckListLookup(RepositoryItemCheckedComboBoxEdit checkList, DataView dv, string valueMember, string displayMember)
        //{
        //    checkList.DataSource = dv;
        //    checkList.ValueMember = valueMember;
        //    checkList.DisplayMember = displayMember;
        //    checkList.SelectAllItemVisible = false;
        //    checkList.SynchronizeEditValueWithCheckedItems = true;
        //}


        //#endregion


        //public static void BindAVRGisRepositoryLookup(RepositoryItemLookUpEdit cb, GisRefereneceType referenceType, string valueMember)
        //{
        //    cb.Columns.Clear();

        //    cb.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ExtendedName", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near) });

        //    cb.PopupWidth = 400;
        //    SetDataSource(cb, LookupCache.Get(LookupTables.AVRGIS.ToString()), "ExtendedName", valueMember);
        //    if (referenceType == GisRefereneceType.Country)
        //    {
        //        ((DataView)cb.DataSource).RowFilter = string.Format("idfsGISReferenceType = {0}", System.Convert.ToInt32(referenceType));
        //    }
        //    else
        //    {
        //        ((DataView)cb.DataSource).RowFilter = string.Format("idfsCountry = {0} and idfsGISReferenceType = {1}", eidss.model.Core.EidssSiteContext.Instance.CountryID, System.Convert.ToInt32(referenceType));
        //    }

        //}
        public static void BindDate(DateEdit dateEdit, object bo, string bindField)
        {
            dateEdit.DataBindings.Clear();
            Dbg.Assert(bo != null, "datasource for binding field {0} is not defined", bindField);
            dateEdit.DataBindings.Add("EditValue", bo, bindField, true, DataSourceUpdateMode.OnPropertyChanged);
            dateEdit.EditValueChanging += new ChangingEventHandler(dateEdit_EditValueChanging);
            dateEdit.DataBindings[0].BindingComplete += new BindingCompleteEventHandler(LookupBinder_BindingComplete);
            DxControlsHelper.InitDateEdit(dateEdit);
        }

        static void LookupBinder_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
        }
        static void dateEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            //DateEdit dateEdit = (DateEdit)sender;
            //IObject o = (IObject)dateEdit.DataBindings[0].DataSource;
            //string name = dateEdit.DataBindings[0].BindingMemberInfo.BindingField;
            //dateEdit.DataBindings[0].
        }


        public static void BindSpinEdit(SpinEdit spinEdit, object bo, string bindField, decimal minValue = 0, decimal maxValue = 0, bool isFloatingValue = false, decimal increment = 1)
        {
            spinEdit.DataBindings.Clear();
            spinEdit.KeyDown -= SpinEdit_KeyDown;
            Dbg.Assert(bo != null, "datasource for binding field {0} is not defined", bindField);
            spinEdit.DataBindings.Add("EditValue", bo, bindField, true, DataSourceUpdateMode.OnPropertyChanged);
            if (minValue != 0)
                spinEdit.Properties.MinValue = minValue;
            if (maxValue != 0)
                spinEdit.Properties.MaxValue = maxValue;
            spinEdit.Properties.IsFloatValue = isFloatingValue;
            spinEdit.Properties.Increment = 1;
            spinEdit.Properties.AllowNullInput = DefaultBoolean.True;
            spinEdit.KeyDown += SpinEdit_KeyDown;

        }

        private static void SpinEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (((SpinEdit)sender).Text.Replace("0", "").Replace(".", "").Replace(",", "") == "")
                {
                    ((SpinEdit)sender).EditValue = null;
                }
            }
        }



        public static void BindRepositorySpinEdit(RepositoryItemSpinEdit spinEdit, decimal minValue = 0, decimal maxValue = 0, bool isFloatingValue = false, decimal increment = 1)
        {
            if (minValue != 0)
                spinEdit.MinValue = minValue;
            if (maxValue != 0)
                spinEdit.MaxValue = maxValue;
            spinEdit.IsFloatValue = isFloatingValue;
            spinEdit.Increment = 1;
            spinEdit.KeyDown -= SpinEdit_KeyDown;
            spinEdit.KeyDown += SpinEdit_KeyDown;
        }
        public static void BindRepositoryCheckEdit(RepositoryItemCheckEdit checkEdit)
        {
            checkEdit.ValueChecked = true;
            checkEdit.ValueUnchecked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="lookup"></param>
        public static void BindFieldTestTestTypeRepository(RepositoryItemLookUpEdit cb, List<PensideTestLookup> lookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("strPensideTypeName", EidssFields.Get("strPensideTypeName", "Test Name"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, lookup, "strPensideTypeName", "idfsPensideTestName");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="lookup"></param>
        public static void BindVectorType2SampleTypeRepository(RepositoryItemLookUpEdit cb, List<VectorType2SampleTypeLookup> lookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo("SampleName", EidssFields.Get("SampleType", "Sample Type"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, lookup, "SampleName", "idfsSampleType");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="lookup"></param>
        public static void BindFieldTestResultRepository(RepositoryItemLookUpEdit cb, List<TypeFieldTestToResultMatrixLookup> lookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                         new LookUpColumnInfo("strPensideTestResultName", EidssFields.Get("strPensideTestResultName", "Result"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, lookup, "strPensideTestResultName", "idfsPensideTestResult");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="lookup"></param>
        public static void BindFieldTestDiagnosisRepository(RepositoryItemLookUpEdit cb, List<Diagnosis2PensideTestMatrixLookup> lookup)
        {
            cb.Columns.Clear();
            cb.Columns.AddRange(
                new[]
                    {
                         new LookUpColumnInfo("DiagnosisName", EidssFields.Get("DiagnosisName", "Diagnosis"), 100)
                    });
            cb.PopupWidth = 200;
            SetDataSource(cb, lookup, "DiagnosisName", "idfsDiagnosis");
        }

        private static DataView GetHacodeView(int intHaCodeMask)
        {
            DataView dv = null;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                manager.SetCommand(
                    CommandType.StoredProcedure
                    , "dbo.spHACode_SelectCheckList"
                    , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                    , manager.Parameter("@intHACodeMask", intHaCodeMask)
                    );
                var dt = manager.ExecuteDataTable();
                if (dt != null)
                {
                    dv = dt.DefaultView;
                    dv.Sort = "intHACode";
                }
            }
            return dv;
        }

        private static void InitPopupContainer(PopupContainerControl popup, DataView dv, int intHaCodeMask)
        {
            if (dv == null)
                return;
            int haCodePopupWidth;
            int haCodePopupHeight;
            popup.Tag = new List<CheckEdit>();
            UpdateHACodeList(dv, popup, intHaCodeMask, out haCodePopupWidth, out haCodePopupHeight);
            popup.AutoScroll = true;
            popup.AutoScrollMinSize = new Size(haCodePopupWidth, haCodePopupHeight);
            popup.Width = 200;
            popup.Height = haCodePopupHeight;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="popup"></param>
        /// <param name="intHaCodeMask"></param>
        /// <param name="haCodePopupWidth"></param>
        /// <param name="haCodePopupHeight"></param>
        private static void UpdateHACodeList
            (DataView dv, PopupContainerControl popup, int intHaCodeMask, out int haCodePopupWidth, out int haCodePopupHeight)
        {
            haCodePopupWidth = 0;
            haCodePopupHeight = 0;
            popup.Controls.Clear();
            foreach (DataRowView row in dv)
            {
                var iha = Convert.ToInt32(row["intHACode"]);
                if ((iha & intHaCodeMask) != 0)
                {
                    AddHACode(dv, popup, iha, ref haCodePopupWidth, ref haCodePopupHeight);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="popup"></param>
        /// <param name="code"></param>
        /// <param name="haCodePopupWidth"></param>
        /// <param name="haCodePopupHeight"></param>
        /// <returns></returns>
        private static bool AddHACode
            (DataView dv, PopupContainerControl popup, int code, ref int haCodePopupWidth, ref int haCodePopupHeight)
        {
            var found = dv.FindRows(code);
            if (found.Length == 0) return false;
            var check = new CheckEdit { Tag = code, Text = found[0]["CodeName"].ToString(), Top = haCodePopupHeight };
            check.Width = check.CalcBestSize().Width;
            if (check.Width > haCodePopupWidth) haCodePopupWidth = check.Width;
            haCodePopupHeight += check.Height;
            popup.Controls.Add(check);
            ((List<CheckEdit>)popup.Tag).Add(check);
            return true;
        }
        public static void BindHACodeLookup(PopupContainerEdit popup, object ds, string bindField, int intHaCodeMask)
        {
            var popupContainer = new PopupContainerControl();
            popup.Properties.PopupControl = popupContainer;
            DataView dv = GetHacodeView(intHaCodeMask);
            InitPopupContainer(popupContainer, dv, intHaCodeMask);
            popup.QueryResultValue -= PopupContainerEdit_QueryResultValue;
            popup.QueryResultValue += PopupContainerEdit_QueryResultValue;
            popup.QueryPopUp -= PopupContainer_QueryPopUp;
            popup.QueryPopUp += PopupContainer_QueryPopUp;
            popup.QueryDisplayText -= PopupContainer_QueryDisplayText;
            popup.QueryDisplayText += PopupContainer_QueryDisplayText;
            AddBinding(popup, ds, bindField);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="popup"></param>
        /// <param name="gridView"></param>
        /// <param name="intHaCodeMask"></param>
        public static void BindRepositoryHACodeLookup
            (RepositoryItemPopupContainerEdit popup,
             GridView gridView, int intHaCodeMask)
        {
            var popupContainer = new PopupContainerControl();
            popup.PopupControl = popupContainer;
            DataView dv = GetHacodeView(intHaCodeMask);
            InitPopupContainer(popupContainer, dv, intHaCodeMask);
            popup.QueryResultValue -= PopupContainerEdit_QueryResultValue;
            popup.QueryResultValue += PopupContainerEdit_QueryResultValue;
            popup.QueryPopUp -= PopupContainer_QueryPopUp;
            popup.QueryPopUp += PopupContainer_QueryPopUp;
            popup.QueryDisplayText -= PopupContainer_QueryDisplayText;
            popup.QueryDisplayText += PopupContainer_QueryDisplayText;
            //gridView.ShowFilterPopupListBox -= HACodeColumn_ShowFilterPopupListBox;
            //gridView.ShowFilterPopupListBox += HACodeColumn_ShowFilterPopupListBox;
        }

        private static List<CheckEdit> GetHaCodeChecksList(object sender)
        {
            PopupContainerControl popup = null;
            var popupContainer = sender as PopupContainerEdit;
            if (popupContainer != null)
            {
                if (popupContainer.Properties.PopupControl != null)
                    popup = popupContainer.Properties.PopupControl;
                else if (popupContainer.Tag is RepositoryItemPopupContainerEdit)
                    popup = (popupContainer.Tag as RepositoryItemPopupContainerEdit).PopupControl;
            }
            var repositoryPopupContainer = sender as RepositoryItemPopupContainerEdit;
            if (repositoryPopupContainer != null)
                popup = repositoryPopupContainer.PopupControl;
            if (popup != null)
                return popup.Tag as List<CheckEdit>;
            return null;
        }

        private static void PopupContainerEdit_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            Int32? haCode = 0;
            var listCheckEdit = GetHaCodeChecksList(sender);
            if (listCheckEdit != null)
            {
                haCode +=
                    listCheckEdit.Where(checkEdit => checkEdit.Checked).Sum(checkEdit => Convert.ToInt32(checkEdit.Tag));
                if (haCode > 0)
                {
                    e.Value = haCode;
                    SetValue(sender, haCode.ToString());
                }
                else
                {
                    e.Value = null;
                    SetValue(sender, null);
                }
            }
        }
        private static void SetValue(object sender, string value)
        {
            var ctl = sender as Control;
            if (ctl != null && ctl.DataBindings.Count > 0)
            {
                var binding = ctl.DataBindings[0];
                var obj = binding.DataSource as IObject;
                if (obj != null)
                    obj.SetValue(binding.BindingMemberInfo.BindingField, value);
            }
        }
        private static void PopupContainerTree_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (sender is PopupContainerEdit)
            {
                var popupContainer = (PopupContainerEdit)sender;
                var tree = popupContainer.Properties.PopupControl.Controls[0] as TreeList;
                if (tree != null)
                {
                    tree.FocusedNode = tree.FindNodeByKeyID(tree.Tag);
                }
            }
            else
            {
                Dbg.Debug("unexpected type");
            }
        }

        private static void PopupContainer_QueryPopUp(object sender, CancelEventArgs e)
        {
            Int32 haCode = 0;
            var popupContainer = sender as PopupContainerEdit;
            if (popupContainer != null && !Utils.IsEmpty(popupContainer.EditValue))
            {
                haCode = (Int32)popupContainer.EditValue;
            }
            var lst = GetHaCodeChecksList(sender);
            if (lst != null)
            {
                foreach (var check in lst)
                {
                    check.Checked = (Convert.ToInt32(check.Tag) & haCode) != 0;
                }
            }
        }

        private static void PopupContainer_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            var haCode = Utils.IsEmpty(e.EditValue) ? 0 : Convert.ToInt32(e.EditValue);
            var lst = GetHaCodeChecksList(sender);
            if (lst != null)
            {
                e.DisplayText = String.Empty;
                foreach (var check in lst)
                {
                    var bitset = (Convert.ToInt32(check.Tag) & haCode) != 0;
                    if (bitset)
                    {
                        var s = e.DisplayText;
                        Utils.AppendLine(ref s, check.Text, ", ");
                        e.DisplayText = s;
                    }
                }
            }
        }

        private static void HACodeColumn_ShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e)
        {
            if ((e.Column.FieldName == "intHACode") && (e.ComboBox.Items.Count > 0))
            {
                foreach (FilterItem item in e.ComboBox.Items)
                {
                    var fi = item.Value as FilterItem;
                    if ((fi != null) && fi.Value.Equals(1)) e.ComboBox.Items.Remove(item);
                }
            }
        }

        public static void BindCheckEdit(CheckEdit cb, object ds, string bindField)
        {
            cb.Properties.ValueChecked = true;
            cb.Properties.ValueUnchecked = false;
            cb.Properties.AutoHeight = false;
            cb.Height = 28;
            //cb.Margin = new Padding(3,0,3,0);
            cb.DataBindings.Clear();
            Dbg.Assert(ds != null, "datasource for binding field {0} is not defined", bindField);
            cb.DataBindings.Add("Checked", ds, bindField, false, DataSourceUpdateMode.OnValidation);
        }
    }
}

