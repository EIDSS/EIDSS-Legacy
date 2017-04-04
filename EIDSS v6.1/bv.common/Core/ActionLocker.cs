
using System.Collections.Generic;
using bv.winclient.Core;

namespace bv.common.Core
{
    public class ActionLocker
    {
        public delegate object ShowWaitDialogDelegate(WaitDialogType waitType);
        public delegate void CloseWaitDialogDelegate(object waitDialog);

        public static ShowWaitDialogDelegate ShowWaitDialog { get; set; }
        public static CloseWaitDialogDelegate CloseWaitDialog { get; set; }

        private object m_WaitDialog;

        private bool m_Locked;

        public bool Lock(WaitDialogType waitType = WaitDialogType.None)
        {
            if (m_Locked) return false;
            if (waitType != WaitDialogType.None && (ShowWaitDialog != null)) m_WaitDialog = ShowWaitDialog(waitType);
            return m_Locked = true;
        }
        public void Unlock()
        {
            if ((CloseWaitDialog != null) && (m_WaitDialog != null)) CloseWaitDialog(m_WaitDialog);
            m_Locked = false;
        }
        public bool Locked { get { return m_Locked; } }
        private static readonly Dictionary<object, ActionLocker> m_LockedObjects = new Dictionary<object, ActionLocker>();
        public static bool LockAction(object lockObject)
        {
            ActionLocker locker;
            if (!m_LockedObjects.TryGetValue(lockObject, out locker))
            {
                locker = new ActionLocker();
                m_LockedObjects.Add(lockObject, locker);
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
