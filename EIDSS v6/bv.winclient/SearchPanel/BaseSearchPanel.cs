using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.common.Resources.Images;
using bv.common.Resources.TranslationTool;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;
using bv.winclient.Layout;
using bv.winclient.Localization;
using bv.winclient.SearchPanel.Validate;

namespace bv.winclient.SearchPanel
{
    public partial class BaseSearchPanel : BvXtraUserControl, ISearchPanel
    {
        private readonly List<GroupValidator> m_GroupValidatorList = new List<GroupValidator>();
        private readonly bool m_IsListSearchPanel;
        private readonly Dictionary<Control, string> m_TranslatableControls = new Dictionary<Control, string>();
        private readonly List<Control> m_BvMessagesControls = new List<Control>();

        private SearchPanelDataBinder m_DataBinder;
        private bool m_IsAdditionalPanelVisible;

        private int m_CurrentControlPosition;
        private IObject m_DefaultObject;
        public LinkedContent m_LContent = new LinkedContent();
        public int m_RowInterval = 28;
        private int m_SearchPanelWidth;
        private int m_ControlWidth;
        private int m_ComboControlWidth;
        private bool m_Updating;
        private int m_Shift;
        private readonly FilterParams m_InitialSearchFilter;
        private readonly List<Control> m_AnchoredComboboxes = new List<Control>();
        private readonly bv.winclient.ActionPanel.ActionPanel m_actionPanel;
        private LookUpEdit m_comboBoxToolbox;

        #region get filter params

        /// <summary>
        ///   Getting Params
        /// </summary>
        /// <returns></returns>
        private FilterParams GetFilterParams()
        {
            return SearchPanelHelper.GetFilterParams(CurrentObject, m_LContent);
        }

        private FilterParams GetFilterParamsWithoutToolbox()
        {
            return SearchPanelHelper.GetFilterParams(CurrentObject, new LinkedContent() { m_LinkedItems = m_LContent.m_LinkedItems.Where(s => s.MetaItem.Location != SearchPanelLocation.Toolbox).ToList() });
        }

        #endregion

        public BaseSearchPanel()
        {
            InitializeComponent();
        }

        private void SetButtonWidth(SimpleButton btn)
        {
            var size = btn.CalcBestSize();
            if (size.Width < 75)
                size.Width = 75;
            btn.Width = size.Width;
        }
        public BaseSearchPanel(Type objectType, bool isListSearchPanel, FilterParams initialSearchFilter, bv.winclient.ActionPanel.ActionPanel toolBox, int labelWidth = 0, Func<SearchPanelMetaItem, SearchPanelMetaItem> item = null, Func<IObject, IObject> AdjustObject = null)
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
                return;
            // TODO: Complete member initialization
            m_actionPanel = toolBox;
            ObjectType = objectType;
            m_IsListSearchPanel = isListSearchPanel;
            m_InitialSearchFilter = initialSearchFilter;
            InitPanels(labelWidth);
            InitSearchPanelList(item, AdjustObject);
        }

        public Type ObjectType { get; set; }
        public IObject CurrentObject { get; set; }

        #region ISearchPanel Members

        public event EventHandler Search;

        public virtual FilterParams Parameters
        {
            get { return GetFilterParams(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        private int m_ControlLeftMargin;
        private int m_LabelWidth;
        private void InitPanels(int labelWidth)
        {
            if (labelWidth > 176)
            {
                m_LabelWidth = labelWidth;
                m_SearchPanelWidth = 442 + (m_LabelWidth - labelWidth);
            }
            else
            {
                m_LabelWidth = 176;
                m_SearchPanelWidth = 442;
            }
            m_ControlLeftMargin = m_LabelWidth + 8;
            Width = m_SearchPanelWidth;
            m_ControlWidth = m_SearchPanelWidth - m_ControlLeftMargin - 20;
            m_ComboControlWidth = m_SearchPanelWidth - SearchPanelConstants.ComboLeftMargin - 20;
            mainPanelContainer.AutoScroll = false;

        }

        public void InitializeSearchPanel()
        {
        }

        protected void RaiseSearch()
        {
            var args = new EventArgs(); // SearchPanelEventArgs(Parameters);
            EventHandler handler = Search;
            if (handler != null)
            {
                try
                {
                    handler(this, args);
                }
                catch (ValidationModelException e)
                {
                    MessageForm.Show(BvMessages.Get(e.MessageId));
                }
            }
        }

        protected virtual void Clear()
        {
            foreach (LinkedItem item in m_LContent.m_LinkedItems)
            {
                ClearControlValue(item);
            }
        }

        public void ClearControl(BaseEdit ctrl)
        {
            LinkedItem item = m_LContent.m_LinkedItems.FirstOrDefault(s => s.Controls.Contains(ctrl));
            ClearControlValue(item, ctrl);
        }

        public void InitSearchPanelList(Func<SearchPanelMetaItem, SearchPanelMetaItem> item, Func<IObject, IObject> AdjustObject)
        {
            m_CurrentControlPosition = 4;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                // create default group validator
                m_GroupValidatorList.Add(new GroupValidator());


                IObjectMeta meta = ObjectAccessor.MetaInterface(ObjectType);

                ////object creation
                IObjectCreator meta2 = ObjectAccessor.CreatorInterface(ObjectType);

                CurrentObject = meta2.CreateFake(manager, null, null);
                if (AdjustObject != null)
                    CurrentObject = AdjustObject(CurrentObject);

                if (m_IsListSearchPanel)
                {
                    m_DefaultObject = CurrentObject.CloneWithSetup(manager);
                }

                m_DataBinder = new SearchPanelDataBinder(CurrentObject, m_LContent, this);

                foreach (
                    SearchPanelMetaItem m in
                        meta.SearchPanelMeta.Where(l => l.UseInWin && l.Location == SearchPanelLocation.Main).ToArray())
                {
                    SearchPanelMetaItem i = item == null ? m : item(m);
                    CreatePanel(i, mainPanelContainer);
                }
                foreach (
                    SearchPanelMetaItem m in
                        meta.SearchPanelMeta.Where(l => l.UseInWin && l.Location == SearchPanelLocation.Additional).ToArray())
                {
                    SearchPanelMetaItem i = item == null ? m : item(m);
                    CreatePanel(i, mainPanelContainer);
                }

                m_CurrentControlPosition += 4;
                for (int i = 0; i < 4; i++)
                {
                    CreateComboboxPanel(mainPanelContainer, SearchPanelLocation.Combobox, m_CurrentControlPosition, false);
                    MoveToNextRow();
                }

                CreateComboboxPanel(m_actionPanel, SearchPanelLocation.Toolbox, 8, true);



                SetButtonWidth(btSearch);
                btSearch.Location = new Point(commonPanel2.Width - btSearch.Width - 8, 4);
                commonPanel2.Controls.Add(btSearch);
                btSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                SetButtonWidth(btClear);
                btClear.Location = new Point(btSearch.Left - btClear.Width - 8, 4);
                commonPanel2.Controls.Add(btClear);
                btClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                if (meta.SearchPanelMeta.Any(l => l.UseInWin && l.Location == SearchPanelLocation.Additional))
                {
                    var button = new SimpleButton { Name = "btnShowHideAdditional", Text = SearchPanelHelper.GetText("btnMore") };
                    RegisterTranslationItem(button, "btnMore", true);
                    SetButtonWidth(button);
                    button.Location = new Point(btSearch.Left - button.Width - 8, btSearch.Top);
                    commonPanel2.Controls.Add(button);
                    button.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                    button.Click += ShowHideAdditionalPanelMethod;
                }

                m_DataBinder.BindAllData(true, m_InitialSearchFilter);

                foreach (var control in m_LContent.m_LinkedItems.SelectMany(s => s.Controls))
                {
                    control.EditValueChanged += SelectedIndexChanged;
                }

                var firstOrDefault = m_GroupValidatorList.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    firstOrDefault.Validate();
                }

                //ShowHideAdditionalPanel();

            }
            if (m_InitialSearchFilter != null)
            {
                m_InitialSearchFilter.Clear();
            }
        }

        private void ShowHideAdditionalPanelMethod(object sender, EventArgs arg)
        {
            m_IsAdditionalPanelVisible = !m_IsAdditionalPanelVisible;
            ShowHideAdditionalPanel();
            ((SimpleButton)sender).Text = BvMessages.Get(m_IsAdditionalPanelVisible ? "btnLess" : "btnMore");
            m_TranslatableControls[(SimpleButton)sender] = m_IsAdditionalPanelVisible ? "btnLess" : "btnMore";
            SetButtonWidth((SimpleButton)sender);
            ((SimpleButton)sender).Left = btSearch.Left - ((SimpleButton)sender).Width - 8;
        }

        private void ShowHideAdditionalPanel()
        {


            if (m_LContent.m_LinkedItems.Any(s => s.MetaItem.Location == SearchPanelLocation.Additional))
            {
                var storedAutoScroll = mainPanelContainer.AutoScroll;
                mainPanelContainer.AutoScroll = false;
                mainPanelContainer.SuspendLayout();
                SetRightAnchor(false);
                List<BaseEdit> a =
                    m_LContent.m_LinkedItems.Last(s => s.MetaItem.Location == SearchPanelLocation.Main).Controls;

                int indexMain = mainPanelContainer.Controls.GetChildIndex(a.Last());

                List<BaseEdit> b =
                    m_LContent.m_LinkedItems.Last(s => s.MetaItem.Location == SearchPanelLocation.Additional).
                        Controls;

                int indexAdditional = mainPanelContainer.Controls.GetChildIndex(b.Last());

                if (m_Shift == 0)
                {
                    m_Shift = b[0].Top - a[0].Top;
                }

                if (!m_IsAdditionalPanelVisible)
                {
                    for (int i = indexMain + 1; i <= indexAdditional; i++)
                    {
                        if (mainPanelContainer.Controls[i] is DateEdit)
                        {
                            mainPanelContainer.Controls[i].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        }
                        mainPanelContainer.Controls[i].Visible = false;

                    }
                    for (int i = indexAdditional + 1; i < mainPanelContainer.Controls.Count; i++)
                    {
                        mainPanelContainer.Controls[i].Top -= m_Shift;
                    }
                }
                else
                {
                    for (int i = indexMain + 1; i <= indexAdditional; i++)
                    {
                        mainPanelContainer.Controls[i].Visible = true;
                    }

                    for (int i = indexAdditional + 1; i < mainPanelContainer.Controls.Count; i++)
                    {
                        mainPanelContainer.Controls[i].Top += m_Shift;
                    }
                }
                mainPanelContainer.AutoScroll = storedAutoScroll;
                mainPanelContainer.ResumeLayout();
                SetRightAnchor(true);
            }
        }

        private BaseEdit CreateOperatorControl(EditorType editorType)
        {
            return CreateLookUpEdit(SearchPanelHelper.GetSearchCaseByType(editorType), null);
        }

        private LookUpEdit CreateLookUpEdit(List<object> items, object currentValue, bool bSorting = true)
        {
            return new SearchControlFactory(this).CreateLookUpEdit(items, currentValue, bSorting);
        }

        private LookUpEdit CreateLookUpEdit(IObject obj, string lookupName, List<Tuple<string, string>> columns, object currentValue, bool bBinding)
        {
            return new SearchControlFactory(this).CreateLookUpEdit(obj, lookupName, columns, currentValue, bBinding);
        }

        private PopupContainerEdit CreateMultipleLookUpEdit(IObject obj, string lookupName, object currentValue)
        {
            var controlFactory = new SearchControlFactory(this);
            return controlFactory.CreateMultipleLookUpEdit(obj, lookupName, currentValue);
        }

        public class ComboItem
        {
            public string Name { get; set; }
            public SearchPanelMetaItem Value { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <returns>is created, or not</returns>
        private void CreateComboboxPanel(Control panel, SearchPanelLocation panelLocation, int yPosition, bool bTopPanel)
        {
            IObjectMeta meta = ObjectAccessor.MetaInterface(ObjectType);

            SearchPanelMetaItem[] metaItems =
                meta.SearchPanelMeta.Where(l => l.UseInWin && l.Location == panelLocation && !m_DefaultObject.IsHiddenPersonalData(l.Name)).ToArray();

            List<object> items;
            if (bTopPanel)
            {
                items = metaItems.Select(s => (object)new ComboItem { Name = SearchPanelHelper.GetCaption(s), Value = s }).Reverse()
                                 .Union(new[] { (object)new ComboItem { Name = "", Value = null } }).Reverse().ToList();
                // no items
                if (items.Count == 1)
                {
                    return;
                }
            }
            else
            {
                items = metaItems.Select(s => (object)new ComboItem { Name = SearchPanelHelper.GetCaption(s), Value = s }).ToList();
                // no items
                if (items.Count == 0)
                {
                    return;
                }
            }

            LookUpEdit comboBox = CreateLookUpEdit(items, null, false);
            comboBox.Properties.AllowNullInput = DefaultBoolean.Default;
            comboBox.Properties.NullText = ""; //string.Empty;
            comboBox.MinimumSize = new Size(136, comboBox.Height);
            if (bTopPanel)
            {
                m_comboBoxToolbox = comboBox;
                comboBox.QueryPopUp += (sender, args) =>
                    {
                        var pars = GetFilterParamsWithoutToolbox();
                        List<object> itemsFiltered = items.Where(c => (c as ComboItem).Value == null || !pars.Content.Any(i => i.Key == (c as ComboItem).Value.Name)).ToList();
                        comboBox.Properties.DataSource = itemsFiltered;
                        args.Cancel = false;
                    };
            }

            AddControlToPanel(panel, comboBox, 8, yPosition); //, true

            BaseEdit comboBoxValue = new TextEdit();

            BaseEdit comboOperator = CreateOperatorControl(EditorType.Text);
            comboOperator.Width = 64;

            if (!bTopPanel)
            {
                comboBoxValue.Width = m_ComboControlWidth;
                comboBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                m_AnchoredComboboxes.Add(comboBoxValue);
            }
            else
            {
                comboBoxValue.Width = 230;
                comboBoxValue.Visible = false;
            }

            if (!bTopPanel)
            {
                AddControlToPanel(panel, comboOperator, 152, yPosition);
            }
            AddControlToPanel(panel, comboBoxValue, bTopPanel ? 152 : SearchPanelConstants.ComboLeftMargin, yPosition);

            SimpleButton btSimpleSearch = null;
            if (bTopPanel)
            {
                btSimpleSearch = new SimpleButton();
                btSimpleSearch.Image = ImagesStorage.Get("Browse5");
                btSimpleSearch.Width = 20;
                btSimpleSearch.Height = 20;
                btSimpleSearch.Click += BtSearchTopPanelClick;
                AddControlToPanel(panel, btSimpleSearch, 390, yPosition);
                btSimpleSearch.Visible = false;
            }


            comboBox.EditValueChanged += (a, b) =>
                                             {

                                                 var todel2 =
                                                     m_LContent.m_LinkedItems.SingleOrDefault(c => c.Controls.Contains(a));
                                                 if (todel2 != null)
                                                     m_LContent.m_LinkedItems.Remove(todel2);

                                                 int currentPosition = comboBoxValue.Location.Y;
                                                 int x = comboBoxValue.Location.X;
                                                 int width = comboBoxValue.Width;
                                                 if (!bTopPanel)
                                                 {
                                                     m_AnchoredComboboxes.Remove(comboBoxValue);
                                                 }
                                                 panel.Controls.Remove(comboBoxValue);
                                                 comboBoxValue.Dispose();
                                                 comboBoxValue = null;
                                                 dynamic v = ((LookUpEdit)a).EditValue;

                                                 if (!Utils.IsEmpty(v))
                                                 {
                                                     if (btSimpleSearch != null)
                                                         btSimpleSearch.Visible = true;

                                                     var s = (SearchPanelMetaItem)v;

                                                     Point location = comboOperator.Location;
                                                     int operatorWidth = comboOperator.Width;

                                                     if (!bTopPanel)
                                                     {
                                                         panel.Controls.Remove(comboOperator);
                                                     }
                                                     comboOperator.Dispose();
                                                     comboOperator = CreateOperatorControl(s.EditorType);
                                                     comboOperator.Location = location;
                                                     comboOperator.Width = operatorWidth;
                                                     if (!Utils.IsEmpty(s.DefaultOper))
                                                     {
                                                         comboOperator.EditValue = s.DefaultOper;
                                                     }

                                                     if (!bTopPanel)
                                                     {
                                                         panel.Controls.Add(comboOperator);
                                                     }

                                                     switch (s.EditorType)
                                                     {
                                                         case EditorType.Datetime:
                                                         case EditorType.Date:
                                                             {
                                                                 if (!bTopPanel)
                                                                 {
                                                                     comboBoxValue = new DateEdit();
                                                                 }
                                                                 else
                                                                 {
                                                                     comboBoxValue = new BaseEdit();
                                                                     comboBoxValue.BorderStyle = BorderStyles.NoBorder;
                                                                     comboBoxValue.BackColor = panel.BackColor;
                                                                     comboBoxValue.Font = new Font(panel.Font.FontFamily, 15);
                                                                     CreateDateControl(s, comboBoxValue, true);
                                                                 }
                                                             }
                                                             break;
                                                         case EditorType.Lookup:
                                                             {
                                                                 //List<object> list =
                                                                 //    SearchPanelHelper.GetItemList(CurrentObject, s);

                                                                 //object value =
                                                                 //    SearchPanelHelper.GetCurrentItemValue(
                                                                 //        CurrentObject, s);
                                                                 //comboBoxValue = CreateComboBox(list, value);
                                                                 if (s.IsMultiple)
                                                                     comboBoxValue = CreateMultipleComboBox(CurrentObject, s.LookupName, null);
                                                                 else
                                                                     comboBoxValue = CreateComboBox(CurrentObject, s.LookupName, null, null, false);
                                                             }
                                                             break;
                                                         case EditorType.Numeric:
                                                             {
                                                                 comboBoxValue = new SpinEdit();
                                                             }
                                                             break;
                                                         case EditorType.Text:
                                                             {
                                                                 comboBoxValue = new TextEdit();
                                                             }
                                                             break;
                                                     }
                                                     if (comboBoxValue != null)
                                                     {
                                                         comboBoxValue.Width = width;
                                                         comboBoxValue.Location = new Point(x, currentPosition);
                                                         panel.Controls.Add(comboBoxValue);
                                                         m_LContent.Add(s, comboBox, comboOperator, comboBoxValue);
                                                         if (!bTopPanel)
                                                         {
                                                             comboBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                                             m_AnchoredComboboxes.Add(comboBoxValue);
                                                         }

                                                     }

                                                 }
                                                 else
                                                 {
                                                     if (btSimpleSearch != null)
                                                         btSimpleSearch.Visible = false;
                                                     comboBoxValue = new TextEdit
                                                                         {
                                                                             Width = width,
                                                                             Location =
                                                                                 new Point(x, currentPosition),
                                                                         };

                                                     panel.Controls.Add(comboBoxValue);
                                                     if (!bTopPanel)
                                                     {
                                                         comboBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                                         m_AnchoredComboboxes.Add(comboBoxValue);
                                                     }
                                                     else
                                                     {
                                                         comboBoxValue.Visible = false;
                                                     }

                                                 }
                                             };
        }

        public virtual void CreatePanel(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            if (metaItem.Name.Contains("Custom"))
            {
                switch (metaItem.Name)
                {
                    case "Custom_CaseStatus":
                        {
                            CreateLabelAndAddToPanel(metaItem, panelSearchList);

                            List<object> itemList = new[]
                                                        {
                                                            //(object) new { Name = "", Value = "0" },
                                                            new
                                                                {
                                                                    Name = BvMessages.Get("msgCaseModePassive", "Passive"),
                                                                    Value = "2"
                                                                },
                                                            new
                                                                {
                                                                    Name = BvMessages.Get("msgCaseModeActive", "Active"),
                                                                    Value = "1"
                                                                },
                                                            (object)
                                                            new
                                                                {
                                                                    Name = BvMessages.Get("msgCaseModeVector", "Vector"),
                                                                    Value = "3"
                                                                }
                                                        }.ToList();

                            BaseEdit comboBox = CreateComboBox(itemList, null);

                            AddControlToPanel(panelSearchList, comboBox, m_ControlLeftMargin, m_CurrentControlPosition);
                            m_LContent.Add(metaItem, comboBox);
                            SetDefaultValue(m_LContent.m_LinkedItems.Last());
                            comboBox.EditValueChanged += CheckDefaultValueOnClear;
                        }
                        break;
                }
            }

            else
            {
                switch (metaItem.EditorType)
                {
                    case EditorType.Numeric:
                        {
                            CreateNumericControl(metaItem, panelSearchList);
                        }
                        break;
                    case EditorType.Text:
                        {
                            CreateTextBox(metaItem, panelSearchList);
                        }
                        break;
                    case EditorType.Date:
                        {
                            CreateDateControl(metaItem, panelSearchList);
                        }
                        break;
                    case EditorType.Lookup:
                        if (metaItem.IsMultiple)
                        {
                            CreateLookupMultipleControl(metaItem, panelSearchList);
                        }
                        else
                        {
                            CreateLookupControl(metaItem, panelSearchList);
                        }
                        break;
                    case EditorType.Datetime:
                        {
                            CreateDateControl(metaItem, panelSearchList);
                        }
                        break;
                    case EditorType.Flag:
                        {
                            CreateFlagControl(metaItem, panelSearchList);
                        }
                        break;
                    case EditorType.Separator:
                        {
                            CreateSeparatorControl(metaItem, panelSearchList);
                        }
                        break;
                }
            }
            if (metaItem.Mandatory(CurrentObject))
            {
                var firstOrDefault = m_LContent.m_LinkedItems.FirstOrDefault(c => c.MetaItem == metaItem);
                if (firstOrDefault != null)
                {
                    foreach (
                        BaseEdit ctl in
                            firstOrDefault.Controls)
                    {
                        LayoutCorrector.SetStyleController(ctl, LayoutCorrector.MandatoryStyleController);
                        if (ctl is ButtonEdit)
                        {
                            foreach (EditorButton btn in (ctl as ButtonEdit).Properties.Buttons)
                            {
                                if (btn.Kind == ButtonPredefines.Delete)
                                {
                                    btn.Visible = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            MoveToNextRow();
        }



        public void SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                LinkedItem[] ss =
                    m_LContent.m_LinkedItems.Where(s => s.Controls.Contains(sender)).ToArray();
                if (ss.Any())
                {
                    LinkedItem pair = ss.First();

                    SearchPanelMetaItem metaItem = pair.MetaItem;
                    object editValue = ((BaseEdit)sender).EditValue;
                    if (Utils.IsEmpty(editValue))
                    {
                        if (metaItem.EditorType == EditorType.Lookup)
                        {
                            CurrentObject.SetValue(
                                metaItem.LookupName.Substring(0, metaItem.LookupName.IndexOf("Lookup", StringComparison.Ordinal)), null);
                        }
                        else if (metaItem.EditorType == EditorType.Flag)
                        {
                            // do nothing
                        }
                        else
                            CurrentObject.SetValue(metaItem.Name, null);
                    }
                    else
                    {
                        if (metaItem.EditorType == EditorType.Date || metaItem.EditorType == EditorType.Datetime)
                        {
                            string format = (metaItem.EditorType == EditorType.Date)
                                                ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
                                                : CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
                            string value = ((DateTime)editValue).ToString(format);
                            CurrentObject.SetValue(metaItem.Name, value);
                        }
                        else if (metaItem.EditorType == EditorType.Lookup)
                        {
                            //string value = editValue.ToString();
                            if (!metaItem.IsMultiple)
                            {
                                string value = (editValue as IObject).Key.ToString();
                                CurrentObject.SetValue(
                                    metaItem.LookupName.Substring(0,
                                                                  metaItem.LookupName.IndexOf("Lookup",
                                                                                              StringComparison.Ordinal)),
                                    value);
                            }
                        }
                        else
                        {
                            string value = editValue.ToString();
                            CurrentObject.SetValue(metaItem.Name, value);
                        }
                    }
                }
            }
        }

        public virtual void CreateLookupControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {

            // get item list
            //BvSelectList itemList = SearchPanelHelper.GetList(CurrentObject, metaItem);

            if (metaItem.Location != SearchPanelLocation.Combobox && metaItem.Location != SearchPanelLocation.Toolbox)
            {
                CreateLabelAndAddToPanel(metaItem, panelSearchList);
                var comboBox = CreateComboBox(CurrentObject, metaItem.LookupName, metaItem.LookupColumns, null, true);
                //if (itemList != null)
                //{
                //    if (itemList.items.Count == 0)
                //    {
                //        comboBox.Enabled = false;
                //    }
                //}

                //((LookUpEdit)comboBox).Properties.EditValueChanged += SelectedIndexChanged;

                AddControlToPanel(panelSearchList, comboBox, m_ControlLeftMargin, m_CurrentControlPosition);
                comboBox.Width = m_ControlWidth;
                if (metaItem.Mandatory(CurrentObject))
                {
                    Control validator = ValidatorHelper.CreatMandatoryValidator(comboBox, "this field is mandatory",
                                                                                m_GroupValidatorList.FirstOrDefault());
                    panelSearchList.Controls.Add(validator);
                    var ds = comboBox.Properties.DataSource as IList;
                    if (ds != null && ds.Count > 0)
                    {
                        var emptyElem = ds[0] as IObject;
                        if (emptyElem != null && emptyElem.Key.Equals(0L))
                            ds.Remove(emptyElem);
                    }
                    //This is needed to set lookup to default value if we try to clear mandatory lookup
                    comboBox.EditValueChanged += CheckDefaultValueOnClear;
                }

                m_LContent.Add(metaItem, comboBox);
                SetDefaultValue(m_LContent.m_LinkedItems.Last());


            }
        }

        public virtual void CreateLookupMultipleControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            // get item list
            //BvSelectList itemList = SearchPanelHelper.GetList(CurrentObject, metaItem);
            CreateLabelAndAddToPanel(metaItem, panelSearchList);

            BaseEdit comboBox = CreateMultipleComboBox(CurrentObject, metaItem.LookupName, null);
            //if (itemList != null)
            //{
            //    if (itemList.items.Count == 0)
            //    {
            //        comboBox.Enabled = false;
            //    }
            //}
            //((LookUpEdit)comboBox).Properties.EditValueChanged += SelectedIndexChanged;

            AddControlToPanel(panelSearchList, comboBox, m_ControlLeftMargin, m_CurrentControlPosition);
            comboBox.Width = 402 - comboBox.Left;

            if (metaItem.Mandatory(CurrentObject))
            {
                Control validator = ValidatorHelper.CreatMandatoryValidator(comboBox, "this field is mandatory",
                                                                            m_GroupValidatorList.FirstOrDefault());
                panelSearchList.Controls.Add(validator);
            }

            m_LContent.Add(metaItem, comboBox);
            SetDefaultValue(m_LContent.m_LinkedItems.Last());
            //comboBox.EditValueChanged += CheckDefaultValueOnClear;
        }


        private void AddControlToPanel(Control panelSearchList, Control control, int marginLeft, int yPosition)
        {
            control.Location = new Point(marginLeft, yPosition);
            panelSearchList.Controls.Add(control);
        }

        private void MoveToNextRow()
        {
            m_CurrentControlPosition += m_RowInterval;
        }

        private LookUpEdit CreateComboBox(List<object> itemList, object currentValue)
        {
            return CreateLookUpEdit(itemList, currentValue);
        }

        private LookUpEdit CreateComboBox(IObject obj, string lookupName, List<Tuple<string, string>> columns, object currentValue, bool bBinding)
        {
            return CreateLookUpEdit(obj, lookupName, columns, currentValue, bBinding);
        }

        private PopupContainerEdit CreateMultipleComboBox(IObject obj, string lookupName, object currentValue)
        {
            return CreateMultipleLookUpEdit(obj, lookupName, currentValue);
        }

        public virtual void CreateFlagControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            var flag = new CheckEdit
                           {
                               Name = CreateUniquieControlName(),
                               Width = SearchPanelConstants.TextBoxWidth,
                               Text = SearchPanelHelper.GetCaption(metaItem),
                               Location = new Point(m_ControlLeftMargin, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset)
                           };
            flag.Properties.AllowGrayed = false;
            flag.Properties.NullStyle = StyleIndeterminate.Unchecked;
            flag.Properties.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            flag.Properties.AutoHeight = false;
            flag.Height = 28;
            flag.Margin = new Padding(3,0,3,0);

            LayoutCorrector.SetControlFont(flag);
            panelSearchList.Controls.Add(flag);
            RegisterTranslationItem(flag, metaItem.LabelId);
            m_LContent.Add(metaItem, flag);
            SetDefaultValue(m_LContent.m_LinkedItems.Last());
            flag.EditValueChanged += CheckDefaultValueOnClear;
        }
        private void CreateSeparatorControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            var label = new LabelControl
            {
                Name = CreateUniquieControlName(),
                Text = SearchPanelHelper.GetCaption(metaItem),
                Location = new Point(8, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset),
                MinimumSize = new Size(SearchPanelConstants.LabelMinimumSize, 0),
                AutoSize = false,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = SearchPanelConstants.TextBoxWidth + m_ControlLeftMargin - Location.X - 8,
                Height = 26,
                LineVisible = true,
                LineLocation = LineLocation.Center,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Appearance =
                {
                    TextOptions =
                    {
                        VAlignment = VertAlignment.Center,
                        WordWrap = WordWrap.Wrap,
                        HAlignment = HorzAlignment.Center
                    }
                }
            };
            RegisterTranslationItem(label, metaItem.LabelId);

            panelSearchList.Controls.Add(label);
            label.SendToBack();
        }
        public virtual void CreateNumericControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {


            if (metaItem.IsRange)
            {
                CreateRange(metaItem, panelSearchList);
            }
            else
            {
                CreateLabelAndAddToPanel(metaItem, panelSearchList);

                var textBox1 = new SpinEdit
                                   {
                                       EditValue = null,
                                       Width = SearchPanelConstants.DateTimeWidth,
                                       Location =
                                           new Point(m_ControlLeftMargin, m_CurrentControlPosition)
                                   };
                panelSearchList.Controls.Add(textBox1);
                m_LContent.Add(metaItem, textBox1);
                SetDefaultValue(m_LContent.m_LinkedItems.Last());
                InitSpinEdit(metaItem, textBox1);

                //m_LinkedContent.Add(metaItem, new[] { (BaseEdit)textBox1 }.ToList());
            }
        }

        private void InitSpinEdit(SearchPanelMetaItem metaItem, SpinEdit edit)
        {
            edit.Properties.AllowNullInput = DefaultBoolean.True;
            if (!metaItem.Name.StartsWith("dbl"))
            {
                edit.Properties.MaxValue = int.MaxValue;
                edit.Properties.MinValue = 0;
                edit.Properties.IsFloatValue = false;
                edit.Properties.Mask.MaskType = MaskType.RegEx;
                edit.Properties.Mask.EditMask = @"\d+";
            }
            edit.EditValueChanged += CheckDefaultValueOnClear;

        }
        public virtual void CreateDateControl(SearchPanelMetaItem metaItem, Control panelSearchList, bool bTopPanel = false)
        {
            if (metaItem.IsRange)
            {
                CreateRange(metaItem, panelSearchList, bTopPanel);
            }
            else
            {
                //panelSearchList.Controls.Add(controlOperator);
                CreateLabelAndAddToPanel(metaItem, panelSearchList);

                var dateEdit = new DateEdit
                                   {
                                       Location =
                                           new Point(m_ControlLeftMargin, m_CurrentControlPosition)
                                   };
                DxControlsHelper.InitDateEdit(dateEdit);
                panelSearchList.Controls.Add(dateEdit);
                dateEdit.Width = m_ControlWidth;

                m_LContent.Add(metaItem, dateEdit);
                SetDefaultValue(m_LContent.m_LinkedItems.Last());
                dateEdit.EditValueChanged += CheckDefaultValueOnClear;
            }
        }

        private void CreateRange(SearchPanelMetaItem metaItem, Control panelSearchList, bool bTopPanel = false)
        {

            BaseEdit textBox1;
            BaseEdit textBox2;
            string fromTextId = "lblFrom";
            string toTextId = "lblTo";
            switch (metaItem.EditorType)
            {
                case EditorType.Date:
                case EditorType.Datetime:
                    {
                        textBox1 = new DateEdit
                                       {
                                           EditValue = null,
                                           Width = SearchPanelConstants.DateTimeWidth,
                                           Location = bTopPanel
                                                ?
                                               new Point(0,
                                                         0)
                                                :
                                               new Point(m_ControlLeftMargin,
                                                         m_CurrentControlPosition)
                                       };
                        DxControlsHelper.InitDateEdit((DateEdit)textBox1);
                        textBox2 = new DateEdit { EditValue = null, Width = SearchPanelConstants.DateTimeWidth };
                        DxControlsHelper.InitDateEdit((DateEdit)textBox2);
                    }
                    break;

                case EditorType.Numeric:
                    {
                        fromTextId = "lblFromNumeric";
                        toTextId = "lblToNumeric";
                        textBox1 = new SpinEdit
                                       {
                                           EditValue = null,
                                           Width = SearchPanelConstants.DateTimeWidth,
                                           Location =
                                               new Point(m_ControlLeftMargin,
                                                         m_CurrentControlPosition)
                                       };

                        textBox2 = new SpinEdit { EditValue = null, Width = SearchPanelConstants.DateTimeWidth };
                        InitSpinEdit(metaItem, textBox1 as SpinEdit);
                        InitSpinEdit(metaItem, textBox2 as SpinEdit);

                    }
                    break;

                default:
                    {
                        //textBox1 = new DateEdit();
                        //textBox2 = new DateEdit();
                        throw new Exception("search range is supported for dates and numeric values only");
                    }
            }

            if (metaItem.Mandatory(CurrentObject))
            {
                Control validator = ValidatorHelper.CreatMandatoryValidator(textBox1, "this field is mandatory",
                                                                            m_GroupValidatorList.FirstOrDefault());
                Control validator2 = ValidatorHelper.CreatMandatoryValidator(textBox2, "this field is mandatory",
                                                                             m_GroupValidatorList.FirstOrDefault());
                panelSearchList.Controls.Add(validator);
                panelSearchList.Controls.Add(validator2);

                //textBox1.EditValue = metaItem.DefaultValue;
            }

            var lblFrom = new LabelControl
                              {
                                  Name = CreateUniquieControlName(),
                                  Text = SearchPanelHelper.GetText(fromTextId),
                                  AutoSizeMode = LabelAutoSizeMode.None,
                                  Height = SearchPanelConstants.LabelToHeight
                              };
            lblFrom.Width = lblFrom.CalcBestSize().Width;
            RegisterTranslationItem(lblFrom, fromTextId, true);

            var lblTo = new LabelControl
                            {
                                Name = CreateUniquieControlName(),
                                Text = SearchPanelHelper.GetText(toTextId),
                                AutoSizeMode = LabelAutoSizeMode.None,
                                Height = SearchPanelConstants.LabelToHeight
                            };
            lblTo.Width = lblTo.CalcBestSize().Width;
            RegisterTranslationItem(lblTo, toTextId, true);

            if (bv.common.Core.Localizer.ReverseFromToLabelsPosition)
            {
                lblFrom.Location = new Point(textBox1.Left + textBox1.Width + 4,
                    m_CurrentControlPosition - SearchPanelConstants.LabelYOffset);
                textBox2.Location = new Point(lblFrom.Left + lblFrom.Width + 4, bTopPanel ? 0 : m_CurrentControlPosition);

                lblTo.Location = new Point(textBox2.Left + textBox2.Width + 4,
                                             (bTopPanel ? 0 : m_CurrentControlPosition) - SearchPanelConstants.LabelYOffset);
                lblFrom.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                lblTo.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            }
            else
            {
                if (bTopPanel)
                    textBox1.Left = lblFrom.Width + 4;

                lblFrom.Location = new Point(textBox1.Left - lblFrom.Width - 4, (bTopPanel ? 0 : m_CurrentControlPosition) - SearchPanelConstants.LabelYOffset);
                lblTo.Location = new Point(textBox1.Left + textBox1.Width + 4, (bTopPanel ? 0 : m_CurrentControlPosition) - SearchPanelConstants.LabelYOffset);
                textBox2.Location = new Point(lblTo.Left + lblTo.Width + 4, bTopPanel ? 0 : m_CurrentControlPosition);
                lblFrom.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                lblTo.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }

            lblFrom.SendToBack(); //.BringToFront();

            lblFrom.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            lblTo.Appearance.TextOptions.VAlignment = VertAlignment.Center;

            panelSearchList.Controls.Add(lblFrom);
            panelSearchList.Controls.Add(textBox1);
            lblTo.SendToBack();


            //Anchors for More/Less
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            panelSearchList.Controls.Add(lblTo);
            panelSearchList.Controls.Add(textBox2);

            if (!bTopPanel)
            {
                m_LContent.Add(metaItem, textBox1, textBox2);
                SetDefaultValue(m_LContent.m_LinkedItems.Last());
            }
            textBox1.EditValueChanged += CheckDefaultValueOnClear;
            textBox2.EditValueChanged += CheckDefaultValueOnClear;
            if (!bTopPanel)
            {
                if (bv.common.Core.Localizer.ReverseFromToLabelsPosition)
                    CreateLabelAndAddToPanel(metaItem, panelSearchList);
                else
                    CreateLabelAndAddToPanel(metaItem, panelSearchList,
                                             lblFrom.Left - 12);
            }
        }

        public virtual void CreateTextBox(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            CreateLabelAndAddToPanel(metaItem, panelSearchList);
            var textBox = new TextEdit
                              {
                                  Location = new Point(m_ControlLeftMargin, m_CurrentControlPosition)
                              };

            panelSearchList.Controls.Add(textBox);
            textBox.Width = m_ControlWidth;
            textBox.Properties.MaxLength = 100;
            m_LContent.Add(metaItem, textBox);
            if (metaItem.Mandatory(CurrentObject))
            {
                Control validator = ValidatorHelper.CreatMandatoryValidator(textBox, "this field is mandatory",
                                                                            m_GroupValidatorList.FirstOrDefault());
                panelSearchList.Controls.Add(validator);
            }
            SetDefaultValue(m_LContent.m_LinkedItems.Last());
            textBox.EditValueChanged += CheckDefaultValueOnClear;
        }

        private int m_CtlIndex;
        private string CreateUniquieControlName()
        {
            return string.Format("ctl{0}", m_CtlIndex++);
        }
        private void CreateLabelAndAddToPanel
            (SearchPanelMetaItem metaItem, Control panelSearchList, int width = 0)
        {
            if (width == 0)
                width = m_LabelWidth;
            //           m_CurrentControlPosition += m_RowInterval;
            var label = new LabelControl
                            {
                                Name = CreateUniquieControlName(),
                                Text = SearchPanelHelper.GetCaption(metaItem),
                                Location = new Point(8, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset),
                                MinimumSize = new Size(SearchPanelConstants.LabelMinimumSize, 0),
                                AutoSize = false,
                                AutoSizeMode = LabelAutoSizeMode.None,
                                Width = width,
                                Height = 28,
                                Appearance =
                                    {
                                        TextOptions =
                                            {
                                                VAlignment = VertAlignment.Center,
                                                WordWrap = WordWrap.Wrap,
                                                HAlignment = HorzAlignment.Near
                                            }
                                    }
                            };

            panelSearchList.Controls.Add(label);
            RegisterTranslationItem(label, metaItem.LabelId);
            label.SendToBack();
        }


        private void BtSearchClick(object sender, EventArgs e)
        {
            if (m_comboBoxToolbox != null)
            {
                m_comboBoxToolbox.ItemIndex = 0;
            }
            RaiseSearch();
        }

        private void BtSearchTopPanelClick(object sender, EventArgs e)
        {
            RaiseSearch();
        }


        private void BtClearClick(object sender, EventArgs e)
        {
            Clear();
        }

        private void ClearControlValue(LinkedItem item, BaseEdit ctl = null)
        {
            if (item != null)
            {
                SearchPanelMetaItem meta = item.MetaItem;
                if (meta.Mandatory(CurrentObject))
                {
                    SetDefaultValue(item, ctl);
                }
                else
                {
                    SetControlValue(item, ctl, null);
                }
            }
        }

        private void SetDefaultValue(LinkedItem item, BaseEdit ctl = null)
        {
            if (SetInitialFilter(item))
                return;
            SearchPanelMetaItem meta = item.MetaItem;
            switch (meta.EditorType)
            {
                case EditorType.Date:
                    SetDefaultDate(item, ctl);
                    break;
                default:
                    if (meta.IsRange)
                    {
                        SetDefaultForRange(item, ctl);
                    }
                    else
                    {
                        SetDefaultForSingle(item, ctl);
                    }
                    break;
            }
        }

        private object GetDefaultValue(LinkedItem item)
        {

            object value = null;
            bool bFromDefObj = false;
            if (item.MetaItem.DefaultValue != null)
            {
                value = item.MetaItem.DefaultValue.Invoke(m_DefaultObject);
            }
            if (value == null && m_DefaultObject != null)
            {
                if (item.MetaItem.EditorType == EditorType.Lookup)
                {
                    string name = item.MetaItem.LookupName.Replace("Lookup", "");
                    PropertyInfo pi = m_DefaultObject.GetType().GetProperty(name);
                    if (pi != null)
                    {
                        object val = pi.GetValue(m_DefaultObject, null);
                        value = val;
                        bFromDefObj = true;
                    }
                }
                else
                {
                    value = m_DefaultObject.GetValue(item.MetaItem.Name);
                    bFromDefObj = true;
                }
            }
            if (value == null && item.MetaItem.EditorType == EditorType.Flag)
            {
                value = false;
            }

            if (value != null && !bFromDefObj)
            {
                if (item.MetaItem.EditorType == EditorType.Lookup)
                {
                    string name = item.MetaItem.LookupName.Replace("Lookup", "");
                    PropertyInfo pi = m_DefaultObject.GetType().GetProperty(name);
                    if (pi != null)
                    {
                        pi.SetValue(CurrentObject, value, null);
                    }
                }
                else
                {
                    CurrentObject.SetValue(item.MetaItem.Name, value.ToString());
                }
            }

            return value;
        }

        private void SetDefaultForSingle(LinkedItem item, BaseEdit ctl)
        {
            object value = GetDefaultValue(item);
            SetControlValue(item, ctl, value);
        }

        private void SetDefaultForRange(LinkedItem item, BaseEdit ctl)
        {
            object value = GetDefaultValue(item);
            if (ctl != null)
            {
                SetControlValue(item, ctl, value);
            }
            else
            {
                SetControlValue(item, item.Controls[0], value);
                SetControlValue(item, item.Controls[1], null);
            }
        }

        private bool SetInitialFilter(LinkedItem item)
        {
            if (m_InitialSearchFilter != null && m_InitialSearchFilter.Contains(item.MetaItem.Name))
            {
                for (int i = 0; i < m_InitialSearchFilter.ValueCount(item.MetaItem.Name); i++)
                {
                    if (item.Controls.Count > i)
                    {
                        object value = m_InitialSearchFilter.Value(item.MetaItem.Name, i);
                        //change value type from Long to BaseReference for notmultiple lookups
                        if (item.MetaItem.EditorType.Equals(EditorType.Lookup) && item.MetaItem.IsMultiple == false)
                        {
                            PropertyInfo pi = CurrentObject.GetType().GetProperty(item.MetaItem.LookupName);
                            if (pi != null)
                            {
                                var ds = pi.GetValue(CurrentObject, null);
                                if (ds != null)
                                {
                                    for (int j = 0; j < ((IList)ds).Count; j++)
                                    {
                                        var it = ((IList)ds)[j];
                                        PropertyInfo piItem = it.GetType().GetProperty("Key");
                                        var key = piItem.GetValue(it, null);
                                        if ((long)key == (long)value)
                                        {
                                            value = it;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        SetControlValue(item, item.Controls[i], value);

                        if (item.MetaItem.EditorType == EditorType.Lookup)
                            CurrentObject.SetValue(item.MetaItem.LookupName.Replace("Lookup", ""),
                                                        m_InitialSearchFilter.Value(item.MetaItem.Name, i).ToString());
                        else
                            CurrentObject.SetValue(item.MetaItem.Name,
                                                        m_InitialSearchFilter.Value(item.MetaItem.Name, i).ToString());
                    }
                    else
                        break;
                }
                return true;
            }
            return false;
        }
        private void SetDefaultDate(LinkedItem item, BaseEdit ctl)
        {
            SearchPanelMetaItem meta = item.MetaItem;

            if (meta.DefaultValue == null)
            {
                object val = CurrentObject.GetValue(meta.Name);
                if (val is DateTime && IsFirstInRange(item, ctl))
                {
                    SetControlValue(item, ctl, val);
                }
                else
                {
                    SetControlValue(item, ctl, null);
                }
            }
            else
            {
                object val = meta.DefaultValue;
                if (!(val is DateTime))
                {
                    val = meta.DefaultValue.Invoke(m_DefaultObject);
                }
                if (val is DateTime)
                {
                    if ((DateTime)val != default(DateTime))
                    {
                        if (ctl != null)
                        {
                            if (IsFirstInRange(item, ctl))
                            {
                                SetControlValue(item, ctl, val);
                            }
                            else if (IsSecondInRange(item, ctl))
                            {
                                SetControlValue(item, ctl, DateTime.Today);
                            }
                        }
                        else
                        {
                            SetControlValue(item, item.Controls[0], val);
                            if (meta.IsRange)
                            {
                                SetControlValue(item, item.Controls[1], DateTime.Today);
                            }
                        }
                    }
                }
                else
                {
                    SetControlValue(item, ctl, null);
                    if (ctl == null && meta.IsRange)
                    {
                        SetControlValue(item, item.Controls[1], null);
                    }
                }
            }
        }

        private bool IsFirstInRange(LinkedItem item, BaseEdit ctl)
        {
            if (ctl == null)
            {
                return false;
            }
            return item.Controls[0] == ctl;
        }

        private bool IsSecondInRange(LinkedItem item, BaseEdit ctl)
        {
            if (ctl == null)
            {
                return false;
            }
            return item.MetaItem.IsRange && item.Controls.Count > 1 && item.Controls[1] == ctl;
        }

        private void SetPopupContainerEditValue(BaseEdit ctl, object value, bool isBitMask)
        {
            if (ctl is PopupContainerEdit)
            {
                if (isBitMask && value != null && !(value is int))
                    return;
                var container = (ctl as PopupContainerEdit).Properties.PopupControl;
                var list = container.Controls[0] as CheckedListBoxControl;
                if (list != null)
                {
                    list.UnCheckAll();
                    if (value != null)
                    {
                        //list.SetItemChecked(list.FindStringExact(value.ToString()), true);

                        var item = list.FindItem(0, true, e => e.IsFound = isBitMask ? (Convert.ToInt64(value) & Convert.ToInt64(e.ItemValue)) > 0 : value.Equals(e.ItemValue));
                        if (item >= 0)
                            list.SetItemChecked(item, true);
                    }
                }
                SearchPanelHelper.DisplayMultipleText(ctl as PopupContainerEdit);
            }
        }

        private void SetControlValue(LinkedItem item, BaseEdit ctl, object value)
        {
            if (ctl != null)
            {
                if (ctl is LookUpEdit && (-1L).Equals(value))
                    ctl.EditValue = null;
                else if (!(ctl is PopupContainerEdit))
                    ctl.EditValue = value;
                SetPopupContainerEditValue(ctl, value, item.MetaItem.IsBitMask);
            }
            else if (value != null)
            {
                if (!(item.Controls[0] is PopupContainerEdit))
                    item.Controls[0].EditValue = value;
                SetPopupContainerEditValue(item.Controls[0], value, item.MetaItem.IsBitMask);
            }
            else
            {
                for (int i = 0; i < item.Controls.Count; i++)
                {
                    if ((item.MetaItem.Location == SearchPanelLocation.Combobox || item.MetaItem.Location == SearchPanelLocation.Toolbox) && i < 2)
                        continue;
                    var c = item.Controls[i];
                    //if (item.MetaItem.EditorType == EditorType.Flag)
                    //    c.EditValue = false;
                    //else
                    if (!(c is PopupContainerEdit))
                        c.EditValue = null;
                    SetPopupContainerEditValue(c, null, item.MetaItem.IsBitMask);
                }
            }
        }

        private void CheckDefaultValueOnClear(object sender, EventArgs e)
        {
            if (m_Updating)
            {
                return;
            }
            try
            {
                m_Updating = true;
                LinkedItem item =
                    m_LContent.m_LinkedItems.FirstOrDefault(s => s.Controls.Contains(sender as BaseEdit));
                if (item != null && (item.MetaItem.Mandatory(CurrentObject) && GetDefaultValue(item) != null &&
                                     Utils.IsEmpty(((BaseEdit)sender).EditValue)))
                {
                    SetDefaultValue(item, sender as BaseEdit);
                }
            }
            finally
            {
                m_Updating = false;
            }
        }

        private bool m_FirstLoad = true;
        private void mainPanelContainer_VisibleChanged(object sender, EventArgs e)
        {

            if (Visible && m_FirstLoad)
            {
                ShowHideAdditionalPanel();
                //SetRightAnchor(false);
                mainPanelContainer.AutoScroll = true;
                mainPanelContainer.HorizontalScroll.Visible = false;
                //SetRightAnchor(true);
                m_FirstLoad = false; //this fixes the problem with incorrent controls placing after restoring minimized form
            }

        }
        public void SetRightAnchor(bool setAnchor)
        {
            AnchorStyles anchor = setAnchor
                                      ? AnchorStyles.Top | AnchorStyles.Left |
                                        AnchorStyles.Right
                                      : AnchorStyles.Top | AnchorStyles.Left;
            if (setAnchor)
                mainPanelContainer.HorizontalScroll.Visible = false;
            foreach (var item in m_LContent.m_LinkedItems.Where(s => s.Controls.Count == 1))
            {
                if (setAnchor)
                    item.Controls[item.Controls.Count - 1].Width = mainPanelContainer.ClientSize.Width -
                                                                   item.Controls[item.Controls.Count - 1].Left - 4;
                item.Controls[item.Controls.Count - 1].Anchor = anchor;
            }
            foreach (var ctl in m_AnchoredComboboxes)
            {
                if (setAnchor)
                    ctl.Width = mainPanelContainer.ClientSize.Width -
                                                                   ctl.Left - 4;
                ctl.Anchor = anchor;
            }
        }
        //This is themporary to go around problem with readonly fields on vector detail panel
        public virtual bool IsFieldReadonly(IObject bo, string fieldName)
        {
            return bo != null && bo.IsReadOnly(fieldName);
        }
        public void BindField(string fieldName, FilterParams filter)
        {
            foreach (var item in m_LContent.m_LinkedItems.Where(s => s.MetaItem.Name == fieldName))
                m_DataBinder.Bind(item, false, filter);
        }


        #region ITranslationView
        private void RegisterTranslationItem(Control ctl, string textId, bool isBvMessagesControl = false)
        {
            if (BaseSettings.TranslationMode)
            {
                m_TranslatableControls.Add(ctl, textId);
                if (isBvMessagesControl)
                    m_BvMessagesControls.Add(ctl);
            }
        }
        private string GetResourceNameForControl(Control ctl)
        {
            if (m_BvMessagesControls.Contains(ctl))
                return "BvMessages";
            return "EidssFields";
        }
        public override void ApplyResources(string cultureCode)
        {
            ResourcesList.Clear();
            //entry.Key - control
            //entry.Value - textId
            foreach (var entry in m_TranslatableControls)
            {
                var ctl = entry.Key;
                string resourceName = GetResourceNameForControl(ctl);
                var resValue = CommonResourcesCache.Get(resourceName, cultureCode, entry.Value, GetViewNameForSplittedResources());
                string propName = TranslationToolHelper.GetPropertyName(ctl.Name, TranslationToolHelper.TextPropName);

                if (resValue != null)
                {
                    if (!ResourcesList.ContainsKey(propName))
                        ResourcesList.Add(propName, resValue);
                    ctl.Text = resValue.Value.ToString();
                }
                else
                {
                    if (!ResourcesList.ContainsKey(propName))
                        ResourcesList.Add(propName, new ResourceValue
                            {
                                Value = ctl.Text,
                                //RawValue = ctl.Text,
                                //SourceFileName = string.Format("{0}.{1}.resx", resourceName, cultureCode),
                                EnglishText = WinClientContext.FieldCaptions.GetString(entry.Value, null, common.Core.Localizer.lngEn),
                                SourceKey = entry.Value,
                                ResourceName = resourceName
                            });
                }
            }
            TranslationToolHelper.ReadResxFile(GetType().Name, cultureCode, ResourcesList, DefaultResourcesList);
            TranslationToolHelperWinClient.ApplyResources(btClear, this, cultureCode);
            TranslationToolHelperWinClient.ApplyResources(btSearch, this, cultureCode);
        }
        public override bool SaveChanges(Dictionary<object, DesignElement> changes, string cultureCode)
        {
            bool res = TranslationToolHelperWinClient.SaveViewChanges(this, "EidssFields", changes, cultureCode, false);
            if (res)
                res = TranslationToolHelperWinClient.SaveViewChanges(this, "BvMessages", changes, cultureCode, false);
            if (res)
                res = TranslationToolHelperWinClient.SaveViewChanges(this, GetType().Name, changes, cultureCode, false);
            return res;
        }
        public override string GetKeyForComponent(Component component, DesignElement designType)
        {
            var ctl = component as Control;
            if (ctl != null && m_TranslatableControls.ContainsKey(ctl))
            {
                return m_TranslatableControls[ctl];
            }
            return base.GetKeyForComponent(component, designType);
        }
        private IBasePanel BasePanel
        {
            get
            {
                var ctl = Parent;
                while (ctl != null)
                {
                    var layout = ctl as ILayout;
                    if (layout != null)
                        return layout.ParentBasePanel;
                    ctl = ctl.Parent;
                }
                return null;

            }
        }
        private string GetParentFormViewName()
        {
            var ctl = BasePanel as Control;
            while (ctl != null)
            {
                return ctl.GetType().Name;
            }
            return string.Empty;
        }
        public override string GetResourceNameForComponent(Component component, DesignElement designType)
        {
            if (component == btClear || component == btSearch)
                return GetType().Name;
            var key = GetKeyForComponent(component, designType);
            if (!string.IsNullOrEmpty(ResourceSplitter.Read(GetViewNameForSplittedResources(), key)))
                return string.Empty;
            return GetResourceNameForControl(component as Control);
        }

        public override DesignElement GetDesignTypeForComponent(Component component)
        {
            var ctl = component as Control;
            if (ctl is ControlDesignerProxy)
                ctl = ((ControlDesignerProxy)ctl).HostControl;
            if (ctl != null && (ctl == btClear || ctl == btSearch || m_TranslatableControls.ContainsKey(ctl)))
                return DesignElement.Caption;
            return DesignElement.None;
        }
        public override string GetViewNameForSplittedResources()
        {
            return string.Format("{0}.{1}", GetParentFormViewName(), GetType().Name);
        }
        public override string GetViewNameForResourceUsage()
        {
            var basePanel = BasePanel;
            if (basePanel != null)
            {
                if (basePanel.RootPanel == basePanel)
                    return GetType().Name;
                return string.Format("{0}.{1}", basePanel.GetType().Name, GetType().Name);
            }
            return base.GetViewNameForResourceUsage();
        }

        #endregion

    }
}
