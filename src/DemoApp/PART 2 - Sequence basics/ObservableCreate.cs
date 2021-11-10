using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;

namespace DemoApp.PART_2___Sequence_basics
{
    public static class ObservableCreate
    {
        public static IObservable<string> BlockingMethod()
        {
            var subject = new ReplaySubject<string>();
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnCompleted();
            Thread.Sleep(1000);
            return subject;
        }
        
        public static IObservable<string> NonBlocking()
        {
            return Observable.Create<string>(
                (IObserver<string> observer) =>
                {
                    observer.OnNext("a");
                    observer.OnNext("b");
                    observer.OnCompleted();
                    Thread.Sleep(1000);
                    return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
                    //or can return an Action like 
                    //return () => Console.WriteLine("Observer has unsubscribed"); 
                });
        }


        public static IObservable<T> Empty<T>()
        {
            return Observable.Create<T>(o =>
                {
                    o.OnCompleted();
                    return Disposable.Empty;
                }
            );
        }

        public static IObservable<T> Returns<T>(T value)
        {
            return Observable.Create<T>(o =>
            {
                o.OnNext(value);
                o.OnCompleted();
                return Disposable.Empty;
            });
        }

        public static IObservable<T> Never<T>()
        {
            return Observable.Create<T>(o => Disposable.Empty);
        }

        public static IObservable<T> Throws<T>(Exception exception)
        {
            return Observable.Create<T>(o =>
            {
                o.OnError(exception);
                return Disposable.Empty;
            });
        }
        
        //Example code only
        public static void NonBlocking_event_driven()
        {
            var ob = Observable.Create<string>(
                observer =>
                {
                    var timer = new System.Timers.Timer();
                    timer.Interval = 1000;
                    timer.Elapsed += (s, e) => observer.OnNext("tick");
                    timer.Elapsed += OnTimerElapsed;
                    timer.Start();
                    return timer;
                });
            var subscription = ob.Subscribe(Console.WriteLine);
            Console.ReadLine();
            subscription.Dispose();
        }
        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime);
        }

    }
}