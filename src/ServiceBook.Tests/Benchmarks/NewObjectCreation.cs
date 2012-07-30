namespace ServiceBook.Tests.Benchmarks
{
    public class NewObjectCreation :
        ObjectCreation
    {
        public T Get<T>() 
            where T : new()
        {
            return new T();
        }

        public void Remove<T>()
        {
        }
    }
}