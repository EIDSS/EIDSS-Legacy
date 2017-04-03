using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.DesignerHosting;
using eidss.model.Resources;

namespace EIDSS.FlexibleForms.Helpers
{
    public static class HelperFunctions
    {

        #region "HACode lookup binder"

        private static int m_HACodePopupHeight;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="popupContainer"></param>
        /// <param name="dv"></param>
        public static void BindReprositoryHACodeLookup(this RepositoryItemPopupContainerEdit popupContainer, DataView dv)
        {
            var popup = new PopupContainerControl();
            popupContainer.PopupControl = popup;
            m_HACodePopupHeight = 0;
            var haCodePopupWidth = 0;
            dv.Sort = "intHACode";
            popup.Tag = new List<CheckEdit>();
            
            AddHACode(dv, popupContainer, Convert.ToInt32(HACode.Human), ref haCodePopupWidth);
            AddHACode(dv, popupContainer, Convert.ToInt32(HACode.Livestock), ref haCodePopupWidth);
            AddHACode(dv, popupContainer, Convert.ToInt32(HACode.Avian), ref haCodePopupWidth);
            AddHACode(dv, popupContainer, Convert.ToInt32(HACode.Vector), ref haCodePopupWidth);
            
            popup.AutoScroll = true;
            popup.AutoScrollMinSize = new Size(haCodePopupWidth, m_HACodePopupHeight);
            popupContainer.QueryResultValue -= OnPopupContainerEditQueryResultValue;
            popupContainer.QueryResultValue += OnPopupContainerEditQueryResultValue;
            popupContainer.QueryPopUp -= OnPopupContainerQueryPopUp;
            popupContainer.QueryPopUp += OnPopupContainerQueryPopUp;
            popupContainer.QueryDisplayText -= OnPopupContainerQueryDisplayText;
            popupContainer.QueryDisplayText += OnPopupContainerQueryDisplayText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="popupContainer"></param>
        /// <param name="code"></param>
        /// <param name="haCodePopupWidth"></param>
        /// <returns></returns>
        private static bool AddHACode(DataView dv, RepositoryItemPopupContainerEdit popupContainer, int code, ref int haCodePopupWidth)
        {
            var found = dv.FindRows(code);
            if (found.Length == 0)
            {
                return false;
            }
            var check = new CheckEdit
                            {
                                Tag = code,
                                Text = found[0].Row["CodeName"].ToString(),
                                Top = m_HACodePopupHeight
                            };
            check.Width = check.CalcBestSize().Width;
            if (check.Width > haCodePopupWidth)
            {
                haCodePopupWidth = check.Width;
            }
            m_HACodePopupHeight += check.Height;
            popupContainer.PopupControl.Controls.Add(check);
            ((List<CheckEdit>)popupContainer.PopupControl.Tag).Add(check);
            //check.CheckedChanged += CheckedHandler;
            return true;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private static void CheckedHandler(object sender, EventArgs e)
        //{
        //    var check = (CheckEdit)sender;
        //    var popup = (PopupContainerControl)check.Parent;
        //    int code = Convert.ToInt32(check.Tag);
        //    if (code.Equals(Convert.ToInt32(HACode.Animal)))
        //    {
        //        SetChecked(((List<CheckEdit>)popup.Tag)[1], check.Checked);
        //        SetChecked(((List<CheckEdit>)popup.Tag)[2], check.Checked);
        //    }
        //    if (code.Equals(Convert.ToInt32(HACode.Avian)) || code.Equals(Convert.ToInt32(HACode.Livestock)))
        //    {
        //        SetChecked(((List<CheckEdit>)popup.Tag)[0], ((List<CheckEdit>)popup.Tag)[1].Checked || ((List<CheckEdit>)popup.Tag)[2].Checked);
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnPopupContainerEditQueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            //If Closing Then
            //    Return
            //End If
            int haCode = 0;
            if (sender is PopupContainerEdit)
            {
                sender = ((PopupContainerEdit)sender).Tag;
            }

            if (sender is RepositoryItemPopupContainerEdit)
            {
                var popupContainer = (RepositoryItemPopupContainerEdit)sender;
                foreach (var check in ((List<CheckEdit>)popupContainer.PopupControl.Tag))
                {
                    if (check.Checked)
                    {
                        haCode += Convert.ToInt32(check.Tag);
                    }
                }
                if (Utils.IsEmpty(e.Value) && haCode == 0)
                {
                    return;
                }
                e.Value = haCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnPopupContainerQueryDisplayText(object sender,QueryDisplayTextEventArgs e)
        {
            //If Closing Then
            //    Return
            //End If
            int haCode = 0;
            if (Utils.IsEmpty(e.EditValue) == false)
            {
                haCode = Convert.ToInt32(e.EditValue);
            }
            if (sender is PopupContainerEdit)
            {
                sender = ((PopupContainerEdit)sender).Tag;
            }

            if (sender is RepositoryItemPopupContainerEdit)
            {
                var popupContainer = (RepositoryItemPopupContainerEdit)sender;
                e.DisplayText = String.Empty;
                foreach (var check in ((List<CheckEdit>)popupContainer.PopupControl.Tag))
                {
                    bool bitSet = (Convert.ToInt32(check.Tag) & haCode) != 0;
                    SetChecked(check, bitSet);
                    if (bitSet)
                    {
                        string s = e.DisplayText;
                        Utils.AppendLine(ref s, check.Text, ", ");
                        e.DisplayText = s;
                    }
                }
            }
            else
            {
                Dbg.Debug("unexpected type", null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnPopupContainerQueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is PopupContainerEdit)
            {
                sender = ((PopupContainerEdit)sender).Tag;
            }

            if (sender is RepositoryItemPopupContainerEdit)
            {
                var popupContainer = (RepositoryItemPopupContainerEdit)sender;
                popupContainer.PopupControl.Size = new Size(200, popupContainer.PopupControl.AutoScrollMinSize.Height);
            }
            else
            {
                Dbg.Debug("unexpected type", null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="check"></param>
        /// <param name="status"></param>
        private static void SetChecked(CheckEdit check, bool status)
        {
            if (check.Checked == status)
            {
                return;
            }
            //check.CheckedChanged -= CheckedHandler;
            check.Checked = status;
            //check.CheckedChanged += CheckedHandler;
        }

        #endregion

        #region "Repository check list lookup binder"
        
        public static void BindReprositoryCheckListLookup(this RepositoryItemCheckedComboBoxEdit checkList, DataView dv, string valueMember, string displayMember)
        {
            checkList.DataSource = dv;
            checkList.ValueMember = valueMember;
            checkList.DisplayMember = displayMember;
            checkList.SelectAllItemVisible = false;
            checkList.SynchronizeEditValueWithCheckedItems = true;
        }


        #endregion

        /// <summary>
        /// Перенумеровка строк пользовательских данных в соответствии с номерами строк боковика
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="predefinedStubRow"></param>
        /// <param name="idfObservation"></param>
        public static void RenumActivityParameters(this FlexibleFormsDS.ActivityParametersDataTable activityParameters, FlexibleFormsDS.PredefinedStubRow predefinedStubRow, long idfObservation)
        {
            foreach (var row in activityParameters)
            {
                if (!IsRowAlive(row)) continue;
                if (!row.idfObservation.Equals(idfObservation)) continue;
                if (!row.idfRow.Equals(predefinedStubRow.idfRow)) continue;
                //TODO правильно добавить входной параметр с версией матрицы в spFFGetActivityParameters. Иначе может не найти номер строки.
                if (!row.IsintNumRowNull() && row.intNumRow.Equals(predefinedStubRow.NumRow)) continue;
                row.intNumRow = predefinedStubRow.NumRow;
            }
        }

        /// <summary>
        /// Изменяет значение в таблице пользовательских данных (ActivityParameters)
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsParameter"></param>
        /// <param name="idfRow"></param>
        /// <param name="numRow"></param>
        /// <param name="newvalue"></param>
        /// <param name="strNameValue"></param>
        public static FlexibleFormsDS.ActivityParametersRow ChangeValue(this DbServiceUserData mainDbService, long idfObservation, long idfsFormTemplate, long idfsParameter, long idfRow, int numRow, object newvalue, string strNameValue)
        {
            //удалённое значение newvalue обычно имеет значение пустой строки ""
            //оно будет реально удалено в процедуре сохранения данных

            var pairkey = new Dictionary<string, long>
                                                   {
                                                       {"idfObservation", idfObservation},
                                                       {"idfsParameter", idfsParameter},
                                                       {"idfRow", idfRow}
                                                   };
            //если параметр числовой, то нужно привести его к инвариантной культуре
            if (IsParameterNumeric(mainDbService, idfsParameter) && !Utils.IsEmpty(newvalue))
            {
                decimal d;
                if (!Decimal.TryParse(newvalue.ToString(), out d)){d = Decimal.MaxValue;}
                newvalue = d;
            }
            //определим, существует ли эта строка
            var rows = DataHelper.FindDataRows(pairkey, mainDbService.MainDataSet.ActivityParameters);
            FlexibleFormsDS.ActivityParametersRow rowResult = null;
            if (rows.Length > 0)
            {
                //если строка существует, то установим ей новое значение
                rowResult = (FlexibleFormsDS.ActivityParametersRow) rows[0];
                if (!rowResult.varValue.Equals(newvalue))rowResult.varValue = newvalue;
            }
            else
            {
                if (!Utils.IsEmpty(newvalue))
                {
                    //создадим новую строку
                    rowResult =(FlexibleFormsDS.ActivityParametersRow)DataHelper.GetDataRow(pairkey, mainDbService.MainDataSet.ActivityParameters);
                    rowResult.idfsFormTemplate = idfsFormTemplate;
                    rowResult.intNumRow = numRow;
                    rowResult.varValue = newvalue;
                    rowResult.strNameValue = strNameValue;
                }
            }
            return rowResult;
        }

        /// <summary>
        /// Определяет, является ли тип данных параметра относящимся к выпадающим спискам
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        public static bool IsParameterComboBox(this DbService mainDbService, long idfsParameter)
        {
            bool result = false;
            var parametersRows = (FlexibleFormsDS.ParametersRow[])mainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsParameter", idfsParameter));
            //переберём методом исключения
            if (parametersRows.Length > 0)
            {
                if (!(
                    (parametersRows[0].idfsParameterType.Equals((long)FFParameterTypes.Boolean))
                    || (parametersRows[0].idfsParameterType.Equals((long)FFParameterTypes.Date))
                    || (parametersRows[0].idfsParameterType.Equals((long)FFParameterTypes.DateTime))
                    || (IsParameterNumeric(mainDbService, parametersRows[0].idfsParameter))
                    || (parametersRows[0].idfsParameterType.Equals((long)FFParameterTypes.String))
                    )
                    ) result = true;

            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        public static bool IsParameterDate(this DbService mainDbService, long idfsParameter)
        {
            var result = false;
            var parametersRows = (FlexibleFormsDS.ParametersRow[])mainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsParameter", idfsParameter));
            //переберём методом исключения
            if (parametersRows.Length > 0)
            {
                var parameterType = parametersRows[0].idfsParameterType;

                if (parameterType.Equals((long)FFParameterTypes.Date)) result = true;
            }

            return result;
        }

        /// <summary>
        /// Определяет, является ли тип данных параметра числовым
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        public static bool IsParameterNumeric(this DbService mainDbService, long idfsParameter)
        {
            var result = false;
            var parametersRows = (FlexibleFormsDS.ParametersRow[])mainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsParameter", idfsParameter));
            //переберём методом исключения
            if (parametersRows.Length > 0)
            {
                var parameterType = parametersRows[0].idfsParameterType;

                if (
                    parameterType.Equals((long)FFParameterTypes.Numeric)
                    || parameterType.Equals((long)FFParameterTypes.NumericNatural)
                    || parameterType.Equals((long)FFParameterTypes.NumericPositive)
                    || parameterType.Equals((long)FFParameterTypes.NumericInteger)
                   ) result = true;
            }

            return result;
        }

        /// <summary>
        /// Преобразует коллекцию идентификаторов в строку фильтра
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string ConvertToFilterString(string fieldName, List<long> ids)
        {
            var sb = new StringBuilder();
            if (ids.Count == 1)
            {
                sb.Append(ids[0]);
            }
            else if (ids.Count > 1)
            {
                for (int i = 0; i < ids.Count; i++ )
                {
                    sb.Append(ids[i]);
                    if (i != ids.Count - 1) sb.AppendFormat(",");
                }
            }
            string result = String.Empty;
            if (sb.Length > 0)
            {
                result = String.Format("[{0}] in ({1})", fieldName, sb);
            }

            return result;
        }

        /// <summary>
        /// Определяет маску для параметра, исходя из его типа
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        public static MaskProperties GetMaskPropertiesForParameter(long parameterType)
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
                result.EditMask = String.Format(@"\d+([" +CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator +  @"]?\d+)?");
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
        /// Определение стиля шрифта
        /// </summary>
        /// <param name="intFontStyle"></param>
        /// <returns></returns>
        public static FontStyle ConvertToFontStyle(int intFontStyle)
        {
            var result = FontStyle.Regular;
            switch (intFontStyle)
            {
                case 1:
                    result = FontStyle.Bold;
                    break;
                case 2:
                    result = FontStyle.Italic;
                    break;
                case 8:
                    result = FontStyle.Strikeout;
                    break;
                case 4:
                    result = FontStyle.Underline;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Проверяет, является ли узел-источник родительским для узла-приёмника
        /// </summary>
        /// <param name="nodeSource"></param>
        /// <param name="nodeTarget"></param>
        /// <returns></returns>
        public static bool CheckForChildNode(TreeListNode nodeSource, TreeListNode nodeTarget)
        {
            bool result = false;
            if (nodeTarget.ParentNode != null) 
            {
                result = nodeTarget.ParentNode == nodeSource || CheckForChildNode(nodeSource, nodeTarget.ParentNode);
            }

            return result;
        }

        /// <summary>
        /// Определяет среди внутренних контролов контрола самый правый нижний и выводит его координаты
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="excludeControl">Контрол, который не нужно учитывать при поиске</param>
        /// <returns></returns>
        public static Point GetMostRightTopControl(this Control parentControl, Control excludeControl)
        {
            return GetMostRightTopControl(parentControl, new Point(0, 0), excludeControl);
        }

        /// <summary>
        /// Определяет среди внутренних контролов контрола самый правый нижний и выводит его координаты
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="minPoint">Минимальная точка</param>
        /// <param name="excludeControl">Контрол, который не нужно учитывать при поиске</param>
        /// <returns></returns>
        public static Point GetMostRightTopControl(this Control parentControl, Point minPoint, Control excludeControl)
        {
            int left = minPoint.X;
            int top = minPoint.Y;
            if (parentControl.Controls.Count > 0)
            {
                left = parentControl.Controls[0].Left;
                top = parentControl.Controls[0].Top;
                for (int i = 0; i < parentControl.Controls.Count; i++)
                {
                    var ctrl = parentControl.Controls[i];
                    if ((excludeControl != null) && ctrl.Equals(excludeControl)) continue;
                    if (ctrl.Left < left) left = ctrl.Left;
                    if ((ctrl.Top + ctrl.Height) > top) top = (ctrl.Top + ctrl.Height); //ищем самый нижний контрол
                }
            }

            return new Point(left, top);
        }

        private const int IndexSectionDefaultImage = 1;
        private const int IndexSectionTableImage = 6;
        private static readonly string m_StrEmpty = EidssMessages.Get("strEmpty");
        private const string StrEmptyKey = "emptykey";

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
        /// Размещает секции в дереве
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="parentTree"></param>
        /// <param name="parentNode"></param>
        /// <param name="rows"></param>
        /// <param name="useCache"></param>
        /// <param name="loadTableSections"></param>
        public static TreeListNode AppendSectionNodes(this DbService mainDbService, TreeList parentTree, TreeListNode parentNode, FlexibleFormsDS.SectionsRow[] rows, bool useCache, bool loadTableSections)
        {
            TreeListNode result = null;
            //размещаем все узлы
            foreach (var row in rows)
            {
                //если не нужно размещать табличные секции, то пропускаем их
                if (row.blnGrid && (!loadTableSections)) continue;

                var node = parentTree.AppendNode(null, parentNode, row);
                result = node;
                node[0] = row.NationalName;
                SetImageForSectionType(row.blnGrid, node);
                //parentTree.SetNodeIndex(node, row.intOrder);
                // 
                if (!useCache)
                {
                    //осуществляем дозагрузку секций
                    mainDbService.LoadSections(row.idfsFormType, null, row.idfsSection);
                    //осуществляем дозагрузку параметров
                    mainDbService.LoadParameters(row.idfsFormType, row.idfsSection);
                }
                //если внутри этой секции есть другие секции или параметры, то сделаем там фиктивные узлы
                if (mainDbService.HasNestedSections(row) || mainDbService.HasNestedParameters(row))
                {
                    var nodeEmpty = parentTree.AppendNode(null, node, StrEmptyKey);
                    nodeEmpty[0] = m_StrEmpty;
                    node.Expanded = false;
                }
            }
            //удаляем узел <Empty>, если строк было больше нуля
            if (rows.Length > 0) DeleteEmptyNode(parentNode);
            return result;
        }

        /// <summary>
        /// Удаление узла Empty
        /// </summary>
        /// <param name="parentNode"></param>
        public static void DeleteEmptyNode(TreeListNode parentNode)
        {
            //отыскиваем фиктивный нод в этой ветке, у которого Tag=strEmpty
            //и удаляем этот нод
            foreach (TreeListNode node in parentNode.Nodes)
            {
                if ((node.Tag != null) && (node.Tag.Equals(StrEmptyKey)))
                {
                    parentNode.Nodes.Remove(node);
                    break;
                }
            }
        }

        /// <summary>
        /// Размещает параметры в дереве
        /// </summary>
        /// <param name="parentTree"></param>
        /// <param name="parentNode"></param>
        /// <param name="rows"></param>
        /// <param name="useNationalLongName">Использовать ли в заголовке узла длинное национальное имя</param>
        public static void AppendParameterNodes(this TreeList parentTree, TreeListNode parentNode, FlexibleFormsDS.ParametersRow[] rows, bool useNationalLongName)
        {
            //размещаем все узлы
            foreach (var row in rows)
            {
                var node = parentTree.AppendNode(null, parentNode, row);
                node[0] = useNationalLongName ? row.NationalLongName : node[0] = row.NationalName;
                node.ImageIndex = node.SelectImageIndex = 2;
                //parentTree.SetNodeIndex(node, row.intOrder);
            }
            //удаляем узел <Empty>, если строк было больше нуля
            if (rows.Length > 0) DeleteEmptyNode(parentNode);
        }

        /// <summary>
        /// Размещает секции в дереве
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="parentTree"></param>
        /// <param name="parentNode"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsParentSection"></param>
        /// <param name="rowRules"></param>
        public static void AppendSectionNodes(this TreeList parentTree, DbService mainDbService, TreeListNode parentNode, long idfsFormTemplate, long? idfsParentSection, FlexibleFormsDS.RulesRow rowRules)
        {
            //TODO заменить на проверку в DataHelper?
            FlexibleFormsDS.SectionTemplateRow[] rows;
            if (!Utils.IsEmpty(idfsParentSection))
                rows = (FlexibleFormsDS.SectionTemplateRow[])mainDbService.MainDataSet.SectionTemplate.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "idfsParentSection", idfsParentSection));
            else
                rows = (FlexibleFormsDS.SectionTemplateRow[])mainDbService.MainDataSet.SectionTemplate.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "idfsParentSection", null));
            //размещаем все узлы
            foreach (var row in rows)
            {
                var node = parentTree.AppendNode(null, parentNode, row);
                node[0] = row.NationalName;
                SetImageForSectionType(row.blnGrid, node);
                //построим зависимые секции
                AppendSectionNodes(parentTree, mainDbService, node, idfsFormTemplate, row.idfsSection, rowRules);
                //построим зависимые параметры
                AppendParameterNodes(parentTree, mainDbService, node, idfsFormTemplate, row.idfsSection, rowRules);
            }
            parentNode.Expanded = true;
        }

        /// <summary>
        /// Размещает шаблоны в дереве
        /// </summary>
        /// <param name="treeTemplates"></param>
        /// <param name="parentNode"></param>
        /// <param name="rows"></param>
        public static void AppendTemplatesNodes(this TreeList treeTemplates, TreeListNode parentNode, FlexibleFormsDS.TemplatesRow[] rows)
        {
            //размещаем все узлы
            foreach (var row in rows)
            {
                var node = treeTemplates.AppendNode(null, parentNode, row);
                node[0] = row.NationalName;
                node.Tag = row;
                node.ImageIndex = node.SelectImageIndex = 3;
            }
            //удаляем узел <Empty>, если строк было больше нуля
            if (rows.Length > 0) DeleteEmptyNode(parentNode);
        }

        /// <summary>
        /// Размещает параметры в дереве
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="parentTree"></param>
        /// <param name="parentNode"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsSection"></param>
        /// <param name="rowRules"></param>
        public static void AppendParameterNodes(this TreeList parentTree, DbService mainDbService, TreeListNode parentNode, long idfsFormTemplate, long? idfsSection, FlexibleFormsDS.RulesRow rowRules)
        {
            FlexibleFormsDS.ParameterTemplateRow[] rows;
            if (!Utils.IsEmpty(idfsSection))
                rows = (FlexibleFormsDS.ParameterTemplateRow[])mainDbService.MainDataSet.ParameterTemplate.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "idfsSection", idfsSection));
            else
                rows = (FlexibleFormsDS.ParameterTemplateRow[])mainDbService.MainDataSet.ParameterTemplate.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplate, "idfsSection", null));
            
            //размещаем все узлы
            foreach (var row in rows)
            {
                var node = parentTree.AppendNode(null, parentNode, row);
                node[0] = row.NationalName;
                node[1] = GetRuleActionsText(mainDbService, rowRules, row);
                node.ImageIndex = node.SelectImageIndex = 2;
            }
            parentNode.Expanded = true;
        }

        /// <summary>
        /// Получает строку функции, которая соответствует правилу
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="rowRules"></param>
        /// <returns></returns>
        public static string GetRuleFunctionText(this DbService mainDbService, FlexibleFormsDS.RulesRow rowRules)
        {
            //формируем строку для отображения выбранной функции
            //заодно проверка правильного формирования функции
            var rowsArgs =
                    (FlexibleFormsDS.RuleParameterForFunctionRow[])
                    mainDbService.MainDataSet.RuleParameterForFunction.Select(
                        DataHelper.Filter("idfsRule", rowRules.idfsRule), "[intOrder] asc");
            string result = String.Empty;
            if ((rowsArgs.Length > 0) && (rowsArgs.Length <= 2))
            {
                //максимально может быть 2 параметра в функции
                var paramCaption = new string[2];
                var i = 0;
                foreach (var row in rowsArgs)
                {
                    //получаем заголовок параметра по его ID
                    var rowParameter = mainDbService.GetParameterRow(row.idfsParameter);
                    if (rowParameter != null)
                    {
                        paramCaption[i] = rowParameter.NationalName;
                    }

                    i++;
                }
                //определим маску правила
                var rowRuleFunction = (FlexibleFormsDS.RuleFunctionsRow[])mainDbService.MainDataSet.RuleFunctions.Select(DataHelper.Filter("idfsRuleFunction", rowRules.idfsRuleFunction));
                if (rowRuleFunction.Length == 1)
                {
                    //сформируем настоящий заголовок
                    result = String.Format(String.Format(rowRuleFunction[0].strMaskNational, paramCaption));
                    //если включено "НЕТ" для функции, то отобразим это
                    if (rowRules.blnNot)
                    {
                        result = String.Format("Not({0})", result);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Получает строку заголовка по действиям для правила, которые применяются к параметру
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="rowRules">Правило</param>
        /// <param name="rowParameterTemplate">Параметр, к которому применяются действия</param>
        /// <returns></returns>
        public static string GetRuleActionsText(this DbService mainDbService, FlexibleFormsDS.RulesRow rowRules, FlexibleFormsDS.ParameterTemplateRow rowParameterTemplate)
        {
            var result = new StringBuilder();

            var dvActions = LookupCache.Get(BaseReferenceType.rftFFRuleAction);
            //по всем действиям, касающимся данного параметра, соберём заголовки
            var rows =
                    (FlexibleFormsDS.RuleParameterForActionRow[])
                    mainDbService.MainDataSet.RuleParameterForAction.Select(
                    DataHelper.Filter("idfsRule", rowRules.idfsRule, "idfsParameter", rowParameterTemplate.idfsParameter));
            foreach (var row in rows)
            {
                var fltrRows = dvActions.Table.Select(DataHelper.Filter("idfsReference", row.idfsRuleAction));
                if (fltrRows.Length != 1) continue;
                if (result.Length > 0) result.Append(", ");
                result.Append(fltrRows[0]["Name"]);
                //result.Append(fltrRows[0]["strDefault"]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Обрабатывает нажатие KeyUp на дереве
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="e"></param>
        public static void ProcessKeyUpForTree(this TreeList tree, KeyEventArgs e)
        {
            if ((tree.Selection.Count == 1) && (tree.Selection[0].Nodes.Count > 0))
            {
                if (e.KeyCode.Equals(Keys.Right)) tree.Selection[0].Expanded = true;
                if (e.KeyCode.Equals(Keys.Left)) tree.Selection[0].Expanded = false;
            }
        }

        /// <summary>
        /// Отыскивает бэнд по имени
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bands"></param>
        /// <returns></returns>
        public static GridBand GetGridBandByName(string name, GridBandCollection bands)
        {
            GridBand gridBand = null;
            foreach (GridBand band in bands)
            {
                if (band.Name.Equals(name))
                {
                    gridBand = band;
                    break;
                }
            }

            return gridBand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static bool IsRowAlive(this DataRow dataRow)
        {
            return (!dataRow.RowState.Equals(DataRowState.Deleted) && !dataRow.RowState.Equals(DataRowState.Detached));
        }

        /// <summary>
        /// Рекурсивно отыскивает нод, тэг которого совпадает с образцом
        /// </summary>
        /// <param name="templateNode"></param>
        /// <param name="sample"></param>
        /// <returns></returns>
        public static TreeListNode GetNodeMatch(this TreeListNode templateNode, object sample)
        {
            TreeListNode result = null;

            for (int i = 0; i < templateNode.Nodes.Count; i++)
            {
                var node = templateNode.Nodes[i];
                if (node.Tag.Equals(sample))
                {
                    result = node;
                    break;
                }
                result = GetNodeMatch(node, sample);
                if (result != null) break;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="listNodes"></param>
        public static void CollectExpandedNodes(this TreeListNode parentNode, List<TreeListNode> listNodes)
        {
            if (parentNode.Expanded) listNodes.Add(parentNode);
            foreach (TreeListNode childNode in parentNode.Nodes)
            {
                CollectExpandedNodes(childNode, listNodes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="listNodes"></param>
        public static void CollapseNodes(this TreeListNode parentNode, List<TreeListNode> listNodes)
        {
            if (!listNodes.Contains(parentNode)) parentNode.Expanded = false;
            foreach (TreeListNode childNode in parentNode.Nodes)
            {
                CollapseNodes(childNode, listNodes);
            }
        }

        /// <summary>
        /// Проверяет, используется ли параметр в экшене правила
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="parameterTemplateRow"></param>
        /// <param name="ruleNames"></param>
        /// <returns></returns>
        public static bool IsParameterUseInAction(this DbService mainDbService, FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow, out string ruleNames)
        {
            ruleNames = String.Empty;

            //если параметр участвует в каком-либо экшене правила, то его удалять нельзя
            var actionRows =
                mainDbService.GetRuleParameterForAction(parameterTemplateRow.idfsFormTemplate, parameterTemplateRow.idfsParameter);
            if (actionRows.Length > 0)
            {
                //собираем названия правил, где используется удаляемый параметр
                var stringBuilder = new StringBuilder();
                foreach (var row in actionRows)
                {
                    var rulesRow = DataHelper.GetRule(mainDbService, row.idfsRule);
                    if (rulesRow == null) continue;
                    if (!IsRowAlive(rulesRow)) continue;
                    if (!stringBuilder.ToString().Contains(rulesRow.NationalName))
                    {
                        if (stringBuilder.Length > 0) stringBuilder.Append(", ");
                        stringBuilder.Append(String.Format("'{0}'", rulesRow.NationalName));
                    }
                }
                ruleNames = stringBuilder.ToString();
            }

            return ruleNames.Length > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterHost"></param>
        /// <returns></returns>
        public static FlexibleFormsDS.ParameterTemplateRow GetParameterTemplateRow(this ParameterHost parameterHost)
        {
            FlexibleFormsDS.ParameterTemplateRow result = null;

            var parameter = parameterHost as Parameter;
            var sectionTable = parameterHost as SectionTable;
            if ((parameter == null) && (sectionTable == null)) return result;
            if (parameter != null)
            {
                result = parameter.ParameterTemplateRow;
            }
            else
            {
                if (sectionTable.SelectedBand != null)
                {
                    result = sectionTable.SelectedBand.Tag as FlexibleFormsDS.ParameterTemplateRow;
                }
            }

            return result;
        }

        /// <summary>
        /// В указанном типе формы отыскивает шаблоны, содержащие указанный детерминант
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsDeterminantValue"></param>
        /// <param name="ffType"></param>
        /// <param name="onlyUNI">Нужно ли оставлять только UNI шаблоны. Если false, то остаются все</param>
        /// <returns></returns>
        public static List<FlexibleFormsDS.TemplateDeterminantValuesRow> GetTemplateWithSameDeterminant(this DbService mainDbService, long idfsDeterminantValue, long ffType, bool onlyUNI)
        {
            var templateDeterminants = mainDbService.GetFFTypeDeterminants(ffType);
            var templates = new List<FlexibleFormsDS.TemplateDeterminantValuesRow>();
            foreach (var templateDeterminantValuesRow in templateDeterminants)
            {
                if (!templateDeterminantValuesRow.DeterminantValue.Equals(idfsDeterminantValue)) continue;
                
                //если нужно проверять на UNI
                if (onlyUNI)
                {
                    var template = mainDbService.GetTemplateRow(templateDeterminantValuesRow.idfsFormTemplate);
                    if ((template != null) && (!template.blnUNI)) continue;
                }
                templates.Add(templateDeterminantValuesRow);
            }
            return templates;
        }

        /// <summary>
        /// Находит в указанном типе формы UNI шаблон, который либо не имеет детерминантов типа страна, либо имеет детерминант = текущей стране
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templatesRow"></param>
        /// <returns></returns>
        public static bool GetTemplateInFFTypeWithUNICredentionals(this DbService mainDbService, FlexibleFormsDS.TemplatesRow templatesRow)
        {
            return GetTemplateInFFTypeWithUNICredentionals(mainDbService, templatesRow, true);
        }

        /// <summary>
        /// Находит в указанном типе формы UNI шаблон, который либо не имеет детерминантов типа страна, либо имеет детерминант = текущей стране
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templatesRow"></param>
        /// <param name="checkTemplate">Нужно ли включить в цикл проверки сам шаблон, который передаётся аргументом</param>
        /// <returns></returns>
        public static bool GetTemplateInFFTypeWithUNICredentionals(this DbService mainDbService, FlexibleFormsDS.TemplatesRow templatesRow, bool checkTemplate)
        {
            var templates = mainDbService.GetTemplatesByFormType(templatesRow.idfsFormType);
            var finded = false;
            foreach (var tmpl in templates)
            {
                if (!tmpl.blnUNI) continue;
                if (checkTemplate && templatesRow.idfsFormTemplate.Equals(tmpl.idfsFormTemplate)) continue;
                if (
                    (mainDbService.GetTemplateDeterminants(tmpl.idfsFormTemplate, FFDeterminantTypes.Country).Length == 0)
                    ||
                    (mainDbService.HasTemplateDeterminant(tmpl.idfsFormTemplate, eidss.model.Core.EidssSiteContext.Instance.CountryID))
                    )
                {
                    finded = true;
                    break;
                }
            }
            return finded;
        }

        /// <summary>
        /// Создаёт комбинации детерминантов шаблона, преобразовывая их в уникальные строки
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templatesRow"></param>
        /// <param name="determinantValue"></param>
        /// <param name="addDeterminant">Если null, то другие параметры для доб/уд детерм. игнорируются</param>
        /// <param name="determinantType"></param>
        /// <returns></returns>
        public static List<string> CreateDeterminantCombinations(DbService mainDbService, FlexibleFormsDS.TemplatesRow templatesRow, long determinantValue, bool? addDeterminant, FFDeterminantTypes determinantType)
        {
            //валидные комбинации: страна, страна+диагноз, страна+тест

            var result = new List<string>();

            //получаем перечень детерминантов
            var countries = mainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate, FFDeterminantTypes.Country);
            var diagnoses = mainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate, FFDeterminantTypes.Diagnosis);
            var tests = mainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate, FFDeterminantTypes.Test);
            var vectors = mainDbService.GetTemplateDeterminants(templatesRow.idfsFormTemplate, FFDeterminantTypes.VectorType);

            var countryList = countries.Select(country => country.DeterminantValue).ToList();
            var diagnosesList = diagnoses.Select(diagnosis => diagnosis.DeterminantValue).ToList();
            var testsList = tests.Select(test => test.DeterminantValue).ToList();
            var vectorsList = vectors.Select(vector => vector.DeterminantValue).ToList();
            
            if (addDeterminant.HasValue)
            {
                if (addDeterminant.Value)
                {
                    if (determinantType.Equals(FFDeterminantTypes.Country)) countryList.Add(determinantValue);
                    else if (determinantType.Equals(FFDeterminantTypes.Diagnosis)) diagnosesList.Add(determinantValue);
                    else if (determinantType.Equals(FFDeterminantTypes.Test)) testsList.Add(determinantValue);
                    else if (determinantType.Equals(FFDeterminantTypes.VectorType)) vectorsList.Add(determinantValue);
                }
                else
                {
                    if (determinantType.Equals(FFDeterminantTypes.Country)) countryList.Remove(determinantValue);
                    else if (determinantType.Equals(FFDeterminantTypes.Diagnosis)) diagnosesList.Remove(determinantValue);
                    else if (determinantType.Equals(FFDeterminantTypes.Test)) testsList.Remove(determinantValue);
                    else if (determinantType.Equals(FFDeterminantTypes.VectorType)) vectorsList.Remove(determinantValue);
                }
            }

            //без стран построение комбинаций производить нельзя (непонятно почему 12.05.2011, теперь можно)
            if (countryList.Count > 0)
            {
                foreach (var country in countryList)
                {
                    var idCountry = country;

                    //страна как единственный детерминант нужна только если нет других типов детерминантов у этого шаблона (Паша, 17.01.2011)
                    if ((diagnosesList.Count == 0) && (testsList.Count == 0))
                    {
                        result.Add(CombinationString(country, null));
                    }

                    result.AddRange(diagnosesList.Select(diagnosis => CombinationString(idCountry, diagnosis)));
                    result.AddRange(testsList.Select(test => CombinationString(idCountry, test)));
                    result.AddRange(vectorsList.Select(vector => CombinationString(idCountry, vector)));
                }
            }
            else
            {
                result.AddRange(diagnosesList.Select(diagnosis => CombinationString(diagnosis, null)));
                result.AddRange(testsList.Select(test => CombinationString(test, null)));
                result.AddRange(vectorsList.Select(vector => CombinationString(vector, null)));
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfDeterminantValue1"></param>
        /// <param name="idfDeterminantValue2"></param>
        /// <returns></returns>
        private static string CombinationString(long idfDeterminantValue1, long? idfDeterminantValue2)
        {
            return String.Format("{0}|{1}", idfDeterminantValue1, idfDeterminantValue2.HasValue ? idfDeterminantValue2.Value.ToString() : String.Empty);
        }

        /// <summary>
        /// Проверяет парами детерминанты у двух шаблонов
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templatesRow">Редактируемый шаблон</param>
        /// <param name="determinantValue">Дополнительный детерминант, который предполагается добавить/удалить в редактируемый шаблон</param>
        /// <param name="addDeterminant">true-доп.детерм. добавляется, false - удаляется</param>
        /// <param name="determinantType"></param>
        /// <param name="errStr">Строка ошибки, если таковая возникла</param>
        /// <returns>true -- если все правильно, false -- если есть совпадения</returns>
        public static bool CheckValidDeterminantCombinations(this DbService mainDbService, FlexibleFormsDS.TemplatesRow templatesRow, long determinantValue, bool? addDeterminant, FFDeterminantTypes determinantType, out string errStr)
        {
            errStr = String.Empty;
            //получим комбинации для редактируемого шаблона
            var temp1 = CreateDeterminantCombinations(mainDbService, templatesRow, determinantValue, addDeterminant, determinantType);
            
            //проходим по всем шаблонам в этом же типе формы и выявляем совпадения пар детерминантов
            var templates = mainDbService.GetTemplatesByFormType(templatesRow.idfsFormType);
            foreach (var template in templates)
            {
                if (templatesRow.idfsFormTemplate.Equals(template.idfsFormTemplate)) continue;
                var temp2 = CreateDeterminantCombinations(mainDbService, template, determinantValue, null, FFDeterminantTypes.Test); //параметры игнорируются
                if (temp1.Count > 0)
                {
                    foreach (var s in temp2)
                    {
                        if (temp1.Contains(s) /*&& templatesRow.blnUNI.Equals(template.blnUNI)*/)
                        {
                            errStr =String.Format(EidssMessages.Get("TemplateDeterminant_Have_Equal_Combinations_Determinants"), templatesRow.NationalName, template.NationalName);
                            return false;
                        }
                    }
                }
                else
                {
                    if ((temp2.Count == 0) && templatesRow.blnUNI.Equals(template.blnUNI))
                    {
                        errStr = String.Format(EidssMessages.Get("TemplateDeterminant_Have_Equal_Combinations_Determinants"), templatesRow.NationalName, template.NationalName);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detType"></param>
        /// <returns></returns>
        public static FFDeterminantTypes GetDeterminantType(long detType)
        {
            var result = FFDeterminantTypes.Country;
            switch (detType)
            {
                case 19000001:
                    result = FFDeterminantTypes.Country;
                    break;
                case 19000019:
                    result = FFDeterminantTypes.Diagnosis;
                    break;
                case 19000097:
                    result = FFDeterminantTypes.Test;
                    break;
                case 19000140:
                    result = FFDeterminantTypes.VectorType;
                    break;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static List<string> ParseToStringList(this IEnumerable<long> inputList)
        {
            const int parseLength = 3900;

            var resultList = new List<string>();

            var sb = new StringBuilder();
            foreach (long l in inputList)
            {
                if (l.ToString().Length + sb.Length > parseLength)
                {
                    resultList.Add(sb.ToString());
                    sb = new StringBuilder();
                }
                sb.AppendFormat("{0};", l);
            }
            resultList.Add(sb.ToString());

            return resultList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static TreeListNode FindNode(this TreeListNodes nodes, string nodeName)
        {
            TreeListNode result = null;
            foreach (TreeListNode node in nodes)
            {
                string thisNode = node[0].ToString().Trim().ToUpperInvariant();
                string ss = nodeName.Trim().ToUpperInvariant();

                //в результат помещаем только если полностью совпадает текст
                if (thisNode.Equals(ss))
                {
                    result = node;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool GetInt32(object value, out Int32 i)
        {
            i = 0;
            if (value == null) return false;
            Int32.TryParse(value.ToString(), out i);
            return true;
        }

        /// <summary>
        /// Расставляет объектам TabIndex
        /// </summary>
        /// <param name="parametersDictionary"></param>
        /// <param name="sectionsDictionary"></param>
        public static void SetTabIndex(Dictionary<long, Parameter> parametersDictionary, Dictionary<long, Section> sectionsDictionary)
        {
            //var controls
            var controls = new List<ParameterHost>();
            controls.AddRange(parametersDictionary.Keys.Select(key => parametersDictionary[key]));
            controls.AddRange(sectionsDictionary.Keys.Select(key => sectionsDictionary[key]));
            var comparer = new ParameterHost.Comparer();
            controls.Sort(comparer);
            for (var i = 0; i < controls.Count; i++)
            {
                controls[i].TabIndex = i;
            }
        }
    }
}
