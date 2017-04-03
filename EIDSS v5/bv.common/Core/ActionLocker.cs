
using System.Collections.Generic;

namespace bv.common.Core
{
    public class ActionLocker
    {
        private bool m_Locked;
        public bool Lock()
        {
            if (m_Locked)
                return false;
            return m_Locked = true;
        }
        public void Unlock()
        {
            m_Locked = false;
        }
        public bool Locked { get { return m_Locked; } }
        private static readonly Dictionary<object, ActionLocker> m_LockedObjects = new Dictionary<object, ActionLocker>();
        public static bool LockAction(object lockObject)
        {
            ActionLocker locker; 
            if(!m_LockedObjects.TryGetValue(lockObject, out locker))
            {
                locker = new ActionLocker();
                m_LockedObjects.Add(lockObject,locker);
            }
            return locker.Lock();
        }
        public static void UnlockAction(object lockObject)
        {
            ActionLocker locker;
            if (m_LockedObjects.TryGetValue(lockObject, out locker))
            {
                locker.Unlock();
                m_LockedObjects.Remove(lockObject);
            }
        }
    }

}
