using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using System.Linq;

namespace eidss.model.Model.FlexibleForms.FlexNodes
{
    public class FlexNode
    {
        private readonly FlexNode m_ParentNode;
        private readonly FlexItem m_DataItem;
        private readonly int m_Level;
        private readonly EditableList<ActivityParameter> m_ActivityParameters;
        private readonly FFPresenterModel m_Model;

        private readonly List<FlexNode> m_ChildList = new List<FlexNode>();

        public void DeleteNode(FlexNode node)
        {
            m_ChildList.Remove(node);
        }

        /// <summary>
        /// Порядок этого узла среди соседей внутри родительского узла
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Нужно ли при выводе заголовков использовать рекурсивные пути
        /// </summary>
        public bool UseFullPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ChildListCount
        {
            get { return m_ChildList != null ? m_ChildList.Count : 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="ffObject"></param>
        /// <param name="activityParameters"></param>
        /// <param name="model"></param>
        public FlexNode(FlexNode parentNode, FlexItem ffObject, EditableList<ActivityParameter> activityParameters, FFPresenterModel model)
        {
            m_ParentNode = parentNode;
            m_DataItem = ffObject;
            m_Level = (parentNode == null) ? 0 : parentNode.Level + 1;
            m_ActivityParameters = activityParameters;
            m_Model = model;
            UseFullPath = false;
            idfRow = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        public FFPresenterModel FFModel
        {
            get { return m_Model; }
        }

        /// <summary>
        /// 
        /// </summary>
        public EditableList<ActivityParameter> ActivityParameters { get { return m_ActivityParameters; } }
        
        /// <summary>
        /// Parent of current node
        /// </summary>
        public FlexNode ParentNode
        {
            get { return m_ParentNode; }
        }

        /// <summary>
        /// collection of child nodes
        /// </summary>
        public IEnumerable<FlexNode> ChildList
        {
            get { return m_ChildList.AsReadOnly(); }
        }

        public FlexNode GetItem(int index)
        {
            return (index >= 0 && index <= m_ChildList.Count - 1) ? m_ChildList[index] : null;
        }

        public int Level
        {
            get { return m_Level; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSection()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is SectionTemplate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSectionTable()
        {
            return (IsSection() && GetSectionTemplate().blnGrid);
        }

        /// <summary>
        /// Определяет, является ли кто-то из предков этого узла табличной секцией
        /// </summary>
        /// <returns></returns>
        public bool IsSectionTableChild()
        {
            if (ParentNode == null) return false;
            return ParentNode.IsSectionTable() || ParentNode.IsSectionTableChild();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsParameter()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is ParameterTemplate));
        }

        /// <summary>
        /// Является ли это вспомогательным столбцом
        /// </summary>
        /// <returns></returns>
        public bool IsServiceColumn()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is Int32));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsPredefinedStub()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is PredefinedStub));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsLabel()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is Label));
        }

        public bool IsString()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is String));
        }

        public bool IsParametersDeletedFromTemplate()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is ParametersDeletedFromTemplate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsLine()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is Line));
        }

        private long? m_IdfRow;
        public long? idfRow
        {
            get { return m_IdfRow; }
            set
            {
                m_IdfRow = value;
                SetIdfRowToChildren(m_IdfRow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfrow"></param>
        private void SetIdfRowToChildren(long? idfrow)
        {
            foreach (var node in ChildList)
            {
                node.idfRow = idfrow;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get 
            { 
                var result = String.Empty;
                if (IsSection())
                {
                    result = GetSectionTemplate().NationalName;
                }
                else if (IsParameter())
                {
                    result = GetParameterTemplate().NationalName;
                }
                else if (IsPredefinedStub())
                {
                    result = GetPredefinedStub().strDefaultParameterName;
                }
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            get
            {
                int? width = 0;
                if (IsSection())
                {
                    width = GetSectionTemplate().intWidth;
                }
                else if (IsParameter())
                {
                    width = GetParameterTemplate().intWidth;
                }
                else if (IsPredefinedStub())
                {
                    //TODO надо ли какую-то особую величину для колонок боковика вычислять. Как именно?
                    width = PredefinedStubWidth; //GetPredefinedStub();
                }
                else if (IsServiceColumn())
                {
                    width = ServiceColumnWidth;
                }
                return width.HasValue ? width.Value : 0;
            }
        }

        public static int PredefinedStubWidth { get { return 80; } }

        public static int ServiceColumnWidth { get { return 25; } }

        /// <summary>
        /// Координаты расположения контрола, который описывается этим узлом
        /// </summary>
        public Point Coord
        {
            get
            {
                var result = new Point(0, 0);
                if (IsSection())
                {
                    var t = GetSectionTemplate();
                    if (t.intLeft.HasValue && t.intTop.HasValue)
                        result = new Point(t.intLeft.Value, t.intTop.Value);
                }
                else if (IsParameter())
                {
                    var t = GetParameterTemplate();
                    result = new Point(t.intLeft, t.intTop);
                }
                else if (IsLabel())
                {
                    var t = GetLabel();
                    result = new Point(t.intLeft, t.intTop);
                }
                //для боковиков нет координат (они не нужны)
                return result;
            }
        }
        
        public ParameterTemplate GetParameterTemplate()
        {
            return IsParameter() ? (ParameterTemplate) DataItem.LinkedObject : null;
        }

        public ParametersDeletedFromTemplate GetParametersDeletedFromTemplate()
        {
            return DataItem.LinkedObject as ParametersDeletedFromTemplate;
        }
        
        public PredefinedStub GetPredefinedStub()
        {
            return IsPredefinedStub() ? (PredefinedStub)DataItem.LinkedObject : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActivityParameter GetParameterValue()
        {
            ActivityParameter result = null;
            if ((ActivityParameters != null) && (ActivityParameters.Count > 0))
            {
                long idfsParameter = 0;
                long idfsFormTemplate = 0;

                var parameter = GetParameterTemplate();
                if (parameter != null)
                {
                    idfsParameter = parameter.idfsParameter;
                    idfsFormTemplate = parameter.idfsFormTemplate;
                }
                else
                {
                    var deletedParameter = GetParametersDeletedFromTemplate();
                    if ((deletedParameter != null) && (deletedParameter.idfsFormTemplate.HasValue))
                    {
                        idfsParameter = deletedParameter.idfsParameter;
                        idfsFormTemplate = deletedParameter.idfsFormTemplate.Value;
                    }
                }

                if ((idfsParameter > 0) && (idfsFormTemplate > 0))
                {
                    result =
                        idfRow > 0 ?
                        ActivityParameters.FirstOrDefault(
                            m =>
                            ((m.idfsParameter == idfsParameter) 
                             &&(m.idfsFormTemplate == idfsFormTemplate))
                             &&(m.idfRow == idfRow)) :
                        ActivityParameters.FirstOrDefault(
                            m =>
                            ((m.idfsParameter == idfsParameter) &&
                             (m.idfsFormTemplate == idfsFormTemplate)));
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SectionTemplate GetSectionTemplate()
        {
            return IsSection() ? (SectionTemplate)DataItem.LinkedObject : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Label GetLabel()
        {
            return IsLabel() ? (Label)DataItem.LinkedObject : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int CompareFlexNodes(FlexNode node1, FlexNode node2)
        {
            int result = 0;
            if (node1.DataItem.Order < node2.DataItem.Order)
            {
                result = -1;
            }
            else if (node1.DataItem.Order > node2.DataItem.Order)
            {
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int CompareFlexNodesRecursive(FlexNode node1, FlexNode node2)
        {
            //если узлы одного уровня (они всегда при сортировке одного уровня вложенности) лежат в табличной
            //секции, то сортируем по Order, иначе -- по координатам.
            //var diff = node1.Order - node2.Order;
            //return diff != 0 ? diff : node1.Coord.Y - node2.Coord.Y;
            return node2.IsSectionTableChild() ? node1.Order - node2.Order : node1.Coord.Y - node2.Coord.Y;
        }

        /// <summary>
        /// Сортирует дочерние элементы по порядку (Data.Order)
        /// </summary>
        public void Sort()
        {
            m_ChildList.Sort(CompareFlexNodes);
        }

        /// <summary>
        /// Сортирует дочерние элементы по порядку (Order)
        /// </summary>
        public void SortRecursive()
        {
            m_ChildList.Sort(CompareFlexNodesRecursive);
            foreach (var node in m_ChildList)
            {
                node.m_ChildList.Sort(CompareFlexNodesRecursive);
                node.SortRecursive();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_ChildList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRoot
        {
            get { return ParentNode == null; }
        }

        /// <summary>
        /// data item stored in current node
        /// </summary>
        public FlexItem DataItem
        {
            get { return m_DataItem; }
        }

        public FlexNode this[int index]
        {
            get { return m_ChildList[index]; }
            set { m_ChildList[index] = value; }
        }

        /// <summary>
        /// Ключ, которым нужно маркировать параметры
        /// </summary>
        public string FormKey { get; set; }

        //TODO сделать добавление для лейблов и линий(?)

        //public void Add(FlexibleFormsDS.LinesRow row)
        //{
        //    FlexLineItem item = new FlexLineItem(row);
        //    mChildList.Add(new FlexNode(this, item));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="row"></param>
        //public void Add(FlexibleFormsDS.LabelsRow row)
        //{
        //    FlexLabelItem item = new FlexLabelItem(row);
        //    mChildList.Add(new FlexNode(this, item));
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffObject"></param>
        /// <param name="activityParameters"></param>
        /// <param name="index">Индекс для вставки</param>
        /// <param name="model"></param>
        public FlexNode Add(object ffObject, EditableList<ActivityParameter> activityParameters, int index, FFPresenterModel model)
        {
            var flexNode = new FlexNode(this, new FlexItem(ffObject), activityParameters, model);
            if (index == -1)
            {
                m_ChildList.Add(flexNode);
            }
            else
            {
                m_ChildList.Insert(0, flexNode);
            }
            return flexNode;
        }

        public void Add(FlexNode node, int index = -1)
        {
            if (index == -1)
            {
                m_ChildList.Add(node);
            }
            else
            {
                m_ChildList.Insert(0, node);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffObject"></param>
        /// <param name="activityParameters"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public FlexNode Add(object ffObject, EditableList<ActivityParameter> activityParameters, FFPresenterModel model)
        {
            return Add(ffObject, activityParameters, -1, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffObject"></param>
        /// <param name="model"></param>
        public FlexNode Add(object ffObject, FFPresenterModel model)
        {
            return Add(ffObject, null, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffObject"></param>
        /// <param name="index"></param>
        /// <param name="model"></param>
        public FlexNode Insert(object ffObject, int index, FFPresenterModel model)
        {
            return Add(ffObject, null, index, model);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="rowParameter"></param>
        ///// <param name="isParameterInSection"></param>
        //public FlexNode Add(FlexibleFormsDS.ParametersDeletedFromTemplateRow rowParameter, bool isParameterInSection)
        //{
        //    FlexLabelItem rowParameterItem = new FlexLabelItem(rowParameter, isParameterInSection);
        //    //пересчитываем правильно его координаты
        //    //отыщем среди них самый нижний (вложенные не учитываем)
        //    int top;
        //    int height;
        //    GetCorrectSize(mChildList, out top, out height);
        //    rowParameterItem.Top = top + height + 10;
        //    FlexNode result = new FlexNode(this, rowParameterItem);
        //    mChildList.Add(result);
        //    return result;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="parameterTemplateRow"></param>
        ///// <param name="activityParametersRow"></param>
        //public void Add(FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow, FlexibleFormsDS.ActivityParametersRow activityParametersRow)
        //{
        //    Add(parameterTemplateRow, false);

        //    FlexLabelItem parametersItem = new FlexLabelItem(parameterTemplateRow, activityParametersRow);
        //    parametersItem.IsParameterValue = true;
        //    FlexNode nodeAP = new FlexNode(this, parametersItem);
        //    //нод, который отвечает за контрол, выводится с фиксированной высотой
        //    BaseEdit control = Parameter.GetControlParameter(ParameterControlTypeHelper.ConvertToParameterControlType(parameterTemplateRow.idfsEditor));
        //    nodeAP.DataItem.Height = control.Height;
        //    mChildList.Add(nodeAP);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="rowParameter"></param>
        ///// <param name="activityParametersRow"></param>
        ///// <param name="size"></param>
        //public void Add(FlexibleFormsDS.ParametersDeletedFromTemplateRow rowParameter, FlexibleFormsDS.ActivityParametersRow activityParametersRow, out Size size)
        //{
        //    FlexNode node = Add(rowParameter, false);

        //    FlexLabelItem parametersItem = new FlexLabelItem(rowParameter, activityParametersRow);
        //    parametersItem.IsParameterValue = true;
        //    parametersItem.Top = node.DataItem.Top;
        //    FlexNode nodeAP = new FlexNode(this, parametersItem);
        //    mChildList.Add(nodeAP);
        //    //нод, который отвечает за контрол, выводится с фиксированной высотой
        //    BaseEdit control = Parameter.GetControlParameter(ParameterControlTypeHelper.ConvertToParameterControlType(rowParameter.idfsEditor));
        //    nodeAP.DataItem.Height = control.Height;
        //    size = new Size(rowParameter.intWidth, rowParameter.intHeight);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="flexNodes"></param>
        ///// <param name="top"></param>
        ///// <param name="height"></param>
        //private void GetCorrectSize(List<FlexNode> flexNodes, out int top, out int height)
        //{
        //    top = height = 0;
        //    //отыщем среди них самый нижний (вложенные не учитываем)
        //    for (int i = 0; i < flexNodes.Count; i++)
        //    {
        //        if (top < flexNodes[i].DataItem.Top)
        //        {
        //            top = flexNodes[i].DataItem.Top;
        //            height = flexNodes[i].DataItem.Height;
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FlexNode CreateRoot()
        {
            return new FlexNode(null, null, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if ((DataItem != null) && (DataItem.LinkedObject != null))
            {
                sb.Append(String.Format("Type: {0}; ", DataItem.LinkedObject.GetType()));
                if (DataItem.LinkedObject is SectionTemplate)
                {
                    sb.Append(String.Format("Name: {0}; ", ((SectionTemplate) DataItem.LinkedObject).NationalName));
                }
                else if (DataItem.LinkedObject is ParameterTemplate)
                {
                    sb.Append(String.Format("Name: {0}; ", ((ParameterTemplate) DataItem.LinkedObject).NationalName));
                }
                sb.Append(String.Format("Count: {0}; ", Count));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Возвращает перечень параметров, которые лежат в секции (если этот узел -- секция). Поиск рекурсивен.
        /// </summary>
        /// <returns></returns>
        public List<ParameterTemplate> GetParameterTemplateForDataTable()
        {
            var result = new List<ParameterTemplate>();
            var paramList = GetParameterTemplateNodesForDataTable();

            foreach (var node in paramList)
            {
                var parameter = node.GetParameterTemplate();
                if (parameter != null) result.Add(parameter);
            }
            
            return result;
        }

        /// <summary>
        /// Возвращает перечень параметров, которые лежат в секции (если этот узел -- секция). Поиск рекурсивен.
        /// </summary>
        /// <returns></returns>
        public List<FlexNode> GetParameterTemplateNodesForDataTable()
        {
            var result = new List<FlexNode>();
            var section = GetSectionTemplate();
            if (section != null)
            {
                foreach (var flexNode in ChildList)
                {
                    var parameter = flexNode.GetParameterTemplate();
                    if (parameter != null)
                    {
                        result.Add(flexNode);
                    }

                    if (flexNode.ChildListCount > 0)
                    {
                        result.AddRange(flexNode.GetParameterTemplateNodesForDataTable());
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTotalWidth()
        {
            var parameters = GetParameterTemplateForDataTable();
            var predefinedStubs = GetPredefinedStubsForDataTable();

            var sum = 0;
            foreach (var parameter in parameters)
            {
                if (FFModel.IsSummary && !parameter.IsParameterNumeric())continue;
                sum += parameter.intWidth;
            }

            return predefinedStubs.Sum(predefinedStub => PredefinedStubWidth) + sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTotalColumnsCount()
        {
            var parameters = GetParameterTemplateForDataTable();
            var predefinedStubsCount = GetPredefinedStubsForDataTable().Count;

            var count = 0;
            foreach (var parameter in parameters)
            {
                if (FFModel.IsSummary && !parameter.IsParameterNumeric()) continue;
                count++;
            }

            return predefinedStubsCount + count;
        }
        
        /// <summary>
        /// Возвращает перечень параметров, которые лежат в секции (если этот узел -- секция)
        /// </summary>
        /// <returns></returns>
        public List<PredefinedStub> GetPredefinedStubsForDataTable()
        {
            var result = new List<PredefinedStub>();
            var section = GetSectionTemplate();
            if (section != null)
            {
                foreach (var flexNode in ChildList)
                {
                    var predefinedStub = flexNode.GetPredefinedStub();
                    if (predefinedStub != null)
                    {
                        result.Add(predefinedStub);
                    }

                    if (flexNode.ChildListCount > 0)
                    {
                        result.AddRange(flexNode.GetPredefinedStubsForDataTable());
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Определяет, имеются ли среди вложенных объектов секции
        /// </summary>
        public bool HasSectionChildren
        {
            get {return ChildList.Any(child => child.IsSection() && (child != this));}
        }

        /// <summary>
        /// Определяет, имеются ли среди соседних объектов секции
        /// </summary>
        public bool HasSectionSiblings
        {
            get{return ParentNode != null && ParentNode.HasSectionChildren;}
        }

        /// <summary>
        /// Определяет, имеются ли среди вложенных объектов фиксированные столбцы
        /// </summary>
        public bool HasStubChildren
        {
            get { return ChildList.Any(child => child.IsPredefinedStub()); }
        }
    }
}