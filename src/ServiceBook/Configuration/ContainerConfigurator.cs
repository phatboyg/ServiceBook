namespace ServiceBook
{
    using BuilderConfigurators;

    public interface ContainerConfigurator
    {
        void AddConfigurator(CatalogBuilderConfigurator configurator);
        void AddConfigurator(ContainerBuilderConfigurator configurator);
    }
}