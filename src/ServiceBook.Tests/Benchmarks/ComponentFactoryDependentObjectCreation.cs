namespace ServiceBook.Tests.Benchmarks
{
    public class ComponentFactoryDependentObjectCreation :
        DependentObjectCreation
    {
        public ParentObject Get()
        {
            return ComponentFactory.Get<ParentObject>();
        }
    }
}