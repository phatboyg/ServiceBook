namespace ServiceBook
{
    using FactoryConfigurators;

    public static class TransientConfiguratorExtensions
    {
        public static TransientFactoryConfigurator<T> Transient<T>(this ContainerConfigurator configurator)
        {
            var factoryConfigurator = new TransientFactoryConfiguratorImpl<T>();

            configurator.AddConfigurator(factoryConfigurator);

            return factoryConfigurator;
        }
    }
}