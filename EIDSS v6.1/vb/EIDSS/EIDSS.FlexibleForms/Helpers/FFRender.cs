using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.DesignerHosting;
using bv.model.Model.Core;
using eidss.model.Core;
using Label=EIDSS.FlexibleForms.Components.Label;
using eidss.model.Resources;

namespace EIDSS.FlexibleForms.Helpers
{
    /// <summary>
    /// Отображение визуального представления форм
    /// </summary>
    public class FFRender
    {
        /// <summary>
        /// Ссылка на датасет для Flexible Forms
        /// </summary>
        public DbService MainDbService { get; private set; }

        /// <summary>
        /// Компонент-хост, куда осуществляется вывод шаблона
        /// </summary>
        internal DesignerHost TemplateDesignerHost { get; private set; }

        /// <summary>
        /// Панель для отображения динамических параметров
        /// </summary>
        internal GroupControl DynamicParametersGroupControl { get; set; }

        /// <summary>
        /// Создаёт и показывает панель динамических параметров
        /// </summary>
        internal void ShowDynamicParametersGroupControl(long idfsFormTemplate)
        {
            if (DynamicParametersGroupControl == null)
            {
                DynamicParametersGroupControl = new GroupControl
                                                    {Text = EidssMessages.Get("DynamicParametersGroupControlCaption")};
            }

            int left;
            int labelSize;
            int width;
            DataHelper.GetSizesForFit(MainDbService, idfsFormTemplate, null, out left, out labelSize, out width);

            if (!TemplateDesignerHost.Controls.Contains(DynamicParametersGroupControl)) TemplateDesignerHost.Controls.Add(DynamicParametersGroupControl);
            
            DynamicParametersGroupControl.Location = TemplateDesignerHost.GetMostRightTopControl(new Point(5, 5), DynamicParametersGroupControl);
            DynamicParametersGroupControl.Left = left;
            DynamicParametersGroupControl.Width = width;
            //ставим минимальную высоту, которая затем будет расширена параметрами.
            DynamicParametersGroupControl.Height = 20;
            SetVisibleDynamicParametersGroupControl(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visible"></param>
        internal void SetVisibleDynamicParametersGroupControl(bool visible)
        {
            if (DynamicParametersGroupControl != null) DynamicParametersGroupControl.Visible = visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="mainTemplateDesignerHost"></param>
        public FFRender(DbService mainDbService, DesignerHost mainTemplateDesignerHost)
        {
            MainDbService = mainDbService;
            TemplateDesignerHost = mainTemplateDesignerHost;
            
            ParameterList = new Dictionary<long, Parameter>();
            SectionTableList = new Dictionary<long, SectionTable>();
            SectionList = new Dictionary<long, Section>();
            LineList = new Dictionary<long, Line>();
            LabelList = new Dictionary<long, Label>();
            CriticalObjects = new CriticalObjectsHelper();

            LanguageTemplate = bv.common.Core.Localizer.lngEn;

            SectionTableCaptionsIsVisible = true;
        }

        /// <summary>
        /// Язык, с которым открывается шаблон
        /// </summary>
        private string LanguageTemplate { get; set; }

        /// <summary>
        /// Список размещённых в шаблоне параметров для быстрого доступа к ним. Хранятся пары [idfsParameter, экземпляр класса Parameter]
        /// </summary>
        internal Dictionary<long, Parameter> ParameterList{ get; set; }

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

        /// <summary>
        /// Возвращает контрол параметра из листа параметров
        /// </summary>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        internal Parameter GetParameter(long idfsParameter)
        {
            Parameter parameter = null;
            if (ParameterList.ContainsKey(idfsParameter))
                parameter = ParameterList[idfsParameter];
            return parameter;
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
                TemplateDesignerHost.ReadOnly = m_ReadOnly;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        internal SectionTable GetSectionTable(long idfsSection)
        {
            SectionTable result = null;
            if (SectionTableList != null)
                if (SectionTableList.ContainsKey(idfsSection))
                    result = SectionTableList[idfsSection];
            return result;
        }

        /// <summary>
        /// Возвращает табличную секцию, если таковая имеется в шаблоне
        /// </summary>
        /// <param name="index">Порядковый номер табличной секции</param>
        /// <returns>возвращает табличную секцию, если таковая имеется в шаблоне, или null, если её нет</returns>
        public SectionTable GetSectionTableByIndex(int index)
        {
            SectionTable result = null;
            if (SectionTableList != null)
                if ((SectionTableList.Count > 0) && (index <= SectionTableList.Count))
                    foreach (var sectionTable in SectionTableList.Values)
                    {
                        result = sectionTable;
                        break;
                    }

            return result;
        }

        /// <summary>
        /// Добавляет параметр на хост-контрол
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="mouseLocation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="isSummaryTemplate"></param>
        /// <returns></returns>
        internal Parameter CreateParameterInTemplateHost(FlexibleFormsDS.ParametersRow rowParameter, Point mouseLocation, long idfsFormTemplate, bool isSummaryTemplate)
        {
            var rowParameterTemplate = MainDbService.CreateParameterTemplateRow(rowParameter, idfsFormTemplate);
            rowParameterTemplate.intLeft = mouseLocation.X;
            rowParameterTemplate.intTop = mouseLocation.Y;

            return CreateParameterInTemplateHost(rowParameterTemplate, mouseLocation, isSummaryTemplate);
        }

        /// <summary>
        /// Добавляет параметр на хост-контрол
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="parameterLocation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="parentControl">Куда поместить созданный параметр</param>
        /// <param name="dynamicParameter">Динамический ли это параметр</param>
        /// <returns></returns>
        internal Parameter CreateParameterInTemplateHost(FlexibleFormsDS.ParametersRow rowParameter, Point parameterLocation, long idfsFormTemplate, Control parentControl, bool dynamicParameter)
        {
            var rowParameterTemplate = MainDbService.CreateParameterTemplateRow(rowParameter, idfsFormTemplate);
            rowParameterTemplate.intLeft = parameterLocation.X;
            rowParameterTemplate.intTop = parameterLocation.Y;
            rowParameterTemplate.blnDynamicParameter = dynamicParameter;

            if (dynamicParameter)
            {
                int left;
                int labelSize;
                int width;
                DataHelper.GetSizesForFit(MainDbService, idfsFormTemplate, null, out left, out labelSize, out width);

                if (labelSize > 0) rowParameterTemplate.intLabelSize = labelSize;
                rowParameterTemplate.intWidth = DynamicParametersGroupControl.Width - 10;
            }

            return CreateParameterInTemplateHost(rowParameterTemplate, parameterLocation, false);
        }

        /// <summary>
        /// Добавляет параметр на панель динамических параметров
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="idfsFormTemplate"></param>
        internal void CreateParameterInParameterDynamicParametersGroupControl(FlexibleFormsDS.ParametersRow rowParameter, long idfsFormTemplate)
        {
            //определим куда поставить параметр
            //Вычисляем левую верхнюю координату для добавляемого параметра
            var location = DynamicParametersGroupControl.GetMostRightTopControl(new Point(5, 25), null);
            //если параметр шире и выше рабочего поля панели, то увеличим её
            var parameterWidth = location.X + rowParameter.intWidth;
            var parameterHeight = location.Y + rowParameter.intHeight;
            if (parameterWidth > DynamicParametersGroupControl.Width) rowParameter.intWidth = DynamicParametersGroupControl.Width - 10;
            if (parameterHeight > DynamicParametersGroupControl.Height) DynamicParametersGroupControl.Height = parameterHeight + 10;
            //
            CreateParameterInTemplateHost(rowParameter, location, idfsFormTemplate, DynamicParametersGroupControl, true);
        }

        /// <summary>
        /// Производит очистку шаблона
        /// </summary>
        internal void ClearTemplate()
        {
            NowClearingTemplate = true;

            var lines = new List<Line>(LineList.Values);
            for (var i = lines.Count - 1; i >= 0; i--) { lines[i].Delete(false); }

            var labels = new List<Label>(LabelList.Values);
            for (var i = labels.Count - 1; i >= 0; i--) { labels[i].Delete(false); }

            var parameters = new List<Parameter>(ParameterList.Values);
            for (var i = parameters.Count - 1; i >= 0; i--) { parameters[i].Delete(false); }

            var sectionTables = new List<SectionTable>(SectionTableList.Values);
            for (var i = sectionTables.Count - 1; i >= 0; i--) { sectionTables[i].Delete(false); }

            var sections = new List<Section>(SectionList.Values);
            for (var i = sections.Count - 1; i >= 0; i--) { sections[i].Delete(false); }
            
            //очистим словарь быстрого доступа
            LineList.Clear();
            LabelList.Clear();
            ParameterList.Clear();
            SectionTableList.Clear();
            SectionList.Clear();

            foreach (Control c in TemplateDesignerHost.Controls) 
            {
                var st = c as SectionTable;
                if (st != null) 
                    st.Delete(false);
            }

            NowClearingTemplate = false;
        }

        /// <summary>
        /// Восстанавливает шаблон на контроле-хосте
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsFormType"></param>
        /// <param name="langid"></param>
        /// <param name="idfVersion"></param>
        /// <param name="presetStubs"></param>
        /// <param name="idfsMatrixType"></param>
        /// <param name="isSummary"></param>
        internal void RestoreTemplate(long idfsFormTemplate, long idfsFormType, string langid, List<long> presetStubs, long? idfVersion, long? idfsMatrixType, bool isSummary)
        {
            NowLoadingTemplate = true;
            //очистим рабочую область шаблона
            ClearTemplate();

            TemplateDesignerHost.SuspendLayout();
            Application.DoEvents();

            if (langid == null) langid = ModelUserContext.CurrentLanguage;
            TemplateDesignerHost.AutoScrollPosition = new Point(0, 0);
            TemplateDesignerHost.DisplayRectangleLeftStart = TemplateDesignerHost.DisplayRectangle.Left;
            TemplateDesignerHost.DisplayRectangleTopStart = TemplateDesignerHost.DisplayRectangle.Top;
            
            //если по данному типу формы, к которому относится шаблон, не загружены мета-данные по секциям, то дозагрузим их
            //(проверка уже внутри)
            MainDbService.LoadSections(idfsFormType, null, null);
            MainDbService.LoadParameters(idfsFormType, null);
            
            //дозагружаем данные по этому шаблону (если они до сих пор не загружены)
            MainDbService.LoadSectionTemplate(idfsFormTemplate, langid);
            MainDbService.LoadParameterTemplate(idfsFormTemplate, langid);

            var stubLength = 0;
            if ((presetStubs != null) && idfVersion.HasValue && idfsMatrixType.HasValue)
            {
                //обработаем загруженный боковик
                stubLength = presetStubs.IncludeStub(MainDbService, idfsFormTemplate, idfVersion.Value, idfsMatrixType.Value);
            }

            //загружаем линии
            //MainDbService.LoadLines(idfsFormTemplate, langid);
            //загружаем лейблы
            MainDbService.LoadLabels(idfsFormTemplate, langid);

            #region загружаем всё, что связано с правилами

            MainDbService.LoadRulesForTemplate(idfsFormTemplate);
            MainDbService.LoadRuleFunctions(-1); //означает, что нужно загрузить все функции (всю библиотеку функций для правил)
            //для каждого правила загрузим его инфраструктуру
            foreach (var row in MainDbService.MainDataSet.Rules)
            {
                if (!row.IsRowAlive()) continue;
                if (!row.idfsFormTemplate.Equals(idfsFormTemplate)) continue;
                //загружаем данные по параметрам функции, которая в этом правиле
                MainDbService.LoadRuleParameterForFunction(row.idfsRule);
                //загружаем действия по правилу
                MainDbService.LoadRuleParameterForAction(row.idfsRule);
                //загружаем константы (или предустановленные значения) по правилу
                MainDbService.LoadRuleConstants(row.idfsRule);
            }

            #endregion

            //если шаблон содержит тело таблицы, а не только боковик, то покажем его
            var finded = false;
            var pts = MainDbService.GetParameterTemplateRows(null, idfsFormTemplate, langid);
            foreach (var parameterTemplate in pts)
            {
                if (parameterTemplate.intOrder >= 0)
                {
                    finded = true;
                    break;
                }
            }

            if (finded)
            {
                //сначала разместим все секции, учитывая их вложенность
                RestoreSections(idfsFormTemplate, langid, isSummary);
                //разместим все параметры по их родителям
                RestoreParameters(idfsFormTemplate, langid, isSummary);
                //разместим все линии
                RestoreLines(idfsFormTemplate, langid);
                //разместим лейблы
                RestoreLabels(idfsFormTemplate, langid);

                //размещаем столбцы табличных секций в правильном порядке
                foreach (var sectionTable in SectionTableList.Values)
                {
                    sectionTable.RefreshBandPositions(sectionTable.GridViewMain.Bands);
                }

                //если был предустановленный боковик
                if (presetStubs != null)
                {
                    //Постобработка боковика
                    presetStubs.PostProcessingStub(SectionTableList, stubLength);
                }

                //определяем порядок перехода по параметрам
                var listTemplate = TemplateHelper.GetReportView(MainDbService, idfsFormTemplate);
                var tabIndex = 0;
                foreach (var dataRow in listTemplate)
                {
                    var parameterTemplateRow = dataRow as FlexibleFormsDS.ParameterTemplateRow;
                    if (parameterTemplateRow == null) continue;
                    if (!ParameterList.ContainsKey(parameterTemplateRow.idfsParameter)) continue;
                    ParameterList[parameterTemplateRow.idfsParameter].TabIndex = tabIndex;
                    tabIndex++;
                }
            }
            TemplateDesignerHost.ResumeLayout(true);
            
            NowLoadingTemplate = false;
        }

        /// <summary>
        /// Восстанавливает шаблон на контроле-хосте
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsFormType"></param>
        /// <param name="langid"></param>
        internal void RestoreTemplate(long idfsFormTemplate, long idfsFormType, string langid)
        {
            RestoreTemplate(idfsFormTemplate, idfsFormType, langid, null, null, null, false);
        }

        /// <summary>
        /// Визуализирует секции по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        /// <param name="isSummary"></param>
        internal void RestoreSections(long idfsFormTemplate, string langid, bool isSummary)
        {
            var sectionTemplateRows = MainDbService.GetSectionTemplateRows(null, idfsFormTemplate, langid);
            //если не найдено языковое описание шаблона, то берем соответствующее выбранному в системе языку
            if (sectionTemplateRows.Length == 0)
                sectionTemplateRows = MainDbService.GetSectionTemplateRows(null, idfsFormTemplate);
            if (sectionTemplateRows.Length == 0) return;

            ////построим все табличные секции верхнего уровня (у которых нет родителей))
            //foreach (var sectionTemplateRow in sectionTemplateRows)
            //{
            //    if ((sectionTemplateRow.blnGrid) && (sectionTemplateRow.IsidfsParentSectionNull()))
            //    {
            //        CreateSectionInTemplateHost(sectionTemplateRow, new Point(sectionTemplateRow.intLeft, sectionTemplateRow.intTop), isSummary);
            //    }
            //}

            foreach (var sectionTemplateRow in sectionTemplateRows)
            {
                //сначала построим секции верхнего уровня
                if (sectionTemplateRow.IsidfsParentSectionNull())
                    CreateSectionInTemplateHost(sectionTemplateRow,
                                                new Point(sectionTemplateRow.intLeft, sectionTemplateRow.intTop),
                                                isSummary);
            }

            foreach (var sectionTemplateRow in sectionTemplateRows)
            {
                //сначала построим секции верхнего уровня
                if (!sectionTemplateRow.IsidfsParentSectionNull())
                    CreateSectionInTemplateHost(sectionTemplateRow,
                                                new Point(sectionTemplateRow.intLeft, sectionTemplateRow.intTop),
                                                isSummary);
            }
        }

        /// <summary>
        /// Определяет добавлена ли уже секция в шаблон
        /// </summary>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        internal bool SectionAlreadyAdded(long idfsSection)
        {
            return IsSectionTable(idfsSection) || SectionList.ContainsKey(idfsSection);
        }

        /// <summary>
        /// Определяет добавлена ли уже секция в шаблон
        /// </summary>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        internal bool IsSectionTable(long idfsSection)
        {
            return SectionTableList.ContainsKey(idfsSection);
        }

        /// <summary>
        /// Определяет добавлен ли уже параметр в шаблон
        /// </summary>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        internal bool ParameterAlreadyAdded(long idfsParameter)
        {
            return ParameterList.ContainsKey(idfsParameter);
        }



        /// <summary>
        /// Событие, когда секция выбрана
        /// </summary>
        public event ParameterHost.SelectHandler SectionSelect;

        /// <summary>
        /// Событие, когда параметр выбран
        /// </summary>
        public event ParameterHost.SelectHandler ParameterSelect;

        /// <summary>
        /// Событие, когда лейбл выбран
        /// </summary>
        public event ParameterHost.SelectHandler LabelSelect;

        /// <summary>
        /// Событие, когда линия выбрана
        /// </summary>
        public event ParameterHost.SelectHandler LineSelect;

        /// <summary>
        /// Событие, когда компонент на шаблоне перестаёт быть выбранной
        /// </summary>
        public event ParameterHost.SelectHandler ParameterHostUnSelect;

        /// <summary>
        /// Событие, когда секция изменяет размеры
        /// </summary>
        public event EventHandler SectionResize;

        /// <summary>
        /// Событие, когда параметр изменяет размеры
        /// </summary>
        public event EventHandler ParameterResize;

        /// <summary>
        /// Событие, когда лейбл изменяет размеры
        /// </summary>
        public event EventHandler LabelResize;

        /// <summary>
        /// Событие, когда линия изменяет размеры
        /// </summary>
        public event EventHandler LineResize;

        /// <summary>
        /// Событие, когда производится клик мыши на рабочем столе шаблонов
        /// </summary>
        public event MouseEventHandler TemplateMouseDown;

        public delegate void EditValueChangingDelegate(object sender, ChangingEventArgs e);

        public delegate void SelectedBandChangedDelegate(GridBand selectedBand);

        /// <summary>
        /// Событие, когда изменяется текущий бэнд в гриде
        /// </summary>
        public event SelectedBandChangedDelegate OnSelectedBandChanged;

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

        /// <summary>
        /// Срабатывает для определения визуального стиля mandatory параметра
        /// </summary>
        public event SetControlMandatoryStateDelegate ParameterIsMandatory;

        /// <summary>
        /// Событие срабатывает, когда  значение в ячейке изменилось
        /// </summary>
        public event EditValueChangedDelegate EditValueChanged;

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
        /// Валидация изменения значения (для обычных параметров и столбцов в таблице)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEditValueChanging(object sender, ChangingEventArgs e)
        {
            var baseEdit = sender as BaseEdit;
            if (baseEdit == null) return;
            var parameter = baseEdit.Tag as Parameter;
            if ((parameter != null) && (parameter.IdfsParameterType != null) && (parameter.IdfsParameter != null))
            {
                if (MainDbService.IsParameterNumeric(parameter.IdfsParameter.Value))
                {
                    int value;
                    if ((e.NewValue != null) && Int32.TryParse(e.NewValue.ToString(), out value))
                    {
                        if (value > 99000000) e.Cancel = true;
                    }
                }
            }
            if ((EditValueChanging != null) && !e.Cancel) EditValueChanging(sender, e);
        }

        /// <summary>
        /// Отыскивает родительскую секцию либо создаёт её
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="parentSectionTemplateId"></param>
        /// <param name="mouseLocation"></param>
        /// <returns></returns>
        private Section FindParentSection(long idfsFormTemplate, long parentSectionTemplateId, Point mouseLocation)
        {
            Section result = null;

            //найдем по parentSectionTemplateId секцию
            //дешевле всего искать по библиотеке параметров, поскольку там всегда есть эта секция
            var sectionsRow = MainDbService.GetSectionRow(parentSectionTemplateId);
            if (sectionsRow != null)
            {
                //просматриваем всё содержимое хоста-контрола, чтобы понять, есть ли у нас уже эта секция
                if (SectionList.ContainsKey(sectionsRow.idfsSection))
                {
                    result = SectionList[sectionsRow.idfsSection];
                }
                else if (SectionTableList.ContainsKey(sectionsRow.idfsSection))
                {
                    result = SectionTableList[sectionsRow.idfsSection];
                }
                else
                {
                    //если отыскать секцию не удалось, то придётся её создать
                    //попробуем найти её среди тех, что добавлена в шаблон, но не помещена на Design Host
                    var sectionTemplateRow = MainDbService.GetSectionTemplateRow(parentSectionTemplateId, idfsFormTemplate);
                    result = sectionTemplateRow != null ? CreateSectionInTemplateHost(sectionTemplateRow, mouseLocation) : CreateSectionInTemplateHost(sectionsRow, mouseLocation, idfsFormTemplate);
                }
            }

            return result;
        }

        /// <summary>
        /// Создаёт секцию, а также все её родительские секции, и размещает их на дизайн-хосте шаблона
        /// </summary>
        /// <param name="rowSection"></param>
        ///<param name="mouseLocation"></param>
        /// <param name="idfsFormTemplate"></param>
        internal Section CreateSectionInTemplateHost(FlexibleFormsDS.SectionsRow rowSection, Point mouseLocation, long idfsFormTemplate)
        {
            //Добавляем строку в таблицу данных
            var rowSectionTemplate = MainDbService.CreateSectionTemplateRow(rowSection, idfsFormTemplate);
            rowSectionTemplate.intLeft = mouseLocation.X;
            rowSectionTemplate.intTop = mouseLocation.Y;
            return CreateSectionInTemplateHost(rowSectionTemplate, mouseLocation);
        }

        public const int DefaultCaptionHeight = 23;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowSectionTemplate"></param>
        /// <param name="mouseLocation"></param>
        /// <returns></returns>
        internal Section CreateSectionInTemplateHost(FlexibleFormsDS.SectionTemplateRow rowSectionTemplate, Point mouseLocation)
        {
            return CreateSectionInTemplateHost(rowSectionTemplate, mouseLocation, false);
        }

        /// <summary>
        /// Создаёт секцию, а также все её родительские секции, и размещает их на дизайн-хосте шаблона
        /// </summary>
        /// <param name="rowSectionTemplate"></param>
        ///<param name="mouseLocation"></param>
        ///<param name="isSummaryTemplate"></param>
        internal Section CreateSectionInTemplateHost(FlexibleFormsDS.SectionTemplateRow rowSectionTemplate, Point mouseLocation, bool isSummaryTemplate)
        {
            //проверим, если эта секция уже добавлена на рабочий стол, то выходим
            if (SectionAlreadyAdded(rowSectionTemplate.idfsSection)) return null;
            var section = rowSectionTemplate.blnGrid ? new SectionTable() : new Section();
            section.NowLoading = true;
            section.MainDbService = MainDbService;
            section.ParentRender = this;
            section.Location = new Point(rowSectionTemplate.intLeft, rowSectionTemplate.intTop); //mouseLocation;
            section.Size = new Size(rowSectionTemplate.intWidth, rowSectionTemplate.intHeight);
            section.CaptionHeight = rowSectionTemplate.IsintCaptionHeightNull()
                                        ? DefaultCaptionHeight
                                        : rowSectionTemplate.intCaptionHeight;
            section.ReadOnly = ReadOnly;
            section.OnSelect += OnSectionOnSelect;
            section.Resize += OnSectionOnResize;
            section.Splitter.SplitterMoved += OnSectionOnResize;
            
            //сначала проверим, вложена ли эта секция в другую секцию
            //у секции может быть только один родитель-секция или не быть вовсе
            //(построение предков)
            Section parentSection = null;
            if (!(rowSectionTemplate.IsidfsParentSectionNull()))
            {
                //Определение родительской секции
                //пробуем определить секцию, где должен лежать параметр
                //если найдём её, то положим туда контрол
                //если не найдём её, то создадим её
                parentSection = FindParentSection(rowSectionTemplate.idfsFormTemplate, rowSectionTemplate.idfsParentSection, mouseLocation);
            }
            //создаём секцию

            var sectionTable = section as SectionTable;
            //укажем, что созданная секция относится к этой строке
            section.Tag = rowSectionTemplate;
            //особые действия для табличных секций
            if (sectionTable != null)
            {
                //сделаем передачу указателя на источник данных
                sectionTable.MainDbService = MainDbService;
                //определим, можно ли в эту таблицу заводить новые строки (по умолчанию можно)
                if (rowSectionTemplate.blnFixedRowSet)
                    sectionTable.GridViewMain.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                sectionTable.GridViewMain.MouseDown += OnSectionTableGridViewMainMouseDown;
                //имеет ли фиксированный боковик
                sectionTable.IsFixedStubSection = CriticalObjects.Sections.ContainsKey(rowSectionTemplate.idfsSection);
            }
            //задаём свойства секции
            section.Name = String.Format("section{0}", rowSectionTemplate.idfsSection);

            section.Caption = rowSectionTemplate.NationalName;
            section.Visible = true;
            //на секцию тоже вешаем событие, чтобы можно было что-то в неё заносить
            section.TopControl().MouseDown += OnTemplateOnMouseDown;
            section.OnUnSelect += OnParameterHostOnUnSelect;
            //
            section.ParentSection = parentSection;

            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            if (parentSection != null)
            {
                //не может быть ситуации, когда в табличную секцию добавляется обычная
                //ситуация, когда в обычную секцию добавляется табличная, возможна
                if (!((parentSection is SectionTable) && (!(section is SectionTable))))
                    parentSection.Add(section);
            }
            else
            {
                //эта секция -- корневая
                TemplateDesignerHost.Add(section);
            }

            if (sectionTable != null)
            {
                sectionTable.Init(); //
                sectionTable.RootSection = sectionTable;
                //добавим в список быстрого доступа
                if (!SectionAlreadyAdded(rowSectionTemplate.idfsSection))
                    SectionTableList.Add(rowSectionTemplate.idfsSection, sectionTable);
                //подписываемся на событие изменения значения в ячейке таблицы
                sectionTable.EditValueChanging += OnEditValueChanging;
            }
            else
            {
                //добавим в список быстрого доступа
                if (!SectionAlreadyAdded(rowSectionTemplate.idfsSection))
                    SectionList.Add(rowSectionTemplate.idfsSection, section);
            }

            //выставим правильные размеры
            section.SetBestSize();

            //присвоим их строке
            rowSectionTemplate.intLeft = section.Left;
            rowSectionTemplate.intTop = section.Top;
            rowSectionTemplate.intWidth = section.Width;
            rowSectionTemplate.intHeight = section.Height;

            //если это табличная секция, то запустим построение её потомков
            //(построение потомков)
            if (sectionTable != null)
            {
                //запускаем рекурсивное построение табличных секций и параметров первого уровня (а для каждой т.с. затем запустится рекурсивное построение нижних секций)
                RestoreSectionTableChildren(sectionTable, rowSectionTemplate.idfsFormTemplate, isSummaryTemplate);
                //заканчиваем инициализацию табличной секции
                sectionTable.FinishInit();
            }

            section.LabelControlCaption.Visible = SectionTableCaptionsIsVisible;

            section.NowLoading = false;

            return section;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSectionTableGridViewMainMouseDown(object sender, MouseEventArgs e)
        {
            var gv = sender as AdvBandedGridView;
            if (gv == null) return;
            BaseHitInfo hit = gv.CalcHitInfo(e.Location);
            var bhit = hit as BandedGridHitInfo;
            if (bhit == null) return;
            var selectedBand = (bhit.Band != null) && (bhit.InBandPanel) ? bhit.Band : null;
            if (OnSelectedBandChanged != null) OnSelectedBandChanged(selectedBand);
        }

        private bool m_SectionTableCaptionsIsVisible;

        /// <summary>
        /// Показывать ли заголовки у табличных секций загруженного шаблона
        /// </summary>
        internal bool SectionTableCaptionsIsVisible
        {
            get { return m_SectionTableCaptionsIsVisible; }
            set{
                m_SectionTableCaptionsIsVisible = value;
                if (SectionTableList != null)
                {
                    foreach (var sectionTable in SectionTableList)
                    {
                        sectionTable.Value.LabelControlCaption.Visible = m_SectionTableCaptionsIsVisible;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnParameterHostOnUnSelect(ParameterHost parameterHost)
        {
            if (ParameterHostUnSelect != null) ParameterHostUnSelect(parameterHost);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnTemplateOnMouseDown(object sender, MouseEventArgs e)
        {
            if (TemplateMouseDown != null) TemplateMouseDown(sender, e);
        }

        /// <summary>
        /// Построение первого уровня дочерних табличных секций и параметров у табличной секции
        /// (построение более нижних уровней рекурсивное)
        /// </summary>
        /// <param name="sectionTable"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="isSummaryTemplate"></param>
        private void RestoreSectionTableChildren(SectionTable sectionTable, long idfsFormTemplate, bool isSummaryTemplate)
        {
            //построим те секции, которые непосредственно относятся к данной секции
            //также учтём параметры, и будем выводить с. и п. по порядку
            var sectionTemplateRows =
                (FlexibleFormsDS.SectionTemplateRow[])
                MainDbService.MainDataSet.SectionTemplate.Select(
                    DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "langid",
                                      String.Format("'{0}'", LanguageTemplate), "idfsParentSection",
                                      sectionTable.IdfsSection), "[intOrder] ASC");
            var parameterTemplateRows =
                (FlexibleFormsDS.ParameterTemplateRow[])
                MainDbService.MainDataSet.ParameterTemplate.Select(
                    DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "langid",
                                      String.Format("'{0}'", LanguageTemplate), "idfsSection", sectionTable.IdfsSection),
                    "[intOrder] ASC");
            var columns = new SortedDictionary<int, DataRow>();
            foreach (var sectionTemplateRow in sectionTemplateRows)
            {
                if (columns.ContainsKey(sectionTemplateRow.intOrder)) continue;
                columns.Add(sectionTemplateRow.intOrder, sectionTemplateRow);
            }
            foreach (var parameterTemplateRow in parameterTemplateRows)
            {
                if (columns.ContainsKey(parameterTemplateRow.intOrder)) continue;
                columns.Add(parameterTemplateRow.intOrder, parameterTemplateRow);
            }

            //строим все объекты данного уровня. 
            foreach (var dataRow in columns.Values)
            {
                if (dataRow is FlexibleFormsDS.SectionTemplateRow)
                {
                    //Для табличных секций рекурсивно запускаем построение их первого уровня (внутри CreateSectionInTemplateHost)
                    CreateSectionInTemplateHost((FlexibleFormsDS.SectionTemplateRow)dataRow, new Point(0, 0));
                }
                if (dataRow is FlexibleFormsDS.ParameterTemplateRow)
                {
                    CreateParameterInTemplateHost((FlexibleFormsDS.ParameterTemplateRow)dataRow, new Point(0, 0), isSummaryTemplate);
                }
            }
        }

        /// <summary>
        /// Добавляет параметр на хост-контрол
        /// </summary>
        /// <param name="rowParameterTemplate"></param>
        /// <param name="mouseLocation"></param>
        /// <param name="isSummaryTemplate"></param>
        /// <returns></returns>
        internal Parameter CreateParameterInTemplateHost(FlexibleFormsDS.ParameterTemplateRow rowParameterTemplate, Point mouseLocation, bool isSummaryTemplate)
        {
            //проверим, если эта секция уже добавлена на рабочий стол, то выходим
            if (ParameterAlreadyAdded(rowParameterTemplate.idfsParameter)) return null;

            //если в данный момент рендерится Summary-шаблон, то туда выводятся только числовые параметры, не входящие в боковик
            if (isSummaryTemplate && !MainDbService.IsParameterNumeric(rowParameterTemplate.idfsParameter) && (rowParameterTemplate.intOrder >= 0)) return null;
            
            var parameter = new Parameter
                                      {
                                          NowLoading = true,
                                          ParentRender = this,
                                          MainDbService = MainDbService,
                                          Tag = rowParameterTemplate,
                                          Scheme = ParameterSchemeHelper.ConvertToParameterScheme(rowParameterTemplate.intScheme),
                                          Editor = ParameterControlTypeHelper.ConvertToParameterControlType(rowParameterTemplate.idfsEditor),
                                          Text = rowParameterTemplate.NationalName,
                                          ParameterList = ParameterList,
                                          Visible = true,
                                          ReadOnly = ReadOnly,
                                          Location = mouseLocation,
                                          Size = new Size(rowParameterTemplate.intWidth, rowParameterTemplate.intHeight),
                                          LabelSize = rowParameterTemplate.intLabelSize
                                      };
            //parameter.IsDesignMode = false;
            //
            parameter.OnSelect += OnParameterOnSelect;
            parameter.SizeChanged += OnParameterOnResizeChanged;
            parameter.m_Splitter.SplitterMoved += OnParameterOnResizeChanged;
            parameter.EditValueChanged += OnEditValueChanged;
            parameter.EditValueChanging += OnEditValueChanging;
            
            parameter.OnUnSelect += OnParameterHostOnUnSelect;
            //параметр может находиться либо в своей секции, либо прямо на хост-контроле, если у него нет секции,
            //и он расположен сразу в типе формы
            Section parentSection = null;
            if (!rowParameterTemplate.IsidfsSectionNull() && !rowParameterTemplate.blnDynamicParameter)
            {
                //пробуем определить секцию, где должен лежать параметр
                //если найдём её, то положим туда контрол
                //если не найдём её, то создадим её
                parentSection = FindParentSection(rowParameterTemplate.idfsFormTemplate, rowParameterTemplate.idfsSection, mouseLocation);
            }
            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            if (!rowParameterTemplate.blnDynamicParameter)
            {
                if (parentSection != null)
                {
                    if (parentSection is SectionTable)
                    {
                        parameter.RootSection = ((SectionTable)parentSection).RootSection;
                    }
                    parentSection.Add(parameter);
                    //parameter.Backcolor = parentSection.BackColor;
                }
                else
                {
                    //параметр не может располагаться в чужой секции
                    //если у него нет своей секции, то он должен быть на хост-контроле
                    TemplateDesignerHost.Add(parameter);
                    //parameter.Backcolor = TemplateDesignerHost.BackColor;
                }
            }
            else
            {
                //ставим параметр на указанный родительский контрол                
                var parametersRow = MainDbService.GetParameterRow(rowParameterTemplate.idfsParameter);
                if (parametersRow != null) parameter.Text = parametersRow.NationalLongName;
                DynamicParametersGroupControl.Controls.Add(parameter);
                parameter.IsDesignMode = TemplateDesignerHost.IsDesignMode;
            }

            //добавим в список быстрого доступа
            //параметр может быть добавлен в секцию, если эта секция табличная, и там запустилось рекурсивное построение потомков
            if (!ParameterAlreadyAdded(rowParameterTemplate.idfsParameter))
                ParameterList.Add(rowParameterTemplate.idfsParameter, parameter);
            //выставим правильные размеры
            parameter.SetBestSize();

            //присвоим их строке
            rowParameterTemplate.intLeft = parameter.Left;
            rowParameterTemplate.intTop = parameter.Top;
            rowParameterTemplate.intWidth = parameter.Width;
            rowParameterTemplate.intHeight = parameter.Height;
            rowParameterTemplate.intLabelSize = parameter.LabelSize;

            //если параметр на форме обязательный, то специально маркируем его
            if (parameter.IsMandatoryField())
            {
                if (ParameterIsMandatory != null) 
                    ParameterIsMandatory(parameter.ControlParameter);
            }

            parameter.NowLoading = false;

            return parameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnParameterOnResizeChanged(object sender, EventArgs e)
        {
            if (ParameterResize != null) ParameterResize(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnParameterOnSelect(ParameterHost parameterHost)
        {
            if (ParameterSelect != null) ParameterSelect(parameterHost);
        }

        /// <summary>
        /// Трансляция события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSectionOnResize(object sender, EventArgs e)
        {
            if (SectionResize != null) SectionResize(sender, e);
        }

        /// <summary>
        /// Трансляция события
        /// </summary>
        /// <param name="parameterHost"></param>
        private void OnSectionOnSelect(ParameterHost parameterHost)
        {
            if (SectionSelect != null) SectionSelect(parameterHost);
        }

        /// <summary>
        /// Визуализирует параметры по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        /// <param name="isSummary"></param>
        internal void RestoreParameters(long idfsFormTemplate, string langid, bool isSummary)
        {
            var parameterTemplateRows = MainDbService.GetParameterTemplateRows(null, idfsFormTemplate, langid);
            //если не найдено языковое описание шаблона, то берем соответствующее выбранному в системе языку
            if (parameterTemplateRows.Length == 0)
                parameterTemplateRows = MainDbService.GetParameterTemplateRows(null, idfsFormTemplate);
            if (parameterTemplateRows.Length == 0) return;
            foreach (var parameterTemplateRow in parameterTemplateRows)
            {
                //динамические параметры рендерятся отдельно
                if (parameterTemplateRow.blnDynamicParameter) continue;
                CreateParameterInTemplateHost(parameterTemplateRow, new Point(parameterTemplateRow.intLeft, parameterTemplateRow.intTop), isSummary);
            }
        }

        /// <summary>
        /// Визуализирует линии по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        internal void RestoreLines(long? idfsFormTemplate, string langid)
        {
            //в отличие от параметров и секций, линии жестко привязаны к языку
            var linesRows = MainDbService.MainDataSet.Lines.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "langid", String.Format("'{0}'", langid)));
            if (linesRows.Length == 0) return;
            foreach (FlexibleFormsDS.LinesRow row in linesRows)
            {
                CreateLineInTemplateHost(row);
            }
        }

        /// <summary>
        /// Создаёт линию на рабочем столе шаблона
        /// </summary>
        /// <param name="linesRow"></param>
        internal Line CreateLineInTemplateHost(FlexibleFormsDS.LinesRow linesRow)
        {
            //создаём линию
            var line = new Line
                           {
                               NowLoading = true,
                               MainDbService = MainDbService,
                               ParentRender = this,
                               Tag = linesRow,
                               Location = new Point(linesRow.intLeft, linesRow.intTop),
                               Size = new Size(linesRow.intWidth, linesRow.intHeight),
                               BackColor = Color.FromArgb(linesRow.intColor)
                           };
            //задаём свойства линии
            line.OnSelect += OnLineOnSelect;
            line.SizeChanged += OnLineOnSizeChanged;
            line.OnUnSelect += OnParameterHostOnUnSelect;
            line.Visible = true;

            Section parentSection = null;
            if (!(linesRow.IsidfsSectionNull()))
            {
                //Определение родительской секции
                //если найдём её, то положим туда контрол
                //если не найдём её, то создадим её
                parentSection = FindParentSection(linesRow.idfsFormTemplate, linesRow.idfsSection, line.Location);
            }

            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            Control parent;
            if (parentSection != null)
            {
                parentSection.Add(line);
                parent = parentSection;
            }
            else
            {
                TemplateDesignerHost.Add(line);
                parent = TemplateDesignerHost;
            }

            //это событие будем использовать, чтобы подстраивать размеры линии под родителя
            parent.SizeChanged += OnLineParentSizeChanged;

            //добавим в коллекцию быстрого доступа
            LineList.Add(linesRow.idfDecorElement, line);

            //выставим правильные размеры
            line.SetBestSize();
            line.LookAndFeel.Style = LookAndFeelStyle.Flat;
            line.LookAndFeel.UseDefaultLookAndFeel = false;

            //если нужно -- подстроим под размер родительского компонента
            line.ResizeLine();

            line.NowLoading = false;
            return line;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLineParentSizeChanged(object sender, EventArgs e)
        {
            //при изменении размеров родителя линии нужно подстроить все линии, которые относятся к этому родителю, к новым размерам
            foreach (long idfDecorElement in LineList.Keys)
            {
                var line = LineList[idfDecorElement];
                if (line.Parent == null) continue;
                //если линия расположена на родителе, то нужно перевычислить ее размеры
                //родителем может быть либо темплейт-хост или секция
                if (line.Parent == TemplateDesignerHost)
                {
                    line.ResizeLine(TemplateDesignerHost);
                }
                else
                {
                    //TODO м.б. сделать вспомогательный метод для выявления истинного родителя-секции
                    if ((line.Parent.Parent != null) && (line.Parent.Parent.Parent == sender))
                    {
                        line.ResizeLine();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLineOnSizeChanged(object sender, EventArgs e)
        {
            if (LineResize != null) LineResize(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnLineOnSelect(ParameterHost parameterHost)
        {
            if (LineSelect != null) LineSelect(parameterHost);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnLabelOnSelect(ParameterHost parameterHost)
        {
            if (LabelSelect != null) LabelSelect(parameterHost);
        }

        /// <summary>
        /// Визуализирует лейблы по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        internal void RestoreLabels(long idfsFormTemplate, string langid)
        {
            //в отличие от параметров и секций, лейблы жестко привязаны к языку
            var lablesRows = MainDbService.GetLabelTemplateRows(idfsFormTemplate, langid);
            if (lablesRows.Length == 0) return;
            foreach (var row in lablesRows)
            {
                CreateLabelInTemplateHost(row);
            }
        }

        /// <summary>
        /// Создаёт лейбл на рабочем столе шаблона
        /// </summary>
        /// <param name="labelsRow"></param>
        internal Label CreateLabelInTemplateHost(FlexibleFormsDS.LabelsRow labelsRow)
        {
            //создаём лейбл
            var label = new Label
                            {
                                NowLoading = true,
                                MainDbService = MainDbService,
                                ParentRender = this,
                                Tag = labelsRow,
                                MinimumSize = new Size(20, 10),
                                Location = new Point(labelsRow.intLeft, labelsRow.intTop),
                                Size = new Size(labelsRow.intWidth, labelsRow.intHeight),
                                mainLabel = {Text = labelsRow.NationalText}
                            };
            //задаём свойства
            label.mainLabel.Font = new Font(label.mainLabel.Font.FontFamily, labelsRow.intFontSize,
                                            HelperFunctions.ConvertToFontStyle(labelsRow.intFontStyle));
            label.mainLabel.ForeColor = Color.FromArgb(labelsRow.intColor);
            label.OnSelect += OnLabelOnSelect;
            label.SizeChanged += OnLabelSizeChanged;
            label.OnUnSelect += OnParameterHostOnUnSelect;
            label.Visible = true;

            Section parentSection = null;
            if (!(labelsRow.IsidfsSectionNull()))
            {
                //Определение родительской секции
                //если найдём её, то положим туда контрол
                //если не найдём её, то создадим её
                parentSection = FindParentSection(labelsRow.idfsFormTemplate, labelsRow.idfsSection, label.Location);
            }

            //помещаем ее либо в родительскую секцию, либо прямо на хост-контрол
            if (parentSection != null)
            {
                parentSection.Add(label);
            }
            else
            {
                TemplateDesignerHost.Add(label);
            }

            //выставим правильные размеры
            label.SetBestSize();
            label.NowLoading = false;

            //добавим в коллекцию быстрого доступа
            if (!LabelList.ContainsKey(labelsRow.idfDecorElement))
                LabelList.Add(labelsRow.idfDecorElement, label);

            return label;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLabelSizeChanged(object sender, EventArgs e)
        {
            if (LabelResize != null) LabelResize(sender, e);
        }

        public static long idfObservationFake { get { return -200; } }

        /// <summary>
        /// Осуществляет слияние шаблонов и боковиков, которые относятся к указанным observation
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="idfsFormTemplateMerged">ID шаблона, в который нужно поместить совокупный шаблон</param>
        internal bool MergeTemplates(long idfsFormTemplateMerged, List<long> observations, FFType formType)
        {
            var isEmptySummary = observations.Count == 0;

            var idfsFormType = (long)formType;

            //если по данному типу формы, к которому относится шаблон, не загружены мета-данные по секциям, то дозагрузим их
            //(проверка уже внутри)
            MainDbService.LoadSections(idfsFormType, null, null);
            MainDbService.LoadParameters(idfsFormType, null);
           
            //каждому observation может соответствовать свой шаблон, потому надо загрузить их все
            var observationsRows = new List<FlexibleFormsDS.ObservationsRow>();
            if (!isEmptySummary)
            {
                observationsRows.AddRange(MainDbService.LoadObservations(observations));
            }
            else
            {
                var row = MainDbService.MainDataSet.Observations.NewObservationsRow();
                long? idfsFormTemplateActual;
                MainDbService.LoadActualTemplate(EidssSiteContext.Instance.CountryID, null, idfsFormType, out idfsFormTemplateActual);
                if (!idfsFormTemplateActual.HasValue) return false;
                row.idfsFormTemplate = idfsFormTemplateActual.Value;
                row.idfObservation = idfObservationFake;
                observationsRows.Add(row);
            }
            
            //если из БД ничего не подгрузилось
            if (observationsRows.Count == 0) return false;

            //очистим структуру собранной таблицы
            DataHelper.DeleteRows(MainDbService.MainDataSet.ParameterTemplate, idfsFormTemplateMerged, ModelUserContext.CurrentLanguage);
            DataHelper.DeleteRows(MainDbService.MainDataSet.SectionTemplate, idfsFormTemplateMerged, ModelUserContext.CurrentLanguage);

            #region Загрузка данных по телу таблицы

            //нужно сначало тело, потому что боковик проверяет наличие нужных табличных секций в шаблоне
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                //загружаем данные по каждому шаблону (если они до сих пор не загружены)
                MainDbService.LoadSectionTemplate(observationsRow.idfsFormTemplate);
                MainDbService.LoadParameterTemplate(observationsRow.idfsFormTemplate);
            }

            #endregion

            //порядок именно такой, потому что боковик заносит признаки загрузки боковика и в тело шаблона

            #region Слияние структуры по шапке таблицы

            //очищаем данные предыдущего слияния
            ClearTemplate();

            //копируем секции в саммари-шаблон
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;

                //Копия секций в шаблоне
                CopyHelper.CopySectionTemplate(MainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, ModelUserContext.CurrentLanguage);

                //Копия параметров в шаблоне
                CopyHelper.CopyParameterTemplate(MainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, ModelUserContext.CurrentLanguage);
            }

            #endregion

            #region Слияние структуры по боковику

            var listStubInfo = MainDbService.GetListSectionsAndVersionsForStub(observationsRows, formType);
            //получаем информацию о версии матрицы боковика
            //загружаем данные по боковику и сразу вставляем их в шаблон
            var stubLength = MainDbService.IncludeStub(idfsFormTemplateMerged, listStubInfo);

            #endregion
          
            //если шаблон содержит тело таблицы, а не только боковик, то покажем его
            var finded = false;
            var pts = MainDbService.GetParameterTemplateRows(null, idfsFormTemplateMerged, ModelUserContext.CurrentLanguage);
            foreach (var parameterTemplate in pts)
            {
                if (parameterTemplate.intOrder >= 0)
                {
                    finded = true;
                    break;
                }
            }

            if (finded)
            {
                //сначала разместим все секции, учитывая их вложенность
                RestoreSections(idfsFormTemplateMerged, ModelUserContext.CurrentLanguage, true);
                //разместим все параметры по их родителям
                RestoreParameters(idfsFormTemplateMerged, ModelUserContext.CurrentLanguage, true);

                //Постобработка боковика
                listStubInfo.PostProcessingStub(SectionTableList, stubLength);
            }
            return finded;
        }

        /// <summary>
        /// Происходит ли сейчас загрузка/инициализация шаблона
        /// </summary>
        public bool NowLoadingTemplate { get; set; }

        /// <summary>
        /// Происходит ли сейчас очистка шаблона
        /// </summary>
        public bool NowClearingTemplate { get; set; }

        public CriticalObjectsHelper CriticalObjects { get; set; }
    }
}
