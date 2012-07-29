namespace ServiceBook.ContainerConfigurators
{
    using Builders;

    public class ContainerConfiguratorImpl :
        ContainerConfigurator
    {
        ContainerBuilderFactory _containerBuilderFactory;

        public ContainerConfiguratorImpl()
        {
            _containerBuilderFactory = DefaultContainerBuilderFactory;
        }

        ContainerBuilder DefaultContainerBuilderFactory()
        {
            return new ContainerBuilderImpl();
        }

        public Container Configure()
        {
            ContainerBuilder builder = _containerBuilderFactory();


            return builder.Build();
        }
    }
}