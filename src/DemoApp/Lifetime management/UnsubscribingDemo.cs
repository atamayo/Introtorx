using System;
using System.Reactive.Subjects;

namespace DemoApp.Lifetime_management
{
    public static class UnsubscribingDemo
    {
        
        /// <summary>
        /// Note that calling Dispose on the result of a Subscribe call will not cause any side effects for other subscribers;
        /// it just removes the subscription from the observable's internal list of subscriptions. This then allows us to call Subscribe many times on a single IObservable&lt;T&gt;,
        /// allowing subscriptions to come and go without affecting each other. In this example we initially have two subscriptions, we then dispose of one subscription early which still
        /// allows the other to continue to receive publications from the underlying sequence:
        /// </summary>
        public static void UnsubscribingExample()
        {
            var values = new Subject<int>();
            var firstSubscription = values.Subscribe(value => 
                Console.WriteLine("1st subscription received {0}", value));
            var secondSubscription = values.Subscribe(value => 
                Console.WriteLine("2nd subscription received {0}", value));
            values.OnNext(0);
            values.OnNext(1);
            values.OnNext(2);
            values.OnNext(3);
            firstSubscription.Dispose();
            Console.WriteLine("Disposed of 1st subscription");
            values.OnNext(4);
            values.OnNext(5);
        }
        
    }
}