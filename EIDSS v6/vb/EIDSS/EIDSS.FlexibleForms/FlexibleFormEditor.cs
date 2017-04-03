using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Objects;
using bv.common.db.Core;
using bv.common.win;
using bv.winclient.BasePanel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;
using System;
using System.Drawing;
using EIDSS.FlexibleForms.DesignerHosting;
using EIDSS.FlexibleForms.Helpers;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors.Controls;
using eidss.model.Enums;
using Label = EIDSS.FlexibleForms.Components.Label;
using DevExpress.XtraGrid.Views.BandedGrid;
using FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;
using System.Linq;
using BaseReferenceType = bv.common.db.BaseReferenceType;
using FFDecorElementTypes = bv.common.FFDecorElementTypes;
using FFDeterminantTypes = bv.common.FFDeterminantTypes;
using FFEditModes = bv.common.FFEditModes;
using FFParameterEditors = bv.common.FFParameterEditors;
using FFParameterTypes = bv.common.FFParameterTypes;
using FFRuleCheckPointType = bv.common.FFRuleCheckPointType;
using FFRuleFunctions = bv.common.FFRuleFunctions;

namespace EIDSS.FlexibleForms
{
    /// <summary>
    /// Редактор динамических форм (Flexible Forms)
    /// </summary>
    public partial class FlexibleFormEditor : BaseDetailList
    {
        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;

                //всем элементам проставляем
                if (value)
                {
                    propSection.Enabled =
                        propParameter.Enabled =
                        pnlParameterDesignHost.Enabled =
                        standaloneBarDockControl3.Enabled =
                        standaloneBarDockControl1.Enabled =
                        pnlTemplateDesignHost.Enabled =
                        tbcTemplateComponentsProperties.Enabled =
                        false;

                }
                miTemplateLanguage.Enabled = true;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public FlexibleFormEditor()
        {
            InitializeComponent();
            //
            nbcTemplatesEditor.View = new StandardSkinNavigationPaneViewInfoRegistrator(BaseSettings.SkinName);

            DbService = new DbService();
            baseDataSet = MainDbService.MainDataSet;
            MainDbService.OnAfterPost += OnMainDbServiceOnAfterPost;
            Load += OnFlexibleFormEditorLoad;
            PermissionObject = EIDSSPermissionObject.FlexibleForm;

            ffRender = new FFRender((DbService)DbService, pnlTemplateDesignHost);
            ffRender.TemplateDesignerHost.RightClick += OnTemplateDesignerHostRightClick;
            ffRender.EditValueChanging += OnFlexibleFormEditorEditValueChanging;
            ffRender.EditValueChanged += OnFlexibleFormEditorEditValueChanged;
            ffRender.ParameterIsMandatory += SetControlMandatoryState;
            ffRender.SectionSelect += OnSectionSelect;
            ffRender.SectionResize += OnSectionSizeChanged;
            ffRender.ParameterSelect += OnParameterSelect;
            ffRender.ParameterResize += OnParameterSizeChanged;
            ffRender.LabelSelect += OnLabelSelect;
            ffRender.LabelResize += OnLabelSizeChanged;
            ffRender.LineSelect += OnLineSelect;
            ffRender.LineResize += OnLineSizeChanged;
            ffRender.ParameterHostUnSelect += OnParameterHostOnUnSelect;
            ffRender.TemplateMouseDown += OnTemplateMouseDown;
            ffRender.OnSelectedBandChanged += OnSelectedBandChanged;
            cbTemplateUNI.EditValueChanged += OnCbTemplateUNIOnEditValueChanged;
            //стартовые параметры
            tbcRedParamProperties.ShowTabHeader = tbcTemplateComponentsProperties.ShowTabHeader = DefaultBoolean.False;
            tbcRedParamProperties.SelectedTabPage = tbpRedFormType;
            //
            tbcMain.SelectedTabPage = tbpParameters;

            //группа Шаблонов будет активной при старте
            nbcTemplatesEditor.ActiveGroup = nbgTemplates;

            //действия в правиле
            repPopupRuleActions.Popup += OnPopupRuleActionsPopup;
            repPopupRuleActions.CloseUp += OnPopupRuleActionsCloseUp;

            popupRuleActions.QueryPopUp += OnRuleActionsQueryPopUp;
            popupRuleActions.Popup += OnRuleActionsPopup;
            popupRuleActions.CloseUp += OnRuleActionsCloseUp;

            //константы в правиле
            repPopupRuleConstants.Popup += OnPopupRuleConstantsPopup;
            repPopupRuleConstants.CloseUp += OnPopupRuleConstantsCloseUp;

            //меню для копирования и вставки секций и параметров
            popupParameters.Popup += OnPopupParametersPopup;
            //меню для копирования шаблонов см. дизайн файл
            //
            constantsFixedPreset.EditValueChanged += OnConstantsFixedPresetEditValueChanged;
            //
            barManagerMain.SetPopupContextMenu(treeTemplates, popupTemplates);
            barManagerMain.SetPopupContextMenu(treeParameters, popupParameters);
            //
            OnAfterPost += OnFlexibleFormEditorOnAfterPost;

            erParameterID.Visible = erSectionID.Visible = erTemplateID.Visible =
                                                          erTemplateParameterID.Visible = erTemplateSectionID.Visible = erLabelID.Visible
                                                                                          = false;//true; 

            StrEmpty = EidssMessages.Get("strEmpty");
            StrPointer = EidssMessages.Get("strPointer");
            delimiterPath = EidssMessages.Get("delimiterPath");

            nationalTemplateName = EidssMessages.Get("defaultTemplateName");
            nationalRuleName = EidssMessages.Get("defaultRuleName");
            nationalSectionName = EidssMessages.Get("defaultSectionName");
            nationalParameterName = EidssMessages.Get("defaultParameterName");
            nationalLabelName = EidssMessages.Get("defaultLabelName");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedBand"></param>
        void OnSelectedBandChanged(GridBand selectedBand)
        {
            if (selectedBand == null) return;
            btnFreezeSection.Down = selectedBand.RootBand.Fixed.Equals(FixedStyle.Left);
        }

        //private bool selectPermission;
        private bool UpdatePermission { get; set; }
        private bool DeletePermission { get; set; }
        private bool InsertPermission { get; set; }

        //private CriticalObjectsHelper CriticalObjectsHelper { get; set; }

        /// <summary>
        /// Клик по переключателю UNI/не UNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnCbTemplateUNIOnEditValueChanged(object sender, EventArgs e)
        {
            var templatesRow = GetActiveTemplate();
            if (templatesRow == null) return;
            var checkEdit = sender as CheckEdit;
            if (checkEdit == null) return;

            if (checkEdit.Checked)
            {
                //если UNI-признак поставлен другом шаблону из этого FF-типа, то предложим сменить
                //иначе просто поставим
                var templatesRows = MainDbService.GetTemplatesByFormType(templatesRow.idfsFormType);
                foreach (var row in templatesRows)
                {
                    if (row.blnUNI)
                    {
                        if (
                            !WinUtils.ConfirmMessage(
                                String.Format(EidssMessages.Get("Question_Change_UNI"), row.NationalName,
                                              templatesRow.NationalName), String.Empty))
                        {
                            templatesRow.blnUNI = false;
                            checkEdit.Checked = false;
                            return;
                        }
                        row.blnUNI = false;
                        break;
                    }
                }
            }
            else
            {
                //нельзя снимать последний UNI. У типа формы должен быть хотя бы один UNI (10366)
                var templatesRows = MainDbService.GetTemplatesByFormType(templatesRow.idfsFormType);
                var hasAnotherUni = false;
                foreach (var row in templatesRows)
                {
                    if (!row.IsRowAlive()) continue;
                    if (row.idfsFormTemplate == templatesRow.idfsFormTemplate) continue;
                    if (row.blnUNI)
                    {
                        hasAnotherUni = true;
                        break;
                    }
                }
                if (!hasAnotherUni)
                {
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("TemplateUNI_Mustbe"));
                    templatesRow.blnUNI = true;
                    cbTemplateUNI.EditValueChanged -= OnCbTemplateUNIOnEditValueChanged;
                    cbTemplateUNI.ValueChecked = true;
                    cbTemplateUNI.EditValueChanged += OnCbTemplateUNIOnEditValueChanged;
                }
            }

            #region Прежняя бизнес-логика

            /*
            //если у данного шаблона нет детерминантов и у другого UNI тоже нет детерминантов, то выставить этому признак UNI нельзя
            if (checkEdit.Checked)
            {
                bool wasError = false;
                //если у этого шаблона несколько детерминантов типа страна, то он в принципе не может быть UNI
                if (MainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate, FFDeterminantTypes.Country).Length > 1)
                {
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("Determinants_Already_Have_Country"));
                    wasError = true;
                }

                //если у этого шаблона нет детерминантов и есть другой шаблон тоже без детерминантов, то  нужно предложить переставить UNI с того на этот шаблон
                if (MainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate).Length == 0)
                {
                    var templatesRows = MainDbService.GetTemplatesByFormType(templatesRow.idfsFormType);
                    foreach (var row in templatesRows)
                    {
                        if (!row.blnUNI) continue;
                        if (row.idfsFormTemplate.Equals(templatesRow.idfsFormTemplate)) continue;
                        //получим список шаблонов, у которых нет детерминантов
                        if (MainDbService.GetTemplateDeterminants(row.idfsFormTemplate).Length == 0)
                        {
                            //если пользователь не хочет снимать признак UNI с найденного шаблона, чтобы остался только на этом шаблоне, значит на этот шаблон не ставим детерминант-страну
                            if (!WinUtils.ConfirmMessage(String.Format(EidssMessages.Get("Determinants_Question_Remove_UNI2"), row.NationalName), String.Empty))
                            {
                                wasError = true;
                                break;
                            }
                            row.blnUNI = false;

                            //ErrorForm.ShowMessageDirect(String.Format(EidssMessages.Get("TemplateUNI_Cant_Set", null, null), row.NationalName));
                            //wasError = true;
                            //break;
                        }
                    }
                }

                var determinants =
                    MainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate, FFDeterminantTypes.Country);
                if (determinants.Length == 1)
                {
                    //если всё правильно, но есть ещё шаблон с такой же страной, то предложим сменить
                    var templates =
                        MainDbService.GetTemplateWithSameDeterminant(determinants[0].IsidfsBaseReferenceNull() ? determinants[0].idfsGISBaseReference : determinants[0].idfsBaseReference, templatesRow.idfsFormType, true);
                    foreach (var templateDeterminantValuesRow in templates)
                    {
                        var template = MainDbService.GetTemplateRow(templateDeterminantValuesRow.idfsFormTemplate);
                        if (template == null) return;
                        if (templatesRow.idfsFormTemplate.Equals(template.idfsFormTemplate)) continue;
                        //если пользователь не хочет снимать признак UNI с найденного шаблона, чтобы остался только на этом шаблоне, значит на этот шаблон не ставим детерминант-страну
                        if (!WinUtils.ConfirmMessage(String.Format(EidssMessages.Get("Determinants_Question_Remove_UNI"), template.NationalName), String.Empty))
                        {
                            wasError = true;
                            //break;
                        }
                        else
                        {
                            template.blnUNI = false;
                        }
                    }
                }
                if (wasError)
                {
                    templatesRow.blnUNI = false;
                    checkEdit.Checked = false;
                }
            }

            //блокируем признак UNI, если он выставлен, потому что вручную его снять нельзя
            erTemplateUNI.Enabled = !templatesRow.blnUNI;
            */
            #endregion

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnConstantsFixedPresetEditValueChanged(object sender, EventArgs e)
        {
            var row = grdvRuleConstants.GetFocusedRow() as FlexibleFormsDS.RuleConstantRow;
            if (row == null) return;
            var lookUpEdit = ((LookUpEdit)sender);
            row.varConstant = lookUpEdit.EditValue;
        }

        private string StrEmpty { get; set; }
        private const string StrEmptyKey = "emptykey";
        private string StrPointer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFlexibleFormEditorEditValueChanged(object sender, EventArgs e)
        {
            if (EditValueChanged != null) EditValueChanged(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        private FFRender ffRender { get; set; }

        /// <summary>
        /// Выставляет доступность кнопки, опираясь на пользовательские права
        /// </summary>
        /// <param name="button"></param>
        /// <param name="type">true -- кнопка на добавление, false -- кнопка на удаление</param>
        private void SetButtonEnabled(BarButtonItem button, bool type)
        {
            if (type)
            {
                button.Enabled = InsertPermission || ReadOnly;
            }
            else
            {
                button.Enabled = DeletePermission || ReadOnly;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFlexibleFormEditorLoad(object sender, EventArgs e)
        {
            #region Определение прав доступа и доступности контролов

            AuditObject = new AuditObject((long)EIDSSAuditObject.daoFlexibleFormDesigner, (long)AuditTable.ffParameter);
            PermissionObject = eidss.model.Enums.EIDSSPermissionObject.FlexibleForm;
            //определяем доступность по правам
            //selectPermission = eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(PermissionObject));
            UpdatePermission = EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(PermissionObject));
            InsertPermission = EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(PermissionObject));
            DeletePermission = EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(PermissionObject));
            
            //применяем права к интерфейсу
            btnAddDeterminant.Enabled =
                btnAddLabelToTemplate.Enabled = btnAddLineToTemplate.Enabled = btnAddParameter.Enabled =
                                                                               btnAddRule.Enabled =
                                                                               btnAddSection.Enabled =
                                                                               btnRuleAddConstant.Enabled =
                                                                               btnAddTemplate.Enabled =
                                                                               InsertPermission && !ReadOnly;
            btnFreezeSection.Enabled = UpdatePermission || InsertPermission || !ReadOnly;

            btnDeleteDeterminant.Enabled = btnDeleteParameter.Enabled = btnDeleteRule.Enabled =
                                                                        btnDeleteSection.Enabled =
                                                                        btnDeleteTemplate.Enabled =
                                                                        btnRuleDeleteConstant.Enabled =
                                                                        btnTemplateRemoveObject.Enabled =
                                                                        DeletePermission && !ReadOnly;
            barTemplateManagement.Visible = 
                standaloneBarDockControl3.Visible =
                barTemplateItems.Visible = 
                barTemplateCommands.Visible = !ReadOnly;

            ffRender.ReadOnly = ReadOnly;

            #endregion

            
        }

        public override bool LoadData(ref object id)
        {
            var result = base.LoadData(ref id);

            #region Открытие активного шаблона

            //считаем, что передается ИД шаблона + ИД его типа формы
            long idfsFormTemplate = 0;
            
            if ((StartUpParameters != null) && StartUpParameters.ContainsKey("t"))
            {
                idfsFormTemplate = (long) StartUpParameters["t"];
            }
            
            if (idfsFormTemplate > 0)
            {
                //получаем тип формы
                var templatesRow = MainDbService.LoadTemplate(idfsFormTemplate);
                if (templatesRow != null)
                {
                    //отыскиваем узел в дереве шаблонов
                    TreeListNode formTemplateNode = null;
                    foreach (TreeListNode node in treeTemplates.Nodes)
                    {
                        var ftRow = node.Tag as FlexibleFormsDS.FormTypesRow;
                        if ((ftRow != null) && (ftRow.idfsFormType == templatesRow.idfsFormType))
                        {
                            formTemplateNode = node;
                            break;
                        }
                    }
                    if (formTemplateNode != null)
                    {
                        formTemplateNode.ExpandAll();
                        //дерево динамически достроилось. Добавились узлы шаблонов. Ищем среди них нужный.
                        foreach (TreeListNode node in formTemplateNode.Nodes)
                        {
                            var tRow = node.Tag as FlexibleFormsDS.TemplatesRow;
                            if ((tRow != null) && (tRow.idfsFormTemplate == idfsFormTemplate))
                            {
                                tbcMain.SelectedTabPage = tbpTemplates;
                                treeTemplates.FocusedNode = node;
                                OnTreeTemplatesClick(this, EventArgs.Empty);
                                break;
                            }
                        }
                    }
                    
                }
            }


            //OnTemplateMouseDown

            #endregion

            return result;
        }

        /// <summary>
        /// Действия после успешного сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMainDbServiceOnAfterPost(object sender, PostEventArgs e)
        {
            var listDelete = new List<long>();
            var dictionary = new Dictionary<long, Line>();
            //переменим в словаре ID на реальные
            foreach (var key in ffRender.LineList.Keys)
            {
                if (key > 0) continue;
                var line = ffRender.LineList[key];
                var linesRow = (FlexibleFormsDS.LinesRow)line.Tag;
                listDelete.Add(key);
                dictionary.Add(linesRow.idfDecorElement, line);
            }
            foreach (var key in listDelete)
            {
                ffRender.LineList.Remove(key);
            }
            foreach (var key in dictionary.Keys)
            {
                ffRender.LineList.Add(key, dictionary[key]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnRuleActionsPopup(object sender, EventArgs e)
        {
            var rowParameterTemplate = (FlexibleFormsDS.ParameterTemplateRow)treeRuleActionParameters.Selection[0].Tag;
            //должно быть выбрано активное правило
            var rowRules = GetActiveRule();
            if (rowRules == null) return;

            //определяем какие действия выбраны для этого параметра
            var rows =
                    (FlexibleFormsDS.RuleParameterForActionRow[])
                    MainDbService.MainDataSet.RuleParameterForAction.Select(
                        DataHelper.Filter("idfsRule", rowRules.idfsRule, "idfsParameter", rowParameterTemplate.idfsParameter));

            //снимаем выделение
            foreach (Control control in popupRuleActions.PopupControl.Controls)
            {
                ((CheckEdit)control).Checked = false;
            }

            //проставляем выделение там, где ранее было что-то выбрано
            foreach (var row in rows)
            {
                if (!row.IsRowAlive()) continue;

                foreach (Control control in popupRuleActions.PopupControl.Controls)
                {
                    if (control.Tag == null) continue;
                    long id;
                    if (!Int64.TryParse(control.Tag.ToString(), out id)) continue;
                    if (id.Equals(row.idfsRuleAction))
                        ((CheckEdit)control).Checked = true;
                }
            }
        }

        /// <summary>
        /// После сохранения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFlexibleFormEditorOnAfterPost(object sender, EventArgs e)
        {
            if (parEditingParameter != null)
                parEditingParameter.RefreshSelectListInControl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupRuleActionsCloseUp(object sender, CloseUpEventArgs e)
        {
            //помещаем свойства выбранного правила
            propTemplateRule.SelectedObject = null;
            propTemplateRule.SelectedObject = GetActiveRule();
        }

        /// <summary>
        /// Секция, помеченная как источник для копирования
        /// </summary>
        private FlexibleFormsDS.SectionsRow RowCopiedSection { get; set; }
        /// <summary>
        /// Параметр, помеченный как источник для копирования
        /// </summary>
        private FlexibleFormsDS.ParametersRow RowCopiedParameter { get; set; }
        /// <summary>
        /// Шаблон, помеченный как источник для копирования
        /// </summary>
        private FlexibleFormsDS.TemplatesRow RowCopiedTemplate { get; set; }

        /// <summary>
        /// Контекстное меню на дереве параметров и секций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupParametersPopup(object sender, EventArgs e)
        {
            if (treeParameters.Selection.Count == 0)
            {
                btnCopySectionOrParameter.Enabled = btnPasteSectionOrParameter.Enabled = false;
                return;
            }
            //копирование доступно только при положении курсора на параметре либо секции
            //вставка доступна когда курсор на типе формы или секции. также должно быть сделано предварительное копирование.
            //вставка секции недоступна в саму себя и в своего потомка-секцию
            object tag = treeParameters.Selection[0].Tag;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            var rowSections = tag as FlexibleFormsDS.SectionsRow;
            var rowParameters = tag as FlexibleFormsDS.ParametersRow;
            bool isFormType = rowFormType != null;
            bool isSection = rowSections != null;
            bool isParameter = rowParameters != null;
            bool existCopiedObject = !((RowCopiedSection == null) && (RowCopiedParameter == null));
            //если копируется секция, то дополнительные проверки на место, куда её вставляют
            if ((RowCopiedSection != null) && isSection)
            {
                existCopiedObject = !MainDbService.IsChildSection(RowCopiedSection.idfsSection, rowSections.idfsSection);
            }

            btnCopySectionOrParameter.Enabled = isSection || isParameter;
            btnPasteSectionOrParameter.Enabled = (isFormType || isSection) && existCopiedObject;
        }

        /// <summary>
        /// Закрытие окна ввода констант
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupRuleConstantsCloseUp(object sender, CloseUpEventArgs e)
        {
            //помещаем свойства выбранного правила
            var rowRules = GetActiveRule();
            //propTemplateRule.SelectedObject = null;
            //propTemplateRule.SelectedObject = rowRules;
            if (grdvRuleConstants.EditingValue != null)
            {
                var row = grdvRuleConstants.GetFocusedRow() as FlexibleFormsDS.RuleConstantRow;
                if (row != null) row.varConstant = grdvRuleConstants.EditingValue;
            }

            if (rowRules != null) rowRules.ConstantsText = MainDbService.GetRuleConstantsText(rowRules);
        }

        /// <summary>
        /// Открытие окна ввода предустановленных значений для правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupRuleConstantsPopup(object sender, EventArgs e)
        {
            //именно такой порядок
            if (grdRuleConstants.Parent == null) grdRuleConstants.Parent = popupRuleConstants;
            if (standaloneBarDockControlRuleConstants.Parent == null) standaloneBarDockControlRuleConstants.Parent = popupRuleConstants;
            //присвоим строки констант, связанных с выбранным правилом, таблице на открывающемся окне
            RefreshRuleConstants();
        }

        /// <summary>
        /// Обновляет строки констант в таблице для правила
        /// </summary>
        private void RefreshRuleConstants()
        {
            //присвоим строки констант, связанных с выбранным правилом, таблице на открывающемся окне
            //должно быть выбрано активное правило
            var rowRules = GetActiveRule();
            if (rowRules == null) return;
            //определяем какие константы выбраны для этого правила
            grdRuleConstants.DataSource = MainDbService.MainDataSet.RuleConstant.Select(DataHelper.Filter("idfsRule", rowRules.idfsRule));
        }

        /// <summary>
        /// Попытка открыть окно выбора действий для правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnRuleActionsQueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //если в текущем узле находится не параметр, то отменяем открытие окна
            if (treeRuleActionParameters.Selection.Count == 0) e.Cancel = true;
            if (!(treeRuleActionParameters.Selection[0].Tag is FlexibleFormsDS.ParameterTemplateRow)) e.Cancel = true;
        }

        /// <summary>
        /// Возвращает правило, которое сейчас выбрано
        /// </summary>
        /// <returns></returns>
        private FlexibleFormsDS.RulesRow GetActiveRule()
        {
            FlexibleFormsDS.RulesRow result = null;

            if ((treeRules.Selection.Count > 0) && (treeRules.Selection[0].Tag != null))
            {
                result = (FlexibleFormsDS.RulesRow)treeRules.Selection[0].Tag;
            }
            return result;
        }

        /// <summary>
        /// Возвращает шаблон, который сейчас выбран 
        /// <returns></returns>
        /// </summary>
        private FlexibleFormsDS.TemplatesRow GetActiveTemplate()
        {
            FlexibleFormsDS.TemplatesRow result = null;

            if ((treeTemplates.Selection.Count > 0) && (treeTemplates.Selection[0].Tag is FlexibleFormsDS.TemplatesRow))
            {
                result = (FlexibleFormsDS.TemplatesRow)treeTemplates.Selection[0].Tag;
            }
            return result;
        }

        /// <summary>
        /// Закрытие окна выбора действия для параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRuleActionsCloseUp(object sender, CloseUpEventArgs e)
        {
            if (treeRuleActionParameters.Selection.Count == 0) return;
            if (!(treeRuleActionParameters.Selection[0].Tag is FlexibleFormsDS.ParameterTemplateRow)) return;
            var rowParameterTemplate = (FlexibleFormsDS.ParameterTemplateRow)treeRuleActionParameters.Selection[0].Tag;
            //нельзя использовать несохранённый параметр
            if (rowParameterTemplate.idfsParameter < 0)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("Rule_Cant_Add_Unsaved_Parameter"));
                return;
            }

            //должно быть выбрано активное правило
            var rowRules = GetActiveRule();
            if (rowRules == null) return;

            //получаем выбранные действия для правила
            var idsActions = new List<long>();
            foreach (Control control in popupRuleActions.PopupControl.Controls)
            {
                var checkEdit = control as CheckEdit;
                if (checkEdit == null) continue;
                if (checkEdit.Tag == null) continue;
                if (checkEdit.Checked)
                {
                    idsActions.Add(Convert.ToInt64(checkEdit.Tag));
                }
            }

            //выставляем действия правилу
            //поскольку состав действий для правила может измениться, то удалим аргументы и соберём их заново
            var rows =
                    (FlexibleFormsDS.RuleParameterForActionRow[])
                    MainDbService.MainDataSet.RuleParameterForAction.Select(
                    DataHelper.Filter("idfsRule", rowRules.idfsRule, "idfsParameter", rowParameterTemplate.idfsParameter));
            foreach (var row in rows)
            {
                row.Delete();
            }

            //выставляем новый перечень действий
            for (int i = 0; i < idsActions.Count; i++)
            {
                #region Создаём новую строку

                var rowParameterForAction = MainDbService.MainDataSet.RuleParameterForAction.NewRuleParameterForActionRow();
                rowParameterForAction.idfsFormTemplate = rowRules.idfsFormTemplate;
                rowParameterForAction.idfsRule = rowRules.idfsRule;
                rowParameterForAction.idfsParameter = rowParameterTemplate.idfsParameter;
                rowParameterForAction.idfsRuleAction = idsActions[i];
                MainDbService.MainDataSet.RuleParameterForAction.AddRuleParameterForActionRow(rowParameterForAction);

                #endregion
            }

            #region Обновление данных о выбранных правилах

            if (treeRuleActionParameters.Nodes.Count > 0)
            {
                var templateNode = treeRuleActionParameters.Nodes.FirstNode;
                var node = templateNode.GetNodeMatch(rowParameterTemplate);
                if (node != null) node[tlcAction] = MainDbService.GetRuleActionsText(rowRules, rowParameterTemplate);
            }

            #endregion

            rowRules.ActionText = String.Format("{0}{1}", MainDbService.MainDataSet.RuleParameterForAction.Select(DataHelper.Filter("idfsRule", rowRules.idfsRule)).Length, EidssMessages.Get("actions"));
        }




        /// <summary>
        /// Открытие окна ввода действий для правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupRuleActionsPopup(object sender, EventArgs e)
        {
            //именно такой порядок
            if (treeRuleActionParameters.Parent == null) treeRuleActionParameters.Parent = popupRuleActionParameters;
            //
            RefreshRuleActionParameters();
        }

        /// <summary>
        /// Строит дерево параметров для выбора цели действия в правиле
        /// </summary>
        private void RefreshRuleActionParameters()
        {
            //дерево строим сразу всё, а не динамически
            treeRuleActionParameters.Nodes.Clear();
            //верхним узлом является сам шаблон (потому что мы строим дерево из его содержимого)
            var templatesRow = GetActiveTemplate();
            if (templatesRow == null) return;
            var node = treeRuleActionParameters.AppendNode(null, null, templatesRow);
            node[trlcTreeListParametersColumn] = templatesRow.NationalName;

            //построим все секции и параметры, что на данный момент есть в шаблоне
            treeRuleActionParameters.AppendSectionNodes(MainDbService, node, templatesRow.idfsFormTemplate, null, GetActiveRule());
            treeRuleActionParameters.AppendParameterNodes(MainDbService, node, templatesRow.idfsFormTemplate, null, GetActiveRule());
        }

        /// <summary>
        /// Правый клик на шаблоне
        /// </summary>
        /// <param name="sender"></param>
        void OnTemplateDesignerHostRightClick(object sender)
        {
            //должно быть выбрано активное правило, чтобы можно было добавлять функции
            if (treeRules.Selection.Count == 0)
            {
                //убираем контекстное
                barManagerMain.SetPopupContextMenu((Control)sender, null);
                return;
            }
            //
            if (ReadOnly) return;

            //определим, что выбрано
            int selectedCount = ffRender.TemplateDesignerHost.SelectedParameterHostsCount();

            if ((selectedCount < 1) || (selectedCount > 2)) return;
            //не даём выбирать параметр в таблице
            if (!(ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) is Parameter))
            {
                //убираем контекстное
                barManagerMain.SetPopupContextMenu((Control)sender, null);
                return;
            }
            var parameterTemplateRow1 = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0).GetParameterTemplateRow();
            if (parameterTemplateRow1 == null) return;
            FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow2 = null;

            if (selectedCount == 2)
            {
                parameterTemplateRow2 = ffRender.TemplateDesignerHost.GetSelectedParameterHost(1).GetParameterTemplateRow();
                if (parameterTemplateRow2 == null) return;
                //проверим, чтобы параметры были одного типа данных
                if (parameterTemplateRow1.idfsEditor != parameterTemplateRow2.idfsEditor)
                {
                    //скроем все элементы списка
                    //TODO надо как-то уйти от фиксированного количества
                    for (var i = 0; i < 5; i++)
                    {
                        barManagerMain.Items[String.Format("btnRuleFunction{0}", i + 1)].Visibility = BarItemVisibility.Never;
                    }
                    return;
                }
            }
            //получаем доступные виды функций
            MainDbService.LoadRuleFunctions(selectedCount);
            barManagerMain.SetPopupContextMenu((Control)sender, popupRules);
            //TODO нужно придумать более элегантный способ с динамическими элементами
            for (int i = 0; i < MainDbService.MainDataSet.RuleFunctions.Count; i++)
            {
                var row = MainDbService.MainDataSet.RuleFunctions[i];
                //если параметр не имеет тип Дата, то ему не доступно правило про сравнение с текущей датой
                if (row.idfsRuleFunction.Equals((long)FFRuleFunctions.CurrentDate))
                {
                    if (!parameterTemplateRow1.idfsParameterType.Equals((long)FFParameterTypes.Date) && !parameterTemplateRow1.idfsParameterType.Equals((long)FFParameterTypes.DateTime))
                    {
                        barManagerMain.Items[String.Format("btnRuleFunction{0}", i + 1)].Visibility = BarItemVisibility.Never;
                        continue;
                    }
                }

                //проверим наличие такого элемента в коллекции кнопок меню
                var buttonItem = (BarButtonItem)popupRules.LinksPersistInfo[i].Item;
                //buttonItem.Caption = String.Format(row.strMask, parameterTemplateRow1.NationalName, null);
                buttonItem.Caption = String.Format(row.strMaskNational, parameterTemplateRow1.NationalName, null);
                //поставим ему в тэг "id правила;параметр1;параметр2"
                var tag = new StringBuilder(String.Format("{0};{1};", row.idfsRuleFunction, parameterTemplateRow1.idfsParameter));
                if (parameterTemplateRow2 != null)
                {
                    buttonItem.Caption = String.Format(row.strMaskNational, parameterTemplateRow1.NationalName, parameterTemplateRow2.NationalName);
                    tag.Append(parameterTemplateRow2.idfsParameter);
                }
                buttonItem.Tag = tag;
                //покажем этот элемент списка
                barManagerMain.Items[String.Format("btnRuleFunction{0}", i + 1)].Visibility = BarItemVisibility.Always;
            }
            for (int i = MainDbService.MainDataSet.RuleFunctions.Count; i < 5; i++)
            {
                barManagerMain.Items[String.Format("btnRuleFunction{0}", i + 1)].Visibility = BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Обработка изменения значения в одной из табличных секций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFlexibleFormEditorEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (EditValueChanging != null) EditValueChanging(sender, e);
        }

        public delegate void EditValueChangingDelegate(object sender, ChangingEventArgs e);

        /// <summary>
        /// Событие срабатывает, когда меняется значение в управляющего контрола одного из обычных параметров
        /// </summary>
        public event EditValueChangingDelegate EditValueChanging;

        public delegate void EditValueChangedDelegate(object sender, EventArgs e);

        /// <summary>
        /// Событие срабатывает, когда  значение в ячейке изменилось
        /// </summary>
        public event EditValueChangedDelegate EditValueChanged;

        /// <summary>
        /// Когда размер лейбла изменился
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLabelSizeChanged(object sender, EventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var label = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Label;
            if (label == null) return;

            var labelsRow = ((FlexibleFormsDS.LabelsRow)label.Tag);
            //надо именно так, иначе не срабатывает обновление
            propTemplateLabel.SelectedObject = null;
            propTemplateLabel.SelectedObject = labelsRow;
        }

        /// <summary>
        /// Когда лейбл выбран на шаблоне
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnLabelSelect(ParameterHost parameterHost)
        {
            var label = (Label)parameterHost;
            var labelsRow = (FlexibleFormsDS.LabelsRow)label.Tag;
            if (labelsRow.IsColorNull()) labelsRow.Color = Color.FromArgb(labelsRow.intColor);
            //скрываем кнопку, поскольку она не должна быть доступна при выделении этого объекта
            btnFit.Enabled = false;
            //визуализация строки
            propTemplateLabel.SelectedObject = null;
            propTemplateLabel.SelectedObject = labelsRow;

            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateLabel;
        }

        /// <summary>
        /// Изменение размеров линии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLineSizeChanged(object sender, EventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var line = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Line;
            if (line == null) return;

            var linesRow = ((FlexibleFormsDS.LinesRow)line.Tag);
            //надо именно так, иначе не срабатывает обновление
            propTemplateLine.SelectedObject = null;
            propTemplateLine.SelectedObject = linesRow;
        }

        /// <summary>
        /// Когда выбрана линия на рабочем столе шаблонов
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnLineSelect(ParameterHost parameterHost)
        {
            var line = (Line)parameterHost;
            var linesRow = (FlexibleFormsDS.LinesRow)line.Tag;
            if (linesRow.IsColorNull()) linesRow.Color = Color.FromArgb(linesRow.intColor);
            if (linesRow.IsintOrientationNull())
            {
                if (linesRow.IsblnOrientationNull()) linesRow.intOrientation = -1;
                else linesRow.intOrientation = linesRow.blnOrientation ? 1 : 0;
            }
            //скрываем кнопку, поскольку она не должна быть доступна при выделении этого объекта
            btnFit.Enabled = false;

            linesRow.Color = Color.FromArgb(linesRow.intColor);

            //визуализация строки
            propTemplateLine.SelectedObject = null;
            propTemplateLine.SelectedObject = linesRow;

            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateLine;
        }

        /// <summary>
        /// Клик по форме, которая является хост-контейнером для шаблона
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void OnTemplateMouseDown(object sender, MouseEventArgs e)
        {
            //если не выбран активный шаблон, то выходим
            FlexibleFormsDS.TemplatesRow rowTemplate = GetActiveTemplate();
            if (rowTemplate == null) return;

            //определяем доступность кнопок
            List<ParameterHost> list = ffRender.TemplateDesignerHost.GetSelectedParameterHosts();
            btnFit.Enabled = ((list.Count == 0) ||
                              ((list.Count == 1)
                              && (list[0].Tag is FlexibleFormsDS.SectionTemplateRow)
                              && (!((FlexibleFormsDS.SectionTemplateRow)list[0].Tag).blnGrid)));

            //если не выбран объект из библиотеки параметров, то выходим
            if (SelectedObjectInParametersLibrary == null) return;
            //
            if (ReadOnly) return;

            //в шаблон нельзя добавлять и удалять параметры и секции, если у него уже есть observation
            if (MainDbService.HasObservationsForTemplate(rowTemplate.idfsFormTemplate))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("AddInTemplate_Template_Has_Observations"));
                return;
            }

            #region Если это секция

            if (SelectedObjectInParametersLibrary is FlexibleFormsDS.SectionsRow)
            {
                var sectionRow = (FlexibleFormsDS.SectionsRow)SelectedObjectInParametersLibrary;
                //проверим, не явлется ли этот объект критическим
                if (ffRender.CriticalObjects.Sections.ContainsKey(sectionRow.idfsSection))
                {
                    var co = ffRender.CriticalObjects.Sections[sectionRow.idfsSection];
                    if (!co.CanAddToTemplate)
                    {
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantAddCriticalObjectToTemplate"));
                        return;
                    }
                }

                //определяем, не является ли эта секция или её родитель только что добавленными. Несохранённые секции и параметры нельзя добавлять в шаблон.
                if (MainDbService.CheckSectionForNew(sectionRow))
                {
                    //предложим сохранить данные
                    bool result = WinUtils.ConfirmMessage(EidssMessages.Get("AddSectionInTemplate_Cant_Add_Unsaved_Section"), String.Empty);
                    if (!result) return;
                    result = Post();
                    if (!(result && (m_PromptResult == DialogResult.Yes))) return;
                }
                //определяем, не добавлена ли уже эта секция
                if (ffRender.SectionAlreadyAdded(sectionRow.idfsSection)) return;
                ffRender.CreateSectionInTemplateHost(sectionRow, e.Location, rowTemplate.idfsFormTemplate);
            }

            #endregion

            #region Если это параметр

            else if (SelectedObjectInParametersLibrary is FlexibleFormsDS.ParametersRow)
            {
                var rowParameter = (FlexibleFormsDS.ParametersRow)SelectedObjectInParametersLibrary;
                //проверим, не явлется ли этот объект критическим
                if (ffRender.CriticalObjects.Parameters.ContainsKey(rowParameter.idfsParameter))
                {
                    var co = ffRender.CriticalObjects.Parameters[rowParameter.idfsParameter];
                    if (!co.CanAddToTemplate)
                    {
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantAddCriticalObjectToTemplate"));
                        return;
                    }
                }
                //определяем, не является ли этот параметр или его родитель только что добавленными. Несохранённые секции и параметры нельзя добавлять в шаблон.
                if (MainDbService.CheckParameterForNew(rowParameter))
                {
                    bool result = WinUtils.ConfirmMessage(EidssMessages.Get("AddParameterInTemplate_Cant_Add_Unsaved_Parameter"), String.Empty);
                    if (!result) return;
                    result = Post();
                    if (!(result && (m_PromptResult == DialogResult.Yes))) return;
                }
                //определяем, не добавлен ли уже этот параметр
                if (ffRender.ParameterAlreadyAdded(rowParameter.idfsParameter)) return;
                ffRender.CreateParameterInTemplateHost(rowParameter, e.Location, rowTemplate.idfsFormTemplate, false);
            }

            #endregion

            //обнулим выбранный объект, чтобы избежать копирования параметров при серии кликов
            SelectedObjectInParametersLibrary = null;
            //кликнем по дереву параметров, чтобы синхронизировать с изменениями
            OnTreeParametersClick(sender, null);
        }

        /// <summary>
        /// Срабатывает, когда компонент более не выбран
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnParameterHostOnUnSelect(ParameterHost parameterHost)
        {
            tbcTemplateComponentsProperties.SelectedTabPage = null; //ничего не выбрано
        }

        /// <summary>
        /// Изменение размеров выбранного параметра-контрола на рабочем столе шаблонов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnParameterSizeChanged(object sender, EventArgs e)
        {
            //определяем какой параметр выбран
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var parameter = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Parameter;
            if (parameter == null) return;
            if (parameter.NowLoading) return;

            var rowParameterTemplate = ((FlexibleFormsDS.ParameterTemplateRow)parameter.Tag);
            //надо именно так, иначе не срабатывает обновление
            propTemplateParameter.SelectedObject = null;
            propTemplateParameter.SelectedObject = rowParameterTemplate;
        }

        /// <summary>
        /// Изменение размеров выбранной секции-контрола на рабочем столе шаблонов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSectionSizeChanged(object sender, EventArgs e)
        {
            //определяем какой параметр выбран
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var section = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Section;
            if (section == null) return;
            if (section.NowLoading) return;

            var rowSectionTemplate = ((FlexibleFormsDS.SectionTemplateRow)section.Tag);
            //надо именно так, иначе не срабатывает обновление
            propTemplateSection.SelectedObject = null;
            propTemplateSection.SelectedObject = rowSectionTemplate;
        }

        /// <summary>
        /// Выбран какой-то параметр (в виде контрола) на рабочем столе шаблонов
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnParameterSelect(ParameterHost parameterHost)
        {
            if (parameterHost.NowLoading) return;
            var parameter = parameterHost as Parameter;
            if (parameter == null) return;

            //скрываем кнопку, поскольку она не должна быть доступна при выделении этого объекта
            btnFit.Enabled = false;

            //визуализация строки
            propTemplateParameter.SelectedObject = null;
            propTemplateParameter.SelectedObject = parameter.Tag;

            erTemplateParameterEditMode.Visible = parameter.Editor != FFParameterEditors.CheckBox;

            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateParameter;
        }

        /// <summary>
        /// Выбрана какая-то секция (в виде контрола) на рабочем столе шаблонов
        /// </summary>
        /// <param name="parameterHost"></param>
        void OnSectionSelect(ParameterHost parameterHost)
        {
            if (parameterHost.NowLoading) return;
            var section = parameterHost as Section;
            if (section == null) return;
            //визуализация строки
            propTemplateSection.SelectedObject = section.Tag;

            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateSection;
        }

        /// <summary>
        /// Регистрация модуля редактора
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category, "MenuCustomForms", 1005, false, (int)eidss.model.Enums.MenuIconsSmall.FFDesigner)
                                {
                                    SelectPermission =
                                        PermissionHelper.SelectPermission(
                                            eidss.model.Enums.EIDSSPermissionObject.FlexibleForm)
                                };
        }

        /// <summary>
        /// Запуск редактора
        /// </summary>
        public static void ShowMe()
        {
            BaseFormManager.ShowNormal(new FlexibleFormEditor(), null);
        }

        /// <summary>
        /// Запуск редактора
        /// </summary>
        /// <param name="ff"></param>
        public static void ShowMe(FlexibleFormEditor ff)
        {
            object id = null;
            BaseFormManager.ShowClient(ff, BaseFormManager.MainForm, ref id);
        }

        /// <summary>
        /// Определяет список доступных действий для правил
        /// </summary>
        private void BindingRuleActions()
        {
            var popup = new PopupContainerControl();
            popupRuleActions.PopupControl = popup;
            var dv = LookupCache.Get(BaseReferenceType.rftFFRuleAction);
            popup.Controls.Clear();
            var popupHeight = 0;
            var popupWidth = 0;
            foreach (DataRowView row in dv)
            {
                var idfsReference = long.Parse(row["idfsReference"].ToString());
                if (idfsReference <= 0) continue;
                var checkEdit = new CheckEdit
                                    {
                                        Text = row["Name"].ToString(),
                                        Checked = false,
                                        Tag = Convert.ToInt64(row["idfsReference"]),
                                        Top = popupHeight
                                    };
                checkEdit.Width = checkEdit.CalcBestSize().Width;
                if (checkEdit.Width > popupWidth)
                {
                    popupWidth = checkEdit.Width;
                }
                popupHeight += checkEdit.Height;

                popup.Controls.Add(checkEdit);
            }
            popup.AutoScroll = true;
            popup.AutoScrollMinSize = new Size(popupWidth, popupHeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableLanguages"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        private DataRow CreateRowForLang(DataTable tableLanguages, string lang)
        {
            var row = tableLanguages.NewRow();
            row["ID"] = lang;
            row["Name"] = bv.common.Core.Localizer.GetMenuLanguageName(lang);
            return row;
        }

        /// <summary>
        /// Размещаем данные
        /// </summary>
        protected override void DefineBinding()
        {
            base.DefineBinding();

            //настройка выбора HACode в меню Параметр
            popupHACodeParameter.BindReprositoryHACodeLookup(MainDbService.LoadHACodeList());
            popupHACodeParameter.QueryResultValue += OnPopupHACodeParameterQueryResultValue;
            BindingRuleActions();

            //Загружаем типы форм в дерево
            LoadFormTypes();

            #region Инициализация данных
            //наполняем список ParameterTypeReference
            rleParameterTypeReferenceEditor.DataSource = LookupCache.Get(LookupTables.ParameterTypeReferenceEditor);
            //rleParameterTypeReferenceEditor.EditValueChanged += OnChangeParameterType;
            rleParameterTypeReferenceEditor.Closed += OnChangeParameterType;
            rleParameterTypeReferenceEditor.ButtonClick += OnRleParameterTypeReferenceEditorButtonClick;

            //наполняем список контролов для Editor параметров
            MainDbService.LoadParameterEditors();
            leParameterControlType.DataSource = MainDbService.MainDataSet.ParameterEditors;
            leParameterControlType.Closed += OnLeParameterControlTypeClosed;
            icbSectionType.EditValueChanged += OnSectionTypeChanged;

            #region Помещаем информацию о перечне языков, поддерживаемых системой

            //Localizer.SupportedLanguages
            LanguageTemplate = bv.common.Core.Localizer.lngEn;

            var tableLanguages = new DataTable();
            tableLanguages.Columns.Add("ID", typeof(string));
            tableLanguages.Columns.Add("Name", typeof(string));
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                DataRow row = null;

                switch (lang.Culture.TwoLetterISOLanguageName)
                {
                    case "uz":
                        row = CreateRowForLang(tableLanguages, lang.Culture.Name.IndexOf("Cyrl") > 0 ? bv.common.Core.Localizer.lngUzCyr : bv.common.Core.Localizer.lngUzLat);
                        break;
                    case "az":
                        row = CreateRowForLang(tableLanguages, bv.common.Core.Localizer.lngAzLat);
                        break;
                    case "en":
                    case "ru":
                    case "ka":
                    case "kk":
                    case "hy":
                    case "uk":
                        row = CreateRowForLang(tableLanguages, lang.Culture.TwoLetterISOLanguageName);
                        break;
                }

                if (row != null)
                    tableLanguages.Rows.Add(row);
            }

            leTemplateLanguage.DataSource = tableLanguages;
            leTemplateLanguage.ButtonPressed += OnLeTemplateLanguageButtonPressed;
            //выставляем тот язык, с которым стартует система
            miTemplateLanguage.EditValue = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            leTemplateLanguage.Buttons[1].Visible = false;

            #endregion

            #endregion
        }

        /// <summary>
        /// В таблице редактирования свойств параметра редактирование типов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnRleParameterTypeReferenceEditorButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var form = new FFParameterTypesEditor();
                BaseFormManager.ShowModal(form, FindForm());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupHACodeParameterQueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            if ((parEditingParameter.ParametersRow == null) || (e.Value == null)) return;
            parEditingParameter.ParametersRow.intHACode = Convert.ToInt32(e.Value);
            parEditingParameter.RefreshSelectListInControl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLeParameterControlTypeClosed(object sender, ClosedEventArgs e)
        {
            propParameter.PostEditor();
        }

        /// <summary>
        /// Нажатие кнопок в контроле выбора языка для отображения шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLeTemplateLanguageButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (treeTemplates.Selection.Count == 0) return;
            if (Utils.IsEmpty(miTemplateLanguage.EditValue)) return;
            var template = GetActiveTemplate();
            if (template == null) return;
            //выполнить добавление и удаление языковых надстроек можно для любых языков, кроме английского
            if (miTemplateLanguage.EditValue.Equals(bv.common.Core.Localizer.lngEn)) return;

            var langid = miTemplateLanguage.EditValue.ToString();

            switch (e.Button.Kind)
            {
                case ButtonPredefines.Undo:
                    //если для выбранного языка нет надстройки, то выходим
                    if (!HasLanguageTemplate(template.idfsFormTemplate, langid)) return;

                    /*
                    //удаляем связанные секции
                    MainDbService.DeleteSectionTemplate(template.idfsFormTemplate, langid);
                    //удаляем связанные параметры
                    MainDbService.DeleteParameterTemplate(template.idfsFormTemplate, langid);
                    //удаляем связанные лейблы
                    MainDbService.DeleteLabelTemplate(template.idfsFormTemplate, langid);
                    //удаляем связанные линии
                    MainDbService.DeleteLineTemplate(template.idfsFormTemplate, langid);
                    */

                    //теперь не будем удалять слой, а будем прописывать туда значения из Английского слоя
                    CopyHelper.RestoreLanguageLayout(MainDbService
                        , template.idfsFormTemplate
                        , langid);

                    //переключаем язык на английский
                    //miTemplateLanguage.EditValue = bv.common.Core.Localizer.lngEn;
                    OnTreeTemplatesClick(sender, EventArgs.Empty);

                    break;
            }
        }

        /// <summary>
        /// Сменился тип секции (обычная или табличная)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSectionTypeChanged(object sender, EventArgs e)
        {
            //проходим по ей и её дочерним секциям, меняя и их тип
            var isGrid = Convert.ToBoolean(((ImageComboBoxEdit)sender).EditValue);
            var node = treeParameters.Selection[0];
            if (isGrid)
                // ReSharper disable ConditionIsAlwaysTrueOrFalse
                SetSectionType(node, isGrid);
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
            else
                // ReSharper disable ConditionIsAlwaysTrueOrFalse
                SetImageForSectionType(isGrid, node);
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);
        }

        /// <summary>
        /// Накладывает фильтр 
        /// </summary>
        /// <param name="idEditor"></param>
        private void SetFilterControlTypeEditors(long idEditor)
        {
            string filter;
            if (!Utils.IsEmpty(idEditor))
            {
                switch (idEditor)
                {
                    case (long)FFParameterTypes.Boolean/*"parBoolean"*/:
                        filter = "idfsEditor=10067001";//'editCheck'
                        break;
                    case (long)FFParameterTypes.Numeric/*"fptNumeric"*/:
                    case (long)FFParameterTypes.NumericNatural:
                    case (long)FFParameterTypes.NumericPositive:
                    case (long)FFParameterTypes.NumericInteger:
                        filter = "idfsEditor=10067008 or idfsEditor=10067009";//'editText''editUpDown'
                        break;
                    case (long)FFParameterTypes.String/*"parString"*/:
                        filter = "idfsEditor=10067008 or idfsEditor=10067006";//'editText''editMemo'
                        break;
                    case (long)FFParameterTypes.DateTime /*"parDatetime"*/:
                        filter = "idfsEditor=10067004";//'editDateTime'
                        break;
                    case (long)FFParameterTypes.Date /*"parDate"*/:
                        filter = "idfsEditor=10067003";//'editDate'
                        break;
                    default:
                        filter = "idfsEditor=10067002";//'editCombo'
                        break;
                }
            }
            else
            {
                //это когда из BaseReference и rftParametersFixedPresetValue
                filter = "idfsEditor=10067002";//'editCombo'
            }

            if (filter.Length == 0) return;
            var editors = (FlexibleFormsDS.ParameterEditorsRow[])MainDbService.MainDataSet.ParameterEditors.Select(filter);
            leParameterControlType.DataSource = editors;

            //тот узел параметра, который выбран в дереве
            var rowParameter = (FlexibleFormsDS.ParametersRow)treeParameters.Selection[0].Tag;
            //принудительно выставим новое значение, ибо выставление фильтра его сбивает
            rowParameter.idfsParameterType = idEditor;
            //если среди новых значений фильтра есть то, что уже было у параметра, то выберем его
            //если нет такого значения, то выберем первое попавшееся

            if (editors.Length == 0) return;

            var finded = false;
            foreach (var row in editors)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                if (!row["idfsEditor"].Equals(rowParameter.idfsEditor)) continue;
                finded = true;
                break;
            }
            rowParameter.idfsEditor = finded ? rowParameter.idfsEditor : Convert.ToInt64(editors[0].idfsEditor);
            parEditingParameter.Editor = ParameterControlTypeHelper.ConvertToParameterControlType(rowParameter.idfsEditor);
            propParameter.SelectedObject = null;
            propParameter.SelectedObject = rowParameter;
        }

        /// <summary>
        /// Смена типа параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnChangeParameterType(object sender, EventArgs e)
        {
            propParameter.PostEditor();
            var leSender = (sender as LookUpEdit);
            if (leSender == null) return;

            //определяем тип
            SetFilterControlTypeEditors(Convert.ToInt64(leSender.EditValue));
        }

        /// <summary>
        /// Выбранный объект в библиотеке параметров
        /// (по сути строка-секция или строка-параметр)
        /// </summary>
        private object SelectedObjectInParametersLibrary { get; set; }

        /// <summary>
        /// Заново получает типы форм из БД и размещает их в деревья
        /// </summary>
        public void LoadFormTypes()
        {
            //переполучаем данные по типам форм
            MainDbService.LoadFormTypes();
            //размещаем их сразу в несколько деревьев
            treeParameters.ClearNodes();
            treeTemplates.ClearNodes();
            foreach (FlexibleFormsDS.FormTypesRow row in MainDbService.MainDataSet.FormTypes.Rows)
            {
                if (!row.IsRowAlive()) continue;
                AppendFormTypeNode(treeParameters, row, true);
                AppendFormTypeNode(treeTemplates, row, false);
            }
        }

        /// <summary>
        /// Вспомогательный метод добавления узла типа формы в дерево
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="row"></param>
        /// <param name="isParameterTree"></param>
        public void AppendFormTypeNode(TreeList tree, FlexibleFormsDS.FormTypesRow row, bool isParameterTree)
        {
            var node = tree.AppendNode(null, null, row);
            node[trlcTreeListParametersColumn] = row.Name;
            node.ImageIndex = node.SelectImageIndex = 0;
            //если у типа формы есть секции или параметры, то сделаем там фиктивные узлы
            //поскольку этот метод вызывается в самом начале работы программы, то здесь допустимо использовать эти значения
            if (isParameterTree)
            {
                if (row.HasNestedSections || row.HasParameters)
                {
                    var nodeEmpty = tree.AppendNode(null, node, StrEmptyKey);
                    nodeEmpty[trlcTreeListParametersColumn] = StrEmpty;
                    node.Expanded = false;
                }
            }
            else
            {
                if (row.HasTemplates)
                {
                    var nodeEmpty = tree.AppendNode(null, node, StrEmptyKey);
                    nodeEmpty[trlcTreeListParametersColumn] = StrEmpty;
                    node.Expanded = false;
                }
            }
        }

        /// <summary>
        /// Возвращает полный путь к ноду в дереве
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetFullPathForNode(TreeListNode node)
        {
            return CollectPath(node, new StringBuilder());
        }

        /// <summary>
        /// Рекурсивная функция для сбора пути до узла
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sbPath"></param>
        /// <returns></returns>
        private string CollectPath(TreeListNode node, StringBuilder sbPath)
        {
            sbPath.Insert(0, node[trlcTreeListParametersColumn].ToString(), 1);
            return node.ParentNode != null ? CollectPath(node.ParentNode, sbPath.Insert(0, delimiterPath, 1)) : sbPath.ToString();
        }


        /// <summary>
        /// Ссылка на датасет для Flexible Forms
        /// </summary>
        private DbService MainDbService { get { return (DbService)DbService; } }

        /// <summary>
        /// Развёртывание узла дерева параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersBeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            var parentTree = (TreeList)sender;
            var parentNode = e.Node;
            var parentObject = e.Node.Tag;
            //если у узла уже загружены дочерние узлы, то повторно их не перегружаем
            if ((parentNode.FirstNode != null) && (!parentNode.FirstNode.Tag.Equals(StrEmptyKey))) return;

            //развёртываться может либо тип формы, либо секция
            //параметр не может содержать вложенные узлы
            Cursor = Cursors.WaitCursor;

            //если строится дерево параметров для использования в шаблоне, то будет использовать только кэшированные записи
            var useCache = (parentTree == treeParametersLibrary);

            //если раскрывается тип формы
            if (parentObject is FlexibleFormsDS.FormTypesRow)
            {
                #region загрузка содержимого

                //догрузим секции, относящиеся к этому типу форм
                var row = (FlexibleFormsDS.FormTypesRow)parentObject;

                if (!useCache)
                {
                    //осуществляем дозагрузку секций
                    MainDbService.LoadSections(row.idfsFormType, null, null);
                    //осуществляем дозагрузку параметров
                    //берем только те, что не относятся к какой-либо секции, а только к типу формы
                    MainDbService.LoadParameters(row.idfsFormType, null);
                }

                //посмотрим, что по нему нужно грузить, а что нет
                if (MainDbService.HasNestedSections(row.idfsFormType))
                {
                    //размещаем секции в дереве
                    MainDbService.AppendSectionNodes(parentTree, parentNode, MainDbService.GetSectionsByFormType(row.idfsFormType), useCache, true);
                }
                if (MainDbService.HasNestedParameters(row.idfsFormType))
                {
                    //размещаем параметры в дереве (помещаем только те, которые относятся к типу формы, но не имеют никакой секции)
                    parentTree.AppendParameterNodes(parentNode, MainDbService.GetParametersByFormType(row.idfsFormType), false);
                }

                #endregion
            }

            //если раскрывается секция
            if (parentObject is FlexibleFormsDS.SectionsRow)
            {
                #region загрузка содержимого

                //догрузим секции, для которых эта секция является родительской
                var row = (FlexibleFormsDS.SectionsRow)parentObject;

                if (!useCache)
                {
                    //осуществляем дозагрузку секций
                    MainDbService.LoadSections(row.idfsFormType, null, row.idfsSection);
                    //осуществляем дозагрузку параметров
                    //берем только те, что не относятся к какой-либо секции, а только к типу формы
                    MainDbService.LoadParameters(row.idfsFormType, row.idfsSection);
                }

                if (MainDbService.HasNestedSections(row))
                {
                    //размещаем секции в дереве
                    MainDbService.AppendSectionNodes(parentTree, parentNode, MainDbService.GetSectionChildrenRows(row.idfsSection), useCache, true);
                }
                if (MainDbService.HasNestedParameters(row))
                {

                    //размещаем секции в дереве
                    parentTree.AppendParameterNodes(parentNode, (FlexibleFormsDS.ParametersRow[])MainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsSection", row.idfsSection)), false);

                }

                #endregion
            }

            Cursor = Cursors.Default;
        }

        private const int IndexSectionDefaultImage = 1;
        private const int IndexSectionTableImage = 6;

        /// <summary>
        /// Проставляет иконку типу секции
        /// </summary>
        /// <param name="isTable"></param>
        /// <param name="node"></param>
        private static void SetImageForSectionType(bool isTable, TreeListNode node)
        {
            node.ImageIndex = isTable
                                  ? (node.SelectImageIndex = IndexSectionTableImage)
                                  : (node.SelectImageIndex = IndexSectionDefaultImage);
        }

        /// <summary>
        /// Смена размеров редактируемого Параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnParEditingParameterSizeChanged(object sender, EventArgs e)
        {
            if ((treeParameters.Selection.Count > 0) && (treeParameters.Selection[0].Tag is FlexibleFormsDS.ParametersRow))
            {
                var rowParameter = ((FlexibleFormsDS.ParametersRow)treeParameters.Selection[0].Tag);
                rowParameter.intWidth = parEditingParameter.Width;
                rowParameter.intHeight = parEditingParameter.Height;
                //в зависимости от схемы параметра применим величину текста
                rowParameter.intLabelSize = parEditingParameter.LabelSize;
                //надо именно так, иначе не срабатывает обновление
                propParameter.SelectedObject = null;
                propParameter.SelectedObject = rowParameter;
            }
        }

        /// <summary>
        /// Визуальное представление параметра, которое сейчас редактируется
        /// </summary>
        private Parameter parEditingParameter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool HasChanges()
        {
            //return true;//MainDbService.MainDataSet.HasChanges();
            return ((InsertPermission || UpdatePermission || DeletePermission)
                    && ((MainDbService.MainDataSet.Sections.GetChanges() != null) ||
                    (MainDbService.MainDataSet.Parameters.GetChanges() != null) ||
                    (MainDbService.MainDataSet.Templates.GetChanges() != null) ||
                    (MainDbService.MainDataSet.SectionTemplate.GetChanges() != null) ||
                    (MainDbService.MainDataSet.ParameterTemplate.GetChanges() != null) ||
                    (MainDbService.MainDataSet.Rules.GetChanges() != null) ||
                    (MainDbService.MainDataSet.RuleParameterForFunction.GetChanges() != null) ||
                    (MainDbService.MainDataSet.RuleConstant.GetChanges() != null) ||
                    (MainDbService.MainDataSet.RuleParameterForAction.GetChanges() != null) ||
                    (MainDbService.MainDataSet.Lines.GetChanges() != null) ||
                    (MainDbService.MainDataSet.TemplateDeterminantValues.GetChanges() != null) ||
                    (MainDbService.MainDataSet.Labels.GetChanges() != null)
                    )
                    );
        }

        /// <summary>
        /// Изменение одного из значений Свойств Секции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropSectionCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (!(e.Row.Equals(erSectionNationalName) || e.Row.Equals(erSectionName))) return;
            if ((treeParameters.Selection.Count > 0) && (treeParameters.Selection[0].Tag is FlexibleFormsDS.SectionsRow))
            {
                var treeNode = treeParameters.Selection[0];
                if (e.Row.Equals(erSectionNationalName))
                {
                    treeNode[trlcTreeListParametersColumn] = e.Value;
                }
                //обновляем полный путь
                var rowSection = (FlexibleFormsDS.SectionsRow)treeNode.Tag;
                //если дефолтное имя не задано
                if (rowSection.IsDefaultNameNull() || rowSection.DefaultName.Equals(String.Empty))
                {
                    rowSection.DefaultName = DefaultSectionName;
                }
                //если национальное имя не задано, то подставляем дефолтное имя
                if (rowSection.IsNationalNameNull() || rowSection.NationalName.Equals(String.Empty))
                {
                    rowSection.NationalName = rowSection.DefaultName;
                    treeNode[trlcTreeListParametersColumn] = rowSection.NationalName;
                }

                rowSection.FullPath = GetFullPathForNode(treeParameters.Selection[0]);
                propSection.SelectedObject = rowSection;
            }
            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);
        }

        /// <summary>
        /// Разделитель, использующийся при генерации строки, содержащей полный путь к узлу в дереве
        /// </summary>
        private string delimiterPath { get; set; }

        /// <summary>
        /// Ввод в компонент Свойств Параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropParameterCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if ((treeParameters.Selection.Count == 0) || (treeParameters.Selection[0].Tag == null) ||
                (!(treeParameters.Selection[0].Tag is FlexibleFormsDS.ParametersRow))) return;
            var treeListNode = treeParameters.Selection[0];
            var rowParameter = (FlexibleFormsDS.ParametersRow)treeListNode.Tag;
            if (e.Row.Equals(erParameterDefaultName))
            {
                //если дефолтное имя не задано
                if (rowParameter.IsDefaultNameNull() || rowParameter.DefaultName.Equals(String.Empty))
                {
                    rowParameter.DefaultName = DefaultParameterName;
                }
            }
            //смена национального имени
            if (e.Row.Equals(erParameterNationalName))
            {
                rowParameter.NationalName = e.Value.ToString();
                if (rowParameter.IsNationalNameNull() || rowParameter.NationalName.Equals(String.Empty))
                {
                    rowParameter.NationalName = rowParameter.DefaultName;
                }
                //меняем заголовок у активного компонента
                parEditingParameter.Text = rowParameter.NationalName;
                //и заголовок узла
                treeListNode[trlcTreeListParametersColumn] = rowParameter.NationalName;
                //обновляем полный путь
                rowParameter.FullPath = GetFullPathForNode(treeListNode);
            }
            //смена стандартной схемы параметра
            if (e.Row.Equals(erParameterScheme))
            {
                parEditingParameter.Scheme = ParameterSchemeHelper.ConvertToParameterScheme(Convert.ToInt32(e.Value));
                //перерасчитаем размер заголовка
                if (parEditingParameter.ParametersRow != null)
                {
                    parEditingParameter.ParametersRow.intLabelSize = parEditingParameter.LabelSize;
                }
            }
            //смена типа управляющего контрола у параметра
            if (e.Row.Equals(erParameterEditors))
            {
                parEditingParameter.Editor = ParameterControlTypeHelper.ConvertToParameterControlType(Convert.ToInt64(e.Value));
            }
            int val;
            //смена ширины
            if (e.Row.Equals(erParameterWidth))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int width = val;
                    if (width < parEditingParameter.MinimumSize.Width) width = parEditingParameter.MinimumSize.Width;
                    if (width > Parameter.MaxParameterSize.Width) width = Parameter.MaxParameterSize.Width;
                    if (parEditingParameter.ParametersRow != null) parEditingParameter.ParametersRow.intWidth = parEditingParameter.Width = width;
                }
            }
            //смена высоты
            if (e.Row.Equals(erParameterHeight))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int height = val;
                    if (height < parEditingParameter.MinimumSize.Height) height = parEditingParameter.MinimumSize.Height;
                    if (height > Parameter.MaxParameterSize.Height) height = Parameter.MaxParameterSize.Height;
                    if (parEditingParameter.ParametersRow != null) parEditingParameter.ParametersRow.intHeight = parEditingParameter.Height = height;
                }
            }
            //смена ширины текстового поля
            if (e.Row.Equals(erParameterLabelSize))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int labelsize = val;
                    if (labelsize < 1) labelsize = 1;
                    if (parEditingParameter.ParametersRow != null)
                    {
                        if (parEditingParameter.Scheme.IsHorizontalOrientation())
                        {
                            if (labelsize > parEditingParameter.Width) labelsize = parEditingParameter.Width;
                        }
                        else
                        {
                            if (labelsize > parEditingParameter.Height) labelsize = parEditingParameter.Height;
                        }
                    }

                    if (parEditingParameter.ParametersRow != null) parEditingParameter.ParametersRow.intLabelSize = parEditingParameter.LabelSize = labelsize;
                }
            }

            propParameter.SelectedObject = null;
            propParameter.SelectedObject = parEditingParameter.Tag;

            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="formTypesRow"></param>
        public void LoadTemplateNodes(TreeListNode parentNode, FlexibleFormsDS.FormTypesRow formTypesRow)
        {
            //если у узла уже загружены дочерние узлы, то повторно их не перегружаем
            if ((parentNode.FirstNode != null) && (!parentNode.FirstNode.Tag.Equals(StrEmptyKey))) return;

            //развёртываться может либо тип формы, либо секция
            //параметр не может содержать вложенные узлы
            Cursor = Cursors.WaitCursor;

            //если раскрывается тип формы

            #region загрузка содержимого

            //осуществляем дозагрузку шаблонов
            MainDbService.LoadTemplates(formTypesRow.idfsFormType);
            //размещаем шаблоны в дереве
            treeTemplates.AppendTemplatesNodes(parentNode, MainDbService.GetTemplatesByFormType(formTypesRow.idfsFormType));

            #endregion

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Развёртывание узлов дерева шаблонов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeTemplatesBeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (!(e.Node.Tag is FlexibleFormsDS.FormTypesRow)) return;
            var parentNode = e.Node;
            var formTypesRow = (FlexibleFormsDS.FormTypesRow)e.Node.Tag;
            LoadTemplateNodes(parentNode, formTypesRow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        private void RefreshRules(long? idfsFormTemplate)
        {
            treeRules.Nodes.Clear();
            if (idfsFormTemplate.HasValue)
            {
                MainDbService.LoadRulesForTemplate(idfsFormTemplate.Value);
                AppendRuleNodes(treeRules, MainDbService.GetRules(idfsFormTemplate.Value));
            }
        }

        /// <summary>
        /// Добавляет правила в дерево правил
        /// </summary>
        /// <param name="parentTree"></param>
        /// <param name="rows"></param>
        private void AppendRuleNodes(TreeList parentTree, IEnumerable<FlexibleFormsDS.RulesRow> rows)
        {
            foreach (var row in rows)
            {
                if (!row.IsRowAlive()) continue;
                var node = parentTree.AppendNode(row, null, row);
                node.ImageIndex = node.SelectImageIndex = 3;
                node[trlcTreeListParametersColumn] = row.NationalName;
            }
        }

        /// <summary>
        /// Формирует визуальное представление детерминантов шаблона в Свойствах Шаблона
        /// </summary>
        private /*EditorRow*/void RefreshDeterminantsInProp()
        {
            var templatesRow = GetActiveTemplate();
            if (templatesRow == null) return/* null*/;
            /*return*/
            RefreshDeterminantsInProp((FlexibleFormsDS.TemplateDeterminantValuesRow[])MainDbService.MainDataSet.TemplateDeterminantValues.Select(DataHelper.Filter("idfsFormTemplate", templatesRow.idfsFormTemplate)));
        }

        /// <summary>
        /// Формирует визуальное представление детерминантов шаблона в Свойствах Шаблона 
        /// </summary>
        /// <param name="rows"></param>
        private /*EditorRow*/ void RefreshDeterminantsInProp(IEnumerable<FlexibleFormsDS.TemplateDeterminantValuesRow> rows)
        {
            //очищаем строки так, чтобы не трогать фиксированную часть
            propTemplateDeterminant.Rows.Clear();

            //типы детерминантов будут категориями, а строки -- редактируемыми свойствами
            //каждой строке выдадим редактор для ввода значений
            foreach (var row in rows)
            {
                if (!row.IsRowAlive()) continue;

                //категории именуются так: catDeterminantXXX_YYY, где XXX - шаблон, YYY-тип детерминанта
                //принудительное именование свойств (editrow) не нужно
                //каждому свойству в Tag положим его строку

                //получим или создадим категорию, предназначенную для этой строки
                var categoryRow = GetDeterminantCategory(row);
                //если все нормально, то создадим строку и добавим в категорию
                if (categoryRow != null)
                {
                    var editorRow = new EditorRow();
                    editorRow.Properties.Value = row.DeterminantNationalName;
                    editorRow.Properties.ReadOnly = false;
                    editorRow.Tag = row;
                    categoryRow.ChildRows.Add(editorRow);
                }
            }

            /*return editorRow*/
        }

        /// <summary>
        /// Отыскивает среди категорий нужную по имени и возвращает её. Если таковой нет, то создаёт и возвращает.
        /// </summary>
        /// <param name="rowCategory"></param>
        /// <returns></returns>
        private CategoryRow GetDeterminantCategory(FlexibleFormsDS.TemplateDeterminantValuesRow rowCategory)
        {
            CategoryRow result = null;

            string categoryName = String.Format("catDeterminant{0}_{1}", rowCategory.idfsFormTemplate, rowCategory.DeterminantTypeDefaultName);

            foreach (BaseRow row in propTemplateDeterminant.Rows)
            {
                if (row.Name.Equals(categoryName))
                {
                    result = (CategoryRow)row;
                    break;
                }
            }
            //если найти не удалось, то создаём
            if (result == null)
            {
                result = new CategoryRow { Name = categoryName };
                result.Properties.Caption = rowCategory.DeterminantTypeNationalName;
                propTemplateDeterminant.Rows.Add(result);
            }
            return result;
        }

        /// <summary>
        /// Выравниваем ширину таблицы детерминантов шаблона под величину компонента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropTemplateDeterminantsResize(object sender, EventArgs e)
        {
            propTemplateDeterminant.RecordWidth = propTemplateDeterminant.ClientSize.Width;
        }

        /// <summary>
        /// Смена значения в таблице свойств Шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropTemplateCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (treeTemplates.Selection.Count == 0) return;
            var treeNode = treeTemplates.Selection[0];
            var templatesRow = treeNode.Tag as FlexibleFormsDS.TemplatesRow;
            if (templatesRow == null) return;

            //смена национального имени
            if (e.Row.Equals(erTemplateNationalName))
            {
                if (String.IsNullOrEmpty(e.Value.ToString()) && (!templatesRow.IsDefaultNameNull()))
                {
                    templatesRow.NationalName = templatesRow.DefaultName;
                }
            }

            if (templatesRow.IsDefaultNameNull()) templatesRow.DefaultName = DefaultTemplateName;
            if (templatesRow.IsNationalNameNull()) templatesRow.NationalName = nationalTemplateName;

            treeNode[trlcTemplateTreeListColumn] = templatesRow.NationalName.Length > 0
                                                       ? templatesRow.NationalName
                                                       : templatesRow.DefaultName;

            propTemplate.SelectedObject = null;
            propTemplate.SelectedObject = templatesRow;
        }

        /// <summary>
        /// Возвращает строку для конкретных результатов поиска
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static string GetItemsString(int count)
        {
            if (count == 1) return EidssMessages.Get("item");
            return count > 1 ? EidssMessages.Get("items") : String.Empty;
        }

        /// <summary>
        /// Запуск поиска Параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoSearchParameters(object sender, EventArgs e)
        {
            if ((tbSearchParameterCriteria.Text.Length == 0) && (tbSearchSectionCriteria.Text.Length == 0)) return;
            Cursor = Cursors.WaitCursor;

            var parameterCriteria = tbSearchParameterCriteria.Text;
            var sectionCriteria = tbSearchSectionCriteria.Text;

            MainDbService.LoadParametersSearch(parameterCriteria, sectionCriteria);
            lbSearchParameterResults.DataSource = MainDbService.MainDataSet.ParametersSearch;

            int count = MainDbService.MainDataSet.ParametersSearch.Rows.Count;
            lSearchParameterResults.Text = count > 0 ? String.Format(EidssMessages.Get("ResultsFound"), count) : EidssMessages.Get("NoResults");

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Выбор какого-нибудь элемента в списке найденных Параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLbSearchParameterResultsDoubleClick(object sender, EventArgs e)
        {
            if (lbSearchParameterResults.SelectedItem == null) return;
            string path = ((DataRowView)lbSearchParameterResults.SelectedItem).Row["FullPathIdfs"].ToString();
            string[] pathElements = path.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (pathElements.Length < 2) return;
            //первым элементом всегда идёт Form Type (idfsFormTypeID)
            //потом может быть какое-то количество секций idfsSectionID (>=0)
            //последним всегда идёт idfsParameterID

            TreeListNode nodeFormType = null;

            //откроем тип формы
            foreach (TreeListNode node in treeParameters.Nodes)
            {
                var row = (FlexibleFormsDS.FormTypesRow)node.Tag;
                if (row.idfsFormType.Equals(Convert.ToInt64(pathElements[0])))
                {
                    nodeFormType = node;
                    nodeFormType.Expanded = true;
                    break;
                }
            }
            //если не удалось почему-то найти тип формы, выходим
            if (nodeFormType == null) return;

            //если есть какие-то секции, то откроем их
            var nodeParentSection = nodeFormType; //не совсем секция, но он родитель
            for (int i = 1; i < (pathElements.Length - 1); i++)
            {
                foreach (TreeListNode node in nodeParentSection.Nodes)
                {
                    if (!(node.Tag is FlexibleFormsDS.SectionsRow)) continue;
                    var row = (FlexibleFormsDS.SectionsRow)node.Tag;
                    if (row.idfsSection.Equals(Convert.ToInt64(pathElements[i])))
                    {
                        nodeParentSection = node;
                        nodeParentSection.Expanded = true;
                        break;
                    }
                }
            }

            //отыскиваем нод параметра и встаём на него
            //nodeParentSection всегда будет нод родительской секции или типа формы
            foreach (TreeListNode node in nodeParentSection.Nodes)
            {
                if (!(node.Tag is FlexibleFormsDS.ParametersRow)) continue;
                var row = (FlexibleFormsDS.ParametersRow)node.Tag;
                if (row.idfsParameter.Equals(Convert.ToInt64(pathElements[pathElements.Length - 1])))
                {
                    //параметр найден -- встанем на него
                    treeParameters.Selection.Clear();
                    treeParameters.Selection.Add(node);
                    OnTreeParametersClick(treeParameters, null);
                    treeParameters.MakeNodeVisible(node);
                    break;
                }
            }

        }

        /// <summary>
        /// Выставление нового значения подсказки для найденного Параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLbSearchParameterResultsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSearchParameterResults.SelectedItem == null) return;
            var row = ((DataRowView)lbSearchParameterResults.SelectedItem).Row;
            lbSearchParameterResults.ToolTipTitle = row["NationalName"].ToString();
            lbSearchParameterResults.ToolTip = row["NationalLongName"].ToString();
        }

        /// <summary>
        /// Начало перетаскивания в дереве Параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersMouseDown(object sender, MouseEventArgs e)
        {
            dragStartHitInfo = treeParameters.CalcHitInfo(new Point(e.X, e.Y));
        }

        private TreeListHitInfo dragStartHitInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragStartHitInfo != null && dragStartHitInfo.Node != null)
            {
                var dragSize = SystemInformation.DragSize;
                var dragRect = new Rectangle(new Point(dragStartHitInfo.MousePoint.X - dragSize.Width / 2, dragStartHitInfo.MousePoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    var nodeDrag = treeParameters.Selection[0];
                    treeParameters.DoDragDrop(nodeDrag, DragDropEffects.Move);//All);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersDragOver(object sender, DragEventArgs e)
        {
            var hi = treeParameters.CalcHitInfo(treeParameters.PointToClient(new Point(e.X, e.Y)));
            if (hi.HitInfoType == HitInfoType.Empty || hi.Node != null)
            {
                e.Effect = DragDropEffects.Move;// &DragDropEffects.Scroll;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersDragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TreeListNode)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            //нод, который перетаскивается
            var nodeSource = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            var hi = treeParameters.CalcHitInfo(treeParameters.PointToClient(new Point(e.X, e.Y)));
            if ((hi.HitInfoType == HitInfoType.Empty || hi.Node == null)) return;
            //нод, который является целью перетаскивания
            var nodeTarget = hi.Node;
            if ((nodeSource == null) || (nodeSource.Equals(nodeTarget))) return;
            //узел-приемник не может быть дочерним по отношению к узлу-источнику
            if (HelperFunctions.CheckForChildNode(nodeSource, nodeTarget)) return;
            //приёмником может быть только секция или тип формы
            if ((!(nodeTarget.Tag is FlexibleFormsDS.FormTypesRow))
                && (!(nodeTarget.Tag is FlexibleFormsDS.SectionsRow))
                ) return;
            //перетаскиваемый узел нельзя перетаскивать в приёмник, у которого другой тип формы
            var rowSource = (DataRow)nodeSource.Tag;
            var rowTarget = (DataRow)nodeTarget.Tag;
            if (!rowSource["idfsFormType"].Equals(rowTarget["idfsFormType"])) return;

            //нод-приёмник обязательно развернём
            nodeTarget.Expanded = true;
            //в зависимости от источника создаём новый узел
            if (nodeSource.Tag is FlexibleFormsDS.ParametersRow)
            {
                var row = (FlexibleFormsDS.ParametersRow)nodeSource.Tag;
                //если параметр используется в каком-нибудь шаблоне, то нельзя его переносить
                if (MainDbService.IsParameterUsed(row.idfsParameter)) return;
                //проставляем строке новые значения
                if (nodeTarget.Tag is FlexibleFormsDS.FormTypesRow)
                {
                    //это тип формы
                    row.SetidfsSectionNull();
                }
                else
                {
                    //это секция
                    row.idfsSection = ((FlexibleFormsDS.SectionsRow)nodeTarget.Tag).idfsSection;
                }
                //
                nodeSource.ParentNode.Nodes.Remove(nodeSource);
                treeParameters.AppendParameterNodes(nodeTarget, new[] { row }, false);
            }
            if (nodeSource.Tag is FlexibleFormsDS.SectionsRow)
            {
                var row = (FlexibleFormsDS.SectionsRow)nodeSource.Tag;
                //если секция используется в каком-нибудь шаблоне, то нельзя её переносить
                if (MainDbService.IsSectionUsed(row.idfsSection)) return;
                //проставляем строке новые значения
                if (nodeTarget.Tag is FlexibleFormsDS.FormTypesRow)
                {
                    //это тип формы
                    row.idfsFormType = ((FlexibleFormsDS.FormTypesRow)nodeTarget.Tag).idfsFormType;
                    row.SetidfsParentSectionNull();
                }
                else
                {
                    var rowSection = (FlexibleFormsDS.SectionsRow)nodeTarget.Tag;
                    //это секция
                    row.idfsParentSection = rowSection.idfsSection; //TODO потенциальное место ошибки
                    //если родительская секция табличная, то эта и все её потомки тоже должны стать табличными
                    if (rowSection.blnGrid) SetSectionType(nodeSource, rowSection.blnGrid);
                }
                nodeSource.ParentNode.Nodes.Remove(nodeSource);
                MainDbService.AppendSectionNodes(treeParameters, nodeTarget, new[] { row }, true, true);
            }
            //повторим развёртывание ещё раз, если это добавлялся первый параметр
            nodeTarget.Expanded = true;
            //обновим порядок следования узлов
            RefreshOrder(nodeSource);
            //обновим библиотеку параметров
            RefreshParametersLibrary(true);
        }

        /// <summary>
        /// Выставляет секции и всем её дочерним секциям признак того, табличная ли это секция
        /// </summary>
        /// <param name="nodeSection"></param>
        /// <param name="isGrid"></param>
        private static void SetSectionType(TreeListNode nodeSection, bool isGrid)
        {
            var rowSection = (FlexibleFormsDS.SectionsRow)nodeSection.Tag;
            rowSection.blnGrid = isGrid;
            //выставим узлу этой секции правильную пиктограммку
            SetImageForSectionType(isGrid, nodeSection);
            //развернём её потомков
            nodeSection.Expanded = true;
            //каждого потомка-секцию тоже сделаем табличным
            foreach (TreeListNode nodeChild in nodeSection.Nodes)
            {
                if (nodeChild.Tag is FlexibleFormsDS.SectionsRow)
                    SetSectionType(nodeChild, isGrid);
            }
        }

        /// <summary>
        /// Движение Параметра вверх в дереве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnParametersUpOrder(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            TreeListNode nodeSelected = treeParameters.Selection[0];
            if (nodeSelected.Tag is FlexibleFormsDS.FormTypesRow) return;
            if (nodeSelected == nodeSelected.ParentNode.FirstNode) return;
            treeParameters.SetNodeIndex(nodeSelected, nodeSelected.ParentNode.Nodes.IndexOf(nodeSelected.PrevNode));
            RefreshOrder(nodeSelected);
        }

        /// <summary>
        /// У потомков родительского узла проставляет правильный порядок
        /// </summary>
        /// <param name="node"></param>
        private static void RefreshOrder(TreeListNode node)
        {
            if (node.ParentNode == null) return;
            //у каждого дочернего узла правильно проставим intOrder
            for (var i = 0; i < node.ParentNode.Nodes.Count; i++)
            {
                if (node.ParentNode.Nodes[i].Tag is FlexibleFormsDS.SectionsRow)
                {
                    ((FlexibleFormsDS.SectionsRow)node.ParentNode.Nodes[i].Tag).intOrder = i;
                }

                if (node.ParentNode.Nodes[i].Tag is FlexibleFormsDS.ParametersRow)
                {
                    ((FlexibleFormsDS.ParametersRow)node.ParentNode.Nodes[i].Tag).intOrder = i;
                }
            }
        }

        /// <summary>
        /// Движение Параметра вниз в дереве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnParametersDownOrder(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            TreeListNode nodeSelected = treeParameters.Selection[0];
            if (nodeSelected.Tag is FlexibleFormsDS.FormTypesRow) return;
            if (nodeSelected == nodeSelected.ParentNode.LastNode) return;
            treeParameters.SetNodeIndex(nodeSelected, nodeSelected.ParentNode.Nodes.IndexOf(nodeSelected.NextNode));
            RefreshOrder(nodeSelected);
        }

        const string DefaultTemplateName = "New Template";
        const string DefaultRuleName = "New Rule";
        const string DefaultSectionName = "New Section";
        const string DefaultParameterName = "New Parameter";
        const string DefaultLabelName = "New Label";
        string nationalTemplateName { get; set; }
        string nationalRuleName { get; set; }
        string nationalSectionName { get; set; }
        string nationalParameterName { get; set; }
        string nationalLabelName { get; set; }

        /// <summary>
        /// Добавление нового шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddTemplate(object sender, ItemClickEventArgs e)
        {
            //нужно стоять на узле типа формы
            if (treeTemplates.Selection.Count == 0) return;
            if (treeTemplates.Selection[0].Tag == null) return;
            var rowFormType = treeTemplates.Selection[0].Tag as FlexibleFormsDS.FormTypesRow;
            if (rowFormType == null) return;
            treeTemplates.Selection[0].Expanded = true;

            #region Создаём новую строку
            var rowTemplate = MainDbService.MainDataSet.Templates.NewTemplatesRow();
            rowTemplate.idfsFormType = rowFormType.idfsFormType;
            //если это первый шаблон в своём типе формы, то сделаем его UNI
            rowTemplate.blnUNI = (MainDbService.GetTemplatesByFormType(rowFormType.idfsFormType).Length == 0);

            //подсчитаем, сколько шаблонов, с наименованием по умолчанию, уже содержится в таблице
            int count = MainDbService.MainDataSet.Templates.Select(String.Format("[DefaultName] like '{0}%'", DefaultTemplateName)).Length;

            rowTemplate.DefaultName = String.Format("{0}{1}", DefaultTemplateName, count + 1);
            rowTemplate.NationalName = String.Format("{0}{1}", nationalTemplateName, count + 1);

            rowTemplate.NationalLongName = nationalTemplateName;
            rowTemplate.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            MainDbService.MainDataSet.Templates.AddTemplatesRow(rowTemplate);
            #endregion

            //добавляем узел по созданной строке в дерево шаблонов
            var parentNode = treeTemplates.Selection[0];
            treeTemplates.AppendTemplatesNodes(parentNode, new[] { rowTemplate });
            //дефолтный language layout
            miTemplateLanguage.EditValue = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            //встаём на последний узел у этого родителя
            treeTemplates.FocusedNode = parentNode.LastNode;
            OnTreeTemplatesClick(sender, null);
        }

        /// <summary>
        /// Удаление существующего шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDeleteTemplate(object sender, ItemClickEventArgs e)
        {
            //нужно стоять на узле типа формы
            if (treeTemplates.Selection.Count == 0) return;
            if (treeTemplates.Selection[0].Tag == null) return;
            var templatesRow = treeTemplates.Selection[0].Tag as FlexibleFormsDS.TemplatesRow;
            if (templatesRow == null) return;

            #region Проверки

            //проверим, нет ли конфликтов на клиенте
            if (!MainDbService.CanDeleteTemplate(templatesRow))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("TemplateRemove_Has_Observation"));
                return;
            }

            //UNI-шаблон удалять нельзя
            if (templatesRow.blnUNI)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("UNI_template_cantbe_deleted"));
                return;

                #region Прежняя бизнес-логика

                /*
                //получаем все шаблоны этого типа формы
                if (!MainDbService.GetTemplateInFFTypeWithUNICredentionals(templatesRow))
                {
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("TemplateRemove_Must_Have_Another_Template"));
                    return;
                }
                */
                #endregion
            }

            #endregion

            var result = WinUtils.ConfirmMessage(EidssMessages.Get("TemplateDeleteQuestion"), String.Empty);
            if (!result) return;

            ffRender.ClearTemplate();

            //если шаблон помечен для копирования, то снимем эту пометку
            if ((RowCopiedTemplate != null) && (RowCopiedTemplate.idfsFormTemplate.Equals(templatesRow.idfsFormTemplate))) RowCopiedTemplate = null;

            //удаляем его детерминанты
            MainDbService.DeleteDeterminantsFromTemplate(templatesRow.idfsFormTemplate);
            //удаляем связанные секции
            MainDbService.DeleteSectionTemplate(templatesRow.idfsFormTemplate, String.Empty);
            //удаляем связанные параметры
            MainDbService.DeleteParameterTemplate(templatesRow.idfsFormTemplate, String.Empty);
            //удаляем связанные правила
            MainDbService.DeleteRulesFromTemplate(templatesRow.idfsFormTemplate);
            //удаляем связанные лейблы
            MainDbService.DeleteLabelTemplate(templatesRow.idfsFormTemplate, String.Empty);
            //удаляем связанные линии
            MainDbService.DeleteLineTemplate(templatesRow.idfsFormTemplate, String.Empty);

            //удаляем строку
            templatesRow.Delete();
            //удаляем узел
            var nodeParent = treeTemplates.Selection[0].ParentNode;
            nodeParent.Nodes.Remove(treeTemplates.Selection[0]);
            OnTreeTemplatesClick(this, null);
        }

        /// <summary>
        /// Удаление выбранного объекта из шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTemplateRemoveObject(object sender, ItemClickEventArgs e)
        {
            var rowTemplate = GetActiveTemplate();
            if (rowTemplate == null) return;

            //в шаблон нельзя добавлять и удалять, если у него уже есть observation
            if (MainDbService.HasObservationsForTemplate(rowTemplate.idfsFormTemplate))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("DeleteFromTemplate_Template_Has_Observations"));
                return;
            }

            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() == 0) return;

            if (!WinUtils.ConfirmMessage(EidssMessages.Get("TemplateObjectDeleteQuestion"), String.Empty)) return;

            var parameterHost = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0);

            #region Удаление параметров и секций

            //в шаблон нельзя добавлять и удалять параметры и секции, если у него уже есть observation
            //if ((parameterHost is Section) || (parameterHost is SectionTable) || (parameterHost is Parameter))
            if ((parameterHost is Section) || (parameterHost is Parameter))
            {
                //удалим также из списков быстрого доступа
                var parameter = parameterHost as Parameter;
                var section = parameterHost as Section;
                var sectionTable = parameterHost as SectionTable;
                if ((parameter != null) && (parameter.IdfsParameter.HasValue) && ffRender.ParameterList.ContainsKey(parameter.IdfsParameter.Value) && (parameter.ParameterTemplateRow != null))
                {
                    string ruleNames;
                    if (MainDbService.IsParameterUseInAction(parameter.ParameterTemplateRow, out ruleNames))
                    {
                        ErrorForm.ShowMessageDirect(
                            String.Format(EidssMessages.Get("DeleteFromTemplate_ParameterUseInRuleAction"),
                                          ruleNames));
                        return;
                    }
                    ffRender.ParameterList.Remove(parameter.IdfsParameter.Value);
                }

                if ((sectionTable != null) && (sectionTable.IdfsSection.HasValue))
                {
                    //не выбран ли параметр в табличной секции?
                    if (sectionTable.SelectedBand != null)
                    {
                        var sectionTemplateRow = sectionTable.SelectedBand.Tag as FlexibleFormsDS.SectionTemplateRow;
                        var parameterTemplateRow = sectionTable.SelectedBand.Tag as FlexibleFormsDS.ParameterTemplateRow;
                        if ((sectionTemplateRow != null) && (ffRender.SectionTableList.ContainsKey(sectionTemplateRow.idfsSection)))
                        {
                            if (MainDbService.CheckSectionDependItems(sectionTemplateRow.idfsSection, rowTemplate.idfsFormTemplate))
                            {
                                ErrorForm.ShowMessageDirect(EidssMessages.Get("DeleteFromTemplate_Section_Has_Children"));
                                return;
                            }
                            ffRender.SectionTableList.Remove(sectionTemplateRow.idfsSection);
                        }
                        if ((parameterTemplateRow != null) && (ffRender.ParameterList.ContainsKey(parameterTemplateRow.idfsParameter)))
                        {
                            string ruleNames;
                            if (MainDbService.IsParameterUseInAction(parameterTemplateRow, out ruleNames))
                            {
                                ErrorForm.ShowMessageDirect(
                                    String.Format(EidssMessages.Get("DeleteFromTemplate_ParameterUseInRuleAction"),
                                                  ruleNames));
                                return;
                            }
                            ffRender.ParameterList.Remove(parameterTemplateRow.idfsParameter);
                        }
                    }
                    else
                    {
                        //если нет, то удаляется сама табличная секция
                        //при удалении с. нужно проверить не осталось ли у неё вложенных параметров или других с.
                        if ((MainDbService.GetSectionTemplateChildrenRows(sectionTable.IdfsSection.Value, rowTemplate.idfsFormTemplate).Length > 0)
                            || (MainDbService.GetParameterTemplateChildrenRows(sectionTable.IdfsSection.Value, rowTemplate.idfsFormTemplate).Length > 0))
                        {
                            ErrorForm.ShowMessageDirect(EidssMessages.Get("DeleteFromTemplate_Section_Has_Children"));
                            return;
                        }

                        if (ffRender.SectionTableList.ContainsKey(sectionTable.IdfsSection.Value)) ffRender.SectionTableList.Remove(sectionTable.IdfsSection.Value);
                    }
                }
                else if ((section != null) && (section.IdfsSection.HasValue))
                {
                    //при удалении с. нужно проверить не осталось ли у неё вложенных параметров или других с.
                    if (MainDbService.CheckSectionDependItems(section.IdfsSection.Value, rowTemplate.idfsFormTemplate))
                    {
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("DeleteFromTemplate_Section_Has_Children"));
                        return;
                    }
                    if (ffRender.SectionList.ContainsKey(section.IdfsSection.Value)) ffRender.SectionList.Remove(section.IdfsSection.Value);
                }
            }

            #endregion

            #region Удаление декоративных элементов

            if (parameterHost is Line)
            {
                var linesRow = (FlexibleFormsDS.LinesRow)parameterHost.Tag;
                if (ffRender.LineList.ContainsKey(linesRow.idfDecorElement)) ffRender.LineList.Remove(linesRow.idfDecorElement);
            }

            if (parameterHost is Label)
            {
                var labelsRow = (FlexibleFormsDS.LabelsRow)parameterHost.Tag;
                if (ffRender.LabelList.ContainsKey(labelsRow.idfDecorElement)) ffRender.LabelList.Remove(labelsRow.idfDecorElement);
            }

            #endregion

            //лейблы и линии удаляются просто так
            parameterHost.Delete();
            ffRender.TemplateDesignerHost.GetSelectedParameterHosts().RemoveAt(0);
            ffRender.TemplateDesignerHost.ClearActive();
            //сбрасываем выделение из библиотеки
            SelectedObjectInParametersLibrary = null;
            //кликнем по дереву параметров, чтобы синхронизировать с изменениями
            OnTreeParametersClick(sender, null);
        }

        /// <summary>
        /// Нажата кнопка "Freeze"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFreezeItemClick(object sender, ItemClickEventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() == 0) return;
            var sectTable = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as SectionTable;
            if (!((sectTable != null) && (sectTable.SelectedBand != null))) return;
            sectTable.SelectedBand.RootBand.Fixed = btnFreezeSection.Down ? FixedStyle.Left : FixedStyle.None;
            if (sectTable.SelectedBand.Tag is FlexibleFormsDS.SectionTemplateRow)
            {
                var row = (FlexibleFormsDS.SectionTemplateRow)sectTable.SelectedBand.Tag;
                //важно взять именно эту секцию
                row.blnFreeze = btnFreezeSection.Down;
            }
            else if (sectTable.SelectedBand.Tag is FlexibleFormsDS.ParameterTemplateRow)
            {
                var row = (FlexibleFormsDS.ParameterTemplateRow)sectTable.SelectedBand.Tag;
                //важно взять именно эту секцию
                row.blnFreeze = btnFreezeSection.Down;
            }
        }

        /// <summary>
        /// Добавление нового правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddRuleItemClick(object sender, ItemClickEventArgs e)
        {
            //нужно стоять на узле шаблона формы
            if (treeTemplates.Selection.Count == 0) return;
            if (treeTemplates.Selection[0].Tag == null) return;
            var rowTemplate = treeTemplates.Selection[0].Tag as FlexibleFormsDS.TemplatesRow;
            if (rowTemplate == null) return;
            //правила нельзя добавлять в несохранённый шаблон
            if (rowTemplate.idfsFormTemplate < 0)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("Rule_Cant_Add_Unsaved_Template"));
                return;
            }

            #region Создаём новую строку

            var rowRules = MainDbService.MainDataSet.Rules.NewRulesRow();
            rowRules.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            rowRules.idfsFormTemplate = rowTemplate.idfsFormTemplate;

            //подсчитаем, сколько правил, с наименованием по умолчанию, уже содержится в таблице
            int count = MainDbService.MainDataSet.Rules.Select(String.Format("[DefaultName] like '{0}%'", DefaultRuleName)).Length;

            rowRules.DefaultName = String.Format("{0}{1}", DefaultRuleName, count + 1);
            rowRules.NationalName = String.Format("{0}{1}", nationalRuleName, count + 1);

            rowRules.idfsCheckPoint = ((long)FFRuleCheckPointType.OnValueChanged).ToString();
            rowRules.idfsCheckPointDescr = String.Empty;
            rowRules.blnNot = false;
            rowRules.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;

            MainDbService.MainDataSet.Rules.AddRulesRow(rowRules);

            #endregion

            //добавляем узел по созданной строке в дерево правил
            AppendRuleNodes(treeRules, new[] { rowRules });
            //встаём на последний узел у этого родителя
            treeRules.FocusedNode = treeRules.Nodes.LastNode;
            //скрываем строку с константами
            erTemplateRuleConstants.Visible = false;
            //
            OnTreeRulesClick(sender, null);
        }

        /// <summary>
        /// Выбор какой-либо функции для правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnRuleFunctionClick(object sender, ItemClickEventArgs e)
        {
            //должно быть выбрано активное правило
            var rowRules = GetActiveRule();
            if (rowRules == null) return;
            if (e.Item.Tag == null) return;
            string tag = e.Item.Tag.ToString();
            //"встанем" на этот узел, чтобы нормально загрузились все справочники
            OnTreeRulesClick(sender, null);
            //тэг "id правила;параметр1;параметр2"
            string[] tagsplited = tag.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            //выставляем функцию правилу
            rowRules.idfsRuleFunction = Convert.ToInt64(tagsplited[0]);
            //поскольку состав аргументов в функции для правила может измениться, то удалим аргументы и соберём их заново
            for (int i = MainDbService.MainDataSet.RuleParameterForFunction.Count - 1; i >= 0; i--)
            {
                var row = MainDbService.MainDataSet.RuleParameterForFunction[i];
                if (!row.IsRowAlive()) continue;
                if (row.idfsRule.Equals(rowRules.idfsRule)) row.Delete();
            }

            //также очистим перечень констант, которые соответствуют этому правилу и его аргументам
            grdRuleConstants.DataSource = null;
            grdvRuleConstants.EditingValue = null;
            for (int i = MainDbService.MainDataSet.RuleConstant.Count - 1; i >= 0; i--)
            {
                var row = MainDbService.MainDataSet.RuleConstant[i];
                if (!row.IsRowAlive()) continue;
                if (row.idfsRule.Equals(rowRules.idfsRule)) row.Delete();
            }

            //для каждого параметра (их 1 или 2) определяем записи в хранилище для параметров в функции
            for (int i = 1; i < tagsplited.Length; i++)
            {
                #region Создаём новую строку

                var rowRuleParameterForFunctionRow = MainDbService.MainDataSet.RuleParameterForFunction.NewRuleParameterForFunctionRow();
                rowRuleParameterForFunctionRow.idfsFormTemplate = rowRules.idfsFormTemplate;
                rowRuleParameterForFunctionRow.idfsRule = rowRules.idfsRule;
                rowRuleParameterForFunctionRow.intOrder = i - 1;
                rowRuleParameterForFunctionRow.idfsParameter = Convert.ToInt64(tagsplited[i]);
                //получим тип параметра
                var rowParameter =
                    (FlexibleFormsDS.ParameterTemplateRow[])
                    MainDbService.MainDataSet.ParameterTemplate.Select(
                        DataHelper.Filter("idfsParameter", rowRuleParameterForFunctionRow.idfsParameter, "idfsFormTemplate", rowRuleParameterForFunctionRow.idfsFormTemplate));
                if (rowParameter.Length == 1)
                    rowRuleParameterForFunctionRow.idfsParameterType = rowParameter[0].idfsParameterType;
                MainDbService.MainDataSet.RuleParameterForFunction.AddRuleParameterForFunctionRow(rowRuleParameterForFunctionRow);

                #endregion
            }
            rowRules.FunctionText = MainDbService.GetRuleFunctionText(rowRules);
            rowRules.intNumberOfParameters = tagsplited.Length;
            //установим видимость строки для ввода предустановленных значений
            SetRuleConstantVisible(rowRules);
            rowRules.ConstantsText = MainDbService.GetRuleConstantsText(rowRules);
            //помещаем свойства выбранного правила
            propTemplateRule.SelectedObject = null;
            propTemplateRule.SelectedObject = rowRules;
            //на всякий случай перевернём на вкладку правил
            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateRule;
        }

        /// <summary>
        /// Выставляет видимость строки для ввода констант для правила в шаблоне
        /// </summary>
        /// <param name="rowRules"></param>
        private void SetRuleConstantVisible(FlexibleFormsDS.RulesRow rowRules)
        {
            //если не задана функция для правила, то выходим
            if (rowRules.IsidfsRuleFunctionNull()) return;
            //если тип функции предусматривает указание конкретных значений, то откроем строку для их ввода. Иначе она не должна быть видна.
            var rfRows = (FlexibleFormsDS.RuleFunctionsRow[])MainDbService.MainDataSet.RuleFunctions.Select(DataHelper.Filter("idfsRuleFunction", rowRules.idfsRuleFunction));
            erTemplateRuleConstants.Visible = rfRows.Length == 1 && rfRows[0].idfsRuleFunction.Equals((long)FFRuleFunctions.Value);

            //если строка ввода констант видима, то определим какой редактор использовать, исходя из типа параметра
            if (!erTemplateRuleConstants.Visible)
            {
                //относительно этого параметра очистим таблицу констант, которые могли быть введены ранее
                MainDbService.DeleteRuleConstants(rowRules.idfsRule);
                return;
            }
            var rows = (FlexibleFormsDS.RuleParameterForFunctionRow[])MainDbService.MainDataSet.RuleParameterForFunction.Select(DataHelper.Filter("idfsRule", rowRules.idfsRule));
            //получим параметр
            var rowParameter = (FlexibleFormsDS.ParametersRow[])MainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsParameter", rows[0].idfsParameter));
            //может быть только один параметр, когда используется ф-ция Arg is Value
            if (rows.Length == 1)
            {
                switch (rows[0].idfsParameterType)
                {
                    case (long)FFParameterTypes.Boolean/*"parBoolean"*/:
                        colRuleConstants.ColumnEdit = constantsBoolean;
                        break;
                    case (long)FFParameterTypes.Date/*"parDate"*/:
                        colRuleConstants.ColumnEdit = constantsDateTime;
                        break;
                    case (long)FFParameterTypes.DateTime/*"parDateTime"*/:
                        colRuleConstants.ColumnEdit = constantsDateTime;
                        break;
                    case (long)FFParameterTypes.String/*"parString"*/:
                        colRuleConstants.ColumnEdit = constantsText;
                        break;
                    case (long)FFParameterTypes.Numeric /*"parNumeric"*/:
                    case (long)FFParameterTypes.NumericNatural /*"parNumeric"*/:
                    case (long)FFParameterTypes.NumericPositive /*"parNumeric"*/:
                    case (long)FFParameterTypes.NumericInteger /*"parNumeric"*/:
                        colRuleConstants.ColumnEdit = constantsInt;
                        break;
                    default:
                        //все остальные типы данных, а именно -- пресеты
                        colRuleConstants.ColumnEdit = constantsFixedPreset;
                        if (rowParameter.Length == 1)
                            constantsFixedPreset.DataSource = MainDbService.LoadParameterSelectList(rowParameter[0].idfsParameter, rowParameter[0].idfsParameterType, rowParameter[0].intHACode);
                        break;
                }
            }
        }

        /// <summary>
        /// Клик на дереве правил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeRulesClick(object sender, EventArgs e)
        {
            propTemplateRule.SelectedObject = null;
            FlexibleFormsDS.RulesRow rowRules = GetActiveRule();
            if (rowRules == null) return;
            //пробуем загрузить мета-данные функций для правил
            MainDbService.LoadRuleFunctions(-1); //-1 значит, что все функции что есть
            //загружаем данные по параметрам функции, которая в этом правиле
            MainDbService.LoadRuleParameterForFunction(rowRules.idfsRule);
            //загружаем действия по правилу
            MainDbService.LoadRuleParameterForAction(rowRules.idfsRule);
            //загружаем константы (или предустановленные значения) по правилу
            MainDbService.LoadRuleConstants(rowRules.idfsRule);
            //восстанавливаем текст функции
            rowRules.FunctionText = MainDbService.GetRuleFunctionText(rowRules);
            //устанавливаем поясняющий текст для действий
            rowRules.ActionText = String.Format("{0}{1}", MainDbService.MainDataSet.RuleParameterForAction.Select(DataHelper.Filter("idfsRule", rowRules.idfsRule)).Length, EidssMessages.Get("actions"));
            //установим видимость строки ввода предустановленных значений
            SetRuleConstantVisible(rowRules);
            rowRules.ConstantsText = MainDbService.GetRuleConstantsText(rowRules);
            //помещаем свойства выбранного правила
            propTemplateRule.SelectedObject = rowRules;
            //перелистываем на вкладку правил
            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateRule;
        }

        /// <summary>
        /// Изменение свойств правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropRuleInTemplateCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (treeRules.Selection.Count == 0) return;
            if (e.Row.Equals(erTemplateRuleNationalName))
            {
                treeRules.Selection[0][trlcTreeListParametersColumn] = e.Value;
            }
            else if (e.Row.Equals(erTemplateRuleNot))
            {
                var rowRules = (FlexibleFormsDS.RulesRow)treeRules.Selection[0].Tag;
                rowRules.FunctionText = MainDbService.GetRuleFunctionText(rowRules);
                //помещаем свойства выбранного правила
                //propTemplateRule.SelectedObject = null;
                //propTemplateRule.SelectedObject = rowRules;
            }
        }

        /// <summary>
        /// Добавление новой константы в правило
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnRuleAddConstantItemClick(object sender, ItemClickEventArgs e)
        {
            FlexibleFormsDS.RulesRow rowRules = GetActiveRule();
            if (rowRules == null) return;
            if (rowRules.IsidfsRuleFunctionNull()) return;

            #region Создаём новую строку

            FlexibleFormsDS.RuleConstantRow rowConstant = MainDbService.MainDataSet.RuleConstant.NewRuleConstantRow();
            rowConstant.idfsRule = rowRules.idfsRule;
            MainDbService.MainDataSet.RuleConstant.AddRuleConstantRow(rowConstant);

            #endregion

            RefreshRuleConstants();
        }

        /// <summary>
        /// Удаление константы из правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnRuleDeleteConstantItemClick(object sender, ItemClickEventArgs e)
        {
            int[] handles = grdvRuleConstants.GetSelectedRows();
            foreach (int handle in handles)
            {
                var row = (DataRow)grdvRuleConstants.GetRow(handle);
                if (row != null)
                {
                    row.Delete();
                    RefreshRuleConstants();
                }

            }
        }

        /// <summary>
        /// Выбран узел в параметрах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersClick(object sender, EventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;

            SetButtonEnabled(btnAddParameter, true);
            SetButtonEnabled(btnAddSection, true);

            var treeListNode = treeParameters.Selection[0];
            if (treeListNode.Tag == null) return;
            Cursor = Cursors.WaitCursor;
            if (treeListNode.Tag is FlexibleFormsDS.FormTypesRow)
            {
                //редактировать тип формы нельзя, потому просто перелистываем на его вкладку
                tbcRedParamProperties.SelectedTabPage = tbpRedFormType;
            }
            else if (treeListNode.Tag is FlexibleFormsDS.SectionsRow)
            {
                propSection.Enabled = !ReadOnly;
                btnDeleteParameter.Enabled = false;
                SetButtonEnabled(btnDeleteSection, false);

                #region Показ содержимого секции

                tbcRedParamProperties.SelectedTabPage = tbRedSection;
                var rowSection = (FlexibleFormsDS.SectionsRow)treeListNode.Tag;
                //покажем полный путь
                rowSection.FullPath = GetFullPathForNode(treeListNode);
                //признак возможности заводить новые строки нужно показывать только если это табличная секция
                erSectionFixedRowset.Visible = rowSection.blnFixedRowset;
                //если у секции есть родительская секция и она табличная, то нельзя редактировать тип секции (в противном случае можно)
                FlexibleFormsDS.SectionsRow rowParentSection = null;
                if (!rowSection.IsidfsParentSectionNull())
                    rowParentSection = MainDbService.GetSectionRow(rowSection.idfsParentSection);
                //если секция используется в каком-либо шаблоне, то блокируем те строки, которые при этом нельзя редактировать
                erSectionGrid.Properties.ReadOnly =
                    erSectionFixedRowset.Properties.ReadOnly =
                    MainDbService.IsSectionUsed(rowSection.idfsSection) ||
                    ((rowParentSection != null) && (rowParentSection.blnGrid));
                //
                propSection.SelectedObject = rowSection;

                #endregion
            }
            else if (treeListNode.Tag is FlexibleFormsDS.ParametersRow)
            {
                propParameter.Enabled = !ReadOnly;

                btnAddParameter.Enabled = btnAddSection.Enabled = btnDeleteSection.Enabled = false;
                SetButtonEnabled(btnDeleteParameter, false);

                #region Показ содержимого параметра

                //тот узел параметра, который выбран в дереве
                var rowParameter = (FlexibleFormsDS.ParametersRow)treeParameters.Selection[0].Tag;
                //произведём связывание строки и таблицы для отображения её свойств
                propParameter.SelectedObject = rowParameter;
                //покажем полный путь
                rowParameter.FullPath = GetFullPathForNode(treeListNode);
                //если параметр используется в каком-либо шаблоне, то блокируем те строки, которые при этом нельзя редактировать
                erParameterScheme.Properties.ReadOnly
                    = erParameterType.Properties.ReadOnly
                      = erParameterEditors.Properties.ReadOnly
                        = erParameterWidth.Properties.ReadOnly
                          = erParameterHeight.Properties.ReadOnly
                            = erParameterLabelSize.Properties.ReadOnly
                              = erParameterHACode.Properties.ReadOnly //= false;
                                = MainDbService.IsParameterUsed(rowParameter.idfsParameter);
                //произведём повторное связывание строки и таблицы для отображения её свойств
                propParameter.SelectedObject = rowParameter;
                //отобразим визуальное представление редактируемого параметра
                if (parEditingParameter == null)
                {
                    //если он не создан, то создадим его и поместим на форму-хост
                    parEditingParameter = new Parameter
                                              {
                                                  NowLoading = true,
                                                  MainDbService = MainDbService,
                                                  Location = new Point(10, 10),
                                                  Name = "parEditingParameter"
                                              };
                    //это просто настроечные параметры
                    parEditingParameter.SizeChanged += OnParEditingParameterSizeChanged;
                    parEditingParameter.m_Splitter.SplitterMoved += OnParEditingParameterSizeChanged;

                    pnlParameterDesignHost.Add(parEditingParameter);
                    parEditingParameter.NowLoading = false;
                }
                parEditingParameter.Tag = rowParameter;
                parEditingParameter.Scheme = ParameterSchemeHelper.ConvertToParameterScheme(rowParameter.intScheme);
                parEditingParameter.Editor = ParameterControlTypeHelper.ConvertToParameterControlType(rowParameter.idfsEditor);
                parEditingParameter.Text = rowParameter.NationalName;
                //в зависимости от схемы параметра применим величину текста
                parEditingParameter.LabelSize = rowParameter.intLabelSize;
                //теперь проставляем ему реальные данные выбранного Параметра
                parEditingParameter.Size = new Size(rowParameter.intWidth, rowParameter.intHeight);

                //посчитаем оптимальное расположение
                //расположим Параметр ровно посередине, отталкиваясь от текущей величины формы
                //если форма меньше, чем параметр, то не будем выполнять эти преобразования

                if ((pnlParameterDesignHost.Width > parEditingParameter.Width) &&
                    (pnlParameterDesignHost.Height > parEditingParameter.Height))
                {
                    parEditingParameter.Location =
                        new Point((pnlParameterDesignHost.Width - parEditingParameter.Width) / 2,
                                  (pnlParameterDesignHost.Height - parEditingParameter.Height) / 2);
                }

                #region Фильтруем доступные контролы

                var dv =
                    LookupCache.Get(LookupTables.ParameterTypeReferenceEditor);
                var rows = dv.Table.Select(DataHelper.Filter("idfsParameterType", rowParameter.idfsParameterType));
                if (rows.Length == 1)
                {
                    SetFilterControlTypeEditors(rowParameter.idfsParameterType);
                }

                #endregion

                #region Показываем список шаблонов, где используется этот параметр

                MainDbService.LoadTemplates(rowParameter.idfsFormType);
                var idfsParameter = rowParameter.idfsParameter;
                // = MainDbService.MainDataSet.ParameterTemplate.Select(DataHelper.Filter("idfsParameter", rowParameter.idfsParameter)).to;
                MainDbService.LoadTemplatesByParameter(idfsParameter);

                //сливаем с текущими изменениями на клиенте
                foreach (var templateRow in MainDbService.MainDataSet.TemplatesByParameter)
                {
                    //для тех шаблонов, что ещё не загружались, загрузим. Те, которые загружены, повторно загружаться не будут
                    MainDbService.LoadParameterTemplate(templateRow.idfsFormTemplate);
                }

                //удаляем те шаблоны, которых уже нет на клиенте
                for (var i = MainDbService.MainDataSet.TemplatesByParameter.Count - 1; i >= 0; i--)
                {
                    var idfsFormTemplate = MainDbService.MainDataSet.TemplatesByParameter[i].idfsFormTemplate;
                    if (!MainDbService.MainDataSet.Templates.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplate)).Any()
                        ||
                        (!MainDbService.MainDataSet.ParameterTemplate.Select(DataHelper.Filter("idfsParameter",
                                                                                               idfsParameter,
                                                                                               "idfsFormTemplate",
                                                                                               idfsFormTemplate)).Any()))
                    {
                        MainDbService.MainDataSet.TemplatesByParameter.Rows.RemoveAt(i);
                    }
                }

                //добавляем те шаблоны, которые добавились на клиенте
                var paramsTemplate = MainDbService.MainDataSet.ParameterTemplate.Select(DataHelper.Filter("idfsParameter", idfsParameter));
                foreach (var parameterTemplate in paramsTemplate)
                {
                    var idfsFormTemplate = ((FlexibleFormsDS.ParameterTemplateRow)parameterTemplate).idfsFormTemplate;
                    if (MainDbService.MainDataSet.TemplatesByParameter.Count(t => t.idfsFormTemplate == idfsFormTemplate) == 0)
                    {
                        var template = MainDbService.GetTemplateRow(idfsFormTemplate);
                        if (template == null) continue;

                        var row = (FlexibleFormsDS.TemplatesByParameterRow)MainDbService.MainDataSet.TemplatesByParameter.NewRow();
                        row.DefaultName = template.DefaultName;
                        row.NationalName = template.NationalName;
                        MainDbService.MainDataSet.TemplatesByParameter.AddTemplatesByParameterRow(row);
                    }
                }


                var count = MainDbService.MainDataSet.TemplatesByParameter.Rows.Count;
                grpTemplatesByParameter.Text = count > 0
                                                   ? String.Format(EidssMessages.Get("TemplatesWhichUseThisParameter"),
                                                                   count, GetItemsString(count))
                                                   : EidssMessages.Get("ThereAreNoTemplatesWhichUseThisParameter");

                lbTemplatesByParameter.DataSource = MainDbService.MainDataSet.TemplatesByParameter;

                #endregion

                //переключимся на вкладку параметров
                tbcRedParamProperties.SelectedTabPage = tbRedParameter;

                #endregion
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Выбор узла 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersLibraryClick(object sender, EventArgs e)
        {
            if (treeParametersLibrary.Selection.Count == 0) return;
            //если выбран спец.узел, то снимаем выделение
            if (treeParametersLibrary.Selection[0].Tag.Equals(StrPointer))
            {
                SelectedObjectInParametersLibrary = null;
            }
            else if ((treeParametersLibrary.Selection[0].Tag is FlexibleFormsDS.SectionsRow) || (treeParametersLibrary.Selection[0].Tag is FlexibleFormsDS.ParametersRow))
            {
                SelectedObjectInParametersLibrary = treeParametersLibrary.Selection[0].Tag;
            }
        }

        /// <summary>
        /// Обработка узла в дереве шаблонов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeTemplatesClick(object sender, EventArgs e)
        {
            propTemplate.SelectedObject = null;

            propTemplate.Enabled = !ReadOnly;
            SetButtonEnabled(btnAddTemplate, true);
            SetButtonEnabled(btnDeleteTemplate, false);

            var templatesRow = GetActiveTemplate();
            if (templatesRow == null)
            {
                btnDeleteTemplate.Enabled = false;
                return;
            }

            btnAddTemplate.Enabled = false;

            Cursor = Cursors.WaitCursor;
            //помещаем свойства шаблона
            propTemplate.SelectedObject = templatesRow;

            #region Обработка детерминантов

            MainDbService.LoadTemplateDeterminants(templatesRow.idfsFormTemplate);
            var rows = (FlexibleFormsDS.TemplateDeterminantValuesRow[])MainDbService.MainDataSet.TemplateDeterminantValues.Select(DataHelper.Filter("idfsFormTemplate", templatesRow.idfsFormTemplate));

            //заполняем таблицу детерминантов
            //типы идут в категории, значения идут в редактируемые свойства
            RefreshDeterminantsInProp(rows);

            //блокируем признак UNI, если он выставлен, потому что вручную его снять нельзя
            //erTemplateUNI.Enabled = !templatesRow.blnUNI;

            #endregion

            #region Загрузка библиотеки параметров, которые пригодны для данного шаблона

            RefreshParametersLibrary(false);

            #endregion

            #region Восстанавливаем шаблон на рабочем столе шаблонов

            ffRender.RestoreTemplate(templatesRow.idfsFormTemplate, templatesRow.idfsFormType, LanguageTemplate);

            #endregion

            #region Отображаем перечень правил для этого шаблона

            RefreshRules(templatesRow.idfsFormTemplate);

            #endregion

            //определим, какие кнопки показывать на контроле управления выбором языка
            //однако если выбранный язык английский, то можно только выбирать
            if (!miTemplateLanguage.EditValue.Equals(bv.common.Core.Localizer.lngEn))
            {
                //[0] - select, [1] - undo
                var hasLanguageTemplate = HasLanguageTemplate(templatesRow.idfsFormTemplate, miTemplateLanguage.EditValue.ToString());

                leTemplateLanguage.Buttons[1].Visible = hasLanguageTemplate;
            }
            else
            {
                leTemplateLanguage.Buttons[1].Visible = false;
            }

            //сбрасываем выделение из библиотеки
            SelectedObjectInParametersLibrary = null;
            //перелистываем на вкладку шаблонов, где свойства шаблона, включая детерминанты
            tbcTemplateComponentsProperties.SelectedTabPage = tbpTemplateProperties;

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Обновляет содержимое библиотеки параметров
        /// </summary>
        /// <param name="mustRefresh">Нужно ли принудительно обновить библиотеку</param>
        private void RefreshParametersLibrary(bool mustRefresh)
        {
            if (treeTemplates.Selection.Count == 0) return;
            if (treeTemplates.Selection[0].ParentNode == null) return;
            //если нужно принудительно обновление библиотеки, то просто удалим всё из неё (самый простой алгоритм),
            //а затем выстроим заново (ветви, открытые пользователем, не восстанавливаются)
            if (mustRefresh)
            {
                treeParametersLibrary.Nodes.Clear();
            }
            //вешаем в дереве библиотеки параметров узел этого типа формы и разворачиваем его
            //если этот узел уже висит сейчас, то не трогаем его
            var rowFormType = ((FlexibleFormsDS.FormTypesRow)treeTemplates.Selection[0].ParentNode.Tag);
            var needRefresh = mustRefresh || ((treeParametersLibrary.Nodes.Count == 0) ||
                                              (!treeParametersLibrary.Nodes[0].Tag.Equals(rowFormType)));

            if (!needRefresh) return;

            //первый нод со стрелкой-курсором оставляем, удаляем второй и всё, что под ним
            if (treeParametersLibrary.Nodes.Count > 1)
                treeParametersLibrary.Nodes.RemoveAt(1);
            else
            {
                //создаём специальный узел -- курсор
                var node = treeParametersLibrary.AppendNode(null, null, StrPointer);
                node[trlcTreeListParametersColumn] = StrPointer;
                node.ImageIndex = node.SelectImageIndex = 4;
            }
            //на всякий случай произведём дозагрузку секций и параметров по этому типу формы
            //осуществляем дозагрузку секций
            if (!mustRefresh)
            {
                MainDbService.LoadSections(rowFormType.idfsFormType, null, null);
                //осуществляем дозагрузку параметров
                //берем только те, что не относятся к какой-либо секции, а только к типу формы
                MainDbService.LoadParameters(rowFormType.idfsFormType, null);
            }
            //обновим статусные данные по этому типу формы
            rowFormType.HasNestedSections = MainDbService.HasNestedSections(rowFormType.idfsFormType);
            rowFormType.HasParameters = MainDbService.HasNestedParameters(rowFormType.idfsFormType);
            //добавляем узел с типом формы
            AppendFormTypeNode(treeParametersLibrary, rowFormType, true);
        }

        /// <summary>
        /// Определяет, имеется ли языковая надстройка
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        /// <returns></returns>
        private bool HasLanguageTemplate(long idfsFormTemplate, string langid)
        {
            var filterstring = DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "langid", String.Format("'{0}'", langid), "blnIsRealStruct", 1);
            var sectionTemplateRows = (FlexibleFormsDS.SectionTemplateRow[])MainDbService.MainDataSet.SectionTemplate.Select(filterstring);
            var parameterTemplateRows = (FlexibleFormsDS.ParameterTemplateRow[])MainDbService.MainDataSet.ParameterTemplate.Select(filterstring);
            var labelsRows = MainDbService.GetLabelTemplateRows(idfsFormTemplate, langid);
            var linesRows = MainDbService.GetLineTemplateRows(idfsFormTemplate, langid);

            return ((sectionTemplateRows.Length > 0) || (parameterTemplateRows.Length > 0) || (labelsRows.Length > 0) || (linesRows.Length > 0));
        }

        /// <summary>
        /// Добавление параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddParameterItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            var nodeParent = treeParameters.Selection[0];
            object tag = nodeParent.Tag;
            //можно подвешивать к секции или типу формы
            var rowParentSection = tag as FlexibleFormsDS.SectionsRow;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            if ((rowParentSection == null) && (rowFormType == null)) return;
            //развернём родительский нод
            nodeParent.Expanded = true;

            #region Создаём новую строку

            var rowParameter = MainDbService.MainDataSet.Parameters.NewParametersRow();
            if (rowParentSection != null)
            {
                rowParameter.idfsSection = rowParentSection.idfsSection;
                rowParameter.idfsFormType = rowParentSection.idfsFormType;
            }
            else
            {
                rowParameter.idfsFormType = rowFormType.idfsFormType;
            }
            rowParameter.intScheme = 0;
            rowParameter.idfsParameterType = 10071045; //parString
            rowParameter.ParameterTypeName = "String"; //все равно будет заменен в редакторе
            rowParameter.idfsEditor = 10067008; //editText
            rowParameter.intOrder = 0;
            rowParameter.intHACode = 0; //????
            rowParameter.intLabelSize = 75;
            rowParameter.intLeft = 0;
            rowParameter.intTop = 0;
            rowParameter.intWidth = 150;
            rowParameter.intHeight = 100;
            rowParameter.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;

            //подсчитаем, сколько параметров, с наименованием по умолчанию уже содержится в таблице
            int count = MainDbService.MainDataSet.Parameters.Select(String.Format("[DefaultName] like '{0}%'", DefaultParameterName)).Length;

            rowParameter.DefaultName = rowParameter.DefaultLongName = String.Format("{0}{1}", DefaultParameterName, count + 1);
            rowParameter.NationalName = rowParameter.NationalLongName = String.Format("{0}{1}", nationalParameterName, count + 1);

            //добавим строку
            MainDbService.MainDataSet.Parameters.AddParametersRow(rowParameter);
            //если подвешиваем к секции, то надо пометить этой секции, что она теперь содержит параметры

            //добавим узел для этого объекта
            treeParameters.AppendParameterNodes(nodeParent, new[] { rowParameter }, false);

            //переопределим порядок следования
            RefreshOrder(nodeParent);

            #endregion

            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);

            //на всякий случай ещё раз развернём родительский нод, если до этого в нем не было дочерних узлов
            nodeParent.Expanded = true;
            //встаём на узел у этого родителя
            treeParameters.FocusedNode = nodeParent.LastNode;
            OnTreeParametersClick(sender, null);
        }



        /// <summary>
        /// Удаление параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDeleteParameterItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            var nodeParent = treeParameters.Selection[0];
            var rowParameter = nodeParent.Tag as FlexibleFormsDS.ParametersRow;
            if (rowParameter == null) return;

            #region Проверки

            //проверим, не явлется ли этот объект критическим
            if (ffRender.CriticalObjects.Parameters.ContainsKey(rowParameter.idfsParameter))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantDeleteCriticalObject"));
                return;
            }

            //загрузим перечень шаблонов для того же Form Type, что и удаляемый параметр
            MainDbService.LoadTemplates(rowParameter.idfsFormType);
            foreach (var row in MainDbService.MainDataSet.Templates)
            {
                if (!row.IsRowAlive()) continue;
                MainDbService.LoadParameterTemplate(row.idfsFormTemplate);
                MainDbService.LoadSectionTemplate(row.idfsFormTemplate);
                MainDbService.LoadRulesForTemplate(row.idfsFormTemplate);
                var rules = (FlexibleFormsDS.RulesRow[])MainDbService.MainDataSet.Rules.Select(DataHelper.Filter("idfsFormTemplate", row.idfsFormTemplate));
                foreach (FlexibleFormsDS.RulesRow rulesRow in rules)
                {
                    if (!rulesRow.IsRowAlive()) continue;
                    MainDbService.LoadRuleParameterForFunction(rulesRow.idfsRule);
                    MainDbService.LoadRuleParameterForAction(rulesRow.idfsRule);
                }
            }
            if (MainDbService.MainDataSet.ParameterTemplate.Select(DataHelper.Filter("idfsParameter", rowParameter.idfsParameter)).Length > 0)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("ParameterRemove_Has_ffParameterForTemplate_Rows"));
                return;
            }
            if (MainDbService.MainDataSet.RuleParameterForFunction.Select(DataHelper.Filter("idfsParameter", rowParameter.idfsParameter)).Length > 0)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("ParameterRemove_Has_Rules_Rows"));
                return;
            }
            if (MainDbService.MainDataSet.RuleParameterForAction.Select(DataHelper.Filter("idfsParameter", rowParameter.idfsParameter)).Length > 0)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("ParameterRemove_Has_Rules_Rows"));
                return;
            }
            //проверим, чтобы он в матрицу не входил
            if (MainDbService.IsParameterUsed(rowParameter.idfsParameter))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("ParameterRemove_Has_tlbAggrMatrixVersion_Rows"));
                return;
            }

            #endregion

            if (!WinUtils.ConfirmMessage(EidssMessages.Get("ParameterDeleteQuestion"), String.Empty)) return;

            //если параметр помечен для копирования, то снимем эту пометку
            if ((RowCopiedParameter != null) && (RowCopiedParameter.idfsParameter.Equals(rowParameter.idfsParameter))) RowCopiedParameter = null;

            //отыскиваем этот параметр в таблице и удаляем его
            //for (var i = MainDbService.MainDataSet.Parameters.Count - 1; i >= 0; i-- )
            //{
            //    var parameter = MainDbService.MainDataSet.Parameters[i];
            //    if (!parameter.IsRowAlive()) continue;
            //    if (!rowParameter.IsRowAlive()) continue;
            //    if (parameter.idfsParameter == rowParameter.idfsParameter)
            //    {
            //        MainDbService.MainDataSet.Parameters.RemoveParametersRow(parameter);
            //    }
            //}

            rowParameter.Delete();

            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);

            var pn = nodeParent.ParentNode;
            pn.Nodes.Remove(nodeParent);
            //выберем этот родительский узел
            pn.Selected = true;
            OnTreeParametersClick(sender, null);
        }

        /// <summary>
        /// Добавление секции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddSectionItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            var nodeParent = treeParameters.Selection[0];
            //если уровень вложенности родителя предельный, то не даём добавлять новый
            if (nodeParent.Level >= 30)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("GainedMaxNestLevel", "Can't add Section. The maximum nest level is reached."));
                return;
            }

            object tag = nodeParent.Tag;
            //можно подвешивать к секции или типу формы
            var rowParentSection = tag as FlexibleFormsDS.SectionsRow;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            if ((rowParentSection == null) && (rowFormType == null)) return;
            //развернём родительский нод
            nodeParent.Expanded = true;

            #region Создаём новую строку
            var rowSection = MainDbService.MainDataSet.Sections.NewSectionsRow();
            if (rowParentSection != null)
            {
                rowSection.idfsParentSection = rowParentSection.idfsSection;
                rowSection.idfsFormType = rowParentSection.idfsFormType;
                rowSection.blnGrid = rowParentSection.blnGrid;
                rowSection.blnFixedRowset = rowParentSection.blnFixedRowset;
            }
            else
            {
                rowSection.idfsFormType = rowFormType.idfsFormType;
                rowSection.blnGrid = rowSection.blnFixedRowset = false;
            }

            //подсчитаем, сколько секций, с наименованием по умолчанию уже содержится в таблице
            int count = MainDbService.MainDataSet.Sections.Select(String.Format("[DefaultName] like '{0}%'", DefaultSectionName)).Length;
            rowSection.DefaultName = String.Format("{0}{1}", DefaultSectionName, count + 1);
            rowSection.NationalName = String.Format("{0}{1}", nationalSectionName, count + 1);
            rowSection.intOrder = 0;
            rowSection.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            //добавим строку
            MainDbService.MainDataSet.Sections.AddSectionsRow(rowSection);
            //если подвешиваем к секции, то надо пометить этой секции, что она теперь содержит другие секции
            //if (rowParentSection != null) rowParentSection.HasNestedSections = true;

            //добавим узел для этого объекта
            var nodeNew = MainDbService.AppendSectionNodes(treeParameters, nodeParent, new[] { rowSection }, true, true);
            //развернём этот узел
            nodeNew.Expanded = true;

            //переопределим порядок следования
            RefreshOrder(nodeParent);

            #endregion

            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);

            //на всякий случай ещё раз развернём родительский нод, если до этого в нем не было дочерних узлов
            nodeParent.Expanded = true;
            //встаём на последний узел у этого родителя
            treeParameters.FocusedNode = nodeParent.LastNode;
            OnTreeParametersClick(sender, null);
        }

        /// <summary>
        /// Удаление секции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDeleteSectionItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            var nodeParent = treeParameters.Selection[0];
            var rowSection = nodeParent.Tag as FlexibleFormsDS.SectionsRow;
            if (rowSection == null) return;

            #region Проверки

            //проверим, не явлется ли этот объект критическим
            if (ffRender.CriticalObjects.Sections.ContainsKey(rowSection.idfsSection))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantDeleteCriticalObject"));
                return;
            }

            //загрузим перечень шаблонов для того же Form Type, что и удаляемый параметр
            MainDbService.LoadTemplates(rowSection.idfsFormType);
            foreach (FlexibleFormsDS.TemplatesRow row in MainDbService.MainDataSet.Templates)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                MainDbService.LoadParameterTemplate(row.idfsFormTemplate);
                MainDbService.LoadSectionTemplate(row.idfsFormTemplate);
            }

            //если на сервере ошибок нет, то проверим, нет ли конфликтов на клиенте
            if (MainDbService.HasNestedSections(rowSection))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("SectionRemove_Has_ffSection_ParentSection_Rows"));
                return;
            }
            if (MainDbService.HasNestedParameters(rowSection))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("SectionRemove_Has_ffParameter_Rows"));
                return;
            }
            if (MainDbService.MainDataSet.SectionTemplate.Select(DataHelper.Filter("idfsSection", rowSection.idfsSection)).Length > 0)
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("SectionRemove_Has_ffSectionForTemplate_Rows"));
                return;
            }

            //TODO выполнить проверку для линий и лейблов (через ffDecorElement)

            #endregion

            bool result = WinUtils.ConfirmMessage(EidssMessages.Get("SectionDeleteQuestion"), String.Empty);
            if (!result) return;

            //если секция помечена для копирования, то снимем эту пометку
            if ((RowCopiedSection != null) && (RowCopiedSection.idfsSection.Equals(rowSection.idfsSection))) RowCopiedSection = null;

            rowSection.Delete();

            //принудительно обновим библиотеку параметров
            RefreshParametersLibrary(true);

            TreeListNode pn = nodeParent.ParentNode;
            pn.Nodes.Remove(nodeParent);
            //выберем этот родительский узел
            pn.Selected = true;
            OnTreeParametersClick(sender, null);
        }

        /// <summary>
        /// Помечает объект в дереве параметров для копирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnCopySectionOrParameterItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeParameters.Selection.Count == 0) return;
            object tag = treeParameters.Selection[0].Tag;
            //копировать можно только секции и параметры
            var rowSection = tag as FlexibleFormsDS.SectionsRow;
            var rowParameter = tag as FlexibleFormsDS.ParametersRow;
            if ((rowSection == null) && (rowParameter == null)) return;
            if (rowSection != null)
            {
                RowCopiedSection = rowSection;
                RowCopiedParameter = null;
            }
            else
            {
                RowCopiedSection = null;
                RowCopiedParameter = rowParameter;
            }
        }

        /// <summary>
        /// Вставка секции или параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnPasteSectionOrParameterItemClick(object sender, ItemClickEventArgs e)
        {
            //родительским узлом для вставки может быть только тип формы или секция
            if (treeParameters.Selection.Count == 0) return;
            var nodeParent = treeParameters.Selection[0];
            object tag = nodeParent.Tag;
            var rowSection = tag as FlexibleFormsDS.SectionsRow;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            if ((rowSection == null) && (rowFormType == null)) return;
            //развернём родительский нод
            nodeParent.Expanded = true;

            //ранее должен быть помечен объект копирования
            if ((RowCopiedSection == null) && (RowCopiedParameter == null)) return;

            if (RowCopiedParameter != null)
            {
                //если копируется параметр, то просто делаем с него копию
                var arr = new FlexibleFormsDS.ParametersRow[1];
                arr[0] = RowCopiedParameter;
                CopyParameters(nodeParent, arr);
            }
            else
            {
                //запомним, какие секции были развёрнуты пользователем, чтобы потом их оставить развёрнутыми, а все остальные свернуть
                var listNodes = new List<TreeListNode>();
                nodeParent.CollectExpandedNodes(listNodes);

                //если копируется секция, то нужно собрать все её дочерние секции и параметры и тоже их скопировать
                //развернём полностью дерево под этим узлом, чтобы загрузились все данные
                nodeParent.ExpandAll();

                var arr = new FlexibleFormsDS.SectionsRow[1];
                arr[0] = RowCopiedSection;
                CopySections(nodeParent, arr);

                //свернём все те секции, что не были развёрнуты пользователем
                nodeParent.CollapseNodes(listNodes);
            }
        }

        /// <summary>
        /// Делает копию шаблона
        /// </summary>
        /// <param name="targetNode"></param>
        /// <param name="template"></param>
        /// <param name="needTransferUNI"></param>
        private FlexibleFormsDS.TemplatesRow CopyTemplate(TreeListNode targetNode, FlexibleFormsDS.TemplatesRow template, bool needTransferUNI)
        {
            var formTypesRow = targetNode.Tag as FlexibleFormsDS.FormTypesRow;
            if (formTypesRow == null) return null;

            var rulesRows = MainDbService.GetRules(template.idfsFormTemplate);

            foreach (var row in rulesRows)
            {
                if (MainDbService.CheckRuleForNew(row))
                {
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("Cant_Use_Unsaved_Rule"));
                    return null;
                }
            }
            var rowTemplate = CopyHelper.CopyTemplate(MainDbService, template, formTypesRow.idfsFormType, needTransferUNI);

            //помещаем новый узел скопированного шаблона в дерево
            treeTemplates.AppendTemplatesNodes(targetNode, new[] { rowTemplate });

            return rowTemplate;
        }

        /// <summary>
        /// Делает копии секций
        /// </summary>
        /// <param name="sections"></param>
        /// <param name="targetNode"></param>
        private void CopySections(TreeListNode targetNode, FlexibleFormsDS.SectionsRow[] sections)
        {
            //для каждого параметра делаем его копию и подвешиваем к целевому узлу
            object tag = targetNode.Tag;
            var rowParentSection = tag as FlexibleFormsDS.SectionsRow;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            if ((rowParentSection == null) && (rowFormType == null)) return;

            for (var i = 0; i < sections.Length; i++)
            {
                var row = sections[i];

                #region Создаём новую строку

                var rowSection = MainDbService.MainDataSet.Sections.NewSectionsRow();
                if (rowParentSection != null)
                {
                    rowSection.idfsParentSection = rowParentSection.idfsSection;
                    rowSection.idfsFormType = rowParentSection.idfsFormType;
                }
                else
                {
                    rowSection.idfsFormType = rowFormType.idfsFormType;
                }
                rowSection.DefaultName = row.DefaultName;
                rowSection.NationalName = row.NationalName;
                //rowSection.HasParameters = row.HasParameters;
                //rowSection.HasNestedSections = row.HasNestedSections;
                rowSection.blnGrid = row.blnGrid;
                if ((rowParentSection != null) && (rowParentSection.blnGrid))
                    rowSection.blnGrid = rowParentSection.blnGrid;
                rowSection.blnFixedRowset = row.blnFixedRowset;
                rowSection.intOrder = 0;
                //добавим строку
                MainDbService.MainDataSet.Sections.AddSectionsRow(rowSection);

                //добавим узлел для этой новой секции
                var nodeNewSection = MainDbService.AppendSectionNodes(treeParameters, targetNode, new[] { rowSection }, true, true);

                //Копирование дочерних секций
                //скопируем все секции, расположенные под секцией-образцом
                CopySections(nodeNewSection, MainDbService.GetSectionChildrenRows(row.idfsSection));

                //Копирование зависимых параметров
                //скопируем все параметры, относящиеся к секции-образцу
                CopyParameters(nodeNewSection, MainDbService.GetParameterChildrenRows(row.idfsSection));

                #endregion
            }

            //переопределим порядок следования
            RefreshOrder(targetNode);
        }

        /// <summary>
        /// Делает копии параметров
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="targetNode">Узел, куда надо подцепить скопированные параметры</param>
        private void CopyParameters(TreeListNode targetNode, FlexibleFormsDS.ParametersRow[] parameters)
        {
            //для каждого параметра делаем его копию и подвешиваем к целевому узлу
            object tag = targetNode.Tag;
            var rowSection = tag as FlexibleFormsDS.SectionsRow;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            if ((rowSection == null) && (rowFormType == null)) return;

            var parametersNew = new FlexibleFormsDS.ParametersRow[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var row = parameters[i];
                if (!row.IsRowAlive()) continue;

                #region Создаём новую строку

                var rowParameter = MainDbService.MainDataSet.Parameters.NewParametersRow();
                if (rowSection != null)
                {
                    rowParameter.idfsSection = rowSection.idfsSection;
                    rowParameter.idfsFormType = rowSection.idfsFormType;
                }
                else
                {
                    rowParameter.idfsFormType = rowFormType.idfsFormType;
                }
                rowParameter.intScheme = row.intScheme;
                rowParameter.idfsParameterType = row.idfsParameterType;
                rowParameter.ParameterTypeName = row.ParameterTypeName;
                rowParameter.idfsEditor = row.idfsEditor;
                rowParameter.intOrder = row.intOrder;
                rowParameter.intHACode = row.intHACode;
                rowParameter.intLabelSize = row.intLabelSize;
                rowParameter.intLeft = row.intLeft;
                rowParameter.intTop = row.intTop;
                rowParameter.intWidth = row.intWidth;
                rowParameter.intHeight = row.intHeight;
                rowParameter.DefaultName = row.DefaultName;
                rowParameter.NationalName = row.NationalName;
                rowParameter.NationalLongName = row.NationalLongName;
                rowParameter.DefaultLongName = row.DefaultLongName;
                rowParameter.langid = row.langid;
                rowParameter.strNote = row.strNote;
                //добавим строку
                MainDbService.MainDataSet.Parameters.AddParametersRow(rowParameter);

                parametersNew[i] = rowParameter;

                #endregion
            }

            //добавим все узлы для этого объекта (уже новые узлы)
            treeParameters.AppendParameterNodes(targetNode, parametersNew, false);

            //переопределим порядок следования
            RefreshOrder(targetNode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnPasteTemplateItemClick(object sender, ItemClickEventArgs e)
        {
            //родительским узлом для вставки может быть только тип формы или секция
            if (treeTemplates.Selection.Count == 0) return;
            var nodeParent = treeTemplates.Selection[0];
            object tag = nodeParent.Tag;
            var formTypesRow = tag as FlexibleFormsDS.FormTypesRow;
            if (formTypesRow == null) return;
            //развернём родительский нод
            nodeParent.Expanded = true;

            //ранее должен быть помечен объект копирования
            if (RowCopiedTemplate == null) return;

            //копируем
            CopyTemplate(nodeParent, RowCopiedTemplate, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnCopyTemplateItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeTemplates.Selection.Count == 0) return;
            object tag = treeTemplates.Selection[0].Tag;
            var rowTemplate = tag as FlexibleFormsDS.TemplatesRow;
            if (rowTemplate != null)
            {
                RowCopiedTemplate = rowTemplate;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPopupTemplates(object sender, EventArgs e)
        {
            if (treeTemplates.Selection.Count == 0)
            {
                btnCopyTemplate.Enabled = btnPasteTemplate.Enabled = btnMakeSuccessor.Enabled = false;
                return;
            }

            //кнопка копирования недоступна, когда курсор стоит на типе формы. Кнопка вставки наоборот доступна.
            //кнопка копирования недоступна, если тип формы источника отличается от типа формы получателя (из-за требуемых параметров)
            //кнопка "создать преемника" доступна только на шаблоне
            object tag = treeTemplates.Selection[0].Tag;
            var rowFormType = tag as FlexibleFormsDS.FormTypesRow;
            var rowTemplates = tag as FlexibleFormsDS.TemplatesRow;
            bool isCopiedTemplateNotNull = RowCopiedTemplate != null;
            bool isFormType = rowFormType != null;
            bool isTemplate = rowTemplates != null;
            bool isFormTypeEqual = isCopiedTemplateNotNull && isFormType && (rowFormType.idfsFormType.Equals(RowCopiedTemplate.idfsFormType));
            btnCopyTemplate.Enabled = !isFormType;
            btnPasteTemplate.Enabled = isCopiedTemplateNotNull && isFormTypeEqual;
            btnMakeSuccessor.Enabled = isTemplate;
        }

        /// <summary>
        /// Смена языка шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMiTemplateLanguageEditValueChanged(object sender, EventArgs e)
        {
            if (!(miTemplateLanguage.EditValue is string)) return;
            LanguageTemplate = miTemplateLanguage.EditValue.ToString();
            OnTreeTemplatesClick(sender, e);
        }

        /// <summary>
        /// Язык, с которым открывается шаблон
        /// </summary>
        private string LanguageTemplate { get; set; }

        

        /// <summary>
        /// Изменение свойств параметра в шаблоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropParameterInTemplateCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var selectedParameter = (Parameter)ffRender.TemplateDesignerHost.GetSelectedParameterHost(0);

            //смена стандартной схемы параметра
            if (e.Row.Equals(erTemplateParameterScheme))
            {
                selectedParameter.Scheme = ParameterSchemeHelper.ConvertToParameterScheme(Convert.ToInt32(e.Value));
            }
            int val;
            //смена ширины
            if (e.Row.Equals(erTemplateParameterWidth))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int width = val;
                    if (width < Parameter.DefaultParameterSize.Width) width = Parameter.DefaultParameterSize.Width;
                    if (width > Parameter.MaxParameterSize.Width) width = Parameter.MaxParameterSize.Width;
                    selectedParameter.Width = width;
                }
            }
            //смена высоты
            if (e.Row.Equals(erTemplateParameterHeight))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int height = val;
                    if (height < Parameter.DefaultParameterSize.Height) height = Parameter.DefaultParameterSize.Height;
                    if (height > Parameter.MaxParameterSize.Height) height = Parameter.MaxParameterSize.Height;
                    selectedParameter.Height = height;
                }
            }
            //смена ширины заголовка
            if (e.Row.Equals(erTemplateParameterLabelSize))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int labelsize = val;
                    if (labelsize < Parameter.DefaultLabelSize) labelsize = Parameter.DefaultLabelSize;
                    selectedParameter.LabelSize = labelsize;
                }
            }
            //смена режима ввода параметра
            if (e.Row.Equals(erTemplateParameterEditMode))
            {
                if (Convert.ToInt64(e.Value).Equals((long)FFEditModes.Required))
                {
                    SetControlMandatoryState(selectedParameter.ControlParameter);
                }
                else
                {
                    //TODO сделать возврат к дефолтному стилю   
                }
            }
            selectedParameter.ParameterMoveAndResize(selectedParameter, e);
        }

        /// <summary>
        /// Удаление правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDeleteRuleItemClick(object sender, ItemClickEventArgs e)
        {
            var rulesRow = GetActiveRule();
            if (rulesRow == null) return;

            bool result = WinUtils.ConfirmMessage(EidssMessages.Get("RuleDeleteQuestion"), String.Empty);
            if (!result) return;

            MainDbService.DeleteRule(rulesRow);
            //удалим узел правила
            TreeListNode node = treeRules.Selection[0];
            treeRules.Nodes.Remove(node);
            OnTreeRulesClick(this, null);
        }

        /// <summary>
        /// Проверяет, можно ли добавлять линию или лейбл в шаблон
        /// </summary>
        /// <param name="rowTemplate"></param>
        /// <param name="parentSection">Возвращает секцию, если декоративный элемент нужно добавлять в неё</param>
        /// <returns></returns>
        private bool CanAddDecorateElementToTemplate(FlexibleFormsDS.TemplatesRow rowTemplate, out FlexibleFormsDS.SectionTemplateRow parentSection)
        {
            parentSection = null;
            if (rowTemplate == null) return false;

            //определим, выбран ли сейчас какой-нибудь объект на рабочем столе шаблонов
            //линии добавлять можно только в тело шаблона или в секции
            //при этом секции не должны быть табличными
            var list = ffRender.TemplateDesignerHost.GetSelectedParameterHosts();
            if (list.Count > 1) return false;
            if ((list.Count == 1) && (list[0].Tag is FlexibleFormsDS.SectionTemplateRow))
            {
                parentSection = (FlexibleFormsDS.SectionTemplateRow)list[0].Tag;
                var sectionsRow = MainDbService.GetSectionRow(parentSection.idfsSection);
                //определяем, не является ли эта секция или её родитель только что добавленными. Несохранённые секции и параметры нельзя добавлять в шаблон.
                if (MainDbService.CheckSectionForNew(sectionsRow)) return false;
                //если секция табличная, то тоже выходим
                if (parentSection.blnGrid) return false;
            }
            //в шаблон нельзя добавлять и удалять, если у него уже есть observation
            if (MainDbService.HasObservationsForTemplate(rowTemplate.idfsFormTemplate))
            {
                ErrorForm.ShowMessageDirect(EidssMessages.Get("AddInTemplate_Template_Has_Observations"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Добавление Линий в шаблон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddLineToTemplateItemClick(object sender, ItemClickEventArgs e)
        {
            FlexibleFormsDS.TemplatesRow rowTemplate = GetActiveTemplate();
            if (rowTemplate == null) return;

            FlexibleFormsDS.SectionTemplateRow parentSection;
            if (!CanAddDecorateElementToTemplate(rowTemplate, out parentSection)) return;

            #region Добавляем строку в таблицу данных

            var rowLines = MainDbService.MainDataSet.Lines.NewLinesRow();
            rowLines.idfsDecorElementType = (long)FFDecorElementTypes.Line;
            //создаём именно для используемого в данный момент языка

            rowLines.langid = Utils.IsEmpty(miTemplateLanguage.EditValue) ? bv.model.Model.Core.ModelUserContext.CurrentLanguage : miTemplateLanguage.EditValue.ToString();
            rowLines.idfsFormTemplate = rowTemplate.idfsFormTemplate;
            if (parentSection != null) rowLines.idfsSection = parentSection.idfsSection;
            rowLines.SetblnOrientationNull();
            rowLines.intLeft = rowLines.intTop = 5;
            rowLines.intWidth = 100;
            rowLines.intHeight = 15;
            rowLines.intColor = Color.Black.ToArgb();

            MainDbService.MainDataSet.Lines.AddLinesRow(rowLines);

            #endregion

            ffRender.CreateLineInTemplateHost(rowLines);
        }

        /// <summary>
        /// Изменение значений линии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropTemplateLineCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var line = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Line;
            if (line == null) return;
            var linesRow = (FlexibleFormsDS.LinesRow)line.Tag;

            //смена X
            if (e.Row.Equals(erLineLeft))
            {
                if (e.Value != null)
                {
                    int i;
                    if (Int32.TryParse(e.Value.ToString(), out i))
                    {
                        if (i < 0) i = 0;
                        line.Left = i;
                    }
                }
            }
            //смена Y
            if (e.Row.Equals(erLineTop))
            {
                if (e.Value != null)
                {
                    int i;
                    if (Int32.TryParse(e.Value.ToString(), out i))
                    {
                        if (i < 0) i = 0;
                        line.Top = i;
                    }
                }
            }
            //смена ширины
            if (e.Row.Equals(erLineWidth))
            {
                if (e.Value != null)
                {
                    int i;
                    if (Int32.TryParse(e.Value.ToString(), out i))
                    {
                        if (i < Line.DefaultLineSize.Width) i = Line.DefaultLineSize.Width;
                        if (i > Line.MaxLineSize.Width) i = Line.MaxLineSize.Width;
                        line.Width = i;
                    }
                }
            }
            //смена высоты
            if (e.Row.Equals(erLineHeight))
            {
                if (e.Value != null)
                {
                    int i;
                    if (Int32.TryParse(e.Value.ToString(), out i))
                    {
                        if (i < Line.DefaultLineSize.Height) i = Line.DefaultLineSize.Height;
                        if (i > Line.MaxLineSize.Height) i = Line.MaxLineSize.Height;
                        line.Height = i;
                    }
                }
            }
            //смена цвета
            if (e.Row.Equals(erLineColor))
            {
                if (e.Value is Color)
                {
                    var clr = (Color)e.Value;
                    linesRow.intColor = clr.ToArgb();
                    line.BackColor = clr;
                }
            }
            //смена ориентации линии
            if (e.Row.Equals(erLineOrientation))
            {
                if (e.Value != null)
                {
                    int i;
                    if (Int32.TryParse(e.Value.ToString(), out i))
                    {
                        if (i == -1) linesRow.SetblnOrientationNull();
                        if (i == 1) linesRow.blnOrientation = true;
                        if (i == 0) linesRow.blnOrientation = false;
                        line.ResizeLine();
                    }
                }
            }

            propTemplateLine.SelectedObject = null;
            propTemplateLine.SelectedObject = linesRow;
        }

        /// <summary>
        /// Добавление нового детерминанта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddDeterminantItemClick(object sender, ItemClickEventArgs e)
        {
            var templatesRow = GetActiveTemplate();
            if (templatesRow == null) return;
            //Проверки на возможность добавления детерминанта
            //if (DataHelper.HasObservationsForTemplate(MainDbService, templatesRow.idfsFormTemplate))
            //{
            //    ErrorForm.ShowMessageDirect(EidssMessages.Get("Determinant_Save_Cant_Change_Because_Has_Observations", null, null));
            //    return;
            //}

            //пробуем загрузить перечень детерминантов
            MainDbService.LoadDeterminants();
            if (MainDbService.MainDataSet.Determinants.Count == 0) return;
            //
            var ffDeterminants = new FFDeterminants(MainDbService, templatesRow);
            BaseFormManager.ShowModal(ffDeterminants, FindForm());
            if ((ffDeterminants.SelectedDeterminantsRow == null)) return;
            //если такой детерминант уже был добавлен, то повторно его не добавляем
            if (MainDbService.HasTemplateDeterminant(templatesRow.idfsFormTemplate, ffDeterminants.SelectedDeterminantsRow.idfsBaseReference)) return;
            //если среди шаблонов есть UNI+страна на этом шаблоне, то надо по запросу UNI оттуда снять и перевесить сюда
            //найдем такие шаблоны (ищем только UNI)
            if (templatesRow.blnUNI && ffDeterminants.SelectedDeterminantsRow.idfsReferenceType.Equals((long)FFDeterminantTypes.Country))
            {
                var templates =
                    MainDbService.GetTemplateWithSameDeterminant(ffDeterminants.SelectedDeterminantsRow.idfsBaseReference, templatesRow.idfsFormType, true);
                foreach (var templateDeterminantValuesRow in templates)
                {
                    var template = MainDbService.GetTemplateRow(templateDeterminantValuesRow.idfsFormTemplate);
                    if (template == null) return;
                    //если пользователь не хочет снимать признак UNI с найденного шаблона, чтобы остался только на этом шаблоне, значит на этот шаблон не ставим детерминант-страну
                    if (!WinUtils.ConfirmMessage(
                            String.Format(EidssMessages.Get("Determinants_Question_Remove_UNI"),
                                          template.NationalName), String.Empty)) return;
                    template.blnUNI = false;
                }
            }
            //если этот шаблон не UNI и в данном типе формы нет ни одного шаблона UNI без детерминантов или с детерминантом-текущей страной, то делаем этот шаблон UNI
            bool wasSetAsUNI = false;
            if (!templatesRow.blnUNI)
            {
                if (!MainDbService.GetTemplateInFFTypeWithUNICredentionals(templatesRow))
                {
                    templatesRow.blnUNI = true;
                    wasSetAsUNI = true;
                    //уведомление
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("TemplateUNI_This_Template_Set_UNI"));
                }
            }
            string errStr;
            //проверяем, чтобы не было парных шаблонов
            if (!MainDbService.CheckValidDeterminantCombinations(templatesRow, ffDeterminants.SelectedDeterminantsRow.idfsBaseReference, true, HelperFunctions.GetDeterminantType(ffDeterminants.SelectedDeterminantsRow.idfsReferenceType), out errStr))
            {
                ErrorForm.ShowMessageDirect(errStr);
                return;
            }

            MainDbService.CreateTemplateDeterminantValuesRow(ffDeterminants.SelectedDeterminantsRow, templatesRow.idfsFormTemplate, templatesRow.idfsFormType);
            if (wasSetAsUNI) OnTreeTemplatesClick(sender, e); else RefreshDeterminantsInProp();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDeleteDeterminantItemClick(object sender, ItemClickEventArgs e)
        {
            var editorRow = propTemplateDeterminant.FocusedRow as EditorRow;
            if (editorRow == null) return;
            var templateDeterminantValuesRow = (FlexibleFormsDS.TemplateDeterminantValuesRow)editorRow.Tag;
            if (templateDeterminantValuesRow == null) return;
            if (!templateDeterminantValuesRow.IsRowAlive()) return;
            var templatesRow = GetActiveTemplate();
            if (templatesRow == null) return;
            if (!templatesRow.IsRowAlive()) return;

            //Проверки на возможность удаления детерминанта
            //if (DataHelper.HasObservationsForTemplate(MainDbService, templateDeterminantValuesRow.idfsFormTemplate))
            //{
            //    ErrorForm.ShowMessageDirect(EidssMessages.Get("Determinant_Save_Cant_Change_Because_Has_Observations", null, null));
            //    return;
            //}
            //если удаляется UNI-шаблон, то нужно проверить, чтобы в этом же типе формы были другие UNI шаблоны либо без детерминанта-стран, либо с текущей страной
            if (templatesRow.blnUNI)
            {
                //получаем все шаблоны этого типа формы
                if (!MainDbService.GetTemplateInFFTypeWithUNICredentionals(templatesRow, false))
                {
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("Determinant_Remove_Must_Have_Another_Template"));
                    return;
                }
            }
            //проверяем, чтобы не было парных шаблонов
            string errStr;
            if (!MainDbService.CheckValidDeterminantCombinations(templatesRow, templateDeterminantValuesRow.DeterminantValue, false, HelperFunctions.GetDeterminantType(templateDeterminantValuesRow.DeterminantType), out errStr))
            {
                ErrorForm.ShowMessageDirect(errStr);
                return;
            }

            templateDeterminantValuesRow.Delete();
            RefreshDeterminantsInProp();
        }

        /// <summary>
        /// Сделать преемника шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnMakeSuccessorItemClick(object sender, ItemClickEventArgs e)
        {
            //операция преемственности нужна, чтобы сделать следующую версию шаблона, при сохранении его качеств
            //при этом копируется структура шаблона штатными средствами и происходит перенос детерминантов, то есть
            //детерминанты удаляются у шаблона-источника и выставляются у шаблона-копии.

            if (treeParameters.Selection.Count == 0) return;
            object tag = treeTemplates.Selection[0].Tag;
            var rowTemplateSource = tag as FlexibleFormsDS.TemplatesRow;
            if (rowTemplateSource == null) return;
            //вставлять преемника будем в тот же тип формы, где находится шаблон-источник
            var nodeParent = treeTemplates.Selection[0].ParentNode;
            tag = nodeParent.Tag;
            var formTypesRow = tag as FlexibleFormsDS.FormTypesRow;
            if (formTypesRow == null) return;
            //развернём родительский нод
            nodeParent.Expanded = true;
            var rowTemplateSuccessor = CopyTemplate(nodeParent, rowTemplateSource, true);
            if (rowTemplateSuccessor == null) return;
            //с шаблона-предка снимаем признак UNI
            rowTemplateSource.blnUNI = false;

            //копируем детерминанты со старого шаблона
            CopyHelper.CopyDeterminants(MainDbService, rowTemplateSource.idfsFormTemplate, rowTemplateSuccessor.idfsFormTemplate);

            //удалим со старого шаблона его детерминанты
            MainDbService.DeleteDeterminantsFromTemplate(rowTemplateSource.idfsFormTemplate);

            //
            OnTreeTemplatesClick(sender, e);
        }

        /// <summary>
        /// Добавление лейбла на шаблон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddLabelToTemplateItemClick(object sender, ItemClickEventArgs e)
        {
            var rowTemplate = GetActiveTemplate();
            if (rowTemplate == null) return;
            FlexibleFormsDS.SectionTemplateRow parentSection;
            if (!CanAddDecorateElementToTemplate(rowTemplate, out parentSection)) return;

            #region Добавляем строку в таблицу данных

            var rowLabels = MainDbService.MainDataSet.Labels.NewLabelsRow();
            rowLabels.idfsDecorElementType = (long)FFDecorElementTypes.Label;
            rowLabels.langid = Utils.IsEmpty(miTemplateLanguage.EditValue) ? bv.model.Model.Core.ModelUserContext.CurrentLanguage : miTemplateLanguage.EditValue.ToString();
            rowLabels.idfsFormTemplate = rowTemplate.idfsFormTemplate;
            if (parentSection != null) rowLabels.idfsSection = parentSection.idfsSection;
            rowLabels.intLeft = rowLabels.intTop = 5;
            rowLabels.intWidth = 60;
            rowLabels.intHeight = 20;
            rowLabels.intColor = Color.Black.ToArgb();
            rowLabels.intFontSize = 10;
            rowLabels.intFontStyle = (int)FontStyle.Regular;
            rowLabels.DefaultText = DefaultLabelName;
            rowLabels.NationalText = nationalLabelName;

            MainDbService.MainDataSet.Labels.AddLabelsRow(rowLabels);

            #endregion

            ffRender.CreateLabelInTemplateHost(rowLabels);
        }

        /// <summary>
        /// Изменение свойств лейбла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropTemplateLabelCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var label = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Label;
            if (label == null) return;

            var labelsRow = (FlexibleFormsDS.LabelsRow)label.Tag;
            if (labelsRow == null) return;

            if (e.Row.Equals(erLabelDefaultText))
            {
                labelsRow.DefaultText = e.Value == null ? String.Empty : e.Value.ToString();
            }
            if (e.Row.Equals(erLabelNationalText))
            {
                labelsRow.NationalText = e.Value == null ? String.Empty : e.Value.ToString();
            }

            if (labelsRow.IsDefaultTextNull()) labelsRow.DefaultText = DefaultLabelName;
            if (labelsRow.IsNationalTextNull()) labelsRow.NationalText = nationalLabelName;
            if ((labelsRow.NationalText.Length == 0) && (!labelsRow.IsDefaultTextNull())) labelsRow.NationalText = labelsRow.DefaultText;

            label.mainLabel.Text = labelsRow.NationalText.Length > 0 ? labelsRow.NationalText : labelsRow.DefaultText;

            if (e.Row.Equals(erLabelFontSize))
            {int fontSize;
                if (HelperFunctions.GetInt32(e.Value, out fontSize))
                {
                    if (fontSize < Label.MinFontSize) fontSize = Label.MinFontSize;
                    if (fontSize > Label.MaxFontSize) fontSize = Label.MaxFontSize;
                    labelsRow.intFontSize = fontSize;
                    label.mainLabel.Font = new Font(label.mainLabel.Font.FontFamily, labelsRow.intFontSize,
                                                    HelperFunctions.ConvertToFontStyle(labelsRow.intFontStyle));
                }
            }
            if (e.Row.Equals(erLabelFontStyle))
            {
                int fontStyle;
                if (HelperFunctions.GetInt32(e.Value, out fontStyle))
                {
                    labelsRow.intFontStyle = fontStyle;
                    label.mainLabel.Font = new Font(label.mainLabel.Font.FontFamily, label.mainLabel.Font.Size,
                                                    HelperFunctions.ConvertToFontStyle(fontStyle));
                }
            }
            if (e.Row.Equals(erLabelColor))
            {
                if (e.Value is Color)
                {
                    var clr = (Color)e.Value;
                    labelsRow.intColor = clr.ToArgb();
                    label.mainLabel.ForeColor = clr;
                }
            }
            //смена ширины
            int val;
            if (e.Row.Equals(erLabelWidth))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int width = val;
                    if (width < label.MinimumSize.Width) width = label.MinimumSize.Width;
                    if (width > Label.MaxLabelSize.Width) width = Label.MaxLabelSize.Width;
                    labelsRow.intWidth = label.Width = width;
                }
            }
            //смена высоты
            if (e.Row.Equals(erLabelHeight))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int height = val;
                    if (height < label.MinimumSize.Height) height = label.MinimumSize.Height;
                    if (height > Label.MaxLabelSize.Height) height = Label.MaxLabelSize.Height;
                    labelsRow.intHeight = label.Height = height;
                }
            }

            propTemplateLabel.SelectedObject = null;
            propTemplateLabel.SelectedObject = labelsRow;
        }

        /// <summary>
        /// Изменение свойств секции в шаблоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropSectionInTemplateCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (ffRender.TemplateDesignerHost.SelectedParameterHostsCount() != 1) return;
            var selectedSection = ffRender.TemplateDesignerHost.GetSelectedParameterHost(0) as Section;
            if (selectedSection == null) return;

            int val;
            //смена ширины
            if (e.Row.Equals(erTemplateSectionWidth))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int width = val;
                    if (width < Section.DefaultSectionSize.Width) width = Section.DefaultSectionSize.Width;
                    if (width > Section.MaxSectionSize.Width) width = Section.MaxSectionSize.Width;
                    selectedSection.Width = width;
                }

            }
            //смена высоты
            if (e.Row.Equals(erTemplateSectionHeight))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int height = val;
                    if (height < Section.DefaultSectionSize.Height) height = Section.DefaultSectionSize.Height;
                    if (height > Section.MaxSectionSize.Height) height = Section.MaxSectionSize.Height;
                    selectedSection.Height = height;
                }

            }
            //смена высоты заголовка
            if (e.Row.Equals(erTemplateSectionCaptionHeight))
            {
                if (HelperFunctions.GetInt32(e.Value, out val))
                {
                    int captionHeight = val;
                    if (captionHeight < FFRender.DefaultCaptionHeight) captionHeight = FFRender.DefaultCaptionHeight;
                    selectedSection.CaptionHeight = captionHeight;
                }
            }

            selectedSection.SectionMoveAndResize(selectedSection, e);
        }

        /// <summary>
        /// Подравнивание компонент на рабочем столе шаблонов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnFitItemClick(object sender, ItemClickEventArgs e)
        {
            //применять эту функцию можно только если "в фокусе" рабочий стол шаблонов или выбрана обычная секция
            var rowTemplate = GetActiveTemplate();
            if (rowTemplate == null) return;
            var list = ffRender.TemplateDesignerHost.GetSelectedParameterHosts();
            if (list.Count > 1) return;
            //ID контейнера, в котором нужно произвести подравнивание
            long? containerID = null;
            if (list.Count == 1)
            {
                if (list[0].Tag is FlexibleFormsDS.SectionTemplateRow)
                {
                    var sectionTemplateRow =
                        (FlexibleFormsDS.SectionTemplateRow)list[0].Tag;
                    if (sectionTemplateRow.blnGrid) return;
                    containerID = sectionTemplateRow.idfsSection;
                }
                else return;
            }
            MainDbService.FitParameterHostInContainer(rowTemplate.idfsFormTemplate, containerID);
            //переоткроем шаблон
            OnTreeTemplatesClick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Подравнивает весь отчёт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnFitTemplateItemClick(object sender, ItemClickEventArgs e)
        {
            var rowTemplate = GetActiveTemplate();
            if (rowTemplate == null) return;
            MainDbService.FitParameterHostInContainer(rowTemplate.idfsFormTemplate);
            //переоткроем шаблон
            OnTreeTemplatesClick(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersKeyUp(object sender, KeyEventArgs e)
        {
            treeParameters.ProcessKeyUpForTree(e);
            OnTreeParametersClick(sender, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeTemplatesKeyUp(object sender, KeyEventArgs e)
        {
            treeTemplates.ProcessKeyUpForTree(e);
            OnTreeTemplatesClick(sender, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersLibraryKeyUp(object sender, KeyEventArgs e)
        {
            treeParametersLibrary.ProcessKeyUpForTree(e);
        }
    }
}
