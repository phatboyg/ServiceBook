namespace ServiceBook.Tests.Benchmarks
{
    using System;

    static class Factory<T>
    {
        public static Func<T> Get { get; internal set; }
    }
}