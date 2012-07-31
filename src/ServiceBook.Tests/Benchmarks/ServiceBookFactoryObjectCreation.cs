namespace ServiceBook.Tests.Benchmarks
{
    using Factories;

    public class ServiceBookFactoryObjectCreation :
        ObjectCreation
    {
        object _factory;

        public T Get<T>()
            where T : new()
        {
            if (_factory == null)
                _factory = new ConstructorFactory<T>(() => new T());

            var factory = (ServiceBook.Factory<T>)_factory;

            return factory.Get();
        }

        public void Remove<T>()
        {
        }
    }
}