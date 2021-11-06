﻿using System;

namespace DemoApp
{
    public static class Helpers
    {
        //Takes an IObservable<string> as its parameter. 
        //Subject<string> implements this interface.
       public static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            //The next two lines are equivalent.
            //sequence.Subscribe(value=>Console.WriteLine(value));
            sequence.Subscribe(Console.WriteLine);
        }
    }
}