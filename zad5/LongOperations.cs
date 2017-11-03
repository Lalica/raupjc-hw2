using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace zad5
{
    public static class LongOperations
    { 
        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished. Executing Thread: {1}", taskName, Thread.CurrentThread.ManagedThreadId);
        }

        public static void Example1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            LongOperation("A");
            LongOperation("B");
            LongOperation("C");
            LongOperation("D");
            LongOperation("E");
            stopwatch.Stop();
            Console.WriteLine("Synchronous long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
        }

        public static void Example2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(
                () => LongOperation("A"),
                () => LongOperation("B"),
                () => LongOperation("C"),
                () => LongOperation("D"),
                () => LongOperation("E"));
            stopwatch.Stop();
            Console.WriteLine("Parallel long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
        }

        public static void Example3()
        {
            List<int> results = new List<int>();
            Parallel.For(0, 100000, (i) => 
            {
                Thread.Sleep(1);
                results.Add(i* i); 
            });
            Console.WriteLine("Bag length should be 100000. Length is {0}", results.Count);
        }

        public static void Example4()
        {
            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100000, (i) => 
            {
                Thread.Sleep(1);
                iterations.Add(i);
            });
            Console.WriteLine("Bag length should be 100000. Length is {0}", iterations.Count);

        }
    }
}
