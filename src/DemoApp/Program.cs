using System;
using System.Reactive.Subjects;
using System.Threading;
using DemoApp.Lifetime_management;
using DemoApp.Subjects;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var numbers = new MySequenceOfNumbers();
            var observer = new MyConsoleObserver<int>();
            numbers.Subscribe(observer);
            */
           
             
            DisposableFactoryDemo.DisposableBasicExample();      
          Console.ReadKey();


        }
    }
}
