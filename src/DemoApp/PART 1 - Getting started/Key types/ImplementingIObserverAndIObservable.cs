using System;
using System.Reactive.Disposables;

namespace DemoApp.PART_1___Getting_started.Key_types
{
    class MyConsoleObserver<T> : IObserver<T>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Sequence terminated");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Sequence faulted with {0}", error);
        }

        public void OnNext(T value)
        {
            Console.WriteLine("Received value {0}", value);
        }
    }
    
    public class MySequenceOfNumbers : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
            observer.OnCompleted();
            return Disposable.Empty;
        }
    }
}