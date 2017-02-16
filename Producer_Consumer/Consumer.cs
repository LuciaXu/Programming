using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;  

namespace Producer_Consumer
{
    class Consumer
    {
        public Consumer(Queue<int> queue, SyncEvents syncEvents)
        {
            _queue = queue;
            _syncEvents = syncEvents;
        }
        Queue<int> _queue;
        SyncEvents _syncEvents;

        public void ThreadRun()
        {
            int count = 0;
            while (WaitHandle.WaitAny(_syncEvents.EventArray) != 1)
            {
                lock (((ICollection)_queue).SyncRoot)
                {
                    int item = _queue.Dequeue();
                }
                count++;
            }
            //Console.WriteLine("Consumer Thread: consumed"+count+" items");
        }  
    }
}
