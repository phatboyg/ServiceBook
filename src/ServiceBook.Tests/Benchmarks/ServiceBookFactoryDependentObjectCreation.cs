namespace ServiceBook.Tests.Benchmarks
{
    using Factories;

    public class ServiceBookFactoryDependentObjectCreation :
        DependentObjectCreation
    {
        object _factory;


        public ParentObject Get()
        {
            if (_factory == null)
            {
                var other = new ConstructorFactory<DependentObject>(() => new DependentObject());
                var factory1 = new ConstructorFactory<ParentObject, DependentObject>(x => new ParentObject(x));
                _factory = new PartialFactory<ParentObject, DependentObject>(factory1, other);
            }
            var factory = (ServiceBook.Factory<ParentObject>)_factory;

            return factory.Get();
        }
    }
}