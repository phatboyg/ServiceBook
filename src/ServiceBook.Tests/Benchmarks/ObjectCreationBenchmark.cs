namespace ServiceBook.Tests.Benchmarks
{
    using System.Collections.Generic;
    using Benchmarque;

    public class ObjectCreationBenchmark :
        Benchmark<ObjectCreation>
    {
        public void WarmUp(ObjectCreation instance)
        {
            instance.Get<MyClass>();
        }

        public void Shutdown(ObjectCreation instance)
        {
            instance.Remove<MyClass>();
        }

        public void Run(ObjectCreation instance, int iterationCount)
        {
            for (int i = 0; i < iterationCount; i++)
            {
                instance.Get<MyClass>();
            }
        }

        public IEnumerable<int> Iterations
        {
            get { return new[] {1000000}; }
        }

        class MyClass
        {
        }
    }
}