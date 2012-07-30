namespace ServiceBook.Tests.Benchmarks
{
    public class ServiceBookContainerObjectCreation :
        ObjectCreation
    {
        readonly ServiceBook.Container _container;

        public ServiceBookContainerObjectCreation()
        {
            _container = ContainerFactory.New(x => { });
        }

        public T Get<T>() 
            where T : new()
        {
            return _container.Get<T>();
        }

        public void Remove<T>()
        {
        }
    }
}