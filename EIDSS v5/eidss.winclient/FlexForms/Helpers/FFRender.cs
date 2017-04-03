using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.winclient.FlexForms.Controls;
using Label = eidss.winclient.FlexForms.Controls.Label;

namespace eidss.winclient.FlexForms.Helpers
{
    public class FFRender : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainTemplateDesignerHost"></param>
        public FFRender(DesignerHost mainTemplateDesignerHost)
        {
            TemplateDesignerHost = mainTemplateDesignerHost;
            ParameterList = new Dictionary<long, Parameter>();
        }

        /// <summary>
        /// Компонент-хост, куда осуществляется вывод шаблона
        /// </summary>
        internal DesignerHost TemplateDesignerHost { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childList"></param>
        /// <param name="parentSection"></param>
        private void RestoreChildList(IEnumerable<FlexNode> childList, Section parentSection)
        {
            foreach (var node in childList)
            {
                if (node.IsSection())
                {
                    var sectionControl = RestoreSection(node, parentSection);
                    if ((sectionControl != null) && (node.ChildListCount > 0))
                        RestoreChildList(node.ChildList, sectionControl);
                }
                else if (node.IsParameter())
                {
                    RestoreParameter(node, parentSection);
                }
                else if (node.IsLabel())
                {
                    RestoreLabel(node, parentSection);
                }
                else if (node.IsLine())
                {
                    RestoreLine(node, parentSection);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateNode"></param>
        public void RestoreTemplate(FlexNode templateNode)
        {
            if (templateNode == null) return;
            RestoreChildList(templateNode.ChildList, null);
        }

        public const int DefaultCaptionHeight = 23;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionNode"></param>
        /// <param name="parentSection"></param>
        private Section RestoreSection(FlexNode sectionNode, Section parentSection)
        {
            var section = sectionNode.GetSectionTemplate();

            //проверим, если эта секция уже добавлена на рабочий стол, то выходим
            var sectionControl = section.blnGrid ? new SectionTable() : new Section();
            sectionControl.ParentRender = this;
            sectionControl.Location = new Point(section.Left, section.Top);
            sectionControl.Size = new Size(section.Width, section.Height);
            sectionControl.CaptionHeight = section.intCaptionHeight.HasValue
                                               ? section.intCaptionHeight.Value
                                               : DefaultCaptionHeight;
            sectionControl.Tag = section;
           

            //создаём секцию
            var sectionTable = sectionControl as SectionTable;
            //особые действия для табличных секций
            if (sectionTable != null)
            {
                //сделаем передачу указателя на источник данных
                //sectionTable.MainDbService = MainDbService;
                ////определим, можно ли в эту таблицу заводить новые строки (по умолчанию можно)
                //if (rowSectionTemplate.blnFixedRowSet)
                //    sectionTable.GridViewMain.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                //sectionTable.GridViewMain.MouseDown += OnSectionTableGridViewMainMouseDown;
            }
            //задаём свойства секции
            sectionControl.Name = String.Format("section{0}", section.idfsSection);

            sectionControl.Caption = section.NationalName;
            sectionControl.Visible = true;
            //
            sectionControl.ParentSection = parentSection;

            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            if (parentSection != null)
            {
                //не может быть ситуации, когда в табличную секцию добавляется обычная
                //ситуация, когда в обычную секцию добавляется табличная, возможна
                if (!((parentSection is SectionTable) && (!(sectionControl is SectionTable))))
                    parentSection.Add(sectionControl);
            }
            else
            {
                //эта секция -- корневая
                TemplateDesignerHost.Add(sectionControl);
            }

            /*
            if (sectionTable != null)
            {
                //sectionTable.Init(); //
                //sectionTable.RootSection = sectionTable;
                ////добавим в список быстрого доступа
                //if (!SectionAlreadyAdded(rowSectionTemplate.idfsSection))
                //    SectionTableList.Add(rowSectionTemplate.idfsSection, sectionTable);
                ////подписываемся на событие изменения значения в ячейке таблицы
                //sectionTable.EditValueChanging += OnEditValueChanging;
            }
            else
            {
                //добавим в список быстрого доступа
                SectionList.Add(section.idfsSection, sectionControl);
            }
            */
             
            //выставим правильные размеры
            sectionControl.SetBestSize();

            //если это табличная секция, то запустим построение её потомков
            //(построение потомков)
            //if (sectionTable != null)
            //{
            //    //запускаем рекурсивное построение табличных секций и параметров первого уровня (а для каждой т.с. затем запустится рекурсивное построение нижних секций)
            //    RestoreSectionTableChildren(sectionTable, rowSectionTemplate.idfsFormTemplate, isSummaryTemplate);
            //    //заканчиваем инициализацию табличной секции
            //    sectionTable.FinishInit();
            //}

            //sectionControl.LabelControlCaption.Visible = SectionTableCaptionsIsVisible;

            return sectionControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterNode"></param>
        /// <param name="parentSection"></param>
        private void RestoreParameter(FlexNode parameterNode, Section parentSection)
        {
            var parameter = parameterNode.GetParameterTemplate();
            
            var parameterControl = new Parameter
            {
                ParentRender = this,
                Tag = parameter,
                Scheme = ParameterSchemeHelper.ConvertToParameterScheme(parameter.intScheme),
                Editor = ParameterControlTypeHelper.ConvertToParameterControlType(parameter.idfsEditor),
                Text = parameter.NationalName,
                Visible = true,
                Location = new Point(parameter.intLeft, parameter.intTop),
                Size = new Size(parameter.intWidth, parameter.intHeight),
                LabelSize = parameter.intLabelSize
            };
            
            parameterControl.EditValueChanged += OnEditValueChanged;
            parameterControl.EditValueChanging += OnEditValueChanging;

            
            //параметр может находиться либо в своей секции, либо прямо на хост-контроле, если у него нет секции,
            //и он расположен сразу в типе формы
            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            
            //TODO отработать динамический параметр
            //if (!parameter.blnDynamicParameter)
            //{
            //    if (parentSection != null)
            //    {
            //        if (parentSection is SectionTable)
            //        {
            //            parameterControl.RootSection = ((SectionTable)parentSection).RootSection;
            //        }
            //        parentSection.Add(parameterControl);
            //        //parameter.Backcolor = parentSection.BackColor;
            //    }
            //    else
            //    {
            //        //параметр не может располагаться в чужой секции
            //        //если у него нет своей секции, то он должен быть на хост-контроле
            //        TemplateDesignerHost.Add(parameterControl);
            //        //parameter.Backcolor = TemplateDesignerHost.BackColor;
            //    }
            //}
            //else
            //{
            //    //ставим параметр на указанный родительский контрол                
            //    var parametersRow = MainDbService.GetParameterRow(rowParameterTemplate.idfsParameter);
            //    if (parametersRow != null) parameterControl.Text = parametersRow.NationalLongName;
            //    DynamicParametersGroupControl.Controls.Add(parameterControl);
            //}

            if (parentSection != null)
            {
                //TODO отработать табличную секцию
                //if (parentSection is SectionTable)
                //{
                //    parameterControl.RootSection = ((SectionTable)parentSection).RootSection;
                //}
                parentSection.Add(parameterControl);
                //parameter.Backcolor = parentSection.BackColor;
            }
            else
            {
                //параметр не может располагаться в чужой секции
                //если у него нет своей секции, то он должен быть на хост-контроле
                TemplateDesignerHost.Add(parameterControl);
                //parameter.Backcolor = TemplateDesignerHost.BackColor;
            }

            //добавим в список быстрого доступа
            //параметр может быть добавлен в секцию, если эта секция табличная, и там запустилось рекурсивное построение потомков
            ParameterList.Add(parameter.idfsParameter, parameterControl);
            //выставим правильные размеры
            parameterControl.SetBestSize();

            //TODO сделать цветовую разметку обязательных полей
            //если параметр на форме обязательный, то специально маркируем его
            //if (parameterControl.IsMandatoryField())
            //{
            //    if (ParameterIsMandatory != null)
            //        ParameterIsMandatory(parameterControl.ControlParameter);
            //}
        }

        /// <summary>
        /// Изменилось значение управляющего контрола в одном из обычных параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEditValueChanged(object sender, EventArgs e)
        {
            if (EditValueChanged != null) EditValueChanged(sender, e);
        }

        /// <summary>
        /// Обработка изменения значения в одной из табличных секций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEditValueChanging(object sender, ChangingEventArgs e)
        {
            int value;
            if ((e.NewValue != null) && Int32.TryParse(e.NewValue.ToString(), out value))
            {
                if (value > 99000000)
                    e.Cancel = true;
            }
            if ((EditValueChanging != null) && !e.Cancel) EditValueChanging(sender, e);
        }

        
        ///// <summary>
        ///// Событие, когда секция изменяет размеры
        ///// </summary>
        //public event EventHandler SectionResize;

        ///// <summary>
        ///// Событие, когда параметр изменяет размеры
        ///// </summary>
        //public event EventHandler ParameterResize;

        ///// <summary>
        ///// Событие, когда лейбл изменяет размеры
        ///// </summary>
        //public event EventHandler LabelResize;

        ///// <summary>
        ///// Событие, когда линия изменяет размеры
        ///// </summary>
        //public event EventHandler LineResize;

        ///// <summary>
        ///// Событие, когда производится клик мыши на рабочем столе шаблонов
        ///// </summary>
        //public event MouseEventHandler TemplateMouseDown;

        public delegate void EditValueChangingDelegate(object sender, ChangingEventArgs e);

        public delegate void SelectedBandChangedDelegate(GridBand selectedBand);

        ///// <summary>
        ///// Событие, когда изменяется текущий бэнд в гриде
        ///// </summary>
        //public event SelectedBandChangedDelegate OnSelectedBandChanged;

        /// <summary>
        /// Событие срабатывает, когда меняется значение в управляющего контрола одного из обычных параметров
        /// </summary>
        public event EditValueChangingDelegate EditValueChanging;

        public delegate void EditValueChangedDelegate(object sender, EventArgs e);

        /// <summary>
        /// Делегат для указания метода выставления mandatory параметров
        /// </summary>
        /// <param name="c"></param>
        public delegate void SetControlMandatoryStateDelegate(BaseControl c);

        /*
        /// <summary>
        /// Срабатывает для определения визуального стиля mandatory параметра
        /// </summary>
        public event SetControlMandatoryStateDelegate ParameterIsMandatory;
        */

        /// <summary>
        /// Событие срабатывает, когда  значение в ячейке изменилось
        /// </summary>
        public event EditValueChangedDelegate EditValueChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelNode"></param>
        /// <param name="parentSection"></param>
        private Label RestoreLabel(FlexNode labelNode, Section parentSection)
        {
            var label = labelNode.GetLabel();

            //создаём лейбл
            var labelControl = new Label
            {
                ParentRender = this,
                Tag = labelNode,
                MinimumSize = new Size(20, 10),
                Location = new Point(label.intLeft, label.intTop),
                Size = new Size(label.Width, label.Height),
                mainLabel = { Text = label.NationalText }
            };
            //задаём свойства
            labelControl.mainLabel.Font = new Font(labelControl.mainLabel.Font.FontFamily
                , label.FontSize, HelperFunctions.ConvertToFontStyle(label.FontStyle));
            labelControl.mainLabel.ForeColor = Color.FromArgb(label.Color);
            labelControl.Visible = true;

            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            if (parentSection != null)
            {
                parentSection.Add(labelControl);
            }
            else
            {
                TemplateDesignerHost.Add(labelControl);
            }

            //выставим правильные размеры
            labelControl.SetBestSize();

            //добавим в коллекцию быстрого доступа
            //LabelList.Add(label.idfDecorElement, labelControl);

            return labelControl;
        }

        
        /// <summary>
        /// Список размещённых в шаблоне параметров для быстрого доступа к ним. Хранятся пары [idfsParameter, экземпляр класса Parameter]
        /// </summary>
        internal Dictionary<long, Parameter> ParameterList{ get; set; }
        
        /*
        /// <summary>
        /// Список размещённых в шаблоне табличных секций для быстрого доступа к ним. Хранятся пары [idfsSection, экземпляр класса SectionTable]
        /// </summary>
        internal Dictionary<long, SectionTable> SectionTableList{ get; set; }

        /// <summary>
        /// Список размещённых в шаблоне секций для быстрого доступа к ним. Хранятся пары [idfsSection, экземпляр класса Section]
        /// </summary>
        internal Dictionary<long, Section> SectionList{ get; set; }

        /// <summary>
        /// Список размещённых в шаблоне линий для быстрого доступа к ним. Хранятся пары [idfDecorElement, экземпляр класса Line]
        /// </summary>
        internal Dictionary<long, Line> LineList { get; set; }

        /// <summary>
        /// Список размещённых в шаблоне лейблов для быстрого доступа к ним. Хранятся пары [idfDecorElement, экземпляр класса Label]
        /// </summary>
        internal Dictionary<long, Label> LabelList { get; set; }
        
         */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineNode"></param>
        /// <param name="parentSection"></param>
        private void RestoreLine(FlexNode lineNode, Section parentSection)
        {
            //TODO имплементировать
        }

        public void Dispose()
        {
            
        }
    }
}
