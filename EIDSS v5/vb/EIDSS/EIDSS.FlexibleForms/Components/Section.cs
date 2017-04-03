using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.DesignerHosting;
using EIDSS.FlexibleForms.Helpers;

namespace EIDSS.FlexibleForms.Components
{
    public class Section : ParameterHost
    {
        internal LabelControl LabelControlCaption { get; set; }
        internal Panel Toolbar { get; set; }
        internal LabelControl LabelControl { get; set; }
        internal SplitterControl Splitter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Section()
        {
            InitializeComponent();
            Move += SectionMoveAndResize;
            Resize += SectionMoveAndResize;
            Splitter.SplitterMoved += SectionMoveAndResize;
            OnDesignModeChanged += OnSectionOnDesignModeChanged;

            Toolbar.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        void OnSectionOnDesignModeChanged()
        {
            Splitter.Visible = IsDesignMode;
        }

        /// <summary>
        /// Определяет и возвращает ID секции
        /// </summary>
        public long? IdfsSection
        {
            get
            {
                long? result = -1;
                var sectionsRow = Tag as FlexibleFormsDS.SectionsRow;
                if ((sectionsRow != null) && (sectionsRow.IsRowAlive()))
                {
                    result = sectionsRow.idfsSection;
                }
                else
                {
                    var sectionTemplateRow = Tag as FlexibleFormsDS.SectionTemplateRow;
                    if ((sectionTemplateRow != null) && (sectionTemplateRow.IsRowAlive())) result = sectionTemplateRow.idfsSection;
                }

                return result;
            }
        }

        /// <summary>
        /// Определяет и возвращает ID секции
        /// </summary>
        internal FlexibleFormsDS.SectionsRow SectionsRow
        {
            get { return Tag as FlexibleFormsDS.SectionsRow; }
        }

        /// <summary>
        /// Определяет и возвращает ID секции
        /// </summary>
        internal FlexibleFormsDS.SectionTemplateRow SectionTemplateRow
        {
            get { return Tag as FlexibleFormsDS.SectionTemplateRow; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void SectionMoveAndResize(object sender, EventArgs e)
        {
            if (NowLoading) return;
            var parameterHost = (sender as ParameterHost) ?? GetParentParameterHost((Control) sender);
            if (parameterHost == null) return;
            var sectionTemplateRow = (FlexibleFormsDS.SectionTemplateRow)parameterHost.Tag;
            if (sectionTemplateRow == null) return;
            if (!sectionTemplateRow.IsRowAlive()) return;
            sectionTemplateRow.intLeft = parameterHost.LeftReal;//parameterHost.Left;
            sectionTemplateRow.intTop = parameterHost.TopReal;//parameterHost.Top;
            sectionTemplateRow.intWidth = parameterHost.Width;
            sectionTemplateRow.intHeight = parameterHost.Height;
            var section = parameterHost as Section;
            if (section != null)
            {
                sectionTemplateRow.intCaptionHeight = section.CaptionHeight;
            }
        }

        /// <summary>
        /// Выставляет заголовок секции
        /// </summary>
        public string Caption
        {
            get { return LabelControlCaption.Text; }
            set { LabelControlCaption.Text = value; }
        }

        /// <summary>
        /// Выставляет высоту заголовка секции
        /// </summary>
        public int CaptionHeight
        {
            get { return LabelControlCaption.Height; }
            set { LabelControlCaption.Height = value; }
        }

        private bool m_ReadOnly;

        /// <summary>
        /// 
        /// </summary>
        public bool ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                m_ReadOnly = value;
                Splitter.Enabled = !m_ReadOnly;
            }
        }

        /// <summary>
        /// Показывает, какие контролы параметра не находятся под управлением DesignHost, т.е. которые ведут себя как обычные контролы
        /// </summary>
        /// <returns></returns>
        internal override bool IsManagedControl(Control ctl)
        {
            return (Splitter == ctl);
        }

        /// <summary>
        /// Ссылка на родительскую секцию
        /// </summary>
        public Section ParentSection { get; set; }

        /// <summary>
        /// Добавляем секцию или параметр
        /// </summary>
        /// <param name="child"></param>
        public override void Add(Control child)
        {
            var ph = child as ParameterHost;
            if (ph != null) ph.IsDesignMode = IsDesignMode;
            TopControl().Controls.Add(child);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control TopControl()
        {
            return LabelControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deleteLinkedData"></param>
        public override void Delete(bool deleteLinkedData)
        {
            //если тип секции Обычная, то удаляем внутренние контролы
            //если тип секции Табличная, то удаляем внутренние бэнды и столбцы
            //удаляем те контролы, что на нём лежат
            for (int i = TopControl().Controls.Count - 1; i >= 0; i--)
            {
                Control control = TopControl().Controls[i];

                if (control is Section)
                {
                    ((Section) control).Delete();
                }
                else if (control is Parameter)
                {
                    ((Parameter) control).Delete();
                }
            }
            //удаляем сам контрол
            Parent.Controls.Remove(this);
            //удаляем запись из таблицы
            if (deleteLinkedData)
            {
                var rowSection = (FlexibleFormsDS.SectionTemplateRow)Tag;
                if (rowSection.IsRowAlive()) MainDbService.DeleteSectionTemplate(rowSection.idfsFormTemplate, rowSection.idfsSection, String.Empty);
            }
        } 

        /// <summary>
        /// Удаляет секцию из шаблона
        /// </summary>
        public override void Delete()
        {
            Delete(true);
        }

        /// <summary>
        /// Размер секции по умолчанию
        /// </summary>
        public static Size DefaultSectionSize
        {
            get { return new Size(200, 200); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Size MaxSectionSize
        {
            get { return new Size(3000, 3000); }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelControlCaption = new DevExpress.XtraEditors.LabelControl();
            this.Toolbar = new Panel();
            this.LabelControl = new DevExpress.XtraEditors.LabelControl();
            this.Splitter = new DevExpress.XtraEditors.SplitterControl();
            this.SuspendLayout();
            // 
            // LabelControlCaption
            // 
            this.LabelControlCaption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(193)))), ((int)(((byte)(236)))));
            this.LabelControlCaption.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.LabelControlCaption.Appearance.Options.UseBackColor = true;
            this.LabelControlCaption.Appearance.Options.UseBorderColor = true;
            this.LabelControlCaption.Appearance.Options.UseTextOptions = true;
            this.LabelControlCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LabelControlCaption.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.LabelControlCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControlCaption.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.LabelControlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlCaption.Location = new System.Drawing.Point(3, 3);
            this.LabelControlCaption.Name = "LabelControlCaption";
            this.LabelControlCaption.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelControlCaption.Size = new System.Drawing.Size(194, 23);
            this.LabelControlCaption.TabIndex = 6;

            //Toolbar
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toolbar.Location = new System.Drawing.Point(3, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Toolbar.Size = new System.Drawing.Size(194, 23);
            this.Toolbar.TabIndex = 7;

            // 
            // LabelControl
            // 
            this.LabelControl.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.LabelControl.Appearance.Options.UseBorderColor = true;
            this.LabelControl.Appearance.Options.UseTextOptions = true;
            this.LabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.LabelControl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.LabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.LabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelControl.Location = new System.Drawing.Point(3, 32);
            this.LabelControl.Name = "LabelControl";
            this.LabelControl.Size = new System.Drawing.Size(194, 165);
            this.LabelControl.TabIndex = 8;
            // 
            // splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.Splitter.Location = new System.Drawing.Point(3, 26);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(194, 6);
            this.Splitter.TabIndex = 9;
            this.Splitter.TabStop = false;
            // 
            // Section
            // 
            this.Controls.Add(this.LabelControl);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.LabelControlCaption);
            
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Section";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }
    }
}