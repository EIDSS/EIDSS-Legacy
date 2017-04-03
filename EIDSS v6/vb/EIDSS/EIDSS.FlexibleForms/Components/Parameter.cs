using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using bv.common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.DesignerHosting;
using EIDSS.FlexibleForms.Helpers;
using System.Data;
using bv.common.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;

namespace EIDSS.FlexibleForms.Components
{
    public class Parameter : ParameterHost
    {
        /// <summary>
        /// Быстрая ссылка на управляющий компонент
        /// </summary>
        internal BaseEdit ControlParameter { get; set; }

        private FFParameterEditors m_Editor;
        private FFParameterScheme m_Scheme;
        internal LabelControl m_TextMark;
        internal LabelControl m_LabelControl;
        internal SplitterControl m_Splitter;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Parameter()
        {
            InitializeComponent();

            Editor = FFParameterEditors.TextBox;

            Scheme = FFParameterScheme.Left;

            Move += ParameterMoveAndResize;
            Resize += ParameterMoveAndResize;
            m_Splitter.SplitterMoved += ParameterMoveAndResize;
            OnDesignModeChanged += OnDesignModeChangedHandler;

            ParameterSelectListFull = new FlexibleFormsDS.ParameterSelectListDataTable();

            NowLoading = false;
        }

        public delegate void EditValueChangedDelegate(object sender, EventArgs e);

        /// <summary>
        /// Событие срабатывает, когда  значение управляющего контрола изменилось
        /// </summary>
        public event EditValueChangedDelegate EditValueChanged;

        /// <summary>
        /// Изменилось значение свойства IsDesignMode
        /// </summary>
        private void OnDesignModeChangedHandler()
        {
            m_Splitter.Visible = IsDesignMode;
        }

        /// <summary>
        /// Размер секции по умолчанию
        /// </summary>
        public static Size DefaultParameterSize
        {
            get { return new Size(200, 100); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Size MaxParameterSize
        {
            get { return new Size(1000, 1000); }
        }

        /// <summary>
        /// Размер лейбла по умолчанию
        /// </summary>
        public static int DefaultLabelSize
        {
            get { return 23; }
        }

        /// <summary>
        /// Стандартная схема параметра
        /// </summary>
        public FFParameterScheme Scheme
        {
            get { return m_Scheme; }
            set
            {
                m_Scheme = value;
                
                m_LabelControl.Dock = DockStyle.None;

                //устанавливаем панелям форматирование
                switch (m_Scheme)
                {
                    case FFParameterScheme.Left:
                        m_TextMark.Dock = m_Splitter.Dock = DockStyle.Left;
                        break;
                    case FFParameterScheme.Right:
                        m_TextMark.Dock = m_Splitter.Dock = DockStyle.Right;
                        break;
                    case FFParameterScheme.Top:
                        m_LabelControl.Dock = m_Splitter.Dock = DockStyle.Bottom;
                        break;
                    case FFParameterScheme.Bottom:
                        m_LabelControl.Dock = m_Splitter.Dock = DockStyle.Top;
                        break;
                }
                m_Splitter.BringToFront();
                //донастройка
                if (Scheme.IsHorizontalOrientation())
                {
                    m_LabelControl.Dock = DockStyle.Fill;
                    m_LabelControl.BringToFront();
                }
                else
                {
                    m_TextMark.Dock = DockStyle.Fill;
                    m_LabelControl.Height = ControlParameter.Height;
                    m_TextMark.BringToFront();
                }
            }
        }

        /// <summary>
        /// Полный перечень значений для параметра (независимо от intRowStatus)
        /// </summary>
        internal FlexibleFormsDS.ParameterSelectListDataTable ParameterSelectListFull { get; set; }

        /// <summary>
        /// Обновляет перечень данных в управляющем контроле в случае выпадающего списка
        /// </summary>
        internal void RefreshSelectListInControl()
        {
            //связываем с выборкой данных
            var le = ControlParameter as LookUpEdit;
            if ((le == null) || !IdfsParameter.HasValue || !IdfsParameterType.HasValue) return;
            ParameterSelectListFull.Clear();
            var rows = MainDbService.LoadParameterSelectList(IdfsParameter.Value, IdfsParameterType.Value, IntHACode);
            foreach (var row in rows)
            {
                if (!row.IsRowAlive()) continue;
                var newRow = ParameterSelectListFull.NewParameterSelectListRow();
                newRow.idfsParameter = row.idfsParameter;
                newRow.idfsParameterType = row.idfsParameterType;
                newRow.idfsReferenceType = row.idfsReferenceType;
                newRow.idfsValue = row.idfsValue;
                
                newRow.intOrder = row.IsintOrderNull() ? 0 : row.intOrder;
                newRow.intRowStatus = row.intRowStatus;
                newRow.langid = row.langid;
                newRow.strValueCaption = row.strValueCaption;
                ParameterSelectListFull.AddParameterSelectListRow(newRow);
            }

            var dv = new DataView(ParameterSelectListFull);// {RowFilter = "intRowStatus = 0"};
            le.Properties.DataSource = dv;
        }

        /// <summary>
        /// Первоначальная простановка значений при открытии формы
        /// </summary>
        /// <param name="newValue"></param>
        internal void SetValue(object newValue)
        {
            //если есть список значений, то надо его отфильтровать
            if (ParameterSelectListFull.Count > 0)
            {
                var le = ControlParameter as LookUpEdit;
                if (le != null)
                {
                    var dv = (DataView)le.Properties.DataSource;
                    dv.RowFilter = !Utils.IsEmpty(newValue) ? String.Format("intRowStatus = 0 or idfsValue = {0}", Convert.ToInt64(newValue)) : "intRowStatus = 0";
                }
            }
            ControlParameter.EditValue = newValue;
        }

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

        /// <summary>
        /// Определяет управляющий контрол по типу
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BaseEdit GetControlParameter(FFParameterEditors value)
        {
            BaseEdit result;

            switch (value)
            {
                case FFParameterEditors.TextBox:
                    result = new TextEdit();
                    break;
                case FFParameterEditors.ComboBox:
                    result = new LookUpEdit();
                    break;
                case FFParameterEditors.CheckBox:
                    result = new CheckEdit();
                    LayoutCorrector.SetControlFont(result);
                    break;
                case FFParameterEditors.Date:
                    result = new DateEdit();
                    break;
                case FFParameterEditors.DateTime:
                    result = new TimeEdit();
                    break;
                case FFParameterEditors.Memo:
                    result = new MemoEdit();
                    break;
                case FFParameterEditors.UpDown:
                    result = new SpinEdit();
                    break;
                default:
                    //это крайне маловероятно, но всё же
                    result = new TextEdit();
                    break;
            }
            return result;
        }

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
                            le.Properties.Columns.Add(column);
                            le.Properties.ShowHeader = le.Properties.ShowFooter = false;
                            m_DeleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                            le.Properties.Buttons.Add(m_DeleteEditorButton);
                            le.ButtonClick += OnButtonControlClick;
                            le.QueryPopUp += new System.ComponentModel.CancelEventHandler(le_QueryPopUp);
                            le.QueryCloseUp += new System.ComponentModel.CancelEventHandler(le_QueryCloseUp);
                            break;
                        case FFParameterEditors.CheckBox:
                            ControlParameter = new CheckEdit {Text = String.Empty};
                            var checkEdit = (CheckEdit)ControlParameter;
                            LayoutCorrector.SetControlFont(checkEdit);
                            checkEdit.Properties.AutoWidth = true;
                            checkEdit.Properties.NullStyle = StyleIndeterminate.Unchecked;
                            checkEdit.Properties.FullFocusRect = true;
                            break;
                        case FFParameterEditors.Date:
                            ControlParameter = new DateEdit();
                            m_DeleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                            var de = (DateEdit)ControlParameter;
                            DxControlsHelper.InitDateEdit((DateEdit)ControlParameter);
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
                    //если тип данных -- Numeric, то накладываем маску
                    //иначе снимаем маску
                    long parameterType = LongNullValue;
                    if (ParametersRow != null)
                        parameterType = ParametersRow.idfsParameterType;
                    else if (ParameterTemplateRow != null)
                        parameterType = ParameterTemplateRow.idfsParameterType;

                    var result = HelperFunctions.GetMaskPropertiesForParameter(parameterType);
                    
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

        void le_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var le = sender as LookUpEdit;
            if (le != null)
            {
                var dv = (DataView)le.Properties.DataSource;
                dv.RowFilter = String.Empty;
                //dv.RowFilter = String.Empty;
                //le.Properties.DataSource = (List<FlexibleFormsDS.ParameterSelectListRow>) le.Tag;
                //var parameter = le.Tag as Parameter;
                //if (parameter != null)
                //{
                //    le.Properties.DataSource = parameter.ParameterSelectListFull;
                //}
            }
        }

        void le_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var le = sender as LookUpEdit;

            if (le == null)
            {
                e.Cancel = true;
                return;
            }
            var dv = (DataView)le.Properties.DataSource;
            var obj = le.EditValue;
            if (obj != null)
            {
                long val;

                if (Int64.TryParse(obj.ToString(), out val))
                {
                    le.EditValue = val;
                    dv.RowFilter = String.Format("intRowStatus = 0 or idfsValue = {0}", val);
                }
                else
                {
                    dv.RowFilter = "intRowStatus = 0";
                }
            }
            else
            {
                dv.RowFilter = "intRowStatus = 0";
            }
        }

        private bool m_ReadOnly;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="rdOnly"></param>
        private void SetButtonsState(EditorButtonCollection buttons, bool rdOnly)
        {
            foreach (EditorButton button in buttons)
            {
                button.Enabled = !rdOnly;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                m_ReadOnly = value;
                if (ControlParameter == null) return;
                ControlParameter.Properties.ReadOnly = m_ReadOnly;
                //
                var le = ControlParameter as LookUpEdit;
                if (le != null) SetButtonsState(le.Properties.Buttons, m_ReadOnly);
                //
                var de = ControlParameter as DateEdit;
                if (de != null) SetButtonsState(de.Properties.Buttons, m_ReadOnly);
                //
                var te = ControlParameter as TimeEdit;
                if (te != null) SetButtonsState(te.Properties.Buttons, m_ReadOnly);

                m_Splitter.Enabled = !m_ReadOnly;
            }
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

        /// <summary>
        /// Ссылка на перечень параметров для быстрого доступа
        /// </summary>
        public Dictionary<long, Parameter> ParameterList { get; set; }


        /// <summary>
        /// Текст, отображаемый в текстовой метке
        /// </summary>
        public new string Text
        {
            get { return m_TextMark.Text; }
            set { m_TextMark.Text = value; }
        }

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

        /// <summary>
        /// Определяет и возвращает ID параметра
        /// </summary>
        public long? IdfsParameter
        {
            get
            {
                long? result = LongNullValue;
                var parametersRow = Tag as FlexibleFormsDS.ParametersRow;
                if ((parametersRow != null) && (parametersRow.IsRowAlive()))
                {
                    result = parametersRow.idfsParameter;
                }
                else
                {
                    var parameterTemplateRow = Tag as FlexibleFormsDS.ParameterTemplateRow;
                    if ((parameterTemplateRow != null) && (parameterTemplateRow.IsRowAlive()))
                    {
                        result = parameterTemplateRow.idfsParameter;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Определяет и возвращает idfsParameterType
        /// </summary>
        public long? IdfsParameterType
        {
            get
            {
                long? result = LongNullValue;
                var parametersRow = Tag as FlexibleFormsDS.ParametersRow;
                if ((parametersRow != null) && (parametersRow.IsRowAlive()))
                {
                    result = parametersRow.idfsParameterType;
                }
                else
                {
                    var parameterTemplateRow = Tag as FlexibleFormsDS.ParameterTemplateRow;
                    if ((parameterTemplateRow != null) && (parameterTemplateRow.IsRowAlive()))
                    {
                        result = parameterTemplateRow.idfsParameterType;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Пустое значение для long?
        /// </summary>
        public const long LongNullValue = -1;

        /// <summary>
        /// Определяет и возвращает HA Code параметра
        /// </summary>
        public long? IntHACode
        {
            get
            {
                long? result = LongNullValue;
                var parametersRow = ParametersRow;
                if ((parametersRow != null) && (parametersRow.IsRowAlive()))
                {
                    if (parametersRow.IsintHACodeNull())
                        result = null;
                    else
                        result = parametersRow.intHACode;
                }
                else
                {
                    var parameterTemplateRow = ParameterTemplateRow;
                    if ((parameterTemplateRow != null) && (parameterTemplateRow.IsRowAlive()))
                    {
                        if (parameterTemplateRow.IsintHACodeNull())
                            result = null;
                        else
                            result = parameterTemplateRow.intHACode;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal FlexibleFormsDS.ParameterTemplateRow ParameterTemplateRow
        {
            get { return Tag as FlexibleFormsDS.ParameterTemplateRow; }
        }

        /// <summary>
        /// Определяет и возвращает ID параметра
        /// </summary>
        internal FlexibleFormsDS.ParametersRow ParametersRow
        {
            get { return Tag as FlexibleFormsDS.ParametersRow; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ParameterMoveAndResize(object sender, EventArgs e)
        {
            if (NowLoading) return;
            var parameterHost = (sender as ParameterHost) ?? GetParentParameterHost((Control) sender);
            if (parameterHost == null) return;
            var parameterTemplateRow =
                parameterHost.Tag as FlexibleFormsDS.ParameterTemplateRow;
            if (parameterTemplateRow == null) return;
            if (!parameterTemplateRow.IsRowAlive()) return;
            parameterTemplateRow.intLeft = parameterHost.LeftReal;
            parameterTemplateRow.intTop = parameterHost.TopReal;
            parameterTemplateRow.intWidth = parameterHost.Width;
            parameterTemplateRow.intHeight = parameterHost.Height;
            var parameter = parameterHost as Parameter;
            int lsize = 0;
            if (parameter != null)
            {
                lsize = ParameterSchemeHelper.IsHorizontalOrientation(parameterTemplateRow.intScheme)
                            ? parameter.m_Splitter.Left
                            : parameter.m_Splitter.Top;
            }
            if (lsize < DefaultLabelSize) lsize = DefaultLabelSize;
            parameterTemplateRow.intLabelSize = lsize;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.m_Splitter = new SplitterControl();
            this.m_TextMark = new LabelControl();
            this.m_LabelControl = new LabelControl();
            this.SuspendLayout();
            // 
            // Splitter
            // 
            this.m_Splitter.Location = new Point(82, 3);
            this.m_Splitter.Name = "m_Splitter";
            this.m_Splitter.Size = new Size(6, 94);
            this.m_Splitter.TabIndex = 2;
            this.m_Splitter.TabStop = false;
            // 
            // TextMark
            // 
            this.m_TextMark.Appearance.Options.UseTextOptions = true;
            this.m_TextMark.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.m_TextMark.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.m_TextMark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.m_TextMark.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.m_TextMark.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_TextMark.Location = new System.Drawing.Point(3, 3);
            this.m_TextMark.Name = "m_TextMark";
            this.m_TextMark.Size = new System.Drawing.Size(79, 94);
            this.m_TextMark.TabIndex = 3;
            this.m_TextMark.Text = "labelControl1";
            // 
            // LabelControl
            // 
            this.m_LabelControl.Appearance.Options.UseTextOptions = true;
            this.m_LabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.m_LabelControl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.m_LabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.m_LabelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.m_LabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelControl.Location = new System.Drawing.Point(88, 3);
            this.m_LabelControl.Name = "m_LabelControl";
            this.m_LabelControl.Size = new System.Drawing.Size(109, 94);
            this.m_LabelControl.TabIndex = 4;
            // 
            // Parameter
            // 
            this.Controls.Add(this.m_LabelControl);
            this.Controls.Add(this.m_Splitter);
            this.Controls.Add(this.m_TextMark);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(10, 33);
            this.Name = "Parameter";
            this.Size = new System.Drawing.Size(200, 100);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Корневая табличная секция, к которой опосредованно относится данный параметр
        /// </summary>
        public SectionTable RootSection { get; set; }

        /// <summary>
        /// Показывает, какие контролы параметра не находятся под управлением DesignHost, т.е. которые ведут себя как обычные контролы
        /// </summary>
        /// <returns></returns>
        internal override bool IsManagedControl(Control ctl)
        {
            return (m_Splitter == ctl) || ((ctl == ControlParameter) 
                && (
                (ControlParameter is CheckEdit) 
                || (ControlParameter is DateEdit) 
                || (ControlParameter is LookUpEdit) 
                || (ControlParameter is SpinEdit)
                || (ControlParameter is TimeEdit)
                )
                );
        }

        /// <summary>
        /// Является ли этот параметр на форме обязательным
        /// </summary>
        /// <returns></returns>
        public bool IsMandatoryField()
        {
            return ParameterTemplateRow.idfsEditMode.Equals(((long) FFEditModes.Required).ToString());
        }

        /// <summary>
        /// Если данный параметр в шаблоне обязательный, то проверит, чтобы он был не пустой
        /// </summary>
        /// <returns></returns>
        public bool IsMandatoryFieldEmpty()
        {
            bool result = false;

            if (ParameterTemplateRow != null)
            {
                if (IsMandatoryField())
                {
                    result = (ControlParameter.EditValue == null);
                    if (result && (ControlParameter.EditValue != null)) result = ControlParameter.EditValue.ToString().Length == 0;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deleteLinkedData"></param>
        public override void Delete(bool deleteLinkedData)
        {
            //удаляем запись о нём из списка быстрого доступа
            var parameterTemplateRow = (FlexibleFormsDS.ParameterTemplateRow)Tag;

            if ((parameterTemplateRow != null) && parameterTemplateRow.IsRowAlive() && (ParameterList != null) && (IdfsParameter.HasValue))
            {
                ParameterList.Remove(IdfsParameter.Value);
            }
            
            //удаляем сам контрол
            if (Parent != null)
            {
                Parent.Controls.Remove(this);
            }
            else if ((RootSection != null) && (IdfsParameter.HasValue))
            {
                var gridBandParameter = HelperFunctions.GetGridBandByName(String.Format("band{0}", IdfsParameter.Value), RootSection.GridViewMain.Bands);
                if (gridBandParameter != null)
                {
                    //gridBandParameter.Columns.Clear();
                    //ищем родительский бэнд (секцию!)
                    var parentBand = RootSection.FindBand(ParameterTemplateRow.idfsSection, true);
                    if (parentBand != null)
                    {
                        parentBand.Children.Remove(gridBandParameter);
                    }
                    else
                    {
                        RootSection.GridViewMain.Bands.Remove(gridBandParameter);
                    }
                }
            }

            //удаляем запись о нём из таблицы
            if (deleteLinkedData)
            {
                if ((parameterTemplateRow != null) && parameterTemplateRow.IsRowAlive())
                {
                    //удаляем записи для всех языков
                    MainDbService.DeleteParameterTemplate(parameterTemplateRow.idfsFormTemplate, parameterTemplateRow.idfsParameter, String.Empty);
                }
            }
        }

        /// <summary>
        /// Удаляет указанный параметр из шаблона
        /// </summary>
        public override void Delete()
        {
            Delete(true);
        }
    }
}