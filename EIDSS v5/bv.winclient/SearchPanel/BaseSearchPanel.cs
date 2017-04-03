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
using bv.common.Core;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.SearchPanel.Validate;

namespace bv.winclient.SearchPanel
{
    public partial class BaseSearchPanel : UserControl, ISearchPanel
    {
        private readonly List<GroupValidator> m_GroupValidatorList = new List<GroupValidator>();
        private readonly bool m_IsListSearchPanel;

        //private readonly Dictionary<SearchPanelMetaItem, List<BaseEdit>> m_LinkedContent =
        //    new Dictionary<SearchPanelMetaItem, List<BaseEdit>>();

        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof(BaseSearchPanel));

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
        #region get filter params

        /// <summary>
        ///   Getting Params
        /// </summary>
        /// <returns></returns>
        private FilterParams GetFilterParams()
        {
            return SearchPanelHelper.GetFilterParams(CurrentObject, m_LContent);
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
            if (btn.Width != size.Width)
                btn.Width = size.Width;
        }
        public BaseSearchPanel(Type objectType, bool isListSearchPanel, FilterParams initialSearchFilter, int labelWidth = 0)
        {
            InitializeComponent();
            if(WinUtils.IsComponentInDesignMode(this))
                return;
            // TODO: Complete member initialization
            ObjectType = objectType;
            m_IsListSearchPanel = isListSearchPanel;
            m_InitialSearchFilter = initialSearchFilter;
            InitPanels(labelWidth);
            InitSearchPanelList();
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

        private int ControlLeftMargin;
        private int LabelWidth;
        private void InitPanels(int labelWidth)
        {
            if (labelWidth > 176)
            {
                LabelWidth = labelWidth;
                m_SearchPanelWidth = 442 + (LabelWidth - labelWidth);
            }
            else
            {
                LabelWidth = 176;
                m_SearchPanelWidth = 442;
            }
            ControlLeftMargin = LabelWidth + 8;
            Width = m_SearchPanelWidth;
            m_ControlWidth = m_SearchPanelWidth - ControlLeftMargin - 20;
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
                handler(this, args);
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

        public void InitSearchPanelList()
        {
            m_CurrentControlPosition = 4;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                // create default group validator
                m_GroupValidatorList.Add(new GroupValidator());


                IObjectMeta meta = ObjectAccessor.MetaInterface(ObjectType);

                ////object creation
                IObjectCreator meta2 = ObjectAccessor.CreatorInterface(ObjectType);

                CurrentObject = meta2.CreateNew(manager, null, null);

                if (m_IsListSearchPanel)
                {
                    m_DefaultObject = CurrentObject.CloneWithSetup(manager);
                }

                m_DataBinder = new SearchPanelDataBinder(CurrentObject, m_LContent, this);

                foreach (
                    SearchPanelMetaItem m in
                        meta.SearchPanelMeta.Where(l => l.Location == SearchPanelLocation.Main).ToArray())
                {
                    CreatePanel(m, mainPanelContainer);
                }
                foreach (
                    SearchPanelMetaItem m in
                        meta.SearchPanelMeta.Where(l => l.Location == SearchPanelLocation.Additional).ToArray())
                {
                    CreatePanel(m, mainPanelContainer);
                }

                m_CurrentControlPosition += 4;
                for (int i = 0; i < 4; i++)
                {
                    CreateComboboxPanel(mainPanelContainer);
                }
                SetButtonWidth(btClear);
                btClear.Location = new Point(commonPanel2.Width - btClear.Width - 8, 4);
                commonPanel2.Controls.Add(btClear);
                btClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                SetButtonWidth(btSearch);
                btSearch.Location = new Point(btClear.Left - btSearch.Width - 8, 4);
                commonPanel2.Controls.Add(btSearch);
                btSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                if (meta.SearchPanelMeta.Any(l => l.Location == SearchPanelLocation.Additional))
                {
                    var button = new SimpleButton { Name = "btnShowHideAdditional", Text = BvMessages.Get("btnMore") };
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

        private LookUpEdit CreateLookUpEdit(List<object> items, object currentValue)
        {
           return new SearchControlFactory(this).CreateLookUpEdit(items, currentValue);
        }

        private LookUpEdit CreateLookUpEdit(IObject obj, string lookupName, object currentValue, bool bBinding)
        {
            return new SearchControlFactory(this).CreateLookUpEdit(obj, lookupName, currentValue, bBinding);
        }

        private PopupContainerEdit CreateMultipleLookUpEdit(IObject obj, string lookupName, object currentValue)
        {
            var controlFactory = new SearchControlFactory(this);
            return controlFactory.CreateMultipleLookUpEdit(obj, lookupName, currentValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <returns>is created, or not</returns>
        private void CreateComboboxPanel(Control panel)
        {
            IObjectMeta meta = ObjectAccessor.MetaInterface(ObjectType);

            SearchPanelMetaItem[] metaItems =
                meta.SearchPanelMeta.Where(l => l.Location == SearchPanelLocation.Combobox && !m_DefaultObject.IsHiddenPersonalData(l.Name)).ToArray();

            List<object> items =
                metaItems.Select(s => (object)(new { Name = SearchPanelHelper.GetCaption(s), Value = s })).ToList();
            // no items
            if (items.Count == 0)
            {
                return;
            }


            LookUpEdit comboBox = CreateLookUpEdit(items, null);
            comboBox.Properties.AllowNullInput = DefaultBoolean.Default;
            comboBox.Properties.NullText = ""; //string.Empty;
            comboBox.MinimumSize = new Size(136, comboBox.Height);

            AddControlToPanel(panel, comboBox, 8); //, true

            BaseEdit comboBoxValue = new TextEdit();

            m_AnchoredComboboxes.Add(comboBoxValue);
            BaseEdit comboOperator = CreateOperatorControl(EditorType.Text);
            comboOperator.Width = 64;

            comboBoxValue.Width = m_ComboControlWidth;

            AddControlToPanel(panel, comboOperator, 152);
            AddControlToPanel(panel, comboBoxValue, SearchPanelConstants.ComboLeftMargin);

            comboBox.EditValueChanged += (a, b) =>
                                             {

                                                 var todel2 =
                                                     m_LContent.m_LinkedItems.SingleOrDefault(c => c.Controls.Contains(a));
                                                 if (todel2 != null)
                                                     m_LContent.m_LinkedItems.Remove(todel2);

                                                 int currentPosition = comboBoxValue.Location.Y;
                                                 int x = comboBoxValue.Location.X;
                                                 int width = comboBoxValue.Width;
                                                 m_AnchoredComboboxes.Remove(comboBoxValue);
                                                 panel.Controls.Remove(comboBoxValue);
                                                 comboBoxValue.Dispose();
                                                 comboBoxValue = null;
                                                 dynamic v = ((LookUpEdit)a).EditValue;

                                                 if (!Utils.IsEmpty(v))
                                                 {
                                                     var s = (SearchPanelMetaItem)v;

                                                     Point location = comboOperator.Location;
                                                     int operatorWidth = comboOperator.Width;

                                                     panel.Controls.Remove(comboOperator);
                                                     comboOperator.Dispose();
                                                     comboOperator = CreateOperatorControl(s.EditorType);
                                                     comboOperator.Location = location;
                                                     comboOperator.Width = operatorWidth;
                                                     if (!Utils.IsEmpty(s.DefaultOper))
                                                     {
                                                         comboOperator.EditValue = s.DefaultOper;
                                                     }

                                                     panel.Controls.Add(comboOperator);

                                                     switch (s.EditorType)
                                                     {
                                                         case EditorType.Datetime:
                                                         case EditorType.Date:
                                                             {
                                                                 comboBoxValue = new DateEdit(); //DateTimePicker();
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
                                                                 comboBoxValue = CreateComboBox(CurrentObject, s.LookupName, null, false);
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
                                                         comboBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                                                                AnchorStyles.Right;
                                                         m_AnchoredComboboxes.Add(comboBoxValue);

                                                     }

                                                 }
                                                 else
                                                 {
                                                     comboBoxValue = new TextEdit
                                                                         {
                                                                             Width = width,
                                                                             Location =
                                                                                 new Point(x, currentPosition),
                                                                         };

                                                     panel.Controls.Add(comboBoxValue);
                                                     comboBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                                                            AnchorStyles.Right;
                                                     m_AnchoredComboboxes.Add(comboBoxValue);

                                                 }
                                             };
            MoveToNextRow();
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

                            AddControlToPanel(panelSearchList, comboBox, ControlLeftMargin);
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
            if (metaItem.IsMandatory)
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
                            /*string value = editValue.ToString();
                            CurrentObject.SetValue(
                                metaItem.LookupName.Substring(0, metaItem.LookupName.IndexOf("Lookup", StringComparison.Ordinal)), value);*/
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
            BvSelectList itemList = SearchPanelHelper.GetList(CurrentObject, metaItem);

            if (metaItem.Location != SearchPanelLocation.Combobox)
            {
                CreateLabelAndAddToPanel(metaItem, panelSearchList);
                var comboBox = CreateComboBox(CurrentObject, metaItem.LookupName, null, true);
                //if (itemList != null)
                //{
                //    if (itemList.items.Count == 0)
                //    {
                //        comboBox.Enabled = false;
                //    }
                //}

                //((LookUpEdit)comboBox).Properties.EditValueChanged += SelectedIndexChanged;

                AddControlToPanel(panelSearchList, comboBox, ControlLeftMargin);
                comboBox.Width = m_ControlWidth;
                if (metaItem.IsMandatory)
                {
                    Control validator = ValidatorHelper.CreatMandatoryValidator(comboBox, "this field is mandatory",
                                                                                m_GroupValidatorList.FirstOrDefault());
                    panelSearchList.Controls.Add(validator);
                    var ds =  comboBox.Properties.DataSource as IList;
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

            AddControlToPanel(panelSearchList, comboBox, ControlLeftMargin);
            comboBox.Width = 402 - comboBox.Left;

            if (metaItem.IsMandatory)
            {
                Control validator = ValidatorHelper.CreatMandatoryValidator(comboBox, "this field is mandatory",
                                                                            m_GroupValidatorList.FirstOrDefault());
                panelSearchList.Controls.Add(validator);
            }

            m_LContent.Add(metaItem, comboBox);
            //SetDefaultValue(m_LContent.m_LinkedItems.Last());
            //comboBox.EditValueChanged += CheckDefaultValueOnClear;
        }


        private void AddControlToPanel(Control panelSearchList, Control control, int marginLeft)
        {
            control.Location = new Point(marginLeft, m_CurrentControlPosition);
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

        private LookUpEdit CreateComboBox(IObject obj, string lookupName, object currentValue, bool bBinding)
        {
            return CreateLookUpEdit(obj, lookupName, currentValue, bBinding);
        }

        private PopupContainerEdit CreateMultipleComboBox(IObject obj, string lookupName, object currentValue)
        {
            return CreateMultipleLookUpEdit(obj, lookupName, currentValue);
        }

        public virtual void CreateFlagControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            var flag = new CheckEdit
                           {
                               Width = SearchPanelConstants.TextBoxWidth,
                               Text = SearchPanelHelper.GetCaption(metaItem),
                               Location = new Point(ControlLeftMargin, m_CurrentControlPosition)
                           };
            flag.Properties.AllowGrayed = false;
            flag.Properties.NullStyle = StyleIndeterminate.Unchecked;
            panelSearchList.Controls.Add(flag);
            m_LContent.Add(metaItem, flag);
            SetDefaultValue(m_LContent.m_LinkedItems.Last());
            flag.EditValueChanged += CheckDefaultValueOnClear;
        }
        private void CreateSeparatorControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            var label = new LabelControl
            {
                Text = SearchPanelHelper.GetCaption(metaItem),
                Location = new Point(8, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset),
                MinimumSize = new Size(SearchPanelConstants.LabelMinimumSize, 0),
                AutoSize = false,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = SearchPanelConstants.TextBoxWidth + ControlLeftMargin - Location.X - 8,
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
                                           new Point(ControlLeftMargin, m_CurrentControlPosition)
                                   };

                panelSearchList.Controls.Add(textBox1);
                m_LContent.Add(metaItem, textBox1);
                SetDefaultValue(m_LContent.m_LinkedItems.Last());
                textBox1.EditValueChanged += CheckDefaultValueOnClear;

                //m_LinkedContent.Add(metaItem, new[] { (BaseEdit)textBox1 }.ToList());
            }
        }

        public virtual void CreateDateControl(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            if (metaItem.IsRange)
            {
                CreateRange(metaItem, panelSearchList);
            }
            else
            {
                //panelSearchList.Controls.Add(controlOperator);
                CreateLabelAndAddToPanel(metaItem, panelSearchList);

                var textBox1 = new DateEdit
                                   {
                                       Location =
                                           new Point(ControlLeftMargin, m_CurrentControlPosition)
                                   };

                //if (metaItem.DefaultValue == null)
                //{
                //    object val = CurrentObject.GetValue(metaItem.Name);
                //    if (val is DateTime)
                //    {
                //        //textBox2.EditValue = DateTime.Now;
                //        textBox1.EditValue = (DateTime)val;
                //    }
                //}
                //else
                //{
                //    object val = metaItem.DefaultValue.ToString();
                //    if (!(val is DateTime))
                //    {
                //        val = metaItem.DefaultValue.Invoke();
                //    }
                //    //textBox2.EditValue = DateTime.Today;
                //    textBox1.EditValue = (DateTime)val; // metaItem.DefaultValue;
                //}

                textBox1.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                textBox1.Properties.MinValue = new DateTime(1900, 1, 1);
                //textBox1.Properties.EditFormat.FormatString = "MM/dd/yyyy";

                panelSearchList.Controls.Add(textBox1);
                textBox1.Width = m_ControlWidth;
                //textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                m_LContent.Add(metaItem, textBox1);
                SetDefaultValue(m_LContent.m_LinkedItems.Last());
                textBox1.EditValueChanged += CheckDefaultValueOnClear;
                //m_LinkedContent.Add(metaItem, new[] { (BaseEdit)textBox1 }.ToList());
            }
        }

        private void CreateRange(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            if (CultureInfo.CurrentCulture.Name == "ka-GE")
                CreateLabelAndAddToPanel(metaItem, panelSearchList);
            else
                CreateLabelAndAddToPanel(metaItem, panelSearchList,
                                     LabelWidth - SearchPanelConstants.LabelToWidth);

            BaseEdit textBox1;
            BaseEdit textBox2;
            string fromText = SearchPanelHelper.GetText("lblFrom");
            string toText = SearchPanelHelper.GetText("lblTo");
            switch (metaItem.EditorType)
            {
                case EditorType.Date:
                case EditorType.Datetime:
                    {
                        textBox1 = new DateEdit
                                       {
                                           EditValue = null,
                                           Width = SearchPanelConstants.DateTimeWidth,
                                           Location =
                                               new Point(ControlLeftMargin,
                                                         m_CurrentControlPosition)
                                       };

                        textBox1.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        (textBox1 as DateEdit).Properties.MinValue = new DateTime(1900, 1, 1);
                        textBox2 = new DateEdit { EditValue = null, Width = SearchPanelConstants.DateTimeWidth };
                        textBox2.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        (textBox2 as DateEdit).Properties.MinValue = new DateTime(1900, 1, 1);
                    }
                    break;

                case EditorType.Numeric:
                    {
                        fromText = SearchPanelHelper.GetText("lblFromNumeric");
                        toText = SearchPanelHelper.GetText("lblToNumeric");
                        textBox1 = new SpinEdit
                                       {
                                           EditValue = null,
                                           Width = SearchPanelConstants.DateTimeWidth,
                                           Location =
                                               new Point(ControlLeftMargin,
                                                         m_CurrentControlPosition)
                                       };

                        textBox2 = new SpinEdit { EditValue = null, Width = SearchPanelConstants.DateTimeWidth };
                    }
                    break;

                default:
                    {
                        //textBox1 = new DateEdit();
                        //textBox2 = new DateEdit();
                        throw new Exception("search range is supported for dates and numeric values only");
                    }
            }

            if (metaItem.IsMandatory)
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
                                  Text = fromText,
                                  AutoSizeMode = LabelAutoSizeMode.None,
                                  Height = SearchPanelConstants.LabelToHeight
                              };
            lblFrom.Width = lblFrom.CalcBestSize().Width;

            var lblTo = new LabelControl
                            {
                                Text = toText,
                                AutoSizeMode = LabelAutoSizeMode.None,
                                Height = SearchPanelConstants.LabelToHeight
                            };
            lblTo.Width = lblTo.CalcBestSize().Width;

            if (CultureInfo.CurrentCulture.Name == "ka-GE")
            {
                lblFrom.Location = new Point(textBox1.Left + textBox1.Width + 4,
                    m_CurrentControlPosition - SearchPanelConstants.LabelYOffset);
                textBox2.Location = new Point(lblFrom.Left + lblFrom.Width + 4, m_CurrentControlPosition);

                lblTo.Location = new Point(textBox2.Left + textBox2.Width + 4,
                                             m_CurrentControlPosition - SearchPanelConstants.LabelYOffset);
                lblFrom.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                lblTo.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            }
            else
            {
                lblFrom.Location = new Point(textBox1.Left - lblFrom.Width - 4, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset);
                lblTo.Location = new Point(textBox1.Left + textBox1.Width + 4, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset);
                textBox2.Location = new Point(lblTo.Left + lblTo.Width + 4, m_CurrentControlPosition);
                lblFrom.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                lblTo.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }

            lblFrom.SendToBack(); //.BringToFront();
            lblFrom.Name = "lblFrom";

            lblFrom.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            lblTo.Appearance.TextOptions.VAlignment = VertAlignment.Center;

            panelSearchList.Controls.Add(lblFrom);
            panelSearchList.Controls.Add(textBox1);
            lblTo.Name = "lblTo";
            lblTo.SendToBack();


            //Anchors for More/Less
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            panelSearchList.Controls.Add(lblTo);
            panelSearchList.Controls.Add(textBox2);

            m_LContent.Add(metaItem, textBox1, textBox2);
            SetDefaultValue(m_LContent.m_LinkedItems.Last());
            textBox1.EditValueChanged += CheckDefaultValueOnClear;
            textBox2.EditValueChanged += CheckDefaultValueOnClear;
        }

        public virtual void CreateTextBox(SearchPanelMetaItem metaItem, Control panelSearchList)
        {
            CreateLabelAndAddToPanel(metaItem, panelSearchList);
            var textBox = new TextEdit
                              {
                                  Location = new Point(ControlLeftMargin, m_CurrentControlPosition)
                              };

            panelSearchList.Controls.Add(textBox);
            textBox.Width = m_ControlWidth;
            textBox.Properties.MaxLength = 100;
            m_LContent.Add(metaItem, textBox);
            if (metaItem.IsMandatory)
            {
                Control validator = ValidatorHelper.CreatMandatoryValidator(textBox, "this field is mandatory",
                                                                            m_GroupValidatorList.FirstOrDefault());
                panelSearchList.Controls.Add(validator);
            }
            SetDefaultValue(m_LContent.m_LinkedItems.Last());
            textBox.EditValueChanged += CheckDefaultValueOnClear;
        }



        private void CreateLabelAndAddToPanel
            (SearchPanelMetaItem metaItem, Control panelSearchList, int width = 0)
        {
            if (width == 0)
                width = LabelWidth;
            //           m_CurrentControlPosition += m_RowInterval;
            var label = new LabelControl
                            {
                                Text = SearchPanelHelper.GetCaption(metaItem),
                                Location = new Point(8, m_CurrentControlPosition - SearchPanelConstants.LabelYOffset),
                                MinimumSize = new Size(SearchPanelConstants.LabelMinimumSize, 0),
                                AutoSize = false,
                                AutoSizeMode = LabelAutoSizeMode.None,
                                Width = width,
                                Height = 26,
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
            label.SendToBack();
        }

        private void BtSearchClick(object sender, EventArgs e)
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
                if (meta.IsMandatory)
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
            if (item.MetaItem.DefaultValue != null)
            {
                value = item.MetaItem.DefaultValue.Invoke();
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
                    }
                }
                else
                {
                    value = m_DefaultObject.GetValue(item.MetaItem.Name);
                }
            }
            if (value == null && item.MetaItem.EditorType == EditorType.Flag)
                value = false;
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
                        SetControlValue(item, item.Controls[i], m_InitialSearchFilter.Value(item.MetaItem.Name, i));
                        CurrentObject.SetValue(item.MetaItem.Name, m_InitialSearchFilter.Value(item.MetaItem.Name, i).ToString());
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
                    val = meta.DefaultValue.Invoke();
                }
                if (val is DateTime)
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

        private void SetPopupContainerEditValue(BaseEdit ctl, object value)
        {
            if (ctl is PopupContainerEdit)
            {
                var container = (ctl as PopupContainerEdit).Properties.PopupControl;
                var list = container.Controls[0] as CheckedListBoxControl;
                list.UnCheckAll();
                if (value != null)
                {
                    list.SetItemChecked(list.FindStringExact(value.ToString()), true);
                }
            }
        }

        private void SetControlValue(LinkedItem item, BaseEdit ctl, object value)
        {
            if (ctl != null)
            {
                ctl.EditValue = value;
                SetPopupContainerEditValue(ctl, value);
            }
            else if (value != null)
            {
                item.Controls[0].EditValue = value;
                SetPopupContainerEditValue(item.Controls[0], value);
            }
            else
            {
                for (int i = 0; i < item.Controls.Count; i++)
                {
                    if (item.MetaItem.Location == SearchPanelLocation.Combobox && i < 2)
                        continue;
                    var c = item.Controls[i];
                    //if (item.MetaItem.EditorType == EditorType.Flag)
                    //    c.EditValue = false;
                    //else
                    c.EditValue = null;
                    SetPopupContainerEditValue(c, null);
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
                if (item != null && (item.MetaItem.IsMandatory && GetDefaultValue(item) != null &&
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

        private bool firstLoad = true;
        private void mainPanelContainer_VisibleChanged(object sender, EventArgs e)
        {

            if (Visible && firstLoad)
            {
                ShowHideAdditionalPanel();
                //SetRightAnchor(false);
                mainPanelContainer.AutoScroll = true;
                mainPanelContainer.HorizontalScroll.Visible = false;
                //SetRightAnchor(true);
                firstLoad = false; //this fixes the problem with incorrent controls placing after restoring minimized form
            }

        }
        public void SetRightAnchor(bool setAnchor)
        {
            AnchorStyles anchor = setAnchor
                                      ? AnchorStyles.Top | AnchorStyles.Left |
                                        AnchorStyles.Right
                                      : AnchorStyles.Top | AnchorStyles.Left;
            if(setAnchor)
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
    }
}
