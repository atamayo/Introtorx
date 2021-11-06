using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class MyConsoleObserver<T> : IObserver<T>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Sequence terminated");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Sequence faulted with {0}", error);
        }

        public void OnNext(T value)
        {
            Console.WriteLine("Received value {0}", value);
        }
    }
}
