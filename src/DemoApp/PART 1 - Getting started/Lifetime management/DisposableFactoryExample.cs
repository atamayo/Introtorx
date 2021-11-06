using System;
using System.Reactive.Disposables;

namespace DemoApp.PART_1___Getting_started.Lifetime_management
{
    public static class DisposableFactoryExample
    {
        
        /// <summary>
        /// The Create method will ensure the standard Dispose semantics,
        /// so calling Dispose() multiple times will only invoke the delegate you provide once:
        /// </summary>
        public static void DisposableBasicExample()
        {
            var disposable = Disposable.Create(() => Console.WriteLine("Being disposed."));
            Console.WriteLine("Calling dispose...");
            disposable.Dispose();
            Console.WriteLine("Calling again...");
            disposable.Dispose();
        }
    }
}