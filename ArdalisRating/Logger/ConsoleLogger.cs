using System;

namespace ArdalisRating.Logger
{
    public class ConsoleLogger
    {
        // This still does the same work, but the details are delegated to this
        // ConsoleLogger class, which does only one thing.
        // This is easy to understand and a descriptive classname is also easy to think of
        //
        // The new classes are now easily testable
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}