namespace ServiceBook.Tests.Benchmarks
{
    using StructureMap;

    public class StructureMapDependentObjectCreation :
        DependentObjectCreation
    {
        readonly Container _container;

        public StructureMapDependentObjectCreation()
        {
            _container = new Container(x => { });
        }

        public ParentObject Get()
        {
            return _container.GetInstance<ParentObject>();
        }
    }
}