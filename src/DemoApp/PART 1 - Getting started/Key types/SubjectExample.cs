using System.Reactive.Subjects;

namespace DemoApp.PART_1___Getting_started.Key_types
{
    /// <summary>
    /// Subject&lt;T&gt; is the most basic of the subjects.
    /// Effectively you can expose your Subject&lt;T&gt; behind a method that returns IObservable&lt;T&gt;
    /// but internally you can use the OnNext, OnError and OnCompleted methods to control the sequence.
    /// </summary>
    public static class SubjectExample
    {
        /// <summary>
        /// In this very basic example, creates a subject, subscribe to that subject and then publish values to the sequence (by calling subject.OnNext(T)).
        /// </summary>
        public static void BasicSubject()
        {
            var subject = new Subject<string>();
            Helpers.WriteSequenceToConsole(subject);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
        }
        
        /// <summary>
        /// Here we see an attempt to publish the value 'c' on a completed sequence. Only values 'a' and 'b' are written to the console.
        /// </summary>
        public static void SubjectInvalidUsageExample()
        {
            var subject = new Subject<string>();
            Helpers.WriteSequenceToConsole(subject);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnCompleted();
            subject.OnNext("c");
        }
    }
}