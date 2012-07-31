namespace ServiceBook.Tests.Benchmarks
{
    public class ServiceBookDependentObjectCreation :
        DependentObjectCreation
    {
        readonly Container _container;

        public ServiceBookDependentObjectCreation()
        {
            _container = ContainerFactory.New(x => { });
        }


        public ParentObject Get()
        {
            return _container.Get<ParentObject>();
        }
    }
}