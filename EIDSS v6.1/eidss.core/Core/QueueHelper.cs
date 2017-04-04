using System.Collections.Generic;
using System.Threading;

namespace eidss.model.Core
{
    public class QueueHelper
    {
        public static void ThreadSafeEnqueue<T>(Queue<T> queue, T item, object locker, CancellationTokenSource tokenSource)
        {
            lock (locker)
            {
                if (!tokenSource.IsCancellationRequested)
                {
                    queue.Enqueue(item);
                }
                Monitor.PulseAll(locker);
            }
        }

        public static T ThreadSafeDequeue<T>(Queue<T> queue, object locker, CancellationTokenSource tokenSource)
        {
            lock (locker)
            {
                while (queue.Count == 0 && !tokenSource.IsCancellationRequested)
                {
                    Monitor.Wait(locker);
                }

                T item = tokenSource.IsCancellationRequested ? default(T) : queue.Dequeue();
                
                return item;
            }
        }
    }
}