using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;  

namespace Producer_Consumer
{
    class Program
    {
        static void Main(string[] args)  
        {  
            Queue<int> queue = new Queue<int>();  
            SyncEvents syncEvents = new SyncEvents();  
  
            Producer producer = new Producer(queue, syncEvents);  
            Consumer consumer = new Consumer(queue, syncEvents);  
            Thread producerThread = new Thread(producer.ThreadRun);  
            Thread consumerThread = new Thread(consumer.ThreadRun);  
  
            producerThread.Start();  
            consumerThread.Start();  
  
            //Show 
            //for (int i = 0; i < 12; i++)  
            //{  
            //    Thread.Sleep(1000);  
            //    ShowQueueContents(queue);  
            //}

            Console.WriteLine("Press any key to stop!");
            while (!Console.KeyAvailable)
            {
                ShowQueueContents(queue);
            }

            //exit
            syncEvents.ExitThreadEvent.Set();  
        }  
  
        private static void ShowQueueContents(Queue<int> q)  
        {  
            lock (((ICollection) q).SyncRoot)  
            {  
                foreach (int item in q)  
                {  
                    Console.Write(item);  
                }  
            }  
            Console.WriteLine();  
        }  

        }
    }
