using System;
using System.Reactive.Subjects;
using Console = System.Console;

namespace DemoApp.PART_1___Getting_started.Key_types
{
    /// <summary>
    /// BehaviorSubject&lt;T&gt; is similar to ReplaySubject&lt;T&gt; except it only remembers the last publication. BehaviorSubject&lt;T&gt;
    /// also requires you to provide it a default value of T. This means that all subscribers will receive a value immediately (unless it is already completed).
    /// </summary>
    public static class BehaviorSubjectExample
    {
        /// <summary>
        /// In this example the value 'a' is written to the console:
        /// </summary>
        public static void BehaviorSubjectExample1()
        {
            //Need to provide a default value.
            var subject = new BehaviorSubject<string>("a");
            subject.Subscribe(Console.WriteLine);
        }
        
        /// <summary>
        /// In this example the value 'b' is written to the console, but not 'a'.
        /// </summary>
        public static void BehaviorSubjectExample2()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.Subscribe(Console.WriteLine);
        }
        
        /// <summary>
        ///  In this example the values 'b', 'c' & 'd' are all written to the console, but again not 'a'
        /// </summary>
        public static void BehaviorSubjectExample3()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("c");
            subject.OnNext("d");
        }
        
        public static void BehaviorSubjectCompletedExample()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.OnNext("c");
            subject.OnCompleted();
            subject.Subscribe(Console.WriteLine);
        }
    }
}