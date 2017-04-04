using System;
using System.Collections.Generic;
using System.Text;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using System.Linq;

namespace eidss.webui.Areas.FlexForms.Models.FlexNodes
{
    public class FlexNode
    {
        private readonly FlexNode m_ParentNode;
        private readonly FlexItem m_DataItem;
        private readonly int m_Level;
        private readonly EditableList<ActivityParameter> m_ActivityParameters;

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
        /// <param name="ffObject"></param>
        /// <param name="activityParameters"></param>
        public FlexNode(FlexNode parentNode, FlexItem ffObject, EditableList<ActivityParameter> activityParameters)
        {
            m_ParentNode = parentNode;
            m_DataItem = ffObject;
            m_Level = (parentNode == null) ? 0 : parentNode.Level + 1;
            m_ActivityParameters = activityParameters;
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
        public bool IsParameter()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is ParameterTemplate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsLabel()
        {
            return ((DataItem != null) && (DataItem.LinkedObject is Label));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ParameterTemplate GetParameterTemplate()
        {
            return IsParameter() ? (ParameterTemplate) DataItem.LinkedObject : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActivityParameter GetParameterValue()
        {
            ActivityParameter result = null;
            if ((m_ActivityParameters != null) && (m_ActivityParameters.Count > 0))
            {
                var parameter = GetParameterTemplate();
                if (parameter != null)
                {
                    result =
                        m_ActivityParameters.FirstOrDefault(
                            m =>
                            ((m.idfsParameter == parameter.idfsParameter) &&
                             (m.idfsFormTemplate == parameter.idfsFormTemplate)));
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
        /// Сортирует дочерние элементы по порядку (Order)
        /// </summary>
        public void Sort()
        {
            m_ChildList.Sort(CompareFlexNodes);
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
        public FlexNode Add(object ffObject, EditableList<ActivityParameter> activityParameters)
        {
            var flexNode = new FlexNode(this, new FlexItem(ffObject), activityParameters);
            m_ChildList.Add(flexNode);
            return flexNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffObject"></param>
        public FlexNode Add(object ffObject)
        {
            return Add(ffObject, null);
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
            return new FlexNode(null, null, null);
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
    }
}