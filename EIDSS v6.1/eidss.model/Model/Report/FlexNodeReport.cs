using System.Collections.Generic;
using System.Drawing;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;

namespace eidss.model.Model.Report
{
    public class FlexNodeReport : FlexNodeBase
    {
        public FlexNodeReport(FlexNodeBase parentNode, FlexItem item)
            : base(parentNode, item)
        {
        }

        /// <summary>
        /// collection of child nodes ordered by top and left
        /// </summary>
        public IEnumerable<FlexNodeBase> OrderedChildList
        {
            get
            {
                var ordered = new List<FlexNodeBase>(ChildList);
                ordered.Sort(CompareNodesByPosition);
                return ordered;
            }
        }

        public bool ProcessAsTable { get; set; }

        /// <summary>
        /// report control assigned to current node
        /// </summary>
        public object AssignedControl { get; set; } //XRControl

        public void AcceptForward(FlexNodeVisitor visitor)
        {
            visitor.Visit(this);
            var children = ProcessAsTable
                ? ChildList
                : OrderedChildList;
            foreach (var child in children)
            {
                ((FlexNodeReport) child).AcceptForward(visitor);
            }
        }

        public void AcceptBackword(FlexNodeVisitor visitor)
        {
            var children = ProcessAsTable ? ChildList : OrderedChildList;

            foreach (var child in children)
            {
                ((FlexNodeReport)child).AcceptBackword(visitor);
            }
            visitor.Visit(this);
        }
        
        public void Add(Label row)
        {
            var item = new FlexLabelItem(row);
            ChildList.Add(new FlexNodeBase(this, item));
        }

        /// <summary>
        /// Добавляет лейбл с простым текстовым полем
        /// </summary>
        /// <param name="caption"></param>
        public FlexNodeReport Add(string caption)
        {
            var labelItem = new FlexLabelItem(caption, new Size(50, 50));
            var result = new FlexNodeReport(this, labelItem);
            //выставляем размеры и положение для контейнера дин. параметров
            //отыщем среди них самый нижний (вложенные не учитываем)
            int top;
            int height;
            GetCorrectSize(ChildList, out top, out height);
            labelItem.Top = top + height;

            ChildList.Add(result);
            return result;
        }
        
        public FlexNodeReport Add(SectionTemplate row)
        {
            var flexNode = row.blnGrid
                                    ? new FlexNodeReport(this, new FlexTableItem(row))
                                    : new FlexNodeReport(this, new FlexLabelItem(row));
            ChildList.Add(flexNode);
            return flexNode;
        }
        
        public void Add(ParameterTemplate parameterTemplateRow, bool isParameterInSection)
        {
            var parameterTemplateItem = new FlexLabelItem(parameterTemplateRow, isParameterInSection);
            ChildList.Add(new FlexNodeReport(this, parameterTemplateItem));
        }

        public FlexNodeReport Add(ParametersDeletedFromTemplate rowParameter, bool isParameterInSection)
        {
            var rowParameterItem = new FlexLabelItem(rowParameter, isParameterInSection);
            //пересчитываем правильно его координаты
            //отыщем среди них самый нижний (вложенные не учитываем)
            int top;
            int height;
            GetCorrectSize(ChildList, out top, out height);
            rowParameterItem.Top = top + height + 10;
            var result = new FlexNodeReport(this, rowParameterItem);
            ChildList.Add(result);
            return result;
        }

        public void Add
            (ParameterTemplate parameterTemplateRow,
             ActivityParameter activityParametersRow)
        {
            Add(parameterTemplateRow, false);

            var parametersItem = new FlexLabelItem(parameterTemplateRow, activityParametersRow) { IsParameterValue = true };
            var nodeAp = new FlexNodeReport(this, parametersItem);
            //нод, который отвечает за контрол, выводится с фиксированной высотой
            nodeAp.DataItem.Height = DefaultControlHeight;
            if (nodeAp.DataItem.Height > parametersItem.Height)
                nodeAp.DataItem.Height = parametersItem.Height;
            ChildList.Add(nodeAp);
        }
        
        public void Add
            (ParametersDeletedFromTemplate rowParameter,
             ActivityParameter activityParametersRow, out Size size)
        {
            var node = Add(rowParameter, false);

            var parametersItem = new FlexLabelItem(rowParameter, activityParametersRow)
            {
                IsParameterValue = true,
                Top = node.DataItem.Top
            };
            var nodeAp = new FlexNodeReport(this, parametersItem);
            ChildList.Add(nodeAp);
            //нод, который отвечает за контрол, выводится с фиксированной высотой
            nodeAp.DataItem.Height = DefaultControlHeight;
            size = new Size(rowParameter.intWidth, rowParameter.intHeight);
        }

        private const int DefaultControlHeight = 10;
        
        private static void GetCorrectSize(List<FlexNodeBase> flexNodes, out int top, out int height)
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

        public override string ToString()
        {
            return string.Format("Data:{0}, Count:{1}", DataItem, Count);
        }

        internal static int CompareNodesByOrder(FlexNodeReport x, FlexNodeReport y)
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

        internal static int CompareNodesByPosition(FlexNodeBase x, FlexNodeBase y)
        {
            int result;
            if (TryCompareNullNodes(x, y, out result))
            {
                return result;
            }

            long xPosition = (long)int.MaxValue * x.DataItem.Top + x.DataItem.Left;
            long yPosition = (long)int.MaxValue * y.DataItem.Top + y.DataItem.Left;
            return xPosition.CompareTo(yPosition);
        }

        private static bool TryCompareNullNodes(FlexNodeBase x, FlexNodeBase y, out int result)
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
