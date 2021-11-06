using System;
using System.Reactive.Subjects;

namespace DemoApp.PART_1___Getting_started.Lifetime_management
{
    public static class OnErrorAndOnCompletedExample
    {
        /// <summary>
        /// Both the OnError and OnCompleted signify the completion of a sequence.
        /// If your sequence publishes an OnError or OnCompleted it will be the last publication and no further calls to OnNext can be performed.
        /// In this example we try to publish an OnNext call after an OnCompleted and the OnNext is ignored:
        /// </summary>
        public static void OnErrorOnCompleteExample1()
        {
            var subject = new Subject<int>();
            subject.Subscribe(
                Console.WriteLine, 
                () => Console.WriteLine("Completed"));
            subject.OnCompleted();
            subject.OnNext(2);
        }
    }
}