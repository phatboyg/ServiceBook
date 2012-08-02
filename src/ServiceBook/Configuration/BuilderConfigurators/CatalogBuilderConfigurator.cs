namespace ServiceBook.BuilderConfigurators
{
    using Builders;
    using Configurators;

    public interface CatalogBuilderConfigurator :
        Configurator
    {
        CatalogBuilder Configure(CatalogBuilder builder);
    }
}