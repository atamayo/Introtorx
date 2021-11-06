using System;
using System.Diagnostics;
using System.Threading;

namespace DemoApp.PART_1___Getting_started.Lifetime_management
{
    public static class DisposableExample
    {
        public static void DisposableTimeItExample()
        {
            using (new TimeIt("Outer scope"))
            {
                using (new TimeIt("Inner scope A"))
                {
                    DoSomeWork("A");
                }
                using (new TimeIt("Inner scope B"))
                {
                    DoSomeWork("B");
                }
                Cleanup();
            }
        }

        public static void DisposableConsoleColorExample()
        {
            Console.WriteLine("Normal color");
            using (new ConsoleColor(System.ConsoleColor.Red))
            {
                Console.WriteLine("Now I am Red");
                using (new ConsoleColor(System.ConsoleColor.Green))
                {
                    Console.WriteLine("Now I am Green");
                }
                Console.WriteLine("and back to Red");
            }
        }
        

        private static void Cleanup()
        {
            Console.WriteLine($"Cleaning up ...");
        }

        private static void DoSomeWork(string p0)
        {
            Console.WriteLine($"Doing work {p0} ...");
            Thread.Sleep(500);
        }
    }
    
    public class TimeIt : IDisposable
    {
        private readonly string _name;
        private readonly Stopwatch _watch;
        public TimeIt(string name)
        {
            _name = name;
            _watch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            _watch.Stop();
            Console.WriteLine("{0} took {1}", _name, _watch.Elapsed);
        }
    }

   /// <summary>
   /// Creates a scope for a console foreground color. When disposed, will return to
   ///  the previous Console.ForegroundColor
   /// </summary>
    public class ConsoleColor : IDisposable
    {
        private readonly System.ConsoleColor _previousColor;
        
        public ConsoleColor(System.ConsoleColor color)
        {
            _previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
        }
        
        public void Dispose()
        {
            Console.ForegroundColor = _previousColor;
        }
    }
    
    
}