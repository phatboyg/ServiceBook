namespace ServiceBook.Tests.Benchmarks
{
    public class ContainerObjectCreation :
        ObjectCreation
    {
        readonly ServiceBook.Container _container;

        public ContainerObjectCreation()
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