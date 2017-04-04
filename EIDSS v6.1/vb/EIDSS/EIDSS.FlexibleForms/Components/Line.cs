using System;
using System.Drawing;
using System.Windows.Forms;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.DesignerHosting;
using EIDSS.FlexibleForms.Helpers;

namespace EIDSS.FlexibleForms.Components
{
    public class Line : ParameterHost
    {
        /// <summary>
        /// 
        /// </summary>
        public Line()
        {
            InitializeComponent();
            Move += OnLineMoveAndResize;
            SizeChanged += OnLineMoveAndResize;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            MaximumSize = new Size(0, 0); //new Size(4000, 4000);
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        /// <summary>
        /// Размер секции по умолчанию
        /// </summary>
        public static Size DefaultLineSize
        {
            get
            {
                return new Size(1, 1);
            }
        }

        /// <summary>
        /// Максимальный размер линии для ручных проверок
        /// </summary>
        public static Size MaxLineSize
        {
            get
            {
                return new Size(4000, 4000);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLineMoveAndResize(object sender, EventArgs e)
        {
            if (NowLoading) return;
            ParameterHost parameterHost = (sender as ParameterHost) ?? GetParentParameterHost((Control)sender);
            if (parameterHost == null) return;
            FlexibleFormsDS.LinesRow linesRow = (FlexibleFormsDS.LinesRow)parameterHost.Tag;
            if (linesRow == null) return;
            linesRow.intLeft = parameterHost.LeftReal;
            linesRow.intTop = parameterHost.TopReal;
            linesRow.intWidth = parameterHost.Width;
            linesRow.intHeight = parameterHost.Height;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Line
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "Line";
            this.Size = new System.Drawing.Size(150, 22);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 
        /// </summary>
        public override void Delete()
        {
            Delete(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deleteLinkedData"></param>
        public override void Delete(bool deleteLinkedData)
        {
            //удаляем сам контрол
            Parent.Controls.Remove(this);
            //удаляем запись о нём из таблицы
            if (deleteLinkedData)
            {
                FlexibleFormsDS.LinesRow linesRow = (FlexibleFormsDS.LinesRow) Tag;
                if (HelperFunctions.IsRowAlive(linesRow)) DataHelper.DeleteLineTemplate(MainDbService, linesRow.idfsFormTemplate, linesRow.idfDecorElement, String.Empty);
            }
        }

        /// <summary>
        /// Меняет размеры линии в соответствие с размерами родителя
        /// </summary>
        /// <param name="parentControl"></param>
        public void ResizeLine(Control parentControl)
        {
            FlexibleFormsDS.LinesRow linesRow = (FlexibleFormsDS.LinesRow)Tag;
            if (linesRow.IsblnOrientationNull()) return;
            if (linesRow.blnOrientation)
            {
                //линия по ширине равняется родительскому контролу
                linesRow.intLeft = Left = 0;
                linesRow.intWidth = Width = parentControl.Width; //чтобы зазор небольшой остался
                linesRow.intHeight = Height = 10;
            }
            if (!linesRow.blnOrientation)
            {
                //линия по высоте равняется родительскому контролу
                linesRow.intTop = Top = 0;
                linesRow.intHeight = Height = parentControl.Height; //чтобы зазор небольшой остался
                linesRow.intWidth = Width = 10;
            }
        }

        /// <summary>
        /// Меняет размеры линии в соответствие с размерами родителя
        /// </summary>
        public void ResizeLine()
        {
            ResizeLine(Parent);
        }
    }
}
