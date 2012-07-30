namespace ServiceBook.Tests.Benchmarks
{
    public interface ObjectCreation
    {
        T Get<T>()
            where T : new();

        void Remove<T>();
    }
}