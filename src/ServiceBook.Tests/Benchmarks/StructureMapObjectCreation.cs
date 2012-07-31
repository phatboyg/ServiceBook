namespace ServiceBook.Tests.Benchmarks
{
    using StructureMap;

    public class StructureMapObjectCreation :
        ObjectCreation
    {
        readonly Container _container;

        public StructureMapObjectCreation()
        {
            _container = new Container(x => { });
        }

        public T Get<T>()
            where T : new()
        {
            return _container.GetInstance<T>();
        }

        public void Remove<T>()
        {
        }
    }
}