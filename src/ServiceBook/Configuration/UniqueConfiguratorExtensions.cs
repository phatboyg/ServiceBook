namespace ServiceBook
{
    using FactoryConfigurators;

    public static class UniqueConfiguratorExtensions
    {
        public static UniqueFactoryConfigurator<T> Unique<T>(this ContainerConfigurator configurator)
        {
            var factoryConfigurator = new UniqueFactoryConfiguratorImpl<T>();

            configurator.AddConfigurator(factoryConfigurator);

            return factoryConfigurator;
        }
    }
}