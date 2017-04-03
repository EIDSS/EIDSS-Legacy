using System;
using System.Drawing;
using System.Windows.Forms;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.DesignerHosting;
using EIDSS.FlexibleForms.Helpers;

namespace EIDSS.FlexibleForms.Components
{

    public partial class Label : ParameterHost
    {
        /// <summary>
        /// 
        /// </summary>
        public Label()
        {
            InitializeComponent();
            Move += OnLabelMoveAndResize;
            SizeChanged += OnLabelMoveAndResize;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int MinFontSize
        {
            get { return 8; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int MaxFontSize
        {
            get { return 28; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Size MaxLabelSize
        {
            get { return new Size(1000, 1000); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLabelMoveAndResize(object sender, EventArgs e)
        {
            if (NowLoading) return;
            ParameterHost parameterHost = (sender as ParameterHost) ?? GetParentParameterHost((Control)sender);
            if (parameterHost == null) return;
            FlexibleFormsDS.LabelsRow labelsRow = (FlexibleFormsDS.LabelsRow)parameterHost.Tag;
            if (labelsRow == null) return;
            labelsRow.intLeft = parameterHost.LeftReal;
            labelsRow.intTop = parameterHost.TopReal;
            labelsRow.intWidth = parameterHost.Width;
            labelsRow.intHeight = parameterHost.Height;
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
            //удал€ем сам контрол
            Parent.Controls.Remove(this);
            //удал€ем запись о нЄм из таблицы
            if (deleteLinkedData)
            {
                FlexibleFormsDS.LabelsRow labelsRow = (FlexibleFormsDS.LabelsRow) Tag;
                if (HelperFunctions.IsRowAlive(labelsRow)) DataHelper.DeleteLabelTemplate(MainDbService, labelsRow.idfsFormTemplate, labelsRow.idfDecorElement, String.Empty);
            }
        }
    }
}

