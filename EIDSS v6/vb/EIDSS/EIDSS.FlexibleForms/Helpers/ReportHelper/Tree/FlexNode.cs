using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.Tree
{
    public class FlexNode
    {
        private readonly FlexNode m_ParentNode;
        private readonly FlexItem m_DataItem;
        private readonly int m_Level;

        private readonly List<FlexNode> m_ChildList = new List<FlexNode>();

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
        /// <param name="item"></param>
        public FlexNode(FlexNode parentNode, FlexItem item)
        {
            m_ParentNode = parentNode;
            m_DataItem = item;
            m_Level = (parentNode == null) ? 0 : parentNode.Level + 1;
        }

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

        /// <summary>
        /// collection of child nodes ordered by top and left
        /// </summary>
        public IEnumerable<FlexNode> OrderedChildList
        {
            get
            {
                var ordered = new List<FlexNode>(m_ChildList);
                ordered.Sort(CompareNodesByPosition);
                return ordered;
            }
        }

        public int Level
        {
            get { return m_Level; }
        }

       

        public int Count
        {
            get { return m_ChildList.Count; }
        }

       
        public bool IsRoot
        {
            get { return ParentNode == null; }
        }

        public bool ProcessAsTable { get; set; }

        /// <summary>
        /// data item stored in current node
        /// </summary>
        public FlexItem DataItem
        {
            get { return m_DataItem; }
        }

        /// <summary>
        /// report control assigned to current node
        /// </summary>
        public XRControl AssignedControl { get; set; }

        
        public FlexNode this[int index]
        {
            get { return m_ChildList[index]; }
            set { m_ChildList[index] = value; }
        }

        /// <summary>
        /// Сортирует дочерние элементы по порядку (Order)
        /// </summary>
        public void Sort()
        {
            m_ChildList.Sort(CompareNodesByOrder);
        }

        public void AcceptForward(FlexNodeVisitor visitor)
        {
            visitor.Visit(this);
            var children = ProcessAsTable
                                                 ? ChildList
                                                 : OrderedChildList;
            foreach (var child in children)
            {
                child.AcceptForward(visitor);
            }
        }

        public void AcceptBackword(FlexNodeVisitor visitor)
        {
            var children = ProcessAsTable? ChildList : OrderedChildList;

            foreach (var child in children)
            {
                child.AcceptBackword(visitor);
            }
            visitor.Visit(this);
        }

        public void Add(FlexibleFormsDS.LinesRow row)
        {
            var item = new FlexLineItem(row);
            m_ChildList.Add(new FlexNode(this, item));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void Add(FlexibleFormsDS.LabelsRow row)
        {
            var item = new FlexLabelItem(row);
            m_ChildList.Add(new FlexNode(this, item));
        }

        /// <summary>
        /// Добавляет лейбл с простым текстовым полем
        /// </summary>
        /// <param name="caption"></param>
        public FlexNode Add(string caption)
        {
            var labelItem = new FlexLabelItem(caption);
            var result = new FlexNode(this, labelItem);
            //выставляем размеры и положение для контейнера дин. параметров
            //отыщем среди них самый нижний (вложенные не учитываем)
            int top;
            int height;
            GetCorrectSize(m_ChildList, out top, out height);
            labelItem.Top = top + height;

            m_ChildList.Add(result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public FlexNode Add(FlexibleFormsDS.SectionTemplateRow row)
        {
            FlexNode flexNode = row.blnGrid
                                    ? new FlexNode(this, new FlexTableItem(row))
                                    : new FlexNode(this, new FlexLabelItem(row));
            m_ChildList.Add(flexNode);
            return flexNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterTemplateRow"></param>
        /// <param name="isParameterInSection"></param>
        public void Add(FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow, bool isParameterInSection)
        {
            var parameterTemplateItem = new FlexLabelItem(parameterTemplateRow, isParameterInSection);
            m_ChildList.Add(new FlexNode(this, parameterTemplateItem));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="isParameterInSection"></param>
        public FlexNode Add(FlexibleFormsDS.ParametersDeletedFromTemplateRow rowParameter, bool isParameterInSection)
        {
            var rowParameterItem = new FlexLabelItem(rowParameter, isParameterInSection);
            //пересчитываем правильно его координаты
            //отыщем среди них самый нижний (вложенные не учитываем)
            int top;
            int height;
            GetCorrectSize(m_ChildList, out top, out height);
            rowParameterItem.Top = top + height + 10;
            var result = new FlexNode(this, rowParameterItem);
            m_ChildList.Add(result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterTemplateRow"></param>
        /// <param name="activityParametersRow"></param>
        public void Add
            (FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow,
             FlexibleFormsDS.ActivityParametersRow activityParametersRow)
        {
            Add(parameterTemplateRow, false);

            var parametersItem = new FlexLabelItem(parameterTemplateRow, activityParametersRow)
                                     {IsParameterValue = true};
            var nodeAp = new FlexNode(this, parametersItem);
            //нод, который отвечает за контрол, выводится с фиксированной высотой
            var control =
                Parameter.GetControlParameter(
                    ParameterControlTypeHelper.ConvertToParameterControlType(parameterTemplateRow.idfsEditor));
            nodeAp.DataItem.Height = control.Height;
            if (nodeAp.DataItem.Height > parametersItem.Height) 
                nodeAp.DataItem.Height = parametersItem.Height;
            m_ChildList.Add(nodeAp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="activityParametersRow"></param>
        /// <param name="size"></param>
        public void Add
            (FlexibleFormsDS.ParametersDeletedFromTemplateRow rowParameter,
             FlexibleFormsDS.ActivityParametersRow activityParametersRow, out Size size)
        {
            FlexNode node = Add(rowParameter, false);

            var parametersItem = new FlexLabelItem(rowParameter, activityParametersRow)
                                     {
                                         IsParameterValue = true,
                                         Top = node.DataItem.Top
                                     };
            var nodeAp = new FlexNode(this, parametersItem);
            m_ChildList.Add(nodeAp);
            //нод, который отвечает за контрол, выводится с фиксированной высотой
            BaseEdit control =
                Parameter.GetControlParameter(
                    ParameterControlTypeHelper.ConvertToParameterControlType(rowParameter.idfsEditor));
            nodeAp.DataItem.Height = control.Height;
            size = new Size(rowParameter.intWidth, rowParameter.intHeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flexNodes"></param>
        /// <param name="top"></param>
        /// <param name="height"></param>
        private static void GetCorrectSize(List<FlexNode> flexNodes, out int top, out int height)
        {
            top = height = 0;
            //отыщем среди них самый нижний (вложенные не учитываем)
            for (int i = 0; i < flexNodes.Count; i++)
            {
                if (top < flexNodes[i].DataItem.Top)
                {
                    top = flexNodes[i].DataItem.Top;
                    height = flexNodes[i].DataItem.Height;
                }
            }
        }

        public static FlexNode CreateRoot()
        {
            return new FlexNode(null, null);
        }

        public override string ToString()
        {
            return string.Format("Data:{0}, Count:{1}", DataItem, Count);
        }

        internal static int CompareNodesByOrder(FlexNode x, FlexNode y)
        {
              int result;
            if (TryCompareNullNodes(x, y, out result))
            {
                return result;
            }
            
            if (x.DataItem.Order < y.DataItem.Order)
            {
                result = -1;
            }
            else if (x.DataItem.Order > y.DataItem.Order)
            {
                result = 1;
            }
            return result;
        }

        internal static int CompareNodesByPosition(FlexNode x, FlexNode y)
        {
            int result;
            if (TryCompareNullNodes(x, y, out result))
            {
                return result;
            }

            long xPosition = (long) int.MaxValue * x.DataItem.Top + x.DataItem.Left;
            long yPosition = (long) int.MaxValue * y.DataItem.Top + y.DataItem.Left;
            return xPosition.CompareTo(yPosition);
        }

        private static bool TryCompareNullNodes(FlexNode x, FlexNode y, out int result)
        {
            if (x == null && y == null)
            {
                result = 0;
                return true;
            }
            if (x == null)
            {
                result = -1;
                return true;
            }
            if (y == null)
            {
                result = 1;
                return true;
            }
            if (x.DataItem == null && y.DataItem == null)
            {
                result = 0;
                return true;
            }
            if (x.DataItem == null)
            {
                result = -1;
                return true;
            }
            if (y.DataItem == null)
            {
                result = 1;
                return true;
            }

            result = 0;
            return false;
        }
    }
}