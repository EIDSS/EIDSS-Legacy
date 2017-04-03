using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using bv.winclient.Localization;
using eidss.model.Enums;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Schema;

namespace eidss.winclient.FlexForms.Controls
{
    public partial class Parameter : ParameterHost
    {
        public Parameter()
        {
            InitializeComponent();

            //убираем splitter (для показа не нужен)
            m_Splitter.Visible = false;
        }

        /// <summary>
        /// Текст, отображаемый в текстовой метке
        /// </summary>
        public new string Text
        {
            get { return m_TextMark.Text; }
            set { m_TextMark.Text = value; }
        }

        /// <summary>
        /// Быстрая ссылка на управляющий компонент
        /// </summary>
        internal BaseEdit ControlParameter { get; set; }

        private FFParameterEditors m_Editor;
        private FFParameterScheme m_Scheme;

        /// <summary>
        /// Нажатие на кнопку на управляющем контроле, если он Lookup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonControlClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind != ButtonPredefines.Delete) return;
            if (ControlParameter != null)
            {
                ControlParameter.EditValue = null;
            }
        }

        /// <summary>
        /// Кнопка X, используемая для удаления значения в контроле управления
        /// </summary>
        private EditorButton m_DeleteEditorButton;

        public delegate void EditValueChangingDelegate(object sender, ChangingEventArgs e);

        /// <summary>
        /// Событие срабатывает, когда меняется значение параметра
        /// </summary>
        public event EditValueChangingDelegate EditValueChanging;

        /// <summary>
        /// Событие на изменение значения в ячейке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnControlEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (EditValueChanging != null) EditValueChanging(sender, e);
        }

        /// <summary>
        /// Определяет маску для параметра, исходя из его типа
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        private static MaskProperties GetMaskPropertiesForParameter(long parameterType)
        {
            var result = new MaskProperties();

            if (parameterType.Equals((long)FFParameterTypes.Numeric))
            {
                result.EditMask = @"f";
                result.MaskType = MaskType.Numeric;
            }
            else if (parameterType.Equals((long)FFParameterTypes.NumericNatural))
            {
                result.EditMask = @"\d+";
                result.MaskType = MaskType.RegEx;
            }
            else if (parameterType.Equals((long)FFParameterTypes.NumericPositive))
            {
                //определим разделитель в маске, исходя из текущей культуры
                result.EditMask = String.Format(@"\d+([" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + @"]?\d+)?");
                result.MaskType = MaskType.RegEx;
                result.ShowPlaceHolders = false;
            }
            else if (parameterType.Equals((long)FFParameterTypes.NumericInteger))
            {
                result.EditMask = @"d";
                result.MaskType = MaskType.Numeric;
            }
            else
            {
                result.EditMask = String.Empty;
                result.MaskType = MaskType.None;
            }

            return result;
        }

        /// <summary>
        /// Компонент управления в этом параметре
        /// </summary>
        public FFParameterEditors Editor
        {
            get { return m_Editor; }
            set
            {
                if ((ControlParameter == null) || (m_Editor != value))
                {
                    if (ControlParameter != null)
                    {
                        m_LabelControl.Controls.Remove(ControlParameter);
                        ControlParameter.Dispose();
                    }
                    switch (value)
                    {
                        case FFParameterEditors.TextBox:
                            ControlParameter = new TextEdit();
                            break;
                        case FFParameterEditors.ComboBox:
                            ControlParameter = new LookUpEdit();
                            var le = ControlParameter as LookUpEdit;
                            le.Properties.NullText = String.Empty;
                            le.Properties.ValueMember = "idfsValue";
                            le.Properties.DisplayMember = "strValueCaption";
                            var column = new LookUpColumnInfo("strValueCaption", 120);
                            //column.SortOrder = ColumnSortOrder.Ascending;
                            le.Properties.Columns.Add(column);
                            le.Properties.ShowHeader = le.Properties.ShowFooter = false;
                            m_DeleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                            le.Properties.Buttons.Add(m_DeleteEditorButton);
                            le.ButtonClick += OnButtonControlClick;
                            break;
                        case FFParameterEditors.CheckBox:
                            ControlParameter = new CheckEdit { Text = String.Empty };
                            var checkEdit = (CheckEdit)ControlParameter;
                            checkEdit.Properties.AutoWidth = true;
                            checkEdit.Properties.NullStyle = StyleIndeterminate.Unchecked;
                            checkEdit.Properties.FullFocusRect = true;
                            break;
                        case FFParameterEditors.Date:
                            ControlParameter = new DateEdit();
                            m_DeleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                            var de = (DateEdit)ControlParameter;
                            DxControlsHelper.InitDateEdit(de);
                            de.Properties.Buttons.Add(m_DeleteEditorButton);
                            de.ButtonClick += OnButtonControlClick;
                            break;
                        case FFParameterEditors.DateTime:
                            ControlParameter = new TimeEdit();
                            var te = (TimeEdit)ControlParameter;
                            te.Properties.EditMask = "g";
                            m_DeleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                            te.Properties.Buttons.Add(m_DeleteEditorButton);
                            te.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            te.ButtonClick += OnButtonControlClick;
                            break;
                        case FFParameterEditors.Memo:
                            ControlParameter = new MemoEdit();
                            break;
                        case FFParameterEditors.UpDown:
                            ControlParameter = new SpinEdit();
                            var se = (SpinEdit)ControlParameter;
                            se.Properties.MaxValue = 99000000;
                            se.Properties.MinValue = 0;
                            m_DeleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                            se.Properties.Buttons.Add(m_DeleteEditorButton);
                            se.ButtonClick += OnButtonControlClick;
                            break;
                        default:
                            //это крайне маловероятно, но всё же
                            ControlParameter = new TextEdit();
                            break;
                    }
                    ControlParameter.Dock = DockStyle.Fill;
                    ControlParameter.Tag = this; //укажем ссылку на сам этот параметр
                    ControlParameter.EditValueChanged += OnControlParameterEditValueChanged;
                    ControlParameter.EditValueChanging += OnControlEditValueChanging;
                    m_LabelControl.Controls.Add(ControlParameter);
                    ControlParameter.EditValue = null;
                }

                m_Editor = value;

                if (value == FFParameterEditors.ComboBox)
                {
                    //связываем с выборкой данных
                    RefreshSelectListInControl();
                }

                if ((Tag != null) && ((value == FFParameterEditors.TextBox) || (value == FFParameterEditors.UpDown)))
                {
                    var parameterTemplate = Tag as ParameterTemplate;
                    //если тип данных -- Numeric, то накладываем маску
                    //иначе снимаем маску
                    long parameterType = -1;
                    if ((parameterTemplate != null) && parameterTemplate.idfsParameterType.HasValue)
                        parameterType = parameterTemplate.idfsParameterType.Value;
                    if (parameterType > -1)
                    {
                        var result = GetMaskPropertiesForParameter(parameterType);

                        var textEdit = ControlParameter as TextEdit;
                        if (textEdit != null)
                        {
                            textEdit.Properties.Mask.EditMask = result.EditMask;
                            textEdit.Properties.Mask.MaskType = result.MaskType;
                            textEdit.Properties.Mask.ShowPlaceHolders = false;
                        }
                        var spinEdit = ControlParameter as SpinEdit;
                        if (spinEdit != null)
                        {
                            spinEdit.Properties.Mask.EditMask = result.EditMask;
                            spinEdit.Properties.Mask.MaskType = result.MaskType;
                            spinEdit.Properties.Mask.ShowPlaceHolders = false;
                        }
                    }                    
                }
            }
        }

        /// <summary>
        /// Корневая табличная секция, к которой опосредованно относится данный параметр
        /// </summary>
        public SectionTable RootSection { get; set; }

        /// <summary>
        /// Обновляет перечень данных в управляющем контроле в случае выпадающего списка
        /// </summary>
        internal void RefreshSelectListInControl()
        {
            //связываем с выборкой данных
            var le = ControlParameter as LookUpEdit;
            if (le == null) return;
            var parameter = Tag as ParameterTemplate;
            if (parameter == null) return;
            le.Properties.DataSource = parameter.SelectList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnControlParameterEditValueChanged(object sender, EventArgs e)
        {
            if (EditValueChanged != null) EditValueChanged(sender, e);
        }

        public delegate void EditValueChangedDelegate(object sender, EventArgs e);

        /// <summary>
        /// Событие срабатывает, когда  значение управляющего контрола изменилось
        /// </summary>
        public event EditValueChangedDelegate EditValueChanged;

        /// <summary>
        /// Стандартная схема параметра
        /// </summary>
        public FFParameterScheme Scheme
        {
            get { return m_Scheme; }
            set
            {
                m_Scheme = value;

                //panelLabel.Dock = DockStyle.None;
                //panelControl.Dock = DockStyle.None;
                m_LabelControl.Dock = DockStyle.None;

                //устанавливаем панелям форматирование
                switch (m_Scheme)
                {
                    case FFParameterScheme.Left:
                        //panelLabel.Dock = splitter.Dock = DockStyle.Left;
                        m_TextMark.Dock = m_Splitter.Dock = DockStyle.Left;
                        break;
                    case FFParameterScheme.Right:
                        //panelLabel.Dock = splitter.Dock = DockStyle.Right;
                        m_TextMark.Dock = m_Splitter.Dock = DockStyle.Right;
                        break;
                    case FFParameterScheme.Top:
                        //labelControl.Dock = splitter.Dock = DockStyle.Bottom;
                        m_LabelControl.Dock = m_Splitter.Dock = DockStyle.Bottom;
                        break;
                    case FFParameterScheme.Bottom:
                        //panelControl.Dock = splitter.Dock = DockStyle.Top;
                        m_LabelControl.Dock = m_Splitter.Dock = DockStyle.Top;
                        break;
                }
                m_Splitter.BringToFront();
                //донастройка
                if (Scheme.IsHorizontalOrientation())
                {
                    //panelControl.Dock = DockStyle.Fill;
                    //panelControl.BringToFront();
                    m_LabelControl.Dock = DockStyle.Fill;
                    m_LabelControl.BringToFront();
                }
                else
                {
                    m_TextMark.Dock = DockStyle.Fill;
                    //panelControl.Height = controlParameter.Height;
                    m_LabelControl.Height = ControlParameter.Height;
                    m_TextMark.BringToFront();
                }
            }
        }

        /// <summary>
        /// Ссылка на перечень параметров для быстрого доступа
        /// </summary>
        public Dictionary<long, Parameter> ParameterList { get; set; }

        /// <summary>
        /// Величина текстового поля
        /// </summary>
        public int LabelSize
        {
            get
            {
                return Scheme.IsHorizontalOrientation()
                           ? m_TextMark.Width//panelLabel.Width
                           : Height - m_LabelControl.Height;//panelControl.Height;
            }
            set
            {
                if (value < 0) value = 0;
                if (Scheme.IsHorizontalOrientation())
                {
                    //panelLabel.Width = value;
                    m_TextMark.Width = value;
                }
                else
                {
                    //panelControl.Height = Height - value;
                    m_LabelControl.Height = Height - value;
                }
            }
        }
    }
}
