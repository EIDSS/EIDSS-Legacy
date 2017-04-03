using System;
using System.Diagnostics;

namespace eidss.model.Trace
{
    public class StopwathTransaction : IDisposable
    {
        private readonly Stopwatch m_Watch = new Stopwatch();
        private readonly string m_Name;
        private readonly long m_StartMemory;
        private readonly bool m_CollectMamory;

        public StopwathTransaction(string name, bool collectMemory = false)
        {
            m_Name = name;
            m_CollectMamory = collectMemory;
            if (m_CollectMamory)
            {
                GC.Collect();
                m_StartMemory = GC.GetTotalMemory(true);
            }
            Console.WriteLine("{0} Strated", m_Name);
            m_Watch.Start();
        }

        public void Dispose()
        {
            m_Watch.Stop();
            if (m_CollectMamory)
            {
                GC.Collect();
                Console.WriteLine("{0} Finished: {1:# ### ###} ms ({2:# ### ### ###} tics). Memory usage: {3:# ### ### ###}",
                                  m_Name, m_Watch.ElapsedMilliseconds, m_Watch.ElapsedTicks, GC.GetTotalMemory(true) - m_StartMemory);
            }
            else
            {
                Console.WriteLine("{0} Finished: {1:# ### ###} ms ({2:# ### ### ###} tics).",
                                  m_Name, m_Watch.ElapsedMilliseconds, m_Watch.ElapsedTicks);
            }
        }
    }
}