using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DemoApp.PART_2___Sequence_basics
{
    public static class SimpleFactoryMethods
    {
        //  This method takes a value of T and returns an IObservable<T> with the single value and then completes.
        // It has unfolded a value of T into an observable sequence.
        public static void ObservableReturnFactory()
        {
            var singleValue = Observable.Return<string>("Value");
            
            //which could have also been simulated with a replay subject
            var subject = new ReplaySubject<string>();
            subject.OnNext("Value");
            subject.OnCompleted();
            
            //Can be reduced to the following
            singleValue = Observable.Return("Value");
        }

        // The next two examples only need the type parameter to unfold into an observable sequence.
        // The first is Observable.Empty<T>(). This returns an empty IObservable<T> i.e. it just publishes an OnCompleted notification.
        public static void ObservableEmptyFactory()
        {
            var empty = Observable.Empty<string>();
            //Behaviorally equivalent to
            var subject = new ReplaySubject<string>();
            subject.OnCompleted();
        }

        // The Observable.Never<T>() method will return infinite sequence without any notifications.
        public static void ObservableNeverFactory()
        {
            var never = Observable.Never<string>();
            //similar to a subject without notifications
            var subject = new Subject<string>();
        }

        public static void ObservableThrowFactory()
        {
            var throws = Observable.Throw<string>(new Exception()); 
           //Behaviorally equivalent to
            var subject = new ReplaySubject<string>(); 
            subject.OnError(new Exception());
        }
        
        
    }
}