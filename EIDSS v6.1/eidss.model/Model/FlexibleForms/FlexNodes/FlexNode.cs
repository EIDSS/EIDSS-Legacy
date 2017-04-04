using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using System.Linq;
using eidss.model.Model.Report;

namespace eidss.model.Model.FlexibleForms.FlexNodes
{
    public class FlexNode : FlexNodeBase
    {
        private readonly EditableList<ActivityParameter> m_ActivityParameters;
        private readonly FFPresenterModel m_Model;

        /// <summary>
        /// Нужно ли при выводе заголовков использовать рекурсивные пути
        /// </summary>
        public bool UseFullPath { get; set; }

        //protected new List<FlexNode> ChildList { get; set; }

        public FlexNode(FlexNode parentNode, FlexItem ffObject, EditableList<ActivityParameter> activityParameters, FFPresenterModel model)
            : base(parentNode, ffObject)
        {
            m_ActivityParameters = activityParameters;
            m_Model = model;
            UseFullPath = false;
            idfRow = -1;
        }
       
        public FFPresenterModel FFModel
        {
            get { return m_Model; }
        }
        
        public EditableList<ActivityParameter> ActivityParameters { get { return m_ActivityParameters; } }
        

        public bool IsSection()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is SectionTemplate));
        }

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
            var pn = (FlexNode) ParentNode;
            return pn.IsSectionTable() || pn.IsSectionTableChild();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsParameter()
        {
            return (DataItem != null && DataItem.LinkedObject is ParameterTemplate);
        }

        public bool IsParametersDeletedFromTemplate()
        {
            return (DataItem != null && DataItem.LinkedObject is ParametersDeletedFromTemplate);
        }

        /// <summary>
        /// Является ли это вспомогательным столбцом
        /// </summary>
        /// <returns></returns>
        public bool IsServiceColumn()
        {
            return (DataItem != null && DataItem.LinkedObject is Int32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsPredefinedStub()
        {
            return (DataItem != null && DataItem.LinkedObject is PredefinedStub);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsLabel()
        {
            return (DataItem != null && DataItem.LinkedObject is Label);
        }

        public bool IsString()
        {
            return (DataItem != null && DataItem.LinkedObject is SectionDeletedFromTemplate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsLine()
        {
            return (DataItem != null && DataItem.LinkedObject is Line);
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
        
        private void SetIdfRowToChildren(long? idfrow)
        {
            foreach (var node in ChildList)
            {
                ((FlexNode)node).idfRow = idfrow;
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

        public int Height
        {
            get
            {
                int ret = 0;
                if (IsSection())
                {
                    ret = GetSectionTemplate().Height;
                }
                else if (IsParameter())
                {
                    ret = GetParameterTemplate().intHeight;
                }
                else if (IsString())
                {
                    ret = GetSectionDeletedFromTemplate().Height;
                }
                else if (IsParametersDeletedFromTemplate())
                {
                    ret = GetParametersDeletedFromTemplate().intHeight;
                }
                return ret;
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

        public SectionDeletedFromTemplate GetSectionDeletedFromTemplate()
        {
            return IsString() ? (SectionDeletedFromTemplate)DataItem.LinkedObject : null;
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
        /// Сортирует дочерние элементы по порядку (Order)
        /// </summary>
        public void SortRecursive()
        {
            var lst = new List<FlexNode>();
            foreach (var node in ChildList)
            {
                lst.Add((FlexNode)node);
            }

            lst.Sort(CompareFlexNodesRecursive);
            foreach (var node in lst)
            {
                var lstInner = new List<FlexNode>();
                foreach (var nodeInner in node.ChildList)
                {
                    lstInner.Add((FlexNode)nodeInner);
                }
                lstInner.Sort(CompareFlexNodesRecursive);
                node.SortRecursive();
            }
            ChildList.Clear();
            ChildList.AddRange(lst);
        }

        public static int CompareFlexNodesRecursive(FlexNode node1, FlexNode node2)
        {
            //если узлы одного уровня (они всегда при сортировке одного уровня вложенности) лежат в табличной
            //секции, то сортируем по Order, иначе -- по координатам.
            //var diff = node1.Order - node2.Order;
            //return diff != 0 ? diff : node1.Coord.Y - node2.Coord.Y;
            return node2.IsSectionTableChild() ? node1.Order - node2.Order : node1.Coord.Y - node2.Coord.Y;
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
                ChildList.Add(flexNode);
            }
            else
            {
                ChildList.Insert(0, flexNode);
            }
            return flexNode;
        }
       
        public FlexNode Add(object ffObject, EditableList<ActivityParameter> activityParameters, FFPresenterModel model)
        {
            return Add(ffObject, activityParameters, -1, model);
        }
        
        public FlexNode Add(object ffObject, FFPresenterModel model)
        {
            return Add(ffObject, null, model);
        }
       
        public FlexNode Insert(object ffObject, int index, FFPresenterModel model)
        {
            return Add(ffObject, null, index, model);
        }
        
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
                    var fn = (FlexNode) flexNode;
                    var parameter = fn.GetParameterTemplate();
                    if (parameter != null)
                    {
                        result.Add(fn);
                    }

                    if (flexNode.ChildListCount > 0)
                    {
                        result.AddRange(fn.GetParameterTemplateNodesForDataTable());
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
                    var fn = (FlexNode)flexNode;
                    var predefinedStub = fn.GetPredefinedStub();
                    if (predefinedStub != null)
                    {
                        result.Add(predefinedStub);
                    }

                    if (flexNode.ChildListCount > 0)
                    {
                        result.AddRange(fn.GetPredefinedStubsForDataTable());
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
            get {return ChildList.Any(child => ((FlexNode)child).IsSection() && (child != this));}
        }

        /// <summary>
        /// Определяет, имеются ли среди соседних объектов секции
        /// </summary>
        public bool HasSectionSiblings
        {
            get{return ParentNode != null && ((FlexNode)ParentNode).HasSectionChildren;}
        }

        /// <summary>
        /// Определяет, имеются ли среди вложенных объектов фиксированные столбцы
        /// </summary>
        public bool HasStubChildren
        {
            get { return ChildList.Any(child => ((FlexNode)child).IsPredefinedStub()); }
        }

        public static explicit operator FlexNodeReport(FlexNode node)
        {
            var result = new FlexNodeReport(node.ParentNode, node.DataItem);



            return result;
        }
    }
}