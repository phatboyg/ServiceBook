namespace ServiceBook.Tests.Benchmarks
{
    public class ComponentFactoryObjectCreation :
        ObjectCreation
    {
        public T Get<T>() 
            where T : new()
        {
            return ComponentFactory.Get<T>();
        }

        public void Remove<T>()
        {
            ComponentFactory.Remove<T>();
        }
    }
}