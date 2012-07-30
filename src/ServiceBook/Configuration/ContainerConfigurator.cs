namespace ServiceBook
{
    using BuilderConfigurators;

    public interface ContainerConfigurator
    {
        void AddConfigurator(ContainerBuilderConfigurator configurator);
    }
}