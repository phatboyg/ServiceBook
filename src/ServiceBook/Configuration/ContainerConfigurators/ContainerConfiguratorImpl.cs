namespace ServiceBook.ContainerConfigurators
{
    using System.Collections.Generic;
    using System.Linq;
    using BuilderConfigurators;
    using Builders;
    using Configurators;

    public class ContainerConfiguratorImpl :
        ContainerConfigurator,
        Configurator
    {
        readonly IList<ContainerBuilderConfigurator> _configurators = new List<ContainerBuilderConfigurator>();
        readonly IList<CatalogBuilderConfigurator> _catalogConfigurators = new List<CatalogBuilderConfigurator>();
        ContainerBuilderFactory _containerBuilderFactory = DefaultContainerBuilderFactory;

        public IEnumerable<ValidateConfigurationResult> ValidateConfiguration()
        {
            if (_containerBuilderFactory == null)
                yield return this.Failure("ContainerBuilderFactory", "must not be null");

            foreach (ValidateConfigurationResult result in _configurators.SelectMany(x => x.ValidateConfiguration()))
                yield return result.WithParentKey("Configurator");

            foreach (ValidateConfigurationResult result in _catalogConfigurators.SelectMany(x => x.ValidateConfiguration()))
                yield return result.WithParentKey("Configurator");
        }

        public void AddConfigurator(CatalogBuilderConfigurator configurator)
        {
            _catalogConfigurators.Add(configurator);
        }

        public void AddConfigurator(ContainerBuilderConfigurator configurator)
        {
            _configurators.Add(configurator);
        }

        static ContainerBuilder DefaultContainerBuilderFactory()
        {
            return new ContainerBuilderImpl();
        }

        public Container Create()
        {
            CatalogBuilder catalogBuilder = new CatalogBuilderImpl();

            catalogBuilder = _catalogConfigurators.Aggregate(catalogBuilder, (x, c) => c.Configure(x));

            catalogBuilder.Build();

            ContainerBuilder builder = _containerBuilderFactory();

            builder = _configurators.Aggregate(builder, (current, configurator) => configurator.Configure(current));

            return builder.Build();
        }
    }
}