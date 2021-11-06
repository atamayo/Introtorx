using System;
using System.Reactive.Subjects;

namespace DemoApp.Lifetime_management
{
    public static class ExceptionHandlingDemo
    {

        /// <summary>
        /// Incorrect way of catching errors in RxNET
        /// </summary>
        public static void CatchErrorUsingStandardNetStructuredException()
        {
            var values = new Subject<int>();
            try
            {
                values.Subscribe(value => Console.WriteLine("1st subscription received {0}", value));
            }
            catch (Exception)
            {
                Console.WriteLine("Won't catch anything here!");
            }
            values.OnNext(0);
            
            //Exception will be thrown here causing the app to fail.
            values.OnError(new Exception("Dummy exception"));
        }


        public static void CorrectWayToHandleExceptions()
        {
            var values = new Subject<int>();
            values.Subscribe(
                value => Console.WriteLine("1st subscription received {0}", value),
                ex => Console.WriteLine("Caught an exception : {0}", ex));
            values.OnNext(0);
            values.OnError(new Exception("Dummy exception"));
        }
        
        
        
    }
}