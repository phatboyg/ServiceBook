namespace ServiceBook.BuilderConfigurators
{
    using Builders;
    using Configurators;

    public interface ContainerBuilderConfigurator :
        Configurator
    {
        ContainerBuilder Configure(ContainerBuilder builder);
    }
}