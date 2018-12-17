using System;
using System.Threading;

namespace DebugAndReleaseDifferences
{
    class Program
    {
        // the difference between debug and release mode won't be appear if you use 'console.Write...' method in the new thread
        static void Main(string[] args)
        {

            int Num =1;
            var t = new Thread(() =>
            {
                var isSuccess = true;
                while (Num == 1)
                {
                    //Thread.VolatileRead(ref Num);
                    isSuccess = !isSuccess;    
                }
            });
            t.Start();
            Thread.Sleep(1000);

            Num = 2;
            t.Join();

            Console.WriteLine("Main Thread is over!");
            Console.ReadKey();
        }
    }
}
