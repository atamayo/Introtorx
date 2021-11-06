using System;
using System.Reactive.Subjects;
using System.Threading;

namespace DemoApp.PART_1___Getting_started.Key_types
{
    /// <summary>
    /// ReplaySubject&lt;T&gt; provides the feature of caching values and then replaying them for any late subscriptions.
    /// </summary>
    public class ReplaySubjectExample
    {
        
       public static void ReplaySubjectBasic()
        {
            var subject = new ReplaySubject<string>();
            subject.OnNext("a");
            Helpers.WriteSequenceToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
        }
        
        public static void ReplaySubjectWindowExample()
        {
            var window = TimeSpan.FromMilliseconds(150);
            var subject = new ReplaySubject<string>(window);
            subject.OnNext("w");
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            subject.OnNext("x");
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            subject.OnNext("y");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("z");
        }
        
        public void ReplaySubjectBufferExample()
        {
            var bufferSize = 2;
            var subject = new ReplaySubject<string>(bufferSize);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("d");
        }
    }
}