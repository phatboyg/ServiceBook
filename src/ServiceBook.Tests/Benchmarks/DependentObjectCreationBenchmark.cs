namespace ServiceBook.Tests.Benchmarks
{
    using System.Collections.Generic;
    using Benchmarque;

    public class DependentObjectCreationBenchmark :
        Benchmark<DependentObjectCreation>
    {
        public void WarmUp(DependentObjectCreation instance)
        {
            instance.Get();
        }

        public void Shutdown(DependentObjectCreation instance)
        {
        }

        public void Run(DependentObjectCreation instance, int iterationCount)
        {
            for (int i = 0; i < iterationCount; i++)
            {
                instance.Get();
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