using System;
using System.Reactive.Subjects;
using System.Threading;
using DemoApp.PART_1___Getting_started.Key_types;
using DemoApp.PART_2___Sequence_basics;

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
           
            SimpleFactoryMethods.ObservableReturnFactory();      
          Console.ReadKey();


        }
    }
}
