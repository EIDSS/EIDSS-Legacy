using System;
using System.Collections;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Diagnostics;
//using Timer = System.Threading.Timer;
using Timer = System.Windows.Forms.Timer;

namespace bv.winclient.BasePanel
{
    public class FormDisposer
    {
        private static volatile Timer m_Timer;
        private static readonly object m_SyncObject = new object();
		private static readonly IList m_FormsToDispose = ArrayList.Synchronized(new ArrayList());

        private static void Start()
        {
            if (m_Timer == null)
                lock (m_SyncObject)
                    if (m_Timer == null)
                    {
                        //TimeSpan interval = TimeSpan.FromSeconds(5);
                        //m_Timer = new Timer(DisposeForms, null, interval, interval);
                        m_Timer = new Timer {Interval = 5000, Enabled = true};
                        m_Timer.Tick += TimerTick;

                    }
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            DisposeInternal(false);       
        }


        public static void Stop()
        {
            if (m_Timer != null)
                lock (m_SyncObject)
                    if (m_Timer != null)
                    {
                        m_Timer.Dispose();
                        m_Timer = null;
                    }
            DisposeInternal(true);
        }

        public static void Add(Control form)
        {
            Start();
            lock(m_FormsToDispose.SyncRoot)
            {
                if (form!=null)
                    m_FormsToDispose.Add(form);               
            }
        }

        private static void DisposeInternal(bool disposeAll)
        {
            lock (m_FormsToDispose.SyncRoot)
            {

                try
                {
                    var limit = 1;
                    if (disposeAll)
                        limit = 0;
                    int cnt = m_FormsToDispose.Count;
                    while (m_FormsToDispose.Count > limit)
                    {
                        var ctl = m_FormsToDispose[0] as Control;
                        var app = ctl as IApplicationForm;
                        if (app != null && app.DisableDelayedDisposing)
                            return;
                        m_FormsToDispose.RemoveAt(0);
                        if (ctl != null)
                        {
                            var frm = ctl.FindForm();
                            SafeDispose(frm ?? ctl);
                        }
                    }
                    if (cnt > limit)
                        MemoryManager.Flush();

                }
                catch (Exception e)
                {
                    Dbg.WriteLine("error during delayed form disposing: {0}", e);
                }
            }

        }
        private static void DisposeForms(object state)
        {
            DisposeInternal(false);
        }
        public delegate void DisposeDelegate();
        private static void SafeDispose(Control ctl )
        {
            if (ctl.InvokeRequired)
            {
                var mi = ctl.GetType().GetMethod("Dispose");
                if (mi != null)
                {
                    Delegate d = Delegate.CreateDelegate(typeof (DisposeDelegate), ctl, mi);
                    ctl.Invoke(d, null);
                }
            }
            else
            {
                ctl.Dispose();
            }

        }

    }
}
