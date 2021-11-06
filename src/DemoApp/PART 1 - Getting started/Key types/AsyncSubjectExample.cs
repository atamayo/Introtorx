using System.Reactive.Subjects;

namespace DemoApp.PART_1___Getting_started.Key_types
{
    /// <summary>
    /// AsyncSubject&lt;T&gt; is similar to the Replay and Behavior subjects in the way that it caches values,
    /// however it will only store the last value, and only publish it when the sequence is completed. The general usage of the AsyncSubject&lt;T&gt;
    /// is to only ever publish one value then immediately complete. This means that is becomes quite comparable to Task&lt;T&gt;.
    /// </summary>
    public static class AsyncSubjectExample
    {

        /// <summary>
        /// In this example no values will be published as the sequence never completes. No values will be written to the console.
        /// </summary>
        public static void AsyncSubjectExample1()
        {
            var subject = new AsyncSubject<string>();
            subject.OnNext("a");
            Helpers.WriteSequenceToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
        }
        
        /// <summary>
        /// In this example we invoke the OnCompleted method so the last value 'c' is written to the console:
        /// </summary>
        public static void AsyncSubjectExample2()
        {
            var subject = new AsyncSubject<string>();
            subject.OnNext("a");
            Helpers.WriteSequenceToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
            subject.OnCompleted();
        }
        
    
        
    }
}