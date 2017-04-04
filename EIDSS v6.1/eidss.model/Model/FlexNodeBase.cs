using System;
using System.Collections.Generic;
using System.Text;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;

namespace eidss.model.Model
{
    public class FlexNodeBase
    {
        private readonly FlexNodeBase m_ParentNode;
        protected FlexItem m_DataItem;
        private readonly int m_Level;

        private readonly List<FlexNodeBase> m_ChildList = new List<FlexNodeBase>();

        public void DeleteNode(FlexNodeBase node)
        {
            m_ChildList.Remove(node);
        }

        /// <summary>
        /// Порядок этого узла среди соседей внутри родительского узла
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ChildListCount
        {
            get { return m_ChildList != null ? m_ChildList.Count : 0; }
        }

        public FlexNodeBase(FlexNodeBase parentNode, FlexItem ffObject)
        {
            m_ParentNode = parentNode;
            m_DataItem = ffObject;
            m_Level = (parentNode == null) ? 0 : parentNode.Level + 1;
        }

        
        /// <summary>
        /// Parent of current node
        /// </summary>
        public FlexNodeBase ParentNode
        {
            get { return m_ParentNode; }
        }

        /// <summary>
        /// collection of child nodes
        /// </summary>
        public List<FlexNodeBase> ChildList
        {
            get { return m_ChildList; }
        }

        public FlexNodeBase GetItem(int index)
        {
            return (index >= 0 && index <= m_ChildList.Count - 1) ? m_ChildList[index] : null;
        }

        public int Level
        {
            get { return m_Level; }
        }

        public static int CompareFlexNodes(FlexNodeBase node1, FlexNodeBase node2)
        {
            var result = 0;
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
        
        
        
        public void Sort()
        {
            m_ChildList.Sort(CompareFlexNodes);
        }
        
        public int Count
        {
            get { return m_ChildList.Count; }
        }
       
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

        public FlexNodeBase this[int index]
        {
            get { return m_ChildList[index]; }
            set { m_ChildList[index] = value; }
        }

        public FlexNodeBase Add(object ffObject, int index)
        {
            var flexNode = new FlexNodeBase(this, new FlexItem(ffObject));
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

        public void Add(FlexNodeBase node, int index = -1)
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

        /*
        public static FlexNode CreateRoot()
        {
            return new FlexNode(null, null, null, null);
        }
        */

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
