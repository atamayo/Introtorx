using System;
using System.Reactive.Subjects;
using System.Threading;
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
           // SubjectDemo.BasicSubject();
            
           // ReplaySubjectDemo.ReplaySubjectWindowExample();
           
         //  BehaviorSubjectDemo.BehaviorSubjectExample();
          // BehaviorSubjectDemo.BehaviorSubjectExample3();
          
         // BehaviorSubjectDemo.BehaviorSubjectCompletedExample();
         
         //  AsyncSubjectDemo.AsyncSubjectExample1();
           AsyncSubjectDemo.AsyncSubjectExample2();
          
          
          Console.ReadKey();


        }
    }
}
