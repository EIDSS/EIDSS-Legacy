

namespace bv.common.Core
{
    /// <summary>
    /// A drop-out-stack is simply a stack variant that modifies the push()operation 
    /// so that the bottom element in the stack is dropped out (lost) if the stack is full. 
    /// Applications of drop-out-stacks include history lists and undo lists in applications. 
    /// http://courses.cs.vt.edu/~cs2704/spring04/projects/DropOutStack.pdf
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DropOutStack<T>
    {
        private readonly T[] m_Items;
        private int m_Top;//index of the cell where next item shall be pushed
        private int m_Count;
        private readonly int m_Capacity;
        public DropOutStack(int capacity)
        {
            if (capacity < 3)
                capacity = 3;
            m_Items = new T[capacity];
            m_Capacity = capacity;
        }
        public int Count { get { return m_Count; } }
        public void Push(T item)
        {
            m_Items[m_Top] = item;
            m_Top = GetPushIndex();
            if (m_Count < m_Capacity)
                m_Count++;
        }
        public T Pop()
        {
            if (m_Count > 0)
            {
                m_Top = GetPopIndex();
                //var item = m_Items[m_Top];
                //m_Items[m_Top] = default(T); //clear cell
                m_Count--;
                return m_Items[m_Top];
            }
            return default(T);
        }
        public T Rollback()
        {
            if (m_Count <= m_Capacity)
            {
                var item = m_Items[m_Top];
                m_Top = GetPushIndex();
                if (m_Count < m_Capacity)
                    m_Count++;
                return item;
            }
            return default(T);
        }

        public bool CanRollback()
        {
            if (m_Count <= m_Capacity)
            {
                var item = m_Items[m_Top];
                return (object)item != null;
                //return !item.Equals(default(T));
            }
            return false;
        }
        private int GetPopIndex()
        {
            return (m_Capacity + m_Top - 1) % m_Capacity;
        }
        private int GetPushIndex()
        {
            return (m_Top + 1) % m_Capacity; 
        }
        public T Peek()
        {
            int i = GetPopIndex();
            return m_Items[i];
        }

        public void Clear()
        {
            m_Count = 0;
            m_Top = 0;
            for (var i = 0; i < m_Capacity;i++ )
            {
                m_Items[i] = default(T);
            }
        }

        public T[] Items { get { return m_Items; } }
    }
}
