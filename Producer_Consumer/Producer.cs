using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;  

namespace Producer_Consumer
{
    class Producer
    {
        public Producer(Queue<int> queue, SyncEvents syncEvents)
        {
            _queue = queue;
            _syncEvents = syncEvents;
        }
        Queue<int> _queue;
        SyncEvents _syncEvents;
        public void ThreadRun()
        {
            int count = 0;
            Random r = new Random();
            while (!_syncEvents.ExitThreadEvent.WaitOne(0, false))
            {
                lock (((ICollection)_queue).SyncRoot)
                {
                    while (_queue.Count < 20)
                    {
                        _queue.Enqueue(r.Next(0, 100));
                        _syncEvents.NewItemEvent.Set();
                        count++;
                    }
                }
            }
           Console.WriteLine("Producer thread: produced {0} items", count);
        }  
    }
}
